﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using OpenTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Game.Graphics.Sprites;

namespace osu.Game.Graphics.UserInterface
{
    public class OsuMenu : Menu
    {
        public OsuMenu()
        {
            CornerRadius = 4;
            BackgroundColour = Color4.Black.Opacity(0.5f);
        }

        protected override void AnimateOpen() => this.FadeIn(300, Easing.OutQuint);
        protected override void AnimateClose() => this.FadeOut(300, Easing.OutQuint);

        protected override void UpdateMenuHeight()
        {
            var actualHeight = (RelativeSizeAxes & Axes.Y) > 0 ? 1 : ContentHeight;
            this.ResizeHeightTo(State == MenuState.Opened ? actualHeight : 0, 300, Easing.OutQuint);
        }

        protected override MarginPadding ItemFlowContainerPadding => new MarginPadding(5);

        protected override DrawableMenuItem CreateDrawableMenuItem(MenuItem item) => new DrawableOsuMenuItem(item);

        protected class DrawableOsuMenuItem : DrawableMenuItem
        {
            private const int margin_horizontal = 17;
            private const int text_size = 17;
            private const int transition_length = 80;
            public const int MARGIN_VERTICAL = 4;

            private SampleChannel sampleClick;
            private SampleChannel sampleHover;

            private TextContainer text;

            public DrawableOsuMenuItem(MenuItem item)
                : base(item)
            {

            }

            [BackgroundDependencyLoader]
            private void load(AudioManager audio)
            {
                sampleHover = audio.Sample.Get(@"UI/generic-hover");
                sampleClick = audio.Sample.Get(@"UI/generic-click");

                BackgroundColour = Color4.Transparent;
                BackgroundColourHover = OsuColour.FromHex(@"172023");

                updateTextColour();
            }

            private void updateTextColour()
            {
                switch ((Item as OsuMenuItem)?.Type)
                {
                    default:
                    case MenuItemType.Standard:
                        text.Colour = Color4.White;
                        break;
                    case MenuItemType.Destructive:
                        text.Colour = Color4.Red;
                        break;
                    case MenuItemType.Highlighted:
                        text.Colour = OsuColour.FromHex(@"ffcc22");
                        break;
                }
            }

            protected override bool OnHover(InputState state)
            {
                sampleHover.Play();
                text.BoldText.FadeIn(transition_length, Easing.OutQuint);
                text.NormalText.FadeOut(transition_length, Easing.OutQuint);
                return base.OnHover(state);
            }

            protected override void OnHoverLost(InputState state)
            {
                text.BoldText.FadeOut(transition_length, Easing.OutQuint);
                text.NormalText.FadeIn(transition_length, Easing.OutQuint);
                base.OnHoverLost(state);
            }

            protected override bool OnClick(InputState state)
            {
                sampleClick.Play();
                return base.OnClick(state);
            }

            protected override Drawable CreateContent() => text = new TextContainer();

            private class TextContainer : Container, IHasText
            {
                public string Text
                {
                    get { return NormalText.Text; }
                    set
                    {
                        NormalText.Text = value;
                        BoldText.Text = value;
                    }
                }

                public readonly SpriteText NormalText;
                public readonly SpriteText BoldText;

                public TextContainer()
                {
                    Anchor = Anchor.CentreLeft;
                    Origin = Anchor.CentreLeft;

                    AutoSizeAxes = Axes.Both;

                    Children = new Drawable[]
                    {
                        NormalText = new OsuSpriteText
                        {
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                            TextSize = text_size,
                            Margin = new MarginPadding { Horizontal = margin_horizontal, Vertical = MARGIN_VERTICAL },
                        },
                        BoldText = new OsuSpriteText
                        {
                            AlwaysPresent = true,
                            Alpha = 0,
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                            TextSize = text_size,
                            Font = @"Exo2.0-Bold",
                            Margin = new MarginPadding { Horizontal = margin_horizontal, Vertical = MARGIN_VERTICAL },
                        }
                    };
                }
            }
        }
    }
}

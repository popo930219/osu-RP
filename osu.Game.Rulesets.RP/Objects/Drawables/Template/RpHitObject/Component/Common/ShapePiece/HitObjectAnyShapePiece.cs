﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common.ShapePiece
{
    /// <summary>
    ///     ������������
    ///     �ڑO��ܕ�� : �����I�󕨌�
    /// </summary>
    internal class HitObjectAnyShapePiece : BaseHitObjectShapePiece
    {
        public bool IsFirst = true;

        /// <summary>
        ///     �O�y
        /// </summary>
        private readonly ImagePicec _borderImagePicec;

        /// <summary>
        ///     Mask
        /// </summary>
        private ImagePicec _maskImagePicec;

        /// <summary>
        ///     Mask �ꉺ�I�w�i����
        /// </summary>
        private ImagePicec _startBackgroundImagePicec;


        /// <summary>
        ///     ���\
        /// </summary>
        public HitObjectAnyShapePiece(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                /*
                _startBackgroundImagePicec = new ImagePicec(RpTexturePathManager.GetStartObjectBackgroundByType(HitObject as BaseRpHitableObject))
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,

                    Colour = RpTextureColorManager.GetKeyLayoutButtonShage(((BaseRpHitableObject)HitObject).Shape),
                    Scale = new Vector2(0.5f),
                    CornerRadius = DrawSize.X / 2,
                    Masking = true
                },

                ////�ڑO���wmask���L�p�r
                _maskImagePicec = new ImagePicec(RpTexturePathManager.GetStartObjectMaskByType(HitObject as BaseRpHitableObject))
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,

                    //Colour = osuObject.Colour,
                    Scale = new Vector2(0.5f),
                    Masking = true
                },
                */

                //�O�y�g�p
                _borderImagePicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(HitObject as BaseRpHitableObject))
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,

                    Colour = RpTextureColorManager.GetKeyLayoutButtonShage(((BaseRpHitableObject)HitObject).Shape),
                    Scale = new Vector2(0.5f)
                }
            };
        }

        /// <summary>
        ///     ���n������
        /// </summary>
        public override void Initial()
        {
        }

        /// <summary>
        ///     �J�n����
        /// </summary>
        public override void FadeIn(double time = 0)
        {
        }

        /// <summary>
        ///     ����
        /// </summary>
        public override void FadeOut(double time = 0)
        {
        }
    }
}

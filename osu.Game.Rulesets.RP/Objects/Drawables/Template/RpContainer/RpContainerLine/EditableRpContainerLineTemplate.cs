﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.CommonInterface;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer.RpContainerLine
{
    public class EditableRpContainerLineTemplate : RpContainerLineTemplate , IContainerEditableTemplate
    {
        public EditableRpContainerLineTemplate(DrawableRpContainerLine drawablehitObject): base(drawablehitObject)
        {
        }
    }
}

﻿//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Rulesets.RP.Objects.type;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     可以往左邊�E是右邊長壓滑動
    /// </summary>
    public class RpContainerLineHoldObject : BaseRpHitableObject
    {
        /// <summary>
        ///     初始化預設物件
        /// </summary>
        public override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
            ObjectType = RpBaseObjectType.ObjectType.ContainerPress;
        }
    }
}

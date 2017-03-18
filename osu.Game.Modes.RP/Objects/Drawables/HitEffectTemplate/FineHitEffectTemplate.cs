﻿using OpenTK;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Modes.RP.Objects.Drawables.HitEffectTemplate
{
    class FineHitEffectTemplate :BaseHitEffectTemplate
    {
        /// <summary>
        /// 目前結果
        /// </summary>
        protected new RPScoreResult RPScoreResult = RPScoreResult.Fine;

        /// <summary>
        /// 白色十字
        /// </summary>
        ImagePicec _crossPicec;

        /// <summary>
        /// 白色十字
        /// </summary>
        ImagePicec _effectPicec;

        /// <summary>
        /// 有音樂形狀那個icon
        /// </summary>
        ImagePicec _onpuPicec;

        public FineHitEffectTemplate()
        {
            Children = new Drawable[]
            {
                _crossPicec = new ImagePicec(SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult,"Cross"))
                {
                    //Colour = osuObject.Colour,
                    Position=new Vector2(0,0),
                    Scale=new Vector2(1,1),
                },
                _effectPicec = new ImagePicec(SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult,"Slide_effect"))
                {
                    //Colour = osuObject.Colour,
                    Position=new Vector2(0,0),
                    Scale=new Vector2(1,1),
                },
                _onpuPicec = new ImagePicec(SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult,"RP"))
                {
                    //Colour = osuObject.Colour,
                    Position=new Vector2(0,0),
                    Scale=new Vector2(1,1),
                },
            };
        }

        public override void StartEffect()
        {
            //透明度
            _crossPicec.FadeTo(0.7f, 0);
            _crossPicec.FadeTo(0.7f, 250);
            _crossPicec.FadeTo(0f, 300);
            //scale
            _crossPicec.Scale = new Vector2(0.8f);
            _crossPicec.ScaleTo(1.6f, 200);
            _crossPicec.ScaleTo(1.6f, 220);

            _crossPicec.RotateTo(-30, 220);

            //透明度
            _effectPicec.FadeTo(0.7f, 0);
            _effectPicec.FadeTo(0.7f, 250);
            _effectPicec.FadeTo(0f, 300);
            //scale
            _effectPicec.Scale = new Vector2(0.8f);
            _effectPicec.ScaleTo(2f, 50);
            _effectPicec.ScaleTo(2f, 150);

            //透明度
            _onpuPicec.FadeTo(0.8f, 0);
            _onpuPicec.FadeTo(0.8f, 350);
            _onpuPicec.FadeTo(0f, 400);
            //scale
            _onpuPicec.Scale = new Vector2(1f);
            _onpuPicec.ScaleTo(1.8f, 200);
            _onpuPicec.ScaleTo(1.8f, 220);
        }
    }
}

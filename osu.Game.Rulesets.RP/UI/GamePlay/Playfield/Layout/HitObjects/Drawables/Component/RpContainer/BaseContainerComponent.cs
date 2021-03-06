using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Position;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpContainer
{
    public class BaseContainerComponent : BaseComponent
    {
        /// <summary>
        /// </summary>
        public new Objects.RpContainerLineGroup HitObject;

        /// <summary>
        ///     ΣvZ¨έΤκyYLIΚu
        /// </summary>
        protected readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        public BaseContainerComponent(Objects.RpContainerLineGroup hitObject)
        {
            HitObject = hitObject;
            InitialObject();
            InitialChild();
        }

        /// <summary>
        ///     XVVI LayoutΙΚ
        /// </summary>
        /// <param name="newLayerNumber"></param>
        public virtual void UpdateLayerNumber()
        {
            //Ώn ObjectContainer ‘Κζ€ζ
        }

        /// <summary>
        ///     @ΚXVΉJn½₯©IΤ
        /// </summary>
        public virtual void UpdateTime()
        {
        }


        /// <summary>
        ///     n»Lθϋ¦¨
        /// </summary>
        protected virtual void InitialObject(int layerCount = 1)
        {
        }

        /// <summary>
        ///     n»Lθϋ¦¨
        /// </summary>
        protected virtual void InitialChild()
        {
        }

        /// <summary>
        ///     ͺΤκyvZ¨Κu
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        protected Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time, HitObject.Velocity), 0);
        }

        /// <summary>
        ///     ζΎΤuΤ
        /// </summary>
        /// <returns></returns>
        protected double GetDeltaBeatTime()
        {
            return 1000 * 60 / HitObject.BPM;
        }
    }
}

namespace Entitas {
    public partial class Entity {
        public MyEnumComponent myEnum { get { return (MyEnumComponent)GetComponent(ComponentIds.MyEnum); } }

        public bool hasMyEnum { get { return HasComponent(ComponentIds.MyEnum); } }

        public Entity AddMyEnum(MyEnumComponent.MyEnum newMyEnum) {
            var componentPool = GetComponentPool(ComponentIds.MyEnum);
            var component = (MyEnumComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MyEnumComponent());
            component.myEnum = newMyEnum;
            return AddComponent(ComponentIds.MyEnum, component);
        }

        public Entity ReplaceMyEnum(MyEnumComponent.MyEnum newMyEnum) {
            var componentPool = GetComponentPool(ComponentIds.MyEnum);
            var component = (MyEnumComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MyEnumComponent());
            component.myEnum = newMyEnum;
            ReplaceComponent(ComponentIds.MyEnum, component);
            return this;
        }

        public Entity RemoveMyEnum() {
            return RemoveComponent(ComponentIds.MyEnum);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMyEnum;

        public static IMatcher MyEnum {
            get {
                if (_matcherMyEnum == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.MyEnum);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMyEnum = matcher;
                }

                return _matcherMyEnum;
            }
        }
    }
}
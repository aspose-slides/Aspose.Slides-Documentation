---
title: Aspose.Slides for Java 14.7.0 的公共 API 和不兼容的更改
type: docs
weight: 60
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

此页面列出所有[新增的](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)类、方法、属性等，以及在 Aspose.Slides for Java 14.7.0 API 中引入的任何新限制和其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **某些 TransitionValueBase 子类型的构造函数已被删除，TransitionValueFactory 已被删除**
某些 TransitionValueBase 子类型（特别是 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）的构造函数在公共 API 中没有用，因此已被删除。相关类 TransitionValueFactory 及其接口 ITransitionValueFactory 也由于同样原因被删除。
### **元素 SoundAction 已从 com.aspose.slides.TransitionType 枚举中删除**
元素 SoundAction 是不正确且没有使用的。音频设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。
### **FlyThroughTransition 类和 IFlyThroughTransition 接口已添加**
com.aspose.slides.FlyThroughTransition 类（及其接口 com.aspose.slides.IFlyThroughTransition）与此版本支持的 Flythrough 转换类型相关。
### **GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举已添加**
com.aspose.slides.GlitterTransition 类（及其接口 com.aspose.slides.IGlitterTransition）与此版本支持的 Glitter 转换类型相关。
com.aspose.slides.TransitionPattern 枚举在此类中使用，用于指定一个几何图形，该图形拼合在一起以填充更大的区域。
### **LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举已添加**
com.aspose.slides.LeftRightDirectionTransition 类（及其接口 com.aspose.slides.ILeftRightDirectionTransition）与此版本支持的 Switch、Flip、Ferris、Gallery、Conveyor 转换类型相关。
com.aspose.slides.TransitionLeftRightDirectionType 枚举在此类中使用，指定一个仅限于左和右的方向。
### **新元素已添加到 com.aspose.slides.TransitionType 枚举中**
com.aspose.slides.TransitionType 枚举已扩展到新元素。
新元素与新的 PowerPoint 2010 转场相关：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。
新元素与新的 PowerPoint 2013 转场相关：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **RevealTransition 类和 IRevealTransition 接口已添加**
com.aspose.slides.RevealTransition 类（及其接口 com.aspose.slides.IRevealTransition）与此版本支持的 Reveal 转换类型相关。
RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举已添加
com.aspose.slides.RippleTransition 类（及其接口 com.aspose.slides.IRippleTransition）与此版本支持的 Ripple 转换类型相关。
com.aspose.slides.TransitionCornerAndCenterDirectionType 枚举在此类中使用，指定一个仅限于角和中心的方向。
### **ShredTransition 类、IShredTransition 接口和 TransitionShredPattern 枚举已添加**
com.aspose.slides.ShredTransition 类（及其接口 com.aspose.slides.IShredTransition）与此版本支持的 Shred 转换类型相关。
com.aspose.slides.TransitionShredPattern 枚举在此类中使用，指定一个几何形状，该形状拼合在一起以填充更大的区域。
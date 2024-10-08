---
title: Aspose.Slides for PHP via Java 14.7.0 中的公共 API 和不兼容的更改
type: docs
weight: 60
url: /zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

本页列出了所有在 Aspose.Slides for PHP via Java 14.7.0 API 中新增的 [类](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)、方法、属性等，以及任何新限制和其他变更。

{{% /alert %}} 
## **公共 API 更改**
### **某些 TransitionValueBase 子类型的构造函数已被移除，TransitionValueFactory 已被移除**
某些 TransitionValueBase 子类型（具体是 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）的构造函数在公共 API 中无用，因此已被移除。相关类 TransitionValueFactory 和其接口 ITransitionValueFactory 也因同样原因被移除。
### **Element SoundAction 已从 com.aspose.slides.TransitionType 枚举中移除**
Element SoundAction 是不正确且未使用的。声音设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。
### **FlyThroughTransition 类和 IFlyThroughTransition 接口已被添加**
com.aspose.slides.FlyThroughTransition 类（及其接口 com.aspose.slides.IFlyThroughTransition）涉及到本次发布支持的 Flythrough 过渡类型。
### **GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举已被添加**
com.aspose.slides.GlitterTransition 类（及其接口 com.aspose.slides.IGlitterTransition）涉及到本次发布支持的 Glitter 过渡类型。
com.aspose.slides.TransitionPattern 枚举在此类中使用，并指定一个几何图案，用于填充更大的区域。
### **LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举已被添加**
com.aspose.slides.LeftRightDirectionTransition 类（及其接口 com.aspose.slides.ILeftRightDirectionTransition）涉及到本次发布支持的 Switch、Flip、Ferris、Gallery、Conveyor 过渡类型。
com.aspose.slides.TransitionLeftRightDirectionType 枚举在此类中使用，并指定方向仅限于左和右的值。
### **com.aspose.slides.TransitionType 枚举中新增元素**
com.aspose.slides.TransitionType 枚举已扩展为新增元素。
与新的 PowerPoint 2010 转场相关的新元素：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。
与新的 PowerPoint 2013 转场相关的新元素：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **RevealTransition 类和 IRevealTransition 接口已被添加**
com.aspose.slides.RevealTransition 类（及其接口 com.aspose.slides.IRevealTransition）涉及到本次发布支持的 Reveal 过渡类型。
RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举已被添加
com.aspose.slides.RippleTransition 类（及其接口 com.aspose.slides.IRippleTransition）涉及到本次发布支持的 Ripple 过渡类型。
com.aspose.slides.TransitionCornerAndCenterDirectionType 枚举在此类中使用，并指定方向仅限于角落和中心。
### **ShredTransition 类、IShredTransition 接口和 TransitionShredPattern 枚举已被添加**
com.aspose.slides.ShredTransition 类（及其接口 com.aspose.slides.IShredTransition）涉及到本次发布支持的 Shred 过渡类型。
com.aspose.slides.TransitionShredPattern 枚举在此类中使用，并指定几何形状，用于填充更大的区域。
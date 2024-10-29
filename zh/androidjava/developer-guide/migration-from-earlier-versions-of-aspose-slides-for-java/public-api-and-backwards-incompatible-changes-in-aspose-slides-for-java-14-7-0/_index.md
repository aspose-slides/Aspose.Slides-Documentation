---
title: Aspose.Slides for Java 14.7.0 的公共 API 和不兼容的更改
type: docs
weight: 60
url: /zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 14.7.0 API 中添加的类、方法、属性等，以及任何新的限制和其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **某些 TransitionValueBase 子类型的构造函数已被移除，TransitionValueFactory 已被移除**
某些 TransitionValueBase 子类型（特别是 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）的构造函数在公共 API 中已无用，因此已被移除。相关类 TransitionValueFactory 及其接口 ITransitionValueFactory 也因同样的原因被移除。
### **com.aspose.slides.TransitionType 枚举中的元素 SoundAction 已被移除**
元素 SoundAction 是不正确且未使用的。声音设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。
### **FlyThroughTransition 类和 IFlyThroughTransition 接口已添加**
com.aspose.slides.FlyThroughTransition 类（及其接口 com.aspose.slides.IFlyThroughTransition）与此版本中支持的 Flythrough 过渡类型相关。
### **GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举已添加**
com.aspose.slides.GlitterTransition 类（及其接口 com.aspose.slides.IGlitterTransition）与此版本中支持的 Glitter 过渡类型相关。com.aspose.slides.TransitionPattern 枚举在此类中使用，并指定填充更大区域的几何图案。
### **LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举已添加**
com.aspose.slides.LeftRightDirectionTransition 类（及其接口 com.aspose.slides.ILeftRightDirectionTransition）与此版本中支持的 Switch、Flip、Ferris、Gallery、Conveyor 过渡类型相关。com.aspose.slides.TransitionLeftRightDirectionType 枚举在此类中使用，并指定限制为左和右的方向值。
### **com.aspose.slides.TransitionType 枚举中已添加新元素**
com.aspose.slides.TransitionType 枚举已扩展新元素。与新的 PowerPoint 2010 过渡相关的新元素包括：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。与新的 PowerPoint 2013 过渡相关的新元素包括：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **RevealTransition 类和 IRevealTransition 接口已添加**
com.aspose.slides.RevealTransition 类（及其接口 com.aspose.slides.IRevealTransition）与此版本中支持的 Reveal 过渡类型相关。RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举已添加。com.aspose.slides.RippleTransition 类（及其接口 com.aspose.slides.IRippleTransition）与此版本中支持的 Ripple 过渡类型相关。com.aspose.slides.TransitionCornerAndCenterDirectionType 枚举在此类中使用，并指定限制在角落和中心的方向。
### **ShredTransition 类、IShredTransition 接口和 TransitionShredPattern 枚举已添加**
com.aspose.slides.ShredTransition 类（及其接口 com.aspose.slides.IShredTransition）与此版本中支持的 Shred 过渡类型相关。com.aspose.slides.TransitionShredPattern 枚举在此类中使用，并指定填充更大区域的几何形状。
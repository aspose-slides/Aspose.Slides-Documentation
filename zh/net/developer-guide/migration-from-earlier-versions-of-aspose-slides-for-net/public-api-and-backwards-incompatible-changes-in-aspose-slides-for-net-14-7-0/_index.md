---
title: Aspose.Slides for .NET 14.7.0 的公共 API 和向后不兼容变更
type: docs
weight: 90
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

此页面列出了所有 [新增](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) 或 [移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) 的类、方法、属性等，以及与 Aspose.Slides for .NET 14.7.0 API 一起引入的其他变更。

{{% /alert %}} 
## **公共 API 变更**
### **移除的构造函数和元素**
#### **移除部分 TransitionValueBase 子类型构造函数和 TransitionValueFactory**
某些 TransitionValueBase 子类型的构造函数（具体为 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）在公共 API 中是无用的，因此已被移除。

相关的类 TransitionValueFactory 及其接口 ITransitionValueFactory 也因同样原因被移除。
#### **从 Aspose.Slides.SlideShow.TransitionType 枚举中移除 SoundAction 元素**
SoundAction 元素是不正确的且未使用。声音设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。
### **新增的类和接口**
#### **新增 FlyThroughTransition 类及 IFlyThroughTransition 接口**
Aspose.Slides.SlideShow.FlyThroughTransition 类（及其接口 Aspose.Slides.SlideShow.IFlyThroughTransition）与此次发布支持的 Flythrough 转场类型相关。
#### **新增 GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举**
Aspose.Slides.SlideShow.GlitterTransition 类（及其接口 Aspose.Slides.SlideShow.IGlitterTransition）与此次发布支持的 Glitter 转场类型相关。

Aspose.Slides.SlideShow.TransitionPattern 枚举在此类中使用，指定一个几何图案，该图案可以拼接在一起以填充更大的区域。
#### **新增 LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举**
Aspose.Slides.SlideShow.LeftRightDirectionTransition 类（及其接口 Aspose.Slides.SlideShow.ILeftRightDirectionTransition）与此发布支持的 Conveyer、Ferris、Flip、Gallery 和 Switch 等转场类型相关。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 枚举在此类中使用，指定一个方向，仅限于左和右的值。
#### **为 Aspose.Slides.SlideShow.TransitionType 枚举新增元素**
Aspose.Slides.SlideShow.TransitionType 枚举已扩展以包含新元素。

- 与 PowerPoint 2010 转场相关的新元素：Box、Conveyor、Cube、Doors、Ferris、Flash、Flip、Flythrough、Gallery、Glitter、Honeycomb、Orbit、Pan、Reveal、Ripple、Rotate、Shred、Switch、Vortex、Warp、WheelReverse、Window。
- 与新的 PowerPoint 2013 转场相关的新元素：Airplane、Crush、Curtains、Drape、FallOver、Fracture、Origami、PageCurlDouble、PageCurlSingle、PeelOff、Prestige、Wind。
#### **新增 RevealTransition 类和 IRevealTransition 接口**
Aspose.Slides.SlideShow.RevealTransition 类（及其接口 Aspose.Slides.SlideShow.IRevealTransition）与此次发布支持的 Reveal 转场类型相关。
#### **新增 RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举**
Aspose.Slides.SlideShow.RippleTransition 类（及其接口 Aspose.Slides.SlideShow.IRippleTransition）与此次发布支持的 Ripple 转场类型相关。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 枚举在此类中使用，指定一个方向，仅限于角落和中心。
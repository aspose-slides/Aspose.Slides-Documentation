---
title: Aspose.Slides for .NET 14.7.0 中的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)或[已删除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 14.7.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **已删除的构造函数和元素**
#### **已删除某些 TransitionValueBase 子类型的构造函数和 TransitionValueFactory**
某些 TransitionValueBase 子类型的构造函数（具体为 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）在公共 API 中已无用，因此已被删除。

相关类 TransitionValueFactory 及其接口 ITransitionValueFactory 也因同样原因被删除。
#### **已从 Aspose.Slides.SlideShow.TransitionType 枚举中删除 SoundAction 元素**
SoundAction 元素不正确且未使用。声音设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。
### **添加的类和接口**
#### **添加了 FlyThroughTransition 类和 IFlyThroughTransition 接口**
Aspose.Slides.SlideShow.FlyThroughTransition 类（及其接口 Aspose.Slides.SlideShow.IFlyThroughTransition）对应本次发行版支持的 Flythrough 转场类型。
#### **添加了 GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举**
Aspose.Slides.SlideShow.GlitterTransition 类（及其接口 Aspose.Slides.SlideShow.IGlitterTransition）对应本次发行版支持的 Glitter 转场类型。

Aspose.Slides.SlideShow.TransitionPattern 枚举在该类中使用，用于指定几何图案以平铺填充更大区域。
#### **添加了 LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举**
Aspose.Slides.SlideShow.LeftRightDirectionTransition 类（及其接口 Aspose.Slides.SlideShow.ILeftRightDirectionTransition）对应本次发行版支持的 Conveyor、Ferris、Flip、Gallery 和 Switch 转场类型。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 枚举在该类中使用，用于指定仅限 left 和 right 的方向。
#### **向 Aspose.Slides.SlideShow.TransitionType 枚举添加了新元素**
Aspose.Slides.SlideShow.TransitionType 枚举已扩展新元素。

- 与 PowerPoint 2010 转场相关的新元素：Box、Conveyor、Cube、Doors、Ferris、Flash、Flip、Flythrough、Gallery、Glitter、Honeycomb、Orbit、Pan、Reveal、Ripple、Rotate、Shred、Switch、Vortex、Warp、WheelReverse、Window。
- 与 PowerPoint 2013 新转场相关的新元素：Airplane、Crush、Curtains、Drape、FallOver、Fracture、Origami、PageCurlDouble、PageCurlSingle、PeelOff、Prestige、Wind。
#### **添加了 RevealTransition 类和 IRevealTransition 接口**
Aspose.Slides.SlideShow.RevealTransition 类（及其接口 Aspose.Slides.SlideShow.IRevealTransition）对应本次发行版支持的 Reveal 转场类型。
#### **添加了 RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举**
Aspose.Slides.SlideShow.RippleTransition 类（及其接口 Aspose.Slides.SlideShow.IRippleTransition）对应本次发行版支持的 Ripple 转场类型。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 枚举在该类中使用，用于指定仅限角落和中心的方向。
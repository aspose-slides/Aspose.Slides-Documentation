---
title: Aspose.Slides for .NET 14.7.0 的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "回顾 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有在 Aspose.Slides for .NET 14.7.0 API 中添加的[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **已移除的构造函数和元素**
#### **已移除部分 TransitionValueBase 子类型构造函数和 TransitionValueFactory**
某些 TransitionValueBase 子类型的构造函数（具体包括 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）在公共 API 中无实际作用，已被移除。

出于同样原因，相关类 TransitionValueFactory 及其接口 ITransitionValueFactory 也已移除。
#### **已从 Aspose.Slides.SlideShow.TransitionType 枚举中移除 SoundAction 元素**
SoundAction 元素不正确且未被使用。声音设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。
### **添加的类和接口**
#### **添加了 FlyThroughTransition 类和 IFlyThroughTransition 接口**
Aspose.Slides.SlideShow.FlyThroughTransition 类（及其接口 Aspose.Slides.SlideShow.IFlyThroughTransition）对应本次发布支持的 Flythrough 过渡类型。
#### **添加了 GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举**
Aspose.Slides.SlideShow.GlitterTransition 类（及其接口 Aspose.Slides.SlideShow.IGlitterTransition）对应本次发布支持的 Glitter 过渡类型。

Aspose.Slides.SlideShow.TransitionPattern 枚举在该类中使用，用于指定几何图案以平铺填充更大区域。
#### **添加了 LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举**
Aspose.Slides.SlideShow.LeftRightDirectionTransition 类（及其接口 Aspose.Slides.SlideShow.ILeftRightDirectionTransition）对应 Conveyor、Ferris、Flip、Gallery 和 Switch 过渡类型，全部在本次发布中支持。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 枚举在该类中使用，限定方向为 left 或 right。
#### **向 Aspose.Slides.SlideShow.TransitionType 枚举添加了新元素**
Aspose.Slides.SlideShow.TransitionType 枚举已扩展，新增元素包括：

- 与 PowerPoint 2010 过渡相关的新元素：Box、Conveyor、Cube、Doors、Ferris、Flash、Flip、Flythrough、Gallery、Glitter、Honeycomb、Orbit、Pan、Reveal、Ripple、Rotate、Shred、Switch、Vortex、Warp、WheelReverse、Window。
- 与 PowerPoint 2013 新过渡相关的新元素：Airplane、Crush、Curtains、Drape、FallOver、Fracture、Origami、PageCurlDouble、PageCurlSingle、PeelOff、Prestige、Wind。
#### **添加了 RevealTransition 类和 IRevealTransition 接口**
Aspose.Slides.SlideShow.RevealTransition 类（及其接口 Aspose.Slides.SlideShow.IRevealTransition）对应本次发布支持的 Reveal 过渡类型。
#### **添加了 RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举**
Aspose.Slides.SlideShow.RippleTransition 类（及其接口 Aspose.Slides.SlideShow.IRippleTransition）对应本次发布支持的 Ripple 过渡类型。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 枚举在该类中使用，限定方向为角落和中心。
---
title: Aspose.Slides for .NET 14.7.0 的公共 API 及向后不兼容更改
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
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)的类、方法、属性等，并介绍了 Aspose.Slides for .NET 14.7.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **已移除的构造函数和元素**
#### **已移除某些 TransitionValueBase 子类型的构造函数和 TransitionValueFactory**
某些 TransitionValueBase 子类型（具体包括 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）的构造函数在公共 API 中没有作用，已被移除。

相关的 TransitionValueFactory 类及其接口 ITransitionValueFactory 也因同样原因被移除。
#### **已从 Aspose.Slides.SlideShow.TransitionType 枚举中移除 SoundAction 元素**
SoundAction 元素不正确且未被使用。声音设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。
### **新增的类和接口**
#### **新增 FlyThroughTransition 类和 IFlyThroughTransition 接口**
Aspose.Slides.SlideShow.FlyThroughTransition 类（及其接口 Aspose.Slides.SlideShow.IFlyThroughTransition）对应本次发布支持的 Flythrough 过渡类型。
#### **新增 GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举**
Aspose.Slides.SlideShow.GlitterTransition 类（及其接口 Aspose.Slides.SlideShow.IGlitterTransition）对应本次发布支持的 Glitter 过渡类型。

Aspose.Slides.SlideShow.TransitionPattern 枚举在该类中使用，指定用于填充更大面积的几何图案。
#### **新增 LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举**
Aspose.Slides.SlideShow.LeftRightDirectionTransition 类（及其接口 Aspose.Slides.SlideShow.ILeftRightDirectionTransition）对应 Conveyor、Ferris、Flip、Gallery 和 Switch 过渡类型，全部从本次发布开始支持。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 枚举在该类中使用，指定方向，仅限 left 和 right 两个取值。
#### **向 Aspose.Slides.SlideShow.TransitionType 枚举添加了新元素**
Aspose.Slides.SlideShow.TransitionType 枚举已扩展新元素。

- 与 PowerPoint 2010 过渡相关的新元素：Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window。
- 与新 PowerPoint 2013 过渡相关的新元素：Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind。
#### **新增 RevealTransition 类和 IRevealTransition 接口**
Aspose.Slides.SlideShow.RevealTransition 类（及其接口 Aspose.Slides.SlideShow.IRevealTransition）对应本次发布支持的 Reveal 过渡类型。
#### **新增 RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举**
Aspose.Slides.SlideShow.RippleTransition 类（及其接口 Aspose.Slides.SlideShow.IRippleTransition）对应本次发布支持的 Ripple 过渡类型。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 枚举在该类中使用，指定方向，仅限角落和中心。
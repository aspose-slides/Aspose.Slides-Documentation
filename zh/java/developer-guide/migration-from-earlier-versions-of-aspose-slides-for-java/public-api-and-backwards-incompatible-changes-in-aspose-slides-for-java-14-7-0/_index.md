---
title: Aspose.Slides for Java 14.7.0 的公共 API 及向后不兼容更改
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

本页列出所有[已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)的类、方法、属性等内容，以及 Aspose.Slides for Java 14.7.0 API 引入的任何新限制和其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **已删除某些 TransitionValueBase 子类型的构造函数，且已删除 TransitionValueFactory**
某些 TransitionValueBase 子类型的构造函数（特别是 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）在公共 API 中无用，已被删除。相关类 TransitionValueFactory 及其接口 ITransitionValueFactory 也因同样原因被移除。

### **已从 com.aspose.slides.TransitionType 枚举中移除元素 SoundAction**
元素 SoundAction 不正确且未使用。声音设置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 属性定义。

### **已添加 FlyThroughTransition 类和 IFlyThroughTransition 接口**
com.aspose.slides.FlyThroughTransition 类（及其接口 com.aspose.slides.IFlyThroughTransition）对应本次发布支持的 Flythrough 转场类型。

### **已添加 GlitterTransition 类、IGlitterTransition 接口和 TransitionPattern 枚举**
com.aspose.slides.GlitterTransition 类（及其接口 com.aspose.slides.IGlitterTransition）对应本次发布支持的 Glitter 转场类型。com.aspose.slides.TransitionPattern 枚举在该类中使用，用于指定几何图案以平铺填充更大区域。

### **已添加 LeftRightDirectionTransition 类、ILeftRightDirectionTransition 接口和 TransitionLeftRightDirectionType 枚举**
com.aspose.slides.LeftRightDirectionTransition 类（及其接口 com.aspose.slides.ILeftRightDirectionTransition）对应本次发布支持的 Switch、Flip、Ferris、Gallery、Conveyor 转场类型。com.aspose.slides.TransitionLeftRightDirectionType 枚举在该类中使用，指定仅限 left 和 right 两个值的方向。

### **已向 com.aspose.slides.TransitionType 枚举中添加新元素**
com.aspose.slides.TransitionType 枚举已扩展新元素。  
与 PowerPoint 2010 新转场相关的元素：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。  
与 PowerPoint 2013 新转场相关的元素：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。

### **已添加 RevealTransition 类和 IRevealTransition 接口**
com.aspose.slides.RevealTransition 类（及其接口 com.aspose.slides.IRevealTransition）对应本次发布支持的 Reveal 转场类型。

RippleTransition 类、IRippleTransition 接口和 TransitionCornerAndCenterDirectionType 枚举已添加  
com.aspose.slides.RippleTransition 类（及其接口 com.aspose.slides.IRippleTransition）对应本次发布支持的 Ripple 转场类型。com.aspose.slides.TransitionCornerAndCenterDirectionType 枚举在该类中使用，指定仅限角落和中心的方向。

### **已添加 ShredTransition 类、IShredTransition 接口和 TransitionShredPattern 枚举**
com.aspose.slides.ShredTransition 类（及其接口 com.aspose.slides.IShredTransition）对应本次发布支持的 Shred 转场类型。com.aspose.slides.TransitionShredPattern 枚举在该类中使用，指定几何形状以平铺填充更大区域。
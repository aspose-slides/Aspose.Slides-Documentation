---
title: 检索和更新 .NET 中的演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/net/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单一视图
- 栏状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 配置 PowerPoint 演示文稿中的普通视图布局、幻灯片和备注的缩放、网格间距以及批注可见性。"
---
## **简介**

在 PowerPoint 的普通视图中，幻灯片位于缩略图或大纲的侧窗格与下面的备注窗格之间。Aspose.Slides for .NET 通过 [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) 公开演示文稿保存的编辑首选项。这些包括窗格布局、缩放级别、网格间距和批注可见性。

## **关于 INormalViewProperties**

使用 [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) 访问 [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) 接口。[ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) 控制是否在大纲中的幻灯片标题旁显示图标。[SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) 允许在用户缩窄时将侧窗格捕捉到其最小化状态。[PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) 指示在整个窗口中显示单个窗格的首选项。

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) 控制侧窗格与幻灯片之间的分隔条。[HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) 控制备注窗格上方的分隔条。这两个属性都接受 [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) 的 `Minimized`、`Maximized` 或 `Restored` 值。

## **关于恢复 INormalViewProperties**

当分隔条被恢复时，[RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) 提供侧窗格的已保存尺寸，且 [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) 提供上部幻灯片区域的已保存尺寸。两者都公开 [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/)。其 [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) 属性接受 0 到 100 的百分比，且 [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) 控制编辑器在窗口大小改变时是否调整尺寸。

此示例更新现有演示文稿。它恢复水平分隔条，将 [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) 设置为 80% 并启用自动调整，并将垂直分隔条最大化。它还为大纲视图启用 [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/)。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **设置默认缩放值**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) 和 [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) 为编辑器存储独立的缩放设置。这些设置不影响幻灯片尺寸、幻灯片放映播放或图像导出分辨率。

此示例打开现有演示文稿，并启用 [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) 以使幻灯片适应编辑窗口。对于备注页面，它禁用自动缩放并将 [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) 设置为固定的 80% 缩放。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **设置网格间距**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) 设置整个演示文稿中编辑网格线之间的距离。它采用以点为单位的正数值，1 英寸等于 72 点。此示例打印现有演示文稿中的当前间距，并通过将间隔设为 18 点来保存四分之一英寸的网格。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

网格以固定间隔重复。[Drawing guides](/slides/zh/net/drawing-guides/) 标记各个水平或垂直位置。这两者都是编辑辅助，仅在显示它们的编辑器中出现。幻灯片放映以及导出为 PDF、图像或 SVG 时会省略它们。

## **打开演示文稿时显示或隐藏批注**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) 存储兼容编辑器在打开演示文稿时使用的首选项。对于带有批注的现有演示文稿，此示例打印当前设置并保存一个批注隐藏的副本。它还将 [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) 设置为 [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/)，使该副本以幻灯片视图打开。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

隐藏批注会保留其文本、作者、位置、回复和状态。如需更改批注本身，请参阅 [Presentation Comments](/slides/zh/net/presentation-comments/)。导出设置控制批注是否出现在 PDF、HTML、图像、备注或讲义中。

## **常见问题**

**为什么重新打开演示文稿时网格会隐藏？**

演示文稿保存了网格间隔。要查看网格，请在编辑器中启用网格可见性。

**清除绘图指南会改变网格间距吗？**

不会。添加、移动或清除指南都不会改变网格间隔。

**演示文稿的不同章节可以有不同的视图设置吗？**

不能。[Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) 适用于整个演示文稿。

**我可以为不同用户保存不同的视图设置吗？**

文件为所有用户存储一套视图属性。编辑器还可能应用用户的本地首选项。

**我可以在模板中保存视图设置吗？**

可以。从模板创建的演示文稿会继承其保存的视图设置。
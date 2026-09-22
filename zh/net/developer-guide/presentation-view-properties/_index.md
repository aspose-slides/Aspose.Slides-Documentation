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
description: "了解 Aspose.Slides for .NET 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。属性涉及不同内容区域的位置。这些信息允许应用程序将视图状态保存到文件中，以便重新打开时视图保持与上次保存时相同的状态。

已添加属性[IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/iviewproperties/properties/normalviewproperties)，以提供对演示文稿普通视图属性的访问。

已添加[INormalViewProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/inormalviewrestoredproperties)接口及其派生类型，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh/net/aspose.slides/splitterbarstatetype)枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

属性**ShowOutlineIcons**指定当在普通视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

属性**SnapVerticalSplitter**指定当侧边区域足够小时时，垂直分割条是否应自动捕捉到最小化状态。

属性**PreferSingleView**指定用户是否更倾向于在整个窗口中查看单一内容区域，而非包含三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性**VerticalBarState**和**HorizontalBarState**指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的值有：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized**和**SplitterBarStateType.Restored**。

属性**RestoredLeft**和**RestoredTop**指定当**VerticalBarState**和**HorizontalBarState**分别设置为**SplitterBarStateType.Restored**时，普通视图中侧边或顶部幻灯片区域的大小。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的大小（当为**RestoredTop**的子项时为宽度，当为**RestoredLeft**的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性**DimensionSize**指定幻灯片区域的大小（当为**restoredTop**的子项时为宽度，当为**restoredLeft**的子项时为高度）。

属性**AutoAdjust**指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应随之进行补偿。

下面的示例演示如何访问演示文稿的**ViewProperties.NormalViewProperties**属性。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // 恢复演示文稿的视图属性
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **设置默认缩放值**

Aspose.Slides for .NET 现在支持为演示文稿设置默认缩放值，使得打开演示文稿时已预先设置缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties)来实现。幻灯片视图属性以及[NotesViewProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties/properties/notesviewproperties)均可通过代码设置。在本主题中，我们将通过示例展示如何在 Aspose.Slides 中设置演示文稿的视图属性。

设置视图属性的步骤如下：

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation)类的实例  
1. 设置演示文稿的视图[Properties](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties)  
1. 将演示文稿写入为 PPTX 文件  

在下面的示例中，我们已为幻灯片视图和备注视图分别设置了缩放值。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 设置演示文稿的视图属性
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 幻灯片视图的缩放值（百分比）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 笔记视图的缩放值（百分比） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **设置网格间距**

使用[Presentation.ViewProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/viewproperties/)访问整个演示文稿的视图设置。[IViewProperties.GridSpacing](https://reference.aspose.com/slides/zh/net/aspose.slides/iviewproperties/gridspacing/)属性读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而非单个幻灯片。网格间距以磅为单位，72 磅等于一英寸。请使用正值，符合 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，打印其当前网格间距，设置为四分之一英寸的间隔，并保存结果。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

网格不同于[绘图参考线](/slides/zh/net/drawing-guides/)。网格间距控制规律的间隔，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会改变网格间距。

网格和绘图参考线都是编辑辅助工具。它们在 PDF、图像、SVG 或幻灯片放映中不会作为幻灯片内容呈现。存储网格间距并不保证编辑器一定会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **常见问题**

**重新打开演示文稿后网格为何不可见？**

文件会存储网格间距，但是否显示网格由编辑器控制。请检查编辑器的网格可见性设置。

**清除绘图参考线会改变网格间距吗？**

不会。绘图参考线和网格间距是相互独立的设置。清除参考线不会改变已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/viewproperties/)在演示文稿层面定义（[普通视图](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties/normalviewproperties/)/[幻灯片视图](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties/slideviewproperties/)），而不是按章节划分。因此，打开文档时整个文档使用同一套参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并且是共享的。查看器应用程序可以尊重用户偏好，但文件本身只包含一套视图属性。

**我可以准备带有预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**

可以。因为[视图属性](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/viewproperties/)存储在演示文稿层面，你可以将它们嵌入模板中，之后基于该模板创建的新文档将拥有相同的初始视图配置。
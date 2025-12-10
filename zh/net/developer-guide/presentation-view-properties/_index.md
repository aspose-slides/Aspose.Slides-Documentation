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
- 单视图
- 分割条状态
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

{{% alert color="primary" %}} 

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。用于定位不同内容区域的属性。这些信息允许应用程序将视图状态保存到文件中，以便重新打开时视图保持在上次保存时的相同状态。

已添加属性[IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties)，以提供对演示文稿普通视图属性的访问。

已添加[INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties)接口及其派生类，以及[SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype)枚举。

{{% /alert %}}

## **About INormalViewProperties**

表示普通视图属性。

属性**ShowOutlineIcons** 指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

属性**SnapVerticalSplitter** 指定当侧边区域足够小且垂直分割条应捕捉到最小化状态时的行为。

属性**PreferSingleView** 指定用户是否倾向于在整个窗口中只显示单个内容区域，而不是带有三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性**VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值为：**SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

属性**RestoredLeft** 和 **RestoredTop** 指定普通视图中顶部或侧边幻灯片区域的尺寸，当 **VerticalBarState** 和 **HorizontalBarState** 分别使用 **SplitterBarStateType.Restored** 值时适用。

## **About Restoring INormalViewProperties** 

指定普通视图中幻灯片区域（作为 RestoredTop 的子项时为宽度，作为 RestoredLeft 的子项时为高度）的尺寸，当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性**DimensionSize** 指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

属性**AutoAdjust** 指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应补偿新的大小。

下面的示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。
```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // 还原演示文稿的视图属性
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```


## **Set the Default Zoom Value**

Aspose.Slides for .NET 现在支持为演示文稿设置默认缩放值，以便打开演示文稿时已设置缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties)来实现。幻灯片视图属性以及[NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties)都可以以编程方式设置。在本主题中，我们将通过示例展示如何在 Aspose.Slides 中设置演示文稿的视图属性。

设置视图属性请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例
1. 设置演示文稿的视图[Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties)
1. 将演示文稿写入为 PPTX 文件

在下面的示例中，我们已经为幻灯片视图和备注视图设置了缩放值。
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 设置演示文稿的视图属性
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 幻灯片视图的缩放值（百分比）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 备注视图的缩放值（百分比） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) 在演示文稿级别（[Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)）定义，而不是按章节定义。因此，在打开文档时，整个文档使用同一组参数。

**Can I predefine different view states for different users?**

不可以。设置存储在文件中并共享。查看器应用程序可能会尊重用户偏好，但文件本身只包含一组视图属性。

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

可以。由于[view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/)存储在演示文稿级别，您可以将它们嵌入模板中，并从该模板创建新文档，以实现相同的初始视图配置。
---
title: 演示文稿视图属性
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
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- 演示文稿
- C#
- C#
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中管理 PowerPoint 演示文稿视图属性"
---

{{% alert color="primary" %}} 

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。涉及不同内容区域定位的属性。这些信息使应用程序能够将视图状态保存到文件中，从而在重新打开时视图保持与上次保存演示文稿时相同的状态。

已添加属性 [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties)，以提供对演示文稿普通视图属性的访问。

已添加 [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) 接口及其子类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) 枚举。

{{% /alert %}}

## **关于 INormalViewProperties**

表示普通视图属性。

属性 **ShowOutlineIcons** 指定在普通视图模式下的任何内容区域显示大纲内容时，应用程序是否应显示图标。

属性 **SnapVerticalSplitter** 指定当侧边区域足够小时时，垂直分割条是否应捕捉到最小化状态。

属性 **PreferSingleView** 指定用户是否更倾向于在全窗口单内容区域中查看，而不是标准的包含三个内容区域的普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值为：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

属性 **RestoredLeft** 和 **RestoredTop** 指定普通视图中顶部或侧边幻灯片区域的大小，当 **VerticalBarState** 和 **HorizontalBarState** 分别使用 **SplitterBarStateType.Restored** 值时。

## **关于恢复 INormalViewProperties** 

指定普通视图中幻灯片区域的大小（当为 RestoredTop 的子项时为宽度， 当为 RestoredLeft 的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性 **DimensionSize** 指定幻灯片区域的大小（当为 restoredTop 的子项时为宽度， 当为 restoredLeft 的子项时为高度）。

属性 **AutoAdjust** 指定在应用程序中调整包含视图的窗口大小时，侧边内容区域的大小是否应随之补偿。

下面的示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。
```c#
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

Aspose.Slides for .NET 现在支持为演示文稿设置默认缩放值，使得打开演示文稿时已设置缩放。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) 来实现。幻灯片视图属性以及 [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) 也可以通过代码设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中设置演示文稿的视图属性。

要设置视图属性，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例
2. 设置演示文稿的视图 [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties)
3. 将演示文稿写入为 PPTX 文件

在下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 设置演示文稿的视图属性
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 幻灯片视图的缩放值（百分比）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 备注视图的缩放值（百分比） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) 在演示文稿层面定义（[普通视图](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)、[幻灯片视图](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)），而不是按章节划分，因此在打开文档时，整个文档使用同一套参数。

**我可以为不同的用户预定义不同的视图状态吗？**

不能。设置存储在文件中并且是共享的。查看器应用程序可能会遵循用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个预定义视图属性的模板，使新演示文稿以相同方式打开吗？**

可以。因为 [视图属性](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) 存储在演示文稿层面，您可以将其嵌入模板中，并基于该模板创建新文档，从而拥有相同的初始视图配置。
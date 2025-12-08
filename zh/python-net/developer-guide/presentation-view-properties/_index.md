---
title: 检索并更新Python中演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/python-net/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 贴合垂直分割条
- 单视图
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---

{{% alert color="primary" %}} 

正常视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。涉及不同内容区域定位的属性。该信息允许应用程序将其视图状态保存到文件中，以便重新打开时视图保持与上次保存演示文稿时相同的状态。

已添加属性 [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) 以提供对演示文稿的普通视图属性的访问。

已添加 [INormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) 接口及其子类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 枚举。

{{% /alert %}} 

## **关于 INormalViewProperties** 

表示普通视图属性。

属性 **ShowOutlineIcons** 指定在普通视图模式下，如果在任何内容区域显示大纲内容时，应用程序是否应显示图标。

属性 **SnapVerticalSplitter** 指定当侧边区域足够小时，垂直分割条是否应自动贴合到最小化状态。

属性 **PreferSingleView** 指定用户是否倾向于在全窗口单内容区域中查看，而不是使用包含三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔开，垂直分割条将幻灯片与侧边内容区域分隔开。可能的值为：**SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

属性 **RestoredLeft** 和 **RestoredTop** 指定在相应的 **VerticalBarState** 和 **HorizontalBarState** 应用 **SplitterBarStateType.Restored** 值时，普通视图的顶部或侧边幻灯片区域的大小。

## **关于恢复 INormalViewProperties** 

指定普通视图中幻灯片区域的大小（当为 RestoredTop 的子项时为宽度，当为 RestoredLeft 的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性 **DimensionSize** 指定幻灯片区域的尺寸（当为 restoredTop 的子项时为宽度， 当为 restoredLeft 的子项时为高度）。

属性 **AutoAdjust** 指定在应用程序中调整包含视图的窗口大小时，侧边内容区域的大小是否应自动进行补偿。

下面的示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # 恢复演示文稿的视图属性
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **设置默认缩放值** 

Aspose.Slides for Python via .NET 现在支持为演示文稿设置默认缩放值，以便在打开演示文稿时已经设置好缩放。可以通过设置演示文稿的 [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) 来实现。幻灯片视图属性以及 [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) 都可以通过编程方式设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中设置演示文稿的视图属性。

为了设置视图属性，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 设置演示文稿的视图 [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/)
1. 将演示文稿写入为 PPTX 文件

在下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 设置演示文稿的视图属性
    presentation.view_properties.slide_view_properties.scale = 100 # 幻灯片视图的缩放值（百分比）
    presentation.view_properties.notes_view_properties.scale = 100 # 注释视图的缩放值（百分比）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题** 

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) 在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)、[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)），而不是针对每个章节，因此在打开文档时会使用同一套参数应用于整个文档。

**我可以为不同用户预定义不同的视图状态吗？**

不可以。设置存储在文件中并且是共享的。查看器应用程序可以遵循用户偏好，但文件本身只包含一组视图属性。

**我可以准备一个预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**

可以。因为 [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) 存储在演示文稿级别，您可以将其嵌入模板中，并基于该模板创建新文档，从而拥有相同的初始视图配置。
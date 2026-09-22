---
title: 检索和更新 Python 中的演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/python-net/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单视图
- 栏状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **简介**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。有关不同内容区域定位的属性。这些信息允许应用程序将其视图状态保存到文件中，以便重新打开时视图保持在上次保存演示文稿时的相同状态。

已添加属性 [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/normal_view_properties/)，以提供对演示文稿普通视图属性的访问。

已添加 [NormalViewProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/normalviewrestoredproperties/) 类及其派生类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/splitterbarstatetype/) 枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

属性 **ShowOutlineIcons** 指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

属性 **SnapVerticalSplitter** 指定当侧边区域足够小时时，垂直分割条是否应自动收缩至最小化状态。

属性 **PreferSingleView** 指定用户是否倾向于在全窗口单一内容区域中查看，而不是使用含有三个内容区域的标准普通视图。如果启用，应用程序可能会选择将其中一个内容区域显示在整个窗口中。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔，垂直分割条将幻灯片与侧边内容区域分隔。可能的取值为：**SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

属性 **RestoredLeft** 和 **RestoredTop** 指定在 **VerticalBarState** 和 **HorizontalBarState** 分别采用 **SplitterBarStateType.Restored** 值时，普通视图中侧边或顶部幻灯片区域的大小。

## **关于恢复 INormalViewProperties**

在普通视图中，当区域处于可变的恢复大小（既非最小化也非最大化）时，指定幻灯片区域的尺寸（作为 RestoredTop 的子项时为宽度，作为 RestoredLeft 的子项时为高度）。

属性 **DimensionSize** 指定幻灯片区域的尺寸（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

属性 **AutoAdjust** 指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应自动补偿新的尺寸。

下面的示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # 恢复演示文稿的视图属性
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **设置默认缩放值**

Aspose.Slides for Python via .NET 现在支持为演示文稿设置默认缩放值，使得打开演示文稿时已设置缩放。可以通过设置演示文稿的 [view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 来实现。幻灯片视图属性以及 [notes_view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/notes_view_properties/) 均可通过编程方式设置。在本主题中，我们将通过示例展示如何在 Aspose.Slides 中设置演示文稿的视图属性。

要设置视图属性，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例
2. 设置演示文稿的 [view properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/)
3. 将演示文稿写入为 PPTX 文件

在下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # 设置演示文稿的视图属性
    presentation.view_properties.slide_view_properties.scale = 100 # 幻灯片视图的缩放值（百分比）
    presentation.view_properties.notes_view_properties.scale = 100 # 注释视图的缩放值（百分比）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **设置网格间距**

使用 [Presentation.view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 可访问演示文稿范围的视图设置。[ViewProperties.grid_spacing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/grid_spacing/) 属性读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而非单个幻灯片。网格间距以点为单位，72 点等于一英寸。请使用正值，符合 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，打印其当前网格间距，设置四分之一英寸的间隔，并保存结果。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

网格与 [drawing guides](/slides/zh/python-net/drawing-guides/) 不同。网格间距控制规则间隔，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会更改网格间距。

网格和绘图参考线都是编辑辅助工具。它们不会在 PDF、图像、SVG 或幻灯片放映中作为幻灯片内容渲染。保存网格间距并不保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **常见问题**

**为什么重新打开演示文稿后网格不可见？**

文件会存储网格间距，但编辑器决定是否显示网格。请检查编辑器的网格可见性设置。

**清除绘图参考线会改变网格间距吗？**

不会。绘图参考线和网格间距是独立的设置。清除参考线不会改变已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 在演示文稿级别定义（[普通视图](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/normal_view_properties/)/[幻灯片视图](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/slide_view_properties/)），而不是按章节划分，因此在打开文档时会对整个文档应用同一套参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并共享。查看器应用程序可能会遵循用户偏好，但文件本身仅包含一套视图属性。

**我可以准备带有预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**

可以。因为 [view properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 存储在演示文稿级别，您可以将其嵌入模板中，并基于该模板创建新文档，从而拥有相同的初始视图配置。
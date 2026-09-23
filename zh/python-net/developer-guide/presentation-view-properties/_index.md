---
title: 在 Python 中检索和更新演示文稿视图属性
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
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。涉及不同内容区域定位的属性。这些信息允许应用程序将其视图状态保存到文件中，这样在重新打开时，视图状态与上次保存演示文稿时相同。

已添加属性 [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/normal_view_properties/) 以提供对演示文稿普通视图属性的访问。

已添加 [NormalViewProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/normalviewrestoredproperties/) 类及其派生类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/splitterbarstatetype/) 枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

属性 **ShowOutlineIcons** 指定在普通视图模式的任何内容区域中显示大纲内容时，应用程序是否应显示图标。

属性 **SnapVerticalSplitter** 指定当侧边区域足够小时时，垂直分割条是否应捕捉到最小化状态。

属性 **PreferSingleView** 指定用户是否更倾向于在全窗口单内容区域中查看，而不是标准的三内容区域普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔，垂直分割条将幻灯片与侧边内容区域分隔。可能的取值为：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

当 **VerticalBarState** 和 **HorizontalBarState** 分别使用 **SplitterBarStateType.Restored** 值时，属性 **RestoredLeft** 和 **RestoredTop** 指定普通视图中顶部或侧边幻灯片区域的尺寸。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的尺寸（当为 RestoredTop 的子项时为宽度，当为 RestoredLeft 的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性 **DimensionSize** 指定幻灯片区域的大小（当为 restoredTop 的子项时为宽度，当为 restoredLeft 的子项时为高度）。

属性 **AutoAdjust** 指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应补偿新的大小。

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

Aspose.Slides for Python via .NET 现在支持为演示文稿设置默认缩放值，这样在打开演示文稿时，缩放已预先设定。可以通过设置演示文稿的 [view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 来实现。幻灯片视图属性以及 [notes_view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/notes_view_properties/) 都可以以编程方式设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中设置演示文稿的视图属性。

为了设置视图属性，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例
1. 设置演示文稿的 [视图属性](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/)
1. 将演示文稿写入 PPTX 文件

在下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # 设置演示文稿的视图属性
    presentation.view_properties.slide_view_properties.scale = 100 # 幻灯片视图的缩放值（百分比）
    presentation.view_properties.notes_view_properties.scale = 100 # 备注视图的缩放值（百分比）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **设置网格间距**

使用 [Presentation.view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 访问整个演示文稿的视图设置。属性 [ViewProperties.grid_spacing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/grid_spacing/) 读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而不是单个幻灯片。网格间距以点为单位，72 点等于一英寸。请使用正值，符合 API 文档的要求。

以下示例打开现有的 `demo.pptx`，输出其当前网格间距，设置四分之一英寸的间隔，并保存结果。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

网格不同于 [drawing guides](/slides/zh/python-net/drawing-guides/)。网格间距控制规则的间隔，而绘图指南是单独定位的水平或垂直对齐线。添加、移动或清除绘图指南不会更改网格间距。

网格和绘图指南都是编辑辅助工具。它们不会在 PDF、图像、SVG 或幻灯片放映中作为幻灯片内容渲染。存储网格间距并不能保证编辑器会显示网格：其可见性还取决于查看器或编辑器的设置。

## **打开演示文稿时显示或隐藏批注**

使用 [Presentation.view_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 访问整个演示文稿的视图设置。读取或更改 [ViewProperties.show_comments](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/show_comments/) 以存储在 PowerPoint 或其他兼容编辑器打开演示文稿时是否显示批注的偏好。

此设置仅控制存储的视图偏好。它不添加、删除、编辑或解决批注。隐藏批注会保留其内容、作者、位置、回复和状态。请参阅 [Presentation Comments](/slides/zh/python-net/presentation-comments/) 了解更改批注本身的操作。

以下示例需要一个包含批注的现有 `comments.pptx`。它输出当前的可见性设置，要求隐藏批注，并保存一个新的 PPTX 而不删除任何批注。它还将 [ViewProperties.last_view](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/last_view/) 设置为 [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewtype/)，以在批注可见性之外配置初始编辑视图。

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

此设置并不决定批注是否包含在 PDF、HTML、图像、备注或讲义导出中。请单独配置相应的导出特定选项。

## **常见问题**

**为什么重新打开演示文稿后网格不可见？**

文件存储了网格间距，但编辑器决定是否显示网格。检查编辑器的网格可见性设置。

**清除绘图指南会改变网格间距吗？**

不会。绘图指南和网格间距是独立的设置。清除指南不会改变已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/slide_view_properties/)），而非按章节划分，因此在打开时整个文档使用同一组参数。

**我可以为不同用户预定义不同的视图状态吗？**

不可以。设置存储在文件中并共享。查看器应用程序可能会遵循用户偏好，但文件本身只包含一组视图属性。

**我可以准备一个预定义视图属性的模板，使新演示文稿以相同方式打开吗？**

可以。因为 [view properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/view_properties/) 存储在演示文稿级别，您可以将它们嵌入模板中，基于该模板创建新文档时具有相同的初始视图配置。
---
title: 在 Python via Java 中检索和更新演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/python-java/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单视图
- 栏状态
- 维度大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片——调整布局、缩放级别和显示设置。"
---
## **简介**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。普通视图属性描述这些内容区域的位置。此信息允许应用程序将其视图状态保存到文件中，以便重新打开时视图与上次保存演示文稿时的状态相同。

已添加方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 以提供对演示文稿的普通视图属性的访问。

已添加 [NormalViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/) 和 [NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/) 类以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/) 枚举。

## **关于 NormalViewProperties**

表示普通视图属性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 指定当侧边区域足够小时，垂直分割条是否应捕捉到最小化状态。

方法 [getPreferSingleView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 指定用户是否更喜欢在整个窗口显示单一内容区域，而不是标准的带有三个内容区域的普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开；垂直分割条将幻灯片与侧边内容区域分开。可能的值有: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 和 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 指定在对 [getVerticalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 应用 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Restored) 值时，普通视图的侧边或顶部幻灯片区域的大小。

## **关于恢复 NormalViewProperties**

指定普通视图中幻灯片区域的大小（当作为 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 指定幻灯片区域的大小（当作为 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子项时为高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应补偿新的大小。

下面的示例展示了如何访问演示文稿的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNormalViewProperties)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # 恢复演示文稿的视图属性。
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置默认缩放值**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java 支持设置默认缩放值，以便在打开演示文稿时已经应用。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/) 来实现。可以通过编程方式配置 [getSlideViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 和 [getNotesViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNotesViewProperties)。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中为 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 设置 [View Properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/)。
{{% /alert %}}

要设置视图属性，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 设置 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 的 [View Properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/)。
1. 将演示文稿写为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下示例中，我们为幻灯片视图和备注视图设置缩放值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 设置演示文稿的视图属性。
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # 幻灯片视图的缩放百分比。
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # 备注视图的缩放百分比。

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置网格间距**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 访问整个演示文稿的视图设置。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getGridSpacing) 和 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#setGridSpacing) 方法读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而不是单个幻灯片。网格间距以点为单位指定，72 点等于一英寸。请使用正值，符合 API 文档的要求。

以下示例打开现有的 `demo.pptx`，打印其当前网格间距，设置四分之一英寸的间隔，并保存结果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

网格不同于 [drawing guides](/slides/zh/python-java/drawing-guides/)。网格间距控制规则的间隔，而绘图指南是单独定位的水平或垂直对齐线。添加、移动或清除绘图指南不会改变网格间距。

网格和绘图指南都是编辑辅助工具。它们不会在 PDF、图像、SVG 或幻灯片放映中作为幻灯片内容呈现。存储网格间距并不能保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **常见问题**

**重新打开演示文稿后为何看不到网格？**

文件保存了网格间距，但由编辑器决定是否显示网格。请检查编辑器的网格可见性设置。

**清除绘图指南会改变网格间距吗？**

不会。绘图指南和网格间距是独立的设置。清除指南不会改变已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[View settings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getSlideViewProperties)），而不是针对各章节。因此在打开时，整个文档使用同一套参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并共享。查看程序可能会遵循用户偏好，但文件本身仅包含一套视图属性。

**我可以准备带有预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**

可以。因为 [view properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 存储在演示文稿级别，您可以将其嵌入模板中，并基于该模板创建新文档，以获得相同的初始视图配置。
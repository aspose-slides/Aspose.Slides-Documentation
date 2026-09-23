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
- 条状态
- 尺寸大小
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
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。普通视图属性描述这些内容区域的位置。此信息允许应用程序将视图状态保存到文件中，以便在重新打开时视图保持为上次保存时的状态。

已添加方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 以提供对演示文稿普通视图属性的访问。

已添加 [NormalViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/) 和 [NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/) 类以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/) 枚举。

## **关于 NormalViewProperties**

表示普通视图属性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 指定在普通视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 指定当侧边区域足够小时时，垂直分割条是否应捕捉到最小化状态。

方法 [getPreferSingleView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 指定用户是否更倾向于在整个窗口中只显示单个内容区域，而不是包含三个内容区域的标准普通视图。如果启用，应用程序可以选择将其中一个内容区域显示在整个窗口中。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔；垂直分割条将幻灯片与侧边内容区域分隔。可能的取值有: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 和 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 指定在将 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Restored) 值应用于 [getVerticalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 时，普通视图的侧边或顶部幻灯片区域的大小。

## **关于恢复 NormalViewProperties**

指定普通视图的幻灯片区域（当作为 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子项时为高度）的大小，当该区域处于可变的恢复大小（既非最小化也非最大化）时。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 指定幻灯片区域的尺寸（作为 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子项时为高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应随之补偿。

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
Aspose.Slides for Python via Java 支持设置默认缩放值，以便在打开演示文稿时已应用该缩放。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/) 来实现。可以以编程方式配置 [getSlideViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 和 [getNotesViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNotesViewProperties)。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中为 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 设置 [View Properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/)。
{{% /alert %}}

设置视图属性，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 为 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 设置 [View Properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/)。  
3. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面的示例为幻灯片视图和备注视图都设置了缩放值。

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

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 访问整个演示文稿的视图设置。方法 [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getGridSpacing) 和 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#setGridSpacing) 读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而不是单个幻灯片。网格间距以点为单位，72 点等于一英寸。请使用正值，符合 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，打印当前网格间距，设置为四分之一英寸的间隔，并保存结果。

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

网格与[绘图参考线](/slides/zh/python-java/drawing-guides/)不同。网格间距控制规则的间隔，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会改变网格间距。

网格和绘图参考线都是编辑辅助工具。它们不会在 PDF、图像、SVG 或幻灯片放映中作为幻灯片内容渲染。存储网格间距并不保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **打开演示文稿时显示或隐藏批注**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 访问整个演示文稿的视图设置。使用 [ViewProperties.getShowComments](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getShowComments) 和 [ViewProperties.setShowComments](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#setShowComments) 读取或更改存储的首选项，以决定在 PowerPoint 或其他兼容编辑器打开演示文稿时是否显示批注。

此设置仅控制存储的视图偏好。它不会添加、删除、编辑或解决批注。隐藏批注会保留其内容、作者、位置、回复和状态。有关更改批注本身的操作，请参阅 [Presentation Comments](/slides/zh/python-java/presentation-comments/)。

下面的示例需要一个包含批注的现有 `comments.pptx`。它打印当前的可见性设置，请求隐藏批注，并在不删除任何批注的情况下保存新的 PPTX。它还使用 [ViewProperties.setLastView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#setLastView) 与 [ViewType.SlideView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewtype/#SlideView) 配合配置初始编辑视图以及批注可见性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此设置不决定批注是否会包含在 PDF、HTML、图像、备注或讲义的导出中。请分别配置相应的导出特定选项。

## **常见问题解答**

**为什么重新打开演示文稿后网格不可见？**  
文件会存储网格间距，但编辑器控制是否显示网格。请检查编辑器的网格可见性设置。

**清除绘图参考线会改变网格间距吗？**  
不会。绘图参考线和网格间距是独立的设置。清除参考线不会改变已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**  
[视图设置](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 在演示文稿级别定义（[普通视图](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[幻灯片视图](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getSlideViewProperties)），而不是按章节。因此，文档打开时只有一套参数适用于整个文档。

**我能预先为不同用户定义不同的视图状态吗？**  
不能。设置存储在文件中并且是共享的。查看器应用程序可以遵循用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个模板，预定义视图属性，使新演示文稿以相同方式打开吗？**  
可以。因为[视图属性](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties)存储在演示文稿级别，你可以将它们嵌入模板中，从而使用该模板创建的新文档具有相同的初始视图配置。
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
description: "探索 Aspose.Slides for Python via Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片——调整布局、缩放级别和显示设置。"
---
## **介绍**

正常视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。正常视图属性描述这些内容区域的位置。此信息允许应用程序将其视图状态保存到文件中，以便重新打开时视图保持与上次保存时相同的状态。

已添加方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 以提供对演示文稿的正常视图属性的访问。

已添加 [NormalViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/) 类以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/) 枚举。

## **关于 NormalViewProperties**

表示正常视图属性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 指定在正常视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 指定当侧边区域足够小时时，垂直分割条是否应自动收缩至最小状态。

方法 [getPreferSingleView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 指定用户是否更倾向于在整个窗口显示单一内容区域，而不是标准的包含三个内容区域的正常视图。如果启用，应用程序可能会选择将其中一个内容区域占满整个窗口。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开；垂直分割条将幻灯片与侧边内容区域分开。可能的取值为：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 和 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 指定在将 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/python-java/aspose.slides/splitterbarstatetype/#Restored) 值应用于 [getVerticalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 时，正常视图的侧边或顶部幻灯片区域的大小。

## **关于恢复 NormalViewProperties**

指定当区域处于可变的恢复大小（既非最小化也非最大化）时，正常视图中幻灯片区域的尺寸（作为 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子项时为高度）。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 指定幻灯片区域的大小（作为 [getRestoredTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 的子项时为高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应随之补偿。

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

Aspose.Slides for Python via Java 支持设置默认缩放值，以便在打开演示文稿时已自动应用。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/) 来实现。可以以编程方式配置 [getSlideViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 和 [getNotesViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNotesViewProperties)。在本主题中，我们将通过示例演示如何在 [Aspose.Slides](/slides/zh/) 中为 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 设置 [View Properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/)。

{{% /alert %}}

要设置视图属性，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 设置 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 的 [View Properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/)。
1. 将演示文稿写入为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

在下面的示例中，我们为幻灯片视图和备注视图都设置了缩放值。

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

## **常见问题**

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[View settings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#getSlideViewProperties)），而不是在每个章节单独定义，因此在打开文档时整个文档使用同一组参数。

**我可以为不同的用户预定义不同的视图状态吗？**

不能。设置存储在文件中并共享。查看器应用程序可以尊重用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个带有预定义 View Properties 的模板，以便新演示文稿以相同方式打开吗？**

可以。由于 [view properties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getViewProperties) 存储在演示文稿级别，您可以将其嵌入模板中，并基于该模板创建新文档，以获得相同的初始视图配置。
---
title: 在 Python 通过 Java 检索和更新演示文稿视图属性
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
- 尺寸
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 配置 PowerPoint 演示文稿的普通视图布局、幻灯片和备注的缩放、网格间距以及注释可见性。"
---
## **简介**

在 PowerPoint 的普通视图中，幻灯片位于缩略图或大纲的侧边窗格与下面的备注窗格之间。Aspose.Slides for Python via Java 通过 [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) 暴露了演示文稿保存的编辑首选项。这些包括窗格布局、缩放级别、网格间距和注释可见性。

## **关于 NormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 来访问 [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) 类。[setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 控制是否在大纲中幻灯片标题旁显示图标。[setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 让侧边窗格在用户收窄时自动折叠至最小状态。[setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 表示在全窗口中显示单一窗格的偏好。

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) 控制侧边窗格与幻灯片之间的分隔条。[setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) 控制备注窗格上方的分隔条。这两者都接受 [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) 的值，`Minimized`、`Maximized` 或 `Restored`。

## **关于恢复 NormalViewProperties**

当分隔条被恢复时，[getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 提供侧边窗格保存的大小，[getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 提供上部幻灯片区域保存的大小。这两者都返回 [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) 的实例。其 [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) 方法接受 0 到 100 的百分比，[setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) 控制编辑器在窗口大小改变时是否自动调整尺寸。

此示例更新现有演示文稿。它恢复水平分隔条，将 [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 返回的大小设置为 80%，并启用自动调整，并将垂直分隔条最大化。它还调用 [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 在大纲视图中显示图标。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **设置默认缩放值**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) 和 [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) 为编辑器存储独立的缩放设置。这些设置不影响幻灯片尺寸、幻灯片放映播放或图像导出分辨率。

此示例打开现有演示文稿并调用 [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) 使幻灯片适应编辑窗口。对于备注页，它禁用自动缩放并调用 [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) 将缩放固定为 80%。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **设置网格间距**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) 设置整个演示文稿中编辑网格线之间的距离。它接受以点为单位的正数值，1 英寸等于 72 点。此示例打印现有演示文稿的当前间距，并通过将间隔设为 18 点来保存四分之一英寸的网格。

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
网格以固定间隔重复。[Drawing guides](/slides/zh/python-java/drawing-guides/) 标记单独的水平或垂直位置。它们都是编辑辅助，仅在显示此功能的编辑器中出现。幻灯片放映以及导出为 PDF、图像或 SVG 时会省略它们。

## **打开演示文稿时显示或隐藏评论**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) 保存兼容编辑器在打开演示文稿时使用的首选项。针对包含评论的现有演示文稿，此示例打印当前设置并保存一个隐藏评论的副本。它还使用 [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) 调用 [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView)，使副本以幻灯片视图打开。

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
隐藏评论会保留其文本、作者、位置、回复和状态。要修改评论本身，请参阅 [Presentation Comments](/slides/zh/python-java/presentation-comments/)。导出设置决定评论是否出现在 PDF、HTML、图像、备注或讲义中。

## **常见问题**

**为什么重新打开演示文稿时网格被隐藏？**  
演示文稿保存了网格间隔。要查看网格，请在编辑器中启用网格可见性。

**清除绘图指南会改变网格间距吗？**  
不会。添加、移动或清除指南不会影响网格间隔。

**演示文稿的不同章节可以拥有不同的视图设置吗？**  
不能。[Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) 适用于整个演示文稿。

**我可以为不同用户保存不同的视图设置吗？**  
文件仅存储一套视图属性供所有人使用。编辑器可能会应用用户本地的偏好。

**我可以在模板中保存视图设置吗？**  
可以。基于模板创建的演示文稿会继承模板中保存的视图设置。
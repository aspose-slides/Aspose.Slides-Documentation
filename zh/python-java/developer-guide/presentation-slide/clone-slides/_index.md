---
title: 在 Python 中克隆演示文稿幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 35
url: /zh/python-java/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 快速复制 PowerPoint 幻灯片。遵循我们的清晰代码示例，在几秒钟内自动化 PPT 创建，消除手动工作。"
---
## **简介**

克隆是对某事物进行完全复制或复制的过程。Aspose.Slides for Python via Java 也可以对任何幻灯片进行复制或克隆，然后将该克隆幻灯片插入当前演示文稿或任何其他打开的演示文稿中。幻灯片克隆的过程会创建一个新幻灯片，开发人员可以对其进行修改，而不会更改原始幻灯片。克隆幻灯片有多种可能的方式：

- 在演示文稿内部的末尾克隆。
- 在演示文稿内部的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 将其母版幻灯片一起克隆到另一个演示文稿中。

在 Aspose.Slides for Python via Java 中，Presentation 对象公开的 slide collection（[Slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 对象的集合）提供了 [addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addClone) 和 [insertClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#insertClone) 方法，以执行上述类型的幻灯片克隆。

## **在演示文稿末尾克隆幻灯片**

如果您想克隆幻灯片并将其放置在同一演示文稿文件的现有幻灯片末尾，请按照以下步骤使用 [addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addClone) 方法：

1. 创建 Presentation 类的实例。
2. 通过引用 Presentation 对象公开的 Slides 集合获取 SlideCollection 对象。
3. 调用 SlideCollection 对象公开的 addClone 方法，并将要克隆的幻灯片作为参数传递给 addClone 方法。
4. 写入修改后的演示文稿文件。

在下面的示例中，我们将演示文稿中位于第一位置（索引 0）的幻灯片克隆到演示文稿的末尾。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 实例化表示演示文稿文件的 Presentation 类
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # 将修改后的演示文稿写入磁盘
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在演示文稿内部的其他位置克隆幻灯片**

如果您想克隆幻灯片并在同一演示文稿文件的不同位置使用它，请使用 [insertClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#insertClone) 方法：

1. 创建 Presentation 类的实例。
2. 通过对 Presentation 对象调用 [getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides) 获取幻灯片集合的引用。
3. 调用 SlideCollection 对象公开的 insertClone 方法，并将要克隆的幻灯片连同新位置的索引一起作为参数传递给 insertClone 方法。
4. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们将演示文稿中位于索引 1（位置 2）的幻灯片克隆到索引 2（位置 3）。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 实例化表示演示文稿文件的 Presentation 类
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # 获取演示文稿中的幻灯片集合
    slides = presentation.getSlides()

    # 将所需幻灯片克隆到同一演示文稿的指定索引
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # 将修改后的演示文稿写入磁盘
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在另一个演示文稿的末尾克隆幻灯片**

如果您需要从一个演示文稿克隆幻灯片并将其放置在另一个演示文稿的现有幻灯片末尾：

1. 创建包含要克隆幻灯片来源的演示文稿的 Presentation 类的实例。
2. 创建包含目标演示文稿的 Presentation 类的实例。
3. 通过对目标演示文稿的 Presentation 对象调用 [getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides) 获取幻灯片集合的引用，进而获取 SlideCollection 对象。
4. 调用 SlideCollection 对象公开的 addClone 方法，并将源演示文稿中的幻灯片作为参数传递给 addClone 方法。
5. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿索引 0 处的幻灯片克隆到目标演示文稿的末尾。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 实例化 Presentation 类以加载源演示文稿文件
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    destination_presentation = Presentation()
    try:
        # 将所需幻灯片从源演示文稿克隆到目标演示文稿中幻灯片集合的末尾
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # 将目标演示文稿写入磁盘
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **在另一个演示文稿的其他位置克隆幻灯片**

如果您需要从一个演示文稿克隆幻灯片并在另一个演示文稿的特定位置使用它：

1. 创建包含源演示文稿的 Presentation 类的实例。
2. 创建包含目标演示文稿的 Presentation 类的实例。
3. 通过引用目标演示文稿的 Presentation 对象公开的 Slides 集合获取 SlideCollection 对象。
4. 调用 SlideCollection 对象公开的 insertClone 方法，并将源演示文稿中的幻灯片连同所需位置一起作为参数传递给 insertClone 方法。
5. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿的零索引幻灯片克隆到目标演示文稿的索引 1（位置 2）。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 实例化 Presentation 类以加载源演示文稿文件
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    destination_presentation = Presentation()
    try:
        # 将所需幻灯片从源演示文稿克隆到目标演示文稿的指定索引
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # 将目标演示文稿写入磁盘
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **将幻灯片及其母版克隆到另一个演示文稿**

如果您需要将带有母版的幻灯片从一个演示文稿克隆到另一个演示文稿，首先必须先将所需的母版从源演示文稿克隆到目标演示文稿。然后在克隆幻灯片时使用已克隆的母版。[addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addClone) 方法期望使用目标演示文稿中的母版，而不是源演示文稿中的母版。请按照以下步骤克隆带有母版的幻灯片：

1. 创建包含源演示文稿的 Presentation 类的实例。
2. 创建包含目标演示文稿的 Presentation 类的实例。
3. 访问要克隆的幻灯片及其母版。
4. 通过引用目标演示文稿的 Presentation 对象公开的 Masters 集合获取 MasterSlideCollection 对象。
5. 调用 MasterSlideCollection 对象公开的 addClone 方法，并将源 PPTX 中的母版作为参数传递给 addClone 方法。
6. 通过引用目标演示文稿的 Presentation 对象公开的 Slides 集合获取 SlideCollection 对象。
7. 调用 SlideCollection 对象公开的 addClone 方法，并将源演示文稿中的幻灯片及其母版作为参数传递给 addClone 方法。
8. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿零索引处的带母版幻灯片克隆到目标演示文稿的末尾，并使用源幻灯片的母版。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 实例化 Presentation 类以加载源演示文稿文件
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # 实例化用于目标演示文稿的 Presentation 类（要克隆幻灯片的地方）
    destination_presentation = Presentation()
    try:
        # 从源演示文稿的幻灯片集合中实例化幻灯片以及
        # 母版幻灯片
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # 将所需幻灯片从源演示文稿与所需母版克隆到目标演示文稿的幻灯片集合末尾
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # 将目标演示文稿保存到磁盘
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **在指定章节的末尾克隆幻灯片**

如果您想克隆幻灯片并在同一演示文稿文件的不同章节中使用它，请使用由 **SlideCollection** 类公开的 [**addClone**](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addClone) 方法。Aspose.Slides for Python via Java 使得可以从第一章节克隆幻灯片，然后将该克隆幻灯片插入同一演示文稿的第二章节。

下面的代码片段演示了如何克隆幻灯片并将克隆的幻灯片插入指定章节。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # 将目标演示文稿保存到磁盘
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **确保幻灯片尺寸匹配**

在将幻灯片克隆到另一个演示文稿时，请确保目标演示文稿的幻灯片尺寸与源演示文稿相同。如果尺寸不同，Aspose.Slides 不会自动重新缩放克隆的形状——它们的原始坐标和尺寸会被保留，这可能导致内容出现错位或超出幻灯片边界。

您可以在克隆母版和幻灯片之前，将目标演示文稿的幻灯片尺寸设置为与源演示文稿匹配：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

在克隆母版和幻灯片之前执行此操作。

## **FAQ**

**演讲者备注和审阅者评论会被克隆吗？**

是的。备注页和审阅评论会随克隆一起复制。如果不需要它们，请在插入后 [删除它们](/slides/zh/python-java/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会保留为 [OLE 对象](/slides/zh/python-java/manage-ole/)。在文件之间移动后，请验证数据可用性并检查刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在指定的幻灯片索引处插入克隆，并将其放入选定的 [章节](/slides/zh/python-java/slide-section/)。如果目标章节不存在，请先创建，然后将幻灯片移动到该章节。
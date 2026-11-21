---
title: 通过 Java 在 Python 中更改注释页大小和方向
linktitle: 注释页大小
type: docs
weight: 10
url: /zh/python-java/notes-size/
keywords:
- 注释页大小
- 注释方向
- 横向注释
- 纵向注释
- 讲义大小
- PowerPoint
- 演示文稿
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中读取并更改注释页尺寸，切换方向，验证保存的大小，并将注释或讲义导出为 PDF 和图像。"
---
## **概述**

使用 [Presentation.getNotesSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getNotesSize) 来访问演示文稿的注释页设置。它返回一个 [NotesSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notessize/) 对象，其 [setSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notessize/#setSize) 方法设置页面尺寸。虽然设置对象本身不能被替换，但可以通过此方法分配新的尺寸。

宽度和高度以 **点** 为单位指定，1英寸等于 72 点。例如，900 × 600 点相当于 12.5 × 8⅓ 英寸。这些设置适用于整个演示文稿，而不是单个幻灯片的注释。

| 设置 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getNotesSize) | 控制注释页尺寸以及用于讲义导出的页面尺寸。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlideSize) | 通过 [SlideSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesize/) 控制常规演示文稿幻灯片尺寸。 |

更改任一设置不会自动更改另一个。更改注释页方向也不会旋转常规幻灯片。请参阅 [幻灯片尺寸](/slides/zh/python-java/slide-size/) 以调整常规幻灯片的大小。

下面的示例使用现有的 `sample.pptx`。对于导出示例，请使用至少包含一张带有演讲者备注的幻灯片的演示文稿。每个示例都可以独立运行。

## **读取注释页尺寸和方向**

读取宽度和高度并比较以确定方向：宽的页面为横向，高的页面为纵向，尺寸相等则为方形页面。本示例以点为单位打印实际尺寸，而不假设标准纸张大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **切换为横向而不更改纸张大小**

仅更改方向时，只需交换现有的宽度和高度。这会保留两侧的长度，包括自定义纸张尺寸的长度。下面的条件可防止已为横向的页面被切换回纵向，并保持方形页面不变。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

对于纵向方向，当 `size.getWidth() > size.getHeight()` 时使用相同的赋值。除非您也想更改纸张大小，否则不要替换为 A4 或 Letter 尺寸。

## **设置并验证自定义注释页尺寸**

一次性分配两个维度，然后使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 将演示文稿写入文件。本示例设置一个 900 × 600 点的横向页面，将其保存为 PPTX，并再次打开已保存的文件以检查持久化的值。比较时允许 0.01 点的浮点误差；这并不能保证每种文件格式的精度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

预期结果为 `900.0 x 600.0 points` 和 `Size preserved: True`。检查新打开的演示文稿可验证已保存的文件，而不仅仅是内存中的设置。

## **导出注释和讲义**

页面尺寸定义了注释或讲义布局的可用区域。它们本身并不会启用这些布局：还需配置导出选项。常规幻灯片导出仍使用幻灯片尺寸。

### **导出注释为 PDF 和 PNG**

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/) 分配给 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 以在 PDF 中包含注释。此示例还使用 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/) 将带注释的第一张幻灯片渲染为 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/) 模式将注释保留在单页上；不适合的注释会被截断。PDF 使用 900 × 600 点的页面。以下使用的 1 × 1 图像比例下，PNG 为 900 × 600 像素。点描述页面几何，像素描述光栅输出，其尺寸还取决于渲染比例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

对于包含长注释的 PDF 导出，[BottomFull](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/) 可根据需要添加额外页面。不要在上述单幻灯片图像调用中使用该模式，因为它不受支持。调整大小后，检查输出是否有被截断的注释以及现有 notes-master 对象的放置；仅更改页面尺寸并不能保证所有内容都能适配。请参阅 [将 PowerPoint 转换为带注释的 PDF](/slides/zh/python-java/convert-powerpoint-to-pdf-with-notes/) 了解更多关于注释导出的信息。

### **导出讲义为 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handoutlayoutingoptions/) 在一页上显示多个幻灯片缩略图。以下示例设置一个 900 × 600 点的页面，并使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handouttype/) 将每页最多排列四张幻灯片。水平预设控制幻灯片顺序；页面方向由其宽度和高度决定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

更改页面尺寸会改变讲义网格的可用区域，但不会更改源幻灯片的尺寸。对于讲义图像，请使用带有讲义布局的 [Presentation.getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages)，而不是单个幻灯片的图像方法。在 Aspose.Slides 中，演示文稿级别的讲义渲染使用注释页尺寸，而单个幻灯片的图像调用不会生成讲义页面。请参阅 [讲义模式](/slides/zh/python-java/convert-powerpoint-in-handout-mode/) 了解布局选项。

## **查看器、导出和打印中的页面尺寸**

保持存储的演示文稿尺寸、导出的页面尺寸以及打印的纸张尺寸相互独立：

- **演示文稿查看器：** 查看器可以使用其自身的布局规则显示或打印注释。如果其他应用程序保存了文件，请重新打开并再次检查尺寸；该应用的格式转换可能会对其进行标准化。
- **导出格式：** 上述注释和讲义 PDF 示例使用了配置的页面尺寸。光栅图像使用整数像素尺寸和渲染比例，因此在图像输出中，可能会对小数点的点值进行四舍五入。导出常规幻灯片时不适用注释页尺寸。
- **打印机驱动程序：** 纸张选择、自动旋转和适合页面的设置可能会更改实际输出，而不改变演示文稿或 PDF 中存储的尺寸。对于特定纸张尺寸，请匹配打印机设置并检查打印预览。

## **常见问题**

**我可以仅为单个幻灯片设置注释尺寸吗？**

注释页尺寸是演示文稿级别的设置。各个幻灯片可以拥有不同的注释内容，但此属性不为每张幻灯片提供独立的页面尺寸。

**为什么更改注释方向没有影响我的幻灯片？**

注释页和常规幻灯片的尺寸是相互独立的。当您想要调整幻灯片本身的大小时，请使用常规幻灯片尺寸设置。

**为什么我保存或打印的结果尺寸不同？**

首先重新打开已保存的演示文稿并比较其注释尺寸。如果尺寸已更改，请检查是否在其他应用程序中保存或转换文件时更改了页面设置。如果没有，更检查导出布局、图像比例、查看器设置以及打印机的纸张选择。
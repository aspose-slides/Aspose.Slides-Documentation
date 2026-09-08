---
title: 从 PDF 或 HTML 在 Python via Java 中导入演示文稿
linktitle: 导入演示文稿
type: docs
weight: 60
url: /zh/python-java/import-presentation/
keywords:
- 导入演示文稿
- 导入幻灯片
- 导入 PDF
- 导入 HTML
- PDF 转演示文稿
- PDF 转 PPT
- PDF 转 PPTX
- PDF 转 ODP
- HTML 转演示文稿
- HTML 转 PPT
- HTML 转 PPTX
- HTML 转 ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python via Java 中将 PDF 和 HTML 内容导入 PowerPoint 演示文稿，并将结果保存为 PPTX 文件。"
---
## **简介**

Aspose.Slides for Python via Java 可以在没有 Microsoft PowerPoint 的情况下将 PDF 页面或 HTML 内容转换为 PowerPoint 幻灯片。 [SlideCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/) 类提供 [addFromPdf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addFromPdf) 和 [addFromHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addFromHtml) 用于将导入的内容追加到演示文稿。

若需更精细控制 HTML 的放置位置，可使用 [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#insertFromHtml) 在集合索引处插入生成的幻灯片，或在现有幻灯片上填充可用空间。长 HTML 会自动分页到额外的幻灯片，源可以作为字符串或流提供，外部资源可通过带基 URI 的 [ExternalResourceResolver](https://reference.aspose.com/slides/zh/python-java/aspose.slides/externalresourceresolver/) 加载。返回的 [Slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 数组标识受影响的以及新创建的幻灯片。

## **从 PDF 导入**

要将 PDF 文档转换为 PowerPoint 演示文稿，请将其内容导入幻灯片集合并将结果保存为 PPTX 文件。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. 创建一个新的 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 对象。  
2. 使用指向 PDF 文件的路径调用 [addFromPdf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addFromPdf)。  
3. 使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Pptx) 调用 [save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 将演示文稿写入 PPTX 文件。

以下 Python 示例导入 PDF 文档并将生成的幻灯片保存为 PowerPoint 演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

默认的空白幻灯片仍保留在演示文稿中，因为导入会追加幻灯片。若只保留导入的页面，可在导入前使用 [SlideCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#clear) 清空幻灯片集合。

[addFromPdf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addFromPdf) 方法返回其添加的幻灯片，这在只需处理导入的幻灯片时非常有用。

{{% alert title="提示" color="success" %}}

尝试免费的 [PDF to PowerPoint](https://products.aspose.app/slides/zh/import/pdf-to-powerpoint) 网络应用，体验此转换工作流。

{{% /alert %}}

## **从 HTML 导入**

Aspose.Slides 还可以从 HTML 文档创建幻灯片。源可以作为 HTML 文本或流提供。以下步骤使用文件流：

1. 创建一个新的 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 对象。  
2. 打开 HTML 文件进行读取，并将流传递给 [addFromHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addFromHtml)。  
3. 使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Pptx) 调用 [save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 将结果写入 PPTX 文件。

以下 Python 示例导入 HTML 文档并将生成的幻灯片保存为 PowerPoint 演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **插入 HTML 内容**

当需要将 HTML 生成的幻灯片放置在特定位置而不是追加时，请使用 [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#insertFromHtml)。索引为零基，标识导入开始的位置。

`useSlideWithIndexAsStart` 参数控制导入器如何使用该位置：

- 为 `False` 时，导入器在指定索引处创建新幻灯片并将其后的幻灯片向后移动。  
- 为 `True` 时，导入器在该索引的现有幻灯片的可用空间中开始放置内容。如果 HTML 内容不适合，Aspose.Slides 会自动分页并在起始幻灯片之后立即插入额外幻灯片。

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#insertFromHtml) 返回一个 [Slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 对象数组。当插入在新幻灯片上开始时，返回的每个项目都是新创建的；当使用现有幻灯片作为起始时，数组包括受影响的幻灯片以及随后任何新产生的溢出幻灯片。您可以检查此数组，而无需根据演示文稿的幻灯片计数计算受影响的范围。

### **将 HTML 作为新幻灯片插入**

以下示例将 HTML 作为字符串提供，并在集合索引 `1` 处插入生成的幻灯片。传入 `False` 会保持现有幻灯片不变，只是将它们向后移动以腾出空间。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **在现有幻灯片上开始**

下一个示例通过流提供 HTML。它保留模板幻灯片上的标题形状，从占用区域下方开始导入，并让长正文继续到新幻灯片。

HTML 还包含相对图像 URL。一个 [ExternalResourceResolver](https://reference.aspose.com/slides/zh/python-java/aspose.slides/externalresourceresolver/) 获取该资源，而基 URI 告诉导入器如何解析 `images/logo.png`。在本例中，该文件预计位于 `html-assets/images/logo.png`。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="警告" color="warning" %}}

不受限制的外部资源解析器可以读取 HTML 引用的本地或网络资源。对于不可信的输入，请在导入 HTML 前根据允许的方案、目录和主机列表验证并清理资源 URL。

{{% /alert %}}

## **常见问题**

**Aspose.Slides 在导入 PDF 时能检测到表格吗？**

可以。创建一个 [PdfImportOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfimportoptions/) 对象，使用 `True` 调用 [setDetectTables](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfimportoptions/#setDetectTables)，并将该选项传递给 [addFromPdf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addFromPdf)。表格识别的质量取决于源 PDF 的结构和复杂度。

{{% alert title="注释" color="info" %}}

导入 HTML 后，您还可以将幻灯片导出为 [images](/slides/zh/python-java/convert-powerpoint-to-png/)、[TIFF](/slides/zh/python-java/convert-powerpoint-to-tiff/) 或 [SVG](/slides/zh/python-java/render-slide-as-svg/)。

{{% /alert %}}
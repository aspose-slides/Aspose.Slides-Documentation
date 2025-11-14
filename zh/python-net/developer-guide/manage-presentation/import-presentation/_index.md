---
title: 用 Python 导入演示文稿
linktitle: 导入演示文稿
type: docs
weight: 60
url: /zh/python-net/import-presentation/
keywords:
- 导入 PowerPoint
- 导入演示文稿
- 导入幻灯片
- PDF 转演示文稿
- PDF 转 PPT
- PDF 转 PPTX
- PDF 转 ODP
- HTML 转演示文稿
- HTML 转 PPT
- HTML 转 PPTX
- HTML 转 ODP
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中轻松将 PDF 和 HTML 文档导入 PowerPoint 和 OpenDocument 演示文稿，实现无缝且高性能的幻灯片处理。"
---

使用 [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，您可以从其他格式的文件中导入演示文稿。Aspose.Slides 提供 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 类以允许您从 PDF、HTML 文档等中导入演示文稿。

## **从 PDF 导入 PowerPoint**

在这种情况下，您可以将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 实例化演示文稿类的对象。
2. 调用 `add_from_pdf` 方法并传入 PDF 文件。
3. 使用 `save` 方法将文件保存为 PowerPoint 格式。

以下 Python 代码演示了 PDF 到 PowerPoint 的操作：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="提示" color="primary" %}} 

您可能想要查看 **Aspose 免费** [PDF 转 PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) 在线应用，因为它是此处描述的过程的实时实现。

{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在这种情况下，您可以将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 调用 `add_from_html` 方法并传入 HTML 文件。
3. 使用 `save` 方法将文件保存为 PowerPoint 文档。

以下 Python 代码演示了 HTML 到 PowerPoint 的操作：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

您还可以使用 Aspose.Slides 将 HTML 转换为其他流行的文件格式：

* [HTML 转图片](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}
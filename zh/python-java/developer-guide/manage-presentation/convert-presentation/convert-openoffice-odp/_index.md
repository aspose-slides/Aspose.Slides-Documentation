---
title: 在 Python 中转换 OpenDocument 演示文稿
linktitle: 转换 OpenDocument
type: docs
weight: 10
url: /zh/python-java/convert-openoffice-odp/
keywords:
- 转换 ODP
- ODP 转 PDF
- ODP 转 HTML
- ODP 转 TIFF
- ODP 转 PPT
- ODP 转 PPTX
- ODP 转 XPS
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 OpenDocument (ODP) 演示文稿转换为 PDF、HTML 等格式，无需安装 OpenOffice 或 LibreOffice。"
---
## **简介**

Aspose.Slides for Python via Java 允许您将 OpenDocument (ODP) 演示文稿转换为 PDF、HTML、TIFF、XPS、PPT 和 PPTX 等格式。ODP 转换使用与 PowerPoint 转换相同的 API：使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 加载源文件，并使用 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 选择输出格式。

## **将 ODP 转换为 PDF**

在运行示例之前，请先按照 [安装说明](/slides/zh/python-java/installation/) 操作。将名为 `pres.odp` 的 ODP 演示文稿放在工作目录中。以下代码在必要时启动 JVM，加载演示文稿，并将其保存为 `pres.pdf`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **不同应用程序中的 OpenDocument 演示文稿**

ODP 演示文稿在 PowerPoint 和 LibreOffice/OpenOffice Impress 中可能显示不同，因为这些应用程序支持的演示功能和渲染行为不同。当布局依赖于复杂格式时，请检查转换后的演示文稿。

兼容性差异可能影响：

- 表格，包括相对于其他形状的堆叠顺序以及对图片填充的支持。
- 文本旋转和对齐方式。
- 应用于文本的图片、渐变和图案填充。
- 编号和项目符号列表。

下图显示了在 LibreOffice Impress 中创建的列表：

![LibreOffice Impress 中的 ODP 列表示例](odp-list-example.png)

Aspose.Slides 为了兼容 LibreOffice/OpenOffice Impress，会保存 ODP 列表。

有关功能兼容性的详细信息，请参阅 [Microsoft 的 OpenDocument 演示文稿格式指南](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)。

## **常见问题**

**如果我的 ODP 文件在转换后格式发生变化该怎么办？**

ODP 和 PowerPoint 使用不同的演示模型。表格、字体和填充样式可能会呈现不同。请确保所需字体可用，检查输出结果，并在必要时调整布局或格式。

**转换 ODP 文件是否需要安装 OpenOffice 或 LibreOffice？**

不需要。Aspose.Slides for Python via Java 在没有任何这些应用程序的情况下处理演示文稿。只需兼容的 Java 运行时和 Python 包。

**在将 ODP 演示文稿转换为 PDF 时，我可以自定义 PDF 输出吗？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 配置 PDF 导出设置，例如图像质量和压缩。

**我可以在服务器或容器中转换 ODP 演示文稿吗？**

可以。只需在目标环境中安装 Python 包、兼容的 Java 运行时，以及演示文稿所需的字体。无需任何办公应用程序。
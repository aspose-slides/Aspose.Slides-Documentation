---
title: 在 Python via Java 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/python-java/create-presentation/
keywords:
- 创建演示文稿
- 新演示文稿
- 创建 PPT
- 新 PPT
- 创建 PPTX
- 新 PPTX
- 创建 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中创建演示文稿——生成 PPT、PPTX 和 ODP 文件，支持 OpenDocument，并可通过编程方式保存，确保可靠的结果。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Python via Java 创建演示文稿、在第一张幻灯片上添加带文本的形状，并将结果保存为 PPTX 文件。FAQ 包含输出格式、模板、幻灯片尺寸、内存使用、线程、授权、数字签名和 VBA 支持等内容。

在开始之前，请安装 Python、JDK、JPype 和 Aspose.Slides for Python via Java。有关 Windows、Linux 和 macOS 的步骤，请参阅[安装](/slides/zh/python-java/installation/)。

## **创建演示文稿**

在 Aspose.Slides for Python via Java 中从头创建 PowerPoint 文件与实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类一样简单。构造函数会自动提供一张空白幻灯片，让您立即拥有用于放置形状、文本、图表或任何其他内容的画布。修改该幻灯片或添加新幻灯片后，您可以将结果持久化为 PPTX、旧版 PPT，甚至 OpenDocument 格式。下面的简短代码示例演示了在第一张幻灯片上添加一个简单形状的工作流。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引 0 获取第一张幻灯片。  
1. 使用 [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAutoShape) 添加类型为 [ShapeType.Cloud](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapetype/#Cloud) 的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
1. 通过 [TextFrame.setText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#setText) 设置形状的文本。  
1. 使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 并指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Pptx) 保存演示文稿。

下面的示例在 JVM 未启动时启动它，向第一张幻灯片添加一个带文本的云形状，并保存演示文稿。将其保存为 *create_presentation.py*：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 创建一个包含单张空白幻灯片的演示文稿。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加云形状并设置其文本。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在已安装相应包的环境中运行脚本：

```sh
python create_presentation.py
```

云的左上角距幻灯片左边缘和上边缘各 20 点，云的宽度为 200 点，高度为 80 点。脚本将在当前工作目录保存 *new_presentation.pptx*，其中包含一张带有云形状及其文本的幻灯片。JVM 将持续运行直至 Python 进程退出；详情请参阅[限制和 API 差异](/slides/zh/python-java/limitations-and-api-differences/#import-the-library)。如果未授权，Aspose.Slides 还会在保存的每张幻灯片上添加评估水印文本框；请参阅[授权](/slides/zh/python-java/licensing/)。

结果如下：

![The new presentation](new_presentation.png)

## **FAQ**

**可以将新演示文稿保存为何种格式？**

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/python-java/save-presentation/)，并导出为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/python-java/convert-powerpoint-to-html/)、[SVG](/slides/zh/python-java/render-a-slide-as-an-svg-image/) 和 [图像](/slides/zh/python-java/convert-powerpoint-to-png/)，等等。

**可以从模板 (POTX/POTM) 开始并保存为普通 PPTX 吗？**

可以。加载模板后保存为所需格式；POTX/POTM/PPTM 等格式 [受支持](/slides/zh/python-java/supported-file-formats/)。

**创建演示文稿时如何控制幻灯片尺寸/宽高比？**

设置 [幻灯片尺寸](/slides/zh/python-java/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标使用什么单位？**

使用点（points）：1 英寸等于 72 单位。

**如何处理包含大量媒体文件的大型演示文稿以降低内存使用？**

使用 [BLOB 管理策略](/slides/zh/python-java/manage-blob/)，通过临时文件限制内存存储，并优先采用基于文件的工作流而非纯内存流。

**可以并行创建/保存演示文稿吗？**

不能在 [多个线程](/slides/zh/python-java/multithreading/) 中操作同一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例。请为每个线程或进程使用独立的实例。

**如何移除试用水印和限制？**

在每个进程中 [应用授权](/slides/zh/python-java/licensing/)。授权 XML 必须保持原样，若涉及多线程，授权设置应同步进行。

**可以对创建的 PPTX 进行数字签名吗？**

可以。支持演示文稿的 [数字签名](/slides/zh/python-java/digital-signature-in-powerpoint/)（添加和验证）。

**创建的演示文稿是否支持宏 (VBA)？**

支持。您可以 [创建/编辑 VBA 项目](/slides/zh/python-java/presentation-via-vba/) 并保存为支持宏的文件，例如 PPTM/PPSM。
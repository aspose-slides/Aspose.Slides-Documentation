---
title: 在 Python via Java 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/python-java/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新建 PPT
- 创建 PPTX
- 新建 PPTX
- 创建 ODP
- 新建 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中创建演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于 OpenDocument 支持，并以编程方式保存以获得可靠的结果。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Python via Java 创建演示文稿、在第一张幻灯片上添加带文本的形状，并将结果保存为 PPTX 文件。常见问题涵盖了输出格式、模板、幻灯片尺寸、内存使用、线程、授权、数字签名以及 VBA 支持等内容。

## **创建演示文稿**

在 Aspose.Slides for Python via Java 中从头创建 PowerPoint 文件就像实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类一样简单。构造函数会自动提供一个包含单张幻灯片的空白演示文稿，为形状、文本、图表或任何其他内容提供立即可用的画布。修改该幻灯片或添加新幻灯片后，您可以将结果持久化为 PPTX、旧版 PPT，甚至 OpenDocument 格式。下面的简短代码示例演示了通过在第一张幻灯片上添加一个简单形状来实现此工作流。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取第一张幻灯片。  
3. 使用 [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAutoShape) 添加类型为 [ShapeType.Cloud](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapetype/#Cloud) 的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。  
4. 通过 [TextFrame.setText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#setText) 设置形状的文本。  
5. 使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 并指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Pptx) 保存演示文稿。

以下示例需要 Aspose.Slides for Python via Java 和兼容的 Java 运行时。如果 JVM 尚未启动，它会被启动，随后在第一张幻灯片上添加云形状，并保存演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 创建一个包含一张空白幻灯片的演示文稿。
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

结果：

![新演示文稿](new_presentation.png)

## **常见问题**

**可以将新演示文稿保存为哪些格式？**

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/python-java/save-presentation/)，并可以导出为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/python-java/convert-powerpoint-to-html/)、[SVG](/slides/zh/python-java/render-slide-as-svg/)、以及 [图像](/slides/zh/python-java/convert-powerpoint-to-png/) 等格式。

**可以从模板（POTX/POTM）开始并保存为普通 PPTX 吗？**

可以。加载模板后保存为所需格式；POTX、POTM、PPTM 等格式 [受支持](/slides/zh/python-java/supported-file-formats/)。

**创建演示文稿时如何控制幻灯片尺寸/宽高比？**

设置 [幻灯片尺寸](/slides/zh/python-java/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标的单位是什么？**

使用点（point）：1 英寸等于 72 单位。

**如何处理包含大量媒体文件的超大演示文稿以降低内存使用？**

使用 [BLOB 管理策略](/slides/zh/python-java/manage-blob/)，通过临时文件限制内存存储，并倾向于基于文件的工作流而非纯内存流。

**可以并行创建/保存演示文稿吗？**

不能从 [多个线程](/slides/zh/python-java/multithreading/) 操作同一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例。请为每个线程或进程运行独立的实例。

**如何去除试用水印和限制？**

在每个进程中 [应用授权](/slides/zh/python-java/licensing/)。授权 XML 必须保持未修改，且在多线程环境下应同步授权设置。

**可以对创建的 PPTX 进行数字签名吗？**

可以。支持对演示文稿进行 [数字签名](/slides/zh/python-java/digital-signature-in-powerpoint/)（添加和验证）。

**在创建的演示文稿中是否支持宏（VBA）？**

支持。您可以 [创建/编辑 VBA 项目](/slides/zh/python-java/presentation-via-vba/)，并保存为支持宏的文件，如 PPTM/PPSM。
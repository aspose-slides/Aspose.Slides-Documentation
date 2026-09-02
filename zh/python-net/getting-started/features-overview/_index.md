---
title: 功能概览
type: docs
weight: 20
url: /zh/python-net/features-overview/
keywords:
- 功能
- 支持的平台
- 文件格式
- 转换
- 渲染
- 格式化
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET：一个强大的 API，可高效地创建、编辑、自动化和转换 PowerPoint 与 OpenDocument 演示文稿。"
---
## **支持的平台**
Aspose.Slides for Python via .NET 可在 Windows x64 或 x86，以及安装了 Python 3.5 或更高版本的各种 Linux 发行版上使用。目标 Linux 平台还有以下额外要求：
- GCC-6 运行时库（或更高）
- .NET Core Runtime 的依赖项。**不需要**安装 .NET Core Runtime 本身
- 对于 Python 3.5-3.7：需要使用 `pymalloc` 构建的 Python。`--with-pymalloc` Python 构建选项默认已启用。通常，`pymalloc` 构建的 Python 文件名后缀为 `m`。
- `libpython` 共享 Python 库。`--enable-shared` Python 构建选项默认未启用，部分 Python 发行版不包含 `libpython` 共享库。对于某些 Linux 平台，可使用包管理器安装 `libpython` 共享库，例如：`sudo apt-get install libpython3.7`。常见问题是 `libpython` 库被安装在与系统标准共享库位置不同的目录。可以通过在编译 Python 时使用构建选项设置替代库路径，或在系统标准共享库位置创建指向 `libpython` 库文件的符号链接来解决。通常，Python 3.5-3.7 的 `libpython` 共享库文件名为 `libpythonX.Ym.so.1.0`，Python 3.8 及以后为 `libpythonX.Y.so.1.0`（例如：`libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

如果需要支持更多平台，请查找 “双胞胎” 产品 Aspose.Slides for .NET 或 Aspose.Slides for Java。

## **文件格式和转换**
Aspose.Slides for Python via .NET 支持大多数 PowerPoint 文档格式，并可将它们导出为组织广泛使用并相互交换的流行格式。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/zh/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET 为此演示文稿格式提供最快的处理速度。|
|[PPT to PPTX conversion](/slides/zh/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET 支持 PPT 转 PPTX 的转换。|
|[Portable Document Format (PDF)](/slides/zh/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|您可以使用单个方法将所有受支持的文件格式导出为 Adobe Portable Document Format (PDF) 文档。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/zh/python-net/convert-powerpoint-to-xps/)|您可以使用单个方法将所有受支持的文件格式导出为 XML Parser Specification (XPS) 文档。|
|[Tagged Image File Format (TIFF)](/slides/zh/python-net/convert-powerpoint-to-tiff/)|您可以将所有受支持的演示文稿文件格式导出为 Tagged Image File Format (TIFF)。|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/zh/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET 支持将 PresentationEx 转换为 HTML 格式。|

## **演示文稿渲染**
Aspose.Slides for Python via .NET 支持将演示文稿中的幻灯片高保真渲染为多种图形格式。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|.NET Supported Image Formats|使用 Aspose.Slides for Python via .NET，您可以将演示文稿幻灯片及幻灯片中的图像渲染为所有 .NET 支持的图形格式，如 TIFF、PNG、BMP、JPEG、GIF 和元文件。|
|SVG Format|Aspose.Slides for Python via .NET 还提供内置方法，可将演示文稿幻灯片导出为可缩放矢量图形 (SVG) 格式。|

## **内容功能**
Aspose.Slides for Python via .NET 允许您访问、修改或创建演示文稿几乎所有的项目或内容。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|Master Slides|母版幻灯片定义普通幻灯片的布局。Aspose.Slides for Python via .NET 允许您访问并修改演示文稿的母版幻灯片。|
|Normal Slides|使用 Aspose.Slides for Python via .NET，您可以创建不同类型的新幻灯片；也可以访问并修改演示文稿中已有的幻灯片。|
|Cloning / Copying Slides|Aspose.Slides for Python via .NET 提供内置方法，可在同一演示文稿中克隆或复制现有幻灯片。您还可以将复制或克隆的幻灯片从一个演示文稿使用到另一个。由于幻灯片从母版幻灯片继承布局，内置克隆方法在克隆时会自动复制母版。|
|Managing Slides sections|提供方法将幻灯片组织到演示文稿的不同节中。|
|Place Holders and Text Holders|您可以访问幻灯片中的占位符和文字占位符。此外，还可以使用相应方法从头创建带有文字占位符的幻灯片。|
|Header and Footers|Aspose.Slides for Python via .NET 简化了幻灯片中页眉/页脚的处理。|
|Notes in Slides|使用 Aspose.Slides for Python via .NET，您可以访问并修改与幻灯片关联的备注，还可以添加新备注。|
|Finding a Shape|您还可以使用与形状关联的替代文本在幻灯片中查找特定形状。|
|Backgrounds|Aspose.Slides for Python via .NET 允许您处理母版或普通幻灯片的背景。|
|Text Boxes|文本框可以从头创建。您可以访问已有的文本框，并在不丢失原始文本格式的情况下修改其文本。|
|Rectangle Shapes|您可以使用 Aspose.Slides for Python via .NET 创建或修改矩形形状。|
|Poly Line Shapes|您可以使用 Aspose.Slides for Python via .NET 创建或修改折线形状。|
|Ellipse Shapes|您可以使用 Aspose.Slides for Python via .NET 创建或修改椭圆形状。|
|Group Shapes|Aspose.Slides for Python via .NET 支持组合形状。|
|Auto Shapes|Aspose.Slides for Python via .NET 支持自动形状。|
|SmartArt|Aspose.Slides for Python via .NET 提供对 MS PowerPoint 中 SmartArt 形状的支持。|
|Charts|Aspose.Slides for Python via .NET 提供对 PowerPoint 中 MSO 图表的支持。|
|Shapes Serialization|Aspose.Slides for Python via .NET 支持大量形状。当缺少某种形状的直接支持时，您可以使用序列化方法将该形状从已有幻灯片序列化，然后按需重新使用。|
|Picture Frames|您可以使用 Aspose.Slides for Python via .NET 在图片框中管理图片。|
|Audio Frames|您可以在音频框中链接或嵌入音频文件。|
|Video Frames|您可以在视频框中处理视频文件。Aspose.Slides for Python via .NET 还支持链接和嵌入式视频。|
|OLE Frame|您可以使用 Aspose.Slides for Python via .NET 在 OLE 框中管理 OLE 对象。|
|Tables|Aspose.Slides for Python via .NET 支持幻灯片中的表格。|
|ActiveX Controls|支持 ActiveX 控件。|
|VBA Macros|支持在演示文稿中管理 VBA 宏。|
|Text Frame|您可以通过与形状关联的文本框访问该形状的文本。|
|Text Scanning|您可以使用内置扫描方法在演示文稿或幻灯片级别扫描文本。|
|Animations|您可以对形状应用动画。|
|Slide Shows|Aspose.Slides for Python via .NET 支持幻灯片放映和幻灯片切换。|

## **格式化功能**
使用 Aspose.Slides for Python via .NET，您可以对演示文稿中幻灯片的文本和形状进行格式化。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|Text Formatting|<p>在 Aspose.Slides for Python via .NET 中，您可以通过与形状关联的文本框管理文本。因此，您可以使用文本框中的段落和文本段对文本进行格式化。这些文本元素可通过 Aspose.Slides for Python via .NET 进行格式化。</p><p>- 字体类型</p><p>- 字体大小</p><p>- 字体颜色</p><p>- 字体色调</p><p>- 段落对齐</p><p>- 段落项目符号</p><p>- 段落方向</p>|
|Shape Formatting|<p>在 Aspose.Slides for Python via .NET 中，幻灯片的基本元素是形状。您可以使用 Aspose.Slides for Python via .NET 对这些形状元素进行格式化：</p><p>- 位置</p><p>- 大小</p><p>- 边线</p><p>- 填充（包括图案、渐变、纯色）</p><p>- 文本</p><p>- 图像</p>|

## **FAQ**

### 我是否需要在服务器/电脑上安装 Microsoft PowerPoint 才能使库工作？

不需要。PowerPoint 不是必需的；Aspose.Slides 是一个独立的引擎，用于创建、编辑、转换和渲染演示文稿。

### 多线程是如何工作的？可以并行处理吗？

在不同线程中处理不同文档是安全的；同一个 [presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象不能被 [multiple threads](/slides/zh/python-net/multithreading/) 同时使用。

### 是否支持文件密码和加密？

是的。您可以[打开受密码保护的演示文稿](/slides/zh/python-net/password-protected-presentation/)，设置或移除打开和写入密码，并检查保护状态。

### 在 Linux 容器中需要关注字体包吗？

是的。建议安装常用字体包，或在应用程序中显式[指定字体目录](/slides/zh/python-net/custom-font/)，以避免意外的字体替换。

### 评估版有什么限制？

在[评估模式](/slides/zh/python-net/licensing/)下，输出会添加水印并且存在某些限制；您可以获取[30 天临时许可证](https://purchase.aspose.com/temporary-license/)以进行完整功能测试。

### 是否支持将外部格式导入演示文稿（PDF/HTML → PPTX）？

是的。您可以将[PDF 页面和 HTML 内容](/slides/zh/python-net/import-presentation/)添加到演示文稿中，从而将它们转换为幻灯片。
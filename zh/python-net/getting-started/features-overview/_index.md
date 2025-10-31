---
title: 功能概述
type: docs
weight: 20
url: /zh/python-net/features-overview/
keywords:
- 功能
- 支持的平台
- 文件格式
- 转换
- 渲染
- 打印
- 格式化
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 .NET 使用 Aspose.Slides for Python：一个强大的 API，用于高效创建、编辑、自动化和转换 PowerPoint 与 OpenDocument 演示文稿。"
---

## **支持的平台**
Aspose.Slides for Python via .NET 可在 Windows x64 或 x86 以及安装了 Python 3.5 或更高版本的各种 Linux 发行版上使用。目标 Linux 平台还有以下附加要求：
- GCC-6 运行时库（或更高）
- .NET Core Runtime 的依赖项。无需安装 .NET Core Runtime 本身
- 对于 Python 3.5-3.7：需要 `pymalloc` 构建的 Python。默认启用 `--with-pymalloc` 构建选项。通常，`pymalloc` 构建的 Python 文件名带有 `m` 后缀。
- `libpython` 共享 Python 库。默认禁用 `--enable-shared` 构建选项，一些 Python 发行版不包含 `libpython` 共享库。对于某些 Linux 平台，可通过包管理器安装 `libpython` 共享库，例如：`sudo apt-get install libpython3.7`。常见问题是 `libpython` 库安装在了非系统标准共享库路径下。可以通过在编译 Python 时使用构建选项设置替代库路径，或在系统标准共享库目录下创建指向 `libpython` 库文件的符号链接来解决。通常，Python 3.5-3.7 的 `libpython` 共享库文件名为 `libpythonX.Ym.so.1.0`，而 Python 3.8 及以上为 `libpythonX.Y.so.1.0`（例如：`libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

如果需要支持更多平台，请查找 “双胞胎兄弟” 产品 Aspose.Slides for .NET 或 Aspose.Slides for Java。

## **文件格式和转换**
Aspose.Slides for Python via .NET 支持大多数 PowerPoint 文档格式，并且可以将它们导出为组织广泛使用和交换的流行格式。详情如下：

|**功能**|**描述**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/zh/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET 提供此演示文稿格式的最快处理速度。|
|[PPT to PPTX conversion](/slides/zh/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET 支持 PPT 转 PPTX 的转换。|
|[Portable Document Format (PDF)](/slides/zh/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|您可以使用单一方法将所有受支持的文件格式导出为 Adobe 可移植文档格式（PDF）文档。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|您可以使用单一方法将所有受支持的文件格式导出为 XML Parser Specification（XPS）文档。|
|[Tagged Image File Format (TIFF)](/slides/zh/python-net/convert-powerpoint-to-tiff/)|您可以将所有受支持的演示文稿文件格式导出为 Tagged Image File Format（TIFF）。|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET 支持将 PresentationEx 转换为 HTML 格式。|

## **渲染和打印**
Aspose.Slides for Python via .NET 支持将演示文稿中的幻灯片高保真渲染为各种图形格式。详情如下：

|**功能**|**描述**|
| :- | :- |
|.NET 支持的图像格式|使用 Aspose.Slides for Python via .NET，您可以将演示文稿幻灯片及幻灯片上的图像渲染为所有 .NET 支持的图形格式，如 TIFF、PNG、BMP、JPEG、GIF 和元文件。|
|SVG 格式|Aspose.Slides for Python via .NET 还提供内置方法，允许您将演示文稿幻灯片导出为可缩放矢量图形（SVG）格式。|
|演示文稿打印|最新版本的 Aspose.Slides for Python via .NET 提供带有不同选项的内置打印方法。|

## **内容功能**
Aspose.Slides for Python via .NET 允许您访问、修改或创建演示文稿中几乎所有的项目或内容。详情如下：

|**功能**|**描述**|
| :- | :- |
|母版幻灯片|母版幻灯片定义普通幻灯片的布局。Aspose.Slides for Python via .NET 允许您访问和修改演示文稿的母版幻灯片。|
|普通幻灯片|使用 Aspose.Slides for Python via .NET，您可以创建不同类型的新幻灯片；也可以访问和修改演示文稿中的现有幻灯片。|
|克隆 / 复制幻灯片|Aspose.Slides for Python via .NET 提供内置方法，允许您克隆或复制演示文稿中的现有幻灯片。您还可以将复制或克隆的幻灯片从一个演示文稿应用到另一个。由于幻灯片从母版幻灯片继承布局，内置克隆方法会在克隆时自动复制母版。|
|管理幻灯片章节|提供在演示文稿中将幻灯片组织到不同章节的方法。|
|占位符和文本占位符|您可以访问幻灯片中的占位符和文本占位符。此外，您可以使用相应方法从头创建带有文本占位符的幻灯片。|
|页眉和页脚|Aspose.Slides for Python via .NET 便于在幻灯片中处理页眉/页脚。|
|幻灯片备注|使用 Aspose.Slides for Python via .NET，您可以访问和修改与幻灯片关联的备注，并可以添加新备注。|
|查找形状|您还可以使用形状的替代文本在幻灯片中查找特定形状。|
|背景|Aspose.Slides for Python via .NET 允许您处理与母版或普通幻灯片关联的背景。|
|文本框|可以从头创建文本框。您也可以访问现有文本框，并在不丢失原始文本格式的情况下修改其文本。|
|矩形形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改矩形形状。|
|折线形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改折线形状。|
|椭圆形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改椭圆形状。|
|组合形状|Aspose.Slides for Python via .NET 支持组合形状。|
|自动形状|Aspose.Slides for Python via .NET 支持自动形状。|
|SmartArt|Aspose.Slides for Python via .NET 为 MS PowerPoint 中的 SmartArt 形状提供支持。|
|图表|Aspose.Slides for Python via .NET 为 PowerPoint 中的 MSO 图表提供支持。|
|形状序列化|Aspose.Slides for Python via .NET 支持大量形状。当缺少某种形状的直接支持时，您可以使用序列化方法将该形状从现有幻灯片序列化出来，以便后续按需使用。|
|图片框|您可以使用 Aspose.Slides for Python via .NET 管理图片框中的图片。|
|音频框|您可以在音频框中链接或嵌入音频文件。|
|视频框|您可以在视频框中处理视频文件。Aspose.Slides for Python via .NET 还提供对链接和嵌入视频的支持。|
|OLE 框|您可以使用 Aspose.Slides for Python via .NET 管理 OLE 框中的 OLE 对象。|
|表格|Aspose.Slides for Python via .NET 支持幻灯片中的表格。|
|ActiveX 控件|支持 ActiveX 控件。|
|VBA 宏|支持在演示文稿中管理 VBA 宏。|
|文本框架|您可以通过与形状关联的文本框架访问任何形状的文本。|
|文本扫描|您可以使用内置扫描方法在演示文稿或幻灯片层面对文本进行扫描。|
|动画|您可以对形状应用动画。|
|幻灯片放映|Aspose.Slides for Python via .NET 支持幻灯片放映和幻灯片切换。|

## **格式化功能**
使用 Aspose.Slides for Python via .NET，您可以对演示文稿中幻灯片上的文本和形状进行格式化。详情如下：

|**功能**|**描述**|
| :- | :- |
|文本格式化|<p>在 Aspose.Slides for Python via .NET 中，您可以通过形状关联的文本框来管理文本。因此，您可以使用与文本框关联的段落和文本段来格式化文本。这些文本元素可通过 Aspose.Slides for Python via .NET 进行格式化。</p><p>- 字体类型</p><p>- 字体大小</p><p>- 字体颜色</p><p>- 字体色调</p><p>- 段落对齐</p><p>- 段落项目符号</p><p>- 段落方向</p>|
|形状格式化|<p>在 Aspose.Slides for Python via .NET 中，幻灯片的基本元素是形状。您可以使用 Aspose.Slides for Python via .NET 对这些形状进行以下格式化：</p><p>- 位置</p><p>- 大小</p><p>- 线条</p><p>- 填充（包括图案、渐变、纯色）</p><p>- 文本</p><p>- 图像</p>|

## **常见问题解答**

**是否需要在服务器/电脑上安装 Microsoft PowerPoint 才能使库工作？**

不需要。PowerPoint 不是必装项；Aspose.Slides 是一个独立的引擎，用于创建、编辑、转换和渲染演示文稿。

**多线程是如何工作的？可以并行处理吗？**

在不同线程中处理不同文档是安全的；同一个[演示文稿](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)对象不能被[多个线程](/slides/zh/python-net/multithreading/)同时使用。

**是否支持文件密码和加密？**

是的。您可以[打开受密码保护的演示文稿](/slides/zh/python-net/password-protected-presentation/)、设置或移除打开和写入密码，并检查保护状态。

**在 Linux 容器中需要关注字体包吗？**

是的。建议安装常用字体包，或在应用程序中显式[指定字体目录](/slides/zh/python-net/custom-font/)，以避免出现意外的字体替换。

**评估版是否有限制？**

在[评估模式](/slides/zh/python-net/licensing/)下，输出会添加水印并存在一定限制；可获取[30 天临时许可证](https://purchase.aspose.com/temporary-license/)以进行完整功能测试。

**是否支持将外部格式导入演示文稿（PDF/HTML → PPTX）？**

是的。您可以将[PDF 页面和 HTML 内容](/slides/zh/python-net/import-presentation/)添加到演示文稿中，将它们转换为幻灯片。
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
- 打印
- 格式化
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET：一个功能强大的 API，可高效地创建、编辑、自动化和转换 PowerPoint 与 OpenDocument 演示文稿。"
---

## **支持的平台**
Aspose.Slides for Python via .NET 可在 Windows x64 或 x86，以及安装了 Python 3.5 或更高版本的各种 Linux 发行版上使用。目标 Linux 平台还有以下额外要求：
- GCC-6 运行时库（或更高）
- .NET Core Runtime 的依赖项。**不需要**安装 .NET Core Runtime 本身
- 对于 Python 3.5-3.7：需要 `pymalloc` 构建的 Python。默认启用 `--with-pymalloc` 构建选项。通常，`pymalloc` 构建的 Python 文件名带有 `m` 后缀。
- `libpython` 共享 Python 库。默认情况下 `--enable-shared` Python 构建选项是关闭的，一些 Python 发行版不包含 `libpython` 共享库。对于某些 Linux 平台，可以通过包管理器安装 `libpython` 共享库，例如：`sudo apt-get install libpython3.7`。常见问题是 `libpython` 库安装在不同于系统标准共享库位置的目录中。可以在编译 Python 时使用构建选项设置备用库路径，或在系统标准共享库目录下为 `libpython` 库文件创建符号链接来解决。通常，Python 3.5-3.7 的 `libpython` 共享库文件名为 `libpythonX.Ym.so.1.0`，而 Python 3.8 及以上为 `libpythonX.Y.so.1.0`（例如：`libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

如果需要支持更多平台，请查阅其“兄弟”产品 Aspose.Slides for .NET 或 Aspose.Slides for Java。

## **文件格式和转换**
Aspose.Slides for Python via .NET 支持大多数 PowerPoint 文档格式，并且可以将它们导出为组织广泛使用并相互交换的流行格式。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|[Microsoft PowerPoint（PPT）](/slides/zh/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET 为该演示文稿格式提供最快的处理速度。|
|[PPT 到 PPTX 转换](/slides/zh/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET 支持 PPT 转 PPTX 的转换。|
|[便携式文档格式（PDF）](/slides/zh/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|您可以使用单一方法将所有受支持的文件格式导出为 Adobe PDF 文档。|
|[XML 打印规范（XPS）](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|您可以使用单一方法将所有受支持的文件格式导出为 XML 打印规范（XPS）文档。|
|[标记图像文件格式（TIFF）](/slides/zh/python-net/convert-powerpoint-to-tiff/)|您可以将所有受支持的演示文稿文件格式导出为标记图像文件格式（TIFF）。|
|[PPTX 到 HTML 转换](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET 支持将 PresentationEx 转换为 HTML 格式。|

## **渲染和打印**
Aspose.Slides for Python via .NET 支持将演示文稿中的幻灯片高保真渲染为各种图形格式。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|.NET 支持的图像格式|使用 Aspose.Slides for Python via .NET，您可以将演示文稿幻灯片及幻灯片中的图像渲染为所有 .NET 支持的图形格式，如 TIFF、PNG、BMP、JPEG、GIF 和元文件。|
|SVG 格式|Aspose.Slides for Python via .NET 还提供内置方法，允许您将演示文稿幻灯片导出为可缩放矢量图形（SVG）格式。|
|演示文稿打印|最新版本的 Aspose.Slides for Python via .NET 提供带有不同选项的内置打印方法。|

## **内容功能**
Aspose.Slides for Python via .NET 允许您访问、修改或创建几乎所有演示文稿的项目或内容。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|母版幻灯片|母版幻灯片定义普通幻灯片的布局。Aspose.Slides for Python via .NET 允许您访问和修改演示文稿的母版幻灯片。|
|普通幻灯片|使用 Aspose.Slides for Python via .NET，您可以创建不同类型的新幻灯片；还可以访问并修改演示文稿中已有的幻灯片。|
|克隆/复制幻灯片|Aspose.Slides for Python via .NET 提供内置方法，允许您克隆或复制演示文稿中的现有幻灯片。您还可以将复制或克隆的幻灯片从一个演示文稿使用到另一个演示文稿。由于幻灯片从母版幻灯片继承布局，内置克隆方法在克隆时会自动复制母版。|
|管理幻灯片章节|提供方法在演示文稿内部将幻灯片组织到不同章节。|
|占位符和文字占位符|您可以访问幻灯片中的占位符和文字占位符。此外，您可以使用相应方法从头创建带有文字占位符的幻灯片。|
|页眉和页脚|Aspose.Slides for Python via .NET 方便地处理幻灯片的页眉/页脚。|
|幻灯片备注|使用 Aspose.Slides for Python via .NET，您可以访问并修改与幻灯片关联的备注，还可以添加新备注。|
|查找形状|您还可以通过形状的备用文本在幻灯片中查找特定形状。|
|背景|Aspose.Slides for Python via .NET 允许您处理与母版或普通幻灯片关联的背景。|
|文本框|可以从头创建文本框。您可以访问已有的文本框，也可以在不丢失原始文本格式的情况下修改其文本。|
|矩形形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改矩形形状。|
|折线形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改折线形状。|
|椭圆形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改椭圆形状。|
|组合形状|Aspose.Slides for Python via .NET 支持组合形状。|
|自动形状|Aspose.Slides for Python via .NET 支持自动形状。|
|SmartArt|Aspose.Slides for Python via .NET 为 MS PowerPoint 中的 SmartArt 形状提供支持。|
|图表|Aspose.Slides for Python via .NET 为 PowerPoint 中的 MSO 图表提供支持。|
|形状序列化|Aspose.Slides for Python via .NET 支持大量形状。当产品本身不支持某种形状时，您可以使用序列化方法将该形状从现有幻灯片序列化，然后按需再次使用。|
|图片框|您可以使用 Aspose.Slides for Python via .NET 在图片框中管理图片。|
|音频框|您可以在音频框中链接或嵌入音频文件。|
|视频框|您可以在视频框中处理视频文件。Aspose.Slides for Python via .NET 还提供对链接视频和嵌入视频的支持。|
|OLE 框|您可以在 OLE 框中管理 OLE 对象。|
|表格|Aspose.Slides for Python via .NET 支持幻灯片中的表格。|
|ActiveX 控件|支持 ActiveX 控件。|
|VBA 宏|支持在演示文稿中管理 VBA 宏。|
|文本框架|您可以通过与形状关联的文本框架访问该形状的文本。|
|文本扫描|您可以使用内置扫描方法在演示文稿或幻灯片级别扫描文本。|
|动画|您可以在形状上应用动画。|
|幻灯片放映|Aspose.Slides for Python via .NET 支持幻灯片放映和幻灯片切换。|

## **格式化功能**
使用 Aspose.Slides for Python via .NET，您可以对演示文稿中的文本和形状进行格式化。详细信息如下：

|**功能**|**描述**|
| :- | :- |
|文本格式化|<p>在 Aspose.Slides for Python via .NET 中，您可以通过与形状关联的文本框来管理文本。因此，您可以使用与文本框关联的段落和文本块来格式化文本。这些文本元素可以通过 Aspose.Slides for Python via .NET 进行格式化。</p><p>- 字体类型</p><p>- 字体大小</p><p>- 字体颜色</p><p>- 字体色调</p><p>- 段落对齐</p><p>- 段落项目符号</p><p>- 段落方向</p>|
|形状格式化|<p>在 Aspose.Slides for Python via .NET 中，幻灯片的基本元素是形状。您可以使用 Aspose.Slides for Python via .NET 对这些形状元素进行以下格式化：</p><p>- 位置</p><p>- 大小</p><p>- 线条</p><p>- 填充（包括图案、渐变、纯色）</p><p>- 文本</p><p>- 图像</p>|

## **常见问题**

**我需要在服务器/电脑上安装 Microsoft PowerPoint 才能使用该库吗？**

不需要。PowerPoint 并非必装；Aspose.Slides 是一个独立的引擎，用于创建、编辑、转换和渲染演示文稿。

**多线程是如何工作的？可以并行处理吗？**

在不同线程中处理不同文档是安全的；同一个 [presentation](/slides/zh/python-net/multithreading/) 对象不能被 [multiple threads](/slides/zh/python-net/multithreading/) 同时使用。

**是否支持文件密码和加密？**

支持。您可以 [/slides/python-net/password-protected-presentation/](/slides/zh/python-net/password-protected-presentation/) 打开加密的演示文稿，设置或移除打开和写入密码，并检查保护状态。

**在 Linux 容器中需要关注字体包吗？**

需要。建议在容器中安装常用字体包，或在应用程序中显式 [/slides/python-net/custom-font/](/slides/zh/python-net/custom-font/) 指定字体目录，以免出现意外的字体替换。

**评估版有何限制？**

在 [/slides/python-net/licensing/](/slides/zh/python-net/licensing/) 评估模式下，输出会添加水印并受限；可通过 [30 天临时许可证](https://purchase.aspose.com/temporary-license/) 获得完整功能的测试。

**是否支持将外部格式导入演示文稿（PDF/HTML → PPTX）？**

支持。您可以将 [/slides/python-net/import-presentation/](/slides/zh/python-net/import-presentation/) 的 PDF 页面和 HTML 内容添加到演示文稿中，转换为幻灯片。
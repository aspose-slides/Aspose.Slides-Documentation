---
title: 功能概述
type: docs
weight: 20
url: /zh/python-net/features-overview/
---

## **支持的平台**
Aspose.Slides for Python via .NET 可在安装有 Python 3.5 或更高版本的 Windows x64 或 x86 和广泛的 Linux 发行版上使用。目标 Linux 平台还有额外的要求：
- GCC-6 运行时库（或更高版本）
- .NET Core Runtime 的依赖项。安装 .NET Core Runtime 本身不是必须的。
- 对于 Python 3.5-3.7：需要 `pymalloc` 构建的 Python。`--with-pymalloc` Python 构建选项默认启用。通常，`pymalloc` 构建的 Python 文件名带有 `m` 后缀。
- `libpython` 共享 Python 库。`--enable-shared` Python 构建选项默认禁用，一些 Python 发行版不包含 `libpython` 共享库。对于某些 Linux 平台，可以使用包管理器安装 `libpython` 共享库，例如：`sudo apt-get install libpython3.7`。普遍的问题是 `libpython` 库安装在不同于共享库标准系统位置的地方。该问题可以通过使用 Python 构建选项在编译 Python 时设置备用库路径来解决，或者通过在共享库的系统标准位置创建指向 `libpython` 库文件的符号链接来解决。通常，Python 3.5-3.7 的 `libpython` 共享库文件名为 `libpythonX.Ym.so.1.0`，而 Python 3.8 或更高版本的文件名为 `libpythonX.Y.so.1.0`（例如：`libpython3.7m.so.1.0`，`libpython3.9.so.1.0`）。

如果您需要支持更多平台，请查找 “兄弟” 产品 Aspose.Slides for .NET 或 Aspose.Slides for Java。

## **文件格式和转换**
Aspose.Slides for Python via .NET 支持大多数 PowerPoint 文档格式。它还允许您将它们导出到组织广泛使用和交换的流行格式。请查看以下详细信息：

|**功能**|**描述**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/zh/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET 为该演示文档格式提供最快的处理速度。|
|[PPT 到 PPTX 转换](/slides/zh/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET 支持将 PPT 转换为 PPTX。|
|[可移植文档格式 (PDF)](/slides/zh/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|您可以使用单个方法将所有支持的文件格式导出为 Adobe 可移植文档格式 (PDF) 文档。|
|[XML 解析器规范 (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|您可以使用单个方法将所有支持的文件格式导出为 XML 解析器规范 (XPS) 文档。|
|[标记图像文件格式 (TIFF)](/slides/zh/python-net/convert-powerpoint-to-tiff/)|您可以将所有支持的演示文档格式导出为标记图像文件格式 (TIFF)。|
|[PPTX 到 HTML 转换](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET 支持将 PresentationEx 转换为 HTML 格式。|

## **渲染和打印**
Aspose.Slides for Python via .NET 支持将演示文档中的幻灯片高保真度渲染为各种图形格式。请查看以下详细信息：

|**功能**|**描述**|
| :- | :- |
|.NET 支持的图像格式|使用 Aspose.Slides for Python via .NET，您可以将演示文稿幻灯片和幻灯片上的图像渲染为所有 .NET 支持的图形格式，例如 TIFF、PNG、BMP、JPEG、GIF 和元文件。|
|SVG 格式|Aspose.Slides for Python via .NET 还提供内置方法，允许您将演示文稿幻灯片导出为可缩放矢量图形 (SVG) 格式。|
|演示文稿打印|Aspose.Slides for Python via .NET 的最新版本提供了具有不同选项的内置打印方法。|

## **内容特性**
Aspose.Slides for Python via .NET 允许您访问、修改或创建演示文档几乎所有的项目或内容。请查看以下详细信息：

|**功能**|**描述**|
| :- | :- |
|母版幻灯片|母版幻灯片定义了普通幻灯片的布局。Aspose.Slides for Python via .NET 允许您访问和修改演示文档的母版幻灯片。|
|普通幻灯片|使用 Aspose.Slides for Python via .NET，您可以创建不同类型的新幻灯片；您还可以访问和修改演示文稿中现有的幻灯片。|
|克隆/复制幻灯片|Aspose.Slides for Python via .NET 提供内置方法，允许您在演示文稿中克隆或复制现有幻灯片。您还可以将复制和克隆的幻灯片从一个演示文稿使用到另一个演示文稿。由于幻灯片从母版幻灯片继承其布局，因此内置的克隆方法会自动在克隆时复制母版。|
|管理幻灯片部分|在演示文稿中以不同部分组织幻灯片的方法。|
|占位符和文本占位符|您可以访问幻灯片中的占位符和文本占位符。此外，您可以使用适当的方法从头开始创建带有文本占位符的幻灯片。|
|页眉和页脚|Aspose.Slides for Python via .NET 方便地处理幻灯片中的页眉/页脚。|
|幻灯片中的备注|使用 Aspose.Slides for Python via .NET，您可以访问和修改与幻灯片相关的备注，并添加新的备注。|
|寻找形状|您还可以使用与形状相关的替代文本从幻灯片中找到特定形状。|
|背景|Aspose.Slides for Python via .NET 允许您处理与演示文稿中的母版或普通幻灯片相关的背景。|
|文本框|文本框可以从头开始创建。您可以访问现有的文本框。您还可以在不丢失原始文本格式的情况下修改其文本。|
|矩形形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改矩形形状。|
|折线形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改折线形状。|
|椭圆形状|您可以使用 Aspose.Slides for Python via .NET 创建或修改椭圆形状。|
|组合形状|Aspose.Slides for Python via .NET 支持组合形状。|
|自动形状|Aspose.Slides for Python via .NET 支持自动形状。|
|SmartArt|Aspose.Slides for Python via .NET 提供对 MS PowerPoint 中 SmartArt 形状的支持。|
|图表|Aspose.Slides for Python via .NET 提供对 PowerPoint 中 MSO 图表的支持。|
|形状序列化|Aspose.Slides for Python via .NET 支持大量形状。当 Aspose.Slides for Python via .NET 对某个形状缺乏支持时，您可以使用序列化方法，通过该方法可以序列化来自现有幻灯片的形状。这样，您可以根据需求进一步使用该形状。|
|图片框|您可以使用 Aspose.Slides for Python via .NET 管理图片框中的图片。|
|音频框|您可以在幻灯片的音频框中链接或嵌入音频文件，使用 Aspose.Slides for Python via .NET。|
|视频框|您可以在视频框中处理视频文件。Aspose.Slides for Python via .NET 还支持链接和嵌入视频。|
|OLE 框|您可以使用 Aspose.Slides for Python via .NET 管理 OLE 框中的 OLE 对象。|
|表格|Aspose.Slides for Python via .NET 支持幻灯片中的表格。|
|ActiveX 控件|支持 ActiveX 控件。|
|VBA 宏|支持管理演示文稿中的 VBA 宏。|
|文本框|您可以通过与该形状相关的文本框访问任何形状中的文本。|
|文本扫描|您可以通过内置扫描方法在演示文稿或幻灯片级别扫描文本。|
|动画|您可以在形状上应用动画。|
|幻灯片放映|Aspose.Slides for Python via .NET 支持幻灯片放映和幻灯片切换。|

## **格式化特性**
使用 Aspose.Slides for Python via .NET，您可以格式化演示文稿幻灯片中的文本和形状。请查看以下详细信息：

|**功能**|**描述**|
| :- | :- |
|文本格式化|<p>在 Aspose.Slides for Python via .NET 中，您可以通过与形状关联的文本框管理文本。因此，您可以使用与文本框相关的段落和部分格式化文本。这些文本元素可以通过 Aspose.Slides for Python via .NET 进行格式化。</p><p>- 字体类型</p><p>- 字体大小</p><p>- 字体颜色</p><p>- 字体阴影</p><p>- 段落对齐</p><p>- 段落项目符号</p><p>- 段落方向</p>|
|形状格式化|<p>在 Aspose.Slides for Python via .NET 中，幻灯片的基本元素是形状。您可以使用 Aspose.Slides for Python via .NET 格式化这些形状元素：</p><p>- 位置</p><p>- 尺寸</p><p>- 线条</p><p>- 填充（包括图案、渐变、实心）</p><p>- 文本</p><p>- 图像</p>|
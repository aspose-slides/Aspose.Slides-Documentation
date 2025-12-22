---
title: 支持的文件格式
type: docs
weight: 150
url: /zh/androidjava/supported-file-formats/
keywords:
- 文件格式
- 支持的格式
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 能够打开、保存和转换的所有文件格式——包括 PPT、PPTX 和 ODP——并查看明确的导入/导出支持说明。"
---

## **支持的 Microsoft PowerPoint 版本**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **支持的文件格式**
此表列出了 Aspose.Slides for Android via Java 可以加载和保存的文件格式：

|**格式**|**说明**|**加载**|**保存**|**备注**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 放映文件|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 放映文件|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 启用宏的演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 启用宏的放映文件|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 启用宏的模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 演示文稿模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|标签图像文件格式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|增强型元文件格式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|可移植文档格式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 纸张规格| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|联合图像专家组格式| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|便携式网络图形| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|图形交换格式| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|设备无关位图| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可缩放矢量图形| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型网页格式| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|超文本标记语言|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|可扩展应用标记语言| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 演示文稿| |{{< emoticons/tick >}}| |

## **常见问题**

**我可以将演示文稿保存为符合归档和可访问性标准（PDF/A 和 PDF/UA）的 PDF 吗？**

是的。Aspose.Slides 支持通过 [PDF 导出选项](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 中的 [compliance](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setCompliance-int-) 设置导出符合 PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 以及 PDF/UA 标准的 PDF。

**库在导出为 PDF 时是否支持字体嵌入，并且可以细粒度控制嵌入内容？**

是的。您可以控制字体是完全嵌入还是子集嵌入（仅使用的字形），指定系统常用字体的处理方式，并通过 [PDF 导出选项](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 配置 ASCII 文本的行为。

**我能在实际加载文件之前检测文件是否受密码保护吗？**

可以。使用 [基于工厂的检测 API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/) ，您可以在不完全打开文件的情况下查询演示文稿文件是否受密码保护。

**是否存在字体后备机制并支持自定义字体？**

是的。库支持 [加载](/slides/zh/androidjava/custom-font/) 和 [嵌入](/slides/zh/androidjava/embedded-font/) 自定义字体，并提供字体 [后备规则](/slides/zh/androidjava/fallback-font/) 以防止在渲染和转换过程中出现缺失字形。

**我可以将幻灯片导出为 XPS 吗？是否有调节 XPS 输出的选项？**

可以。支持 [导出为 XPS](/slides/zh/androidjava/convert-powerpoint-to-xps/)，并且您可以通过相关的 [保存选项](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/) 调整 XPS 文档的输出质量和内容。
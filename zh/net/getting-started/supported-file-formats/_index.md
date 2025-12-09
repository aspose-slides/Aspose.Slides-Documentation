---
title: 支持的文件格式
type: docs
weight: 30
url: /zh/net/supported-file-formats/
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
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 能够打开、保存和转换的所有文件格式——包括 PPT、PPTX 和 ODP——并附有明确的导入/导出支持说明。"
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
此表列出了 Aspose.Slides for .NET 可以加载和保存的文件格式：

|**格式**|**描述**|**加载**|**保存**|**备注**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 幻灯片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 幻灯片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 宏启用演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 宏启用幻灯片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 宏启用模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 演示文稿模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|标记图像文件格式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|增强型图元文件格式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|可移植文档格式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 纸张规范| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|联合图像专家组| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|可移植网络图形| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|图形互换格式| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|设备无关位图| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可缩放矢量图形| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型网页格式| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|超文本标记语言|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|可扩展应用标记语言| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 演示文稿| |{{< emoticons/tick >}}| |

## **常见问题**

**我可以将演示文稿保存为符合存档和可访问性标准（PDF/A 和 PDF/UA）的 PDF 吗？**

可以。Aspose.Slides 支持通过 PDF 导出选项中的 compliance 设置，将 PDF 导出为符合 PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 以及 PDF/UA 等合规级别的文件。

**库在导出为 PDF 时是否支持字体嵌入，并且可以对嵌入内容进行细粒度控制？**

可以。您可以通过 PDF 导出选项控制字体是完整嵌入还是子集嵌入（仅使用的字形），指定常见系统字体的处理方式，并配置 ASCII 文本的行为。

**我能在实际加载文件之前检测文件是否受密码保护吗？**

可以。使用基于工厂的检查 API，您可以在不完整打开文件的情况下查询演示文稿文件是否受密码保护。

**是否有字体回退机制并支持自定义字体？**

可以。该库支持加载和嵌入自定义字体，并提供字体回退规则，以防在渲染和转换过程中出现缺失字形。

**我可以将幻灯片导出为 XPS 吗？是否有调节 XPS 输出的选项？**

可以。支持导出为 XPS，您可以调整相关的保存选项，以控制 XPS 文档的输出质量和内容。
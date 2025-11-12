---
title: 支持的文件格式
type: docs
weight: 30
url: /zh/nodejs-java/supported-file-formats/
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
此表列出了 Aspose.Slides for Node.js via Java 可以加载和保存的文件格式：

|**格式**|**描述**|**加载**|**保存**|**备注**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 幻灯片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 幻灯片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 含宏演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 含宏幻灯片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 含宏模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 演示文稿|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 演示文稿模板|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|标签图像文件格式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|增强型图元文件格式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|可移植文档格式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 纸张规范| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|联合图像专家组| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|可移植网络图形| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|图形交换格式| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|设备无关位图| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可缩放矢量图形| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型网络格式| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|超文本标记语言|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|可扩展应用程序标记语言| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 演示文稿| |{{< emoticons/tick >}}| |

## **常见问题解答**

**我可以将演示文稿保存为符合存档和可访问性标准的 PDF（PDF/A 和 PDF/UA）吗？**

是的。Aspose.Slides 支持通过 [PDF 导出选项](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 中的 [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) 设置导出符合 PDF/A‑2a、PDF/A‑2b、PDF/A‑2u、PDF/A‑3a、PDF/A‑3b 以及 PDF/UA 标准的 PDF。

**库在导出为 PDF 时是否支持字体嵌入，并能细粒度控制嵌入内容？**

是的。您可以控制字体是完整嵌入还是子集嵌入（仅使用的字形），指定系统常用字体的处理方式，并通过 [PDF 导出选项](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 配置 ASCII 文本的行为。

**我能在实际加载文件之前检测文件是否受密码保护吗？**

可以。使用 [基于工厂的检查 API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/)，您可以在不完整打开文件的情况下查询演示文稿是否受密码保护。

**是否有字体回退机制并支持自定义字体？**

是的。库支持 [加载](/slides/zh/nodejs-java/custom-font/) 和 [嵌入](/slides/zh/nodejs-java/embedded-font/) 自定义字体，并提供字体 [回退规则](/slides/zh/nodejs-java/fallback-font/) 以防止渲染和转换过程中出现缺失字形。

**我可以将幻灯片导出为 XPS 吗？是否有调节 XPS 输出的选项？**

可以。支持 [导出为 XPS](/slides/zh/nodejs-java/convert-powerpoint-to-xps/)，并且您可以通过相关的 [保存选项](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) 调整 XPS 文档的输出质量和内容。
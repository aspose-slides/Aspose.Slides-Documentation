---
title: Aspose.Slides 中的 PPT 转换为 PPTX 格式
type: docs
weight: 10
url: /zh/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** for .NET 现在使开发者能够使用 Presentation 类实例访问 PPT 并将其转换为相应的 PPTX 格式。当前，它仅支持 PPT 到 PPTX 的部分转换。有关在 PPT 到 PPTX 转换中支持和不支持的功能的更多详细信息，请访问此文档链接。

**Aspose.Slides** for .NET 提供了代表 PPTX 演示文稿文件的 Presentation 类。现在，当实例化对象时，Presentation 类也可以通过 Presentation 访问 PPT。

``` csharp
 //实例化一个表示 PPTX 文件的 Presentation 对象
PresentationEx pres = new PresentationEx("Conversion.ppt");
 //将 PPTX 演示文稿保存为 PPTX 格式
pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);
``` 
## **下载示例代码**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)
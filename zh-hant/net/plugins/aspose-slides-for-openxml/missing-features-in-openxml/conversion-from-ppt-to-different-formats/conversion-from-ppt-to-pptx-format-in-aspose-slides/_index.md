---
title: Aspose.Slides 中的 PPT 轉換為 PPTX 格式
type: docs
weight: 10
url: /zh-hant/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET 現在讓開發人員能夠使用 Presentation 類別實例來存取 PPT，並將其轉換為相應的 PPTX 格式。目前，它支援將 PPT 部分轉換為 PPTX。如需了解 PPT 轉換為 PPTX 時支援與不支援的功能細節，請參閱此文件連結。

**Aspose.Slides** for .NET 提供的 Presentation 類別代表 PPTX 簡報檔案。現在，當建立物件時，Presentation 類別也可以透過 Presentation 直接存取 PPT。

``` csharp

 //實例化一個代表 PPTX 檔案的 Presentation 物件

PresentationEx pres = new PresentationEx("Conversion.ppt");

//將 PPTX 簡報儲存為 PPTX 格式

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)
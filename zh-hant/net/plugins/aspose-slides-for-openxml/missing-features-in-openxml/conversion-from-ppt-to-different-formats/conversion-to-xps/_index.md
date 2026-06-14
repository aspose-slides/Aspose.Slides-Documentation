---
title: 轉換為 XPS
type: docs
weight: 40
url: /zh-hant/net/conversion-to-xps/
---
**XPS** 格式也被廣泛用於資料交換。Aspose.Slides for .NET 重視其重要性，並提供內建的支援，可將簡報轉換為 XPS 文件。

Presentation 類別所公開的 **Save** 方法可用於將整個簡報轉換為 **XPS** 文件。此外，**XpsOptions** 類別公開 **SaveMetafileAsPng** 屬性，可根據需求設定為 true 或 false。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//實例化一個代表簡報檔案的 Presentation 物件

Presentation pres = new Presentation(srcFileName);

//將簡報儲存為 TIFF 文件

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)
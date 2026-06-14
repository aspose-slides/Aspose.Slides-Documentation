---
title: 轉換為 PDF
type: docs
weight: 30
url: /zh-hant/net/conversion-to-pdf/
---
PDF 文件被廣泛用作組織、政府部門與個人之間交換文件的標準格式。由於此格式流行，開發人員常被要求將 Microsoft PowerPoint 簡報檔轉換為 PDF 文件。為了滿足此需求，Aspose.Slides for .NET 支援在不使用其他元件的情況下將簡報轉換為 PDF 文件。

**Aspose.Slides for .NET** 提供了代表簡報檔的 Presentation 類別。**Presentation** 類別公開了 Save 方法，可用於將整個簡報轉換為 **PDF** 文件。**PdfOptions** 類別提供了建立 **PDF** 時的選項，例如 JpegQuality、TextCompression、Compliance 等。這些選項可用於取得符合需求的 PDF 標準。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//實例化一個表示簡報檔的 Presentation 物件

Presentation pres = new Presentation(srcFileName);

//使用預設選項將簡報儲存為 PDF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)
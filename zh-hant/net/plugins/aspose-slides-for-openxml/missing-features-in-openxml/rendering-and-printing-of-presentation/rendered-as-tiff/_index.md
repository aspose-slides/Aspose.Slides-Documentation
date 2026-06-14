---
title: 渲染為 Tiff
type: docs
weight: 30
url: /zh-hant/net/rendered-as-tiff/
---
TIFF 格式以其靈活性而聞名，能容納多頁影像與資料。鑑於 TIFF 格式的重要性與普及度，Aspose.Slides for .NET 提供將簡報轉換為 TIFF 文件的支援。
本文說明不同的 TIFF 匯出選項：

- 將簡報轉換為預設大小的 TIFF。
- 將簡報轉換為自訂大小的 TIFF。

開發人員可以呼叫 **Presentation** 類別所提供的 **Save** 方法，將整個簡報轉換為 **TIFF** 文件。此外，TiffOptions 類別公開 ImageSize 屬性，讓開發人員在需要時定義影像的大小。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//實例化一個表示簡報檔案的 Presentation 物件

using (Presentation pres = new Presentation(srcFileName))

{

    //將簡報儲存為 TIFF 文件

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)
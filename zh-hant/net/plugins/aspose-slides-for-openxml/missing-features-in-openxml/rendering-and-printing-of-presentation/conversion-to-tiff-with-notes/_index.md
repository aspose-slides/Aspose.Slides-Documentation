---
title: 含備註的 TIFF 轉換
type: docs
weight: 10
url: /zh-hant/net/conversion-to-tiff-with-notes/
---
TIFF 是 Aspose.Slides for .NET 支援的多種常用影像格式之一，可用於將包含備註的簡報轉換為影像。您也可以在「備註投影片」視圖中產生投影片縮圖。以下兩段程式碼示範如何在「備註投影片」視圖中產生簡報的 TIFF 影像。

**Presentation** 類別提供的 **Save** 方法可用於將整個「備註投影片」視圖的簡報轉換為 TIFF。您也可以為單一投影片在「備註投影片」視圖中產生縮圖。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//實例化一個代表簡報檔案的 Presentation 物件

Presentation pres = new Presentation(srcFileName);

//將簡報儲存為含備註的 TIFF

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)
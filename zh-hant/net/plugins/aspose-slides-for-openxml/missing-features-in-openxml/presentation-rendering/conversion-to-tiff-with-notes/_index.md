---
title: 轉換為含備註的 Tiff
type: docs
weight: 10
url: /zh-hant/net/conversion-to-tiff-with-notes/
---
TIFF 是 Aspose.Slides for .NET 支援的多種廣泛使用的影像格式之一，可將含有備註的簡報轉換為影像。您也可以在備註投影片檢視中產生投影片縮圖。以下是兩段程式碼片段，示範如何在備註投影片檢視中產生簡報的 TIFF 影像。

由 **Presentation** 類別提供的 **Save** 方法可用於將備註投影片檢視中的整個簡報轉換為 TIFF。您也可以為單獨的投影片在備註投影片檢視中產生縮圖。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//實例化一個代表簡報檔案的 Presentation 物件
using (Presentation pres = new Presentation(srcFileName))
{
    //將演講者備註放在每張已渲染投影片的下方
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //將簡報儲存為含備註的 TIFF
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)
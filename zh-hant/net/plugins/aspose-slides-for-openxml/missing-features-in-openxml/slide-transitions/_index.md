---
title: 投影片過渡
type: docs
weight: 80
url: /zh-hant/net/slide-transitions/
---
為了更容易理解，我們示範了使用 Aspose.Slides for .NET 來管理簡單的投影片過渡效果。開發人員不僅可以在投影片上套用不同的過渡效果，還可以自訂這些過渡效果的行為。若要建立簡單的投影片過渡效果，請依照以下步驟：

- 建立 Presentation 類別的實例
- 透過 **TransitionType** 列舉，從 Aspose.Slides for .NET 提供的過渡效果中，對投影片套用投影片過渡類型
- 寫入已修改的簡報檔案。

## **範例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//實例化代表簡報檔案的 Presentation 類別

using (Presentation pres = new Presentation(FileName))

{

    //在投影片 1 上套用圓形過渡效果

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //在投影片 2 上套用梳狀過渡效果

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //在投影片 3 上套用縮放過渡效果

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //將簡報寫入磁碟

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下載執行範例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
如需更多資訊，請造訪 [管理投影片過渡](/slides/zh-hant/net/slide-transition/)。
{{% /alert %}}
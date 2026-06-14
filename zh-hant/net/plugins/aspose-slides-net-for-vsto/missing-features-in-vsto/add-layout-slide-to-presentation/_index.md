---
title: 新增版面配置投影片至簡報
type: docs
weight: 10
url: /zh-hant/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET 允許開發人員在簡報中新增版面配置投影片。若要新增版面配置投影片，請依照下列步驟執行：

- 建立 Presentation 類別的實例
- 存取母片投影片集合
- 嘗試尋找現有的版面配置投影片，查看所需的投影片是否已存在於版面配置投影片集合中
- 若所需的版面配置不存在，則新增一個版面配置投影片
- 使用新加入的版面配置投影片新增空白投影片
- 最後，使用 Presentation 物件寫入簡報檔案。

## **範例**
``` csharp

 //實例化代表簡報檔案的 Presentation 類別
using (Presentation p = new Presentation("Test.pptx"))
{
   //嘗試依版面配置投影片類型搜尋
   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;
   ILayoutSlide layoutSlide =
   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??
   layoutSlides.GetByType(SlideLayoutType.Title);
   if (layoutSlide == null)
   {
     //當簡報不包含某些類型的版面配置時的情況。
     //Technographics.pptx 簡報僅包含 Blank 及 Custom 版面配置類型。
     //但 Custom 類型的版面配置投影片有不同的投影片名稱，
     //如 "Title"、"Title and Content" 等，且可以使用這些
     //名稱來選取版面配置投影片。
     //也可以使用佔位符形狀類型的集合。例如，
     //Title 投影片應僅有 Title 佔位符類型，等等。
     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
     {
       if (titleAndObjectLayoutSlide.Name == "Title and Object")
       {
          layoutSlide = titleAndObjectLayoutSlide;
          break;
       }
      }
      if (layoutSlide == null)
      {
         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
         {
            if (titleLayoutSlide.Name == "Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
          }
          if (layoutSlide == null)
          {
             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
             if (layoutSlide == null)
             {
                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
             }
          }
      }
  }
  //使用已加入的版面配置投影片新增空白投影片
  p.Slides.InsertEmptySlide(0, layoutSlide);
  //儲存簡報
  p.Save("Output.pptx", SaveFormat.Pptx);
}
``` 
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
欲取得更多資訊，請造訪 [在 .NET 中套用或變更投影片版面配置](/slides/zh-hant/net/slide-layout/)。
{{% /alert %}}
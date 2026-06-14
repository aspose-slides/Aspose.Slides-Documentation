---
title: 新增版面配置投影片至簡報
type: docs
weight: 20
url: /zh-hant/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET 允許開發人員在簡報中新增版面配置投影片。若要新增版面配置投影片，請依照以下步驟操作：

- 建立 Presentation 類別的實例
- 存取母片投影片集合
- 嘗試尋找現有的版面配置投影片，以確定所需的投影片是否已存在於版面配置投影片集合中
- 如果所需的版面配置不存在，則新增一個版面配置投影片
- 使用新新增的版面配置投影片新增空白投影片
- 最後，使用 Presentation 物件寫入簡報檔案

## **範例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

 //Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation(FileName))

{

    // Try to search by layout slide type

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // The situation when a presentation doesn't contain some type of layouts.

        // Technographics.pptx presentation only contains Blank and Custom layout types.

        // But layout slides with Custom types has different slide names,

        // like "Title", "Title and Content", etc. And it is possible to use these

        // names for layout slide selection.

        // Also it is possible to use the set of placeholder shape types. For example,

        // Title slide should have only Title pleceholder type, etc.

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

    //Adding empty slide with added layout slide 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Save presentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

如需更多資訊，請造訪[在 .NET 中套用或變更投影片版面配置](/slides/zh-hant/net/slide-layout/)。 

{{% /alert %}}
---
title: 在 .NET 中套用或變更投影片版面配置
linktitle: 投影片版面配置
type: docs
weight: 60
url: /zh-hant/net/slide-layout/
keywords:
- 投影片版面配置
- 內容版面配置
- 佔位元
- 簡報設計
- 投影片設計
- 未使用的版面
- 頁腳可見性
- 標題投影片
- 標題與內容
- 章節標題
- 雙內容
- 比較
- 僅標題
- 空白版面
- 帶說明文字的內容
- 帶說明文字的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- C#
- .NET
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理與自訂投影片版面配置。透過 C# 程式碼範例探索版面類型、佔位元控制與頁腳可見性。"
---
## **簡介**

投影片版面配置定義了投影片上佔位方塊的排列方式以及內容的格式設定。它控制哪些佔位元可用及其顯示位置。投影片版面配置可協助您快速且一致地設計簡報，無論是簡單或較複雜的情況。PowerPoint 中最常見的投影片版面配置包括：

**標題投影片版面配置** – 包含兩個文字佔位元：一個用於標題，另一個用於副標題。

**標題與內容版面配置** – 於上方提供較小的標題佔位元，下方提供較大的主內容佔位元（例如文字、項目符號、圖表、圖片等）。

**空白版面配置** – 不含任何佔位元，讓您能從頭自行設計投影片。

投影片版面配置是投影片母片的一部份，母片是定義簡報版面樣式的最高層投影片。您可以透過投影片母片存取與修改版面投影片——依類型、名稱或唯一 ID 皆可。或者，您也可以直接在簡報內編輯特定的版面投影片。

若要在 Aspose.Slides for .NET 中操作投影片版面配置，您可以使用：

- 例如在 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別下的 [LayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/layoutslides/) 與 [Masters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/masters/) 屬性
- 如 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutplaceholdermanager/)、[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslideheaderfootermanager/) 等類型

{{% alert title="Info" color="info" %}}
若想了解更多關於母片的操作，請參閱 [Slide Master](/slides/zh-hant/net/slide-master/) 文章。
{{% /alert %}}

## **將版面配置新增至簡報**

若要自訂投影片的外觀與結構，您可能需要在簡報中加入新的版面投影片。Aspose.Slides for .NET 允許您檢查特定版面是否已存在，必要時新增，並以該版面插入投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 取得 [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterlayoutslidecollection/)。
1. 檢查所需的版面投影片是否已存在於集合中。若不存在，則新增所需的版面投影片。
1. 新增一張基於新版面投影片的空白投影片。
1. 儲存簡報。

以下 C# 程式碼示範如何將版面配置加入 PowerPoint 簡報：

```cs
// 實例化代表 PowerPoint 檔案的 Presentation 類別。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // 遍歷版面投影片類型以選擇版面投影片。
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // 簡報不包含所有版面類型的情況。
        // 簡報檔案僅包含空白和自訂版面類型。
        // 但是，自訂類型的版面投影片可能具有可辨識的名稱，
        // 例如 "Title"、"Title and Content" 等，可用於版面投影片的選取。
        // 您也可以依賴一組佔位元形狀類型。
        // 例如，標題投影片應僅有 Title 佔位元類型，依此類推。
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

    // 使用新增的版面投影片插入空白投影片。
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // 將簡報儲存至磁碟。  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **移除未使用的版面投影片**

Aspose.Slides 透過 [Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) 類別的 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法，讓您刪除不需要且未被使用的版面投影片。

以下 C# 程式碼示範如何從 PowerPoint 簡報中移除版面投影片：

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **向版面投影片新增佔位元**

Aspose.Slides 提供 [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/placeholdermanager/) 屬性，讓您能在版面投影片上新增佔位元。

此管理器提供以下佔位元類型的方法：

| PowerPoint 佔位元 | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutplaceholdermanager/) 方法 |
| ----------------- | ------------------------------------------------------------ |
| ![內容](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![內容（垂直）](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![文字](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![文字（垂直）](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![圖片](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![圖表](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![表格](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![媒體](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![線上圖片](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

以下 C# 程式碼示範如何在「空白」版面投影片上新增佔位元圖形：

```cs
using (var presentation = new Presentation())
{
    // 取得空白版面投影片。
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 取得版面投影片的佔位元管理器。
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // 為空白版面投影片新增不同的佔位元。
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // 使用空白版面新增一張投影片。
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

結果：

![版面配置投影片上的佔位元](add_placeholders.png)

## **設定版面投影片的頁腳可見性**

在 PowerPoint 簡報中，日期、投影片編號與自訂文字等頁腳元素可依版面配置顯示或隱藏。Aspose.Slides for .NET 讓您控制這些頁腳佔位元的可見性，適用於需要在特定版面顯示頁腳資訊，而其他版面保持簡潔的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得版面投影片的參考。
1. 設定投影片頁腳佔位元為可見。
1. 設定投影片編號佔位元為可見。
1. 設定日期時間佔位元為可見。
1. 儲存簡報。

以下 C# 程式碼示範如何設定投影片頁腳的可見性及相關操作：

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **設定子版面投影片的頁腳可見性**

在 PowerPoint 簡報中，日期、投影片編號與自訂文字等頁腳元素可在母片層級設定，以確保所有版面投影片的一致性。Aspose.Slides for .NET 允許您在母片上設定這些頁腳佔位元的可見性與內容，並將設定傳播至所有子版面投影片，從而在整個簡報中維持統一的頁腳資訊。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得母片投影片的參考。
1. 將母片及所有子版面的頁腳佔位元設為可見。
1. 將母片及所有子版面的投影片編號佔位元設為可見。
1. 將母片及所有子版面的日期時間佔位元設為可見。
1. 儲存簡報。

以下 C# 程式碼示範此操作：

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**主片與版面投影片有何不同？**

主片定義整體主題與預設格式，版面投影片則為不同類型內容定義特定的佔位元排列。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以，您可以從一個簡報的 [LayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/layoutslides/) 集合中克隆版面投影片，然後使用 `AddClone` 方法將其插入另一個簡報。

**如果刪除仍被投影片使用的版面投影片會發生什麼事？**

若嘗試刪除仍被至少一張投影片參照的版面投影片，Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception/)。為避免此問題，請使用 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)，它只會安全地移除未被使用的版面投影片。
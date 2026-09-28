---
title: 在 .NET 中套用或變更投影片版面配置
linktitle: 投影片版面配置
type: docs
weight: 60
url: /zh-hant/net/slide-layout/
keywords:
- 投影片版面配置
- 內容版面配置
- 占位符
- 簡報設計
- 投影片設計
- 未使用的版面配置
- 頁腳可見性
- 標題投影片
- 標題與內容
- 章節標題
- 雙內容
- 比較
- 僅標題
- 空白版面配置
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
description: "在 Aspose.Slides for .NET 中套用、建立與修改投影片版面配置，新增占位符、移除未使用的版面配置，並控制頁腳可見性。"
---
## **概述**

投影片版面配置定義了占位符（例如標題、文字、圖片、圖表和表格）的位置和格式。套用版面配置可為投影片提供一致的結構，同時允許每張投影片保有自己的內容。

最常見的版面配置包括：

- **Title Slide**：包含標題和副標題占位符。
- **Title and Content**：包含標題占位符與一般用途的內容占位符。
- **Blank**：不含任何內容占位符，適用於需要手動定位每個圖形的情況。

## **了解版面繼承**

簡報有三個相關層級：

1. 一個[master slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/) 定義佈景主題、共用格式、背景與共同物件。  
2. 一個[layout slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/) 屬於 master，並定義特定的占位符排列。  
3. 一個[normal slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 使用某個版面配置，並儲存該投影片的內容。

普通投影片會從其版面配置繼承佈景主題與格式，版面配置則繼承自其 master。直接設定於普通投影片的值會覆寫該層級的繼承值。建立普通投影片時，其占位符圖形會根據選取的版面配置產生，而填入這些占位符的內容屬於普通投影片本身。

在使用版面配置建立投影片之前，請先於版面配置加入必要的占位符。之後再為版面配置新增占位符，並不會自動為已存在的普通投影片新增相應的占位符圖形。

此關係有兩個重要的結果：

- 變更版面配置上繼承的格式或現有占位符的幾何形狀，會更新所有依賴該版面的投影片。編輯已在使用的版面配置前，請先檢查其相依投影片並審視最終的簡報結果。  
- 稍被投影片使用的版面配置無法被移除。必須先將其相依投影片指派至其他版面配置，或僅移除未被使用的版面配置。

欲取得有關此層級頂層的更多資訊，請參閱[Slide Master](/slides/zh-hant/net/slide-master/)。

若要在單一投影片或透過共用版面隱藏繼承的標誌或裝飾性 master 圖形，請參閱[Control the Visibility of Master Graphics](/slides/zh-hant/net/slide-master/)。範例比較了兩張使用相同 master 的投影片。

## **選取並套用投影片版面配置**

當簡報遵循標準 PowerPoint 版面定義時，請使用版面類型。版面名稱可由使用者編輯且能本地化，因此除非您掌控來源範本，否則僅依名稱選取的可靠度較低。

以下範例在第一個 master 中搜尋 **Title and Content**。若找不到該版面，則會刻意退回使用 **Blank**。第二個 null 檢查是必要的，因為簡報可能僅包含自訂版面。選取的版面再透過[ISlide.LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/layoutslide/)屬性套用至第一張 normal slide。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

變更投影片的版面配置不會移除直接加入投影片的普通圖形。然而，佔位符位置、繼承的格式以及現有佔位符與新版面之間的對應關係可能會變更，切換至差異較大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前一個範例僅選取既有版面，並未建立新版面。若要建立版面，請在目標 master 的版面集合上呼叫[IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterlayoutslidecollection/add/)方法。

以下範例始終新增一個名稱為 `Report Title and Content` 的 **Title and Content** 版面，然後依據該版面新增一張 normal slide。版面名稱在集合內必須唯一。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

僅在範本真正需要另一個可重複使用的結構時才新增版面。若已有合適的版面，請選取並重複使用，而非建立重複的版面。

## **在版面投影片中加入占位符**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/placeholdermanager/)屬性提供一個[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutplaceholdermanager/)，用於向版面加入占位符圖形。

| PowerPoint 占位符 | `ILayoutPlaceholderManager` 方法 |
| ------------------ | -------------------------------- |
| ![內容](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![內容（垂直）](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![文字](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![文字（垂直）](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![圖片](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![圖表](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![表格](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![媒體](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![線上圖片](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

以下範例驗證 **Blank** 版面是否存在，向其加入四個占位符，然後建立使用已修改版面的 normal slide。此順序刻意設計：先加入占位符再建立 normal slide，讓 Aspose.Slides 能在該投影片上產生相對應的占位符圖形。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

結果：

![版面投影片上的占位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更繼承的格式或既有版面占位符的幾何形狀可能會影響相依的投影片。新加入的版面占位符不會自動填入已存在的 normal slide。請在簡報的副本上測試版面變更，並檢查每一張相依投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用[Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)方法可移除無任何 normal slide 參照的版面。此方法會保留仍在使用中的版面。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

若要移除特定版面，請先使用其[HasDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/hasdependingslides/)屬性或[GetDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/getdependingslides/)方法。在呼叫[ILayoutSlide.Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/remove/)之前，先重新指派所有相依投影片。試圖移除仍被使用的版面會拋出[PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間占位符。使用[ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/headerfootermanager/)屬性可針對單一版面控制這些占位符。這在例如內容版面需要顯示頁腳，而標題版面則不需要時相當有用。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **控制 Master 及其子版面的頁腳可見性**

若要在 master 階層中套用一致的頁腳設定，請使用[IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/headerfootermanager/)屬性。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslideheaderfootermanager/)的傳播方法作用於 master 以及其相依的版面投影片與 normal slide；不僅限於單一 normal slide。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **常見問題**

**Master 投影片與 Layout 投影片有何差異？**

master 投影片定義簡報的佈景主題與共用格式。layout 投影片屬於 master，並定義一個可重複使用的占位符排列。normal 投影片使用這些版面，並儲存投影片特定的內容。

**我可以將 Layout 投影片從一個簡報複製到另一個嗎？**

可以。使用[AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/globallayoutslidecollection/addclone/)方法將副本加入目標集合。於跨簡報複製時，亦需確認來源版面所使用的字型、佈景主題、圖像及其他資源。

**當我修改已在使用的版面時會發生什麼情況？**

相依的投影片會繼承版面變更，除非它們在本地覆寫受影響的格式或物件。因此，占位符的幾何形狀與繼承樣式可能一次變更多張投影片。編輯版面前，使用[GetDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/getdependingslides/)辨識受影響的投影片。

**如果我移除仍在使用中的版面會怎樣？**

Aspose.Slides 會拋出[PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception/)。請先重新指派相依的投影片，或使用[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)只移除未被參照的版面。
---
title: 在 .NET 中套用或變更投影片版面配置
linktitle: 投影片版面配置
type: docs
weight: 60
url: /zh-hant/net/slide-layout/
keywords:
- 投影片版面配置
- 內容版面配置
- 佔位符
- 簡報設計
- 投影片設計
- 未使用的版面
- 頁腳可見性
- 標題投影片
- 標題與內容
- 章節標頭
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
description: "在 Aspose.Slides for .NET 中套用、建立與修改投影片版面配置，新增佔位符、移除未使用的版面，並控制頁腳可見性。"
---
## **概觀**

投影片版面配置定義了標題、文字、圖片、圖表和表格等佔位符的位置與格式。套用版面配置可為投影片提供一致的結構，同時允許每張投影片包含其各自的內容。

最常見的版面配置包括：

- **標題投影片**：包含標題和副標題佔位符。
- **標題與內容**：包含標題佔位符和一般用途的內容佔位符。
- **空白**：不包含任何內容佔位符，適用於需要手動定位所有圖形的情況。

## **了解版面繼承**

簡報有三個相關層級：

1. [母片投影片](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/) 定義簡報的主題、共用格式、背景和共同物件。
2. [版面投影片](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/) 屬於母片，定義特定的佔位符排列。
3. [普通投影片](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 使用一個版面，並儲存該投影片的內容。

普通投影片會從其版面繼承主題與格式，而版面則繼承自其母片。直接在普通投影片上設定的值會覆蓋該層級的繼承值。建立普通投影片時，佔位符形狀會根據所選版面產生，而填入這些佔位符的內容屬於普通投影片本身。

在使用版面建立投影片之前，先在版面中加入必要的佔位符。之後再向版面添加佔位符，並不會自動為現有的普通投影片添加相對應的佔位符形狀。

此關係有兩個重要的結果：

- 變更版面上繼承的格式或現有佔位符的幾何形狀，會更新所有依賴該版面的投影片。在編輯已在使用的版面前，請檢查其受影響的投影片並審閱產生的簡報。
- 仍被投影片使用的版面無法被刪除。必須先將其受影響的投影片重新指派至其他版面，或僅刪除未使用的版面。

如需了解此階層之最高層級的更多資訊，請參閱[投影片母片](/slides/zh-hant/net/slide-master/)。

## **選取與套用投影片版面**

當簡報遵循標準 PowerPoint 版面定義時，請使用版面類型。版面名稱可供使用者編輯且可能被本地化，因此僅依名稱進行選取的可靠性較低，除非您能控制來源範本。

以下範例在第一個母片上搜尋 **標題與內容**。若找不到該版面，會刻意退回至 **空白**。第二個 null 檢查是必要的，因為簡報可能僅包含自訂版面。接著透過[ISlide.LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/layoutslide/)屬性將選取的版面套用至第一張普通投影片。

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

變更投影片的版面不會移除直接加入投影片的普通圖形。然而，佔位符位置、繼承的格式以及既有佔位符與新版面之間的對應關係可能會改變，因此在切換差異較大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前一個範例僅選取既有版面，並未建立新版面。若要建立版面，請對目標母片的版面集合呼叫[IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterlayoutslidecollection/add/)方法。

以下範例固定新增一個名為 `Report Title and Content` 的 **標題與內容** 版面，然後基於該版面新增普通投影片。版面名稱在集合中必須唯一。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

僅在範本確實需要另一個可重複使用的結構時才新增版面。如果已存在合適的版面，請選取並重複使用，而非建立重複的版面。

## **向版面投影片新增佔位符**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/placeholdermanager/)屬性提供一個[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutplaceholdermanager/)，用於向版面新增佔位符形狀。

| PowerPoint 佔位符                | `ILayoutPlaceholderManager` 方法 |
| -------------------------------- | -------------------------------- |
| ![內容](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![內容（垂直）](contentV.png)    | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![文字](text.png)                | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![文字（垂直）](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![圖片](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![圖表](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![表格](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)        | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![媒體](media.png)               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![線上圖片](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

以下範例驗證 **空白** 版面是否存在，向其新增四個佔位符，然後建立使用已修改版面的普通投影片。此順序刻意安排：先新增佔位符，才建立普通投影片，讓 Aspose.Slides 能在該投影片上產生相對應的佔位符形狀。

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

![版面投影片上的佔位符](add_placeholders.png)

{{% alert color="warning" title="警告" %}}
變更繼承的格式或既有版面佔位符的幾何形狀可能會影響受影響的投影片。新新增的版面佔位符不會回填至現有的普通投影片。請在簡報的副本上測試版面變更，並檢查每一張受影響的投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用[Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)方法移除未被任何普通投影片參照的版面。此方法會保留仍在使用中的版面。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

若要移除特定的版面，首先使用其[HasDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/hasdependingslides/)屬性或[GetDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/getdependingslides/)方法。於呼叫[ILayoutSlide.Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/remove/)之前，先重新指派所有受影響的投影片。嘗試移除仍在使用中的版面會拋出[PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位符。使用[ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/headerfootermanager/)屬性可針對單一版面控制這些佔位符。此功能在例如內容版面需要顯示頁腳而標題版面則不需要時非常有用。

以下範例安全地選取一個版面，並將其頁腳元素設為可見：

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

## **控制母片及其子版面的頁腳可見性**

若要在母片層級中套用一致的頁腳設定，請使用[IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/headerfootermanager/)屬性。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslideheaderfootermanager/)的傳播方法會作用於母片及其受影響的版面投影片和普通投影片；不會僅針對單一普通投影片。

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

## **FAQ**

**母片與版面投影片有何差異？**

母片定義簡報的主題與共用格式。版面投影片屬於母片，定義一個可重複使用的佔位符排列。普通投影片使用這些版面，並儲存投影片特定的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用[AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/globallayoutslidecollection/addclone/)方法將副本加入目標集合。於跨簡報複製時，亦需確認來源版面使用的字型、主題、圖片與其他資源。

**當我修改已在使用的版面會發生什麼？**

除非投影片在本機覆寫了受影響的格式或物件，否則受影響的投影片會繼承版面變更。佔位符幾何形狀與繼承樣式因此可能一次改變多張投影片。編輯版面前，請使用[GetDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/getdependingslides/)以找出受影響的投影片。

**如果我移除仍在使用中的版面會發生什麼？**

Aspose.Slides 會拋出[PptxEditException]。請先重新指派受影響的投影片，或使用[RemoveUnusedLayoutSlides]只移除未被參照的版面。
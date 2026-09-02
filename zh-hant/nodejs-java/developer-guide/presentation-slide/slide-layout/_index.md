---
title: 在 JavaScript 中套用或變更投影片版面配置
linktitle: 投影片版面配置
type: docs
weight: 60
url: /zh-hant/nodejs-java/slide-layout/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js（透過 Java）中套用、建立與修改投影片版面配置、加入佔位符、移除未使用的版面，並控制頁腳可見性。"
---
## **概觀**

投影片版面配置定義了佔位符（如標題、文字、圖片、圖表和表格）的位置與格式。套用版面配置可讓投影片具備一致的結構，同時允許每張投影片保有各自的內容。

最常見的版面配置包括：

- **標題投影片**：包含標題與副標題佔位符。
- **標題與內容**：包含標題佔位符與一般用途的內容佔位符。
- **空白**：不包含任何內容佔位符，適用於需要手動定位每個圖形的情況。

## **了解版面繼承**

簡報包含三個相關層級：

1. A [母投影片](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [版面投影片](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [普通投影片](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

普通投影片從其版面繼承主題與格式，版面則從其母投影片繼承。直接在普通投影片上設定的值會覆寫該層級的繼承值。建立普通投影片時，會依所選版面產生佔位符形狀，而填入這些佔位符的內容屬於普通投影片。

在從版面建立投影片之前，請先在版面上加入必要的佔位符。之後再為版面新增佔位符不會自動在已存在的普通投影片中加入相對應的佔位符形狀。

此關係有兩個重要的結果：

- 變更版面上繼承的格式或現有佔位符的幾何形狀會更新所有依賴該版面的投影片。在編輯已在使用的版面前，請檢查其依賴的投影片並審閱最終簡報。
- 仍被投影片使用的版面無法移除。必須先將其依賴的投影片指派給其他版面，或只移除未使用的版面。

如需瞭解此階層最高層級的更多資訊，請參閱 [投影片母片](/slides/zh-hant/nodejs-java/slide-master/)。

## **選取並套用投影片版面配置**

當簡報遵循標準 PowerPoint 版面定義時，請使用 [SlideLayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidelayouttype/) 值。版面名稱可由使用者編輯且可本地化，因此除非掌控來源範本，否則僅依名稱選取的可靠性較低。

以下範例在第一個母投影片上尋找 **Title and Content**。若該版面不存在，則刻意回退至 **Blank**。第二個 null 檢查是必要的，因為簡報可能只包含自訂版面。選取的版面隨後透過 [Slide.setLayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#setLayoutSlide) 方法套用到第一張普通投影片。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

變更投影片的版面不會移除直接加入投影片的普通圖形。然而，佔位符位置、繼承的格式以及現有佔位符與新版面之間的對應關係可能會改變，切換至差異較大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前面的範例僅選取既有版面，並未建立新版面。若要建立版面，請在目標母投影片的版面集合上呼叫 [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) 方法。

以下範例始終新增一個名為 `Report Title and Content` 的 **Title and Content** 版面，然後基於它新增一張普通投影片。版面名稱在同一集合內必須唯一。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

僅在範本確實需要另一個可重複使用的結構時才新增版面。如果已有合適的版面，請選取並重複使用，而非建立重複的版面。

## **為版面投影片新增佔位符**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) 方法提供一個 [LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/) 以將佔位符形狀加入版面。

| PowerPoint 佔位符                | `LayoutPlaceholderManager` 方法 |
| --------------------------------- | -------------------------------- |
| ![Content](content.png)           | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                 | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)           | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)               | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)               | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)               | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)  | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

以下範例驗證 **Blank** 版面是否存在，為其新增四個佔位符，然後建立使用修改後版面的普通投影片。此順序刻意安排：先加入佔位符再建立普通投影片，讓 Aspose.Slides 能在該投影片上產生相對應的佔位符形狀。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![版面投影片上的佔位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更繼承格式或現有版面佔位符的幾何形狀可能會影響依賴的投影片。新加入的版面佔位符不會回填至已存在的普通投影片。請在簡報的副本上測試版面變更，並檢查每張依賴的投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用 [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 方法移除沒有任何普通投影片參照的版面。此方法會保留仍在使用中的版面。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要移除特定版面，首先使用其 [hasDependingSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) 或 [getDependingSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) 方法。在呼叫 [LayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#remove) 前，先重新指派所有依賴的投影片。嘗試移除仍被使用的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位符。使用 [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) 方法可對單一版面控制這些佔位符。此功能在例如內容版面需要顯示頁腳而標題版面不需要時非常實用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制母片及其子版面的頁腳可見性**

若要在母片層級上套用一致的頁腳設定，請使用 [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) 方法。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslideheaderfootermanager/) 的傳播方法會作用於母片、其依賴的版面投影片以及普通投影片；不會僅針對單一普通投影片。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**主投影片與版面投影片有何差異？**

主投影片定義簡報的主題與共用格式。版面投影片屬於某個主投影片，定義一組可重複使用的佔位符排列。普通投影片使用這些版面並存放投影片特有的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) 方法將副本加入目標集合。跨簡報複製時，亦需確認來源版面使用的字型、主題、影像與其他資源。

**當我修改已在使用的版面時會發生什麼？**

依賴的投影片會繼承版面的變更，除非它們在本機覆寫了受影響的格式或物件。佔位符的幾何形狀與繼承樣式因此可能同時在多張投影片上變更。編輯版面前，可使用 [getDependingSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) 辨識受影響的投影片。

**如果移除仍在使用的版面會發生什麼？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxeditexception/)。請先重新指派依賴的投影片，或使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 只移除未被參照的版面。
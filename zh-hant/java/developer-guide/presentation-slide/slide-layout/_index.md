---
title: 在 Java 中套用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/java/slide-layout/
keywords:
- 投影片版面
- 內容版面
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中套用、建立與修改投影片版面，新增佔位元、移除未使用的版面，並控制頁腳可見性。"
---
## **概覽**

投影片佈局定義了標題、文字、圖片、圖表和表格等佔位元的位置信息與格式設定。套用佈局可為投影片提供一致的結構，同時允許每張投影片包含其各自的內容。

最常見的佈局包括：

- **標題投影片**：包含標題與副標題佔位元。
- **標題與內容**：包含標題佔位元與通用內容佔位元。
- **空白**：不包含任何內容佔位元，適用於需要手動定位所有圖形的情況。

## **了解佈局繼承**

簡報具有三個相關層級：

1. [主投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/) 定義主題、共用格式、背景與通用物件。
2. [版面投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/) 屬於主投影片，並定義特定的佔位元排列。
3. [一般投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 使用一個版面，並儲存此投影片的內容。

一般投影片會從其版面繼承主題與格式，而版面則繼承自其主投影片。直接在一般投影片上設定的值會在該層級覆寫繼承值。建立一般投影片時，會根據所選版面產生佔位元圖形，而填入這些佔位元的內容屬於該一般投影片。

在使用版面建立投影片之前，請先在版面上新增所需的佔位元。之後再向版面加入佔位元，並不會自動在現有的一般投影片中新增相應的佔位元圖形。

此關係有兩個重要的結果：

- 變更版面上繼承的格式或既有佔位元的幾何形狀，可能會更新所有依賴該版面的投影片。編輯已使用的版面前，請先檢查其依賴的投影片並審閱最終簡報。
- 仍被投影片使用的版面無法直接移除。請先將其依賴的投影片重新指派至其他版面，或僅移除未使用的版面。

如需瞭解此階層最上層的更多資訊，請參閱[投影片母片](/slides/zh-hant/java/slide-master/)。

## **選取並套用投影片版面**

在簡報遵循標準 PowerPoint 版面定義時，使用版面類型。版面名稱可由使用者編輯且可能會本地化，因此除非您能掌控來源範本，否則僅依名稱選取的可靠性較低。

以下範例在第一個主投影片中尋找 **標題與內容**。若找不到該版面，則會故意退回使用 **空白**。第二個 null 檢查是必要的，因為簡報可能僅包含自訂版面。選取的版面接著透過 [ISlide.setLayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) 方法套用到第一個一般投影片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

變更投影片的版面不會移除直接添加於投影片的普通圖形。然而，佔位元位置、繼承的格式以及現有佔位元與新版面之間的對應關係可能會改變，因此在切換差異極大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分離的操作。前一個範例僅選取既有版面，並未建立新版面。若要建立版面，請在目標主投影片的版面集合上呼叫 [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) 方法。

以下範例始終新增一個名為 `Report Title and Content` 的 **標題與內容** 版面，然後基於該版面新增一般投影片。版面名稱在集合中必須唯一。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

只有在範本確實需要另一個可重複使用的結構時才新增版面。若已有合適的版面，請選取並重用，而非建立重複的版面。

## **為版面投影片新增佔位元**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) 方法提供一個 [ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/)，用於向版面新增佔位元圖形。

| PowerPoint 佔位元 | `ILayoutPlaceholderManager` 方法 |
| ------------------ | -------------------------------- |
| ![內容](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![內容（垂直）](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![文字](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![文字（垂直）](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![圖片](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![圖表](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![表格](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![媒體](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![線上圖片](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

以下範例驗證 **空白** 版面是否存在，向其新增四個佔位元，然後建立使用該修改版面的普通投影片。順序刻意安排：先新增佔位元再建立普通投影片，以便 Aspose.Slides 能在該投影片上產生相對應的佔位元圖形。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![版面投影片上的佔位元](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更繼承的格式或既有版面佔位元的幾何形狀可能會影響依賴的投影片。新加入的版面佔位元不會自動填入現有的一般投影片。請在簡報的副本上測試版面變更，並檢查每個依賴的投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用 [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法移除未被任何一般投影片參考的版面。此方法會保留仍在使用中的版面。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要移除特定的版面，首先使用其 [hasDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) 或 [getDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) 方法。呼叫 [ILayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#remove--) 前，請先重新指派任何依賴的投影片。嘗試移除正在使用的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。

## **在版面投影片上控制頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位元。可使用 [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) 方法來控制單一版面的這些佔位元。例如，內容版面應顯示頁腳，但標題版面則不需要。

以下範例安全地選取一個版面，並將其頁腳元素設為可見：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在母片及其子版面上控制頁腳可見性**

若要在母片階層中套用一致的頁腳設定，請使用 [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) 方法。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslideheaderfootermanager/) 的傳播方法會作用於母片及其依賴的版面投影片與一般投影片；不會僅針對單一一般投影片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**母片與版面投影片有何不同？**

母片定義簡報的主題與共用格式。版面投影片屬於母片，定義一種可重複使用的佔位元排列。一般投影片使用這些版面，並儲存投影片特定的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) 方法將副本加入目標集合。於簡報之間複製時，亦須確認來源版面所使用的字型、主題、影像與其他資源。

**當我修改已在使用的版面時會發生什麼？**

除非依賴投影片在本地覆寫受影響的格式或物件，否則它們會繼承版面的變更。因此，佔位元的幾何形狀與繼承樣式可能會同時在多張投影片上變化。編輯版面前，可使用 [getDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) 來識別受影響的投影片。

**如果移除仍在使用的版面會發生什麼？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。請先重新指派依賴的投影片，或使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 只移除未被參考的版面。
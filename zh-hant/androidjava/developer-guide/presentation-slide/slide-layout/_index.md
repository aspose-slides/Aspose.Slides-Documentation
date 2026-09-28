---
title: 套用或變更 Android 上的投影片版面配置
linktitle: 投影片版面配置
type: docs
weight: 60
url: /zh-hant/androidjava/slide-layout/
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
- 含說明文字的內容
- 含說明文字的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android（透過 Java）中套用、建立與修改投影片版面配置，加入佔位符、移除未使用的版面，並控制頁腳可見性。"
---
## **概觀**

投影片版面配置定義了佔位符（例如標題、文字、圖片、圖表和表格）的定位與格式。套用版面配置可為投影片提供一致的結構，同時允許每張投影片包含自己的內容。

最常見的版面配置包括：

- **Title Slide**：包含標題與副標題佔位符。
- **Title and Content**：包含一個標題佔位符和一個通用內容佔位符。
- **Blank**：不包含任何內容佔位符，適用於需要手動定位每個圖形的情況。

## **了解版面繼承**

簡報具有三個相關層級：

1. 一個[母片](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/) 定義主題、共用格式、背景與共用物件。
2. 一個[版面投影片](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/) 隸屬於母片，並定義特定的佔位符排列。
3. 一個[一般投影片](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 使用一個版面，並儲存該投影片輸入的內容。

一般投影片從其版面繼承主題與格式，版面則繼承自其母片。直接設定在一般投影片上的值會覆寫該層級繼承的值。建立一般投影片時，會根據所選版面產生佔位符圖形，而輸入於這些佔位符的內容屬於一般投影片。

在從版面建立投影片之前，請先在版面中加入必要的佔位符。之後再向版面加入佔位符不會自動為已存在的一般投影片新增對應的佔位符圖形。

此關係有兩個重要的結果：

- 變更版面繼承的格式或現有佔位符的幾何形狀可能會更新所有依賴該版面的投影片。編輯已在使用的版面前，請先檢查其依賴的投影片並審視最終的簡報。
- 仍被投影片使用的版面無法被移除。必須先將其依賴的投影片重新指派至其他版面，或僅移除未使用的版面。

如需了解此階層最高層的更多資訊，請參閱[投影片母片](/slides/zh-hant/androidjava/slide-master/)。

若要隱藏單一投影片或透過共享版面中的繼承標誌或裝飾性母片圖形，請參閱[控制母片圖形的可見性](/slides/zh-hant/androidjava/slide-master/)。此範例比較了使用相同母片的兩張投影片。

## **選取與套用投影片版面**

當簡報遵循標準 PowerPoint 版面定義時，請使用版面類型。版面名稱可由使用者編輯且可本地化，除非您控制來源範本，否則僅依名稱選取的可靠性較低。

以下範例在第一個母片上搜尋 **Title and Content**。若找不到該版面，則主動回退至 **Blank**。第二個 null 檢查是必要的，因為簡報可能僅包含自訂版面。選取的版面再透過[ISlide.setLayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) 方法套用至第一張一般投影片。

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

變更投影片的版面不會移除直接加入投影片的普通圖形。然而，佔位符位置、繼承的格式以及現有佔位符與新版面之間的對應可能會改變，因此在切換差異較大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前一個範例僅選取現有版面，並未建立新版面。若要建立版面，請對目標母片的版面集合呼叫[IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) 方法。

以下範例始終新增一個名為 `Report Title and Content` 的 **Title and Content** 版面，然後基於它新增一般投影片。版面名稱在集合中必須唯一。

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

只有在範本真正需要另一個可重複使用的結構時才新增版面。如果已存在合適的版面，請直接選取並重複使用，而不是建立重複的版面。

## **向版面投影片新增佔位符**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) 方法提供一個[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) 用於向版面新增佔位符圖形。

| PowerPoint 佔位符                | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![內容](content.png)                | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![內容（垂直）](contentV.png)       | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![文字](text.png)                  | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![文字（垂直）](textV.png)          | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![圖片](picture.png)                | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![圖表](chart.png)                  | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![表格](table.png)                  | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![媒體](media.png)                  | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![線上圖片](onlineImage.png)        | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

以下範例驗證 **Blank** 版面是否存在，向其新增四個佔位符，然後建立使用修改後版面的一般投影片。順序刻意設計：先新增佔位符，再建立一般投影片，以便 Aspose.Slides 能在該投影片上產生對應的佔位符圖形。

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

![版面投影片上的佔位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更版面繼承的格式或現有佔位符的幾何形狀可能會影響依賴的投影片。新加入的版面佔位符不會回填至現有的一般投影片。請在簡報的副本上測試版面變更，並檢查每一張依賴的投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法移除沒有任何一般投影片參照的版面。此方法會保留仍在使用中的版面。

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

若要移除特定版面，首先使用其[hasDependingSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) 或 [getDependingSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) 方法。於呼叫[ILayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#remove--) 前，先重新指派任何依賴的投影片。嘗試移除仍被使用的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位符。使用[ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) 方法可對單一版面控制這些佔位符。這在例如內容版面需要顯示頁腳，而標題版面則不需要時非常有用。

以下範例安全地選取一個版面，並使其頁腳元素可見：

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

## **控制母片及其子版面的頁腳可見性**

要在母片層級中套用一致的頁腳設定，請使用[IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) 方法。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) 的傳播方法會作用於母片以及其依賴的版面投影片與一般投影片；它們不會僅針對單一一般投影片。

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

母片定義簡報的主題與共用格式。版面投影片屬於母片，定義一套可重複使用的佔位符排列。一般投影片使用這些版面，並儲存投影片特有的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用[addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) 方法將版面加入目標集合。跨簡報複製時，亦需確認來源版面使用的字型、主題、圖片與其他資源是否在目標簡報中可用。

**當我修改已在使用的版面時會發生什麼？**

依賴的投影片會繼承版面變更，除非它們在本地覆寫了受影響的格式或物件。佔位符的幾何形狀與繼承的樣式可能會同時在多張投影片上改變。編輯版面前，請使用[getDependingSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) 識別受影響的投影片。

**若移除仍在使用的版面會發生什麼？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxeditexception/)。請先重新指派依賴的投影片，或使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 只移除未被參照的版面。
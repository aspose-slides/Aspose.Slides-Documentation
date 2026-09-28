---
title: 在 Java 中套用或變更投影片版面配置
linktitle: 投影片版面配置
type: docs
weight: 60
url: /zh-hant/java/slide-layout/
keywords:
- 投影片版面配置
- 內容版面配置
- 占位符
- 簡報設計
- 投影片設計
- 未使用的版面
- 頁腳可見性
- 標題投影片
- 標題與內容
- 章節標題
- 兩欄內容
- 比較
- 僅標題
- 空白版面
- 帶說明的內容
- 帶說明的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中套用、建立與修改投影片版面配置，新增占位符、移除未使用的版面，並控制頁腳可見性。"
---
## **概觀**

投影片版面配置定義了標題、文字、圖片、圖表和表格等占位符的位置與格式。套用版面配置可讓投影片具有一致的結構，同時允許每張投影片擁有自己的內容。

最常見的版面配置包括：

- **標題投影片**：包含標題與副標題占位符。
- **標題與內容**：包含標題占位符和一般內容占位符。
- **空白**：不含任何內容占位符，適用於需要手動定位所有圖形的情況。

## **了解版面繼承**

簡報有三個相關層級：

1. 一個[母片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/)定義主題、共用格式、背景以及公用物件。
1. 一個[版面投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/)屬於母片，定義特定的占位符排列。
1. 一個[普通投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/)使用一個版面，並儲存該投影片的實際內容。

普通投影片從其版面繼承主題與格式，版面則從母片繼承。直接設定在普通投影片上的值會覆寫該層級的繼承值。建立普通投影片時，其占位符圖形會根據所選版面產生，而填入占位符的內容則屬於普通投影片。

在建立投影片前，請先將必要的占位符加入版面。之後再為版面新增占位符不會自動在已存在的普通投影片中加入對應的占位符圖形。

此關係有兩個重要的影響：

- 變更版面上繼承的格式或已存在的占位符幾何形狀會更新所有依賴該版面的投影片。編輯已在使用中的版面前，請先檢查其受影響的投影片並檢視最終的簡報結果。
- 仍被投影片使用的版面無法被移除。必須先將其受影響的投影片重新指派至其他版面，或僅移除未使用的版面。

如需了解此階層的最高層級，請參閱[投影片母片](/slides/zh-hant/java/slide-master/)。

若要在單一投影片或共用版面上隱藏繼承的標誌或裝飾性母片圖形，請參閱[控制母片圖形的可見性](/slides/zh-hant/java/slide-master/)。範例比較了兩張使用相同母片的投影片。

## **選取並套用投影片版面配置**

當簡報遵循標準 PowerPoint 版面定義時，請使用版面類型。版面名稱可由使用者編輯且可本地化，因此除非您掌控來源範本，否則基於名稱的選取可靠性較低。

以下範例在第一個母片上尋找**標題與內容**版面。如果該版面不存在，會特意回退至**空白**。第二個空值檢查是必要的，因為簡報可能僅包含自訂版面。選取的版面接著透過[ISlide.setLayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)方法套用到第一張普通投影片。

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

變更投影片的版面不會移除直接加入投影片的普通圖形。然而，占位符位置、繼承的格式以及現有占位符與新版面之間的對應關係可能會改變，請在切換至差異較大的版面時檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前面的範例只選取了既有版面，並未建立新版面。若要建立版面，請在目標母片的版面集合上呼叫[IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-)方法。

以下範例始終新增一個名為`Report Title and Content`的**標題與內容**版面，然後基於該版面新增普通投影片。版面名稱在集合內必須唯一。

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

僅當範本確實需要另一個可重用結構時才新增版面。如果已存在合適的版面，請選取並重複使用它，而不是建立重複的版面。

## **向版面投影片新增占位符**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)方法會提供一個[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/) 以將占位符圖形加入版面。

| PowerPoint 占位符                | `ILayoutPlaceholderManager` 方法 |
| --------------------------------- | -------------------------------- |
| ![Content](content.png)           | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

以下範例先驗證**空白**版面是否存在，然後向其新增四個占位符，最後建立使用該修改版面的普通投影片。此順序刻意設計：先新增占位符再建立普通投影片，以讓 Aspose.Slides 在該投影片上產生對應的占位符圖形。

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

![版面投影片上的占位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更繼承的格式或現有版面占位符的幾何形狀可能會影響依賴的投影片。新加入的版面占位符不會回填至已存在的普通投影片。請在簡報副本上測試版面變更，並檢查每張受影響的投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)方法移除沒有普通投影片參考的版面。該方法會保留仍在使用中的版面。

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

若要移除特定版面，首先使用其[hasDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--)或[getDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getDependingSlides--)方法。重新指派任何受影響的投影片後，再呼叫[ILayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#remove--)。嘗試移除仍在使用中的版面會拋出[PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間占位符。使用[ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--)方法可控制單一版面的這些占位符。這在例如內容版面需要顯示頁腳而標題版面不需要時特別有用。

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

## **控制母片及其子版面的頁腳可見性**

若要在母片層級中套用一致的頁腳設定，請使用[IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--)方法。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslideheaderfootermanager/)的傳播方法會針對母片及其依賴的版面投影片與普通投影片生效；不會僅針對單一普通投影片。

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

## **常見問題集**

**母片與版面投影片有什麼差異？**

母片定義簡報的主題與共用格式。版面投影片屬於母片，定義一組可重用的占位符排列。普通投影片使用這些版面，並儲存投影片特有的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用[addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)方法將其複製到目標集合。跨簡報複製時，亦需同時檢查字型、主題、影像與其他資源是否同步。

**當我修改已在使用的版面時會發生什麼？**

受影響的投影片會繼承版面變更，除非它們在本地覆寫了相關格式或物件。占位符的幾何形狀與繼承樣式因此可能一次在多張投影片上改變。編輯版面前，請使用[getDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getDependingSlides--)確認受影響的投影片。

**如果我移除仍在使用的版面會怎樣？**

Aspose.Slides 會拋出[PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。請先重新指派受影響的投影片，或使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)僅移除未被參考的版面。
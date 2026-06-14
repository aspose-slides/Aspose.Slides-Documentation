---
title: 在 Java 中套用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/java/slide-layout/
keywords:
- 投影片版面
- 內容版面
- 佔位元件
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
- 含說明文字的內容
- 含說明文字的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理與自訂投影片版面。透過 Java 程式碼範例探索版面類型、佔位元件控制與頁腳可見性。"
---
## **簡介**

投影片版面定義投影片上佔位盒的排列方式與內容格式。它控制哪些佔位元件可用以及它們顯示的位置。投影片版面可協助您快速且一致地設計簡報，無論是建立簡單的還是較複雜的內容。PowerPoint 中最常見的投影片版面包括：

**標題投影片版面** – 包含兩個文字佔位元件：一個用於標題，另一個用於副標題。

**標題與內容版面** – 在上方有較小的標題佔位元件，下方有較大的主內容佔位元件（例如文字、項目符號、圖表、影像等）。

**空白版面** – 不含任何佔位元件，讓您可以從頭自行設計投影片。

投影片版面是投影片母片的一部分，母片是定義簡報版面樣式的最高層投影片。您可以透過投影片母片存取並修改版面投影片，方式可以是依類型、名稱或唯一 ID。或者，您也可以直接在簡報內編輯特定的版面投影片。

要在 Aspose.Slides for Java 中處理投影片版面，您可以使用：

- 方法，例如 [getLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getLayoutSlides--)，以及 [getMasters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getMasters--)，位於 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別下
- 類型，如 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutplaceholdermanager/)，以及 [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
若要進一步了解如何使用母片，請參閱 [Slide Master](/slides/zh-hant/java/slide-master/) 文章。
{{% /alert %}}

## **將版面投影片新增至簡報**

若要自訂投影片的外觀與結構，您可能需要在簡報中新增版面投影片。Aspose.Slides for Java 可讓您檢查特定版面是否已存在，必要時新增，並使用該版面插入投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 存取 [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterlayoutslidecollection/)。
3. 檢查所需的版面投影片是否已存在於集合中。若不存在，新增所需的版面投影片。
4. 依新版面投影片新增一張空白投影片。
5. 儲存簡報。

以下 Java 程式碼示範如何將版面投影片新增至 PowerPoint 簡報：

```java
// 實例化代表 PowerPoint 檔案的 Presentation 類別。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // 遍歷版面投影片類型以選取版面投影片。
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // 簡報不包含所有版面類型的情況。
        // 簡報檔案僅包含空白與自訂版面類型。
        // 然而，具有自訂類型的版面投影片可能有可辨識的名稱，
        // 例如「Title」、「Title and Content」等，可用於版面投影片的選取。
        // 您也可以依賴一組佔位形狀類型。
        // 例如，標題投影片應僅具有 Title 佔位類型，依此類推。
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 使用新增的版面投影片插入一張空白投影片。
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // 將簡報儲存至磁碟。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **移除未使用的版面投影片**

Aspose.Slides 於 [Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) 類別提供 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法，以便刪除不需要且未使用的版面投影片。

以下 Java 程式碼顯示如何從 PowerPoint 簡報中移除版面投影片：

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在版面投影片中新增佔位元件**

Aspose.Slides 提供 [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) 方法，允許您在版面投影片中新增佔位元件。

此管理員包含以下佔位元件類型的方法：

| PowerPoint 佔位元件               | 方法 |
| ----------------------------------- | ------------------------------------------------------------ |
| ![內容](content.png)               | addContentPlaceholder(float x, float y, float width, float height) |
| ![內容（垂直）](contentV.png)       | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![文字](text.png)                  | addTextPlaceholder(float x, float y, float width, float height) |
| ![文字（垂直）](textV.png)          | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![圖片](picture.png)                | addPicturePlaceholder(float x, float y, float width, float height) |
| ![圖表](chart.png)                  | addChartPlaceholder(float x, float y, float width, float height) |
| ![表格](table.png)                  | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![媒體](media.png)                  | addMediaPlaceholder(float x, float y, float width, float height) |
| ![線上圖像](onlineimage.png)        | addOnlineImagePlaceholder(float x, float y, float width, float height) |

以下 Java 程式碼示範如何將新佔位形狀加入空白版面投影片：

```java
Presentation presentation = new Presentation();
try {
    // 取得空白版面投影片。
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // 取得版面投影片的佔位元件管理員。
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // 為空白版面投影片新增不同的佔位元件。
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // 使用空白版面新增新投影片。
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![版面投影片上的佔位元件](add_placeholders.png)

## **設定版面投影片的頁腳可見性**

在 PowerPoint 簡報中，日期、投影片編號與自訂文字等頁腳元素可依版面不同而顯示或隱藏。Aspose.Slides for Java 允許您控制這些頁腳佔位元件的可見性。當您希望某些版面顯示頁腳資訊而其他版面保持簡潔時，此功能相當有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得版面投影片參考。
3. 設定投影片頁腳佔位元件為可見。
4. 設定投影片編號佔位元件為可見。
5. 設定日期時間佔位元件為可見。
6. 儲存簡報。

以下 Java 程式碼顯示如何設定投影片頁腳的可見性以及相關操作：

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **設定子版面投影片的頁腳可見性**

在 PowerPoint 簡報中，日期、投影片編號與自訂文字等頁腳元素可在母片層級控制，以確保所有版面投影片的一致性。Aspose.Slides for Java 允許您在母片上設定這些頁腳佔位元件的可見性與內容，並將設定傳播至所有子版面投影片，從而在整個簡報中保持統一的頁腳資訊。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得母片參考。
3. 設定母片及所有子版面的頁腳佔位元件為可見。
4. 設定母片及所有子版面的投影片編號佔位元件為可見。
5. 設定母片及所有子版面的日期時間佔位元件為可見。
6. 儲存簡報。

以下 Java 程式碼示範此操作：

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**母片與版面投影片有何差異？**

母片定義整體主題與預設格式，而版面投影片則為不同內容類型定義特定的佔位元件排列方式。

**我可以將版面投影片從一個簡報複製到另一個簡報嗎？**

可以，您可以透過 [getLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getLayoutSlides--) 方法取得的版面投影片集合，使用 `addClone` 方法將版面投影片克隆並插入至另一個簡報。

**如果我刪除仍被投影片使用的版面投影片會發生什麼事？**

若嘗試刪除仍被至少一張投影片參照的版面投影片，Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。為避免此情況，請使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 只安全地移除未使用的版面投影片。
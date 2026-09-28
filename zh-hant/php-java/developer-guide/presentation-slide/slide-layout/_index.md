---
title: 在 PHP 中套用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/php-java/slide-layout/
keywords:
- 投影片版面
- 內容版面
- 佔位符
- 簡報設計
- 投影片設計
- 未使用版面
- 頁腳可見性
- 標題投影片
- 標題與內容
- 節標題
- 兩個內容
- 比較
- 僅標題
- 空白版面
- 內容含說明文字
- 圖片含說明文字
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP (透過 Java) 中套用、建立與修改投影片版面，新增佔位符、移除未使用的版面，並控制頁腳可見性。"
---
## **概覽**

投影片版面定義了標題、文字、圖片、圖表和表格等佔位符的位置與格式。套用版面可使投影片具備一致的結構，同時允許每張投影片保有各自的內容。

最常見的版面包括：

- **標題投影片**：包含標題與副標題佔位符。
- **標題與內容**：包含標題佔位符與通用內容佔位符。
- **空白**：不包含任何內容佔位符，適用於需要手動定位所有形狀的情況。

## **瞭解版面繼承**

簡報具有三個相關層級：

1. 一個[母片投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 定義主題、共用格式、背景及共通物件。
1. 一個[版面投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 屬於母片，定義特定的佔位符配置。
1. 一個[普通投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 使用一個版面，並儲存該投影片的內容。

普通投影片從其版面繼承主題與格式，版面則從其母片繼承。直接在普通投影片上設定的值會覆寫該層級的繼承值。建立普通投影片時，其佔位符形狀會根據所選版面產生，而填入這些佔位符的內容屬於普通投影片本身。

在建立投影片之前，請先在版面中加入所需的佔位符。之後再為版面新增佔位符不會自動為現有的普通投影片添加對應的佔位符形狀。

此關係有兩個重要的後果：

- 變更版面上繼承的格式或現有佔位符的幾何形狀會更新所有依賴該版面的投影片。在編輯已被使用的版面前，請先檢查其依賴的投影片並審視產生的簡報。
- 仍被投影片使用的版面無法移除。必須先將其依賴的投影片重新指派到其他版面，或只移除未被使用的版面。

欲瞭解此層級階層的更多資訊，請參閱[投影片母片](/slides/zh-hant/php-java/slide-master/)。

若要在單一投影片或透過共用版面隱藏繼承的商標或裝飾性母片圖形，請參閱[控制母片圖形的可見性](/slides/zh-hant/php-java/slide-master/)。範例比較了兩張使用相同母片的投影片。

## **選取與套用投影片版面**

當簡報遵循 PowerPoint 標準版面定義時，使用版面類型。版面名稱可由使用者編輯且能本地化，因此除非您能控制來源範本，否則基於名稱的選取可靠性較低。

以下範例在第一個母片上尋找**標題與內容**版面。如果該版面不存在，則會明確回退到**空白**。第二個 null 檢查是必要的，因為簡報可能只包含自訂版面。選取的版面随后透過[Slide.setLayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#setLayoutSlide) 方法套用到第一張普通投影片。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

變更投影片的版面不會移除直接加入投影片的普通形狀。然而，佔位符位置、繼承的格式以及現有佔位符與新版面之間的對應關係可能會改變，切換差異大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前面的範例只選取了既有版面，並未建立。若要建立版面，請於目標母片的版面集合呼叫[MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterlayoutslidecollection/#add) 方法。

以下範例始終新增一個名為`Report Title and Content`的**標題與內容**版面，然後基於它新增普通投影片。版面名稱在集合內必須唯一。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

僅在範本真正需要另一個可重複使用的結構時才新增版面。若已有合適的版面，請選取並重複使用，而非建立重複的版面。

## **在版面投影片中新增佔位符**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getPlaceholderManager) 方法會回傳一個[LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/) 物件，用於向版面新增佔位符形狀。

| PowerPoint 佔位符                | `LayoutPlaceholderManager` 方法 |
| -------------------------------- | -------------------------------- |
| ![內容](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![內容（垂直）](contentV.png)    | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![文字](text.png)                | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![文字（垂直）](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![圖片](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![圖表](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![表格](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)        | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![媒體](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![線上圖片](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

以下範例驗證**空白**版面是否存在，向其新增四個佔位符，然後建立使用修改後版面的普通投影片。順序故意安排在先新增佔位符，再建立普通投影片，讓 Aspose.Slides 能在該投影片上產生對應的佔位符形狀。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![版面投影片上的佔位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更繼承的格式或現有版面佔位符的幾何形狀可能會影響依賴的投影片。新加入的版面佔位符不會回填到既有的普通投影片。請在簡報副本上測試版面變更，並檢查每一張依賴投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 方法移除沒有任何普通投影片參照的版面。該方法會保留仍在使用中的版面。

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若要移除特定版面，首先使用其[hasDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#hasDependingSlides) 或[getDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getDependingSlides) 方法。重新指派所有依賴的投影片後，再呼叫[LayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#remove)。嘗試移除仍在使用的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位符。使用[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) 方法即可對單一版面的這些佔位符進行控制。例如，內容版面顯示頁腳而標題版面不顯示。

以下範例安全地選取版面，並將其頁腳元素設為可見：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在母片及其子版面上控制頁腳可見性**

若要在母片層級上套用一致的頁腳設定，請使用[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/#getHeaderFooterManager) 方法。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslideheaderfootermanager/) 的傳播方法同時作用於母片、其依賴的版面投影片與普通投影片；不會只針對單一普通投影片。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**母片投影片與版面投影片有何差異？**

母片投影片定義簡報的主題與共用格式。版面投影片屬於母片，定義可重複使用的佔位符排列。普通投影片使用這些版面，並儲存投影片特定的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/globallayoutslidecollection/#addClone) 方法將副本加入目標集合。跨簡報複製時，同時請確認來源版面使用的字型、主題、影像與其他資源。

**當我修改已在使用的版面時會發生什麼？**

依賴的投影片會繼承版面的變更，除非它們在本機覆寫了受影響的格式或物件。佔位符幾何形狀與繼承的樣式因此可能一次改變多張投影片。編輯版面前，請使用[getDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getDependingSlides) 以識別受影響的投影片。

**如果我移除仍在使用的版面會怎樣？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。請先重新指派依賴的投影片，或使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 僅移除未被參照的版面。
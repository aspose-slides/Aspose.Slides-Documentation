---
title: 在 PHP 中套用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/php-java/slide-layout/
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
- 區段標題
- 雙內容版面
- 比較
- 只有標題
- 空白版面
- 含說明文字的內容
- 含說明文字的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP（透過 Java）中套用、建立及修改投影片版面，加入佔位元、移除未使用的版面，並控制頁腳可見性。"
---
## **概述**

投影片版面定義了諸如標題、文字、圖片、圖表和表格等佔位元的定位與格式。套用版面可為投影片提供一致的結構，同時允許每張投影片保有自己的內容。

最常見的版面包括：

- **Title Slide**：包含標題和副標題佔位元。
- **Title and Content**：包含標題佔位元以及一般用途的內容佔位元。
- **Blank**：不包含任何內容佔位元，適用於需要手動定位每個圖形的情況。

## **瞭解版面繼承**

簡報具有三個相關層級：

1. A [母片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 定義主題、共用格式、背景和共同物件。
2. A [版面投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 隸屬於母片，定義特定的佔位元排列。
3. A [普通投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 使用一個版面，並儲存該投影片的內容。

普通投影片繼承版面的主題與格式，而版面則繼承自母片。直接設定於普通投影片的值會覆寫該層級繼承的值。當建立普通投影片時，其佔位元圖形會根據所選版面產生，而填入這些佔位元的內容則屬於普通投影片本身。

在從版面建立投影片之前，請先在版面上加入必要的佔位元。之後再於版面新增佔位元不會自動為已存在的普通投影片加入相對應的佔位元圖形。

此關係有兩個重要的影響：

- 修改版面上繼承的格式或現有佔位元的幾何形狀，會更新所有依賴該版面的投影片。編輯已在使用中的版面前，請檢查其受影響的投影片並審閱最終簡報。
- 仍被投影片使用的版面無法被移除。請先將其受影響的投影片重新指派至其他版面，或僅移除未使用的版面。

欲了解此階層最上層的更多資訊，請參閱 [Slide Master](/slides/zh-hant/php-java/slide-master/)。

## **選取並套用投影片版面**

使用版面類型時，簡報遵循標準 PowerPoint 版面定義。版面名稱可由使用者編輯且可本地化，因此僅依名稱選取的可靠性較低，除非您掌控來源模板。

以下範例在第一個母片上尋找 **Title and Content**。若該版面不存在，則刻意退回到 **Blank**。第二個 null 檢查是必要的，因為簡報可能僅包含自訂版面。接著透過 [Slide.setLayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#setLayoutSlide) 方法，將選取的版面套用至第一張普通投影片。

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

變更投影片的版面不會移除直接加在投影片上的一般圖形。然而，佔位元位置、繼承的格式，以及既有佔位元與新版面之間的對應關係可能會改變，因此在切換差異較大的版面時，請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。先前的範例僅選取既有版面，並未建立新的。若要建立版面，請於目標母片的版面集合上呼叫 [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterlayoutslidecollection/#add) 方法。

以下範例總是新增一個名為 `Report Title and Content` 的 **Title and Content** 版面，然後再基於該版面加入普通投影片。版面名稱在集合中必須唯一。

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

僅在模板確實需要另一個可重複使用的結構時才新增版面。如果已有合適的版面，請直接選取並重複使用，而非建立重複的版面。

## **在版面投影片中加入佔位元**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getPlaceholderManager) 方法提供一個 [LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/)，用於向版面新增佔位元圖形。

| PowerPoint 佔位元 | `LayoutPlaceholderManager` 方法 |
| ------------------- | --------------------------------- |
| ![內容](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![內容（垂直）](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![文字](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![文字（垂直）](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![圖片](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![圖表](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![表格](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![媒體](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![線上圖像](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

以下範例驗證 **Blank** 版面是否存在，向其加入四個佔位元，然後建立使用該修改後版面的普通投影片。此順序刻意安排：先加入佔位元，再建立普通投影片，讓 Aspose.Slides 能在該投影片上產生相對應的佔位元圖形。

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

![版面投影片上的佔位元](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更繼承的格式或既有版面佔位元的幾何形狀可能會影響依賴的投影片。新加入的版面佔位元不會自動填入已存在的普通投影片。請在簡報的副本上測試版面變更，並檢查所有受影響的投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用 [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 方法，可移除未被任何普通投影片參考的版面。仍在使用中的版面會保持不變。

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

若要移除特定版面，先使用其 [hasDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#hasDependingSlides) 或 [getDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getDependingSlides) 方法。於呼叫 [LayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#remove) 前，請重新指派所有受影響的投影片。嘗試移除仍在使用中的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號和日期時間佔位元。使用 [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) 方法，可針對單一版面控制這些佔位元。這在例如內容版面需要顯示頁腳，而標題版面不需要時非常有用。

以下範例安全地選取版面並將其頁腳元素設為可見：

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

## **控制母片及其子版面的頁腳可見性**

若要在母片層級中套用一致的頁腳設定，請使用 [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/#getHeaderFooterManager) 方法。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslideheaderfootermanager/) 的傳播方法會作用於母片及其依賴的版面投影片與普通投影片；不會僅針對單一普通投影片。

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

**母片與版面投影片的差異是什麼？**

母片定義簡報的主題與共用格式。版面投影片隸屬於母片，定義一套可重複使用的佔位元排列。普通投影片使用這些版面，並儲存特定投影片的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/globallayoutslidecollection/#addClone) 方法將副本加入目標集合。跨簡報複製時，也請確認來源版面使用的字型、主題、圖片及其他資源。

**當我修改已在使用的版面時會發生什麼？**

依賴的投影片會繼承版面的變更，除非它們在本機覆寫了受影響的格式或物件。因此，佔位元的幾何形狀與繼承的樣式可能一次在多張投影片上改變。編輯版面前，請使用 [getDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getDependingSlides) 來辨識受影響的投影片。

**如果我移除仍在使用中的版面會發生什麼？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。請先重新指派受影響的投影片，或使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 只移除未被參考的版面。
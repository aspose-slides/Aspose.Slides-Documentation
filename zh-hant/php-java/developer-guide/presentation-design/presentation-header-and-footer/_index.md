---
title: 在 PHP 中管理簡報標題與頁腳
linktitle: 標題與頁腳
type: docs
weight: 140
url: /zh-hant/php-java/presentation-header-and-footer/
keywords:
- 標題
- 標題文字
- 頁腳
- 頁腳文字
- 設定標題
- 設定頁腳
- 講義
- 備註
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 於投影片、備註頁面與講義上管理頁腳、日期/時間、投影片編號與標題佔位符。"
---
## **概述**

PowerPoint 會根據頁面類型使用不同的標題與頁腳佔位符。Aspose.Slides for PHP via Java 允許您透過標題/頁腳管理器類別控制這些佔位符的文字與可見性。

可用的佔位符取決於範圍：

| 範圍 | 標題 | 頁腳 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 普通投影片 | 否 | 是 | 是 | 是 |
| 備註母片 | 是 | 是 | 是 | 是 |
| 備註投影片 | 是 | 是 | 是 | 是 |
| 講義母片 | 是 | 是 | 是 | 是 |

普通的簡報投影片沒有標題佔位符。標題僅在備註頁面和講義上可用。對於普通投影片，請改用頁腳、日期/時間和投影片編號佔位符。

變更的範圍取決於您使用的管理器。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideheaderfootermanager/) 類別控制一個普通投影片。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslideheaderfootermanager/) 類別控制一個備註投影片。母片與版面配置管理器也可以將設定傳播至相依的投影片，而 [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) 類別則控制講義母片。

## **設定普通投影片的頁腳、日期/時間與投影片編號**

對於普通投影片，基本工作流程是存取每張投影片的標題/頁腳管理器、設定頁腳與日期/時間文字、啟用所需的佔位符，然後儲存簡報。投影片編號由簡報自動產生，因此您只需控制其可見性。

使用 [`setFooterText`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) 與 [`setDateTimeText`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) 設定文字，並使用 [`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) 與 [`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) 顯示相應的佔位符。

以下的端到端範例將相同的頁腳、日期/時間文字以及投影片編號可見性套用至所有普通投影片：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果您只需要更新單一投影片，請直接透過 [`getSlides`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getslides/) 方法存取該投影片，而不是遍歷整個集合。

## **設定備註母片的標題與頁腳**

備註母片為備註頁面定義共通的格式與佔位符行為。當您只想變更備註母片本身時，請使用 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/) 類別。

以下範例在備註母片上設定標題、頁腳與日期/時間文字，並使該母片上所有支援的佔位符可見：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) 方法在簡報未包含備註母片時會傳回 `null`。

## **將備註母片設定套用至子備註投影片**

備註母片可以將標題與頁腳設定套用於自身以及所有相依的備註投影片。當相同設定需套用於整個備註層級時，請使用 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/) 上的專屬傳播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) 與 [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) 會更新備註母片的標題以及所有子標題。對於頁腳、日期/時間與投影片編號也有等效的方法。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

上述使用的傳播方法包括 [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)、[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)。

## **設定單一備註投影片的標題與頁腳**

備註投影片屬於特定的普通投影片。當您只想自訂該備註頁面時，請使用其 [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslideheaderfootermanager/) 類別。

[`addNotesSlide`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslidemanager/addnotesslide/) 方法會傳回目前投影片的備註投影片，若不存在則會建立一個。以下範例設定與第一張簡報投影片關聯的備註頁面：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果您先從備註母片傳播設定，然後再變更單一備註投影片，之後的逐投影片設定即可讓您獨立自訂該備註頁面。

## **設定講義母片的標題與頁腳**

講義頁面使用講義母片作為其標題、頁腳、日期/時間與頁碼佔位符。與備註頁面不同，講義設定是透過講義母片管理，而非個別的講義投影片。

使用 [`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) 方法存取講義母片。如果不存在，請呼叫 [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) 建立預設的講義母片。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **了解範圍與繼承**

選擇與您欲變更之範圍相符的標題/頁腳管理器：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideheaderfootermanager/) 變更單一普通投影片的頁腳、日期/時間與投影片編號設定。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslideheaderfootermanager/) 控制版面投影片，且可將支援的設定傳播至相依的投影片。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslideheaderfootermanager/) 控制普通投影片母片，且可將支援的設定傳播至相依的投影片。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslideheaderfootermanager/) 控制備註母片，且可將設定傳播至所有相依的備註投影片。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslideheaderfootermanager/) 變更單一備註投影片，並支援標題佔位符，此外還有頁腳、日期/時間與投影片編號。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) 變更講義母片，並支援全部四種佔位符類型。

當相同設定應套用於整個層級時，請使用母片或版面的傳播。當您需要為單一頁面設定局部設定時，請使用個別投影片或備註投影片管理器。

## **常見問題**

**我可以在普通投影片上加入標題嗎？**

不行。PowerPoint 未為普通投影片定義標題佔位符。於普通投影片請使用頁腳、日期/時間與投影片編號佔位符。標題佔位符僅在備註頁面與講義上可用。

**如果頁腳、日期/時間或投影片編號佔位符未顯示該怎麼辦？**

使用相應的標題/頁腳管理器檢查其可見性，並在需要時啟用。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) 會回報是否存在頁腳佔位符，而 [`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) 則變更其可見性。

**如何從非 1 的數值開始投影片編號？**

呼叫簡報的 [`setFirstSlideNumber`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/setfirstslidenumber/) 方法。投影片編號佔位符將使用更新後的編號序列。

**匯出為 PDF、圖像或 HTML 時，標題與頁腳會發生什麼變化？**

可見的標題與頁腳元素會與簡報內容一起在輸出格式中呈現。其外觀取決於被匯出的頁面類型以及相對的佔位符可見性設定。
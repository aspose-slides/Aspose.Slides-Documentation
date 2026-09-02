---
title: 管理 JavaScript 簡報的頁眉與頁腳
linktitle: 頁眉與頁腳
type: docs
weight: 140
url: /zh-hant/nodejs-java/presentation-header-and-footer/
keywords:
- 頁眉
- 頁眉文字
- 頁腳
- 頁腳文字
- 設定頁眉
- 設定頁腳
- 講義
- 備註
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 於投影片、備註頁面與講義上管理頁腳、日期/時間、投影片編號與頁眉佔位符。"
---
## **概述**

PowerPoint 會根據頁面類型使用不同的頁眉和頁腳佔位符。Aspose.Slides for Node.js via Java 允許您透過頁眉/頁腳管理器類別控制這些佔位符的文字和可見性。

可用的佔位符取決於範圍：

| 範圍 | 頁眉 | 頁腳 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 一般投影片 | 否 | 是 | 是 | 是 |
| 備註主版 | 是 | 是 | 是 | 是 |
| 備註投影片 | 是 | 是 | 是 | 是 |
| 講義主版 | 是 | 是 | 是 | 是 |

一般投影片沒有頁眉佔位符。頁眉僅在備註頁面和講義上可用。對於一般投影片，請改用頁腳、日期/時間和投影片編號佔位符。

變更的範圍取決於您使用的管理器。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideheaderfootermanager/) 類別控制單一一般投影片。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslideheaderfootermanager/) 類別控制單一備註投影片。主版與版面配置管理器也可以將設定傳播至相依的投影片，而 [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) 類別則控制講義主版。

## **設定一般投影片的頁腳、日期/時間與投影片編號**

對於一般投影片，基本工作流程是存取每張投影片的頁眉/頁腳管理器、設定頁腳與日期/時間文字、啟用所需的佔位符，然後儲存簡報。投影片編號由簡報自動產生，因此您只需要控制其可見性。

使用 [`setFooterText`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) 和 [`setDateTimeText`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) 來設定文字，並使用 [`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), 以及 [`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) 以顯示相應的佔位符。

以下的端對端範例會將相同的頁腳、日期/時間文字與投影片編號可見性套用至所有一般投影片：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果您只需要更新單一投影片，請直接透過 [`getSlides`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslides/) 方法存取該投影片，而不是遍歷整個集合。

## **設定備註主版的頁眉與頁腳**

備註主版定義備註頁面的共通格式與佔位符行為。若只想變更備註主版本身，請使用 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) 類別。

以下範例會在備註主版上設定頁眉、頁腳與日期/時間文字，並使該主版上所有支援的佔位符皆可見：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) 方法會在簡報不包含備註主版時回傳 `null`。

## **將備註主版設定套用至子備註投影片**

備註主版可以將頁眉與頁腳設定套用到自身以及所有相依的備註投影片。當相同設定需於備註層級中套用時，請使用 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) 上的專屬傳播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) 和 [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) 會更新備註主版的頁眉以及所有子頁眉。對於頁腳、日期/時間與投影片編號也提供了等效的方法。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

上述使用的傳播方法包括 [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), 以及 [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)。

## **在單一備註投影片上設定頁眉與頁腳**

備註投影片屬於特定的一般投影片。若只想自訂該備註頁面，請使用其 [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslideheaderfootermanager/) 類別。

[`addNotesSlide`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) 方法會回傳當前投影片的備註投影片，若不存在則會建立一個。以下範例設定與第一張投影片關聯的備註頁面：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果您先從備註主版傳播設定，然後再變更單一備註投影片，後者的逐投影片設定即可讓您獨立自訂該備註頁面。

## **在講義主版上設定頁眉與頁腳**

講義頁面使用講義主版作為其頁眉、頁腳、日期/時間與頁碼佔位符。與備註頁面不同，講義的設定是透過講義主版而非個別講義投影片來管理。

使用 [`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) 以存取講義主版。若不存在，請呼叫 [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) 以建立預設的講義主版。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **了解範圍與繼承**

選擇符合您欲變更範圍的頁眉/頁腳管理器：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideheaderfootermanager/) 會變更單一一般投影片的頁腳、日期/時間與投影片編號設定。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) 控制版面投影片，並能將支援的設定傳播至相依的投影片。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslideheaderfootermanager/) 控制一般投影片的主版，並可將支援的設定傳播至相依的投影片。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) 控制備註主版，並可將設定傳播至所有相依的備註投影片。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslideheaderfootermanager/) 變更單一備註投影片，並支援頁眉佔位符，除此之外還有頁腳、日期/時間與投影片編號。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) 變更講義主版，並支援所有四種佔位符類型。

當相同設定需在整個層級中套用時，請使用主版或版面配置的傳播功能。若僅需對單一頁面進行本地設定，則使用個別投影片或備註投影片的管理器。

## **常見問題**

**我可以在一般投影片上添加頁眉嗎？**

不能。PowerPoint 並未為一般投影片定義頁眉佔位符。在一般投影片上，請使用頁腳、日期/時間與投影片編號佔位符。頁眉佔位符僅在備註頁面和講義上可用。

**如果頁腳、日期/時間或投影片編號佔位符未顯示該怎麼辦？**

使用相應的頁眉/頁腳管理器檢查其可見性，並在需要時啟用。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) 會回報頁腳佔位符是否存在，而 [`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) 則可變更其可見性。

**我要如何從非 1 的數值開始投影片編號？**

呼叫簡報的 [`setFirstSlideNumber`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) 方法。投影片編號佔位符將會使用更新後的編號序列。

**匯出為 PDF、圖像或 HTML 時，頁眉與頁腳會發生什麼變化？**

可見的頁眉與頁腳元素會與簡報內容一起在輸出格式中呈現。其外觀取決於匯出的頁面類型以及相應的佔位符可見性設定。
---
title: 在 Android 上管理簡報標題與頁腳
linktitle: 標題與頁腳
type: docs
weight: 140
url: /zh-hant/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for Android via Java 在投影片、備註頁面與講義上管理頁腳、日期時間、投影片編號與標題佔位元。"
---
## **概述**

PowerPoint會根據頁面類型使用不同的標題與頁腳佔位元。Aspose.Slides for Android via Java 允許您透過標題/頁腳管理器介面控制這些佔位元的文字與可見性。

可用的佔位元取決於範圍：

| 範圍 | 標題 | 頁腳 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 一般投影片 | 否 | 是 | 是 | 是 |
| 備註母版 | 是 | 是 | 是 | 是 |
| 備註投影片 | 是 | 是 | 是 | 是 |
| 講義母版 | 是 | 是 | 是 | 是 |

一般的簡報投影片沒有標題佔位元。標題僅在備註頁面與講義上可用。對於一般投影片，請改用頁腳、日期/時間與投影片編號的佔位元。

變更的範圍取決於您使用的管理器。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideheaderfootermanager/) 介面控制單一一般投影片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) 介面控制單一備註投影片。母版與版面配置管理器也可以將設定傳播至相依投影片，而[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 介面則控制講義母版。

## **在一般投影片上設定頁腳、日期/時間與投影片編號**

對於一般投影片，其基本工作流程是存取每張投影片的標題/頁腳管理器、設定頁腳與日期/時間文字、啟用所需的佔位元，然後儲存簡報。投影片編號由簡報自動產生，因此只需控制其可見性。

使用[`setFooterText`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-)與[`setDateTimeText`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-)設定文字，並使用[`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)以及[`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-)顯示對應的佔位元。

以下端對端範例將相同的頁腳、日期/時間文字與投影片編號可見性套用至所有一般投影片：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需要更新單一投影片，可直接透過[`getSlides`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--) 方法存取該投影片，而不是遍歷整個集合。

## **在備註母版上設定標題與頁腳**

備註母版定義備註頁面的共用格式與佔位元行為。若只想變更備註母版本身，請使用[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) 介面。

以下範例在備註母版上設定標題、頁腳與日期/時間文字，並使該母版上所有支援的佔位元可見：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) 方法在簡報未包含備註母版時會回傳 `null`。

## **將備註母版設定套用至子備註投影片**

備註母版可以將標題與頁腳設定套用到自身以及所有相依的備註投影片。若需在整個備註層級中套用相同設定，請使用[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) 上的專用傳播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-)與[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-)會更新備註母版的標題以及所有子標題。對於頁腳、日期/時間與投影片編號也提供了等效的方法。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

上述使用的傳播方法包括[`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)以及[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)。

## **在單一備註投影片上設定標題與頁腳**

備註投影片屬於特定的一般投影片。若只想自訂該備註頁面，請使用其[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) 介面。

[`addNotesSlide`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) 方法會回傳目前投影片的備註投影片，若尚未存在則會建立一個。以下範例設定與第一張簡報投影片關聯的備註頁面：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果您先從備註母版傳播設定，然後再變更單一備註投影片，後續的逐投影片設定即可讓您獨立自訂該備註頁面。

## **在講義母版上設定標題與頁腳**

講義頁面使用講義母版來放置其標題、頁腳、日期/時間與頁碼佔位元。與備註頁面不同，講義的設定是透過講義母版而非個別講義投影片來管理。

使用[`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) 方法存取講義母版。若不存在，請呼叫[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 以建立預設的講義母版。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **了解範圍與繼承**

選擇符合您欲變更範圍的標題/頁腳管理器：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideheaderfootermanager/) 變更單一一般投影片的頁腳、日期/時間與投影片編號設定。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) 控制版面配置投影片，並可將支援的設定傳播至相依投影片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) 控制一般投影片母版，並可將支援的設定傳播至相依投影片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) 控制備註母版，並可將設定傳播至所有相依的備註投影片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) 變更單一備註投影片，並支援標題佔位元，此外亦支援頁腳、日期/時間與投影片編號。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 變更講義母版，並支援所有四種佔位元類型。

當相同設定需在整個層級中套用時，請使用母版或版面配置的傳播功能。若只需針對單一頁面設定局部值，請使用個別投影片或備註投影片管理器。

## **FAQ**

**我可以在一般投影片上加入標題嗎？**

不能。PowerPoint 未為一般投影片定義標題佔位元。在一般投影片上，請使用頁腳、日期/時間與投影片編號佔位元。標題佔位元僅在備註頁面與講義中可用。

**如果頁腳、日期/時間或投影片編號佔位元未顯示，該怎麼辦？**

使用相對應的標題/頁腳管理器檢查其可見性，並在需要時啟用它。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) 會回報是否存在頁腳佔位元，[`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) 則變更其可見性。

**如何讓投影片編號從非 1 的值開始？**

呼叫簡報的[`setFirstSlideNumber`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 方法。投影片編號佔位元將使用更新後的編號序列。

**將簡報匯出為 PDF、影像或 HTML 時，標題與頁腳會怎樣？**

可見的標題與頁腳元素會與簡報內容一起在輸出格式中呈現。其外觀取決於匯出的頁面類型以及相應的佔位元可見性設定。
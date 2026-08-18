---
title: 管理 Java 中的簡報頁首與頁尾
linktitle: 頁首與頁尾
type: docs
weight: 140
url: /zh-hant/java/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁尾
- 頁尾文字
- 設定頁首
- 設定頁尾
- 講義
- 註解
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 管理投影片、註解頁面與講義中的頁尾、日期/時間、投影片編號與頁首佔位元。"
---
## **概述**

PowerPoint 會根據頁面類型使用不同的頁首和頁尾佔位元。Aspose.Slides for Java 讓您能透過頁首/頁尾管理介面控制這些佔位元的文字與可見性。

可用的佔位元取決於範圍：

| 範圍 | 頁首 | 頁尾 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 普通投影片 | 否 | 是 | 是 | 是 |
| 註解母片 | 是 | 是 | 是 | 是 |
| 註解投影片 | 是 | 是 | 是 | 是 |
| 講義母片 | 是 | 是 | 是 | 是 |

普通的簡報投影片沒有頁首佔位元。頁首在註解頁面和講義上可用。在普通投影片上，請改為使用頁尾、日期/時間與投影片編號佔位元。

變更的範圍取決於您使用的管理員。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islideheaderfootermanager/) 介面控制單一普通投影片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/inotesslideheaderfootermanager/) 介面控制單一註解投影片。母片與版面配置管理員也可以將設定傳播至依賴的投影片，而[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 介面則控制講義母片。

## **設定普通投影片的頁尾、日期/時間與投影片編號**

對於普通投影片，基本工作流程是存取每張投影片的頁首/頁尾管理員，設定頁尾與日期/時間文字，啟用所需的佔位元，然後儲存簡報。投影片編號由簡報自動產生，只需控制其可見性即可。

使用[`setFooterText`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-)與[`setDateTimeText`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-)設定文字，並使用[`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)與[`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-)顯示相應的佔位元。

以下端對端範例將相同的頁尾、日期/時間文字與投影片編號可見性套用至所有普通投影片：

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

如果只需要更新單一投影片，請直接透過[`getSlides`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlides--) 方法取得該投影片，而非遍歷整個集合。

## **在註解母片上設定頁首與頁尾**

註解母片定義了註解頁面的通用格式與佔位元行為。當您只想變更註解母片本身時，請使用[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/) 介面。

以下範例在註解母片上設定頁首、頁尾與日期/時間文字，並使該母片上所有支援的佔位元皆可見：

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

當簡報未包含註解母片時，[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) 方法會回傳 `null`。

## **將註解母片設定套用至子註解投影片**

註解母片可以將頁首與頁尾設定套用給自己以及所有相依的註解投影片。當相同設定需在註解層級中傳播時，請使用[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/) 上的專屬傳播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-)與[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-)會更新註解母片的頁首以及所有子頁首。對於頁尾、日期/時間與投影片編號亦有對應的方法。

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

上述使用的傳播方法包括[`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)、以及[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)。

## **在個別註解投影片上設定頁首與頁尾**

註解投影片屬於特定的普通投影片。當您只想自訂該註解頁面時，請使用其[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/inotesslideheaderfootermanager/) 介面。

[`addNotesSlide`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) 方法會回傳目前投影片的註解投影片，若尚未存在則會建立。以下範例設定與第一張簡報投影片關聯的註解頁面：

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

如果先從註解母片傳播設定，然後再變更個別註解投影片，後續的單張設定即可讓該註解頁面獨立客製化。

## **在講義母片上設定頁首與頁尾**

講義頁面使用講義母片作為其頁首、頁尾、日期/時間與頁號佔位元。與註解頁面不同，講義的設定是透過講義母片管理，而非各別講義投影片。

使用[`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) 方法存取講義母片。若不存在，請呼叫[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 以建立預設的講義母片。

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

選擇符合您欲變更範圍的頁首/頁尾管理員：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islideheaderfootermanager/) 變更單一普通投影片的頁尾、日期/時間與投影片編號設定。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslideheaderfootermanager/) 控制版面投影片，並可將支援的設定傳播至相依投影片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslideheaderfootermanager/) 控制普通投影片母片，並可將支援的設定傳播至相依投影片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslideheaderfootermanager/) 控制註解母片，並可將設定傳播至所有相依的註解投影片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/inotesslideheaderfootermanager/) 變更單一註解投影片，並支援頁首佔位元以及頁尾、日期/時間與投影片編號。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 變更講義母片，支援所有四種佔位元類型。

當相同設定應套用於整個層級時，請從母片或版面傳播設定。需要單頁局部設定時，則使用個別投影片或註解投影片管理員。

## **FAQ**

**我可以在普通投影片上加入頁首嗎？**

不行。PowerPoint 未為普通投影片定義頁首佔位元。請在普通投影片上使用頁尾、日期/時間與投影片編號佔位元。頁首佔位元僅在註解頁面與講義上可用。

**如果頁尾、日期/時間或投影片編號佔位元未顯示怎麼辦？**

使用相應的頁首/頁尾管理員檢查其可見性，必要時啟用。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) 會回報頁尾佔位元是否存在，而[`setFooterVisibility`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) 則可變更其可見性。

**如何將投影片編號的起始值設定為非 1？**

呼叫簡報的[`setFirstSlideNumber`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 方法。之後投影片編號佔位元會依更新的編號序列顯示。

**匯出為 PDF、影像或 HTML 時，頁首與頁尾會怎樣？**

可見的頁首與頁尾元素會與簡報內容一同在輸出格式中呈現。其外觀取決於被匯出的頁面類型以及相對應的佔位元可見性設定。
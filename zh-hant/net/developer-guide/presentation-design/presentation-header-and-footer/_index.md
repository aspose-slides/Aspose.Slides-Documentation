---
title: 在 .NET 中管理簡報的標題與頁腳
linktitle: 標題與頁腳
type: docs
weight: 140
url: /zh-hant/net/presentation-header-and-footer/
keywords:
- 標題
- 標題文字
- 頁腳
- 頁腳文字
- 設定標題
- 設定頁腳
- 講義
- 註記
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在投影片、註記頁面與講義上管理頁腳、日期時間、投影片編號與標題佔位符。"
---
## **概述**

PowerPoint 會根據頁面類型使用不同的標題和頁腳佔位符。Aspose.Slides for .NET 讓您透過標題/頁腳管理介面控制這些佔位符的文字與可見性。

可用的佔位符取決於範圍：

| 範圍 | 標題 | 頁腳 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 一般投影片 | 否 | 是 | 是 | 是 |
| 註記母片 | 是 | 是 | 是 | 是 |
| 註記投影片 | 是 | 是 | 是 | 是 |
| 講義母片 | 是 | 是 | 是 | 是 |

一般投影片沒有標題佔位符。標題佔位符僅在註記頁面與講義上可用。對於一般投影片，請改用頁腳、日期/時間及投影片號碼佔位符。

變更的範圍取決於您使用的管理器。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideheaderfootermanager/) 介面控制單一一般投影片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inotesslideheaderfootermanager/) 介面控制單一註記投影片。母片與版面配置管理器也可以將設定傳播至相依投影片，而 [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterhandoutslideheaderfootermanager/) 介面則控制講義母片。

## **在一般投影片上設定頁腳、日期/時間與投影片編號**

對於一般投影片，基本工作流程是存取每張投影片的標題/頁腳管理器、設定頁腳與日期/時間文字、啟用所需的佔位符，然後儲存簡報。投影片編號由簡報自動產生，因此您僅需控制其可見性。

使用 [`SetFooterText`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) 與 [`SetDateTimeText`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) 設定文字，並使用 [`SetFooterVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)、[`SetDateTimeVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/)、[`SetSlideNumberVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) 來顯示相對應的佔位符。

以下完整範例會將相同的頁腳、日期/時間文字與投影片編號可見性套用至所有一般投影片：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

如果只需更新單一投影片，請直接透過 [`Slides`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slides/zh-hant/) 集合存取該投影片，而非遍歷整個集合。

## **在註記母片上設定標題與頁腳**

註記母片定義註記頁面的共用格式與佔位符行為。當您只想變更註記母片本身時，請使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslideheaderfootermanager/) 介面。

以下範例會在註記母片上設定標題、頁腳與日期/時間文字，並使該母片上所有支援的佔位符可見：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

當簡報不包含註記母片時，[`MasterNotesSlide`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslidemanager/masternotesslide/) 屬性會回傳 `null`。

## **將註記母片設定套用至子註記投影片**

註記母片可以將標題與頁腳設定套用於自身及所有相依的註記投影片。當相同設定需套用於整個註記階層時，請使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslideheaderfootermanager/) 上的專屬傳播方法。

例如，[`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) 與 [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) 會更新註記母片的標題與所有子標題。對於頁腳、日期/時間與投影片編號亦提供等效的方法。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

上述使用的傳播方法包括 [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)、[`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)、[`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)、[`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)、[`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)。

## **在單一註記投影片上設定標題與頁腳**

註記投影片隸屬於特定的一般投影片。當您只想自訂該註記頁面時，請使用其 [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inotesslideheaderfootermanager/) 介面。

[`AddNotesSlide`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inotesslidemanager/addnotesslide/) 方法會回傳目前投影片的註記投影片，若不存在則會建立。以下範例會設定與第一張簡報投影片關聯的註記頁面：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

如果您先從註記母片傳播設定，然後再變更單一註記投影片，後續的逐投影片設定即可讓您獨立自訂該註記頁面。

## **在講義母片上設定標題與頁腳**

講義頁面使用講義母片來放置標題、頁腳、日期/時間與頁碼佔位符。與註記頁面不同，講義的設定是透過講義母片管理，而非個別的講義投影片。

使用 [`MasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) 屬性存取講義母片。若不存在，請呼叫 [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 以建立預設的講義母片。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **了解範圍與繼承**

選擇與您欲變更的範圍相符的標題/頁腳管理器：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideheaderfootermanager/) 會變更單一一般投影片的頁腳、日期/時間與投影片編號設定。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslideheaderfootermanager/) 控制版面配置投影片，且可將支援的設定傳播至相依投影片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslideheaderfootermanager/) 控制一般投影片母片，並可將支援的設定傳播至相依投影片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslideheaderfootermanager/) 控制註記母片，且可將設定傳播至所有相依的註記投影片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inotesslideheaderfootermanager/) 會變更單一註記投影片，並支援標題佔位符，此外亦支援頁腳、日期/時間與投影片編號。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterhandoutslideheaderfootermanager/) 會變更講義母片，且支援全部四種佔位符類型。

當相同設定需套用於整個階層時，請使用母片或版面配置的傳播。若只需要單一頁面的局部設定，請使用個別投影片或註記投影片管理器。

## **常見問題**

**我可以在一般投影片上新增標題嗎？**

不能。PowerPoint 並未為一般投影片定義標題佔位符。一般投影片請使用頁腳、日期/時間與投影片號碼佔位符。標題佔位符僅在註記頁面與講義上可用。

**如果頁腳、日期/時間或投影片號碼佔位符未顯示該怎麼辦？**

請使用相對應的標題/頁腳管理器檢查其可見性，並在需要時啟用。例如，[`IsFooterVisible`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) 會回報頁腳佔位符是否存在，而 [`SetFooterVisibility`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) 則變更其可見性。

**如何讓投影片編號從非 1 的值開始？**

設定簡報的 [`FirstSlideNumber`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/firstslidenumber/) 屬性。投影片編號佔位符便會使用更新後的編號序列。

**將簡報匯出為 PDF、圖像或 HTML 時，標題與頁腳會發生什麼情況？**

可見的標題與頁腳元素會與簡報內容一同在輸出格式中呈現。其外觀取決於匯出的頁面類型以及相對應的佔位符可見性設定。
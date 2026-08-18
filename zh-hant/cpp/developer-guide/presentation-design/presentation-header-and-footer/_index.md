---
title: 管理 C++ 簡報的頁首與頁尾
linktitle: 頁首與頁尾
type: docs
weight: 140
url: /zh-hant/cpp/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁尾
- 頁尾文字
- 設定頁首
- 設定頁尾
- 講義
- 備註
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 管理投影片、備註頁面與講義上的頁尾、日期時間、投影片編號與頁首佔位符。"
---
## **概觀**

PowerPoint 會根據頁面類型使用不同的頁首與頁尾佔位符。Aspose.Slides for C++ 讓您能透過頁首/頁尾管理介面控制這些佔位符的文字與可見性。

可用的佔位符取決於範圍：

| 範圍 | 頁首 | 頁尾 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 一般投影片 | 否 | 是 | 是 | 是 |
| 備註母片 | 是 | 是 | 是 | 是 |
| 備註投影片 | 是 | 是 | 是 | 是 |
| 講義母片 | 是 | 是 | 是 | 是 |

一般的簡報投影片沒有頁首佔位符。頁首僅在備註頁面與講義上可用。對於一般投影片，請改用頁尾、日期/時間與投影片編號佔位符。

變更的範圍取決於您使用的管理器。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islideheaderfootermanager/) 介面控制單一一般投影片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotesslideheaderfootermanager/) 介面控制單一備註投影片。母片與版面配置管理器亦能將設定傳播至相依的投影片，而 [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) 介面則控制講義母片。

## **在一般投影片上設定頁尾、日期/時間與投影片編號**

對於一般投影片，基本工作流程是存取每張投影片的頁首/頁尾管理器、設定頁尾與日期/時間文字、啟用所需的佔位符，並儲存簡報。投影片編號由簡報自動產生，因此您只需控制其可見性。

使用 [`SetFooterText`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) 與 [`SetDateTimeText`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) 設定文字，並使用 [`SetFooterVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), 與 [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) 來顯示相對應的佔位符。

以下的端對端範例會將相同的頁尾、日期/時間文字與投影片編號可見性套用於所有一般投影片：

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

如果您只需要更新單一投影片，請直接透過 [`Presentation::get_Slide`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_slide/) 存取該投影片，而不是遍歷整個投影片集合。

## **在備註母片上設定頁首與頁尾**

備註母片定義備註頁面的共用格式與佔位符行為。當您只想變更備註母片本身時，請使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/) 介面。

以下範例在備註母片上設定頁首、頁尾與日期/時間文字，並使該母片上所有支援的佔位符皆可見：

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

[`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) 方法會在簡報不含備註母片時返回 `nullptr`。

## **將備註母片設定套用至子備註投影片**

備註母片可以將頁首與頁尾設定套用於自身以及所有相依的備註投影片。當需在備註層級中套用相同設定時，請使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/) 上的專屬傳播方法。

例如，[`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) 與 [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) 可更新備註母片的頁首以及所有子頁首。相同的方式亦提供給頁尾、日期/時間與投影片編號。

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

上述使用的傳播方法包括 [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), 與 [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)。

## **在單一備註投影片上設定頁首與頁尾**

備註投影片屬於特定的一般投影片。當您只想自訂該備註頁面時，請使用其 [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotesslideheaderfootermanager/) 介面。

[`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotesslidemanager/addnotesslide/) 方法會返回目前投影片的備註投影片，若尚未存在則會建立一個。以下範例設定與第一張簡報投影片相關聯的備註頁面：

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

如果您先從備註母片傳播設定，然後再變更單一備註投影片，後續的逐投影片設定即可讓您獨立自訂該備註頁面。

## **在講義母片上設定頁首與頁尾**

講義頁面使用講義母片來放置其頁首、頁尾、日期/時間與頁碼佔位符。與備註頁面不同，講義的設定是透過講義母片管理，而不是各別的講義投影片。

使用 [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) 取得講義母片。若不存在，請呼叫 [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 以建立預設的講義母片。

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **了解範圍與繼承**

選擇與您要變更的範圍相符的頁首/頁尾管理器：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islideheaderfootermanager/) 變更單一一般投影片的頁尾、日期/時間與投影片編號設定。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslideheaderfootermanager/) 控制版面投影片，並可將支援的設定傳播至相依投影片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslideheaderfootermanager/) 控制一般投影片母片，並可將支援的設定傳播至相依投影片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslideheaderfootermanager/) 控制備註母片，並可將設定傳播至所有相依的備註投影片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotesslideheaderfootermanager/) 變更單一備註投影片，且支援頁首佔位符，除了頁尾、日期/時間與投影片編號外。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) 變更講義母片，並支援全部四種佔位符類型。

當相同設定應套用於整個層級時，請使用母片或版面配置的傳播。當您需要針對單一頁面設定局部設定時，請使用個別投影片或備註投影片管理器。

## **常見問答**

**我可以在一般投影片加入頁首嗎？**

不能。PowerPoint 並未為一般投影片定義頁首佔位符。在一般投影片上，請使用頁尾、日期/時間與投影片編號佔位符。頁首佔位符僅在備註頁面與講義上可用。

**如果頁尾、日期/時間或投影片編號佔位符未顯示，該怎麼辦？**

使用相對應的頁首/頁尾管理器檢查其可見性，並在需要時啟用。例如，[`get_IsFooterVisible`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) 會回報頁尾佔位符是否存在，而 [`SetFooterVisibility`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) 則可變更其可見性。

**我要如何讓投影片編號從非 1 的值開始？**

使用 [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/set_firstslidenumber/) 設定第一張投影片的編號。之後投影片編號佔位符會使用更新後的編號序列。

**將簡報匯出為 PDF、影像或 HTML 時，頁首與頁尾會如何處理？**

可見的頁首與頁尾會隨同簡報內容一起在輸出格式中呈現。它們的外觀取決於被匯出的頁面類型以及相對應的佔位符可見性設定。
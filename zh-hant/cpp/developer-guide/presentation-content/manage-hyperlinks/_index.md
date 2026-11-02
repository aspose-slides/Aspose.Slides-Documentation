---
title: 管理 C++ 簡報中的超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/cpp/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 影像超連結
- 影片超連結
- 可變更超連結
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 並結合 C++ 範例，於 PowerPoint 與 OpenDocument 簡報中新增、格式化、更新與移除超連結。"
---
## **簡介**

超連結可將簡報內容連結至網站或簡報內的其他位置。在 PowerPoint 中，超連結通常有兩個用途：

* 由文字、圖形或多媒體框架開啟網站。
* 由目錄等切換至另一張投影片。

Aspose.Slides for C++ 讓您能新增這些連結、控制其外觀與音效、更新設定，並移除連結。以下範例示範如何在單一元素上操作超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}
您也可以使用[免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/editor)編輯簡報。
{{% /alert %}} 

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、圖形或多媒體框架。指派超連結的元素決定可點擊區域：文字部份僅讓所選文字可點擊，圖形或框架則讓整個投影片物件可點擊。

若簡報內含相對路徑超連結，請參考[管理超連結基底](/slides/zh-hant/cpp/presentation-properties/#manage-the-hyperlink-base)以讀取、變更或清除文件層級基底。

### **新增 URL 超連結至文字**

若要將文字連結至網站，請建立[Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/)，並使用文字部份的[set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/)方法指派，如下所示。只有該文字部份會變成可點擊。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **新增 URL 超連結至圖形與媒體框架**

若要使圖形或框架可點擊，請使用其[set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/)方法。超連結屬於該物件本身，而非其內部文字部份。

相同方式同樣適用於圖片、音訊與視訊框架：將超連結指派給框架，並使用[set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/)在需要時加入提示文字。

以下範例使矩形可點擊：

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **使用超連結建立目錄**

內部超連結可讓讀者從目錄跳至特定投影片。以下範例使用[SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)，將第一張投影片上的「Page 2」文字連結至第二張投影片。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **格式化超連結**

### **顏色**

[IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) 的[set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/)方法決定超連結是使用簡報的超連結顏色，或是文字部份的格式。若要套用自訂文字顏色，請選擇[HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) 並設定該部份的填色。本功能於 PowerPoint 2019 之後引入；較舊版本不會套用此設定。

以下範例於同一張投影片加入兩個文字超連結。第一個使用紅色文字填色，第二個則保留預設超連結顏色。

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **音效**

超連結在被觸發時可以播放音效，或是停止已播放的音效。使用以下方法設定這些行為：

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) 指定與超連結相關的音訊。
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) 控制點擊超連結時是否停止先前的音效。

#### **新增超連結音效**

以下範例載入 `sampleaudio.wav` 並將其與第一張投影片上的按鈕關聯。點擊按鈕會播放音效並導向下一張投影片。該投影片上的第二個圖形在點擊時會停止先前的音效，且不執行導向動作。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **擷取超連結音效**

以下範例開啟前述建立的簡報，並透過[get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) 與[get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) 讀取第一個圖形的超連結音訊至記憶體。

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **提示文字與互動設定**

指派超連結至文字或圖形後，您可以透過以下方法更新[IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) 的設定：

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) 設定觀眾可顯示的提示文字。
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) 在適用時指定父 HTML frameset 中的目標框架。
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) 控制啟用連結時是否將目的地加入已檢視超連結清單。
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) 控制點擊時是否以醒目方式呈現超連結。

## **從簡報中移除超連結**

使用[GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 收集包括文字部份連結在內的超連結容器，之後再進行變更。以下範例同時移除第一張投影片的兩種啟動方式。若僅想移除單一類型，只呼叫[RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)或[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)；移除點擊動作不會同時移除滑鼠移過動作。

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

若需無條件移除，[RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 會在選取範圍內一次移除兩種啟動方式。若要有條件清理且同時處理母片、版面配置與備註，請參考[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

## **建立完整的超連結清單**

在分發簡報前，請盤點其互動動作與網路連結。[GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 會回傳[IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/) 物件，而非單純的 URL 字串。請同時檢查每個容器的[get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) 與[get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/)。它們是獨立的：同一容器可同時包含兩種動作，因此完整報告需要每個容器最多兩列。

僅檢查圖形層級的超連結可能會遺漏附加於文字部份的連結。請改為查詢適當的範圍，並保留回傳的容器，以便日後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) 介面可由[IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/)、[IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) 與[ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) 取得。每個範圍支援相同的查詢：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) 回傳具有點擊動作的容器。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) 回傳具有滑鼠移過動作的容器。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 回傳具有任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，內容包含外部點擊連結、檔案滑鼠移過連結、內部投影片導覽、文字滑鼠移過連結以及巨集動作。此範例不會執行任何動作。三種查詢在每個範圍皆可使用；回傳的計數代表容器數量，而非動作總數。文字框範圍會排除其所屬圖形本身的連結。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

在此範例中，簡報與投影片查詢各回傳三個點擊容器、兩個滑鼠移過容器，以及三個任一動作的容器。文字框查詢則在每個類別中各回傳一個容器。

### **分類動作與目的地**

使用[IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) 取得動作類型後，再判斷其目的地。[HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) 的值涵蓋超出網頁導覽的情況：

| 值 | 稽核說明 |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 與其協議。 |
| `JumpSpecificSlide` | 內部導覽至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片秀導覽，於放映情境下解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的秀或啟動自訂秀。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或其他簡報；需與網頁 URL 分開審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導覽動作，或是未辨識的動作，需要進一步審查。 |

從[get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) 取得外部目的地，從[get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/) 取得具體的內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 不代表容器沒有動作。若[get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) 與正規化後的 URL 不同，請保留原始值；若有[get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) 也請一併記錄。

### **報告、清理與驗證超連結**

以下 C++ 範例讀取已建立的簡報（使用先前產生的檔案），寫入 `hyperlink-audit.json`、套用政策、儲存為 `hyperlink-sanitized.pptx`，再重新開啟以再次檢查兩種啟動方式。它會在變更前收集容器，並透過指標身分避免重複處理同一容器。簡報查詢會遍歷普通投影片；若要整個套件的清點，範例亦會明確查詢母片、版面配置、備註，以及備註與講義母片（若存在）。

報告會記錄以 1 為基礎的投影片索引與[get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/)（若可取得）。[ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) 提供支援容器的所屬投影片。母片、版面配置與備註沒有普通投影片索引，會以其範圍辨識。圖形容器與文字部份格式容器分別標記；其他容器則保留其執行時型別名稱。每個容器會取得報告本地 ID，以便關聯其兩個動作。

此限制性政策僅允許絕對的 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片秀動作、未知動作以及其他 URL 協議。這些拒絕屬於政策決策，而非 Aspose.Slides 安全性的結論。HTTPS 本身不代表信任：請加入主機白名單與其他檢查以符合您的應用。原始與正規化的外部 URL 皆會檢查。範例僅稽核中繼資料，不會跟隨連結或執行動作。

若要修正，容器的[get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) 支援[SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 與[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)。此處會將被禁止的外部點擊連結取代為固定的 HTTPS 登陸頁面；其他被禁止的點擊與滑鼠移過動作則分別移除。將 `replaceExternalClicks` 設為 `false` 可直接移除所有政策違規項目。請於部署前先決定應用自有的取代頁面。

報告的匯出標記採用保守的 PDF 審查政策：將滑鼠移過動作以及除外部連結或特定投影片跳轉之外的任何動作標記為可能不支援。此為審查提示，非功能測試或保證未標記的連結在匯出後一定能保留。支援的[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)與[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/) 匯出可能保留超連結，取決於動作、匯出選項與檢視器。光柵化的[圖像](/slides/zh-hant/cpp/convert-powerpoint-to-png/)與[影片](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 則無法保留互動式超連結；在針對這些輸出進行稽核時請將所有動作標記。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

使用先前建立的輸入，報告會包含五筆動作列。檔案滑鼠移過連結與巨集點擊會被移除，而 HTTPS 連結與內部投影片導覽則保留。驗證階段會列印零筆違規動作。若輸入包含被禁止的外部點擊 URL，亦會走取代分支。容器若同時具有允許的點擊與被禁止的滑鼠移過，會保留點擊動作。

此選擇性清理不同於[RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)，後者會在選取範圍內不論政策如何都移除兩種啟動方式。此處的驗證僅檢查超連結動作，不會移除嵌入的 VBA 專案、OLE 物件或其他主動內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **FAQ**

**如何將超連結指向章節或其第一張投影片？**

PowerPoint 中的章節會將投影片分組，但內部超連結只能指向單一投影片。若要導向章節，請將連結指向該章節的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上都有效嗎？**

可以。母片與版面配置元素支援超連結。使用這些元素的連結在投影片秀期間，會在套用該母片或版面的所有投影片上可用。

**匯出為 PDF、HTML、圖像或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能會保留超連結；光柵圖像與影片則不會。請參考[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)中的匯出考量。
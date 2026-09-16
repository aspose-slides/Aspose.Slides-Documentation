---
title: 在 .NET 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/net/manage-hyperlinks/
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
- 圖像超連結
- 影片超連結
- 可變更超連結
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 C# 範例，透過 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中新增、格式化、更新與移除超連結。"
---
## **簡介**

超連結將簡報內容連接到網站或簡報內的某個位置。在 PowerPoint 中，超連結通常有兩個用途：

* 從文字、圖案或媒體框架開啟網站。
* 導覽至另一張投影片，例如從目錄。

Aspose.Slides for .NET 讓您可以新增這些連結、控制其外觀與聲音、更新其屬性並將其移除。以下範例說明如何在個別元素上使用超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}
您也可以使用 [免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor) 編輯簡報。
{{% /alert %}} 

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、圖案或媒體框架。指派超連結的元素決定可點擊的範圍：文字區段會連結所選文字，而圖案或框架則會連結整個投影片物件。

### **新增 URL 超連結至文字**

若要將文字連結至網站，請將 [Hyperlink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/hyperlink/) 指派給文字區段的 [HyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portionformat/hyperlinkclick/) 屬性，如下所示。僅該文字區段會變成可點擊。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **新增 URL 超連結至圖案和媒體框架**

若要使圖案或框架可點擊，請設定其 [HyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/hyperlinkclick/) 屬性。超連結屬於該物件本身，而非其中的文字區段。

相同的做法適用於圖片、音訊和影片框架：將超連結指派給框架，必要時設定連結的 [Tooltip](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/tooltip/)。

以下範例使矩形可點擊：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **使用超連結建立目錄**

內部超連結讓讀者可從目錄跳至特定投影片。以下範例使用 [SetInternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) 將第一張投影片上的「Page 2」文字連結至第二張投影片。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **格式化超連結**

### **顏色**

[IHyperlink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/) 的 [ColorSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/colorsource/) 屬性決定超連結是使用簡報的超連結顏色還是文字區段的格式。若要套用自訂文字顏色，請選取 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/hyperlinkcolorsource/) 並設定區段的填滿顏色。此功能於 PowerPoint 2019 引入；舊版不會套用此設定。

以下範例在同一張投影片上新增兩個文字超連結。第一個使用紅色文字填滿，第二個保留預設的超連結顏色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **聲音**

超連結在被觸發時可以播放聲音，或停止已在播放的聲音。使用以下屬性來設定這些行為：

- [IHyperlink.Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/sound/) 指定與超連結相關聯的音訊。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/stopsoundonclick/) 控制在觸發超連結時是否停止先前的聲音。

#### **新增超連結聲音**

以下範例載入 `sampleaudio.wav` 並將其與第一張投影片上的按鈕關聯。點擊按鈕會播放聲音並導覽至下一張投影片。該投影片上的第二個圖案在點擊時會停止先前的聲音，且不執行導覽動作。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **擷取超連結聲音**

以下範例開啟上述建立的簡報，並透過 [Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/sound/) 與 [BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudio/binarydata/) 讀取第一個圖案的超連結音訊至記憶體。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **提示文字與互動設定**

在將超連結指派給文字或圖案後，您可以更新以下 [IHyperlink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/) 屬性：

- [Tooltip](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/tooltip/) 設定觀者可顯示為連結提示的文字。
- [TargetFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/targetframe/) 在適用時指定父 HTML frameset 中的目標框架。
- [History](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/history/) 控制啟動連結時是否將其目的地加入已檢視超連結清單。
- [HighlightClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/highlightclick/) 控制點擊時是否突出顯示超連結。

## **從簡報中移除超連結**

在變更之前，使用 [GetAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 取得包括文字區段連結在內的超連結容器。以下範例從第一張投影片中移除兩種觸發類型。若僅移除單一類型，請僅呼叫 [RemoveHyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 或 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)；移除點擊動作不會移除其滑鼠懸停對應項目。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

若需無條件移除，可使用 [RemoveAllHyperlinks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 在一次呼叫中移除所選範圍內的兩種觸發類型。若需選擇性清理並涵蓋母片、版面配置與備註，請參閱 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)。

## **建立完整的超連結清單**

在發佈簡報之前，請對其互動動作與網路連結進行清點。[GetAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 會回傳 [IHyperlinkContainer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkcontainer/) 物件，而非純粹的 URL 字串列表。請檢查每個容器的 [HyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) 與 [HyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/)。兩者相互獨立：同一容器可同時提供兩種動作，因此完整報告可能需要每個容器最多兩列。

僅掃描圖案層級的超連結可能會遺漏附加於文字區段的連結。請改為查詢適當的範圍，並保留返回的容器，以便稍後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[IHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/) 介面可透過 [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/hyperlinkqueries/) 與 [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/hyperlinkqueries/) 取得。每個範圍支援相同的查詢：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) 回傳具點擊動作的容器。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) 回傳具滑鼠懸停動作的容器。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 回傳具任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，其中包含外部點擊連結、檔案滑鼠懸停連結、內部投影片導覽、文字滑鼠懸停連結與巨集動作。這些動作皆不會被執行。相同的三個查詢在每個範圍皆適用；計數指的是容器數量，而非動作總數。文字框範圍會排除其所屬圖案本身的連結。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

在此範例中，簡報與投影片查詢各報告三個點擊容器、兩個滑鼠懸停容器，以及三個具任一動作的容器。文字框查詢則在每個類別各報告一個容器。

### **分類動作與目的地**

使用 [IHyperlink.ActionType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/actiontype/) 先解讀動作，再解讀其目的地。[HyperlinkActionType] 的值涵蓋不僅僅是網頁導覽：

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 與其協定。 |
| `JumpSpecificSlide` | 內部導覽至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導覽，在投影片放映模式下解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的放映或啟動自訂放映。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或另一份簡報；與網頁 URL 分開審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導覽動作，或未辨識的動作，需要審查。 |

從 [ExternalUrl](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/externalurl/) 讀取外部目的地，從 [TargetSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/targetslide/) 讀取特定的內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 並不代表容器沒有動作。當 [ExternalUrlOriginal](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/externalurloriginal/) 與正規化後的 URL 不同時，請保留它，且若有提供則包含 [Tooltip](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/tooltip/)。

### **報告、清理與驗證超連結**

以下 .NET 6+ 範例會讀取既有的簡報（使用上述建立的檔案），寫入 `hyperlink-audit.json`，套用政策，儲存為 `hyperlink-sanitized.pptx`，並重新開啟以再次檢查兩種觸發類型。它在變更前收集容器，並使用參考相等性避免重複處理同一容器。簡報查詢涵蓋普通投影片；若要進行整個套件的清點，亦會明確查詢母片、版面配置、備註，以及存在時的備註與講義母片。

報告會記錄以 1 為起點的投影片索引與（若有）[SlideId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/slideid/)。[ISlideComponent.Slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecomponent/slide/) 為支援的容器提供所屬投影片。母片、版面配置與備註沒有普通投影片索引，以其範圍識別。圖案容器與文字區段格式容器會分別標記；其他容器類型保留其執行時類型名稱。每個容器會取得報告本地 ID，以便關聯其兩個動作。

此刻意嚴格的應用政策僅允許絕對的 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作以及其他 URL 協定。這些拒絕屬於政策決策，而非 Aspose.Slides 安全性的判斷。僅有 HTTPS 並不保證信任：請為您的應用程式加入主機白名單與其他檢查。會檢查原始與正規化後的外部 URL。此範例僅稽核中繼資料，未跟隨連結或執行動作。

為了修正，容器的 [HyperlinkManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) 支援 [SetExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 與 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)。此處，受限的外部點擊連結會被固定的 HTTPS 登陸頁面取代；其他受限的點擊及受限的滑鼠懸停動作則分別移除。將 `replaceExternalClicks` 設為 `false` 即可改為移除所有政策違規。請於部署前選擇由應用程式提供的取代頁面。

報告的匯出標記使用保守的 PDF 檢查政策：將滑鼠懸停動作以及除外部連結或特定投影片跳轉之外的所有項目標記為可能不支援。這只是一項檢查提示，並非功能測試或保證未標記的連結在匯出時仍能存活。支援的 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/net/convert-powerpoint-to-html/) 匯出可能會保留超連結，取決於動作、匯出選項與檢視器。點陣 [images](/slides/zh-hant/net/convert-powerpoint-to-png/) 與 [video](/slides/zh-hant/net/convert-powerpoint-to-video/) 無法保留互動式超連結；在審核這些輸出時請將每個動作都標記。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

使用上述建立的輸入，報告包含五筆動作列。檔案滑鼠懸停連結與巨集點擊被移除，而 HTTPS 連結與內部投影片導覽則保留。驗證結果顯示零項違規動作。若輸入包含受限的外部點擊 URL，亦會執行取代分支。具允許點擊且受限滑鼠懸停的容器會保留其點擊動作。

此選擇性清理與 [RemoveAllHyperlinks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 不同，後者會在所選範圍內無條件移除兩種觸發類型。此處的驗證僅檢查超連結動作；不會移除內嵌的 VBA 專案、OLE 物件或其他活躍內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何將連結指向區段或其第一張投影片？**

PowerPoint 中的區段用於將投影片分組，但內部超連結會鎖定單一投影片。若要導覽至區段，請將連結指向該區段的第一張投影片。

**我可以將超連結附加在母片元素上，使其在所有投影片上都有效嗎？**

可以。母片與版面配置元素支援超連結。這些元素上的連結會在投影片放映時於使用相應母片或版面配置的投影片上生效。

**匯出為 PDF、HTML、影像或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能會保留超連結；點陣影像與影片則無法保留。請參閱 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) 中的匯出考量。
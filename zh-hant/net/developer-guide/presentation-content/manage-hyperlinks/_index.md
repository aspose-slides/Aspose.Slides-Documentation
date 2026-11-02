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
- 影像超連結
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

超連結將簡報內容連結到網站或簡報內的某個位置。在 PowerPoint 中，超連結通常有兩個用途：

* 從文字、形狀或媒體框架開啟網站。
* 從目錄等導覽至其他投影片。

Aspose.Slides for .NET 讓您可以新增這些連結、控制其外觀與音效、更新屬性，並將其移除。下列範例說明如何在個別元素上操作超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}
您也可以使用[免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/editor)編輯簡報。
{{% /alert %}} 

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、形狀或媒體框架。指派超連結的元素決定可點擊的區域：文字片段會連結所選文字，而形狀或框架則連結整個投影片物件。

針對包含相對超連結的簡報，請參閱[管理超連結基礎](/slides/zh-hant/net/presentation-properties/#manage-the-hyperlink-base)以讀取、變更或清除文件層級的基礎。

### **將 URL 超連結新增至文字**

如需將文字連結至網站，請將[Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/)指派給文字片段的[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/)屬性，如下所示。僅該文字片段會變成可點擊。

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

### **將 URL 超連結新增至形狀和媒體框架**

要讓形狀或框架可點擊，請設定其[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/)屬性。超連結屬於該物件本身，而非其中的文字片段。

相同的方法也適用於圖片、音訊與影片框架：將超連結指派給框架，必要時設定連結的[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)。

以下範例將矩形設定為可點擊：

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

內部超連結讓讀者可從目錄跳轉至特定投影片。以下範例使用[SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)將第一張投影片上的「Page 2」文字連結至第二張投影片。

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

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)的[ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/)屬性決定超連結是使用簡報的超連結色彩，還是使用文字片段的格式。若要套用自訂文字顏色，請選取[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/)並設定該片段的填色。此功能於 PowerPoint 2019 之後引入；較舊版本不會套用此設定。

以下範例在同一張投影片上加入兩個文字超連結。第一個使用紅色文字填色，第二個保留預設超連結色彩。

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
### **音效**

超連結可在啟動時播放音效，或停止已在播放的音效。使用下列屬性來設定這些行為：

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) 指定與超連結相關聯的音訊。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) 控制啟動超連結時是否停止先前的音效。

#### **新增超連結音效**

以下範例載入`sampleaudio.wav`，並將其與第一張投影片上的按鈕關聯。點擊按鈕會播放音效並跳至下一張投影片。該投影片上的第二個形狀在點擊時會停止先前的音效，且不執行導覽動作。

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

#### **擷取超連結音效**

以下範例開啟先前建立的簡報，並透過[Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)與[BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/)將第一個形狀的超連結音訊讀取至記憶體。

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

### **工具提示與互動設定**

指派超連結至文字或形狀後，您可以更新以下[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)屬性：

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) 設定使用者在滑鼠懸停時顯示的提示文字。
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) 指定在父 HTML frameset 中的目標框架（如適用）。
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) 控制啟動連結時是否將其目的地加入已檢視超連結清單。
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) 控制點擊時是否將超連結以高亮方式呈現。

## **從簡報中移除超連結**

使用[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)可在變更前收集超連結容器，包括文字片段連結。以下範例移除第一張投影片上兩種啟動類型。若只想移除其中一種，僅呼叫[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)或[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)；移除點擊動作不會同時移除滑鼠懸停對應的動作。

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

若需無條件移除，[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)會在一次呼叫中移除所選範圍內的兩種啟動類型。若要針對母片、版面配置與備註進行選擇性清理，請參閱[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

## **建立完整的超連結清單**

在發佈簡報前，請先清點其互動動作與網路連結。[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)會回傳[IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)物件，而非單純的 URL 字串清單。請同時檢查每個容器的[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/)與[HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/)。它們是獨立的：相同容器可以同時暴露兩種動作，因此完整報表可能需要每個容器列出兩列。

僅掃描形狀層級的超連結會遺漏附加在文字片段上的連結。請改為查詢適當的範圍，並保留回傳的容器，以便之後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/)介面可透過[IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/)與[ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/)取得。每個範圍支援相同的查詢：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) 回傳具有點擊動作的容器。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) 回傳具有滑鼠懸停動作的容器。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 回傳具有任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，內容包含外部點擊連結、檔案滑鼠懸停連結、內部投影片導覽、文字滑鼠懸停連結以及巨集動作。此範例不會執行任何動作。相同的三個查詢在每個範圍皆可使用；計數描述的是容器數量，而非動作總次數。文字框範圍會排除其所屬形狀本身的連結。

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

在此範例中，簡報與投影片查詢各回報三個點擊容器、兩個滑鼠懸停容器與三個任一動作的容器。文字框查詢則在每個類別各回報一個容器。

### **分類動作與目的地**

使用[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) 先解讀動作，再解讀其目的地。[HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) 的值涵蓋了超出網頁導覽的情況：

| 值 | 審核說明 |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 及其協議。 |
| `JumpSpecificSlide` | 內部導覽至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導覽，於放映環境中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的放映或啟動自訂放映。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或另一個簡報；需與網路 URL 分開審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導覽動作，或需審查的未知動作。 |

從[ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) 讀取外部目的地，從[TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) 讀取特定內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 並不代表容器沒有動作。當[ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) 與正規化後的 URL 不同時，請保留前者，並在可用時加入[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)。

### **報告、清理與驗證超連結**

以下 .NET 6+ 範例讀取先前建立的簡報（使用上述產生的檔案），寫入 `hyperlink-audit.json`、套用政策、儲存 `hyperlink-sanitized.pptx`，再重新開啟以再次檢查兩種啟動類型。它在變更前收集容器，並使用參照相等性避免重複處理同一容器。簡報查詢涵蓋普通投影片；若要全套件清點，亦會明確查詢母片、版面配置、備註，以及備註與講義母片（若存在）。

報表會記錄一個基於 1 的投影片索引以及（如有）[SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/)。[ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) 提供支援容器的所屬投影片。母片、版面配置與備註沒有普通投影片索引，會以其範圍作為識別。形狀容器與文字片段格式容器會分別標記；其他容器類型保留其執行階段類型名稱。每個容器取得報表本地 ID，以便其兩個動作可相互對應。

此刻意限制的應用政策僅允許絕對 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作及其他 URL 協議。這些拒絕屬於政策決策，而非 Aspose.Slides 安全性的判斷。僅有 HTTPS 並不代表可信任：請加入主機白名單與其他檢查。原始與正規化的外部 URL 都會被檢查。範例僅稽核中介資料，未跟隨連結或執行動作。

若需修正，容器的[HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/)支援[SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)以及[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)。此處會將被禁止的外部點擊連結取代為固定的 HTTPS 登陸頁面；其他被禁止的點擊與被禁止的滑鼠懸停動作則分別移除。將 `replaceExternalClicks` 設為 `false` 則可直接移除所有政策違規項目。請在部署前選擇應用程式擁有的取代頁面。

報表的匯出旗標採用保守的 PDF 稽核政策：將滑鼠懸停動作以及除外部連結或特定投影片跳轉之外的任何動作標記為可能不受支援。這僅是稽核提示，而非功能測試或未被標記的連結一定能在匯出後存活的保證。支援的[PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)與[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)匯出可能保留超連結，取決於動作、匯出選項與檢視器。光柵化的[images](/slides/zh-hant/net/convert-powerpoint-to-png/)與[video](/slides/zh-hant/net/convert-powerpoint-to-video/)則無法保留互動超連結；在針對這些輸出進行稽核時，請對每個動作加上旗標。

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

使用上述產生的輸入，報表包含五筆動作列。檔案滑鼠懸停連結與巨集點擊被移除，HTTPS 連結與內部投影片導覽則保留。驗證結果列出零筆違規動作。若輸入中包含被禁止的外部點擊 URL，亦會走到取代分支。容器若同時具備允許的點擊與被禁止的滑鼠懸停，則保留其點擊動作。

此選擇性清理與[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 不同，後者會在所選範圍內無條件移除兩種啟動類型。此處的驗證僅檢查超連結動作，不會移除嵌入的 VBA 專案、OLE 物件或其他活躍內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何將連結指向章節或其第一張投影片？**

PowerPoint 中的章節會將投影片分組，但內部超連結只能指向單一投影片。若要導覽至章節，請將連結指向該章節的第一張投影片。

**我可以將超連結附加到母片元素，讓所有投影片皆可使用嗎？**

可以。母片與版面配置的元素支援超連結。這些元素上的連結在投影片放映時，會在使用相應母片或版面配置的投影片上可用。

**匯出為 PDF、HTML、圖像或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能會保留超連結；光柵圖像與影片則無法保留。請參閱[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)中的匯出考量。
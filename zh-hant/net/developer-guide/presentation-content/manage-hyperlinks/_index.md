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
- 圖片超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 於 PowerPoint 與 OpenDocument 簡報中新增、格式化、更新與移除超連結，並提供 C# 範例。"
---
## **簡介**

超連結將簡報內容連結到網站或簡報內的某個位置。在 PowerPoint 中，超連結通常有兩個用途：

* 從文字、圖形或媒體框架開啟網站。
* 從目錄等導覽至其他投影片。

Aspose.Slides for .NET 讓您可以新增這些連結、控制其外觀與聲音、更新其屬性，並將其移除。以下範例說明如何在單一元素上操作超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}

您也可以使用 [免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/editor) 編輯簡報。

{{% /alert %}}

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、圖形或媒體框架。指派超連結的元素決定可點擊的範圍：文字部份只連結所選取的文字，而圖形或框架則連結整個投影片物件。

若簡報包含相對超連結，請參閱 [管理超連結基底](/slides/zh-hant/net/presentation-properties/#manage-the-hyperlink-base) 以讀取、變更或清除文件層級的基底。

### **將 URL 超連結新增至文字**

如需將文字連結至網站，請將 [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) 指派給文字部份的 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) 屬性，如下所示。只有該文字部份會變成可點擊。

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

### **將 URL 超連結新增至圖形與媒體框架**

將 URL 指派給矩形的 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) 屬性，即可使其整個區域可點擊。[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) 會在使用者將滑鼠懸停於矩形上時提供目的地提示。相同屬性亦適用於圖片、音訊與影片框架。

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

內部超連結讓讀者可以從目錄跳至特定投影片。以下範例使用 [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)，將第一投影片上的「第 2 頁」文字連結至第二投影片。

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

您可以變更已連結文字的色彩、在讀者啟動連結時播放或停止聲音，並設定懸停時顯示的工具提示。

### **色彩**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) 的 [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) 屬性決定超連結是使用簡報的超連結色彩，還是文字部份的格式。若要套用自訂文字色彩，請選擇 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) 並設定部份的填充色彩。此功能於 PowerPoint 2019 之後加入；較舊版本不會套用此設定。

在本例中，將第一個連結的 [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) 設為 `PortionFormat` 後，文字顯示為紅色。第二個連結保留簡報的超連結色彩。

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

超連結可以在被啟動時播放聲音，或停止已在播放的聲音。使用下列屬性來設定這些行為：

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) 指定與超連結相關的音訊。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) 控制在點擊超連結時是否停止先前的聲音。

#### **新增超連結聲音**

第一投影片上的按鈕使用 [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) 於讀者點擊前進時播放 WAV 檔音訊。第二投影片上的另一個按鈕則使用 [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) 停止播放，並讓讀者停留在該投影片。

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

以下範例開啟先前建立的簡報，並透過 [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) 與 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) 讀取第一個圖形的超連結音訊至記憶體。

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

在將超連結指派給文字或圖形後，您可以更新以下 [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) 屬性：

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) 設定觀眾可顯示的提示文字。
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) 指定在父 HTML frameset 中的目標框架（如適用）。
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) 控制啟動連結時是否將目的地加入已檢視超連結清單。
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) 控制點擊時是否突顯超連結。

## **從簡報中移除超連結**

使用 [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 在變更前收集包含文字部份連結的超連結容器。下例移除第一投影片的兩種啟動類型。若只想移除單一類型，僅呼叫 [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 或 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)；移除點擊動作不會同時移除滑鼠懸停對應的動作。

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

若要無條件移除，[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 會在所選範圍內一次呼叫即移除兩種啟動類型。若需有選擇性地清理且涵蓋母版、版面配置與備註，請參閱 [報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

### **在取代 SmartArt 文字前清除超連結**

當您取代現有 SmartArt 節點中的段落時，先前的超連結可能仍然有效。透過 [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/) 取得段落，然後在清除其文字部份之前，於節點形狀的文字框上呼叫 [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)（透過 [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/)），即可移除該框架內的所有超連結，包括其他段落中的連結。

範例假設第一投影片的第三個圖形是 SmartArt 圖形，並取代第四個節點的第一段落。該節點的第一個圖形負責顯示此段落。

加入兩個文字部份後，範例使用 [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) 讀取其實際格式。實際的 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) 屬性會回傳第一部份的新超連結，而第二部份則為 `null`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **建立完整的超連結清查清單**

在發佈簡報之前，請清查其互動動作與網路連結。[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 會回傳 [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) 物件，而非單純的 URL 字串清單。檢查每個容器的 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) 與 [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/)。它們是獨立的：同一容器可以同時曝露兩種動作，因此完整報告可能需要每個容器最多兩列。

僅掃描圖形層級的超連結可能遺漏附加於文字部份的連結。請改為查詢適當的範圍，並保留回傳的容器，以便稍後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) 介面可透過 [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) 與 [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) 取得。每個範圍支援相同的查詢：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) 回傳包含點擊動作的容器。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) 回傳包含滑鼠懸停動作的容器。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 回傳包含任一或兩種動作的容器。

此範例將點擊與滑鼠懸停動作指派給圖形與其文字，並為另一個按鈕指派巨集動作。它比較 [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 回傳的容器與各啟動類型的計數。文字框查詢僅計算文字中的連結。外圍圖形的動作會出現在投影片與簡報查詢中。

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

在此範例中，簡報與投影片查詢各回報三個點擊容器、兩個滑鼠懸停容器與三個任一動作的容器。文字框查詢則在每個類別中各回報一個容器。

### **分類動作與目的地**

使用 [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) 先判斷動作類型，再解讀目的地。[HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) 的值涵蓋超出網頁導覽的情況：

| 值 | 稽核時的意義 |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 與其協定。 |
| `JumpSpecificSlide` | 內部導覽至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導覽，在投影片放映情境中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的放映或啟動自訂放映。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或其他簡報；需與網頁 URL 分別審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導覽動作，或未識別的動作，需要進一步檢查。 |

從 [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) 讀取外部目的地，從 [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) 讀取特定內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 不代表容器沒有動作。若 [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) 與正規化後的 URL 不同，請保留前者，並在可用時加入 [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)。

### **報告、清理與驗證超連結**

此 .NET 6+ 範例開啟前述範例建立的簡報，並為每個動作寫入一筆 JSON 記錄。它使用 [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 收集普通投影片、母版、版面配置與備註中的容器（若有備註與講義母版亦會包含）。透過參照相等性計算每個容器一次，套用下列政策後重新開啟已儲存的簡報，以檢查點擊與滑鼠懸停動作。

報告記錄一個基於 1 的投影片索引與可用的 [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/)。[ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) 提供支援容器的所屬投影片。母版、版面配置與備註沒有普通投影片索引，以其範圍辨識。圖形容器與文字部份格式容器分別標示；其他容器類型保留其執行階段型別名稱。每個容器取得報告內部 ID，以便關聯其兩個動作。

此限制性應用政策僅允許絕對 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作與其他 URL 協定。這些拒絕屬於政策決策，而非 Aspose.Slides 安全判斷。僅 HTTPS 並不代表信任：請為您的應用程式加入主機白名單與其他檢查。原始與正規化的外部 URL 皆會檢查。此範例僅審核中繼資料，不會跟隨連結或執行動作。

若需修正，容器的 [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) 支援 [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 與 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)。此處將被禁止的外部點擊連結取代為固定的 HTTPS 登陸頁面；其他被禁止的點擊與滑鼠懸停動作則分別移除。將 `replaceExternalClicks` 設為 `false` 則會移除所有政策違規項目。請在部署前選擇應用程式擁有的取代頁面。

報告的匯出旗標採用保守的 PDF 審查政策：將滑鼠懸停動作以及除外部連結或特定投影片跳轉之外的任何動作標記為可能不受支援。這僅是審查提示，非功能測試或保證未標記的連結在匯出時一定會保留。支援的 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/net/convert-powerpoint-to-html/) 匯出可能會保留超連結，視動作、匯出選項與檢視器而定。光柵化的 [images](/slides/zh-hant/net/convert-powerpoint-to-png/) 與 [video](/slides/zh-hant/net/convert-powerpoint-to-video/) 無法保留互動式超連結；在審核這類輸出時請將每個動作都標記。

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

依上述輸入建立的報告包含五筆動作列。檔案的滑鼠懸停連結與巨集點擊被移除，HTTPS 連結與內部投影片導覽則保留。驗證階段列印零筆違規動作。若輸入包含被禁止的外部點擊 URL，亦會走訪取代分支。容器若同時具備允許的點擊與被禁止的滑鼠懸停，則保留其點擊動作。

此選擇性清理與 [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 不同，後者會無論政策如何，於所選範圍內移除兩種啟動類型。此處的驗證僅檢查超連結動作；不會移除嵌入的 VBA 專案、OLE 物件或其他活性內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **FAQ**

**如何連結到某個區段或其第一張投影片？**

PowerPoint 中的區段會將投影片分組，但內部超連結只能針對單一投影片。若要導覽至區段，請連結至該區段的第一張投影片。

**能否將超連結附加到母版投影片元素，使其在所有投影片上皆有效？**

可以。母版投影片與版面配置元素支援超連結。這些元素上的連結在使用相應母版或版面配置的投影片放映時可用。

**匯出為 PDF、HTML、影像或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能會保留超連結；光柵影像與影片則不會。相關匯出注意事項請參閱 [報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。
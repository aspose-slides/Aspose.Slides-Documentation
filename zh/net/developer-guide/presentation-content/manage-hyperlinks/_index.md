---
title: 在 .NET 中管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/net/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 移除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图像超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 C# 示例，通过 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和移除超链接。"
---
## **Introduction**

超链接将演示文稿内容连接到网站或演示文稿内部的某个位置。在 PowerPoint 中，超链接通常有两种用途：

* 从文本、形状或媒体框打开网站。
* 导航至另一张幻灯片，例如从目录页。

Aspose.Slides for .NET 允许您添加这些链接、控制其外观和声音、更新属性以及将其移除。以下示例演示了如何在单个元素上使用超链接，以及如何在演示文稿、幻灯片或文本框级别访问超链接。

{{% alert color="info" title="Note" %}}

您还可以使用[免费在线 Aspose PowerPoint 编辑器](https://products.aspose.app/slides/editor)编辑演示文稿。

{{% /alert %}} 

## **Add URL Hyperlinks**

您可以将网站 URL 分配给文本、形状或媒体框。您为其分配超链接的元素决定了可点击区域：文本片段链接所选文本，而形状或框则链接幻灯片对象。

对于包含相对超链接的演示文稿，请参阅[管理超链接基准](/slides/zh/net/presentation-properties/#manage-the-hyperlink-base)以读取、更改或清除文档级别的基准。

### **Add URL Hyperlinks to Text**

要将文本链接到网站，请将[Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/)分配给文本片段的[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/)属性，如下所示。只有该文本片段会变为可点击。

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

### **Add URL Hyperlinks to Shapes and Media Frames**

要使形状或框可点击，请设置其[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/)属性。超链接归属于该对象本身，而不是其中的文本片段。

同样的方法适用于图片、音频和视频框：将超链接分配给框，并在需要时设置链接的[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)。

下面的示例创建了一个可点击的矩形：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Use Hyperlinks to Create a Table of Contents**

内部超链接使读者能够从目录跳转到特定幻灯片。下面的示例使用[SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)将第一页上的“Page 2”文本链接到第二页。

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

## **Format Hyperlinks**

### **Color**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) 的[ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/)属性决定超链接使用演示文稿的超链接颜色还是文本片段的格式。要应用自定义文本颜色，请选择[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/)并设置片段的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不支持此设置。

下面的示例向同一张幻灯片添加了两个文本超链接。第一个使用红色文字填充，第二个保持默认的超链接颜色。

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
### **Sound**

超链接可在激活时播放声音或停止已在播放的声音。使用以下属性配置这些行为：

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) 指定与超链接关联的音频。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) 控制激活超链接时是否停止之前的声音。

#### **Add a Hyperlink Sound**

下面的示例加载 `sampleaudio.wav` 并将其关联到第一页的按钮上。单击按钮会播放声音并导航到下一页。该页上的第二个形状在单击时会停止之前的声音，而不执行导航操作。

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

#### **Extract a Hyperlink Sound**

下面的示例打开上述创建的演示文稿，并通过[Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/)和[BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/)将第一个形状的超链接音频读取到内存中。

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

### **Tooltip and Interaction Settings**

在为文本或形状分配超链接后，您可以更新以下[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)属性：

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) 设置查看者可显示的链接提示文本。
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) 在适用时指定父 HTML 框架集中的目标框架。
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) 控制激活链接时是否将其目标添加到已查看超链接列表中。
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) 控制单击时是否突出显示超链接。

## **Remove Hyperlinks from Presentations**

在更改之前，使用[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)收集包括文本片段链接在内的超链接容器。下面的示例从第一页中移除两种激活方式。若仅想移除一种类型，请仅调用[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)或[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)；移除点击操作并不会移除其鼠标悬停对应操作。

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

若要无条件移除，[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 在一次调用中移除所选范围内的两种激活方式。有关选择性清理以及对母版、布局和备注的覆盖，请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。

## **Build a Complete Hyperlink Inventory**

在分发演示文稿之前，先对其交互操作和网络链接进行清点。[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 返回[IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) 对象，而不是 URL 字符串的扁平列表。检查每个容器的[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/)和[HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/)。它们相互独立：同一容器可以同时提供两种操作，因此完整报告每个容器最多需要两行。

仅扫描形状级别的超链接可能会遗漏附加在文本片段上的链接。请改为查询相应范围，并保留返回的容器，以便随后更新或移除其操作。

### **Query Presentation, Slide, and Text-Frame Scopes**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) 接口可通过[IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/)和[ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/)访问。每个范围支持相同的查询：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) 返回具有点击操作的容器。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) 返回具有鼠标悬停操作的容器。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 返回具有任一或两种操作的容器。

下面的示例创建了 `hyperlink-audit-input.pptx`，其中包含外部点击链接、文件鼠标悬停链接、内部幻灯片导航、文本鼠标悬停链接和宏操作。它不会执行任何这些操作。同样的三个查询在每个范围都适用；计数描述的是容器数量，而非操作总数。文本框范围不包括其所在形状的链接。

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

在本例中，演示文稿和幻灯片查询各报告三个点击容器、两个鼠标悬停容器以及三个任一操作的容器。文本框查询在每个类别报告一个容器。

### **Classify Actions and Destinations**

使用[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) 在解释目标之前先解释操作。[HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) 的取值覆盖了除网页导航之外的多种操作：

| 值 | 审计含义 |
| --- | --- |
| `Hyperlink` | 外部超链接；检查 URL 及其协议。 |
| `JumpSpecificSlide` | 内部导航至特定幻灯片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 内置幻灯片放映导航，在放映上下文中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 结束当前放映或启动自定义放映。 |
| `StartMacro` | 执行宏。 |
| `StartProgram` | 启动程序。 |
| `OpenFile`, `OpenPresentation` | 打开文件或另一个演示文稿；需与网页 URL 分别审查。 |
| `StartStopMedia` | 开始或停止媒体播放。 |
| `NoAction`, `Unknown` | 无导航动作，或需要审查的未识别动作。 |

从[ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/)读取外部目标，从[TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/)读取特定内部目标。内部操作和内置命令可能没有外部 URL；空 URL 并不意味着容器没有操作。当[ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/)与规范化 URL 不同时时，请保留它，并在可用时包括[Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/)。

### **Report, Sanitize, and Verify Hyperlinks**

以下 .NET 6+ 示例读取已有演示文稿（使用上面创建的文件），写入 `hyperlink-audit.json`，应用策略，保存 `hyperlink-sanitized.pptx`，并重新打开以再次检查两种激活方式。它在更改之前收集容器，并使用引用相等性避免对同一容器进行两次处理。演示文稿查询覆盖普通幻灯片；若需全包清点，还会显式查询母版、布局、备注以及存在时的备注和讲义母版。

报告记录基于 1 的幻灯片索引和可用时的[SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/)。[ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/)提供受支持容器的所属幻灯片。母版、布局和备注没有普通幻灯片索引，使用其范围进行标识。形状容器和文本片段格式容器单独标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便关联其两个操作。

此项有意限制的应用策略仅允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件操作、其他幻灯片操作、未知操作以及其他 URL 方案。这些拒绝是策略决定，而非 Aspose.Slides 安全结论。仅 HTTPS 并不能建立信任：请为您的应用添加主机白名单及其他检查。原始和规范化的外部 URL 均会被检查。示例仅审计元数据，不会跟随链接或执行操作。

为修复问题，容器的[HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/)支持[SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)和[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)。这里，将被禁止的外部点击链接替换为固定的 HTTPS 着陆页；其他被禁止的点击和被禁止的鼠标悬停操作则分别移除。将 `replaceExternalClicks` 设置为 `false` 可改为移除所有策略违规项。请在部署前选择应用拥有的替换页面。

报告的导出标记采用保守的 PDF 审核策略：将鼠标悬停操作以及除外部链接或特定幻灯片跳转之外的任何操作标记为可能不受支持。这是审核提示，而非功能测试或未标记链接一定能在导出后存活的保证。受支持的[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/net/convert-powerpoint-to-html/)导出可能会保留超链接，具体取决于操作、导出选项和查看器。栅格[图像](/slides/zh/net/convert-powerpoint-to-png/)和[视频](/slides/zh/net/convert-powerpoint-to-video/)无法保留交互式超链接；在对这些输出进行审计时请对每个操作都标记。

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

使用上述创建的输入，报告包含五行操作。文件鼠标悬停链接和宏点击被移除，而 HTTPS 链接和内部幻灯片导航保留。验证结果显示零个违规操作。包含被禁止的外部点击 URL 的输入也会走到替换分支。允许点击且被禁止鼠标悬停的容器保留其点击操作。

此选择性清理不同于[RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)，后者在所选范围内不论策略如何都移除两种激活方式。此处的验证仅检查超链接操作；它不移除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不验证导出的 PDF 或 HTML 文件。

## **FAQ**

**如何链接到章节或其第一张幻灯片？**

PowerPoint 中的章节将幻灯片分组，但内部超链接针对的是单个幻灯片。若要实现对章节的导航，请链接到该章节的第一张幻灯片。

**我能将超链接附加到母版幻灯片元素上，使其在所有幻灯片上都有效吗？**

可以。母版幻灯片和布局元素支持超链接。这些元素上的链接在使用相应母版或布局的幻灯片放映期间可用。

**导出为 PDF、HTML、图像或视频时，超链接会被保留吗？**

受支持的 PDF 和 HTML 导出可能会保留超链接；栅格图像和视频则不会。请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)中的导出注意事项。
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
- 删除超链接
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
description: "使用 Aspose.Slides for .NET 并使用 C# 示例，在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和删除超链接。"
---
## **介绍**

超链接将演示内容连接到网站或演示内部的某个位置。在 PowerPoint 中，超链接通常有两种用途：

* 从文本、形状或媒体框打开网站。
* 从目录等位置跳转到另一张幻灯片。

Aspose.Slides for .NET 允许您添加这些链接、控制其外观和声音、更新属性以及删除链接。下面的示例展示了如何在单个元素上使用超链接，以及如何在演示、幻灯片或文本框级别访问超链接。

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/zh/editor).

{{% /alert %}} 

## **添加 URL 超链接**

您可以将网站 URL 分配给文本、形状或媒体框。分配超链接的元素决定可点击区域：文本部分链接所选文本，形状或框则链接整个幻灯片对象。

### **向文本添加 URL 超链接**

要将文本链接到网站，请将 [Hyperlink](https://reference.aspose.com/slides/zh/net/aspose.slides/hyperlink/) 分配给文本部分的 [HyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/portionformat/hyperlinkclick/) 属性，如下所示。只有该文本部分会变为可点击。

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

### **向形状和媒体框添加 URL 超链接**

要使形状或框可点击，请设置其 [HyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/hyperlinkclick/) 属性。超链接属于对象本身，而不是其中的文本部分。

同样的方法适用于图片、音频和视频框：将超链接分配给框，并在需要时设置链接的 [Tooltip](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/tooltip/)。

下面的示例使一个矩形可点击：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **使用超链接创建目录**

内部超链接让读者可以从目录跳转到特定幻灯片。下面的示例使用 [SetInternalHyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) 将第一张幻灯片上的 “Page 2” 文本链接到第二张幻灯片。

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

## **格式化超链接**

### **颜色**

[IHyperlink](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/) 的 [ColorSource](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/colorsource/) 属性决定超链接是使用演示的超链接颜色还是文本部分的格式。要应用自定义文字颜色，请选择 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/hyperlinkcolorsource/) 并设置该部分的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不适用此设置。

下面的示例在同一张幻灯片上添加了两个文本超链接。第一个使用红色文字填充，第二个保持默认的超链接颜色。

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
### **声音**

激活超链接时可以播放声音，或停止已在播放的声音。使用以下属性来配置这些行为：

- [IHyperlink.Sound](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/sound/) 指定与超链接关联的音频。
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/stopsoundonclick/) 控制激活超链接时是否停止之前的声音。

#### **添加超链接声音**

下面的示例加载 `sampleaudio.wav` 并将其关联到第一张幻灯片上的一个按钮。单击该按钮会播放声音并跳转到下一张幻灯片。该幻灯片上的第二个形状在单击时会停止之前的声音，但不执行跳转操作。

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

#### **提取超链接声音**

下面的示例打开上述创建的演示，并通过 [Sound](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/sound/) 和 [BinaryData](https://reference.aspose.com/slides/zh/net/aspose.slides/iaudio/binarydata/) 将第一个形状的超链接音频读取到内存中。

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

### **提示文本和交互设置**

在为文本或形状分配超链接后，您可以更新以下 [IHyperlink](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/) 属性：

- [Tooltip](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/tooltip/) 设置查看者在悬停时显示的提示文字。
- [TargetFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/targetframe/) 指定在父 HTML frameset 中的目标帧（适用时）。
- [History](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/history/) 控制激活链接后是否将其目的地加入已查看超链接列表。
- [HighlightClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/highlightclick/) 控制点击时是否高亮显示超链接。

## **从演示中删除超链接**

使用 [GetAnyHyperlinks](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 在修改之前收集包括文本片段链接在内的所有超链接容器。下面的示例删除第一张幻灯片上的两种激活方式。若只删除一种类型，只调用 [RemoveHyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 或 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)；删除点击操作不会自动删除其鼠标悬停对应操作。

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

若需无条件删除， [RemoveAllHyperlinks](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) 在一次调用中删除选定范围内的两种激活方式。有关选择性清理以及对母版、版式和备注的覆盖，请参见 [报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。

## **构建完整的超链接清单**

在分发演示之前，请清点其交互动作以及网络链接。 [GetAnyHyperlinks](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 返回的是 [IHyperlinkContainer](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkcontainer/) 对象，而不是平铺的 URL 列表。检查每个容器上的 [HyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) 和 [HyperlinkMouseOver](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/)。它们是独立的：同一容器可以同时暴露两种动作，因此完整的报告需要每个容器最多两行。

仅扫描形状级别的超链接可能会漏掉附加在文本片段上的链接。请改为查询适当的范围，并保留返回的容器，以便后续更新或删除其动作。

### **查询演示、幻灯片和文本框范围**

[IHyperlinkQueries](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/) 接口可通过 [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/hyperlinkqueries/)、[IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/hyperlinkqueries/) 和 [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/hyperlinkqueries/) 访问。每个范围支持相同的查询：

- [GetHyperlinkClicks](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) 返回具有点击动作的容器。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) 返回具有鼠标悬停动作的容器。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) 返回同时或任意一种动作的容器。

下面的示例创建 `hyperlink-audit-input.pptx`，其中包含外部点击链接、文件鼠标悬停链接、内部幻灯片导航、文本鼠标悬停链接以及宏动作。示例本身不执行这些动作。相同的三个查询在每个范围内都可使用；计数描述的是容器数量，而非动作总数。文本框范围不包括其所在形状的链接。

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

在本例中，演示和幻灯片查询各报告三个点击容器、两个鼠标悬停容器以及三个任意动作容器。文本框查询在每个类别中各报告一个容器。

### **对动作和目标进行分类**

使用 [IHyperlink.ActionType](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/actiontype/) 在解释目标之前先解释动作。 [HyperlinkActionType](https://reference.aspose.com/slides/zh/net/aspose.slides/hyperlinkactiontype/) 的取值覆盖了除了网页导航之外的更多场景：

| 值 | 审计含义 |
| --- | --- |
| `Hyperlink` | 外部超链接；检查 URL 及其协议。 |
| `JumpSpecificSlide` | 跳转到特定幻灯片的内部导航。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 幻灯片放映内置导航，在放映上下文中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 结束当前放映或启动自定义放映。 |
| `StartMacro` | 执行宏。 |
| `StartProgram` | 启动程序。 |
| `OpenFile`, `OpenPresentation` | 打开文件或其他演示；需单独与网页 URL 区分审查。 |
| `StartStopMedia` | 开始或停止媒体播放。 |
| `NoAction`, `Unknown` | 无导航动作，或未识别的动作，需要审查。 |

通过 [ExternalUrl](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/externalurl/) 读取外部目标，通过 [TargetSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/targetslide/) 读取具体内部目标。内部动作和内置命令可能没有外部 URL；空 URL 并不表示容器没有动作。当 [ExternalUrlOriginal](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/externalurloriginal/) 与规范化 URL 不同时，请保留原始值，并在可用时包含 [Tooltip](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlink/tooltip/)。

### **报告、清理和验证超链接**

下面的 .NET 6+ 示例读取已有演示（使用上面创建的文件），写入 `hyperlink-audit.json`，应用策略后保存为 `hyperlink-sanitized.pptx`，再次打开以检查两种激活方式。它在修改前收集容器，并使用引用相等性避免对同一容器重复处理。演示查询覆盖普通幻灯片；若需对整个包进行清点，还显式查询母版、版式、备注以及存在的备注和讲义母版。

报告记录基于 1 的幻灯片索引以及可用时的 [SlideId](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/slideid/)。[ISlideComponent.Slide](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecomponent/slide/) 为受支持的容器提供所属幻灯片。母版、版式和备注没有普通幻灯片索引，以其范围标识。形状容器和文本片段格式容器单独标记；其他容器类型保留运行时类型名称。每个容器获得报告本地 ID，以便关联其两种动作。

此限制性策略仅允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件动作、其他放映动作、未知动作以及除 HTTPS 之外的 URL 方案。这些拒绝属于策略决定，而非 Aspose.Slides 安全判断。仅 HTTPS 并不等同于可信：请为您的应用添加主机白名单和其他检查。原始和规范化的外部 URL 均会被检查。示例在不跟随链接或执行动作的情况下审计元数据。

若需修复，容器的 [HyperlinkManager](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) 支持 [SetExternalHyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 和 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)。示例中，将被禁止的外部点击链接替换为固定的 HTTPS 登录页面；其它被禁止的点击和鼠标悬停动作则独立删除。将 `replaceExternalClicks` 设置为 `false` 可直接删除所有策略违规项。请在部署前准备好应用拥有的替代页面。

报告的导出标记采用保守的 PDF 审核策略：将鼠标悬停动作以及除外部链接或特定幻灯片跳转之外的任何动作标记为可能不受支持。这是审查提示，而非功能测试或对未标记链接的生存保证。受支持的 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh/net/convert-powerpoint-to-html/) 导出可能保留超链接，具体取决于动作、导出选项和观看器。光栅化的 [images](/slides/zh/net/convert-powerpoint-to-png/) 与 [video](/slides/zh/net/convert-powerpoint-to-video/) 则无法保留交互式超链接；在审计这些输出时请对每个动作进行标记。

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

使用上述生成的输入文件，报告包含五行动作。文件鼠标悬停链接和宏点击被移除，HTTPS 链接及内部幻灯片导航保留。验证阶段打印出零个违规动作。包含违规外部点击 URL 的输入还演示了替换分支。一个允许点击且禁止鼠标悬停的容器保留其点击动作。

此选择性清理不同于 [RemoveAllHyperlinks](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)，后者会在选定范围内不考虑策略直接删除两种激活方式。这里的验证仅检查超链接动作本身；它不删除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不验证导出的 PDF 或 HTML 文件。

## **FAQ**

**如何链接到某个章节或其第一张幻灯片？**

PowerPoint 中的章节用于分组幻灯片，但内部超链接只能定位到单个幻灯片。要实现跳转到章节，需链接到该章节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素上，使其在所有幻灯片上生效吗？**

可以。母版幻灯片和版式元素支持超链接。这些元素上的链接在使用相应母版或版式的幻灯片放映期间可用。

**导出为 PDF、HTML、图像或视频时超链接会被保留吗？**

受支持的 PDF 和 HTML 导出可能保留超链接；光栅图像和视频则无法保留。请参阅 [报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks) 中的导出注意事项。
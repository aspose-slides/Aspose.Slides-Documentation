---
title: Manage Presentation Hyperlinks in .NET
linktitle: Manage Hyperlinks
type: docs
weight: 20
url: /net/manage-hyperlinks/
keywords:
- add URL
- add hyperlink
- create hyperlink
- format hyperlink
- remove hyperlink
- update hyperlink
- text hyperlink
- slide hyperlink
- shape hyperlink
- image hyperlink
- video hyperlink
- mutable hyperlink
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add, format, update, and remove hyperlinks in PowerPoint and OpenDocument presentations with Aspose.Slides for .NET, using C# examples."
---

## **Introduction**

A hyperlink connects presentation content to a website or a location within the presentation. In PowerPoint, hyperlinks commonly serve two purposes:

* Open a website from text, a shape, or a media frame.
* Navigate to another slide, for example, from a table of contents.

Aspose.Slides for .NET lets you add these links, control their appearance and sound, update their properties, and remove them. The examples below show how to work with hyperlinks on individual elements and how to access hyperlinks at the presentation, slide, or text-frame level.

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Add URL Hyperlinks**

You can assign a website URL to text, a shape, or a media frame. The element to which you assign the hyperlink determines the clickable area: a text portion links the selected text, while a shape or frame links the slide object.

### **Add URL Hyperlinks to Text**

To link text to a website, assign a [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) to the text portion's [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) property, as shown below. Only that portion of text becomes clickable.

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

To make a shape or frame clickable, set its [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) property. The hyperlink belongs to the object itself rather than to a text portion inside it.

The same approach applies to picture, audio, and video frames: assign the hyperlink to the frame and set the link's [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) if needed.

The following example makes a rectangle clickable:

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

Internal hyperlinks let readers jump from a table of contents to a specific slide. The following example uses [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) to link the “Page 2” text on the first slide to the second slide.

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

The [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) property of [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) determines whether a hyperlink uses the presentation's hyperlink color or the text portion's formatting. To apply a custom text color, select [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) and set the portion's fill color. This feature was introduced in PowerPoint 2019; older versions do not apply this setting.

The following example adds two text hyperlinks to the same slide. The first uses a red text fill, while the second retains the default hyperlink color.

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

A hyperlink can play a sound when activated or stop a sound that is already playing. Use the following properties to configure these behaviors:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) specifies the audio associated with the hyperlink.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) controls whether activating the hyperlink stops the previous sound.

#### **Add a Hyperlink Sound**

The following example loads `sampleaudio.wav` and associates it with a button on the first slide. Clicking the button plays the sound and navigates to the next slide. A second shape on that slide stops the previous sound when clicked, without performing a navigation action.

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

The following example opens the presentation created above and reads the first shape's hyperlink audio into memory through [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) and [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

You can update the following [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) properties after assigning a hyperlink to text or a shape:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) sets the text that a viewer can display as a hint for the link.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) specifies the target frame within a parent HTML frameset, when applicable.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) controls whether activating the link adds its destination to the list of viewed hyperlinks.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) controls whether the hyperlink is highlighted when clicked.

## **Remove Hyperlinks from Presentations**

Use [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) to collect hyperlink containers, including text-portion links, before changing them. The following example removes both activation types from the first slide. To remove only one type, call only [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) or [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); removing a click action does not remove its mouse-over counterpart.

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

For unconditional removal, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) removes both activation types in the selected scope in one call. For selective cleanup and coverage of masters, layouts, and notes, see [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Build a Complete Hyperlink Inventory**

Before distributing a presentation, inventory its interactive actions as well as its web links. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returns [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) objects, not a flat list of URL strings. Inspect both [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) and [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) on each container. They are independent: the same container can expose both actions, so a complete report needs up to two rows per container.

Scanning only shape-level hyperlinks can miss links attached to text portions. Query the appropriate scope instead, and retain the returned containers so that you can later update or remove their actions.

### **Query Presentation, Slide, and Text-Frame Scopes**

The [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) interface is available through [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), and [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Each scope supports the same queries:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) returns containers with a click action.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) returns containers with a mouse-over action.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returns containers with either or both actions.

The following example creates `hyperlink-audit-input.pptx` with an external click link, a file mouse-over link, internal slide navigation, a text mouse-over link, and a macro action. It does not execute any of these actions. The same three queries work at every scope; the counts describe containers, not action totals. The text-frame scope excludes the enclosing shape's own links.

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

For this example, presentation and slide queries each report three click containers, two mouse-over containers, and three containers with either action. The text-frame query reports one container in each category.

### **Classify Actions and Destinations**

Use [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) to interpret an action before interpreting its destination. The [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) values cover more than web navigation:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | External hyperlink; inspect the URL and its scheme. |
| `JumpSpecificSlide` | Internal navigation to a particular slide. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Built-in slideshow navigation, resolved in slideshow context. |
| `JumpEndShow`, `StartCustomSlideShow` | End the current show or start a custom show. |
| `StartMacro` | Execute a macro. |
| `StartProgram` | Launch a program. |
| `OpenFile`, `OpenPresentation` | Open a file or another presentation; review separately from web URLs. |
| `StartStopMedia` | Start or stop media playback. |
| `NoAction`, `Unknown` | No navigation action, or an unrecognized action requiring review. |

Read external destinations from [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) and specific internal destinations from [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Internal actions and built-in commands may have no external URL; an empty URL does not mean that the container has no action. Preserve [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) when it differs from the normalized URL, and include the [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) when available.

### **Report, Sanitize, and Verify Hyperlinks**

The following .NET 6+ example reads an existing presentation (use the file created above), writes `hyperlink-audit.json`, applies a policy, saves `hyperlink-sanitized.pptx`, and reopens it to check both activation types again. It collects containers before changing them and uses reference equality to avoid processing the same container twice. Presentation queries cover ordinary slides; for a package-wide inventory, it also explicitly queries masters, layouts, notes, and the notes and handout masters when present.

The report records a one-based slide index and [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) where available. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) supplies the owning slide for supported containers. Masters, layouts, and notes have no ordinary slide index and are identified by their scope. Shape containers and text-portion formatting containers are labeled separately; other container types retain their runtime type name. Each container gets a report-local ID so its two actions can be correlated.

This deliberately restrictive application policy allows only absolute HTTPS URLs and valid internal slide targets. It rejects macros, programs, file actions, other slideshow actions, unknown actions, and other URL schemes. These rejections are policy decisions, not an Aspose.Slides safety verdict. HTTPS alone does not establish trust: add host allowlists and other checks for your application. Both original and normalized external URLs are checked. The example audits metadata without following links or running actions.

For remediation, the container's [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) supports [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), and [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Here, prohibited external click links are replaced with a fixed HTTPS landing page; other prohibited clicks and prohibited mouse-over actions are removed independently. Set `replaceExternalClicks` to `false` to remove all policy violations instead. Choose an application-owned replacement page before deployment.

The report's export flag uses a conservative PDF review policy: flag mouse-over actions and anything other than an external link or specific slide jump as potentially unsupported. It is a review hint, not a capability test or a guarantee that unflagged links will survive export. Supported [PDF](/slides/net/convert-powerpoint-to-pdf/) and [HTML](/slides/net/convert-powerpoint-to-html/) exports may preserve hyperlinks, depending on the action, export options, and viewer. Raster [images](/slides/net/convert-powerpoint-to-png/) and [video](/slides/net/convert-powerpoint-to-video/) cannot preserve interactive hyperlinks; flag every action when auditing for those outputs.

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

With the input created above, the report contains five action rows. The file mouse-over link and macro click are removed, while the HTTPS links and internal slide navigation remain. The verification prints zero prohibited actions. An input containing a prohibited external click URL also exercises the replacement branch. A container with an allowed click and a prohibited mouse-over keeps its click action.

This selective cleanup differs from [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), which removes both activation types throughout the selected scope regardless of policy. Verification here checks hyperlink actions only; it does not remove embedded VBA projects, OLE objects, or other active content, and it does not validate an exported PDF or HTML file.

## **FAQ**

**How can I link to a section or its first slide?**

Sections in PowerPoint group slides, but an internal hyperlink targets an individual slide. To create navigation to a section, link to the first slide in that section.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

Yes. Master slide and layout elements support hyperlinks. Links on these elements are available during the slide show on slides that use the corresponding master or layout.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

Supported PDF and HTML exports may preserve hyperlinks; raster images and video cannot. See the export considerations in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

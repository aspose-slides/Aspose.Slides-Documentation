---
title: Manage Presentation Zoom in .NET
linktitle: Manage Zoom
type: docs
weight: 60
url: /net/manage-zoom/
keywords:
- zoom
- zoom frame
- slide zoom
- section zoom
- summary zoom
- add zoom
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create and customize Zoom with Aspose.Slides for .NET — jump between sections, add thumbnails and transitions in PowerPoint presentations."
---

## **Introduction**

PowerPoint zooms let you navigate between specific slides and sections during a slide show. With Aspose.Slides for .NET, you can create slide, section, and summary zooms and customize their previews, borders, and transitions.

![PowerPoint zoom overview](overview.png)

* To summarize an entire presentation on a single slide, use a [Summary Zoom](#summary-zoom).
* To show selected slides only, use a [Slide Zoom](#slide-zoom).
* To show a single section only, use a [Section Zoom](#section-zoom).

## **Slide Zoom**

A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Slide zooms let you explore related information from a single overview slide.

![Selecting slides for a slide zoom](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype/) enumeration, the [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe/) interface, and methods on the [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) interface.

### **Create Zoom Frames**

Use [IShapeCollection.AddZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addzoomframe/) to place links to individual slides on an overview slide. This example creates two target slides with distinct backgrounds and labels, then adds a preview of each to the first slide and saves the presentation as PPTX. Frame positions and dimensions are specified in points.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var secondSlide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
var thirdSlide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);

secondSlide.Background.Type = BackgroundType.OwnBackground;
secondSlide.Background.FillFormat.FillType = FillType.Solid;
secondSlide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

var textBox = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
textBox.TextFrame.Text = "Second Slide";

thirdSlide.Background.Type = BackgroundType.OwnBackground;
thirdSlide.Background.FillFormat.FillType = FillType.Solid;
thirdSlide.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

textBox = thirdSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
textBox.TextFrame.Text = "Third Slide";

overviewSlide.Shapes.AddZoomFrame(20, 20, 250, 200, secondSlide);
overviewSlide.Shapes.AddZoomFrame(200, 250, 250, 200, thirdSlide);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

### **Create Zoom Frames with Custom Images**

Pass a custom image to [IShapeCollection.AddZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addzoomframe/) to replace the target slide's default preview. This example requires a local image, loads it with [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/), and adds it to the presentation using [IImageCollection.AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). The resulting frame displays that image while still linking to the second slide.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
textBox.TextFrame.Text = "Second Slide";

using var image = Images.FromFile("image.png");
var previewImage = presentation.Images.AddImage(image);

overviewSlide.Shapes.AddZoomFrame(20, 20, 300, 200, slide, previewImage);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

### **Format Zoom Frames**

This example customizes two slide zoom frames. It assigns a local image to the first frame through [IZoomObject.ZoomImage](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/zoomimage/), and gives the second frame a five-point, dash-dot pink border through [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/). Setting [IZoomObject.ShowBackground](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/showbackground/) to `false` hides the second frame's background. A local image is required for the custom preview; both frames retain their slide targets in the saved PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var secondSlide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
var thirdSlide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);

secondSlide.Background.Type = BackgroundType.OwnBackground;
secondSlide.Background.FillFormat.FillType = FillType.Solid;
secondSlide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

var textBox = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
textBox.TextFrame.Text = "Second Slide";

thirdSlide.Background.Type = BackgroundType.OwnBackground;
thirdSlide.Background.FillFormat.FillType = FillType.Solid;
thirdSlide.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

textBox = thirdSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
textBox.TextFrame.Text = "Third Slide";

var firstZoomFrame = overviewSlide.Shapes.AddZoomFrame(20, 20, 250, 200, secondSlide);
var secondZoomFrame = overviewSlide.Shapes.AddZoomFrame(200, 250, 250, 200, thirdSlide);

using var image = Images.FromFile("image.png");
var previewImage = presentation.Images.AddImage(image);

firstZoomFrame.ZoomImage = previewImage;

secondZoomFrame.LineFormat.Width = 5;
secondZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
secondZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
secondZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;

secondZoomFrame.ShowBackground = false;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

## **Section Zoom**

A section zoom links to a section in your presentation. Use it to revisit a topic or show how different parts of the presentation connect.

![Selecting a section for a section zoom](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe/) interface and methods on the [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) interface.

### **Create Section Zoom Frames**

Create a section with [ISectionCollection.AddSection](https://reference.aspose.com/slides/net/aspose.slides/isectioncollection/addsection/), then pass the returned section to [IShapeCollection.AddSectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsectionzoomframe/). This example places a section zoom on the first slide and links it to a section beginning with a colored slide. The frame's position and dimensions are specified in points, and the presentation is saved as PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
slide.Background.Type = BackgroundType.OwnBackground;

var section = presentation.Sections.AddSection("Section 1", slide);
var sectionZoomFrame = overviewSlide.Shapes.AddSectionZoomFrame(20, 20, 300, 200, section);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

### **Create Section Zoom Frames with Custom Images**

The image overload of [IShapeCollection.AddSectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsectionzoomframe/) lets you display a custom preview without changing the destination section. This example requires a local image, which is loaded with [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) and added through [IImageCollection.AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). The saved presentation contains a section zoom on the first slide linked to the newly created section.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
slide.Background.Type = BackgroundType.OwnBackground;

using var image = Images.FromFile("image.png");
var previewImage = presentation.Images.AddImage(image);

var section = presentation.Sections.AddSection("Section 1", slide);
var sectionZoomFrame = overviewSlide.Shapes.AddSectionZoomFrame(20, 20, 300, 200, section, previewImage);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

### **Change a Section Zoom's Target Section**

Use [ISectionZoomFrame.TargetSection](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe/targetsection/) to redirect an existing section zoom without recreating it. Choose a populated section from the same presentation's [Sections](https://reference.aspose.com/slides/net/aspose.slides/presentation/sections/) collection. Assigning an empty section leaves the current target unchanged, so check [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/net/aspose.slides/isection/getslideslistofsection/) before assigning it. See [Manage Slide Sections](/slides/net/slide-section/) for more about sections.

The following example loads a presentation file, which must contain multiple populated sections, an existing section zoom named `Section navigation`, and a section with the unique name `Results`. It searches all slides for the zoom and finds the destination by name rather than by a collection index that can change when sections are reordered. If names are not unique, use [ISection.SectionId](https://reference.aspose.com/slides/net/aspose.slides/isection/sectionid/) to identify the destination instead.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("section-zoom.pptx");

var zoom = presentation.Slides.SelectMany(slide => slide.Shapes).OfType<ISectionZoomFrame>().FirstOrDefault(shape => shape.Name == "Section navigation");
var targetSection = presentation.Sections.FirstOrDefault(section => section.Name == "Results");

if (zoom == null || targetSection == null)
{
    Console.WriteLine("The section zoom or destination section was not found.");
}
else if (targetSection.GetSlidesListOfSection().Count == 0)
{
    Console.WriteLine("The destination section is empty.");
}
else
{
    Console.WriteLine($"Current section: {zoom.TargetSection?.Name}");
    zoom.TargetSection = targetSection;
    presentation.Save("section-zoom-updated.pptx", SaveFormat.Pptx);
}
```

### **Format Section Zoom Frames**

This example moves and resizes a section zoom to 100 by 75 points, assigns a local image through [IZoomObject.ZoomImage](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/zoomimage/), and applies a 2.5-point, dash-dot brown border. It enables [IZoomObject.ReturnToParent](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/returntoparent/) to return to the originating slide after the section, disables [IZoomObject.ShowBackground](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/showbackground/), and sets [IZoomObject.TransitionDuration](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/transitionduration/) to 1.5 seconds. A local image is required for the custom preview.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
slide.Background.Type = BackgroundType.OwnBackground;

var section = presentation.Sections.AddSection("Section 1", slide);

var sectionZoomFrame = overviewSlide.Shapes.AddSectionZoomFrame(20, 20, 300, 200, section);
sectionZoomFrame.X = 100;
sectionZoomFrame.Y = 300;
sectionZoomFrame.Width = 100;
sectionZoomFrame.Height = 75;

using var image = Images.FromFile("image.png");
var previewImage = presentation.Images.AddImage(image);

sectionZoomFrame.ZoomImage = previewImage;

sectionZoomFrame.ReturnToParent = true;
sectionZoomFrame.ShowBackground = false;

sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
sectionZoomFrame.LineFormat.Width = 2.5f;

sectionZoomFrame.TransitionDuration = 1.5f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

## **Summary Zoom**

A summary zoom provides an overview of presentation sections. During a slide show, you can use it to jump to a section, skip ahead, or revisit a topic without following the slide order.

![Selecting sections for a summary zoom](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection/), and [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection/) interfaces and methods on the [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) interface.

### **Create a Summary Zoom**

Use [IShapeCollection.AddSummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsummaryzoomframe/) to create an overview of the presentation's sections. This example creates four sections with distinct slide backgrounds and adds a summary zoom to the first slide. The frame's position and dimensions are specified in points, and the resulting overview is saved in a PPTX presentation.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
slide.Background.Type = BackgroundType.OwnBackground;

presentation.Sections.AddSection("Section 1", slide);

slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
slide.Background.Type = BackgroundType.OwnBackground;

presentation.Sections.AddSection("Section 2", slide);

slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
slide.Background.Type = BackgroundType.OwnBackground;

presentation.Sections.AddSection("Section 3", slide);

slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
slide.Background.Type = BackgroundType.OwnBackground;

presentation.Sections.AddSection("Section 4", slide);

var summaryZoomFrame = overviewSlide.Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

### **Add and Remove a Summary Zoom Section**

A summary zoom stores its [ISummaryZoomSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection/) objects in [ISummaryZoomFrame.SummaryZoomCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe/summaryzoomcollection/). This example creates an overview of two sections, adds a third section using [ISummaryZoomSectionCollection.AddSummaryZoomSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection/addsummaryzoomsection/), and removes the first section's entry using [ISummaryZoomSectionCollection.RemoveSummaryZoomSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection/removesummaryzoomsection/). Removing the entry leaves the presentation section and its slides intact.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
slide.Background.Type = BackgroundType.OwnBackground;

var firstSection = presentation.Sections.AddSection("Section 1", slide);

slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
slide.Background.Type = BackgroundType.OwnBackground;

presentation.Sections.AddSection("Section 2", slide);

var summaryZoomFrame = overviewSlide.Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
slide.Background.Type = BackgroundType.OwnBackground;

var thirdSection = presentation.Sections.AddSection("Section 3", slide);

summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(thirdSection);

summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(firstSection);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

### **Format Summary Zoom Sections**

This example formats the first entry in [ISummaryZoomFrame.SummaryZoomCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe/summaryzoomcollection/), using the zero-based index `0`. It requires a local image for [IZoomObject.ZoomImage](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/zoomimage/), applies a 1.5-point, dash-dot black border, and sets [IZoomObject.TransitionDuration](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/transitionduration/) to 1.5 seconds. Setting [IZoomObject.ReturnToParent](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/returntoparent/) to `false` disables the automatic return to the summary slide for this entry.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var overviewSlide = presentation.Slides[0];

var slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
slide.Background.Type = BackgroundType.OwnBackground;

presentation.Sections.AddSection("Section 1", slide);

slide = presentation.Slides.AddEmptySlide(overviewSlide.LayoutSlide);
slide.Background.FillFormat.FillType = FillType.Solid;
slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
slide.Background.Type = BackgroundType.OwnBackground;

presentation.Sections.AddSection("Section 2", slide);

var summaryZoomFrame = overviewSlide.Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

var summarySection = summaryZoomFrame.SummaryZoomCollection[0];

using var image = Images.FromFile("image.png");
var previewImage = presentation.Images.AddImage(image);

summarySection.ZoomImage = previewImage;
summarySection.ReturnToParent = false;

summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
summarySection.LineFormat.Width = 1.5f;

summarySection.TransitionDuration = 1.5f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. Set [IZoomObject.ReturnToParent](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/returntoparent/) to `true` to return to the originating slide after the target content is shown.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Set [IZoomObject.TransitionDuration](https://reference.aspose.com/slides/net/aspose.slides/izoomobject/transitionduration/) to control the transition duration in seconds.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.

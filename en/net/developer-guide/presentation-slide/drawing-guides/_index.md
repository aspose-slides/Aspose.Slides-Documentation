---
title: Manage Drawing Guides in Presentations in .NET
linktitle: Drawing Guides
type: docs
weight: 85
url: /net/drawing-guides/
keywords:
- drawing guide
- horizontal guide
- vertical guide
- alignment guide
- slide view
- master slide
- layout slide
- notes master
- handout master
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add, access, and clear horizontal and vertical drawing guides in PowerPoint presentations using Aspose.Slides for .NET."
---

## **Overview**

Drawing guides are adjustable horizontal and vertical lines that help users align shapes consistently while editing a presentation in PowerPoint. They are especially useful when an application generates a presentation that will later be refined manually: the application can save the same alignment aids that authors should follow when adding or moving content.

Drawing guides are editing aids, not slide content. They do not appear in a slide show or rendered output. Aspose.Slides for .NET exposes them through the [IDrawingGuidesCollection](https://reference.aspose.com/slides/net/aspose.slides/idrawingguidescollection/) interface. A guide is represented by [IDrawingGuide](https://reference.aspose.com/slides/net/aspose.slides/idrawingguide/) and has an orientation, a position, and a color.

The position is measured in points from the top-left corner of the relevant slide or master. A vertical guide uses a horizontal coordinate, typically between zero and the slide width. A horizontal guide uses a vertical coordinate, typically between zero and the slide height.

## **Add Guides to the Slide View**

Use [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/drawingguides/) to manage guides displayed while editing normal slides. Call [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/idrawingguidescollection/add/) with an [Orientation](https://reference.aspose.com/slides/net/aspose.slides/orientation/) value and a position in points.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Access Drawing Guides**

The [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/net/aspose.slides/idrawingguidescollection/count/) property and indexer provide access to existing guides. The [IDrawingGuide.Orientation](https://reference.aspose.com/slides/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/net/aspose.slides/idrawingguide/position/), and [IDrawingGuide.Color](https://reference.aspose.com/slides/net/aspose.slides/idrawingguide/color/) properties can be read or changed.

The following example reads the slide-view guides from the presentation created above:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Add Guides to Master and Layout Slides**

A slide master and each of its layout slides can have their own drawing-guide collections. Use [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/drawingguides/) for a master slide and [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/drawingguides/) for a layout slide.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Add Guides to Notes and Handout Masters**

Notes masters and handout masters also support drawing guides. Use [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide/drawingguides/) and [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslide/drawingguides/) to access their collections. If a presentation does not contain one of these masters, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) or [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) creates the default master and returns it.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Clear Drawing Guides**

Call [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/idrawingguidescollection/clear/) to remove every guide from a particular collection. Clearing one collection does not affect guides stored in another scope.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Do drawing guides appear in a slide show or exported images?**

No. Drawing guides are alignment aids for editing and are not rendered as presentation content.

**Can a drawing guide be added directly to an individual normal slide?**

Normal-slide editing guides are stored in the presentation's slide-view properties. Separate guide collections are available for slide masters, layout slides, notes masters, and handout masters.

**Which units are used for guide positions?**

Positions are specified in points, where 72 points equal one inch. Vertical positions are measured from the left edge, and horizontal positions are measured from the top edge.

**Does clearing drawing guides remove shapes or change slide content?**

No. The `Clear` method removes only the guides in the selected collection. Shapes and other slide content remain unchanged.

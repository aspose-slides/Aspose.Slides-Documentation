---
title: Retrieve and Update Presentation View Properties in .NET
linktitle: View Properties
type: docs
weight: 80
url: /net/presentation-view-properties/
keywords: 
- view properties
- normal view
- outline content
- outline icons
- snap vertical splitter
- single view
- bar state
- dimension size
- auto adjust
- default zoom
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Discover Aspose.Slides for .NET view properties to customize formats PPT, PPTX, and ODP slides—adjust layouts, zoom levels, and display settings."
---

## **Introduction**

The normal view consists of three content regions: the slide itself, a side content region, and a bottom content region. Properties pertaining to the positioning of the different content regions. This information allows the application to save its view state to the file, so that when reopened the view is in the same state as when the presentation was last saved.

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) has been added to provide access to normal view properties of presentation. 

[INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) interfaces and its descendants, [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) enum have been added.

## **About INormalViewProperties**

Represents normal view properties.

Property **ShowOutlineIcons** specifies whether the application should show icons if displaying outline content in any of the content regions of normal view mode.

Property **SnapVerticalSplitter** specifies whether the vertical splitter should snap to a minimized state when the side region is sufficiently small.

Property **PreferSingleView** specifies whether the user prefers to see a full-window single-content region over the standard normal view with three content regions. If enabled, the application may choose to display one of the content regions in the entire window.

Properties **VerticalBarState** and **HorizontalBarState** specify the state that the horizontal or vertical splitter bar should be shown in. A horizontal splitter bar separates the slide from the content region below the slide, vertical splitter bar separates the slide from the side content region. Possible values are: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** and **SplitterBarStateType.Restored.**

Properties **RestoredLeft** and **RestoredTop** specify the sizing of the top or side slide region of the normal view, when **SplitterBarStateType.Restored** value applied for **VerticalBarState** and **HorizontalBarState** accordingly.

## **About Restoring INormalViewProperties** 

Specifies the sizing of the slide region (width when a child of RestoredTop, height when a child of RestoredLeft) of the normal view, when the region is of a variable restored size(neither minimized nor maximized). 

Property **DimensionSize** specifies the size of the slide region (width when a child of restoredTop, height when a child of restoredLeft).

Property **AutoAdjust** specifies whether the size of the side content region should compensate for the new size when resizing the window containing the view within the application

An example is given below shows how can you access **ViewProperties.NormalViewProperties** properties for a presentation.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Restore the view properties of the presentation
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Set the Default Zoom Value**

Aspose.Slides for .NET now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) of a presentation. Slide View Properties as well as [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in Aspose.Slides.

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class
1. Set View [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) of Presentation
1. Write the presentation as a PPTX file

In the example given below, we have set the zoom value for slide view as well as notes view.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Setting the view properties of the presentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoom value in percentages for slide view
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoom value in percentages for notes view 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Set the Grid Spacing**

Use [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) to access presentation-wide view settings. The [IViewProperties.GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) property reads or changes the interval of the underlying editing grid. This setting applies to the entire presentation, not to an individual slide. Grid spacing is specified in points, where 72 points equal one inch. Use a positive value, as required by the API documentation.

The following example opens an existing `demo.pptx`, prints its current grid spacing, sets a quarter-inch interval, and saves the result.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

The grid is different from [drawing guides](/slides/net/drawing-guides/). Grid spacing controls a regular interval, while drawing guides are individually positioned horizontal or vertical alignment lines. Adding, moving, or clearing drawing guides does not change the grid spacing.

Both the grid and drawing guides are editing aids. They are not rendered as slide content in PDF, images, SVG, or a slide show. Storing the grid spacing does not guarantee that an editor will display the grid: its visibility also depends on the viewer or editor's preferences.

## **Show or Hide Comments When Opening a Presentation**

Use [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) to access presentation-wide view settings. Read or change [IViewProperties.ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) to store a preference for whether comments should be shown when the presentation opens in PowerPoint or another compatible editor.

This setting only controls the stored view preference. It does not add, remove, edit, or resolve comments. Hiding comments preserves their content, authors, positions, replies, and statuses. See [Presentation Comments](/slides/net/presentation-comments/) for operations that change the comments themselves.

The following example requires an existing `comments.pptx` containing comments. It prints the current visibility setting, requests that comments be hidden, and saves a new PPTX without removing any comments. It also sets [IViewProperties.LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) to [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) to configure the initial editing view alongside comment visibility.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

This setting does not determine whether comments are included in PDF, HTML, image, notes, or handout exports. Configure the relevant export-specific options separately.

## **FAQ**

**Why is the grid not visible after I reopen the presentation?**

The file stores the grid spacing, but the editor controls whether the grid is displayed. Check the editor's grid visibility settings.

**Does clearing drawing guides change the grid spacing?**

No. Drawing guides and grid spacing are independent settings. Clearing guides leaves the stored grid interval unchanged.

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) are defined at the presentation level ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)), not per section, so a single set of parameters applies to the entire document when it opens.

**Can I predefine different view states for different users?**

No. The settings are stored in the file and are shared. Viewer applications may honor user preferences, but the file itself contains one set of view properties.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

Yes. Because [view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) are stored at the presentation level, you can embed them in a template and create new documents from it with the same initial view configuration.

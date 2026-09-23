---
title: Retrieve and Update Presentation View Properties in Python via Java
linktitle: View Properties
type: docs
weight: 80
url: /python-java/presentation-view-properties/
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
- Python
- Java
- Aspose.Slides
description: "Discover Aspose.Slides for Python via Java view properties to customize PPT, PPTX, and ODP slides—adjust layouts, zoom levels, and display settings."
---

## **Introduction**

The normal view consists of three content regions: the slide itself, a side content region, and a bottom content region. Normal view properties describe the positioning of these content regions. This information allows the application to save its view state to the file, so that when reopened the view is in the same state as when the presentation was last saved.

The method [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) has been added to provide access to the normal view properties of a presentation.

The [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) and [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) classes and the [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) enumeration have been added.

## **About NormalViewProperties**

Represents normal view properties.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) and [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) specify whether the application should show icons if displaying outline content in any of the content regions of normal view mode.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) and [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) specify whether the vertical splitter should snap to a minimized state when the side region is sufficiently small.

Methods [getPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) and [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) specify whether the user prefers to see a full-window single-content region over the standard normal view with three content regions. If enabled, the application may choose to display one of the content regions in the entire window.

Methods [getVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) and [getHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) specify the state that the horizontal or vertical splitter bar should be shown in. A horizontal splitter bar separates the slide from the content region below the slide; a vertical splitter bar separates the slide from the side content region. Possible values are: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/#Maximized) and [SplitterBarStateType.Restored](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/#Restored).

Methods [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) and [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) specify the sizing of the top or side slide region of the normal view, when the [SplitterBarStateType.Restored](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/#Restored) value is applied to [getVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) and [getHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectively.

## **About Restoring NormalViewProperties**

Specifies the sizing of the slide region (width when a child of [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop), height when a child of [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) of the normal view, when the region is of a variable restored size (neither minimized nor maximized).

The method [getDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) specifies the size of the slide region (width when a child of [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop), height when a child of [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

The method [getAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) specifies whether the size of the side content region should compensate for the new size when resizing the window containing the view within the application.

The example below shows how to access [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) for a presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Restore the view properties of the presentation.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Default Zoom Value**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java supports setting the default zoom value so that it is already applied when the presentation opens. This can be done by setting the [ViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/) of a presentation. [getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) as well as [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) can be configured programmatically. In this topic, we will see with an example how to set the [View Properties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/) of [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) in Aspose.Slides.

{{% /alert %}}

To set the view properties, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Set [View Properties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/) of [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Write the presentation as a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

In the example below, we set the zoom value for both slide view and notes view.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Set the view properties of the presentation.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoom percentage for slide view.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoom percentage for notes view.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Grid Spacing**

Use [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) to access presentation-wide view settings. The [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getGridSpacing) and [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) methods read or change the interval of the underlying editing grid. This setting applies to the entire presentation, not to an individual slide. Grid spacing is specified in points, where 72 points equal one inch. Use a positive value, as required by the API documentation.

The following example opens an existing `demo.pptx`, prints its current grid spacing, sets a quarter-inch interval, and saves the result.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The grid is different from [drawing guides](/slides/python-java/drawing-guides/). Grid spacing controls a regular interval, while drawing guides are individually positioned horizontal or vertical alignment lines. Adding, moving, or clearing drawing guides does not change the grid spacing.

Both the grid and drawing guides are editing aids. They are not rendered as slide content in PDF, images, SVG, or a slide show. Storing the grid spacing does not guarantee that an editor will display the grid: its visibility also depends on the viewer or editor's preferences.

## **Show or Hide Comments When Opening a Presentation**

Use [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) to access presentation-wide view settings. Use [ViewProperties.getShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getShowComments) and [ViewProperties.setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) to read or change the stored preference for whether comments should be shown when the presentation opens in PowerPoint or another compatible editor.

This setting only controls the stored view preference. It does not add, remove, edit, or resolve comments. Hiding comments preserves their content, authors, positions, replies, and statuses. See [Presentation Comments](/slides/python-java/presentation-comments/) for operations that change the comments themselves.

The following example requires an existing `comments.pptx` containing comments. It prints the current visibility setting, requests that comments be hidden, and saves a new PPTX without removing any comments. It also uses [ViewProperties.setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) with [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) to configure the initial editing view alongside comment visibility.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

This setting does not determine whether comments are included in PDF, HTML, image, notes, or handout exports. Configure the relevant export-specific options separately.

## **FAQ**

**Why is the grid not visible after I reopen the presentation?**

The file stores the grid spacing, but the editor controls whether the grid is displayed. Check the editor's grid visibility settings.

**Does clearing drawing guides change the grid spacing?**

No. Drawing guides and grid spacing are independent settings. Clearing guides leaves the stored grid interval unchanged.

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) are defined at the presentation level ([Normal View](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), not per section, so a single set of parameters applies to the entire document when it opens.

**Can I predefine different view states for different users?**

No. The settings are stored in the file and are shared. Viewer applications may honor user preferences, but the file itself contains one set of view properties.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

Yes. Because [view properties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) are stored at the presentation level, you can embed them in a template and create new documents from it with the same initial view configuration.

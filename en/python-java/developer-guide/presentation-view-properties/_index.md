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
description: "Use Aspose.Slides for Python via Java to configure the normal view layout, slide and notes zoom, grid spacing, and comment visibility in PowerPoint presentations."
---

## **Introduction**

In PowerPoint's normal view, the slide appears between a side pane for thumbnails or an outline and a notes pane below. Aspose.Slides for Python via Java exposes the presentation's saved editing preferences through [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). These include the pane layout, zoom levels, grid spacing, and comment visibility.

## **About NormalViewProperties**

Use [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) to access the [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) class. [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) controls whether icons appear beside slide titles in the outline. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) lets the side pane snap to its minimized state when the user narrows it. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indicates a preference for displaying one pane in the full window.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) controls the divider between the side pane and the slide. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) controls the divider above the notes pane. Both accept a [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) value of `Minimized`, `Maximized`, or `Restored`.

## **About Restoring NormalViewProperties**

When a divider is restored, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) supplies the saved size of the side pane and [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) supplies the saved size of the upper slide area. Both return an instance of [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Its [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) method accepts a percentage from 0 to 100, and [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) controls whether the editor adjusts the size when the window is resized.

This example updates an existing presentation. It restores the horizontal divider, sets the size returned by [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) to 80% with automatic adjustment enabled, and maximizes the vertical divider. It also calls [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) to display icons in outline view.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Default Zoom Value**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) and [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) store independent zoom settings for the editor. These settings do not affect slide dimensions, slide-show playback, or image export resolution.

This example opens an existing presentation and calls [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) to fit the slide to the editing window. For the notes page, it disables automatic scaling and calls [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) to set a fixed 80% zoom.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Grid Spacing**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) sets the distance between editing grid lines throughout the presentation. It takes a positive value in points, with 72 points per inch. This example prints the current spacing in an existing presentation and saves a quarter-inch grid by setting the interval to 18 points.

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

The grid repeats at a fixed interval. [Drawing guides](/slides/python-java/drawing-guides/) mark individual horizontal or vertical positions. Both are editing aids and appear only in editors that display them. Slide shows and exports to PDF, images, or SVG omit them.

## **Show or Hide Comments When Opening a Presentation**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) stores a preference that compatible editors use when opening the presentation. For an existing presentation with comments, this example prints the current setting and saves a copy with comments hidden. It also calls [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) with [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) so the copy opens in slide view.

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

Hiding comments preserves their text, authors, positions, replies, and statuses. To change the comments themselves, see [Presentation Comments](/slides/python-java/presentation-comments/). Export settings control whether comments appear in PDF, HTML, images, notes, or handouts.

## **FAQ**

**Why is the grid hidden when I reopen the presentation?**

The presentation stores the grid interval. To see the grid, enable grid visibility in the editor.

**Does clearing drawing guides change the grid spacing?**

No. Adding, moving, or clearing a guide leaves the grid interval unchanged.

**Can different sections of a presentation have different view settings?**

No. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) applies to the entire presentation.

**Can I save different view settings for different users?**

The file stores one set of view properties for everyone. An editor may also apply a user's local preferences.

**Can I save view settings in a template?**

Yes. Presentations created from the template inherit its saved view settings.

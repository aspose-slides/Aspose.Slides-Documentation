---
title: Retrieve and Update Presentation View Properties in Java
linktitle: View Properties
type: docs
weight: 80
url: /java/presentation-view-properties/
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
- Java
- Aspose.Slides
description: "Discover Aspose.Slides for Java view properties to customize formats PPT, PPTX, and ODP slides—adjust layouts, zoom levels, and display settings."
---

{{% alert color="primary" %}} 

The normal view consists of three content regions: the slide itself, a side content region, and a bottom content region. Properties pertaining to the positioning of the different content regions. This information allows the application to save its view state to the file, so that when reopened the view is in the same state as when the presentation was last saved.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) has been added to provide access to normal view properties of presentation. 

[INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) interfaces and its descendants, [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType) enum have been added.

{{% /alert %}} 

## **About INormalViewProperties**

Represents normal view properties.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) and [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specifies whether the application should show icons if displaying outline content in any of the content regions of normal view mode.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) and [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specifies whether the vertical splitter should snap to a minimized state when the side region is sufficiently small.

Property [getPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) and [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) specifies whether the user prefers to see a full-window single-content region over the standard normal view with three content regions. If enabled, the application may choose to display one of the content regions in the entire window.

Methods [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) and [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specify the state that the horizontal or vertical splitter bar should be shown in. A horizontal splitter bar separates the slide from the content region below the slide, vertical splitter bar separates the slide from the side content region. Possible values are: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) and [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

Methods [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) and [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specify the sizing of the top or side slide region of the normal view, when [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) value applied for [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) and [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) accordingly.

## **About Restoring INormalViewProperties** 

Specifies the sizing of the slide region (width when a child of [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), height when a child of [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) of the normal view, when the region is of a variable restored size (neither minimized nor maximized). 

Method [getDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specifies the size of the slide region (width when a child of restoredTop, height when a child of restoredLeft).

Method [getAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specifies whether the size of the side content region should compensate for the new size when resizing the window containing the view within the application

An example is given below shows how can you access [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) properties for a presentation.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restore the view properties of the presentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Set the Default Zoom Value**

{{% alert color="primary" %}} 

Aspose.Slides for Java now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) of a presentation. [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) as well as [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) could be set programmatically. In this topic, we will see with an example how to set the [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) of [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) in [Aspose.Slides](/slides/).

{{% /alert %}} 

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Set [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) of [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Write the presentation as a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.
   In the example given below, we have set the zoom value for slide view as well as notes view.

```java
Presentation presentation = new Presentation();
try {
    // Setting the view properties of the presentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoom value in percentages for slide view
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoom value in percentages for notes view 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) are defined at the presentation level ([Normal View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), not per section, so a single set of parameters applies to the entire document when it opens.

**Can I predefine different view states for different users?**

No. The settings are stored in the file and are shared. Viewer applications may honor user preferences, but the file itself contains one set of view properties.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

Yes. Because [view properties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) are stored at the presentation level, you can embed them in a template and create new documents from it with the same initial view configuration.

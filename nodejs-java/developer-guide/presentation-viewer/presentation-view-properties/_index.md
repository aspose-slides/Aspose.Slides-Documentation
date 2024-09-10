---
title: Presentation View Properties
type: docs
url: /nodejs-java/presentation-view-properties/
---

{{% alert color="primary" %}} 

The normal view consists of three content regions: the slide itself, a side content region, and a bottom content region. Properties pertaining to the positioning of the different content regions. This information allows the application to save its view state to the file, so that when reopened the view is in the same state as when the presentation was last saved.

Method [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) has been added to provide access to normal view properties of presentation. 

[**INormalViewProperties**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties) interfaces and its descendants, [**SplitterBarStateType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType) enum have been added.

{{% /alert %}} 


## **About INormalViewProperties** #
Represents normal view properties.

Methods [**getShowOutlineIcons**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) and [**setShowOutlineIcons**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) specifies whether the application should show icons if displaying outline content in any of the content regions of normal view mode.

Methods [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) and [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) specifies whether the vertical splitter should snap to a minimized state when the side region is sufficiently small.

Property [**getPreferSingleView**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) and [**setPreferSingleView**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) specifies whether the user prefers to see a full-window single-content region over the standard normal view with three content regions. If enabled, the application may choose to display one of the content regions in the entire window.

Methods [**getVerticalBarState**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) and [**getHorizontalBarState**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) specify the state that the horizontal or vertical splitter bar should be shown in. A horizontal splitter bar separates the slide from the content region below the slide, vertical splitter bar separates the slide from the side content region. Possible values are: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) and [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Methods [**getRestoredLeft**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) and [**getRestoredTop**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) specify the sizing of the top or side slide region of the normal view, when [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored) value applied for [**getVerticalBarState**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) and [**getHorizontalBarState**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) accordingly.


## **About Restoring INormalViewProperties** 
Specifies the sizing of the slide region (width when a child of [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), height when a child of [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) of the normal view, when the region is of a variable restored size (neither minimized nor maximized). 

Method [**getDimensionSize**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) specifies the size of the slide region (width when a child of restoredTop, height when a child of restoredLeft).

Method [**getAutoAdjust**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) specifies whether the size of the side content region should compensate for the new size when resizing the window containing the view within the application

An example is given below shows how can you access [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) properties for a presentation.

```javascript
    // Instantiate a Presentation object that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
        pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);
        // Restore View Properties of Presentation
        pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
        pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
        pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
        pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        pres.dispose();
    }
```

## **Set Default Zoom Value**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) of a presentation. [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) as well as [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) could be set programmatically. In this topic, we will see with an example how to set the [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) in [Aspose.Slides](/slides/).

{{% /alert %}} 

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Set [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Write the presentation as a [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.
   In the example given below, we have set the zoom value for slide view as well as notes view.

```javascript
    // Instantiate a Presentation object that represents a presentation file
    var presentation = new  aspose.slides.Presentation();
    try {
        // Setting View Properties of Presentation
        presentation.getViewProperties().getSlideViewProperties().setScale(100);// Zoom value in percentages for slide view
        presentation.getViewProperties().getNotesViewProperties().setScale(100);// Zoom value in percentages for notes view
        presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

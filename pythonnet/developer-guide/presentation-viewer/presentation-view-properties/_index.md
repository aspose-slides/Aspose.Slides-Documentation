---
title: Presentation View Properties
type: docs
url: /pythonnet/presentation-view-properties/
keywords: "PowerPoint viewer, viewer properties, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "PowerPoint presentation viewer properties in Python"
---

{{% alert color="primary" %}} 

The normal view consists of three content regions: the slide itself, a side content region, and a bottom content region. Properties pertaining to the positioning of the different content regions. This information allows the application to save its view state to the file, so that when reopened the view is in the same state as when the presentation was last saved.

Property [**IViewProperties.NormalViewProperties**](https://apireference.aspose.com/slides/pythonnet/aspose.slides/iviewproperties/properties/normalviewproperties) has been added to provide access to normal view properties of presentation. 

[**INormalViewProperties**](https://apireference.aspose.com/slides/pythonnet/aspose.slides/inormalviewproperties), [**INormalViewRestoredProperties** ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/inormalviewrestoredproperties)interfaces and its descendants, [**SplitterBarStateType**](https://apireference.aspose.com/slides/pythonnet/aspose.slides/splitterbarstatetype) enum have been added.

{{% /alert %}} 



## **About INormalViewProperties** #

Represents normal view properties.

Property **ShowOutlineIcons** specifies whether the application should show icons if displaying outline content in any of the content regions of normal view mode.

Property **SnapVerticalSplitter** specifies whether the vertical splitter should snap to a minimized state when the side region is sufficiently small.

Property **PreferSingleView** specifies whether the user prefers to see a full-window single-content region over the standard normal view with three content regions. If enabled, the application may choose to display one of the content regions in the entire window.

Properties **VerticalBarState** and **HorizontalBarState** specify the state that the horizontal or vertical splitter bar should be shown in. A horizontal splitter bar separates the slide from the content region below the slide, vertical splitter bar separates the slide from the side content region. Possible values are: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** and **SplitterBarStateType.Restored.**

Properties **RestoredLeft** and **RestoredTop** specify the sizing of the top or side slide region of the normal view, when **SplitterBarStateType.Restored** value applied for **VerticalBarState** and **HorizontalBarState** accordingly.



## **About INormalViewRestoredProperties** #

Specifies the sizing of the slide region ((width when a child of RestoredTop, height when a child of RestoredLeft) of the normal view, when the region is of a variable restored size(neither minimized nor maximized). 

Property **DimensionSize** specifies the size of the slide region (width when a child of restoredTop, height when a child of restoredLeft).

Property **AutoAdjust** specifies whether the size of the side content region should compensate for the new size when resizing the window containing the view within the application

An example is given below shows how can you access **ViewProperties.NormalViewProperties** properties for a presentation.

```py
//Instantiate a presentation object that represents a presentation file
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```




## **Set Default Zoom Value**
Aspose.Slides for Python via .NET now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [**ViewProperties**](https://apireference.aspose.com/slides/pythonnet/aspose.slides/viewproperties) of a presentation. Slide View Properties as well as [NotesViewProperties](https://apireference.aspose.com/slides/pythonnet/aspose.slides/viewproperties/properties/notesviewproperties) could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in Aspose.Slides.

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class
1. Set View [Properties](https://apireference.aspose.com/slides/pythonnet/aspose.slides/viewproperties) of Presentation
1. Write the presentation as a PPTX file

In the example given below, we have set the zoom value for slide view as well as notes view.

```py
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Setting View Properties of Presentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoom value in percentages for slide view
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoom value in percentages for notes view 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```



## **Set View Properties**
In order to set the view properties. Please follow the steps below:

1. Create an instance of Presentation class.
1. Set View Properties of Presentation.
1. Write the presentation as a PPTX file.

In the example given below, we have set the zoom value for slide view as well as notes view.

```py
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Setting View Properties of Presentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoom value in percentages for slide view
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoom value in percentages for notes view 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


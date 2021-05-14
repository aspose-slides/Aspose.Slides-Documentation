---
title: Presentation View Properties
type: docs
url: /cpp/presentation-view-properties/
---



{{% alert color="primary" %}} 

The normal view consists of three content regions: the slide itself, a side content region, and a bottom content region. Properties pertaining to the positioning of the different content regions. This information allows the application to save its view state to the file, so that when reopened the view is in the same state as when the presentation was last saved.

New **IViewProperties::get_NormalViewProperties()** method has been added to provide access to normal view properties of presentation.

New **INormalViewProperties**, **INormalViewRestoredProperties**, **NormalViewProperties**, **NormalViewRestoredProperties** classes and **SplitterBarStateType** enum class have been added.

{{% /alert %}} 



***About INormalViewProperties***

Represents normal view properties.

- **get_ShowOutlineIcons()**, **set_ShowOutlineIcons()**. These methods specify whether the application should show icons if displaying outline content in any of the content regions of normal view mode.
- **get_SnapVerticalSplitter()**, **set_get_SnapVerticalSplitter()**. These methods specify whether the vertical splitter should snap to a minimized state when the side region is sufficiently small.
- **get_PreferSingleView()**, **set_PreferSingleView()**. These methods specify whether the user prefers to see a full-window single-content region over the standard normal view with three content regions.If enabled, the application may choose to display one of the content regions in the entire window.
- **get_VerticalBarState()**, **set_VerticalBarState()**, **get_HorizontalBarState()**, **set_HorizontalBarState()**. These methods specify the state that the horizontal or vertical splitter bar should be shown in. A horizontal splitter bar separates the slide from the content region below the slide, vertical splitter bar separates the slide from the side content region. Possible values are: **SplitterBarStateType::Minimized**, **SplitterBarStateType::Maximized** and **SplitterBarStateType::Restored**.
- **get_RestoredLeft()**, **get_RestoredTop()**. These methods specify the sizing of the top or side slide region of the normal view, when **SplitterBarStateType.Restored** value applied for **VerticalBarState** and **HorizontalBarState** accordingly.



***About INormalViewRestoredProperties***

Specifies the sizing of the slide region (width when a child of RestoredTop, height when a child of RestoredLeft) of the normal view, when the region is of a variable restored size(neither minimized nor maximized). 

- **get_DimensionSize()**, **set_DimensionSize()**. These methods specify the size of the slide region (width when a child of restoredTop, height when a child of restoredLeft).
- **get_AutoAdjust()**, **set_AutoAdjust()**. These methods specify whether the size of the side content region should compensate for the new size when resizing the window containing the view within the application.

An example is given below shows how can you access* ***ViewProperties** for a presentation.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ManagePresenetationNormalViewState-ManagePresenetationNormalViewState.cpp" >}}


## **Set Default Zoom Value**
Aspose.Slides for C++ now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) of a presentation. [SlideViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/slideviewproperties) as well as [NotesViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/notesviewproperties) could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in Aspose.Slides.

## **Set View Properties**
In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Set [View Properties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) of Presentation.
1. Write the presentation as a PPTX file.

In the example given below, we have set the zoom value for slide view as well as notes view.
{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetZoom-SetZoom.cpp" >}}



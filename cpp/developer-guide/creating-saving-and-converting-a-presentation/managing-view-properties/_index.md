---
title: Managing View Properties
type: docs
weight: 90
url: /cpp/managing-view-properties/
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

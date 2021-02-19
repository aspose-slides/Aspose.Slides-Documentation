---
title: Presentation View Properties
type: docs
url: /java/presentation-view-properties/
---

{{% alert color="primary" %}} 

The normal view consists of three content regions: the slide itself, a side content region, and a bottom content region. Properties pertaining to the positioning of the different content regions. This information allows the application to save its view state to the file, so that when reopened the view is in the same state as when the presentation was last saved.

Property [**IViewProperties.*getNormalViewProperties***](https://apireference.aspose.com/java/slides/com.aspose.slides/IViewProperties#getNormalViewProperties--) has been added to provide access to normal view properties of presentation. 

[**INormalViewProperties**](https://apireference.aspose.com/java/slides/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://apireference.aspose.com/java/slides/com.aspose.slides/INormalViewRestoredProperties) interfaces and its descendants, [**SplitterBarStateType**](https://apireference.aspose.com/java/slides/com.aspose.slides/SplitterBarStateType) enum have been added.

{{% /alert %}} 


## **About INormalViewProperties** 
An example is given below shows the usage of [**NormalViewProperties**](https://apireference.aspose.com/java/slides/com.aspose.slides/NormalViewProperties).

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Views-ManagePresenetationNormalViewState-ManagePresenetationNormalViewState.java" >}}


## **Set Default Zoom Value**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [ViewProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewProperties) of a presentation. SlideViewProperties as well as NotesViewProperties could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in [Aspose.Slides](https://docs.aspose.com/slides/).

{{% /alert %}} 

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class.
1. Set View Properties of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation).
1. Write the presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.
   In the example given below, we have set the zoom value for slide view as well as notes view.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-SettingDefaultZoomValueForPresentation-SettingDefaultZoomValueForPresentation.java" >}}

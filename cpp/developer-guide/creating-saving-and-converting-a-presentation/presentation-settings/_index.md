---
title: Presentation Settings
type: docs
weight: 100
url: /cpp/presentation-settings/
---


## **Setting Default Zoom Value**
{{% alert color="primary" %}} 

Aspose.Slides for C++ now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the ViewProperties of a presentation. SlideViewProperties as well as NotesViewProperties could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in Aspose.Slides.

{{% /alert %}} 

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class
1. Set View [Properties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) of Presentation
1. Write the presentation as a PPTX file

In the example given below, we have set the zoom value for slide view as well as notes view.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetZoom-SetZoom.cpp" >}}
## **Setting the Slide Number**
{{% alert color="primary" %}} 

Aspose.Slides for C++ now supports, setting the Slide Number. In this topic, we will see with an example how to get and set the slide number property in Aspose.Slides.

{{% /alert %}} 

The new property [FirstSlideNumber](http://www.aspose.com/api/net/slides/aspose.slides/ipresentation/properties/firstslidenumber) added to [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) allows to get or to set the number of the first slide in a presentation. When a new [FirstSlideNumber](http://www.aspose.com/api/net/slides/aspose.slides/ipresentation/properties/firstslidenumber) value is specified all slide numbers are recalculated. In order to set the Slide Number, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Get the slide number.
1. Set the slide number.
1. Write the presentation as a PPTX file.

In the example given below, we have get and set the slide number property.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetSlideNumber-SetSlideNumber.cpp" >}}







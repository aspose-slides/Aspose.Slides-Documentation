---
title: Creating and Opening
type: docs
weight: 10
url: /net/creating-and-opening/
---

## **Create a PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of Presentation class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-CreateNewPresentation-CreateNewPresentation.cs" >}}
## **Adding Layout Slides to Presentation**
Aspose.Slides also offer to add Layout slides in presentation. There are cases when there is missing Layout slide in presentation and once can now add the Layout Slides in presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name. Aspose.Slides for .NET allows developers to add new Layout slides in presentation. To add a Layout Slide, please follow the steps below:

1. Create an instance of Presentation class.
1. Access the Master Slide collection.
1. Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not.
1. Add a new Layout slide if the desired layout is unavailable.
1. Add an empty slide with a newly added Layout slide.
1. Finally, write the presentation file using the Presentation object.

In the example given below, we have added Layout Slides to Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-AddLayoutSlides-AddLayoutSlides.cs" >}}
## **Setting Default Zoom Value**
Aspose.Slides for .NET now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the ViewProperties of a presentation. SlideViewProperties as well as NotesViewProperties could be set programmatically. In this topic, we will see with example how to set the View Properties of Presentation in Aspose.Slides.
### **Setting View Properties**
In order to set the view properties. Please follow the steps below:

1. Create an instance of Presentation class.
1. Set View Properties of Presentation.
1. Write the presentation as a PPTX file.

In the example given below, we have set the zoom value for slide view as well as notes view.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-SetZoom-SetZoom.cs" >}}
## **Setting the Slide Number**
Aspose.Slides for .NET now supports, setting the Slide Number. In this topic, we will see with an example how to get and set the slide number property in Aspose.Slides. The new methods added to the Presentation allows to get or to set the number of the first slide in a presentation. When a new FirstSlideNumber value is specified all slide numbers are recalculated. In order to get or set the Slide Number, please follow the steps below:

1. Create an instance of Presentation class.
1. Get the slide number.
1. Set the slide number.
1. Write the presentation as a PPTX file.

In the example given below, we have get and set the slide number.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-SetSlideNumber-SetSlideNumber.cs" >}}
## **Load a Presentation**
New IResourceLoadingCallback interface has been added. This callback interface is used to manage external resources loading and has one method:

The code snippet below shows how to use IResourceLoadingCallback interface:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Opening-LoadPresentation-LoadPresentation.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Opening-LoadPresentation-IResourceLoadingCallback.cs" >}}

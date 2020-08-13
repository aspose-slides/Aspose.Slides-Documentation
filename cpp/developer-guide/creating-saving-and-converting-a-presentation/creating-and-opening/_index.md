---
title: Creating and Opening
type: docs
weight: 70
url: /cpp/creating-and-opening/
---

## **Create a PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using the AddAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}
## **Adding Layout Slides to Presentation**
Aspose.Slides also offer to add Layout slides in a presentation. There are cases when there is missing Layout slide in the presentation and once can now add the Layout Slides in a presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name. Aspose.Slides for C++ allows developers to add new Layout slides in the presentation. To add a Layout Slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access the Master Slide collection.
1. Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not.
1. Add a new Layout slide if the desired layout is unavailable.
1. Add an empty slide with a newly added Layout slide.
1. Finally, write the presentation file using the Presentation object.

In the example given below, we have added Layout Slides to Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddLayoutSlides-AddLayoutSlides.cpp" >}}
## **Setting Default Zoom Value**
Aspose.Slides for C++ now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) of a presentation. [SlideViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/slideviewproperties) as well as [NotesViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/notesviewproperties) could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in Aspose.Slides.
### **Setting View Properties**
In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Set [View Properties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) of Presentation.
1. Write the presentation as a PPTX file.

In the example given below, we have set the zoom value for slide view as well as notes view.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetZoom-SetZoom.cpp" >}}
## **Setting the Slide Number**
Aspose.Slides for C++ now supports, setting the Slide Number. In this topic, we will see with an example how to get and set the slide number property in Aspose.Slides. The new methods added to [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) allows to get or to set the number of the first slide in a presentation. When a new [FirstSlideNumber](http://www.aspose.com/api/net/slides/aspose.slides/presentation/properties/firstslidenumber) value is specified all slide numbers are recalculated. In order to get or set the Slide Number, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Get the slide number.
1. Set the slide number.
1. Write the presentation as a PPTX file.

In the example given below, we have get and set the slide number.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetSlideNumber-SetSlideNumber.cpp" >}}
## **Opening a Presentation**
Using Aspose.Slides for C++, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

Aspose.Slides for C++ provides a [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class to create its object based on an existing presentation. In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of the  [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. After the file is opened, we get the total number of slides present in the presentation to print on the screen. The following example shows how to Open a Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-VerifyingPresentationWithoutloading-VerifyingPresentationWithoutloading.cpp" >}}
## **Opening Large Presentation**
Aspose.Slides for C++ provides a facility to open very large presentations using [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OpenVeryLargePresentation-OpenVeryLargePresentation.cpp" >}}
## **Opening a Password Protected Presentation**
Aspose.Slides for C++ provides a facility to open password protected presentation using [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. It offers few overloaded constructors and we can make use of one of the suitable constructors of the Presentation class to create its object based on an existing presentation. In the example given below, we are accessing the password protected presentation. We will use the [LoadOptions](http://www.aspose.com/api/net/slides/aspose.slides/loadoptions) class object to set the access [password](http://www.aspose.com/api/net/slides/aspose.slides/loadoptions/properties/password) and then will use the Presentation class to open a presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OpenPasswordPresentation-OpenPasswordPresentation.cpp" >}}
## **Verifying the presentation file before loading**
Aspose.Slides for C++ provides [PresentationFactory](http://www.aspose.com/api/net/slides/aspose.slides/presentationfactory) class that is used to get the file format before even loading.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-VerifyingPresentationWithoutloading-VerifyingPresentationWithoutloading.cpp" >}}
## **Retrieving File format**
In order to get the file format. Please follow the steps below:

1. Create an instance of [IPresentationInfo](http://www.aspose.com/api/net/slides/aspose.slides/ipresentationinfo/properties/index) class.
1. Get information about the presentation.

In the example given below, we have got the file format.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetFileFormat-GetFileFormat.cpp" >}}
## **Verifying File format**
In order to verify the file format. Please follow the steps below:

1. Create an instance of [IPresentationInfo](http://www.aspose.com/api/net/slides/aspose.slides/ipresentationinfo/properties/index) class.
1.  Check whether the presentation format is old Microsoft PowerPoint 95.

In the example given below, we have got the file format.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-LoadFormatEnumeration-LoadFormatEnumeration.cpp" >}}

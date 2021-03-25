---
title: Open Presentation
type: docs
weight: 30
url: /cpp/open-presentation/
---

## **Open Presentation**
Using Aspose.Slides for C++, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

Aspose.Slides for C++ provides a [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class to create its object based on an existing presentation. In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of the  [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. After the file is opened, we get the total number of slides present in the presentation to print on the screen. The following example shows how to Open a Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-VerifyingPresentationWithoutloading-VerifyingPresentationWithoutloading.cpp" >}}
## **Open Password Protected Presentation**
Aspose.Slides for C++ provides a facility to open password protected presentation using [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. It offers few overloaded constructors and we can make use of one of the suitable constructors of the Presentation class to create its object based on an existing presentation. In the example given below, we are accessing the password protected presentation. We will use the [LoadOptions](http://www.aspose.com/api/net/slides/aspose.slides/loadoptions) class object to set the access [password](http://www.aspose.com/api/net/slides/aspose.slides/loadoptions/properties/password) and then will use the Presentation class to open a presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OpenPasswordPresentation-OpenPasswordPresentation.cpp" >}}


## **Open Large Presentation**
Aspose.Slides for C++ provides a facility to open very large presentations using [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OpenVeryLargePresentation-OpenVeryLargePresentation.cpp" >}}


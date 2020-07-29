---
title: Opening a Presentation
type: docs
weight: 50
url: /java/opening-a-presentation/
---

{{% alert color="primary" %}} 

Using Aspose.Slides for Java, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

{{% /alert %}} 
## **Opening a Presentation**
Aspose.Slides for Java provides [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of Presentation class. After the file is opened, we get the total number of slides present in the presentation to print on the screen.



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-OpeningAPresentation-OpeningAPresentation.java" >}}
## **Opening a Password Protected Presentation**
Aspose.Slides for Java provides a facility to open password-protected presentation using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we are accessing the password-protected presentation. We will use [LoadOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/LoadOptionsOptions) class object to set the access password and then will use Presentation class to open a presentation.



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-OpeningAPasswordProtectedPresentation-OpeningAPasswordProtectedPresentation.java" >}}
## **Opening Large Presentation**
Aspose.Slides for Java provides a facility to open very large presentations using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-OpenVeryLargePresentation-OpenVeryLargePresentation.java" >}}
## **Accessing the Document Properties of a Password Protected Presentation without Password**
Aspose.Slides for Java provides a facility to access the **Document Properties** of the presentation in password-protected presentation without supplying password using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we are accessing the Document Properties of a password protected presentation. We will use [LoadOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/LoadOptions) class object to set the presentation access properties.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-AccessDocPropOfProtectedPresentationWithoutPassword-AccessDocPropOfProtectedPresentationWithoutPassword.java" >}}
## **Verifying the presentation file without even loading**
Aspose.Slides for Java provides [PresentationFactory](https://apireference.aspose.com/java/slides/com.aspose.slides/PresentationFactory) class that is used to get the file format before even loading that using Aspose.Slides for Java [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class object.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-VerifyingThePresentationFileWithoutEvenLoading-VerifyingThePresentationFileWithoutEvenLoading.java" >}}
## **Verifying File format**
In order to verify the file format. Please follow the steps below:

1. Create an instance of [IPresentationInfo](https://apireference.aspose.com/java/slides/com.aspose.slides/IPresentationInfo) class.
1. Check whether the presentation format is old Microsoft PowerPoint 95.

In the example given below, we have got the file format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-DetectionMicrosoftPowerPoint95presentations-DetectionMicrosoftPowerPoint95presentations.java" >}}


## **Load a Presentation**
New [**IResourceLoadingCallback**](https://apireference.aspose.com/java/slides/com.aspose.slides/IResourceLoadingCallback) interface has been added. This callback interface is used to manage external resources loading and has one method.

The code snippet below shows how to use IResourceLoadingCallback interface:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-LoadPresentation-LoadPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-LoadPresentation-IResourceLoadingCallback.java" >}}

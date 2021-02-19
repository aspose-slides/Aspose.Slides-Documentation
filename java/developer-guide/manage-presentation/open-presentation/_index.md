---
title: Open Presentation
type: docs
weight: 50
url: /java/open-presentation/
---

## **Overview**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

{{% /alert %}} 

## **Open Presentation**
Aspose.Slides for Java provides [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of Presentation class. After the file is opened, we get the total number of slides present in the presentation to print on the screen.


{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-OpeningAPresentation-OpeningAPresentation.java" >}}

## **Open Password Protected Presentation**
Aspose.Slides for Java provides a facility to open password-protected presentation using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we are accessing the password-protected presentation. We will use [LoadOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/LoadOptionsOptions) class object to set the access password and then will use Presentation class to open a presentation.



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-OpeningAPasswordProtectedPresentation-OpeningAPasswordProtectedPresentation.java" >}}

## **Open Large Presentation**
Aspose.Slides for Java provides a facility to open very large presentations using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-OpenVeryLargePresentation-OpenVeryLargePresentation.java" >}}

## **Load Presentation**
New [**IResourceLoadingCallback**](https://apireference.aspose.com/java/slides/com.aspose.slides/IResourceLoadingCallback) interface has been added. 
This callback interface is used to manage external resources loading and has one method.

The code snippet below shows how to use IResourceLoadingCallback interface:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-LoadPresentation-LoadPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-LoadPresentation-IResourceLoadingCallback.java" >}}

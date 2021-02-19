---
title: Save Presentation
type: docs
weight: 60
url: /java/save-presentation/
---

## **Overview**
{{% alert color="primary" %}} 

[Opening Presentation](/slides/java/opening-a-presentation/) described how to use the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class to open a presentation. This article explains how to create and save presentations.

{{% /alert %}} 

The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Java, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:

## **Save Presentation to File**
Save a presentation to file by calling the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class **Save** method. Simply pass the file name and **SaveFormat** to the **Save** method.

The examples that follow show how to save a presentation with Aspose.Slides for Java.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingAPresentation-SavingAPresentation.java" >}}

## **Save Presentation to Stream**
It is possible to save a presentation to a stream by passing an output stream to the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class **Save** method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SaveToStream-SaveToStream.java" >}}

## **Save Presentation with Predefined View Type**
Aspose.Slides for Java provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewProperties) class. The [**setLastView**](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewProperties#setLastView-int-) property is used to set the view type by using the [**ViewType**](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewType) enumerator.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavePresentationWithPredefinedViewType-SavePresentationWithPredefinedViewType.java" >}}

## **Save Presentation to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the [**PptxOptions** ](https://apireference.aspose.com/java/slides/com.aspose.slides/pptxoptions)class where you can set the Conformance property while saving the presentation file. If you set its value as [**Conformance.Iso29500_2008_Strict**](https://apireference.aspose.com/java/slides/com.aspose.slides/Conformance#Iso29500_2008_Strict), then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the **PptxOptions** object is passed into it with the Conformance property set as **Conformance.Iso29500_2008_Strict**.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SaveToStrictOpenXML-SaveToStrictOpenXML.java" >}}

## **Save Progress Updates in Percentage**
New [**IProgressCallback**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProgressCallback) interface has been added to [**ISaveOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISaveOptions) interface and [**SaveOptions** ](https://apireference.aspose.com/java/slides/com.aspose.slides/SaveOptions)abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.  

The following code snippets below show how to use IProgressCallback interface:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-CovertToPDFWithProgressUpdate-ExportProgressHandler.java" >}}

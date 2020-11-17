---
title: Save Presentation
type: docs
weight: 40
url: /net/save-presentation/
---

## **Save Presentation**
Opening a Presentation described how to use the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to open a presentation. This article explains how to create and save presentations.
The [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for .NET, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:
### **Save Presentation to File**
Save a presentation to files by calling the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. Simply pass the file name and save format to the [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. The examples that follow show how to save a presentation with Aspose.Slides for .NET using C#.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Saving-SaveToFile-SaveToFile.cs" >}}
### **Save Presentation to Stream**
It is possible to save a presentation to a stream by passing an output stream to the  [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Saving-SaveToStream-SaveToStream.cs" >}}
### **Save Presentation with Predefined View Type**
Aspose.Slides for .NET provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](https://apireference.aspose.com/net/slides/aspose.slides/viewproperties) class. The [LastView](https://apireference.aspose.com/net/slides/aspose.slides/viewproperties/properties/lastview) property is used to set the view type by using the [ViewType](https://apireference.aspose.com/net/slides/aspose.slides/viewtype) enumerator.

{{< gist "aspose-slides" "53249e5573Convert SVG Images Into Groud2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Saving-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cs" >}}
### **Save Presentation to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the [**Aspose.Slides.Export.PptxOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pptxoptions) class where you can set the Conformance property, while saving the presentation file. If you set its value as Conformance.Iso29500_2008_Strict, then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the  **[Aspose.Slides.Export.PptxOptions](https://apireference.aspose.com/net/slides/aspose.slides.export/pptxoptions)** object is passed into it with the [**Conformance** ](https://apireference.aspose.com/net/slides/aspose.slides.export/pptxoptions/properties/conformance)property set as [**Conformance.Iso29500_2008_Strict**](https://apireference.aspose.com/net/slides/aspose.slides.export/conformance).



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Saving-SaveToStrictOpenXML-SaveToStrictOpenXML.cs" >}}
### **Saving Progress Updates in Percentage**
New [**IProgressCallback** ](https://apireference.aspose.com/net/slides/aspose.slides/iprogresscallback)interface has been added to [**ISaveOptions** ](https://apireference.aspose.com/net/slides/aspose.slides.export/isaveoptions)interface and [**SaveOptions** ](https://apireference.aspose.com/net/slides/aspose.slides.export/saveoptions)abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.

The following code snippets below shows how to use IProgressCallback interface:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-CovertToPDFWithProgressUpdate-ExportProgressHandler.cs" >}}

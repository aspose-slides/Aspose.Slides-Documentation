---
title: Saving, Printing and Managing
type: docs
weight: 40
url: /net/saving-printing-and-managing/
---

## **Saving a Presentation**
Opening a Presentation described how to use the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to open a presentation. This article explains how to create and save presentations.
The [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for .NET, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:
### **Save to File**
Save a presentation to files by calling the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. Simply pass the file name and save format to the [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. The examples that follow show how to save a presentation with Aspose.Slides for .NET using C#.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Saving-SaveToFile-SaveToFile.cs" >}}
### **Save to Stream**
It is possible to save a presentation to a stream by passing an output stream to the  [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Saving-SaveToStream-SaveToStream.cs" >}}
### **Save with predefined View Type**
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
## **Printing and Setting a Presentation**
Aspose.Slides for .NET provides four overloads methods for the printing of the presentations. These methods are flexible enough to print the presentation to the default printer or to any of the available printers with customized settings. You only need to select the appropriate print method according to the requirement.
### **Printing to Default Printer**
Printing of the presentation to the default printer is quite simple in Aspose.Slides for .NET. Perform the following steps in order to print the presentation to default printer:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to load a presentation that is to be printed
1. Call the [Print method](https://apireference.aspose.com/net/slides/aspose.slides.ipresentation/print/methods/1) with no parameters as exposed by the Presentation object

In the example given below, we have call the Print method with no parameters.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-DefaultPrinterPrinting-DefaultPrinterPrinting.cs" >}}
### **Setting print options dynamically**
Aspose.Slides provides support for setting the print presentation dynamically with options involving setting Margin, Print copies and also provide an option to preview print setting dialog. To setup printer settings use an instance of [**System.Drawing.Printing.PrinterSettings**](https://apireference.aspose.com/cpp/slides/class/system.drawing.printing.printer_settings/) class. Perform the following steps in order to print the presentation, set print option like Margin, Print copies and also you can set print option dynamically.

1. Create an instance of [**Presentation**](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to load a presentation that is to be printed
1. Instantiate printer setting object to represent print settings.
1. Set number of copies to be printed.
1. Set orientation of page.
1. Set margin for a page.
1. Print preview and print setting dialog.

In the example given below, we have called the Print method with no parameters.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-PrintPreview-PrintPreview.cs" >}}
### **Printing to Specific Printer**
Printing of the presentation to the specific printer requires the name of the printer as a parameter to the [**Print**](https://apireference.aspose.com/net/slides/aspose.slides.ipresentation/print/methods/1) method of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation). Perform the following steps in order to print the presentation to the desired printer:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to load a presentation that is to be printed.
1. Call the [Print method](https://apireference.aspose.com/net/slides/aspose.slides.ipresentation/print/methods/1) of the Presentation class with the printer name as a string parameter to the Print method.

In the example given below, we have called the Print method with the printer name as a string parameter to the Print method.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-SpecificPrinterPrinting-SpecificPrinterPrinting.cs" >}}
### **Setting Default Zoom Value**
Aspose.Slides for .NET now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [**ViewProperties**](https://apireference.aspose.com/net/slides/aspose.slides/viewproperties) of a presentation. Slide View Properties as well as [NotesViewProperties](https://apireference.aspose.com/net/slides/aspose.slides/viewproperties/properties/notesviewproperties) could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in Aspose.Slides.

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class
1. Set View [Properties](https://apireference.aspose.com/net/slides/aspose.slides/viewproperties) of Presentation
1. Write the presentation as a PPTX file

In the example given below, we have set the zoom value for slide view as well as notes view.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-SetZoom-SetZoom.cs" >}}
### **Setting Slide Numbers**
Aspose.Slides for .NET supports setting the Slide Number. In this topic, we will see with an example how to get and set the slide number property in Aspose.Slides. The new property [**FirstSlideNumber**](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/firstslidenumber) added to [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) allows to get or to set the number of the first slide in a presentation. When a new [FirstSlideNumber](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/firstslidenumber) value is specified all slide numbers are recalculated. In order to set the Slide Number, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Get the slide number.
1. Set the slide number.
1. Write the presentation as a PPTX file.

In the example given below, we have get and set the slide number property.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-SetSlideNumber-SetSlideNumber.cs" >}}
## **Add Blob in Presentations**
[Aspose.Slides](/slides/net/home/) for .NET provides a facility to add large files (video file in that case) and prevent a high memory consumption. An example is given below that shows how to add Blob in presentations.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddBlobToPresentation-AddBlobToPresentation.cs" >}}
## **Export Blob from Presentations**
Aspose.Slides for .NET provides a facility to Export large files (audio and video file in that case). We want to extract these files from the presentation and do not want to load this presentation into memory to keep our memory consumption low. Here is an example is given below how we can export blob from presentations.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ExportBlobFromPresentation-ExportBlobFromPresentation.cs" >}}
## **Check if Presentation is Modified or Created**
Aspose.Slides for .NET provides a facility to check if a presentation is modified or created. An example is given below that shows how to check if the presentation is created or modified.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}
## **Support for adding EMZ image to Images collection**
Aspose.Slides for .NET provides a facility to embed EMZ file inside a presentation images collection. An example is given below that shows how to add EMZ image to images collection.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddingEMZImagesToImageCollection-AddingEMZImagesToImageCollection.cs" >}}
## **Render comments when saving Presentation into Image**
Aspose.Slides for .NET provides a facility to render comments of presentations or slide when converting those into images.  An example is given below that shows how to render comments of presentation into an image.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-RenderComments-RenderComments.cs" >}}
## **Support for rendering emoji characters**
Aspose.Slides for .NET provides a facility to render emoji characters of presentations or slide when converting those into [PDF](https://wiki.fileformat.com/view/pdf/), image, [XPS](https://wiki.fileformat.com/page-description-language/xps/) or [SWF](https://wiki.fileformat.com/page-description-language/swf/).  An example is given below that shows how to render emoji characters of presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-RenderingEmoji-RenderingEmoji.cs" >}}


## **Add an Image From SVG Object**
Aspose.Slides for .NET added new [**AddImage** ](https://apireference.aspose.com/net/slides/aspose.slides/imagecollection/methods/addimage/index)method to **[IImageCollection **interface**](https://apireference.aspose.com/net/slides/aspose.slides/iimagecollection)** and [**ImageCollection class**](https://apireference.aspose.com/net/slides/aspose.slides/imagecollection)**.** These methods provide the ability to insert SVG fragments to the presentation image collection.

The code sample below shows how to insert SVG fragments to the presentation image collection.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Saving-AddImageFromSVGObject-AddImageFromSVGObject.cs" >}}

The following code shows how to insert SVG fragments to the presentation image collection from an external resource.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Saving-AddImageFromSVGObjectFromExternalResource-AddImageFromSVGObjectFromExternalResource.cs" >}}
## **Convert SVG Images Into Group Shape**
New [**AddGroupShape** ](https://apireference.aspose.com/net/slides/aspose.slides/shapecollection/methods/addgroupshape)method has been added to **[IShapeCollection](https://apireference.aspose.com/net/slides/aspose.slides/ishapecollection) interface** and [**ShapeCollection** ](https://apireference.aspose.com/net/slides/aspose.slides/shapecollection)**class** in Aspose.Slides for .NET. This method allows to convert [**SvgImage**](https://apireference.aspose.com/net/slides/aspose.slides/svgimage) object that represents SVG data into a group of shapes.

The code sample below shows how to convert SVG images into a group of shapes.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Saving-ConvertSvgImageObjectIntoGroupOfShapes-ConvertSvgImageObjectIntoGroupOfShapes.cs" >}}


## **Add Image as BLOB in Presentation**
Aspose.Slides for .NET added a new method to [**IImageCollection**](https://apireference.aspose.com/net/slides/aspose.slides/iimagecollection) interface and [**ImageCollection** ](https://apireference.aspose.com/net/slides/aspose.slides/imagecollection)class to support adding a large image as streams to treat them as BLOBs.

This example demonstrates how to include the large BLOB (image) and prevent high memory consumption.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Saving-AddBlobImageToPresentation-AddBlobImageToPresentation.cs" >}}




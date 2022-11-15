---
title: Save Presentation in .NET
linktitle: Save Presentation
type: docs
weight: 80
url: /net/save-presentation/
keywords: "Save PowerPoint, PPT, PPTX, Save Presentation, file, stream, C#, Csharp, .NET"
description: "Save PowerPoint Presentation as file or stream in C# or .NET"
---

## Overview

This article is part of the following two articles.

- [Open Presentation](https://docs.aspose.com/slides/net/open-presentation/)
- [Save Presentation](https://docs.aspose.com/slides/net/save-presentation/)

<strong>Topics Covered</strong>

The above articles together cover such topics. e.g.

- [C# Convert PPT to PDF](#csharp-open-save-presentation)
- [C# Convert PPTX to XPS](#csharp-open-save-presentation)
- [C# PPTX to ODP Code](#csharp-open-save-presentation)
- [See Also](#see-also)

## **Save Presentation**
Opening a Presentation described how to use the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to open a presentation. This article explains how to create and save presentations.
The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for .NET, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:

### **Saving Presentation to Files**
Save a presentation to files by calling the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method. Simply pass the file name and save format to the [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method. The examples that follow show how to save a presentation with Aspose.Slides for .NET using C#.

```c#
// Instantiate a Presentation object that represents a PPT file
Presentation presentation= new Presentation();

//...do some work here...

// Save your presentation to a file
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **Saving Presentation to Streams**
It is possible to save a presentation to a stream by passing an output stream to the  [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

```c#
// Instantiate a Presentation object that represents a PPT file
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Add text to shape
    shape.TextFrame.Text = "This demo shows how to Create PowerPoint file and save it to Stream.";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```


### **Saving Presentations with Predefined View Type**
Aspose.Slides for .NET provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) class. The [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview) property is used to set the view type by using the [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype) enumerator.

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **Saving Presentations to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the [**Aspose.Slides.Export.PptxOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions) class where you can set the Conformance property, while saving the presentation file. If you set its value as Conformance.Iso29500_2008_Strict, then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the  **[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)** object is passed into it with the [**Conformance** ](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance)property set as [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/net/aspose.slides.export/conformance).



```c#
   // Instantiate a Presentation object that represents a presentation file
   using (Presentation presentation = new Presentation())
   {
       // Get the first slide
       ISlide slide = presentation.Slides[0];

       // Add an autoshape of type line
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // Save the presentation to Strict Open XML Format
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });

   }

```


### **Saving Progress Updates in Percentage**
New [**IProgressCallback** ](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback)interface has been added to [**ISaveOptions** ](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions)interface and [**SaveOptions** ](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions)abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.

The following code snippets below shows how to use IProgressCallback interface:

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}

```



```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Use progress percentage value here
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "% file converted");
    }
}
```



{{% alert title="Info" color="info" %}}

Using its own API, Aspose developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) that allows users to split their presentations into multiple files. Essentially, the app saves selected slides from a given presentation as new PowerPoint (PPTX or PPT) files. 

{{% /alert %}}

<h2>Open and Save Presentation</h2>

<a name="csharp-open-save-presentation"><strong>Steps: Open and Save Presentation in C#</strong></a>

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class with any format i.e. PPT, PPTX, ODP etc.
2. Save _Presentation_ to any format supported by [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Load any supported file in Presentation e.g. ppt, pptx, odp etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## See Also 

This article also covers these topics. The codes are same as above.

_Format_: **PPTX**
- [C# PPTX to PPT](#csharp-open-save-presentation)
- [C# PPTX to ODP](#csharp-open-save-presentation)
- [C# PPTX to PPS](#csharp-open-save-presentation)
- [C# PPTX to PDF](#csharp-open-save-presentation)
- [C# PPTX to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert PPTX to PPT](#csharp-open-save-presentation)
- [C# Convert PPTX to ODP](#csharp-open-save-presentation)
- [C# Convert PPTX to PPS](#csharp-open-save-presentation)
- [C# Convert PPTX to PDF](#csharp-open-save-presentation)
- [C# Convert PPTX to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# PPTX to PPT Programmatically](#csharp-open-save-presentation)
- [C# PPTX to ODP Programmatically](#csharp-open-save-presentation)
- [C# PPTX to PPS Programmatically](#csharp-open-save-presentation)
- [C# PPTX to PDF Programmatically](#csharp-open-save-presentation)
- [C# PPTX to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# PPTX to PPT API](#csharp-open-save-presentation)
- [C# PPTX to ODP API](#csharp-open-save-presentation)
- [C# PPTX to PPS API](#csharp-open-save-presentation)
- [C# PPTX to PDF API](#csharp-open-save-presentation)
- [C# PPTX to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# PPTX to PPT Code](#csharp-open-save-presentation)
- [C# PPTX to ODP Code](#csharp-open-save-presentation)
- [C# PPTX to PPS Code](#csharp-open-save-presentation)
- [C# PPTX to PDF Code](#csharp-open-save-presentation)
- [C# PPTX to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# PPTX to PPT Library](#csharp-open-save-presentation)
- [C# PPTX to ODP Library](#csharp-open-save-presentation)
- [C# PPTX to PPS Library](#csharp-open-save-presentation)
- [C# PPTX to PDF Library](#csharp-open-save-presentation)
- [C# PPTX to XPS Library](#csharp-open-save-presentation)

_Format_: **PPT**
- [C# PPT to PPTX](#csharp-open-save-presentation)
- [C# PPT to ODP](#csharp-open-save-presentation)
- [C# PPT to PPS](#csharp-open-save-presentation)
- [C# PPT to PDF](#csharp-open-save-presentation)
- [C# PPT to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert PPT to PPTX](#csharp-open-save-presentation)
- [C# Convert PPT to ODP](#csharp-open-save-presentation)
- [C# Convert PPT to PPS](#csharp-open-save-presentation)
- [C# Convert PPT to PDF](#csharp-open-save-presentation)
- [C# Convert PPT to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# PPT to PPTX Programmatically](#csharp-open-save-presentation)
- [C# PPT to ODP Programmatically](#csharp-open-save-presentation)
- [C# PPT to PPS Programmatically](#csharp-open-save-presentation)
- [C# PPT to PDF Programmatically](#csharp-open-save-presentation)
- [C# PPT to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# PPT to PPTX API](#csharp-open-save-presentation)
- [C# PPT to ODP API](#csharp-open-save-presentation)
- [C# PPT to PPS API](#csharp-open-save-presentation)
- [C# PPT to PDF API](#csharp-open-save-presentation)
- [C# PPT to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# PPT to PPTX Code](#csharp-open-save-presentation)
- [C# PPT to ODP Code](#csharp-open-save-presentation)
- [C# PPT to PPS Code](#csharp-open-save-presentation)
- [C# PPT to PDF Code](#csharp-open-save-presentation)
- [C# PPT to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# PPT to PPTX Library](#csharp-open-save-presentation)
- [C# PPT to ODP Library](#csharp-open-save-presentation)
- [C# PPT to PPS Library](#csharp-open-save-presentation)
- [C# PPT to PDF Library](#csharp-open-save-presentation)
- [C# PPT to XPS Library](#csharp-open-save-presentation)

_Format_: **ODP**
- [C# ODP to PPTX](#csharp-open-save-presentation)
- [C# ODP to PPT](#csharp-open-save-presentation)
- [C# ODP to PPS](#csharp-open-save-presentation)
- [C# ODP to PDF](#csharp-open-save-presentation)
- [C# ODP to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert ODP to PPTX](#csharp-open-save-presentation)
- [C# Convert ODP to PPT](#csharp-open-save-presentation)
- [C# Convert ODP to PPS](#csharp-open-save-presentation)
- [C# Convert ODP to PDF](#csharp-open-save-presentation)
- [C# Convert ODP to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# ODP to PPTX Programmatically](#csharp-open-save-presentation)
- [C# ODP to PPT Programmatically](#csharp-open-save-presentation)
- [C# ODP to PPS Programmatically](#csharp-open-save-presentation)
- [C# ODP to PDF Programmatically](#csharp-open-save-presentation)
- [C# ODP to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# ODP to PPTX API](#csharp-open-save-presentation)
- [C# ODP to PPT API](#csharp-open-save-presentation)
- [C# ODP to PPS API](#csharp-open-save-presentation)
- [C# ODP to PDF API](#csharp-open-save-presentation)
- [C# ODP to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# ODP to PPTX Code](#csharp-open-save-presentation)
- [C# ODP to PPT Code](#csharp-open-save-presentation)
- [C# ODP to PPS Code](#csharp-open-save-presentation)
- [C# ODP to PDF Code](#csharp-open-save-presentation)
- [C# ODP to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# ODP to PPTX Library](#csharp-open-save-presentation)
- [C# ODP to PPT Library](#csharp-open-save-presentation)
- [C# ODP to PPS Library](#csharp-open-save-presentation)
- [C# ODP to PDF Library](#csharp-open-save-presentation)
- [C# ODP to XPS Library](#csharp-open-save-presentation)

---
title: Save Presentation in .NET
linktitle: Save Presentation
type: docs
weight: 80
url: /net/save-presentation/
keywords: "Save PowerPoint, PPT, PPTX, Save Presentation, file, stream, C#, Csharp, .NET"
description: "Save PowerPoint Presentation as file or stream in C# or .NET"
---

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

### **Saving Presentations to Open XML format in Zip64 mode**
An Open XML file is a ZIP-archive that has a 4 GB (2^32 bytes) limit on uncompressed size of a file, compressed size of a file, and total size of the archive, as well as a limit of 65,535 (2^16-1) files in the archive. ZIP64 format extensions increase the limits to 2^64.

The new [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) property allows you to choose when to use ZIP64 format extensions for the saved Open XML file.

This property provides the following modes:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) means that ZIP64 format extensions will only be used if the presentation falls outside the above limitations. This is the default mode.
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) means that ZIP64 format extensions will not be used. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) means that ZIP64 format extensions will always be used.

The following C# code demonstrates how to save the presentation to PPTX format with ZIP64 format extensions:

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}

Saving in the Zip64Mode.Never mode will throw a [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) if the presentation cannot be saved in ZIP32 format.

{{% /alert %}}

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

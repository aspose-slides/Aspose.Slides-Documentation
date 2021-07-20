---
title: Save Presentation
type: docs
weight: 70
url: /net/save-presentation/
---

## **Save Presentation**
Opening a Presentation described how to use the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to open a presentation. This article explains how to create and save presentations.
The [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for .NET, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:
### **Saving Presentation to Files**
Save a presentation to files by calling the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. Simply pass the file name and save format to the [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. The examples that follow show how to save a presentation with Aspose.Slides for .NET using C#.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationSaving();

// Create directory if it is not already present.
bool IsExists = System.IO.Directory.Exists(dataDir);
if (!IsExists)
    System.IO.Directory.CreateDirectory(dataDir);

// Instantiate a Presentation object that represents a PPT file
Presentation presentation= new Presentation();

//...do some work here...

// Save your presentation to a file
presentation.Save(dataDir + "Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **Saving Presentation to Streams**
It is possible to save a presentation to a stream by passing an output stream to the  [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationSaving();

// Instantiate a Presentation object that represents a PPT file
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Add text to shape
    shape.TextFrame.Text = "This demo shows how to Create PowerPoint file and save it to Stream.";

    FileStream toStream = new FileStream(dataDir + "Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```


### **Saving Presentations with Predefined View Type**
Aspose.Slides for .NET provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](https://apireference.aspose.com/net/slides/aspose.slides/viewproperties) class. The [LastView](https://apireference.aspose.com/net/slides/aspose.slides/viewproperties/properties/lastview) property is used to set the view type by using the [ViewType](https://apireference.aspose.com/net/slides/aspose.slides/viewtype) enumerator.

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **Saving Presentations to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the [**Aspose.Slides.Export.PptxOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pptxoptions) class where you can set the Conformance property, while saving the presentation file. If you set its value as Conformance.Iso29500_2008_Strict, then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the  **[Aspose.Slides.Export.PptxOptions](https://apireference.aspose.com/net/slides/aspose.slides.export/pptxoptions)** object is passed into it with the [**Conformance** ](https://apireference.aspose.com/net/slides/aspose.slides.export/pptxoptions/properties/conformance)property set as [**Conformance.Iso29500_2008_Strict**](https://apireference.aspose.com/net/slides/aspose.slides.export/conformance).



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
New [**IProgressCallback** ](https://apireference.aspose.com/net/slides/aspose.slides/iprogresscallback)interface has been added to [**ISaveOptions** ](https://apireference.aspose.com/net/slides/aspose.slides.export/isaveoptions)interface and [**SaveOptions** ](https://apireference.aspose.com/net/slides/aspose.slides.export/saveoptions)abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.

The following code snippets below shows how to use IProgressCallback interface:

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Conversion();

using (Presentation presentation = new Presentation(dataDir + "ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save(dataDir + "ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
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


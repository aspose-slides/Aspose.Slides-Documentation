---
title: Save Presentation
type: docs
weight: 80
url: /pythonnet/save-presentation/
keywords: "Save PowerPoint, PPT, PPTX, Save Presentation, file, stream, Python"
description: "Save PowerPoint Presentation as file or stream in Python"
---

## **Save Presentation**
Opening a Presentation described how to use the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class to open a presentation. This article explains how to create and save presentations.
The [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Python via .NET, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:

### **Saving Presentation to Files**
Save a presentation to files by calling the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class [save](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation/methods/save/index) method. Simply pass the file name and save format to the [save](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation/methods/save/index) method. The examples that follow show how to save a presentation with Aspose.Slides for Python via .NET using Python.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
with slides.Presentation() as presentation:
    
    #...do some work here...

    # Save your presentation to a file
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Saving Presentation to Streams**
It is possible to save a presentation to a stream by passing an output stream to the  [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # Save your presentation to a stream
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **Saving Presentations with Predefined View Type**
Aspose.Slides for Python via .NET provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [view_properties](https://apireference.aspose.com/slides/pythonnet/aspose.slides/viewproperties) class. The [last_view](https://apireference.aspose.com/slides/pythonnet/aspose.slides/viewproperties/properties/lastview) property is used to set the view type by using the [ViewType](https://apireference.aspose.com/slides/pythonnet/aspose.slides/viewtype) enumerator.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **Saving Presentations to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the [**PptxOptions**](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/pptxoptions) class where you can set the Conformance property, while saving the presentation file. If you set its value as Conformance.Iso29500_2008_Strict, then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the  **[PptxOptions](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/pptxoptions)** object is passed into it with the [**Conformance** ](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/pptxoptions/properties/conformance)property set as [**Conformance.Iso29500_2008_Strict**](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/conformance).



```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation() as presentation:
    # Get the first slide
    slide = presentation.slides[0]

    #Add an autoshape of type line
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # Save the presentation to Strict Open XML Format
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **Saving Progress Updates in Percentage**
New [**IProgressCallback** ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/iprogresscallback)interface has been added to [**ISaveOptions** ](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/isaveoptions)interface and [**SaveOptions** ](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/saveoptions)abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.

The following code snippets below shows how to use IProgressCallback interface:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

{{% alert title="Info" color="info" %}}

Using its own API, Aspose developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) that allows users to split their presentations into multiple files. Essentially, the app saves selected slides from a given presentation as new PowerPoint (PPTX or PPT) files. 

{{% /alert %}}


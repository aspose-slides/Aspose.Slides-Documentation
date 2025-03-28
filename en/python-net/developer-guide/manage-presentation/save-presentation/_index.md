---
title: Save Presentation
type: docs
weight: 80
url: /python-net/save-presentation/
keywords: "Save PowerPoint, PPT, PPTX, Save Presentation, file, stream, Python"
description: "Save PowerPoint Presentation as file or stream in Python"
---

## **Save Presentation**
Opening a Presentation described how to use the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class to open a presentation. This article explains how to create and save presentations.
The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Python via .NET, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:

### **Saving Presentation to Files**
Save a presentation to files by calling the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method. Simply pass the file name and save format to the [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method. The examples that follow show how to save a presentation with Aspose.Slides for Python via .NET using Python.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
with slides.Presentation() as presentation:
    
    #...do some work here...

    # Save your presentation to a file
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Saving Presentation to Streams**
It is possible to save a presentation to a stream by passing an output stream to the  [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

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
Aspose.Slides for Python via .NET provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) class. The [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) property is used to set the view type by using the [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) enumerator.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **Saving Presentations to Strict Office Open XML Format**
Aspose.Slides allows you to save the presentation in Strict Office Open XML format. For that purpose, it provides the [**PptxOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) class where you can set the Conformance property, while saving the presentation file. If you set its value as Conformance.Iso29500_2008_Strict, then the output presentation file will be saved in Strict Office Open XML format.

The following sample code creates a presentation and saves it in the Strict Office Open XML Format. While calling the Save method for the presentation, the  **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** object is passed into it with the [**Conformance** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)property set as [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/).



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

    # Save the presentation to Strict Office Open XML Format
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```

### **Saving a Presentation without Refreshing the Thumbnail**

The [**PptxOptions.refresh_thumbnail**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) property allows you to control the generation of the thumbnail when saving a presentation in PPTX format:

- When the property value is **True**, the presentation thumbnail will be refreshed while saving. This is the *default* value.
- When the property value is **False**, the current thumbnail will be saved as is. If the presentation doesn't have a thumbnail, no thumbnail will be generated.

In the code below, we saved the presentation to PPTX format without refreshing its thumbnail:

```py
with slides.Presentation("Sample.pptx") as presentation:
    
    pptx_options = slides.export.PptxOptions()
    pptx_options.refresh_thumbnail = False
    
    presentation.save("Sample_with_old_thumbnail.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}

This option allows you to save time when saving a presentation in PPTX format.

{{% /alert %}}

### **Saving Progress Updates in Percentage**
New [**IProgressCallback** ](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/)interface has been added to [**ISaveOptions** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/)interface and [**SaveOptions** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/)abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.

The following code snippets below shows how to use IProgressCallback interface:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

{{% alert title="Info" color="info" %}}

Using its own API, Aspose developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) that allows users to split their presentations into multiple files. Essentially, the app saves selected slides from a given presentation as new PowerPoint (PPTX or PPT) files. 

{{% /alert %}}


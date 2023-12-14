---
title: Open Presentation
type: docs
weight: 20
url: /python-net/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, Python"
description: "Open or load Presentation PPT, PPTX, ODP in Python"
---

Besides creating PowerPoint presentations from scratch, Aspose.Slides allows you to open existing presentations. After you load a presentation, you can get information about the presentation, edit the presentation (content on its slides), add new slides or remove existing ones, etc. 

## Open Presentation

To open an existing presentation, you simply have to instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the file path (of the presentation you want to open) to its contructor. 

This Python code shows you how to open a presentation and also find out the number of slides it contains: 

```python
import aspose.slides as slides

# Instantiates the Presentation class and passes the file path to its constructor
with slides.Presentation("pres.pptx") as pres:
    # Prints the total number of slides present in the presentation
    print(pres.slides.length)
```

## **Open Password Protected Presentation**

When you have to open a password-protected presentation, you can pass the password through the `password` property (from the [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) class) to decrypt the presentation and load the presentation. This Python code demonstrates the operation: xxx 

```python

```

## Open Large Presentation

Aspose.Slides provides options (the `blob_management_options` property in particular) under the [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) class to allow you to load large presentations. 

This Python demonstrates an operation in which a large presentation (say 2gb in size) is loaded:

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # The large presentation has been loaded and can be used, but the memory consumption is still low.

    # Makes changes to the presentation.
    pres.slides[0].name = "Very large presentation"

    # The presentation will be saved to the other file. The memory consumption stays low during the operation
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # can't do that! IO exception will be thrown because the file is locked while pres objects will
    # not be disposed
    os.remove("pres.pptx")

# It is ok to do it here. The source file is not locked by the pres object.
os.remove("pres.pptx")
```

{{% alert color="info" title="Info" %}}

When you want create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/python-net/manage-blob/) to reduce memory consumption.

{{%/alert %}} 


## Load Presentation

Aspose.Slides provides [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) with a single method to allow you to manage external resources. This Python code shows you how to use the `IResourceLoadingCallback` interface:

```python
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

<h2>Open and Save Presentation</h2>

<a name="python-net-open-save-presentation"><strong>Steps: Open and Save Presentation in Python</strong></a>

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the file you want to open. 
2. Save the presentation. 

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
with slides.Presentation() as presentation:
    
    #...do some work here...

    # Save your presentation to a file
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


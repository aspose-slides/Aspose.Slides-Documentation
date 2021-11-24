---
title: Open Presentation
type: docs
weight: 20
url: /pythonnet/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, Python"
description: "Open and load PowerPoint presentation in Python"
---

## **Open Presentation**
Using Aspose.Slides for Python via .NET, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

Aspose.Slides for Python via .NET provides Presentation class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of Presentation class. After the file is opened, we get the total number of slides present in the presentation to print on the screen. The following example shows how to Open a Presentation.

```py
import aspose.slides as slides

# Opening the presentation file by passing the file path to the constructor of Presentation class
with slides.Presentation("pres.pptx") as pres:
    # Printing the total number of slides present in the presentation
    print(pres.slides.length)
```



## **Open Large Presentation**
Aspose.Slides for Python via .NET provides facility to open very large presentations using Presentation class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

```py
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # the huge presentation is loaded and ready to use, but the memory consumption is still low.

    # make any changes to the presentation.
    pres.slides[0].name = "Very large presentation"

    # presentation will be saved to the other file, the memory consumptions still low during saving.
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # can't do that! IO exception will be thrown, because the file is locked while pres objects will
    # not be disposed
    os.remove("pres.pptx")

# it's ok to do it here, the source file is not locked by pres object
os.remove("pres.pptx")
```



{{% alert color="info" title="Info" %}}When you have to create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/pythonnet/manage-blob/) to reduce memory consumption.{{%/alert %}} 


## **Load Presentation**
New IResourceLoadingCallback interface has been added. This callback interface is used to manage external resources loading and has one method:

The code snippet below shows how to use IResourceLoadingCallback interface:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```


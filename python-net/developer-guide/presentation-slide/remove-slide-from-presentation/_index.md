---
title: Remove Slide from Presentation
type: docs
weight: 30
url: /python-net/remove-slide-from-presentation/
keywords: "Remove slide, Delete slide, PowerPoint, Presentation, Python, Aspose.Slides"
description: "Remove slide from PowerPoint by reference or index in Python"
---

## Overview
Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for Python via .NET offers few methods to do so. In this topic, we will explore these methods to accomplish this task. We know that [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class in Aspose.Slides for Python via .NET represents a presentation file. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class encapsulates a [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this Slides collection in two ways:

1. Using Slide Reference
1. Using Slide Index
## **Remove Slide by Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its Id or Index.
1. Remove the referenced slide from the presentation.
1. Write the modified presentation file.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "RemoveSlideUsingReference.pptx") as pres:
    # Accessing a slide using its index in the slides collection
    slide = pres.slides[0]

    # Removing a slide using its reference
    pres.slides.remove(slide)

    #Writing the presentation file
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Remove Slide by Index**
To remove a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Remove the slide from the presentation by using its index position.
1. Write the modified presentation file.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "RemoveSlideUsingIndex.pptx") as pres:
    # Removing a slide using its slide index
    pres.slides.remove_at(0)

    # Writing the presentation file
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```


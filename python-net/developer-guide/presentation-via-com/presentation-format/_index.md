---
title: Presentation Format
type: docs
weight: 10
url: /python-net/presentation-format/
---

Aspose.Slides for Python via .NET provides [**PresentationFactory** ](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/)class that is used to get the presentation format before even loading.

In order to get presentation format. Please follow the steps below:

1. Create an instance of [**IPresentationInfo** ](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/)class.
1. Get information about the presentation format.

In the example given below, we have got the presentation format:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```



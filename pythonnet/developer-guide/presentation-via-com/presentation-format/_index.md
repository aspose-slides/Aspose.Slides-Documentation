---
title: Presentation Format
type: docs
weight: 10
url: /pythonnet/presentation-format/
---

Aspose.Slides for Python via .NET provides [**PresentationFactory** ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentationfactory)class that is used to get the presentation format before even loading.

In order to get presentation format. Please follow the steps below:

1. Create an instance of [**IPresentationInfo** ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/ipresentationinfo)class.
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



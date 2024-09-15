---
title: Presentation Format
type: docs
weight: 10
url: /net/presentation-format/
---

Aspose.Slides for .NET provides [**PresentationFactory** ](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory)class that is used to get the presentation format before even loading.

In order to get presentation format. Please follow the steps below:

1. Create an instance of [**IPresentationInfo** ](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo)class.
1. Get information about the presentation format.

In the example given below, we have got the presentation format:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("HelloWorld.pptx");
switch (info.LoadFormat)
{
    case LoadFormat.Pptx:
        {
            break;
        }

    case LoadFormat.Unknown:
        {
            break;
        }
}
```



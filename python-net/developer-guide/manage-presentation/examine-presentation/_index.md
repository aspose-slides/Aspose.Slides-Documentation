---
title: Examine Presentation
type: docs
weight: 30
url: /python-net/examine-presentation/
keywords: "Check PowerPoint, PPTX, PPT, Check Presentation, PowerPoint Properties, Presentation Properties, Python"
description: "Check and get PowerPoint Presentation Properties in Python"
---

Aspose.Slides for Python via .NET allows you to examine a presentation to find out its properties and understand its behavior. 

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://apireference.aspose.com/slides/python-net/aspose.slides/presentationinfo) class contains most of the properties and methods needed for operations here. 

{{% /alert %}} 

## **Checking a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this sample code:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Getting the Properties of a Presentation**

This sample code in Python shows you how to get a presentation’s properties (information about the presentation):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

## **Updating the Properties of a Presentation**

Aspose.Slides provides the [PresentationInfoUpdateDocumentProperties](https://apireference.aspose.com/slides/python-net/aspose.slides/presentationinfo/methods/updatedocumentproperties) method that allows you to make changes to a presentation’s properties.

This sample code shows you how to edit the properties for a presentation in Python:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.title)

props.title = "My title"
info.update_document_properties(props)

print(props.title)
```

### **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)
---
title: Retrieve and Update Presentation Information in Python
linktitle: Presentation Information
type: docs
weight: 30
url: /python-net/examine-presentation/
keywords:
- presentation format
- presentation properties
- document properties
- get properties
- read properties
- change properties
- modify properties
- update properties
- examine PPTX
- examine PPT
- examine ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using Python for faster insights and smarter content audits."
---

Aspose.Slides for Python via .NET allows you to examine a presentation to find out its properties and understand its behavior. 

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) and [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **Check a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this Python code:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Get Presentation Properties**

This Python code shows you how to get presentation properties (information about the presentation):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

You may want to see the [properties under the DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) class.

## **Update Presentation Properties**

Aspose.Slides provides the [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) method that allows you to make changes to presentation properties.

Let's say we have a PowerPoint presentation with the document properties shown below.

![Original document properties of the PowerPoint presentation](input_properties.png)

This code example shows you how to edit some presentation properties:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

The results of changing the document properties are shown below.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Look for [embedded-font information](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) at the presentation level, then compare those entries with the set of [fonts actually used across content](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) to identify which fonts are critical for rendering.

**How can I quickly tell if the file has hidden slides and how many?**

Iterate through the [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) and inspect each slide's [visibility flag](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/).

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Compare the current [slide size](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) and orientation with the standard presets; this helps anticipate behavior for printing and export.

**Is there a quick way to see if charts reference external data sources?**

Yes. Traverse all [charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), check their [data source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), and note whether the data is internal or link-based, including any broken links.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

For each slide, tally object counts and look for large images, transparency, shadows, animations, and multimedia; assign a rough complexity score to flag potential performance hotspots.

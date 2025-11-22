---
title: Retrieve and Update Presentation Information in .NET
linktitle: Presentation Information
type: docs
weight: 30
url: /net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using .NET for faster insights and smarter content audits."
---

Aspose.Slides for .NET allows you to examine a presentation to find out its properties and understand its behavior. 

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) and [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **Check a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this C# code:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Get Presentation Properties**

This C# code shows you how to get presentation properties (information about the presentation):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

You may want to see the [properties under the DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) class.

## **Update Presentation Properties**

Aspose.Slides provides the [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) method that allows you to make changes to presentation properties.

Let's say we have a PowerPoint presentation with the document properties shown below.

![Original document properties of the PowerPoint presentation](input_properties.png)

This code example shows you how to edit some presentation properties:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

The results of changing the document properties are shown below.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Look for [embedded-font information](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) at the presentation level, then compare those entries with the set of [fonts actually used across content](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) to identify which fonts are critical for rendering.

**How can I quickly tell if the file has hidden slides and how many?**

Iterate through the [slide collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) and inspect each slide's [visibility flag](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/).

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Compare the current [slide size](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) and orientation with the standard presets; this helps anticipate behavior for printing and export.

**Is there a quick way to see if charts reference external data sources?**

Yes. Traverse all [charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), check their [data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/), and note whether the data is internal or link-based, including any broken links.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

For each slide, tally object counts and look for large images, transparency, shadows, animations, and multimedia; assign a rough complexity score to flag potential performance hotspots.

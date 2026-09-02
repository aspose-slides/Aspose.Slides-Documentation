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

## **Overview**

Aspose.Slides can identify a presentation's format and read its document metadata without creating a complete presentation object model. This is useful when you need to classify files, build an inventory, or inspect properties before deciding whether to load and process the presentation content.

This article demonstrates lightweight inspection through [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) and [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/), as well as targeted updates through [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/).

## **Check a Presentation Format**

Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) to inspect a file without creating a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance. The [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/loadformat/) property reports the detected format, such as PPTX, PPT, or ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Build a Lightweight Presentation Inventory**

When you process many presentation files, you may need a compact inventory for validation, indexing, or a document-management system. In this scenario, use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) to obtain an [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/) object, and then call [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) to read the document metadata. This approach does not create a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance or require you to traverse the complete presentation object model.

The extended properties exposed by [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) provide the following inventory values:

| Property | Inventory value |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/slides/) | Total number of slides. |
| [HiddenSlides](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hiddenslides/) | Number of hidden slides. |
| [Notes](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/notes/) | Number of slides that contain notes. |
| [Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/paragraphs/) | Total number of paragraphs, when available. |
| [Words](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/words/) | Total number of words. |
| [MultimediaClips](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/multimediaclips/) | Total number of audio and video clips. |

The following example reads these values without creating a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object and prints a compact inventory. It also combines [HeadingPairs](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/headingpairs/) with [TitlesOfParts](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/titlesofparts/) to display content groups such as fonts, themes, and slide titles.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Each [IHeadingPair](https://reference.aspose.com/slides/net/aspose.slides/iheadingpair/) supplies a group name and the number of items in that group. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/titlesofparts/) is a flat, ordered array, so consume the number of consecutive titles specified by each heading pair.

### **Stored Metadata and Format Limitations**

The inventory properties returned by [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) reflect metadata available in the source document. Aspose.Slides does not load and traverse the presentation object model to recalculate these values for this call. Missing properties are represented by default values, and stored values may be stale if the application that last saved the file did not update its document properties.

- **PPTX:** The format provides extended document properties for slide, note, hidden-slide, paragraph, word, and multimedia counts, as well as heading pairs and part titles. Availability depends on which properties were written by the document producer.
- **PPT:** The binary format can store corresponding document-summary properties. If a property is absent or was not refreshed by the document producer, Aspose.Slides returns its stored or default value rather than calculating it from the slides.
- **ODP:** OpenDocument metadata provides general document statistics, such as page, paragraph, and word counts, but these values do not map to every PowerPoint-specific extended property. Hidden-slide, notes-slide, multimedia, heading-pair, and part-title metadata may be unavailable, and the inventory properties may return default values. Do not treat a zero value or an empty array as authoritative proof that the corresponding content is absent.

Use the lightweight metadata approach for inventories and preliminary checks. Load the presentation and inspect its live object model when the result must reflect in-memory changes or when you need to verify the actual presentation content.

## **Update Presentation Properties**

The properties returned by [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) can also be changed without creating a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance. Apply the changes with [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), and then write the bound presentation with [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

The following image shows the original document properties.

![Original document properties of the PowerPoint presentation](input_properties.png)

The following example changes the title and last-saved time and writes the result to a new file:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

The following image shows the updated document properties.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

For related security checks and protection settings, see the following articles:

- [Password-Protect Presentations](/slides/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/net/write-protected-presentation/)

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Load the presentation and use [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Call [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) to obtain the embedded fonts and [FontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) to obtain the fonts used by the presentation. Compare the two results to find fonts that are required for rendering but are not embedded.

**How can I quickly tell if the file has hidden slides and how many?**

When stored document metadata is sufficient, read [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hiddenslides/) through [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) and [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/). This is suitable for a lightweight inventory. If the presentation has been modified in memory, the stored metadata may be missing or stale, or you need to verify live values, iterate through [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) and inspect each slide's [Slide.Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) property instead.

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Load the presentation and read [Presentation.SlideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/). Inspect [ISlideSize.Type](https://reference.aspose.com/slides/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/net/aspose.slides/islidesize/size/), and [ISlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) to compare the current settings with the expected preset and dimensions.

**Is there a quick way to see if charts reference external data sources?**

Yes. Locate each [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/) and inspect [ChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/). For an external workbook, read [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). The data source type and path identify an external reference, but verifying whether the target is available requires a separate resource check.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

There is no single complexity property. Traverse [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) and each slide's [IBaseSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/) collection. Use shape counts and the presence of large images, effects, animations, or multimedia as screening signals, and measure a representative render or export before treating a slide as a confirmed performance bottleneck.

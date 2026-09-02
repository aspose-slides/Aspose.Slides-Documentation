---
title: Retrieve and Update Presentation Information in C++
linktitle: Presentation Information
type: docs
weight: 30
url: /cpp/examine-presentation/
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
- C++
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using C++ for faster insights and smarter content audits."
---

## **Overview**

Aspose.Slides can identify a presentation's format and read its document metadata without creating a complete presentation object model. This is useful when you need to classify files, build an inventory, or inspect properties before deciding whether to load and process the presentation content.

This article demonstrates lightweight inspection through [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/) and [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/), as well as targeted updates through [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/).

## **Check a Presentation Format**

Use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) to inspect a file without creating a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance. The [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_loadformat/) method reports the detected format, such as PPTX, PPT, or ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Build a Lightweight Presentation Inventory**

When you process many presentation files, you may need a compact inventory for validation, indexing, or a document-management system. In this scenario, use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) to obtain an [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/) object, and then call [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) to read the document metadata. This approach does not create a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance or require you to traverse the complete presentation object model.

The extended properties exposed by [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) provide the following inventory values:

| Method | Inventory value |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_slides/) | Total number of slides. |
| [get_HiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Number of hidden slides. |
| [get_Notes](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_notes/) | Number of slides that contain notes. |
| [get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Total number of paragraphs, when available. |
| [get_Words](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_words/) | Total number of words. |
| [get_MultimediaClips](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Total number of audio and video clips. |

The following example reads these values without creating a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) object and prints a compact inventory. It also combines [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_headingpairs/) with [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) to display content groups such as fonts, themes, and slide titles.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Each [IHeadingPair](https://reference.aspose.com/slides/cpp/aspose.slides/iheadingpair/) supplies a group name through [IHeadingPair::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/iheadingpair/get_name/) and the number of items in that group through [IHeadingPair::get_Count](https://reference.aspose.com/slides/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) returns a flat, ordered array, so consume the number of consecutive titles specified by each heading pair.

### **Stored Metadata and Format Limitations**

The inventory properties returned by [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) reflect metadata available in the source document. Aspose.Slides does not load and traverse the presentation object model to recalculate these values for this call. Missing properties are represented by default values, and stored values may be stale if the application that last saved the file did not update its document properties.

- **PPTX:** The format provides extended document properties for slide, note, hidden-slide, paragraph, word, and multimedia counts, as well as heading pairs and part titles. Availability depends on which properties were written by the document producer.
- **PPT:** The binary format can store corresponding document-summary properties. If a property is absent or was not refreshed by the document producer, Aspose.Slides returns its stored or default value rather than calculating it from the slides.
- **ODP:** OpenDocument metadata provides general document statistics, such as page, paragraph, and word counts, but these values do not map to every PowerPoint-specific extended property. Hidden-slide, notes-slide, multimedia, heading-pair, and part-title metadata may be unavailable, and the inventory properties may return default values. Do not treat a zero value or an empty array as authoritative proof that the corresponding content is absent.

Use the lightweight metadata approach for inventories and preliminary checks. Load the presentation and inspect its live object model when the result must reflect in-memory changes or when you need to verify the actual presentation content.

## **Update Presentation Properties**

The properties returned by [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) can also be changed without creating a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance. Apply the changes with [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), and then write the bound presentation with [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

The following image shows the original document properties.

![Original document properties of the PowerPoint presentation](input_properties.png)

The following example changes the title and last-saved time and writes the result to a new file:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

The following image shows the updated document properties.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

For related security checks and protection settings, see the following articles:

- [Password-Protect Presentations](/slides/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cpp/write-protected-presentation/)

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Load the presentation and use [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Call [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) to obtain the embedded fonts and [FontsManager::GetFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) to obtain the fonts used by the presentation. Compare the two results to find fonts that are required for rendering but are not embedded.

**How can I quickly tell if the file has hidden slides and how many?**

When stored document metadata is sufficient, read [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) through [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) and [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). This is suitable for a lightweight inventory. If the presentation has been modified in memory, the stored metadata may be missing or stale, or you need to verify live values, iterate through [Presentation::get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) and inspect each slide's [Slide::get_Hidden](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) method instead.

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Load the presentation and read [Presentation::get_SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/). Inspect [ISlideSize::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/get_size/), and [ISlideSize::get_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/get_orientation/) to compare the current settings with the expected preset and dimensions.

**Is there a quick way to see if charts reference external data sources?**

Yes. Locate each [Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/) and inspect [ChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). For an external workbook, read [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). The data source type and path identify an external reference, but verifying whether the target is available requires a separate resource check.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

There is no single complexity property. Traverse [Presentation::get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) and each slide's [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/) collection. Use shape counts and the presence of large images, effects, animations, or multimedia as screening signals, and measure a representative render or export before treating a slide as a confirmed performance bottleneck.

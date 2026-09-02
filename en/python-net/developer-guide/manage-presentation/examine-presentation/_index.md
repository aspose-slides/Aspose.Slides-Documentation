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

## **Overview**

Aspose.Slides can identify a presentation's format and read its document metadata without creating a complete presentation object model. This is useful when you need to classify files, build an inventory, or inspect properties before deciding whether to load and process the presentation content.

This article demonstrates lightweight inspection through [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) and [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/), as well as targeted updates through [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/).

## **Check a Presentation Format**

Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) to inspect a file without creating a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance. The [PresentationInfo.load_format](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/load_format/) property reports the detected format, such as PPTX, PPT, or ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Build a Lightweight Presentation Inventory**

When you process many presentation files, you may need a compact inventory for validation, indexing, or a document-management system. In this scenario, use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) to obtain a [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) object, and then call [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) to read the document metadata. This approach does not create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance or require you to traverse the complete presentation object model.

The extended properties exposed by [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) provide the following inventory values:

| Property | Inventory value |
| --- | --- |
| [slides](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/slides/) | Total number of slides. |
| [hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hidden_slides/) | Number of hidden slides. |
| [notes](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/notes/) | Number of slides that contain notes. |
| [paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/paragraphs/) | Total number of paragraphs, when available. |
| [words](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/words/) | Total number of words. |
| [multimedia_clips](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/multimedia_clips/) | Total number of audio and video clips. |

The following example reads these values without creating a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object and prints a compact inventory. It also combines [heading_pairs](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/heading_pairs/) with [titles_of_parts](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/titles_of_parts/) to display content groups such as fonts, themes, and slide titles.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Each [HeadingPair](https://reference.aspose.com/slides/python-net/aspose.slides/headingpair/) supplies a group name and the number of items in that group. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/titles_of_parts/) is a flat, ordered collection, so consume the number of consecutive titles specified by each heading pair.

### **Stored Metadata and Format Limitations**

The inventory properties returned by [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) reflect metadata available in the source document. Aspose.Slides does not load and traverse the presentation object model to recalculate these values for this call. Missing properties are represented by default values, and stored values may be stale if the application that last saved the file did not update its document properties.

- **PPTX:** The format provides extended document properties for slide, note, hidden-slide, paragraph, word, and multimedia counts, as well as heading pairs and part titles. Availability depends on which properties were written by the document producer.
- **PPT:** The binary format can store corresponding document-summary properties. If a property is absent or was not refreshed by the document producer, Aspose.Slides returns its stored or default value rather than calculating it from the slides.
- **ODP:** OpenDocument metadata provides general document statistics, such as page, paragraph, and word counts, but these values do not map to every PowerPoint-specific extended property. Hidden-slide, notes-slide, multimedia, heading-pair, and part-title metadata may be unavailable, and the inventory properties may return default values. Do not treat a zero value or an empty collection as authoritative proof that the corresponding content is absent.

Use the lightweight metadata approach for inventories and preliminary checks. Load the presentation and inspect its live object model when the result must reflect in-memory changes or when you need to verify the actual presentation content.

## **Update Presentation Properties**

The properties returned by [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) can also be changed without creating a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance. Apply the changes with [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/), and then write the bound presentation with [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

The following image shows the original document properties.

![Original document properties of the PowerPoint presentation](input_properties.png)

The following example changes the title and last-saved time and writes the result to a new file:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

The following image shows the updated document properties.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

For related security checks and protection settings, see the following articles:

- [Password-Protect Presentations](/slides/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/python-net/write-protected-presentation/)

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Load the presentation and use [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Call [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) to obtain the embedded fonts and [FontsManager.get_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) to obtain the fonts used by the presentation. Compare the two results to find fonts that are required for rendering but are not embedded.

**How can I quickly tell if the file has hidden slides and how many?**

When stored document metadata is sufficient, read [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hidden_slides/) through [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) and [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/). This is suitable for a lightweight inventory. If the presentation has been modified in memory, the stored metadata may be missing or stale, or you need to verify live values, iterate through [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) and inspect each slide's [Slide.hidden](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) property instead.

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Load the presentation and read [Presentation.slide_size](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/). Inspect [SlideSize.type](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/size/), and [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) to compare the current settings with the expected preset and dimensions.

**Is there a quick way to see if charts reference external data sources?**

Yes. Locate each [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) and inspect [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/). For an external workbook, read [ChartData.external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). The data source type and path identify an external reference, but verifying whether the target is available requires a separate resource check.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

There is no single complexity property. Traverse [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) and each slide's [BaseSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) collection. Use shape counts and the presence of large images, effects, animations, or multimedia as screening signals, and measure a representative render or export before treating a slide as a confirmed performance bottleneck.

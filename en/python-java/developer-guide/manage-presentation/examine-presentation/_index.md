---
title: Retrieve and Update Presentation Information in Python via Java
linktitle: Presentation Information
type: docs
weight: 30
url: /python-java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using Python via Java for faster insights and smarter content audits."
---

## **Overview**

Aspose.Slides can identify a presentation's format and read its document metadata without creating a complete presentation object model. This is useful when you need to classify files, build an inventory, or inspect properties before deciding whether to load and process the presentation content.

The examples require Aspose.Slides for Python via Java and a compatible Java runtime. Each example starts the JVM if it is not already running. Supply existing presentation files at the paths used in the examples.

This article demonstrates lightweight inspection through [PresentationFactory](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/) and [PresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/), as well as targeted updates through [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/).

## **Check a Presentation Format**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) to inspect a file without creating a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance. The [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#getLoadFormat) method reports the detected format, such as PPTX, PPT, or ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Build a Lightweight Presentation Inventory**

When you process many presentation files, you may need a compact inventory for validation, indexing, or a document-management system. In this scenario, use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) to obtain an [PresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/) object, and then call [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) to read the document metadata. This approach does not create a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance or require you to traverse the complete presentation object model.

The extended properties exposed by [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) provide the following inventory values:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getSlides) | Total number of slides. |
| [getHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Number of hidden slides. |
| [getNotes](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getNotes) | Number of slides that contain notes. |
| [getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getParagraphs) | Total number of paragraphs, when available. |
| [getWords](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getWords) | Total number of words. |
| [getMultimediaClips](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Total number of audio and video clips. |

The following example reads these values without creating a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object and prints a compact inventory. It also combines [getHeadingPairs](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHeadingPairs) with [getTitlesOfParts](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitlesOfParts) to display content groups such as fonts, themes, and slide titles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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

Each [HeadingPair](https://reference.aspose.com/slides/python-java/aspose.slides/headingpair/) supplies a group name and the number of items in that group. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitlesOfParts) returns a flat, ordered array, so consume the number of consecutive titles specified by each heading pair.

### **Stored Metadata and Format Limitations**

The inventory properties returned by [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) reflect metadata available in the source document. Aspose.Slides does not load and traverse the presentation object model to recalculate these values for this call. Missing properties are represented by default values, and stored values may be stale if the application that last saved the file did not update its document properties.

- **PPTX:** The format provides extended document properties for slide, note, hidden-slide, paragraph, word, and multimedia counts, as well as heading pairs and part titles. Availability depends on which properties were written by the document producer.
- **PPT:** The binary format can store corresponding document-summary properties. If a property is absent or was not refreshed by the document producer, Aspose.Slides returns its stored or default value rather than calculating it from the slides.
- **ODP:** OpenDocument metadata provides general document statistics, such as page, paragraph, and word counts, but these values do not map to every PowerPoint-specific extended property. Hidden-slide, notes-slide, multimedia, heading-pair, and part-title metadata may be unavailable, and the inventory properties may return default values. Do not treat a zero value or an empty array as authoritative proof that the corresponding content is absent.

Use the lightweight metadata approach for inventories and preliminary checks. Load the presentation and inspect its live object model when the result must reflect in-memory changes or when you need to verify the actual presentation content.

## **Update Presentation Properties**

The properties returned by [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) can also be changed without creating a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance. Apply the changes with [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), and then write the bound presentation with [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

The following image shows the original document properties.

![Original document properties of the PowerPoint presentation](input_properties.png)

The following example changes the title and last-saved time and writes the result to a new file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

The following image shows the updated document properties.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

For related security checks and protection settings, see the following articles:

- [Password-Protect Presentations](/slides/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/python-java/write-protected-presentation/)

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Load the presentation and use [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Call [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) to obtain the embedded fonts and [FontsManager.getFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getFonts) to obtain the fonts used by the presentation. Compare the two results to find fonts that are required for rendering but are not embedded.

**How can I quickly tell if the file has hidden slides and how many?**

When stored document metadata is sufficient, read [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHiddenSlides) through [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) and [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties). This is suitable for a lightweight inventory. If the presentation has been modified in memory, the stored metadata may be missing or stale, or you need to verify live values, iterate through [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) and inspect each slide's [Slide.getHidden](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getHidden) method instead.

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Load the presentation and call [Presentation.getSlideSize](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlideSize). Use [SlideSize.getType](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#getSize), and [SlideSize.getOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#getOrientation) to compare the current settings with the expected preset and dimensions.

**Is there a quick way to see if charts reference external data sources?**

Yes. Locate each [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) and call [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType). For an external workbook, call [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). The data source type and path identify an external reference, but verifying whether the target is available requires a separate resource check.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

There is no single complexity property. Traverse [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) and each slide's [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) collection. Use shape counts and the presence of large images, effects, animations, or multimedia as screening signals, and measure a representative render or export before treating a slide as a confirmed performance bottleneck.

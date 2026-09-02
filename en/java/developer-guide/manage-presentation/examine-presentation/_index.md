---
title: Retrieve and Update Presentation Information in Java
linktitle: Presentation Information
type: docs
weight: 30
url: /java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using Java for faster insights and smarter content audits."
---

## **Overview**

Aspose.Slides can identify a presentation's format and read its document metadata without creating a complete presentation object model. This is useful when you need to classify files, build an inventory, or inspect properties before deciding whether to load and process the presentation content.

This article demonstrates lightweight inspection through [PresentationFactory](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/) and [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/), as well as targeted updates through [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/).

## **Check a Presentation Format**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) to inspect a file without creating a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance. The [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) method reports the detected format, such as PPTX, PPT, or ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Build a Lightweight Presentation Inventory**

When you process many presentation files, you may need a compact inventory for validation, indexing, or a document-management system. In this scenario, use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) to obtain an [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/) object, and then call [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) to read the document metadata. This approach does not create a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance or require you to traverse the complete presentation object model.

The extended properties exposed by [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) provide the following inventory values:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getSlides--) | Total number of slides. |
| [getHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Number of hidden slides. |
| [getNotes](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getNotes--) | Number of slides that contain notes. |
| [getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Total number of paragraphs, when available. |
| [getWords](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getWords--) | Total number of words. |
| [getMultimediaClips](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Total number of audio and video clips. |

The following example reads these values without creating a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) object and prints a compact inventory. It also combines [getHeadingPairs](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) with [getTitlesOfParts](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) to display content groups such as fonts, themes, and slide titles.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Each [IHeadingPair](https://reference.aspose.com/slides/java/com.aspose.slides/iheadingpair/) supplies a group name and the number of items in that group. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) returns a flat, ordered array, so consume the number of consecutive titles specified by each heading pair.

### **Stored Metadata and Format Limitations**

The inventory properties returned by [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) reflect metadata available in the source document. Aspose.Slides does not load and traverse the presentation object model to recalculate these values for this call. Missing properties are represented by default values, and stored values may be stale if the application that last saved the file did not update its document properties.

- **PPTX:** The format provides extended document properties for slide, note, hidden-slide, paragraph, word, and multimedia counts, as well as heading pairs and part titles. Availability depends on which properties were written by the document producer.
- **PPT:** The binary format can store corresponding document-summary properties. If a property is absent or was not refreshed by the document producer, Aspose.Slides returns its stored or default value rather than calculating it from the slides.
- **ODP:** OpenDocument metadata provides general document statistics, such as page, paragraph, and word counts, but these values do not map to every PowerPoint-specific extended property. Hidden-slide, notes-slide, multimedia, heading-pair, and part-title metadata may be unavailable, and the inventory properties may return default values. Do not treat a zero value or an empty array as authoritative proof that the corresponding content is absent.

Use the lightweight metadata approach for inventories and preliminary checks. Load the presentation and inspect its live object model when the result must reflect in-memory changes or when you need to verify the actual presentation content.

## **Update Presentation Properties**

The properties returned by [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) can also be changed without creating a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance. Apply the changes with [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), and then write the bound presentation with [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

The following image shows the original document properties.

![Original document properties of the PowerPoint presentation](input_properties.png)

The following example changes the title and last-saved time and writes the result to a new file:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

The following image shows the updated document properties.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

For related security checks and protection settings, see the following articles:

- [Password-Protect Presentations](/slides/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/java/write-protected-presentation/)

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Load the presentation and use [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--). Call [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) to obtain the embedded fonts and [IFontsManager.getFonts](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getFonts--) to obtain the fonts used by the presentation. Compare the two results to find fonts that are required for rendering but are not embedded.

**How can I quickly tell if the file has hidden slides and how many?**

When stored document metadata is sufficient, read [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) through [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) and [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). This is suitable for a lightweight inventory. If the presentation has been modified in memory, the stored metadata may be missing or stale, or you need to verify live values, iterate through [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) and inspect each slide's [ISlide.getHidden](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getHidden--) method instead.

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Load the presentation and call [Presentation.getSlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideSize--). Use [ISlideSize.getType](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#getSize--), and [ISlideSize.getOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#getOrientation--) to compare the current settings with the expected preset and dimensions.

**Is there a quick way to see if charts reference external data sources?**

Yes. Locate each [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) and call [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--). For an external workbook, call [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). The data source type and path identify an external reference, but verifying whether the target is available requires a separate resource check.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

There is no single complexity property. Traverse [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) and each slide's [IBaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getShapes--) collection. Use shape counts and the presence of large images, effects, animations, or multimedia as screening signals, and measure a representative render or export before treating a slide as a confirmed performance bottleneck.

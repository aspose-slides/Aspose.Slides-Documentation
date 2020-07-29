---
title: Aspose.Slides for Java 15.11.0 Release Notes
type: docs
weight: 10
url: /java/aspose-slides-for-java-15-11-0-release-notes/
---

## **Other Improvements and Chages**
Other Improvements and Chages

Bug Fixes

SLIDESJAVA-35143 - pdf rendered incorrectly

SLIDESJAVA-35137 - Wrong text underline type returned for text

SLIDESJAVA-35136 - Setting text underline color not working

SLIDESJAVA-35129 - Creation Date and Last Save Time fields are not extracted correctly

SLIDESJAVA-35120 - Shape to BMP thumbnail is not working

SLIDESJAVA-35116 - Incorrect text on presentation load and save

SLIDESJAVA-35107 - Incorrect chart legend displayed

SLIDESJAVA-35106 - PptxReadException thrown on loading pptx

SLIDESJAVA-35101 - SlideSizeType.Custom property is not working

SLIDESJAVA-35093 - License is disabled message while setting the license

SLIDESJAVA-35075 - Image (Jpeg) is improperly rendered in generated thumbnail

SLIDESJAVA-35067 - Blank html generated from presentation

SLIDESJAVA-35034 - PptxReadException thrown on loading pptx

SLIDESJAVA-34920 - writeAsSvg creates incorrect text

SLIDESJAVA-34919 - writeAsSvg creates incorrect svg files

SLIDESJAVA-34916 - writeAsSvg method loses background image.

SLIDESJAVA-34496 - Text indentation lost in generated thumbnail

SLIDESJAVA-34485 - The text is improperly rendered in generated PDF

SLIDESJAVA-34374 - AnimationSettings is missing in new Aspose.Slides for Java Unified API

SLIDESJAVA-34314 - Fonts are not rendered from HTML to presentation

SLIDESJAVA-34222 - Invalid String exception on accessing presentaiton

SLIDESJAVA-34089 - Unknown file format exception on generating PDF
## **Public API Changes**
{{< highlight java >}}



Public API Changes

New methods getFirstSlideNumber() and setFirstSlideNumber() have been added to the Presentation class

Presentation pres = new Presentation(path);


int firstSlideNumber = pres.getFirstSlideNumber();


pres.setFirstSlideNumber(10);


pres.save(newPath, SaveFormat.Pptx);

Obsolete methods in com.aspose.slides.DataLabelCollection class have been deleted


{{< /highlight >}}

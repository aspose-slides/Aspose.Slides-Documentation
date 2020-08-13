---
title: Aspose.Slides for Java 15.6.0 Release Notes
type: docs
weight: 40
url: /java/aspose-slides-for-java-15-6-0-release-notes/
---

## **Minor Changes**
Minor Changes

SLIDESJAVA-34866 - Support for cleaning of PowerPoint document properties

SLIDESJAVA-34642 - Setting custom position and size for chart legends

SLIDESJAVA-34305 - Joining connector to shapes in PPTX

SLIDESNET-36325 - Support for removing Notes slides in presentation
## **Other improvements and changes**
Other improvements and changes

Bug fixes

SLIDESJAVA-34930 - Font name not shown from title placeholder

SLIDESJAVA-34926 - NullPointer exception on loading the presentation

SLIDESJAVA-34921 - Error while opening the saved presentation with Animations

SLIDESJAVA-34918 - Unsupported file format while loading a presentation

SLIDESJAVA-34909 - Line with markers chart is lost in generated thumbnail

SLIDESJAVA-34905 - Presentation repair message on opening the Aspose.Slides saved presentation

SLIDESJAVA-34904 - Chart axis and legends text is improeprly rendered in exported HTML

SLIDESJAVA-34901 - NegativeSeekOffset Exception on loading presentation

SLIDESJAVA-34900 - Exception on saving presentation

SLIDESJAVA-34891 - Hyperlink text is lost on converting odp to html

SLIDESJAVA-34889 - Incorrect rendering of shapes on generated thumbnail

SLIDESJAVA-34888 - color of picture changed on generated thumbnail

SLIDESJAVA-34856 - Setting InvertIfNegative does not set the color of data item bars to blank

SLIDESJAVA-34841 - Chart failed to get opened in edit mode when edited in PowerPoint

SLIDESJAVA-34727 - Text alignment in merged cell of the table is not correct in PDF file

SLIDESJAVA-34718 - Exception: Couldnot read PowerPoint Document record on opening the PPT file

SLIDESJAVA-34644 - NullPointerException thrown while converting PPT to PDF

SLIDESJAVA-34633 - HeadlessException thrown on adding HTML to PPTX file

SLIDESJAVA-34572 - Chart failed to get edited in PowerPoint after renaming series name

SLIDESJAVA-34539 - Couldn't read "PowerPoint Document" record on converting PPT to PDF

SLIDESJAVA-6023 - Object resizing problem
## **Public API changes**
``` java

 Public API changes

com.aspose.slides.DataLabel constructor signature has been changed

Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead.

Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added

Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated

Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties

Method remove() has been added to com.aspose.slides.IComment

Method remove() has been added to com.aspose.slides.ICommentAuthor

Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties

Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape

Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection

```

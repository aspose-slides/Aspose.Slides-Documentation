---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Node.js via Java 15.11.0
type: docs
weight: 190
url: /nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) or [removed](/slides/nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Node.js via Java 15.11.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Obsolete methods in aspose.slides.DataLabelCollection class have been deleted**
Obsolete methods in aspose.slides.DataLabelCollection class have been deleted:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **New methods getFirstSlideNumber() and setFirstSlideNumber() have been added to the Presentation class**
New methods getFirstSlideNumber() and setFirstSlideNumber() allow to get or to set the number of first slide in a presentation.
When a new first slide number value is specified all slide numbers are recalculated.

```javascript
    var pres = new  aspose.slides.Presentation(path);
    var firstSlideNumber = pres.getFirstSlideNumber();
    pres.setFirstSlideNumber(10);
    pres.save(newPath, aspose.slides.SaveFormat.Pptx);
```

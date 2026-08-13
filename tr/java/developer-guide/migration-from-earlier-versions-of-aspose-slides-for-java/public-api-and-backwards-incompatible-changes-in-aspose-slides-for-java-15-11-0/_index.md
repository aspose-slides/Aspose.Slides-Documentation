---
title: Aspose.Slides for Java 15.11.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- geçiş
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve geriye uyumsuz değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 15.11.0 API'siyle tanıtılan [eklenmiş](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) veya [kaldırılmış](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
#### **com.aspose.slides.DataLabelCollection sınıfındaki geçersiz yöntemler silindi**
Obsolete methods in com.aspose.slides.DataLabelCollection class have been deleted:

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


#### **Presentation sınıfına yeni getFirstSlideNumber() ve setFirstSlideNumber() yöntemleri eklendi**
New methods getFirstSlideNumber() and setFirstSlideNumber() allow to get or to set the number of first slide in a presentation.
When a new first slide number value is specified all slide numbers are recalculated.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
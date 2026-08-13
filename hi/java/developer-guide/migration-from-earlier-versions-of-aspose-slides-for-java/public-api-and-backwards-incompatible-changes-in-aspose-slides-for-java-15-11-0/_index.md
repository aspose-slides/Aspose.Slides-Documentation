---
title: Aspose.Slides for Java 15.11.0 में सार्वजनिक API और असंगत पीछे की ओर परिवर्तन
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- माइग्रेशन
- पुराना कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़ा गया](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) या [हटाया गया](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) वर्गों, विधियों, गुणों आदि की सूची देता है, और Aspose.Slides for Java 15.11.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **com.aspose.slides.DataLabelCollection क्लास में अप्रचलित मेथड्स को हटा दिया गया है**
com.aspose.slides.DataLabelCollection क्लास में अप्रचलित मेथड्स को हटा दिया गया है:

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


#### **Presentation क्लास में नए मेथड्स getFirstSlideNumber() और setFirstSlideNumber() जोड़े गए हैं**
नए मेथड्स getFirstSlideNumber() और setFirstSlideNumber() प्रस्तुति में पहली स्लाइड की संख्या को प्राप्त करने या सेट करने की अनुमति देते हैं।
जब नई पहली स्लाइड नंबर मान निर्दिष्ट किया जाता है, सभी स्लाइड नंबरों की पुनर्गणना की जाती है।

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
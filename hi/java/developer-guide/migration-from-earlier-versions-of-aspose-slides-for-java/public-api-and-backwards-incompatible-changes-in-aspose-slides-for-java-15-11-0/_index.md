---
title: Aspose.Slides for Java 15.11.0 में सार्वजनिक API और पीछे की असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- माइग्रेशन
- पुराना कोड
- आधुनिक कोड
- पुराना दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) या [हटाए गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) वर्गों, विधियों, गुणों आदि को सूचीबद्ध करता है, और Aspose.Slides for Java 15.11.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन। 

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **com.aspose.slides.DataLabelCollection वर्ग में अप्रचलित विधियों को हटा दिया गया है**
com.aspose.slides.DataLabelCollection वर्ग में अप्रचलित विधियों को हटा दिया गया है:

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


#### **Presentation वर्ग में नई विधियाँ getFirstSlideNumber() और setFirstSlideNumber() जोड़ी गई हैं**
नई विधाएँ getFirstSlideNumber() और setFirstSlideNumber() प्रस्तुति में पहली स्लाइड की संख्या को प्राप्त करने या सेट करने की अनुमति देती हैं।
जब नई पहली स्लाइड संख्या का मान निर्दिष्ट किया जाता है तो सभी स्लाइड नंबरों की पुनः गणना की जाती है।

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```
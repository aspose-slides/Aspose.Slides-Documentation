---
title: Aspose.Slides for Java 15.7.0 में सार्वजनिक API और अनुकूलन‑रहित परिवर्तन
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- माइग्रेशन
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी अप्रोच
- आधुनिक अप्रोच
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़ा गया](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) या [हटाया गया](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) क्लास, मेथड, प्रॉपर्टी आदि और Aspose.Slides for Java 15.7.0 API के साथ परिचित किए गए अन्य परिवर्तनों की सूची देता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **Enum com.aspose.slides.ImagePixelFormat को जोड़ा गया है**
उत्पन्न छवियों के लिए पिक्सेल फ़ॉर्मेट निर्दिष्ट करने हेतु Enum com.aspose.slides.ImagePixelFormat को जोड़ा गया है।

#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() मेथड को जोड़ा गया है**
यह मेथड श्रृंखला सूचकांक, डेटा पॉइंट सूचकांक, parentSeriesGroup, isColorVaried मानों और चार्ट शैली के आधार पर डेटा पॉइंट का स्वतः रंग लौटाता है। यदि fillType NotDefined के बराबर हो तो यह रंग डिफ़ॉल्ट रूप से उपयोग किया जाता है।

#### **Methods getPixelFormat(), setPixelFormat(int) को com.aspose.slides.ITiffOptions में जोड़ा गया है**
उत्पन्न TIFF छवियों के लिए पिक्सेल फ़ॉर्मेट निर्दिष्ट करने हेतु Methods getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) को com.aspose.slides.ITiffOptions और com.aspose.slides.TiffOptions में जोड़ा गया है।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```
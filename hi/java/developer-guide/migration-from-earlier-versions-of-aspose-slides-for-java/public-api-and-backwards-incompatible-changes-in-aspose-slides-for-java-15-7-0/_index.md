---
title: Aspose.Slides for Java 15.7.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- स्थानांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुतीकरण समाधान को सहजता से स्थानांतरित कर सकें।"
---
{{% alert color="primary" %}} 
यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) या [हटाए गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) वर्गों, विधियों, प्रॉपर्टीज़ आदि तथा Aspose.Slides for Java 15.7.0 API के साथ पेश किए गए अन्य परिवर्तनों की सूची देता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **Enum com.aspose.slides.ImagePixelFormat जोड़ा गया है**
Enum com.aspose.slides.ImagePixelFormat जोड़ा गया है जिससे उत्पन्न छवियों के लिए पिक्सेल फ़ॉर्मेट निर्धारित किया जा सके।
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() विधि जोड़ी गई है**
यह विधि series index, data point index, parentSeriesGroup, isColorVaried मान और चार्ट शैली के आधार पर डेटा पॉइंट का स्वचालित रंग लौटाती है। यह रंग तब डिफ़ॉल्ट रूप से उपयोग होता है जब fillType NotDefined के बराबर हो।
#### **Methods getPixelFormat(), setPixelFormat(int) को com.aspose.slides.ITiffOptions में जोड़ा गया है**
Methods getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) को com.aspose.slides.ITiffOptions और com.aspose.slides.TiffOptions में जोड़ दिया गया है जिससे उत्पन्न TIFF छवियों के लिए पिक्सेल फ़ॉर्मेट निर्दिष्ट किया जा सके।
``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```
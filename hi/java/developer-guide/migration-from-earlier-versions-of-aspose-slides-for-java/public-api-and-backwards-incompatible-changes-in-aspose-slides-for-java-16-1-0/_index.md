---
title: Aspose.Slides for Java 16.1.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- स्थांतरण
- पुराना कोड
- आधुनिक कोड
- परम्परागत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट करें।"
---
{{% alert color="primary" %}} 
यह पृष्ठ सभी [added](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) या [removed](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) क्लास, मेथड, प्रॉपर्टी आदि तथा Aspose.Slides for Java 16.1.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन सूचीबद्ध करता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**

#### **मेथड getRotationAngle() और setRotationAngle() को IChartTextBlockFormat और ITextFrameFormat इंटरफ़ेस में जोड़ा गया है**
मेथड getRotationAngle() और setRotationAngle() को इंटरफ़ेस com.aspose.slides.IChartTextBlockFormat और com.aspose.slides.ITextFrameFormat में जोड़ा गया है।  
वे बाउंडिंग बॉक्स के भीतर टेक्स्ट पर लागू कस्टम रोटेशन तक पहुंच प्रदान करते हैं।

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```
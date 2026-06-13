---
title: Aspose.Slides for Java 15.8.0 में सार्वजनिक API और पीछे की ओर असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- माइग्रेशन
- पुरानी कोड
- आधुनिक कोड
- पुरानी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़ें](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) या [हटाए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) क्लासेस, मेथड्स, प्रॉपर्टीज़ आदि की सूची देता है, और Aspose.Slides for Java 15.8.0 API में प्रस्तुत अन्य परिवर्तन।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **मेथड्स getDoughnutHoleSize(), setDoughnutHoleSize(byte) को IChartSeries और ChartSeries में जोड़ा गया है**
डोनट चार्ट में छेद के आकार को निर्दिष्ट करता है।

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```
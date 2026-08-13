---
title: Aspose.Slides for Java 15.8.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- स्थानांतरण
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुतीकरण समाधान को सुगमता से माइग्रेट करें।"
---
{{% alert color="info" %}} 
यह पृष्ठ Aspose.Slides for Java 15.8.0 API के साथ प्रस्तुत किए गए सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) या [हटाए गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) क्लास, मेथड, प्रॉपर्टी आदि और अन्य परिवर्तन सूचीबद्ध करता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **IChartSeries और ChartSeries में Methods getDoughnutHoleSize(), setDoughnutHoleSize(byte) जोड़े गए हैं**
डोनट चार्ट में छेद के आकार को निर्दिष्ट करता है।
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```
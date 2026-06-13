---
title: जावा का उपयोग करके प्रस्तुतियों में डोनट चार्ट को अनुकूलित करें
linktitle: डोनट चार्ट
type: docs
weight: 30
url: /hi/java/doughnut-chart/
keywords:
- डोनट चार्ट
- केंद्र अंतराल
- छेद आकार
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में डोनट चार्ट बनाने और अनुकूलित करने का तरीका जानें, जो गतिशील प्रस्तुतियों के लिए PowerPoint फॉर्मेट का समर्थन करता है।"
---
## **सारांश**

यह लेख Aspose.Slides में डोनट चार्ट के साथ काम करने का तरीका दर्शाता है, जिसमें चार्ट को स्लाइड में जोड़ना, उसके केंद्र के छेद का आकार निर्धारित करना, और प्रस्तुति को सहेजना शामिल है। यह `setDoughnutHoleSize` मेथड पर केंद्रित है और कोड में इस चार्ट प्रकार को अनुकूलित करने के लिए आवश्यक बुनियादी चरणों को प्रदर्शित करता है।

यह एक छोटा FAQ भी शामिल करता है जो संबंधित डोनट‑चार्ट परिदृश्यों को कवर करता है, जैसे कई श्रृंखलाओं का उपयोग करके कई रिंग बनाना, विस्फोटित डोनट चार्ट के साथ काम करना, और चार्ट को रास्टर इमेज या SVG के रूप में निर्यात करना।

## **डोनट चार्ट में केंद्र अंतराल निर्दिष्ट करें**
{{% alert color="primary" %}} 

Aspose.Slides for Java अब डोनट चार्ट में छेद का आकार निर्दिष्ट करने का समर्थन करता है। इस विषय में, हम उदाहरण के साथ देखेंगे कि डोनट चार्ट में छेद का आकार कैसे निर्दिष्ट किया जाए।

{{% /alert %}} 

डोनट चार्ट में छेद का आकार निर्दिष्ट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट बनाएं।
1. स्लाइड पर डोनट चार्ट जोड़ें।
1. डोनट चार्ट में छेद का आकार निर्दिष्ट करें।
1. प्रस्तुति को डिस्क पर सहेजें।

नीचे दिए गए उदाहरण में, हमने डोनट चार्ट में छेद का आकार सेट किया है।

```java
// Presentation वर्ग का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई रिंग वाले बहु‑स्तरीय डोनट बना सकता हूँ?**

हाँ। एक ही डोनट चार्ट में कई श्रृंखलाएँ जोड़ें—प्रत्येक श्रृंखला एक अलग रिंग बन जाती है। रिंग क्रम संग्रह में श्रृंखलाओं के क्रम द्वारा निर्धारित होता है।

**क्या "विस्फोटित" डोनट (भिन्न स्लाइस) समर्थित है?**

हाँ। एक Exploded Doughnut [chart type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) और डेटा पॉइंट्स पर विस्फोट गुण है; आप व्यक्तिगत स्लाइस को अलग कर सकते हैं।

**रिपोर्ट के लिए डोनट चार्ट की छवि (PNG/SVG) कैसे प्राप्त करूँ?**

एक चार्ट एक आकार (shape) है; आप इसे एक [raster image](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getImage-int-float-float-) में रेंडर कर सकते हैं या चार्ट को एक [SVG image](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) में निर्यात कर सकते हैं।
---
title: Java के उपयोग से प्रस्तुतियों में डोनट चार्ट को कस्टमाइज़ करें
linktitle: डोनट चार्ट
type: docs
weight: 30
url: /hi/java/doughnut-chart/
keywords:
- डोनट चार्ट
- केंद्र अंतर
- छेद का आकार
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में डोनट चार्ट बनाने और कस्टमाइज़ करने का तरीका जानें, जो गतिशील प्रस्तुतियों के लिए PowerPoint फॉर्मेट को सपोर्ट करता है।"
---
## **परिचय**

यह लेख Aspose.Slides में डोनट चार्ट के साथ काम करने का तरीका दर्शाता है, जिसमें चार्ट को स्लाइड में जोड़ना, उसके केंद्र में छेद का आकार सेट करना, और प्रस्तुति को सहेजना शामिल है। यह `setDoughnutHoleSize` मेथड पर केंद्रित है और कोड में इस चार्ट प्रकार को अनुकूलित करने के लिए आवश्यक मूल चरणों को प्रदर्शित करता है।

यह एक संक्षिप्त अक्सर पूछे जाने वाले प्रश्न (FAQ) को भी शामिल करता है जो संबंधित डोनट-चार्ट परिदृश्यों को कवर करता है, जैसे कई श्रृंखलाओं का उपयोग करके कई रिंग बनाना, विस्फोटित डोनट चार्ट के साथ काम करना, और चार्ट को रास्टर इमेज या SVG के रूप में निर्यात करना।

## **डोनट चार्ट में केंद्र गैप निर्दिष्ट करें**
{{% alert color="info" %}} 

Aspose.Slides for Java अब डोनट चार्ट में छेद का आकार निर्दिष्ट करने का समर्थन करता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि डोनट चार्ट में छेद का आकार कैसे निर्दिष्ट किया जाता है।

{{% /alert %}} 

डोनट चार्ट में छेद का आकार निर्दिष्ट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट बनाएं।
2. स्लाइड पर डोनट चार्ट जोड़ें।
3. डोनट चार्ट में छेद का आकार निर्दिष्ट करें।
4. प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डोनट चार्ट में छेद का आकार सेट किया है।

```java
import com.aspose.slides.*;

// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // प्रेजेंटेशन को डिस्क पर लिखें
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं कई रिंग वाले बहु-स्तरीय डोनट बना सकता हूँ?

हां। एक एकल डोनट चार्ट में कई श्रृंखलाएँ जोड़ें—प्रत्येक श्रृंखला एक अलग रिंग बन जाती है। रिंग का क्रम संग्रह में श्रृंखलाओं के क्रम द्वारा निर्धारित होता है।

### क्या "विस्फोटित" डोनट (अलग स्लाइस) समर्थित है?

हां। एक Exploded Doughnut [चार्ट प्रकार](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) और डेटा पॉइंट्स पर विस्फोट गुण उपलब्ध है; आप व्यक्तिगत स्लाइस को अलग कर सकते हैं।

### रिपोर्ट के लिए डोनट चार्ट की इमेज (PNG/SVG) कैसे प्राप्त करूँ?

एक चार्ट एक आकार है; आप इसे एक [रास्टर इमेज](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getImage-int-float-float-) में रेंडर कर सकते हैं या चार्ट को एक [SVG इमेज](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) में निर्यात कर सकते हैं।
---
title: JavaScript का उपयोग करके प्रस्तुतियों में डोनट चार्ट को अनुकूलित करें
linktitle: डोनट चार्ट
type: docs
weight: 30
url: /hi/nodejs-java/doughnut-chart/
keywords:
- डोनट चार्ट
- केंद्र अंतर
- छेद आकार
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides के साथ Node.js के लिए डोनट चार्ट बनाना और अनुकूलित करना जानें, जिससे गतिशील प्रस्तुतियों के लिए PowerPoint फ़ॉर्मैट का समर्थन हो।"
---
## **सारांश**

यह लेख Aspose.Slides में डोनट चार्ट के साथ काम करना दिखाता है, जिसमें चार्ट को स्लाइड में जोड़ना, इसके मध्य छेद का आकार निर्धारित करना, और प्रस्तुति को सहेजना शामिल है। यह `setDoughnutHoleSize` मेथड पर ध्यान केंद्रित करता है और कोड में इस चार्ट प्रकार को अनुकूलित करने के लिए आवश्यक बुनियादी कदमों को प्रदर्शित करता है।

यह एक संक्षिप्त FAQ भी शामिल करता है जो संबंधित डोनट‑चार्ट परिदृश्यों को कवर करता है, जैसे कई श्रृंखलाओं का उपयोग करके कई रिंग बनाना, एक्सप्लोडेड डोनट चार्ट के साथ काम करना, और चार्ट को रास्टर इमेज या SVG के रूप में निर्यात करना।

## **डोनट चार्ट में केंद्र अंतर बदलें**

डोनट चार्ट में छेद का आकार निर्दिष्ट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) ऑब्जेक्ट बनाएं।
1. स्लाइड पर डोनट चार्ट जोड़ें।
1. डोनट चार्ट में छेद का आकार निर्दिष्ट करें।
1. प्रस्तुति को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डोनट चार्ट में छेद का आकार सेट किया है।

```javascript
// Presentation क्लास की एक इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // प्रस्तुति को डिस्क पर लिखें
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई रिंगों के साथ बहु-स्तरीय डोनट बना सकता हूँ?**

हां। एक ही डोनट चार्ट में कई श्रृंखलाएं जोड़ें—प्रत्येक श्रृंखला एक अलग रिंग बन जाती है। रिंग का क्रम संग्रह में श्रृंखलाओं के क्रम द्वारा निर्धारित होता है।

**क्या "एक्सप्लोडेड" डोनट (अलग किए गए स्लाइस) समर्थित है?**

हां। एक एक्सप्लोडेड डोनट [chart type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) मौजूद है और डेटा पॉइंट्स पर एक एक्सप्लोज़न प्रॉपर्टी है; आप व्यक्तिगत स्लाइस को अलग कर सकते हैं।

**रिपोर्ट के लिए डोनट चार्ट (PNG/SVG) की छवि कैसे प्राप्त करूँ?**

एक चार्ट एक आकार है; आप इसे एक [raster image](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getImage) में रेंडर कर सकते हैं या चार्ट को एक [SVG image](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/) में निर्यात कर सकते हैं।
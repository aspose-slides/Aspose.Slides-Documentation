---
title: PHP का उपयोग करके प्रस्तुतियों में डोनट चार्ट को कस्टमाइज़ करें
linktitle: डोनट चार्ट
type: docs
weight: 30
url: /hi/php-java/doughnut-chart/
keywords:
- डोनट चार्ट
- केंद्र अंतराल
- छेद आकार
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "जानेँ कैसे Aspose.Slides for PHP में जावा के माध्यम से डोनट चार्ट बनाएं और कस्टमाइज़ करें, जो गतिशील प्रस्तुतियों के लिए PowerPoint फ़ॉर्मेट को सपोर्ट करता है।"
---
## **अवलोकन**

यह लेख दर्शाता है कि Aspose.Slides में डोनट चार्ट के साथ कैसे काम करें, चार्ट को स्लाइड में जोड़कर, उसके मध्य छेद का आकार सेट करके, और प्रस्तुति को सहेजकर। यह `setDoughnutHoleSize` मेथड पर केंद्रित है और कोड में इस चार्ट प्रकार को अनुकूलित करने के लिए आवश्यक मूलभूत चरणों को प्रदर्शित करता है।

यह एक संक्षिप्त FAQ भी शामिल करता है जो संबंधित डोनट-चार्ट परिदृश्यों को कवर करता है, जैसे कई श्रृंखलाओं का उपयोग करके कई रिंग बनाना, एक्सप्लोडेड डोनट चार्ट के साथ काम करना, और चार्ट को रास्टर इमेज या SVG के रूप में निर्यात करना।

## **डोनट चार्ट में केंद्र अंतराल निर्दिष्ट करें**

डोनट चार्ट में छेद का आकार निर्दिष्ट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) ऑब्जेक्ट बनाएं।
1. स्लाइड पर डोनट चार्ट जोड़ें।
1. डोनट चार्ट में छेद का आकार निर्दिष्ट करें।
1. प्रेज़ेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डोनट चार्ट में छेद का आकार सेट किया है।

```php
  # Presentation क्लास का एक उदाहरण बनाएं
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # प्रस्तुति को डिस्क पर लिखें
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई रिंगों के साथ मल्टी-लेवल डोनट बना सकता हूँ?**

हाँ। एक ही डोनट चार्ट में कई श्रृंखलाएँ जोड़ें—प्रत्येक श्रृंखला एक अलग रिंग बनती है। रिंग का क्रम संग्रह में श्रृंखलाओं के क्रम द्वारा निर्धारित होता है।

**क्या "एक्सप्लोडेड" डोनट (विभक्त स्लाइस) समर्थित है?**

हाँ। एक Exploded Doughnut [chart type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) मौजूद है और डेटा पॉइंट्स पर एक एक्सप्लोजन प्रॉपर्टी है; आप व्यक्तिगत स्लाइस को अलग कर सकते हैं।

**रिपोर्ट के लिए डोनट चार्ट (PNG/SVG) की छवि कैसे प्राप्त करूँ?**

एक चार्ट एक शैप है; आप इसे एक [raster image](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) में रेंडर कर सकते हैं या चार्ट को एक [SVG image](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#writeAsSvg) में निर्यात कर सकते हैं।
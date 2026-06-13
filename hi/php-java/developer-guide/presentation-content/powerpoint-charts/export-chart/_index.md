---
title: PHP में प्रस्तुति चार्ट निर्यात करें
linktitle: चार्ट निर्यात करें
type: docs
weight: 90
url: /hi/php-java/export-chart/
keywords:
- चार्ट
- चार्ट को छवि में
- चार्ट को छवि के रूप में
- चार्ट छवि निकालें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुति चार्ट निर्यात करना सीखें, PPT और PPTX फ़ॉर्मैट को समर्थन देते हुए, और किसी भी कार्यप्रवाह में रिपोर्टिंग को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुति से एक चार्ट को छवि के रूप में निर्यात करने की अनुमति देता है। यह लेख दिखाता है कि चार्ट से छवि कैसे प्राप्त की जाए और उसे सहेजा जाए, जो तब उपयोगी होता है जब आपको PowerPoint प्रस्तुति के बाहर चार्ट दृश्य को पुन: उपयोग करना पड़े।

## **चार्ट छवि प्राप्त करें**
Aspose.Slides for PHP via Java विशिष्ट चार्ट की छवि निकालने के लिए समर्थन प्रदान करता है। नीचे एक नमूना उदाहरण दिया गया है।

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक चार्ट को रास्टर इमेज के बजाय वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हां। एक चार्ट एक shape है, और उसकी सामग्री को SVG में सहेजा जा सकता है [shape-to-SVG saving method](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) का उपयोग करके।

**मैं निर्यात किए गए चार्ट का सटीक आकार पिक्सेल में कैसे सेट कर सकता हूँ?**

इमेज-रेंडरिंग ओवरलोड का उपयोग करें जो आकार या स्केल निर्दिष्ट करने की अनुमति देता है—लाइब्रेरी दी गई आयाम/स्केल के साथ वस्तुओं को रेंडर करने का समर्थन करती है।

**निर्यात के बाद लेबल और लीजेंड में फ़ॉन्ट गलत दिखें तो मुझे क्या करना चाहिए?**

[Load the required fonts](/slides/hi/php-java/custom-font/) को [FontsLoader](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/) के माध्यम से लोड करें ताकि चार्ट रेंडरिंग मेट्रिक्स और टेक्स्ट की उपस्थिति को बनाए रखे।

**क्या निर्यात PowerPoint थीम, स्टाइल और इफ़ेक्ट्स का सम्मान करता है?**

हां। Aspose.Slides का रेंडरर प्रस्तुति के फ़ॉर्मैटिंग (थीम, स्टाइल, फ़िल, इफ़ेक्ट्स) का पालन करता है, इसलिए चार्ट की उपस्थिति संरक्षित रहती है।

**मैं चार्ट छवियों के अलावा उपलब्ध रेंडरिंग/एक्सपोर्ट क्षमताएँ कहाँ पा सकता हूँ?**

आउटपुट टार्गेट्स के लिए [API](https://reference.aspose.com/slides/hi/php-java/aspose.slides/)/[documentation](/slides/hi/php-java/convert-powerpoint/) देखें ([PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/hi/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/php-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/php-java/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्पों को देखें।
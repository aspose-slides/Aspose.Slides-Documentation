---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/php-java/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ चार्ट लेजेंड को अनुकूलित करके PowerPoint प्रस्तुतियों को अनुकूलित लेजेंड फ़ॉर्मेटिंग के साथ बेहतर बनाएं।"
---
## **समीक्षा**

Aspose.Slides PowerPoint प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करने के विकल्प प्रदान करता है। यह लेख दिखाता है कि लेजेंड को कैसे स्थित और आकार दिया जाए, पूरे लेजेंड के फ़ॉन्ट आकार को कैसे सेट किया जाए, और व्यक्तिगत लेजेंड एंट्री पर फ़ॉर्मेटिंग कैसे लागू की जाए।

यह FAQ में कई संबंधित व्यवहारों को भी कवर करता है, जिसमें नॉन-ओवरले मोड का उपयोग करके प्लॉट एरिया को लेजेंड के लिए जगह बनाने, लंबे लेजेंड लेबल को रैप या लाइन ब्रेक का उपयोग करने की अनुमति देना, और जब स्पष्ट टेक्स्ट और फ़िल सेटिंग्स नहीं लागू की जाती हैं तो लेजेंड फ़ॉर्मेटिंग को प्रस्तुति थीम से विरासत में लेने देना शामिल है।

## **लेजेंड का स्थान निर्धारित करना**
लेजेंड प्रॉपर्टीज़ सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड पर एक चार्ट जोड़ें।
- लेजेंड की प्रॉपर्टीज़ सेट करें।
- प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट लेजेंड के स्थान और आकार को सेट किया है।

```php
  # Presentation क्लास का एक इंस्टैंस बनाएं
  $pres = new Presentation();
  try {
    # स्लाइड का रेफ़रेंस प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # स्लाइड पर क्लस्टर्ड कॉलम चार्ट जोड़ें
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # लेजेंड प्रॉपर्टीज़ सेट करें
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # प्रस्तुति को डिस्क पर लिखें
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लेजेंड का फ़ॉन्ट आकार सेट करना**
Aspose.Slides for PHP via Java डेवलपर्स को लेजेंड का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टैंस बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रेज़ेंटेशन को डिस्क पर लिखें।

```php
  # Presentation क्लास का एक इंस्टैंस बनाएं
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **व्यक्तिगत लेजेंड का फ़ॉन्ट आकार सेट करना**
Aspose.Slides for PHP via Java डेवलपर्स को व्यक्तिगत लेजेंड एंट्रीज़ का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दिए गए चरणों का पालन करें।

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टैंस बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- लेजेंड एंट्री तक पहुँचें।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रेज़ेंटेशन को डिस्क पर लिखें।

```php
  # Presentation क्लास का एक इंस्टैंस बनाएं
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं लेजेंड को सक्षम कर सकता हूँ जिससे चार्ट स्वचालित रूप से उसके लिए जगह आवंटित करे, ओवरले करने के बजाय?**

हाँ। नॉन-ओवरले मोड का उपयोग करें ([setOverlay(false)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/legend/setoverlay/)); इस स्थिति में, प्लॉट एरिया लेजेंड को समायोजित करने के लिए छोटा हो जाएगा।

**क्या मैं मल्टी-लाइन लेजेंड लेबल बना सकता हूँ?**

हाँ। जब स्थान अपर्याप्त हो तो लंबे लेबल स्वतः रैप हो जाते हैं; मजबूर लाइन ब्रेक सीरीज़ नाम में नई लाइन कैरेक्टर्स के माध्यम से समर्थित होते हैं।

**मैं लेजेंड को प्रस्तुति थीम की रंग योजना के अनुसार कैसे बना सकता हूँ?**

लेजेंड या उसके टेक्स्ट के लिए स्पष्ट रंग/फ़िल/फ़ॉन्ट सेट न करें। वे तब थीम से विरासत में ले लेंगे और डिज़ाइन बदलने पर सही ढंग से अपडेट होंगे।
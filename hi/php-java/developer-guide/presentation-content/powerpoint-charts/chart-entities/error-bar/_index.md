---
title: PHP का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार को अनुकूलित करें
linktitle: त्रुटि बार
type: docs
url: /hi/php-java/error-bar/
keywords:
- त्रुटि बार
- कस्टम मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ चार्ट में त्रुटि बार को जोड़ने और अनुकूलित करने के तरीके सीखें — PowerPoint प्रस्तुतियों में डेटा विज़ुअल को बेहतर बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार के साथ कैसे काम किया जाए, इसे समझाता है। यह दिखाता है कि चार्ट सीरीज़ में त्रुटि बार कैसे जोड़े, X और Y त्रुटि बार सेटिंग्स कैसे कॉन्फ़िगर करें, और स्थिर, प्रतिशत, तथा कस्टम मान जैसे विभिन्न मान प्रकार कैसे लागू करें।

यह यह भी प्रदर्शित करता है कि कैसे श्रृंखला में व्यक्तिगत डेटा पॉइंट्स के लिए संबंधित डेटा पॉइंट संग्रह का उपयोग करके कस्टम त्रुटि बार मान आवंटित किए जा सकते हैं। अतिरिक्त रूप से, लेख में निर्यात के दौरान त्रुटि बार कैसे व्यवहार करते हैं, उनके मार्कर और डेटा लेबल के साथ संगतता, तथा संबंधित API रेफरेंस क्लासेस और एनोंम कहाँ मिलते हैं, इस बारे में संक्षिप्त नोट्स शामिल हैं।

## **त्रुटि बार जोड़ें**
Aspose.Slides for PHP via Java त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब कस्टम मान प्रकार का उपयोग किया जाता है। मान निर्दिष्ट करने के लिए, श्रृंखला के [**data points**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriescollection/) संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहली चार्ट सीरीज़ तक पहुंचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहली चार्ट सीरीज़ तक पहुंचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. बार मान और फ़ॉर्मेट सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # बबल चार्ट बना रहे हैं
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # त्रुटि बार जोड़ रहे हैं और उसका फ़ॉर्मेट सेट कर रहे हैं
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # प्रस्तुति सहेज रहे हैं
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **कस्टम त्रुटि बार मान जोड़ें**
Aspose.Slides for PHP via Java कस्टम त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/errorbarsformat/#getValueType) मेथड **Custom** लौटाता है। मान निर्दिष्ट करने के लिए, श्रृंखला के [**data points**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriescollection/) संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहली चार्ट सीरीज़ तक पहुंचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहली चार्ट सीरीज़ तक पहुंचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. चार्ट सीरीज़ के व्यक्तिगत डेटा पॉइंट्स तक पहुंचें और व्यक्तिगत सीरीज़ डेटा पॉइंट के लिए त्रुटि बार मान सेट करें।
1. बार मान और फ़ॉर्मेट सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # बबल चार्ट बना रहे हैं
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # कस्टम त्रुटि बार जोड़ रहे हैं और उसका फ़ॉर्मेट सेट कर रहे हैं
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # चार्ट श्रृंखला डेटा पॉइंट तक पहुँच रहे हैं और त्रुटि बार मान सेट कर रहे हैं
    # व्यक्तिगत बिंदु
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # चार्ट श्रृंखला बिंदुओं के लिए त्रुटि बार सेट कर रहे हैं
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # प्रस्तुति सहेज रहे हैं
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रस्तुति को PDF या छवियों में निर्यात करने पर त्रुटि बार क्या होते हैं?**

वे चार्ट के हिस्से के रूप में रेंडर होते हैं और रूपांतरण के दौरान चार्ट फ़ॉर्मेटिंग के बाकी हिस्सों के साथ संरक्षित रहते हैं, बशर्ते संगत संस्करण या रेंडरर हो।

**क्या त्रुटि बार को मार्कर और डेटा लेबल के साथ संयोजित किया जा सकता है?**

हां। त्रुटि बार एक अलग तत्व है और मार्कर और डेटा लेबल के साथ संगत है; यदि तत्व ओवरलैप होते हैं, तो आपको फ़ॉर्मेटिंग समायोजित करने की आवश्यकता पड़ सकती है।

**API में त्रुटि बार के साथ काम करने के लिए गुणों और क्लासों की सूची मैं कहाँ पा सकता हूं?**

API रेफरेंस में: [ErrorBarsFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/errorbarsformat/) क्लास और संबंधित क्लासें [ErrorBarType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/errorbartype/) तथा [ErrorBarValueType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/errorbarvaluetype/)।
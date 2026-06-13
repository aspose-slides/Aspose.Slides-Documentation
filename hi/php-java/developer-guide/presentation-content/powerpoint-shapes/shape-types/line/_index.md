---
title: PHP में प्रस्तुतियों में लाइन शैप जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/php-java/Line/
keywords:
- लाइन
- लाइन बनाएं
- लाइन जोड़ें
- साधारण लाइन
- लाइन कॉन्फ़िगर करें
- लाइन अनुकूलित करें
- डैश शैली
- तीर सिर
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में लाइन फ़ॉर्मेटिंग को नियंत्रित करना सीखें। गुण, विधियाँ और उदाहरणों की खोज करें।"
---
## **सारांश**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन शैप जोड़ने की अनुमति देता है। यह लेख दर्शाता है कि कैसे एक सरल लाइन बनाई जा सकती है और लाइन को कैसे अनुकूलित किया जाए ताकि वह तीर जैसा दिखे।

आप सीखेंगे कि स्लाइड में लाइन शैप कैसे जोड़ी जाए, उसकी दृश्य उपस्थिति को कैसे समायोजित किया जाए, और अद्यतन प्रस्तुति को कैसे सहेजा जाए। उदाहरण व्यावहारिक लाइन फ़ॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, तीर के सिर के विकल्प, और भरने का रंग पर केंद्रित हैं।

## **साधारण लाइन बनाएं**

प्रेजेंटेशन की चयनित स्लाइड में एक साधारण लाइन जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक उदाहरण बनाएं।
- इंडेक्स का उपयोग करके एक स्लाइड का रेफ़रेंस प्राप्त करें।
- ShapeCollection ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके लाइन प्रकार का AutoShape जोड़ें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

निचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक लाइन जोड़ी है।

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास को बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # लाइन प्रकार का AutoShape जोड़ें
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX को डिस्क पर लिखें
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तीर के आकार वाली लाइन बनाएं**

Aspose.Slides for PHP via Java डेवलपर्स को लाइन की कुछ विशेषताओं को कॉन्फ़िगर करने की सुविधा भी देता है जिससे वह अधिक आकर्षक दिखे। चलिए लाइन की कुछ विशेषताओं को इस तरह कॉन्फ़िगर करते हैं कि वह तीर जैसा दिखे। इसके लिए नीचे दिए चरणों का पालन करें:

- Presentation क्लास का एक उदाहरण बनाएं।
- इंडेक्स का उपयोग करके एक स्लाइड का रेफ़रेंस प्राप्त करें।
- ShapeCollection ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके लाइन प्रकार का AutoShape जोड़ें।
- [Line Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineStyle) को Aspose.Slides for PHP via Java द्वारा प्रदान की गई शैलियों में से एक पर सेट करें।
- लाइन की चौड़ाई सेट करें।
- लाइन के [Dash Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineDashStyle) को Aspose.Slides for PHP via Java द्वारा प्रदान की गई शैलियों में से एक पर सेट करें।
- लाइन के प्रारंभ बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadLength) सेट करें।
- लाइन के अंत बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadLength) सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # लाइन प्रकार का AutoShape जोड़ें
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # लाइन पर कुछ फ़ॉर्मेटिंग लागू करें
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # PPTX को डिस्क पर लिखें
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य लाइन को कनेक्टर में बदल सकता हूँ ताकि यह आकृतियों से "स्नैप" हो जाए?**

नहीं। एक सामान्य लाइन (type [Line] का एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/)) स्वतः कनेक्टर नहीं बनती। इसे आकृतियों से स्नैप करने के लिए समर्पित [Connector](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/) प्रकार और कनेक्शनों के लिए [corresponding APIs](/slides/hi/php-java/connector/) का उपयोग करें।

**यदि लाइन की विशेषताएँ थीम से विरासत में मिली हों और अंतिम मान निर्धारित करना कठिन हो तो मैं क्या करूँ?**

[असली गुण पढ़ें](/slides/hi/php-java/shape-effective-properties/) `LineFormatEffectiveData`/`LineFillFormatEffectiveData` के माध्यम से — ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं लाइन को संपादन (हिलाना, आकार बदलना) से लॉक कर सकता हूँ?**

हां। शैप [lock objects](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/getautoshapelock/) प्रदान करते हैं जो आपको संपादन ऑपरेशनों को प्रतिबंधित करने की अनुमति देते हैं।
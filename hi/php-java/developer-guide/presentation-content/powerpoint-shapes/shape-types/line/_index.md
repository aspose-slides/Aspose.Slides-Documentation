---
title: PHP में प्रस्तुतियों में लाइन शैलियों को जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/php-java/line/
keywords:
- लाइन
- लाइन बनाएं
- लाइन जोड़ें
- साधारण लाइन
- लाइन कॉन्फ़िगर करें
- लाइन कस्टमाइज़ करें
- डैश शैली
- तीर सिरा
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में लाइन फ़ॉर्मेटिंग को नियंत्रित करना सीखें। गुण, विधियों और उदाहरणों की खोज करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन शैलियों को जोड़ने की अनुमति देता है। यह लेख दिखाता है कि एक साधारण लाइन कैसे बनायीं जाए और कैसे एक लाइन को इस प्रकार अनुकूलित किया जाए कि वह तीर जैसा दिखे।

आप सीखेंगे कि कैसे एक स्लाइड में लाइन शैपे जोड़ें, उसकी दृश्य रूपरेखा समायोजित करें, और अपडेटेड प्रस्तुतीकरण को सहेजें। उदाहरण व्यावहारिक लाइन फ़ॉर्मेटिंग सेटिंग्स पर केंद्रित हैं जैसे शैली, चौड़ाई, डैश पैटर्न, एरोहेड विकल्प, और भराव रंग।

## **साधारण लाइन बनाना**

एक चयनित प्रस्तुतीकरण स्लाइड में एक साधारण प्लेन लाइन जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
- Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- एक लाइन प्रकार की AutoShape को [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके, जो [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा उपलब्ध कराया गया है, जोड़ें।
- परिवर्तित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुतीकरण की पहली स्लाइड में एक लाइन जोड़ी है।

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाले PresentationEx क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # लाइन प्रकार की AutoShape जोड़ें
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX को डिस्क पर लिखें
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तीर-आकार की लाइन बनाना**

Aspose.Slides for PHP via Java भी डेवलपर्स को लाइन की कुछ गुणों को कॉन्फ़िगर करने की अनुमति देता है ताकि वह अधिक आकर्षक दिखे। चलिए लाइन की कुछ गुणों को इस प्रकार कॉन्फ़िगर करने का प्रयास करते हैं कि वह तीर जैसा दिखे। इसके लिए नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
- Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- एक लाइन प्रकार की AutoShape को [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके, जो [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा उपलब्ध कराया गया है, जोड़ें।
- [Line Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineStyle) को Aspose.Slides for PHP via Java द्वारा उपलब्ध कराई गई शैलियों में से एक पर सेट करें।
- लाइन की चौड़ाई सेट करें।
- लाइन के [Dash Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineDashStyle) को Aspose.Slides for PHP via Java द्वारा उपलब्ध कराई गई शैलियों में से एक पर सेट करें।
- लाइन के प्रारंभ बिंदु के [Arrow Head Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadLength) सेट करें।
- लाइन के अंत बिंदु के [Arrow Head Style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LineArrowheadLength) सेट करें।
- परिवर्तित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाले PresentationEx क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # लाइन प्रकार की AutoShape जोड़ें
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

**क्या मैं एक सामान्य लाइन को कनेक्टर में बदल सकता हूँ ताकि वह आकृतियों (shapes) से 'स्नैप' हो जाए?**

नहीं। एक सामान्य लाइन (एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) प्रकार की [Line](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapetype/)) स्वचालित रूप से कनेक्टर नहीं बनती। इसे आकृतियों से स्नैप करने के लिए, समर्पित [Connector](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/) प्रकार और कनेक्शन के लिए [corresponding APIs](/slides/hi/php-java/connector/) का उपयोग करें।

**यदि लाइन की गुणधर्म थीम से विरासत में मिले हों और अंतिम मान निर्धारित करना कठिन हो तो मैं क्या करूँ?**

[Read the effective properties](/slides/hi/php-java/shape-effective-properties/) को `LineFormatEffectiveData`/`LineFillFormatEffectiveData` के माध्यम से पढ़ें—ये पहले से ही विरासत और थीम स्टाइल्स को ध्यान में रखते हैं।

**क्या मैं किसी लाइन को संपादन (हिलाना, आकार बदलना) से लॉक कर सकता हूँ?**

हाँ। शैलियां [lock objects](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/getautoshapelock/) प्रदान करती हैं जो आपको संपादन संचालन को प्रतिबंधित करने देती हैं।
---
title: PHP में प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/php-java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- घातीय ट्रेंड लाइन
- रैखिक ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग एवरेज ट्रेंड लाइन
- पॉलीनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint चार्ट में ट्रेंड लाइन्स को जल्दी से जोड़ें और अनुकूलित करें — दर्शकों को जोड़ने के लिए एक व्यावहारिक मार्गदर्शिका।"
---
## **समीक्षा**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ने का तरीका समझाता है। यह दिखाता है कि चार्ट कैसे बनाएं, चार्ट सीरीज़ में ट्रेंड लाइन्स कैसे जोड़ें, और एक्सपोनेंशियल, लीनियर, लॉगरिदमिक, मूविंग एवरेज, पॉलीनॉमियल और पावर सहित कई ट्रेंड लाइन प्रकारों के साथ कैसे काम करें।

यह यह भी बताता है कि एक लाइन शैप जोड़कर चार्ट में कस्टम लाइन कैसे डालें, और फ़ॉरवर्ड और बैकवर्ड ट्रेंडलाइन प्रोजेक्शन मानों तथा क्या ट्रेंड लाइन्स PDF या SVG में निर्यात या चार्ट को इमेज के रूप में रेंडर करते समय संरक्षित रहती हैं, इस पर संक्षिप्त FAQ शामिल है।

## **एक ट्रेंड लाइन जोड़ें**
Aspose.Slides for PHP via Java विभिन्न चार्ट ट्रेंड लाइन्स को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और इच्छित प्रकार चुनें (इस उदाहरण में ChartType::ClusteredColumn उपयोग किया गया है)।
4. चार्ट सीरीज़ 1 के लिए एक्सपोनेंशियल ट्रेंड लाइन जोड़ें।
5. चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ें।
6. चार्ट सीरीज़ 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ें।
7. चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ें।
8. चार्ट सीरीज़ 3 के लिए पॉलीनॉमियल ट्रेंड लाइन जोड़ें।
9. चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

निम्न कोड का उपयोग ट्रेंड लाइनों के साथ एक चार्ट बनाने के लिए किया जाता है।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएँ
  $pres = new Presentation();
  try {
    # क्लस्टर्ड कॉलम चार्ट बनाना
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # चार्ट सीरीज़ 1 के लिए घातीय ट्रेंड लाइन जोड़ना
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # चार्ट सीरीज़ 1 के लिए रैखिक ट्रेंड लाइन जोड़ना
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # चार्ट सीरीज़ 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ना
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ना
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # चार्ट सीरीज़ 3 के लिए पॉलीनॉमियल ट्रेंड लाइन जोड़ना
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ना
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # प्रस्तुति सहेजना
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **एक कस्टम लाइन जोड़ें**
Aspose.Slides for PHP via Java चार्ट में कस्टम लाइन्स जोड़ने के लिए एक सरल API प्रदान करता है। प्रस्तुति की चयनित स्लाइड में एक साधारण सी लाइन जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- Shapes ऑब्जेक्ट के AddChart मेथड का उपयोग करके नया चार्ट बनाएं।
- Shapes ऑब्जेक्ट के AddAutoShape मेथड का उपयोग करके लाइन प्रकार का AutoShape जोड़ें।
- शेप की लाइनों का रंग सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

निम्न कोड का उपयोग कस्टम लाइनों के साथ एक चार्ट बनाने के लिए किया जाता है।

```php
  # Presentation क्लास का एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**ट्रेंडलाइन में 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

इनका अर्थ है ट्रेंडलाइन की लंबाई जो आगे/पीछे प्रोजेक्ट की गई है: स्कैटर (XY) चार्ट के लिए — अक्ष इकाइयों में; गैर-स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर-नकारात्मक मानों की अनुमति है।

**क्या ट्रेंडलाइन PDF या SVG में निर्यात करते समय, या स्लाइड को इमेज के रूप में रेंडर करते समय संरक्षित रहती है?**

हां। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/hi/php-java/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को इमेज में रेंडर करता है; ट्रेंडलाइन, चार्ट का हिस्सा होने के नाते, इन ऑपरेशनों के दौरान संरक्षित रहती हैं। एक मेथड भी उपलब्ध है जिससे आप सीधे [चार्ट की इमेज निर्यात](/slides/hi/php-java/create-shape-thumbnails/) कर सकते हैं।
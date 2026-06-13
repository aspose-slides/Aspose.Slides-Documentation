---
title: PHP का उपयोग करके प्रस्तुतियों में 3D चार्ट कस्टमाइज़ करें
linktitle: 3D चार्ट
type: docs
url: /hi/php-java/3d-chart/
keywords:
- 3D चार्ट
- रोटेशन
- गहराई
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में 3-D चार्ट बनाना और कस्टमाइज़ करना सीखें, PPT और PPTX फ़ाइलों का समर्थन के साथ — आज ही अपनी प्रस्तुतियों को सशक्त बनाएं।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides में `Rotation3D` सेटिंग्स जैसे `RotationX`, `RotationY`, `DepthPercents`, और `RightAngleAxes` को कॉन्फ़िगर करके 3D चार्ट को कैसे कस्टमाइज़ किया जाए। यह एक प्रस्तुति बनाने, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ने, आवश्यक 3D व्यू सेटिंग्स लागू करने, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजने की प्रक्रिया को दर्शाता है।

## **3D चार्ट की RotationX, RotationY और DepthPercents प्रॉपर्टी सेट करना**
Aspose.Slides for PHP via Java इन प्रॉपर्टीज़ को सेट करने के लिए एक सरल API प्रदान करता है। यह लेख आपको **X,Y Rotation, DepthPercents** आदि जैसी विभिन्न प्रॉपर्टीज़ सेट करने में मदद करेगा। नमूना कोड उपरोक्त प्रॉपर्टीज़ को लागू करता है।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

```php
  $pres = new Presentation();
  try {
    # पहला स्लाइड एक्सेस करें
    $slide = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # चार्ट डेटा शीट का इंडेक्स सेट करना
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त करना
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # सीरीज़ जोड़ें
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # श्रेणियाँ जोड़ें
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Rotation3D प्रॉपर्टी सेट करें
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # दूसरी चार्ट सीरीज़ लेते हैं
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # अब सीरीज़ डेटा भर रहे हैं
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # OverLap मान सेट करें
    $series->getParentSeriesGroup()->setOverlap(100);
    # प्रस्तुति को डिस्क पर सहेजें
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट्स का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) क्लास के माध्यम से उपलब्ध हैं। सटीक, नवीनतम सूची के लिए अपने स्थापित संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता/सकती हूँ?**

हाँ। आप चार्ट को छवि के रूप में निर्यात कर सकते हैं [chart API](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) के द्वारा या संपूर्ण स्लाइड को [render the entire slide](/slides/hi/php-java/convert-powerpoint-to-png/) करके PNG या JPEG जैसे फॉर्मेट में रेंडर कर सकते हैं। यह उपयोगी है जब आपको पिक्सेल‑परफेक्ट पूर्वावलोकन चाहिए या आप चार्ट को दस्तावेज़, डैशबोर्ड या वेब पेज में एम्बेड करना चाहते हैं बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट बनाना और रेंडर करना कितना प्रदर्शनकारी है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए, 3D प्रभावों को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों में भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला के डेटा बिंदुओं की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुसार उपयुक्त आकार (रिज़ॉल्यूशन और आयाम) के आउटपुट में रेंडर करें।
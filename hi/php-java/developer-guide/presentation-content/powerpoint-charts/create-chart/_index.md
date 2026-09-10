---
title: PHP में PowerPoint प्रस्तुति चार्ट बनाएं या अपडेट करें
linktitle: चार्ट बनाएं या अपडेट करें
type: docs
weight: 10
url: /hi/php-java/create-chart/
keywords:
- चार्ट जोड़ें
- चार्ट बनाएं
- चार्ट संपादित करें
- चार्ट बदलें
- चार्ट अपडेट करें
- स्कैटर चार्ट
- पाई चार्ट
- लाइन चार्ट
- ट्री मैप चार्ट
- स्टॉक चार्ट
- बॉक्स और व्हिस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगरी चार्ट
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रेजेंटेशन में चार्ट बनाएं और अनुकूलित करें। व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके चार्ट बनाने और अनुकूलित करने के लिए एक व्यापक मार्गदर्शिका प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, उसे डेटा से भरें, और अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार विभिन्न फ़ॉर्मेटिंग विकल्प लागू करें। पूरे लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रारंभिक प्रस्तुति और चार्ट ऑब्जेक्ट से लेकर सीरीज़, एक्सिस और लेजेंड को कॉन्फ़िगर करने तक। इस मार्गदर्शिका का पालन करके आप अपनी एप्लिकेशन में डायनमिक चार्ट जेनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा-ड्रिवन प्रस्तुतियों का निर्माण सरल हो जाएगा।

## **चार्ट बनाएं**

चार्ट लोगों को जल्दी से डेटा को विज़ुअलाइज़ करने और ऐसे अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो किसी तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होते।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* एक ही स्लाइड में बड़ी मात्रा में डेटा को समेकित, संक्षिप्त या सारांशित कर सकते हैं
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं
* समय के साथ या किसी विशिष्ट माप इकाई के संबंध में डेटा की दिशा और गति निर्धारित कर सकते हैं
* अपवाद, असामान्यताएँ, विचलन, त्रुटियाँ, बेतुके डेटा आदि की पहचान कर सकते हैं
* जटिल डेटा को संवादित या प्रस्तुत कर सकते हैं

PowerPoint में आप *Insert* फ़ंक्शन के माध्यम से चार्ट बना सकते हैं, जो कई प्रकार के चार्ट डिज़ाइन करने के लिए टेम्प्लेट प्रदान करता है। Aspose.Slides का उपयोग करके आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}

चार्ट बनाने के लिए, [ChartType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) क्लास का उपयोग करें। इस क्लास के फ़ील्ड विभिन्न चार्ट प्रकारों से मेल खाते हैं।

{{% /alert %}}

### **क्लस्टर्ड कॉलम चार्ट बनाएं**

यह अनुभाग Aspose.Slides का उपयोग करके क्लस्टर्ड कॉलम चार्ट बनाने की विधि बताता है। आप प्रस्तुति को प्रारंभ करना, चार्ट जोड़ना, और शीर्षक, डेटा, सीरीज़, श्रेणियाँ और स्टाइलिंग जैसे तत्वों को अनुकूलित करना सीखेंगे। नीचे दिए गए चरणों का पालन करके देखें कि एक मानक क्लस्टर्ड कॉलम चार्ट कैसे उत्पन्न होता है:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. कुछ डेटा के साथ एक चार्ट जोड़ें और `ChartType::ClusteredColumn` प्रकार निर्दिष्ट करें।
1. चार्ट को एक शीर्षक जोड़ें।
1. चार्ट के डेटा वर्कशीट तक पहुँचें।
1. सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. चार्ट सीरीज़ पर एक फ़िल रंग लागू करें।
1. चार्ट सीरीज़ के लिए लेबल जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड क्लस्टर्ड कॉलम चार्ट बनाने को दर्शाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # चार्ट का शीर्षक सेट करता है
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # पहले सीरीज़ को मान दिखाने के लिए सेट करता है
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त करता है
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # डिफ़ॉल्ट रूप से उत्पन्न सीरीज़ और श्रेणियों को हटाता है
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # नई सीरीज़ जोड़ता है
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # नई श्रेणियाँ जोड़ता है
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # पहली चार्ट सीरीज़ लेता है
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # अब सीरीज़ डेटा को भरता है
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # सीरीज़ के लिए फ़िल रंग सेट करता है
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # दूसरी चार्ट सीरीज़ लेता है
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # सीरीज़ डेटा को भरता है
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # सीरीज़ के लिए फ़िल रंग सेट करता है
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # नई सीरीज़ के लिए प्रत्येक श्रेणी के कस्टम लेबल बनाता है
    # पहला लेबल श्रेणी नाम दिखाने के लिए सेट करता है
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # तीसरे लेबल के लिए मान दिखाता है
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # चार्ट के साथ प्रस्तुति सहेजता है
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **स्कैटर चार्ट बनाएं**
स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ़ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न या सहसंबंध जाँचने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास युग्मित संख्यात्मक डेटा हो
* दो चर एक साथ उचित रूप से मिलते हों
* आप यह निर्धारित करना चाहते हों कि दो चर संबंधित हैं या नहीं
* आपके पास एक स्वतंत्र चर हो जिसके कई मान निर्भरशील चर के लिए हों

1. [Create Clustered Column Charts](#create-clustered-column-charts) अनुभाग के चरणों का पालन करें।
2. तीसरे चरण में, कुछ डेटा के साथ एक चार्ट जोड़ें और अपने चार्ट प्रकार को निम्नलिखित में से किसी एक के रूप में निर्दिष्ट करें:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _स्कैटर चार्ट का प्रतिनिधित्व करता है।_
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _वक्रों द्वारा जुड़ा स्कैटर चार्ट, डेटा मार्कर के साथ।_
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _वक्रों द्वारा जुड़ा स्कैटर चार्ट, बिना डेटा मार्कर के।_
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _रेखाओं द्वारा जुड़ा स्कैटर चार्ट, डेटा मार्कर के साथ।_
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _रेखाओं द्वारा जुड़ा स्कैटर चार्ट, बिना डेटा मार्कर के।_

यह PHP कोड प्रत्येक सीरीज़ के लिए विभिन्न मार्कर के साथ स्कैटर चार्ट बनाने को दर्शाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $slide = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट चार्ट बनाता है
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करता है
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त करता है
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # डेमो सीरीज़ को हटाता है
    $chart->getChartData()->getSeries()->clear();
    # नई सीरीज़ जोड़ता है
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # पहली चार्ट सीरीज़ लेता है
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # सीरीज़ में नया बिंदु (1:3) जोड़ता है
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # नया बिंदु (2:10) जोड़ता है
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # सीरीज़ प्रकार बदलता है
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # चार्ट सीरीज़ मार्कर बदलता है
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # दूसरी चार्ट सीरीज़ लेता है
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # वहाँ नया बिंदु (5:2) जोड़ता है
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # नया बिंदु (3:1) जोड़ता है
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # नया बिंदु (2:2) जोड़ता है
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # नया बिंदु (5:1) जोड़ता है
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # चार्ट सीरीज़ मार्कर बदलता है
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑समग्र संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेष रूप से जब डेटा में वर्गीकृत लेबल के साथ संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में कई भाग या लेबल हों, तो आप बार चार्ट का उपयोग करने पर विचार कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::Pie](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#Pie) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. चार्ट के लिए नए पॉइंट जोड़ें और पाई चार्ट के सेक्टरों के लिए कस्टम रंग लागू करें।
9. सीरीज़ के लिए लेबल सेट करें।
10. सीरीज़ लेबल के लिए लीडर लाइन्स सक्षम करें।
11. पाई चार्ट सेक्टरों के लिए घूर्णन कोण सेट करें।
12. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड पाई चार्ट बनाने को दर्शाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $slides = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # चार्ट शीर्षक सेट करता है
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # पहली सीरीज़ को मान दिखाने के लिए सेट करता है
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त करता है
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # डिफ़ॉल्ट जेनरेट की गई सीरीज़ और श्रेणियों को हटाता है
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # नई श्रेणियाँ जोड़ता है
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # नई सीरीज़ जोड़ता है
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # सीरीज़ डेटा को भरता है
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # नई संस्करण में काम नहीं कर रहा है
    # नई पॉइंट जोड़ रहा है और सेक्टर रंग सेट कर रहा है
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # सेक्टर बॉर्डर सेट करता है
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # सेक्टर बॉर्डर सेट करता है
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # सेक्टर बॉर्डर सेट करता है
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # नई सीरीज़ के लिए प्रत्येक श्रेणी के लिए कस्टम लेबल बनाता है
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # चार्ट के लिए लीडर लाइन्स दिखाता है
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # पाई चार्ट सेक्टरों के लिए घुमाव कोण सेट करता है
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # चार्ट के साथ प्रस्तुति को सहेजता है
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट का उपयोग करके आप बड़ी मात्रा में डेटा को एक साथ तुलना कर सकते हैं, समय के साथ बदलाव और रुझान को ट्रैक कर सकते हैं, डेटा सीरीज़ में विसंगतियों को उजागर कर सकते हैं, और अधिक।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::Line](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#Line) प्रकार निर्दिष्ट करें।
1. चार्ट डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड लाइन चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में पॉइंट्स को सीधी निरंतर रेखाओं से जोड़ा जाता है। यदि आप पॉइंट्स को डैश वाले रेखाओं से जोड़ना चाहते हैं, तो आप अपनी पसंदीदा डैश प्रकार को इस प्रकार निर्दिष्ट कर सकते हैं:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट उन स्थितियों में उपयोगी होते हैं जहाँ आप डेटा वर्गों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक वर्ग के बड़े योगदानकर्ताओं पर जल्दी से ध्यान आकर्षित करना चाहते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::Treemap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#Treemap) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड ट्री मैप चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # शाखा 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # शाखा 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **स्टॉक चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#OpenHighLowClose) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. हाई‑लो लाइन्स फ़ॉर्मेट निर्दिष्ट करें।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड स्टॉक चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#BoxAndWhisker) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड बॉक्स एंड व्हिस्कर चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **फ़नल चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::Funnel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#Funnel) प्रकार निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड फ़नल चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **सनबर्स्ट चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::Sunburst](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#Sunburst) प्रकार निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड सनबर्स्ट चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # शाखा 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # शाखा 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **हिस्टोग्राम चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::Histogram](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#Histogram) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड हिस्टोग्राम चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **रेडार चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. कुछ डेटा के साथ एक चार्ट जोड़ें और अपनी पसंदीदा चार्ट प्रकार ([ChartType::Radar](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#Radar) इस मामले में) निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड रेडार चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **मल्टी‑कैटेगरी चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType::ClusteredColumn](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/#ClusteredColumn) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड मल्टी‑कैटेगरी चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # सीरीज़ जोड़ना
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # चार्ट के साथ प्रस्तुति सहेजें
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को विज़ुअलाइज़ करते हैं और क्षेत्रों के बीच मानों की तुलना करने में मदद करते हैं।

यह PHP कोड मैप चार्ट बनाने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **कम्बिनेशन चार्ट बनाएं**

कम्बिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको दो या अधिक डेटा सेटों के बीच अंतर को उजागर, तुलना या निरीक्षण करने की अनुमति देता है, जिससे संबंधों की पहचान आसान हो जाती है।

![The combination chart](combination_chart.png)

नीचे दिया गया PHP कोड ऊपर दिखाए गए कॉम्बिनेशन चार्ट को PowerPoint प्रस्तुति में बनाने को दर्शाता है:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // चार्ट शीर्षक सेट करें।
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // चार्ट लेजेंड सेट करें।
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // डिफ़ॉल्ट जेनरेट की गई सीरीज़ और श्रेणियों को हटाएँ।
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // नई श्रेणियाँ जोड़ें।
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // पहली सीरीज़ जोड़ें।
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // क्षैतिज अक्ष सेट करें।
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // ऊर्ध्वाधर अक्ष सेट करें।
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // ऊर्ध्वाधर प्रमुख ग्रिडलाइन का रंग सेट करें।
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // द्वितीयक क्षैतिज अक्ष सेट करें।
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // द्वितीयक ऊर्ध्वाधर अक्ष सेट करें।
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **चार्ट अपडेट करें**

1. उस प्रस्तुति को प्रतिनिधित्व करने वाले [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं जिसमें वह चार्ट हो जिसे आप अपडेट करना चाहते हैं।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. सभी शेप्स को पार करके इच्छित चार्ट खोजें।
4. चार्ट डेटा वर्कशीट तक पहुँचें।
5. सीरीज़ मान बदलकर चार्ट डेटा सीरीज़ को संशोधित करें।
6. नई सीरीज़ जोड़ें और उसके डेटा को भरें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड चार्ट को अपडेट करने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    # पहली स्लाइड मार्कर तक पहुँचें
    $sld = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट डेटा के साथ चार्ट प्राप्त करें
    $chart = $sld->getShapes()->get_Item(0);
    # चार्ट डेटा शीट का इंडेक्स सेट कर रहा है
    $defaultWorksheetIndex = 0;
    # चार्ट डेटा वर्कशीट प्राप्त कर रहा है
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # चार्ट श्रेणी नाम बदल रहा है
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # पहली चार्ट सीरीज़ लें
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # अब सीरीज़ डेटा अपडेट कर रहे हैं
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1"); // सीरीज़ नाम संशोधित कर रहा है

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # दूसरी चार्ट सीरीज़ लें
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # अब सीरीज़ डेटा अपडेट कर रहे हैं
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2"); // सीरीज़ नाम संशोधित कर रहा है

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # अब, नई सीरीज़ जोड़ रहे हैं
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # तीसरी चार्ट सीरीज़ लें
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # अब सीरीज़ डेटा भर रहे हैं
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # चार्ट के साथ प्रस्तुति सहेजें
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट के लिए डेटा रेंज सेट करें**

चार्ट की डेटा रेंज सेट करने के लिए यह करें:

1. उस प्रस्तुति को प्रतिनिधित्व करने वाले [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं जिसमें चार्ट हो।
2. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. सभी शेप्स को पार करके इच्छित चार्ट खोजें।
4. चार्ट डेटा तक पहुँचें और रेंज सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड चार्ट की डेटा रेंज सेट करने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वतः एक अलग मार्कर प्रतीक मिल जाता है।

यह PHP कोड चार्ट सीरीज़ मार्कर को स्वचालित रूप से सेट करने को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # दूसरी चार्ट सीरीज़ लें
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # अब सीरीज़ डेटा भर रहे हैं
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides कौन‑से चार्ट प्रकारों का समर्थन करता है?**

Aspose.Slides विभिन्न [चार्ट प्रकारों](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) का समर्थन करता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य शामिल हैं। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूं?**

एक नया चार्ट जोड़ने के लिए, पहले [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करें, और फिर चार्ट जोड़ने वाले मेथड को कॉल करें, जिसमें चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करें। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में सम्मिलित करती है।

**मैं चार्ट में दिखाए गए डेटा को कैसे अपडेट करूं?**

आप चार्ट के डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/)) तक पहुँचकर, डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, और अपना कस्टम डेटा जोड़कर चार्ट के डेटा को अपडेट कर सकते हैं। इससे चार्ट नवीनतम डेटा को दर्शाने के लिए रीफ़्रेश हो जाता है।

**क्या चार्ट की उपस्थिति को अनुकूलित करना संभव है?**

हाँ, Aspose.Slides व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य [फ़ॉर्मेटिंग तत्वों](/slides/hi/php-java/chart-entities/) को संशोधित करके चार्ट की उपस्थिति को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुरूप बना सकते हैं।
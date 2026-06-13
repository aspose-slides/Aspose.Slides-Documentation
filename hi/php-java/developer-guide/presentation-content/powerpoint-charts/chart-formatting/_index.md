---
title: PHP में प्रस्तुति चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/php-java/chart-formatting/
keywords:
- चार्ट फ़ॉर्मेट
- चार्ट फ़ॉर्मेटिंग
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में चार्ट फ़ॉर्मेटिंग सीखें और अपने PowerPoint प्रस्तुति को पेशेवर, आकर्षक शैली के साथ उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फॉर्मेट करने का तरीका समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट एरिया और वॉल फ़िल्स जैसी प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को सुधारने को दर्शाता है।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर प्रीसेट और कस्टम न्यूमेरिक फॉर्मेट लागू करने, तथा चार्ट एरिया के लिए गोल कोने सक्षम करने का भी प्रदर्शन करता है। ये सभी उदाहरण प्रस्तुतियों में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने के तरीके दिखाते हैं।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**
Aspose.Slides for PHP via Java डेवलपर्स को शून्य से अपनी स्लाइड्स में कस्टम चार्ट जोड़ने की सुविधा देता है। यह लेख विभिन्न चार्ट इकाइयों को फ़ॉर्मेट करने का तरीका बताता है, जिसमें चार्ट श्रेणी और मान अक्ष शामिल हैं।

Aspose.Slides for PHP via Java विभिन्न चार्ट इकाइयों को प्रबंधित करने और उन्हें कस्टम मानों से फ़ॉर्मेट करने के लिए एक सरल API प्रदान करता है:

1. [**Presentation**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
1. स्लाइड को उसके इंडेक्स से प्राप्त करें।
1. किसी भी इच्छित प्रकार के साथ डिफ़ॉल्ट डेटा वाला चार्ट जोड़ें (इस उदाहरण में हम ChartType::LineWithMarkers का उपयोग करेंगे)।
1. चार्ट के वैल्यू एक्सिस तक पहुँचें और निम्न गुण सेट करें:
   1. वैल्यू एक्सिस मेजर ग्रिड लाइनों के लिए **Line format** सेट करना
   1. वैल्यू एक्सिस मिनर ग्रिड लाइनों के लिए **Line format** सेट करना
   1. वैल्यू एक्सिस के लिए **Number Format** सेट करना
   1. वैल्यू एक्सिस के लिए **Min, Max, Major and Minor units** सेट करना
   1. वैल्यू एक्सिस डेटा के लिए **Text Properties** सेट करना
   1. वैल्यू एक्सिस के लिए **Title** सेट करना
   1. वैल्यू एक्सिस के लिए **Line Format** सेट करना
1. चार्ट के कैटेगरी एक्सिस तक पहुँचें और निम्न गुण सेट करें:
   1. कैटेगरी एक्सिस मेजर ग्रिड लाइनों के लिए **Line format** सेट करना
   1. कैटेगरी एक्सिस मिनर ग्रिड लाइनों के लिए **Line format** सेट करना
   1. कैटेगरी एक्सिस डेटा के लिए **Text Properties** सेट करना
   1. कैटेगरी एक्सिस के लिए **Title** सेट करना
   1. कैटेगरी एक्सिस के लिए **Label Positioning** सेट करना
   1. कैटेगरी एक्सिस लेबल्स के लिए **Rotation Angle** सेट करना
1. चार्ट के लेजेंड तक पहुँचें और उनके लिए **Text Properties** सेट करें
1. ओवरलैपिंग चार्ट के बिना चार्ट लेजेंड दिखाएँ
1. चार्ट के **Secondary Value Axis** तक पहुँचें और निम्न गुण सेट करें:
   1. सेकेंडरी **Value Axis** को सक्षम करें
   1. सेकेंडरी वैल्यू एक्सिस के लिए **Line Format** सेट करना
   1. सेकेंडरी वैल्यू एक्सिस के लिए **Number Format** सेट करना
   1. सेकेंडरी वैल्यू एक्सिस के लिए **Min, Max, Major and Minor units** सेट करना
1. अब सेकेंडरी वैल्यू एक्सिस पर पहला चार्ट सीरीज़ प्लॉट करें
1. चार्ट बैक वॉल फ़िल कलर सेट करें
1. चार्ट प्लॉट एरिया फ़िल कलर सेट करें
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें

```php
  # Presentation क्लास की एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँच रहे हैं
    $slide = $pres->getSlides()->get_Item(0);
    # नमूना चार्ट जोड़ रहे हैं
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # चार्ट शीर्षक सेट कर रहे हैं
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # वैल्यू एक्सिस के लिए मेजर ग्रिड लाइनों का फॉर्मेट सेट कर रहे हैं
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # वैल्यू एक्सिस के लिए माइनर ग्रिड लाइनों का फॉर्मेट सेट कर रहे हैं
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # वैल्यू एक्सिस का नंबर फॉर्मेट सेट कर रहे हैं
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # चार्ट के अधिकतम और न्यूनतम मान सेट कर रहे हैं
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # वैल्यू एक्सिस के टेक्स्ट गुण सेट कर रहे हैं
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # वैल्यू एक्सिस शीर्षक सेट कर रहे हैं
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # कैटेगरी एक्सिस के लिए मेजर ग्रिड लाइनों का फॉर्मेट सेट कर रहे हैं
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # कैटेगरी एक्सिस के लिए माइनर ग्रिड लाइनों का फॉर्मेट सेट कर रहे हैं
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # कैटेगरी एक्सिस के टेक्स्ट गुण सेट कर रहे हैं
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # कैटेगरी शीर्षक सेट कर रहे हैं
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # कैटेगरी एक्सिस लेबल स्थिति सेट कर रहे हैं
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # कैटेगरी एक्सिस लेबल घूर्णन कोण सेट कर रहे हैं
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # लेजेंड के टेक्स्ट गुण सेट कर रहे हैं
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # चार्ट के साथ ओवरलैप किए बिना लेजेंड दिखाने के लिए सेट करें
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # सेकेंडरी वैल्यू एक्सिस सेट कर रहे हैं
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # सेकेंडरी वैल्यू एक्सिस का नंबर फॉर्मेट सेट कर रहे हैं
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # चार्ट के अधिकतम और न्यूनतम मान सेट कर रहे हैं
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # चार्ट बैक वॉल का रंग सेट कर रहे हैं
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # प्लॉट एरिया का रंग सेट कर रहे हैं
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # प्रस्तुति सहेजें
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for PHP via Java चार्ट के लिए फ़ॉन्ट संबंधित गुण सेट करने का समर्थन प्रदान करता है। कृपया नीचे दिए गए चरणों का पालन करके चार्ट के फ़ॉन्ट गुण सेट करें।

- [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास ऑब्जेक्ट का इंस्टैंसिएशन करें।
- स्लाइड पर चार्ट जोड़ें।
- फ़ॉन्ट की ऊँचाई सेट करें।
- संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```php
  # Presentation क्लास की एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **न्यूमेरिक फॉर्मेट सेट करें**
Aspose.Slides for PHP via Java चार्ट डेटा फ़ॉर्मेट को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएँ।
1. स्लाइड को उसके इंडेक्स से प्राप्त करें।
1. किसी भी इच्छित प्रकार के साथ डिफ़ॉल्ट डेटा वाला चार्ट जोड़ें (इस उदाहरण में **ChartType::ClusteredColumn** उपयोग किया गया है)।
1. उपलब्ध प्रीसेट मानों में से प्रीसेट नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ में चार्ट डेटा सेल को पार करते हुए चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति सहेजें।
1. कस्टम नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ में चार्ट डेटा सेल को पार करते हुए अलग-अलग चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति सहेजें।

```php
  # Presentation क्लास की एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # पहले प्रस्तुतीकरण स्लाइड तक पहुँचें
    $slide = $pres->getSlides()->get_Item(0);
    # डिफ़ॉल्ट क्लस्टर्ड कॉलम चार्ट जोड़ें
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # चार्ट सीरीज़ संग्रह तक पहुँच रहे हैं
    $series = $chart->getChartData()->getSeries();
    # प्रत्येक चार्ट सीरीज़ के माध्यम से ट्रैवर्स करें
    foreach($series as $ser) {
      # सीरीज़ में प्रत्येक डेटा सेल के माध्यम से ट्रैवर्स करें
      foreach($ser->getDataPoints() as $cell) {
        # नंबर फ़ॉर्मेट सेट कर रहे हैं
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # प्रस्तुति सहेजें
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

नीचे संभव प्रीसेट नंबर फ़ॉर्मेट मान, उनके इंडेक्स के साथ दिए गए हैं:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **चार्ट एरिया को गोल किनारा दें**
Aspose.Slides for PHP via Java चार्ट एरिया को सेट करने का समर्थन प्रदान करता है। [**hasRoundedCorners**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/hasroundedcorners/) और [**setRoundedCorners**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/setroundedcorners/) मेथड्स को [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Chart) क्लास में जोड़ा गया है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास ऑब्जेक्ट का इंस्टैंसिएशन करें।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट का फ़िल टाइप और फ़िल कलर सेट करें।
1. गोल कोना गुण को True सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```php
  # Presentation क्लास की एक इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**क्या मैं कॉलम/एरिया के लिए अर्धपारदर्शी फ़िल सेट कर सकता हूँ जबकि बॉर्डर अपरदर्शी रहे?**

हाँ। फ़िल ट्रांसपेरेंसी और आउटलाइन को अलग-अलग कॉन्फ़िगर किया जाता है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता को बेहतर बनाने में उपयोगी है।

**लेबल ओवरलैप होने पर मैं कैसे निपटूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (जैसे श्रेणियाँ) को अक्षम करें, लेबल ऑफ़सेट/पोज़िशन सेट करें, आवश्यक होने पर केवल चयनित पॉइंट्स के लिए लेबल दिखाएँ, या फॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल अप्लाई कर सकता हूँ?**

हाँ। ठोस और ग्रेडिएंट/पैटर्न फ़िल दोनों आमतौर पर उपलब्ध होते हैं। व्यावहारिक रूप से, ग्रेडिएंट का सीमित उपयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट कम कर दें।
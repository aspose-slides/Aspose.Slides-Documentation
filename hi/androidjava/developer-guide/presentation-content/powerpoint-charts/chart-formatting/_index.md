---
title: एंड्रॉइड पर प्रस्तुति चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/androidjava/chart-formatting/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में चार्ट फ़ॉर्मेटिंग सीखें और अपने PowerPoint प्रस्तुति को पेशेवर, आकर्षक शैली के साथ उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फॉर्मेट करने के तरीके को समझाता है। यह दिखाता है कि अक्ष, ग्रिड लाइन्स, शीर्षक, लेजेंड, प्लॉट एरिया और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को कैसे अनुकूलित किया जाए ताकि चार्ट डेटा की उपस्थिति और पठनीयता बेहतर हो सके।

यह यह भी दर्शाता है कि चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण कैसे सेट करें, चार्ट डेटा पर पूर्वनिर्धारित और कस्टम संख्यात्मक फ़ॉर्मेट लागू करें, और चार्ट एरिया के लिए गोल किनारे सक्षम करें। साथ मिलकर ये उदाहरण दिखाते हैं कि प्रस्तुति में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को कैसे नियंत्रित किया जाए।

## **चार्ट संस्थाओं का फ़ॉर्मेटिंग**
Aspose.Slides for Android via Java डेवलपर्स को शून्य से अपने स्लाइड्स में कस्टम चार्ट जोड़ने की सुविधा देता है। यह लेख विभिन्न चार्ट संस्थाओं जैसे चार्ट श्रेणी और मान अक्ष को फ़ॉर्मेट करने का विवरण देता है।

Aspose.Slides for Android via Java विभिन्न चार्ट संस्थाओं को प्रबंधित करने और कस्टम मानों के साथ फ़ॉर्मेट करने के लिए एक सरल API प्रदान करता है:

1. **[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/)** वर्ग की एक उदाहरण बनाएँ।
1. उसकी अनुक्रमणिका द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. इच्छित प्रकार (इस उदाहरण में हम **ChartType.LineWithMarkers** का उपयोग करेंगे) के साथ डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. चार्ट के वैल्यू एक्सिस तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. वैल्यू एक्सिस मेजर ग्रिड लाइन्स के लिए **Line format** सेट करना
   1. वैल्यू एक्सिस माइनर ग्रिड लाइन्स के लिए **Line format** सेट करना
   1. वैल्यू एक्सिस के लिए **Number Format** सेट करना
   1. वैल्यू एक्सिस के लिए **Min, Max, Major and Minor units** सेट करना
   1. वैल्यू एक्सिस डेटा के लिए **Text Properties** सेट करना
   1. वैल्यू एक्सिस के लिए **Title** सेट करना
   1. वैल्यू एक्सिस के लिए **Line Format** सेट करना
1. चार्ट के कैटेगरी एक्सिस तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. कैटेगरी एक्सिस मेजर ग्रिड लाइन्स के लिए **Line format** सेट करना
   1. कैटेगरी एक्सिस माइनर ग्रिड लाइन्स के लिए **Line format** सेट करना
   1. कैटेगरी एक्सिस डेटा के लिए **Text Properties** सेट करना
   1. कैटेगरी एक्सिस के लिए **Title** सेट करना
   1. कैटेगरी एक्सिस के लिए **Label Positioning** सेट करना
   1. कैटेगरी एक्सिस लेबल्स के लिए **Rotation Angle** सेट करना
1. चार्ट के लेजेंड तक पहुँचें और उनके लिए **Text Properties** सेट करें
1. चार्ट लेजेंड को ओवरलैपिंग चार्ट के बिना दिखाएँ
1. चार्ट के **Secondary Value Axis** तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. द्वितीयक **Value Axis** सक्षम करें
   1. द्वितीयक वैल्यू एक्सिस के लिए **Line Format** सेट करें
   1. द्वितीयक वैल्यू एक्सिस के लिए **Number Format** सेट करें
   1. द्वितीयक वैल्यू एक्सिस के लिए **Min, Max, Major and Minor units** सेट करें
1. अब द्वितीयक वैल्यू एक्सिस पर पहला चार्ट सीरीज़ प्लॉट करें
1. चार्ट के बैक वॉल फ़िल रंग सेट करें
1. चार्ट प्लॉट एरिया फ़िल रंग सेट करें
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें

```java
// Presentation class की एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहले स्लाइड तक पहुँच रहा है
    ISlide slide = pres.getSlides().get_Item(0);

    // नमूना चार्ट जोड़ रहा है
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // चार्ट शीर्षक सेट कर रहा है
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // वैल्यू अक्ष के लिए मेजर ग्रिड लाइन्स फ़ॉर्मेट सेट कर रहा है
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // वैल्यू अक्ष के लिए माइनर ग्रिड लाइन्स फ़ॉर्मेट सेट कर रहा है
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // वैल्यू अक्ष का नंबर फ़ॉर्मेट सेट कर रहा है
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // चार्ट के अधिकतम, न्यूनतम मान सेट कर रहा है
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // वैल्यू एक्सिस टेक्स्ट प्रॉपर्टीज़ सेट कर रहा है
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // वैल्यू अक्ष शीर्षक सेट कर रहा है
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // कैटेगरी अक्ष के लिए मेजर ग्रिड लाइन्स फ़ॉर्मेट सेट कर रहा है
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // कैटेगरी अक्ष के लिए माइनर ग्रिड लाइन्स फ़ॉर्मेट सेट कर रहा है
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // कैटेगरी अक्ष के टेक्स्ट प्रॉपर्टीज़ सेट कर रहा है
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // कैटेगरी शीर्षक सेट कर रहा है
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // कैटेगरी अक्ष लेबल की स्थिति सेट कर रहा है
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // कैटेगरी अक्ष लेबल घूर्णन कोण सेट कर रहा है
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // लेजेंड्स टेक्स्ट प्रॉपर्टीज़ सेट कर रहा है
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // ओवरलैपिंग चार्ट के बिना चार्ट लेजेंड दिखाने के लिए सेट करें

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // सेकेंडरी वैल्यू अक्ष सेट कर रहा है
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // सेकेंडरी वैल्यू अक्ष का नंबर फ़ॉर्मेट सेट कर रहा है
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // चार्ट के अधिकतम, न्यूनतम मान सेट कर रहा है
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // चार्ट बैक वॉल रंग सेट कर रहा है
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // प्लॉट एरिया रंग सेट कर रहा है
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // प्रस्तुति सहेजें
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for Android via Java चार्ट के लिए फ़ॉन्ट से संबंधित गुण सेट करने का समर्थन प्रदान करता है। कृपया चार्ट के फ़ॉन्ट गुण सेट करने के लिए नीचे दिए गए चरणों का पालन करें।

- **[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/)** वर्ग का ऑब्जेक्ट बनाएँ।
- स्लाइड पर चार्ट जोड़ें।
- फ़ॉन्ट की ऊँचाई सेट करें।
- संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया नमूना उदाहरण है।

```java
// Presentation वर्ग की एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **संख्यात्मक फ़ॉर्मेट सेट करें**
Aspose.Slides for Android via Java चार्ट डेटा फ़ॉर्मेट को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. **[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation)** वर्ग की एक उदाहरण बनाएँ।
1. उसकी अनुक्रमणिका द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. इच्छित प्रकार (इस उदाहरण में **ChartType.ClusteredColumn** उपयोग किया गया है) के साथ डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. उपलब्ध प्रीसेट मूल्यों में से प्रीसेट नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ में चार्ट डेटा सेल के माध्यम से पार करके चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति सहेजें।
1. कस्टम नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ में चार्ट डेटा सेल के माध्यम से पार करके अलग-अलग चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति सहेजें।

```java
// Presentation वर्ग की एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली प्रस्तुति स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // एक डिफ़ॉल्ट क्लस्टर्ड कॉलम चार्ट जोड़ें
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // चार्ट सीरीज़ संग्रह तक पहुँच रहे हैं
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // प्रत्येक चार्ट सीरीज़ पर इटररेट कर रहे हैं
    for (IChartSeries ser : series) 
    {
        // सीरीज़ में प्रत्येक डेटा सेल पर इटररेट कर रहे हैं
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // नंबर फ़ॉर्मेट सेट कर रहे हैं
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // प्रस्तुति सहेजें
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

निचे दिए गए प्रीसेट नंबर फ़ॉर्मेट मान और उनके अनुक्रमणिका दिए गये हैं:

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

## **चार्ट एरिया गोल किनारे सेट करें**
Aspose.Slides for Android via Java चार्ट एरिया सेट करने के लिए समर्थन प्रदान करता है। मेथड **[hasRoundedCorners](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart#hasRoundedCorners--)** और **[setRoundedCorners](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-)** को **[IChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart)** इंटरफ़ेस और **[Chart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Chart)** वर्ग में जोड़ा गया है।

1. **[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation)** वर्ग का ऑब्जेक्ट बनाएँ।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट का फ़िल टाइप और फ़िल रंग सेट करें।
1. गोल कोना गुण को True सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया नमूना उदाहरण है।  

```java
// Presentation वर्ग की एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सामान्य प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध-पारदर्शी फ़िल सेट कर सकता हूँ जबकि बॉर्डर अपारदर्शी रहे?**

हाँ। फ़िल पारदर्शिता और रूपरेखा को अलग-अलग कॉन्फ़िगर किया जाता है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता सुधारने के लिए उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार कम करें, गैर‑आवश्यक लेबल घटकों (जैसे श्रेणियाँ) को निष्क्रिय करें, लेबल ऑफसेट/स्थिति सेट करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल लागू कर सकता हूँ?**

हाँ। ठोस तथा ग्रेडिएंट/पैटर्न फ़िल आमतौर पर उपलब्ध होते हैं। व्यावहारिक रूप से, ग्रेडिएंट का संक्षिप्त उपयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के बीच कंट्रास्ट को कम कर दें।
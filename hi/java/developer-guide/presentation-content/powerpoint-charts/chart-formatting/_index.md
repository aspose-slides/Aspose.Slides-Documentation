---
title: Java में प्रस्तुति चार्ट को फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/java/chart-formatting/
keywords:
- चार्ट फ़ॉर्मेट
- चार्ट फ़ॉर्मेटिंग
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल कोना
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में चार्ट फ़ॉर्मेटिंग सीखें और अपने PowerPoint प्रस्तुति को पेशेवर, आकर्षक शैली के साथ उन्नत बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फॉर्मेट करने का तरीका समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लेजेंड, प्लॉट क्षेत्र, और वॉल भराव जैसी प्रमुख चार्ट तत्वों को अनुकूलित करने का तरीका दिखाता है, जिससे चार्ट डेटा की उपस्थिति और पठनीयता में सुधार होता है।

यह चार्ट टेक्स्ट के फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर प्रीसेट और कस्टम संख्यात्मक फ़ॉर्मेट लागू करने, और चार्ट क्षेत्र के लिए गोल कोने सक्षम करने का भी प्रदर्शन करता है। साथ में, ये उदाहरण प्रस्तुतियों में चार्ट के दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने का तरीका दर्शाते हैं।

## **चार्ट इकाइयों को फॉर्मेट करना**
Aspose.Slides for Java डेवलपर्स को शून्य से अपने स्लाइड्स में कस्टम चार्ट जोड़ने देता है। यह लेख विभिन्न चार्ट इकाइयों जैसे कि चार्ट श्रेणी और मान अक्ष को फॉर्मेट करने का तरीका बताता है।

Aspose.Slides for Java विभिन्न चार्ट इकाइयों का प्रबंधन करने और उन्हें कस्टम मूल्यों के साथ फॉर्मेट करने के लिए एक सरल API प्रदान करता है:

1. एक नया [**Presentation**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. स्लाइड को उसके अनुक्रमणिका द्वारा प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और इच्छित प्रकार में से कोई एक चुनें (इस उदाहरण में हम ChartType.LineWithMarkers का उपयोग करेंगे)।
1. चार्ट के Value Axis तक पहुंचें और निम्नलिखित गुण सेट करें:
   1. Value Axis की Major Grid रेखाओं के लिए **Line format** सेट करें।
   1. Value Axis की Minor Grid रेखाओं के लिए **Line format** सेट करें।
   1. Value Axis के लिए **Number Format** सेट करें।
   1. Value Axis के लिए **Min, Max, Major and Minor units** सेट करें।
   1. Value Axis डेटा के लिए **Text Properties** सेट करें।
   1. Value Axis का **Title** सेट करें।
   1. Value Axis के लिए **Line Format** सेट करें।
1. चार्ट के Category Axis तक पहुंचें और निम्नलिखित गुण सेट करें:
   1. Category Axis की Major Grid रेखाओं के लिए **Line format** सेट करें।
   1. Category Axis की Minor Grid रेखाओं के लिए **Line format** सेट करें।
   1. Category Axis डेटा के लिए **Text Properties** सेट करें।
   1. Category Axis का **Title** सेट करें।
   1. Category Axis के लिए **Label Positioning** सेट करें।
   1. Category Axis लेबल के लिए **Rotation Angle** सेट करें।
1. चार्ट के Legend तक पहुंचें और उनके लिए **Text Properties** सेट करें।
1. चार्ट लेजेंड को इस प्रकार दिखाएँ कि वह चार्ट के साथ ओवरलैप न हो।
1. चार्ट के **Secondary Value Axis** तक पहुंचें और नीचे दिए गए गुण सेट करें:
   1. Secondary **Value Axis** को सक्षम करें।
   1. Secondary Value Axis के लिए **Line Format** सेट करें।
   1. Secondary Value Axis के लिए **Number Format** सेट करें।
   1. Secondary Value Axis के लिए **Min, Max, Major and Minor units** सेट करें।
1. अब पहले चार्ट सीरीज़ को Secondary Value Axis पर प्लॉट करें।
1. चार्ट की बैक वॉल भराव रंग सेट करें।
1. चार्ट के प्लॉट एरिया का भराव रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंच रहे हैं
    ISlide slide = pres.getSlides().get_Item(0);

    // नमूना चार्ट जोड़ रहे हैं
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // चार्ट शीर्षक सेट कर रहे हैं
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // मान अक्ष के लिए प्रमुख ग्रिड रेखाओं का फ़ॉर्मेट सेट कर रहे हैं
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // मान अक्ष के लिए उप-ग्रिड रेखाओं का फ़ॉर्मेट सेट कर रहे हैं
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // मान अक्ष का संख्या फ़ॉर्मेट सेट कर रहे हैं
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // चार्ट के अधिकतम, न्यूनतम मान सेट कर रहे हैं
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // मान अक्ष के टेक्स्ट गुण सेट कर रहे हैं
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // मान अक्ष का शीर्षक सेट कर रहे हैं
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // श्रेणी अक्ष के लिए प्रमुख ग्रिड रेखाओं का फ़ॉर्मेट सेट कर रहे हैं
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // श्रेणी अक्ष के लिए उप-ग्रिड रेखाओं का फ़ॉर्मेट सेट कर रहे हैं
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // श्रेणी अक्ष के टेक्स्ट गुण सेट कर रहे हैं
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // श्रेणी शीर्षक सेट कर रहे हैं
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // श्रेणी अक्ष लेबल स्थिति सेट कर रहे हैं
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // श्रेणी अक्ष लेबल घुमाव कोण सेट कर रहे हैं
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // लेजेंड के टेक्स्ट गुण सेट कर रहे हैं
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // चार्ट लेजेंड दिखाएँ बिना चार्ट के साथ ओवरलैप हुए

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // द्वितीयक मान अक्ष सेट कर रहे हैं
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // द्वितीयक मान अक्ष का संख्या फ़ॉर्मेट सेट कर रहे हैं
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // चार्ट के अधिकतम, न्यूनतम मान सेट कर रहे हैं
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // चार्ट की बैक वॉल का रंग सेट कर रहे हैं
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // प्लॉट एरिया का रंग सेट कर रहे हैं
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // प्रस्तुति सहेजें
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करना**
Aspose.Slides for Java चार्ट के फ़ॉन्ट-संबंधित गुण सेट करने के लिए समर्थन प्रदान करता है। कृपया नीचे दिए गए चरणों का पालन करके चार्ट के फ़ॉन्ट गुण सेट करें।

- एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास ऑब्जेक्ट बनाएँ।
- स्लाइड पर चार्ट जोड़ें।
- फ़ॉन्ट की ऊँचाई सेट करें।
- संशोधित प्रस्तुति को सहेजें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
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

## **संख्यात्मक फ़ॉर्मेट सेट करना**
Aspose.Slides for Java चार्ट डेटा फ़ॉर्मेट प्रबंधन के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएं।
1. स्लाइड को उसके अनुक्रमणिका से प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और इच्छित प्रकार चुनें (इस उदाहरण में **ChartType.ClusteredColumn** का उपयोग किया गया है)।
1. संभव प्रीसेट मानों में से प्रीसेट नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ में चार्ट डेटा सेल के माध्यम से जाएँ और चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति को सहेजें।
1. कस्टम नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ में चार्ट डेटा सेल के माध्यम से जाएँ और विभिन्न चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति को सहेजें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली प्रस्तुति स्लाइड तक पहुंचें
    ISlide slide = pres.getSlides().get_Item(0);

    // डिफ़ॉल्ट क्लस्टर्ड कॉलम चार्ट जोड़ें
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // चार्ट सीरीज़ संग्रह तक पहुंच रहे हैं
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // प्रत्येक चार्ट सीरीज़ के माध्यम से जाएँ
    for (IChartSeries ser : series) 
    {
        // सीरीज़ में प्रत्येक डेटा सेल के माध्यम से जाएँ
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // संख्या फ़ॉर्मेट सेट कर रहे हैं
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // प्रस्तुति सहेज रहे हैं
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**0**|सामान्य|
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

## **चार्ट एरिया के गोल किनारे सेट करना**
Aspose.Slides for Java चार्ट एरिया सेट करने के लिए समर्थन प्रदान करता है। मेथड्स [**hasRoundedCorners**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChart#hasRoundedCorners--) और [**setRoundedCorners**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) को [IChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChart) इंटरफ़ेस और [Chart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Chart) क्लास में जोड़ा गया है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास ऑब्जेक्ट बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट का फ़िल टाइप और फ़िल रंग सेट करें।
1. गोल किनारा प्रॉपर्टी को True सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्द्ध-पारदर्शी भराव सेट कर सकता हूँ जबकि बॉर्डर को अपारदर्शी रख सकता हूँ?**

हां। फ़िल ट्रांसपैरेंसी और आउटलाइन को अलग-अलग कॉन्फ़िगर किया जाता है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार कम करें, गैर-आवश्यक लेबल घटकों को निष्क्रिय करें (जैसे श्रेणियां), लेबल ऑफ़सेट/स्थिति सेट करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को "value + legend" में बदल दें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न भराव लागू कर सकता हूँ?**

हां। ठोस और ग्रेडिएंट/पैटर्न भराव आमतौर पर उपलब्ध होते हैं। व्यावहारिक रूप से, ग्रेडिएंट का उपयोग सीमित मात्रा में करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को कम कर दें।
---
title: जावास्क्रिप्ट में प्रस्तुति चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/nodejs-java/chart-formatting/
keywords:
  - चार्ट फॉर्मेट
  - चार्ट फॉर्मेटिंग
  - चार्ट इकाई
  - चार्ट गुण
  - चार्ट सेटिंग्स
  - चार्ट विकल्प
  - फ़ॉन्ट गुण
  - गोल किनारा
  - PowerPoint
  - प्रस्तुति
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js में जावास्क्रिप्ट के लिए चार्ट फॉर्मेटिंग सीखें और अपने PowerPoint प्रस्तुति को पेशेवर, आकर्षक शैली के साथ उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने की विधि समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट एरिया, और वॉल फ़िल्स जैसी प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता में सुधार करने के तरीकों को दर्शाता है।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर प्रीसेट और कस्टम संख्यात्मक फ़ॉर्मेट लागू करने, तथा चार्ट एरिया के लिए गोल किनारे सक्षम करने का भी प्रदर्शन करता है। ये उदाहरण मिलकर दर्शाते हैं कि प्रस्तुतियों में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को कैसे नियंत्रित किया जा सकता है।

## **फ़ॉर्मेट चार्ट इकाइयाँ**

Aspose.Slides for Node.js via Java डेवलपर्स को शून्य से कस्टम चार्ट अपनी स्लाइड्स में जोड़ने की सुविधा देता है। यह लेख विभिन्न चार्ट इकाइयों को फ़ॉर्मेट करने की विधि समझाता है, जिसमें चार्ट श्रेणी और मान अक्ष शामिल हैं।

Aspose.Slides for Node.js via Java विभिन्न चार्ट इकाइयों को प्रबंधित करने और उन्हें कस्टम मानों के साथ फ़ॉर्मेट करने के लिए एक सरल API प्रदान करता है:

1. एक [**Presentation**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार का चार्ट जोड़ें (इस उदाहरण में हम ChartType.LineWithMarkers का उपयोग करेंगे)।
1. चार्ट के Value Axis को एक्सेस करें और निम्नलिखित गुण सेट करें:
   1. Value Axis Major Grid lines के लिए **Line format** सेट करना
   1. Value Axis Minor Grid lines के लिए **Line format** सेट करना
   1. Value Axis के लिए **Number Format** सेट करना
   1. Value Axis के लिए **Min, Max, Major and Minor units** सेट करना
   1. Value Axis डेटा के लिए **Text Properties** सेट करना
   1. Value Axis के लिए **Title** सेट करना
   1. Value Axis के लिए **Line Format** सेट करना
1. चार्ट के Category Axis को एक्सेस करें और निम्नलिखित गुण सेट करें:
   1. Category Axis Major Grid lines के लिए **Line format** सेट करना
   1. Category Axis Minor Grid lines के लिए **Line format** सेट करना
   1. Category Axis डेटा के लिए **Text Properties** सेट करना
   1. Category Axis के लिए **Title** सेट करना
   1. Category Axis के लिए **Label Positioning** सेट करना
   1. Category Axis लेबल्स के लिए **Rotation Angle** सेट करना
1. चार्ट के Legend को एक्सेस करें और उनके लिए **Text Properties** सेट करें
1. चार्ट लेजेंड को बिना ओवरलैपिंग के दिखाएँ
1. चार्ट के **Secondary Value Axis** को एक्सेस करें और निम्नलिखित गुण सेट करें:
   1. द्वितीयक **Value Axis** सक्षम करें
   1. द्वितीयक Value Axis के लिए **Line Format** सेट करें
   1. द्वितीयक Value Axis के लिए **Number Format** सेट करें
   1. द्वितीयक Value Axis के लिए **Min, Max, Major and Minor units** सेट करें
1. अब द्वितीयक Value Axis पर पहले चार्ट सीरीज़ को प्लॉट करें
1. चार्ट के बैक वॉल फ़िल रंग को सेट करें
1. चार्ट के प्लॉट एरिया फ़िल रंग को सेट करें
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें

```javascript
// Presentation क्लास की एक instance बनाएं
var pres = new aspose.slides.Presentation();
try {
    // प्रथम स्लाइड को एक्सेस करना
    var slide = pres.getSlides().get_Item(0);
    // नमूना चार्ट जोड़ना
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // चार्ट शीर्षक सेट करना
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // मान अक्ष के लिए प्रमुख ग्रिड लाइनों का फ़ॉर्मेट सेट करना
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // मान अक्ष के लिए गौण ग्रिड लाइनों का फ़ॉर्मेट सेट करना
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // मान अक्ष के संख्या फ़ॉर्मेट सेट करना
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // चार्ट अधिकतम, न्यूनतम मान सेट करना
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // मान अक्ष के टेक्स्ट गुण सेट करना
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // मान अक्ष का शीर्षक सेट करना
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // श्रेणी अक्ष के लिए प्रमुख ग्रिड लाइनों का फ़ॉर्मेट सेट करना
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // श्रेणी अक्ष के लिए गौण ग्रिड लाइनों का फ़ॉर्मेट सेट करना
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // श्रेणी अक्ष के टेक्स्ट गुण सेट करना
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // श्रेणी शीर्षक सेट करना
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // श्रेणी अक्ष लेबल की स्थिति सेट करना
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // श्रेणी अक्ष लेबल घूर्णन कोण सेट करना
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // लीजेंड टेक्स्ट गुण सेट करना
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // ओवरले किए बिना चार्ट लीजेंड दिखाएँ
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // द्वितीयक मान अक्ष सेट करना
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // द्वितीयक मान अक्ष का संख्या फ़ॉर्मेट सेट करना
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // चार्ट अधिकतम, न्यूनतम मान सेट करना
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // चार्ट बैक वॉल का रंग सेट करना
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // प्लॉट एरिया का रंग सेट करना
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // प्रस्तुति सहेजें
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

Aspose.Slides for Node.js via Java चार्ट के लिए फ़ॉन्ट-संबंधित गुण सेट करने का समर्थन प्रदान करता है। कृपया चार्ट के फ़ॉन्ट गुण सेट करने के लिए नीचे दिए गए चरणों का पालन करें।

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।
- स्लाइड पर एक चार्ट जोड़ें।
- फ़ॉन्ट की ऊँचाई सेट करें।
- संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```javascript
// Presentation क्लास की एक instance बनाएं
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **संख्यात्मक फ़ॉर्मेट सेट करें**

Aspose.Slides for Node.js via Java चार्ट डेटा फ़ॉर्मेट प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
1. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार का चार्ट जोड़ें (इस उदाहरण में **ChartType.ClusteredColumn** का उपयोग किया गया है)।
1. उपलब्ध प्रीसेट मानों में से प्रीसेट नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ में चार्ट डेटा सेल को ट्रैवर्स करें और चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति को सहेजें।
1. कस्टम नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ के अंदर चार्ट डेटा सेल को ट्रैवर्स करें और अलग-अलग चार्ट डेटा नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुति को सहेजें।

```javascript
// Presentation क्लास की एक instance बनाएं
var pres = new aspose.slides.Presentation();
try {
    // पहली प्रस्तुति स्लाइड तक पहुँचें
    var slide = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट क्लस्टर्ड कॉलम चार्ट जोड़ना
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // चार्ट सीरीज़ कलेक्शन तक पहुँचना
    var series = chart.getChartData().getSeries();
    // प्रत्येक चार्ट सीरीज़ में ट्रैवर्स करना
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // सीरीज़ में प्रत्येक डेटा सेल में ट्रैवर्स करना
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // संख्या फ़ॉर्मेट सेट करना
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // प्रस्तुति सहेजना
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

संभव प्रीसेट नंबर फ़ॉर्मेट मान उनके प्रीसेट इंडेक्स के साथ नीचे दिए गए हैं:

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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **चार्ट एरिया गोल किनारे सेट करें**

Aspose.Slides for Node.js via Java चार्ट एरिया के लिए गोल किनारे सेट करने का समर्थन प्रदान करता है। मेथड्स [**hasRoundedCorners**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) और [**setRoundedCorners**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) को [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart) क्लास में जोड़ा गया है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।
1. स्लाइड पर एक चार्ट जोड़ें।
1. चार्ट का फ़िल टाइप और फ़िल रंग सेट करें।
1. गोल किनारा प्रॉपर्टी को True सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```javascript
// Presentation क्लास की एक instance बनाएं
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या मैं कॉलम/एरिया के लिए अर्ध-पारदर्शी फ़िल्स सेट कर सकता हूँ जबकि बॉर्डर अपारदर्शी रहे?**

हाँ। फ़िल ट्रांसपेरेंसी और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता में सुधार के लिए उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं कैसे निपटूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (जैसे श्रेणियाँ) को अक्षम करें, लेबल ऑफ़सेट/स्थिति सेट करें, आवश्यक हो तो केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हाँ। सॉलिड और ग्रेडिएंट/पैटर्न फ़िल्स दोनों आम तौर पर उपलब्ध होते हैं। वास्तविक उपयोग में ग्रेडिएंट को सीमित मात्रा में प्रयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को घटाते हों।
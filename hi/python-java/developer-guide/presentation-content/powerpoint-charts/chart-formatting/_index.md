---
title: Python में प्रेज़ेंटेशन चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/python-java/chart-formatting/
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
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java में चार्ट फ़ॉर्मेटिंग सीखें और अपने PowerPoint प्रेज़ेंटेशन को पेशेवर, आकर्षक शैली के साथ उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के तरीके को समझाता है। यह अक्ष, ग्रिड लाइनें, शीर्षक, लीजेंड, प्लॉट एरिया और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को सुधारने का तरीका दिखाता है।

यह चार्ट टेक्स्ट के फ़ॉन्ट गुण निर्धारित करने, चार्ट डेटा पर पूर्व निर्धारित और कस्टम संख्यात्मक फ़ॉर्मेट लागू करने, और चार्ट एरिया के लिए गोल कोनों को सक्षम करने का भी प्रदर्शन करता है। ये सभी उदाहरण मिलकर प्रस्तुतियों में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने का तरीका दर्शाते हैं।

## **फ़ॉर्मेट चार्ट एंटिटीज़**
Aspose.Slides for Python via Java डेवलपर्स को शून्य से कस्टम चार्ट अपने स्लाइड्स में जोड़ने की सुविधा देता है। यह लेख विभिन्न चार्ट एंटिटीज़ जैसे श्रेणी और मान अक्ष को फ़ॉर्मेट करने के तरीके को समझाता है।

Aspose.Slides for Python via Java विभिन्न चार्ट एंटिटीज़ का प्रबंधन करने और उन्हें कस्टम मानों से फ़ॉर्मेट करने के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसकी इंडेक्स द्वारा स्लाइड तक पहुँचें।
1. इच्छित प्रकार का चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ें (इस उदाहरण में [ChartType.LineWithMarkers](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/#LineWithMarkers) उपयोग किया गया है)।
1. चार्ट वैल्यू एक्सिस तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. वैल्यू एक्सिस के मेजर ग्रिड लाइन्स के लिए **Line format** सेट करें।
   1. वैल्यू एक्सिस के माइनर ग्रिड लाइन्स के लिए **Line format** सेट करें।
   1. वैल्यू एक्सिस के लिए **Number Format** सेट करें।
   1. वैल्यू एक्सिस के लिए **minimum, maximum, major, and minor units** सेट करें।
   1. वैल्यू एक्सिस डेटा के लिए **Text Properties** सेट करें।
   1. वैल्यू एक्सिस के लिए **Title** सेट करें।
1. चार्ट कैटेगरी एक्सिस तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. कैटेगरी एक्सिस के मेजर ग्रिड लाइन्स के लिए **Line format** सेट करें।
   1. कैटेगरी एक्सिस के माइनर ग्रिड लाइन्स के लिए **Line format** सेट करें।
   1. कैटेगरी एक्सिस डेटा के लिए **Text Properties** सेट करें।
   1. कैटेगरी एक्सिस के लिए **Title** सेट करें।
   1. कैटेगरी एक्सिस के लिए **Label Positioning** सेट करें।
   1. कैटेगरी एक्सिस लेबल्स के लिए **Rotation Angle** सेट करें।
1. चार्ट लीजेंड तक पहुँचें और इसकी **text properties** सेट करें।
1. चार्ट लीजेंड को इस प्रकार दिखाएँ कि वह चार्ट के साथ ओवरलैप न करे।
1. चार्ट **secondary value axis** तक पहुँचें और निम्नलिखित गुण सेट करें:
   1. सेकेंडरी **value axis** को सक्षम करें।
   1. सेकेंडरी वैल्यू एक्सिस के लिए **Line Format** सेट करें।
   1. सेकेंडरी वैल्यू एक्सिस के लिए **Number Format** सेट करें।
   1. सेकेंडरी वैल्यू एक्सिस के लिए **minimum, maximum, major, and minor units** सेट करें।
1. पहले चार्ट सीरीज़ को सेकेंडरी वैल्यू एक्सिस पर प्लॉट करें।
1. चार्ट बैक वॉल फ़िल रंग सेट करें।
1. चार्ट प्लॉट एरिया फ़िल रंग सेट करें।
1. संशोधित प्रस्तुतिकरण को PPTX फ़ाइल में लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Presentation क्लास का एक उदाहरण बनाएं
presentation = Presentation()
try:
    # पहले स्लाइड तक पहुँचें
    slide = presentation.getSlides().get_Item(0)

    # नमूना चार्ट जोड़ें
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # चार्ट शीर्षक सेट करें
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # वैल्यू एक्सिस के लिए मेजर ग्रिड लाइन्स फ़ॉर्मेट सेट करें
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # वैल्यू एक्सिस के लिए माइनर ग्रिड लाइन्स फ़ॉर्मेट सेट करें
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # वैल्यू एक्सिस का नम्बर फ़ॉर्मेट सेट करें
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # चार्ट के अधिकतम, न्यूनतम मान सेट करें
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # वैल्यू एक्सिस टेक्स्ट गुण सेट करें
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # वैल्यू एक्सिस शीर्षक सेट करें
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # कैटेगरी एक्सिस के लिए मेजर ग्रिड लाइन्स फ़ॉर्मेट सेट करें
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # कैटेगरी एक्सिस के लिए माइनर ग्रिड लाइन्स फ़ॉर्मेट सेट करें
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # कैटेगरी एक्सिस टेक्स्ट गुण सेट करें
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # कैटेगरी शीर्षक सेट करें
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # कैटेगरी एक्सिस लेबल स्थिति सेट करें
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # कैटेगरी एक्सिस लेबल घुमाव कोण सेट करें
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # लीजेंड टेक्स्ट गुण सेट करें
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # चार्ट लीजेंड को चार्ट के साथ ओवरलैप न होने दें

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # सेकेंडरी वैल्यू एक्सिस सेट करें
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # सेकेंडरी वैल्यू एक्सिस का नम्बर फ़ॉर्मेट सेट करें
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # चार्ट के अधिकतम, न्यूनतम मान सेट करें
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # चार्ट बैक वॉल का रंग सेट करें
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # प्लॉट एरिया का रंग सेट करें
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # प्रस्तुति सहेजें
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for Python via Java चार्ट के लिए फ़ॉन्ट गुण सेट करने का समर्थन करता है। फ़ॉन्ट गुण सेट करने के लिए इन चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
- स्लाइड में एक चार्ट जोड़ें।
- फ़ॉन्ट की ऊँचाई सेट करें।
- संशोधित प्रस्तुतिकरण को सहेजें।

नीचे दिया गया उदाहरण इन चरणों को दर्शाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation क्लास का एक उदाहरण बनाएं
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **संख्यात्मक फ़ॉर्मेट सेट करें**
Aspose.Slides for Python via Java चार्ट डेटा फ़ॉर्मेट का प्रबंधन करने के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसकी इंडेक्स द्वारा स्लाइड तक पहुँचें।
1. इच्छित प्रकार का चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ें (इस उदाहरण में [ChartType.ClusteredColumn](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/#ClusteredColumn) उपयोग किया गया है)।
1. उपलब्ध प्रीसेट मानों में से प्रीसेट नंबर फ़ॉर्मेट सेट करें।
1. प्रत्येक चार्ट सीरीज़ के डेटा सेल्स को इटरेट करें और उनका नंबर फ़ॉर्मेट सेट करें।
1. प्रस्तुतिकरण को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpape.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation क्लास का एक उदाहरण बनाएं
presentation = Presentation()
try:
    # पहली प्रेज़ेंटेशन स्लाइड तक पहुँचें
    slide = presentation.getSlides().get_Item(0)

    # डिफ़ॉल्ट क्लस्टर्ड कॉलम चार्ट जोड़ें
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # चार्ट सीरीज़ कलेक्शन तक पहुँचें
    chart_series_collection = chart.getChartData().getSeries()

    # प्रत्येक चार्ट सीरीज़ पर इटरेट करें
    for chart_series in chart_series_collection:
        # सीरीज़ में प्रत्येक डेटा पॉइंट पर इटरेट करें
        for data_point in chart_series.getDataPoints():
            # नंबर फ़ॉर्मेट सेट करें
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # प्रेज़ेंटेशन सहेजें
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

उपलब्ध प्रीसेट नंबर फ़ॉर्मेट और उनके इंडेक्स नीचे सूचीबद्ध हैं:

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
Aspose.Slides for Python via Java [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) क्लास की [hasRoundedCorners](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#hasRoundedCorners) और [setRoundedCorners](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setRoundedCorners) विधियों के माध्यम से चार्ट एरिया के लिए गोल कोनों का समर्थन करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. स्लाइड में एक चार्ट जोड़ें।
1. चार्ट बॉर्डर लाइन का फ़िल टाइप और शैली सेट करें।
1. गोल कोनों को सक्षम करें।
1. संशोधित प्रस्तुतिकरण को सहेजें।

नीचे दिया गया उदाहरण इन चरणों को दर्शाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Presentation क्लास का एक उदाहरण बनाएं
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं कॉलम/एरिया के लिये अर्द्ध-पारदर्शी फ़िल सेट कर सकता हूँ जबकि बॉर्डर अपरिवर्तित रहे?**

हाँ। फ़िल ट्रांसपेरेंसी और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**यदि डेटा लेबल ओवरलैप हो रहे हों तो मैं क्या करूँ?**

फ़ॉन्ट आकार कम करें, गैर‑आवश्यक लेबल घटकों (जैसे श्रेणियाँ) को निष्क्रिय करें, लेबल ऑफ़सेट/पोज़िशन सेट करें, आवश्यक होने पर केवल चुनी हुई पॉइंट्स के लिये लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल लागू कर सकता हूँ?**

हाँ। सॉलिड और ग्रेडिएंट/पैटर्न फ़िल दोनों सामान्यतः उपलब्ध होते हैं। व्यावहारिक रूप से ग्रेडिएंट का संयमित उपयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट कम कर दें।
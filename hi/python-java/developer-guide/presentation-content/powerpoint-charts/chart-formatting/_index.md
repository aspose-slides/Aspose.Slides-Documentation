---
title: Python में प्रस्तुति चार्ट को फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/python-java/chart-formatting/
keywords:
- फ़ॉर्मेट चार्ट
- चार्ट फ़ॉर्मेटिंग
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (Java के माध्यम से) में चार्ट फ़ॉर्मेटिंग सीखें और अपने PowerPoint प्रस्तुति को कस्टम अक्ष, फ़ॉन्ट, संख्या फ़ॉर्मेट और गोल चार्ट किनारों के साथ उन्नत बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के तरीके को समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लेजेंड, प्लॉट क्षेत्र और दीवार फ़िल्स जैसी मुख्य चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता में सुधार कैसे किया जा सकता है, दर्शाता है।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक फ़ॉर्मेट लागू करने, और चार्ट क्षेत्र के लिए गोल कोनों को सक्षम करने का भी प्रदर्शन करता है। साथ मिलकर, ये उदाहरण प्रदर्शित करते हैं कि प्रस्तुति में चार्टों की दृश्य शैली और डेटा प्रस्तुति दोनों को कैसे नियंत्रित किया जा सकता है।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

चार्ट शीर्षक, अक्ष, ग्रिड रेखाओं, लेजेंड और प्लॉट क्षेत्र को फ़ॉर्मेट करने के लिए [चार्ट](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) का उपयोग करें। यह उदाहरण मार्कर और डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, फिर इसके वैल्यू और कैटेगरी अक्षों पर अलग-अलग टेक्स्ट और लाइन शैलियों को लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट्स में निर्दिष्ट की गई हैं; कैटेगरी लेबल 45 डिग्री घुमाए गए हैं।

वैल्यु अक्ष स्रोत कोशिकाओं से स्वतंत्र रूप से [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) का उपयोग करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और गौण अंतराल 0.5 है। यह उदाहरण प्रतिशत फ़ॉर्मेटिंग को [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) को हजारों पर सेट करने के साथ भी जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लेजेंड प्लॉट क्षेत्र के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) को `False` के साथ बुलाया जाता है। बैक-वॉल और फ़्लोर फ़िल्स को [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) और [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) के माध्यम से कॉन्फ़िगर किया जाता है, लेकिन ये सतहें केवल 3D चार्ट में दिखाई देती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

[Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) के माध्यम से चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार सेट करें। यह उदाहरण 20 पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) के माध्यम से पहली सीरीज़ के लिए वैल्यू लेबल सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट की डिफ़ॉल्ट सेटिंग को ओवरराइड कर सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **संख्यात्मक फ़ॉर्मेट सेट करें**

[ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) का उपयोग करके चार्ट वर्कबुक कोशिकाओं पर एक बिल्ट-इन नंबर फ़ॉर्मेट लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल-आधारित डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक सीरीज़ वैल्यू सेल पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। इससे वर्कबुक में मानों का प्रदर्शन बदलता है बिना मूल संख्याओं को बदले; उदाहरण के लिए, 0.25 को 25.00% के रूप में दिखाया जाता है। अक्ष और डेटा-लेबल फ़ॉर्मेट को अलग-अलग कॉन्फ़िगर किया जा सकता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

निम्न तालिका में अंग्रेजी (संयुक्त राज्य) लोकैल के लिए प्रतिनिधि Excel फ़ॉर्मेट के साथ बिल्ट-इन संख्या फ़ॉर्मेट इंडेक्स सूचीबद्ध हैं। सटीक फ़ॉर्मेट स्ट्रिंग्स और उनका प्रदर्शन एप्लिकेशन और लोकैल के अनुसार बदल सकता है, विशेषकर मुद्रा और तिथियों के लिए। कुछ Excel फ़ॉर्मेट OOXML मानक के डिफ़ॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft का संख्या फ़ॉर्मेट कार्यान्वयन नोट्स](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| इंडेक्स | फ़ॉर्मेट |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **चार्ट क्षेत्र के गोल किनारों को सेट करें**

[Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) को `True` के साथ कॉल करके चार्ट क्षेत्र के कोनों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रस्तुति सहेजने से पहले उसकी रूपरेखा को ठोस ग्रे रंग और सिंगल-लाइन शैली देने के लिए [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) का उपयोग करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मौजूदा चार्ट एनोटेशन को संपादित करें**

एक चार्ट में कस्टम शेप हो सकते हैं, जैसे रिपोर्ट की स्थिति समझाने वाला टेक्स्ट एनोटेशन। इन शेप्स तक पहुंचने के लिए आप [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes) का उपयोग कर सकते हैं। [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) द्वारा लौटाई गई कलेक्शन में चार्ट-स्वामित्व वाली शेप्स शामिल होती हैं।

चार्ट के ऊपर रखा एक सामान्य टेक्स्ट बॉक्स स्लाइड का हिस्सा होता है, भले ही वह चार्ट का हिस्सा जैसा दिखे। [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) के माध्यम से इटररेट करने पर चार्ट और सामान्य स्लाइड शेप्स मिलते हैं, लेकिन चार्ट के भीतर के व्यक्तिगत शेप्स की सूची नहीं बनती। चार्ट शीर्षक और डेटा लेबल अलग-अलग चार्ट तत्व होते हैं, इस कलेक्शन में कस्टम एनोटेशन नहीं होते।

[chart-annotations.pptx](chart-annotations.pptx) को डाउनलोड करें और इसे एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें एक अनग्रुप्ड एनोटेशन "Preliminary results", एक चार्ट-स्वामित्व वाली लाइन, और एक सामान्य स्लाइड टेक्स्ट बॉक्स "Slide overlay" है। यह उदाहरण उस स्लाइड पर पहला चार्ट खोजता है और रिपोर्ट प्रकाशित करने के तैयार होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली कलेक्शन की जाँच करता है और केवल एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) को संपादित करता है जिसकी टेक्स्ट फ्रेम `None` नहीं है, जो [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) द्वारा लौटाई गई है और अपेक्षित टेक्स्ट से मेल खाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहता है। निम्न छवियां इनपुट और सहेजी गई, फिर खोली गई परिणाम को दिखाती हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![प्रारंभिक परिणाम पढ़ता चार्ट एनोटेशन](chart-annotations-before.png) | ![अंतिम परिणाम पढ़ता चार्ट एनोटेशन](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष-स्तर के चार्ट-स्वामित्व वाले शेप्स की जाँच करता है। यदि कोई एनोटेशन [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) के अंदर है, तो उस समूह की [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) कलेक्शन को भी जांचें। नेस्टेड समूहों के लिए इसे पुनरावर्ती रूप से दोहराएँ, उनके चाइल्ड शेप्स पर समान टेक्स्ट जांच लागू करें। एक समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न समझें।
{{% /alert %}}

## **FAQ**

**क्या मैं कॉलम/क्षेत्रों के लिए अर्ध-पारदर्शी फिल्स सेट कर सकता हूँ जबकि बॉर्डर को अपारदर्शी रखूँ?**

हां। फ़िल ट्रांसपरेंसी और आउटलाइन को अलग-अलग कॉन्फ़िगर किया जाता है। यह घने विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता सुधारने के लिए उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं कैसे निपटूँ?**

फ़ॉन्ट आकार कम करें, गैर-आवश्यक लेबल घटकों को निष्क्रिय करें (उदाहरण के लिए, श्रेणियाँ), लेबल की स्थिति समायोजित करें, आवश्यकता पड़ने पर केवल चयनित पॉइंट्स के लिए लेबल दिखाएं, या फ़ॉर्मेट को "value + legend" में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हां। सीरीज़ ठोस, ग्रेडिएंट और पैटर्न फ़िल्स का समर्थन करती हैं। व्यवहार में, ग्रेडिएंट को कम प्रयोग करें और ऐसी संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को कम कर दें।
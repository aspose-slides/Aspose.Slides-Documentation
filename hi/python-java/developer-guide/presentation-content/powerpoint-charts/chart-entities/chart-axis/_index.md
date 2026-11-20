---
title: "Python का उपयोग करके प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करें"
linktitle: "चार्ट अक्ष"
type: docs
url: /hi/python-java/chart-axis/
keywords:
- "चार्ट अक्ष"
- "ऊर्ध्वाधर अक्ष"
- "क्षैतिज अक्ष"
- "अक्ष को अनुकूलित करें"
- "अक्ष को व्यवस्थित करें"
- "अक्ष का प्रबंधन करें"
- "अक्ष गुण"
- "अधिकतम मान"
- "न्यूनतम मान"
- "अक्ष रेखा"
- "तिथि प्रारूप"
- "अक्ष शीर्षक"
- "अक्ष स्थिति"
- "PowerPoint"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्ष को अनुकूलित करने के तरीके जानें।"
---
## **सारांश**

यह लेख Aspose.Slides for Python via Java के साथ चार्ट एक्सिस को अनुकूलित करने के तरीके को समझाता है। यह गणना किए गए एक्सिस मान, चार्ट की पंक्तियों और स्तंभों को स्विच करना, एक्सिस की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और फ़ॉर्मेटिंग, शीर्षक का घुमाव, एक्सिस का स्थिति निर्धारण, डिस्प्ले यूनिट, और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट के ऊर्ध्वाधर अक्ष पर अधिकतम मान प्राप्त करना**

एक [प्रेजेंटेशन](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए एक्सिस मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) को कॉल करें ताकि चार्ट लेआउट अप‑टू‑डेट रहे।

अक्ष सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) और [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) पढ़ें, और टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) और [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) और [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में संग्रहित करता है और चार्ट को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्षों के बीच डेटा अदला‑बदली करें**

चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलने के लिए [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूहकरण को बदलता है; यह क्षैतिज और ऊर्ध्वाधर अक्षों को नहीं बदलता। उदाहरण [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी कॉलम शामिल हैं, पंक्तियों और स्तंभों को स्विच करने से पहले। यह चार श्रृंखलाओं और तीन श्रेणियों के साथ एक चार्ट सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्ष के प्लॉट क्रम को उल्टें**

[setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) का उपयोग करके किसी श्रेणी या मान अक्ष को उलटा किया जा सकता है। उदाहरण के लिए, एक क्षैतिज बार चार्ट में परियोजना चरणों को शीर्ष से नीचे उसी क्रम में दिखाया जा सकता है जैसा कि कार्यपत्र में है: Planning, Development, Testing। अक्ष को उलटा करने से प्लॉट दिशा बदलती है; यह कार्यपत्र डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना के लिए, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) श्रृंखला और श्रेणियों की भूमिकाओं को बदलता है।

निम्नलिखित उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रेजेंटेशन सहेजता है: सामान्य क्रम, उल्टी श्रेणियां, और उल्टे मान। प्रत्येक कॉपी समान डेटा सेट का उपयोग करती है, और प्रत्येक कॉपी में केवल एक ही अक्ष उलटा होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # स्लाइड 2: पहली श्रेणी को शीर्ष पर प्रदर्शित करें।
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # क्षैतिज मान अक्ष को नीचे रखें।
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

अक्ष को उलटा करने से लम्बवत अक्ष को प्लॉट के विपरीत पक्ष पर भी ले जाया जा सकता है। [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) निर्धारित करता है कि अन्य अक्ष कहाँ से वर्तमान कॉन्फ़िगर किए जा रहे अक्ष को काटता है। स्लाइड 2 में, उल्टी श्रेणी अक्ष पर [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) के साथ इसे कॉल करने से क्षैतिज मान अक्ष नीचे रहता है। किसी विशिष्ट कटाव बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) का उपयोग करें। दिशा बदलते समय क्रॉसिंग सेटिंग्स की जांच करें, विशेषकर यदि चार्ट में पहले से ही एक कस्टम क्रॉसिंग बिंदु है। सामान्य प्लॉटिंग दिशा को पुनर्स्थापित करने के लिए `False` के साथ [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) कॉल करें; क्रॉसिंग सेटिंग्स अलग हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टी श्रेणियां (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान अक्ष क्रम के साथ क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे श्रेणियों के साथ क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उल्टे मान अक्ष और दाएँ शून्य के साथ क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियां नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | Planning, Development, और Testing ऊपर से नीचे चलते हैं। मान और कार्यपुस्तिका पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियां अपनी सामान्य क्रम बनाए रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर काटता है। |

## **लाइन चार्ट के लिए ऊर्ध्वाधर अक्ष को अक्षम करें**

ऊर्ध्वाधर अक्ष को छिपाने के लिए `False` के साथ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे ऊर्ध्वाधर अक्ष छिपे हुए सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**

क्षैतिज अक्ष को छिपाने के लिए `False` के साथ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष छिपे हुए सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट ग्रिडलाइन दिखाएँ या छिपाएँ**

[getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) और [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) को कॉल करके जानें कि कौन सी ग्रिडलाइन अक्ष प्रदर्शित करता है। लघु ग्रिडलाइन दिखाने के लिए, [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) का उपयोग करें और लाइन फ़िल को ठोस, दिखाई देने वाले रंग में सेट करें। उन्हें छिपाने के लिए, फ़िल को [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill) में सेट करें। प्रमुख ग्रिडलाइन के लिए, [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) का उपयोग करके उसी तरह लाइन फ़िल बदलें। फ़िल बदलने से अक्ष दृश्यता और टिक मार्क नहीं बदलते।

इस क्लस्टर्ड कॉलम चार्ट का ऊर्ध्वाधर अक्ष शुरू में केवल प्रमुख ग्रिडलाइन दिखाता है। उदाहरण लघु ग्रिडलाइन को गहरे नारंगी में दिखाता है, फिर उन्हें फिर से छिपाता है और प्रेजेंटेशन सहेजता है। यह प्रत्येक चरण पर ग्रिडलाइन दृश्यता को प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| लघु ग्रिडलाइन सक्षम | लघु ग्रिडलाइन छिपी हुई |
| --- | --- |
| ![ऊर्ध्वाधर अक्ष पर प्रमुख ग्रिडलाइन के बीच नारंगी लघु ग्रिडलाइन](minor-gridlines-enabled.png) | ![सिर्फ प्रमुख ग्रिडलाइन दृश्यमान वाला वही कॉलम चार्ट](minor-gridlines-hidden.png) |

## **श्रेणी अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) का उपयोग करके तिथि या पाठ श्रेणी अक्ष चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहले स्लाइड पर पहला आकार चार्ट है और श्रेणी कोशिकाएँ मौजूदा एक्सेल तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) को `False` के साथ, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) को `1` के साथ, और [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) को [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) के साथ कॉल करने से मुख्य टिक एक महीने के अंतराल पर रखी जाती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **डेटा से श्रेणी अक्ष प्रकार निर्धारित करें**

[setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) को श्रेणियों को भरने के बाद कॉल करें, फिर चयन को जांचने के लिए [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) पढ़ें। यह उपयोगी है जब एक ही चार्ट को या तो पाठ लेबल या संख्यात्मक तिथि मान मिलते हैं। यह विधि कॉल किए जाने पर प्रकार निर्धारित करती है; यह बाद में डेटा बदलावों को पुनर्मूल्यांकन करने वाला स्थायी मोड सक्षम नहीं करती। श्रेणियों को बदलने के बाद फिर से इसे कॉल करें।

निम्नलिखित उदाहरण पाठ श्रेणियों के साथ एक चार्ट बनाता है और जब चयनित प्रकार [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text) हो तो `True` प्रिंट करता है। फिर यह श्रेणी कोशिकाओं के मान को तिथियों से बदलता है और फिर से विधि को कॉल करता है, जिससे चयनित प्रकार [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) होने पर `True` प्रिंट होता है। तिथियां संख्यात्मक OLE Automation मान के रूप में संग्रहीत होती हैं, जो 30 दिसंबर 1899 से दिनों की संख्या के रूप में गणना की जाती हैं, न कि स्ट्रिंग के रूप में। [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) नियंत्रित करता है कि उन मानों को कैसे प्रदर्शित किया जाए; यह पाठ को संख्यात्मक तिथियों में नहीं बदलता। श्रेणी कोशिकाओं के बारे में अधिक जानकारी के लिए देखें [Chart Workbook](/slides/hi/python-java/chart-workbook/)।

इनपुट में यदि ज्ञात हो कि पाठ श्रेणियां या संख्यात्मक तिथियां हैं, तो स्वचालित निर्धारण का उपयोग करें, जैसा कि इस उदाहरण में दिखाया गया है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियां, या खाली डेटा के लिए, इच्छित अर्थ से मिलाने के लिए स्पष्ट रूप से [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) को कॉल करें। केवल संख्यात्मक मान अकेले यह स्थापित नहीं करते कि श्रेणियां तिथियां हैं।

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # सही

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # सही

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियां हों, तो बिना श्रेणियों या डेटा पॉइंट्स को हटाए दिखाई देने वाले अक्ष लेबलों की संख्या घटाएँ। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) को `False` के साथ कॉल करें, फिर इच्छित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) में पास करें। सामान्य क्रम में पाठ श्रेणियों के लिए, गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, … श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, … श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, … श्रेणी 22 |

`3` का अंतराल हर तीसरा लेबल दिखाता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तम्भों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर चुनता है; यह आवश्यक नहीं कि हर लेबल दिखाए।

टिक मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) को `False` के साथ कॉल करें और [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) का उपयोग करके उनका अंतराल सेट करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर टिक मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखाई देते हैं। दिखाने के लिए [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) को एक दृश्यमान शैली के साथ प्रयोग करें। किसी भी स्वचालित‑स्पेसिंग सेटर को फिर से `True` करने से चार्ट को वह अंतराल फिर से चुनने देता है।

निम्नलिखित स्व-निहित उदाहरण 24 श्रेणियां और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड बनाता है: स्वचालित स्पेसिंग, स्वतंत्र लेबल स्पेसिंग के साथ मैनुअल टिक मार्क, और पुनर्स्थापित स्वचालित स्पेसिंग। दोनों कॉपी मूल चार्ट डेटा को रखती हैं। इनपुट प्रेजेंटेशन की आवश्यकता नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व अंतर को देखना आसान बनाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # स्लाइड 2: प्रत्येक तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए टिक मार्क रखें।
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में, प्रत्येक दूसरी श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में लिपटा हुआ होता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![सभी 24 स्तंभ दृश्यमान के साथ स्वचालित श्रेणी लेबल अंतराल](category-axis-automatic.png)

**मैनुअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखाया जाता है, जबकि टिक मार्क प्रत्येक श्रेणी अंतराल पर रहते हैं। सभी 24 स्तंभ, लेबल के बिना भी, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 स्वचालित रूप से ऊपर दिखाए गए रूप को पुनर्स्थापित करता है।

![तीन के मैनुअल श्रेणी लेबल अंतराल के साथ सभी 24 स्तंभ दृश्यमान](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में, यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में, श्रेणी अक्ष लम्बवत होता है, इसलिए इसे [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क अंतराल उन चार्ट में श्रृंखला अक्ष पर भी लागू होता है जिनमें वह मौजूद है।

श्रेणी लेबल अंतराल का उपयोग मान अक्ष के संख्यात्मक स्केल को सेट करने के लिए न करें। मान अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों से परे। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि फ़ॉर्मेट सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां OLE Automation अनुक्रमिक संख्याओं के रूप में पहले कार्यपत्र (इंडेक्स `0`) में संग्रहीत होती हैं, जो 30 दिसंबर 1899 से दिनों की संख्या के रूप में गणना की जाती हैं। [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) को [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) के साथ उपयोग करें, फिर [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) को `False` के साथ कॉल करें, और `yyyy` को [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) में पास करें ताकि श्रेणी लेबल साल को चार अंकों में स्वतंत्रतः दिखाएं, चाहे सेल फ़ॉर्मेट कुछ भी हो।

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट अक्ष शीर्षक के लिए घुमा हुआ कोण निर्धारित करें**

ऊर्ध्वाधर अक्ष पर `True` के साथ [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) को कॉल करें, शीर्षक पाठ प्रदान करें, और शीर्षक के टेक्स्ट ब्लॉक फ़ॉर्मेटिंग में घुमा हुआ कोण सेट करें। कोण डिग्री में मापा जाता है; यह उदाहरण एक कॉलम चार्ट को सहेजता है जिसमें उसके मान‑अक्स शीर्षक को 90 डिग्री पर घुमाया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **श्रेणी या मान अक्ष पर अक्ष का स्थिति निर्धारित करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) का उपयोग करके नियंत्रित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक मार्क पर कहाँ काटता है। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `True` सेट करता है और परिणाम सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) का उपयोग करके मान अक्ष पर लेबल को स्केल करें बिना मूल डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60,000,000 का मान 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके ऊर्ध्वाधर अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लघुगणकीय मान अक्ष को कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान कई आदेशों में फैले हों। उदाहरण के लिए, एक सेवा पाँच अवधियों में 10, 100, 1,000, 10,000, और 100,000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को तुलना करने में आसान बनाता है: समान दूरी समान अनुपात दर्शाती है न कि समान अंतर।

[setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) को `True` के साथ मान अक्ष पर कॉल करें और बेस चुनने के लिए [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) का उपयोग करें। यह मौजूदा मानों को प्रदर्शित करने के तरीके को बदलता है; यह डेटा नहीं बदलता या लघुगणकीय ट्रेंड लाइन नहीं जोड़ता। ट्रेंड लाइन डेटा में फिटेड रिश्ते को दर्शाती है और एक अलग सुविधा है।

### **मान अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिए, मान अक्ष [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिए, यह [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) द्वारा लौटाया जाता है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए ऊर्ध्वाधर अक्ष, या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग न लगाएँ।

डिफ़ॉल्ट लघुगणकीय बेस `10` है। PPTX चार्ट के लिए, `2` से `1000` तक का बेस उपयोग करें, समावेशी; अंशात्मक बेस जैसे `2.5` भी समर्थित हैं। बेस `10` के साथ, क्रमशः 10, 100, 1,000, 10,000 जैसे शक्ति समान रूप से अंतरित होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना करें**

निम्नलिखित स्व-निहित उदाहरण एक लाइन चार्ट बनाता है जिसमें पहली स्लाइड पर पाँच अनुरोध गिनती होती है, फिर उस स्लाइड को क्लोन करता है और दूसरी पर बेस‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान-अक्ष स्केल को बदलें।
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**रैखिक स्केल (स्लाइड 1):** समतल ऊपर‑नीचे दूरी समान अनुरोध गिनती के अंतर को दर्शाती है। सबसे बड़ा मान चार्ट पर हावी होता है, जिससे छोटे मानों को अलग‑अलग देखना कठिन हो जाता है।

![पावरपॉइंट में लाइन चार्ट जो रैखिक मान अक्ष पर पाँच अनुरोध गिनती दिखा रहा है](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समतल ऊपर‑नीचे दूरी समान अनुपात दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर सीधी ऊपर की रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गिनती दिखाते हैं।

![पावरपॉइंट में वही पाँच अनुरोध गिनती बेस‑10 लघुगणकीय मान अक्ष पर](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल स्पष्ट रूप से सकारात्मक मान दिखा सकता है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर रखना उचित है, तो हटाने का कारण बताएं। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलना डेटा का अर्थ बदल देता है। लघुगणकीय अक्ष के लिए मैन्युअल रूप से निर्धारित न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **FAQ**

**मैं एक अक्ष को दूसरे के साथ कब काटता है (अक्ष क्रॉसिंग) का मान कैसे सेट करूँ?**

एक अक्ष के क्रॉसिंग व्यवहार को चुनने के लिए [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) का उपयोग करें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) का उपयोग करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उपयुक्त बेसलाइन पर ले जाने देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) को [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, या `None` का उपयोग करके कॉल करें। टिक मार्क स्वयं को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) या [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) का उपयोग करें; यह लेबल स्थिति से अलग है।
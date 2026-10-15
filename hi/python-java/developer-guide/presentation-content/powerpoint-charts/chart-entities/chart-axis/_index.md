---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/python-java/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष अनुकूलित करें
- अक्ष को नियंत्रित करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "रिपोर्ट और दृश्य प्रस्तुतियों के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने हेतु Python के माध्यम से Java में Aspose.Slides के उपयोग के बारे में जानें."
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via Java के साथ चार्ट अक्षों को अनुकूलित करने की विधि समझाता है। यह गणना किए गए अक्ष मानों, चार्ट की पंक्तियों और स्तम्भों को बदलने, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घूर्णन, अक्ष का स्थान, प्रदर्शन इकाइयों और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट के ऊर्ध्वाधर अक्ष पर अधिकतम मान प्राप्त करें**

एक [प्रस्तुति](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मानों को पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) को कॉल करें ताकि चार्ट लेआउट अद्यतन रहे।

[ getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) और [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) को अक्ष की सीमाओं के लिये पढ़ें, तथा [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) और [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) को टिक अंतराल के लिये पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) और [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिये प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय वेरिएबल्स में संग्रहीत करता है और चार्ट को सहेजता है।

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

चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलने के लिये [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और ऊर्ध्वाधर अक्षों को नहीं बदलता। उदाहरण [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी स्तम्भ शामिल हैं, पंक्तियों और स्तम्भों को बदलने से पहले। यह चार श्रृंखला और तीन श्रेणियों के साथ एक चार्ट सहेजता है।

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

## **अक्ष की प्लॉटिंग क्रम को उलटें**

एक श्रेणी या मान अक्ष को उलटने के लिये [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) का उपयोग करें। उदाहरण के लिये, एक क्षैतिज बार चार्ट कार्य चरणों को शीर्ष से नीचे उसी क्रम में दिखा सकता है जैसा कि कार्यपत्र में है: योजना, विकास, परीक्षण। अक्ष को उलटने से प्लॉटिंग दिशा बदलती है; यह कार्यपत्र डेटा को क्रमबद्ध या पुन: व्यवस्थित नहीं करता। तुलना में, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) श्रृंखला और श्रेणियों की भूमिकाओं को बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रस्तुति सहेजता है: सामान्य क्रम, उल्टी श्रेणियां, और उल्टे मान। प्रत्येक प्रति समान डेटा सेट का उपयोग करता है, और प्रत्येक प्रति में केवल एक अक्ष उलटा होता है।

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

    # स्लाइड 2: पहली श्रेणी को शीर्ष पर दिखाएँ।
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

एक अक्ष को उलटने से लंबवत अक्ष को प्लॉट के विपरीत पक्ष पर ले जाया भी जा सकता है। [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) नियंत्रित करता है कि अन्य अक्ष किस स्थान पर उलटे हुए अक्ष को काटता है। स्लाइड 2 में, उलटे श्रेणी अक्ष पर [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) के साथ इसे कॉल करने से क्षैतिज मान अक्ष नीचे बना रहता है। एक विशिष्ट कटाव बिंदु के लिये, [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) का उपयोग करें। दिशा बदलते समय कटाव सेटिंग्स की जाँच करें, विशेषकर यदि चार्ट में पहले से एक कस्टम कटाव बिंदु है। सामान्य प्लॉटिंग दिशा पुनः प्राप्त करने के लिये `False` के साथ [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) को कॉल करें; कटाव सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टी श्रेणियां (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान अक्ष क्रम के साथ क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे दिखायी गयी श्रेणियों के साथ क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![दाएँ शून्य के साथ उल्टा मान अक्ष वाला क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियां नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, तथा परीक्षण ऊपर से नीचे तक चलते हैं। मान और कार्यपत्र पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियां अपना सामान्य क्रम रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर काटता है। |

## **लाइन चार्ट के लिये ऊर्ध्वाधर अक्ष को अक्षम करें**

ऊर्ध्वाधर अक्ष को छिपाने के लिये `False` के साथ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे ऊर्ध्वाधर अक्ष छिपाए हुए सहेजता है।

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

## **लाइन चार्ट के लिये क्षैतिज अक्ष को अक्षम करें**

क्षैतिज अक्ष को छिपाने के लिये `False` के साथ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष छिपाए हुए सहेजता है।

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

## **एक श्रेणी अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) का उपयोग करके तिथि या पाठ श्रेणी अक्ष चुना जा सकता है। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जहाँ पहला स्लाइड का पहला आकार एक चार्ट है और श्रेणी कोशिकाएँ संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) को `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) को `1`, तथा [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) को [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) के साथ कॉल करने से प्रमुख टिक एक‑महीने अंतराल पर स्थित होते हैं।

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

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियां हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दिखने वाले अक्ष लेबलों की संख्या घटाएँ। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) को `False` के साथ कॉल करें, फिर इच्छित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) को पास करें। सामान्य क्रम में पाठ श्रेणियों के लिये, गणना पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में दिखाए गए लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` का अंतराल हर तीसरा लेबल दिखाता है, जो प्रदर्शित लेबलों के बीच दो लेबल छुपा देता है। यह संबंधित स्तम्भों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर चुना जाता है; यह आवश्यक नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिये अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) को `False` के साथ कॉल करें और उनके अंतराल को सेट करने के लिये [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) उपयोग करें। उदाहरण के लिये, `1` हर श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखते हैं। दृश्य शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) का उपयोग करें ताकि आप परिणाम देख सकें। दोनो स्वचालित‑अंतराल सेटर्स को `True` पर पुनः सेट करने से चार्ट फिर से वह अंतराल चुन लेता है।

निम्न स्व-समाहित उदाहरण 24 श्रेणियां और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइडें सहेजता है: स्वचालित अंतराल, स्वतंत्र टिक‑मार्क के साथ मैन्युअल लेबल अंतराल, और पुनर्स्थापित स्वचालित अंतराल। दोनो प्रतियां मूल चार्ट डेटा बरकरार रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। क्षैतिज लेबल पाठ घनत्व में अंतर को स्पष्ट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpause.startJVM()

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

    # स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन हर श्रेणी के लिए एक टिक‑मार्क रखें।
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

**स्वचालित अंतराल (स्लाइड 1):** इस रेंडरिंग में हर दूसरा श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में लिपटा होता है। स्वचालित परिणाम चार्ट के आकार, फ़ॉन्ट और रेंडरर पर निर्भर हो सकते हैं।

![सभी 24 स्तम्भ दृश्यमान के साथ स्वचालित श्रेणी लेबल अंतराल](category-axis-automatic.png)

**मैन्युअल अंतराल (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति पर दिखाया जाता है, जबकि टिक‑मार्क हर श्रेणी अंतराल पर बना रहता है। सभी 24 स्तम्भ, जिनमें लेबल नहीं वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाया गया स्वचालित स्वरूप पुनर्स्थापित करता है।

![सभी 24 स्तम्भ दृश्यमान के साथ तीन का मैन्युअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिये इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इन सेटिंग्स को [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क अंतराल उन चार्ट्स में श्रृंखला‑अक्ष पर भी लागू होता है जिनमें वह मौजूद हो।

मूल्य अक्ष की संख्यात्मक स्केल सेट करने के लिये श्रेणी लेबल अंतराल का उपयोग न करें। मूल्य अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिये, `10` का प्रमुख इकाई शून्य से शुरू होने पर 0, 10, 20 आदि पर टिक बनाता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों से निरपेक्ष। स्कैटर और बबल चार्ट मूल्य अक्षों का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिये, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिये तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां पहले कार्यपत्र (सूचकांक `0`) में OLE Automation क्रमांक के रूप में संग्रहीत हैं, जो 30 दिसंबर 1899 से दिन गिनती के रूप में गणना की गई हैं। [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) को [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) के साथ उपयोग करें, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) को `False` के साथ कॉल करें, और `yyyy` को [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) को पास करें ताकि श्रेणी लेबल सेल स्वरूपण से स्वतंत्र रूप से चार अंकों के वर्ष दिखाएँ।

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

## **चार्ट अक्ष शीर्षक के लिये घूर्णन कोण सेट करें**

ऊर्ध्वाधर अक्ष पर `True` के साथ [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) को कॉल करें, शीर्षक पाठ प्रदान करें, तथा शीर्षक के टेक्स्ट ब्लॉक स्वरूपण में घूर्णन कोण निर्धारित करें। कोण डिग्री में मापा जाता है; यह उदाहरण एक कॉलम चार्ट को 90 डिग्री घुमाए हुए मान‑अक्ष शीर्षक के साथ सहेजता है।

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

## **श्रेणी या मूल्य अक्ष पर अक्ष की स्थिति निर्धारित करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) का उपयोग करके नियंत्रण करें कि मूल्य अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर काटता है। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `True` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मान अक्ष पर प्रदर्शन इकाई सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) का उपयोग करके मान अक्ष के लेबलों को डेटा बदले बिना स्केल करें। जब [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60 000 000 का मान 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके ऊर्ध्वाधर अक्ष पर मिलियन प्रदर्शन इकाई लागू करता है।

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

## **लघुगणकीय मान अक्ष कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान कई क्रम magnitude में फैले हों। उदाहरण के लिये, एक सेवा पाँच अवधियों में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। एक रैखिक स्केल पर छोटे मान शून्य के करीब एक साथ दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को तुलना करना आसान बनाता है: समान दूरी समान अनुपात को दर्शाती है, न कि समान अंतर को।

मान अक्ष पर `True` के साथ [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) को कॉल करें और [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) के साथ आधार चुनें। इससे मौजूदा मानों का प्रदर्शन बदलता है; डेटा नहीं बदलता और न ही लघुगणकीय ट्रेंड‑लाइन जुड़ी होती है। ट्रेंड‑लाइन डेटा में फिटेड संबंध को दर्शाती है और एक अलग विशेषता है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिये, मान अक्ष [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिये, यह [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) द्वारा लौटाया जाता है। स्कैटर और बबल चार्ट दो मान अक्ष रखते हैं, इसलिए X मानों के लिये क्षैतिज अक्ष, Y मानों के लिये ऊर्ध्वाधर अक्ष, या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग न लागू करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट्स के लिये, `2` से `1000` तक का आधार उपयोग किया जा सकता है; अंशात्मक आधार जैसे `2.5` भी समर्थित हैं। आधार `10` के साथ, 10, 100, 1 000, 10 000 आदि क्रमिक शक्ति समान अंतर पर होती हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना**

निम्न स्व-समाहित उदाहरण पहली स्लाइड पर पाँच अनुरोध गणनाओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करता है और दूसरी स्लाइड पर आधार‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइडें समान डेटा रखती हैं।

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

    # पहले स्लाइड को रैखिक रखें और केवल प्रतिलिपि के मान-अक्ष स्केल को बदलें।
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर अंतराल अनुरोध गणनाओं के समान अंतर को दर्शाते हैं। सबसे बड़ा मान चार्ट पर हावी रहता है, जिससे छोटे मान पहचानने में कठिनाई होती है।

![रैखिक मान अक्ष पर पाँच अनुरोध गणनाओं के साथ लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर अंतराल समान अनुपात को दर्शाते हैं। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु आधार‑10 स्केल पर एक सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाएं दिखाते हैं।

![आधार‑10 लघुगणकीय मान अक्ष पर वही पाँच अनुरोध गणना](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मान प्रदर्शित कर सकता है। इसे सक्षम करने से पहले डेटा की जाँच करें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि उन मानों को विश्लेषण से बाहर करना उपयुक्त है, तो निरस्तीकरण का कारण स्पष्ट रूप से बताएँ। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलें नहीं, क्योंकि यह डेटा का अर्थ बदल देता है। लघुगणकीय अक्ष के लिये मैन्युअली निर्धारित न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक अक्ष को दूसरे अक्ष के साथ कहाँ काटेगा (अक्ष कटाव) इसे कैसे सेट करूँ?**

[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) का उपयोग करके कटाव व्यवहार चुनें। संख्यात्मक कटाव मान निर्दिष्ट करने के लिये [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) का उपयोग करें। ये सेटिंग्स आपको अक्ष कटाव को उपयुक्त बेसलाइन पर ले जाने की सुविधा देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थिति दूँ?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) के साथ [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) को कॉल करके `Low`, `High`, `NextTo` या `None` चुनें। टिक‑मार्क को नियंत्रित करने के लिये, [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) या [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) का उपयोग करें; ये लेबल स्थिति से अलग हैं।
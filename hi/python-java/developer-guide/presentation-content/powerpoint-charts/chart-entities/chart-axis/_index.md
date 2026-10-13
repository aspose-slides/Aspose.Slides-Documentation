---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/python-java/chart-axis/
keywords:
- चार्ट अक्ष
- लंबवत अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
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
description: "Aspose.Slides for Python via Java का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने का तरीका जानें।"
---
## **परिचय**

यह लेख Aspose.Slides for Python via Java के साथ चार्ट अक्षों को अनुकूलित करने के तरीकों को समझाता है। इसमें गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तंभों को बदलना, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक घुमाव, अक्ष का स्थान, प्रदर्शन इकाइयाँ, और लघुगणकीय स्केलिंग शामिल हैं।

## **एक चार्ट के लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [प्रेज़ेंटेशन](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) को कॉल करें ताकि चार्ट लेआउट अद्यतित हो।

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
## **अक्षों के बीच डेटा बदलें**

चार्ट डेटा में श्रृंखलाओं और श्रेणियों की भूमिकाओं को बदलने के लिए [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूहन को बदलता है; यह क्षैतिज और लंबवत अक्षों को नहीं बदलता। उदाहरण में पंक्तियों और स्तंभों को बदलने से पहले डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाँधने के लिए [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग किया गया है, जिसमें शीर्षक पंक्ति और श्रेणी स्तंभ शामिल हैं। यह चार श्रृंखलाएँ और तीन श्रेणियों वाला चार्ट सहेजता है।

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
## **लाइन चार्ट के लिए लंबवत अक्ष को अक्षम करें**

[setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) को `False` के साथ लंबवत अक्ष पर कॉल करें ताकि वह छिप जाए। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे लंबवत अक्ष के छिपे रहने के साथ सहेजता है।

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

[setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) को `False` के साथ क्षैतिज अक्ष पर कॉल करें ताकि वह छिप जाए। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष के छिपे रहने के साथ सहेजता है।

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

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) का उपयोग करके तिथि या पाठ श्रेणी अक्ष चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता करता है, जिसमें पहले स्लाइड पर पहला आकार एक चार्ट है और श्रेणी कोशिकाएँ संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) को `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) को `1`, और [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) को [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) के साथ कॉल करने से मुख्य टिक एक‑महीने के अंतराल पर रखे जाते हैं।

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
## **श्रेणी अक्ष लेबल अंतराल को नियंत्रित करें**

जब किसी चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्य अक्ष लेबलों की संख्या कम करें। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) को `False` के साथ कॉल करें, फिर वांछित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) में पास करें। सामान्य क्रम में पाठ श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को प्रदर्शित करता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को हटाता नहीं है। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर एक अंतराल चुनती है; यह अनिवार्य रूप से प्रत्येक लेबल को प्रदर्शित नहीं करती।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) को `False` के साथ कॉल करें और उनके अंतराल को सेट करने के लिए [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) का उपयोग करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। परिणाम देखने के लिए एक दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) का उपयोग करें। स्वचालित‑स्पेसिंग सेटर को `True` के साथ फिर से कॉल करने से चार्ट फिर से वह अंतराल चुनता है।

निम्नलिखित स्व-निहित उदाहरण 24 श्रेणियाँ और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैनुअल लेबल स्पेसिंग, और पुनर्स्थापित स्वचालित स्पेसिंग। दोनों प्रतियां मूल चार्ट डेटा को बनाए रखती हैं। कोई इनपुट प्रेज़ेंटेशन आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को आसानी से दिखाता है।

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

    # स्लाइड 2: हर तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
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

**स्वचालित स्पेसिंग (स्लाइड 1):** इस प्रतिरूप में, प्रत्येक दूसरे श्रेणी लेबल को प्रदर्शित किया जाता है और दो पंक्तियों में लिपटा हुआ है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के साथ बदल सकता है।

![सभी 24 स्तंभ दृश्यमान होने के साथ स्वचालित श्रेणी लेबल स्पेसिंग](category-axis-automatic.png)

**मैनुअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 स्तंभ, जिसमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित रूप को पुनर्स्थापित करता है।

![सभी 24 स्तंभ दृश्यमान होने के साथ तीन का मैनुअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

इस श्रेणी‑गणना अंतराल का उपयोग टेक्स्ट श्रेणी अक्ष के लिए करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में, श्रेणी अक्ष लंबवत होता है, इसलिए इन सेटिंग्स को [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क स्पेसिंग उन चार्टों में श्रृंखला अक्ष पर भी लागू होती है जिनमें वह होता है।

मूल्य अक्ष की संख्यात्मक स्केल सेट करने के लिए श्रेणी लेबल स्पेसिंग का उपयोग न करें। मूल्य अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का मुख्य इकाई शून्य से शुरू होने पर 0, 10, 20 आदि पर टिक बनाता है। `3` का श्रेणी लेबल अंतराल श्रेणी स्थितियों की गिनती करता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मूल्य अक्षों का उपयोग करते हैं न कि टेक्स्ट श्रेणी अक्ष का। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित अनुसार समय‑आधारित मुख्य इकाइयों और स्केलों का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियों को पहले कार्यपत्रक (इंडेक्स `0`) में OLE ऑटोमेशन सीरियल नंबर के रूप में संग्रहीत किया जाता है, जो 30 दिसंबर 1899 से दिनों की संख्या के रूप में गणना की गई हैं। [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) को [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) के साथ उपयोग करें, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) को `False` के साथ कॉल करें, और [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) को `yyyy` पास करें ताकि श्रेणी लेबल सेल स्वरूप से स्वतंत्र रूप से चार-अंक वाले वर्ष दिखाएँ।

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
## **चार्ट अक्ष शीर्षक के लिए घुमाव कोण सेट करें**

लंबवत अक्ष पर [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) को `True` के साथ कॉल करें, शीर्षक पाठ प्रदान करें, और शीर्षक के टेक्स्ट ब्लॉक स्वरूप में घुमाव कोण सेट करें। कोण डिग्री में मापा जाता है; यह उदाहरण अपने मूल्य‑अक्ष शीर्षक को 90 डिग्री घुमा कर एक कॉलम चार्ट को सहेजता है।

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
## **श्रेणी या मूल्य अक्ष पर अक्ष की स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) का उपयोग करके नियंत्रित करें कि मूल्य अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करता है या नहीं। यह सेटिंग श्रेणी अक्षों पर लागू होती है। उदाहरण में इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `True` सेट किया गया है और परिणाम सहेजा गया है।

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
## **चार्ट मूल्य अक्ष पर प्रदर्शन इकाई सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) का उपयोग करके मूल्य अक्ष पर लेबलों को स्केल करें बिना अंतर्निहित डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) को `Millions` सेट किया जाता है, तो 60 000 000 का मान 60 के रूप में प्रदर्शित होता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन प्रदर्शन इकाई लागू करता है।

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
## **लघुगणकीय मूल्य अक्ष कॉन्फ़िगर करें**

लघुगणकीय मूल्य अक्ष तब उपयोगी होता है जब धनात्मक मान कई क्रमों में फैले हों। उदाहरण के लिए, एक सेवा पाँच अवधियों में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखाई देते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि की तुलना आसान बनाता है: समान दूरी समान अनुपात को दर्शाती है न कि समान अंतर को।

मूल्य अक्ष पर [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) को `True` के साथ कॉल करें और बेस चुनने के लिए [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा नहीं बदलता या लघुगणकीय ट्रेंड लाइन नहीं जोड़ता। ट्रेंड लाइन डेटा में फिटेड संबंध को दर्शाती है और एक अलग सुविधा है।

### **मूल्य अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिए, मूल्य अक्ष [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिए, यह [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) द्वारा लौटाया जाता है। स्कैटर और बबल चार्ट में दो मूल्य अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए लंबवत अक्ष, या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय बेस `10` है। PPTX चार्ट के लिए, `2` से `1000` तक (समेत) का बेस उपयोग करें; `2.5` जैसे भिन्न बेस भी समर्थित हैं। बेस `10` के साथ, क्रमागत घात जैसे 10, 100, 1 000 और 10 000 समान दूरी पर होते हैं।

### **रैखिक और लघुगणकीय स्केलिंग की तुलना**

निम्नलिखित स्व-निहित उदाहरण पहले स्लाइड पर पाँच अनुरोध गणनाओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरे पर बेस‑10 लघुगणकीय मूल्य अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखती हैं।

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

    # पहले स्लाइड को रैखिक रखें और केवल कॉपी के मान‑अक्ष स्केल को बदलें।
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**रैखिक स्केल (स्लाइड 1):** समान लंबवत दूरी अनुरोध गणनाओं में समान अंतर दर्शाती है। सबसे बड़ा मान चार्ट पर हावी होता है, जिससे छोटे मानों को पहचानना कठिन हो जाता है।

![रैखिक मूल्य अक्ष पर पाँच अनुरोध गणनाओं को दिखाता PowerPoint में लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान लंबवत दूरी समान अनुपात दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर एक सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाओं को दिखाते हैं।

![बेस‑10 लघुगणकीय मूल्य अक्ष पर PowerPoint में वही पाँच अनुरोध गणनाएँ](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल सख्ती से धनात्मक मानों को प्रदर्शित कर सकता है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर करना उपयुक्त है, तो बहिष्कार को समझाएँ। उन्हें छोटे धनात्मक संख्याओं से मौन रूप से बदलें नहीं, क्योंकि इससे डेटा का अर्थ बदल जाता है। किसी भी मैन्युअल रूप से कॉन्फ़िगर किए गए न्यूनतम या अधिकतम लघुगणकीय अक्ष के लिए भी धनात्मक होना चाहिए।

## **FAQ**

**एक अक्ष दूसरे के साथ कहाँ कटता है (अक्ष कटाव) इसे कैसे सेट करें?**  
[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) का उपयोग करके कटाव व्यवहार चुनें। संख्यात्मक कटाव मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) का उपयोग करें। ये सेटिंग्स आपको अक्ष कटाव को उपयुक्त आधाररेखा पर ले जाने की अनुमति देती हैं।

**टिक लेबलों को अक्ष के सापेक्ष कैसे स्थित करें?**  
[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) को [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) का उपयोग करके कॉल करें: `Low`, `High`, `NextTo` या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) या [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) का उपयोग करें; ये लेबल स्थिती से अलग हैं।
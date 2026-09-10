---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करें
linktitle: चार्ट एक्सिस
type: docs
url: /hi/python-java/chart-axis/
keywords:
- चार्ट एक्सिस
- लंबवर्त एक्सिस
- क्षैतिज एक्सिस
- एक्सिस अनुकूलित करें
- एक्सिस को नियंत्रित करें
- एक्सिस प्रबंधन
- एक्सिस गुण
- अधिकतम मान
- न्यूनतम मान
- एक्सिस रेखा
- तिथि स्वरूप
- एक्सिस शीर्षक
- एक्सिस स्थिति
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करने हेतु Java के माध्यम से Python के लिये Aspose.Slides के उपयोग की खोज करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट एक्सिस को अनुकूलित करने के तरीकों को समझाता है। यह वास्तविक एक्सिस मान प्राप्त करना, एक्सिस के बीच डेटा अदला‑बदली करना, लाइन चार्ट के लिए लंबवर्त या क्षैतिज एक्सिस को छुपाना, श्रेणी एक्सिस प्रकार बदलना, श्रेणी एक्सिस मानों के लिए तिथि स्वरूप सेट करना, एक्सिस शीर्षक को घुमाना, एक्सिस की स्थिति निर्धारित करना, और मान एक्सिस की डिस्प्ले यूनिट सेट करना दिखाता है।

## **चार्ट के लंबवर्त एक्सिस पर अधिकतम मान प्राप्त करना**

Aspose.Slides for Python via Java आपको लंबवर्त एक्सिस पर न्यूनतम और अधिकतम मान प्राप्त करने की अनुमति देता है। इन चरणों का पालन करें:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. पहले स्लाइड तक पहुंचें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
4. एक्सिस पर वास्तविक अधिकतम मान प्राप्त करें।
5. एक्सिस पर वास्तविक न्यूनतम मान प्राप्त करें।
6. एक्सिस की वास्तविक प्रमुख इकाई प्राप्त करें।
7. एक्सिस की वास्तविक लघु इकाई प्राप्त करें।
8. एक्सिस के वास्तविक प्रमुख इकाई स्केल प्राप्त करें।
9. एक्सिस के वास्तविक लघु इकाई स्केल प्राप्त करें।

यह नमूना कोड—उपर्युक्त चरणों का कार्यान्वयन—आपको पाइथन में आवश्यक मान प्राप्त करने का तरीका दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # प्रस्तुति को सहेजता है
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एक्सिस के बीच डेटा अदला‑बदली**

Aspose.Slides आपको एक्सिस के बीच डेटा शीघ्रता से अदला‑बदली करने की अनुमति देता है—ऊर्ध्वाधर एक्सिस (y‑axis) पर दर्शाए गए डेटा को क्षैतिज एक्सिस (x‑axis) पर ले जाता है और इसके विपरीत।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # चार्ट का डिफ़ॉल्ट डेटा वर्कबुक में लोड करता है — switchRowColumn वर्कबुक को ट्रांसपोज़ करता है,
    # इसलिए इसे पहले भरना आवश्यक है
    workbook = chart.getChartData().getChartDataWorkbook()

    # पंक्तियों और स्तंभों को बदलता है
    chart.getChartData().switchRowColumn()

    # प्रस्तुति को सहेजता है
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लाइन चार्ट के लिए लंबवर्त एक्सिस निष्क्रिय करें**

यह पाइथन कोड आपको लाइन चार्ट के लिए लंबवर्त एक्सिस छिपाने का तरीका दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लाइन चार्ट के लिए क्षैतिज एक्सिस निष्क्रिय करें**

यह कोड आपको लाइन चार्ट के लिए क्षैतिज एक्सिस छिपाने का तरीका दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **श्रेणी एक्सिस बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#setCategoryAxisType) मेथड का उपयोग करके, आप अपनी पसंदीदा श्रेणी एक्सिस प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। पाइथन में यह कोड इस ऑपरेशन को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **श्रेणी एक्सिस मानों के लिए तिथि स्वरूप सेट करें**

Aspose.Slides for Python via Java आपको श्रेणी एक्सिस मान के लिए तिथि स्वरूप सेट करने की अनुमति देता है। यह ऑपरेशन इस पाइथन कोड में दर्शाया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट एक्सिस शीर्षक के लिए घूर्णन कोण सेट करें**

Aspose.Slides for Python via Java आपको चार्ट एक्सिस शीर्षक के लिए घूर्णन कोण सेट करने की अनुमति देता है। यह पाइथन कोड इस ऑपरेशन को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **श्रेणी या मान एक्सिस पर एक्सिस स्थिति सेट करें**

Aspose.Slides for Python via Java आपको श्रेणी या मान एक्सिस पर एक्सिस स्थिति सेट करने की अनुमति देता है। यह पाइथन कोड कार्य को कैसे करना है दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट मान एक्सिस पर डिस्प्ले यूनिट सेट करें**

Aspose.Slides for Python via Java आपको चार्ट मान एक्सिस की डिस्प्ले यूनिट सेट करने की अनुमति देता है। फिर एक्सिस अपने टिक लेबल को उस यूनिट के अनुसार स्केल करता है: [DisplayUnitType.Millions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/displayunittype/#Millions) के साथ, 60,000,000 तक चलने वाला एक्सिस 0 से 60 तक लेबल किया जाता है। यह पाइथन कोड इस ऑपरेशन को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक्सिस के पार होने का मान कैसे सेट करें (axis crossing)?**

एक्सिस एक [crossing setting](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#setCrossType) प्रदान करते हैं: आप शून्य पर, अधिकतम श्रेणी/मान पर, या किसी विशिष्ट संख्यात्मक मान पर पार होने का चयन कर सकते हैं। यह X‑axis को ऊपर या नीचे शिफ्ट करने या बेसलाइन को उजागर करने के लिए उपयोगी है।

**टिक मार्क को एक्सिस के सापेक्ष (crossing, outside, inside) कैसे स्थित करें?**

[tick mark position](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#setMajorTickMark) को "cross", "outside" या "inside" पर सेट करें। यह पठनीयता को प्रभावित करता है और विशेषकर छोटे चार्ट में जगह बचाने में मदद करता है।
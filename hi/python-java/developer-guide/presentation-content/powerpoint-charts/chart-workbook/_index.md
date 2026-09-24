---
title: Java के माध्यम से Python का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/python-java/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Java के माध्यम से Python के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका समझाता है। यह दर्शाता है कि कैसे वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा पढ़ा और लिखा जाता है, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाता है, वर्कशीट संग्रह तक पहुंचा जाता है, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट किया जाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाता है, चार्ट से जुड़े बाहरी वर्कबुक का पथ प्राप्त किया जाता है, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित किया जाता है।

गायब डेटा को दर्शाने वाले वर्कबुक सेल्स के बारे में, खाली सेल और शून्य के बीच अंतर तथा उपलब्ध डिस्प्ले मोड की रेखा-चार्ट तुलना के लिए [Control the Display of Empty Cells](/slides/hi/python-java/chart-series/) देखें।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**
Aspose.Slides [readWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells द्वारा संपादित चार्ट डेटा वाला) पढ़ने और लिखने की अनुमति देता है। **Note** कि चार्ट डेटा को समान रूप से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट का सत्यापन**
जब आप एक एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपने मूल सीरीज़ और कैटेगरी संग्रह को बरकरार रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) को `ArgumentOutOfRangeException` (parameter: index) फेंकने का कारण बन सकती है। अपवाद से बचने के लिए, अपडेटेड वर्कबुक को चार्ट में लिखने **पहले** मौजूदा सीरीज़ और कैटेगरी को साफ़ करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# संशोधन के बाद वर्कबुक पढ़ें (उदाहरण के लिए, Aspose.Cells का उपयोग करके)।
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # मौजूदा डेटा संदर्भों को साफ़ करें।
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

कलेक्शन को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के अनुरूप हो, जिससे [validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) बिना त्रुटियों के पूरा हो जाता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. कुछ डेटा के साथ एक बब्ल चार्ट जोड़ें।
4. चार्ट सीरीज़ तक पहुंचें।
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
6. प्रेजेंटेशन सहेजें।

यह Python कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वर्कशीट्स प्रबंधित करें**

यह Python कोड एक ऑपरेशन दर्शाता है जहाँ [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुंचा जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह Python कोड दिखाता है कि कैसे डेटा स्रोत के लिए एक प्रकार निर्दिष्ट किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेड की जा सकने वाली Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को सपोर्ट नहीं करता है। आप असमर्थित फ़ॉर्मेट का पता लगाने और उन चार्ट को स्किप करने के लिए [ChartData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/workbooktype/) एन्मरेशन के साथ उपयोग कर सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # एम्बेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
            continue
        # यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
finally:
    presentation.dispose()
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुकों का उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **एक बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का उपयोग करके आप एक चार्ट को उसका डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि वह बाद में स्थानांतरित किया गया हो)।

जबकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुकों के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ दिया गया है, तो इसे स्वचालित रूप से पूर्ण पथ में परिवर्तित किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का दूसरा (`bool`) पैरामीटर यह निर्दिष्ट करने के लिए उपयोग किया जाता है कि Excel वर्कबुक लोड होगी या नहीं।

* जब इसका मान `False` सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।
* जब इसका मान `True` सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट का बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।
4. स्रोत ([ChartDataSourceType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatasourcetype/)) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।
5. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर प्रासंगिक शर्त निर्दिष्ट करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुकों के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुकों की सामग्री में परिवर्तन करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट एक ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रेजेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बनाकर लाता है। [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) बनाएं, इसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रेजेंटेशन खोलने से पहले `True` के साथ [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को कॉल करें।

निम्नलिखित Python उदाहरण एक प्रेजेंटेशन खोलता है जिसमें चार्ट एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनर्प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#getChartData) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # पुनर्प्राप्त वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
finally:
    presentation.dispose()
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकता है। पुनर्प्राप्ति केवल तभी सक्षम करें जब कैश किए गए चार्ट डेटा को fallback के रूप में उपयोग करना स्वीकार्य हो, क्योंकि कैश में बाहरी वर्कबुक में प्रेजेंटेशन के अंतिम अपडेट के बाद किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक किया गया है?**

हाँ। चार्ट में एक [data source type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getDataSourceType) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर यह पुष्टि कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुकों के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहित होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए उपयोगी है; हालाँकि, ध्यान रखें कि प्रेजेंटेशन PPTX फ़ाइल में पूर्ण पथ संग्रहीत करता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुकों का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुकों को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुकों को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रेजेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रेजेंटेशन [link to the external file](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) को संग्रहीत करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेजेंटेशन सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक बनाते समय पासवर्ड स्वीकार नहीं करता। आम तौर पर पहले सुरक्षा हटाकर या एक डीक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](/cells/python-java/)) तैयार करके फिर उस कॉपी को लिंक करना उचित है।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को इंगित करते हैं, तो उस फ़ाइल में परिवर्तन किया जाता है तो अगली बार डेटा लोड होने पर सभी चार्ट में वह परिवर्तन परिलक्षित होगा।
---
title: Python द्वारा Java के साथ प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रह तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides [readWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को समान रूप से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करें**
जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपने मूल सीरीज़ और श्रेणी संग्रह को बरकरार रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) को `ArgumentOutOfRangeException` (पैरामीटर: index) फेंकने का कारण बन सकती है। इस अपवाद से बचने के लिए, अपडेटेड वर्कबुक को चार्ट में वापस लिखने से **पहले** मौजूदा सीरीज़ और श्रेणियों को साफ़ करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# संशोधित करने के बाद वर्कबुक पढ़ें (उदा., Aspose.Cells का उपयोग करके).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # मौजूदा डेटा संदर्भ साफ़ करें।
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के साथ मेल खाती है, जिससे [validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) बिना त्रुटियों के पूर्ण हो सकता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।  
1. स्लाइड का संदर्भ उसका इंडेक्स से प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट सीरीज़ तक पहुंचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेजेंटेशन को सेव करें।

यह Python कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट किया जाए:

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

## **वर्कशीट प्रबंधन**
यह Python कोड एक ऑपरेशन दर्शाता है जहाँ [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड का उपयोग वर्कशीट संग्रह तक पहुंचने के लिए किया जाता है:

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
यह Python कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

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
Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/workbooktype/) एन्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं।

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

### **एक बाहरी वर्कबुक बनाएं**
[readWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का उपयोग करके, आप या तो शुरू से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह Python कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

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
[setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का उपयोग करके, आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

हालाँकि आप रिमोट लोकेशन या रिसोर्स में संग्रहित वर्कबुक का डेटा संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ दिया गया है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

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

* जब इसका मान `False` सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।  
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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**
1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।  
1. स्लाइड का संदर्भ उसकी इंडेक्स से प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
1. स्रोत ([ChartDataSourceType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatasourcetype/)) प्रकार का एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।  
1. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर उपयुक्त शर्त निर्दिष्ट करें।

यह Python कोड इस ऑपरेशन को दर्शाता है:

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
आप बाहरी वर्कबुक का डेटा उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में परिवर्तन करते हैं। जब एक बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

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
यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रेज़ेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। प्रेज़ेंटेशन खोलने से पहले [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) बनाएं, इसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और `True` के साथ [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को कॉल करें।

निम्नलिखित Python उदाहरण एक प्रेज़ेंटेशन खोलता है जहाँ चार्ट एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनः प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#getChartData) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```python
import jpide
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

यदि बाहरी वर्कबुक उपलब्ध नहीं है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकता है। केवल तभी पुनर्प्राप्ति को सक्षम करें जब कैश किए गए चार्ट डेटा का उपयोग एक स्वीकार्य वैकल्पिक समाधान हो, क्योंकि कैश में प्रेज़ेंटेशन के अंतिम अपडेट के बाद बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हां। एक चार्ट के पास एक [data source type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getDataSourceType) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ को पढ़कर सुनिश्चित कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रेज़ेंटेशन PPTX फ़ाइल में पूर्ण पथ को संग्रहीत करेगा।

**क्या मैं नेटवर्क रिसोर्सेज़/शेयर्स पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रेज़ेंटेशन सेव करते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रेज़ेंटेशन [link to the external file](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) को संग्रहीत करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेज़ेंटेशन सेव होने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**अगर बाहरी फ़ाइल पासवर्ड-संरक्षित हो तो मैं क्या करूँ?**  
Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका है पहले से सुरक्षा हटाना या डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिए, [Aspose.Cells](/cells/python-java/) का उपयोग करके) और उस कॉपी को लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**  
हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इंगित करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में प्रतिबिंबित होगा।
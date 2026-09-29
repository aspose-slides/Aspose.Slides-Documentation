---
title: Python के माध्यम से Java का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपने प्रेजेंटेशन डेटा को सुगम बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को समझाता है। यह वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को पढ़ने और लिखने, चार्ट डेटा लेबल के रूप में वर्कबुक कोशिकाओं का उपयोग करने, वर्कशीट संग्रहों तक पहुंचने, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने का प्रदर्शन करता है।

यह लेख बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने के बारे में भी बताता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और उसे असाइन करें, चार्ट से जुड़े बाहरी वर्कबुक के पथ को प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करें।

ग़ायब डेटा दर्शाने वाली वर्कबुक कोशिकाओं के लिए, खाली कोशिका और शून्य के अंतर तथा उपलब्ध डिस्प्ले मोड की तुलना के लिए देखें [Control the Display of Empty Cells](/slides/hi/python-java/chart-series/)।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छुपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करने के लिए यह नियंत्रित करता है। इसे `True` सेट करने पर केवल दृश्यमान कोशिकाओं को प्लॉट किया जाता है, या `False` सेट करने पर दृश्यमान और छिपी दोनों कोशिकाएँ शामिल की जाती हैं। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छुपाने या दिखाने का काम नहीं करती।

[hidden-source-data.pptx](hidden-source-data.pptx) डाउनलोड करें और उसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहले आकार के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: महीना | B: खुदरा | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (छिपी पंक्ति) | February | 40 | 60 |
| 4 | March | 20 | 50 |

स्रोत कोशिकाओं को [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करें और उनके छिपे होने की स्थिति को जांचने के लिए [ChartDataCell.isHidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#isHidden) पढ़ें। यह विधि छिपी स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#readWorkbookStream) के साथ रखें और उसे [writeWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#writeWorkbookStream) के साथ पुनः लोड करें। सभी कोशिकाओं को शामिल करने के लिए, छिपी फ़रवरी श्रेणी सहित पूर्ण रेंज पुनर्स्थापित करने हेतु [setRange](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setRange) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ्रेश करने के लिये अपर्याप्त है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # एम्बेडेड वर्कबुक से चार्ट डेटा को रिफ्रेश करें।
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

उदाहरण `hidden_cells_True.pptx` को केवल दृश्यमान खुदरा मान (10 और 20) के साथ सहेजता है, और `hidden_cells_False.pptx` को सभी छह मानों के साथ। नीचे की छवियां दो प्लॉटिंग मोड दर्शाती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`True`) | सभी कोशिकाएँ (`False`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए खुदरा मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फरवरी, और मार्च के लिए खुदरा और थोक मान।](hidden_cells_False.png) |

एक मान वाली छिपी कोशिका खाली कोशिका से अलग होती है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDisplayBlanksAs) नियंत्रित करता है कि ग़ायब मान कैसे दिखाया जाए; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [Control the Display of Empty Cells](/slides/hi/python-java/chart-series/#control-the-display-of-empty-cells)।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Python via Java द्वारा प्रदान किए गए [readWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड्स आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित) पढ़ने और लिखने की सुविधा देते हैं। **Note** कि चार्ट डेटा को उसी तरह व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण `chart.pptx` खोलता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **कार्यपुस्तिका संशोधन के बाद चार्ट लेआउट को मान्य करें**

जब आप एम्बेडेड वर्कबुक को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रहों को बनाए रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि से विफल कर सकती है। अद्यतन वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण `chart.pptx` की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है। टिप्पणी उन भागों को दिखाती है जहाँ वर्कबुक संपादन होना चाहिए; चलाने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # वर्कबुक बाइट्स को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

संग्रहों को साफ़ करने से वर्कबुक लिखने से पहले पुराने डेटा संदर्भ हट जाते हैं। अद्यतन वर्कबुक के लिए आवश्यक किसी भी सीरीज़ और श्रेणी मैपिंग को पुनः बनाएँ।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं से पाठ का उपयोग करके चार्ट डेटा लेबल सेट कर सकते हैं। नीचे दिए गए चरण बबल चार्ट में लेबल को उसके डेटा वर्कबुक की कोशिकाओं से लिंक करने का तरीका दर्शाते हैं।

1. Presentation क्लास की एक instance बनाएं।
2. शून्य‑आधारित इंडेक्स द्वारा पहला स्लाइड एक्सेस करें।
3. डिफॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।
4. चार्ट सीरीज़ को एक्सेस करें।
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
6. प्रेजेंटेशन सहेजें।

यह उदाहरण `chart2.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 पर कोशिकाएँ A10:A12 का उपयोग पहले सीरीज़ के पहले तीन लेबलों के लिये करता है, कोशिकाओं से लेबल सक्षम करता है, और परिणाम `resultchart.pptx` में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

## **वर्कशीट्स का प्रबंधन**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड चार्ट वर्कबुक में उपलब्ध वर्कशीट्स तक पहुँच प्रदान करता है। यह उदाहरण डिफॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह उदाहरण डिफॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा नाम वर्कशीट 0 में सेल C1 से प्राप्त होता है। [DataSourceType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datasourcetype/) एन्नुमरेशन प्रत्येक नाम के स्रोत को चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/workbooktype/) एन्नुमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण `sample.pptx` की पहली स्लाइड पर आकारों की जाँच करता है, गैर‑चार्ट आकारों को छोड़ता है, और एम्बेडेड .xlsb वर्कबुक वाले प्रत्येक चार्ट के लिये निदान संदेश प्रिंट करता है।

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
finally:
    presentation.dispose()
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिये डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसकी वर्कबुक को `externalWorkbook1.xlsx` में लिखता है, और फ़ाइल लिखने के बाद फ़ाइल को चार्ट डेटा स्रोत के रूप में असाइन करता है। लिंक्ड प्रस्तुति `externalWorkbook.pptx` में सहेजी जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का उपयोग करके आप किसी चार्ट को उसके डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिये भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक का डेटा सीधे संपादित नहीं कर सकते, लेकिन उन्हें बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी वर्कबुक के लिये सापेक्ष पथ प्रदान किया जाता है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता रखता है। उसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होने चाहिए। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setRange) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों के रूप में मैप करता है। परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजा जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) का `updateChartData` पैरामीटर यह नियंत्रित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `False` है, तो केवल वर्कबुक पथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक अनुपलब्ध हो सकती है।
* जब `updateChartData` `True` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट किया जाता है।

निम्न उदाहरण `updateChartData` को `False` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफॉल्ट डेटा को बनाए रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, पहले जाँचें कि चार्ट बाहरी डेटा स्रोत का उपयोग कर रहा है या नहीं। यदि हाँ, तो आप निम्न चरणों का पालन करके वर्कबुक पथ प्राप्त कर सकते हैं।

1. Presentation क्लास की एक instance बनाएं।
2. शून्य‑आधारित इंडेक्स द्वारा पहला स्लाइड एक्सेस करें।
3. जाँचें कि पहला आकार एक चार्ट है या नहीं।
4. चार्ट डेटा स्रोत प्रकार पढ़ें।
5. यदि स्रोत एक बाहरी वर्कबुक है, तो उसका पथ पढ़ें।

यह उदाहरण `externalWorkbook.pptx` खोलता है, जिसे पहले के उदाहरण में बनाया गया था, और पहली स्लाइड पर पहले आकार की जाँच करता है। यदि वह एक चार्ट है जो बाहरी वर्कबुक से जुड़ा है, तो उदाहरण कंसोल पर [getExternalWorkbookPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) प्रिंट करता है। फिर वह प्रस्तुति की एक कॉपी `Result.pptx` में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में परिवर्तन करते हैं। जब बाहरी वर्कबुक लोड नहीं किया जा सकता, तो एक अपवाद उत्पन्न होता है।

यह उदाहरण `presentation.pptx` की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है और एक पहुँच योग्य बाहरी वर्कबुक है। यह पहले सीरीज़ के पहले डेटा बिंदु का सेल‑बैक्ड मान 100 पर सेट करता है और परिणाम `presentation_out.pptx` में सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो ग़ायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को `True` सेट करके प्रस्तुति खोलें।

निम्न Python उदाहरण `presentation.pptx` खोलता है, जिसकी पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए जो अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है, और पुनर्प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#getChartData) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा को एक स्वीकार्य बैकअप के रूप में उपयोग करना उचित हो, क्योंकि कैश में बाहरी वर्कबुक के उन परिवर्तनों को शामिल नहीं किया जा सकता जो प्रस्तुति के आख़िरी अपडेट के बाद हुए हों।

## **FAQ**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। चार्ट के पास एक [data source type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getDataSourceType) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर पुष्टि कर सकते हैं कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से दूरस्थ वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रेजेंटेशन में एक [link to the external file](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना आवश्यक है तो वर्कबुक की एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/python-java/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में बदलाव प्रतिबिंबित होंगे।
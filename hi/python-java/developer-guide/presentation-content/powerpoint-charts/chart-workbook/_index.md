---
title: Python via Java का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
description: "Aspose.Slides for Python via Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सुगम बनाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक कैसे पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने के बारे में भी बताता है। उदाहरण दर्शाते हैं कि कैसे बाहरी वर्कबुक बनाएं और असाइन करें, किसी चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

अनुपलब्ध डेटा को प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, खाली सेल और शून्य के बीच अंतर के लिये [Control the Display of Empty Cells](/slides/hi/python-java/chart-series/) देखें, और उपलब्ध डिस्प्ले मोड की रेखीय-चार्ट तुलना देखें।

## **छिपी पंक्तियों और स्तम्भों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तम्भों से डेटा प्लॉट किया जाए या नहीं, इसे नियंत्रित करने के लिये [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) का उपयोग करें। इसे `True` सेट करने पर केवल दृश्यमान सेल्स प्लॉट होते हैं, या `False` पर दृश्यमान और छिपे दोनों सेल्स शामिल होते हैं। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तम्भों को छिपाती या प्रदर्शित नहीं करती।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड के पहले आकार के रूप में एक कॉलम चार्ट है। एंबेडेड वर्कशीट, `Sheet1`, में स्रोत सीमा `A1:C4` है। पंक्ति 3 और स्तम्भ C छिपे हैं, लेकिन उनके सेल्स में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: महीना | B: रिटेल | C: थोक (छिपा स्तम्भ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (छिपी पंक्ति) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से स्रोत सेल्स तक पहुंचें और छिपी स्थिति जांचने के लिये [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) पढ़ें। यह विधि छिपी स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तम्भ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिये, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा रीफ़्रेश करें: एंबेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) से रखकर [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) के साथ पुनः लोड करें। सभी सेल्स को शामिल करने पर, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने के लिये भी [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश किए गए चार्ट डेटा और श्रेणी लेबल्स को रीफ़्रेश करने के लिये पर्याप्त नहीं है।

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

            # एंबेडेड वर्कबुक से चार्ट डेटा रीफ़्रेश करें।
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

उदाहरण प्रस्तुति के दो संस्करण सहेजता है: एक केवल दृश्यमान रिटेल मान (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे की छवियों में दो प्लॉटिंग मोड दर्शाए गए हैं। पंक्ति 3 और स्तम्भ C दोनों एंबेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान सेल्स (`True`) | सभी सेल्स (`False`) |
| --- | --- |
| ![केवल दृश्यमान सेल्स: जनवरी और मार्च के लिये रिटेल मान 10 और 20.](hidden_cells_True.png) | ![सभी सेल्स: जनवरी, फ़रवरी और मार्च के लिये रिटेल और थोक मान.](hidden_cells_False.png) |

एक मान वाली छिपी सेल खाली सेल से अलग होती है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) नियंत्रित करता है कि अनुपलब्ध मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [Control the Display of Empty Cells](/slides/hi/python-java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा अपडेट करने से पहले, स्रोत रेंजों की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन‑से वर्कशीट सेल्स का उपयोग करता है। [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) विधि वर्तमान डेटा रेंज को वर्कशीट‑क्वालिफाइड फ़ॉर्मूला के रूप में लौटाती है, उदाहरण के लिये `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` सेल्स A1 से D5 तक को दर्शाता है। डॉलर चिह्न पूर्ण पंक्ति और स्तम्भ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक उपयोग नहीं करता, तो यह `InvalidOperationException` उत्पन्न करता है। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड में सीधे आकारों को चार्ट के लिये जांचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह संदेश प्रिंट कर अगले चार्ट पर आगे बढ़ता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Python via Java [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) विधियों को प्रदान करता है जिससे आप चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells द्वारा संपादित डेटा है) को पढ़ और लिख सकते हैं। **Note** कि चार्ट डेटा को उसी क्रम में व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड के पहले आकार के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एंबेडेड वर्कबुक को बाइट ऐरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप संशोधित वर्कबुक को एंबेडेड वर्कबुक की जगह रखते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रह को बरकरार रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ फेल करा सकती है। अद्यतन वर्कबुक को चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहले आकार के रूप में एक चार्ट का उपयोग करता है। टिप्पणी दर्शाती है कि वर्कबुक संपादन कहाँ होगा; कार्यात्मक उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

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

        # यहाँ वर्कबुक बाइट्स को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

संग्रहों को साफ़ करने से पुराने डेटा रेफरेंसेज़ हट जाते हैं इससे पहले कि वर्कबुक वापस लिखा जाए। अपडेटेड वर्कबुक के लिये आवश्यक किसी भी श्रृंखला और श्रेणी मैपिंग को पुनः निर्माण करें फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक डिफ़ॉल्ट डेटा वाले बबल चार्ट को जोड़ता है। यह वर्कशीट 0 की सेल्स A10:A12 को पहली श्रृंखला के पहले तीन लेबल के लिये उपयोग करता है, सेल‑आधारित लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट प्रबंधित करें**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) विधि चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

## **डेटा स्रोत प्रकार निर्धारित करें**

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों से सेट करता है। पहली नाम स्ट्रिंग लिटरल से ली गई है; दूसरी नाम वर्कशीट 0 की सेल C1 से ली गई है। [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) एन्थे enumeration प्रत्येक नाम के स्रोत को चुनती है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति सहेजता है।

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

## **एंबेडेड वर्कबुक फ़ॉर्मेट में असमर्थित प्रकारों का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एंबेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) विधि को [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) एन्थे के साथ उपयोग कर असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों को जांचता है, गैर‑चार्ट आकारों को छोड़ता है, और .xlsb वर्कबुक एंबेडेड वाले प्रत्येक चार्ट के लिये निदान संदेश प्रिंट करता है।

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
        # यहाँ समर्थित चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।

finally:
    presentation.dispose()
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिये डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) का उपयोग करके एंबेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। फ़ाइल लेखन पूर्ण होने के बाद बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **एक बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) विधि का उपयोग करके आप किसी चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत स्वरूप में असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक के पथ को भी अपडेट करने के लिये उपयोग की जा सकती है (यदि वह स्थानांतरित किया गया हो)।

जबकि आप रिमोट लोकेशन या रिसोर्सेज़ में संग्रहीत वर्कबुक के डेटा को सीधे संपादित नहीं कर सकते, आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिये सापेक्ष पथ दिया गया है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक लिंक करता है, और [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों के साथ मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) के `updateChartData` पैरामीटर से निर्धारित होता है कि वर्कबुक लोड हो।

* जब `updateChartData` `False` है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध भी हो सकता है।
* जब `updateChartData` `True` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `False` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट की बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिये, जांचें कि क्या चार्ट बाहरी डेटा स्रोत उपयोग करता है और उसके वर्कबुक पथ को प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड के पहले आकार को जांचता है जिसके पास एक लिंक्ड बाहरी वर्कबुक है। यदि वह आकार बाहरी वर्कबुक से लिंक्ड चार्ट है, तो यह [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) को कंसोल में प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक के डेटा को वही तरीके से संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक के डेटा को संपादित करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद उत्पन्न होता है।

यह उदाहरण पहली स्लाइड के पहले आकार के रूप में एक चार्ट का उपयोग करता है जिसकी एक सुलभ बाहरी वर्कबुक से लिंक है। यह पहली श्रृंखला के पहले डेटा बिंदु की सेल‑बैक्ड वैल्यू को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मूल्यों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी उपयोग करें।

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

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को `True` सेट करें फिर प्रस्तुति खोलें।

निम्न Python उदाहरण एक चार्ट के लिये वर्कबुक डेटा पुनः प्राप्त करता है जो पहली स्लाइड के पहले आकार के रूप में है और जिसकी बाहरी वर्कबुक अनुपलब्ध है। यह पुनः प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

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

        # यहाँ पुनर्प्राप्त वर्कबुक डेटा पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनः प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद उठाता है। पुनः प्राप्ति केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा को फॉलबैक के रूप में स्वीकार्य हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बदलाव प्रतिबिंबित नहीं हो सकते।

## **आधिक प्रश्न (FAQ)**

**क्या मैं पता कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एंबेडेड वर्कबुक से लिंक है?**

हां। एक चार्ट के पास [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) और [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति इस पूर्ण पथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक अपडेट करना आवश्यक हो सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूं?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति में [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना हो, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य उपाय यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/python-java/) उपयोग करके) और उस कॉपी से लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट पर असर पड़ेगा।

---
title: Python via Java का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
description: "Aspose.Slides for Python via Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सुगम बनाएँ।"
---
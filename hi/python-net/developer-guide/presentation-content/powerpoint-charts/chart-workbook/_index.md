---
title: Python के साथ प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं को प्रबंधित करें
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/python-net/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- कार्यपुस्तिका कोशिका
- डेटा लेबल
- कार्यपत्रक
- डेटा स्रोत
- बाहरी कार्यपुस्तिका
- बाहरी डेटा
- चार्ट कैश
- कार्यपुस्तिका पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET की खोज करें: PowerPoint और OpenDocument फॉर्मेट में चार्ट कार्यपुस्तिकाओं को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुगम बनाएं।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तिकाओं के साथ काम करने का तरीका समझाता है। यह दिखाता है कि कैसे कार्यपुस्तिका स्ट्रीम्स के माध्यम से चार्ट डेटा पढ़ा और लिखा जाता है, कार्यपुस्तिका कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग किया जाता है, कार्यपत्रक संग्रहों तक पहुँच प्राप्त की जाती है, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट किया जाता है।

यह बाहरी कार्यपुस्तिकाओं को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी कार्यपुस्तिका बनाई और निर्धारित की जाती है, चार्ट से जुड़ी बाहरी कार्यपुस्तिका का पथ प्राप्त किया जाता है, और कार्यपुस्तिका उपलब्ध होने पर चार्ट डेटा को संपादित किया जाता है।

गुम डेटा का प्रतिनिधित्व करने वाली कार्यपुस्तिका कोशिकाओं के लिए, खाली कोशिकाओं और शून्य के बीच अंतर के लिए [Control the Display of Empty Cells](/slides/hi/python-net/chart-series/) देखें, और उपलब्ध प्रदर्शित मोड की तुलनात्मक रेखा-चार्ट देखें।

## **छिपी पंक्तियों और स्तंभों से डेटा सम्मिलित करें**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) का उपयोग करके नियंत्रित किया जाता है कि क्या एक चार्ट छिपी कार्यपत्रक पंक्तियों और स्तंभों से डेटा प्लॉट करता है। इसे `True` पर सेट करने से केवल दृश्यमान कोशिकाएँ प्लॉट होंगी, या `False` पर सेट करने से दृश्यमान और छिपी दोनों कोशिकाएँ सम्मिलित होंगी। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह कार्यपत्रक पंक्तियों या स्तंभों को छिपाती या प्रदर्शित नहीं करती।

[hidden-source-data.pptx](hidden-source-data.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहला आकार एक कॉलम चार्ट है। एम्बेडेड कार्यपत्रक `Sheet1` में निम्नलिखित स्रोत सीमा `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| कार्यपत्रक पंक्ति | A: महीना | B: रिटेल | C: होलसेल (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फरवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) का उपयोग करें और [ChartDataCell.is_hidden](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatacell/is_hidden/) पढ़ें ताकि उनकी छिपी स्थिति का निरीक्षण किया जा सके। यह गुण केवल-पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड कार्यपुस्तिका को [read_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) के साथ रखें और उसे [write_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) से पुनः लोड करें। सभी कोशिकाएँ सम्मिलित करने पर, छिपी फरवरी श्रेणी को पुनर्स्थापित करने के लिए [set_range](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_range/) का भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए अपर्याप्त है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # एम्बेडेड कार्यपुस्तिका से चार्ट डेटा को रीफ़्रेश करें।
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # छिपी श्रेणियों सहित पूर्ण स्रोत सीमा को पुनर्स्थापित करें।
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

उदाहरण `hidden_cells_True.pptx` को केवल दृश्यमान रिटेल मानों (10 और 20) के साथ सहेजता है, और `hidden_cells_False.pptx` को सभी छह मानों के साथ सहेजता है। नीचे की छवियाँ सहेजी गई प्रस्तुतियों को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपनी निर्धारित प्लॉटिंग सेटिंग को बनाए रखती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड कार्यपुस्तिकाओं में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`True`) | सभी कोशिकाएँ (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से भिन्न है। [Chart.display_blanks_as](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/display_blanks_as/) नियंत्रित करता है कि लापता मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को सम्मिलित या बहिष्कृत नहीं करता। उदाहरण के लिए देखें [Control the Display of Empty Cells](/slides/hi/python-net/chart-series/#control-the-display-of-empty-cells)।

## **कार्यपुस्तिका से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Python via .NET [read_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [write_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) मेथड प्रदान करता है जो आपको चार्ट डेटा कार्यपुस्तिकाएँ (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को उसी क्रम में व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण `chart.pptx` खोलता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए। यह एम्बेडेड कार्यपुस्तिका को एक स्ट्रीम में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही कार्यपुस्तिका वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **कार्यपुस्तिका संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एक संशोधित कार्यपुस्तिका को एम्बेडेड कार्यपुस्तिका के साथ बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बनाए रखता है। यह असंगति [Chart.validate_chart_layout](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/validate_chart_layout/) को सीमा‑बाहरी त्रुटि के साथ विफल कर सकती है। अपडेटेड कार्यपुस्तिका को चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण `chart.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए। टिप्पणी उन स्थानों को चिन्हित करती है जहाँ कार्यपुस्तिका संपादन हो सकता है; कार्यान्वित उदाहरण मूल कार्यपुस्तिका को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # वर्कबुक स्ट्रीम को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

संग्रहों को साफ़ करने से कार्यपुस्तिका वापस लिखने से पहले पुराने डेटा रेफ़रेंस हट जाते हैं। अपडेटेड कार्यपुस्तिका के लिए आवश्यक श्रृंखला और श्रेणी मैपिंग को पुनः बनाएँ, फिर चार्ट का उपयोग करें।

## **किसी कार्यपुस्तिका सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप कार्यपुस्तिका कोशिकाओं से पाठ का उपयोग करके चार्ट डेटा लेबल बना सकते हैं। निम्नलिखित चरण दिखाते हैं कि बबल चार्ट में लेबल को उसके डेटा कार्यपुस्तिका की कोशिकाओं से कैसे जोड़ें।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनायें।
1. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।
1. चार्ट श्रृंखला तक पहुँचें।
1. कार्यपुस्तिका सेल को डेटा लेबल के रूप में सेट करें।
1. प्रस्तुतिकरण सहेजें।

यह उदाहरण `chart2.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह कार्यपत्रक 0 की कोशिकाओं A10:A12 का उपयोग पहले श्रृंखला के पहले तीन लेबल के लिए करता है, सेल‑आधारित लेबल सक्षम करता है, और परिणाम को `resultchart.pptx` में सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **कार्यपत्रकों का प्रबंधन करें**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) प्रॉपर्टी एक चार्ट कार्यपुस्तिका में कार्यपत्रकों तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक कार्यपत्रक का नाम कंसोल पर प्रिंट करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल से लिया गया है; दूसरा नाम कार्यपत्रक 0 की सेल C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datasourcetype/) एन्यूमरेशन प्रत्येक नाम के स्रोत को चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **असमर्थित एम्बेडेड कार्यपुस्तिका फॉर्मेट का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी कार्यपुस्तिका (.xlsb) फॉर्मेट का समर्थन नहीं करता जिसे कुछ चार्ट में एम्बेड किया जा सकता है। आप [ChartData](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/) पर [embedded_workbook_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/workbooktype/) एन्यूमरेशन के साथ उपयोग करके असमर्थित फॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं। यह उदाहरण `sample.pptx` की पहली स्लाइड पर स्थित आकृतियों की जांच करता है, गैर‑चार्ट आकृतियों को स्किप करता है, और प्रत्येक .xlsb एम्बेडेड कार्यपुस्तिका वाले चार्ट के लिए निदान संदेश प्रिंट करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # समर्थित चार्ट कार्यपुस्तिका डेटा को यहां पढ़ें या संशोधित करें।
```

## **बाहरी कार्यपुस्तिका**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी कार्यपुस्तिकाओं के उपयोग को समर्थन देता है।

### **एक बाहरी कार्यपुस्तिका बनाएं**

[read_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का उपयोग करके एम्बेडेड चार्ट कार्यपुस्तिका को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी कार्यपुस्तिका से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसकी कार्यपुस्तिका को `externalWorkbook1.xlsx` में लिखता है, और आउटपुट स्ट्रीम को बंद करने के बाद फ़ाइल को चार्ट डेटा स्रोत के रूप में निर्धारित करता है। लिंक्ड प्रस्तुति को `externalWorkbook.pptx` में सहेजा जाता है।

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```


### **एक बाहरी कार्यपुस्तिका सेट करें**

[set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप किसी चार्ट को बाहरी कार्यपुस्तिका को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी कार्यपुस्तिका के पथ को अद्यतन करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गया है)।

हालाँकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत कार्यपुस्तिकाओं के डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसी कार्यपुस्तिकाओं को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी कार्यपुस्तिका के लिए सापेक्ष पथ प्रदान किया गया है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता रखता है। उसका कार्यपत्रक `Sheet1` को B1 में एक श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान शामिल करने चाहिए। उदाहरण एक पाई चार्ट बनाता है, कार्यपुस्तिका लिंक करता है, और [set_range](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों के रूप में मैप करता है। परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजा जाता है।

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का `update_chart_data` पैरामीटर नियंत्रित करता है कि कार्यपुस्तिका लोड की जाए या नहीं।

* जब `update_chart_data` `False` होता है, तो केवल कार्यपुस्तिका पथ अद्यतन किया जाता है। चार्ट डेटा लक्ष्य कार्यपुस्तिका से लोड या अपडेट नहीं होता, इसलिए कार्यपुस्तिका अनुपलब्ध भी हो सकती है।
* जब `update_chart_data` `True` होता है, तो लक्ष्य कार्यपुस्तिका से चार्ट डेटा अपडेट होता है।

निम्न उदाहरण `update_chart_data` को `False` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बनाए रखता है और अनुपलब्ध कार्यपुस्तिका को लोड किए बिना प्रस्तुति सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट की बाहरी डेटा स्रोत कार्यपुस्तिका पथ प्राप्त करें**

किसी चार्ट से जुड़ी कार्यपुस्तिका की पहचान करने के लिए, पहले जांचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है। यदि करता है, तो नीचे दिए चरणों को अपनाकर कार्यपुस्तिका पथ प्राप्त किया जा सकता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनायें।
1. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुँचें।
1. जांचें कि पहला आकार एक चार्ट है।
1. चार्ट डेटा स्रोत प्रकार पढ़ें।
1. यदि स्रोत एक बाहरी कार्यपुस्तिका है, तो उसका पथ पढ़ें।

यह उदाहरण `externalWorkbook.pptx` खोलता है, जो पिछले उदाहरण में बनाया गया था, और पहली स्लाइड पर पहला आकार जांचता है। यदि वह बाहरी कार्यपुस्तिका से लिंक्ड चार्ट है, तो उदाहरण कंसोल पर [external_workbook_path](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) प्रिंट करता है। फिर यह प्रस्तुति की एक प्रति `Result.pptx` में सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट डेटा संपादित करें**

आप बाहरी कार्यपुस्तिकाओं के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक कार्यपुस्तिकाओं की सामग्री बदलते हैं। जब कोई बाहरी कार्यपुस्तिका लोड नहीं हो पाती, तो एक अपवाद उत्पन्न होता है।

यह उदाहरण `presentation.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए और एक सुलभ बाहरी कार्यपुस्तिका हो। यह पहली श्रृंखला के पहले डेटा पॉइंट की सेल‑बैक्ड मान को 100 पर सेट करता है और प्रस्तुति को `presentation_out.pptx` में सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल कार्यपुस्तिका को सुरक्षित रखने हेतु एक प्रतिलिपि उपयोग करें।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **चार्ट कैश से कार्यपुस्तिका पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी कार्यपुस्तिका का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट कार्यपुस्तिका को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) बनाएं, उसके [spreadsheet_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/spreadsheet_options/) को कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hi/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) को `True` सेट करें।

निम्न Python उदाहरण `presentation.pptx` खोलता है, जिसकी पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए जो अनुपलब्ध बाहरी कार्यपुस्तिका का संदर्भ देता है, और पुनः प्राप्त डेटा तक पहुँचता है [Chart.chart_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/chart_data/) और [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # यहाँ पुनर्प्राप्त कार्यपुस्तिका डेटा पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
```

यदि बाहरी कार्यपुस्तिका अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकता है। पुनर्प्राप्ति केवल तब सक्षम करें जब कैश्ड चार्ट डेटा को स्वीकार्य विकल्प माना जाता है, क्योंकि कैश में बाहरी कार्यपुस्तिका में प्रस्तुति के अंतिम अपडेट के बाद किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड कार्यपुस्तिका से जुड़ा है?**

हाँ। एक चार्ट के पास [data source type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत बाहरी कार्यपुस्तिका है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी कार्यपुस्तिकाओं के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए कार्यपुस्तिका को स्थानांतरित करने पर लिंक को अद्यतन करने की आवश्यकता हो सकती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित कार्यपुस्तिकाओं का उपयोग कर सकता हूँ?**

हाँ, ऐसी कार्यपुस्तिकाओं को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से दूरस्थ कार्यपुस्तिकाओं को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो कार्यपुस्तिका की एक प्रतिलिपि उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंक करने के समय पासवर्ड स्वीकार नहीं करता। सामान्य उपाय यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/python-net/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी कार्यपुस्तिका का संदर्भ दे सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट प्रभावित होंगे।
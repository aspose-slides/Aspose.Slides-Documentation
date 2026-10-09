---
title: प्रेजेंटेशन में Python के साथ चार्ट वर्कबुक प्रबंधन
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/python-net/chart-workbook/
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
- वर्कबुक रिकवरी
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET को खोजें: PowerPoint और OpenDocument स्वरूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें ताकि आपके प्रेजेंटेशन डेटा को सुव्यवस्थित किया जा सके।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाएँ और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित करें।

गुम डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, अंतर देखने के लिए [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/) देखें, जिसमें खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध डिस्प्ले मोड का एक लाइन-चार्ट तुलना शामिल है।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है या नहीं, इसे नियंत्रित करने के लिए [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) का उपयोग करें। केवल दृश्यमान कोशिकाएँ प्लॉट करने के लिए इसे `True` सेट करें, या दृश्यमान और छिपी दोनों कोशिकाएँ शामिल करने के लिए `False` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाने या दिखाने का काम नहीं करती।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहले स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) का उपयोग करें और उनके छिपे होने की स्थिति निरीक्षण करने के लिए [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) पढ़ें। यह गुण केवल-पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा रिफ्रेश करें: एम्बेडेड वर्कबुक को [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) से रखें और इसे [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) से पुनः लोड करें। सभी कोशिकाएँ शामिल करने के लिए, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने हेतु [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ्रेश करने के लिए पर्याप्त नहीं है।

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

            # एम्बेडेड वर्कबुक से चार्ट डेटा रिफ्रेश करें।
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक जिसमें केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियों को सहेजी गई प्रस्तुतियों को पुनः खुलने के बाद रेंडर किया गया था; दोनों फ़ाइलें अपने असाइन किए गए प्लॉटिंग सेटिंग को बनाए रखती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे हुए हैं।

| केवल दृश्यमान कोशिकाएँ (`True`) | सभी कोशिकाएँ (`False`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20.](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान.](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से अलग होता है। [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) नियंत्रित करता है कि लापता मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/#control-the-display-of-empty-cells)।

## **एक चार्ट की डेटा रेंज प्राप्त करें**

एक मौजूदा प्रस्तुति में वर्कबुक डेटा अपडेट करने से पहले, स्रोत रेंज को देखिए ताकि यह पहचाना जा सके कि प्रत्येक चार्ट किस वर्कशीट कोशिकाओं का उपयोग करता है। [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) मेथड वर्तमान डेटा रेंज को वर्कशीट-योग्य फ़ॉर्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाओं A1 से D5 तक (समावेशी) को दर्शाता है। डॉलर चिह्न निरपेक्ष पंक्ति और कॉलम संदर्भ दर्शाते हैं।

यह मेथड चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह अपवाद उठाता है। अधिक जानकारी के लिए देखें [ChartData API रेफरेंस](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड की आकृतियों को सीधे जांचता है कि क्या वे चार्ट हैं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि रेंज प्राप्त नहीं हो पाती, तो यह निदान संदेश प्रिंट करता है और अगले चार्ट पर चलता रहता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Python via .NET [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी प्रकार व्यवस्थित करना होगा या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहली स्लाइड की पहली आकृति एक चार्ट है। यह एम्बेडेड वर्कबुक को स्ट्रीम में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एक संशोधित वर्कबुक के साथ एम्बेडेड वर्कबुक को बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रहों को बनाए रखता है। यह असमानता [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ कर दें। यह उदाहरण पहली स्लाइड की पहली आकृति के रूप में एक चार्ट का उपयोग करता है। टिप्पणी उस स्थान को दर्शाती है जहाँ वर्कबुक संपादन होगा; चलाने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

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

कलेक्शन को साफ़ करने से वर्कबुक वापस लिखने से पहले पुराने डेटा रेफ़रेंसेज़ हट जाते हैं। अपडेटेड वर्कबुक के लिए आवश्यक किसी भी सीरीज़ और श्रेणी मैपिंग को पुन: निर्मित करें, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में एक बबल चार्ट के साथ डिफ़ॉल्ट डेटा जोड़ता है। यह वर्कशीट 0 की कोशिकाएँ A10:A12 को पहली सीरीज़ के पहले तीन लेबल के रूप में उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स प्रबंधित करें**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) प्रॉपर्टी चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण एक पाई चार्ट डिफ़ॉल्ट डेटा के साथ बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहली नाम एक स्ट्रिंग लिटरल से आती है; दूसरी नाम वर्कशीट 0 की कोशिका C1 से आती है। [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) एनेमरेशन प्रत्येक नाम के लिए स्रोत चुनता है। उदाहरण अपडेटेड सीरीज़ नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) प्रारूप का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) पर [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट को पहचान सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड की आकृतियों को जांचता है, गैर-चार्ट आकृतियों को छोड़ता है, और प्रत्येक चार्ट के लिए जिसका एम्बेडेड .xlsb वर्कबुक है, निदान संदेश प्रिंट करता है।

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

        # समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएँ**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। यह आउटपुट स्ट्रीम को बंद करता है, फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, और लिंक्ड प्रस्तुति को सहेजता है।

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

### **बाहरी वर्कबुक सेट करें**

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि बाद वाला स्थानांतरित किया गया हो)।

हालांकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों में मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का `update_chart_data` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `update_chart_data` `False` है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो सकता है।
* जब `update_chart_data` `True` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `update_chart_data` को `False` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़े वर्कबुक को पहचानने के लिए, जांचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति की पहली स्लाइड पर पहले आकृति को जांचता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि यह एक चार्ट है जो बाहरी वर्कबुक से जुड़ा है, तो उदाहरण [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) को कंसोल में प्रिंट करता है। इसके बाद यह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं की जा सकती, तो अपवाद फेंका जाता है।

यह उदाहरण एक चार्ट का उपयोग करता है जो पहली स्लाइड की पहली आकृति है और एक उपलब्ध बाहरी वर्कबुक से जुड़ी हुई है। यह पहली सीरीज़ के पहले डेटा बिंदु के सेल-आधारित मान को 100 पर सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिए एक कॉपी का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बनाता है। [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) बनाएं, उसके [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) को कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) को `True` सेट करें।

निम्न Python उदाहरण एक चार्ट के लिए वर्कबुक डेटा पुनर्प्राप्त करता है जो पहली स्लाइड की पहली आकृति है और एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनर्प्राप्त डेटा को [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) और [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से एक्सेस करता है:

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

        # यहाँ पुनः प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति निष्क्रिय है, तो Aspose.Slides अपवाद उठाता है। पुनर्प्राप्ति केवल तब सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य वैकल्पिक उपाय हो, क्योंकि कैश में बाहरी वर्कबुक में अंतिम प्रस्तुति अद्यतन के बाद किए गए परिवर्तन नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट का [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं ताकि सुनिश्चित हो सके कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को ले जाने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत करती है। सेल-आधारित चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक अपरिवर्तित रहना चाहिए, तो उसकी कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित है तो क्या करना चाहिए?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। एक सामान्य उपाय यह है कि पहले सुरक्षा हटाई जाए या डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/python-net/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से प्रत्येक चार्ट पर अगली बार डेटा लोड होने पर परिवर्तन प्रतिबिंबित होंगे।
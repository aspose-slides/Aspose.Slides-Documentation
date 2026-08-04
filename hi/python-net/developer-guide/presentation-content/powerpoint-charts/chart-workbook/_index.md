---
title: Python के साथ प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python को .NET के माध्यम से खोजें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने की विधि समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रह तक कैसे पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides में ऐसे मेथड्स हैं जो चार्ट डेटा वर्कबुक (जो Aspose.Cells के साथ संपादित चार्ट डेटा रखती हैं) को पढ़ने और लिखने की अनुमति देते हैं। **नोट:** चार्ट डेटा को उसी प्रकार या समान संरचना में व्यवस्थित किया जाना चाहिए जैसा स्रोत में है।

निम्नलिखित Python कोड एक नमूना ऑपरेशन दर्शाता है:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना**

कभी‑कभी आपको चार्ट लेबल चाहिए होते हैं जो आधारभूत डेटा वर्कबुक के सेल्स से सीधे आते हों। Aspose.Slides आपको डेटा लेबल को विशिष्ट वर्कबुक सेल्स से बाइंड करने देती है ताकि लेबल टेक्स्ट हमेशा सेल के मान को प्रतिबिंबित करे। नीचे दिया गया उदाहरण दिखाता है कि कैसे सेल‑से‑मान लेबल सक्षम करें और चयनित लेबल को कस्टम सेल्स की ओर इंगित करें।

1. एक [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. नमूना डेटा के साथ एक बबल चार्ट जोड़ें।
4. चार्ट सीरीज़ तक पहुँचें।
5. एक वर्कबुक सेल को डेटा लेबल के रूप में उपयोग करें।
6. प्रस्तुति को सेव करें।

निम्नलिखित Python कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल सेट किया जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **वर्कशीट्स का प्रबंधन**

निम्नलिखित Python कोड `worksheets` प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक पहुँचने का तरीका दर्शाता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

डेटा स्रोत प्रकार निर्दिष्ट करने के लिए निम्नलिखित Python कोड देखें:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मैट का पता लगाना**

Aspose.Slides कुछ चार्ट्स में एम्बेड हो सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मैट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/) पर `embedded_workbook_type` प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/workbooktype/) एन्उमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मैट का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # एम्बेडेड वर्कबुक .xlsb फ़ॉर्मैट में है, जो समर्थित नहीं है।
            continue

        # यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
```

## **बाहरी वर्कबुक्स**

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक्स का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक सेट करना**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का प्रयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहर ले जाने पर बाहरी वर्कबुक का पथ भी अपडेट कर सकता है।

भले ही आप रिमोट लोकेशन या रिसोर्सेज़ पर स्थित वर्कबुक्स को संपादित न कर सकें, फिर भी आप उन वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि आप बाहरी वर्कबुक के लिए रिलेटिव पाथ प्रदान करते हैं, तो वह स्वचालित रूप से पूर्ण पाथ में परिवर्तित हो जाता है।

निम्नलिखित Python कोड दिखाता है कि कैसे एक बाहरी वर्कबुक सेट की जाए:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का `update_chart_data` पैरामीटर यह निर्दिष्ट करता है कि Excel वर्कबुक लोड की जाएगी या नहीं।

- जब `update_chart_data` को `False` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है; चार्ट डेटा लक्ष्य वर्कबुक से लोड या रिफ्रेश नहीं किया जाता। इस सेटिंग का उपयोग तब करें जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।
- जब `update_chart_data` को `True` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से लोड और अपडेट हो जाता है।

### **बाहरी वर्कबुक बनाना**

[read_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी में परिवर्तित कर सकते हैं।

यह Python कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट के लिए बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करना**

कभी‑कभी चार्ट का डेटा एक बाहरी Excel वर्कबुक से जुड़ा होता है, न कि प्रस्तुति के एम्बेडेड डेटा से। Aspose.Slides के साथ आप चार्ट के डेटा स्रोत का निरीक्षण कर सकते हैं और यदि वह बाहरी वर्कबुक है तो पूर्ण पथ पढ़ सकते हैं।

1. एक [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. चार्ट शैप का रेफ़रेंस लें।
4. स्रोत ([ChartDataSourceType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatasourcetype/)) प्राप्त करें जो चार्ट के डेटा स्रोत को दर्शाता है।
5. जांचें कि स्रोत प्रकार बाहरी वर्कबुक डेटा स्रोत प्रकार से मेल खाता है या नहीं।

निम्नलिखित Python कोड इस ऑपरेशन को दर्शाता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **चार्ट डेटा संपादित करना**

आप बाहरी वर्कबुक्स में डेटा को उसी तरह संपादित कर सकते हैं जैसे आंतरिक वर्कबुक्स में करते हैं। यदि कोई बाहरी वर्कबुक लोड नहीं हो पाई, तो एक एक्सेप्शन फेंका जाता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करना**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो गायब या अप्राप्य है, तो Aspose.Slides प्रस्तुतिकरण में कैश्ड डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। पहले [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) बनाएं, फिर प्रस्तुति खोलने से पहले [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/spreadsheet_options/) के माध्यम से [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hi/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) सक्षम करें।

निम्नलिखित Python उदाहरण एक ऐसी प्रस्तुति खोलता है जिसमें चार्ट एक अप्राप्य बाहरी वर्कबुक को संदर्भित करता है और पुनर्प्राप्त डेटा तक पहुँचता है, जो [Chart.chart_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/chart_data/) और [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से उपलब्ध है:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
```

यदि बाहरी वर्कबुक अप्राप्य है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक एक्सेप्शन उठाता है। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [बाहरी वर्कबुक पथ](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर पुष्टि कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के लिए रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से एब्सॉल्यूट पाथ में बदल जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रस्तुति PPTX फ़ाइल में एब्सॉल्यूट पाथ संग्रहीत करेगी।

**क्या मैं नेटवर्क रिसोर्सेज़/शेयर पर स्थित वर्कबुक्स उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से सीधे रिमोट वर्कबुक्स को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रस्तुति एक [बाहरी फ़ाइल लिंक](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। आमतौर पर पहले सुरक्षा हटाकर या एक डिक्रिप्टेड कॉपी तैयार करके (जैसे [Aspose.Cells](/cells/python-net/) का उपयोग करके) लिंक किया जाता है।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में परिवर्तन अगले बार डेटा लोड होने पर सभी चार्ट्स में परिलक्षित होगा।
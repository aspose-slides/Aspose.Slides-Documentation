---
title: "Python के साथ प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें"
linktitle: "चार्ट वर्कबुक"
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
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET को खोजें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका बताता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में कैसे उपयोग करें, वर्कशीट संग्रह तक कैसे पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides में चार्ट डेटा वर्कबुक (जो Aspose.Cells के साथ संपादित चार्ट डेटा शामिल करती हैं) को पढ़ने और लिखने के लिए विधियों उपलब्ध हैं। **नोट:** चार्ट डेटा को उसी तरीके से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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

कभी‑कभी आपको ऐसे चार्ट लेबल चाहिए होते हैं जो मूल डेटा वर्कबुक की सेल्स से सीधे प्राप्त होते हैं। Aspose.Slides आपको डेटा लेबल को विशिष्ट वर्कबुक सेल्स से बाँधने की अनुमति देता है ताकि लेबल टेक्स्ट हमेशा सेल के मान को दर्शाए। नीचे के उदाहरण में दिखाया गया है कि कैसे सेल‑से‑मान वाले लेबल को सक्षम किया जाए और चयनित लेबल को चार्ट की वर्कबुक में कस्टम सेल्स की ओर इंगित किया जाए।

1. [प्रस्तुति](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडैक्स द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. सैंपल डेटा के साथ बबल चार्ट जोड़ें।
4. चार्ट सीरीज़ तक पहुँचें।
5. डेटा लेबल के रूप में वर्कबुक सेल का उपयोग करें।
6. प्रस्तुति को सहेजें।

निम्नलिखित Python कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल कैसे सेट किया जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

    # Presentation क्लास को इंस्टैंशिएट करें जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
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

## **वर्कशीट्स प्रबंधित करना**

निम्नलिखित Python कोड दिखाता है कि `worksheets` प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक कैसे पहुँचें:

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

निम्नलिखित Python कोड दिखाता है कि डेटा स्रोत प्रकार कैसे निर्दिष्ट किया जाए:

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

Aspose.Slides कुछ चार्ट्स में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मैट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/) पर `embedded_workbook_type` प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/workbooktype/) एन्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मैट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं।

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

जब आप [ChartData.set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करते हैं, तो आप एक चार्ट को डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यदि बाहरी वर्कबुक को स्थानांतरित किया गया है, तो यह मेथड पथ को भी अपडेट कर सकता है।

हालांकि आप दूरस्थ स्थानों या संसाधनों पर संग्रहीत वर्कबुक्स में डेटा को संपादित नहीं कर सकते, आप फिर भी उन वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि आप बाहरी वर्कबुक के लिए रिलेटिव पाथ प्रदान करते हैं, तो उसे स्वतः पूर्ण पाथ में परिवर्तित किया जाता है।

निम्नलिखित Python कोड दिखाता है कि बाहरी वर्कबुक कैसे सेट की जाए:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`update_chart_data` पैरामीटर [set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का यह निर्धारित करता है कि Excel वर्कबुक लोड होगी या नहीं।

- जब `update_chart_data` को `False` सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है; चार्ट डेटा लक्ष्य वर्कबुक से लोड या रीफ़्रेश नहीं होता। इस सेटिंग का उपयोग तब करें जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।
- जब `update_chart_data` को `True` सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से लोड हो कर अपडेट हो जाता है।

### **बाहरी वर्कबुक बनाना**

आप [read_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड्स का उपयोग करके या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या आंतरिक वर्कबुक को बाहरी में बदल सकते हैं।

यह Python कोड बाहरी वर्कबुक निर्माण प्रक्रिया दर्शाता है:

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

### **चार्ट के लिए बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करना**

कभी‑कभी एक चार्ट का डेटा प्रस्तुति के एम्बेडेड डेटा की बजाय एक बाहरी Excel वर्कबुक से जुड़ा होता है। Aspose.Slides के साथ आप चार्ट के डेटा स्रोत का निरीक्षण कर सकते हैं और यदि वह बाहरी वर्कबुक है तो उसकी पूरी पाथ पढ़ सकते हैं।

1. [प्रस्तुति](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडैक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. चार्ट शैप का रेफ़रेंस प्राप्त करें।
4. स्रोत ([ChartDataSourceType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatasourcetype/)) प्राप्त करें जो चार्ट के डेटा स्रोत को दर्शाता है।
5. जांचें कि स्रोत प्रकार बाहरी वर्कबुक डेटा स्रोत प्रकार से मेल खाता है या नहीं।

निम्नलिखित Python कोड ऑपरेशन दर्शाता है:

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

आप बाहरी वर्कबुक में डेटा को वहीँ तरह संपादित कर सकते हैं जैसे आंतरिक वर्कबुक में करते हैं। यदि बाहरी वर्कबुक लोड नहीं हो पाती है, तो एक एक्सेप्शन फेंका जाता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट के पास एक [data source type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़ सकते हैं यह सुनिश्चित करने के लिए कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के लिए रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः एब्सोल्यूट पाथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रस्तुति एब्सोल्यूट पाथ को PPTX फ़ाइल में संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक्स को संपादित करना समर्थित नहीं है—उनका उपयोग केवल स्रोत के रूप में ही किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) को संग्रहीत करती है और डेटा पढ़ने के लिए उसका उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो मैं क्या करूँ?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिये, [Aspose.Cells](/cells/python-net/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट पर प्रभाव पड़ेगा।
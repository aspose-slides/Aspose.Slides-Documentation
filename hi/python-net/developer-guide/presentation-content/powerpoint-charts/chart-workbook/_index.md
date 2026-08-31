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
- वर्कबुक रिकवरी
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: ".NET के माध्यम से Python के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ना और लिखना, चार्ट डेटा लेबल के रूप में वर्कबुक कोशिकाओं का उपयोग करना, वर्कशीट संग्रह तक पहुंचना, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करना।

यह लेख बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाए, एक चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides चार्ट डेटा वर्कबुक (जो Aspose.Cells के साथ संपादित चार्ट डेटा रखती हैं) को पढ़ने और लिखने के लिए मेथड प्रदान करता है। **ध्यान दें:** चार्ट डेटा को उसी तरह व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट की वैधता जांचें**

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बरकरार रखता है। यह विसंगति [IChart.validate_chart_layout](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichart/validate_chart_layout/) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को फिर से चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें।

```python
# वर्कबुक स्ट्रीम को संशोधित करने के बाद (उदाहरण के लिए, Aspose.Cells का उपयोग करके)
updated_workbook = chart_data.read_workbook_stream()

# मौजूदा डेटा रेफ़रेन्स को साफ़ करें।
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के साथ सुसंगत है, जिससे `validate_chart_layout` बिना त्रुटियों के पूरा हो सके।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

कभी-कभी आपको चार्ट लेबल चाहिए होते हैं जो सीधे अंतर्निहित डेटा वर्कबुक की कोशिकाओं से आते हैं। Aspose.Slides आपको डेटा लेबल को विशिष्ट वर्कबुक कोशिकाओं से बाइंड करने की अनुमति देता है ताकि लेबल का टेक्स्ट हमेशा कोशिका के मान को दर्शाए। नीचे दिया गया उदाहरण दिखाता है कि कैसे मान-से-कोशिका लेबल सक्षम करें और चयनित लेबल को चार्ट की वर्कबुक में कस्टम कोशिकाओं की ओर इंगित करें।

1. [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. नमूना डेटा के साथ एक बबल चार्ट जोड़ें।
4. चार्ट श्रृंखला तक पहुंचें।
5. एक वर्कबुक सेल को डेटा लेबल के रूप में उपयोग करें।
6. प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल सेट किया जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
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

## **वर्कशीट प्रबंधन**

निम्नलिखित Python कोड `worksheets` प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक पहुंचने का तरीका दर्शाता है:

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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

निम्नलिखित Python कोड डेटा स्रोत प्रकार को कैसे निर्दिष्ट किया जाए, यह दर्शाता है:

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेड की जा सकने वाली Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/) पर `embedded_workbook_type` प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं।

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
            # एम्बेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
            continue

        # यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक सेट करें**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप एक चार्ट को बाहरी वर्कबुक के रूप में डेटा स्रोत असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक को स्थानांतरित करने पर पथ को भी अपडेट कर सकता है।

हालाँकि आप रिमोट स्थान या संसाधन पर संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, फिर भी आप इन वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि आप एक बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

निम्नलिखित Python कोड दिखाता है कि कैसे एक बाहरी वर्कबुक सेट की जाए:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False पास करें ताकि केवल पथ संग्रहीत हो: लक्ष्य वर्कबुक अभी मौजूद होने की आवश्यकता नहीं है।
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` मेथड का `update_chart_data` पैरामीटर यह निर्धारित करता है कि Excel वर्कबुक लोड की जाएगी या नहीं।

- जब `update_chart_data` को `False` सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है; चार्ट डेटा लक्षित वर्कबुक से लोड या रीफ़्रेश नहीं किया जाता। इस सेटिंग का उपयोग तब करें जब लक्षित वर्कबुक मौजूद न हो या उपलब्ध न हो।
- जब `update_chart_data` को `True` (डिफ़ॉल्ट) सेट किया जाता है, तो चार्ट डेटा लक्षित वर्कबुक से लोड और अपडेट हो जाता है। यदि वह वर्कबुक खोला नहीं जा सकता, तो "External workbook is not available" संदेश के साथ एक अपवाद उत्पन्न होता है।

### **बाहरी वर्कबुक बनाएं**

[read_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आन्तरिक वर्कबुक को बाहरी में परिवर्तित कर सकते हैं।

यह Python कोड बाहरी वर्कबुक निर्माण प्रक्रिया को प्रदर्शित करता है:

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

### **चार्ट के लिए बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

कभी-कभी चार्ट का डेटा प्रस्तुति के एम्बेडेड डेटा की बजाय एक बाहरी Excel वर्कबुक से जुड़ा होता है। Aspose.Slides के साथ आप चार्ट के डेटा स्रोत का निरीक्षण कर सकते हैं और यदि वह बाहरी वर्कबुक है तो पूर्ण वर्कबुक पथ पढ़ सकते हैं।

1. [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. चार्ट शेप का संदर्भ प्राप्त करें।
4. स्रोत ([ChartDataSourceType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatasourcetype/)) प्राप्त करें जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।
5. जांचें कि स्रोत प्रकार बाहरी वर्कबुक डेटा स्रोत प्रकार से मेल खाता है या नहीं।

निम्नलिखित Python कोड इस ऑपरेशन को प्रदर्शित करता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आन्तरिक वर्कबुक में करते हैं। यदि कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद उत्पन्न होता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। पहले [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) बनाएं, फिर प्रस्तुति खोलने से पहले [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/spreadsheet_options/) के माध्यम से [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hi/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) को सक्षम करें।

निम्नलिखित Python उदाहरण एक प्रस्तुति खोलता है जिसके चार्ट का संदर्भ एक अनुपलब्ध बाहरी वर्कबुक से है और पुनर्प्राप्त डेटा को [Chart.chart_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/chart_data/) और [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से एक्सेस करता है:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद उठाता है। पुनर्प्राप्ति को केवल तभी सक्षम करें जब कैश किया गया चार्ट डेटा एक स्वीकार्य बैकअप हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तनों को शामिल नहीं किया गया हो सकता है।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। चार्ट के पास एक [data source type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं ताकि यह सुनिश्चित हो सके कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप एक सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से एक पूर्ण पथ में बदल जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान दें कि प्रस्तुति इस पूर्ण पथ को PPTX फ़ाइल में संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या प्रस्तुति सहेजते समय Aspose.Slides बाहरी XLSX को ओवरराइट करता है?**

केवल तब जब आपने चार्ट डेटा संपादित किया हो। प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है, इसलिए प्रस्तुति खोलने और सहेजने से वर्कबुक अपरिवर्तित रहती है। हालांकि, चार्ट डेटा (देखें ऊपर **Edit Chart Data**) में किए गए मान परिवर्तन प्रस्तुति सहेजते समय बाहरी वर्कबुक में वापस लिखे जाते हैं—यदि मूल फ़ाइल को अपरिवर्तित रखना आवश्यक है तो एक कॉपी पर काम करें।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित है तो मैं क्या करूँ?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले संरक्षण हटाया जाए या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](/cells/python-net/) का उपयोग करके) तैयार की जाए और उस कॉपी से लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को रेफ़र कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में परिवर्तन अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिलक्षित होंगे।
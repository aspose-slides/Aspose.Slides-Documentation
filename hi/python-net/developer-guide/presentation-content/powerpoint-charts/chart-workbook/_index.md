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
description: "Aspose.Slides for Python via .NET को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपके प्रेजेंटेशन डेटा को सुव्यवस्थित किया जा सके।"
---
## **Overview**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कैसे वर्कबुक स्ट्रीम्स के द्वारा चार्ट डेटा पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रह तक पहुंचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाए, चार्ट से जुड़े बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा संपादित किया जाए।

गायब डेटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, [Control the Display of Empty Cells](/slides/hi/python-net/chart-series/) देखें कि खाली कोशिकाओं और शून्य के बीच क्या अंतर है, और उपलब्ध डिस्प्ले मोड की लाइन‑चार्ट तुलना देखें।

## **Read and Write Chart Data from a Workbook**

Aspose.Slides ऐसे मेथड प्रदान करता है जो चार्ट डेटा वर्कबुक (जो Aspose.Cells के साथ संपादित चार्ट डेटा रखते हैं) को पढ़ते और लिखते हैं। **Note:** चार्ट डेटा को उसी तरह व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

निम्नलिखित Python कोड एक नमूना ऑपरेशन को प्रदर्शित करता है:

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

### **Validate Chart Layout After Workbook Modification**

जब आप एक अंतर्निहित वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रह को बरकरार रखता है। यह असंगति [IChart.validate_chart_layout](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichart/validate_chart_layout/) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें।

```python
# वर्कबुक स्ट्रीम को संशोधित करने के बाद (उदा., Aspose.Cells का उपयोग करके)
updated_workbook = chart_data.read_workbook_stream()

# मौजूदा डेटा संदर्भों को साफ़ करें।
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नए वर्कबुक के साथ संगत है, जिससे `validate_chart_layout` त्रुटियों के बिना पूरा हो सके।

## **Set a WorkBook Cell as a Chart Data Label**

कभी‑कभी आपको ऐसे चार्ट लेबल चाहिए होते हैं जो सीधे अंतर्निहित डेटा वर्कबुक की कोशिकाओं से आते हों। Aspose.Slides आपको डेटा लेबल को विशिष्ट वर्कबुक सेल से बाइंड करने की अनुमति देता है ताकि लेबल टेक्स्ट हमेशा सेल के मान को प्रतिबिंबित करे। नीचे दिया गया उदाहरण दिखाता है कि कैसे वैल्यू‑फ्रॉम‑सेल लेबल को सक्षम किया जाए और चयनित लेबल को चार्ट की वर्कबुक में कस्टम सेल्स की ओर इंगित किया जाए।

1. [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स द्वारा स्लाइड के संदर्भ को प्राप्त करें।  
3. सैंपल डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में उपयोग करें।  
6. प्रेज़ेंटेशन को सेव करें।

निम्नलिखित Python कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट किया जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
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

## **Manage Worksheets**

निम्नलिखित Python कोड `worksheets` प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक पहुंचने को दर्शाता है:

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

## **Specify the Data Source Type**

डेटा स्रोत प्रकार को निर्दिष्ट करने के लिए निम्नलिखित Python कोड देखें:

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/) पर `embedded_workbook_type` प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं।

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

## **External Workbooks**

Aspose.Slides चार्ट के डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **Set External Workbooks**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप एक चार्ट को उसका डेटा स्रोत बनाते हुए एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड वर्कबुक का पथ भी अपडेट कर सकता है यदि वह स्थानांतरित हो गया हो।

हालांकि आप रिमोट लोकेशन या रिसोर्स पर संग्रहीत वर्कबुक के डेटा को सीधे संपादित नहीं कर सकते, फिर भी आप उन वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि आप बाहरी वर्कबुक के लिए रिलेटिव पथ प्रदान करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है।

निम्नलिखित Python कोड दिखाता है कि कैसे एक बाहरी वर्कबुक सेट किया जाए:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False पास करें ताकि केवल पथ संग्रहीत हो: लक्ष्य वर्कबुक अभी मौजूद नहीं भी हो सकता।
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` मेथड का `update_chart_data` पैरामीटर निर्दिष्ट करता है कि क्या Excel वर्कबुक लोड की जाएगी।

- जब `update_chart_data` को `False` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है; चार्ट डेटा लक्ष्य वर्कबुक से लोड या रिफ्रेश नहीं किया जाता। इस सेटिंग का उपयोग तब करें जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।  
- जब `update_chart_data` को `True` (डिफ़ॉल्ट) पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से लोड और अपडेट किया जाता है। यदि वह वर्कबुक नहीं खोली जा सकती, तो “External workbook is not available” संदेश के साथ एक एक्सेप्शन उत्पन्न होगा।

### **Create External Workbooks**

[read_workbook_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी में बदल सकते हैं।

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

### **Get the External Data Source Workbook Path for a Chart**

कभी‑कभी किसी चार्ट का डेटा एक बाहरी Excel वर्कबुक से जुड़ा होता है न कि प्रेज़ेंटेशन के एम्बेडेड डेटा से। Aspose.Slides के साथ आप चार्ट के डेटा स्रोत का निरीक्षण कर सकते हैं और यदि वह बाहरी वर्कबुक है तो पूर्ण वर्कबुक पथ पढ़ सकते हैं।

1. [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. उसकी इंडेक्स द्वारा स्लाइड के संदर्भ को प्राप्त करें।  
3. चार्ट शेप का रेफ़रेंस प्राप्त करें।  
4. स्रोत ([ChartDataSourceType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatasourcetype/)) प्राप्त करें जो चार्ट के डेटा स्रोत को दर्शाता है।  
5. जांचें कि क्या स्रोत प्रकार बाहरी वर्कबुक डेटा स्रोत प्रकार से मेल खाता है।

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

### **Edit Chart Data**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक में करते हैं। यदि कोई बाहरी वर्कबुक लोड नहीं किया जा सकता, तो एक एक्सेप्शन फेंका जाएगा।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recover a Workbook from the Chart Cache**

यदि कोई चार्ट एक ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रेज़ेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। पहले [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) बनाएं, फिर प्रस्तुति खोलने से पहले [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/spreadsheet_options/) के माध्यम से [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hi/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) को सक्षम करें।

निम्नलिखित Python उदाहरण एक ऐसी प्रेज़ेंटेशन को खोलता है जिसका चार्ट अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनः प्राप्त डेटा को [Chart.chart_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/chart_data/) तथा [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के जरिए एक्सेस करता है:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # पुनर्प्राप्त वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
```

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी अक्षम है, तो Aspose.Slides एक एक्सेप्शन थ्रो करेगा। केवल तभी रिकवरी को सक्षम करें जब कैश किया हुआ चार्ट डेटा एक स्वीकार्य बैकअप हो, क्योंकि कैश में वह परिवर्तन नहीं हो सकते जो बाहरी वर्कबुक में अंतिम अपडेट के बाद किए गए हों।

## **FAQ**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट के पास [data source type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर पुष्टि कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप रिलेटिव पथ 지정 करते हैं, तो वह स्वचालित रूप से एब्सॉल्यूट पथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रेज़ेंटेशन PPTX फ़ाइल में एब्सॉल्यूट पथ संग्रहीत करेगा।

**क्या मैं नेटवर्क रिसोर्सेज/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति को सेव करने पर बाहरी XLSX को ओवरराइट कर देगा?**

केवल तभी जब आप चार्ट डेटा को संपादित करते हैं। प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है, इसलिए प्रस्तुति को खोलने और सेव करने से वर्कबुक अपरिवर्तित रहता है। हालांकि, चार्ट डेटा के माध्यम से आप जो मान बदलते हैं (देखें ऊपर **Edit Chart Data**) उन्हें प्रस्तुति सेव करने पर बाहरी वर्कबुक में लिखा जाता है—यदि मूल फ़ाइल को अपरिवर्तित रखना है तो एक कॉपी पर काम करें।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य समाधान यह है कि पहले प्रोटेक्शन हटा दें या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण हेतु [Aspose.Cells](/cells/python-net/) का उपयोग) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में परिवर्तन अगली बार डेटा लोड होने पर सभी चार्ट में परिलक्षित होंगे।
---
title: "Python के साथ प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें"
linktitle: "डेटा लेबल"
type: docs
url: /hi/python-net/chart-data-label/
keywords:
- "चार्ट"
- "डेटा लेबल"
- "डेटा सटीकता"
- "प्रतिशत"
- "लेबल दूरी"
- "लेबल स्थान"
- "PowerPoint"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for Python via .NET का उपयोग करके चार्ट डेटा लेबल जोड़ना और स्वरूपित करना सीखें, ताकि स्लाइड और अधिक आकर्षक बनें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखला और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठक मानों की पहचान कर सकते हैं और चार्ट को समझ सकते हैं। यह लेख मानों को स्वरूपित करने, प्रतिशत प्रदर्शित करने, लेबल टेक्स्ट पढ़ने, अक्ष अधिकतम से परे लेबल को नियंत्रित करने, श्रेणी अक्ष लेबल स्पेसिंग समायोजित करने और पाई चार्ट लेबल की स्थिति निर्धारित करने के तरीकों को समझाता है।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को स्वरूपित करने के लिए [number_format_of_values](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/number_format_of_values/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, इसका डेटा टेबल प्रदर्शित करता है, और पहली श्रृंखला के लिए मान लेबल सक्षम करता है। स्वरूप `#,##0.00` हजारों विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **लेबल के रूप में प्रतिशत प्रदर्शित करें**

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को [text_frame_for_overriding](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से भाग देने से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट डेटा लेबल के साथ प्रतिशत चिह्न सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत दिखाने के लिए [number_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/number_format/) का उपयोग करें। स्रोत सेल्स से स्वतंत्र रूप से लेबल स्वरूप लागू करने के लिए [is_number_format_linked_to_source](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) को `False` सेट करें।

यह उदाहरण चार श्रेणियों में लाल और नीले श्रृंखला के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 है। लेबल स्वरूप `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि लंबवत अक्ष दो दशमलव स्थान उपयोग करता है। दोनों श्रृंखला सफेद, 10 पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **डेटा लेबल का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए [get_actual_label_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालने, प्रस्तुति सामग्री खोजने, या उत्पन्न चार्ट की सत्यापन में उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम और मान को संयोजित करता है। एक बिंदु अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [text_frame_for_overriding](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) से कस्टम टेक्स्ट उपयोग करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

डेटा बिंदु में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` श्रेणी और श्रृंखला नाम के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को प्रतिस्थापित करता है। [get_actual_label_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्यमान लेबल निकालना चाहते हैं, तो ऊपर दर्शाए अनुसार [is_visible](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/is_visible/) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

यदि आप मैन्युअली अक्ष रेंज सीमा निर्धारित करते हैं, तो कुछ डेटा बिंदु उसकी अधिकतम सीमा से बाहर हो सकते हैं। यह निर्धारित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [show_data_labels_over_maximum](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) का उपयोग करें। यह सेटिंग लेबल दृश्यता को बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

निम्न उदाहरण 60 और 120 मानों के साथ एक 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह लंबवत अक्ष पर [is_automatic_max_value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/axis/is_automatic_max_value/) को `False` और [max_value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/axis/max_value/) को 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल को अनुमति देती है; उसकी एक प्रति उन्हें अक्षम करती है। दोनों स्लाइड्स को `DataLabelsOverMaximum.pptx` में सहेजा जाता है।

[value] लेबल को सक्षम करने के लिए [show_value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/show_value/) का उपयोग करें। चार्ट-स्तर का यह सेटिंग स्वयं मान प्रदर्शित नहीं करता या व्यक्तिगत लेबल की अक्षम मान प्रदर्शनी को ओवरराइड नहीं करता। यह उदाहरण पूरे श्रृंखला के लिए मान सक्षम करता है और [position](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/position/) का उपयोग करके प्रत्येक कॉलम के बाहर के अंत में लेबल रखता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

निम्न छवियों में Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड दिखाए गए हैं। `True` होने पर लेबल **120** ऊपर की सीमा पर दिखाई देता है; `False` होने पर वह छिपा रहता है। लेबल **60** दिखाई ही रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों स्थितियों में **120** बना रहता है।

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष के साथ एक 2D कॉलम चार्ट उपयोग करता है। ऐसे चार्ट जिनमें मान अक्ष नहीं होता, जैसे पाई और डोनट चार्ट, इस प्रकार की अक्ष अधिकतम सीमा नहीं रखते।
{{% /alert %}}

## **अक्ष से लेबल की दूरी सेट करें**

श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करने के लिए [label_offset](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/axis/label_offset/) का उपयोग करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **लेबल स्थान समायोजित करें**

पाई चार्ट में, स्पेसिंग बेहतर करने और लीडर लाइन्स के लिए जगह बनाने हेतु डेटा लेबल की स्थिति समायोजित करें।

यह उदाहरण पहले डेटा बिंदु का मान प्रदर्शित करता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके [x](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/x/) और [y](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/y/) ऑफ़सेट समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**भारी चार्ट में डेटा लेबल ओवरलैप से कैसे बचा जाए?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स, और छोटे फ़ॉन्ट आकार का संयोजन करें; आवश्यकता पड़ने पर कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल चरम मानों या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक या खाली मानों के लिए लेबल केवल कैसे निष्क्रिय करें?**

लेबल सक्षम करने से पहले डेटा बिंदु फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए प्रदर्शनी बंद करें।

**PDF/इमेज निर्यात में लगातार लेबल शैली कैसे सुनिश्चित करें?**

फ़ॉन्ट परिवार और आकार स्पष्ट रूप से सेट करें और रेंडरिंग परिवेश में फ़ॉन्ट उपलब्ध हो, यह सत्यापित करें ताकि फ़ॉलबैक से बचा जा सके।
---
title: प्रेजेंटेशन में Python के साथ चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/python-net/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थिति
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for Python को .NET के माध्यम से उपयोग करके चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के बारे में सीखें, ताकि अधिक आकर्षक स्लाइड्स बनें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख मानों को फ़ॉर्मेट करने, प्रतिशत प्रदर्शित करने, लेबल टेक्स्ट पढ़ने, अक्ष अधिकतम से परे लेबल को नियंत्रित करने, श्रेणी अक्ष लेबल अंतराल को समायोजित करने, और पाई चार्ट लेबल को स्थित करने के तरीकों को समझाता है।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसके डेटा टेबल को प्रदर्शित करता है, और पहले सीरीज़ के लिए वैल्यू लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हजारों विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

## **लेबल के रूप में प्रतिशत दिखाएँ**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत गणना करके [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) में टेक्स्ट असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाले वर्गों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल में प्रतिशत संकेत सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) को `False` सेट करें।

यह उदाहरण चार विभिन्न श्रेणियों में लाल और नीले सीरीज़ के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़े का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0 % के रूप में दिखाता है, जबकि लंबवत अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफ़ेद, 10‑पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

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

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालने, प्रस्तुति सामग्री खोजने, या उत्पन्न चार्ट की वैधता जांचने में उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को संयोजित करता है। एक बिंदु अपना मान प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` श्रेणी और सीरीज़ नामों के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) दोनों स्थितियों में परिणामस्वरूप लेबल स्ट्रिंग लौटाता है। केवल दृश्यमान लेबल निकालने के लिए ऊपर दिखाए अनुसार [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप मैन्युअल रूप से अक्ष सीमा सीमित करते हैं, तो कुछ डेटा बिंदु उसके अधिकतम से अधिक हो सकते हैं। यह नियंत्रित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) का उपयोग करें। यह सेटिंग लेबल की दृश्यता बदलती है; यह अक्ष सीमा या मूल डेटा मूल्यों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मानों के साथ एक 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह लंबवत अक्ष पर [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) को `False` और [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) को 100 सेट करता है। पहला स्लाइड अधिकतम से परे लेबल की अनुमति देता है; उसी स्लाइड की एक प्रतिलिपि उन्हें अक्षम करती है। दोनों स्लाइड `DataLabelsOverMaximum.pptx` में सहेजे जाते हैं।

[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) के साथ वैल्यू लेबल सक्षम करें। चार्ट‑स्तर की सेटिंग स्वयं वैल्यू डिस्प्ले को सक्षम नहीं करती और न ही व्यक्तिगत लेबल की अक्षम वैल्यू डिस्प्ले को ओवरराइड करती है। यह उदाहरण पूरे सीरीज़ के लिए मान सक्षम करता है और [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) का उपयोग करके प्रत्येक कॉलम के बाहरी सिरे पर लेबल रखता है।

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

निम्न छवियाँ Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड दिखाती हैं। `True` के साथ लेबल **120** ऊपरी सीमा पर दिखाई देता है; `False` के साथ यह छिपा रहता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों स्थितियों में **120** रहता है।

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint चार्ट जिसमें मान लेबल 120 दिखाया गया है और अक्ष अधिकतम 100 है](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जिसमें मान लेबल 120 छिपा हुआ है और अक्ष अधिकतम 100 है](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष के साथ 2D कॉलम चार्ट का उपयोग करता है। मान अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार के सीमांकन के लिए अक्ष अधिकतम नहीं रखते हैं।
{{% /alert %}}

## **लेबल को अक्ष से दूरी निर्धारित करें**

[label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरी नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफसेट को 500 सेट करता है। यह सेटिंग श्रेणी अक्ष लेबल को प्रभावित करती है, न कि व्यक्तिगत डेटा बिंदुओं से जुड़े लेबल को।

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

पाई चार्ट पर, डेटा लेबल की स्थिति समायोजित करके स्पेसिंग बेहतर करें और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा बिंदु का मान प्रदर्शित करता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) तथा [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) ऑफसेट को समायोजित करता है। ये ऑफसेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

![समायोजित डेटा लेबल स्थितियों वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण दो पंक्तियों के डेटा लेबल के साथ एक कॉलम चार्ट बनाता है, जो प्लॉट क्षेत्र के ऊपर स्थित हैं। सीरीज़ A दृश्यमान कॉलम दिखाता है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल प्रदान करती हैं। उनके कॉलम को फिल और आउटलाइन हटाकर छिपाया जाता है। सभी तीन सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करने के लिए [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) गुण का उपयोग किया जाता है।

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) सेटिंग लेबल पंक्तियों के लिए स्थान आरक्षित करती है। [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) डिफ़ॉल्ट स्थितियों की गणना करने के बाद, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) और [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए लंबवत ऑफसेट लागू करते हैं। संख्याएँ सीरीज़ मानों से जुड़ी डेटा लेबल ही रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शैप होते हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # B और C के कॉलम छुपाएँ, लेकिन उनके डेटा लेबल रखें।
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # सभी तीन सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करें।
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # प्लॉट के ऊपर दो पंक्तियों के डेटा लेबल के लिए स्थान आरक्षित करें।
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # डिफ़ॉल्ट क्षैतिज स्थान बनाए रखें। Y एक ऑफ़सेट है
            # डिफ़ॉल्ट लेबल स्थान से, जिसे चार्ट-ऊँचाई अंश के रूप में व्यक्त किया गया है।
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # केवल पंक्ति शीर्षक एक अलग टेक्स्ट शेप है।
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![प्लॉट क्षेत्र के ऊपर दो पंक्तियों के डेटा लेबल वाला कॉलम चार्ट](multiple-rows-of-labels.png)

## **बारंबार पूछे जाने वाले प्रश्न**

**सघन चार्ट पर डेटा लेबल ओवरलैप होने से कैसे बचें?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन, और छोटे फ़ॉन्ट आकार को संयोजित करें; आवश्यक होने पर कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल चरम मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक, या खाली मानों के लिए लेबल केवल कैसे निष्क्रिय करें?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें, जैसा कि परिभाषित नियम में बताया गया है।

**PDF/छवियों में निर्यात करते समय लेबल शैली संगत कैसे रखें?**

फ़ॉन्ट परिवार और आकार स्पष्ट रूप से सेट करें और यह सुनिश्चित करें कि रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है, ताकि फ़ॉलबैक से बचा जा सके।
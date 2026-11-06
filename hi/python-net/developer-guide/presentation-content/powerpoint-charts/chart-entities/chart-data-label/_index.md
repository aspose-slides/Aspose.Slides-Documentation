---
title: Python के साथ प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/python-net/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के लिए Aspose.Slides for Python via .NET का उपयोग करके अधिक आकर्षक स्लाइड्स बनाना सीखें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखलाओं और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। इस लेख में बताया गया है कि मानों को कैसे स्वरूपित करें, प्रतिशत कैसे दिखाएँ, लेबल टेक्स्ट कैसे पढ़ें, अक्ष अधिकतम से परे लेबल कैसे नियंत्रित करें, श्रेणी अक्ष लेबल स्पेसिंग कैसे समायोजित करें, और पाई चार्ट लेबल की स्थिति कैसे रखें।

## **दृश्यमान डेटा लेबलों की गिनती**

प्रेजेंटेशन प्रकाशित करने से पहले यह जांचने के लिए [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) का उपयोग करें कि कितने डेटा लेबल दिखाने के लिए सक्षम हैं। `len(labels)` के विपरीत, जो संग्रह में कुल लेबलों की संख्या लौटाता है, यह श्रृंखला की डिफ़ॉल्ट सेटिंग्स और व्यक्तिगत लेबल सेटिंग्स को ध्यान में रखता है।

यह उदाहरण एक कॉलम चार्ट बनाता है जिसमें एक श्रृंखला और तीन डेटा पॉइंट्स होते हैं। यह श्रृंखला के [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) संग्रह तक पहुंचता है और सेटिंग बदलने पर दृश्यमान गणना को प्रिंट करता है: **0, 3, 2, 3**। कुल गणना **3** बनी रहती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    series_cell = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_cell, chart.type)

    for i in range(3):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    labels = series.labels
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # कुल: 3; दृश्यमान: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # दृश्यमान: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # दृश्यमान: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # दृश्यमान: 3
```

श्रेणी का [default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) डिफ़ॉल्ट सेटिंग्स प्रदान करता है। यहाँ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) को सक्रिय करने से सभी तीन लेबलों के मान प्रदर्शित होते हैं। एक लेबल के [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) के माध्यम से इसे `False` सेट करने से चयनित लेबल के लिए वह सेटिंग ओवरराइड हो जाती है। [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) को सक्रिय करने से वह लेबल फिर से दृश्यमान गिना जाता है, भले ही उसका मान छिपा रहता है।

दृश्यमान गिनती दृश्यता सेटिंग को प्रतिबिंबित करती है। यह इस बात को मापती नहीं है कि लेबल ओवरलैप हो रहे हैं, क्लिप किए गए हैं, या रेंडर किए गए चार्ट में पढ़ने योग्य हैं या नहीं।

## **चार्ट डेटा लेबलों में मान सटीकता सेट करें**

सीरीज़ मानों को स्वरूपित करने के लिए [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल दिखाता है, और पहले सीरीज़ के लिए मान लेबल सक्षम करता है। स्वरूप `#,##0.00` हजारों विभाजक और दो दशमलव स्थान प्रदर्शित करता है बिना मूल मान बदले।

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

चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक सेल्स को स्वरूपित करने के लिए देखें [Set Custom Number Formats for Workbook Cells](/slides/hi/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells)। वह उदाहरण यह भी दर्शाता है कि स्रोत सेल स्वरूपों के अनुसार मान लेबल प्रदर्शित होते हैं जबकि संग्रहीत संख्यात्मक मान अपरिवर्तित रहते हैं।

## **लेबल के रूप में प्रतिशत दिखाएँ**

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत निकालें और टेक्स्ट को [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और दो दशमलव स्थान के साथ 8 पॉइंट फ़ॉन्ट में प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। चार्ट डेटा बदलने पर कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबलों के साथ प्रतिशत चिह्न सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) का उपयोग करें। लेबल स्वरूप को स्रोत सेल से स्वतंत्र रूप से लागू करने के लिए [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) को `False` सेट करें।

यह उदाहरण चार श्रेणियों में लाल और नीले सीरीज़ के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान का जोड़ा 1 के बराबर होता है। लेबल स्वरूप `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि ऊर्ध्वाधर अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफ़ेद, 10 पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

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

## **डेटा लेबलों का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल की सेटिंग द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकाले जाने, प्रेजेंटेशन सामग्री खोजने, या उत्पन्न चार्ट का मान्यकरण करने में उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम और मान को संयोजित करता है। एक पॉइंट अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` दिखाए साथ में श्रेणी और सीरीज़ नाम। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) दोनों मामलों में परिणामस्वरूप लेबल स्ट्रिंग लौटाता है। यदि आप केवल दृश्यमान लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप अक्ष रेंज को मैन्युअल रूप से सीमित करते हैं, तो कुछ डेटा पॉइंट्स उसका अधिकतम पार कर सकते हैं। यह निर्धारित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) का उपयोग करें। यह सेटिंग लेबल की दृश्यता को बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह ऊर्ध्वाधर अक्ष पर [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) को `False` और [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) को 100 सेट करता है। पहला स्लाइड अधिकतम के परे लेबल की अनुमति देता है; उसकी एक कॉपी इन्हें अक्षम करती है। दोनों स्लाइड `DataLabelsOverMaximum.pptx` में सहेजे जाते हैं।

[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) के साथ मान लेबल सक्षम करें। चार्ट-स्तरीय सेटिंग स्वयं मान प्रदर्शित नहीं करती या व्यक्तिगत लेबल की अक्षम की गई मान प्रदर्शनी को ओवरराइड नहीं करती। यह उदाहरण पूरी सीरीज़ के लिए मान सक्षम करता है और प्रत्येक कॉलम के बाहर के अंत में लेबल रखने के लिए [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) का उपयोग करता है।

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

निम्न छवियां Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड दिखाती हैं। `True` होने पर लेबल **120** ऊपरी सीमा पर दृश्यमान होता है; `False` होने पर वह छिपा रहता है। लेबल **60** दृश्यमान बना रहता है, अक्ष अधिकतम **100** पर रहता है, और दूसरा डेटा पॉइंट दोनों मामलों में **120** रहता है।

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष वाले 2D कॉलम चार्ट का उपयोग करता है। ऐसे चार्ट जिनमें मान अक्ष नहीं होता, जैसे पाई और डोनट चार्ट, में इस प्रकार का अक्ष अधिकतम नहीं होता।
{{% /alert %}}

## **अक्ष से लेबल दूरी सेट करें**

[label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 पर सेट करता है। यह सेटिंग व्यक्तिगत डेटा पॉइंट लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

पाई चार्ट पर, डेटा लेबल की स्थिति को सुधारें ताकि स्पेसिंग बढ़े और लीडर लाइनों के लिए जगह बन सके।

यह उदाहरण पहले डेटा पॉइंट का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) तथा [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) ऑफ़सेट समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के अनुपात में होते हैं।

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

## **लीडर लाइन्स स्वरूपित करें**

जब पाई चार्ट लेबल स्लाइस के बाहर स्थित होते हैं, तो लीडर लाइन्स पाठकों को प्रत्येक मान को सही स्लाइस से मिलाने में मदद करती हैं। एक विपरीत रंग और थोड़ा मोटी रेखा इन कनेक्शनों को अधिक स्पष्ट बनाती है, जबकि पारदर्शिता और डैश्ड शैली रेखाओं को कम दृश्य बनाती है।

सीरीज़ के डेटा लेबल संग्रह स्तर पर लीडर लाइन्स को स्वरूपित करने के लिए [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) का उपयोग करें। `series.labels.leader_lines_format.line` में सेटिंग्स संग्रह पर लागू होती हैं, न कि व्यक्तिगत लेबल पर।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ पाई चार्ट बनाता है, स्लाइस के बाहर मान दिखाता है, और [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) को सक्रिय करता है। यह दो लेबल को उनकी स्लाइस से अधिक दूर ले जाने के लिए [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) और [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) ऑफ़सेट का उपयोग करता है, जो चार्ट की चौड़ाई और ऊँचाई के अंश होते हैं। कोई इनपुट प्रेजेंटेशन आवश्यक नहीं है।

रेखा का [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) ठोस नीला रंग 191 अल्फा मान (255 में से) के साथ सेट करता है, जिससे लगभग 25% पारदर्शिता मिलती है। [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) रेखा की मोटाई 2 पॉइंट सेट करता है, और [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) इसे डैश्ड बनाता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # दो लेबल्स को उनके स्लाइस से अधिक दूर ले जाएँ।
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

लीडर लाइन्स को सक्रिय करने से यह गारंटी नहीं मिलती कि प्रत्येक लेबल के लिए रेखा दिखाई देगी। दृश्यता लेबल की स्थिति और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो हटाए गए लेबलों के पास दृश्यमान लीडर लाइन्स हैं; जो लेबल स्लाइस के पास रहते हैं, उन्हें इनकी आवश्यकता नहीं होती।

निम्न छवि `FormattedLeaderLines.pptx` को Aspose.Slides द्वारा रेंडर किया गया दिखाती है:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण दो पंक्तियों के डेटा लेबल के साथ कॉलम चार्ट बनाता है जो प्लॉट एरिया के ऊपर स्थित होते हैं। सीरीज़ A दृश्यमान कॉलम दिखाता है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल प्रदान करते हैं। उनके कॉलम फ़िल और आउटलाइन हटाकर छिपे होते हैं। सभी तीन सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करने के लिए [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) गुण का उपयोग किया गया है।

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) सेटिंग्स लेबल पंक्तियों के लिए जगह रिज़र्व करती हैं। [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) डिफ़ॉल्ट स्थितियों की गणना करने के बाद, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) और [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए ऊर्ध्वाधर ऑफ़सेट लागू करते हैं। संख्याएँ सीरीज़ मानों से जुड़ी डेटा लेबल बनी रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शैप होते हैं।

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
            # B और C के कॉलम छिपाएँ, लेकिन उनके डेटा लेबल रखें।
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # तीनों श्रृंखलाओं को एक ही श्रेणी केंद्रों के साथ संरेखित करें।
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # डेटा लेबल की दो पंक्तियों के लिए प्लॉट के ऊपर जगह आरक्षित करें।
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
            # डिफ़ॉल्ट क्षैतिज स्थिति बनाए रखें। Y एक ऑफ़सेट है
            # डिफ़ॉल्ट लेबल स्थिति से, जो चार्ट-ऊँचाई के अनुपात में व्यक्त किया गया है।
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # केवल पंक्ति शीर्षक एक अलग टेक्स्ट शैप है।
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**मैं घने चार्ट पर डेटा लेबल ओवरलैप से कैसे बचूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स, और छोटा फ़ॉन्ट आकार मिलाकर उपयोग करें; आवश्यक होने पर कुछ फ़ील्ड (जैसे श्रेणी) छिपाएँ या केवल अत्यधिक मान या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक या खाली मानों के लिए लेबल केवल कैसे अक्षम करूँ?**

लेबल सक्षम करने से पहले डेटा पॉइंट फ़िल्टर करें और 0, नकारात्मक या लापता मानों के लिए डिस्प्ले बंद करें, जैसा कि नियत नियम में परिभाषित हो।

**PDF/इमेज में निर्यात करते समय लेबल शैली की निरंतरता कैसे सुनिश्चित करूँ?**

फ़ॉन्ट फ़ैमिली और आकार स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध हो, यह सत्यापित करें ताकि फ़ॉलबैक से बचा जा सके।
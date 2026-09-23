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
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for Python via .NET का उपयोग करके चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के बारे में सीखें, जिससे स्लाइड अधिक आकर्षक बनें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मानों की पहचान करने और चार्ट को समझने में मदद मिलती है। यह लेख समझाता है कि मानों को कैसे प्रारूपित करें, प्रतिशत कैसे प्रदर्शित करें, लेबल टेक्स्ट पढ़ें, श्रेणी अक्ष लेबल स्पेसिंग समायोजित करें, और पाई चार्ट लेबल्स की स्थिति कैसे निर्धारित करें।

## **चार्ट डेटा लेबल में डेटा प्रिसीजन सेट करें**

[number_format_of_values](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/number_format_of_values/) को सीरीज़ मानों के फॉर्मेट करने के लिए उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा टेबल दिखाता है, और पहली सीरीज़ के लिए वैल्यू लेबल सक्षम करता है। फॉर्मेट `#,##0.00` हज़ारों विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

## **लेबल्स के रूप में प्रतिशत प्रदर्शित करें**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को [text_frame_for_overriding](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) को असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से भाग देने से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल्स के साथ प्रतिशत चिह्न सेट करें**

जब मानों को भाग के रूप में संग्रहीत किया जाता है, तो प्रतिशत दिखाने के लिए [number_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/number_format/) का उपयोग करें। स्रोत सेल्स से स्वतंत्र रूप से लेबल फॉर्मेट लागू करने के लिए [is_number_format_linked_to_source](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) को `False` सेट करें।

यह उदाहरण चार श्रेणियों में लाल और नीले सीरीज़ के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल फॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दर्शाता है, जबकि वर्टिकल अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफेद, 10‑पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

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

## **डेटा लेबल्स का वास्तविक टेक्स्ट पढ़ें**

[get_actual_label_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) का उपयोग करके डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रेजेंटेशन सामग्री खोजते समय, या उत्पन्न चार्ट की वैधता जाँचते समय उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को मिलाता है। एक पॉइंट अपना मान प्रतिशत के रूप में फॉर्मेट करता है, और दूसरा [text_frame_for_overriding](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` श्रेणी और सीरीज़ नामों के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [get_actual_label_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) किसी भी स्थिति में परिणामस्वरूप लेबल स्ट्रिंग लौटाता है। केवल विज़िबल लेबल निकालना चाहते हैं तो ऊपर दिखाए अनुसार [is_visible](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/is_visible/) को अलग से जांचें।

## **एक्सिस से लेबल दूरी सेट करें**

[label_offset](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/axis/label_offset/) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरी नियंत्रित करें। यह मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफसेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा पॉइंट्स से जुड़े लेबल्स की बजाय श्रेणी अक्ष लेबल्स को प्रभावित करती है।

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

पाई चार्ट में, स्पेसिंग सुधारने और लीडर लाइन्स के लिए जगह बनाने हेतु डेटा लेबल की स्थितियों को समायोजित करें।

यह उदाहरण पहले डेटा पॉइंट का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके [x](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/x/) तथा [y](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/y/) ऑफसेट को समायोजित करता है। ये ऑफसेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

![समायोजित डेटा लेबल स्थिति वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट्स में डेटा लेबल्स के ओवरलैप को कैसे रोक सकता हूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स, और छोटे फ़ॉन्ट आकार को मिलाएँ; आवश्यकता पड़ने पर कुछ फ़ील्ड्स को छुपाएँ (जैसे श्रेणी) या केवल अत्यधिक मानों या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं केवल शून्य, नकारात्मक या खाली मानों के लिए लेबल्स को कैसे अक्षम कर सकता हूँ?**

लेबल सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक मानों या अनुपलब्ध मानों के लिए प्रदर्शन बंद कर दें।

**PDF/छवियों में निर्यात करते समय मैं लेबल शैली को सुसंगत कैसे रख सकता हूँ?**

फ़ॉन्ट फैमिली और साइज को स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है यह सत्यापित करें ताकि फॉलबैक से बचा जा सके।
---
title: Python के साथ प्रस्तुतियों में चार्ट डेटा लेबल्स प्रबंधित करें
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
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के लिए Aspose.Slides for Python को .NET के माध्यम से उपयोग करना सीखें, जिससे अधिक आकर्षक स्लाइड्स बनें।"
---
## **अवलोकन**

एक चार्ट पर डेटा लेबल्स चार्ट की डेटा श्रृंखला या व्यक्तिगत डेटा बिंदुओं के बारे में विवरण दिखाते हैं। वे पाठकों को जल्दी से डेटा श्रृंखलाओं की पहचान करने में मदद करते हैं और चार्ट को समझना आसान बनाते हैं। Aspose.Slides for Python में आप किसी भी चार्ट के लिए डेटा लेबल्स को सक्षम, अनुकूलित और स्वरूपित कर सकते हैं—कि क्या प्रदर्शित करना है (मान, प्रतिशत, श्रृंखला या श्रेणी नाम), लेबल्स को कहाँ रखना है, और उनका रूप (फ़ॉन्ट, संख्या स्वरूप, विभाजक, लीडर लाइन्स, आदि) क्या होगा। यह लेख आवश्यक API और उदाहरणों को रेखांकित करता है जो आपके चार्ट में स्पष्ट, सूचनात्मक लेबल्स जोड़ने के लिए आवश्यक हैं।

## **डेटा लेबल की सटीकता निर्धारित करें**

चार्ट डेटा लेबल्स अक्सर संख्यात्मक मान दिखाते हैं जिनके लिए लगातार सटीकता आवश्यक होती है। इस अनुभाग में बताया गया है कि Aspose.Slides में उचित संख्या स्वरूप लागू करके डेटा लेबल्स के दशमलव स्थानों की संख्या को कैसे नियंत्रित किया जाए।

निम्नलिखित Python उदाहरण दर्शाता है कि चार्ट डेटा लेबल्स की संख्यात्मक सटीकता को कैसे सेट किया जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **लेबल्स के रूप में प्रतिशत प्रदर्शित करें**

Aspose.Slides के साथ, आप चार्ट पर डेटा लेबल्स के रूप में प्रतिशत प्रदर्शित कर सकते हैं। नीचे दिया गया उदाहरण प्रत्येक बिंदु का उसकी श्रेणी में हिस्सा गणना करता है और लेबल को प्रतिशत दिखाने के लिए स्वरूपित करता है।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # चार्ट युक्त प्रस्तुति को सहेजें।
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट डेटा लेबल्स में प्रतिशत चिह्न दिखाएँ**

यह अनुभाग बताता है कि Aspose.Slides का उपयोग करके चार्ट डेटा लेबल्स में प्रतिशत कैसे प्रदर्शित किया जाए और प्रतिशत चिह्न को शामिल किया जाए। आप सीखेंगे कि पूरी श्रृंखला या विशिष्ट बिंदुओं के लिए प्रतिशत मान कैसे सक्षम करें (पाई, डोनट, और 100% स्टैक्ड चार्ट के लिए आदर्श) और लेबल विकल्पों या कस्टम संख्या स्वरूप के माध्यम से स्वरूपण कैसे नियंत्रित किया जाए।

निम्नलिखित Python उदाहरण दर्शाता है कि चार्ट के डेटा लेबल में प्रतिशत चिह्न कैसे जोड़ा जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Presentation वर्ग का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # इंडेक्स द्वारा स्लाइड संदर्भ प्राप्त करें।
    slide = presentation.slides[0]

    # स्लाइड पर PercentsStackedColumn चार्ट बनाएं।
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # चार्ट डेटा कार्यपुस्तिका प्राप्त करें।
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # एक नई श्रृंखला जोड़ें।
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # श्रृंखला भरने का रंग सेट करें।
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # लेबल स्वरूप गुण सेट करें।
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # एक नई श्रृंखला जोड़ें।
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # भराव प्रकार और रंग सेट करें।
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # प्रस्तुति सहेजें।
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **धुर्व से लेबल की दूरी निर्धारित करें**

यह अनुभाग Aspose.Slides में डेटा लेबल्स और चार्ट धुर्व के बीच की दूरी को नियंत्रित करने का तरीका दर्शाता है। इस ऑफ़सेट को समायोजित करने से ओवरलैप रोकने में मदद मिलती है और घनी दृश्यात्मकताओं में पठनीयता बढ़ती है।

निम्नलिखित Python कोड दर्शाता है कि अक्ष-आधारित चार्ट के साथ काम करते समय श्रेणी धुर्व से लेबल की दूरी कैसे निर्धारित की जाए:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation वर्ग का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # स्लाइड संदर्भ प्राप्त करें।
    slide = presentation.slides[0]

    # स्लाइड पर क्लस्टर्ड कॉलम चार्ट बनाएं।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # श्रेणी (क्षैतिज) धुर्व से लेबल दूरी सेट करें।
    chart.axes.horizontal_axis.label_offset = 500

    # प्रस्तुति सहेजें।
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **लेबल की स्थिति समायोजित करें**

जब आप ऐसा चार्ट बनाते हैं जिसमें धुर्व नहीं होते, जैसे पाई चार्ट, तो डेटा लेबल्स किनारे के बहुत पास हो सकते हैं। ऐसे में लेबल की स्थिति को समायोजित करें ताकि लीडर लाइन्स स्पष्ट दिखें।

निम्नलित Python कोड दर्शाता है कि पाई चार्ट पर लेबल की स्थिति को कैसे समायोजित किया जाए:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![बदली हुई लेबल स्थिति](changed_label_position.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट में डेटा लेबल्स के ओवरलैप को कैसे रोकूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स, और फ़ॉन्ट आकार को घटाकर संयोजन करें; यदि आवश्यक हो तो कुछ क्षेत्रों को छुपाएँ (जैसे, श्रेणी) या केवल अत्यधिक/मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक या खाली मानों के लिए केवल लेबल्स को कैसे निष्क्रिय करूँ?**

लेबल्स को सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए प्रदर्शन बंद कर दें।

**PDF/इमेज में निर्यात करते समय एक समान लेबल शैली कैसे सुनिश्चित करूँ?**

फ़ॉन्ट (परिवार, आकार) को स्पष्ट रूप से सेट करें और रेंडरिंग पक्ष पर फ़ॉन्ट उपलब्ध है यह सुनिश्चित करें ताकि फ़ॉलबैक न हो।
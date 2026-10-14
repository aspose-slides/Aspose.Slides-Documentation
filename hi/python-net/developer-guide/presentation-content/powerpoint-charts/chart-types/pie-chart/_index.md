---
title: Python के साथ प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/python-net/pie-chart/
keywords:
- पाई चार्ट
- चार्ट को प्रबंधित करें
- चार्ट को अनुकूलित करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में पाई चार्ट बनाएं और अनुकूलित करें। द्वितीयक प्लॉट कॉन्फ़िगर करें, डेटा लेबल दिखाएँ, और PowerPoint में स्वचालित स्लाइस रंग लागू करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीके को समझाता है। यह Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने तथा मानक पाई चार्ट के लिए स्वचालित स्लाइस रंगकरण सक्षम करने के बारे में दिखाता है।

उदाहरण चार्ट कस्टमाइज़ेशन कार्यों पर केंद्रित हैं जैसे स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अद्यतन प्रस्तुति को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for Python via .NET Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों का समर्थन करता है। ये विकल्प द्वितीयक प्लॉट का आकार और दो प्लॉट्स के बीच डेटा पॉइंट्स के विभाजन को नियंत्रित करते हैं।

निम्न उदाहरण नई प्रस्तुतिकरण में एक Pie of Pie चार्ट बनाता है और डेटा पॉइंट मानों को लेबल के रूप में प्रदर्शित करता है। [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) प्रॉपर्टी द्वितीयक प्लॉट का आकार मुख्य प्लॉट के 149% पर सेट करती है। [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) प्रतिशत-आधारित विभाजन चुनती है, और [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) थ्रेशहोल्ड को 53% पर सेट करती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # मान प्रदर्शित करें और द्वितीयक प्लॉट को कॉन्फ़िगर करें।
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **द्वितीयक प्लॉट के लिए श्रेणियों का चयन**

जब आप द्वितीयक प्लॉट में विशिष्ट श्रेणियों को उनके प्रतिशत मानों की परवाह किए बिना समूहित करना चाहते हैं, तो कस्टम विभाजन का उपयोग करें। उदाहरण के तौर पर, एक बिक्री रिपोर्ट Online और Events को साथ में दिखा सकती है ताकि पाठक इन दो चैनलों की तुलना कर सकें, भले ही वे कुल बिक्री के 35% और 10% के हों।

Set [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) को [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) पर सेट करें और बिंदुओं को [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) के माध्यम से चुनें। संग्रह की [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) मेथड श्रृंखला में शून्य-आधारित सूचकांक या डेटा पॉइंट ऑब्जेक्ट स्वीकार करती है। इस उदाहरण में, सूचकांक 1 Online को चुनता है, और सूचकांक 3 पर बिंदु Events को चुनता है। Partners को भी अस्थायी रूप से जोड़ा जाता है, फिर [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) का उपयोग करके बाहर किया जाता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # डिफ़ॉल्ट डेटा को चैनल के अनुसार बिक्री डेटा से बदलें।
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # शून्य-आधारित सूचकांक द्वारा Online और डेटा पॉइंट ऑब्जेक्ट द्वारा Events चुनें।
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # स्रोत डेटा को हटाए बिना चयन से Partners को बाहर करें।
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) और Events (10) द्वितीयक प्लॉट में अलग-अलग स्लाइस के रूप में दिखाई देते हैं। प्राथमिक प्लॉट में, उन्हें 45 मान के साथ एक संयुक्त स्लाइस के रूप में दर्शाया जाता है, साथ ही Retail (40) और Partners (15) भी। कस्टम चयन से Partners को हटाने से वह प्राथमिक प्लॉट में रहता है; यह श्रेणी या उसका मान चार्ट के स्रोत डेटा से नहीं हटाता।

निम्न छवि PowerPoint में सहेजी गई प्रस्तुति को दिखाती है:
![द्वितीयक प्लॉट में Online और Events के साथ Pie of Pie चार्ट तथा प्राथमिक प्लॉट में उनका संयुक्त मान 45](pie_of_pie_custom.png)

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for Python via .NET पाई चार्ट स्लाइस को स्वचालित रूप से विभिन्न रंगों से असाइन कर सकता है। निम्न उदाहरण केंद्रित शीर्षक के साथ एक पाई चार्ट बनाता है और डिफ़ॉल्ट डेटा को तीन त्रैमासिक श्रेणियों और उनके मानों से बदलता है। [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) प्रॉपर्टी मान 20, 50, और 30 को लेबल के रूप में दिखाती है, जबकि [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) प्रत्येक स्लाइस के लिए अलग रंग सक्षम करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # केंद्रित चार्ट शीर्षक जोड़ें।
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # पहले कार्यपत्रक का उपयोग करके डिफ़ॉल्ट डेटा को बदलें।
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # मान दिखाएँ और स्लाइस को विभिन्न रंग सौंपें।
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Pie of Pie और Bar of Pie विविधताओं का समर्थन किया जाता है?**

हाँ, लाइब्रेरी [समर्थन](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) पाई चार्ट के लिए द्वितीयक प्लॉट का समर्थन करती है, जिसमें Pie of Pie और Bar of Pie प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप [चार्ट स्वयं को एक छवि के रूप में निर्यात करें](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (जैसे PNG) पूरी प्रस्तुति को निर्यात किए बिना कर सकते हैं।
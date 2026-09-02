---
title: Python में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/python-net/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रेणी रंग
- श्रृंखला नाम
- डेटा बिंदु
- श्रृंखला गैप
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक कोशिकाओं, स्वरूपण, ओवरलैप, गैप चौड़ाई, और नकारात्मक मानों का प्रबंधन कैसे करें, सीखें।"
---
## **Overview**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/) एक या अधिक वर्कबुक सेल्स की ओर संकेत करता है। [ChartCategory](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartcategory/) ऑब्जेक्ट्स उन लेबल या समूहित मानों को प्रदान करते हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, कॉलम 0 को श्रेणी नामों के लिए, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग करती है। वर्कशीट, पंक्ति और कॉलम इंडेक्स जो [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) को पास किए जाते हैं, शून्य-आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाने पर उपयोगी है, लेकिन यह मान लेना सही नहीं है कि हर मौजूदा चार्ट इसे उपयोग करता है। लोड किए गए प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों, और डेटा बिंदुओं द्वारा संदर्भित सेल्स की जांच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला-स्तर की सेटिंग्स, जैसे [ChartSeries.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/format/), एक ही श्रृंखला के सभी बिंदुओं की डिफ़ॉल्ट उपस्थिति प्रदान करती हैं।
- डेटा-बिंदु सेटिंग्स, जैसे [ChartDataPoint.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/format/), एक बिंदु के लिए श्रृंखला की उपस्थिति को ओवरराइड करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.parent_series_group](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/parent_series_group/) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया गया है, तो चार्ट स्टाइल और थीम स्वचालित उपस्थिति निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद होती है, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set the Chart Series Overlap**

[ChartSeries.overlap](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/overlap/) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी प्रतिशत तक ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का रीड‑ओनली प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/overlap/) सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

नीचे दिया गया उदाहरण पहले श्रृंखला वाली समूह के लिए ओवरलैप सेट करता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान रखता है।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The series overlap](series_overlap.png)

## **Change the Series Fill Color**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने हेतु [ChartSeries.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/format/) का उपयोग करें। यदि किसी बिंदु का स्पष्ट फ़िल पहले से परिभाषित है, तो उसका [ChartDataPoint.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

नीचे दिया गया उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The color of the series](series_color.png)

## **Change the Series Name**

एक श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और आमतौर पर लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित है और पहली श्रृंखला का नाम रखता है। नीचे के उदाहरण में नामांकित कॉन्स्टेंट्स इस संरचना को स्पष्ट रूप से दर्शाते हैं:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

आप [ChartSeries.name](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशेष पंक्ति या कॉलम को मानने से बचता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The series name](series_name.png)

## **Get the Automatic Series Fill Color**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) श्रृंखला इंडेक्स और चार्ट स्टाइल से गणना किया गया रंग लौटाता है। यह वह रंग है जो श्रृंखला फ़िल स्पष्ट रूप से परिभाषित न होने पर उपयोग किया जाता है। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

नीचे दिया गया उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

डिफ़ॉल्ट चार्ट स्टाइल के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट स्टाइल और थीम पर निर्भर करते हैं।

## **Set Invert Fill Color for a Chart Series**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इन्भर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) के द्वारा असाइन करें। वर्कबुक में नकारात्मक संख्याएँ अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

नीचे दिया गया उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला में बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The inverted solid fill color](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इन्भर्ज़न को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) से सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इन्भर्ज़न अक्षम है और केवल चयनित बिंदु के लिए सक्षम है। प्रभाव दिखाने के लिए बिंदु को नकारात्मक मान भी असाइन किया गया है:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Clear a Specific Data Point Value**

एक बिंदु को खाली करने के लिए, अन्य बिंदुओं को हटाए बिना, उसके बैकिंग वर्कबुक सेल को `None` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [ChartDataPoint.value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/value/) के माध्यम से उपलब्ध होता है। डेटा बिंदु वही श्रेणी स्थिति पर रहता है, लेकिन चार्ट उसकी मान को खाली मानता है, जैसा कि चार्ट की खाली‑मान सेटिंग्स में निर्धारित है।

नीचे दिया गया उदाहरण पहली श्रृंखला के केवल दूसरे बिंदु को साफ़ करता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट में आकार का सेल भी होता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) न कॉल करें, क्योंकि यह मेथड संग्रह से सभी डेटा बिंदुओं को हटा देता है।

## **Set the Series Gap Width**

गैप चौड़ाई बार या कॉलम क्लस्टर के बीच की जगह को दर्शाती है, जो बार या कॉलम चौड़ाई के प्रतिशत के रूप में व्यक्त की जाती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एक श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

नीचे दिया गया उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रेजेंटेशन को सहेजता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The gap width](gap_width.png)

## **FAQ**

**Which chart types support data series?**

[ChartType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) एनेमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स समान नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियाँ और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार जोड़ा जाता है। ऐसी विधि चुनें जो श्रृंखला प्रकार से मेल खाती हो। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होती हैं।

**What is a chart series group?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तरीय प्लॉटिंग सेटिंग्स साझा करती हैं। संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला से पहुँचा गया समूह सभी श्रृंखलाओं को आवश्यक रूप से नहीं बदलता।

**Does a newly created chart contain default data?**

हाँ। डिफ़ॉल्ट रूप से, [ShapeCollection.add_chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_chart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी बिना डिफ़ॉल्ट डेटा के चार्ट बना सकता है।

**How are chart objects connected to workbook cells?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के अंतर्गत प्लॉट हो।

**How do I clear one point instead of the whole series?**

प्रासंगिक मान सेल को `None` सेट करें ताकि बिंदु अपनी श्रेणी स्थिति को एक खाली बिंदु के रूप में बनाए रखे। जब आप किसी श्रृंखला के सभी बिंदुओं को हटाना चाहते हों, तभी [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) उपयोग करें। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**How are empty points displayed?**

परिणाम चार्ट प्रकार और [Chart.display_blanks_as](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/display_blanks_as/) पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। वह सेटिंग चुनें जो आपके प्रेजेंटेशन में लापता डेटा के अर्थ से मेल खाती हो।

**How are negative values formatted?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) सक्षम करें और [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) सेट करें। आप किसी व्यक्तिगत बिंदु के लिए इसे [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) से ओवरराइड कर सकते हैं। ये प्रॉपर्टीज़ फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**Which formatting wins when both a series and a point are formatted?**

स्पष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट स्टाइल और थीम का उपयोग जारी रखते हैं। समूह प्रॉपर्टी जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर की फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**Is there a limit to how many series a chart can contain?**

Aspose.Slides कोई अलग स्थायी श्रृंखला‑गिनती सीमा नहीं लागू करता। व्यावहारिक रूप से, प्रेजेंटेशन फ़ाइल प्रतिबंध, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**What should I change when columns are too close together or too far apart?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। मान बढ़ाकर क्लस्टर के बीच की जगह को विस्तृत करें, या मान घटाकर क्लस्टर को एक‑दूसरे के करीब लाएँ।
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
description: "Python के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदु, वर्कबुक सेल्स, फॉर्मेटिंग, ओवरलैप, गैप-विथ और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉटेड मानों को वर्कबुक सेल्स में या सीधे संख्यात्मक लिटरल के रूप में संग्रहीत कर सकता है। एक [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) उस सेट में एक बिंदु दर्शाता है। [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) ऑब्जेक्ट्स वह लेबल या समूहित मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट्स में, श्रृंखला नाम, श्रेणियाँ, और बिंदु मान चार्ट वर्कबुक से [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) ऑब्जेक्ट्स का उपयोग करते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को श्रेणी नामों के लिए, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) को पास किए गए कार्यपत्र, पंक्ति, और स्तंभ सूचकांक शून्य‑आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाने पर उपयोगी है, लेकिन यह मानकर न चलें कि हर मौजूदा चार्ट इसका उपयोग करता है। एक लोडेड प्रेज़ेंटेशन में, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) से संबंधित हैं। समूह तक पहुंचने के लिए [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) का उपयोग करें जब आपको ओवरलैप या गैप‑विथ जैसी विकल्प सेट करने हों।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया जाता, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करते हैं। जब दोनों, श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद होते हैं, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

क्लस्टर्ड सिलेंडर चार्ट के लिए देखें कि कैसे [changing the 3D series type or bar shape](/slides/hi/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape) पहले श्रृंखला को प्रभावित करता है।

## **संख्यात्मक लिटरल का उपयोग करके श्रृंखला मान सेट करें**

जब श्रृंखला मान एप्लिकेशन डेटा या गणना से आते हैं और कार्यपत्र सेल संदर्भों की आवश्यकता नहीं होती, तो संख्यात्मक लिटरल का उपयोग करें। प्रत्येक बिंदु के [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) को असाइन करने से पहले [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) को [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) पर सेट करें और फिर [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) का प्रयोग करें।

कलेक्शन सेटिंग उस श्रृंखला में सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु का [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) चयनित प्रकार को दर्शाता है; इसे कलेक्शन सेटिंग के माध्यम से बदलें। `WORKSHEET` के साथ, संदर्भित सेल तक पहुंचने के लिए [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) उपयोग करें। `DOUBLE_LITERALS` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए `as_literal_double` प्रयोग करें।

निम्न उदाहरण एक कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट श्रृंखला और श्रेणियां होती हैं, फिर पहले श्रृंखला के मौजूदा बिंदुओं को क्रमशः 10, 20 आदि गणना किए गए मान असाइन करता है। यह प्रस्तुति को सहेजता है, फिर उसे पुनः खोलता है और संग्रहीत मानों को प्रिंट करता है।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

बिंदु मान स्रोत प्रकार [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) से अलग है, जो चार्ट के अंतर्निहित या बाह्य वर्कबुक कॉन्फ़िगरेशन की पहचान करता है। संख्यात्मक लिटरल का उपयोग करना स्वयं में एम्बेडेड वर्कबुक को हटा नहीं देता। इस उदाहरण में, वर्कबुक श्रेणी लेबल, श्रृंखला नाम, और अन्य श्रृंखलाओं के लिए उपलब्ध रहता है। वर्कबुक प्रबंधन के लिए देखें [Chart Workbook](/slides/hi/python-net/chart-workbook/)।

स्कैटर और बबल चार्ट्स के लिए, [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) और [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) को सेट करके क्रमशः [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) और [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) के स्रोत चुने। बबल चार्ट्स के लिए [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) को [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) के लिए सेट करें। प्रत्येक प्रासंगिक स्रोत को `DOUBLE_LITERALS` पर सेट करें और फिर उस मूल्य के `as_literal_double` प्रॉपर्टी के माध्यम से संख्याएँ असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) दर्शाता है कि 2D चार्ट में बार या कॉलम कितने प्रतिशत ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने योग्य प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान शामिल करता है।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The series overlap](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) प्रयोग करें। यदि किसी बिंदु का फ़िल स्पष्ट रूप से सेट है, तो उसका [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहले श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के डिफ़ॉल्ट वर्कबुक में, सेल B1 (पंक्ति 0, स्तम्भ 1) पहले श्रृंखला का नाम रखता है। नीचे दिए गए उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति या स्तम्भ को मानने से बचता है:

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

### **कई सेल्स से नाम वाला श्रृंखला बनाएं**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक सेल्स में संग्रहीत हों, तो मिश्रित श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप `Product A` (B1) को `2026` (C1) के साथ मिलाकर एकल श्रृंखला नाम बना सकते हैं, जबकि दोनों भाग अपने स्रोत सेल्स से जुड़ें रहें।

[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) का उपयोग करके नाम रेंज प्राप्त करें, फिर उसे [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) में पास करें। `skip_hidden_cells` तर्क तय करता है कि छिपे हुए सेल शामिल हों या नहीं: `True` उन्हें बाहर करता है, `False` उन्हें शामिल करता है। इस उदाहरण में सभी सेल्स को शामिल करने के लिए `False` उपयोग किया गया है।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें एक श्रृंखला और दो डेटा पॉइंट्स हैं। सेल B1:C1 केवल श्रृंखला नाम प्रदान करती हैं; A2:A3 श्रेणी लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # ये दो सेल्स श्रृंखला नाम प्रदान करती हैं।
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # अलग-अलग सेल्स श्रेणियों और संख्यात्मक डेटा पॉइंट्स प्रदान करती हैं।
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

परिणामी श्रृंखला नाम `Product A 2026` है, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों स्तम्भों के लिए एक ही प्रविष्टि के रूप में दिखाता है। नीचे की छवि सहेजी गई प्रस्तुति से रेंडर की गई है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) श्रृंखला अनुक्रम और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग में आता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। यह मेथड गणना किया हुआ रंग पढ़ता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑वैल्यू रंग को [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शनी रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। कार्यपत्र पंक्ति 0 में श्रृंखला नाम, स्तम्भ 0 में श्रेणी नाम, और स्तम्भ 1 में मान होते हैं:

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

आप एक बिंदु के लिए इनवर्शन को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) के द्वारा सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इनवर्शन अक्षम है और केवल चयनित बिंदु के लिए सक्षम किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव स्पष्ट दिखे:

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

## **किसी विशिष्ट डेटा पॉइंट मान को साफ़ करें**

एक बिंदु को खाली करने के लिए, उसका बैकिंग वर्कबुक सेल `None` सेट करें, जबकि अन्य बिंदुओं को न हटाएँ। कॉलम चार्ट में, प्लॉटेड मान [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) के माध्यम से उपलब्ध होता है। डेटा पॉइंट उसी श्रेणी स्थिति पर बना रहता है, लेकिन चार्ट उसे खाली मान के रूप में मानता है।

निम्न उदाहरण पहले श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट में आकार सेल भी प्रयोग होता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) न बुलाएँ, क्योंकि यह मेथड सभी डेटा पॉइंट्स को हटाता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छुपे हुए सेल्स जिनमें मान होते हैं, वे खाली सेल्स से अलग होते हैं। छुपी पंक्तियों और स्तम्भों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा को दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान को दर्शाता है। सेल को खाली करने के लिए [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) को `None` सेट करें। संख्यात्मक शून्य शून्य ही रहता है, चाहे खाली‑सेल सेटिंग क्या भी हो।

खाली सेल्स को कैसे प्रदर्शित किया जाए, यह चुनने के लिए [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली बिंदुओं को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरें।

निम्न स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ उसी चार्ट को सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) कार्यपत्र 0, स्तम्भ 0 को श्रेणी लेबल के लिए, और स्तम्भ 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बरकरार रखें।
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले निर्धारित मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, वांछित मोड असाइन करें और प्रस्तुति को एक बार सहेजें।

नीचे तुलनात्मक रूप से तीन फ़ाइलों में एक ही डेटा दिखाया गया है। दिन 3 सभी मामलों में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखायी देने वाला प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड की आसानी से तुलना करता है। बार और कॉलम चार्ट में कोई लाइन नहीं होने के कारण `SPAN` उपर्युक्त कनेक्टिंग सेगमेंट नहीं बनाता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, मार्कर‑केवल वाले स्कैटर चार्ट में भी कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन विशिष्ट परिणामों की अपेक्षा न रखें; अपने उपयोग के प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप‑विथ सेट करें**

गैप‑विथ पड़ोसी बार या कॉलम क्लस्टर के बीच की जगह है, जो बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त की जाती है। यह ओवरलैप की तरह पैरेंट श्रृंखला समूह से जुड़ी होती है, न कि एकल श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें घना करता है।

निम्न उदाहरण गैप‑विथ बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

## **श्रृंखला रेखाएं दिखाएँ या छुपाएँ**

श्रृंखला रेखाएं चार्ट के संबंधित भागों को दृश्य रूप से जोड़ती हैं। समर्थित स्टैक्ड बार और OfPie चार्ट्स में उन्हें दिखाने या छुपाने के लिए [ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/) उपयोग करें। दो‑आयामी स्टैक्ड बार और कॉलम चार्ट्स में, वे श्रेणियों के पार संबंधित स्टैक सीमाओं को जोड़ती हैं। Pie of Pie और Bar of Pie चार्ट्स में, वे मुख्य प्लॉट को द्वितीयक प्लॉट से जोड़ती हैं। यह सेटिंग अन्य चार्ट प्रकारों के लिए सामान्य कनेक्टर नहीं है।

समूह तक पहुंचने के लिए [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) का उपयोग करें। सेटिंग समूह में प्रत्येक श्रृंखला पर लागू होती है। [ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/) केवल‑पढ़ने योग्य है और पैरेंट समूह की सेटिंग को दर्शाता है; समूह प्रॉपर्टी बदलें ताकि यह अपडेट हो।

निम्न उदाहरण एक [ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा है। यह वही चार्ट दो प्रस्तुतियों के साथ सहेजता है: एक में श्रृंखला रेखाएं सक्षम और दूसरे में अक्षम।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| Series lines enabled | Series lines disabled |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| The two lines connect the main pie to the secondary pie. | Both pies remain visible, but the connecting lines are hidden. |

श्रृंखला रेखाएं डेटा लेबल लीडर लाइनों, ग्रिड लाइनों, या लाइन चार्ट की रेखाओं से अलग होती हैं; यह सेटिंग उन तत्वों को नियंत्रित नहीं करती।

## **FAQ**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) एन्‍यूमरेशन द्वारा प्रदर्शित सभी चार्ट प्रकार डेटा उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मूल्य संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट्स में श्रेणियां और मान होते हैं, स्कैटर चार्ट्स में X और Y मान, और बबल चार्ट्स में बबल आकार जोड़ते हैं। डेटा‑पॉइंट निर्माण विधि को श्रृंखला प्रकार के अनुसार चुनें। ओवरलैप और गैप‑विथ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) संगत श्रृंखलाओं को समाहित करता है जो समूह‑स्तर के प्लॉटिंग सेटिंग्स साझा करती हैं। संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को नहीं बदलता।

**क्या नवीन निर्मित चार्ट में डिफ़ॉल्ट डेटा होता है?**

हाँ। डिफ़ॉल्ट रूप से, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट होते हैं। जब आप कस्टम डेटा बनाते हैं, तो सुनिश्चित करें कि श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों का संरेखण ठीक हो, ताकि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**एक पूरे श्रृंखला की बजाय केवल एक बिंदु को कैसे साफ़ करूँ?**

संबंधित मान सेल को `None` सेट करें ताकि बिंदु की श्रेणी स्थिति खाली बिंदु के रूप में बनी रहे। केवल तब [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) उपयोग करें जब आप उस श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को इस तरह अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) पर निर्भर करता है। समर्थित चार्ट खाली मानों को गैप, शून्य मान, या निकटवर्तियों को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपलब्ध डेटा के अर्थ के अनुरूप सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों का फ़ॉर्मेटिंग कैसे किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) को सक्षम करें और [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) सेट करें। आप प्रत्येक बिंदु के लिए इस व्यवहार को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) से ओवरराइड कर सकते हैं। ये प्रॉपर्टीज़ केवल फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब दोनों, श्रृंखला और बिंदु फ़ॉर्मेटेड हों, तो कौन जीतता है?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह प्रॉपर्टीज़ जैसे ओवरलैप और गैप‑विथ लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर की फ़ॉर्मेटिंग ओवरराइड नहीं हैं।

**क्या चार्ट में श्रृंखला की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग स्थायी श्रृंखला‑गिनती सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल की प्रतिबंध, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती है।

**जब कॉलम बहुत करीब या बहुत दूर हों, तो क्या बदलें?**

उपयुक्त पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। मान बढ़ाएँ ताकि क्लस्टरों के बीच स्थान बढ़े, या घटाएँ ताकि क्लस्टर एकत्रित हों।
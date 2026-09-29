---
title: Python में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/python-net/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- वर्ग रंग
- श्रृंखला नाम
- डेटा बिंदु
- श्रृंखला अंतराल
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Python के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक कोशिकाओं, स्वरूपण, ओवरलैप, गैप चौड़ाई और नकारात्मक मूल्यों का प्रबंधन कैसे करें, सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहित करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और उस श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं से जुड़ा होता है। [ChartCategory](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartcategory/) वस्तुएँ लेबल या समूह मान प्रदान करती हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, वर्ग, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatacell/) वस्तुओं से जुड़ते हैं न कि केवल प्रदर्शित टेक्स्ट के रूप में संग्रहित होते हैं।

एक सामान्य वर्ग चार्ट के लिए, डिफॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को वर्ग नामों के लिए, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) को पास किए जाने वाले वर्कशीट, पंक्ति, और स्तंभ अनुक्रमांक शून्य‑आधारित होते हैं। यह लेआउट डिफॉल्ट डेटा वाले चार्ट बनाने पर उपयोगी है, लेकिन यह मानना गलत होगा कि हर मौजूदा चार्ट इसे उपयोग करता है। लोड किए गए प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, वर्ग, और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं का निरीक्षण करें।

चार्ट सेटिंग्स के तीन अलग‑अलग स्तर होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे [ChartSeries.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/format/), एक श्रृंखला के सभी बिंदुओं के लिए डिफॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [ChartDataPoint.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/format/), एक बिंदु के लिए श्रृंखला स्वरूप को ओवरराइड करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप विथ जैसी विकल्प सेट करने की आवश्यकता हो तो [ChartSeries.parent_series_group](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/parent_series_group/) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं है, तो चार्ट शैली और थीम स्वचालित रूप से स्वरूप निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेट मौजूद होते हैं, तो बिंदु फ़ॉर्मेट उस बिंदु के लिए प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.overlap](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/overlap/) बताता है कि 2D चार्ट में बार या कॉलम कितने प्रतिशत ओवरलैप करते हैं, -100 से 100 % तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रक्षेपण है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/overlap/) सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहली श्रृंखला वाले समूह के लिए ओवरलैप सेट करता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # नया चार्ट नमूना श्रृंखलाएँ, वर्ग, और मान रखता है।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The series overlap](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरा श्रृंखला का डिफॉल्ट फ़िल सेट करने के लिए [ChartSeries.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/format/) का प्रयोग करें। यदि किसी बिंदु का फ़िल पहले से स्पष्ट रूप से सेट है, तो उसका [ChartDataPoint.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहली श्रृंखला को ठोस नीला फ़िल लागू करता है:

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

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहित होता है और सामान्यतः लेजेंड में दिखता है। क्लस्टर्ड कॉलम चार्ट के लिए डिफॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तम्भ 1 पर है और पहली श्रृंखला का नाम रखता है। नीचे के उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [ChartSeries.name](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति या स्तम्भ को मानने से बचाता है:

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

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) श्रृंखला क्रमांक और चार्ट शैली से गणना किए गए रंग को लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं होता। इस मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

डिफॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट श्रृंखला के लिए उल्टा फ़िल रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) नकारात्मक मानों को अलग फ़िल के साथ दिखा सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, उलटाव को सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) द्वारा असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तम्भ 0 में वर्ग नाम, और स्तम्भ 1 में मान होते हैं:

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

आप [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) के द्वारा एक बिंदु के लिए उलटाव सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए उलटाव अक्षम है और केवल चयनित बिंदु के लिए सक्षम किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

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

## **विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली करने के लिए, उसके बैकिंग वर्कबुक सेल को `None` सेट करें, जबकि अन्य बिंदुओं को रख दें। कॉलम चार्ट के लिए, प्लॉटेड मान [ChartDataPoint.value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/value/) के द्वारा उपलब्ध होता है। डेटा बिंदु वही वर्ग स्थिति रखता है, लेकिन चार्ट उसके मान को खाली मानता है, जैसा कि चार्ट की खाली‑मान सेटिंग में निर्धारित है।

निम्न उदाहरण पहली श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट में आकार की भी कोशिका होती है। केवल उस सेल को साफ़ करें जो वह मान दर्शाता है जिसे आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) न बुलाएँ, क्योंकि यह मेथड सभी डेटा बिंदुओं को संग्रह से हटा देता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाओं में मान होते हैं, यह केस खाली कोशिकाओं से अलग है। छिपी हुई वर्कशीट पंक्तियों और स्तम्भों से डेटा शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा दर्शाती है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। [ChartDataCell.value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatacell/value/) को `None` सेट करके कोई सेल खाली बनाया जा सकता है। संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग से निरपेक्ष शून्य बना रहता है।

[Chart.display_blanks_as](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/display_blanks_as/) का प्रयोग करके तय करें कि चार्ट खाली कोशिकाओं को कैसे प्रदर्शित करता है। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्वनिर्भर उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला, दिन 3 के लिए मान साफ़ किया जाता है, और प्रत्येक मोड के साथ वही चार्ट सहेजा जाता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/) वर्कशीट 0, स्तम्भ 0 को वर्ग लेबल के लिए, और स्तम्भ 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    # Day 3 को वास्तव में खाली छोड़ें, जबकि उसका वर्ग और डेटा बिंदु बरकरार रखें।
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रेजेंटेशन को एक बार सहेजें, सभी मोडों पर लूप न चलाएँ।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 प्रत्येक केस में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखाई देने वाला प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट तीनों मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में मिसिंग वर्ग के बीच जोड़ने के लिये कोई लाइन नहीं होती, इसलिए `SPAN` ऊपर दिखाए गये कनेक्टिंग सेगमेंट को नहीं बना सकता; एक मिसिंग कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। स्कैटर चार्ट में केवल मार्कर होने पर भी कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन स्पष्ट परिणामों की उम्मीद न रखें; अपने उपयोग किए गए प्रकार के लिए आउटपुट जांचें।

## **श्रृंखला गैप विथ सेट करें**

गैप विथ आसन्न बार या कॉलम क्लस्टरों के बीच की दूरी है, जो बार या कॉलम चौड़ाई के प्रतिशत में व्यक्त होती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एकल श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। बड़ा मान क्लस्टरों के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घना करता है।

निम्न उदाहरण गैप विथ बदलता है और केवल अंतिम प्रेजेंटेशन सहेजता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) एन्‍युमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का प्रयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिये, श्रेणी चार्ट वर्ग और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान, तथा बबल चार्ट बबल आकार जोड़ता है। डेटा‑बिंदु निर्माण मेथड को श्रृंखला प्रकार के अनुसार चुनें। ओवरलैप और गैप विथ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होती हैं।

**चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/) संगत श्रृंखलाओं को रखता है जो समूह‑स्तर प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह बदलना आवश्यक नहीं कि चार्ट की सभी श्रृंखलाएँ बदलें।

**क्या नई बनाई गई चार्ट में डिफॉल्ट डेटा होता है?**

हां। डिफॉल्ट रूप से, [ShapeCollection.add_chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_chart/) नमूना श्रृंखलाएँ, वर्ग, और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और वर्ग संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, वर्ग लेबल, और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/) की कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका बदलने से संबंधित चार्ट एलिमेंट अपडेट हो जाता है। कस्टम डेटा बनाते समय, वर्ग पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित वर्ग के नीचे प्लॉट हो।

**सभी श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान कोशिका को `None` सेट करें जिससे बिंदु की वर्ग स्थिति बनी रहे, लेकिन वह एक खाली बिंदु बन जाए। केवल तब [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) का उपयोग करें जब आप पूरी श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप वर्ग भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान वर्ग संग्रह के साथ संरेखित रहें।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [Chart.display_blanks_as](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/display_blanks_as/) पर निर्भर करता है। समर्थित चार्ट खाली स्थान को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रेजेंटेशन में अनुपस्थित डेटा के अर्थ के अनुसार सेटिंग चुनें। पूरी उदाहरण और दृश्य तुलना के लिए देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे फ़ॉर्मेट किया जाता है?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) को सक्षम करें और [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) सेट करें। आप व्यक्तिगत बिंदु के लिए व्यवहार को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) से ओवरराइड कर सकते हैं। ये गुण फ़ॉर्मेटिंग को प्रभावित करते हैं, संग्रहीत संख्यात्मक मानों को नहीं।

**जब एक श्रृंखला और एक बिंदु दोनों फ़ॉर्मेट किए हों तो कौन जीतता है?**

स्पष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला स्वरूप या, यदि श्रृंखला स्वरूप परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह गुण जैसे ओवरलैप और गैप विथ लेआउट को नियंत्रित करते हैं और बिंदु‑स्तर फ़ॉर्मेटिंग को ओवरराइड नहीं करते।

**एक चार्ट में अधिकतम कितनी श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides कोई अलग‑अलग स्थिर श्रृंखला‑संख्या सीमा नहीं लगाता। व्यावहारिक रूप से, प्रेजेंटेशन फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। मान बढ़ाने से क्लस्टरों के बीच की दूरी बढ़ेगी, और मान घटाने से क्लस्टर एक‑दूसरे के करीब आएँगे।
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
- श्रृंखला अंतराल
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python के साथ प्रस्तुतियों में चार्ट श्रृंखलाएँ, डेटा बिंदु, वर्कबुक कोशिकाएँ, फ़ॉर्मैटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मान कैसे प्रबंधित करें, यह जानें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/) संबंधित मूल्यों के एक सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं से संबंधित होता है। [ChartCategory](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartcategory/) वस्तुएँ लेबल या समूह मान प्रदान करती हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatacell/) वस्तुओं से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक में श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए स्तंभ 0, और शेष कोशिकाएँ श्रृंखला मानों के लिए उपयोग की जाती हैं। वर्कशीट, पंक्ति, और स्तंभ अनुक्रमांक जो [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) को पास किए जाते हैं, शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानना नहीं चाहिए कि हर मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रेज़ेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ और डेटा पॉइंट्स द्वारा संदर्भित कोशिकाओं की जांच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- सीरीज़‑स्तर की सेटिंग्स, जैसे [ChartSeries.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/format/), एक श्रृंखला में सभी बिंदुओं के लिए डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [ChartDataPoint.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/format/), एक बिंदु के लिए श्रृंखला के स्वरूप को ओवरराइड करती हैं।
- ग्रुप सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.parent_series_group](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/parent_series_group/) के माध्यम से समूह तक पहुंचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित स्वरूप निर्धारित करती हैं। जब दोनों, श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![चार्ट-सीरीज़-पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट सीरीज़ ओवरलैप सेट करना**

[ChartSeries.overlap](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/overlap/) 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को -100 से 100 तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल-पढ़ने‑के‑लिए प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/overlap/) सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबद्ध श्रृंखला समूहों को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान सम्मिलित करता है।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![सीरीज़ ओवरलैप](series_overlap.png)

## **सीरीज़ फ़िल रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने हेतु [ChartSeries.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/format/) का उपयोग करें। यदि किसी बिंदु की स्पष्ट फ़िल पहले से परिभाषित है, तो उसका [ChartDataPoint.format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्नलिखित उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

![सीरीज़ रंग](series_color.png)

## **सीरीज़ नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाई गई डिफ़ॉल्ट वर्कबुक में, कोशिका B1 पंक्ति 0, स्तंभ 1 पर स्थित होती है और पहली श्रृंखला का नाम रखती है। निम्नलिखित उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [ChartSeries.name](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/name/) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह दृष्टिकोण यह मानने से बचाता है कि मौजूदा चार्ट में कोई विशेष पंक्ति या स्तंभ है:

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

![सीरीज़ नाम](series_name.png)

## **स्वचालित सीरीज़ फ़िल रंग प्राप्त करें**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) क्रमांक और चार्ट शैली के आधार पर गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। यह मेथड गणना किया गया रंग पढ़ता है; यह नया फ़िल सेट नहीं करता।

निम्नलिखित उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

## **चार्ट सीरीज़ के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) नकारात्मक मानों को अलग फ़िल के साथ दिखा सकता है। सामान्य श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) द्वारा असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम होता है, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान:

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

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इनवर्शन को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) द्वारा सक्षम कर सकते हैं। निम्न उदाहरण में श्रृंखला के लिए इनवर्शन अक्षम किया गया है और केवल चयनित बिंदु के लिए सक्रिय है। प्रभाव दिखाने हेतु बिंदु को नकारात्मक मान भी असाइन किया गया है:

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

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक बिंदु को खाली करने के लिए, उसके बैकिंग वर्कबुक सेल को `None` सेट करें, अन्य बिंदुओं को न हटाएँ। कॉलम चार्ट में, प्लॉट किया गया मान [ChartDataPoint.value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/value/) के माध्यम से उपलब्ध होता है। डेटा पॉइंट उसी श्रेणी स्थिति में रहता है, लेकिन चार्ट उसकी मान को खाली मानता है, जैसा कि चार्ट की खाली‑मान सेटिंग्स निर्धारित करती हैं।

निम्नलिखित उदाहरण पहली श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट में एक आकार कोशिका भी होती है। केवल उस कोशिका को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदु रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) न कॉल करें, क्योंकि यह मेथड संग्रह से सभी डेटा पॉइंट हटाता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

एक खाली वर्कबुक सेल गुम डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान को दर्शाता है। सेल को खाली करने के लिए [ChartDataCell.value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatacell/value/) को `None` सेट करें। शून्य मान सेटिंग से अप्रभावित रहता है।

[Chart.display_blanks_as](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/display_blanks_as/) का उपयोग करके निर्धारित करें कि चार्ट खाली कोशिकाओं को कैसे दिखाएगा। यह सेटिंग सम्पूर्ण चार्ट पर लागू होती है और खाली स्थानों को प्लॉट करने के तरीके को बदलती है, बिना खाली कोशिका को शून्य या इंटरपोलेटेड मान से भरें।

निम्नलिखित स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/) वर्कशीट 0, स्तंभ 0 को श्रेणी लेबल्स के लिए और स्तंभ 1 को मानों के लिए उपयोग करता है; पंक्ति 0 श्रृंखला नाम रखती है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    # Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बनाए रखें।
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

प्रत्येक आउटपुट फ़ाइल में सहेजने से पहले सेट किया गया मोड दर्ज होता है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, वांछित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, मोड पर इटरशन न करें।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 हर मामले में वर्कबुक में खाली है:

![एक ही डेटा वाले लाइन चार्ट: Gap दिन 3 पर लाइन को तोड़ता है, Zero लाइन को शून्य तक गिराता है, और Span दिन 2 को दिन 4 से जोड़ता है।](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट तीनों मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में कोई लाइन नहीं होती जो गुम श्रेणी को जोड़ सके, इसलिए `SPAN` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को उत्पन्न नहीं कर सकता; एक गुम कॉलम और शून्य‑ऊंचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन स्पष्ट परिणाम की उम्मीद न रखें; आप जिस प्रकार का उपयोग कर रहे हैं, उसके लिए आउटपुट जांचें।

## **सीरीज़ गैप चौड़ाई सेट करें**

गैप चौड़ाई क्रमबद्ध बार या कॉलम क्लस्टर के बीच की जगह है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि एकल श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

![गैप चौड़ाई](gap_width.png)

## **FAQ**

**कौन से चार्ट प्रकार डेटा सीरीज़ का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) enumeration द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियाँ और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार जोड़ता है। श्रृंखला प्रकार से मेल खाने वाली डेटा‑बिंदु निर्माण विधि का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट सीरीज़ ग्रुप क्या है?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हाँ। डिफ़ॉल्ट रूप से, [ShapeCollection.add_chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_chart/) नमूना श्रृंखला, श्रेणियाँ और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट वस्तुएँ वर्कबुक कोशिकाओं से कैसे जुड़ी हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/) की कोशिकाओं को संदर्भित करते हैं। किसी संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**कैसे एक बिंदु को पूरी श्रृंखला के बजाय साफ़ करें?**

बिंदु के मूल्य सेल को `None` सेट करें ताकि उसकी श्रेणी स्थिति बनी रहे और वह एक खाली बिंदु बन जाए। जब आप केवल सभी बिंदुओं को हटाना चाहते हैं, तब ही [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointcollection/clear/) का उपयोग करें। यदि आप श्रेणियों को भी हटाते हैं, तो प्रत्येक श्रृंखला को इस प्रकार अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे दिखाए जाते हैं?**

परिणाम चार्ट प्रकार और [Chart.display_blanks_as](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/display_blanks_as/) पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। वह सेटिंग चुनें जो आपके प्रेज़ेंटेशन में गुम डेटा के अर्थ से मेल खाती हो। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें **[खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)**।

**नकारात्मक मानों का फ़ॉर्मेट कैसे किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/invert_if_negative/) को सक्षम करें और [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) द्वारा नकारात्मक‑मान रंग सेट करें। आप व्यक्तिगत बिंदु के लिए व्यवहार को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) से ओवरराइड कर सकते हैं। ये गुण केवल फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मान को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेटेड हों, तो कौन जीतेगा?**

स्पष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप चौड़ाई जैसी समूह गुण लेआउट को नियंत्रित करते हैं और बिंदु‑स्तर की फ़ॉर्मेटिंग को ओवरराइड नहीं करते।

**क्या चार्ट में रखी जा सकने वाली श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑गिनती सीमा लागू नहीं करता। व्यवहार में, प्रेज़ेंटेशन फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट पठनीयता एक उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों, तो क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। मान को बढ़ाने से क्लस्टर के बीच की दूरी बढ़ती है, और घटाने से वे एक‑दूसरे के पास आते हैं।
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
description: "Python के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक कोशिकाओं, स्वरूपण, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों का प्रबंधन कैसे करें, सीखें।"
---
## **अवलोकन**

एक चार्ट अपनी प्लॉट की गई डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) संबंधित मानों का एक सेट दर्शाता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) एक या अधिक वर्कबुक सेल को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) वस्तुएँ उन लेबल या समूह मानों को प्रदान करती हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) वस्तुओं से जुड़ते हैं, न कि केवल प्रदर्शन टेक्स्ट के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तम्भ 0 को श्रेणी नामों के लिए, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) को पास किए गए वर्कशीट, पंक्ति, और स्तम्भ सूचकांक शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानना ठीक नहीं है कि हर मौजूदा चार्ट इसका उपयोग करता है। लोड किए गए प्रस्तुतीकरण के लिए, वर्कबुक मानों को बदलने से पहले श्रृंखलाओं, श्रेणियों, और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं की जांच करें।

चार्ट सेटिंग्स के तीन विभिन्न स्तर होते हैं:

- श्रृंखला-स्तर सेटिंग्स, जैसे [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), एक श्रृंखला में सभी बिंदुओं के लिए डिफ़ॉल्ट उपस्थिति प्रदान करती हैं।
- डेटा-बिंदु सेटिंग्स, जैसे [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), एक बिंदु के लिए श्रृंखला उपस्थिति को ओवरराइड करती हैं।
- समूह सेटिंग्स समान [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) में स्थित संगत श्रृंखलाओं पर लागू होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) के माध्यम से समूह तक पहुँचें।

जब स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं किया जाता, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद होते हैं, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![चार्ट-श्रृंखला-पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को -100 से 100 तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल पढ़ने योग्य प्रोजेक्शन है। [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) सेट करने से उस समूह की सभी संगत श्रृंखलाएँ अपडेट हो जाती हैं। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबद्ध श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को सम्मिलित करने वाले समूह के लिए ओवरलैप सेट करता है:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # नया चार्ट नमूना श्रृंखलाओं, श्रेणियों और मानों को शामिल करता है।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला भराव रंग बदलें**

एक पूरी श्रृंखला के लिए डिफ़ॉल्ट भराव सेट करने हेतु [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट भराव है, तो उसका [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला भराव को ओवरराइड करती है।

निम्न उदाहरण पहला श्रृंखला पर ठोस नीला भराव लागू करता है:

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

![श्रृंखला का रंग](series_color.png)

## **श्रृंखला नाम बदलें**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लीजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए निर्मित डिफ़ॉल्ट वर्कबुक में, कोशिका B1 पंक्ति 0, स्तम्भ 1 पर स्थित है और पहला श्रृंखला नाम रखती है। निम्न उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट रूप से परिभाषित करते हैं:

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

आप [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति या स्तम्भ को मानने से बचता है:

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

![श्रृंखला नाम](series_name.png)

### **कई कोशिकाओं से नाम वाली श्रृंखला बनाएँ**

एक संयोजित श्रृंखला नाम उपयोगी होता है जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक कोशिकाओं में संग्रहीत होते हैं। उदाहरण के लिए, आप `Product A` को B1 में और `2026` को C1 में रखकर दोनों को स्रोत कोशिकाओं से जुड़ा रखते हुए एकल श्रृंखला नाम बना सकते हैं।

[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) का उपयोग करके नाम रेंज प्राप्त करें, फिर उस संग्रह को [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) को पास करें। `skip_hidden_cells` तर्क यह नियंत्रित करता है कि छिपी कोशिकाएँ शामिल हों या नहीं: `True` उन्हें बाहर रखता है, जबकि `False` शामिल करता है। यह उदाहरण `False` का उपयोग करके नाम रेंज की प्रत्येक कोशिका को शामिल करता है।

निम्न उदाहरण एक प्रस्तुतीकरण बनाता है जिसमें एक श्रृंखला और दो डेटा बिंदु होते हैं। कोशिकाएँ B1:C1 केवल श्रृंखला नाम प्रदान करती हैं; A2:A3 श्रेणी लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

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

    # ये दो कोशिकाएँ श्रृंखला नाम प्रदान करती हैं।
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # अलग-अलग कोशिकाएँ श्रेणियां और संख्यात्मक डेटा बिंदु प्रदान करती हैं।
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

परिणामी श्रृंखला नाम `Product A 2026` है, दो कोशिका मानों के बीच एक स्पेस के साथ। लीजेंड इसे दोनों स्तम्भों के लिए एक प्रविष्टि के रूप में दिखाता है। नीचे की छवि सहेजे गए प्रस्तुतीकरण से रेंडर की गई है:

![उत्‍पन्न चार्ट में उत्तरी और दक्षिणी मानों तथा सम्मिलित श्रृंखला नाम Product A 2026 के साथ कॉलम चार्ट](composite_series_name.png)

## **स्वचालित श्रृंखला भराव रंग प्राप्त करें**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) श्रृंखला अनुक्रमांक और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग किया जाता है जब श्रृंखला भराव स्पष्ट रूप से परिभाषित नहीं किया गया हो। यह मेथड गणना किया गया रंग पढ़ता है; यह नया भराव निर्धारित नहीं करता।

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

## **एक चार्ट श्रृंखला के लिए उलटा भराव रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) नकारात्मक मानों को अलग भराव के साथ दर्शा सकता है। नियमित श्रृंखला भराव को ठोस सेट करें, उलटाव को सक्षम करें, और नकारात्मक मान रंग को [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तम्भ 0 में श्रेणी नाम, और स्तम्भ 1 में मान होते हैं:

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

![उलटा ठोस भराव रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए उलटाव को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) द्वारा सक्षम कर सकते हैं। निम्न उदाहरण में श्रृंखला के लिए उलटाव निष्क्रिय है और केवल चयनित बिंदु के लिए सक्रिय है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिख सके:

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

## **एक विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली करने के लिए, लेकिन अन्य बिंदुओं को न हटाने के लिए, उसकी बैकिंग वर्कबुक सेल को `None` सेट करें। कॉलम चार्ट के लिए, प्लॉटेड मान [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) के माध्यम से उपलब्ध होता है। डेटा बिंदु वही श्रेणी स्थिति में रहता है, लेकिन चार्ट उसकी मान को खाली के रूप में मानता है, जैसा कि चार्ट की खाली-मान सेटिंग्स में निर्धारित है।

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट एक आकार कोशिका भी उपयोग करता है। केवल उस कोशिका को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य बिंदुओं को रखना चाहते हैं तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) न कॉल करें, क्योंकि यह विधि संग्रह के सभी डेटा बिंदुओं को हटा देती है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाएँ जिनमें मान होते हैं, वे खाली कोशिकाओं से अलग केस होती हैं। छिपी हुई वर्कशीट पंक्तियों और स्तम्भों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक कोशिका लापता डेटा को दर्शाती है; `0` वाला कोशिका ज्ञात संख्यात्मक मान को दर्शाता है। [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) को `None` सेट करने से कोशिका खाली हो जाती है। संख्यात्मक शून्य खाली‑कोशिका सेटिंग से स्वतंत्र रूप से शून्य रहता है।

[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) का उपयोग करके तय करें कि चार्ट खाली कोशिकाओं को कैसे दिखाए। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैन्क को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक कोशिका को शून्य या अंतर्निहित मान से भरें।

निम्न स्व-निर्भर उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) वर्कशीट 0, स्तम्भ 0 को श्रेणी लेबल के लिए, और स्तम्भ 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    # Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु बरकरार रखें।
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले निर्धारित मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए वांछित मोड को असाइन करें और प्रस्तुतीकरण को एक बार सहेजें, बजाय मोड पर इटरेशन करने के।

नीचे तुलना दिखाती है कि सभी तीन फ़ाइलों में समान डेटा कैसे दिखता है। दिन 3 प्रत्येक केस में वर्कबुक में खाली है:

![लाइन चार्ट्स में समान डेटा: Gap दिन 3 पर रेखा को तोड़ता है, Zero रेखा को शून्य पर गिराता है, और Span दिन 2 को दिन 4 से जोड़ता है।](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में लापता श्रेणी के पार जोड़ने के लिए कोई रेखा नहीं होती, इसलिए `SPAN` ऊपर दिखाए गए जुड़ाव खंड को नहीं बना सकता; एक लापता कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकता है। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई जुड़ाव रेखा नहीं होती। सभी चार्ट प्रकारों के लिए तीन अलग-अलग परिणाम की उम्मीद न करें; आप जिस प्रकार का उपयोग कर रहे हैं, उसके लिए आउटपुट की जाँच करें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर के बीच की जगह का प्रतिशत दर्शाती है, जो बार या कॉलम की चौड़ाई का एक हिस्सा है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एकल श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। बड़ी मान क्लस्टरों के बीच अधिक जगह बनाता है; छोटी मान उन्हें अधिक घना बनाता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुतीकरण सहेजता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) एन्नुमरेशन द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियाँ और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार जोड़ता है। श्रृंखला प्रकार के अनुरूप डेटा‑बिंदु निर्माण विधि का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) संगत श्रृंखलाओं को सम्मिलित करता है जो समूह‑स्तर के प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुंचे गए समूह को बदलने से अनिवार्य रूप से चार्ट की सभी श्रृंखलाएँ नहीं बदलतीं।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हाँ। डिफ़ॉल्ट रूप से, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) नमूना श्रृंखलाएँ, श्रेणियाँ, और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) में कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**कैसे एक बिंदु को पूरी श्रृंखला के बजाय साफ़ करूँ?**

संबद्ध मान कोशिका को `None` सेट करें ताकि बिंदु की श्रेणी स्थिति खाली बिंदु के रूप में बनी रहे। केवल तब [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) का उपयोग करें जब आप उस श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाएँ अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदुओं को कैसे दिखाया जाता है?**

परिणाम चार्ट प्रकार और [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान, या बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रस्तुतीकरण में लापता डेटा के अर्थ के अनुसार सेटिंग चुनें। पूरा उदाहरण और दृश्य तुलना के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मान कैसे स्वरूपित होते हैं?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) को सक्षम करें और [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) सेट करें। आप व्यक्तिगत बिंदु के लिए व्यवहार को [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) से ओवरराइड कर सकते हैं। ये प्रॉपर्टी फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों स्वरूपित हों तो कौन सा स्वरूप जीतता है?**

स्पष्ट डेटा‑बिंदु स्वरूपण उस बिंदु के लिए प्राथमिकता लेता है। अन्य बिंदु स्पष्ट श्रृंखला स्वरूप या, जब श्रृंखला स्वरूप परिभाषित न हो, स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप चौड़ाई जैसी समूह प्रॉपर्टी लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के स्वरूपण ओवरराइड नहीं हैं।

**एक चार्ट में अधिकतम कितनी श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑संख्या सीमा नहीं लगाता। व्यवहार में, प्रस्तुतीकरण फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता एक उपयोगी सीमा तय करती हैं।

**जब कॉलम बहुत निकट या बहुत दूर हों तो क्या बदलूँ?**

उपयुक्त पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) सेट करें। मान बढ़ाने से क्लस्टरों के बीच स्थान widening होता है, जबकि घटाने से वे करीब आ जाते हैं।
---
title: Python में PowerPoint प्रस्तुति चार्ट बनाएं या अपडेट करें
linktitle: चार्ट बनाएं या अपडेट करें
type: docs
weight: 10
url: /hi/python-net/create-chart/
keywords:
- चार्ट जोड़ें
- चार्ट बनाएं
- चार्ट संपादित करें
- चार्ट बदलें
- चार्ट अपडेट करें
- स्कैटर चार्ट
- पाई चार्ट
- लाइन चार्ट
- ट्री मैप चार्ट
- स्टॉक चार्ट
- बॉक्स और व्हिस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगरी चार्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। Python में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via .NET का उपयोग करके चार्ट बनाने और अनुकूलित करने पर एक व्यापक गाइड प्रदान करता है। आप प्रोग्रामेटिक रूप से स्लाइड में चार्ट जोड़ना, डेटा के साथ उसे भरना, और विभिन्न फ़ॉर्मेटिंग विकल्प लागू करना सीखेंगे ताकि आपके विशिष्ट डिज़ाइन आवश्यकताओं के अनुरूप हो सके। लेख के दौरान, विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को इनिशियलाइज़ करने से लेकर श्रृंखलाएँ, अक्ष, और लीजेंड कॉन्फ़िगर करने तक। इस गाइड का पालन करके, आप अपने Python अनुप्रयोगों में डायनेमिक चार्ट जेनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवेन प्रस्तुतियों की निर्माण प्रक्रिया सुगम हो जाएगी।

## **चार्ट बनाएं**

चार्ट लोगों को डेटा को जल्दी से विज़ुअलाइज़ करने और ऐसी अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं हो सकती।

**चार्ट क्यों बनाएं?**

* प्रस्तुति की एक स्लाइड पर बड़ी मात्रा में डेटा को संक्षिप्त, सघन या सारांशित करना;
* डेटा में पैटर्न और रुझानों को उजागर करना;
* समय के साथ या किसी विशिष्ट माप इकाई के संदर्भ में डेटा की दिशा और गति का अनुमान लगाना;
* आउट्लायर, विचलन, त्रुटियों और असंगत डेटा की पहचान करना;
* जटिल डेटा को संप्रेषित या प्रस्तुत करना।

PowerPoint में, आप *Insert* फ़ंक्शन के माध्यम से चार्ट बना सकते हैं, जो कई प्रकार के चार्ट डिज़ाइन करने के लिए टेम्पलेट प्रदान करता है। Aspose.Slides का उपयोग करके, आप नियमित चार्ट (प्रसिद्ध चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}
इस एनेमरेशन का उपयोग [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) को [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) मॉड्यूल के तहत किया जाता है। इस एनेमरेशन में मान विभिन्न चार्ट प्रकारों से मेल खाते हैं।
{{% /alert %}}

### **क्लस्टर्ड कॉलम चार्ट बनाएं**

यह उदाहरण [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) का उपयोग करके एक क्लस्टर्ड कॉलम चार्ट बनाता है जो तीन श्रेणियों में दो श्रृंखलाओं की तुलना करता है। श्रृंखलाएँ लाल और हरे फ़िल्स का उपयोग करती हैं, और व्यक्तिगत लेबल श्रेणी नाम, श्रृंखला नाम और मान दिखाते हैं। वर्कशीट इंडेक्स 0 एम्बेडेड चार्ट वर्कबुक की पहली शीट को संदर्भित करता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series[0]

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    series = chart.chart_data.series[1]

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 60)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![क्लस्टर्ड कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाएं**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x-y ग्राफ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न की जाँच या सहसंबंध दर्शाने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट तब उपयोग करें जब:

* आपके पास युग्मित संख्यात्मक डेटा है।
* आपके पास दो ऐसे चर हैं जो साथ में अच्छी तरह से जुड़ते हैं।
* आप यह निर्धारित करना चाहते हैं कि दो चर संबंधित हैं या नहीं।
* आपके पास एक स्वतंत्र चर है जिसके कई मान एक निर्भर चर के हों।

यह उदाहरण दो सेट x‑y मानों को प्लॉट करता है। पहली श्रृंखला स्टार मार्कर वाले सीधी रेखाओं का उपयोग करती है, जबकि दूसरी स्मूद रेखाओं के साथ सर्कल मार्कर; दोनों का [size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) 10 है। [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) प्रॉपर्टी मार्कर के आकार को नियंत्रित करती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 1, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 1, 3, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    series = chart.chart_data.series[0]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 2, 3)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 2, 10)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    series = chart.chart_data.series[1]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 4, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 5, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेष रूप से जब डेटा में श्रेणी लेबल साथ में संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में कई भाग या लेबल हों तो आप बार चार्ट का उपयोग विचार कर सकते हैं।

यह उदाहरण तीन तिमाही मानों के साथ एक पाई चार्ट बनाता है। प्रत्येक स्लाइस का कस्टम फ़िल और बॉर्डर है, और लेबल विभिन्न संयोजन (मान, प्रतिशत, श्रृंखला जानकारी) दिखाते हैं। [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) प्रॉपर्टी पहले स्लाइस को 180 डिग्री से शुरू करती है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    category_cell = workbook.get_cell(0, 1, 0, "1st Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "2nd Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "3rd Qtr")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_pie_series(value_cell)

    chart.chart_data.series_groups[0].is_color_varied = True

    first_slice = series.data_points[0]
    first_slice.format.fill.fill_type = slides.FillType.SOLID
    first_slice.format.fill.solid_fill_color.color = draw.Color.cyan

    first_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    first_slice.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    first_slice.format.line.width = 3.0
    first_slice.format.line.style = slides.LineStyle.THIN_THICK
    first_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH

    second_slice = series.data_points[1]
    second_slice.format.fill.fill_type = slides.FillType.SOLID
    second_slice.format.fill.solid_fill_color.color = draw.Color.brown

    second_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    second_slice.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    second_slice.format.line.width = 3.0
    second_slice.format.line.style = slides.LineStyle.SINGLE
    second_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    third_slice = series.data_points[2]
    third_slice.format.fill.fill_type = slides.FillType.SOLID
    third_slice.format.fill.solid_fill_color.color = draw.Color.coral

    third_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    third_slice.format.line.fill_format.solid_fill_color.color = draw.Color.red
    third_slice.format.line.width = 2.0
    third_slice.format.line.style = slides.LineStyle.THIN_THIN
    third_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    first_label = series.data_points[0].label
    first_label.data_label_format.show_value = True

    second_label = series.data_points[1].label
    second_label.data_label_format.show_value = True
    second_label.data_label_format.show_legend_key = True
    second_label.data_label_format.show_percentage = True

    third_label = series.data_points[2].label
    third_label.data_label_format.show_series_name = True
    third_label.data_label_format.show_percentage = True

    series.labels.default_data_label_format.show_leader_lines = True

    chart.chart_data.series_groups[0].first_slice_angle = 180

    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पाई चार्ट](pie_chart.png)

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ भी कहा जाता है) तब सबसे उपयुक्त होते हैं जब आप समय के साथ मानों में बदलाव दिखाना चाहते हैं। लाइन चार्ट का उपयोग करके, आप एक साथ बड़ी मात्रा में डेटा की तुलना कर सकते हैं, समय के साथ बदलाव और रुझानों को ट्रैक कर सकते हैं, डेटा श्रृंखला में विसंगतियों को उजागर कर सकते हैं, और अधिक।

यह उदाहरण [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) का उपयोग करके डिफ़ॉल्ट श्रृंखला और श्रेणियों के साथ एक लाइन चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु सीधे निरंतर रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैश द्वारा जोड़ना चाहते हैं, तो [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) को [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) के मान से सेट करें:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH
```

परिणाम:

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट उन मामलों में सबसे उपयुक्त होते हैं जहाँ आप बिक्री डेटा के विभिन्न वर्गों के आकार को दिखाना चाहते हैं और प्रत्येक वर्ग के भीतर बड़े योगदानकर्ताओं पर जल्दी ध्यान आकर्षित करना चाहते हैं।

यह उदाहरण आठ पत्तियों को चार स्तम्भों और दो शाखाओं में समूहित करके एक ट्री मैप बनाता है। [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) मेथड समूह स्तर 1 पर स्तम्भ और स्तर 2 पर शाखाएँ असाइन करता है। मान क्रमशः आयत के सापेक्ष आकार निर्धारित करते हैं, जबकि श्रेणी लेबल और ओवरलैपिंग पेरेंट लेबल पदानुक्रम को पहचानते हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # शाखा 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # शाखा 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("Treemap.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ट्रीमैप चार्ट](treemap_chart.png)

### **वॉटरफ़ॉल चार्ट बनाएं**

वॉटरफ़ॉल चार्ट यह दिखाता है कि सकारात्मक और नकारात्मक बदलाव अंतिम मान में कैसे योगदान देते हैं। उदाहरण के लिए, लाभ विभाजन राजस्व से शुरू हो सकता है, लागत घटाई जा सकती है, और अन्य आय जोड़ी जा सकती है। परिवर्तन कॉलम पिछले और नए चल रहे मानों के बीच तैरते हैं, जबकि कुल कॉलम शून्य से संचयी मान तक विस्तारित होते हैं।

नीचे दिया गया उदाहरण हजारों अमेरिकी डॉलर में राशियों का उपयोग करता है:

| श्रेणी | वर्कबुक मान | कॉलम प्रकार |
| --- | ---: | --- |
| Revenue | 1000 | वृद्धि |
| Cost of sales | -400 | कमी |
| Gross profit | 600 | मध्यवर्ती कुल |
| Operating expenses | -200 | कमी |
| Other income | 50 | वृद्धि |
| Net profit | 450 | अंतिम कुल |

किसी बिंदु को मध्यवर्ती या अंतिम कुल के रूप में चिह्नित करने के लिए, उसके [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) प्रॉपर्टी को `True` सेट करें। उस बिंदु की वर्कबुक सेल में वास्तविक संचयी राशि प्रदान करें: सकल लाभ के लिए `600` (`1000 - 400`) और शुद्ध लाभ के लिए `450` (`600 - 200 + 50`)। यह प्रॉपर्टी कॉलम को कुल के रूप में चिन्हित करती है; यह सेल मान की गणना या भराव नहीं करती। शून्य को प्लेसहोल्डर के रूप में उपयोग न करें या कुल बिंदु के लिए कोई अन्य परिवर्तन न दें। कुल कॉलम संचयी मान को दिखाता है बिना उसे फिर से चल रहे मान में जोड़ें।

यह पूर्ण C# उदाहरण [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) के `Waterfall` सदस्य का उपयोग करके एक चार्ट बनाता है, डिफ़ॉल्ट डेटा हटाता है, और एम्बेडेड वर्कबुक को भरता है। वर्कशीट इंडेक्स `0` पहली वर्कशीट का चयन करता है; कॉलम A में श्रेणी नाम होते हैं और कॉलम B में मान। प्रत्येक मान सेल को [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/) से जोड़ा जाता है। शून्य‑आधारित बिंदु सूचकांक `2` और `5` क्रमशः मध्यवर्ती और अंतिम कुल दर्शाते हैं। [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) को सक्षम करने से मान कॉलम पर प्रदर्शित होते हैं। इनपुट प्रस्तुति या वर्कबुक की आवश्यकता नहीं है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.WATERFALL, 20, 20, 680, 200)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Profit breakdown (USD thousands)")
    chart.chart_title.overlay = False
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Profit")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.WATERFALL)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, categories[i])
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_waterfall_series(value_cell)

    # तीसरे और छठे बिंदु कुल दर्शाते हैं, अतिरिक्त परिवर्तन नहीं।
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

सिरीज़‑स्तर का [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) प्रॉपर्टी `True` सेट करने से क्रमिक कॉलम को जोड़ने वाली रेखाएँ दिखती हैं और चल रहा मान आसानी से देखा जा सकता है। इन रेखाओं को छिपाने के लिए, उदाहरण में असाइनमेंट को `series.show_connector_lines = False` में बदलें सहेजने से पहले। यह केवल रेखा दृश्यता को बदलता है, न कि डेटा या कुलों को।

सहेजी गई प्रस्तुति में 600 का सकल लाभ और 450 का शुद्ध लाभ दिखता है, दोनों कुल शून्य से शुरू होते हैं:

![वॉटरफ़ॉल चार्ट, जिसमें राजस्व, लागत, 600 का सकल लाभ, और 450 का शुद्ध लाभ, मान लेबल और कनेक्टर लाइन्स के साथ](waterfall_chart.png)

### **स्टॉक चार्ट बनाएं**

स्टॉक चार्ट खुले, उच्च, नीचा और बंद मूल्यों जैसे वित्तीय डेटा को प्रदर्शित करने के लिए उपयोग होते हैं, जिससे बाजार रुझानों और अस्थिरता का विश्लेषण किया जा सके। ये स्टॉक प्रदर्शन पर महत्वपूर्ण अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में मदद मिलती है।

यह उदाहरण चार श्रृंखलाओं के साथ एक ओपन‑हाई‑लो‑क्लोज़ चार्ट बनाता है और तीन श्रेणियों को सेट करता है। [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) प्रॉपर्टी अप/डाउन बार सक्षम करती है, और [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) उच्च‑निचले रेखाओं को नियंत्रित करती है जो मूल्य रेंज दिखाती हैं, जबकि व्यक्तिगत श्रृंखला रेखाएँ और लहान क्षैतिज ग्रिडलाइन छिपी रहती हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    workbook = chart.chart_data.chart_data_workbook

    category_cell = workbook.get_cell(0, 1, 0, "A")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "B")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "C")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Open")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 2, "High")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 3, "Low")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 4, "Close")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)

    series = chart.chart_data.series[0]
    value_cell = workbook.get_cell(0, 1, 1, 72)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 1, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 1, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[1]
    value_cell = workbook.get_cell(0, 1, 2, 172)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[2]
    value_cell = workbook.get_cell(0, 1, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 3, 13)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[3]
    value_cell = workbook.get_cell(0, 1, 4, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 4, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 4, 50)
    series.data_points.add_data_point_for_stock_series(value_cell)

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![स्टॉक चार्ट](stock_chart.png)

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

बॉक्स एंड व्हिस्कर चार्ट डेटा के वितरण को प्रमुख सांख्यिकीय माप (जैसे माध्य, क्वारटाइल और संभावित आउट्लायर) का सारांश देकर दर्शाते हैं। ये अन्वेषी डेटा विश्लेषण और सांख्यिकीय अध्ययन में तेज़ी से डेटा वैरिएबिलिटी समझने और किसी भी विसंगति की पहचान करने में विशेष रूप से सहायक होते हैं।

यह उदाहरण छह मानों से एक बॉक्स एंड व्हिस्कर चार्ट बनाता है। [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) प्रॉपर्टी एक्सक्लूसिव क्वारटाइल गणना चुनती है। उदाहरण में औसत रेखाएँ, औसत मार्कर, आंतरिक बिंदु और आउट्लायर बिंदु भी सक्षम किए गए हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    value_cell = workbook.get_cell(0, "B1", 15)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 41)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 10)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 23)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)

    presentation.save("BoxAndWhisker.pptx", slides.export.SaveFormat.PPTX)
```

### **फ़नल चार्ट बनाएं**

फ़नल चार्ट क्रमिक चरणों वाले प्रक्रियाओं को विज़ुअलाइज़ करने के लिए उपयोग होते हैं, जहाँ डेटा की मात्रा प्रत्येक चरण के साथ घटती जाती है। ये रूपांतरण दरों का विश्लेषण, बाधाओं की पहचान, और बिक्री या मार्केटिंग प्रक्रियाओं की दक्षता को ट्रैक करने में विशेष रूप से सहायक होते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में एक फ़नल चार्ट जोड़ने के लिए [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) का उपयोग करता है। यह डिफ़ॉल्ट डेटा को छह श्रेणियों और 50 से 500 तक के मानों से बदल देता है, फिर अपडेटेड प्रस्तुति को सहेजता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    value_cell = workbook.get_cell(0, "B1", 50)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 100)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 200)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 300)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 400)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 500)
    series.data_points.add_data_point_for_funnel_series(value_cell)

    presentation.save("Funnel.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![फ़नल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाएं**

सनबर्स्ट चार्ट पदानुक्रमित डेटा को विज़ुअलाइज़ करने के लिए उपयोग होते हैं, जहाँ स्तरों को concentric rings के रूप में दिखाया जाता है। ये भाग‑से‑सम्पूर्ण संबंधों को स्पष्ट, संक्षिप्त रूप में दर्शाते हैं और नेस्टेड श्रेणियों व उप‑श्रेणियों को प्रदर्शित करने के लिए आदर्श हैं।

यह उदाहरण आठ पत्तियों को चार स्तम्भों और दो शाखाओं में समूहित करके एक सनबर्स्ट चार्ट बनाता है। [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) मेथड समूह स्तर 1 पर स्तम्भ और स्तर 2 पर शाखाएँ असाइन करता है। श्रेणी लेबल खंडों को पहचानते हैं, और मान उनके सापेक्ष आकार निर्धारित करते हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # शाखा 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # शाखा 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)

    presentation.save("Sunburst.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![सनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाएं**

हिस्टोग्राम चार्ट संख्यात्मक डेटा के वितरण को नियमों या बिन्स में मानों को समूहित करके दर्शाते हैं। ये डेटा पैटर्न (जैसे आवृत्ति, विकृति और प्रसार) की पहचान करने और डेटासेट में आउट्लायर का पता लगाने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण छह संख्यात्मक मानों, जिसमें नकारात्मक मान भी शामिल हैं, से एक हिस्टोग्राम बनाता है। [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) को ऑटोमैटिक सेट करने से चार्ट वितरण दिखाने के लिए बिन्स निर्धारित करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    value_cell = workbook.get_cell(0, "A1", 15)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A2", -41)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A3", 16)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A4", 10)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A5", -23)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A6", 16)
    series.data_points.add_data_point_for_histogram_series(value_cell)

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("Histogram.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![हिस्टोग्राम चार्ट](histogram_chart.png)

### **रडार चार्ट बनाएं**

रडार चार्ट दो‑आयामी फ़ॉर्मेट में बहु‑चर डेटा को प्रदर्शित करते हैं, जिससे कई चर की एक साथ आसान तुलना की जा सके। ये कई प्रदर्शन मीट्रिक या विशेषताओं में पैटर्न, ताकत और कमजोरी की पहचान करने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) का उपयोग करके डिफ़ॉल्ट श्रृंखला और श्रेणियों के साथ एक रडार चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_chart(charts.ChartType.RADAR, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![रडार चार्ट](radar_chart.png)

### **मल्टी‑कैटेगरी चार्ट बनाएं**

मल्टी‑कैटेगरी चार्ट तब उपयोग होते हैं जब डेटा कई श्रेणी समूहों से संबंधित हो, जिससे आप कई आयामों में मानों की तुलना एक साथ कर सकें। ये जटिल, बहु‑परत डेटा सेट में रुझानों और संबंधों का विश्लेषण करने में विशेष रूप से मददगार होते हैं।

यह उदाहरण चार जोड़े में व्यवस्थित आठ श्रेणियों के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है। [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) मेथड प्रत्येक जोड़े को समूह स्तर 1 पर साझा लेबल देता है, जिससे व्यक्तिगत और समूह लेबल दोनों वाली श्रेणी अक्ष बनती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.get_cell(0, "c2", "A")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group1")
    category_cell = workbook.get_cell(0, "c3", "B")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c4", "C")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group2")
    category_cell = workbook.get_cell(0, "c5", "D")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c6", "E")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group3")
    category_cell = workbook.get_cell(0, "c7", "F")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c8", "G")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group4")
    category_cell = workbook.get_cell(0, "c9", "H")
    category = chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, "D1", "Series 1")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    value_cell = workbook.get_cell(worksheet_index, "D2", 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D3", 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D4", 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D5", 40)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D6", 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D7", 60)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D8", 70)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D9", 80)
    series.data_points.add_data_point_for_bar_series(value_cell)

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![मल्टी‑कैटेगरी चार्ट](multi_category_chart.png)

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को विशिष्ट स्थानों (जैसे देश, राज्य या शहर) पर मैप करके विज़ुअलाइज़ करने के लिए उपयोग होते हैं। ये क्षेत्रीय रुझान, जनसांख्यिकी और अंतरिक्षीय वितरण को स्पष्ट, आकर्षक रूप में विश्लेषित करने में विशेष रूप से सहायक होते हैं।

यह उदाहरण [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) का उपयोग करके डिफ़ॉल्ट भू‑भौगोलिक डेटा के साथ एक मैप चार्ट बनाता है और इसे PowerPoint में देखने के लिए सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.MAP, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![मैप चार्ट](map_chart.png)

{{% alert color="info" title="Note" %}}
ऊपर की तस्वीर में सहेजी गई प्रस्तुति PowerPoint में खुली हुई दिखाती है। Aspose.Slides मैप चार्ट और उसका डेटा सही ढंग से लिखता है, लेकिन वह स्वयं मैप चार्ट नहीं बनाता: जब किसी स्लाइड पर मौजूद मैप चार्ट को छवि में रेंडर किया जाता है या PDF या SVG में परिवर्तित किया जाता है, तो चार्ट क्षेत्र खाली रहता है। उसी स्लाइड के अन्य आकार अपरिवर्तित रहते हैं।
{{% /alert %}}

### **कंबिनेशन चार्ट बनाएं**

कंबिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको दो या अधिक डेटा सेट के बीच अंतर को उजागर, तुलना या परीक्षण करने में सक्षम बनाता है, जिससे आप उनके बीच संबंध पहचान सकें।

![कंबिनेशन चार्ट](combination_chart.png)

यह उदाहरण चार क्लस्टर्ड कॉलम श्रृंखलाओं को एक लाइन श्रृंखला के साथ चार श्रेणियों में जोड़ता है। कॉलम प्राथमिक ऊर्ध्वाधर अक्ष का उपयोग करते हैं, जबकि [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) लाइन को दाएँ ओर द्वितीय ऊर्ध्वाधर अक्ष पर रखता है। सहायक फ़ंक्शन शीर्षक, लीजेंड, अक्ष लेबल और ग्रिडलाइन को कॉन्फ़िगर करते हैं।

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)

def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    portion_format = chart.chart_title.text_frame_for_overriding.paragraphs[0].paragraph_format.default_portion_format
    portion_format.font_bold = slides.NullableBool.FALSE
    portion_format.font_height = 18

    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 4, 0, "Category 4")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 4.3)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 2.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 3.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 1, 4.5)
    series.data_points.add_data_point_for_bar_series(value_cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 2.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 4.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 1.8)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 2, 2.8)
    series.data_points.add_data_point_for_bar_series(value_cell)

def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    value_cell = workbook.get_cell(worksheet_index, 1, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 3, 3.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 3, 5.0)
    series.data_points.add_data_point_for_line_series(value_cell)

    series.plot_on_second_axis = True

def set_primary_axes_format(chart):
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)

def set_secondary_axes_format(chart):
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12


create_combo_chart()
```

## **चार्ट अपडेट करें**

Aspose.Slides for Python via .NET आपको PowerPoint चार्ट को डेटा, फ़ॉर्मेटिंग और स्टाइलिंग में बदलाव करके अपडेट करने की सुविधा देता है। यह कार्यक्षमता प्रस्तुति को गतिशील सामग्री के साथ अद्यतन रखने की प्रक्रिया को सरल बनाती है और सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सही ढंग से प्रतिबिंबित करें।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर "My chart" नामक चार्ट को अपडेट करता है। इसमें प्रत्येक में तीन डेटा पॉइंट वाले दो कॉलम श्रृंखला की आवश्यकता होती है, जहाँ श्रेणी लेबल कॉलम A में और श्रृंखला नाम पहली पंक्ति में होते हैं। उदाहरण [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) का उपयोग करके वर्कबुक सेल्स को बदलता है, श्रृंखला मानों को अपडेट करता है, तीसरी श्रृंखला जोड़ता है, और [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/) के माध्यम से चार्ट को क्लस्टर्ड सिलिंडर में बदलता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            worksheet_index = 0

            workbook = chart.chart_data.chart_data_workbook

            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.chart_data.series[0]

            workbook.get_cell(worksheet_index, 0, 1, "New_Series 1")
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            series = chart.chart_data.series[1]

            workbook.get_cell(worksheet_index, 0, 2, "New_Series 2")
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
            series = chart.chart_data.series.add(series_name_cell, chart.type)

            value_cell = workbook.get_cell(worksheet_index, 1, 3, 20)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 2, 3, 50)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 3, 3, 30)
            series.data_points.add_data_point_for_bar_series(value_cell)

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

    presentation.save("AsposeChartModified.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट के लिए डेटा रेंज सेट करें**

किसी मौजूदा चार्ट द्वारा पहले से उपयोग की गई रेंज को देखने के लिए, देखें [Retrieve a Chart's Data Range](/slides/hi/python-net/chart-workbook/#retrieve-a-charts-data-range)।

Aspose.Slides for Python via .NET आपको वर्कशीट से एक विशिष्ट डेटा रेंज को चार्ट डेटा स्रोत के रूप में परिभाषित करने की लचीलापन देता है। इसका अर्थ है कि आप सीधे अपनी वर्कशीट के किसी भाग को चार्ट से मानचित्रित कर सकते हैं, जिससे आप नियंत्रित कर सकें कि कौन‑से सेल्स श्रृंखला और श्रेणियों में योगदान देते हैं। परिणामस्वरूप, आप अपने चार्ट को आसानी से नवीनतम डेटा परिवर्तन के साथ अपडेट और सिंक्रनाइज़ कर सकते हैं, यह सुनिश्चित करते हुए कि आपकी PowerPoint प्रस्तुतियाँ वर्तमान और सटीक जानकारी को दर्शाती रहें।

यह उदाहरण [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके मौजूदा प्रस्तुति की पहली स्लाइड पर "My chart" नामक चार्ट के डेटा स्रोत को `Sheet1!A1:B4` पर सेट करता है। चार्ट वर्कबुक में वह शीट और एक भरी हुई रेंज होनी चाहिए जिसमें पहली पंक्ति में श्रृंखला शीर्षक, कॉलम A में श्रेणी लेबल, और कॉलम B में तीन मान हों।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करते हैं, तो प्रत्येक श्रृंखला को स्वचालित रूप से अलग‑अलग डिफ़ॉल्ट मार्कर प्रतीक मिलते हैं।

यह उदाहरण [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) का उपयोग करके दो लाइन श्रृंखला और एक लीजेंड के साथ एक चार्ट बनाता है। [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) सेटिंग्स स्वचालित रूप से असाइन किए गए मार्कर प्रतीकों को बरकरार रखती हैं। पहली श्रृंखला में एक नकारात्मक मान और एक गुम मान `None` द्वारा दर्शाया गया है, जबकि दूसरी में प्रत्येक श्रेणी के लिए मान है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(0, 1, 0, "C1")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 1, 1, 24)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 2, 0, "C2")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 2, 1, 23)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 3, 0, "C3")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 3, 1, -10)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 4, 0, "C4")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 4, 1, None)
    series.data_points.add_data_point_for_line_series(value_cell)

    series_name_cell = workbook.get_cell(0, 0, 2, "Series 2")
    second_series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(0, 1, 2, 30)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 10)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 60)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 4, 2, 40)
    second_series.data_points.add_data_point_for_line_series(value_cell)

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides for Python via .NET द्वारा कौन से चार्ट प्रकार समर्थित हैं?**

Aspose.Slides for Python via .NET कई प्रकार के चार्ट प्रकारों का समर्थन करता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रडार और कई अन्य शामिल हैं। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूँ?**

चार्ट जोड़ने के लिए, आप सबसे पहले [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने के लिए मेथड को कॉल करते हैं, जिसमें चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में सम्मिलित करती है।

**मैं चार्ट में प्रदर्शित डेटा को कैसे अपडेट करूँ?**

आप चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँच कर, किसी भी डिफ़ॉल्ट श्रृंखला और श्रेणियों को साफ करके, और फिर अपनी कस्टम डेटा जोड़कर चार्ट का डेटा अपडेट कर सकते हैं। यह आपको प्रोग्रामेटिक रूप से नवीनतम डेटा को दर्शाने के लिए चार्ट को रीफ़्रेश करने की अनुमति देता है।

**क्या मैं चार्ट की उपस्थिति को अनुकूलित कर सकता हूँ?**

हाँ, Aspose.Slides for Python via .NET व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लीजेंड, और अन्य फ़ॉर्मेटिंग तत्वों को बदलकर चार्ट की उपस्थिति को अपने विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार ढाल सकते हैं।
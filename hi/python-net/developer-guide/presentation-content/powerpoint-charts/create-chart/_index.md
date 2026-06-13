---
title: Python में PowerPoint प्रस्तुति चार्ट बनाएं या अपडेट करें
linktitle: एक चार्ट बनाएं या अपडेट करें
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
- बॉक्स एंड व्हिस्कर चार्ट
- फनल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगरी चार्ट
- PowerPoint प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में चार्ट बनाना और अनुकूलित करना सीखें। यह प्रस्तुतियों में चार्ट जोड़ने, फ़ॉर्मेट करने और संपादित करने के साथ-साथ Python में व्यावहारिक कोड उदाहरणों को कवर करता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via .NET का उपयोग करके चार्ट बनाने और अनुकूलित करने के लिए एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि कैसे प्रोग्रामेटिक रूप से स्लाइड में चार्ट जोड़ा जाए, उसे डेटा से भरा जाए, और आपके विशिष्ट डिजाइन आवश्यकताओं के अनुसार विभिन्न फ़ॉर्मेटिंग विकल्प लागू किए जाएँ। पूरे लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को इनिशियलाइज़ करने से लेकर सीरीज, अक्ष, और लीजेंड को कॉन्फ़िगर करने तक। इस गाइड का पालन करके आप अपने अनुप्रयोगों में डायनेमिक चार्ट जनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा-आधारित प्रस्तुतियों को बनाना आसान हो जाएगा।

## **चार्ट बनाएं**

चार्ट लोगों को डेटा को जल्दी से विज़ुअलाइज़ करने और ऐसे अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं हो सकती।

**चार्ट क्यों बनाएं?**

* एक प्रस्तुति स्लाइड पर बड़ी मात्रा में डेटा को एकत्रित, संक्षिप्त या सारांशित करना;
* डेटा में पैटर्न और रुझानों को उजागर करना;
* समय के साथ या किसी विशिष्ट माप इकाई के संदर्भ में डेटा की दिशा और गति का निष्कर्ष निकालना;
* आउटलेयर, विचलन, त्रुटियाँ और असंगत डेटा को पहचानना;
* जटिल डेटा को संप्रेषित या प्रस्तुत करना।

PowerPoint में, आप *Insert* फ़ंक्शन के माध्यम से चार्ट बना सकते हैं, जो कई प्रकार के चार्ट डिज़ाइन करने के लिए टेम्पलेट प्रदान करता है। Aspose.Slides का उपयोग करके आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="primary" %}} 
[ChartType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) enumeration को [Aspose.Slides.Charts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/) namespace के अंतर्गत उपयोग करें। इस enumeration में मान विभिन्न चार्ट प्रकारों से मेल खाते हैं। 
{{% /alert %}} 

### **क्लस्टर्ड कॉलम चार्ट बनाएं**

यह अनुभाग Aspose.Slides for Python via .NET का उपयोग करके क्लस्टर्ड कॉलम चार्ट बनाने की प्रक्रिया समझाता है। आप एक प्रस्तुति को इनिशियलाइज़ करना, चार्ट जोड़ना, और शीर्षक, डेटा, सीरीज़, कैटेगरी और स्टाइलिंग जैसे तत्वों को अनुकूलित करना सीखेंगे। नीचे दिए गए चरणों का पालन करें ताकि देखें कि मानक क्लस्टर्ड कॉलम चार्ट कैसे उत्पन्न होता है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. कछ डेटा के साथ एक चार्ट जोड़ें और `ChartType.CLUSTERED_COLUMN` प्रकार निर्दिष्ट करें।
1. चार्ट में शीर्षक जोड़ें।
1. चार्ट की डेटा वर्कशीट तक पहुँचें।
1. डिफ़ॉल्ट सभी सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. चार्ट सीरीज़ पर भराव रंग लागू करें।
1. चार्ट सीरीज़ में लेबल जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # चार्ट शीर्षक सेट करें।
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # पहले सीरीज़ को मान प्रदर्शित करने के लिए सेट करें।
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # चार्ट डेटा शीट का इंडेक्स सेट करें।
    worksheet_index = 0

    # चार्ट डेटा वर्कबुक प्राप्त करें।
    workbook = chart.chart_data.chart_data_workbook

    # डिफ़ॉल्ट उत्पन्न सीरीज़ और कैटेगरीज को हटाएँ।
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # नई सीरीज़ जोड़ें।
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # नई कैटेगरीज जोड़ें।
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # पहली चार्ट सीरीज़ प्राप्त करें।
    series = chart.chart_data.series[0]

    # सीरीज़ डेटा को भरें।
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # सीरीज़ के लिए भराव रंग सेट करें।
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # दूसरी चार्ट सीरीज़ प्राप्त करें।
    series = chart.chart_data.series[1]

    # सीरीज़ डेटा को भरें।
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # सीरीज़ के लिए भराव रंग सेट करें।
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # पहला लेबल कैटेगरी नाम दिखाने के लिए सेट करें।
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # तीसरे लेबल के लिए मान दिखाने के लिए सीरीज़ सेट करें।
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

![क्लस्टर्ड कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाएं**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ़ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न की जाँच या सहसंबंध दर्शाने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास युग्मित संख्यात्मक डेटा है।
* आपके पास दो ऐसे चर हैं जो मिलकर अच्छी तरह से काम करते हैं।
* आप यह निर्धारित करना चाहते हैं कि दोनों चरों के बीच संबंध है या नहीं।
* आपके पास एक स्वतंत्र चर है जिसके कई मान निर्भर चर के लिए हैं।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # डिफ़ॉल्ट स्कैटर चार्ट बनाएं।
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # चार्ट डेटा शीट का इंडेक्स सेट करें।
    worksheet_index = 0

    # चार्ट डेटा वर्कबुक प्राप्त करें।
    workbook = chart.chart_data.chart_data_workbook

    # डिफ़ॉल्ट सीरीज़ हटाएँ।
    chart.chart_data.series.clear()

    # नई सीरीज़ जोड़ें।
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # पहली चार्ट सीरीज़ प्राप्त करें।
    series = chart.chart_data.series[0]

    # सीरीज़ में नया पॉइंट (1:3) जोड़ें।
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # नया पॉइंट (2:10) जोड़ें।
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # सीरीज़ प्रकार बदलें।
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # चार्ट सीरीज़ मार्कर बदलें।
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # दूसरी चार्ट सीरीज़ प्राप्त करें।
    series = chart.chart_data.series[1]

    # चार्ट सीरीज़ में नया पॉइंट (5:2) जोड़ें।
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # नया पॉइंट (3:1) जोड़ें।
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # नया पॉइंट (2:2) जोड़ें।
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # नया पॉइंट (5:1) जोड़ें।
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # चार्ट सीरीज़ मार्कर बदलें।
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेष रूप से जब डेटा में श्रेणीबद्ध लेबल के साथ संख्यात्मक मान होते हैं। हालांकि, यदि आपके डेटा में कई भाग या लेबल हों, तो आप बार चार्ट का उपयोग करने पर विचार कर सकते हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.PIE` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. चार्ट के लिए नए पॉइंट जोड़ें और पाई चार्ट के सेक्टरों पर कस्टम रंग लागू करें।
1. सीरीज़ के लिए लेबल सेट करें।
1. सीरीज़ लेबल के लिए लीडर लाइन्स सक्षम करें।
1. पाई चार्ट के लिए घूर्णन कोण सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # चार्ट शीर्षक सेट करें।
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # पहली सीरीज़ को मान दिखाने के लिए सेट करें।
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # चार्ट डेटा शीट का इंडेक्स सेट करें।
    worksheet_index = 0

    # चार्ट डेटा वर्कबुक प्राप्त करें।
    workbook = chart.chart_data.chart_data_workbook

    # डिफ़ॉल्ट रूप से उत्पन्न सीरीज़ और कैटेगरीज हटाएँ।
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # नई कैटेगरीज जोड़ें।
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # नई सीरीज़ जोड़ें।
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # सीरीज़ डेटा भरें।
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # सेक्टर का रंग सेट करें।
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # सेक्टर की सीमा (बॉर्डर) सेट करें।
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # सेक्टर की सीमा (बॉर्डर) सेट करें।
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # सेक्टर की सीमा (बॉर्डर) सेट करें।
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # नई सीरीज़ में प्रत्येक कैटेगरी के लिए कस्टम लेबल बनाएं।
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # चार्ट के लिए लीडर लाइन्स दिखाने के लिए सीरीज़ सेट करें।
    series.labels.default_data_label_format.show_leader_lines = True

    # पाई चार्ट सेक्टरों के लिए घूर्णन कोण सेट करें।
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

![पाई चार्ट](pie_chart.png)

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट का उपयोग करके आप बड़े डेटा को एक साथ तुलना कर सकते हैं, समय के साथ परिवर्तन और रुझानों को ट्रैक कर सकते हैं, डेटा सीरीज़ में विसंगतियों को हाइलाइट कर सकते हैं, आदि।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.LINE` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

डिफ़ॉल्ट रूप से, लाइन चार्ट पर पॉइंट्स को सीधी निरंतर रेखाओं से जोड़ा जाता है। यदि आप पॉइंट्स को डैश द्वारा जोड़ना चाहते हैं, तो आप नीचे दर्शाए गए अनुसार अपनी पसंदीदा डैश प्रकार निर्दिष्ट कर सकते हैं:

```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी में बड़े योगदानकर्ता आइटम्स पर तुरंत ध्यान आकर्षित करना चाहते हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.TREEMAP` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # शाखा 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # शाखा 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

![ट्री मैप चार्ट](treemap_chart.png)

### **स्टॉक चार्ट बनाएं**

स्टॉक चार्ट वित्तीय डेटा जैसे ओपन, हाई, लो, और क्लोज प्राइस दिखाने के लिए उपयोग किए जाते हैं, जो मार्केट रुझानों और अस्थिरता का विश्लेषण करने में मदद करते हैं। ये स्टॉक प्रदर्शन के बारे में महत्वपूर्ण अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में सहायता मिलती है।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.OPEN_HIGH_LOW_CLOSE` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. HiLowLines फ़ॉर्मेट निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

![स्टॉक चार्ट](stock_chart.png)

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

बॉक्स एंड व्हिस्कर चार्ट डेटा के वितरण को प्रमुख सांख्यिकीय मापों, जैसे मीडियन, क्वारटाइल्स, और संभावित आउटलेयर, को सारांशित करके प्रदर्शित करने के लिए उपयोग किए जाते हैं। ये एक्सप्लोरेटरी डेटा एनालिसिस और सांख्यिकीय अध्ययन में डेटा वैरिएबिलिटी को जल्दी समझने और किसी भी विसंगतियों की पहचान करने में विशेष रूप से उपयोगी होते हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.BOX_AND_WHISKER` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **फनल चार्ट बनाएं**

फनल चार्ट प्रक्रियाओं को विज़ुअलाइज़ करने के लिए उपयोग किए जाते हैं जहाँ क्रमिक चरण होते हैं, और डेटा की मात्रा एक चरण से अगले चरण में कम होती जाती है। यह कन्वर्ज़न रेट विश्लेषण, बॉटलनेक पहचान, और बिक्री या मार्केटिंग प्रक्रियाओं की दक्षता ट्रैक करने में विशेष रूप से सहायक होते हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.FUNNEL` प्रकार निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

![फनल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाएं**

सनबर्स्ट चार्ट पदानुक्रमित डेटा को विज़ुअलाइज़ करने के लिए उपयोग किए जाते हैं, जहाँ स्तरों को समकेंद्रित रिंग्स के रूप में दिखाया जाता है। ये भाग‑से‑सम्पूर्ण संबंधों को दर्शाने में मदद करते हैं और नेस्टेड श्रेणियों को स्पष्ट और संक्षिप्त रूप में प्रस्तुत करने के लिए आदर्श हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.SUNBURST` प्रकार निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # शाखा 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # शाखा 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

![सनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाएं**

हिस्टोग्राम चार्ट संख्यात्मक डेटा के वितरण को दर्शाने के लिए उपयोग किए जाते हैं, जहाँ मानों को रेंज या बिन में समूहित किया जाता है। ये डेटा पैटर्न जैसे फ़्रीक्वेंसी, स्क्यूनेस, और फैलाव की पहचान करने और डेटासेट में आउटलेयर खोजने में विशेष रूप से उपयोगी होते हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. कछ डेटा के साथ एक चार्ट जोड़ें और `ChartType.HISTOGRAM` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

![हिस्टोग्राम चार्ट](histogram_chart.png)

### **रेडार चार्ट बनाएं**

रेडार चार्ट बहु-परिवर्ती डेटा को दो-आयामी प्रारूप में प्रदर्शित करने के लिए उपयोग किए जाते हैं, जिससे कई चरों की एक साथ तुलना आसान हो जाती है। ये कई प्रदर्शन मीट्रिक या एट्रिब्यूट्स में पैटर्न, ताकत और कमजोरियों की पहचान करने में विशेष रूप से उपयोगी होते हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. कछ डेटा के साथ एक चार्ट जोड़ें और `ChartType.RADAR` प्रकार निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```

![रेडार चार्ट](radar_chart.png)

### **मल्टी कैटेगरी चार्ट बनाएं**

मल्टी कैटेगरी चार्ट ऐसे डेटा को प्रदर्शित करने के लिए उपयोग किए जाते हैं जिसमें एक से अधिक श्रेणीबद्ध समूह होते हैं, जिससे आप कई आयामों में मानों की एक साथ तुलना कर सकते हैं। ये जटिल, बहु-स्तरीय डेटासेट में रुझान और संबंधों का विश्लेषण करने में विशेष रूप से मददगार होते हैं।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.CLUSTERED_COLUMN` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करें।
1. नई सीरीज़ और कैटेगरीज जोड़ें।
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # एक सीरीज़ जोड़ें।
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # चार्ट के साथ प्रस्तुति को सहेजें।
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

![मल्टी कैटेगरी चार्ट](multi_category_chart.png)

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को विशिष्ट स्थानों जैसे देशों, राज्यों या शहरों से मिलाते हुए विज़ुअलाइज़ करने के लिए उपयोग किए जाते हैं। ये क्षेत्रीय रुझानों, जनसांख्यिकीय डेटा और स्थानिक वितरण का विश्लेषण स्पष्ट और दृष्टिगत रूप से आकर्षक तरीके से करने में मदद करते हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

![मैप चार्ट](map_chart.png)

### **कॉम्बिनेशन चार्ट बनाएं**

कॉम्बिनेशन चार्ट (या कॉम्बो चार्ट) दो या अधिक चार्ट प्रकारों को एक ही ग्राफ़ में संयोजित करता है। यह चार्ट आपको दो या अधिक डेटा सेट्स के बीच अंतर को उजागर, तुलना या विश्लेषण करने की सुविधा देता है, जिससे आप उनके बीच संबंध पहचान सकते हैं।

![कॉम्बिनेशन चार्ट](combination_chart.png)

निम्नलिखित Python कोड दिखाता है कि ऊपर दिखाए गए कॉम्बिनेशन चार्ट को PowerPoint प्रस्तुति में कैसे बनाया जाए:

```python
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

    # चार्ट का शीर्षक सेट करें।
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # चार्ट लेजेंड सेट करें।
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # डिफ़ॉल्ट उत्पन्न सीरीज़ और कैटेगरीज हटाएँ।
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # नई कैटेगरीज जोड़ें।
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # पहली सीरीज़ जोड़ें।
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # क्षैतिज अक्ष सेट करें।
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # ऊर्ध्वाधर अक्ष सेट करें।
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # ऊर्ध्वाधर मुख्य ग्रिडलाइन का रंग सेट करें।
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # द्वितीयक क्षैतिज अक्ष सेट करें।
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # द्वितीयक ऊर्ध्वाधर अक्ष सेट करें।
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **चार्ट अपडेट करें**

Aspose.Slides for Python via .NET आपको चार्ट डेटा, फ़ॉर्मेटिंग और स्टाइलिंग को संशोधित करके PowerPoint चार्ट को अपडेट करने की सुविधा देता है। यह कार्यक्षमता गतिशील सामग्री के साथ प्रस्तुतियों को अद्यतित रखने की प्रक्रिया को सरल बनाती है और सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सटीक रूप से प्रतिबिंबित करें।

1. किसी चार्ट वाली प्रस्तुति को दर्शाने वाली Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. सभी शेप्स के माध्यम से ट्रैवर्स करके चार्ट ढूँढें।
1. चार्ट की डेटा वर्कशीट तक पहुँचें।
1. सीरीज़ मान बदलकर चार्ट डेटा सीरीज़ को संशोधित करें।
1. एक नई सीरीज़ जोड़ें और उसका डेटा भरें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation("ExistingChart.pptx") as presentation:

    # पहले स्लाइड तक पहुँचेँ।
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # चार्ट डेटा शीट का इंडेक्स सेट करें।
            worksheet_index = 0

            # चार्ट डेटा वर्कबुक प्राप्त करें।
            workbook = chart.chart_data.chart_data_workbook

            # चार्ट श्रेणी नाम बदलें।
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # पहली चार्ट सीरीज़ प्राप्त करें।
            series = chart.chart_data.series[0]

            # सीरीज़ डेटा अपडेट करें।
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # सीरीज़ का नाम बदल रहा है।
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # दूसरी चार्ट सीरीज़ प्राप्त करें।
            series = chart.chart_data.series[1]

            # सीरीज़ डेटा अपडेट करें।
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # सीरीज़ का नाम बदल रहा है।
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # नई सीरीज़ जोड़ें।
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # सीरीज़ डेटा भरें।
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # चार्ट के साथ प्रस्तुति सहेजें।
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट के लिए डेटा रेंज सेट करें**

Aspose.Slides for Python via .NET आपको कार्यपत्रक से एक विशिष्ट डेटा रेंज को चार्ट के डेटा स्रोत के रूप में परिभाषित करने की लचीलापन देता है। इसका अर्थ है कि आप सीधे कार्यपत्रक के किसी भाग को चार्ट से मैप कर सकते हैं, जिससे आप नियंत्रित कर सकते हैं कि कौन‑सी सेल्स चार्ट की सीरीज़ और कैटेगरीज में योगदान देती हैं। परिणामस्वरूप, आप आसानी से अपने चार्ट को कार्यपत्रक में नवीनतम डेटा परिवर्तन के साथ अपडेट और सिंक्रोनाइज़ कर सकते हैं, यह सुनिश्चित करते हुए कि आपके PowerPoint प्रस्तुतियाँ वर्तमान और सटीक जानकारी को प्रतिबिंबित करें।

1. किसी चार्ट वाली प्रस्तुति को दर्शाने वाली Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. सभी शेप्स के माध्यम से ट्रैवर्स करके चार्ट ढूँढें।
1. चार्ट डेटा तक पहुँचें और रेंज सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation("ExistingChart.pptx") as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से एक अलग डिफ़ॉल्ट मार्कर प्रतीक मिल जाता है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # सीरीज़ डेटा भरें।
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides for Python via .NET द्वारा कौन‑से चार्ट प्रकार समर्थित हैं?**

Aspose.Slides for Python via .NET विभिन्न प्रकार के चार्ट प्रकारों को समर्थन देता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार, और कई अन्य शामिल हैं। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की ज़रूरतों के लिए सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**स्लाइड में नया चार्ट कैसे जोड़ें?**

एक चार्ट जोड़ने के लिए, पहले आप Presentation क्लास का इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, फिर चार्ट जोड़ने के मेथड को कॉल करते हैं, जहाँ आप चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत करती है।

**एक चार्ट में प्रदर्शित डेटा को कैसे अपडेट कर सकते हैं?**

आप चार्ट के डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/)) तक पहुँचकर, डिफ़ॉल्ट सीरीज़ और कैटेगरीज को साफ़ करके, और फिर अपना कस्टम डेटा जोड़कर चार्ट का डेटा अपडेट कर सकते हैं। यह आपको प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा को प्रतिबिंबित करने के लिए रीफ़्रेश करने की अनुमति देता है।

**क्या चार्ट की उपस्थिति को अनुकूलित करना संभव है?**

हाँ, Aspose.Slides for Python via .NET व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लीजेंड और अन्य फ़ॉर्मेटिंग तत्वों को बदलकर चार्ट की उपस्थिति को आपके विशिष्ट डिजाइन आवश्यकताओं के अनुसार तैयार कर सकते हैं।
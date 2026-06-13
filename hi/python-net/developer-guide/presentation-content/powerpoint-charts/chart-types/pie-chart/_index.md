---
title: Python के साथ प्रस्तुतियों में पाई चार्ट को कस्टमाइज़ करें
linktitle: पाई चार्ट
type: docs
url: /hi/python-net/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधित करें
- चार्ट कस्टमाइज़ करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में पाई चार्ट बनाने और कस्टमाइज़ करने के तरीकों को सीखें, जिन्हें PowerPoint और OpenDocument में निर्यात किया जा सकता है, और सेकंडों में आपके डेटा स्टोरीटेलिंग को बढ़ाते हैं।"
---
## **परिचय**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीकों को समझाता है। यह Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने तथा मानक पाई चार्ट के लिए स्वचालित स्लाइस रंगीकरण को सक्षम करने का तरीका दिखाता है।

उदाहरण व्यावहारिक चार्ट अनुकूलन चरणों पर केंद्रित हैं, जैसे स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से प्रतिस्थापित करना, और अपडेटेड प्रस्तुति को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्प**
Aspose.Slides for Python via .NET अब Pie of Pie या Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों का समर्थन करता है। इस विषय में, हम उदाहरण के साथ दिखाएंगे कि Aspose.Slides का उपयोग करके इन विकल्पों को कैसे निर्दिष्ट किया जाता है। इन गुणों को निर्दिष्ट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास ऑब्जेक्ट को इंस्टैंशिएट करें।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट के द्वितीयक प्लॉट विकल्प निर्दिष्ट करें।
1. प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने Pie of Pie चार्ट के विभिन्न गुण सेट किए हैं।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation क्लास का एक इंस्टेंस बनाएं
with slides.Presentation() as presentation:
    # स्लाइड पर चार्ट जोड़ें
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # विभिन्न गुण सेट करें
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # प्रेजेंटेशन को डिस्क पर लिखें
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**
Aspose.Slides for Python via .NET स्वचालित पाई चार्ट स्लाइड रंग सेट करने के लिए एक सरल API प्रदान करता है। सैंपल कोड ऊपर बताए गए गुणों को लागू करता है।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. चार्ट शीर्षक सेट करें।
1. पहली श्रृंखला को मान दिखाने के लिए सेट करें।
1. चार्ट डेटा शीट का इंडेक्स सेट करें।
1. चार्ट डेटा वर्कशीट प्राप्त करें।
1. डिफ़ॉल्ट जेनरेटेड श्रृंखला और श्रेणियों को हटाएं।
1. नई श्रेणियां जोड़ें।
1. नई श्रृंखला जोड़ें।

संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास इंस्टैंशिएट करें
with slides.Presentation() as presentation:
	# पहली स्लाइड तक पहुँचें
	slide = presentation.slides[0]

	# डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# चार्ट शीर्षक सेट करना
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# पहली श्रृंखला को मान दिखाने के लिए सेट करें
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# चार्ट डेटा शीट का इंडेक्स सेट करना
	defaultWorksheetIndex = 0

	# चार्ट डेटा वर्कशीट प्राप्त करें
	fact = chart.chart_data.chart_data_workbook

	# डिफ़ॉल्ट जनरेटेड श्रृंखला और श्रेणियों को हटाएँ
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# नई श्रेणियां जोड़ना
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# नई श्रृंखला जोड़ना
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# अब श्रृंखला डेटा भरना
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या 'Pie of Pie' और 'Bar of Pie' वेरिएंट समर्थित हैं?**

हां, लाइब्रेरी पाई चार्ट के लिए द्वितीयक प्लॉट का [समर्थन](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) करती है, जिसमें 'Pie of Pie' और 'Bar of Pie' प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (जैसे, PNG) के रूप में निर्यात कर सकता हूँ?**

हां, आप पूरे प्रस्तुति के बिना चार्ट को स्वयं एक छवि (जैसे PNG) के रूप में [निर्यात](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/get_image/) कर सकते हैं।
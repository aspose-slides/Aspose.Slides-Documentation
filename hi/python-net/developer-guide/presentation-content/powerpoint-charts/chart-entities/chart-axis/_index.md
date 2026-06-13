---
title: Python के साथ प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/python-net/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को हेरफेर करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में रिपोर्ट और दृश्यावलोकन के लिए चार्ट अक्षों को कैसे अनुकूलित किया जाए, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट अक्षों को अनुकूलित करने का तरीका समझाता है। यह दिखाता है कि वास्तविक अक्ष मान कैसे प्राप्त किए जाएँ, अक्षों के बीच डेटा कैसे बदला जाए, लाइन चार्ट के लिए लंबवत या क्षैतिज अक्ष को कैसे छिपाया जाए, श्रेणी अक्ष का प्रकार कैसे बदला जाए, श्रेणी अक्ष मानों के लिए तिथि स्वरूप कैसे सेट किया जाए, अक्ष शीर्षक को कैसे घुमाया जाए, अक्ष की स्थिति कैसे निर्धारित करें, और मान अक्ष पर इकाई लेबल कैसे दिखाएँ।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करना**
Aspose.Slides for Python via .NET आपको लंबवत अक्ष पर न्यूनतम और अधिकतम मान प्राप्त करने की अनुमति देता है। इन चरणों को अपनाएँ:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
4. अक्ष पर वास्तविक अधिकतम मान प्राप्त करें।
5. अक्ष पर वास्तविक न्यूनतम मान प्राप्त करें।
6. अक्ष की वास्तविक प्रमुख इकाई प्राप्त करें।
7. अक्ष की वास्तविक गौण इकाई प्राप्त करें।
8. अक्ष के वास्तविक प्रमुख इकाई स्केल को प्राप्त करें।
9. अक्ष के वास्तविक गौण इकाई स्केल को प्राप्त करें।

यह नमूना कोड—ऊपर वर्णित चरणों का कार्यान्वयन—आपको बताता है कि Python में आवश्यक मान कैसे प्राप्त करें:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# प्रस्तुति को सहेजता है
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्षों के बीच डेटा बदलना**
Aspose.Slides आपको जल्दी से अक्षों के बीच डेटा स्वैप करने की अनुमति देता है—लंबवत अक्ष (y-अक्ष) पर प्रदर्शित डेटा क्षैतिज अक्ष (x-अक्ष) पर चला जाता है और इसके विपरीत।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# खाली प्रस्तुति बनाता है
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #पंक्तियों और स्तंभों को बदलता है
    chart.chart_data.switch_row_column()
            
    # प्रस्तुति सहेजता है
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **लाइन चार्ट के लिए लंबवत अक्ष अक्षम करना**

यह Python कोड आपको दिखाता है कि लाइन चार्ट के लिए लंबवत अक्ष को कैसे छिपाया जाए:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष अक्षम करना**

यह कोड आपको दिखाता है कि लाइन चार्ट के लिए क्षैतिज अक्ष को कैसे छिपाया जाए:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी अक्ष बदलना**

**CategoryAxisType** प्रॉपर्टी का उपयोग करके आप अपनी पसंदीदा श्रेणी अक्ष प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। यह Python कोड इस ऑपरेशन को दर्शाता है:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी अक्ष मान के लिए तिथि स्वरूप सेट करना**
Aspose.Slides for Python via .NET आपको श्रेणी अक्ष मान के लिए तिथि स्वरूप सेट करने की अनुमति देता है। यह ऑपरेशन इस Python कोड में दर्शाया गया है:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करना**
Aspose.Slides for Python via .NET आपको चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करने की अनुमति देता है। यह Python कोड इस ऑपरेशन को दर्शाता है:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी या मान अक्ष में स्थिति सेट करना**
Aspose.Slides for Python via .NET आपको श्रेणी या मान अक्ष में स्थिति अक्ष सेट करने की अनुमति देता है। यह Python कोड दर्शाता है कि कार्य कैसे किया जाए:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट मान अक्ष में डिस्प्ले यूनिट लेबल सक्षम करना**
Aspose.Slides for Python via .NET आपको चार्ट को इस तरह कॉन्फ़िगर करने की अनुमति देता है कि वह अपने मान अक्ष पर इकाई लेबल दिखाए। यह Python कोड इस ऑपरेशन को दर्शाता है:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष को दूसरे के साथ जहाँ प्रतिच्छेद करता है (अक्ष प्रतिच्छेदन) उस मान को कैसे सेट करूँ?**

अक्ष एक [क्रॉसिंग सेटिंग](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/axis/cross_type/) प्रदान करते हैं: आप शून्य पर, अधिकतम श्रेणी/मान पर, या किसी विशिष्ट संख्यात्मक मान पर प्रतिच्छेद चुन सकते हैं। यह X-अक्ष को ऊपर या नीचे ले जाने या बेसलाइन को ज़ोर देने में उपयोगी है।

**मैं टिक लेबल को अक्ष के सापेक्ष (साथ में, बाहर, अंदर) कैसे स्थिति दे सकता हूँ?**

[लेबल स्थिति](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/axis/major_tick_mark/) को "cross", "outside" या "inside" पर सेट करें। यह पठनीयता को प्रभावित करता है और विशेषकर छोटे चार्ट्स में स्थान बचाने में मदद करता है।
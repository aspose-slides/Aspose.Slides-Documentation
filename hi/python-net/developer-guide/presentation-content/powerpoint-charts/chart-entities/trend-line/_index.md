---
title: Python में प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/python-net/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्सपोनेंशियल ट्रेंड लाइन
- लीनियर ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग एवरज ट्रेंड लाइन
- पॉलीनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint चार्ट में ट्रेंड लाइन्स को जल्दी से जोड़ें और कस्टमाइज़ करें — अपने दर्शकों को जोड़े रखने के लिए एक व्यावहारिक गाइड।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन जोड़ने के तरीके को समझाता है। यह दिखाता है कि कैसे एक चार्ट बनाएं, चार्ट सीरीज़ में ट्रेंड लाइन जोड़ें, और कई ट्रेंड लाइन प्रकारों के साथ काम करें, जिसमें एक्सपोनेंशियल, लीनियर, लॉगरिदमिक, मूविंग एवरज, पॉलीनॉमियल और पावर शामिल हैं।

यह भी वर्णन करता है कि कैसे एक लाइन शेप डालकर चार्ट में कस्टम लाइन जोड़ें, और फ़ॉरवर्ड और बैकवर्ड ट्रेंड लाइन प्रोजेक्शन मूल्यों तथा PDF या SVG में निर्यात के दौरान ट्रेंड लाइन्स के संरक्षित रहने और चार्ट को छवि के रूप में रेंडर करने के बारे में एक संक्षिप्त FAQ शामिल है।

## **ट्रेंड लाइन जोड़ें**

एक चार्ट सीरीज़ में ट्रेंड लाइन जोड़ने के लिए [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) का उपयोग करें, और उसका प्रकार [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/) से चुनें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और इसकी प्रत्येक तीन सीरीज़ में दो ट्रेंड लाइन्स जोड़ता है।

एक्सपोनेंशियल ट्रेंड लाइन अपनी समीकरण और R-स्क्वेयर मान को [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) और [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/) के माध्यम से छिपाती है, जबकि लीनियर ट्रेंड लाइन रेड है। लॉगरिदमिक ट्रेंड लाइन कस्टम लेबल के लिए [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) का उपयोग करती है। मूविंग एवरज तीन डेटा पॉइंट्स की [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) और एक कस्टम [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) का उपयोग करता है।

पॉलीनॉमियल ट्रेंड लाइन का [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) तीन है और यह एक श्रेणी फ़ॉरवर्ड [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/) के माध्यम से विस्तारित होती है। पावर ट्रेंड लाइन एक श्रेणी बैकवर्ड [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/) के माध्यम से विस्तारित होती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **ट्रेंड लाइन इंटरसेप्ट सेट करें**

[intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) का उपयोग करके ट्रेंड लाइन के Y मान को X = 0 पर फिक्स करें। यह सेटिंग लीनियर, एक्सपोनेंशियल और पॉलीनॉमियल ट्रेंड लाइन्स के लिए समर्थित है।

उदाहरण के लिए, एक उत्पादन लागत मॉडल को ज्ञात फिक्स्ड कॉस्ट 100 से शुरू होना पड़ सकता है, भले ही शून्य नहीं होने वाले उत्पादन वॉल्यूम पर माप अलग बेसलाइन सुझाते हों। लीनियर ट्रेंड लाइन के लिए, इंटरसेप्ट फिक्स करने से समीकरण `y = ax + b` को `b = 100` तक सीमित किया जाता है; ढलान उस प्रतिबंध के तहत डेटा के अनुरूप फिट की जाती है। यह केवल पहले से फिट की गई रेखा को नहीं बदलेगा। एक्सिस क्रॉसिंग सेटिंग्स चार्ट अक्षों के मिलन बिंदु को नियंत्रित करती हैं, न कि फिटेड ट्रेंड लाइन के गुणांक को।

निम्न उदाहरण 1 से 4 तक के उत्पादन वॉल्यूम और 170, 200, 230, तथा 260 लागत के साथ एक स्कैटर (XY) चार्ट बनाता है। यह चार्ट को डिफ़ॉल्ट ऑटोमेटिक इंटरसेप्ट के साथ सहेजता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरी PPTX फ़ाइल सहेजता है। दोनों फ़ाइलें केवल इंटरसेप्ट सेटिंग में अंतर रखती हैं। ट्रेंड लाइन अपना समीकरण दिखाती है और X = 0 तक पीछे की ओर विस्तारित होती है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

ऑटोमेटिक गणना के साथ, यह डेटा `y = 30x + 140` देता है। इंटरसेप्ट को 100 पर सेट करने से लगभग `y = 43.33x + 100` प्राप्त होता है: शून्य पर फिटेड मान ज्ञात बेसलाइन से मेल खाता है, जबकि रेखा अब प्रत्येक डेटा पॉइंट से नहीं गुज़रती।

| ऑटोमेटिक इंटरसेप्ट | 100 का फिक्स्ड इंटरसेप्ट |
| --- | --- |
| ![ऑटोमैटिक रूप से गणना किया गया इंटरसेप्ट 140 के साथ लीनियर ट्रेंड लाइन](intercept-automatic.png) | ![फिक्स्ड इंटरसेप्ट 100 के साथ लीनियर ट्रेंड लाइन](intercept-fixed.png) |

दोनों छवियों में समान डेटा और एक्सिस स्केल उपयोग किए गए हैं। ट्रेंड लाइन्स X = 0 तक पीछे की ओर विस्तारित की गई हैं ताकि उनका इंटरसेप्ट दिखाया जा सके।

डिफ़ॉल्ट रूप से, प्रॉपर्टी में `float("nan")` होता है, जो शून्य के बजाय अनिर्दिष्ट इंटरसेप्ट को दर्शाता है। इंटरसेप्ट फिर डेटा से स्वचालित रूप से गणना किया जाता है।

## **कस्टम लाइन जोड़ें**

कस्टम लाइन एक शेप है जो चार्ट के ऊपर खींची जाती है, न कि सीरीज़ डेटा से गणना की गई ट्रेंड लाइन। यह उदाहरण [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) का उपयोग करके चार्ट के ऊपर स्लाइड में एक क्षैतिज लाइन जोड़ता है। लाइन का स्थान स्लाइड निर्देशांकों में पॉइंट्स में निर्दिष्ट किया जाता है, इसलिए यह चार्ट के बाएँ किनारे से शुरू होती है और चार्ट के आधे हिस्से में नीचे स्थित होती है। इसकी चौड़ाई चार्ट की चौड़ाई के बराबर होती है। [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) लाइन को एक ठोस लाल रंग देता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**ट्रेंड लाइन के लिए 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

वे ट्रेंड लाइन की लंबाई को दर्शाते हैं जो आगे/पीछे प्रोजेक्ट की जाती है: स्कैटर (XY) चार्ट के लिए — अक्ष इकाइयों में; गैर-स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर-नकारात्मक मान ही अनुमति है।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को छवि में रेंडर करने के समय ट्रेंड लाइन संरक्षित रहती है?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/python-net/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को छवियों में रेंडर करता है; ट्रेंड लाइन्स, चार्ट का हिस्सा होने के नाते, इन कार्यों के दौरान संरक्षित रहती हैं। चार्ट की स्वयं की छवि को निर्यात करने के लिए भी एक मेथड उपलब्ध है: [export an image of the chart](/slides/hi/python-net/create-shape-thumbnails/).
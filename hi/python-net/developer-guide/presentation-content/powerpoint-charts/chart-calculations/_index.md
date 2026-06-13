---
title: Python में प्रस्तुतियों के लिए चार्ट गणनाओं का अनुकूलन
linktitle: चार्ट गणनाएँ
type: docs
weight: 50
url: /hi/python-net/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व स्थिति
- वास्तविक स्थिति
- बाल तत्व
- पैरेंट तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में PPT, PPTX और ODP के लिए चार्ट गणनाओं, डेटा अद्यतन और सटीकता नियंत्रण को व्यावहारिक कोड उदाहरणों के साथ समझें।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतियों में चार्ट गणनाएँ और लेआउट डेटा के साथ काम करने के लिए API प्रदान करता है। यह लेख दर्शाता है कि चार्ट तत्वों के वास्तविक मानों को कैसे प्राप्त करें, जिसमें `ActualLayout` को लागू करने वाले तत्वों की वास्तविक स्थिति और आकार तथा चार्ट अक्षों के वास्तविक मान शामिल हैं। यह भी समझाता है कि ये मान चार्ट लेआउट सत्यापन के बाद स्थापित होते हैं।

इसके अलावा, लेख दर्शाता है कि पैरेंट चार्ट तत्वों की वास्तविक स्थिति कैसे प्राप्त करें और शीर्षक, अक्ष, लेजेंड और ग्रिड रेखाओं जैसे चार्ट घटकों को कैसे छुपाएँ। ये उदाहरण मिलकर आपको कार्यक्रमात्मक रूप से PowerPoint प्रस्तुतियों में चार्ट लेआउट जानकारी की जांच करने और चार्ट तत्वों की दृश्यता को नियंत्रित करने में मदद करते हैं।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **चार्ट तत्वों के वास्तविक मानों की गणना**

Aspose.Slides for Python via .NET इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। यह आपको चार्ट तत्वों के वास्तविक मानों की गणना करने में मदद करेगा। वास्तविक मानों में उन तत्वों की स्थिति शामिल है जो [IActualLayout](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/iactuallayout/) क्लास को विरासत में लेते हैं (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) और वास्तविक अक्ष मान (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale)।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **पैरेंट चार्ट तत्वों की वास्तविक स्थिति की गणना**

Aspose.Slides for Python via .NET इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। IActualLayout के गुण पैरेंट चार्ट तत्व की वास्तविक स्थिति के बारे में जानकारी प्रदान करते हैं। वास्तविक मानों से गुणों को भरने के लिए पहले IChart.ValidateChartLayout() मेथड को कॉल करना आवश्यक है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # चार्ट शीर्षक छुपाना
    chart.has_title = False

    # मान अक्ष छुपाना
    chart.axes.vertical_axis.is_visible = False

    # श्रेणी अक्ष दृश्यता
    chart.axes.horizontal_axis.is_visible = False

    # लेजेंड छुपाना
    chart.has_legend = False

    # मुख्य ग्रिड रेखाएँ छुपाना
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # श्रृंखला रेखा का रंग सेट करना
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट से जानकारी छुपाएँ**

यह विषय आपको समझने में मदद करता है कि चार्ट से जानकारी कैसे छुपाएँ। Aspose.Slides for Python via .NET का उपयोग करके आप चार्ट से **Title, Vertical Axis, Horizontal Axis** और **Grid Lines** को छुपा सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि इन गुणों का उपयोग कैसे करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी Excel कार्यपुस्तिकाएँ डेटा स्रोत के रूप में काम करती हैं, और इसका पुनःगणना पर क्या असर पड़ता है?**

हाँ। एक चार्ट बाहरी कार्यपुस्तिका को संदर्भित कर सकता है: जब आप बाहरी स्रोत से कनेक्ट या रीफ़्रेश करते हैं, तो सूत्र और मान उस कार्यपुस्तिका से लिए जाते हैं, और चार्ट खुले/संपादित करने के दौरान अपडेट को दर्शाता है। API आपको [बाहरी कार्यपुस्तिका निर्दिष्ट करें](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) पथ को सेट करने और लिंक्ड डेटा का प्रबंधन करने की सुविधा देती है।

**क्या मैं स्वयं रिग्रेशन लागू किए बिना ट्रेंडलाइन की गणना और प्रदर्शन कर सकता हूँ?**

हाँ। [ट्रेंडलाइन](/slides/hi/python-net/trend-line/) (लीनियर, एक्सपोनेंशियल और अन्य) Aspose.Slides द्वारा जोड़ी और अपडेट की जाती हैं; उनके पैरामीटर सीरीज़ डेटा से स्वतः पुनःगणना होते हैं, इसलिए आपको अपना स्वयं का गणना लागू करने की आवश्यकता नहीं है।

**यदि एक प्रस्तुति में कई चार्ट बाहरी लिंक के साथ हैं, तो क्या मैं नियंत्रित कर सकता हूँ कि प्रत्येक चार्ट कौन सी कार्यपुस्तिका का उपयोग गणना किए गए मानों के लिए करता है?**

हाँ। प्रत्येक चार्ट अपने स्वयं के [बाहरी कार्यपुस्तिका](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) की ओर इंगित कर सकता है, या आप प्रत्येक चार्ट के लिए स्वतंत्र रूप से एक बाहरी कार्यपुस्तिका बना/बदल सकते हैं।
---
title: Python के साथ प्रस्तुतियों में 3D चार्ट को अनुकूलित करें
linktitle: 3D चार्ट
type: docs
url: /hi/python-net/3d-chart/
keywords:
- 3D चार्ट
- रोटेशन
- गहराई
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में 3-D चार्ट को बनाने और अनुकूलित करने का तरीका सीखें, PPT, PPTX और ODP फ़ाइलों के समर्थन के साथ—आज ही अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **समीक्षा**

यह लेख बताता है कि Aspose.Slides में `rotation_3d` सेटिंग्स जैसे `rotation_x`, `rotation_y`, `depth_percents`, और `right_angle_axes` को कॉन्फ़िगर करके 3D चार्ट को कैसे कस्टमाइज़ किया जाए। यह एक प्रेजेंटेशन बनाना, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ना, आवश्यक 3D व्यू सेटिंग्स लागू करना, और संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करने की प्रक्रिया को दर्शाता है।

## **3D चार्ट के RotationX, RotationY और DepthPercents गुण सेट करें**
Aspose.Slides for Python via .NET इन गुणों को सेट करने के लिए एक सरल API प्रदान करता है। यह लेख आपको X, Y Rotation, **DepthPercents** आदि जैसे विभिन्न गुणों को कैसे सेट किया जाए, यह समझाने में मदद करेगा। नमूना कोड उपर्युक्त गुणों को सेट करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. Rotation3D गुण सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का एक उदाहरण बनाएं
with slides.Presentation() as presentation:
            
    # पहली स्लाइड तक पहुँचें
    slide = presentation.slides[0]

    # डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # चार्ट डेटा शीट का इंडेक्स सेट करना
    defaultWorksheetIndex = 0

    # चार्ट डेटा वर्कशीट प्राप्त करना
    fact = chart.chart_data.chart_data_workbook

    # सीरीज़ जोड़ें
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # श्रेणियां जोड़ें
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Rotation3D गुण सेट करें
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # दूसरी चार्ट सीरीज़ लें
    series = chart.chart_data.series[1]

    # अब सीरीज़ डेटा भर रहे हैं
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Overlap मान सेट करें
    series.parent_series_group.overlap = 100         

    # प्रेजेंटेशन को डिस्क पर लिखें
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वैरिएंट्स का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) एन्यूमरेशन के माध्यम से उपलब्ध कराए गए हैं। सटीक और अद्यतन सूची के लिए, अपने स्थापित संस्करण के API रेफरेंस में [ChartType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर इमेज प्राप्त कर सकता हूँ?**

हाँ। आप चार्ट को इमेज में [chart API](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/get_image/) के माध्यम से एक्सपोर्ट कर सकते हैं या पूरे स्लाइड को [/slides/hi/python-net/convert-powerpoint-to-png/](/slides/hi/python-net/convert-powerpoint-to-png/) पर PNG या JPEG जैसे फ़ॉर्मेट में रेंडर कर सकते हैं। यह तब उपयोगी होता है जब आपको पिक्सेल-परफेक्ट प्रीव्यू चाहिए या आप चार्ट को दस्तावेज़ों, डैशबोर्ड या वेब पेजों में एम्बेड करना चाहते हैं बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट बनाने और रेंडर करने में प्रदर्शन कैसे रहता है?**

प्रदर्शन डेटा मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए, 3D इफ़ेक्ट्स को न्यूनतम रखें, दीवारों और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक सीरीज में डेटा पॉइंट्स की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुरूप उपयुक्त रिज़ॉल्यूशन और आकार के आउटपुट में रेंडर करें।
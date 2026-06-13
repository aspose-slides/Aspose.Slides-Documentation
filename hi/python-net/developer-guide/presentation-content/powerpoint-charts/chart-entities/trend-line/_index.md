---
title: Python में प्रस्तुति चार्ट्स में ट्रेंड लाइनों को जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/python-net/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- घातीय ट्रेंड लाइन
- रैखिक ट्रेंड लाइन
- लघुगणक ट्रेंड लाइन
- चल औसत ट्रेंड लाइन
- बहुपद ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument चार्ट्स में Aspose.Slides for Python via .NET के साथ ट्रेंड लाइनों को जल्दी जोड़ें और अनुकूलित करें — भविष्यवाणी की सटीकता सुधारने और अपने दर्शकों को जोड़ने के लिए एक व्यावहारिक मार्गदर्शिका और कोड उदाहरण।"
---
## **अवलोकन**

यह आलेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइनों को जोड़ने के तरीके को समझाता है। यह दर्शाता है कि चार्ट कैसे बनाएं, चार्ट श्रृंखला में ट्रेंड लाइनों को जोड़ें, और घातीय, रैखिक, लघुगणक, चल औसत, बहुपद, तथा पावर सहित विभिन्न ट्रेंड लाइन प्रकारों के साथ कैसे काम करें।

यह भी बताता है कि कैसे एक कस्टम लाइन को चार्ट में लाइन आकार डालकर जोड़ें, और फ़ॉरवर्ड तथा बैकवर्ड ट्रेंडलाइन प्रक्षेपण मानों के बारे में एक छोटा FAQ शामिल है, तथा क्या ट्रेंड लाइनों को PDF या SVG में निर्यात करने या चार्ट को छवि के रूप में रेंडर करने पर संरक्षित रखा जाता है।

## **ट्रेंड लाइन जोड़ें**
Aspose.Slides for Python via .NET विभिन्न चार्ट ट्रेंड लाइनों को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार का एक चार्ट जोड़ें (इस उदाहरण में ChartType.CLUSTERED_COLUMN उपयोग किया गया है)।
1. चार्ट श्रृंखला 1 के लिए घातीय ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 1 के लिए रैखिक ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 2 के लिए लघुगणक ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 2 के लिए चल औसत ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 3 के लिए बहुपद ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 3 के लिए पावर ट्रेंड लाइन जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

निम्न कोड ट्रेंड लाइनों के साथ एक चार्ट बनाने के लिए उपयोग किया गया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# खाली प्रस्तुति बना रहे हैं
with slides.Presentation() as pres:

    # एक क्लस्टर्ड कॉलम चार्ट बना रहे हैं
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # चार्ट श्रृंखला 1 के लिए घातीय ट्रेंड लाइन जोड़ रहे हैं
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # चार्ट श्रृंखला 1 के लिए रैखिक ट्रेंड लाइन जोड़ रहे हैं
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # चार्ट श्रृंखला 2 के लिए लघुगणक ट्रेंड लाइन जोड़ रहे हैं
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # चार्ट श्रृंखला 2 के लिए चल औसत ट्रेंड लाइन जोड़ रहे हैं
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # चार्ट श्रृंखला 3 के लिए बहुपद ट्रेंड लाइन जोड़ रहे हैं
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # चार्ट श्रृंखला 3 के लिए पावर ट्रेंड लाइन जोड़ रहे हैं
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # प्रस्तुति सहेज रहे हैं
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **कस्टम लाइन जोड़ें**
Aspose.Slides for Python via .NET चार्ट में कस्टम लाइनों को जोड़ने के लिए एक सरल API प्रदान करता है। प्रस्तुति की चयनित स्लाइड पर एक साधारण सी लाइन जोड़ने के लिए नीचे दिए चरणों का पालन करें:

- Presentation वर्ग का एक उदाहरण बनाएं
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddChart मेथड का उपयोग करके नया चार्ट बनाएं
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके लाइन प्रकार की AutoShape जोड़ें
- आकार की लाइनों का रंग सेट करें
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

निम्न कोड कस्टम लाइनों के साथ एक चार्ट बनाने के लिए उपयोग किया गया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ट्रेंडलाइन के लिए 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या मतलब है?**

ये ट्रेंडलाइन की वह लंबाई है जो आगे/पीछे प्रोजेक्ट की जाती है: स्कैटर (XY) चार्ट के लिए — अक्ष इकाइयों में; गैर‑स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर‑नकारात्मक मान स्वीकार्य हैं।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को छवि के रूप में रेंडर करने पर ट्रेंडलाइन संरक्षित रहती है?**

हां। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/hi/python-net/render-a-slide-as-an-svg-image/) में बदलता है और चार्ट को छवियों में रेंडर करता है; ट्रेंडलाइन, जो चार्ट का भाग हैं, इन कार्यों के दौरान संरक्षित रहती हैं। एक मेथड भी उपलब्ध है जो चार्ट की स्वयं की छवि को [एक्सपोर्ट](/slides/hi/python-net/create-shape-thumbnails/) करता है।
---
title: "Python के साथ प्रस्तुति चार्ट में त्रुटि बार को अनुकूलित करें"
linktitle: "त्रुटि बार"
type: docs
url: /hi/python-net/error-bar/
keywords:
- त्रुटि बार
- कस्टम मान
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ चार्ट में त्रुटि बार जोड़ना और अनुकूलित करना सीखें—PowerPoint और OpenDocument प्रस्तुतियों में डेटा विज़ुअल्स को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार के साथ काम करने का तरीका समझाता है। यह दिखाता है कि चार्ट सीरीज़ में त्रुटि बार कैसे जोड़ें, X और Y त्रुटि बार सेटिंग्स को कॉन्फ़िगर करें, तथा स्थिर, प्रतिशत और कस्टम मान जैसे विभिन्न मान प्रकारों को लागू करें।

यह यह भी दर्शाता है कि एक सीरीज़ में व्यक्तिगत डेटा पॉइंट्स के लिए संबंधित डेटा पॉइंट संग्रह का उपयोग करके कस्टम त्रुटि बार मान कैसे असाइन करें। अतिरिक्त रूप से, लेख में त्रुटि बार के निर्यात के दौरान व्यवहार, मार्कर्स और डेटा लेबल्स के साथ उनके अनुकूलता, और संबंधित API रेफ़रेंस क्लासेज़ और एन्यूम्स को कहाँ ढूँढ़ें, इस पर संक्षिप्त नोट्स शामिल हैं।

## **त्रुटि बार जोड़ें**
Aspose.Slides for Python via .NET त्रुटि बार मानों को प्रबंधित करने के लिए एक साधारण API प्रदान करता है। यह नमूना कोड कस्टम मान प्रकार का उपयोग करने पर लागू होता है। किसी मान को निर्दिष्ट करने के लिए, सीरीज़ के **DataPoints** संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का प्रयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. बार मानों और फ़ॉर्मेट को सेट करना।
1. परिवर्तित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# खाली प्रस्तुति बनाना
with slides.Presentation() as presentation:
    # बबल चार्ट बनाना
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # त्रुटि बार जोड़ना और उसका फ़ॉर्मेट सेट करना
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # प्रस्तुति सहेजना
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **कस्टम त्रुटि बार मान जोड़ें**
Aspose.Slides for Python via .NET कस्टम त्रुटि बार मानों को प्रबंधित करने के लिए एक साधारण API प्रदान करता है। यह नमूना कोड तब लागू होता है जब **IErrorBarsFormat.ValueType** प्रॉपर्टी **Custom** के बराबर हो। किसी मान को निर्दिष्ट करने के लिए, सीरीज़ के **DataPoints** संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का प्रयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. चार्ट सीरीज़ के व्यक्तिगत डेटा पॉइंट्स तक पहुँचें और प्रत्येक डेटा पॉइंट के लिए त्रुटि बार मान सेट करें।
1. बार मानों और फ़ॉर्मेट को सेट करना।
1. परिवर्तित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# खाली प्रस्तुति बनाना
with slides.Presentation() as presentation:
    # बबल चार्ट बनाना
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # कस्टम त्रुटि बार जोड़ना और उसका फ़ॉर्मेट सेट करना
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # चार्ट सीरीज़ डेटा पॉइंट तक पहुँचना और व्यक्तिगत बिंदु के लिए त्रुटि बार मान सेट करना
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # चार्ट सीरीज़ बिंदुओं के लिए त्रुटि बार सेट करना
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # प्रस्तुति सहेजना
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रस्तुति को PDF या छवियों में निर्यात करने पर त्रुटि बार का क्या होता है?**

वे चार्ट का हिस्सा बनकर रेंडर होते हैं और रूपांतरण के दौरान चार्ट के शेष फ़ॉर्मेटिंग के साथ संरक्षित रहते हैं, बशर्ते उपयुक्त संस्करण या रेंडरर उपलब्ध हो।

**क्या त्रुटि बार को मार्कर्स और डेटा लेबल्स के साथ संयोजित किया जा सकता है?**

हां। त्रुटि बार एक अलग तत्व है और मार्कर्स तथा डेटा लेबल्स के साथ संगत है; यदि तत्व ओवरलैप हो जाएँ, तो आपको फ़ॉर्मेटिंग समायोजित करनी पड़ सकती है।

**API में त्रुटि बार के साथ काम करने के लिए प्रॉपर्टीज़ और एन्यूम्स की सूची कहाँ उपलब्ध है?**

API रेफ़रेंस में: [ErrorBarsFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/errorbarsformat/) क्लास तथा संबंधित एन्यूम्स [ErrorBarType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/errorbartype/) और [ErrorBarValueType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/errorbarvaluetype/)।
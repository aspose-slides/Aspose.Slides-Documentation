---
title: Python का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार को अनुकूलित करें
linktitle: त्रुटि बार
type: docs
url: /hi/python-java/error-bar/
keywords:
- त्रुटि बार
- कस्टम मान
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ चार्ट में त्रुटि बार जोड़ना और अनुकूलित करना सीखें—PowerPoint प्रस्तुतियों में डेटा दृश्य को अनुकूलित करें।"
---
## **Overview**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार के साथ काम करने की विधि को समझाता है। यह दर्शाता है कि चार्ट श्रृंखला में त्रुटि बार कैसे जोड़े जाएँ, X और Y त्रुटि बार सेटिंग्स को कैसे कॉन्फ़िगर किया जाए, और निश्चित, प्रतिशत, तथा कस्टम मान जैसी विभिन्न मान प्रकारों को कैसे लागू किया जाए।

यह भी दिखाता है कि श्रृंखला के व्यक्तिगत डेटा पॉइंट के लिए समानांतर त्रुटि बार मान कैसे निर्धारित किए जाएँ, इसके लिए संबंधित डेटा पॉइंट संग्रह का उपयोग किया जाता है। साथ ही, लेख में त्रुटि बार के निर्यात के दौरान व्यवहार, उनके मार्कर और डेटा लेबल के साथ संगतता, और संबंधित API रेफ़रेंस क्लासेस और एनेम्स कहाँ मिलेंगे, इस पर संक्षिप्त नोट्स शामिल हैं।

## **Add Error Bars**

Aspose.Slides for Python via Java त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। निम्नलिखित नमूना कोड निश्चित और प्रतिशत मान प्रकारों का उपयोग करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. इच्छित स्लाइड में एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. त्रुटि बार मान और फ़ॉर्मेटिंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation क्लास का एक उदाहरण बनाएँ।
presentation = Presentation()
try:
    # एक बबल चार्ट बनाएँ।
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # त्रुटि बार जोड़ें और उनका फ़ॉर्मेट सेट करें।
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # प्रस्तुति को सहेजें।
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add Custom Error Bar Values**

Aspose.Slides for Python via Java कस्टम त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। निम्नलिखित नमूना कोड तब लागू होता है जब [getValueType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/errorbarsformat/#getValueType) [ErrorBarValueType.Custom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/errorbarvaluetype/#Custom) लौटाता है। किसी मान को निर्दिष्ट करने के लिए, श्रृंखला विधि [getDataPoints](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getDataPoints) द्वारा लौटाए गए संग्रह में एक विशिष्ट डेटा पॉइंट के लिए [getErrorBarsCustomValues](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) का उपयोग करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. इच्छित स्लाइड में एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहले चार्ट सीरीज़ तक पहुँचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. चार्ट सीरीज़ में व्यक्तिगत डेटा पॉइंट्स तक पहुँचें और उनके त्रुटि बार मान सेट करें।
1. त्रुटि बार मान और फ़ॉर्मेटिंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation क्लास का एक उदाहरण बनाएँ।
presentation = Presentation()
try:
    # एक बबल चार्ट बनाएँ।
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # कस्टम त्रुटि बार जोड़ें और उनका फ़ॉर्मेट सेट करें।
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # चार्ट श्रृंखला के डेटा पॉइंट्स तक पहुँचें और उनके त्रुटि बार मान स्रोतों को कॉन्फ़िगर करें।
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # चार्ट श्रृंखला के डेटा पॉइंट्स के लिए त्रुटि बार मान सेट करें।
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # प्रस्तुति को सहेजें।
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**एक प्रस्तुति को PDF या इमेज़ में निर्यात करते समय त्रुटि बार का क्या होता है?**

वे चार्ट का हिस्सा बनकर रेंडर होते हैं और चार्ट फ़ॉर्मेटिंग के साथ रूपांतरण के दौरान संरक्षित रहते हैं, बशर्ते उपयोग किया गया संस्करण या रेंडरर संगत हो।

**क्या त्रुटि बार को मार्कर और डेटा लेबल के साथ जोड़ा जा सकता है?**

हाँ। त्रुटि बार एक अलग तत्व है और मार्कर तथा डेटा लेबल के साथ संगत है; यदि तत्व ओवरलैप हों तो फ़ॉर्मेटिंग को समायोजित करना पड़ सकता है।

**API में त्रुटि बार के साथ काम करने के लिए गुणों और क्लासों की सूची कहाँ मिल सकती है?**

API रेफ़रेंस में: [ErrorBarsFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/errorbarsformat/) क्लास तथा संबंधित क्लासें [ErrorBarType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/errorbartype/) और [ErrorBarValueType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/errorbarvaluetype/)।
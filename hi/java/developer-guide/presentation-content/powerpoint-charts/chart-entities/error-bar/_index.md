---
title: जावा का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार को अनुकूलित करें
linktitle: त्रुटि बार
type: docs
url: /hi/java/error-bar/
keywords:
- त्रुटि बार
- कस्टम मान
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ चार्ट में त्रुटि बार को जोड़ना और अनुकूलित करना सीखें—PowerPoint प्रस्तुतियों में डेटा विज़ुअल को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार के साथ काम करने का तरीका बताता है। यह दिखाता है कि चार्ट श्रृंखला में त्रुटि बार कैसे जोड़ें, X और Y त्रुटि बार सेटिंग्स को कॉन्फ़िगर करें, और निश्चित, प्रतिशत, और कस्टम मान जैसी विभिन्न मान प्रकारों को लागू करें।

यह भी दिखाता है कि श्रृंखला में व्यक्तिगत डेटा बिंदुओं के लिए कस्टम त्रुटि बार मान कैसे असाइन करें, संबंधित डेटा पॉइंट कलेक्शन का उपयोग करके। इसके अतिरिक्त, लेख में त्रुटि बार के निर्यात के दौरान व्यवहार, मार्कर और डेटा लेबल्स के साथ उनकी संगतता, और संबंधित API संदर्भ वर्गों और एन्यूम्स को कहाँ पा सकते हैं, के बारे में संक्षिप्त नोट्स शामिल हैं।

## **Add Error Bars**
Aspose.Slides for Java त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब कस्टम मान प्रकार का उपयोग किया जाता है। मान निर्दिष्ट करने के लिए, श्रृंखला की [**DataPoints**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeriesCollection) संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. बार मानों और फ़ॉर्मेट को सेट करना।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // एक बबल चार्ट बनाना
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // त्रुटि बार जोड़ना और उसका फ़ॉर्मेट सेट करना
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // प्रस्तुति सहेजें
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Custom Error Bar Values**
Aspose.Slides for Java कस्टम त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IErrorBarsFormat#getValue--) प्रॉपर्टी **Custom** के बराबर हो। मान निर्दिष्ट करने के लिए, श्रृंखला की [**DataPoints**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeriesCollection) संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. चार्ट श्रृंखला के व्यक्तिगत डेटा पॉइंट्स तक पहुँचें और व्यक्तिगत श्रृंखला डेटा पॉइंट के लिए त्रुटि बार मान सेट करें।
1. बार मानों और फ़ॉर्मेट को सेट करना।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // एक बबल चार्ट बनाना
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // कस्टम त्रुटि बार जोड़ना और उसका फ़ॉर्मेट सेट करना
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // चार्ट श्रृंखला डेटा पॉइंट तक पहुँचना और त्रुटि बार मान सेट करना
    // व्यक्तिगत बिंदु
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // चार्ट श्रृंखला बिंदुओं के लिए त्रुटि बार सेट करना
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // प्रस्तुति सहेजना
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**जब प्रस्तुति को PDF या छवियों में निर्यात किया जाता है तो त्रुटि बार का क्या होता है?**

वे चार्ट के भाग के रूप में रेंडर होते हैं और रूपांतरण के दौरान चार्ट फ़ॉर्मेटिंग के शेष भाग के साथ संरक्षित रहते हैं, बशर्ते उपयुक्त संस्करण या रेंडरर हो।

**क्या त्रुटि बार को मार्कर्स और डेटा लेबल्स के साथ संयोजित किया जा सकता है?**

हाँ। त्रुटि बार एक अलग तत्व है और मार्कर्स तथा डेटा लेबल्स के साथ संगत है; यदि तत्व ओवरलैप होते हैं, तो आपको फ़ॉर्मेटिंग को समायोजित करना पड़ सकता है।

**API में त्रुटि बार के साथ काम करने के लिए प्रॉपर्टीज़ और क्लासेस की सूची मुझे कहाँ मिल सकती है?**

API संदर्भ में: [ErrorBarsFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/errorbarsformat/) क्लास और संबंधित क्लासेस [ErrorBarType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/errorbartype/) तथा [ErrorBarValueType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/errorbarvaluetype/)।
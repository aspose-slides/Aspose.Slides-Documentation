---
title: एंड्रॉइड पर प्रस्तुति चार्ट में त्रुटि पट्टियों को अनुकूलित करें
linktitle: त्रुटि बार
type: docs
url: /hi/androidjava/error-bar/
keywords:
- त्रुटि पट्टी
- कस्टम मान
- PowerPoint
- प्रस्तुतीकरण
- एंड्रॉइड
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ चार्ट में त्रुटि पट्टियों को जोड़ने और अनुकूलित करने के तरीके जानें—PowerPoint प्रस्तुतियों में डेटा दृश्य को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में त्रुटि पट्टियों के साथ काम करने का तरीका समझाता है। यह दिखाता है कि चार्ट श्रृंखला में त्रुटि पट्टियों को कैसे जोड़ें, X और Y त्रुटि पट्टी सेटिंग्स को कैसे कॉन्फ़िगर करें, और फ़िक्स्ड, प्रतिशत, तथा कस्टम मानों जैसे विभिन्न मान प्रकारों को कैसे लागू करें।

यह यह भी दर्शाता है कि श्रृंखला में व्यक्तिगत डेटा पॉइंट के लिए संबंधित डेटा पॉइंट संग्रह का उपयोग करके कस्टम त्रुटि पट्टी मानों को कैसे असाइन किया जाए। अतिरिक्त रूप से, लेख में निर्यात के दौरान त्रुटि पट्टियों के व्यवहार, मार्कर और डेटा लेबल के साथ उनकी अनुकूलता, और संबंधित API रेफ़रेंस क्लासेज़ और एनोमैज़ को कहां पाया जा सकता है, के संक्षिप्त नोट्स शामिल हैं।

## **त्रुटि पट्टियाँ जोड़ें**
Aspose.Slides for Android via Java त्रुटि पट्टी मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब कस्टम मान प्रकार का उपयोग किया जाता है। किसी मान को निर्दिष्ट करने के लिए, श्रृंखला की [**DataPoints**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeriesCollection) संग्रह में एक विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएँ।
1. वांछित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि पट्टी X फ़ॉर्मेट सेट करें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि पट्टी Y फ़ॉर्मेट सेट करें।
1. पट्टियों के मान और फ़ॉर्मेट निर्धारित करें।
1. संसोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // एक बबल चार्ट बनाना
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // त्रुटि पट्टियों को जोड़ना और उनका प्रारूप सेट करना
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

    // प्रस्तुति सहेजना
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **कस्टम त्रुटि पट्टी मान जोड़ें**
Aspose.Slides for Android via Java कस्टम त्रुटि पट्टी मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) प्रॉपर्टी **Custom** के बराबर हो। किसी मान को निर्दिष्ट करने के लिए, श्रृंखला की [**DataPoints**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeriesCollection) संग्रह में एक विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएँ।
1. वांछित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि पट्टी X फ़ॉर्मेट सेट करें।
1. पहली चार्ट श्रृंखला तक पहुँचें और त्रुटि पट्टी Y फ़ॉर्मेट सेट करें।
1. चार्ट श्रृंखला के व्यक्तिगत डेटा पॉइंट तक पहुँचें और प्रत्येक श्रृंखला डेटा पॉइंट के लिए त्रुटि पट्टी मान सेट करें।
1. पट्टियों के मान और फ़ॉर्मेट निर्धारित करें।
1. संसोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // एक बबल चार्ट बनाना
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // कस्टम त्रुटि पट्टियों को जोड़ना और उनका प्रारूप सेट करना
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // चार्ट श्रृंखला डेटा पॉइंट तक पहुंचना और त्रुटि पट्टियों के मान सेट करना
    // व्यक्तिगत बिंदु के लिए
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // चार्ट श्रृंखला बिंदुओं के लिए त्रुटि पट्टियां सेट करना
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

## **पूछे जाने वाले प्रश्न**

**प्रस्तुति को PDF या इमेज़ में निर्यात करते समय त्रुटि पट्टियों के साथ क्या होता है?**

वे चार्ट का हिस्सा बनकर रेंडर किए जाते हैं और रूपांतरण के दौरान चार्ट फ़ॉर्मेटिंग के बाकी हिस्सों के साथ संरक्षित रहते हैं, बशर्ते कि उपयुक्त संस्करण या रेंडरर हो।

**क्या त्रुटि पट्टियों को मार्कर और डेटा लेबल के साथ संयोजित किया जा सकता है?**

हां। त्रुटि पट्टियां एक अलग तत्व हैं और मार्कर तथा डेटा लेबल के साथ अनुकूल हैं; यदि तत्व ओवरलैप होते हैं, तो आपको फ़ॉर्मेटिंग समायोजित करनी पड़ सकती है।

**API में त्रुटि पट्टियों के साथ काम करने वाले गुणों और क्लासेज़ की सूची मैं कहां पा सकता हूं?**

API रेफ़रेंस में: [ErrorBarsFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/errorbarsformat/) क्लास तथा संबंधित क्लासेज़ [ErrorBarType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/errorbartype/) और [ErrorBarValueType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/errorbarvaluetype/)।
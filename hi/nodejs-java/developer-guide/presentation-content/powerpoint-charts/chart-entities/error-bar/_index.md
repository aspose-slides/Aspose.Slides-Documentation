---
title: "प्रस्तुति चार्ट में जावास्क्रिप्ट का उपयोग करके त्रुटि बार को अनुकूलित करें"
linktitle: "त्रुटि बार"
type: docs
url: /hi/nodejs-java/error-bar/
keywords:
- "त्रुटि बार"
- "कस्टम मान"
- "PowerPoint"
- "प्रस्तुति"
- "Node.js"
- "जावास्क्रिप्ट"
- "Aspose.Slides"
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js via Java का उपयोग करके चार्ट में त्रुटि बार जोड़ना और अनुकूलित करना सीखें—PowerPoint प्रस्तुतियों में डेटा दृश्य को बेहतर बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में त्रुटि बार के साथ काम करने की व्याख्या करता है। यह दिखाता है कि चार्ट सीरीज़ में त्रुटि बार कैसे जोड़ें, X और Y त्रुटि बार सेटिंग्स को कैसे कॉन्फ़िगर करें, और विभिन्न मान प्रकार जैसे स्थिर, प्रतिशत, और कस्टम मान कैसे लागू करें।

यह भी प्रदर्शित करता है कि सीरीज़ में व्यक्तिगत डेटा पॉइंट के लिए कस्टम त्रुटि बार मान कैसे निर्दिष्ट करें, जिसके लिए संबंधित डेटा पॉइंट संग्रह का उपयोग किया जाता है। अतिरिक्त रूप से, लेख में त्रुटि बार के निर्यात के दौरान व्यवहार, मार्कर और डेटा लेबल के साथ उनकी संगतता, तथा संबंधित API संदर्भ वर्गों और एन्युम्स को कहाँ पाया जा सकता है, के संक्षिप्त नोट्स भी शामिल हैं।

## **त्रुटि बार जोड़ें**

Aspose.Slides for Node.js via Java त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब कस्टम मान प्रकार का उपयोग किया जाता है। मान निर्दिष्ट करने के लिए, सीरीज़ के [**DataPoints**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeriesCollection) संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. बार मान और फ़ॉर्मेट सेट करें।
1. संशोधित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

```javascript
// Presentation क्लास का एक इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation();
try {
    // एक बबल चार्ट बना रहे हैं
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // त्रुटि बार जोड़ रहे हैं और उसका स्वरूप सेट कर रहे हैं
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // प्रस्तुति सहेज रहे हैं
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **कस्टम त्रुटि बार मान जोड़ें**

Aspose.Slides for Node.js via Java कस्टम त्रुटि बार मानों को प्रबंधित करने के लिए एक सरल API प्रदान करता है। नमूना कोड तब लागू होता है जब [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) प्रॉपर्टी **Custom** के बराबर हो। मान निर्दिष्ट करने के लिए, सीरीज़ के [**DataPoints**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeriesCollection) संग्रह में किसी विशिष्ट डेटा पॉइंट की **ErrorBarCustomValues** प्रॉपर्टी का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
1. इच्छित स्लाइड पर एक बबल चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार X फ़ॉर्मेट सेट करें।
1. पहले चार्ट सीरीज़ तक पहुंचें और त्रुटि बार Y फ़ॉर्मेट सेट करें।
1. चार्ट सीरीज़ के व्यक्तिगत डेटा पॉइंट्स तक पहुंचें और व्यक्तिगत सीरीज़ डेटा पॉइंट के लिए त्रुटि बार मान सेट करें।
1. बार मान और फ़ॉर्मेट सेट करें।
1. संशोधित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

```javascript
// Presentation क्लास का एक इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation();
try {
    // एक बबल चार्ट बना रहे हैं
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // कस्टम त्रुटि बार जोड़ रहे हैं और उसका स्वरूप सेट कर रहे हैं
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // चार्ट सीरीज़ डेटा पॉइंट तक पहुंच रहे हैं और त्रुटि बार मान सेट कर रहे हैं
    // व्यक्तिगत पॉइंट
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // चार्ट सीरीज़ पॉइंट्स के लिए त्रुटि बार सेट कर रहे हैं
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // प्रस्तुति सहेज रहे हैं
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक प्रस्तुति को PDF या इमेज में निर्यात करने पर त्रुटि बार का क्या होता है?**

वे चार्ट का हिस्सा बनकर रेंडर होते हैं और चार्ट फ़ॉर्मेटिंग के साथ निर्यात के दौरान संरक्षित रहते हैं, बशर्ते कि संगत संस्करण या रेंडरर उपयोग किया गया हो।

**क्या त्रुटि बार को मार्कर और डेटा लेबल के साथ संयोजित किया जा सकता है?**

हां। त्रुटि बार एक अलग तत्व है और मार्कर व डेटा लेबल के साथ संगत है; यदि तत्व ओवरलैप होते हैं, तो फ़ॉर्मेटिंग समायोजित करने की आवश्यकता हो सकती है।

**API में त्रुटि बार के साथ काम करने के लिए प्रॉपर्टीज़ और एन्युम्स की सूची कहाँ मिल सकती है?**

API संदर्भ में: [ErrorBarsFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/errorbarsformat/) क्लास और संबंधित एन्युम्स [ErrorBarType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/errorbartype/) तथा [ErrorBarValueType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/errorbarvaluetype/)।
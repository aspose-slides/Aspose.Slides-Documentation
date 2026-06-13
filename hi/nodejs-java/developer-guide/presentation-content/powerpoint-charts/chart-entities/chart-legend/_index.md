---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/nodejs-java/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js के साथ चार्ट लेजेंड को अनुकूलित करके, कस्टम लेजेंड फ़ॉर्मेटिंग के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं।"
---
## **अवलोकन**

Aspose.Slides PowerPoint प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख दर्शाता है कि लेजेंड को कैसे स्थित और आकारित किया जाए, पूरे लेजेंड के फ़ॉन्ट आकार को कैसे सेट किया जाए, और व्यक्तिगत लेजेंड प्रविष्टि पर फ़ॉर्मेटिंग कैसे लागू की जाए।

यह FAQ में कई संबंधित व्यवहारों को भी कवर करता है, जिसमें नॉन-ओवरले मोड का उपयोग करके प्लॉट एरिया को लेजेंड के लिए जगह बनाने, लंबे लेजेंड लेबल को रैप या लाइन ब्रेक का उपयोग करने, और जब स्पष्ट पाठ और भराव सेटिंग नहीं है तो लेजेंड फ़ॉर्मेटिंग को प्रस्तुति थीम से विरासत में लेने शामिल है।

## **लेजेंड की स्थिति निर्धारण**

लेजेंड गुणों को सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का एक उदाहरण बनाएँ।
- स्लाइड का संदर्भ प्राप्त करें।
- स्लाइड पर एक चार्ट जोड़ें।
- लेजेंड की गुणधर्म सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट लेजेंड के लिए स्थिति और आकार सेट किया है।

```javascript
// Presentation वर्ग का एक उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // स्लाइड का संदर्भ प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    // स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // लेजेंड गुण सेट करें
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **लेजेंड का फ़ॉन्ट आकार सेट करें**

Aspose.Slides for Node.js via Java डेवलपर्स को लेजेंड का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दी गई चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का एक उदाहरण बनाएँ।
- डिफ़ॉल्ट चार्ट बनाना।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```javascript
// Presentation वर्ग का एक उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **व्यक्तिगत लेजेंड का फ़ॉन्ट आकार सेट करें**

Aspose.Slides for Node.js via Java डेवलपर्स को व्यक्तिगत लेजेंड प्रविष्टियों का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दी गई चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का एक उदाहरण बनाएँ।
- डिफ़ॉल्ट चार्ट बनाना।
- लेजेंड प्रविष्टि तक पहुँचें।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```javascript
// Presentation वर्ग का एक उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं लेजेंड को सक्षम कर सकता हूँ ताकि चार्ट स्वतः उसके लिए स्थान आवंटित करे, बजाय इसे ओवरले करने के?**

हां। नॉन-ओवरले मोड का उपयोग करें ([setOverlay(false)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/legend/setoverlay/)); इस स्थिति में, प्लॉट एरिया लेजेंड को समायोजित करने के लिए छोटा हो जाएगा।

**क्या मैं बहु-पंक्तियों वाले लेजेंड लेबल बना सकता हूँ?**

हां। जब स्थान अपर्याप्त हो तो लंबे लेबल स्वतः रैप होते हैं; क्रमशः नाम में नई पंक्तियों के उपयोग से जबरन लाइन ब्रेक समर्थित हैं।

**मैं कैसे लेजेंड को प्रस्तुति थिम की रंग योजना के अनुसार बनाऊँ?**

लेजेंड या उसके पाठ के लिए स्पष्ट रंग/भरण/फ़ॉन्ट सेट न करें। वे तब थीम से विरासत में मिलेंगे और डिज़ाइन बदलने पर सही ढंग से अपडेट होंगे।
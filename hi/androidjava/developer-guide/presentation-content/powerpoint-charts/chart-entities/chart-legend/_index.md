---
title: Android पर प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/androidjava/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android via Java के लिए Aspose.Slides के साथ चार्ट लेजेंड को कस्टमाइज़ करें ताकि PowerPoint प्रस्तुतियों को व्यक्तिगत लेजेंड फ़ॉर्मेटिंग से अनुकूलित किया जा सके।"
---
## **सारांश**

Aspose.Slides PowerPoint प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करने के विकल्प प्रदान करता है। इस लेख में बताया गया है कि लेजेंड की स्थिति और आकार कैसे निर्धारित करें, पूरे लेजेंड के लिए फ़ॉन्ट आकार कैसे सेट करें, और व्यक्तिगत लेजेंड एंट्री पर फ़ॉर्मेटिंग कैसे लागू करें।

यह FAQ में कई संबंधित व्यवहारों को भी कवर करता है, जिसमें नॉन-ओवरले मोड का उपयोग करके प्लॉट क्षेत्र को लेजेंड के लिए स्थान देने, लंबे लेजेंड लेबल को रैप या लाइन ब्रेक उपयोग करने, और जब स्पष्ट टेक्स्ट और फ़िल सेटिंग्स लागू नहीं की जाती हैं तो लेजेंड फ़ॉर्मेटिंग को प्रस्तुति थीम से विरासत में लेने शामिल हैं।

## **लेजेंड स्थिति निर्धारण**
लेजेंड गुण सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड पर एक चार्ट जोड़ें।
- लेजेंड के गुण सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट लेजेंड के लिए स्थिति और आकार सेट किया है।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // स्लाइड का रेफ़रेंस प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // लेजेंड गुण सेट करें
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // प्रस्तुति को डिस्क पर लिखें
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **लेजेंड का फ़ॉन्ट आकार सेट करना**
Aspose.Slides for Android via Java डेवेलपर्स को लेजेंड का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टैंस बनाएँ।
- डिफ़ॉल्ट चार्ट बनाएं।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **व्यक्तिगत लेजेंड का फ़ॉन्ट आकार सेट करना**
Aspose.Slides for Android via Java डेवेलपर्स को व्यक्तिगत लेजेंड एंट्रीज़ का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टैंस बनाएँ।
- डिफ़ॉल्ट चार्ट बनाएं।
- लेजेंड एंट्री तक पहुँचें।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं लेजेंड को सक्षम कर सकता हूँ ताकि चार्ट इसे ओवरले करने के बजाय स्वचालित रूप से इसके लिए स्थान आवंटित करे?**

हाँ। नॉन-ओवरले मोड का उपयोग करें ([setOverlay(false)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); इस मामले में, प्लॉट एरिया लेजेंड को समायोजित करने के लिए सिकुड़ जाएगा।

**क्या मैं मल्टी-लाइन लेजेंड लेबल बना सकता हूँ?**

हाँ। जब स्थान अपर्याप्त हो तो लंबे लेबल स्वचालित रूप से रैप हो जाते हैं; फ़ोर्स्ड लाइन ब्रेक सीरीज़ नाम में न्यूलाइन कैरेक्टर के द्वारा समर्थित हैं।

**मैं लेजेंड को प्रस्तुति थीम की रंग योजना के अनुरूप कैसे बना सकता हूँ?**

लेजेंड या उसके टेक्स्ट के लिए स्पष्ट रंग/फ़िल/फ़ॉन्ट सेट न करें। इस प्रकार वे थीम से विरासत में ले लेंगे और डिजाइन बदलने पर सही ढंग से अपडेट हो जाएंगे।
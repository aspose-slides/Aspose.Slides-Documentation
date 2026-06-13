---
title: Presentations में Java का उपयोग करके चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/java/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ चार्ट लेजेंड को कस्टमाइज़ करें ताकि पावरपॉइंट प्रस्तुतियों को अनुकूलित लेजेंड फ़ॉर्मेटिंग के साथ अनुकूलित किया जा सके।"
---
## **अवलोकन**

Aspose.Slides PowerPoint प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख लेजेंड को किस तरह स्थित और आकार दिया जाए, पूरी लेजेंड के लिए फ़ॉन्ट आकार कैसे सेट किया जाए, और व्यक्तिगत लेजेंड एंट्री पर फ़ॉर्मेटिंग कैसे लागू की जाए, दिखाता है।

यह FAQ में कई संबंधित व्यवहारों को भी कवर करता है, जिसमें लेजेंड के लिए जगह बनाने के लिए नॉन-ओवरले मोड का उपयोग, लंबे लेजेंड लेबल्स को रैप होने या लाइन ब्रेक का उपयोग करने देना, और जब स्पष्ट टेक्स्ट और फ़िल सेटिंग्स नहीं लागू की जातीं तो लेजेंड फ़ॉर्मेटिंग को प्रस्तुति थीम से विरासत में लेने देना शामिल है।

## **लेजेंड स्थिति**
लेजेंड गुण सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड पर एक चार्ट जोड़ें।
- लेजेंड के गुण सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने चार्ट लेजेंड के लिए स्थिति और आकार सेट किया है।

```java
// Presentation वर्ग की एक इंस्टेंस बनाएं
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

## **लेजेंड का फ़ॉन्ट आकार सेट करें**
Aspose.Slides for Java डेवलपर्स को लेजेंड का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```java
// Presentation वर्ग की एक इंस्टेंस बनाएं
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

## **व्यक्तिगत लेजेंड का फ़ॉन्ट आकार सेट करें**
Aspose.Slides for Java डेवलपर्स को व्यक्तिगत लेजेंड एंट्रीज़ का फ़ॉन्ट आकार सेट करने की अनुमति देता है। कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- लेजेंड एंट्री तक पहुँचें।
- फ़ॉन्ट आकार सेट करें।
- न्यूनतम अक्ष मान सेट करें।
- अधिकतम अक्ष मान सेट करें।
- प्रस्तुति को डिस्क पर लिखें।

```java
// Presentation वर्ग की एक इंस्टेंस बनाएं
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

**क्या मैं लेजेंड को सक्षम कर सकता हूँ ताकि चार्ट इसे ओवरले करने के बजाय स्वचालित रूप से उसके लिए जगह आवंटित करे?**

हाँ। नॉन-ओवरले मोड का उपयोग करें ([setOverlay(false)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/legend/#setOverlay-boolean-)); इस स्थिति में, प्लॉट एरिया लेजेंड को समायोजित करने के लिए छोटा हो जाएगा।

**क्या मैं मल्टी-लाइन लेजेंड लेबल बना सकता हूँ?**

हाँ। जब स्थान अपर्याप्त हो तो लंबे लेबल अपने आप रैप हो जाते हैं; फोर्स्ड लाइन ब्रेक सीरीज़ नाम में न्यूलाइन अक्षरों द्वारा समर्थित होते हैं।

**मैं कैसे सुनिश्चित करूँ कि लेजेंड प्रस्तुति थीम की रंग योजन का अनुसरण करे?**

लेजेंड या उसके टेक्स्ट के लिए स्पष्ट रंग/फ़िल/फ़ॉन्ट सेट न करें। वे तब थीम से विरासत में लेंगे और डिजाइन बदलने पर सही तरीके से अपडेट होंगे।
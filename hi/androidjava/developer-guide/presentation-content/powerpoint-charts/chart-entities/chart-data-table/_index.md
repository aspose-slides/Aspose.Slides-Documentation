---
title: Android पर प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/androidjava/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android के लिए Aspose.Slides के साथ Java में PPT और PPTX के लिए चार्ट डेटा टेबल को अनुकूलित करके प्रस्तुतियों में दक्षता और आकर्षण बढ़ाएँ।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट डेटा टेबल के साथ काम करने का तरीका बताता है। यह दर्शाता है कि चार्ट के लिए डेटा टेबल कैसे प्रदर्शित करें और फ़ॉन्ट गुण जैसे बोल्ड शैली और फ़ॉन्ट की ऊँचाई सेट करके टेक्स्ट फ़ॉर्मेटिंग को कैसे अनुकूलित करें। उदाहरण में एक प्रस्तुति लोड करना, एक चार्ट जोड़ना, चार्ट डेटा टेबल को सक्षम करना, फ़ॉन्ट सेटिंग्स लागू करना, और अपडेटेड प्रस्तुति को सेव करना दिखाया गया है।

## **चार्ट डेटा टेबल के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for Android via Java, श्रृंखला के रंग में श्रेणियों के रंग को बदलने के लिए समर्थन प्रदान करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास ऑब्जेक्ट का उदाहरण बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट टेबल सेट करें।
1. फ़ॉन्ट की ऊँचाई सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे उदाहरण दिया गया है।

```java
// खाली प्रस्तुति बना रहा है
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा टेबल में मानों के बगल में छोटे लेजेंड कुंजियां दिखा सकता हूँ?**

हां। डेटा टेबल [legend keys](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) का समर्थन करता है, और आप उन्हें चालू या बंद कर सकते हैं।

**क्या प्रस्तुति को PDF, HTML, या छवियों में निर्यात करने पर डेटा टेबल बरकरार रहेगा?**

हां। Aspose.Slides चार्ट को स्लाइड के हिस्से के रूप में रेंडर करता है, इसलिए निर्यातित [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/androidjava/convert-powerpoint-to-html/)/[image](/slides/hi/androidjava/convert-powerpoint-to-png/) में चार्ट उसके डेटा टेबल के साथ शामिल होता है।

**क्या टेम्पलेट फ़ाइल से आए चार्ट के लिए डेटा टेबल का समर्थन किया जाता है?**

हां। किसी भी चार्ट के लिए जो मौजूदा प्रस्तुति या टेम्पलेट से लोड किया गया हो, आप चार्ट की प्रॉपर्टीज़ का उपयोग करके यह जांच और बदल सकते हैं कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/#hasDataTable--) है या नहीं।

**मैं फाइल में कौन से चार्ट डेटा टेबल सक्षम हैं, इसे जल्दी कैसे खोजूं?**

फ़ाइल में प्रत्येक चार्ट की उस प्रॉपर्टी को जांचें जो यह दर्शाती है कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/#hasDataTable--) है, और स्लाइड्स के माध्यम से इटररेट करके उन चार्ट्स की पहचान करें जहाँ यह सक्षम है।
---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/java/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- पावरपॉइंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides के साथ जावा में PPT और PPTX के लिए चार्ट डेटा टेबल को अनुकूलित करके प्रस्तुतियों में दक्षता और आकर्षण बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा टेबल के साथ काम करने की विधि समझाता है। यह दिखाता है कि चार्ट के लिए डेटा टेबल कैसे प्रदर्शित करें और बोल्ड शैली और फ़ॉन्ट ऊँचाई जैसी फ़ॉन्ट गुण सेट करके उसके टेक्स्ट फ़ॉर्मेटिंग को कैसे कस्टमाइज़ करें। उदाहरण में एक प्रस्तुति लोड करना, चार्ट जोड़ना, चार्ट डेटा टेबल को सक्षम करना, फ़ॉन्ट सेटिंग्स लागू करना, और अपडेटेड प्रस्तुति को सहेजना दर्शाया गया है।

यह चार्ट डेटा टेबल में लेजेंड कुंजियों को दिखाने, निर्यात के दौरान डेटा टेबल को संरक्षित रखने, मौजूदा प्रस्तुति या टेम्पलेट से लोड किए गए चार्ट्स के साथ काम करने, और उन चार्ट्स की पहचान करने के बारे में सामान्य प्रश्नों के संक्षिप्त उत्तर भी शामिल करता है जहाँ डेटा टेबल सक्षम है।

## **चार्ट डेटा टेबल के लिए फ़ॉन्ट गुण सेट करें**

Aspose.Slides for Java श्रृंखला रंग में वर्गों के रंग को बदलने के लिए समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास ऑब्जेक्ट को इंस्टैंसिएट करें।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट टेबल सेट करें।
1. फ़ॉन्ट ऊँचाई सेट करें।
1. संशोधित प्रस्तुति सहेजें।

नीचे एक नमूना उदाहरण दिया गया है।

```java
// खाली प्रस्तुति बनाना
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

**क्या मैं चार्ट के डेटा टेबल में मानों के बगल में छोटे लेजेंड कुंजियाँ दिखा सकता हूँ?**

हाँ। डेटा टेबल [legend keys](https://reference.aspose.com/slides/hi/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) का समर्थन करता है, और आप उन्हें चालू या बंद कर सकते हैं।

**क्या प्रस्तुति को PDF, HTML, या चित्रों में निर्यात करते समय डेटा टेबल संरक्षित रहेगा?**

हाँ। Aspose.Slides चार्ट को स्लाइड का हिस्सा बनाकर रेंडर करता है, इसलिए निर्यात किया गया [PDF](/slides/hi/java/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/java/convert-powerpoint-to-html/)/[image](/slides/hi/java/convert-powerpoint-to-png/) चार्ट को उसके डेटा टेबल के साथ शामिल करता है।

**क्या टेम्पलेट फ़ाइल से आने वाले चार्ट्स के लिए डेटा टेबल समर्थित हैं?**

हाँ। किसी भी चार्ट के लिए जो मौजूदा प्रस्तुति या टेम्पलेट से लोड किया गया है, आप चार्ट की प्रॉपर्टी का उपयोग करके यह जांच और बदल सकते हैं कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/#hasDataTable--) है या नहीं।

**मैं फ़ाइल में किन चार्ट्स में डेटा टेबल सक्षम है, इसे जल्दी कैसे खोज सकता हूँ?**

फ़ाइल में प्रत्येक चार्ट की उस प्रॉपर्टी की जाँच करें जो दर्शाती है कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/#hasDataTable--) है या नहीं, और स्लाइड्स के माध्यम से इटरिएट करके उन चार्ट्स की पहचान करें जहाँ यह सक्षम है।
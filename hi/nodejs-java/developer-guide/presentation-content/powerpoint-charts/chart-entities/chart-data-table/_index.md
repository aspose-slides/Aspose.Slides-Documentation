---
title: जावास्क्रिप्ट का उपयोग कर प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/nodejs-java/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- PowerPoint
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ जावास्क्रिप्ट में PPT और PPTX के लिये चार्ट डेटा टेबल को अनुकूलित करें, जिससे प्रस्तुतियों की दक्षता और आकर्षण बढ़े।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा टेबल के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि चार्ट के लिए डेटा टेबल कैसे प्रदर्शित करें और बोल्ड शैली तथा फ़ॉन्ट ऊँचाई जैसे फ़ॉन्ट गुण सेट करके उसके टेक्स्ट फ़ॉर्मैटिंग को कैसे अनुकूलित करें। उदाहरण में एक प्रेजेंटेशन लोड करना, चार्ट जोड़ना, चार्ट डेटा टेबल को सक्रिय करना, फ़ॉन्ट सेटिंग्स लागू करना, और अपडेटेड प्रेजेंटेशन को सहेजना प्रदर्शित किया गया है।

यह चार्ट डेटा टेबल में लेजेंड कुंजियों को दिखाने, निर्यात के दौरान डेटा टेबल को संरक्षित रखने, मौजूदा प्रेजेंटेशन या टेम्पलेट से लोड किए गए चार्ट के साथ काम करने, और उन चार्ट को पहचानने के सामान्य प्रश्नों के संक्षिप्त उत्तर भी शामिल करता है जहाँ डेटा टेबल सक्षम है।

## **Set Font Properties for Chart Data Table**

Aspose.Slides for Node.js via Java श्रेणियों के रंग को बदलने के लिए समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास ऑब्जेक्ट को इंस्टैंटिएट करें।  
2. स्लाइड पर चार्ट जोड़ें।  
3. चार्ट टेबल सेट करें।  
4. फ़ॉन्ट की ऊँचाई सेट करें।  
5. संशोधित प्रेजेंटेशन को सहेजें।

नीचे नमूना उदाहरण दिया गया है।

```javascript
// खाली प्रेज़ेंटेशन बना रहे हैं
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा टेबल में मानों के बगल में छोटे लेजेंड कुंजियों को दिखा सकता हूँ?**

हाँ। डेटा टेबल [legend keys](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datatable/setshowlegendkey/) को समर्थन देता है, और आप उन्हें चालू या बंद कर सकते हैं।

**क्या प्रेजेंटेशन को PDF, HTML या इमेज में निर्यात करते समय डेटा टेबल संरक्षित रहेगी?**

हाँ। Aspose.Slides चार्ट को स्लाइड का हिस्सा के रूप में रेंडर करता है, इसलिए निर्यातित [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में चार्ट उसके डेटा टेबल के साथ शामिल रहता है।

**क्या टेम्पलेट फ़ाइल से आए चार्ट के लिए डेटा टेबल समर्थित हैं?**

हाँ। किसी भी चार्ट के लिए जो मौजूदा प्रेजेंटेशन या टेम्पलेट से लोड किया गया है, आप चार्ट की प्रॉपर्टी का उपयोग करके डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/hasdatatable/) है या नहीं, उसे जांच और बदल सकते हैं।

**मैं फ़ाइल में कौन से चार्ट में डेटा टेबल सक्षम है, इसे जल्दी से कैसे खोज सकता हूँ?**

प्रत्येक चार्ट की प्रॉपर्टी जांचें जो दर्शाती है कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/hasdatatable/) है या नहीं, और स्लाइड्स में इटररेट करके उन चार्टों की पहचान करें जहाँ यह सक्रिय है।
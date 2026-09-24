---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट डेटा टेबल को कस्टमाइज़ करें
linktitle: डेटा टेबल
type: docs
url: /hi/nodejs-java/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा टेबल के फ़ॉन्ट, बॉर्डर और लेजेंड कीज़ को कस्टमाइज़ करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java आपको चार्ट की डेटा टेबल प्रदर्शित करने और उसके टेक्स्ट फॉर्मेटिंग, बॉर्डर और लेजेंड कीज़ को कस्टमाइज़ करने की सुविधा देता है। यह लेख बताता है कि टेबल को कैसे सक्षम करें, उसके टेक्स्ट को फ़ॉर्मेट करें, प्रत्येक प्रकार के बॉर्डर को कैसे नियंत्रित करें, और लेजेंड कीज़ को दिखाएँ या छिपाएँ। उदाहरण कॉन्फ़िगर किए गए चार्ट को PPTX फ़ाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण सेट करें**

चार्ट की डेटा टेबल प्रदर्शित करने के लिए, `true` को [setDataTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/setdatatable/) में पास करें। टेबल तक पहुँचने और उसके टेक्स्ट फ़ॉर्मेटिंग को कॉन्फ़िगर करने के लिए [getChartDataTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/getchartdatatable/) का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
1. पहली स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. चार्ट की डेटा टेबल सक्षम करें।
1. बोल्ड टेक्स्ट सक्षम करने के लिए [setFontBold](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setfontbold) का उपयोग करें और 20 पॉइंट टेक्स्ट के लिए [setFontHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setfontheight) में `20` पास करें।
1. संशोधित प्रस्तुति सहेजें।

निम्न उदाहरण के लिए कार्यशील निर्देशिका में कम से कम एक स्लाइड वाला `input.pptx` आवश्यक है। यह (50, 50) स्थान पर डिफॉल्ट डेटा के साथ एक चार्ट जोड़ता है, जिसकी चौड़ाई 600 पॉइंट और ऊँचाई 400 पॉइंट है। सहेजी गई `output.pptx` में चार्ट की डेटा टेबल सक्षम और निर्दिष्ट फ़ॉन्ट सेटिंग्स लागू होते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डेटा टेबल बॉर्डर कस्टमाइज़ करें**

[Chart.setDataTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/setdatatable/) से टेबल सक्षम करें और उसे [Chart.getChartDataTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/getchartdatatable/) के माध्यम से एक्सेस करें। आप तीन प्रकार के बॉर्डर को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [setBorderHorizontal](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datatable/setborderhorizontal/) क्षैतिज सेल बॉर्डर को नियंत्रित करता है।
- [setBorderVertical](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datatable/setbordervertical/) लंबवत सेल बॉर्डर को नियंत्रित करता है।
- [setBorderOutline](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datatable/setborderoutline/) टेबल के बाहरी बॉर्डर को नियंत्रित करता है।

प्रत्येक मेथड में `true` पास करने से उसका बॉर्डर दिखेगा या `false` पास करने से वह छिपेगा। निम्न उदाहरण डिफॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज बॉर्डर और बाहरी बॉर्डर दिखाता है, और लंबवत बॉर्डर छुपाता है। इसके लिए कोई इनपुट फ़ाइल आवश्यक नहीं है। चार्ट की स्थिति और आकार पॉइंट में निर्दिष्ट हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे दिया गया तुलना चार मामलों में समान चार्ट डेटा और लेजेंड की सेटिंग का उपयोग करती है। सभी बॉर्डर सक्षम से शुरू करके प्रत्येक शेष वैरिएंट केवल एक बॉर्डर सेटिंग को निष्क्रिय करता है। निचले-बायें वैरिएंट में उदाहरण की बॉर्डर सेटिंग्स मिलती हैं।

![सभी बॉर्डर सक्षम, कोई क्षैतिज बॉर्डर नहीं, कोई लंबवत बॉर्डर नहीं, और कोई बाहरी बॉर्डर नहीं वाला चार्ट डेटा टेबल](data-table-borders.png)

## **लेजेंड कीज़ दिखाएँ या छुपाएँ**

लेजेंड कीज़ डेटा टेबल में सीरीज़ नामों के बगल में छोटे रंगीन मार्कर होते हैं। ये पाठकों को प्रत्येक टेबल पंक्ति को चार्ट सीरीज़ से मिलाने में मदद करते हैं। इन मार्करों को दिखाने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datatable/setshowlegendkey/) में `true` पास करें या उन्हें छिपाने के लिए `false` पास करें।

चार्ट का अलग लेजेंड [Chart.setLegend](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/setlegend/) से नियंत्रित होता है। ये सेटिंग्स स्वतंत्र हैं: अलग लेजेंड को छुपाने से डेटा टेबल के अंदर की कीज़ नहीं छुपतीं, और टेबल की कीज़ को छुपाने से अलग लेजेंड नहीं छुपता।

निम्न उदाहरण डिफॉल्ट डेटा के साथ एक चार्ट बनाता है, उसकी डेटा टेबल सक्षम करता है, और लेजेंड कीज़ को दिखाते हुए अलग लेजेंड को छुपाता है। सभी टेबल बॉर्डर स्पष्ट रूप से सक्षम हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। केवल टेबल की कीज़ को छुपाने के लिए, [setShowLegendKey](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datatable/setshowlegendkey/) में `false` पास करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे दिया गया तुलना एक ही टेबल को लेजेंड कीज़ सक्षम और निष्क्रिय स्थिति में दिखाता है। सभी बॉर्डर सक्षम रहते हैं, और अलग चार्ट लेजेंड दोनों मामलों में छुपा रहता है।

![बाएँ तरफ लेजेंड कीज़ दिखाए हुए और दाएँ तरफ छिपे हुए चार्ट डेटा टेबल](data-table-legend-keys.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा टेबल में लेजेंड कीज़ दिखा सकता हूँ?**

हाँ। लेजेंड कीज़ प्रदर्शित करने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datatable/setshowlegendkey/) में `true` पास करें या उन्हें छिपाने के लिए `false` पास करें।

**क्या प्रस्तुति को PDF, HTML, या इमेजेज़ में एक्सपोर्ट करते समय डेटा टेबल संरक्षित रहेगा?**

हाँ। Aspose.Slides चार्ट और उसकी प्रदर्शित डेटा टेबल को स्लाइड का हिस्सा बनाकर [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/), या [images](/slides/hi/nodejs-java/convert-powerpoint-to-png/) के रूप में एक्सपोर्ट करता है।

**क्या मैं टेम्पलेट से लोड किए गए चार्ट की डेटा टेबल के साथ काम कर सकता हूँ?**

हाँ। मौजूदा प्रस्तुति या टेम्पलेट से लोड किए गए चार्ट के लिए, [hasDataTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/hasdatatable/) और [setDataTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/setdatatable/) का उपयोग करके जांचें या बदलें कि उसकी डेटा टेबल प्रदर्शित है या नहीं।

**मैं उन चार्ट्स को कैसे खोजूँ जो डेटा टेबल सक्षम रखते हैं?**

प्रत्येक स्लाइड पर शैक्‍स को इटरेट करें, चार्ट्स को पहचानें, और उनके [hasDataTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/hasdatatable/) मेथड को कॉल करें। मान `true` इंगित करता है कि डेटा टेबल सक्षम है।
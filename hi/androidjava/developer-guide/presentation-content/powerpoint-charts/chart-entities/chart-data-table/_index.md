---
title: Android पर प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/androidjava/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- पावरपॉइंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for Android via Java का उपयोग करके चार्ट डेटा टेबल फ़ॉन्ट, बॉर्डर और लेजेंड कुंजियों को अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides for Android via Java आपको चार्ट की डेटा टेबल दिखाने और उसके टेक्स्ट फॉर्मेटिंग, बॉर्डर और लेजेंड कुंजियों को अनुकूलित करने की सुविधा देता है। यह लेख टेबल को सक्षम करने, टेक्स्ट को फॉर्मेट करने, प्रत्येक प्रकार के बॉर्डर को नियंत्रित करने, और लेजेंड कुंजियों को दिखाने या छिपाने के तरीके को समझाता है। उदाहरण कॉन्फ़िगर किए गए चार्ट को PPTX फ़ाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण सेट करें**

चार्ट की डेटा टेबल दिखाने के लिए, `true` को [setDataTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) में पास करें। टेबल तक पहुंचने और उसके टेक्स्ट फॉर्मेटिंग को कॉन्फ़िगर करने के लिए [getChartDataTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/#getChartDataTable--) का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
1. पहले स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. चार्ट की डेटा टेबल सक्षम करें।
1. [setFontBold](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) से बोल्ड टेक्स्ट सक्षम करें और `20` को [setFontHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) में पास करें ताकि 20‑पॉइंट टेक्स्ट हो।
1. संशोधित प्रस्तुति सहेजें।

निम्न उदाहरण को कार्य करने के लिए कार्य निर्देशिका में न्यूनतम एक स्लाइड वाली `test.pptx` फ़ाइल आवश्यक है। यह स्थिति (50, 50) पर, चौड़ाई 600 पॉइंट और ऊँचाई 400 पॉइंट के साथ डिफ़ॉल्ट डेटा वाला चार्ट जोड़ता है। सहेजी गई `output.pptx` में चार्ट के साथ उसकी डेटा टेबल सक्षम और निर्दिष्ट फ़ॉन्ट सेटिंग्स लागू होती हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डेटा टेबल बॉर्डर को अनुकूलित करें**

टेबल को [IChart.setDataTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) के साथ सक्षम करें और इसे [IChart.getChartDataTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#getChartDataTable--) के माध्यम से प्राप्त करें। आप तीन प्रकार के बॉर्डर को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [setBorderHorizontal](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) क्षैतिज सेल बॉर्डर नियंत्रित करता है।
- [setBorderVertical](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) लंबवत सेल बॉर्डर नियंत्रित करता है।
- [setBorderOutline](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) टेबल के बाहरी बॉर्डर को नियंत्रित करता है।

प्रत्येक मेथड को `true` पास करके उसके बॉर्डर दिखाएँ या `false` पास करके उन्हें छिपाएँ। निम्न उदाहरण डिफ़ॉल्ट डेटा वाला क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज बॉर्डर और बाहरी बॉर्डर दिखाता है, और लंबवत बॉर्डर को छिपाता है। इसे किसी इनपुट फ़ाइल की आवश्यकता नहीं है। चार्ट का स्थान और आकार पॉइंट में निर्दिष्ट है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे का तुलनात्मक दृश्य सभी चार मामलों में समान चार्ट डेटा और लेजेंड कुंजी सेटिंग का उपयोग करता है। सभी बॉर्डर सक्षम होने से शुरू करके, प्रत्येक शेष वैरिएंट केवल एक बॉर्डर सेटिंग को निष्क्रिय करता है। निचले‑बाएँ वैरिएंट उदाहरण के बॉर्डर सेटिंग से मेल खाता है।

![सभी बॉर्डर सक्षम, कोई क्षैतिज बॉर्डर नहीं, कोई लंबवत बॉर्डर नहीं, और कोई बाहरी बॉर्डर नहीं के साथ चार्ट डेटा टेबल्स](data-table-borders.png)

## **लेजेंड कुंजियों को दिखाएँ या छुपाएँ**

लेजेंड कुंजियाँ डेटा टेबल में सीरीज़ नामों के बगल में छोटे रंगीन मार्कर होते हैं। वे पाठकों को प्रत्येक टेबल पंक्ति को चार्ट सीरीज़ से मिलाने में मदद करती हैं। इन मार्करों को दिखाने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) में `true` पास करें या छिपाने के लिए `false` पास करें।

चार्ट का अलग लेजेंड [IChart.setLegend](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) द्वारा नियंत्रित होता है। ये सेटिंग्स स्वतंत्र हैं: अलग लेजेंड को छिपाने से टेबल के भीतर की कुंजियाँ नहीं छिपतीं, और टेबल की कुंजियों को छिपाने से अलग लेजेंड नहीं छिपता।

निम्न उदाहरण डिफ़ॉल्ट डेटा वाला चार्ट बनाता है, उसकी डेटा टेबल सक्षम करता है, और टेबल के भीतर लेजेंड कुंजियाँ दिखाता है जबकि अलग लेजेंड को छिपाता है। सभी टेबल बॉर्डर स्पष्ट रूप से सक्षम हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। केवल टेबल की कुंजियों को छिपाने के लिए, [setShowLegendKey](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) में `false` पास करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे का तुलनात्मक दृश्य वही टेबल लेजेंड कुंजियों को सक्षम और निष्क्रिय करके दिखाता है। सभी बॉर्डर सक्षम रहते हैं, और अलग चार्ट लेजेंड दोनों मामलों में छिपा रहता है।

![बाएँ दिखाए गए लेजेंड कुंजियाँ और दाएँ छिपाए गए लेजेंड कुंजियाँ](data-table-legend-keys.png)

## **FAQ**

**क्या मैं चार्ट की डेटा टेबल में लेजेंड कुंजियाँ दिखा सकता हूँ?**

हाँ। लेजेंड कुंजियों को दिखाने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) में `true` पास करें या छिपाने के लिए `false` पास करें।

**क्या प्रस्तुति को PDF, HTML या इमेजेस में निर्यात करते समय डेटा टेबल बरकरार रहेगी?**

हाँ। Aspose.Slides स्लाइड के भाग के रूप में चार्ट और उसकी प्रदर्शित डेटा टेबल को निर्यात करते समय [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/), या [images](/slides/hi/androidjava/convert-powerpoint-to-png/) में रेंडर करता है।

**क्या मैं टेम्प्लेट से लोड किए गए चार्ट में डेटा टेबल के साथ काम कर सकता हूँ?**

हाँ। मौजूदा प्रस्तुति या टेम्प्लेट से लोड किए गए चार्ट के लिए, उसकी डेटा टेबल दिख रही है या नहीं, इसे जांचने या बदलने के लिए [hasDataTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/#hasDataTable--) और [setDataTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) का उपयोग करें।

**मैं कैसे उन चार्ट्स को खोजूँ जिनमें डेटा टेबल सक्षम है?**

प्रत्येक स्लाइड पर मौजूद शैप्स के माध्यम से इटररेट करें, चार्ट्स की पहचान करें, और उनके [hasDataTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/#hasDataTable--) मेथड को कॉल करें। यदि वैल्यू `true` है तो डेटा टेबल सक्षम है।
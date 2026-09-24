---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/java/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा टेबल के फ़ॉन्ट, बॉर्डर और लेजेंड कुंजियों को अनुकूलित करें।"
---
## **समीक्षा**

Aspose.Slides for Java आपको चार्ट की डेटा टेबल दिखाने और उसके टेक्स्ट फ़ॉर्मेटिंग, बॉर्डर और लेजेंड कुंजियों को अनुकूलित करने देता है। यह लेख बताता है कि टेबल को कैसे सक्षम करें, उसके टेक्स्ट को फ़ॉर्मेट करें, प्रत्येक प्रकार के बॉर्डर को कैसे नियंत्रित करें, और लेजेंड कुंजियों को दिखाएं या छुपाएं। उदाहरण कॉन्फ़िगर किए गए चार्ट को PPTX फ़ाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण सेट करें**

चार्ट की डेटा टेबल दिखाने के लिए, `true` को [setDataTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/#setDataTable-boolean-) के पास पास करें। टेबल तक पहुँचने और उसकी टेक्स्ट फ़ॉर्मेटिंग कॉन्फ़िगर करने के लिए [getChartDataTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/#getChartDataTable--) का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रेज़ेंटेशन को लोड करें।  
2. पहली स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।  
3. चार्ट की डेटा टेबल को सक्रिय करें।  
4. [setFontBold](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) के साथ बोल्ड टेक्स्ट सक्रिय करें और 20 पॉइंट टेक्स्ट के लिए [setFontHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) को `20` पास करें।  
5. परिवर्तित प्रेज़ेंटेशन को सहेजें।

निम्नलिखित उदाहरण को कार्यशील डायरेक्टरी में कम से कम एक स्लाइड वाली `test.pptx` फ़ाइल की आवश्यकता होती है। यह (50, 50) स्थिति पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है, जिसकी चौड़ाई 600 पॉइंट और ऊँचाई 400 पॉइंट है। सहेजी गई `output.pptx` में चार्ट की डेटा टेबल सक्रिय और निर्दिष्ट फ़ॉन्ट सेटिंग्स लागू होती हैं।

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

## **डेटा टेबल बॉर्डर को कस्टमाइज़ करें**

[IChart.setDataTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setDataTable-boolean-) के साथ टेबल को सक्रिय करें और इसे [IChart.getChartDataTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#getChartDataTable--) के माध्यम से पहुँचें। आप तीन प्रकार के बॉर्डर को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [setBorderHorizontal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) क्षैतिज सेल बॉर्डर को नियंत्रित करता है।  
- [setBorderVertical](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) लंबवत सेल बॉर्डर को नियंत्रित करता है।  
- [setBorderOutline](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) टेबल की बाहरी बॉर्डर को नियंत्रित करता है।

प्रत्येक मेथड को `true` पास करने से उसका बॉर्डर दिखेगा या `false` पास करने से छुपेगा। निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज बॉर्डर और बाहरी बॉर्डर दिखाता है, और लंबवत बॉर्डर छुपाता है। इसे कोई इनपुट फ़ाइल चाहिए नहीं। चार्ट की स्थिति और आकार पॉइंट में निर्दिष्ट हैं।

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

नीचे का तुलना चार मामलों में एक ही चार्ट डेटा और लेजेंड कुंजी सेटिंग का उपयोग करता है। सभी बॉर्डर सक्रिय से शुरू करके, प्रत्येक अगला वैरिएंट केवल एक बॉर्डर सेटिंग को अक्षम करता है। निचला-बायाँ वैरिएंट उदाहरण के बॉर्डर सेटिंग्स से मेल खाता है।

![सभी बॉर्डर सक्रिय, कोई क्षैतिज बॉर्डर नहीं, कोई लंबवत बॉर्डर नहीं, और कोई बाहरी बॉर्डर नहीं वाले चार्ट डेटा टेबल](data-table-borders.png)

## **लेजेंड कुंजियों को दिखाएँ या छुपाएँ**

लेजेंड कुंजियाँ डेटा टेबल में श्रृंखला नामों के बगल में छोटे रंगीन मार्कर होते हैं। ये पढ़ने वालों को प्रत्येक टेबल पंक्ति को चार्ट श्रृंखला से मिलाने में मदद करती हैं। इन मार्करों को दिखाने के लिए `true` को [setShowLegendKey](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) में पास करें या छुपाने के लिए `false` पास करें।

चार्ट की अलग लेजेंड [IChart.setLegend](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setLegend-boolean-) द्वारा नियंत्रित होती है। ये सेटिंग्स स्वतंत्र हैं: अलग लेजेंड को छुपाने से डेटा टेबल के भीतर की कुंजियाँ नहीं छुपतीं, और टेबल की कुंजियों को छुपाने से अलग लेजेंड नहीं छुपती।

निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है, उसकी डेटा टेबल को सक्रिय करता है, और अलग लेजेंड को छुपाते हुए उसके भीतर लेजेंड कुंजियों को दिखाता है। सभी टेबल बॉर्डर स्पष्ट रूप से सक्रिय हैं। कोई इनपुट प्रेज़ेंटेशन आवश्यक नहीं है। केवल टेबल की कुंजियों को छुपाने के लिए, [setShowLegendKey](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) को `false` पास करें।

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

नीचे का तुलना उसी टेबल को लेजेंड कुंजियों के सक्रिय और निष्क्रिय स्थिति में दिखाता है। सभी बॉर्डर सक्रिय रहते हैं, और अलग चार्ट लेजेंड दोनों मामलों में छुपी हुई है।

![बाएँ ओर लेजेंड कुंजियाँ दिखाए हुए और दाएँ ओर छिपी हुई चार्ट डेटा टेबल](data-table-legend-keys.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा टेबल में लेजेंड कुंजियाँ दिखा सकता हूँ?**

हाँ। लेजेंड कुंजियों को दिखाने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) में `true` पास करें या उन्हें छुपाने के लिए `false` पास करें।

**क्या प्रेज़ेंटेशन को PDF, HTML, या इमेजेज़ में एक्सपोर्ट करने पर डेटा टेबल सुरक्षित रहती है?**

हाँ। Aspose.Slides चार्ट और उसकी प्रदर्शित डेटा टेबल को स्लाइड का हिस्सा मानते हुए PDF, HTML, या इमेजेज़ में एक्सपोर्ट करता है।  
[PDF](/slides/hi/java/convert-powerpoint-to-pdf/) | [HTML](/slides/hi/java/convert-powerpoint-to-html/) | [images](/slides/hi/java/convert-powerpoint-to-png/)

**क्या मैं टेम्प्लेट से लोड किए गए चार्ट में डेटा टेबल के साथ काम कर सकता हूँ?**

हाँ। मौजूदा प्रेज़ेंटेशन या टेम्प्लेट से लोड किए गए चार्ट के लिए, डेटा टेबल दिख रहा है या नहीं, जानने/बदलने के लिए [hasDataTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/#hasDataTable--) और [setDataTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/#setDataTable-boolean-) का उपयोग करें।

**मैं कैसे पता करूँ कि कौन से चार्ट में डेटा टेबल सक्रिय है?**

प्रत्येक स्लाइड पर शैप्स को इटरेट करके, चार्ट पहचानें और उनके [hasDataTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/#hasDataTable--) मेथड को कॉल करें। `true` मान दर्शाता है कि डेटा टेबल सक्रिय है।
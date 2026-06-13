---
title: जावा में डिफ़ॉल्ट प्रस्तुति फ़ॉन्ट निर्दिष्ट करें
linktitle: डिफ़ॉल्ट फ़ॉन्ट
type: docs
weight: 30
url: /hi/java/default-font/
keywords:
- डिफ़ॉल्ट फ़ॉन्ट
- नियमित फ़ॉन्ट
- सामान्य फ़ॉन्ट
- एशियाई फ़ॉन्ट
- PDF निर्यात
- XPS निर्यात
- इमेज निर्यात
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java में डिफ़ॉल्ट फ़ॉन्ट सेट करें ताकि PowerPoint (PPT, PPTX) और OpenDocument (ODP) का PDF, XPS और इमेज में सही रूपांतरण सुनिश्चित हो सके।"
---
## **अवलोकन**

Aspose.Slides आपको डिफ़ॉल्ट फ़ॉन्ट निर्धारित करने की अनुमति देता है जो प्रस्तुति के रेंडर होने पर उपयोग होते हैं। यह स्लाइड थंबनेल जनरेट करने या प्रस्तुति को PDF और XPS जैसे फ़ॉर्मैट में एक्सपोर्ट करने के समय उपयोगी होता है। डिफ़ॉल्ट फ़ॉन्ट `LoadOptions` के माध्यम से प्रस्तुति लोड होने से पहले कॉन्फ़िगर किए जाते हैं।

`setDefaultRegularFont` मेथड नियमित टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट निर्धारित करता है, जबकि `setDefaultAsianFont` एशियाई टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट तय करता है। इन विकल्पों को सेट करने के बाद, प्रस्तुति को लोड किया जा सकता है और निर्दिष्ट फ़ॉन्ट का उपयोग करके रेंडर किया जा सकता है।

## **प्रस्तुति को रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट का उपयोग**

Aspose.Slides आपको PDF, XPS या थंबनेल बनाने के लिए प्रस्तुति को रेंडर करते समय डिफ़ॉल्ट फ़ॉन्ट सेट करने देता है। यह लेख दिखाता है कि DefaultRegularFont और DefaultAsianFont को डिफ़ॉल्ट फ़ॉन्ट के रूप में कैसे परिभाषित किया जाए। कृपया नीचे दिए गए चरणों का पालन करें ताकि Aspose.Slides for Java API का उपयोग करके बाहरी डायरेक्टरी से फ़ॉन्ट लोड किए जा सकें:

1. [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LoadOptions) का एक इंस्टेंस बनाएं।
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) को अपनी इच्छित फ़ॉन्ट पर सेट करें। निम्न उदाहरण में, मैंने Wingdings का उपयोग किया है।
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) को अपनी इच्छित फ़ॉन्ट पर सेट करें। निम्न नमूने में मैंने Wingdings का उपयोग किया है।
4. Presentation का उपयोग करके और लोड विकल्प सेट करके प्रस्तुति लोड करें।
5. अब, स्लाइड थंबनेल, PDF और XPS जनरेट करके परिणामों की पुष्टि करें।

ऊपर का कार्यान्वयन नीचे दिया गया है।

```java
// लोड विकल्प का उपयोग करके डिफ़ॉल्ट नियमित और एशियाई फ़ॉन्ट परिभाषित करें
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// प्रस्तुति लोड करें
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // स्लाइड थंबनेल जेनरेट करें
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // डिस्क पर इमेज सहेजें।
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDF जेनरेट करें
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPS जेनरेट करें
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**DefaultRegularFont और DefaultAsianFont वास्तव में क्या प्रभावित करते हैं—केवल एक्सपोर्ट, या थंबनेल, PDF, XPS, HTML और SVG भी?**

वे सभी समर्थित आउटपुट के रेंडरिंग पाइपलाइन में भाग लेते हैं। इसमें स्लाइड थंबनेल, [PDF](/slides/hi/java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/java/convert-powerpoint-to-xps/), [रास्टर इमेज](/slides/hi/java/convert-powerpoint-to-png/), [HTML](/slides/hi/java/convert-powerpoint-to-html/), और [SVG](/slides/hi/java/render-a-slide-as-an-svg-image/) शामिल हैं, क्योंकि Aspose.Slides इन लक्ष्यों के लिए समान लेआउट और ग्लिफ़ समाधान लॉजिक का उपयोग करता है।

**क्या डिफ़ॉल्ट फ़ॉन्ट केवल पढ़ने और PPTX को सेव करने पर लागू होते हैं, बिना किसी रेंडरिंग के?**

नहीं। डिफ़ॉल्ट फ़ॉन्ट तब महत्वपूर्ण होते हैं जब टेक्स्ट को मापना और ड्रॉ करना आवश्यक हो। प्रस्तुति को सिर्फ़ खोलकर‑सेव करने से संग्रहीत फ़ॉन्ट रन या फ़ाइल की संरचना में बदलाव नहीं आता। डिफ़ॉल्ट फ़ॉन्ट उन ऑपरेशनों में उपयोग होते हैं जो टेक्स्ट को रेंडर या रीफ़्लो करते हैं।

**यदि मैं अपने फ़ॉन्ट फ़ोल्डरों को जोड़ूँ या मेमोरी से फ़ॉन्ट प्रदान करूँ, तो क्या उन्हें डिफ़ॉल्ट फ़ॉन्ट चुनने में विचार किया जाएगा?**

हां। [Custom font sources](/slides/hi/java/custom-font/) उपलब्ध फ़ॉन्ट परिवारों और ग्लिफ़ों का कैटलॉग विस्तारित करती है जिसे इंजन उपयोग कर सकता है। डिफ़ॉल्ट फ़ॉन्ट और कोई भी [fallback rules](/slides/hi/java/fallback-font/) पहले इन स्रोतों के विरुद्ध रिज़ॉल्व होंगे, जिससे सर्वर और कंटेनर में अधिक विश्वसनीय कवरेज मिलता है।

**क्या डिफ़ॉल्ट फ़ॉन्ट टेक्स्ट मीट्रिक (कर्निंग, एडवांस) को प्रभावित करेंगे और इस प्रकार लाइन ब्रेक और रैपिंग को?**

हां। फ़ॉन्ट बदलने से ग्लिफ़ मीट्रिक बदलते हैं और रेंडरिंग के दौरान लाइन ब्रेक, रैपिंग और पेजिनेशन में परिवर्तन हो सकता है। लेआउट स्थिरता के लिए, [embed the original fonts](/slides/hi/java/embedded-font/) या मीट्रिकली संगत डिफ़ॉल्ट और फ़ॉलबैक परिवार चुनें।

**क्या प्रस्तुति में उपयोग किए सभी फ़ॉन्ट एम्बेडेड होने पर डिफ़ॉल्ट फ़ॉन्ट सेट करने का कोई मतलब है?**

अक्सर यह आवश्यक नहीं होता, क्योंकि [embedded fonts](/slides/hi/java/embedded-font/) पहले से ही सुसंगत रूप सुनिश्चित करते हैं। डिफ़ॉल्ट फ़ॉन्ट अभी भी एक सुरक्षा जाल के रूप में मदद करते हैं उन अक्षरों के लिए जो एम्बेडेड सबसेट में नहीं हैं या जब फ़ाइल एम्बेडेड और गैर‑एम्बेडेड टेक्स्ट दोनों को मिलाती है।
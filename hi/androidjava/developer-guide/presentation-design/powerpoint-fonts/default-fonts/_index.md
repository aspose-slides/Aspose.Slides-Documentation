---
title: Android पर डिफ़ॉल्ट प्रस्तुति फ़ॉन्ट्स निर्धारित करें
linktitle: डिफ़ॉल्ट फ़ॉन्ट
type: docs
weight: 30
url: /hi/androidjava/default-font/
keywords:
- डिफ़ॉल्ट फ़ॉन्ट
- रेगुलर फ़ॉन्ट
- सामान्य फ़ॉन्ट
- एशियन फ़ॉन्ट
- PDF निर्यात
- XPS निर्यात
- इमेज निर्यात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में डिफ़ॉल्ट फ़ॉन्ट सेट करें ताकि PowerPoint (PPT, PPTX) और OpenDocument (ODP) का PDF, XPS और इमेज में सही रूपांतरण सुनिश्चित हो सके।"
---
## **सारांश**

Aspose.Slides आपको डिफ़ॉल्ट फ़ॉन्ट्स निर्दिष्ट करने की अनुमति देता है जो प्रस्तुति रेंडर होने पर उपयोग होते हैं। यह स्लाइड थंबनेल बनाते समय या प्रस्तुति को PDF और XPS जैसे फ़ॉर्मेट में निर्यात करते समय उपयोगी है। डिफ़ॉल्ट फ़ॉन्ट्स `LoadOptions` के माध्यम से कॉन्फ़िगर किए जाते हैं, इससे पहले कि प्रस्तुति लोड की जाए।

`setDefaultRegularFont` मेथड नियमित टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है, जबकि `setDefaultAsianFont` एशियन टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है। इन विकल्पों को सेट करने के बाद, प्रस्तुति को लोड और रेंडर किया जा सकता है जिसमें निर्दिष्ट फ़ॉन्ट्स उपयोग होते हैं।

## **प्रस्तुति को रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट्स का उपयोग**
Aspose.Slides आपको प्रस्तुति को PDF, XPS या थंबनेल में रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट सेट करने देता है। यह लेख दिखाता है कि डिफ़ॉल्ट Regular Font और Default Asian Font को डिफ़ॉल्ट फ़ॉन्ट्स के रूप में कैसे परिभाषित किया जाए। कृपया नीचे दिए गए चरणों का पालन करके Aspose.Slides for Android via Java API का उपयोग करके बाहरी निर्देशिकाओं से फ़ॉन्ट्स लोड करें:

1. LoadOptions का एक उदाहरण बनाएं।[LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LoadOptions)  
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) को अपने इच्छित फ़ॉन्ट पर सेट करें। नीचे के उदाहरण में, मैंने Wingdings का उपयोग किया है।  
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) को अपने इच्छित फ़ॉन्ट पर सेट करें। मैंने नीचे के नमूने में Wingdings का उपयोग किया है।  
4. Presentation का उपयोग करके प्रस्तुति लोड करें और लोड विकल्प सेट करें।  
5. अब, परिणामों को सत्यापित करने के लिए स्लाइड थंबनेल, PDF और XPS जनरेट करें।  

उपर्युक्त का कार्यान्वयन नीचे दिया गया है।

```java
// लोड विकल्पों का उपयोग करके डिफ़ॉल्ट रेगुलर और एशियन फ़ॉन्ट्स निर्धारित करें
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// प्रस्तुति लोड करें
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // स्लाइड थंबनेल बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // छवि को डिस्क पर सहेजें।
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDF बनाएं
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPS बनाएं
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**DefaultRegularFont और DefaultAsianFont वास्तव में क्या प्रभावित करते हैं—केवल निर्यात, या थंबनेल, PDF, XPS, HTML, और SVG सहित?**

वे सभी समर्थित आउटपुट के लिए रेंडरिंग पाइपलाइन में भाग लेते हैं। इसमें स्लाइड थंबनेल, [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/hi/androidjava/convert-powerpoint-to-xps/), [raster images](/slides/hi/androidjava/convert-powerpoint-to-png/), [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/), और [SVG](/slides/hi/androidjava/render-a-slide-as-an-svg-image/) शामिल हैं, क्योंकि Aspose.Slides इन लक्ष्यों के बीच समान लेआउट और ग्लिफ़ समाधान लॉजिक का उपयोग करता है।

**क्या डिफ़ॉल्ट फ़ॉन्ट्स सिर्फ पढ़ने और बिना किसी रेंडरिंग के PPTX को सहेजने पर भी लागू होते हैं?**

नहीं। डिफ़ॉल्ट फ़ॉन्ट्स तब महत्वपूर्ण होते हैं जब टेक्स्ट को मापना और ड्रॉ करना आवश्यक हो। प्रस्तुति का सीधा खोल‑से‑सहेजना फ़ॉन्ट रन्स या फ़ाइल की संरचना को नहीं बदलता। डिफ़ॉल्ट फ़ॉन्ट्स उन कार्यों में भूमिका निभाते हैं जो टेक्स्ट को रेंडर या रीफ़्लो करते हैं।

**यदि मैं अपने स्वयं के फ़ॉन्ट फ़ोल्डर्स जोड़ूँ या मेमोरी से फ़ॉन्ट्स प्रदान करूँ, तो क्या उन्हें डिफ़ॉल्ट फ़ॉन्ट चुनते समय माना जाएगा?**

हां। [Custom font sources](/slides/hi/androidjava/custom-font/) उपलब्ध फ़ॉन्ट परिवारों और ग्लिफ़्स की सूची को विस्तारित करते हैं जिन्हें इंजन उपयोग कर सकता है। डिफ़ॉल्ट फ़ॉन्ट्स और कोई भी [fallback rules](/slides/hi/androidjava/fallback-font/) पहले इन स्रोतों के विरुद्ध रिज़ॉल्व करेंगे, जिससे सर्वरों और कंटेनरों पर कवरेज अधिक विश्वसनीय हो जाएगा।

**क्या डिफ़ॉल्ट फ़ॉन्ट्स टेक्स्ट मीट्रिक (केरनिंग, एडवांस) को प्रभावित करेंगे और इस प्रकार लाइन ब्रेक और रैपिंग को बदल देंगे?**

हां। फ़ॉन्ट बदलने से ग्लिफ़ मीट्रिक बदलते हैं और रेंडरिंग के दौरान लाइन ब्रेक, रैपिंग और पेजिंग बदल सकती है। लेआउट स्थिरता के लिए, [embed the original fonts](/slides/hi/androidjava/embedded-font/) या मीट्रिकली संगत डिफ़ॉल्ट एवं फ़ॉलबैक परिवारों का चयन करें।

**यदि प्रस्तुति में प्रयुक्त सभी फ़ॉन्ट्स एंबेडेड हैं, तो डिफ़ॉल्ट फ़ॉन्ट्स सेट करने का कोई मतलब है क्या?**

अक्सर यह आवश्यक नहीं होता, क्योंकि [embedded fonts](/slides/hi/androidjava/embedded-font/) पहले से ही समान दिखावट सुनिश्चित करते हैं। डिफ़ॉल्ट फ़ॉन्ट्स फिर भी एक सुरक्षा जाल के रूप में काम करते हैं उन अक्षरों के लिए जो एंबेडेड सबसेट में नहीं हैं या जब फ़ाइल एंबेडेड और नॉन‑एंबेडेड टेक्स्ट दोनों को मिलाती है।
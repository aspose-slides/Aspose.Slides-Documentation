---
title: जावास्क्रिप्ट में डिफ़ॉल्ट प्रस्तुति फ़ॉन्ट निर्धारित करें
linktitle: डिफ़ॉल्ट फ़ॉन्ट
type: docs
weight: 30
url: /hi/nodejs-java/default-font/
keywords:
- डिफ़ॉल्ट फ़ॉन्ट
- नियमित फ़ॉन्ट
- सामान्य फ़ॉन्ट
- एशियाई फ़ॉन्ट
- PDF निर्यात
- XPS निर्यात
- छवि निर्यात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js को जावा के माध्यम से डिफ़ॉल्ट फ़ॉन्ट सेट करें ताकि PowerPoint (PPT, PPTX) और OpenDocument (ODP) को PDF, XPS और छवियों में सही रूप से परिवर्तित किया जा सके।"
---
## **अवलोकन**

Aspose.Slides आपको उन डिफ़ॉल्ट फ़ॉन्ट को निर्दिष्ट करने की अनुमति देता है जो प्रस्तुति को रेंडर किया जाता है। यह स्लाइड थंबनेल बनाने या प्रस्तुति को PDF और XPS जैसे फ़ॉर्मेट में निर्यात करने के समय उपयोगी है। डिफ़ॉल्ट फ़ॉन्ट `LoadOptions` के माध्यम से प्रस्तुति लोड होने से पहले कॉन्फ़िगर किए जाते हैं।

`setDefaultRegularFont` मेथड सामान्य टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है, जबकि `setDefaultAsianFont` एशियाई टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है। इन विकल्पों को सेट करने के बाद, प्रस्तुति को लोड किया जा सकता है और निर्दिष्ट फ़ॉन्ट का उपयोग करके रेंडर किया जा सकता है।

## **प्रस्तुति को रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट का उपयोग**

Aspose.Slides आपको PDF, XPS या थंबनेल के लिए प्रस्तुति को रेंडर करने के समय डिफ़ॉल्ट फ़ॉन्ट सेट करने देती है। यह लेख दिखाता है कि DefaultRegular फ़ॉन्ट और DefaultAsian फ़ॉन्ट को डिफ़ॉल्ट फ़ॉन्ट के रूप में कैसे परिभाषित किया जाए। कृपया नीचे दिए गए चरणों का पालन करें ताकि Aspose.Slides for Node.js को Java API के माध्यम से बाहरी निर्देशिकाओं से फ़ॉन्ट लोड किया जा सके:

1. एक [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LoadOptions) का उदाहरण बनाएँ।
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) को अपनी इच्छित फ़ॉन्ट पर सेट करें। निम्न उदाहरण में, मैंने Wingdings का उपयोग किया है।
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) को अपनी इच्छित फ़ॉन्ट पर सेट करें। मैंने निम्न उदाहरण में Wingdings का उपयोग किया है।
1. Presentation का उपयोग करके प्रस्तुति लोड करें और लोड विकल्प सेट करें।
1. अब, परिणामों को सत्यापित करने के लिए स्लाइड थंबनेल, PDF और XPS उत्पन्न करें।

ऊपर दिया गया कार्यान्वयन नीचे दिया गया है।

```javascript
// डिफ़ॉल्ट रेगुलर और एशियाई फ़ॉन्ट को परिभाषित करने के लिए लोड विकल्प का उपयोग करें
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// प्रस्तुति लोड करें
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // स्लाइड थंबनेल जनरेट करें
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // इमेज को डिस्क पर सहेजें।
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // PDF जनरेट करें
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // XPS जनरेट करें
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**DefaultRegularFont और DefaultAsianFont वास्तव में क्या प्रभावित करते हैं—केवल निर्यात, या थंबनेल, PDF, XPS, HTML, और SVG सहित?**

वे सभी समर्थित आउटपुट के लिए रेंडरिंग पाइपलाइन में भाग लेते हैं। इसमें स्लाइड थंबनेल, [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/nodejs-java/convert-powerpoint-to-xps/), [रेस्टर इमेजेज](/slides/hi/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/), और [SVG](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/) शामिल हैं, क्योंकि Aspose.Slides इन सभी लक्ष्यों में समान लेआउट और ग्लिफ़ रिज़ॉल्यूशन लॉजिक का उपयोग करता है।

**क्या डिफ़ॉल्ट फ़ॉन्ट केवल पढ़ने और PPTX को बिना किसी रेंडरिंग के सहेजने पर लागू होते हैं?**

नहीं। डिफ़ॉल्ट फ़ॉन्ट तब मायने रखते हैं जब टेक्स्ट को मापा और खींचा जाना आवश्यक हो। प्रस्तुति को केवल खोलकर सहेजने से संग्रहीत फ़ॉन्ट रन या फ़ाइल की संरचना नहीं बदलती। डिफ़ॉल्ट फ़ॉन्ट उन ऑपरेशनों के दौरान उपयोग होते हैं जो टेक्स्ट को रेंडर या रीफ़्लो करते हैं।

**यदि मैं अपने स्वयं के फ़ॉन्ट फ़ोल्डर जोड़ता हूँ या मेमोरी से फ़ॉन्ट प्रदान करता हूँ, क्या उन्हें डिफ़ॉल्ट फ़ॉन्ट चुनते समय ध्यान में रखा जाएगा?**

हाँ। [कस्टम फ़ॉन्ट स्रोत](/slides/hi/nodejs-java/custom-font/) उपलब्ध फ़ॉन्ट परिवारों और ग्लिफ़ों की सूची को विस्तृत करते हैं जो इंजन उपयोग कर सकता है। डिफ़ॉल्ट फ़ॉन्ट और कोई भी [फ़ॉलबैक नियम](/slides/hi/nodejs-java/fallback-font/) पहले इन स्रोतों के विरुद्ध समाधान करेंगे, जिससे सर्वर और कंटेनर में अधिक विश्वसनीय कवरेज मिलेगा।

**क्या डिफ़ॉल्ट फ़ॉन्ट टेक्स्ट मीट्रिक्स (करनिंग, एडवांस) को प्रभावित करेंगे और इससे लाइन ब्रेक्स और रैपिंग बदल सकते हैं?**

हाँ। फ़ॉन्ट बदलने से ग्लिफ़ मीट्रिक्स बदलते हैं और रेंडरिंग के दौरान लाइन ब्रेक, रैपिंग और पेजिनेशन प्रभावित हो सकते हैं। लेआउट स्थिरता के लिए, [मूल फ़ॉन्ट एम्बेड](/slides/hi/nodejs-java/embedded-font/) करें या मीट्रिकली संगत डिफ़ॉल्ट और फ़ॉलबैक परिवार चुनें।

**यदि प्रस्तुति में उपयोग किए सभी फ़ॉन्ट एम्बेडेड हैं, तो डिफ़ॉल्ट फ़ॉन्ट सेट करने का कोई अर्थ है?**

अक्सर यह आवश्यक नहीं होता, क्योंकि [एम्बेडेड फ़ॉन्ट](/slides/hi/nodejs-java/embedded-font/) पहले से ही सुसंगत रूप सुनिश्चित करते हैं। डिफ़ॉल्ट फ़ॉन्ट फिर भी एक सुरक्षा जाल के रूप में मदद करते हैं उन वर्णों के लिए जो एम्बेडेड उपसमुच्चय में नहीं हैं या जब फ़ाइल एम्बेडेड और गैर-एम्बेडेड टेक्स्ट को मिश्रित करती है।
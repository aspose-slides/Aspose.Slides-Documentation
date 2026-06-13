---
title: एआई-सक्षम बहुभाषी स्लाइड जनरेटर
linktitle: एआई-सक्षम जनरेटर
type: docs
weight: 40
url: /hi/nodejs-java/ai/generator/
keywords:
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- एआई प्रस्तुति जनरेटर
- एआई स्लाइड जनरेटर
- एआई-सक्षम सुविधा
- एआई एजेंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ टेक्स्ट से बहुभाषी स्लाइड बनाएं। अपना टेम्प्लेट लागू करें और परिष्कृत डेक को PowerPoint और OpenDocument में निर्यात करें। अधिक जानें।"
---
## **परिचय**

Aspose.Slides ने एक नई एआई-समर्थित सुविधा, Presentation Generator, को पेश किया है, जो डेवलपर्स को सरल टेक्स्ट इनपुट जैसे विषय विवरण, सारांश, उद्धरण, या बुलेट पॉइंट्स से स्वचालित रूप से अच्छी तरह से संरचित PowerPoint प्रस्तुतियों को बनाने में सक्षम बनाता है।

उपयोगकर्ता सामग्री विवरण के स्तर को समायोजित कर सकते हैं और वैकल्पिक रूप से एक कस्टम प्रस्तुति टेम्प्लेट लागू करके दृश्य डिज़ाइन को परिभाषित कर सकते हैं।

वर्तमान में, AI Presentation Generator टेक्स्ट ब्लॉक्स, बुलेट लिस्ट और तालिकाओं का उपयोग करके सामग्री को संरचित करता है। इमेज जेनरेशन अभी समर्थित नहीं है; हालांकि, इमेज को बाद में Aspose.Slides टूल्स या मैन्युअल रूप से आसानी से जोड़ा जा सकता है।

आउटपुट एक पूर्ण PowerPoint प्रस्तुति है जिसे जैसा है वैसा उपयोग किया जा सकता है या Aspose.Slides API द्वारा समर्थित किसी भी फ़ॉर्मेट में निर्यात किया जा सकता है। जबकि जेनरेटर उच्च-गुणवत्ता वाले परिणाम उत्पन्न करता है, विशिष्ट आवश्यकताओं को पूरा करने के लिए मामूली पोस्ट-एडिटिंग की आवश्यकता हो सकती है।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI मॉडल नहीं हैं; बल्कि, यह इंटरनेट के माध्यम से बाहरी AI सेवाओं के साथ एकीकृत होता है। यह एकीकरण [SlidesAIAgent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesaiagent/) क्लास द्वारा संभाला जाता है।

आप बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग कर सकते हैं, जो OpenAI की API से जुड़ता है। Aspose.Slides AI सेवा के साथ सभी संचार को प्रबंधित करता है और स्लाइड्स बनाने के लिए AI की प्रतिक्रियाओं को प्रोसेस करता है। ध्यान दें कि OpenAI API एक पेड सेवा है, इसलिए बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करने पर एक खाता और API कुंजी की आवश्यकता होती है।

## **आइए कोड लिखें**

### **उदाहरण 1**

यह उदाहरण दिखाता है कि कैसे बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करके Aspose.Slides विषय पर एक प्रस्तुति उत्पन्न की जाए।

```js
// OpenAIWebClient का एक इंस्टेंस बनाएं, जो OpenAI वेब क्लाइंट का अंतर्निहित कार्यान्वयन है।
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // SlidesAIAgent का एक इंस्टेंस बनाएं, जो एआई-सक्षम सुविधाओं तक पहुंच प्रदान करता है।
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // प्रस्तुति उत्पन्न करने के लिए निर्देश परिभाषित करें।
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // निर्देश के आधार पर मध्यम मात्रा की सामग्री वाली प्रस्तुति उत्पन्न करें।
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // उत्पन्न प्रस्तुति को स्थानीय डिस्क पर PowerPoint (.pptx) फ़ाइल के रूप में सहेजें।
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **उदाहरण 2**

निम्न उदाहरण [generatePresentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) मेथड के ओवरलोड्स को दर्शाता है। इस मामले में, एक बाहरी रूप से मैनेज किया गया [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस और उपयोगकर्ता की `master presentation` का उपयोग किया जाता है।

डिफ़ॉल्ट रूप से, बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) अपना स्वयं का इंटरनल [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, तथा इसके जीवनचक्र को स्वचालित रूप से संभालता है। हालांकि, यदि आप स्वयं [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को प्रबंधित करना चाहते हैं—उदाहरण के लिए, बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करते समय—तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) को निर्माण करते समय अपना स्वयं का [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस प्रदान कर सकते हैं।

```js
// HttpURLConnection को OpenAIWebClient कन्स्ट्रक्टर में पास करें.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // SlidesAIAgent का एक इंस्टेंस बनाएं.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // प्रस्तुति उत्पन्न करने के लिए निर्देश परिभाषित करें.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // स्थानीय डिस्क से मास्टर प्रस्तुति लोड करें ताकि इसे डिज़ाइन टेम्प्लेट के रूप में उपयोग किया जा सके.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // निर्देश और मास्टर टेम्प्लेट का उपयोग करके विस्तृत प्रस्तुति उत्पन्न करें.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // उत्पन्न प्रस्तुति को PDF के रूप में सहेजें.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **मुख्य लाभ**

Aspose.Slides में नया AI Presentation Generator सरल टेक्स्ट प्रॉम्प्ट्स से संरचित स्लाइड डेक्स बनाने का एक तेज़ और लचीला तरीका प्रदान करता है। कस्टम टेम्प्लेट्स और बाहरी रूप से मैनेज किए गए [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस का समर्थन करके, इसे विभिन्न प्रकार के अनुप्रयोगों में सहजता से एकीकृत किया जा सकता है।

सामान्य उपयोग मामलों में मार्केटिंग प्रस्तुतियों, शैक्षणिक सामग्री, क्लाइंट रिपोर्ट और आंतरिक स्लाइड डेक्स का निर्माण शामिल है। हालांकि इमेज जेनरेशन अभी समर्थित नहीं है, यह टूल पहले से ही प्रस्तुति निर्माण को स्वचालित करने के लिए एक मजबूत आधार प्रदान करता है, और भविष्य में अतिरिक्त सुधारों की अपेक्षा है।
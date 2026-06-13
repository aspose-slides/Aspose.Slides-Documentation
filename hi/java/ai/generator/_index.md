---
title: AI-संचालित बहुभाषी स्लाइड जेनरेटर
linktitle: AI-संचालित जेनरेटर
type: docs
weight: 40
url: /hi/java/ai/generator/
keywords:
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- AI प्रस्तुति जेनरेटर
- AI स्लाइड जेनरेटर
- AI-संचालित सुविधा
- AI एजेंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ टेक्स्ट से बहुभाषी स्लाइड्स बनाएं। अपना टेम्पलेट लागू करें और पोलिश्ड डेक्स को PowerPoint और OpenDocument में निर्यात करें। अधिक जानें।"
---
## **परिचय**

Aspose.Slides एक नई AI-संचालित सुविधा, Presentation Generator, प्रस्तुत करता है, जो डेवलपर्स को सरल टेक्स्ट इनपुट जैसे विषय विवरण, सारांश, उद्धरण या बुलेट पॉइंट्स से स्वचालित रूप से अच्छी तरह संरचित PowerPoint प्रस्तुतियों को बनाने में सक्षम बनाता है।

उपयोगकर्ता कंटेंट विवरण के स्तर को समायोजित कर सकते हैं और वैकल्पिक रूप से एक कस्टम प्रेजेंटेशन टेम्पलेट लागू करके दृश्य डिजाइन को परिभाषित कर सकते हैं।

वर्तमान में, AI Presentation Generator टेक्स्ट ब्लॉक्स, बुलेट सूचियों और तालिकाओं का उपयोग करके सामग्री को संरचित करता है। इमेज जेनरेशन अभी समर्थित नहीं है; हालांकि, इमेज को बाद में आसानी से Aspose.Slides टूल्स या मैन्युअल रूप से जोड़ सकते हैं।

आउटपुट एक पूर्ण PowerPoint प्रस्तुति है जिसे जैसा है वैसा उपयोग किया जा सकता है या Aspose.Slides API द्वारा समर्थित किसी भी फॉर्मेट में एक्सपोर्ट किया जा सकता है। जबकि जेनरेटर उच्च गुणवत्ता वाले परिणाम देता है, विशिष्ट आवश्यकताओं को पूरा करने के लिए मामूली पोस्ट-एडिटिंग की आवश्यकता हो सकती है।

## **यह कैसे काम करता है**

Aspose.Slides में बिल्ट-इन AI मॉडल नहीं होते; इसके बजाय, यह इंटरनेट के माध्यम से बाहरी AI सेवाओं के साथ एकीकृत होता है। यह एकीकरण [SlidesAIAgent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesaiagent/) क्लास द्वारा संभाला जाता है, जो AI मॉडल के साथ संचार करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) इंटरफ़ेस का एक इम्प्लीमेंटेशन उपयोग करता है।

आप बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग कर सकते हैं, जो OpenAI के API से कनेक्ट होता है, या किसी अन्य AI प्रदाता या भाषा मॉडल के साथ काम करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) का कस्टम इम्प्लीमेंटेशन प्रदान कर सकते हैं। Aspose.Slides AI सेवा के साथ सभी संचार को प्रबंधित करता है और स्लाइड्स जेनरेट करने के लिए AI की प्रतिक्रियाओं को प्रोसेस करता है। ध्यान दें कि OpenAI API एक पेड सेवा है, इसलिए बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करने के लिए एक अकाउंट और API कुंजी आवश्यक है।

## **आइए कोड लिखें**

### **उदाहरण 1**

यह उदाहरण दिखाता है कि कैसे बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करके Aspose.Slides विषय पर एक प्रस्तुति जेनरेट की जा सकती है।

```java
// OpenAIWebClient का एक इंस्टेंस बनाएं, जो OpenAI वेब क्लाइंट का बिल्ट-इन इम्प्लीमेंटेशन है।
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // SlidesAIAgent का एक इंस्टेंस बनाएं, जो AI-संचालित सुविधाओं तक पहुंच प्रदान करता है।
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // प्रस्तुति बनाने के लिए निर्देश परिभाषित करें।
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // निर्देश के आधार पर मध्यम मात्रा की सामग्री के साथ एक प्रस्तुति जेनरेट करें।
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // जेनरेट की गई प्रस्तुति को स्थानीय डिस्क पर PowerPoint (.pptx) फ़ाइल के रूप में सहेजें।
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **उदाहरण 2**

निम्नलिखित उदाहरण [generatePresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) मेथड के ओवरलोड को दर्शाता है। इस मामले में, एक बाहरी रूप से प्रबंधित [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस और उपयोगकर्ता की `master presentation` का उपयोग किया जाता है।

डिफ़ॉल्ट रूप से, बिल्ट-इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, और इसका लाइफ़साइकल स्वतः संभालता है। हालांकि, यदि आप स्वयं [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को प्रबंधित करना पसंद करते हैं—उदाहरण के लिए, बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करते समय—तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का निर्माण करते समय अपना खुद का [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस प्रदान कर सकते हैं।

```java
// HttpURLConnection को OpenAIWebClient कॉन्स्ट्रक्टर में पास करें।
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // SlidesAIAgent का एक इंस्टेंस बनाएं।
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // प्रस्तुति बनाने के लिए निर्देश परिभाषित करें।
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // डिजाइन टेम्प्लेट के रूप में उपयोग करने हेतु स्थानीय डिस्क से एक मास्टर प्रस्तुति लोड करें।
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // निर्देश और मास्टर टेम्प्लेट का उपयोग करके विस्तृत प्रस्तुति जेनरेट करें।
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // जेनरेट की गई प्रस्तुति को PDF के रूप में सहेजें।
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **मुख्य लाभ**

Aspose.Slides में नया AI Presentation Generator सरल टेक्स्ट प्रॉम्प्ट्स से संरचित स्लाइड डेक्स बनाने का तेज़ और लचीला तरीका प्रदान करता है। कस्टम टेम्पलेट्स और बाहरी रूप से प्रबंधित [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस के समर्थन के साथ, इसे विस्तृत श्रेणी के अनुप्रयोगों में सहजता से एकीकृत किया जा सकता है।

सामान्य उपयोग मामलों में मार्केटिंग प्रस्तुतियों, शैक्षणिक सामग्री, क्लाइंट रिपोर्ट और आंतरिक स्लाइड डेक्स बनाना शामिल है। भले ही इमेज जेनरेशन अभी समर्थित नहीं है, टूल पहले से ही प्रस्तुति निर्मान को स्वचालित करने के लिए एक ठोस आधार प्रदान करता है, और भविष्य में आगे सुधारों की उम्मीद है।
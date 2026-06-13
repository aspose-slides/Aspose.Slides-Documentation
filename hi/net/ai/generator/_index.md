---
title: AI-समर्थित बहुभाषी स्लाइड जनरेटर
linktitle: AI-समर्थित जनरेटर
type: docs
weight: 40
url: /hi/net/ai/generator/
keywords:
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- AI प्रेज़ेंटेशन जनरेटर
- AI स्लाइड जनरेटर
- AI-समर्थित सुविधा
- AI एजेंट
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ टेक्स्ट से बहुभाषी स्लाइड बनाएं। अपना टेम्पलेट लागू करें और परिष्कृत डेक्स को PowerPoint और OpenDocument में निर्यात करें। अधिक जानें।"
---
## **परिचय**

Aspose.Slides ने एक नई AI-संचालित सुविधा, प्रेज़ेंटेशन जनरेटर, पेश की है, जो डेवलपर्स को सरल टेक्स्ट इनपुट जैसे टॉपिक विवरण, सारांश, उद्धरण या बुलेट पॉइंट्स से स्वचालित रूप से अच्छी तरह संरचित PowerPoint प्रेज़ेंटेशन बनाने में सक्षम बनाता है।

उपयोगकर्ता सामग्री विवरण के स्तर को समायोजित कर सकते हैं और वैकल्पिक रूप से एक कस्टम प्रेज़ेंटेशन टेम्पलेट लागू करके दृश्य डिज़ाइन को परिभाषित कर सकते हैं।

वर्तमान में, AI प्रेज़ेंटेशन जनरेटर टेक्स्ट ब्लॉक्स, बुलेट सूचियों और तालिकाओं का उपयोग करके सामग्री को संरचित करता है। इमेज जेनरेशन अभी समर्थित नहीं है; हालांकि, इमेज को बाद में Aspose.Slides टूल्स या मैन्युअली जोड़ना आसान है।

आउटपुट एक पूर्ण PowerPoint प्रेज़ेंटेशन है जिसे जैसा का तैसा उपयोग किया जा सकता है या Aspose.Slides API द्वारा समर्थित किसी भी फ़ॉर्मेट में निर्यात किया जा सकता है। जबकि जनरेटर उच्च‑गुणवत्ता वाले परिणाम देता है, विशिष्ट आवश्यकताओं को पूरा करने के लिए थोड़ा पोस्ट‑एडिटिंग आवश्यक हो सकता है।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI मॉडल नहीं होते; इसके बजाय, यह इंटरनेट के माध्यम से बाहरी AI सेवाओं के साथ एकीकृत होता है। यह एकीकरण [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent/) क्लास द्वारा संभाला जाता है, जो AI मॉडल के साथ संचार करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) इंटरफ़ेस के कार्यान्वयन का उपयोग करता है।

आप अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग कर सकते हैं, जो OpenAI के API से कनेक्ट होता है, या किसी अन्य AI प्रोवाइडर या भाषा मॉडल के साथ काम करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) का कस्टम कार्यान्वयन प्रदान कर सकते हैं। Aspose.Slides AI सेवा के साथ सभी संचार को प्रबंधित करता है और स्लाइड्स बनाने के लिए AI की प्रतिक्रियाओं को प्रोसेस करता है। ध्यान दें कि OpenAI API एक भुगतानित सेवा है, इसलिए अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करते समय खाते और API कुंजी की आवश्यकता होती है।

## **चलो कोड लिखें**

### **उदाहरण 1**

यह उदाहरण दिखाता है कि अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करके Aspose.Slides विषय पर प्रेज़ेंटेशन कैसे जेनरेट किया जाए।

```csharp
// OpenAIWebClient का एक इंस्टेंस बनाएं, जो OpenAI वेब क्लाइंट का बिल्ट-इन इम्प्लीमेंटेशन है।
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// SlidesAIAgent का एक इंस्टेंस बनाएं, जो AI-समर्थित सुविधाओं तक पहुंच प्रदान करता है।
var aiAgent = new SlidesAIAgent(aiWebClient);

// प्रस्तुति जनरेट करने के लिए निर्देश को परिभाषित करें।
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// निर्देश के आधार पर मध्यम मात्रा में सामग्री के साथ एक प्रस्तुति जनरेट करें।
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// जनरेट की गई प्रस्तुति को स्थानीय डिस्क पर PowerPoint (.pptx) फ़ाइल के रूप में सहेजें।
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **उदाहरण 2**

निम्न उदाहरण [GeneratePresentation](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent/generatepresentation/) मेथड के ओवरलोड्स को दर्शाता है। इस मामले में, बाहरी रूप से प्रबंधित [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) इंस्टेंस और उपयोगकर्ता का `master presentation` उपयोग किया जाता है।

डिफ़ॉल्ट रूप से, अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) अपना स्वयं का आंतरिक [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) इंस्टेंस बनाता और प्रबंधित करता है, जिससे उसका लाइफ़साइकल और डिस्पोज़ स्वचालित रूप से संभाला जाता है। हालांकि, यदि आप स्वयं [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) का प्रबंधन करना चाहते हैं—उदाहरण के लिए, बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) का उपयोग करते समय—तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का निर्माण करते समय अपना स्वयं का [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) इंस्टेंस प्रदान कर सकते हैं।

```csharp
// बाहरी रूप से प्रबंधित HttpClient इंस्टेंस बनाएं।
using var httpClient = new HttpClient();

// HttpClient को OpenAIWebClient कंस्ट्रक्टर में पास करें।
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// SlidesAIAgent का एक इंस्टेंस बनाएं।
var aiAgent = new SlidesAIAgent(aiWebClient);

// प्रस्तुति जनरेट करने के लिए निर्देश को परिभाषित करें।
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// स्थानीय डिस्क से डिज़ाइन टेम्पलेट के रूप में उपयोग करने के लिए एक मास्टर प्रेज़ेंटेशन लोड करें।
using var masterPresentation = new Presentation("masterPresentation.pptx");

// निर्देश और मास्टर टेम्पलेट का उपयोग करके विस्तृत प्रस्तुति जनरेट करें।
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// जनरेट की गई प्रस्तुति को PDF के रूप में सहेजें।
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

यह उल्लेखनीय है कि कई ग्राहक Aspose.Slides को सिंक्रोनस संदर्भों में उपयोग करते हैं। इसे समर्थन देने के लिए, [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent/) क्लास सिंक्रोनस और असिंक्रोनस दोनों मेथड प्रदान करती है, जिससे आप अपनी एप्लिकेशन की वर्कफ़्लो के अनुसार सर्वोत्तम दृष्टिकोण चुन सकते हैं।

## **मुख्य लाभ**

Aspose.Slides में नया AI प्रेज़ेंटेशन जनरेटर सरल टेक्स्ट प्रॉम्प्ट्स से संरचित स्लाइड डेक्स बनाने का तेज़ और लचीला तरीका प्रदान करता है। कस्टम टेम्पलेट्स, बाहरी रूप से प्रबंधित [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) इंस्टेंस, और सिंक्रोनस व असिंक्रोनस दोनों वर्कफ़्लो के समर्थन के साथ, इसे विभिन्न प्रकार के एप्लिकेशन्स में सहजता से एकीकृत किया जा सकता है।

सामान्य उपयोग मामलों में मार्केटिंग प्रेज़ेंटेशन, शैक्षणिक सामग्री, क्लाइंट रिपोर्ट और आंतरिक स्लाइड डेक्स बनाना शामिल है। यद्यपि इमेज जेनरेशन अभी समर्थित नहीं है, यह टूल पहले से ही प्रेज़ेंटेशन निर्माण को स्वचालित करने के लिए एक मजबूत बुनियादी ढांचा प्रदान करता है, और भविष्य में अतिरिक्त सुधारों की अपेक्षा है।
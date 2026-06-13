---
title: AI-संचालित प्रस्तुति अनुवादक
linktitle: AI-संचालित अनुवादक
type: docs
weight: 20
url: /hi/androidjava/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-संचालित सुविधा
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI-प्रेरित सुविधाएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "AI का उपयोग करके Aspose.Slides for Android (Java) के माध्यम से PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बरकरार रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करता है। स्लाइड्स को बनाने, संपादित करने और रूपांतरित करने के अलावा, यह AI‑परिचालित सुविधाएँ प्रदान करता है - जैसे कि बहुभाषी स्लाइड सामग्री के लिए Presentation Translation API।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ शामिल नहीं हैं, लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesaiagent/) वर्ग के माध्यम से प्रदर्शित की जाती है, जो AI सेवाओं से संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaiwebclient/) इंटरफ़ेस के कार्यान्वयन का उपयोग करता है।

आप निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करके OpenAI के API से जुड़ सकते हैं या एक अलग AI प्रदाता या भाषा मॉडल का उपयोग करने के लिए अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaiwebclient/) लागू कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करता है।

{{% alert color="primary" %}}
ध्यान दें कि OpenAI API एक भुगतान सेवा है, इसलिए आपको एक खाता बनाना होगा और निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करते समय अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी में अनुवादित करते हैं, विशेष OpenAI [मॉडल](https://platform.openai.com/docs/models) के साथ।

```java
// एक प्रस्तुति लोड करें अनुवाद के लिए.
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपने मॉडल और API कुंजी को निर्दिष्ट करते हुए.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // प्रस्तुति को जापानी में अनुवाद करें.
    aiAgent.translate(presentation, "japanese");

    // अनूदित प्रस्तुति को PDF के रूप में सहेजें.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) उदाहरण बनाता और प्रबंधित करता है, और इसके जीवनचक्र को स्वचालित रूप से संभालता है। हालांकि, यदि आप स्वयं [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को प्रबंधित करना चाहते हैं — मुख्य रूप से प्रॉक्सी जैसी आवश्यक सेटिंग्स कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए एक [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करने के लिए — तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) को निर्माण करते समय अपना स्वयं का `HttpURLConnection` उदाहरण प्रदान कर सकते हैं।

```java
// मान लीजिए आपके पास एक पहले से कॉन्फ़िगर किया गया HttpURLConnection उदाहरण है (जैसे, कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API एक AI‑चालित समाधान प्रदान करता है जो बहुभाषी PowerPoint प्रस्तुतियों को वितरित करता है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके, यह मैन्युअल कार्यप्रवाह की तुलना में समय बचाता है और त्रुटियों को न्यूनतम करता है। चाहे आप एक डेवलपर, शिक्षाविद या व्यापार पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियों को बनाने में सक्षम बनाता है - जिससे आपका पहुंच विस्तारता है और संचार में सुधार होता है।
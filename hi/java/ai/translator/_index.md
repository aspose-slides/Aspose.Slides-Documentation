---
title: AI-संचालित प्रस्तुति अनुवादक
linktitle: AI-संचालित अनुवादक
type: docs
weight: 20
url: /hi/java/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-संचालित सुविधा
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI-चालित सुविधाएं
- AI क्षमताएं
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके AI के साथ PowerPoint स्लाइड्स अनुवादित करें। लेआउट को सुरक्षित रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मैत्रीपूर्ण। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करता है। स्लाइड्स बनाने, संपादित करने और परिवर्तित करने के अलावा, यह AI‑चलित सुविधाएँ प्रदान करता है—जैसे कि बहुभाषी स्लाइड सामग्री के लिए Presentation Translation API।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ नहीं हैं, लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesaiagent/) क्लास के माध्यम से उपलब्ध कराई जाती है, जो AI सेवाओं के साथ संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) इंटरफ़ेस का कार्यान्वयन उपयोग करता है।

आप निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करके OpenAI के API से कनेक्ट कर सकते हैं या अलग AI प्रदाता या भाषा मॉडल के लिए अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) लागू कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करता है।

{{% alert color="primary" %}}
ध्यान दें कि OpenAI API एक भुगतान वाली सेवा है, इसलिए निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी भाषा में अनुवादित करते हैं, जिसमें एक विशिष्ट OpenAI [model](https://platform.openai.com/docs/models) निर्धारित किया गया है।

```java
// एक प्रस्तुति लोड करें जिसे अनुवादित करना है।
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपने मॉडल और API कुंजी निर्दिष्ट करते हुए।
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें।
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // प्रस्तुति को जापानी में अनुवाद करें।
    aiAgent.translate(presentation, "japanese");

    // अनुवादित प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, और इसके जीवन‑चक्र को स्वचालित रूप से संभालता है। हालांकि, यदि आप [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को स्वयं प्रबंधित करना चाहते हैं—मुख्यतः प्रॉक्सी जैसे आवश्यक सेटिंग को कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए एक [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करने के लिए—तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) को बनाते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```java
// मान लीजिए आपके पास एक पूर्व-कॉन्फ़िगर किया गया HttpURLConnection इंस्टेंस है (उदा., कस्टम टाइमआउट, प्रॉक्सी सेटिंग आदि के साथ)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API बहुभाषी PowerPoint प्रस्तुतियों को वितरित करने के लिए AI‑संचालित समाधान प्रदान करता है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके यह समय बचाता है और मैन्युअल कार्यप्रवाह की तुलना में त्रुटियों को न्यूनतम करता है। चाहे आप एक डेवलपर, श educator, या व्यवसाय पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिये आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाता है—जिससे आपका पहुंच बढ़ता है और संचार सुधरता है।
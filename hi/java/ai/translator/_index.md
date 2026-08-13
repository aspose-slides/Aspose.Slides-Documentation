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
- AI-चालित सुविधाएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके AI से PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—त्वरित और डेवलपर‑मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिकली PowerPoint प्रस्तुतियों का प्रबंधन करती है। स्लाइड्स को बनाने, संपादित करने और परिवर्तित करने के अलावा, यह AI‑आधारित सुविधाएँ प्रदान करती है - जैसे कि बहुभाषी स्लाइड सामग्री के लिए Presentation Translation API।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ नहीं हैं लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesaiagent/) क्लास के माध्यम से उजागर की गई है, जो AI सेवाओं के साथ संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) इंटरफ़ेस का कार्यान्वयन उपयोग करती है।

आप निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करके OpenAI के API से कनेक्ट कर सकते हैं या अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) लागू कर सकते हैं ताकि किसी अन्य AI प्रदाता या भाषा मॉडल का उपयोग किया जा सके।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए अनूदित सामग्री को समझदारी से सम्मिलित करता है।

{{% alert color="info" %}}
ध्यान दें कि OpenAI API एक भुगतानित सेवा है, इसलिए निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करके एक निर्दिष्ट OpenAI [मॉडल](https://platform.openai.com/docs/models) के साथ PowerPoint प्रस्तुति को जापानी में अनूदित करते हैं।

```java
import com.aspose.slides.*;

// प्रस्तुति को अनुवाद के लिए लोड करें।
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपना मॉडल और API कुंजी निर्दिष्ट करके।
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को इनिशियलाइज़ करें।
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // प्रस्तुति को जापानी में अनुवाद करें।
    aiAgent.translate(presentation, "japanese");

    // अनूदित प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, तथा उसका जीवनचक्र स्वतः संभालता है। हालांकि, यदि आप [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को स्वयं प्रबंधित करना चाहते हैं — मुख्य रूप से प्रॉक्सी जैसे आवश्यक सेटिंग्स कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए किसी [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करने के लिए — तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का निर्माण करते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// HttpURLConnection instance को स्वयं कॉन्फ़िगर करें (कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि)।
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API बहुभाषी PowerPoint प्रस्तुतियों को वितरित करने के लिए एक AI‑संचालित समाधान प्रदान करता है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके, यह मैनुअल कार्यप्रवाह की तुलना में समय बचाता है और त्रुटियों को न्यूनतम करता है। चाहे आप डेवलपर, शिक्षक या व्यावसायिक पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाता है - जिससे आपका पहुँच बढ़ती है और संचार में सुधार होता है।
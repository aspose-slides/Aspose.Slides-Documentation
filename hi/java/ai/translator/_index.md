---
title: AI-शक्तिप्राप्त प्रस्तुति अनुवादक
linktitle: AI-शक्तिप्राप्त अनुवादक
type: docs
weight: 20
url: /hi/java/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-शक्तिप्राप्त सुविधा
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
description: "Aspose.Slides for Java का उपयोग करके AI से PowerPoint स्लाइड्स का अनुवाद करें। PPT, PPTX और ODP को लेआउट बनाए रखते हुए स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करता है। स्लाइड बनाने, संपादित करने और परिवर्तित करने के साथ-साथ यह AI‑चालित सुविधाएँ प्रदान करता है—जैसे कि मल्टीभाषी स्लाइड सामग्री के लिए Presentation Translation API।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निर्मित AI क्षमताएँ नहीं हैं, बल्कि यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ इंटीग्रेट करता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesaiagent/) क्लास द्वारा उजागर की जाती है, जो AI सेवाओं के साथ संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) इंटरफ़ेस के एक कार्यान्वयन का उपयोग करती है।

आप बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करके OpenAI के API से कनेक्ट कर सकते हैं या किसी अन्य AI प्रदाता या भाषा मॉडल का उपयोग करने के लिए अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaiwebclient/) लागू कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और अनूदित सामग्री को मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए बुद्धिमानी से सम्मिलित करता है।

{{% alert color="info" title="Note" %}}
OpenAI API एक भुगतान वाली सेवा है, इसलिये बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी पड़ेगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का प्रयोग करके निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) के साथ PowerPoint प्रस्तुति को जापानी में अनुवादित करते हैं।

```java
import com.aspose.slides.*;

// अनुवाद हेतु प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ AI क्लाइंट बनाएं, अपने मॉडल और API कुंजी निर्दिष्ट करते हुए।
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें।
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // प्रस्तुति को जापानी में अनुवादित करें।
    aiAgent.translate(presentation, "japanese");

    // अनूदित प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक `HttpURLConnection` इंस्टेंस बनाता और प्रबंधित करता है, और उसका जीवन‑चक्र स्वचालित रूप से संभालता है। हालांकि, यदि आप `HttpURLConnection` को स्वयं प्रबंधित करना पसंद करते हैं—जैसे प्रॉक्सी जैसी आवश्यक सेटिंग्स कॉन्फ़िगर करने के लिये, या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिये `URLStreamHandlerFactory` या अलग `HttpClient` का उपयोग करने के लिये—तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaiwebclient/) का निर्माण करते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// अपनी खुद की HttpURLConnection इंस्टेंस को कॉन्फ़िगर करें (कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स आदि)।
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI उदाहरण**

आप अपने Azure OpenAI डिप्लॉयमेंट को उपयोग करने के लिये [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hi/java/com.aspose.slides/openaicompatiblewebclient/) के साथ अनुवादक को कॉन्फ़िगर कर सकते हैं।

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

यह स्निपेट आपके Azure OpenAI एंडपॉइंट का उपयोग करके प्रस्तुति को अनुवादित करने का प्रदर्शन करता है। प्लेसहोल्डर मानों को अपने डिप्लॉयमेंट नाम, API कुंजी, और एंडपॉइंट URL से प्रतिस्थापित करें।

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API एक AI‑संचालित समाधान प्रदान करता है जिससे आप बहुभाषी PowerPoint प्रस्तुतियां आसानी से वितरित कर सकते हैं। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके यह समय बचाता है और मैन्युअल प्रक्रियाओं की तुलना में त्रुटियों को न्यूनतम करता है। चाहे आप डेवलपर हों, शैक्षक हों या व्यवसायिक पेशेवर, यह API आपको वैश्विक दर्शकों के लिये आकर्षक, स्थानीयकृत प्रस्तुतियों को बनाने में सक्षम बनाता है—जिससे आपकी पहुँच बढ़ती है और संचार में सुधार होता है।
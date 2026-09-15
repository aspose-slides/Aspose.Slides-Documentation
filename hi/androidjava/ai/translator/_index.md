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
description: "AI का उपयोग करके Aspose.Slides for Android के माध्यम से Java में PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें-तीव्र और डेवलपर-मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करता है। स्लाइड्स बनाने, संपादित करने और परिवर्तित करने के अलावा, यह AI-चालित सुविधाएँ प्रदान करता है - जैसे कि बहुभाषी स्लाइड सामग्री के लिए Presentation Translation API।

## **यह कैसे काम करता है**

Aspose.Slides में निर्मित AI क्षमता शामिल नहीं है, बल्कि यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesaiagent/) क्लास द्वारा उजागर की जाती है, जो AI सेवाओं से संपर्क करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaiwebclient/) इंटरफ़ेस का एक कार्यान्वयन उपयोग करता है।

आप निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करके OpenAI की API से जुड़ सकते हैं या अपने स्वयं के [IAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaiwebclient/) को लागू कर सकते हैं ताकि किसी अन्य AI प्रदाता या भाषा मॉडल का उपयोग किया जा सके।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और स्वरूपण को बनाए रखते हुए अनूदित सामग्री को बुद्धिमानी से सम्मिलित करता है।

{{% alert color="info" title="Note" %}}
ध्यान रखें कि OpenAI API एक पेड सेवा है, इसलिए आपको एक अकाउंट बनाना होगा और निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करते समय अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करके PowerPoint प्रस्तुति को जापानी में अनुवाद करते हैं, साथ ही एक निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) का उपयोग करते हैं।

```java
import com.aspose.slides.*;

// एक प्रस्तुति लोड करें जिसे अनुवादित किया जाना है।
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपना मॉडल और API कुंजी निर्दिष्ट करते हुए।
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

डिफ़ॉल्ट रूप से, निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, और इसका जीवनचक्र स्वतः संभालता है। हालांकि, यदि आप स्वयं [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को प्रबंधित करना चाहते हैं — मुख्यतः प्रॉक्सी जैसी आवश्यक सेटिंग्स को कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए एक [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करने के लिए — तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का निर्माण करते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // स्वयं एक HttpURLConnection इंस्टेंस कॉन्फ़िगर करें (जैसे कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि)।
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // कनेक्शन को OpenAIWebClient कन्स्ट्रक्टर में पास करें।
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI उदाहरण**

आप ट्रांसलेटर को अपनी Azure OpenAI डिप्लॉयमेंट के साथ उपयोग करने के लिए [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaicompatiblewebclient/) से कॉन्फ़िगर कर सकते हैं।

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

यह स्निपेट आपके Azure OpenAI एंडपॉइंट का उपयोग करके प्रस्तुति को अनुवादित करने का प्रदर्शन करता है। प्लेसहोल्डर मानों को अपने डिप्लॉयमेंट नाम, API कुंजी, और एंडपॉइंट URL से बदलें।

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API एक AI-समर्थित समाधान प्रदान करता है जिससे बहुभाषी PowerPoint प्रस्तुतियों को वितरित किया जा सके। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके, यह मैनुअल कार्यप्रवाहों की तुलना में समय बचाता है और त्रुटियों को कम करता है। चाहे आप डेवलपर, शिक्षक, या व्यवसायिक पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियों को बनाने में सक्षम बनाता है - जिससे आपका विस्तार बढ़ता है और संचार में सुधार होता है।
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
- AI-चालित सुविधाएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके AI के साथ PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। अभी आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों को प्रबंधित करता है। स्लाइड्स को बनाने, संपादित करने और परिवर्तित करने के अलावा, यह AI‑आधारित सुविधाएँ प्रदान करता है - जैसे कि बहुभाषी स्लाइड सामग्री के लिए Presentation Translation API।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ नहीं हैं, लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesaiagent/) क्लास के माध्यम से उजागर की गई है, जो AI सेवाओं के साथ संचार करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaiwebclient/) इंटरफ़ेस की एक कार्यान्वयन का उपयोग करता है।

आप बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करके OpenAI API से जुड़ सकते हैं या अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaiwebclient/) लागू कर विभिन्न AI प्रदाता या भाषा मॉडल का उपयोग कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करता है।

{{% alert color="info" %}}
ध्यान दें कि OpenAI API एक पेड सेवा है, इसलिए बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी में अनुवादित करते हैं, जिसमें एक निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) का प्रयोग किया गया है।

```java
import com.aspose.slides.*;

// अनुवाद के लिए प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को आरंभ करें।
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

डिफ़ॉल्ट रूप से, बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, तथा उसके जीवन‑चक्र को स्वचालित रूप से संभालता है। हालांकि, यदि आप [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को स्वयं प्रबंधित करना चाहते हैं — मुख्यतः प्रॉक्सी जैसी आवश्यक सेटिंग्स कॉन्फ़़िगर करने या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए एक [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या एक अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करने के लिए — तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/openaiwebclient/) का निर्माण करते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // स्वयं HttpURLConnection इंस्टेंस कॉन्फ़िगर करें (उदाहरण के लिए, कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि)।
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // कनेक्शन को OpenAIWebClient कन्स्ट्रक्टर में पास करें।
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API एक AI‑समर्थित समाधान प्रदान करता है जो बहुभाषी PowerPoint प्रस्तुतियों को वितरित करने में सहायता करता है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित कर, यह मैन्युअल कार्यप्रवाह की तुलना में समय बचाता है और त्रुटियों को न्यूनतम करता है। चाहे आप एक डेवलपर, शिक्षाविद या व्यवसाय पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाता है — जिससे आपकी पहुँच बढ़ती है और संचार में सुधार होता है।

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
- AI-चालित सुविधाएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके AI के साथ PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। अभी आज़माएँ।"
---
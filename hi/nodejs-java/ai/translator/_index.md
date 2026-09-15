---
title: AI-चालित प्रस्तुति अनुवादक
linktitle: AI-चालित अनुवादक
type: docs
weight: 20
url: /hi/nodejs-java/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-चालित सुविधा
- बहु‑भाषीय प्रस्तुति
- बहु‑भाषीय स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI-संचालित सुविधाएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके AI के साथ PowerPoint स्लाइड्स अनुवादित करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करता है। स्लाइड्स को बनाने, संपादित करने और परिवर्तित करने के अतिरिक्त, यह AI‑संचालित सुविधाएँ प्रदान करता है – जैसे कि बहु भाषीय स्लाइड सामग्री के लिए Presentation Translation API।

## **यह कैसे काम करता है**

Aspose.Slides में बिल्ट‑इन AI क्षमताएँ नहीं हैं लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesaiagent/) क्लास के माध्यम से AI सेवाओं के साथ संवाद करने के लिए उजागर की गई है।

आप बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करके OpenAI की API से कनेक्ट कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करता है।

{{% alert color="info" title="Note" %}}
ध्यान दें कि OpenAI API एक सशुल्क सेवा है, इसलिए आपको एक खाता बनाना होगा और बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करते समय अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी में अनुवादित करते हैं, जिसमें निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) का प्रयोग किया जाता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// अनुवाद के लिए प्रस्तुति लोड करें।
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को शुरू करें।
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // प्रस्तुति को जापानी में अनुवादित करें।
    aiAgent.translate(presentation, "japanese");

    // अनुवादित प्रस्तुति को PDF के रूप में सहेजें।
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, और उसके लाइफ़साइकल को स्वचालित रूप से संभालता है। हालांकि, यदि आप स्वयं [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को प्रबंधित करना पसंद करते हैं — मुख्यतः प्रॉक्सी जैसे आवश्यक सेटिंग्स को कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए एक [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करने के लिए — आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) को बनाते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक HttpURLConnection इंस्टेंस बनाएं और पूर्व-कॉन्फ़िगर करें (जैसे, कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि)।
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI उदाहरण**

आप अपने Azure OpenAI डिप्लॉयमेंट का उपयोग करने के लिए अनुवादक को [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaicompatiblewebclient/) के साथ कॉन्फ़िगर कर सकते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

यह स्निपेट आपके Azure OpenAI एंडपॉइंट का उपयोग करके प्रस्तुति का अनुवाद दिखाता है। प्लेसहोल्डर मानों को अपने डिप्लॉयमेंट नाम, API कुंजी, और एंडपॉइंट URL से बदलें।

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API एक AI‑संचालित समाधान प्रदान करता है जो बहु‑भाषी PowerPoint प्रस्तुतियों को वितरित करता है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके, यह मैन्युअल कार्यप्रवाहों की तुलना में समय बचाता है और त्रुटियों को न्यूनतम करता है। चाहे आप डेवलपर, शिक्षक, या व्यवसायिक पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाता है ‑ जिससे आपका पहुँच विस्तारित होता है और संचार में सुधार होता है।
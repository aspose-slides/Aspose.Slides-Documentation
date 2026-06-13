---
title: AI-संचालित प्रस्तुति अनुवादक
linktitle: AI-संचालित अनुवादक
type: docs
weight: 20
url: /hi/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके AI के साथ PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। इसे आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों को प्रबंधित करता है। स्लाइड्स को बनाने, संपादित करने और परिवर्तित करने के अलावा, यह AI-समर्थित विशेषताएँ प्रदान करता है - जैसे कि बहुभाषी स्लाइड सामग्री के लिए Presentation Translation API।

## **कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ नहीं हैं, लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडल के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesaiagent/) क्लास के माध्यम से प्रकट होती है जो AI सेवाओं के साथ संचार करती है।

आप निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करके OpenAI के API से जुड़ सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए अनुवादित सामग्री को बौद्धिक रूप से सम्मिलित करता है।

{{% alert color="primary" %}}
ध्यान दें कि OpenAI API एक भुगतान वाली सेवा है, इसलिए आपको खाता बनाना होगा और निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करते समय अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी में अनुवादित करते हैं, साथ ही निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) का उपयोग करते हैं।

```js
// अनुवाद करने के लिए एक प्रस्तुति लोड करें।
let presentation = new aspose.slides.Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपने मॉडल और API कुंजी निर्दिष्ट करते हुए।
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें।
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

डिफ़ॉल्ट रूप से, निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) अपने स्वयं के आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस को बनाता और प्रबंधित करता है, और इसके जीवनचक्र को स्वचालित रूप से संभालता है। हालांकि, यदि आप [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को स्वयं प्रबंधित करना पसंद करते हैं — मुख्यतः प्रॉक्सी जैसे आवश्यक सेटिंग्स को कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए एक [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) का उपयोग करने के लिए — तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/openaiwebclient/) के निर्माण के समय अपना खुद का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```js
// मान लें कि आपके पास एक पूर्व-कॉन्फ़िगर किया गया HttpURLConnection इंस्टेंस है (जैसे, कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि)।
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API बहुभाषी PowerPoint प्रस्तुतियों को प्रदान करने के लिए AI-संचालित समाधान प्रदान करता है। लेआउट और डिजाइन को बनाए रखते हुए अनुवाद को स्वचालित करके, यह मैनुअल कार्यप्रवाह की तुलना में समय बचाता है और त्रुटियों को न्यूनतम करता है। चाहे आप डेवलपर, शिक्षक, या व्यापार प्रोफेशनल हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियों को बनाने में सक्षम बनाता है - आपकी पहुंच का विस्तार करता है और संचार में सुधार करता है।
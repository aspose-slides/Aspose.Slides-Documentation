---
title: AI-समर्थित प्रस्तुति अनुवादक
linktitle: AI-समर्थित अनुवादक
type: docs
weight: 20
url: /hi/php-java/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-समर्थित विशेषता
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI-चालित विशेषताएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP का उपयोग करके AI के साथ PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रपूर्ण। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों को प्रबंधित करता है। स्लाइड्स बनाने, संपादित करने और रूपांतरित करने के अलावा, यह AI-ड्रिवन सुविधाएँ प्रदान करता है - जैसे कि Presentation Translation API बहुभाषी स्लाइड सामग्री के लिए।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ नहीं होतीं, बल्कि यह इंटरनेट पर बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesaiagent/) वर्ग के माध्यम से उजागर की गई है ताकि AI सेवाओं के साथ संचार किया जा सके।

आप बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का उपयोग करके OpenAI की API से कनेक्ट कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट व फॉर्मेटिंग को बनाए रखते हुए अनूदित सामग्री को बौद्धिक रूप से सम्मिलित करता है।

{{% alert color="primary" %}}
ध्यान दें कि OpenAI API एक भुगतान वाली सेवा है, इसलिए बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी भाषा में अनुवाद करते हैं, जिसमें एक निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) उपयोग किया गया है।

```php
// अनुवाद करने के लिए एक प्रस्तुति लोड करें।
$presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपना मॉडल और API कुंजी निर्दिष्ट करते हुए।
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें।
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // प्रस्तुति को जापानी में अनुवाद करें।
    $aiAgent->translate($presentation, "japanese");

    // अनूदित प्रस्तुति को PDF के रूप में सहेजें।
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

डिफ़ॉल्ट रूप से, बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) इंस्टेंस बनाता और प्रबंधित करता है, और उसके जीवनकाल को स्वचालित रूप से संभालता है। हालांकि, यदि आप स्वयं [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) को प्रबंधित करना पसंद करते हैं — मुख्यतः प्रॉक्सी जैसी आवश्यक सेटिंग्स को कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन व प्रदर्शन के लिए एक [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) या अलग [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) उपयोग करने के लिए — तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का निर्माण करते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```php
// मान लें कि आपके पास एक पूर्व-कॉन्फ़िगर किया गया HttpURLConnection इंस्टेंस है (उदाहरण के लिए, कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि)।
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API एक AI‑संचालित समाधान प्रदान करती है जो बहुभाषी PowerPoint प्रस्तुतियों को वितरित करने में मदद करती है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके, यह समय बचाती है और मैनुअल वर्कफ़्लो की तुलना में त्रुटियों को न्यूनतम करती है। चाहे आप डेवलपर, शिक्षाविद् या व्यापार पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाती है — जिससे आपकी पहुँच विस्तृत होती है और संचार बेहतर होता है।
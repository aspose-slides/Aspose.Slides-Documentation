---
title: AI-संचालित प्रस्तुति अनुवादक
linktitle: AI-संचालित अनुवादक
type: docs
weight: 20
url: /hi/php-java/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-संचालित सुविधा
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI-प्रेरित सुविधाएँ
- AI क्षमताएं
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "AI का उपयोग करके Aspose.Slides for PHP के साथ PowerPoint स्लाइड्स को अनुवादित करें। लेआउट को संरक्षित रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करता है। स्लाइड्स बनाने, संपादित करने और परिवर्तित करने के अलावा, यह AI‑चलित सुविधाएँ प्रदान करता है—जैसे कि Presentation Translation API जो बहुभाषी स्लाइड सामग्री के लिए है।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ नहीं हैं, बल्कि यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesaiagent/) क्लास द्वारा AI सर्विसेज़ के साथ संचार करने के लिए उपलब्ध कराई गई है।

आप बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का उपयोग करके OpenAI के API से कनेक्ट हो सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट व फ़ॉर्मेटिंग को बनाए रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करता है।

{{% alert color="info" title="Note" %}}
ध्यान दें कि OpenAI API एक पेड सेवा है, इसलिए आपको एक खाता बनाना होगा और बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का उपयोग करते समय अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का प्रयोग करके एक PowerPoint प्रस्तुति को निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) के साथ जापानी में अनुवाद करते हैं।

```php
// अनुवाद के लिए प्रस्तुति लोड करें.
$presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपना मॉडल और API कुंजी निर्दिष्ट करते हुए.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // प्रस्तुति को जापानी में अनुवादित करें.
    $aiAgent->translate($presentation, "japanese");

    // अनुवादित प्रस्तुति को PDF के रूप में सहेजें.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

डिफ़ॉल्ट रूप से, बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) अपना स्वयं का आंतरिक `HttpURLConnection` इंस्टेंस बनाता और प्रबंधित करता है, और इसका जीवन‑चक्र स्वचालित रूप से संभालता है। हालांकि, यदि आप `HttpURLConnection` को स्वयं प्रबंधित करना चाहते हैं—मुख्यतः प्रॉक्सी जैसे आवश्यक सेटिंग्स कॉन्फ़िगर करने के लिए, या बेहतर संसाधन प्रबंधन व प्रदर्शन के लिए `URLStreamHandlerFactory` या अलग `HttpClient` का उपयोग करने के लिए—तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaiwebclient/) का निर्माण करते समय अपना स्वयं का `HttpURLConnection` इंस्टेंस प्रदान कर सकते हैं।

```php
// अपना स्वयं का HttpURLConnection इंस्टेंस बनाएं और पूर्व-कॉन्फ़िगर करें (कस्टम टाइमआउट, प्रॉक्सी सेटिंग्स, आदि).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// कनेक्शन को AI क्लाइंट को पास करें.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI उदाहरण**

आप अपने Azure OpenAI परिनियोजन को उपयोग करने के लिए ट्रांसलेटर को [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/openaicompatiblewebclient/) के साथ कॉन्फ़िगर कर सकते हैं।

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

यह स्निपेट आपके Azure OpenAI एंडपॉइंट का उपयोग करके प्रस्तुति का अनुवाद दर्शाता है। प्लेसहोल्डर मानों को अपने परिनियोजन नाम, API कुंजी, और एंडपॉइंट URL से बदलें।

## **मुख्य लाभ**

Aspose.Slides Presentation Translation API एक AI‑संचालित समाधान प्रदान करता है जो बहुभाषी PowerPoint प्रस्तुतियों को वितरित करता है। लेआउट और डिज़ाइन को संरक्षित रखते हुए अनुवाद को स्वचालित करके यह समय बचाता है और मैन्युअल कार्यप्रवाह की तुलना में त्रुटियों को कम करता है। चाहे आप एक डेवलपर, शिक्षक, या व्यापार पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाता है—जिससे आपका पहुँच विस्तृत होती है और संचार बेहतर होता है।
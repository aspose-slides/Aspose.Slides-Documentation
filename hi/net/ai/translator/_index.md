---
title: AI‑संचालित प्रस्तुति अनुवादक
linktitle: AI‑संचालित अनुवादक
type: docs
weight: 20
url: /hi/net/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI‑संचालित सुविधा
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI‑चालित सुविधाएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके AI से PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक तौर पर PowerPoint प्रस्तुतियों का प्रबंधन करता है। स्लाइड्स को बनाने, संपादित करने और रूपांतरित करने के अलावा, यह AI‑चालित सुविधाएँ प्रदान करता है - जैसे कि कई भाषाओं के लिए स्लाइड सामग्री के लिये [Presentation Translation API](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/)।

## **यह कैसे काम करता है**

Aspose.Slides में बिल्ट‑इन AI क्षमताएँ नहीं हैं, लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent) क्लास के माध्यम से उजागर की जाती है, जो AI सेवाओं के साथ संवाद करने के लिये [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) इंटरफ़ेस की एक कार्यान्वयन का उपयोग करती है।

आप बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करके OpenAI की API से कनेक्ट कर सकते हैं या अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) लागू करके किसी अलग AI प्रदाता या भाषा मॉडल का उपयोग कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं का विश्लेषण करता है, और अनूदित सामग्री को मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए बुद्धिमानी से सम्मिलित करता है।

{{% alert color="info" title="Note" %}}
ध्यान दें कि OpenAI API एक पेड सेवा है, इसलिए आपको एक खाता बनाना होगा और अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करते समय अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) के साथ जापानी में अनूदित करते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// एक प्रस्तुति लोड करें अनुवाद के लिये.
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपने मॉडल और API कुंजी निर्दिष्ट करके.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI क्लाइंट के साथ SlidesAIAgent को प्रारम्भ करें.
var aiAgent = new SlidesAIAgent(aiWebClient);

// प्रस्तुति को जापानी में अनुवादित करें.
await aiAgent.TranslateAsync(presentation, "japanese");

// अनूदित प्रस्तुति को PDF के रूप में सहेजें.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

डिफ़ॉल्ट रूप से, बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) अपना स्वयं का आंतरिक [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) उदाहरण बनाता और प्रबंधित करता है, इसकी जीवन‑चक्र और निपटान को स्वचालित रूप से संभालता है। हालांकि, यदि आप खुद [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) को प्रबंधित करना चाहते हैं - जैसे कि बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) का उपयोग करते समय - तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का निर्माण करते समय अपनी स्वयं की `HttpClient` उदाहरण प्रदान कर सकते हैं।

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// अपने द्वारा प्रबंधित HttpClient का उपयोग करें - उदाहरण के लिए, एक जिसे IHttpClientFactory द्वारा बनाया गया है
// डिपेंडेंसी इंजेक्शन के माध्यम से इंजेक्ट किया गया.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides आमतौर पर सिंक्रोनस वातावरण में उपयोग किया जाता है। इसे समर्थन देने के लिये, [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent/) क्लास दोनों सिंक्रोनस और असिंक्रोनस मेथड्स प्रदान करती है - जिससे आप अपने एप्लिकेशन के कार्य‑प्रवाह के अनुरूप सर्वोत्तम तरीका चुन सकते हैं।

### **एज़्योर OpenAI उदाहरण**

Aspose.Slides for .NET OpenAI‑संगत प्रदाताओं, जिसमें Azure OpenAI भी शामिल है, का समर्थन करता है। आप अपने इन‑हाउस Azure डिप्लॉयमेंट का उपयोग करने के लिये अनुवादक को [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaicompatiblewebclient/) के साथ कॉन्फ़िगर कर सकते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

यह स्निपेट आपके Azure OpenAI एंडपॉइंट का उपयोग करके प्रस्तुति का अनुवाद दर्शाता है। प्लेसहोल्डर मानों को अपने डिप्लॉयमेंट नाम, API कुंजी और एंडपॉइंट URL से बदलें।

## **प्रमुख लाभ**

Aspose.Slides का [Presentation Translation API](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/) AI‑संचालित समाधान प्रदान करता है जो बहुभाषी PowerPoint प्रस्तुतियों को वितरित करता है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके, यह मैनुअल वर्कफ़्लोज़ की तुलना में समय बचाता है और त्रुटियों को कम करता है। चाहे आप डेवलपर, शैक्षिक या व्यावसायिक पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिये आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाता है - जिससे आपकी पहुंच बढ़ती है और संचार में सुधार होता है।
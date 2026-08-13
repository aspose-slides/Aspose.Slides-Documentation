---
title: AI-संचालित प्रस्तुति अनुवादक
linktitle: AI-संचालित अनुवादक
type: docs
weight: 20
url: /hi/net/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-संचालित सुविधा
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI-आधारित सुविधाएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके AI के साथ PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्र। अभी आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करती है। स्लाइड्स को बनाने, संपादित करने और रूपांतरित करने के अलावा, यह AI‑आधारित सुविधाएँ प्रदान करती है - जैसे कि बहुभाषी स्लाइड सामग्री के लिए [Presentation Translation API](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/)।

## **कैसे काम करता है**

Aspose.Slides में अंतर्निर्मित AI क्षमता नहीं है, बल्कि यह इंटरनेट के माध्यम से बाह्य AI मॉडलों के साथ एकीकृत होती है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent) क्लास द्वारा उजागर की जाती है, जो AI सेवाओं के साथ संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) इंटरफ़ेस के एक कार्यान्वयन का उपयोग करती है।

आप अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) को उपयोग करके OpenAI की API से जुड़ सकते हैं या किसी अलग AI प्रदाता या भाषा मॉडल का उपयोग करने के लिए अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) लागू कर सकते हैं।

Aspose.Slides संचार को संभालती है, AI प्रतिक्रियाओं को पार्स करती है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को बनाए रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करती है।

{{% alert color="info" %}}

ध्यान रखें कि OpenAI API एक सशुल्क सेवा है, इसलिए अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी होगी।

{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करके PowerPoint प्रस्तुति को जापानी में अनुवादित करते हैं, साथ ही एक निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) का उपयोग किया जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// प्रस्तुति को अनुवादित करने के लिए लोड करें।
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ AI क्लाइंट बनाएँ, अपने मॉडल और API कुंजी निर्दिष्ट करते हुए।
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें।
var aiAgent = new SlidesAIAgent(aiWebClient);

// प्रस्तुति को जापानी में अनुवादित करें।
await aiAgent.TranslateAsync(presentation, "japanese");

// अनूदित प्रस्तुति को PDF के रूप में सहेजें।
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

डिफ़ॉल्ट रूप से, अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) अपना स्वयं का अंतरिक [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) इंस्टेंस बनाता और प्रबंधित करता है, उसके जीवन‑चक्र और निपटान को स्वचालित रूप से संभालता है। हालांकि, यदि आप [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) को स्वयं प्रबंधित करना चाहते हैं - जैसे बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए एक [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) का उपयोग करते समय - तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का निर्माण करते समय अपना स्वयं का `HttpClient` इंस्टेंस प्रदान कर सकते हैं।

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// अपने द्वारा प्रबंधित HttpClient का उपयोग करें - उदाहरण के लिए, एक IHttpClientFactory द्वारा निर्मित
// निर्भरता इंजेक्शन के माध्यम से इंजेक्ट किया गया।
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides आमतौर पर सिंक्रोनस वातावरण में उपयोग की जाती है। इसे समर्थन देने के लिए, [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent/) क्लास दोनों सिंक्रोनस और असिंक्रोनस मेथड्स प्रदान करती है - जिससे आप अपने एप्लिकेशन वर्कफ़्लो के अनुकूल तरीका चुन सकते हैं।

## **मुख्य लाभ**

Aspose.Slides का [Presentation Translation API](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/) मल्टीलिंगुअल PowerPoint प्रस्तुतियों के वितरण के लिए AI‑संचालित समाधान प्रदान करता है। लेआउट और डिज़ाइन को संरक्षित रखते हुए अनुवाद को स्वचालित करके यह समय बचाता है और मैनुअल कार्यप्रवाहों की तुलना में त्रुटियों को कम करता है। चाहे आप डेवलपर हों, शिक्षक हों, या व्यापार पेशेवर, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियों को बनाने में सक्षम बनाता है - आपके पहुंच को विस्तारित करता है और संचार को सुधारता है।
---
title: AI-संचालित प्रस्तुति अनुवादक
linktitle: AI-संचालित अनुवादक
type: docs
weight: 20
url: /hi/net/ai/translator/
keywords:
- AI प्रस्तुति अनुवादक
- AI स्लाइड अनुवादक
- AI-संचालित विशेषता
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- AI-प्रेरित विशेषताएँ
- AI क्षमताएँ
- AI एजेंट
- वेब क्लाइंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके AI से PowerPoint स्लाइड्स अनुवादित करें। लेआउट को संरक्षित रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑अनुकूल। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों को प्रबंधित करता है। स्लाइड्स को बनाने, संपादित करने और परिवर्तित करने के अलावा, यह AI‑चलित सुविधाएँ प्रदान करता है - जैसे कि बहु‑भाषी स्लाइड सामग्री के लिए [Presentation Translation API](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/)।

## **कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमता नहीं है, लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होता है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent) क्लास के माध्यम से उजागर की गई है, जो AI सेवाओं के साथ संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) इंटरफ़ेस की एक कार्यान्वयन का उपयोग करता है।

आप अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करके OpenAI के API से कनेक्ट हो सकते हैं या एक अलग AI प्रदाता या भाषा मॉडल का उपयोग करने के लिए अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/iaiwebclient/) लागू कर सकते हैं।

Aspose.Slides संचार को संभालता है, AI प्रतिक्रियाओं को पार्स करता है, और मूल स्लाइड लेआउट और फ़ॉर्मेटिंग को संरक्षित रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करता है।

{{% alert color="primary" %}}
ध्यान दें कि OpenAI API एक भुगतानित सेवा है, इसलिए अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में, हम अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी में अनुवाद करते हैं, जिसमें एक निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) का उपयोग किया गया है।

```csharp
// एक प्रस्तुति लोड करें अनुवाद के लिए।
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient के साथ एक AI क्लाइंट बनाएं, अपने मॉडल और API कुंजी को निर्दिष्ट करते हुए।
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI क्लाइंट के साथ SlidesAIAgent को आरंभ करें।
var aiAgent = new SlidesAIAgent(aiWebClient);

// प्रस्तुति को जापानी में अनुवादित करें।
await aiAgent.TranslateAsync(presentation, "japanese");

// अनुवादित प्रस्तुति को PDF के रूप में सहेजें।
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

डिफ़ॉल्ट रूप से, अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) अपना स्वयं का आंतरिक [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) इंस्टेंस बनाता और प्रबंधित करता है, जो उसके जीवनचक्र और निपटान को स्वचालित रूप से संभालता है। हालांकि, यदि आप स्वयं [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) को प्रबंधित करना पसंद करते हैं - जैसे कि बेहतर संसाधन प्रबंधन और प्रदर्शन के लिए [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) का उपयोग करना - तो आप [OpenAIWebClient](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/openaiwebclient/) को बनाते समय अपना स्वयं का `HttpClient` इंस्टेंस प्रदान कर सकते हैं।

```csharp
// मान लें कि आपके पास एक IHttpClientFactory उदाहरण है (उदा., निर्भरता इंजेक्शन के माध्यम से इंजेक्ट किया गया).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides आमतौर पर सिंक्रोनस वातावरण में उपयोग किया जाता है। इसे समर्थन देने के लिए, [SlidesAIAgent](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/slidesaiagent/) क्लास synchronous और asynchronous दोनों विधियाँ प्रदान करती है - जिससे आप अपने अनुप्रयोग के कार्यप्रवाह के लिए सबसे उपयुक्त तरीका चुन सकते हैं।

## **मुख्य लाभ**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/hi/net/aspose.slides.ai/) बहु‑भाषी PowerPoint प्रस्तुतियों को वितरित करने के लिए एक AI‑समर्थित समाधान प्रदान करता है। लेआउट और डिजाइन को संरक्षित रखते हुए अनुवाद को स्वचालित करके, यह मैनुअल कार्यप्रवाहों की तुलना में समय बचाता है और त्रुटियों को न्यूनतम करता है। चाहे आप डेवलपर, शिक्षक, या व्यापार पेशेवर हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाती है - जिससे आपकी पहुंच विस्तारित होती है और संचार में सुधार होता है।
---
title: AI-संचालित प्रस्तुति अनुवादक
linktitle: AI-संचालित अनुवादक
type: docs
weight: 20
url: /hi/python-net/ai/translator/
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
- Python
- Aspose.Slides
description: "AI का उपयोग करके Aspose.Slides for Python के साथ PowerPoint स्लाइड्स का अनुवाद करें। लेआउट को बनाए रखते हुए PPT, PPTX और ODP को स्थानीयकृत करें—तेज़ और डेवलपर‑मित्रवत। आज़माएँ।"
---
## **परिचय**

Aspose.Slides एक शक्तिशाली API है जो प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों का प्रबंधन करती है। स्लाइड बनाने, संपादित करने और रूपांतरित करने के अलावा, यह AI‑संचालित सुविधाएँ प्रदान करती है - जैसे कि बहुभाषी स्लाइड सामग्री के लिए [Presentation Translation API](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/)।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI क्षमताएँ नहीं हैं, लेकिन यह इंटरनेट के माध्यम से बाहरी AI मॉडलों के साथ एकीकृत होती है। यह कार्यक्षमता [SlidesAIAgent](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/slidesaiagent/) क्लास के माध्यम से उजागर की गई है, जो AI सेवाओं के साथ संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/iaiwebclient/) उपवर्गों का उपयोग करती है।

आप अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/openaiwebclient/) का उपयोग करके OpenAI की API से कनेक्ट हो सकते हैं या अपना स्वयं का [IAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/iaiwebclient/) लागू करके किसी भिन्न AI प्रदाता या भाषा मॉडल का उपयोग कर सकते हैं।

Aspose.Slides संचार को संभालती है, AI प्रतिक्रियाओं को पार्स करती है, और मूल स्लाइड लेआउट और फ़ॉर्मैटिंग को बनाए रखते हुए अनुवादित सामग्री को बुद्धिमानी से सम्मिलित करती है।

{{% alert color="info" %}}
ध्यान दें कि OpenAI API एक पेड सेवा है, इसलिए अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/openaiwebclient/) का उपयोग करते समय आपको एक खाता बनाना होगा और अपना API कुंजी प्रदान करनी होगी।
{{% /alert %}}

## **उदाहरण**

इस उदाहरण में हम अंतर्निहित [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/openaiwebclient/) का उपयोग करके एक PowerPoint प्रस्तुति को जापानी में अनुवादित करते हैं, जिसमें निर्दिष्ट OpenAI [model](https://platform.openai.com/docs/models) का उपयोग किया जाता है।

```py
import aspose.slides as slides

# प्रस्तुति को अनुवादित करने के लिए लोड करें।
with slides.Presentation("sample.pptx") as presentation:

    # OpenAIWebClient के साथ AI क्लाइंट बनाएँ, अपने मॉडल और API कुंजी निर्दिष्ट करके।
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # AI क्लाइंट के साथ SlidesAIAgent को प्रारंभ करें।
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # प्रस्तुति को जापानी में अनुवादित करें।
        ai_agent.translate(presentation, "japanese")

        # अनुवादित प्रस्तुति को PDF के रूप में सहेजें।
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI उदाहरण**

संस्करण **26.7.0** से, Aspose.Slides for Python via .NET OpenAI‑संगत प्रदाताओं, जिसमें Azure OpenAI भी शामिल है, को समर्थन देता है। आप अपने इन‑हाउस Azure परिनियोजन का उपयोग करने के लिए अनुवादक को [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/openaicompatiblewebclient/) के साथ कॉन्फ़िगर कर सकते हैं।

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

यह स्निपेट आपके Azure OpenAI एंडपॉइंट का उपयोग करके प्रस्तुति का अनुवाद दर्शाता है। प्लेसहोल्डर मानों को अपने परिनियोजन नाम, API कुंजी और एंडपॉइंट URL से बदलें।

## **मुख्य लाभ**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/) बहुभाषी PowerPoint प्रस्तुतियों को प्रदान करने के लिए AI‑पावर्ड समाधान पेश करता है। लेआउट और डिज़ाइन को बनाए रखते हुए अनुवाद को स्वचालित करके यह समय बचाता है और मैन्युअल कार्यप्रवाह की तुलना में त्रुटियों को कम करता है। चाहे आप डेवलपर, शैक्षिक पेशेवर या व्यापारिक विशेषज्ञ हों, यह API आपको वैश्विक दर्शकों के लिए आकर्षक, स्थानीयकृत प्रस्तुतियाँ बनाने में सक्षम बनाता है — आपके पहुंच को विस्तारित करता है और संचार में सुधार करता है।
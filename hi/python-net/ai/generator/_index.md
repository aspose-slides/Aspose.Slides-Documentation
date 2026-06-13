---
title: AI-संचालित बहुभाषीय स्लाइड जेनरेटर
linktitle: AI-संचालित जनरेटर
type: docs
weight: 40
url: /hi/python-net/ai/generator/
keywords:
- बहुभाषीय प्रस्तुति
- बहुभाषीय स्लाइड
- AI प्रस्तुति जेनरेटर
- AI स्लाइड जेनरेटर
- AI-संचालित फीचर
- AI एजेंट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के साथ पाठ से बहुभाषीय स्लाइड बनाएं। अपने टेम्प्लेट को लागू करें और परिष्कृत डेक्स को PowerPoint और OpenDocument में निर्यात करें। अधिक जानें।"
---
## **परिचय**

Aspose.Slides एक नई AI-संचालित सुविधा, Presentation Generator, प्रस्तुत करता है, जो डेवलपर्स को सरल टेक्स्ट इनपुट जैसे विषय विवरण, सारांश, उद्धरण, या बुलेट पॉइंट्स से स्वचालित रूप से अच्छी तरह संरचित PowerPoint प्रस्तुतियों को बनाने में सक्षम बनाता है।

उपयोगकर्ता सामग्री विवरण के स्तर को समायोजित कर सकते हैं और वैकल्पिक रूप से कस्टम प्रस्तुति टेम्पलेट लागू करके दृश्य डिज़ाइन को परिभाषित कर सकते हैं।

वर्तमान में, AI Presentation Generator टेक्स्ट ब्लॉक्स, बुलेट सूचियों और तालिकाओं का उपयोग करके सामग्री का संरचन बनाता है। छवि जनरेशन अभी समर्थित नहीं है; हालांकि, छवियों को बाद में Aspose.Slides टूल्स या मैन्युअली जोड़ना आसान है।

आउटपुट एक पूर्ण PowerPoint प्रस्तुति है जिसे जैसा है वैसा ही उपयोग किया जा सकता है या Aspose.Slides API द्वारा समर्थित किसी भी फ़ॉर्मेट में निर्यात किया जा सकता है। जबकि जनरेटर उच्च-गुणवत्ता वाले परिणाम प्रदान करता है, विशिष्ट आवश्यकताओं को पूरा करने के लिए मामूली पोस्ट-एडिटिंग की आवश्यकता हो सकती है।

## **यह कैसे काम करता है**

Aspose.Slides में अंतर्निहित AI मॉडल नहीं होते हैं; इसके बजाय, यह इंटरनेट के माध्यम से बाहरी AI सेवाओं के साथ एकीकृत होता है। यह एकीकरण [SlidesAIAgent](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/slidesaiagent/) क्लास द्वारा संभाला जाता है, जो AI मॉडल के साथ संवाद करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/iaiwebclient/) क्लास की एक कार्यान्वयन का उपयोग करता है।

आप अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/openaiwebclient/) का उपयोग कर सकते हैं, जो OpenAI के API से कनेक्ट होता है, या किसी अन्य AI प्रदाता या भाषा मॉडल के साथ काम करने के लिए [IAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/iaiwebclient/) का कस्टम कार्यान्वयन प्रदान कर सकते हैं। Aspose.Slides AI सेवा के साथ सभी संचार और AI के प्रतिक्रियाओं को प्रोसेस करके स्लाइड्स उत्पन्न करता है। ध्यान दें कि OpenAI API एक सशुल्क सेवा है, इसलिए अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/openaiwebclient/) का उपयोग करने पर एक खाता और API कुंजी आवश्यक है।

## **आइए कोड लिखें**

### **उदाहरण 1**

यह उदाहरण अंतर्निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/openaiwebclient/) का उपयोग करके Aspose.Slides विषय पर एक प्रस्तुति उत्पन्न करने का प्रदर्शन करता है।

```py
# OpenAIWebClient का एक इंस्टेंस बनाएं, जो OpenAI वेब क्लाइंट का अंतर्निहित कार्यान्वयन है।
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # SlidesAIAgent का एक इंस्टेंस बनाएं, जो AI-संचालित सुविधाओं तक पहुंच प्रदान करता है।
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # प्रस्तुति बनाने के लिए निर्देश परिभाषित करें।
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # निर्देश के आधार पर मध्यम मात्रा की सामग्री के साथ एक प्रस्तुति उत्पन्न करें।
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # उत्पन्न प्रस्तुति को स्थानीय डिस्क पर PowerPoint (.pptx) फ़ाइल के रूप में सहेजें।
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **उदाहरण 2**

निम्न उदाहरण [generate_presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation) मेथड के ओवरलोड्स को प्रदर्शित करता है। इस मामले में, उपयोगकर्ता की `master presentation` का उपयोग किया जाता है।

```py
# HttpClient को OpenAIWebClient कन्स्ट्रक्टर को पास करें।
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # SlidesAIAgent का एक इंस्टेंस बनाएं।
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # प्रस्तुति बनाने के लिए निर्देश परिभाषित करें।
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # स्थानीय डिस्क से एक मास्टर प्रस्तुति लोड करें जिसे डिज़ाइन टेम्पलेट के रूप में उपयोग किया जाएगा।
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # निर्देश और मास्टर टेम्पलेट का उपयोग करके विस्तृत प्रस्तुति उत्पन्न करें।
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # उत्पन्न प्रस्तुति को PDF के रूप में सहेजें।
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **मुख्य लाभ**

Aspose.Slides में नया AI Presentation Generator सरल टेक्स्ट प्रॉम्प्ट्स से संरचित स्लाइड डेक्स बनाने का तेज़ और लचीला तरीका प्रदान करता है। कस्टम टेम्पलेट्स के समर्थन के साथ, इसे विभिन्न अनुप्रयोगों में सहजता से एकीकृत किया जा सकता है।

आम उपयोग मामलों में मार्केटिंग प्रस्तुतियों, शैक्षिक सामग्री, क्लाइंट रिपोर्ट और आंतरिक स्लाइड डेक्स बनाना शामिल है। जबकि छवि जनरेशन अभी समर्थित नहीं है, यह टूल पहले से ही प्रस्तुति निर्माण को स्वचालित करने के लिए एक मजबूत आधार प्रदान करता है, और भविष्य में अतिरिक्त सुधारों की आशा है।
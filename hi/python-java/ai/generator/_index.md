---
title: AI-संचालित बहुभाषी स्लाइड जनरेटर
linktitle: AI-संचालित जनरेटर
type: docs
weight: 40
url: /hi/python-java/ai/generator/
keywords:
- बहुभाषी प्रस्तुति
- बहुभाषी स्लाइड
- AI प्रस्तुति जनरेटर
- AI स्लाइड जनरेटर
- प्रस्तुति टेम्पलेट
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ टेक्स्ट से बहुभाषी प्रस्तुतियाँ बनाएँ। सामग्री का विवरण चुनें, टेम्पलेट लागू करें, और PowerPoint या PDF में निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via Java में AI Presentation Generator विषय विवरण, सारांश, उद्धरण या बुलेट पॉइंट्स से प्रस्तुति बनाता है। अपनी प्रॉम्प्ट में आवश्यक भाषा निर्दिष्ट करें, कंटेंट की मात्रा चुनें, और वैकल्पिक रूप से एक प्रस्तुति टेम्पलेट प्रदान करें ताकि लेआउट और डिज़ाइन निर्धारित हो सके।

जेनरेटर कंटेंट को टेक्स्ट ब्लॉक्स, बुलेट लिस्ट और टेबल्स का उपयोग करके व्यवस्थित करता है। यह छवियां उत्पन्न नहीं करता; आप उन्हें उत्पन्न प्रस्तुति में बाद में जोड़ सकते हैं। प्रस्तुति साझा करने से पहले निर्मित कंटेंट और लेआउट की समीक्षा करें।

## **यह कैसे काम करता है**

[SlidesAIAgent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesaiagent/) एक AI क्लाइंट का उपयोग करके बाहरी मॉडल से संवाद करता है। नीचे दिए गए उदाहरण बिल्ट‑इन [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-java/aspose.slides/openaiwebclient/) का उपयोग करते हैं। Aspose.Slides मॉडल की प्रतिक्रियाओं को प्रोसेस करता है और एक प्रस्तुति बनाता है जिसे आप संपादित या निर्यात कर सकते हैं।

[SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesaiagent/#generatePresentation) का उपयोग एक टेक्स्ट विवरण और एक [PresentationContentAmountType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationcontentamounttype/) मान के साथ करें। तीसरे आर्ग्यूमेंट के साथ ओवरलोड एक प्रस्तुति को डिज़ाइन टेम्पलेट के रूप में उपयोग करने की अनुमति देता है।

## **आवश्यकताएँ**

Python, Java, JPype और Aspose.Slides को कॉन्फ़िगर करने के लिए [Installation](/slides/hi/python-java/installation/) देखें। उदाहरण चलाने से पहले `OPENAI_API_KEY` और `OPENAI_MODEL` पर्यावरण वेरिएबल सेट करें। बिल्ट‑इन क्लाइंट द्वारा समर्थित और आपके API खाते के लिए उपलब्ध मॉडल चुनें।

{{% alert color="info" title="Note" %}}
AI सेवा के लिए इंटरनेट कनेक्शन और अलग API एक्सेस की आवश्यकता होती है। प्रॉम्प्ट कॉन्फ़िगर की गई सेवा को भेजे जाते हैं, और इसके उपयोग शुल्क आपके Aspose.Slides लाइसेंस से स्वतंत्र होते हैं।
{{% /alert %}}

प्रत्येक उदाहरण JVM को केवल तब शुरू करता है जब वह पहले से चल नहीं रहा हो और बाद के ऑपरेशनों के लिए उसे उपलब्ध रखता है। नोटबुक के लिए कोड को अनुकूलित करने समय [JVM lifecycle guidance](/slides/hi/python-java/limitations-and-api-differences/#import-the-library) देखें।

## **टेक्स्ट से प्रस्तुति जनरेट करें**

यह उदाहरण अंग्रेज़ी में एक प्रस्तुति बनाता है जिसमें [Medium](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationcontentamounttype/#Medium) मात्रा का कंटेंट होता है और इसे PowerPoint फ़ाइल के रूप में सहेजता है।

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **टेम्पलेट का उपयोग करके प्रस्तुति जनरेट करें**

`masterPresentation.pptx` को कार्य निर्देशिका में रखें। यह उदाहरण इसे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के साथ लोड करता है, स्पेनिश में एक प्रस्तुति बनाता है जिसमें [Detailed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationcontentamounttype/#Detailed) कंटेंट होता है, और इसे PDF के रूप में निर्यात करता है। टेम्पलेट और जनरेटेड प्रस्तुति दोनों ही जारी कर दी जाती हैं, चाहे जनरेशन या सहेजना विफल हो।

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

यदि आपको प्रॉक्सी या कनेक्शन टाइमआउट कॉन्फ़िगर करने की आवश्यकता है, तो देखें [Configure the HTTP Connection](/slides/hi/python-java/ai/translator/#configure-the-http-connection)। आप उत्पन्न क्लाइंट को जेनरेटर को भी पास कर सकते हैं।

## **मुख्य लाभ**

जनरेशन प्रशिक्षण सामग्री, उत्पाद सारांश, क्लाइंट रिपोर्ट और आंतरिक प्रस्तुतियों के प्रारंभिक ड्राफ्ट कार्य को कम कर सकता है। प्रॉम्प्ट विषय और भाषा को नियंत्रित करते हैं, जबकि टेम्पलेट मौजूदा प्रस्तुति डिज़ाइन को पुन: उपयोग करने की अनुमति देता है।

## **FAQ**

**मैं जनरेटेड प्रस्तुति की लंबाई कैसे नियंत्रित करूँ?**

[Brief](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationcontentamounttype/#Medium) या [Detailed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationcontentamounttype/#Detailed) चुनें। ये सेटिंग्स स्लाइडों की संख्या और प्रत्येक स्लाइड पर विवरण को प्रभावित करती हैं; ये सटीक स्लाइड संख्या निर्दिष्ट नहीं करतीं।

**क्या मैं किसी अन्य भाषा में स्लाइड्स जनरेट कर सकता हूँ?**

हाँ। टेक्स्ट विवरण में वांछित भाषा शामिल करें। परिणाम चयनित मॉडल की भाषा क्षमताओं पर निर्भर करता है।

**क्या मैं PDF निर्यात करते समय एक संपादन योग्य संस्करण रख सकता हूँ?**

हाँ। जनरेटेड प्रस्तुति को नष्ट करने से पहले, पहले उदाहरण में दिखाए गए अनुसार इसे PPTX के रूप में भी सहेजें।
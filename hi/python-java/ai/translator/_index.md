---
title: एआई-संचालित प्रस्तुति अनुवादक
linktitle: एआई-संचालित अनुवादक
type: docs
weight: 20
url: /hi/python-java/ai/translator/
keywords:
- एआई प्रस्तुति अनुवादक
- एआई स्लाइड अनुवादक
- बहुभाषी प्रस्तुति
- प्रस्तुति अनुवाद
- स्लाइड अनुवाद
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "एआई का उपयोग करके Aspose.Slides for Python via Java के साथ प्रस्तुतियों का अनुवाद करें। स्लाइड टेक्स्ट को स्थानीयकृत करें और अनूदित प्रस्तुति को PowerPoint या PDF के रूप में सहेजें।"
---
## **परिचय**

Aspose.Slides for Python via Java एक AI प्रस्तुति अनुवाद API प्रदान करता है जिससे स्लाइड सामग्री को स्थानीयकृत किया जा सकता है। मौजूदा प्रस्तुति को निर्दिष्ट भाषा में अनुवाद करें, और फिर अनुवादित संस्करण को अपने दर्शकों की आवश्यक फ़ॉर्मेट में सहेजें।

## **कैसे काम करता है**

[SlidesAIAgent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesaiagent/) बाहरी AI सेवा के साथ AI क्लाइंट के माध्यम से संवाद करता है। उदाहरण में निर्मित [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-java/aspose.slides/openaiwebclient/) का उपयोग किया गया है।

[SlidesAIAgent.translate](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesaiagent/#translate) पास की गई प्रस्तुति को अद्यतन करता है। Aspose.Slides AI प्रतिक्रियाओं को प्रोसेस करता है और स्लाइड टेक्स्ट को बदलता है जबकि मौजूदा लेआउट और फॉर्मेटिंग को बरकरार रखता है। परिणाम की समीक्षा करें: अनूदित टेक्स्ट मूल से लंबा हो सकता है और लेआउट समायोजन की आवश्यकता हो सकती है।

## **आवश्यकताएँ**

लाइब्रेरी और उसका रनटाइम कॉन्फ़िगर करने के लिए [स्थापना](/slides/hi/python-java/installation/) का पालन करें। उदाहरण चलाने से पहले `OPENAI_API_KEY` और `OPENAI_MODEL` पर्यावरण वेरिएबल सेट करें। निर्मित क्लाइंट द्वारा समर्थित और आपके API खाते के लिए उपलब्ध मॉडल चुनें।

{{% alert color="info" title="ध्यान" %}}
अनुवाद के लिए इंटरनेट कनेक्शन आवश्यक है और यह प्रस्तुति टेक्स्ट को कॉन्फ़िगर किए गए AI सेवा को भेजता है। इसका API एक्सेस और उपयोग शुल्क आपके Aspose.Slides लाइसेंस से अलग हैं।
{{% /alert %}}

उदाहरण सक्रिय JVM को पुन: उपयोग करते हैं या आवश्यक होने पर इसे शुरू करते हैं। नोटबुक उपयोग के लिए [JVM जीवनचक्र मार्गदर्शन](/slides/hi/python-java/limitations-and-api-differences/#import-the-library) देखें।

## **एक प्रस्तुति अनुवादित करें**

`sample.pptx` को कार्य निर्देशिका में रखें। यह उदाहरण इसे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के साथ लोड करता है, उसका टेक्स्ट जापानी में अनुवाद करता है, और परिणाम को PDF के रूप में सहेजता है। यह प्रस्तुति को रिलीज़ करता है और AI क्लाइंट को बंद करता है भले ही कोई संचालन विफल हो जाए।

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **HTTP कनेक्शन कॉन्फ़िगर करें**

डिफ़ॉल्ट रूप से, [OpenAIWebClient](https://reference.aspose.com/slides/hi/python-java/aspose.slides/openaiwebclient/) अपना HTTP कनेक्शन आंतरिक रूप से प्रबंधित करता है। इसका चार-आर्ग्यूमेंट कंस्ट्रक्टर बाहरी रूप से प्रबंधित जावा [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) को भी स्वीकार करता है। जब आपको प्रॉक्सी या कनेक्शन टाइमआउट कॉन्फ़िगर करने की आवश्यकता हो तो इस ओवरलोड का उपयोग करें।

निम्न उदाहरण [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) के साथ जावा HTTP प्रॉक्सी बनाता है और [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) के माध्यम से कनेक्शन खोलता है। `proxy.example.com` और पोर्ट को अपने प्रॉक्सी सेटिंग्स से बदलें। कनेक्शन सीधे JPype के माध्यम से पास किया जाता है; एक Python HTTP सत्र इसका उपयोग नहीं कर सकता।

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **मुख्य लाभ**

स्वचालित अनुवाद बहुभाषी प्रशिक्षण सामग्री, उत्पाद प्रस्तुतियों और ग्राहक रिपोर्ट तैयार करने में मदद करता है जबकि मौजूदा स्लाइड डिज़ाइन को पुन: उपयोग किया जाता है। आगे की समीक्षा के लिए संपादनीय प्रस्तुति सहेजें या वितरण के लिए PDF निर्यात करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या अनुवाद एक अलग प्रस्तुति ऑब्जेक्ट बनाता है?**

नहीं। [SlidesAIAgent.translate](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesaiagent/#translate) प्रदान की गई प्रस्तुति को संशोधित करता है। मूल फ़ाइल को अपरिवर्तित रखने के लिए इसे नए फ़ाइल नाम में सहेजें।

**मैं लक्षित भाषा कैसे निर्दिष्ट करूँ?**

भाषा का नाम, जैसे कि `"Japanese"` या `"Spanish"`, दूसरे आर्ग्यूमेंट के रूप में पास करें। अनुवाद की गुणवत्ता और भाषा कवरेज चयनित मॉडल पर निर्भर करती है।

**क्या मैं प्रॉक्सी का उपयोग किए बिना अनुवाद कर सकता हूँ?**

हाँ। पहले उदाहरण में दिखाए गए तीन-आर्ग्यूमेंट क्लाइंट कंस्ट्रक्टर का उपयोग करें। कस्टम कनेक्शन उदाहरण केवल तब आवश्यक है जब आपके अनुप्रयोग को स्पष्ट कनेक्शन सेटिंग्स चाहिए हों।
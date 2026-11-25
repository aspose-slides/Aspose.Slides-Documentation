---
title: Python में दीर्घकालिक प्रेज़ेंटेशन ऑपरेशनों को बाधित करें
linktitle: प्रेज़ेंटेशन ऑपरेशनों को बाधित करें
type: docs
weight: 150
url: /hi/python-net/support-for-interruptable-library/
keywords:
- बाधित करने योग्य ऑपरेशन्स
- विच्छेदन टोकन
- PDF निर्यात रद्द करें
- PowerPoint
- Python
- Aspose.Slides
description: "Python में प्रेज़ेंटेशन रूपांतरण को रद्द करना और रद्दीकरण से पहले निर्यात समाप्त करने वाली स्लाइड्स की सूची लौटाना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET लम्बी‑अवधि वाले कार्यों जैसे लोडिंग, सेविंग और प्रेज़ेंटेशन रेंडरिंग के दौरान सहयोगी रद्दीकरण (cancellation) का समर्थन करता है। जब आप स्लाइड्स को व्यक्तिगत रूप से निर्यात करते हैं, तो आप स्लाइड्स के बीच रद्दीकरण की जाँच भी कर सकते हैं और उन स्लाइड्स के क्रमांक वापस दे सकते हैं जो निर्यात समाप्त कर चुकी हैं।

## **प्रेज़ेंटेशन रूपांतरण रद्द करें**

एक [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/) बनाएँ, उसका [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) को [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/) में सेट करें, और विकल्पों को [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/) में पास करें। टोकन पूरे प्रेज़ेंटेशन के जीवनकाल में लागू रहता है। अपने एप्लिकेशन से रद्दीकरण के अनुरोध के लिए, [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/) को कॉल करें।

उदाहरण `sample.pptx` को `sample.pdf` में परिवर्तित करता है। एक [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) 20 सेकंड के बाद `source.interrupt` को कॉल करता है। फाइल खोलने से पहले टाइमर शुरू करने से टाइम‑आउट लोडिंग और सेविंग दोनों पर लागू होता है। एक Cancel बटन वाला एप्लिकेशन अपने इवेंट हैंडलर से समान मेथड को कॉल कर सकता है।

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

लोडिंग के बाद का स्पष्ट जाँच तब निर्यात को स्किप कर देती है जब टाइम‑आउट पहले ही समाप्त हो चुका हो। यदि लोडिंग या सेविंग अनुरोध को देख लेती है, तो रद्दीकरण अपवाद कॉलर तक पहुँच जाता है। कभी‑कभी सेविंग अनुरोध को देखे‑बिना पहले ही समाप्त हो सकती है, ऐसे में PDF पूरा रहता है।

## **अगली स्लाइड प्रोसेस करने से पहले रोकें**

प्रत्येक निर्यात से पहले [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) को जाँचें। [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 1 से शुरू होने वाले स्लाइड क्रमांक की सूची स्वीकार करता है। केवल तभी पूर्ण सूची में क्रमांक जोड़ें जब उसका PDF सफलतापूर्वक सेव हो गया हो।

एक फ़ाइल `sample.pptx` जिसका कम से कम दो स्लाइड हों, उसका उपयोग करें। परिणाम को पुनरुत्पादन योग्य बनाने के लिए, उदाहरण स्लाइड 1 के समाप्त होते ही रद्दीकरण का अनुरोध करता है। वास्तविक एप्लिकेशन में, अनुरोध किसी अन्य थ्रेड से आ सकता है जबकि स्लाइड सेव हो रही हो।

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

उदाहरण `slide-1.pdf` लिखता है और `Starting slide 1` के बाद `Completed: [1]` प्रिंट करता है। अगली इटरेशन स्लाइड 2 शुरू होने से पहले अनुरोध देख लेती है। यदि रद्दीकरण सेव को बाधित करता है, तो एक्सेप्शन हैंडलर पहले की इटरेशन्स द्वारा दर्ज किए गए क्रमांक लौटाता है। अन्य निर्यात त्रुटियाँ कॉलर तक पहुँचती हैं।

यदि कॉलर को रद्दीकरण को अपवाद के रूप में संभालना चाहिए, तो लूप के शीर्ष पर जाँच और उसका `break` को [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/) से बदलें। साथ ही सेव के आसपास का `try`/`except` हटाएँ। समान इनपुट के साथ, स्लाइड 1 सेव हो जाती है और दूसरी इटरेशन स्लाइड 2 शुरू होने से पहले रद्दीकरण अपवाद उठाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**रद्दीकरण अनुरोध प्रभावी कब होता है?**

एक बाधित होने योग्य ऑपरेशन अपने टोकन को समय‑समय पर जाँचता है। वह अनुरोध मिलते ही रुक जाता है। जो ऑपरेशन पहले ही समाप्त हो चुका है, उसका परिणाम वही रहता है।

**स्रोत (source) और टोकन (token) में क्या अंतर है?**

स्रोत आपके एप्लिकेशन को रद्दीकरण का अनुरोध करने देता है। टोकन प्रेज़ेंटेशन और आपके खुद के कोड दोनों को उस अनुरोध को जाँचने की अनुमति देता है।

**क्या कई ऑपरेशन एक ही स्रोत साझा कर सकते हैं?**

हाँ। `interrupt` को कॉल करने से उस स्रोत से बने सभी टोकन‑आधारित ऑपरेशनों के लिए रद्दीकरण अनुरोध भेजा जाता है। यदि आपको ऑपरेशनों को स्वतंत्र रूप से रद्द करना है तो प्रत्येक ऑपरेशन को अपना स्रोत दें।
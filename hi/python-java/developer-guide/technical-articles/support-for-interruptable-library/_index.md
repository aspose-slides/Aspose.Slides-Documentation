---
title: इंटरप्टेबल लाइब्रेरी के लिए समर्थन
type: docs
weight: 120
url: /hi/python-java/support-for-interruptable-library/
keywords:
- इंटरप्टेबल लाइब्रेरी
- विघटन टोकन
- रद्दीकरण टोकन
- लंबे समय तक चलने वाला कार्य
- कार्य को बाधित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ लंबी अवधि के कार्यों को रद्द करने योग्य बनाएं। PowerPoint और OpenDocument के लिए रेंडरिंग और रूपांतरण को सुरक्षित रूप से बाधित करें, उदाहरणों के साथ।"
---
## **अवलोकन**

Aspose.Slides लम्बे समय तक चलने वाले प्रस्तुति कार्यों, जैसे डीसिरियलाइज़ेशन, सिरियलाइज़ेशन और रेंडरिंग, के लिए एक इंटरप्टेबल प्रोसेसिंग तंत्र प्रदान करता है। यह तंत्र [InterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/) क्लासों पर आधारित है।

[InterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontoken/) को [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) को सौंपा जा सकता है और [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कंस्ट्रक्टर में पास किया जा सकता है। जब [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल किया जाता है, तो सम्बद्ध लम्बे कार्य को बाधित किया जाता है।

## **इंटरप्टेबल लाइब्रेरी**

Aspose.Slides for Python via Java [InterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/) क्लासें प्रदान करता है। ये आपको डीसिरियलाइज़ेशन, सिरियलाइज़ेशन और रेंडरिंग जैसे लम्बे कार्यों को बाधित करने की अनुमति देती हैं।

- [InterruptionTokenSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/) वह स्रोत है जो [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setInterruptionToken) को पास किए जाने वाले टोकन(s) प्रदान करता है।
- जब [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setInterruptionToken) को कॉल किया जाता है और [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) इंस्टेंस को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कंस्ट्रक्टर में पास किया जाता है, तो [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल करने से उस [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) से जुड़े किसी भी लम्बे कार्य को बाधित किया जाता है।

निम्न कोड स्निपेट चल रहे कार्य को बाधित करने का उदाहरण दर्शाता है:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # क्रिया को एक अलग थ्रेड में चलाएँ।
    time.sleep(10)  # समय समाप्ति।
    token_source.interrupt()  # रूपांतरण को रोकें।
    conversion_task.result()
```

## **FAQ**

**Aspose.Slides इंटरप्ट लाइब्रेरी का उद्देश्य क्या है?**

यह लम्बे समय तक चलने वाले संचालन—जैसे प्रस्तुति को लोड करना, सहेजना, या रेंडर करना—को पूरा होने से पहले ही रोकने का तंत्र प्रदान करता है। यह तब उपयोगी है जब प्रसंस्करण समय सीमित होना चाहिए या कार्य की अब आवश्यकता नहीं रही।

**[InterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/) में क्या अंतर है?**

- [InterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontoken/) Aspose.Slides API को पास किया जाता है और लम्बे संचालन के दौरान जाँच किया जाता है।
- [InterruptionTokenSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/) आपके कोड में टोकन बनाने और [interrupt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/#interrupt) को कॉल करके विघटन ट्रिगर करने के लिए उपयोग किया जाता है।

**कौन से कार्य बाधित किए जा सकते हैं?**

कोई भी Aspose.Slides कार्य जो [InterruptionToken](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontoken/) स्वीकार करता है—जैसे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के साथ प्रस्तुति लोड करना या [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) के साथ सहेजना—बाधित किया जा सकता है।

**क्या विघटन तुरंत होता है?**

नहीं। विघटन सहयोगी होता है: संचालन नियमित रूप से टोकन की जाँच करता है और जैसे ही यह पहचानता है कि [interrupt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/#interrupt) कॉल किया गया है, तुरंत रुक जाता है।

**यदि मैं किसी कार्य के समाप्त होने के बाद [interrupt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/#interrupt) कॉल करता हूँ तो क्या होता है?**

कुछ नहीं—यदि संबंधित कार्य पहले ही समाप्त हो चुका है तो कॉल का कोई प्रभाव नहीं पड़ता।

**क्या मैं एक ही [InterruptionTokenSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/) को कई कार्यों के लिए पुनः उपयोग कर सकता हूँ?**

हाँ—लेकिन जब आप उस स्रोत पर [interrupt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/interruptiontokensource/#interrupt) कॉल करते हैं, तो उसके टोकन का उपयोग करने वाले सभी कार्य बाधित हो जाएंगे। कार्यों को स्वतंत्र रूप से प्रबंधित करने के लिए अलग‑अलग टोकन स्रोतों का उपयोग करें।
---
title: इंटरप्टेबल लाइब्रेरी के लिए समर्थन
type: docs
weight: 120
url: /hi/java/support-for-interruptable-library/
keywords:
- इंटरप्टेबल लाइब्रेरी
- इंटरप्शन टोकन
- रद्दीकरण टोकन
- दीर्घकालिक कार्य
- बाधित कार्य
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ दीर्घकालिक कार्यों को रद्दीकरण योग्य बनाएं। PowerPoint और OpenDocument के लिए रेंडरिंग और रूपांतरण को सुरक्षित रूप से बाधित करें, उदाहरणों के साथ।"
---
## **सारांश**

Aspose.Slides लंबी अवधि वाले प्रस्तुति कार्यों, जैसे डीसीरियलाइज़ेशन, सीरियलाइज़ेशन और रेंडरिंग, के लिए बाध्यकारी प्रोसेसिंग तंत्र प्रदान करता है। यह तंत्र `InterruptionToken` और `InterruptionTokenSource` वर्गों पर आधारित है।

`InterruptionToken` को `LoadOptions` को असाइन किया जा सकता है और `Presentation` कन्स्ट्रक्टर में पास किया जा सकता है। जब `InterruptionTokenSource.interrupt()` को कॉल किया जाता है, तो संबंधित लंबा कार्य बाधित हो जाता है।

## **इंटरप्टेबल लाइब्रेरी**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/hi/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) में, हमने [InterruptionToken](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontokensource/) वर्गों को पेश किया। ये आपको डीसीरियलाइज़ेशन, सीरियलाइज़ेशन और रेंडरिंग जैसे दीर्घकालिक कार्यों को बाधित करने की अनुमति देते हैं।

- [InterruptionTokenSource](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontokensource/) वह स्रोत है जो टोकन(s) को [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) में पास करता है।
- जब [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) सेट किया जाता है और [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) इंस्टेंस को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) कन्स्ट्रक्टर में पास किया जाता है, तो [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontokensource/#interrupt--) को बुलाने से उस [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) से जुड़े किसी भी दीर्घकालिक कार्य को बाधित किया जाता है।

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // क्रिया को अलग थ्रेड में चलाएँ
Thread.sleep(10000);     // समय समाप्त
tokenSource.interrupt(); // रूपांतरण रोकें
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides बाध्य लाइब्रेरी का उद्देश्य क्या है?**

यह लम्बी अवधि वाले ऑपरेशनों—जैसे प्रस्तुति को लोड करना, सेव करना, या रेंडर करना—को पूर्ण होने से पहले बाधित करने का तंत्र प्रदान करता है। यह तब उपयोगी होता है जब प्रोसेसिंग समय सीमित होना चाहिए या कार्य अब आवश्यक नहीं रहता।

**[InterruptionToken](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontokensource/) में क्या अंतर है?**

- `InterruptionToken` Aspose.Slides API को पास किया जाता है और दीर्घकालिक ऑपरेशनों के दौरान जाँच किया जाता है।
- `InterruptionTokenSource` आपके कोड में टोकन बनाने और `Interrupt()` कॉल करके बाधाओं को ट्रिगर करने के लिए उपयोग किया जाता है।

**कौन से कार्य बाधित किए जा सकते हैं?**

कोई भी Aspose.Slides कार्य जो एक [InterruptionToken](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontoken/) स्वीकार करता है—जैसे `Presentation(path, loadOptions)` के साथ प्रस्तुति लोड करना या `Presentation.save(...)` के साथ सेव करना—बाधित किया जा सकता है।

**क्या बाधा तुरंत होती है?**

नहीं। बाधा सहयोगी होती है: ऑपरेशन समय-समय पर टोकन की जाँच करता है और जैसे ही वह देखता है कि [Interrupt()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontokensource/#interrupt--) कॉल किया गया है, वह रुक जाता है।

**यदि मैं किसी कार्य के पूर्ण होने के बाद [Interrupt()] कॉल करता हूँ तो क्या होता है?**

कुछ नहीं—यदि संबंधित कार्य पहले ही पूर्ण हो चुका है, तो कॉल का कोई प्रभाव नहीं पड़ता।

**क्या मैं एक ही [InterruptionTokenSource](https://reference.aspose.com/slides/hi/java/com.aspose.slides/interruptiontokensource/) को कई कार्यों के लिए पुन: उपयोग कर सकता हूँ?**

हां— परन्तु जब आप उस स्रोत पर [Interrupt()] कॉल करते हैं, तो उसके टोकन का उपयोग करने वाले सभी कार्य बाधित हो जाएंगे। कार्यों को स्वतंत्र रूप से प्रबंधित करने के लिए अलग-अलग टोकन स्रोतों का उपयोग करें।
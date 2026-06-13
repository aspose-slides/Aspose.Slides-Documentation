---
title: बाधा-सक्षम लाइब्रेरी के लिए समर्थन
type: docs
weight: 150
url: /hi/cpp/support-for-interruptable-library/
keywords:
- बाधा-सक्षम लाइब्रेरी
- बाधा टोकन
- रद्दीकरण टोकन
- दीर्घकालिक कार्य
- कार्य बाधित करना
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ दीर्घकालिक कार्यों को रद्दीकरण योग्य बनाएं। PowerPoint और OpenDocument के लिए रेंडरिंग और रूपांतरण को सुरक्षित रूप से बाधित करें, उदाहरणों के साथ।"
---
## **परिचय**

Aspose.Slides दीर्घकालिक प्रेजेंटेशन कार्यों, जैसे डीसिरियलाइज़ेशन, सिरियलाइज़ेशन, और रेंडरिंग, के लिए एक बाधा योग्य प्रोसेसिंग तंत्र प्रदान करती है। यह तंत्र `InterruptionToken` और `InterruptionTokenSource` क्लासों पर आधारित है।

`InterruptionToken` को `LoadOptions` को असाइन किया जा सकता है और `Presentation` कॉन्स्ट्रक्टर को पास किया जा सकता है। जब `InterruptionTokenSource::Interrupt()` को कॉल किया जाता है, तो संबंधित दीर्घकालिक कार्य बाधित हो जाता है।

## **बाधा‑सक्षम लाइब्रेरी**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/hi/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) में, हमने [InterruptionToken](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/) क्लासें पेश कीं। ये आपको डीसिरियलाइज़ेशन, सिरियलाइज़ेशन, और रेंडरिंग जैसे दीर्घकालिक कार्यों को बाधित करने की अनुमति देती हैं।

- [InterruptionTokenSource](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/) वह स्रोत है जो टोकन(स) को [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_interruptiontoken/) को पास करता है।
- जब [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_interruptiontoken/) सेट किया जाता है और [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) इंस्टेंस को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) कॉन्स्ट्रक्टर को पास किया जाता है, तो [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/interrupt/) को कॉल करने से उस [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) से जुड़े किसी भी दीर्घकालिक कार्य को बाधित किया जाता है।

निम्नलिखित कोड स्निपेट चल रहे कार्य को बाधित करने का प्रदर्शन करता है:

```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // क्रिया को एक अलग थ्रेड में चलाएँ
    Threading::Thread::Sleep(10000);       // समय समाप्ति
    tokenSource->Interrupt();              // रूपांतरण को रोकें
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides बाधा लाइब्रेरी का उद्देश्य क्या है?**

यह दीर्घकालिक ऑपरेशनों—जैसे प्रेजेंटेशन को लोड करना, सेव करना, या रेंडर करना—को पूरा होने से पहले बाधित करने का तंत्र प्रदान करता है। यह तब उपयोगी होता है जब प्रोसेसिंग समय सीमित होना चाहिए या कार्य अब आवश्यक नहीं रहता।

**[InterruptionToken](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/) में क्या अंतर है?**

- `InterruptionToken` को Aspose.Slides API को पास किया जाता है और दीर्घकालिक ऑपरेशनों के दौरान जाँच किया जाता है।
- `InterruptionTokenSource` को आपके कोड में टोकन बनाने और `Interrupt()` कॉल करके बाधाएँ प्रारंभ करने के लिए उपयोग किया जाता है।

**कौन से कार्य बाधित किए जा सकते हैं?**

कोई भी Aspose.Slides कार्य जो [InterruptionToken](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontoken/) को स्वीकार करता है—जैसे `Presentation(path, loadOptions)` के साथ प्रेजेंटेशन लोड करना या `Presentation::Save(...)` के साथ सेव करना—बाधित किया जा सकता है।

**क्या बाधा तुरंत होती है?**

नहीं। बाधा सहयोगी है: ऑपरेशन नियमित रूप से टोकन की जाँच करता है और जैसे ही यह पता करता है कि [Interrupt()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/interrupt/) को कॉल किया गया है, तुरंत रुक जाता है।

**यदि मैं किसी कार्य के पूर्ण होने के बाद [Interrupt()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/interrupt/) कॉल करता हूँ तो क्या होता है?**

कुछ नहीं—यदि संबंधित कार्य पहले ही पूर्ण हो चुका है, तो कॉल का कोई प्रभाव नहीं होता।

**क्या मैं एक ही [InterruptionTokenSource](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/) को कई कार्यों के लिए पुनः उपयोग कर सकता हूँ?**

हां—लेकिन एक बार जब आप उस स्रोत पर [Interrupt()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/interruptiontokensource/interrupt/) कॉल करते हैं, तो उसके टोकन प्रयोग करने वाले सभी कार्य बाधित हो जाएंगे। कार्यों को स्वतंत्र रूप से प्रबंधित करने के लिए अलग-अलग टोकन स्रोतों का उपयोग करें।
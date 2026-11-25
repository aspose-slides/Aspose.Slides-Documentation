---
title: C++ में लंबी अवधि की प्रेजेंटेशन ऑपरेशनों को बाधित करें
linktitle: प्रेजेंटेशन ऑपरेशनों को बाधित करें
type: docs
weight: 150
url: /hi/cpp/support-for-interruptable-library/
keywords:
- बाध्यात्मक ऑपरेशन्स
- इंटरप्शन टोकन
- रद्दीकरण टोकन
- लंबी अवधि का कार्य
- बाधित कार्य
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में लंबी अवधि की प्रेजेंटेशन ऑपरेशनों को रद्द करना सीखें और लूप में स्लाइड्स को एक्सपोर्ट करते समय एक आंशिक परिणाम लौटाएँ।"
---
## **अवलोकन**

Aspose.Slides for C++ लंबी अवधि के ऑपरेशनों जैसे लोडिंग, सेविंग, और प्रेजेंटेशन रेंडरिंग को बाधित कर सकता है। आपका एप्लिकेशन वही interruption token का उपयोग करके अगले स्लाइड को प्रोसेस करने से पहले लूप को रोक सकता है।

## **प्रेजेंटेशन ऑपरेशन को बाधित करें**

एक [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) बनाएं, उसका टोकन [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) के साथ प्राप्त करें, टोकन को [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) में पास करें, और लोड विकल्प को [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) को पास करें। रद्दीकरण का अनुरोध करने के लिए स्रोत पर [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) को कॉल करें। एक बाध्यात्मक ऑपरेशन तब रुकता है जब वह अनुरोध को देखता है।

उदाहरण बैकग्राउंड टास्क में `sample.pptx` को `sample.ppt` में बदलना शुरू करता है और यदि कार्य 10 सेकंड के बाद भी चल रहा है तो रद्दीकरण का अनुरोध करता है। यदि रूपांतरण पहले ही समाप्त हो जाता है, तो आउटपुट पहले से ही पूरा हो गया है।

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **एप्लिकेशन रद्दीकरण को Aspose.Slides से जोड़ें**

यदि आपका एप्लिकेशन एक [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) का उपयोग करता है, तो रद्दीकरण अनुरोधों को [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) पर फॉरवर्ड करने के लिए [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) का उपयोग करें। उदाहरण `sample.pptx` को `sample.pdf` में बैकग्राउंड टास्क में एक्सपोर्ट करता है। यदि एक्सपोर्ट 20 सेकंड के बाद भी चल रहा है, तो एप्लिकेशन [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/) को कॉल करता है, जो पंजीकृत कॉलबैक को invoke करता है।

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **अगले स्लाइड को प्रोसेस करने से पहले रोकें**

प्रेजेंटेशन और उसके स्लाइड्स को एक्सपोर्ट करने वाले लूप दोनों के लिए एक ही [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) का उपयोग करें। प्रत्येक एक्सपोर्ट शुरू करने से पहले [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) को जांचें। यदि कॉलर आंशिक परिणाम का उपयोग कर सकता है, तो सफलतापूर्वक पूर्ण हुए एक्सपोर्ट्स के स्लाइड नंबर वापस करें।

कम से कम दो स्लाइड्स वाला `sample.pptx` नामक प्रेजेंटेशन उपयोग करें। उदाहरण पहले सफल एक्सपोर्ट को रिकॉर्ड करने के बाद तुरंत रद्दीकरण का अनुरोध करता है।

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

उदाहरण `slide-1.pdf` लिखता है और `Starting slide 1` को प्रिंट करता है, उसके बाद `Completed: [1]`। लूप स्लाइड 2 शुरू करने से पहले अनुरोध को देख लेता है। यदि रद्दीकरण के बजाय एक्सपोर्ट के दौरान [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) को बाधित करता है, तो `catch` ब्लॉक कोड को वर्तमान स्लाइड को पूर्ण मानने से पहले लूप से बाहर निकल जाता है।

यदि कॉलर को रद्दीकरण को संभालना हो, तो लूप के शीर्ष पर `if` जांच और उसका `break` को टोकन पर [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) कॉल से बदलें। एक्सपोर्ट के चारों ओर का `try`/`catch` हटाएँ ताकि सेव के दौरान रद्दीकरण भी कॉलर तक पहुंच सके। समान इनपुट के साथ, उदाहरण केवल `Starting slide 1` प्रिंट करता है और `slide-1.pdf` लिखता है। दूसरी इटरेशन की शुरुआत में, एक्सपोर्ट शुरू होने से पहले कॉलर को एक [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) मिलता है। कॉलर को पूर्ण हुए स्लाइड्स की कोई सूची नहीं मिलती।

## **FAQ**

**मुझे कब रद्दीकरण का अनुरोध करना चाहिए?**

जब कोई ऑपरेशन आपके समय सीमा से अधिक हो जाए या आपका एप्लिकेशन परिणाम की अब आवश्यकता न रखे, तब रद्दीकरण का अनुरोध करें।

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) में क्या अंतर है?**

स्रोत आपको रद्दीकरण का अनुरोध करने की अनुमति देता है। टोकन Aspose.Slides और आपके एप्लिकेशन को उस अनुरोध की जाँच करने देता है।

**क्या मैं एक [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) को Aspose.Slides के साथ उपयोग कर सकता हूँ?**

हां। जब आपके एप्लिकेशन का टोकन रद्दीकरण का संकेत देता है, तो प्रेजेंटेशन से जुड़े स्रोत पर [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) को कॉल करें।

**मैं किन ऑपरेशनों को बाधित कर सकता हूँ?**

आप लोडिंग, सेविंग और रेंडरिंग को बाधित कर सकते हैं। टोकन को [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) के माध्यम से [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) में पास करें। प्रेजेंटेशन तब बाद के ऑपरेशनों जैसे कि [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) के दौरान रद्दीकरण देख सकता है।

**क्या कोई ऑपरेशन तुरंत रुकता है?**

रद्दीकरण सहयोगी होता है। कोई ऑपरेशन टोकन को समय-समय पर जांचता है और अनुरोध देखे जाने पर रुकता है।

**यदि मैं किसी ऑपरेशन के समाप्त होने के बाद [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) कॉल करता हूँ तो क्या होता है?**

पूरा हुआ ऑपरेशन अपना परिणाम रखता है।

**क्या कई ऑपरेशनों के साथ एक [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) साझा किया जा सकता है?**

हां। [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) को कॉल करने से उस स्रोत से टोकन उपयोग करने वाले प्रत्येक ऑपरेशन के लिए रद्दीकरण का अनुरोध होता है। उन ऑपरेशनों को स्वतंत्र रूप से रद्द करने के लिए प्रत्येक के लिए अलग स्रोत उपयोग करें।
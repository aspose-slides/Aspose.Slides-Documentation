---
title: إيقاف عمليات العرض التقديمي طويلة الأمد في C++
linktitle: إيقاف عمليات العرض التقديمي
type: docs
weight: 150
url: /ar/cpp/support-for-interruptable-library/
keywords:
- عمليات قابلة للمقاطعة
- رمز المقاطعة
- رمز الإلغاء
- مهمة طويلة الأمد
- إيقاف مهمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرّف على كيفية إلغاء عمليات العرض التقديمي طويلة الأمد في Aspose.Slides for C++ وإرجاع نتيجة جزئية عند تصدير الشرائح في حلقة."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ إيقاف عمليات طويلة الأمد مثل التحميل، الحفظ، وعرض العروض التقديمية. يمكن لتطبيقك استخدام نفس رمز المقاطعة لإيقاف حلقة قبل أن تبدأ بمعالجة الشريحة التالية.

## **مقاطعة عملية العرض التقديمي**

أنشئ [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)، استرجع رمزه باستخدام [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/)، مرّر الرمز إلى [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/)، ومرّر خيارات التحميل إلى [منشئ Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). لطلب الإلغاء، استدعِ [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) على المصدر. تتوقف العملية القابلة للمقاطعة عندما تلاحظ الطلب.

يبدأ المثال بتحويل `sample.pptx` إلى `sample.ppt` في مهمة خلفية ويطلب الإلغاء إذا استمرت المهمة بعد 10 ثوانٍ. إذا انتهى التحويل مبكرًا، يكون الإخراج جاهزًا بالفعل.

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

## **ربط إلغاء التطبيق بـ Aspose.Slides**

إذا كان تطبيقك يستخدم [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/)، استخدم [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) لإرسال طلبات الإلغاء إلى [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). يُصدّر المثال `sample.pptx` إلى `sample.pdf` في مهمة خلفية. إذا استمر التصدير بعد 20 ثانية، يستدعي التطبيق [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/)، مما يُفعِّل الرد المسجَّل.

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

## **الإيقاف قبل معالجة الشريحة التالية**

استخدم نفس [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) لكل من العرض التقديمي والحلقة التي تُصدّر الشرائح. تحقق من [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) قبل بدء كل تصدير. إذا كان المستدعي يمكنه الاستفادة من نتيجة جزئية، أعد أرقام الشرائح التي اكتمل تصديرها بنجاح.

استخدم عرضًا تقديميًا باسم `sample.pptx` يحتوي على شريحتين على الأقل. يطلب المثال الإلغاء فورًا بعد تسجيل أول تصدير ناجح.

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

يكتب المثال `slide-1.pdf` ويطبع `Starting slide 1` متبوعًا بـ `Completed: [1]`. ترى الحلقة الطلب قبل أن تبدأ الشريحة 2. إذا أدى الإلغاء إلى مقاطعة [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) أثناء تصدير، يخرج كتلة `catch` من الحلقة قبل أن يُسجِّل الكود الشريحة الحالية كمنجزة.

إذا احتاج المستدعي إلى معالجة الإلغاء، استبدل فحص `if` و `break` في أعلى الحلقة باستدعاء [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) على الرمز. أزل كتلة `try`/`catch` حول التصدير بحيث يصل الإلغاء أثناء الحفظ إلى المستدعي أيضًا. مع نفس المدخلات، يطبع المثال فقط `Starting slide 1` ويكتب `slide-1.pdf`. عند بداية التكرار الثاني، يتلقى المستدعي [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) قبل بدء التصدير. لا يتلقى المستدعي أي قائمة بالشرائح المكتملة.

## **الأسئلة الشائعة**

**متى يجب أن أطلب الإلغاء؟**  
اطلب الإلغاء عندما تتجاوز العملية حدك الزمني أو عندما لا يحتاج تطبيقك إلى النتيجة بعد الآن.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**  
المصدر يسمح لتطبيقك بطلب الإلغاء. الرمز المميز يسمح لـ Aspose.Slides وتطبيقك بالتحقق من ذلك الطلب.

**هل يمكنني استخدام [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) مع Aspose.Slides؟**  
نعم. عندما يشير الرمز المميز في تطبيقك إلى الإلغاء، استدعِ [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) على المصدر المرتبط بالعرض.

**ما هي العمليات التي يمكنني مقاطعتها؟**  
يمكنك مقاطعة التحميل، الحفظ، والعرض. مرّر الرمز إلى [منشئ Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) عبر [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). يمكن للعرض بعدها مراقبة الإلغاء أثناء العمليات اللاحقة مثل [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**هل تتوقف العملية فورًا؟**  
الإلغاء تعاوني. تتحقق العملية من الرمز بشكل دوري وتتوقف عندما تلاحظ الطلب.

**ماذا يحدث إذا استدعيت [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) بعد انتهاء عملية؟**  
تحتفظ العملية المكتملة بنتيجتها.

**هل يمكن لعدة عمليات مشاركة نفس [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**  
نعم. استدعاء [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) يطلب الإلغاء لكل عملية تستخدم رمزًا من ذلك المصدر. استخدم مصدرًا منفصلاً لكل عملية تريد إلغاؤها بشكل مستقل.
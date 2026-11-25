---
title: قطع عملیات طولانی‌مدت ارائه در C++
linktitle: قطع عملیات ارائه
type: docs
weight: 150
url: /fa/cpp/support-for-interruptable-library/
keywords:
- عملیات‌های قابل قطع
- توکن قطع
- توکن لغو
- کار طولانی‌مدت
- کار قطع
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "نحوهٔ لغو عملیات طولانی‌مدت ارائه در Aspose.Slides برای C++ و بازگرداندن نتیجهٔ جزئی هنگام استخراج اسلایدها در یک حلقه را بیاموزید."
---
## **بررسی کلی**

Aspose.Slides برای C++ می‌تواند عملیات‌های طولانی‌مدت مانند بارگذاری، ذخیره‌سازی و رندر کردن ارائه‌ها را متوقف کند. برنامه شما می‌تواند از همان توکن قطع برای متوقف کردن حلقه قبل از شروع پردازش اسلاید بعدی استفاده کند.

## **متوقف کردن عملیات ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) ایجاد کنید، توکن آن را با [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) دریافت کنید، توکن را به [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) پاس دهید، و گزینه‌های بارگذاری را به [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) پاس کنید. برای درخواست لغو، روی منبع [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) را فراخوانی کنید. یک عملیات قابل قطع زمانی که درخواست را مشاهده کند، متوقف می‌شود.

مثال تبدیل `sample.pptx` به `sample.ppt` را در یک کار پس‌زمینه آغاز می‌کند و در صورتی که کار پس از 10 ثانیه هنوز در حال اجرا باشد، درخواست لغو می‌کند. اگر تبدیل زودتر به پایان برسد، خروجی قبلاً کامل است.

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

## **اتصال لغو برنامه به Aspose.Slides**

اگر برنامه شما از یک [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) استفاده می‌کند، از [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) برای انتقال درخواست‌های لغو به [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) استفاده کنید. مثال `sample.pptx` را به `sample.pdf` در یک کار پس‌زمینه صادر می‌کند. اگر خروجی پس از 20 ثانیه هنوز در حال اجرا باشد، برنامه [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/) را فراخوانی می‌کند که کال‌بک ثبت‌شده را اجرا می‌گیرد.

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

## **توقف پیش از پردازش اسلاید بعدی**

از یک [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) یکسان برای هر دو ارائه و حلقه‌ای که اسلایدهای آن را صادر می‌کند استفاده کنید. قبل از شروع هر خروجی، [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) را بررسی کنید. اگر فراخوان می‌تواند از نتیجهٔ جزئی استفاده کند، شماره اسلایدهای خروجی‌های با موفقیت کامل‌شده را برگردانید.

از یک ارائه به نام `sample.pptx` که حداقل دو اسلاید دارد استفاده کنید. مثال بلافاصله پس از ثبت اولین خروجی موفق، درخواست لغو می‌کند.

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

مثال `slide-1.pdf` را می‌نویسد و `Starting slide 1` را چاپ می‌کند و سپس `Completed: [1]`. حلقه درخواست را پیش از شروع اسلاید 2 می‌بیند. اگر لغو به جای آن [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) را در طول یک خروجی قطع کند، بلوک `catch` قبل از ثبت اسلاید جاری به‌عنوان کامل، حلقه را خاتمه می‌دهد.

اگر فراخوان به مدیریت لغو نیاز دارد، بررسی `if` و `break` آن در ابتدای حلقه را با یک فراخوانی به [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) روی توکن جایگزین کنید. `try`/`catch` اطراف خروجی را حذف کنید تا لغو هنگام ذخیره نیز به فراخوان برسد. با همان ورودی، مثال فقط `Starting slide 1` را چاپ می‌کند و `slide-1.pdf` را می‌نویسد. در شروع تکرار دوم، فراخوان یک [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) دریافت می‌کند پیش از اینکه خروجی آغاز شود. فراخوان هیچ فهرستی از اسلایدهای تکمیل‌شده دریافت نمی‌کند.

## **سؤال‌های متداول**

**چه زمانی باید درخواست لغو کنم؟**

در زمانی که یک عملیات از محدودیت زمانی شما فراتر رود یا برنامه شما دیگر به نتیجه نیاز نداشته باشد، درخواست لغو کنید.

**تفاوت بین [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) چیست؟**

منبع به برنامه شما امکان درخواست لغو را می‌دهد. توکن به Aspose.Slides و برنامه شما امکان بررسی آن درخواست را می‌دهد.

**آیا می‌توانم از یک [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) با Aspose.Slides استفاده کنم؟**

بله. وقتی توکن برنامه شما علامت لغو می‌دهد، [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) را روی منبع مرتبط با ارائه فراخوانی کنید.

**کدام عملیات‌ها را می‌توانم قطع کنم؟**

می‌توانید بارگذاری، ذخیره‌سازی و رندر کردن را قطع کنید. توکن را از طریق [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) به [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) پاس کنید. سپس ارائه می‌تواند لغو را در عملیات‌های بعدی مانند [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) مشاهده کند.

**آیا یک عملیات بلافاصله متوقف می‌شود؟**

لغو همکاری است. یک عملیات به‌صورت دوره‌ای توکن را بررسی می‌کند و زمانی که درخواست را ببیند، متوقف می‌شود.

**چه می‌شود اگر پس از اتمام یک عملیات، [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) را فراخوانی کنم؟**

عملیات تکمیل‌شده نتیجهٔ خود را حفظ می‌کند.

**آیا چندین عملیات می‌توانند یک [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) را به‌اشتراک بگذارند؟**

بله. فراخوانی [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) درخواست لغو را برای هر عملیاتی که از توکن آن منبع استفاده می‌کند، ارسال می‌کند. برای هر عملیاتی که می‌خواهید به‌طور مستقل لغو کنید، یک منبع جداگانه استفاده کنید.
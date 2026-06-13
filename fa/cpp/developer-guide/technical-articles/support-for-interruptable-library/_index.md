---
title: پشتیبانی از کتابخانه قابل قطع
type: docs
weight: 150
url: /fa/cpp/support-for-interruptable-library/
keywords:
- کتابخانه قابل قطع
- توکن قطع
- توکن لغو
- کار طولانی‌مدت
- قطع کار
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کارهای طولانی‌مدت را با Aspose.Slides برای C++ قابل لغو کنید. رندرینگ و تبدیل‌ها برای PowerPoint و OpenDocument را به‌صورت ایمن قطع کنید، به همراه مثال‌ها."
---
## **مروری**

Aspose.Slides یک مکانیسم پردازش قابل قطع برای وظایف طولانی‌مدت ارائه، مانند غیرسریال‌سازی، سریال‌سازی و رندرینگ فراهم می‌کند. این مکانیزم بر پایه کلاس‌های `InterruptionToken` و `InterruptionTokenSource` است.

یک `InterruptionToken` می‌تواند به `LoadOptions` اختصاص داده شود و به سازندهٔ `Presentation` منتقل شود. وقتی `InterruptionTokenSource::Interrupt()` فراخوانی می‌شود، کار طولانی‌مدت مرتبط قطع می‌گردد.

## **کتابخانه قابل قطع**

در [Aspose.Slides 18.4](https://releases.aspose.com/slides/fa/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) ما کلاس‌های [InterruptionToken](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/) را معرفی کردیم. این کلاس‌ها به شما امکان می‌دهند تا وظایف طولانی‌مدت مانند غیرسریال‌سازی، سریال‌سازی و رندرینگ را قطع کنید.

- [InterruptionTokenSource](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/) منبع توکن(ها) است که به [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_interruptiontoken/) پاس داده می‌شود.
- وقتی [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_interruptiontoken/) تنظیم می‌شود و نمونهٔ [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) پاس داده می‌شود، فراخوانی [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/interrupt/) هر کار طولانی‌مدت مرتبط با آن [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را قطع می‌کند.

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
    
    Run(action, tokenSource->get_Token()); // اکشن را در یک نخ جداگانه اجرا کنید
    Threading::Thread::Sleep(10000);       // زمان‌توقف
    tokenSource->Interrupt();              // تبدیل را متوقف کنید
}
```

## **سوالات متداول**

**هدف کتابخانهٔ قطع Aspose.Slides چیست؟**

این یک مکانیزم برای قطع عملیات طولانی‌مدت—مانند بارگذاری، ذخیره‌سازی یا رندرینگ ارائه‌ها—قبل از اتمام آن‌ها فراهم می‌کند. این وقتی مفید است که زمان پردازش باید محدود شود یا کار دیگر مورد نیاز نباشد.

**تفاوت بین [InterruptionToken](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/) چیست؟**

- `InterruptionToken` به API Aspose.Slides پاس داده می‌شود و در طول عملیات طولانی‌مدت بررسی می‌شود.
- `InterruptionTokenSource` در کد شما برای ایجاد توکن‌ها و ایجاد قطع با فراخوانی `Interrupt()` استفاده می‌شود.

**کدام وظایف می‌توانند قطع شوند؟**

هر وظیفه‌ای از Aspose.Slides که یک [InterruptionToken](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontoken/) می‌پذیرد—مانند بارگذاری یک ارائه با `Presentation(path, loadOptions)` یا ذخیره با `Presentation::Save(...)`—قابل قطع است.

**آیا قطع به‌صورت فوری رخ می‌دهد؟**

خیر. قطع به صورت تعاملی است: عملیات به‌طور دوره‌ای توکن را بررسی می‌کند و به محض اینکه متوجه فراخوانی [Interrupt()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/interrupt/) شود، متوقف می‌شود.

**اگر پس از اتمام یک کار، [Interrupt()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/interrupt/) را فراخوانی کنم، چه می‌شود؟**

هیچ چیزی—اگر کار مربوطه قبلاً تکمیل شده باشد، فراخوانی هیچ تاثیری ندارد.

**آیا می‌توانم از همان [InterruptionTokenSource](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/) برای چندین کار استفاده کنم؟**

بله—اما پس از اینکه [Interrupt()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/interruptiontokensource/interrupt/) را روی آن منبع فراخوانی کردید، تمام کارهایی که از توکن‌های آن استفاده می‌کنند قطع می‌شوند. برای مدیریت مستقل کارها از منابع توکن جداگانه استفاده کنید.
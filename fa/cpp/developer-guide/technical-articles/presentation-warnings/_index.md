---
title: "مدیریت هشدارهای ارائه در C++"
type: docs
weight: 70
url: /fa/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- "فراخوانی هشدار"
- "سیاست هشدار"
- "از دست رفتن داده"
- "خرابی منبع"
- "مسئله سازگاری"
- "جایگزینی قلم"
- "امضای دیجیتال"
- "بارگیری ارائه"
- "رندر ارائه"
- "تبدیل ارائه"
- "ذخیره‌سازی ارائه"
- "PowerPoint"
- "OpenDocument"
- "C++"
- "Aspose.Slides"
description: "یاد بگیرید چگونه هشدارها را هنگام بارگیری، رندر، تبدیل و ذخیره‌سازی ارائه‌ها با Aspose.Slides برای C++ جمع‌آوری، طبقه‌بندی و اقدام کنید."
---
## **بررسی کلی**

Aspose.Slides می‌تواند مشکلات قابل بازیابی را هنگام بارگیری، رندر، تبدیل یا ذخیره یک ارائه گزارش کند. مثال‌ها شامل رکوردهای خراب منبع، محتوایی که نمی‌توان حفظ کرد، جایگزینی قلم و محدودیت‌های قالب هدف هستند. یک فراخوانی هشدار (warning callback) به برنامه اجازه می‌دهد این شرایط را ثبت کرده و تصمیم بگیرد آیا عملیات جاری می‌تواند ادامه یابد یا نه.

رابط [IWarningCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/iwarningcallback/) را پیاده‌سازی کنید و روش‌های [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) و [IWarningInfo::get_Description](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/iwarninginfo/get_description/) که از طریق [IWarningInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/iwarninginfo/) ارائه می‌شوند را بررسی کنید. برای پذیرش هشدار، **ReturnAction::Continue** را برگردانید یا برای متوقف کردن عملیات، `ReturnAction::Abort` را برگردانید.

برای هشدارهایی که هنگام باز کردن یک ارائه ایجاد می‌شوند، از [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_warningcallback/) استفاده کنید. کلاس‌های گزینه‌های رندر و خروجی، [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_warningcallback/) را ارث می‌برند که هشدارهای ناشی از رندر اسلاید، تبدیل و ذخیره‌سازی را دریافت می‌کند. چون خود هشدار به طور صریح عملیات برنامه را شناسایی نمی‌کند، هر نمونه فراخوانی را با یک مرحله عملیاتی مرتبط کنید تا گزارش ترکیبی ساخته شود.

## **هشدارها و استثناها**

هشدار شرایطی را توصیف می‌کند که Aspose.Slides در صورت بازگرداندن `ReturnAction::Continue` می‌تواند از آن بازیابی شود. یک استثنا به این معنی است که عملیات درخواست‌شده نمی‌تواند به‌صورت عادی تمام شود؛ استثناها به هشدار تبدیل نمی‌شوند و نمی‌توان آن‌ها را توسط سیاست هشدار مدیریت کرد.

بازگرداندن `ReturnAction::Abort` باعث می‌شود توزیع‌کننده هشدار عملیات جاری را با پرتاب یک استثنا متوقف کند. نوع استثنای عمومی بسته به عملیات و قالب ارائه متفاوت است. برای مثال، هنگام بارگیری ممکن است یک [PptxReadException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxreadexception/) یا [PptReadException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptreadexception/) رخ دهد، در حالی که هنگام ذخیره یا خروجی ممکن است یک [PptxException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxexception/) ظاهر شود. استثنا را در مرز عملیات مدیریت کنید و از گزارش هشدار برای تعیین اینکه آیا سیاست برنامه باعث خاتمه شده است استفاده کنید نه فقط تکیه بر یک زیرنوع یا پیام استثنا. فراخوانی هشدار پیش از بازگرداندن `ReturnAction::Abort` ثبت می‌شود تا دلیل برای برنامه در دسترس بماند.

## **دسته‌های هشدار**

الگوی [WarningType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/warningtype/) دسته‌های زیر را ارائه می‌دهد:

| نوع هشدار | معنی | سیاست معمول |
| --- | --- | --- |
| `SourceFileCorruption` | ارائه منبع شامل خرابی است که می‌تواند سند ذخیره‌شده در قالب اصلی خود را غیرقابل استفاده کند. | Abort. |
| `DataLoss` | ممکن است متن، نمودارها، تصاویر یا داده‌های دیگر پس از بارگیری یا ذخیره‌سازی غائب باشند. | Abort. |
| `MajorFormattingLoss` | ارائه ممکن است قالب‌بندی مهمی را از دست بدهد. | Abort در حالت اعتبارسنجی سفت‌گیر؛ در غیر این صورت ثبت و ادامه. |
| `MinorFormattingLoss` | ممکن است اختلافات محدودی در قالب‌بندی رخ دهد. | ثبت برای تشخیص و ادامه. |
| `CompatibilityIssue` | نتیجه ممکن است در برخی برنامه‌ها یا نسخه‌های قدیمی به‌درستی باز نشود یا رفتار نادرست داشته باشد. | ثبت و ادامه مگر اینکه سازگاری الزامی باشد. |
| `UnexpectedContent` | منبع شامل محتوای پشتیبانی‌نشده یا شناسایی‌نشده‌ای است که اثر آن هنوز شناخته نشده است. | ثبت و ادامه، یا در سیاست سفت‌گیر به‌عنوان خطا در نظر اتخاذ شود. |

دسته‌بندی باید تصمیم‌گیری سیاست را هدایت کند. توضیح هشدار را برای تشخیص ذخیره کنید، اما برای منطق برنامه به عبارات آن وابسته نباشید چون متن پیام می‌تواند بین سناریوهای هشدار و نسخه‌های محصول متفاوت باشد.

## **جمع‌آوری و طبقه‌بندی هشدارها**

مثال زیر یک گزارش سطح برنامه برای کل خط لوله پردازش استفاده می‌کند. یک نمونه فراخوانی جداگانه هشدارهای بارگیری، رندر، تبدیل به PDF و ذخیره‌سازی PPTX را برچسب‌گذاری می‌کند. سیاست در صورت خراب شدن منبع یا از دست رفتن داده‌ها abort می‌کند، به‌طور اختیاری در صورت از دست رفتن قالب‌بندی عمده abort می‌کند و برای سایر هشدارها ادامه می‌دهد.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

`abortOnMajorFormattingLoss` را به `false` تنظیم کنید وقتی اختلافات قالب‌بندی عمده قابل قبول هستند. مسائل سازگاری، از دست رفتن قالب‌بندی جزئی و محتوای غیرمنتظره همچنان در گزارش باقی می‌مانند حتی اگر عملیات ادامه یابد. اگر برنامه باید هر یک از این دسته‌ها را رد کند، `WarningPolicy::GetAction` را گسترش دهید.

## **سناریوهای رایج هشدار**

هشدارها می‌توانند در مراحل مختلف یک جریان کار ظاهر شوند:

- **امضاهای دیجیتال:** یک ارائه امضاشده ممکن است هنگام بارگیری هشداری ایجاد کند که امضای آن در پردازش از دست خواهد رفت. Aspose.Slides این وضعیت `DataLoss` را از طریق [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/) گزارش می‌کند. یک فراخوانی در مرحله بارگیری به برنامه اجازه می‌دهد فایل را رد کند یا به‌صورت صریح فقدان گزارش‌شده را بپذیرد.
- **جایگزینی قلم:** یک قلم در دسترس‌نشدن می‌تواند هنگام رندر یا خروجی اسلاید جایگزین شود. هشدارهای جایگزینی قلم به‌عنوان `DataLoss` گزارش می‌شوند، بنابراین سیاست سفت‌گیر بالا حتی اگر برنامه جایگزینی خاصی را بصورت بصری قابل قبول می‌داند، abort می‌کند. برای مشاهده این رفتار، از یک ارائه ورودی حاوی متنی با قلم در دسترس‌نشدنی استفاده کنید. توضیح هشدار جایگزینی را شناسایی می‌کند؛ قبل از تلاش مجدد قلم‌های مورد نیاز یا [قواعد جایگزینی قلم](/slides/fa/cpp/font-substitution/) را پیکربندی کنید.
- **محتوای پشتیبانی‌نشده یا غیرمنتظره:** یک لودر ممکن است با رکوردها یا ویژگی‌های ارائه‌ای مواجه شود که شناخته نمی‌شوند. چنین هشدارهایی ممکن است `UnexpectedContent` یا دسته‌ی شدیدتری باشند اگر داده یا قالب‌بندی تحت تأثیر باشد.
- **سازگاری قالب:** ذخیره به قالب ارائه‌ای دیگر می‌تواند ویژگی‌ها را حذف کند یا نتیجه‌ای تولید کند که در برخی برنامه‌ها رفتار متفاوتی داشته باشد. برای مثال، ذخیره یک ارائه با بیش از هشت راهنمای افقی یا عمودی به PPT قدیمی یک `CompatibilityIssue` گزارش می‌کند. فراخوانی در مرحله ذخیره می‌تواند این فقدان را ثبت کرده و ادامه دهد، یا اگر حفظ تمام راهنماها ضروری باشد، آن را رد کند.
- **رفتار بارگیری:** گزینه‌های بارگیری و رفتارهای قدیمی نیز می‌توانند هشدار تولید کنند. به‌عنوان مثال، [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) استفاده از رفتار قفل‌گذاری ارائه منسوخ را به‌عنوان `CompatibilityIssue` شناسایی می‌کند.

هشدارها به سند منبع، قالب هدف، عملیات و نسخه Aspose.Slides وابسته‌اند. فرض نکنید هر فایل یک هشدار تولید می‌کند یا هر سناریو همیشه به‌تنهایی به یک دسته تعلق دارد.

## **مدیریت ایمن عملیات خاتمه‌یافته**

زمانی که فراخوانی `ReturnAction::Abort` بر می‌گرداند، از شیئی که بارگیری آن ناموفق بوده استفاده نکنید و فرض نکنید خروجی رندر یا ذخیره کامل شده است. عملیات ممکن است پس از ایجاد فایل خروجی اما پیش از اتمام آن قطع شود.

نتایج اعتبارسنجی‌شده را به مسیر جداگانه‌ای مانند `validated-output.pptx` ذخیره کنید. فقط پس از اینکه عملیات با موفقیت تمام شد، گزارش هشدار سیاست برنامه را برآورده کرد و خروجی قابل باز کردن و بررسی بود، ارائه موجود را جایگزین کنید. این کار از نوشتن فوق‌العاده یک فایل منبع معتبر با نتیجه‌ی جزئی یا ردشده جلوگیری می‌کند.

گزارش هشدار خالی تضمینی نیست که هر ویژگی منبع حفظ شده باشد. هر بررسی محتوا و بصری اضافی که برنامه نیاز دارد اعمال کنید. همچنین به صفحه‌های [Open Presentations](/slides/fa/cpp/open-presentation/) و [Save Presentations](/slides/fa/cpp/save-presentation/) مراجعه کنید.

## **سوالات متداول**

**آیا یک فراخوانی هشدار می‌تواند هر خطای Aspose.Slides را مدیریت کند؟**

خیر. فقط شرایط قابل بازیابی که به‌صورت هشدار گزارش می‌شوند را مدیریت می‌کند. استثناهایی که مستقل از فراخوانی رخ می‌دهند باید توسط برنامه در اطراف فراخوانی‌های بارگیری، رندر، تبدیل یا ذخیره‌سازی مدیریت شوند.

**آیا بازگرداندن `ReturnAction::Continue` خروجی یکسانی را تضمین می‌کند؟**

خیر. فقط اجازه ادامه پردازش را می‌دهد. وضعیت گزارش‌شده همچنان می‌تواند باعث اختلافات داده، قالب‌بندی یا سازگاری شود، بنابراین نوع‌ها و توضیحات هشدارهای جمع‌آوری‌شده را بررسی کنید.

**یک برنامه چگونه می‌تواند عملیات تولیدکننده هشدار را شناسایی کند؟**

برای هر عملیات یک نمونه فراخوانی ایجاد کنید و مرحله تعریف‌شده توسط برنامه را همراه با نوع و توضیح هشدار ذخیره کنید، همان‌طور که در مثال نشان داده شده است.
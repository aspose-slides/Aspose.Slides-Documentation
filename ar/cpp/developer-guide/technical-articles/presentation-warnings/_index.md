---
title: التعامل مع تحذيرات العرض التقديمي في C++
type: docs
weight: 70
url: /ar/cpp/presentation-warnings/
aliases:
- /cpp/الحصول-على-نداءات-التحذير-لإستبدال-الخطوط-في-aspose-slides/
keywords:
- نداء التحذير
- سياسة التحذير
- فقدان البيانات
- فساد المصدر
- مشكلة توافق
- استبدال الخط
- توقيع رقمي
- تحميل العرض التقديمي
- عرض العرض التقديمي
- تحويل العرض التقديمي
- حفظ العرض التقديمي
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "تعلم كيفية جمع وتصنيف واتخاذ إجراءات بشأن التحذيرات أثناء تحميل العروض التقديمية، وعرضها، وتحويلها، وحفظها باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides الإبلاغ عن مشكلات يمكن استردادها أثناء تحميلها أو عرضها أو تحويلها أو حفظ عرض تقديمي. تشمل الأمثلة السجلات المصدرية التالفة، والمحتوى الذي لا يمكن حفظه، واستبدال الخطوط، والقيود في تنسيق الهدف. يتيح رد نداء التحذير للتطبيق تسجيل هذه الحالات وتحديد ما إذا كان يمكن متابعة العملية الحالية.

قم بتنفيذ واجهة [IWarningCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/iwarningcallback/) وفحص الأساليب [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) و[IWarningInfo::get_Description](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/iwarninginfo/get_description/) التي يتم توفيرها عبر [IWarningInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/iwarninginfo/). ارجع [ReturnAction::Continue](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/returnaction/) لقبول التحذير أو `ReturnAction::Abort` لإيقاف العملية.

استخدم [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_warningcallback/) للتحذيرات التي تُثار أثناء فتح عرض تقديمي. ورثت فئات خيارات العرض والتصدير [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveoptions/set_warningcallback/)، والتي تستقبل التحذيرات من عرض الشرائح، والتحويل، والحفظ. نظرًا لأن التحذير نفسه لا يحدد عملية التطبيق، اربط كل نسخة من رد نداء مع مرحلة العملية عندما تُنشئ تقريرًا مركبًا.

## **التحذيرات والاستثناءات**

يصف التحذير حالة يمكن لـ Aspose.Slides استردادها إذا أعاد رد النداء `ReturnAction::Continue`. أما الاستثناء فيعني أن العملية المطلوبة لا يمكن إكمالها بشكل طبيعي؛ لا يتم تحويل الاستثناءات إلى تحذيرات ولا يمكن معالجتها بسياسة التحذير.

إرجاع `ReturnAction::Abort` يطلب من موزع التحذير إنهاء العملية الحالية عبر رفع استثناء. يعتمد نوع الاستثناء العام على العملية وتنسيق العرض التقديمي. على سبيل المثال، قد يُظهر التحميل استثناءً مثل [PptxReadException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxreadexception/) أو [PptReadException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptreadexception/)، بينما قد يُظهر الحفظ أو التصدير استثناءً مثل [PptxException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxexception/). عالج الاستثناء عند حد العملية واستخدم تقرير التحذير لتحديد ما إذا كانت سياسة التطبيق هي التي تسببت في الإنهاء بدلاً من الاعتماد على نوع استثناء واحد أو رسالة محددة. يسجل رد النداء التحذير قبل إرجاع `ReturnAction::Abort`، مما يضمن بقاء السبب متاحًا للتطبيق.

## **فئات التحذير**

توفر تعداد [WarningType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/warningtype/) الفئات التالية:

| نوع التحذير | المعنى | السياسة النموذجية |
| --- | --- | --- |
| `SourceFileCorruption` | يحتوي العرض التقديمي المصدر على تلف قد يجعل المستند المحفوظ بالتنسيق الأصلي غير قابل للاستخدام. | إيقاف. |
| `DataLoss` | قد يكون النص أو المخططات أو الصور أو بيانات أخرى مفقودة بعد التحميل أو الحفظ. | إيقاف. |
| `MajorFormattingLoss` | قد يفقد العرض التقديمي تنسيقًا مهمًا. | إيقاف في وضع التحقق الصارم؛ وإلا سجل واستمر. |
| `MinorFormattingLoss` | قد يحدث فرق تنسيق محدود. | سجل للتشخيص واستمر. |
| `CompatibilityIssue` | قد لا يفتح النتيجة أو يعمل بشكل صحيح في بعض التطبيقات أو الإصدارات القديمة. | سجّل واستمر ما لم يكن التوافق إلزاميًا. |
| `UnexpectedContent` | يحتوي المصدر على محتوى غير مدعوم أو غير معروف قد لا يكون تأثيره معروفًا بعد. | سجّل واستمر، أو عالجه كخطأ في سياسة صارمة. |

يجب أن تقود الفئة قرار السياسة. احفظ وصف التحذير للتشخيص، لكن لا تعتمد على صياغته في منطق التطبيق لأن نص الرسالة قد يختلف بين سيناريوهات التحذير وإصدارات المنتج.

## **جمع وتصنيف التحذيرات**

يستخدم المثال التالي تقريرًا واحدًا على مستوى التطبيق لسلسلة معالجة كاملة. تُعطى نسخة منفصلة من رد النداء علامات للتحذيرات من التحميل، والعرض، وتحويل PDF، وحفظ PPTX. تُعيد السياسة الإيقاف عند حدوث تلف في المصدر أو فقدان بيانات، وتُوقف اختياريًا عند فقدان تنسيق كبير، وتستمر في باقي التحذيرات.

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

عيّن `abortOnMajorFormattingLoss` إلى `false` عندما تكون اختلافات التنسيق الكبيرة مقبولة. لا تزال مشكلات التوافق، وفقدان التنسيق الصغير، والمحتوى غير المتوقع محتفظًا بها في التقرير حتى عندما تستمر العملية. قم بتمديد `WarningPolicy::GetAction` إذا كان التطبيق يجب أن يرفض أيًا من هذه الفئات.

## **سيناريوهات التحذير الشائعة**

يمكن أن تظهر التحذيرات في مراحل مختلفة من سير العمل:

- **التوقيعات الرقمية:** قد ينتج عن عرض تقديمي موقّع تحذير أثناء التحميل بأن توقيعه سيفقد أثناء المعالجة. تُبلغ Aspose.Slides عن هذه الحالة `DataLoss` عبر [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). يتيح رد نداء مرحلة التحميل للتطبيق رفض الملف أو قبول الفقدان المبلَّغ عنه صراحة.
- **استبدال الخطوط:** قد تُستبدل خط غير متوفر أثناء عرض شريحة أو تصديرها. تُبلغ تحذيرات استبدال الخط كـ `DataLoss`، لذا فإن السياسة الصارمة أعلاه تُوقف حتى إذا كان التطبيق يعتبر الاستبدال مقبولًا بصريًا. لملاحظة هذا السلوك، استخدم عرض تقديمي يحتوي على نص بخط غير متوفر في بيئة التشغيل. يحدد وصف التحذير الاستبدال؛ قم بإعداد الخطوط المطلوبة أو [قواعد استبدال الخطوط](/slides/ar/cpp/font-substitution/) قبل إعادة المحاولة.
- **محتوى غير مدعوم أو غير متوقع:** قد يواجه المحمل سجلات أو ميزات لا يتعرف عليها. قد تُستخدم تحذيرات `UnexpectedContent`، أو فئة أكثر شدة عندما يُعرف أن البيانات أو التنسيق متأثران.
- **توافق التنسيق:** قد يتسبب الحفظ إلى تنسيق عرض تقديمي آخر في حذف ميزات أو إنتاج نتيجة تتصرف بشكل مختلف في بعض التطبيقات. على سبيل المثال، يُبلغ حفظ عرض تقديمي يحتوي على أكثر من ثمانية أدلة رسم أفقية أو عمودية إلى PPT قديم عن `CompatibilityIssue`. يمكن لرد نداء مرحلة الحفظ تسجيل الفقدان والاستمرار، أو رفضه إذا كان الحفاظ على جميع الأدلة مطلوبًا.
- **سلوك التحميل:** قد تُنتج خيارات التحميل والسلوكيات القديمة تحذيرات أيضًا. على سبيل المثال، يحدد [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) استخدام سلوك قفل عرض تقديمي قديم كـ `CompatibilityIssue`.

تعتمد التحذيرات على المستند المصدر، التنسيق المستهدف، العملية، وإصدار Aspose.Slides. لا تفترض أن كل ملف ينتج تحذيرًا أو أن كل سيناريو يطابق فئة واحدة فقط.

## **معالجة العمليات المتوقفة بأمان**

عند إرجاع رد النداء `ReturnAction::Abort`، لا تستخدم كائنًا فشل في التحميل ولا تفترض أن إخراج العرض أو الحفظ مكتمل. قد تنتهي العملية بعد إنشاء ملف إخراج ولكن قبل إتمامه.

احفظ النتائج التي تم التحقق منها في مسار منفصل مثل `validated-output.pptx`. استبدل العرض التقديمي الموجود فقط بعد أن تنتهي العملية بنجاح، وتحقق أن تقرير التحذير يوافق سياسة التطبيق، ويمكن فتح الإخراج والتحقق منه. هذا يمنع كتابة ملف مصدر صالح بنتيجة جزئية أو مرفوضة.

التقرير الفارغ للتحذيرات لا يضمن أن كل ميزة في المصدر قد تم الحفاظ عليها. طبّق أي فحوصات محتوى أو بصرية إضافية تطلبها التطبيق. راجع أيضًا [Open Presentations](/slides/ar/cpp/open-presentation/) و[Save Presentations](/slides/ar/cpp/save-presentation/).

## **الأسئلة المتكررة**

**هل يمكن لرد نداء التحذير معالجة كل خطأ في Aspose.Slides؟**

لا. إنه يعالج الحالات القابلة للاسترداد التي تُبلغ كتحذيرات. يجب معالجة الاستثناءات التي تحدث بشكل مستقل عن رد النداء بواسطة التطبيق حول مكالمة التحميل أو العرض أو التحويل أو الحفظ.

**هل يضمن إرجاع `ReturnAction::Continue` مخرجات مطابقة تمامًا؟**

لا. فهو يسمح فقط بالاستمرار في المعالجة. لا تزال الحالة المبلَّغ عنها قد تسبب اختلافات في البيانات أو التنسيق أو التوافق، لذا راجع أنواع التحذيرات المجمعة ووصفها.

**كيف يمكن للتطبيق تحديد العملية التي نتجت عنها التحذير؟**

أنشئ نسخة من رد النداء لكل عملية وخزن مرحلة معرفة بواسطة التطبيق جنبًا إلى جنب مع نوع التحذير ووصفه، كما هو موضح في المثال.
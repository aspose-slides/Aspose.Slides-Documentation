---
title: الحصول على ردود تحذير لاستبدال الخطوط في Aspose.Slides
type: docs
weight: 70
url: /ar/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

تتيح Aspose.Slides لـ C++ الحصول على ردود تحذير لاستبدال الخطوط في حالة عدم توفر الخط المستخدم على جهاز أثناء عملية العرض. تكون ردود التحذير مفيدة عند تصحيح مشاكل الخطوط المفقودة أو غير القابلة للوصول أثناء عملية العرض.

{{% /alert %}} 
## **الحصول على ردود تحذير لاستبدال الخطوط**
تقدم Aspose.Slides لـ C++ طرق API بسيطة للحصول على ردود التحذير أثناء عملية العرض. كل ما تحتاجه هو اتباع الخطوات أدناه لتكوين ردود التحذير على جانبك:

1. إنشاء فئة Callback مخصصة لاستقبال الردود.
1. تعيين ردود التحذير باستخدام فئة [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options).
1. تحميل ملف العرض التقديمي الذي يستخدم خطًا للنص داخله غير متوفر على جهازك المستهدف.
1. إنشاء مصغر الشريحة لرؤية التأثير.

``` cpp
class HandleFontsWarnings : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(SharedPtr<Warnings::IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
        {
            return Warnings::ReturnAction::Continue;
        }

        // 1 - WarningType.DataLoss
        Console::WriteLine(System::ObjectExt::ToString(warning->get_WarningType()));
        // "سيتم استبدال الخط من X إلى Y"
        Console::WriteLine(warning->get_Description());

        return Warnings::ReturnAction::Continue;
    }
};
        
void Run()
{
    System::String dataDir = GetDataPath();

    // تعيين ردود التحذير
    System::SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());

    // إنشاء عرض تقديمي
    System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);

    // إنشاء مصغرات الشرائح
    for (auto slide : presentation->get_Slides())
    {
        System::SharedPtr<IImage> image = slide->GetImage();
    }
}
```
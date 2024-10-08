---
title: الحصول على استدعاءات التحذير لاستبدال الخطوط في Aspose.Slides
type: docs
weight: 120
url: /ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

يجعل Aspose.Slides لـ .NET من الممكن الحصول على استدعاءات تحذير لاستبدال الخطوط في حال عدم توفر الخط المستخدم على الجهاز أثناء عملية التقديم. تعتبر استدعاءات التحذير مفيدة في تصحيح مشكلات الخطوط المفقودة أو غير القابلة للوصول أثناء عملية التقديم.

{{% /alert %}} 
## **الحصول على استدعاءات التحذير لاستبدال الخطوط**
يوفر Aspose.Slides لـ .NET طرق API بسيطة للحصول على استدعاءات التحذير أثناء عملية التقديم. كل ما عليك هو اتباع الخطوات أدناه لتكوين استدعاءات التحذير على جهازك:

1. إنشاء فئة Callback مخصصة لاستقبال الاستدعاءات.
1. تعيين استدعاءات التحذير باستخدام فئة LoadOptions
1. تحميل ملف العرض التقديمي الذي يستخدم خطًا للنص داخله غير متوفر على جهازك المستهدف.
1. توليد الصورة المصغرة للشريحة لرؤية التأثير.

```c#
//تعيين استدعاءات التحذير
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//إنشاء العرض التقديمي
Presentation presentation = new Presentation("1.ppt", lo);

//توليد الصورة المصغرة للشريحة
foreach (ISlide slide in presentation.Slides)
{
    IImage image = slide.GetImage();
}
```

```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "سيتم استبدال الخط من X إلى Y"
        return ReturnAction.Continue;
    }
}
```
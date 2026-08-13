---
title: إدارة مشاريع VBA في العروض التقديمية في .NET
linktitle: العرض التقديمي عبر VBA
type: docs
weight: 250
url: /ar/net/presentation-via-vba/
keywords:
- ماكرو
- VBA
- ماكرو VBA
- إضافة ماكرو
- إزالة ماكرو
- استخراج ماكرو
- إضافة VBA
- إزالة VBA
- استخراج VBA
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides لـ .NET لتبسيط سير عملك."
---
## **مقدمة**

تحتوي مساحة الاسم [Aspose.Slides.Vba](https://reference.aspose.com/slides/ar/net/aspose.slides.vba/) على فئات وواجهات للعمل مع الماكرو وبرمجة VBA.

{{% alert title="Note" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق ملف مختلف (PDF ،HTML ،الخ)، يتجاهل Aspose.Slides جميع الماكروهات (لا يتم نقل الماكروهات إلى الملف الناتج).

عند إضافة ماكروهات إلى عرض تقديمي أو حفظ عرض تقديمي يحتوي على ماكروهات مرة أخرى، يقوم Aspose.Slides ببساطة بكتابة بايتات الماكروهات.

Aspose.Slides **لا** يقوم بتشغيل الماكروهات في العرض التقديمي أبداً.

{{% /alert %}}

## **إضافة ماكرو VBA**

يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/ar/net/aspose.slides.vba/vbaproject/) للسماح لك بإنشاء مشاريع VBA (ومراجع المشاريع) وتعديل الوحدات الموجودة. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/ar/net/aspose.slides.vba/ivbaproject/) لإدارة VBA المدمج في عرض تقديمي.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
1. استخدم المُنشئ [VbaProject](https://reference.aspose.com/slides/ar/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) لإضافة مشروع VBA جديد.
1. إضافة وحدة إلى VbaProject.
1. تعيين شفرة المصدر للوحدة.
1. إضافة مراجع إلى <stdole>.
1. إضافة مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. حفظ العرض التقديمي.

هذا الكود C# يوضح لك كيفية إضافة ماكرو VBA من البداية إلى عرض تقديمي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// إنشاء مثيل من فئة العرض التقديمي
using (Presentation presentation = new Presentation())
{
    // إنشاء مشروع VBA جديد
    presentation.VbaProject = new VbaProject();

    // إضافة وحدة فارغة إلى مشروع VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // تعيين شفرة المصدر للوحدة
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // إنشاء مرجع إلى <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // إنشاء مرجع إلى Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // إضافة مراجع إلى مشروع VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // حفظ العرض التقديمي
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

قد ترغب في تجربة أداة **Aspose** [Macro Remover](https://products.aspose.app/slides/ar/remove-macros)، وهي تطبيق ويب مجاني يُستخدم لإزالة الماكروهات من مستندات PowerPoint وExcel وWord. 

{{% /alert %}} 

## **إزالة ماكرو VBA**
باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/vbaproject/) ضمن فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض التقديمي المعدل.

هذا الكود C# يوضح لك كيفية إزالة ماكرو VBA:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// تحميل العرض التقديمي الذي يحتوي على الماكرو
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // الوصول إلى وحدة Vba وإزالتها
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // حفظ العرض التقديمي
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **استخراج ماكرو VBA**
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. التكرار عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكروهات.

هذا الكود C# يوضح لك كيفية استخراج ماكرو VBA من عرض تقديمي يحتوي على ماكروهات:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // تحميل العرض التقديمي الذي يحتوي على الماكرو
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **التحقق مما إذا كان مشروع VBA محمَّى بكلمة مرور**

باستخدام خاصية [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/ar/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [مشروع VBA](https://reference.aspose.com/slides/ar/net/aspose.slides.vba/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محمَّى بكلمة مرور لعرض خصائصه.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **الأسئلة المتكررة**

### ماذا يحدث للماكروهات إذا حفظت العرض التقديمي كملف PPTX؟

سيتم إزالة الماكروهات لأن PPTX لا يدعم VBA. للحفاظ على الماكروهات، اختر PPTM أو PPSM أو POTM.

### هل يمكن لـ Aspose.Slides تشغيل الماكروهات داخل عرض تقديمي، مثلاً لتحديث البيانات؟

لا. المكتبة لا تقوم بتنفيذ شفرة VBA أبداً؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

### هل يدعم العمل مع عناصر تحكم ActiveX المرتبطة بشفرة VBA؟

نعم، يمكنك الوصول إلى عناصر تحكم ActiveX الحالية، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكروهات مع عناصر تحكم ActiveX.
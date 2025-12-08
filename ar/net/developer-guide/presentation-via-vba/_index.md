---
title: عرض تقديمي عبر VBA
type: docs
weight: 250
url: /ar/net/presentation-via-vba/
keywords: "ماكرو, ماكروهات, VBA, ماكرو VBA, إضافة ماكرو, إزالة ماكرو, إضافة VBA, إزالة VBA, استخراج ماكرو, استخراج VBA, ماكرو PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة، إزالة، واستخراج ماكروات VBA في عروض PowerPoint باستخدام C# أو .NET"
---

تحتوي مساحة الاسم [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) على الفئات والواجهات للعمل مع الماكرو وكود VBA.

{{% alert title="Note" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، يتجاهل Aspose.Slides جميع الماكرو (الماكرو لا يتم نقلها إلى الملف الناتج).

عند إضافة ماكرو إلى عرض تقديمي أو حفظ عرض تقديمي يحتوي على ماكرو مرة أخرى، يقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالماكرو.

Aspose.Slides **never** ينفّذ الماكرو في العرض التقديمي.

{{% /alert %}}

## **إضافة ماكرو VBA**

يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) للسماح بإنشاء مشاريع VBA (ومراجع المشروع) وتعديل الوحدات الموجودة. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) لإدارة VBA المدمج في العرض التقديمي.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) لإضافة مشروع VBA جديد.
3. إضافة وحدة إلى VbaProject.
4. تحديد شفرة المصدر للوحدة.
5. إضافة مراجع إلى <stdole>.
6. إضافة مراجع إلى **Microsoft Office**.
7. ربط المراجع بمشروع VBA.
8. حفظ العرض التقديمي.

هذا الكود C# يوضح كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:
```c#
    // إنشاء كائن من فئة العرض التقديمي
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

    // إضافة المراجع إلى مشروع VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // حفظ العرض التقديمي
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


{{% alert color="primary" %}} 

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكرو من مستندات PowerPoint وExcel وWord. 

{{% /alert %}} 

## **إزالة ماكرو VBA**

باستخدام الخاصية [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) ضمن فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. الوصول إلى وحدة الماكرو وإزالتها.
3. حفظ العرض التقديمي المعدّل.

هذا الكود C# يوضح كيفية إزالة ماكرو VBA:
```c#
    // يقوم بتحميل العرض التقديمي الذي يحتوي على الماكرو
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // يقوم بالوصول إلى وحدة VBA وإزالتها
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // يحفظ العرض التقديمي
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **استخراج ماكرو VBA**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. التنقل عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكرو.

هذا الكود C# يوضح كيفية استخراج ماكرو VBA من عرض تقديمي يحتوي على ماكرو:
```c#
    // يحمل العرض التقديمي الذي يحتوي على الماكرو
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // يتحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```


## **التحقق مما إذا كان مشروع VBA محمياً بكلمة مرور**

باستخدام الخاصية [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [مشروع VBA](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محمياً بكلمة مرور لعرض خصائصه.
```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```


## **الأسئلة الشائعة**

**ماذا يحدث للماكرو إذا حفظت العرض التقديمي كملف PPTX؟**

سيتم إزالة الماكرو لأن تنسيق PPTX لا يدعم VBA. للحفاظ على الماكرو، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكرو داخل العرض التقديمي، على سبيل المثال لتحديث البيانات؟**

لا. المكتبة لا تنفّذ كود VBA أبداً؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يتم دعم العمل مع عناصر التحكم ActiveX المرتبطة بكود VBA؟**

نعم، يمكنك الوصول إلى عناصر التحكم ActiveX الحالية، تعديل خصائصها، وإزالتها. هذا مفيد عندما يتفاعل الماكرو مع عناصر التحكم ActiveX.
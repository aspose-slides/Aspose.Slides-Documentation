---
title: العرض عبر VBA
type: docs
weight: 250
url: /net/presentation-via-vba/
keywords: "ماكرو، ماكرون، VBA، ماكرو VBA، إضافة ماكرو، إزالة ماكرو، إضافة VBA، إزالة VBA، استخراج ماكرو، استخراج VBA، ماكرو PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة وإزالة واستخراج ماكرو VBA في عروض PowerPoint باستخدام C# أو .NET"
---

تحتوي مساحة الاسم [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) على فئات وواجهات للعمل مع الماكرو وكود VBA.

{{% alert title="ملحوظة" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكرو (لا يتم نقل الماكرو إلى الملف الناتج).

عند إضافة الماكرو إلى عرض تقديمي أو إعادة حفظ عرض تقديمي يحتوي على ماكرو، تقوم Aspose.Slides ببساطة بكتابة بايتات الماكرو.

Aspose.Slides **لا** تقوم أبدًا بتشغيل الماكرو في عرض تقديمي.

{{% /alert %}}

## **إضافة ماكرو VBA**

توفر Aspose.Slides فئة [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) للسماح لك بإنشاء مشاريع VBA (ومراجع المشروع) وتحرير الوحدات الموجودة. يمكنك استخدام واجهة [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) لإدارة VBA المضمنة في عرض تقديمي.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى VbaProject.
1. تعيين كود المصدر للوحدة.
1. إضافة مراجع إلى <stdole>.
1. إضافة مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. حفظ العرض التقديمي.

يوضح هذا الكود في C# كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:

```c#
    // إنشاء مثيل من فئة العرض التقديمي
using (Presentation presentation = new Presentation())
{
    // إنشاء مشروع VBA جديد
    presentation.VbaProject = new VbaProject();

    // إضافة وحدة فارغة إلى مشروع VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // تعيين كود المصدر للوحدة
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
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على **Aspose** [إزالة الماكرو](https://products.aspose.app/slides/remove-macros)، وهي تطبيق ويب مجاني يستخدم لإزالة الماكرو من مستندات PowerPoint وExcel وWord. 

{{% /alert %}} 

## **إزالة ماكرو VBA**
باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) تحت فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض التقديمي المعدل.

يوضح هذا الكود في C# كيفية إزالة ماكرو VBA:

```c#
    // تحميل العرض التقديمي الذي يحتوي على الماكرو
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // الوصول إلى وحدة Vba وإزالتها 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // حفظ العرض التقديمي
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **استخراج ماكرو VBA**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. حلقة عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكرو.

يوضح هذا الكود في C# كيفية استخراج ماكرو VBA من عرض تقديمي يحتوي على ماكرو:

```c#
    // تحميل العرض التقديمي الذي يحتوي على الماكرو
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // التحقق مما إذا كان العرض يحتوي على مشروع VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام خاصية [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/)، يمكنك التحقق مما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض يحتوي على [مشروع VBA](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائص المشروع.

يوضح هذا الكود في C# العملية:

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
    if (pres.VbaProject == null) // التحقق مما إذا كان العرض يحتوي على مشروع VBA
        return;

    if (pres.VbaProject.IsPasswordProtected)
    {
        Console.WriteLine("مشروع VBA '" + pres.VbaProject.Name +
                            "' محمي بكلمة مرور لعرض خصائص المشروع.");
    }
}
```
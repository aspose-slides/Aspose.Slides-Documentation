---
title: إدارة مشاريع VBA في العروض التقديمية باستخدام C++
linktitle: العرض التقديمي عبر VBA
type: docs
weight: 250
url: /ar/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint و OpenDocument عبر VBA باستخدام Aspose.Slides للغة C++ لتبسيط سير عملك."
---

تحتوي مساحة الأسماء [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) على فئات وواجهات للعمل مع الماكرو وكود VBA.

{{% alert title="Note" color="warning" %}} 
عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، يتجاهل Aspose.Slides جميع الماكرو (لا يتم نقل الماكرو إلى الملف الناتج).

عند إضافة ماكرو إلى عرض تقديمي أو إعادة حفظ عرض تقديمي يحتوي على ماكرو، يقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالماكرو.

Aspose.Slides **أبدًا** لا يشغِّل الماكرو في عرض تقديمي.
{{% /alert %}}

## **إضافة ماكرو VBA**
يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) لتتيح لك إنشاء مشاريع VBA (ومرجعيات المشروع) وتحرير الوحدات الحالية. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) لإدارة VBA المدمج في عرض تقديمي.

1. إنشاء كائن جديد من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى VbaProject.
1. حدد شفرة المصدر للوحدة.
1. أضف مراجع إلى <stdole>.
1. أضف مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. احفظ العرض التقديمي.

يظهر لك هذا الكود C++ كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي: 
```c++
// مسار دليل المستندات.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// إنشاء كائن من فئة العرض التقديمي
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// إنشاء مشروع VBA جديد
presentation->set_VbaProject(MakeObject<VbaProject>());

// إضافة وحدة فارغة إلى مشروع VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// تعيين شفرة المصدر للوحدة
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// إنشاء مرجع إلى <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// إنشاء مرجع إلى Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// إضافة مراجع إلى مشروع VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// حفظ العرض التقديمي
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


{{% alert color="primary" %}} 
قد ترغب في الاطلاع على **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكرو من مستندات PowerPoint وExcel وWord. 
{{% /alert %}} 

## **إزالة ماكرو VBA**
باستخدام الخاصية [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) ضمن الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)، يمكنك إزالة ماكرو VBA.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة Macro وإزالتها.
1. احفظ العرض التقديمي المعدل.

يُظهر لك هذا الكود C++ كيفية إزالة ماكرو VBA: 
```c++
// مسار دليل المستندات.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// يحمل العرض التقديمي الذي يحتوي على الماكرو
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// يصل إلى وحدة VBA ويزيلها
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// يحفظ العرض التقديمي
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


## **استخراج ماكرو VBA**
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. التجول عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكرو.

يُظهر لك هذا الكود C++ كيفية استخراج ماكرو VBA من عرض تقديمي يحتوي على ماكرو: 
```c++
	// مسار دليل المستندات.
	const String templatePath = u"../templates/VBA.pptm";

	// يحمل العرض التقديمي الذي يحتوي على الماكرو
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // يتحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```


## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**
باستخدام الخاصية [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [VBA project](https://reference.aspose.com/slides/cpp/aspose.slides.vba/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.
```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```


## **FAQ**

**ماذا يحدث للماكرو إذا حفظت العرض التقديمي كـ PPTX؟**
سيتم إزالة الماكرو لأن صيغة PPTX لا تدعم VBA. للحفاظ على الماكرو، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكرو داخل عرض تقديمي، على سبيل المثال لتحديث البيانات؟**
لا. لا تقوم المكتبة بتشغيل كود VBA أبداً؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يدعم العمل مع عناصر تحكم ActiveX المرتبطة بكود VBA؟**
نعم، يمكنك الوصول إلى عناصر تحكم [ActiveX controls](/slides/ar/cpp/activex/) الموجودة، تعديل خصائصها، وإزالتها. هذا مفيد عندما يتفاعل الماكرو مع ActiveX.
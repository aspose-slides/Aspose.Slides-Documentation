---
title: العرض عبر VBA
type: docs
weight: 250
url: /ar/cpp/presentation-via-vba/
keywords: "ماكرو، ماكروس، VBA، ماكرو VBA، إضافة ماكرو، إزالة ماكرو، إضافة VBA، إزالة VBA، استخراج ماكرو، استخراج VBA، ماكرو PowerPoint، عرض PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "إضافة وإزالة واستخراج ماكرو VBA في عروض PowerPoint في C++"
---

تحتوي مساحة أسماء [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) على فئات وواجهات للعمل مع الماكروز وكود VBA.

{{% alert title="ملاحظة" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكروز إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكروز (لا يتم نقل الماكروز إلى الملف الناتج).

عندما تضيف الماكروز إلى عرض تقديمي أو تعيد حفظ عرض تقديمي يحتوي على ماكروز، تقوم Aspose.Slides ببساطة بكتابة بايتات الماكروز.

تقوم Aspose.Slides **أبدًا** بتشغيل الماكروز في عرض تقديمي.

{{% /alert %}}

## **إضافة ماكروز VBA**

توفر Aspose.Slides فئة [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) للسماح لك بإنشاء مشاريع VBA (ومراجع المشروع) وتحرير الوحدات الموجودة. يمكنك استخدام واجهة [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) لإدارة VBA المدمجة في عرض تقديمي.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. استخدام مُنشئ [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) لإضافة مشروع VBA جديد.
1. إضافة وحدة إلى VbaProject.
1. تعيين كود المصدر للوحدة.
1. إضافة مراجع إلى <stdole>.
1. إضافة مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. حفظ العرض التقديمي.

يوضح هذا الكود C++ كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي: 

```c++

// مسار مجلد الوثائق.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// إنشاء مثيل من فئة العرض التقديمي
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// إنشاء مشروع VBA جديد
presentation->set_VbaProject(MakeObject<VbaProject>());

// إضافة وحدة فارغة إلى مشروع VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// تعيين كود المصدر للوحدة
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

قد ترغب في التحقق من **Aspose** [إزالة الماكروز](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكروز من PowerPoint وExcel وWord.

{{% /alert %}} 

## **إزالة ماكروز VBA**

باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) تحت فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)، يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض التقديمي المعدل.

يوضح هذا الكود C++ كيفية إزالة ماكرو VBA: 

```c++

// مسار مجلد الوثائق.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// تحميل العرض التقديمي الذي يحتوي على الماكرو
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// الوصول إلى وحدة VBA وإزالتها 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// حفظ العرض التقديمي
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);


```

## **استخراج ماكروز VBA**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. قم بالمرور عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكروز.

يوضح هذا الكود C++ كيفية استخراج ماكروز VBA من عرض تقديمي يحتوي على الماكروز: 

```c++

	// مسار مجلد الوثائق.
	const String templatePath = u"../templates/VBA.pptm";

	// تحميل العرض التقديمي الذي يحتوي على الماكرو
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA
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
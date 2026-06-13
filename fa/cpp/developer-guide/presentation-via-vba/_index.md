---
title: مدیریت پروژه‌های VBA در ارائه‌ها با استفاده از C++
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/cpp/presentation-via-vba/
keywords:
- ماکرو
- VBA
- ماکرو VBA
- افزودن ماکرو
- حذف ماکرو
- استخراج ماکرو
- افزودن VBA
- حذف VBA
- استخراج VBA
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را از طریق VBA با Aspose.Slides برای C++ تولید و دستکاری کنید تا جریان کار خود را بهبود بخشید."
---
## **مقدمه**

[Aspose.Slides.Vba](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.vba/) فضای نام شامل کلاس‌ها و اینترفیس‌هایی برای کار با ماکروها و کد VBA است.

{{% alert title="Note" color="warning" %}} 

هنگامی که یک ارائه حاوی ماکروها را به قالب فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل نتیجه منتقل نمی‌شوند).

هنگامی که ماکروها را به یک ارائه اضافه می‌کنید یا ارائه‌ای حاوی ماکروها را دوباره ذخیره می‌نمایید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.

{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.vba.vba_project) را فراهم می‌کند تا بتوانید پروژه‌های VBA (و مراجع پروژه) ایجاد کرده و ماژول‌های موجود را ویرایش کنید. می‌توانید از اینترفیس [IVbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.vba.i_vba_project/) برای مدیریت VBA جاسازی‌شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. از سازندهٔ [VbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) برای افزودن یک پروژهٔ VBA جدید استفاده کنید.  
3. یک ماژول به VbaProject اضافه کنید.  
4. کد منبع ماژول را تنظیم کنید.  
5. ارجاعات به <stdole> را اضافه کنید.  
6. ارجاعات به **Microsoft Office** را اضافه کنید.  
7. ارجاعات را با پروژهٔ VBA مرتبط کنید.  
8. ارائه را ذخیره کنید.

این کد C++ نشان می‌دهد که چگونه یک ماکرو VBA را از ابتدا به یک ارائه اضافه کنید: 

```c++
// مسیر به پوشه اسناد.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// یک نمونه از کلاس Presentation ایجاد می‌کند
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// یک پروژه VBA جدید ایجاد می‌کند
presentation->set_VbaProject(MakeObject<VbaProject>());

// یک ماژول خالی به پروژه VBA اضافه می‌کند
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// کد منبع ماژول را تنظیم می‌کند
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// یک مرجع به <stdole> ایجاد می‌کند
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// یک مرجع به Office ایجاد می‌کند
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// مراجع را به پروژه VBA اضافه می‌کند
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// ارائه را ذخیره می‌کند
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید، که یک برنامهٔ وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word است. 

{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از ویژگی [VbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) زیر کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.  
2. به ماژول Macro دسترسی پیدا کنید و آن را حذف کنید.  
3. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد C++ نشان می‌دهد که چگونه یک ماکرو VBA را حذف کنید: 

```c++
// مسیر به پوشه اسناد.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// ارائه حاوی ماکرو را بارگذاری می‌کند
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// به ماژول Vba دسترسی پیدا می‌کند و آن را حذف می‌کند 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// ارائه را ذخیره می‌کند
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.  
2. بررسی کنید که آیا ارائه حاوی پروژهٔ VBA است یا نه.  
3. در تمام ماژول‌های موجود در پروژهٔ VBA حلقه بزنید تا ماکروها را مشاهده کنید.

این کد C++ نشان می‌دهد که چگونه ماکروهای VBA را از یک ارائه حاوی ماکرو استخراج کنید: 

```c++

	// مسیر به پوشه اسناد.
	const String templatePath = u"../templates/VBA.pptm";

	// ارائه حاوی ماکرو را بارگذاری می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // بررسی می‌کند که آیا ارائه حاوی پروژه VBA است
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

## **بررسی اینکه آیا یک پروژهٔ VBA رمزعبور دارد یا نه**

با استفاده از ویژگی [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/fa/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) می‌توانید تعیین کنید که آیا ویژگی‌های یک پروژه با رمز عبور محافظت می‌شوند یا نه.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید و یک ارائه که شامل ماکرو است، بارگذاری کنید.  
2. بررسی کنید که آیا ارائه حاوی [VBA project](https://reference.aspose.com/slides/fa/cpp/aspose.slides.vba/vbaproject/) است یا نه.  
3. بررسی کنید که آیا پروژهٔ VBA با رمز عبور محافظت می‌شود تا ویژگی‌های آن را مشاهده کنید.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // بررسی می‌کند که آیا ارائه حاوی پروژه VBA است.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **سوالات متداول**

**What happens to macros if I save the presentation as PPTX?**  
ماکروها حذف خواهند شد زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**Can Aspose.Slides run macros inside a presentation to, for example, refresh data?**  
خیر. کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرا فقط در PowerPoint با تنظیمات امنیتی مناسب امکان‌پذیر است.

**Is working with ActiveX controls linked to VBA code supported?**  
بله، می‌توانید به کنترل‌های [ActiveX controls](/slides/fa/cpp/activex/) موجود دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و آن‌ها را حذف کنید. این برای مواقعی مفید است که ماکروها با ActiveX تعامل دارند.
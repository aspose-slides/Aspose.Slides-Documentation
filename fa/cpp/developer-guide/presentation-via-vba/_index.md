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
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را با استفاده از VBA و Aspose.Slides برای C++ تولید و دستکاری کنید تا جریان کاری خود را بهبود بخشید."
---
## **مقدمه**

فاصله‌نامی [Aspose.Slides.Vba](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.vba/) شامل کلاس‌ها و رابط‌هایی برای کار با ماکروها و کد VBA است.

{{% alert title="Note" color="warning" %}} 
هنگامی که یک ارائه شامل ماکروها را به قالب فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل خروجی منتقل نمی‌شوند).

هنگامی که ماکروها را به یک ارائه اضافه می‌کنید یا ارائه‌ای حاوی ماکروها را مجدداً ذخیره می‌کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.
{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.vba.vba_project) را برای ایجاد پروژه‌های VBA (و ارجاع‌های پروژه) و ویرایش ماژول‌های موجود فراهم می‌کند. می‌توانید از رابط [IVbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.vba.i_vba_project/) برای مدیریت VBA تعبیه‌شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
1. از سازنده [VbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) برای افزودن یک پروژه VBA جدید استفاده کنید.
1. یک ماژول به VbaProject اضافه کنید.
1. کد منبع ماژول را تنظیم کنید.
1. ارجاع‌ها به <stdole> را اضافه کنید.
1. ارجاع‌ها به **Microsoft Office** را اضافه کنید.
1. این ارجاع‌ها را به پروژه VBA مرتبط کنید.
1. ارائه را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک ماکرو VBA را از ابتدا به یک ارائه اضافه کنید:

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// مسیر به پوشهٔ اسناد.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// یک نمونه از کلاس ارائه ایجاد می‌کند
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// یک پروژه VBA جدید ایجاد می‌کند
presentation->set_VbaProject(MakeObject<VbaProject>());

// یک ماژول خالی به پروژه VBA اضافه می‌کند
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// کد منبع ماژول را تنظیم می‌کند
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// یک ارجاع به <stdole> ایجاد می‌کند
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// یک ارجاع به Office ایجاد می‌کند
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// ارجاع‌ها را به پروژه VBA اضافه می‌کند
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// ارائه را ذخیره می‌کند
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 
ممکن است مایل باشید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید؛ این یک برنامه وب رایگان است که برای حذف ماکروها از اسناد PowerPoint، Excel و Word استفاده می‌شود. 
{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از ویژگی [VbaProject](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) تحت کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کرده و ارائه حاوی ماکرو را بارگیری کنید.
1. به ماژول Macro دسترسی پیدا کنید و آن را حذف کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک ماکرو VBA را حذف کنید:

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// مسیر به پوشه اسناد.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// ارائه حاوی ماکرو را بارگیری می‌کند
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// به ماژول Vba دسترسی پیدا می‌کند و آن را حذف می‌کند
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// ارائه را ذخیره می‌کند
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کرده و ارائه حاوی ماکرو را بارگیری کنید.
2. بررسی کنید آیا ارائه شامل یک پروژه VBA است یا نه.
3. روی تمام ماژول‌های موجود در پروژه VBA حلقه بزنید تا ماکروها را مشاهده کنید.

این کد C++ نشان می‌دهد چگونه ماکروهای VBA را از یک ارائه حاوی ماکرو استخراج کنید:

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// مسیر به پوشهٔ اسناد.
	const String templatePath = u"../templates/VBA.pptm";

	// ارائه حاوی ماکرو را بارگیری می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // بررسی می‌کند آیا ارائه شامل پروژه VBA است
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

## **بررسی اینکه آیا یک پروژه VBA با رمز عبور محافظت شده است**

با استفاده از ویژگی [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/fa/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) می‌توانید تعیین کنید آیا ویژگی‌های پروژه با رمز عبور محافظت شده‌اند یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کرده و ارائه‌ای که شامل ماکرو است را بارگیری کنید.
2. بررسی کنید آیا ارائه شامل یک [پروژه VBA](https://reference.aspose.com/slides/fa/cpp/aspose.slides.vba/vbaproject/) است یا نه.
3. بررسی کنید آیا پروژه VBA با رمز عبور محافظت شده است تا ویژگی‌های آن را مشاهده کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // بررسی اینکه آیا ارائه شامل پروژه VBA است.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **سوالات متداول**

### چه اتفاقی برای ماکروها می‌افتد اگر ارائه را به صورت PPTX ذخیره کنم؟

ماکروها حذف می‌شوند زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

### آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، به‌عنوان مثال برای به‌روزرسانی داده‌ها؟

نه. این کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرای آن فقط در PowerPoint با تنظیمات امنیتی مناسب ممکن است.

### آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟

بله، می‌توانید به کنترل‌های ActiveX موجود دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و آن‌ها را حذف کنید. این ویژگی زمانی مفید است که ماکروها با ActiveX تعامل داشته باشند.
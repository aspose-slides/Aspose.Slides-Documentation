---
title: مدیریت پروژه‌های VBA در ارائه‌ها در .NET
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/net/presentation-via-vba/
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
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید که چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را از طریق VBA با Aspose.Slides برای .NET تولید و دستکاری کنید تا جریان کاری خود را بهینه کنید."
---
## **معرفی**

فضای‌نامی [Aspose.Slides.Vba](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/) شامل کلاس‌ها و اینترفیس‌هایی برای کار با ماکروها و کد VBA است.

{{% alert title="Note" color="warning" %}} 
زمانی که یک ارائه حاوی ماکروها را به فرمت فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل نتیجه منتقل نمی‌شوند).

وقتی ماکروها را به یک ارائه اضافه می‌کنید یا ارائه‌ای که حاوی ماکروهاست را دوباره ذخیره می‌کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.
{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/vbaproject/) را ارائه می‌دهد تا به شما امکان ایجاد پروژه‌های VBA (و ارجاعات پروژه) و ویرایش ماژول‌های موجود را بدهد. می‌توانید از اینترفیس [IVbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/ivbaproject/) برای مدیریت VBA داخل یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. از سازندهٔ [VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) برای افزودن یک پروژه VBA جدید استفاده کنید.
1. یک ماژول به VbaProject اضافه کنید.
1. کد منبع ماژول را تنظیم کنید.
1. ارجاعات به <stdole> را اضافه کنید.
1. ارجاعات به **Microsoft Office** را اضافه کنید.
1. ارجاعات را به پروژه VBA پیوست کنید.
1. ارائه را ذخیره کنید.

این کد C# نشان می‌دهد که چگونه یک ماکرو VBA را از ابتدا به یک ارائه اضافه کنید:

```c#
    // یک نمونه از کلاس Presentation ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // یک پروژه VBA جدید ایجاد می‌کند
    presentation.VbaProject = new VbaProject();

    // یک ماژول خالی به پروژه VBA اضافه می‌کند
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // کد منبع ماژول را تنظیم می‌کند
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // یک ارجاع به <stdole> ایجاد می‌کند
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // یک ارجاع به Office ایجاد می‌کند
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // ارجاعات به پروژه VBA اضافه می‌کند
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // ارائه را ذخیره می‌کند
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 
ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید؛ این یک برنامه وب رایگان است که برای حذف ماکروها از اسناد PowerPoint، Excel و Word استفاده می‌شود. 
{{% /alert %}} 

## **حذف ماکروهای VBA**
با استفاده از ویژگی [VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/vbaproject/) تحت کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
1. به ماژول Macro دسترسی پیدا کنید و آن را حذف کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد C# نشان می‌دهد که چگونه یک ماکرو VBA را حذف کنید:

```c#
    // ارائه حاوی ماکرو را بارگذاری می‌کند
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // به ماژول Vba دسترسی پیدا می‌کند و آن را حذف می‌کند 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // ارائه را ذخیره می‌کند
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **استخراج ماکروهای VBA**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
2. بررسی کنید که آیا ارائه حاوی یک پروژه VBA است یا خیر.
3. از طریق تمام ماژول‌های موجود در پروژه VBA حلقه بزنید تا ماکروها را مشاهده کنید.

این کد C# نشان می‌دهد که چگونه ماکروهای VBA را از یک ارائه حاوی ماکرو استخراج کنید:

```c#
    // ارائه حاوی ماکرو را بارگذاری می‌کند
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // بررسی می‌کند که آیا ارائه شامل پروژه VBA است یا خیر
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **بررسی اینکه آیا یک پروژه VBA با رمز عبور محافظت شده است**
با استفاده از خاصیت [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) می‌توانید تعیین کنید که آیا ویژگی‌های یک پروژه با رمز عبور محافظت شده‌اند یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که حاوی ماکرو است را بارگذاری کنید.
2. بررسی کنید که آیا ارائه شامل یک [VBA project](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/vbaproject/) است یا نه.
3. بررسی کنید که آیا پروژه VBA با رمز عبور محافظت شده است تا ویژگی‌های آن را مشاهده کنید.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // بررسی می‌کند که آیا ارائه شامل پروژه VBA است یا خیر.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **سؤالات متداول**

**اگر ارائه را به صورت PPTX ذخیره کنم چه اتفاقی برای ماکروها می‌افتد؟**  
ماکروها حذف می‌شوند زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگه‌داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، مثلاً برای به‌روزرسانی داده‌ها؟**  
خیر. این کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرای کد فقط در داخل PowerPoint با تنظیمات امنیتی مناسب امکان‌پذیر است.

**آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟**  
بله، می‌توانید به [ActiveX controls](/slides/fa/net/activex/) موجود دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و حذف کنید. این برای زمانی که ماکروها با ActiveX تعامل دارند مفید است.
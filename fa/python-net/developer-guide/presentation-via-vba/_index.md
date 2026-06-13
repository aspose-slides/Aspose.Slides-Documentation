---
title: "مدیریت پروژه‌های VBA در ارائه‌ها با پایتون"
linktitle: "ارائه از طریق VBA"
type: docs
weight: 250
url: /fa/python-net/presentation-via-vba/
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
- پایتون
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را از طریق VBA با Aspose.Slides برای پایتون از طریق .NET تولید و دستکاری کنید تا گردش کار خود را بهینه کنید."
---
## **مرور کلی**

این مقاله قابلیت‌های کلیدی Aspose.Slides برای Python از طریق .NET را برای کار با ماکروها در ارائه‌های PowerPoint بررسی می‌کند. این کتابخانه ابزارهای راحتی برای اضافه کردن، حذف و استخراج ماکروها فراهم می‌کند که به شما امکان خودکارسازی ایجاد و ویرایش ارائه‌ها را می‌دهد.

- سرعت بخشیدن به توسعه ارائه‌ها — خودکارسازی کارهای روتین زمان مورد نیاز برای آماده‌سازی مواد را کاهش می‌دهد.
- تضمین انعطاف‌پذیری — قابلیت مدیریت ماکروها به شما اجازه می‌دهد ارائه‌ها را برای وظایف و سناریوهای خاص سفارشی کنید.
- ادغام داده‌ها — ادغام ساده با منابع داده خارجی به‌روز نگه داشتن محتوای اسلایدها را آسان می‌کند.
- ساده‌سازی نگهداری — مدیریت متمرکز ماکروها اعمال تغییرات و به‌روزرسانی ارائه‌ها را آسان‌تر می‌کند.

مقاله ادامه دارد تا مثال‌های عملی استفاده از Aspose.Slides برای کار موثر با ماکروها در PowerPoint را ارائه دهد.

فضای نام [aspose.slides.vba](https://reference.aspose.com/slides/fa/python-net/aspose.slides.vba/) کلاس‌هایی برای کار با ماکروها و کد VBA فراهم می‌کند.

{{% alert title="Note" color="warning" %}}
هنگامی که یک ارائه شامل ماکروها را به قالب دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides ماکروها را نادیده می‌گیرد—آنها به فایل خروجی منتقل نمی‌شوند.

وقتی ماکروها را به یک ارائه اضافه می‌کنید یا ارائه‌ای که شامل ماکروها است را دوباره ذخیره می‌کنید، Aspose.Slides بایت‌های ماکرو را به همان صورت می‌نویسد.

Aspose.Slides **هیچ‌وقت** ماکروها را در یک ارائه اجرا نمی‌کند.
{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/python-net/aspose.slides.vba/vbaproject/) را برای ایجاد پروژه‌های VBA (و ارجاعات پروژه) و ویرایش ماژول‌های موجود فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. از سازنده [VbaProject](https://reference.aspose.com/slides/fa/python-net/aspose.slides.vba/vbaproject/#constructors) برای اضافه کردن یک پروژه VBA جدید استفاده کنید.  
1. یک ماژول به پروژه VBA اضافه کنید.  
1. کد منبع ماژول را تنظیم کنید.  
1. یک ارجاع به `<stdole>` اضافه کنید.  
1. یک ارجاع به **Microsoft Office** اضافه کنید.  
1. ارجاعات را با پروژه VBA مرتبط کنید.  
1. ارائه را ذخیره کنید.

کد Python زیر نشان می‌دهد چگونه از ابتدا یک ماکرو VBA به ارائه اضافه شود:

```python
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation.
with slides.Presentation() as presentation:

    # ایجاد یک پروژه VBA جدید.
    presentation.vba_project = slides.vba.VbaProject()

    # افزودن یک ماژول خالی به پروژه VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # تنظیم کد منبع ماژول.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # ایجاد یک ارجاع به <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # ایجاد یک ارجاع به Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # افزودن ارجاعات به پروژه VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # ذخیرهٔ ارائه.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را امتحان کنید؛ یک برنامه وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word.
{{% /alert %}}

## **حذف ماکروهای VBA**

با استفاده از ویژگی [vba_project](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/vba_project/) کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل ماکرو است را بارگذاری کنید.  
1. به ماژول ماکرو دسترسی پیدا کنید و آن را حذف کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.

کد Python زیر نشان می‌دهد چگونه یک ماکرو VBA حذف شود:

```python
import aspose.slides as slides

# بارگذاری ارائه‌ای که شامل ماکرو است.
with slides.Presentation("VBA.pptm") as presentation:
    
    # دسترسی به ماژول VBA.
    vba_module = presentation.vba_project.modules[0]

    # حذف ماژول VBA.
    presentation.vba_project.modules.remove(vba_module)

    # ذخیرهٔ ارائه.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **استخراج ماکروهای VBA**

با استفاده از ویژگی `modules` در کلاس [VbaProject](https://reference.aspose.com/slides/fa/python-net/aspose.slides.vba/vbaproject/) می‌توانید به همه ماژول‌های یک پروژه VBA دسترسی پیدا کنید. کلاس [VbaModule](https://reference.aspose.com/slides/fa/python-net/aspose.slides.vba/vbamodule/) می‌تواند برای استخراج ویژگی‌های ماژول مانند نام و کد استفاده شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل ماکرو است را بارگذاری کنید.  
1. بررسی کنید که آیا ارائه شامل پروژه VBA است یا نه.  
1. در تمام ماژول‌های پروژه VBA حلقه بزنید تا ماکروها را مشاهده کنید.

کد Python زیر نشان می‌دهد چگونه ماکروهای VBA از یک ارائه استخراج شوند:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # بررسی اینکه آیا ارائه شامل پروژه VBA است.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **بررسی اینکه آیا پروژه VBA دارای رمز عبور است یا خیر**

با استفاده از ویژگی [VbaProject.is_password_protected](https://reference.aspose.com/slides/fa/python-net/aspose.slides.vba/vbaproject/is_password_protected/) می‌توانید تعیین کنید که آیا ویژگی‌های پروژه با رمز عبور محافظت شده‌اند یا نه.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و یک ارائه شامل ماکرو را بارگذاری کنید.  
1. بررسی کنید که آیا ارائه شامل یک [VBA project](https://reference.aspose.com/slides/fa/python-net/aspose.slides.vba/vbaproject/) است یا نه.  
1. بررسی کنید که آیا پروژه VBA با رمز عبور محافظت شده است تا ویژگی‌های آن را مشاهده کنید.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # بررسی اینکه آیا ارائه شامل پروژه VBA است.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**اگر ارائه را به صورت PPTX ذخیره کنم، چه اتفاقی برای ماکروها می‌افتد؟**

ماکروها حذف می‌شوند چون PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، برای مثال برای تازه‌سازی داده‌ها؟**

خیر. کتابخانه هیچ‌وقت کد VBA را اجرا نمی‌کند؛ اجرا فقط در داخل PowerPoint با تنظیمات امنیتی مناسب امکان‌پذیر است.

**آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟**

بله، می‌توانید به [ActiveX controls](/slides/fa/python-net/activex/) موجود دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و حذف کنید. این کار وقتی مفید است که ماکروها با ActiveX تعامل داشته باشند.
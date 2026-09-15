---
title: مدیریت پروژه‌های VBA در ارائه‌ها با استفاده از پایتون
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/python-java/presentation-via-vba/
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
- Python
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را با استفاده از VBA و Aspose.Slides برای Python via Java ایجاد و دستکاری کنید تا جریان کاری خود را بهینه کنید."
---
## **مقدمه**

Aspose.Slides کلاس‌ها و اینترفیس‌هایی برای کار با ماکروها و کد VBA فراهم می‌کند.

{{% alert title="Warning" color="warning" %}} 

هنگامی که یک ارائه حاوی ماکروها را به فرمت فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل خروجی منتقل نمی‌شوند).

هنگامی که ماکروها را به یک ارائه اضافه می‌کنید یا ارائه‌ای حاوی ماکروها را دوباره ذخیره می‌کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.

{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/vbaproject/) را برای ایجاد پروژه‌های VBA (و مراجع پروژه) و ویرایش ماژول‌های موجود فراهم می‌کند. می‌توانید از کلاس [VbaProject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/vbaproject/) برای مدیریت VBA جاسازی‌شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. از سازنده [VbaProject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/vbaproject/#vbaproject) برای افزودن یک پروژه VBA جدید استفاده کنید.
1. یک ماژول به پروژه VBA اضافه کنید.
1. کد منبع ماژول را تنظیم کنید.
1. مراجع به `stdole` را اضافه کنید.
1. مراجع به **Microsoft Office** را اضافه کنید.
1. مراجع را به پروژه VBA پیوست کنید.
1. ارائه را ذخیره کنید.

این کد پایتون نشان می‌دهد که چگونه یک ماکرو VBA را از ابتدا به یک ارائه اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # ایجاد یک پروژه VBA جدید.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # افزودن یک ماژول خالی و تنظیم کد منبع آن.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # ایجاد مراجع به stdole و Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # افزودن مراجع به پروژه VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # ذخیرهٔ ارائه.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید که یک برنامه وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word است. 

{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از متد [getVbaProject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getvbaproject) کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
1. به ماژول ماکرو دسترسی پیدا کنید و آن را حذف کنید.
1. ارائه تغییر یافته را ذخیره کنید.

این کد پایتون نشان می‌دهد که چگونه یک ماکرو VBA را حذف کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# بارگذاری ارائه حاوی ماکرو.
presentation = Presentation("VBA.pptm")
try:
    # دسترسی به ماژول VBA و حذف آن.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # ذخیرهٔ ارائه.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
2. بررسی کنید آیا ارائه حاوی یک پروژه VBA است یا نه.
3. در تمام ماژول‌های موجود در پروژه VBA حلقه بزنید تا ماکروها را مشاهده کنید.

این کد پایتون نشان می‌دهد که چگونه ماکروهای VBA را از یک ارائه حاوی ماکرو استخراج کنید:

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation

# بارگذاری ارائه حاوی ماکرو.
presentation = Presentation("VBA.pptm")
try:
    # بررسی اینکه آیا ارائه حاوی یک پروژه VBA است.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **بررسی اینکه آیا یک پروژه VBA دارای رمز عبور است یا نه**

با استفاده از متد [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/fa/python-java/aspose.slides/vbaproject/#ispasswordprotected) می‌توانید تعیین کنید که آیا ویژگی‌های یک پروژه با رمز عبور محافظت شده‌اند یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که حاوی ماکرو است را بارگذاری کنید.
2. بررسی کنید آیا ارائه حاوی یک [VBA project](https://reference.aspose.com/slides/fa/python-java/aspose.slides/vbaproject/) است یا نه.
3. بررسی کنید آیا پروژه VBA با رمز عبور محافظت شده است تا ویژگی‌های آن را مشاهده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # بررسی اینکه آیا ارائه حاوی یک پروژه VBA است.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**چه اتفاقی برای ماکروها می‌افتد اگر ارائه را به صورت PPTX ذخیره کنم؟**

ماکروها حذف می‌شوند زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند تا برای مثال داده‌ها را به‌روزرسانی کند؟**

خیر. این کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرای آن فقط در PowerPoint با تنظیمات امنیتی مناسب امکان‌پذیر است.

**آیا کار با کنترل‌های ActiveX که به کد VBA مرتبط‌اند پشتیبانی می‌شود؟**

بله، می‌توانید به [ActiveX controls](/slides/fa/python-java/activex/) موجود دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و آن‌ها را حذف کنید. این برای مواردی که ماکروها با ActiveX تعامل دارند مفید است.
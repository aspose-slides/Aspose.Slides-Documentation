---
title: مدیریت پروژه‌های VBA در ارائه‌ها بر روی اندروید
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/androidjava/presentation-via-vba/
keywords:
- ماکرو
- VBA
- ماکرو VBA
- اضافه کردن ماکرو
- حذف ماکرو
- استخراج ماکرو
- اضافه کردن VBA
- حذف VBA
- استخراج VBA
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را از طریق VBA با استفاده از Aspose.Slides برای اندروید با جاوا ایجاد و دستکاری کنید تا جریان کار خود را بهینه کنید."
---
## **مقدمه**

Aspose.Slides کلاس‌ها و اینترفیس‌هایی برای کار با ماکروها و کد VBA فراهم می‌کند.

{{% alert title="Note" color="warning" %}} 

هنگامی که یک ارائه حاوی ماکروها را به قالب فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل خروجی منتقل نمی‌شوند).

هنگامی که ماکروها را به یک ارائه اضافه می‌کنید یا یک ارائه حاوی ماکروها را دوباره ذخیره می‌کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.

{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/vbaproject/) را فراهم می‌کند تا بتوانید پروژه‌های VBA (و ارجاعات پروژه) ایجاد کنید و ماژول‌های موجود را ویرایش کنید. می‌توانید از اینترفیس [IVbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivbaproject/) برای مدیریت VBA جاسازی شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. از سازندهٔ [VbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/vbaproject/#VbaProject--) برای افزودن یک پروژه VBA جدید استفاده کنید.
1. یک ماژول به VbaProject اضافه کنید.
1. کد منبع ماژول را تنظیم کنید.
1. ارجاعات به <stdole> را اضافه کنید.
1. ارجاعات به **Microsoft Office** را اضافه کنید.
1. ارجاعات را به پروژه VBA مرتبط کنید.
1. ارائه را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک ماکرو VBA را از ابتدا به یک ارائه اضافه کنید:

```java
// یک نمونه از کلاس ارائه ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // یک پروژه VBA جدید ایجاد می‌کند
    pres.setVbaProject(new VbaProject());
    
    // یک ماژول خالی به پروژه VBA اضافه می‌کند
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // کد منبع ماژول را تنظیم می‌کند
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // یک ارجاع به <stdole> ایجاد می‌کند
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // یک ارجاع به Office ایجاد می‌کند
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // ارجاعات را به پروژه VBA اضافه می‌کند
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // ارائه را ذخیره می‌کند
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید، که یک برنامه وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word است. 

{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از ویژگی [VbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getVbaProject--) در کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
1. به ماژول Macro دسترسی پیدا کرده و آن را حذف کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک ماکرو VBA را حذف کنید:

```java
// ارائه حاوی ماکرو را بارگذاری می‌کند
Presentation pres = new Presentation("VBA.pptm");
try {
    // ماژول Vba را دسترسی می‌یابد و حذف می‌کند 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // ارائه را ذخیره می‌کند
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
2. بررسی کنید آیا ارائه حاوی یک پروژه VBA است یا خیر.
3. از طریق تمام ماژول‌های موجود در پروژه VBA حلقه بزنید تا ماکروها را مشاهده کنید.

این کد Java نشان می‌دهد چگونه ماکروهای VBA را از یک ارائه حاوی ماکرو استخراج کنید:

```java
// ارائه حاوی ماکرو را بارگذاری می‌کند
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // بررسی می‌کند که آیا ارائه حاوی یک پروژه VBA است یا نه
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **بررسی اینکه آیا پروژه VBA با رمز عبور محافظت شده است یا خیر**

با استفاده از متد [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) می‌توانید تعیین کنید آیا خصوصیات یک پروژه با رمز عبور محافظت شده‌اند یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که حاوی ماکرو است را بارگذاری کنید.
2. بررسی کنید آیا ارائه حاوی یک [پروژه VBA](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/vbaproject/) است یا خیر.
3. بررسی کنید آیا پروژه VBA با رمز عبور محافظت شده است تا خصوصیات آن را مشاهده کنید.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // بررسی کنید که آیا ارائه حاوی یک پروژه VBA است یا نه.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چه اتفاقی برای ماکروها می‌افتد اگر ارائه را به عنوان PPTX ذخیره کنم؟**

ماکروها حذف می‌شوند زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، برای مثال برای بروزرسانی داده‌ها؟**

خیر. این کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرای آن تنها در داخل PowerPoint با تنظیمات امنیتی مناسب ممکن است.

**آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟**

بله، می‌توانید به [کنترل‌های ActiveX](/slides/fa/androidjava/activex/) موجود دسترسی داشته باشید، خصوصیات آن‌ها را تغییر دهید و حذف کنید. این زمانی مفید است که ماکروها با ActiveX ارتباط دارند.
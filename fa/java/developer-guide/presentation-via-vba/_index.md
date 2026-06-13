---
title: مدیریت پروژه‌های VBA در ارائه‌ها با استفاده از Java
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را از طریق VBA با Aspose.Slides برای Java ایجاد و دستکاری کنید تا جریان کاری خود را بهینه کنید."
---
## **مقدمه**

Aspose.Slides کلاس‌ها و رابط‌هایی را برای کار با ماکروها و کد VBA فراهم می‌کند.

{{% alert title="Note" color="warning" %}} 

زمانی که یک ارائه حاوی ماکروها را به قالب فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل خروجی منتقل نمی‌شوند).

زمانی که ماکروها را به یک ارائه اضافه می‌کنید یا یک ارائه حاوی ماکروها را دوباره ذخیره می‌کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای یک ارائه را اجرا نمی‌کند.

{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/vbaproject/) را برای ایجاد پروژه‌های VBA (و مراجع پروژه) و ویرایش ماژول‌های موجود فراهم می‌کند. می‌توانید از رابط [IVbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivbaproject/) برای مدیریت VBA تعبیه شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. از سازنده [VbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/vbaproject/#VbaProject--) برای افزودن یک پروژه VBA جدید استفاده کنید.
1. یک ماژول به VbaProject اضافه کنید.
1. کد منبع ماژول را تنظیم کنید.
1. مرجع‌ها به <stdole> اضافه کنید.
1. مرجع‌ها به **Microsoft Office** اضافه کنید.
1. مرجع‌ها را به پروژه VBA مرتبط کنید.
1. ارائه را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک ماکرو VBA را از ابتدا به یک ارائه اضافه کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // یک پروژه VBA جدید ایجاد می‌کند
    pres.setVbaProject(new VbaProject());
    
    // یک ماژول خالی به پروژه VBA اضافه می‌کند
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // کد منبع ماژول را تنظیم می‌کند
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // یک مرجع به <stdole> ایجاد می‌کند
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // یک مرجع به Office ایجاد می‌کند
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // مراجع را به پروژه VBA اضافه می‌کند
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

با استفاده از خصوصیت [VbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getVbaProject--) در زیر کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
1. به ماژول Macro دسترسی پیدا کنید و آن را حذف کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

```java
// ارائه حاوی ماکرو را بارگذاری می‌کند
Presentation pres = new Presentation("VBA.pptm");
try {
    // به ماژول Vba دسترسی پیدا می‌کند و آن را حذف می‌کند 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // ارائه را ذخیره می‌کند
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
2. بررسی کنید آیا ارائه دارای یک پروژه VBA است یا خیر.
3. از طریق تمام ماژول‌های موجود در پروژه VBA حلقه بزنید تا ماکروها را مشاهده کنید.

```java
// ارائه حاوی ماکرو را بارگذاری می‌کند
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // بررسی می‌کند آیا ارائه حاوی پروژه VBA است یا خیر
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

## **بررسی اینکه آیا پروژه VBA رمزعبور دارد یا خیر**

با استفاده از متد [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) می‌توانید تعیین کنید آیا ویژگی‌های یک پروژه با رمزعبور محافظت شده‌اند یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که حاوی ماکرو است را بارگذاری کنید.
2. بررسی کنید آیا ارائه دارای یک [پروژه VBA](https://reference.aspose.com/slides/fa/java/com.aspose.slides/vbaproject/) است یا خیر.
3. بررسی کنید آیا پروژه VBA با رمزعبور محافظت شده است تا ویژگی‌های آن را مشاهده کنید.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // بررسی می‌کند آیا ارائه حاوی پروژه VBA است یا خیر.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**اگر ارائه را به صورت PPTX ذخیره کنم چه اتفاقی برای ماکروها می‌افتد؟**

ماکروها حذف می‌شوند زیرا فرمت PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، برای مثال برای به‌روزرسانی داده‌ها؟**

خیر. این کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرا فقط در داخل PowerPoint و با تنظیمات امنیتی مناسب امکان‌پذیر است.

**آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟**

بله، می‌توانید به [کنترل‌های ActiveX](/slides/fa/java/activex/) موجود دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و حذف کنید. این امر زمانی مفید است که ماکروها با ActiveX تعامل داشته باشند.
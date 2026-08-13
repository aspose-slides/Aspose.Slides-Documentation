---
title: مدیریت پروژه‌های VBA در ارائه‌ها در Android
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را از طریق VBA با Aspose.Slides برای Android با Java تولید و دستکاری کنید تا جریان کار خود را بهبود بخشید."
---
## **مقدمه**

Aspose.Slides کلاس‌ها و اینترفیس‌هایی را برای کار با ماکروها و کد VBA فراهم می‌کند.

{{% alert title="یادداشت" color="warning" %}} 

وقتی یک ارائه حاوی ماکروها را به فرمت فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل خروجی منتقل نمی‌شوند).

وقتی ماکروها را به یک ارائه اضافه می‌کنید یا ارائه حاوی ماکروها را دوباره ذخیره می‌کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.

{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/vbaproject/) را فراهم می‌کند تا بتوانید پروژه‌های VBA (و مراجع پروژه) را ایجاد کنید و ماژول‌های موجود را ویرایش کنید. می‌توانید از اینترفیس [IVbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivbaproject/) برای مدیریت VBA جاسازی‌شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.  
1. از سازنده [VbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/vbaproject/#VbaProject--) برای افزودن یک پروژه VBA جدید استفاده کنید.  
1. یک ماژول به VbaProject اضافه کنید.  
1. کد منبع ماژول را تنظیم کنید.  
1. ارجاعات به <stdole> اضافه کنید.  
1. ارجاعات به **Microsoft Office** اضافه کنید.  
1. ارجاعات را با پروژه VBA مرتبط کنید.  
1. ارائه را ذخیره کنید.  

این کد Java نشان می‌دهد چگونه از ابتدا یک ماکرو VBA به یک ارائه اضافه کنید:

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید، که یک برنامه وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word است. 

{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از ویژگی [VbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getVbaProject--) تحت کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.  
1. به ماژول ماکرو دسترسی پیدا کرده و آن را حذف کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

این کد Java نشان می‌دهد چگونه یک ماکرو VBA را حذف کنید:

```java
import com.aspose.slides.*;

// پرزنتیشنی که شامل ماکرو است را بارگذاری می‌کند
Presentation pres = new Presentation("VBA.pptm");
try {
    // ماژول Vba را دسترسی می‌یابد و آن را حذف می‌کند 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // پرزنتیشن را ذخیره می‌کند
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.  
2. بررسی کنید آیا ارائه شامل یک پروژه VBA است یا خیر.  
3. از طریق تمام ماژول‌های موجود در پروژه VBA حلقه بزنید تا ماکروها را مشاهده کنید.  

این کد Java نشان می‌دهد چگونه ماکروهای VBA را از یک ارائه حاوی ماکرو استخراج کنید:

```java
import com.aspose.slides.*;

// پرزنتیشنی که شامل ماکرو است را بارگذاری می‌کند
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // بررسی می‌کند آیا پرزنتیشن شامل پروژه VBA است
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

## **بررسی اینکه آیا یک پروژه VBA با رمز عبور محافظت می‌شود**

با استفاده از متد [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) می‌توانید تعیین کنید آیا ویژگی‌های یک پروژه با رمز عبور محافظت می‌شود یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل یک ماکرو است را بارگذاری کنید.  
2. بررسی کنید آیا ارائه شامل یک [VBA project](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/vbaproject/) است یا خیر.  
3. بررسی کنید آیا پروژه VBA با رمز عبور محافظت می‌شود تا ویژگی‌های آن را مشاهده کنید.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // بررسی می‌کند آیا پرزنتیشن شامل پروژه VBA است.
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

### چه اتفاقی برای ماکروها می‌افتد اگر ارائه را به‌صورت PPTX ذخیره کنم؟

ماکروها حذف می‌شوند زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگهداری ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

### آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، به‌عنوان مثال برای به‌روزرسانی داده‌ها؟

خیر. کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرا فقط در داخل PowerPoint با تنظیمات امنیتی مناسب امکان‌پذیر است.

### آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟

بله، می‌توانید به کنترل‌های ActiveX موجود ([ActiveX controls](/slides/fa/androidjava/activex/)) دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و حذف کنید. این برای زمانی که ماکروها با ActiveX تعامل دارند، مفید است.
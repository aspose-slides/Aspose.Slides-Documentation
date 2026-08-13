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
description: "بدانید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را با VBA و Aspose.Slides برای Java ایجاد و دستکاری کنید تا گردش کار خود را بهینه کنید."
---
## **مقدمه**

Aspose.Slides کلاس‌ها و اینترفیس‌هایی را برای کار با ماکروها و کد VBA فراهم می‌کند.

{{% alert title="Note" color="warning" %}} 

هنگامی که یک ارائه شامل ماکروها را به یک قالب فایل دیگر (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل خروجی منتقل نمی‌شوند).

وقتی ماکروها را به یک ارائه اضافه می‌کنید یا یک ارائه حاوی ماکروها را مجدداً ذخیره می‌کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.

{{% /alert %}}

## **اضافه کردن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/vbaproject/) را فراهم می‌کند تا بتوانید پروژه‌های VBA (و مراجع پروژه) را ایجاد کرده و ماژول‌های موجود را ویرایش کنید. می‌توانید از اینترفیس [IVbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivbaproject/) برای مدیریت VBA داخل یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
2. از سازندهٔ [VbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/vbaproject/#VbaProject--) برای افزودن یک پروژه VBA جدید استفاده کنید.
3. یک ماژول به VbaProject اضافه کنید.
4. کد منبع ماژول را تنظیم کنید.
5. مراجع به <stdole> را اضافه کنید.
6. مراجع به **Microsoft Office** را اضافه کنید.
7. مراجع را با پروژه VBA مرتبط کنید.
8. ارائه را ذخیره کنید.

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

شاید بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید، که یک برنامهٔ وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word است.

{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از خاصیت [VbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getVbaProject--) در کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation)، می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.
2. به ماژول Macro دسترسی پیدا کنید و آن را حذف کنید.
3. ارائه اصلاح‌شده را ذخیره کنید.

```java
import com.aspose.slides.*;

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
2. بررسی کنید که آیا ارائه شامل یک پروژه VBA است یا خیر.
3. در تمام ماژول‌های موجود در پروژه VBA حلقه زده و ماکروها را مشاهده کنید.

```java
import com.aspose.slides.*;

// ارائه حاوی ماکرو را بارگذاری می‌کند
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // بررسی می‌کند که آیا ارائه شامل یک پروژه VBA است
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

## **بررسی اینکه آیا پروژه VBA با رمز عبور محافظت شده است**

با استفاده از متد [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) می‌توانید تعیین کنید که آیا ویژگی‌های یک پروژه با رمز عبور محافظت شده‌اند یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که حاوی ماکرو است را بارگذاری کنید.
2. بررسی کنید که آیا ارائه شامل یک [VBA project](https://reference.aspose.com/slides/fa/java/com.aspose.slides/vbaproject/) است یا نه.
3. بررسی کنید که آیا پروژه VBA با رمز عبور محافظت شده است تا ویژگی‌های آن را مشاهده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // بررسی می‌کند که آیا ارائه شامل یک پروژه VBA است.
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

### اگر ارائه را به صورت PPTX ذخیره کنم چه می‌شود با ماکروها؟

ماکروها حذف خواهند شد زیرا PPTX از VBA پشتیبانی نمی‌کند. برای حفظ ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

### آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، برای مثال برای به‌روزرسانی داده‌ها؟

نه. این کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرا تنها در PowerPoint و با تنظیمات امنیتی مناسب امکان‌پذیر است.

### آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟

بله، می‌توانید به [ActiveX controls](/slides/fa/java/activex/) موجود دسترسی پیدا کنید، خواص آن‌ها را تغییر دهید و حذف کنید. این زمانی مفید است که ماکروها با ActiveX در تعامل باشند.
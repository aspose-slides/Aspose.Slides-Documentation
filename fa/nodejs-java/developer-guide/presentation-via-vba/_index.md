---
title: مدیریت پروژه‌های VBA در ارائه‌ها با استفاده از JavaScript
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تولید و دستکاری ارائه‌های PowerPoint و OpenDocument از طریق VBA در JavaScript با Aspose.Slides برای Node.js از طریق Java جهت بهینه‌سازی جریان کار شما."
---
## **مقدمه**

Aspose.Slides کلاس‌هایی برای کار با ماکروها و کد VBA فراهم می‌کند.

{{% alert title="Note" color="warning" %}} 

زمانی که ارائه‌ای حاوی ماکرو را به فرمت دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل خروجی منتقل نمی‌شوند).

زمانی که ماکروها را به ارائه‌ای اضافه کنید یا ارائه‌ای حاوی ماکرو را دوباره ذخیره کنید، Aspose.Slides فقط بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.

{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/vbaproject/) را برای ایجاد پروژه‌های VBA (و مراجع پروژه) و ویرایش ماژول‌های موجود فراهم می‌کند. می‌توانید از کلاس [VbaProject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/vbaproject/) برای مدیریت VBA تعبیه‌شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.  
1. از سازندهٔ [VbaProject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/vbaproject/#VbaProject--) برای افزودن یک پروژهٔ جدید VBA استفاده کنید.  
1. یک ماژول به VbaProject اضافه کنید.  
1. کد منبع ماژول را تنظیم کنید.  
1. مراجع به <stdole> اضافه کنید.  
1. مراجع به **Microsoft Office** اضافه کنید.  
1. مراجع را به پروژهٔ VBA مرتبط کنید.  
1. ارائه را ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه از صفر یک ماکرو VBA به یک ارائه اضافه کنید:

```javascript
// یک نمونه از کلاس ارائه ایجاد می‌کند
let pres = new aspose.slides.Presentation();
try {
    // یک پروژه VBA جدید ایجاد می‌کند
    pres.setVbaProject(new aspose.slides.VbaProject());
    // یک ماژول خالی به پروژه VBA اضافه می‌کند
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // کد منبع ماژول را تنظیم می‌کند
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // یک مرجع به <stdole> ایجاد می‌کند
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // یک مرجع به Office ایجاد می‌کند
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // مراجع را به پروژه VBA اضافه می‌کند
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // ارائه را ذخیره می‌کند
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید، که یک برنامه وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word است. 

{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از ویژگی [VbaProject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getVbaProject--) در کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.  
1. به ماژول Macro دسترسی پیدا کنید و آن را حذف کنید.  
1. ارائه‌ی اصلاح‌شده را ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک ماکرو VBA را حذف کنید:

```javascript
// بارگذاری ارائه حاوی ماکرو
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // به ماژول Vba دسترسی پیدا می‌کند و آن را حذف می‌کند
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // ارائه را ذخیره می‌کند
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه حاوی ماکرو را بارگذاری کنید.  
2. بررسی کنید که آیا ارائه شامل یک پروژهٔ VBA است یا خیر.  
3. در تمامی ماژول‌های موجود در پروژهٔ VBA حلقه بزنید تا ماکروها را مشاهده کنید.

این کد JavaScript نشان می‌دهد که چگونه ماکروهای VBA را از یک ارائه حاوی ماکرو استخراج کنید:

```javascript
// ارائه حاوی ماکرو را بارگذاری می‌کند
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // بررسی می‌کند که آیا ارائه حاوی پروژه VBA است یا خیر
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **بررسی اینکه آیا یک پروژهٔ VBA با رمز عبور محافظت می‌شود یا نه**

با استفاده از متد [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) می‌توانید تعیین کنید که آیا خواص یک پروژه با رمز عبور محافظت می‌شود یا خیر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل یک ماکرو است را بارگذاری کنید.  
2. بررسی کنید که آیا ارائه شامل یک [VBA project](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/vbaproject/) است یا نه.  
3. بررسی کنید که آیا پروژهٔ VBA با رمز عبور محافظت می‌شود تا خواص آن را مشاهده کنید.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // بررسی می‌کند که آیا ارائه شامل پروژه VBA است یا خیر.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چه اتفاقی برای ماکروها می‌افتد اگر ارائه را به عنوان PPTX ذخیره کنم؟**

ماکروها حذف می‌شوند چون PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، برای مثال برای به‌روزرسانی داده‌ها؟**

خیر. کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرا فقط در PowerPoint با تنظیمات امنیتی مناسب امکان‌پذیر است.

**آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟**

بله، می‌توانید به کنترل‌های ActiveX موجود دسترسی داشته باشید، خواص آن‌ها را تغییر دهید و آن‌ها را حذف کنید. این ویژگی زمانی مفید است که ماکروها با ActiveX تعامل داشته باشند.
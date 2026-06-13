---
title: "مدیریت پروژه‌های VBA در ارائه‌ها با استفاده از PHP"
linktitle: "ارائه از طریق VBA"
type: docs
weight: 250
url: /fa/php-java/presentation-via-vba/
keywords:
- "ماکرو"
- "VBA"
- "ماکرو VBA"
- "افزودن ماکرو"
- "حذف ماکرو"
- "استخراج ماکرو"
- "افزودن VBA"
- "حذف VBA"
- "استخراج VBA"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را با VBA و Aspose.Slides برای PHP از طریق Java تولید و دستکاری کنید تا جریان کار خود را بهینه‌سازی نمایید."
---
## **مقدمه**

API Aspose.Slides شامل کلاس‌هایی برای کار با ماکروها و کد VBA است.

{{% alert title="Note" color="warning" %}} 
هنگامی که ارائه‌ای حاوی ماکروها را به قالب فایل دیگری (PDF، HTML و غیره) تبدیل می‌کنید، Aspose.Slides تمام ماکروها را نادیده می‌گیرد (ماکروها به فایل حاصل منتقل نمی‌شوند).

هنگامی که ماکروها را به یک ارائه اضافه کنید یا ارائه‌ای حاوی ماکروها را مجدداً ذخیره کنید، Aspose.Slides به سادگی بایت‌های ماکروها را می‌نویسد.

Aspose.Slides **هرگز** ماکروهای موجود در یک ارائه را اجرا نمی‌کند.
{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides کلاس [VbaProject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/vbaproject/) را فراهم می‌کند تا بتوانید پروژه‌های VBA (و ارجاعات پروژه) را ایجاد و ماژول‌های موجود را ویرایش کنید. می‌توانید از کلاس `VbaProject` برای مدیریت VBA جاسازی‌شده در یک ارائه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.  
2. از سازندهٔ [VbaProject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/vbaproject/#VbaProject) برای افزودن یک پروژهٔ VBA جدید استفاده کنید.  
3. یک ماژول به VbaProject اضافه کنید.  
4. کد منبع ماژول را تنظیم کنید.  
5. ارجاعات به <stdole> را اضافه کنید.  
6. ارجاعات به **Microsoft Office** را اضافه کنید.  
7. ارجاعات را با پروژهٔ VBA مرتبط کنید.  
8. ارائه را ذخیره کنید.

```php
  # یک نمونه از کلاس ارائه ایجاد می‌کند
  $pres = new Presentation();
  try {
    # یک پروژه VBA جدید ایجاد می‌کند
    $pres->setVbaProject(new VbaProject());
    # یک ماژول خالی به پروژه VBA اضافه می‌کند
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # کد منبع ماژول را تنظیم می‌کند
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # یک ارجاع به <stdole> ایجاد می‌کند
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # یک ارجاع به Office ایجاد می‌کند
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # ارجاعات را به پروژه VBA اضافه می‌کند
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # ارائه را ذخیره می‌کند
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
ممکن است بخواهید **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros) را بررسی کنید، که یک برنامهٔ وب رایگان برای حذف ماکروها از اسناد PowerPoint، Excel و Word است. 
{{% /alert %}} 

## **حذف ماکروهای VBA**

با استفاده از ویژگی [VbaProject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getVbaProject) تحت کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) می‌توانید یک ماکرو VBA را حذف کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائهٔ حاوی ماکرو را بارگذاری کنید.  
2. به ماژول Macro دسترسی پیدا کنید و آن را حذف کنید.  
3. ارائهٔ اصلاح‌شده را ذخیره کنید.

```php
  # ارائه حاوی ماکرو را بارگذاری می‌کند
  $pres = new Presentation("VBA.pptm");
  try {
    # به ماژول Vba دسترسی پیدا می‌کند و آن را حذف می‌کند
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # ارائه را ذخیره می‌کند
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج ماکروهای VBA**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائهٔ حاوی ماکرو را بارگذاری کنید.  
2. بررسی کنید آیا ارائه شامل یک پروژهٔ VBA است یا خیر.  
3. در تمام ماژول‌های موجود در پروژهٔ VBA حلقه بزنید تا ماکروها را مشاهده کنید.

```php
  # ارائه حاوی ماکرو را بارگذاری می‌کند
  $pres = new Presentation("VBA.pptm");
  try {
    # بررسی می‌کند که آیا ارائه شامل یک پروژه VBA است
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **بررسی اینکه آیا یک پروژهٔ VBA با رمز عبور حفاظت شده است یا نه**

با استفاده از متد [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/fa/php-java/aspose.slides/vbaproject/#isPasswordProtected) می‌توانید تعیین کنید آیا ویژگی‌های یک پروژه با رمز عبور محافظت می‌شود یا نه.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل ماکرو است را بارگذاری کنید.  
2. بررسی کنید آیا ارائه شامل یک [VBA project](https://reference.aspose.com/slides/fa/php-java/aspose.slides/vbaproject/) است یا نه.  
3. بررسی کنید آیا پروژهٔ VBA با رمز عبور حفاظت شده است تا ویژگی‌های آن را ببینید.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // بررسی می‌کند که آیا ارائه شامل یک پروژه VBA است.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**اگر ارائه را به صورت PPTX ذخیره کنم، چه اتفاقی برای ماکروها می‌افتد؟**  
ماکروها حذف می‌شوند زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگه داشتن ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

**آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند، برای مثال برای به‌روزرسانی داده‌ها؟**  
خیر. این کتابخانه هرگز کد VBA را اجرا نمی‌کند؛ اجرا فقط در داخل PowerPoint و با تنظیمات امنیتی مناسب ممکن است.

**آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟**  
بله، می‌توانید به [کنترل‌های ActiveX](/slides/fa/php-java/activex/) موجود دسترسی پیدا کنید، ویژگی‌های آن‌ها را تغییر دهید و حذف کنید. این هنگامی مفید است که ماکروها با ActiveX تعامل داشته باشند.
---
title: استخراج اشیاء Flash از ارائه‌ها در C++
linktitle: فلش
type: docs
weight: 10
url: /fa/cpp/flash/
keywords:
- استخراج فلش
- شیء فلش
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "بیاموزید چگونه اشیاء Flash را از اسلایدهای PowerPoint و OpenDocument در C++ با Aspose.Slides استخراج کنید، نمونه‌کدهای کامل و بهترین شیوه‌ها."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides اشیاء Flash را از ارائه‌ها استخراج کنید. نشان می‌دهد چگونه یک کنترل Flash را با نام در مجموعهٔ کنترل‌های یک اسلاید پیدا کرده و با دادهٔ اشیاء SWF جاسازی‌شده کار کنید.

## **استخراج اشیاء Flash از ارائه‌ها**
Aspose.Slides برای C++ امکان استخراج اشیاء flash را از یک ارائه فراهم می‌کند. می‌توانید کنترل flash را براساس نام دسترسی پیدا کنید و آن را همراه با ذخیرهٔ دادهٔ شیء SWF از ارائه استخراج کنید.

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```

## **پرسش‌های متداول**

**قالب‌های ارائه‌ای که هنگام استخراج محتویات Flash پشتیبانی می‌شوند چیست؟**

[Aspose.Slides پشتیبانی می‌کند](/slides/fa/cpp/supported-file-formats/) فرمت‌های اصلی PowerPoint مانند PPT و PPTX، زیرا می‌تواند این کانتینرها را بارگذاری و به کنترل‌های آنها، از جمله عناصر ActiveX مرتبط با Flash، دسترسی داشته باشد.

**آیا می‌توانم یک ارائه شامل Flash را به HTML5 تبدیل کنم و تعاملات Flash را حفظ کنم؟**

خیر. Aspose.Slides محتویات SWF را اجرا نمی‌کند و تعاملات آن را تبدیل نمی‌نماید. در حالی که خروجی به [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/fa/cpp/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی اجرا نمی‌شود. مسیر پیشنهادی این است که قبل از خروجی، Flash را با گزینه‌هایی مانند ویدئو یا انیمیشن‌های HTML5 جایگزین کنید.

**از منظر امنیت، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

خیر. Aspose.Slides Flash را به عنوان دادهٔ باینری جاسازی‌شده در فایل در نظر می‌گیرد و در طول پردازش محتویات SWF را اجرا نمی‌کند.

**چگونه باید ارائه‌هایی که Flash همراه با سایر فایل‌های جاسازی‌شده از طریق OLE دارند را مدیریت کنم؟**

Aspose.Slides از [استخراج اشیاء OLE جاسازی‌شده](/slides/fa/cpp/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتواهای جاسازی‌شده مرتبط را در یک عبور پردازش کنید و کنترل‌های Flash و سایر اسناد جاسازی‌شده OLE را با هم مدیریت کنید.
---
title: استخراج اشیای فلش از ارائه‌ها در پایتون
linktitle: فلش
type: docs
weight: 10
url: /fa/python-java/flash/
keywords:
- استخراج فلش
- شیء فلش
- پاورپوینت
- اسناد باز
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه اشیای فلش را از اسلایدهای پاورپوینت و اسناد باز در پایتون با Aspose.Slides استخراج کنید، نمونه‌های کامل کد و بهترین روش‌ها."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان اشیای Flash را از ارائه‌ها با استفاده از Aspose.Slides استخراج کرد. این مقاله نشان می‌دهد چگونه یک کنترل Flash را بر اساس نام در مجموعهٔ کنترل‌های اسلاید پیدا کرده و با دادهٔ شیء SWF جاسازی‌شده کار کرد.

## **استخراج اشیای Flash از ارائه‌ها**

Aspose.Slides برای Python از طریق Java امکان استخراج اشیای flash را از یک ارائه فراهم می‌کند. می‌توانید کنترل Flash را بر اساس نام دسترسی پیدا کنید و آن را از ارائه استخراج کنید، از جمله دادهٔ شیء SWF ذخیره‌شده.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است.
presentation = Presentation()
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    flash_control = None
    for control in controls:
        if control.getName() == "ShockwaveFlash1":
            flash_control = control
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**چه قالب‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[Aspose.Slides پشتیبانی می‌کند](/slides/fa/python-java/supported-file-formats/) قالب‌های اصلی پاورپوینت مانند PPT و PPTX، زیرا می‌تواند این کانتینرها را بارگذاری کرده و به کنترل‌های آنها دسترسی داشته باشد، از جمله عناصر ActiveX مربوط به Flash.

**آیا می‌توانم یک ارائه با Flash را به HTML5 تبدیل کنم و تعاملات Flash را حفظ کنم؟**

خیر. Aspose.Slides محتوای SWF را اجرا نمی‌کند و تعاملات آن را تبدیل نمی‌نماید. در حالی که صادرات به [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/fa/python-java/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی پخش نمی‌شود. مسیر پیشنهادی این است که قبل از صادرات، Flash را با گزینه‌های جایگزین مانند ویدیو یا انیمیشن‌های HTML5 جایگزین کنید.

**از منظر امنیتی، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

خیر. Aspose.Slides Flash را به عنوان دادهٔ باینری جاسازی‌شده در فایل در نظر می‌گیرد و در طول پردازش محتویات SWF را اجرا نمی‌کند.

**چگونه باید ارائه‌هایی که Flash همراه با فایل‌های جاسازی‌شده دیگر از طریق OLE دارند را مدیریت کنم؟**

Aspose.Slides از [استخراج اشیای OLE جاسازی‌شده](/slides/fa/python-java/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتوای جاسازی‌شده مربوطه را در یک مرحله پردازش کنید و کنترل‌های Flash و سایر اسناد جاسازی‌شده OLE را به‌طور همزمان مدیریت نمایید.
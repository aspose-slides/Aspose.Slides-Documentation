---
title: استخراج اشیای Flash از ارائه‌ها در Python
linktitle: فلاش
type: docs
weight: 10
url: /fa/python-java/flash/
keywords:
- استخراج فلاش
- شیء فلاش
- پاورپوینت
- سند باز
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه اشیای Flash را از اسلایدهای PowerPoint و OpenDocument در Python با Aspose.Slides استخراج کنید، نمونه‌های کامل کد و بهترین روش‌ها."
---
## **نگاه کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان اشیای Flash را از ارائه‌ها با استفاده از Aspose.Slides استخراج کرد. نشان می‌دهد چگونه یک کنترل Flash را بر اساس نام در مجموعه کنترل‌های یک اسلاید پیدا کرده و با داده‌های شیء SWF تعبیه‌شده کار کرد.

## **استخراج اشیای Flash از ارائه‌ها**

Aspose.Slides برای Python از طریق Java قابلیت استخراج اشیای Flash از یک ارائه را فراهم می‌کند. می‌توانید کنترل Flash را بر حسب نام دسترسی پیدا کنید و آن را از ارائه استخراج کنید، از جمله داده‌های ذخیره‌شدهٔ شیء SWF.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد می‌کند.
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

## **پرسش‌های متداول**

**چه فرمت‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[Aspose.Slides supports](/slides/fa/python-java/supported-file-formats/) فرمت‌های اصلی PowerPoint مانند PPT و PPTX را، زیرا می‌تواند این بسته‌ها را بارگذاری کند و به کنترل‌های آن‌ها، از جمله عناصر ActiveX مرتبط با Flash، دسترسی پیدا کند.

**آیا می‌توانم یک ارائه حاوی Flash را به HTML5 تبدیل کنم و تعاملات Flash را حفظ کنم؟**

خیر. Aspose.Slides محتویات SWF را اجرا نمی‌کند یا تعاملات آن را تبدیل نمی‌نماید. اگرچه خروجی به [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/fa/python-java/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی اجرا نمی‌شود. مسیر پیشنهادی این است که قبل از خروجی، Flash را با گزینه‌هایی مانند ویدئو یا انیمیشن‌های HTML5 جایگزین کنید.

**از منظر امنیتی، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

خیر. Aspose.Slides Flash را به عنوان دادهٔ باینری تعبیه‌شده در فایل در نظر می‌گیرد و در طول پردازش محتویات SWF را اجرا نمی‌کند.

**چگونه باید ارائه‌هایی که شامل Flash به‌همراه فایل‌های تعبیه‌شدهٔ دیگر از طریق OLE هستند را مدیریت کنم؟**

Aspose.Slides از [extracting embedded OLE objects](/slides/fa/python-java/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتویات تعبیه‌شده مرتبط را در یک مرحله پردازش کنید و کنترل‌های Flash و دیگر اسناد تعبیه‌شدهٔ OLE را همزمان مدیریت کنید.
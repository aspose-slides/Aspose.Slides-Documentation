---
title: تبدیل PPTX به PPT در Python
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/python-java/convert-pptx-to-ppt/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPTX
- PPTX به PPT
- ذخیره PPTX به‌صورت PPT
- صدور PPTX به PPT
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "تبدیل PPTX به فرمت قدیمی PPT در Python با Aspose.Slides برای Python via Java. شامل یک مثال کد و نکاتی در مورد سازگاری و فایل‌های محافظت‌شده است."
---
## **Overview**

Aspose.Slides for Python via Java به شما امکان می‌دهد یک ارائه PPTX را به فرمت قدیمی PPT که در PowerPoint 97–2003 استفاده می‌شود، بدون نیاز به نصب Microsoft PowerPoint تبدیل کنید. فایل PPTX را بارگذاری کنید و آن را با فرمت خروجی PPT ذخیره کنید، همان‌طور که در زیر نشان داده شده است.

## **Convert PPTX to PPT**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید، سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را با مسیر خروجی و [SaveFormat.Ppt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Ppt) فراخوانی کنید.

مثال زیر در صورت نیاز ماشین مجازی جاوا را راه‌اندازی می‌کند و `template.pptx` را به `output.ppt` با استفاده از گزینه‌های پیش‌فرض تبدیل می‌کند. مسیرها را با نام فایل‌های خود جایگزین کنید. بلوک `finally` منابع ارائه را حتی در صورت شکست ذخیره‌سازی آزاد می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# بارگذاری ارائه PPTX.
presentation = Presentation("template.pptx")
try:
    # ذخیره ارائه در فرمت PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

آرگومان [SaveFormat.Ppt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Ppt) فرمت خروجی را انتخاب می‌کند؛ تنها تغییر پسوند فایل، یک ارائه را تبدیل نمی‌کند. فایل اصلی PPTX را حفظ کنید تا در صورتی که ویژگی جدیدی معادل در PPT نداشت، بتوانید به آن بازگردید.

## **Convert PPTX to Other Formats**

Aspose.Slides همچنین از سایر فرمت‌های خروجی پشتیبانی می‌کند. مقالات مربوطه را برای گزینه‌ها و مثال‌های مخصوص هر فرمت ببینید:

- [تبدیل پاورپوینت به PDF در پایتون](/slides/fa/python-java/convert-powerpoint-to-pdf/)
- [تبدیل پاورپوینت به XPS در پایتون](/slides/fa/python-java/convert-powerpoint-to-xps/)
- [تبدیل پاورپوینت به HTML در پایتون](/slides/fa/python-java/convert-powerpoint-to-html/)
- [ذخیره ارائه‌ها به‌صورت ODP در پایتون](/slides/fa/python-java/save-presentation/)
- [تبدیل پاورپوینت به PNG در پایتون](/slides/fa/python-java/convert-powerpoint-to-png/)

## **FAQ**

**آیا تمام افکت‌ها و ویژگی‌های PPTX پس از تبدیل به PPT حفظ می‌شوند؟**

همیشه نیست. فرمت قدیمی PPT از تمام ویژگی‌های موجود در PPTX پشتیبانی نمی‌کند. برخی افکت‌ها، اشیا یا رفتارها ممکن است ساده‌سازی شده یا به‌طور متفاوتی نمایش داده شوند. ارائه تبدیل‌شده را در نمایش‌گر موردنظر بررسی کنید، به‌ویژه وقتی شامل ویژگی‌های جدید PowerPoint باشد.

**آیا می‌توانم فقط اسلایدهای انتخابی را به PPT تبدیل کنم؟**

ذخیره به PPT تمام ارائه را می‌نویسد. برای تبدیل اسلایدهای انتخابی، یک ارائه جدید ایجاد کنید، اسلاید خالی اولیه آن را حذف کنید، اسلایدهای مورد نیاز را در آن کلون کنید و به‌صورت PPT ذخیره کنید. مراجعه کنید به [کلون کردن اسلایدها در پایتون](/slides/fa/python-java/clone-slides/) .

**آیا می‌توانم یک فایل PPTX محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، در صورتی که هنگام بارگذاری ارائه منبع، رمز عبور صحیح را ارائه دهید. همچنین می‌توانید حفاظت برای فایل خروجی تنظیم کنید. مراجعه کنید به [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/python-java/password-protected-presentation/).
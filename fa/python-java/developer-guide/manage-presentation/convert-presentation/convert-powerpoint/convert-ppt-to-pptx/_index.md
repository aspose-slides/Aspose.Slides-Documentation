---
title: تبدیل PPT به PPTX در Python
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/python-java/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- صادرات PPT به PPTX
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در Python با Aspose.Slides. شامل مثال‌های Python برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات مرتبط با دقت."
---
## **بررسی کلی**

PPT یک فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML می‌باشد. Aspose.Slides برای Python از طریق Java می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint به صورت PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه مواردی را باید بررسی کنید.

هر مثال در صورت نیاز ماشین مجازی Java را راه‌اندازی می‌کند و پس از استفاده ارائه (presentation) را آزاد می‌سازد. مسیرهای مثال را با مسیرهای فایل یا پوشه خود جایگزین کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید، سپس با [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) و با استفاده از [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) ذخیره کنید. بلوک `finally` ارائه را پاک‌سازی می‌کند و منابع آن را آزاد می‌سازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# بارگذاری ارائه PPT قدیمی.
presentation = Presentation("presentation.ppt")
try:
    # ذخیرهٔ ارائه در فرمت PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز به حفظ فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر تمام فایل‌های `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به‌صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق مانع ادامهٔ دسته نمی‌شود.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

برای بارهای کاری تولیدی، استثنا کامل را لاگ کنید، تصمیم بگیرید آیا می‌توان فایل خروجی موجود را بازنویسی کرد، و نام فایل‌های ناموفق را به صف retry یا review بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز درست باز می‌شوند، مسیرهای غیرقابل دسترسی، و محتویات پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، به [Password-Protected Presentations](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

تبدیل به‌طور معمول اسلایدها، مسترها، طرح‌بندی‌ها، متن، شکل‌ها، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌دقت یکسانی نشان نمی‌دهند. ویژگی قدیمی که معادل PPTX نداشته باشد یا توسط کتابخانه پشتیبانی نشود، ممکن است نرمال‌سازی، حذف یا به‌صورت متفاوتی نمایش داده شود.

فایل تبدیل‌شده را زمانی که شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE توکار یا پیوندی، کنترل‌های ActiveX، رسانه‌های توکار، فونت‌های غیرمتداول یا ماکروهای VBA است، بررسی کنید. یک فایل PPTX ساده فرمت فعال‌سازی ماکرو نیست، بنابراین وقتی VBA باید در دسترس باشد، از جریان کاری مناسب ماکروپذیر استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را برنامه‌نویسی مجدداً باز کنید و تعداد اسلایدهای کلیدی و محتوا را بررسی کنید، سپس ظاهر و رفتار ارائه اسلاید شو را در مرورگر مورد نظر مقایسه کنید. یک فراخوانی موفق [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را به‌عنوان اثبات این‌که هر ویژگی قدیمی دقیقاً در PPTX نمایان شده است، در نظر نگیرید.

## **چه موقع از PPTX استفاده کنیم**

از PPTX زمانی استفاده کنید که ارائه در نسخه‌های فعلی PowerPoint ویرایش خواهد شد، با سیستم‌هایی که بسته‌های Open XML را پشتیبانی می‌کنند تبادل شود، یا در فرمت‌ّی ذخیره شود که بررسی و بازیابی آن نسبت به PPT باینری قدیمی آسان‌تر باشد. تا زمانی که ارائه تبدیل‌شده از آزمون‌های دقت شما عبور کرد، نسخه اصلی PPT را به‌عنوان نسخه آرشیوی یا بازگشتی نگه دارید.

اگر به‌جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های مخصوص فرمت را در [Convert Presentations to Multiple Formats](/slides/fa/python-java/convert-presentation/) استفاده کنید به‌جای این‌که فرض کنید تمام مقصدها ویژگی‌های ویرایش‌پذیر PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسهٔ سریع، می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های قابل تکرار، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، API Python از طریق Java را به‌کار ببرید.

## **مقالات مرتبط**

- [PPT در مقابل PPTX](/slides/fa/python-java/ppt-vs-pptx/)
- [ذخیره ارائه‌ها در Python](/slides/fa/python-java/save-presentation/)
- [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/python-java/supported-file-formats/)
- [باز کردن ارائه‌ها در Python](/slides/fa/python-java/open-presentation/)

## **سؤالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides برای Python از طریق Java فایل‌های ارائه را بدون نیاز به Microsoft PowerPoint بارگذاری و ذخیره می‌کند.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌طور دقیق حفظ می‌کند؟**

این تبدیل محتویات رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا غیرپشتیبانی‌شده تضمین نمی‌شود. فایل تولیدشده را زمانی که شامل ماکروها، اشیای OLE یا ActiveX، رسانه، انیمیشن‌های تخصصی یا فونت‌های غیرمتداول است، بررسی کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، در صورتی که هنگام بارگذاری فایل رمز عبور صحیح را فراهم کنید. عدم وجود یا نادرست بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در مرورگرها و جریان‌های کاری مهم برای خود تأیید کنید، نسخهٔ اصلی را نگه دارید. این کار یک نسخهٔ بازگشتی در صورت تبدیل متفاوت یک ویژگی قدیمی فراهم می‌کند.
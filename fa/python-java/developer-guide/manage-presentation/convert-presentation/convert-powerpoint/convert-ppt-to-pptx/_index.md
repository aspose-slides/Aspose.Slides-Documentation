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
- ذخیره PPT به صورت PPTX
- صادرات PPT به PPTX
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در Python با Aspose.Slides. شامل مثال‌های Python برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات مربوط به دقت."
---
## **نمای کلی**

PPT یک قالب باینری ارثی PowerPoint است، در حالی که PPTX قالب جدید Open XML می‌باشد. Aspose.Slides برای Python از طریق Java می‌تواند یک فایل PPT را بارگیری کند و بدون نیاز به Microsoft PowerPoint آن را به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و پس از تبدیل چه مواردی را باید بررسی کنید.

هر مثال در صورت نیاز ماشین مجازی Java را راه‌اندازی می‌کند و پس از استفاده ارائه را آزاد می‌سازد. مسیرهای مثال را با مسیرهای فایل یا پوشه خود جایگزین کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) و [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) ذخیره کنید. بلاک `finally` ارائه را آزاد می‌کند و منابع آن را رها می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# بارگذاری ارائه PPT قدیمی.
presentation = Presentation("presentation.ppt")
try:
    # ذخیرهٔ ارائه در قالب PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

پسوند فایل به تنهایی فرمت خروجی را انتخاب نمی‌کند؛ استدلال [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز به حفظ فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` را در یک پوشه تبدیل می‌کند. هر فایل به‌صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق، بقیهٔ دسته را متوقف نمی‌کند.

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

برای بارهای تولیدی، استثنا را به‌طور کامل ثبت کنید، تصمیم بگیرید آیا می‌توان فایل خروجی موجود را بازنویسی کرد و نام‌های فایل‌های ناموفق را به صف retry یا بازبینی بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترس و محتواهای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگیری فایل‌های رمزگذاری‌شده به بخش [Password-Protected Presentations](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های ارثی**

تبدیل به‌طور معمول اسلایدها، مسترها، چیدمان‌ها، متن، اشکال، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. اما PPT و PPTX هر ویژگی را به‌دقت یکسان نشان نمی‌دهند. یک ویژگی ارثی که معادل PPTX نداشته باشد یا توسط کتابخانه پشتیبانی نشود، ممکن است نرمال‌سازی، حذف یا به‌صورت متفاوتی نمایش داده شود.

زمانی که فایل تبدیل‌شده شامل انیمیشن‌ها، انتقال‌ها، اشیاء OLE تعبیه‌شده یا پیوندی، کنترل‌های ActiveX، رسانه‌های تعبیه‌شده، فونت‌های کمتر رایج یا ماکروهای VBA باشد، آن را بررسی کنید. یک فایل PPTX ساده فرمت ماکرو‌پشتیبانی‌شده نیست، بنابراین هنگام نیاز به حفظ VBA از گردش کار مناسب ماکرو‌پشتیبانی استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشد.

برای اسناد مهم، PPTX تولید شده را به‌صورت برنامه‌نویسی باز کنید و تعداد اسلایدها و محتوای کلیدی را بررسی کنید، سپس ظاهر و رفتار اسلایدشو را در نمایش‌گر مورد نظر مقایسه کنید. فراخوانی موفق [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را به‌عنوان اثبات این‌که هر ویژگی ارثی نمایانگر دقیق PPTX دارد در نظر نگیرید.

## **چه زمانی از PPTX استفاده کنیم**

از PPTX زمانی استفاده کنید که ارائه در نسخه‌های فعلی PowerPoint ویرایش خواهد شد، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند تبادل می‌شود، یا در قالبی ذخیره می‌شود که نسبت به قالب باینری قدیمی PPT، بررسی و بازیابی آن آسان‌تر است. تا زمانی که ارائه تبدیل‌شده آزمایش‌های دقت شما را پشت‌گیری کرد، نسخهٔ اصلی PPT را به‌عنوان نسخهٔ آرشیوی یا بازگشتی نگه دارید.

اگر به‌جای آن به PDF، HTML، تصویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های مربوط به هر فرمت را در [Convert Presentations to Multiple Formats](/slides/fa/python-java/convert-presentation/) دنبال کنید و فرض نکنید همهٔ مقاصد ویژگی‌های ویرایشی PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسهٔ سریع، می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های قابل تکرار، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API Python via Java بهره ببرید.

## **مقالات مرتبط**

- [PPT در مقابل PPTX](/slides/fa/python-java/ppt-vs-pptx/)
- [ذخیره ارائه‌ها در Python](/slides/fa/python-java/save-presentation/)
- [قالب‌های فایل پشتیبانی‌شده](/slides/fa/python-java/supported-file-formats/)
- [باز کردن ارائه‌ها در Python](/slides/fa/python-java/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون اینکه Microsoft PowerPoint نصب باشد؟**

بله. Aspose.Slides برای Python از طریق Java فایل‌های ارائه را بارگیری و ذخیره می‌کند بدون نیاز به Microsoft PowerPoint.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌دقت حفظ می‌کند؟**

این تبدیل محتواهای رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی ارثی یا پشتیبانی‌نشده تضمین نمی‌شود. هنگامیکه فایل شامل ماکروها، اشیاء OLE یا ActiveX، رسانه‌ها، انیمیشن‌های خاص یا فونت‌های کمتر رایج باشد، آن را بازبینی کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، در صورتی که هنگام بارگیری فایل رمز صحیح را ارائه دهید. نبود یا نادرست بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

نسخهٔ اصلی را تا زمانی که PPTX را در نمایشگرها و گردش کارهایی که برای شما مهم‌اند تأیید کرده‌اید، حفظ کنید. این کار یک نسخهٔ بازگشتی فراهم می‌کند در صورتی که ویژگی ارثی به‌صورت متفاوتی تبدیل شود.
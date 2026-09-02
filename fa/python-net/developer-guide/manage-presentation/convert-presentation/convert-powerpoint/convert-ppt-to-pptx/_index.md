---
title: تبدیل PPT به PPTX در پایتون
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/python-net/convert-ppt-to-pptx/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- خروجی PPT به PPTX
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در پایتون با Aspose.Slides. شامل مثال‌هایی برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات دقت."
---
## **بررسی کلی**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides برای Python از طریق .NET می‌تواند یک فایل PPT را بارگیری کرده و بدون نیاز به Microsoft PowerPoint به‌عنوان PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگیری کنید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) و [SaveFormat.PPTX](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) ذخیره کنید. عبارت `with` ارائه را آزاد کرده و منابع آن را هنگام پایان بلوک آزاد می‌کند.

```python
import aspose.slides as slides

# بارگذاری ارائه PPT قدیمی.
with slides.Presentation("presentation.ppt") as presentation:
    # ذخیره ارائه در فرمت PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

پسوند فایل به تنهایی فرمت خروجی را انتخاب نمی‌کند؛ آرگومان [SaveFormat.PPTX](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) این کار را انجام می‌دهد. اگر نیاز به نگه‌داراندن فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر همهٔ فایل‌های `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به‌طور مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق مانع بقیهٔ دسته نمی‌شود.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

برای بارهای کاری تولیدی، استثنای کامل را لاگ کنید، تصمیم بگیرید آیا یک فایل خروجی موجود می‌تواند بازنویسی شود، و نام‌های فایل‌های ناموفق را به صف بازنگری یا باز試ی بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترسی و محتوای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگیری فایل‌های رمزگذاری‌شده، به [Password-Protected Presentations](/slides/fa/python-net/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

تبدیل معمولاً اسلایدها، مسترها، طرح‌بندی‌ها، متن، اشکال، تصویرها, جدول‌ها و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌دقت یکسانی نمایش نمی‌دهند. ویژگی‌های قدیمی که معادلی در PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند، ممکن است نرمال‌سازی، حذف یا به‌ شکلی متفاوت نمایش داده شوند.

فایل تبدیل‌شده را زمانی بررسی کنید که شامل انیمیشن‌ها، گذارها, اشیای OLE جاسازی‌شده یا لینک‌شده, کنترل‌های ActiveX, رسانه‌های جاسازی‌شده, فونت‌های نامعمول یا ماکروهای VBA باشد. یک فایل PPTX ساده فرمت حمایتی ماکرو نیست، بنابراین وقتی VBA باید در دسترس باشد، از جریان کاری مناسب ماکرو‑پشتیبان استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های لازم و منابع خارجی در محیطی که ارائهٔ تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را به‌صورت برنامه‌نویسی باز کنید و شمار اسلایدها و محتواهای کلیدی را بررسی کنید، سپس ظاهر و رفتار اسلاید‑شو را در نمایندهٔ موردنظر مقایسه کنید. یک فراخوانی موفق [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) را به‌عنوان اثبات اینکه هر ویژگی قدیمی دقیقا در PPTX نمایان شده است در نظر نگیرید.

## **چه زمانی از PPTX استفاده کنیم**

از PPTX استفاده کنید زمانی که ارائه در نسخه‌های فعلی PowerPoint ویرایش خواهد شد، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند مبادله می‌شود، یا در فرمت‌ایی ذخیره می‌شود که بررسی و بازیابی آن نسبت به PPT باینری قدیمی آسان‌تر است. تا زمانی که ارائهٔ تبدیل‌شده تست‌های دقت شما را پشتوانه کند، نسخهٔ اصلی PPT را به‌عنوان نسخهٔ بایگانی یا بازگشت نگه دارید.

اگر به‌جای آن به PDF، HTML، تصویرها, XPS یا نوع خروجی دیگری نیاز دارید، به راهنمای مخصوص فرمت در [Convert Presentations to Multiple Formats](/slides/fa/python-net/convert-presentation/) مراجعه کنید به‌جای این‌که فرض کنید همهٔ هدف‌ها ویژگی‌های ویرایش‌پذیر PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسهٔ سریع، می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های تکراری، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API پایتون استفاده کنید.

## **مقالات مرتبط**

- [PPT در مقابل PPTX](/slides/fa/python-net/ppt-vs-pptx/)
- [ذخیره ارائه‌ها در پایتون](/slides/fa/python-net/save-presentation/)
- [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/python-net/supported-file-formats/)
- [باز کردن ارائه‌ها در پایتون](/slides/fa/python-net/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides برای Python از طریق .NET فایل‌های ارائه را بدون نیاز به Microsoft PowerPoint بارگیری و ذخیره می‌کند.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌صورت دقیق حفظ می‌کند؟**

این تبدیل محتوای رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. فایل تولیدشده را وقتی شامل ماکروها، اشیای OLE یا ActiveX، رسانه، انیمیشن‌های خاص یا فونت‌های نامعمول است، بررسی کنید.

**آیا می‌توانم فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر هنگام بارگیری فایل رمز صحیح را ارائه دهید. عدم وجود یا نادرست بودن رمز باعث شکست عملیات بارگیری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در نمایشگرها و جریان‌های کاری مهم برای شما تأیید کرده‌اید، نسخهٔ اصلی را نگه دارید. این یک نسخهٔ بازگشتی فراهم می‌کند اگر ویژگی قدیمی به‌صورت متفاوتی تبدیل شود.
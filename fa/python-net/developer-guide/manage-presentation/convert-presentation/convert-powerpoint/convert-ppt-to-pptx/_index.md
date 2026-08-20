---
title: تبدیل PPT به PPTX در پایتون
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/python-net/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به‌صورت PPTX
- صادرات PPT به PPTX
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در پایتون با Aspose.Slides. شامل مثال‌هایی برای تبدیل تک‌فایلی و دسته‌ای، مدیریت خطا و نکات مربوط به دقت."
---
## **مرور کلی**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides for Python via .NET می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint به‌صورت PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه چیزهایی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید، سپس [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) را با [SaveFormat.PPTX](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) فراخوانی کنید. عبارت `with` هنگام پایان بلوک، ارائه را از بین می‌برد و منابع آن را آزاد می‌کند.

```python
import aspose.slides as slides

# بارگذاری ارائه PPT قدیمی.
with slides.Presentation("presentation.ppt") as presentation:
    # ذخیره ارائه در قالب PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

پسوند فایل به‌تنهایی فرمت خروجی را تعیین نمی‌کند؛ استدلال [SaveFormat.PPTX](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) این کار را انجام می‌دهد. اگر نیاز به نگه داشتن فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به‌صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق اجرای بقیهٔ دسته را متوقف نمی‌کند.

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

برای بارهای کاری تولیدی، استثناء کامل را ثبت کنید، تصمیم بگیرید آیا فایل خروجی موجود می‌تواند بازنویسی شود یا نه، و نام فایل‌های ناموفق را به صف retry یا review بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترسی و محتوای پشتیبانی نشده می‌توانند منجر به شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، به [Password-Protected Presentations](/python-net/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های ارثی**

تبدیل معمولاً اسلایدها، مسترها، چینش‌ها، متن، شکل‌ها، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌دقت یکسان نمایش نمی‌دهند. ویژگی‌های ارثی که معادل PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند ممکن است نرمال‌سازی، حذف یا به‌صورت متفاوتی نمایش داده شوند.

فایل تبدیل شده را زمانی که شامل انیمیشن‌ها، انتقال‌ها، اشیاء OLE توکار یا لینک‌شده، کنترل‌های ActiveX، رسانه‌های توکار، قلم‌های نادر یا ماکروهای VBA است، بررسی کنید. یک فایل PPTX ساده قالب ماکروپشتیبانی نیست، بنابراین وقتی VBA باید موجود باشد، از جریان کاری مناسب ماکروپشتیبانی استفاده کنید. همچنین اطمینان حاصل کنید که قلم‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود هستند.

برای اسناد مهم، PPTX تولید شده را به‌صورت برنامه‌ای باز کنید و تعداد اسلایدها و محتوای کلیدی را بررسی کنید، سپس ظاهر و رفتار اسلایدشو را در نمایشگر موردنظر مقایسه کنید. یک فراخوانی موفق [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) را به‌عنوان اثبات این‌که هر ویژگی ارثی دقیقاً در PPTX نمایان شده است درنظر نگیرید.

## **چه زمانی از PPTX استفاده کنیم**

از PPTX استفاده کنید وقتی ارائه در نسخه‌های فعلی PowerPoint ویرایش می‌شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند، تبادل می‌شود یا در قالبی ذخیره می‌شود که بررسی و بازیابی آن نسبت به PPT باینری ارثی آسان‌تر است. تا زمانی که ارائه تبدیل‌شده آزمون‌های دقت شما را پشت سر بگذارد، نسخهٔ اصلی PPT را به‌عنوان بایگانی یا نسخهٔ بازگشت نگه دارید.

اگر به‌جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های مربوط به فرمت را در [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) استفاده کنید و فرض نکنید که تمام هدف‌ها ویژگی‌های قابل ویرایش PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسه سریع می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های قابل تکرار، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API پایتون استفاده کنید.

## **مقالات مرتبط**

- [PPT در برابر PPTX](/python-net/ppt-vs-pptx/)
- [ذخیره ارائه‌ها در پایتون](/python-net/save-presentation/)
- [قالب‌های فایل پشتیبانی‌شده](/python-net/supported-file-formats/)
- [باز کردن ارائه‌ها در پایتون](/python-net/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides for Python via .NET فایل‌های ارائه را بدون نیاز به Microsoft PowerPoint بارگذاری و ذخیره می‌کند.

**آیا تبدیل PPT به PPTX تمام محتوا را دقیقاً حفظ می‌کند؟**

این تبدیل محتویات معمولی ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی ارثی یا پشتیبانی‌نشده تضمین نمی‌شود. هنگامی که فایل حاوی ماکروها، اشیاء OLE یا ActiveX، رسانه، انیمیشن‌های تخصصی یا قلم‌های نادر باشد، فایل تولید شده را مرور کنید.

**آیا می‌توانم فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، در صورتی که هنگام بارگذاری فایل رمز صحیح را فراهم کنید. عدم وجود یا نادرست بودن رمز باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در نمایشگرها و جریان‌های کاری مهم برای شما تأیید کنید، نسخهٔ اصلی را نگه دارید. این کار یک نسخهٔ بازگشت در صورت تبدیل متفاوت یک ویژگی ارثی فراهم می‌کند.
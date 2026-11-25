---
title: قطع عملیات طولانی‌مدت ارائه در پایتون
linktitle: قطع عملیات ارائه
type: docs
weight: 150
url: /fa/python-net/support-for-interruptable-library/
keywords:
- عملیات قابل قطع
- توکن قطع
- لغو خروجی PDF
- PowerPoint
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه تبدیل یک ارائه را در پایتون لغو کنید و فهرست اسلایدهایی که قبل از لغو تکمیل شده‌اند را برگردانید."
---
## **نمای کلی**

Aspose.Slides for Python via .NET از لغو همکارانه در طول عملیات طولانی‌مدت مانند بارگذاری، ذخیره‌سازی و رندر کردن ارائه‌ها پشتیبانی می‌کند. هنگامی که اسلایدها را به‌صورت جداگانه صادر می‌کنید، می‌توانید لغو را بین اسلایدها بررسی کنید و شماره‌های اسلایدهای صادر شده کامل را برگردانید.

## **لغو تبدیل ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/) ایجاد کنید، [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) آن را به [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/) اختصاص دهید و گزینه‌ها را به [سازنده Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/) پاس دهید. این توکن در طول عمر ارائه معتبر است. برای درخواست لغو از برنامه‌تان، [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/) را فراخوانی کنید.

مثال `sample.pptx` را به `sample.pdf` تبدیل می‌کند. یک [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) پس از 20 ثانیه `source.interrupt` را فراخوانی می‌کند. شروع تایمر قبل از باز کردن فایل باعث می‌شود زمان‑سیمه بر هر دو بارگذاری و ذخیره‌سازی اعمال شود. یک برنامه با دکمه Cancel می‌تواند همان متد را از هندلر رویداد خود فراخوانی کند.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

بررسی صریح پس از بارگذاری، در صورتی که زمان‑سیمه قبلاً تمام شده باشد، صادرات را نادیده می‌گیرد. اگر بارگذاری یا ذخیره‌سازی درخواست را مشاهده کند، استثنای لغو به فراخواننده می‌رسد. همچنین ممکن است ذخیره‌سازی پیش از مشاهدهٔ درخواست به پایان برسد که در این صورت PDF کامل است.

## **متوقف کردن قبل از پردازش اسلاید بعدی**

قبل از هر صادرات، [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) را بررسی کنید. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) یک فهرست از شماره‌های اسلایدها را که از 1 شروع می‌شوند می‌پذیرد. عدد را به فهرست تکمیل‌شده فقط پس از موفقیت‌آمیز ذخیره شدن PDF آن اضافه کنید.

از فایلی به نام `sample.pptx` که حداقل دو اسلاید دارد استفاده کنید. برای قابل بازتولید کردن نتیجه، مثال درخواست لغو را بلافاصله پس از اتمام اسلاید 1 می‌دهد. در یک برنامه، این درخواست می‌تواند از یک رشتهٔ دیگر هنگام ذخیره‌سازی اسلایدی صادر شود.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

مثال `slide-1.pdf` را می‌نویسد و `Starting slide 1` را چاپ می‌کند و سپس `Completed: [1]`. تکرار بعدی درخواست را پیش از شروع اسلاید 2 می‌بیند. اگر لغو یک ذخیره‌سازی را قطع کند، обработчик исключения возвращает номера, записанные предыдущими итерациями. سایر خطاهای صادرات به فراخواننده می‌رسند.

اگر فراخواننده باید لغو را به‌عنوان استثنا مدیریت کند، بررسی و `break` آن را در بالای حلقه با [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/) جایگزین کنید. همچنین `try`/`except` اطراف ذخیره‌سازی را حذف کنید. با همان ورودی، اسلاید 1 ذخیره می‌شود و تکرار دوم قبل از شروع اسلاید 2 یک استثنای لغو ایجاد می‌کند.

## **پرسش‌های متداول**

**در چه زمانی درخواست لغو اثر می‌گذارد؟**

یک عملیات قابل قطع به‌طور دوره‌ای توکن خود را بررسی می‌کند. وقتی درخواست را مشاهده کند، متوقف می‌شود. عملیاتی که قبلاً تمام شده است، نتیجهٔ خود را حفظ می‌کند.

**تفاوت منبع (source) و توکن (token) چیست؟**

منبع به برنامهٔ شما امکان درخواست لغو را می‌دهد. توکن به هر دو، ارائه و کد شما، اجازه می‌دهد که آن درخواست را بررسی کنند.

**آیا چندین عملیات می‌توانند یک منبع را به‌اشتراک بگذارند؟**

بله. فراخوانی `interrupt` برای همهٔ عملیات‌های استفاده‌کننده از توکن‌های آن منبع درخواست لغو می‌کند. اگر نیاز دارید هر عملیات به‌صورت مستقل لغو شود، برای هر کدام منبع جداگانهٔ خود را ایجاد کنید.
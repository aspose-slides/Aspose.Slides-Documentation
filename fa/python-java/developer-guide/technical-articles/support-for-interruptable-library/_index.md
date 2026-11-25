---
title: متوقف کردن عملیات طولانی‌مدت ارائه در پایتون
linktitle: متوقف کردن عملیات ارائه
type: docs
weight: 120
url: /fa/python-java/support-for-interruptable-library/
keywords:
- عملیات‌های قابل قطع
- توکن قطع
- توکن لغو
- وظیفه طولانی‌مدت
- وظیفه توقف
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه عملیات طولانی‌مدت ارائه را در Aspose.Slides برای پایتون از طریق جاوا لغو کنید و هنگام استخراج اسلایدها در یک حلقه، نتیجه جزئی برگردانید."
---
## **مرور کلی**

Aspose.Slides برای Python از طریق Java می‌تواند عملیات‌های طولانی‌مدت مانند بارگذاری، ذخیره‌سازی و رندر کردن ارائه‌ها را متوقف کند. برنامه شما می‌تواند از توکن قطع‌شدن یکسان برای توقف یک حلقه قبل از پردازش اسلاید بعدی استفاده کند.

## **متوقف کردن یک عملیات ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) ایجاد کنید، توکن آن را با [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) دریافت کنید و توکن را به [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) پاس دهید. گزینه‌های بارگذاری را به [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) پاس دهید. برای درخواست لغو، روی منبع متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) را صدا بزنید. یک عملیات قابل قطع زمانی که درخواست را ببیند متوقف می‌شود. برای گرفتن استثنای جاوا `com.aspose.slides.exceptions.OperationCanceledException` در پایتون از `jpype.JClass` استفاده کنید.

در مثال `sample.pptx` به `sample.ppt` در یک رشته پس‌زمینه تبدیل می‌شود. رشته فراخوانی تا ۱۰ ثانیه برای اتمام تبدیل صبر می‌کند. اگر تبدیل هنوز در حال اجرا باشد، درخواست لغو می‌کند و تا خروج کارگر صبر می‌کند.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **اتصال زمان‌سنج پایتون به Aspose.Slides**

برای تعیین محدودیت زمانی بر یک عملیات ارائه، از یک [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) استفاده کنید تا هنگام انقضای زمان‌سنج متد [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) را صدا بزنید. در مثال ۲۰ ثانیه برای بارگذاری `sample.pptx` و خروجی گرفتن آن به `sample.pdf` اجازه داده می‌شود. اگر خروجی زودتر تمام شد، برنامه درخواست زمان‌بندی‌شده را لغو می‌کند.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **توقف قبل از پردازش اسلاید بعدی**

از همان [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) برای ارائه و حلقه‌ای که اسلایدهای آن را صادر می‌کند استفاده کنید. قبل از هر صادرات، [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) را بررسی کنید. اگر فراخوانی می‌تواند از نتیجه جزئی استفاده کند، شماره اسلایدهای صادرات موفق را برگردانید.

یک ارائه با نام `sample.pptx` که حداقل دو اسلاید دارد استفاده کنید. overload [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) که یک `int[]` جاوا می‌گیرد، از شماره اسلایدها از ۱ شروع می‌کند. برای ساخت این آرایه در پایتون از `jpype.JArray(jpype.JInt)` استفاده کنید. در مثال هر اسلاید را به یک PDF جداگانه ذخیره می‌کند و بلافاصله پس از ثبت اولین صادرات موفق، درخواست لغو می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

در مثال `slide-1.pdf` نوشته می‌شود و `Starting slide 1` چاپ می‌شود و سپس `Completed: [1]`. حلقه قبل از شروع اسلاید ۲ درخواست را می‌بیند. اگر لغو در حین ذخیره رخ دهد، حلقه قبل از ثبت تکمیل آن اسلاید خارج می‌شود.

اگر فراخوانی نیاز به مدیریت لغو داشته باشد، بررسی و `break` در ابتدای حلقه را با `token.throwIfInterruptionRequested()` جایگزین کنید. `try`/`except` اطراف ذخیره را حذف کنید تا لغو در حین صادرات نیز به فراخوانی برسد. با همان ورودی، مثال فقط `Starting slide 1` چاپ می‌کند و `slide-1.pdf` می‌نویسد. در شروع دور دوم، [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) قبل از شروع صادرات بعدی `com.aspose.slides.exceptions.OperationCanceledException` را پرتاب می‌کند. استثنا قبل از اینکه تابع بتواند لیست را برگرداند، به فراخوانی‌گر منتقل می‌شود.

## **سؤالات متداول**

**چه زمانی باید درخواست لغو کنم؟**

زمانی که یک عملیات از محدودیت زمانی شما تجاوز کند یا برنامه شما دیگر به نتیجه نیاز نداشته باشد، درخواست لغو کنید.

**تفاوت بین [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) چیست؟**

منبع به برنامه شما امکان درخواست لغو را می‌دهد. توکن به Aspose.Slides و برنامه شما اجازه می‌دهد تا آن درخواست را بررسی کنند.

**آیا می‌توانم یک عملیات را از طریق زمان‌سنج پایتون لغو کنم؟**

بله. یک تماس به [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) روی منبع مرتبط با ارائه زمان‌بندی کنید.

**کدام عملیات‌ها را می‌توانم متوقف کنم؟**

می‌توانید بارگذاری، ذخیره‌سازی و رندر کردن را متوقف کنید. توکن را از طریق [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) به [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) پاس دهید. سپس ارائه می‌تواند در عملیات‌های بعدی مانند ذخیره به PDF، لغو را مشاهده کند.

**آیا یک عملیات بلافاصله متوقف می‌شود؟**

لغو به صورت تعاملی است. یک عملیات به‌صورت دوره‌ای توکن را بررسی می‌کند و زمانی که درخواست را ببیند متوقف می‌شود.

**اگر پس از اتمام یک عملیات، [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) را صدا بزنم چه می‌شود؟**

عملیات تکمیل‌شده نتیجه خود را حفظ می‌کند.

**آیا چندین عملیات می‌توانند یک [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) را به اشتراک بگذارند؟**

بله. صدا زدن [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) درخواست لغو برای هر عملیاتی که از توکن آن منبع استفاده می‌کند را می‌دهد. برای هر عملیاتی که می‌خواهید به‌صورت مستقل لغو کنید، یک منبع جداگانه استفاده کنید.
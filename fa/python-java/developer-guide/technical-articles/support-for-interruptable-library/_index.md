---
title: پشتیبانی از کتابخانه قابل قطع
type: docs
weight: 120
url: /fa/python-java/support-for-interruptable-library/
keywords:
- کتابخانه قابل قطع
- توکن قطع
- توکن لغو
- کار طولانی‌مدت
- قطع کار
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "کارهای طولانی‌مدت را با Aspose.Slides برای Python از طریق Java قابل لغو کنید. رندرینگ و تبدیل‌ها برای PowerPoint و OpenDocument را به‌صورت ایمن قطع کنید، به همراه مثال‌ها."
---
## **نمای کلی**

Aspose.Slides یک مکانیزم پردازش قابل قطع برای وظایف ارائه‌ایی طولانی‌مدت فراهم می‌کند، مانند جداسازی، سریال‌سازی و رندرینگ. این مکانیزم بر پایهٔ کلاس‌های [InterruptionToken](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/) استوار است.

یک [InterruptionToken] می‌تواند به [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) اختصاص داده شود و به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) پاس داده شود. هنگامی که [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/#interrupt) فراخوانی می‌شود، وظیفهٔ طولانی‌مدت مرتبط متوقف می‌شود.

## **کتابخانه قابل قطع**

Aspose.Slides برای Python از طریق Java کلاس‌های [InterruptionToken](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/) را فراهم می‌کند. این کلاس‌ها به شما امکان می‌دهند وظایف طولانی‌مدت مانند جداسازی، سریال‌سازی و رندرینگ را متوقف کنید.

- [InterruptionTokenSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/) منبع توکن(های) پاس‑داده‌شده به [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setInterruptionToken) است.
- هنگامی که [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setInterruptionToken) فراخوانی می‌شود و نمونهٔ [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) پاس داده می‌شود، فراخوانی [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/#interrupt) هر وظیفهٔ طولانی‌مدتی که با آن [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) مرتبط است را متوقف می‌کند.

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # اقدام را در یک رشتهٔ جداگانه اجرا کنید.
    time.sleep(10)  # زمان‌انتظار.
    token_source.interrupt()  # تبدیل را متوقف کنید.
    conversion_task.result()
```

## **سوالات متداول**

**هدف کتابخانهٔ قطع Aspose.Slides چیست؟**

این مکانیزم برای قطع عملیات طولانی‌مدت—مانند بارگذاری، ذخیره‌سازی یا رندرینگ ارائه‌ها—قبل از اتمام آن‌ها فراهم می‌کند. این زمانی مفید است که زمان پردازش باید محدود شود یا وظیفه دیگر نیازی به آن ندارد.

**تفاوت بین [InterruptionToken](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/) چیست؟**

- [InterruptionToken](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontoken/) به API Aspose.Slides پاس داده می‌شود و در طول عملیات طولانی‌مدت بررسی می‌شود.
- [InterruptionTokenSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/) در کد شما برای ایجاد توکن‌ها و ایجاد قطع با فراخوانی [interrupt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/#interrupt) استفاده می‌شود.

**کدام وظایف می‌توانند قطع شوند؟**

هر وظیفهٔ Aspose.Slides که یک [InterruptionToken](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontoken/) می‌پذیرد—مانند بارگذاری یک ارائه با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) یا ذخیره‌سازی با [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save)—قابل قطع است.

**آیا قطع بلافاصله انجام می‌شود؟**

خیر. قطع به صورت تعاونی است: عملیات به‌صورت دوره‌ای توکن را بررسی می‌کند و به محض این که مشاهده کند [interrupt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/#interrupt) فراخوانی شده است، متوقف می‌شود.

**اگر پس از اتمام یک وظیفه، [interrupt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/#interrupt) را فراخوانی کنم چه اتفاقی می‌افتد؟**

هیچ‌چیز—اگر وظیفهٔ مربوطه قبلاً تمام شده باشد، فراخوانی اثری ندارد.

**آیا می‌توانم همان [InterruptionTokenSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/) را برای چندین وظیفه استفاده مجدد کنم؟**

بله—اما پس از فراخوانی [interrupt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/interruptiontokensource/#interrupt) بر روی آن منبع، تمام وظایفی که از توکن‌های آن استفاده می‌کنند قطع می‌شوند. برای مدیریت مستقل وظایف از منابع توکن جداگانه استفاده کنید.
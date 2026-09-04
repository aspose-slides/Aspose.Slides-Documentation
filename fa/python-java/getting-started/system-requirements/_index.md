---
title: نیازهای سیستم
type: docs
weight: 60
url: /fa/python-java/system-requirements/
keywords:
- نیازهای سیستم
- پایتون
- جاوا
- JPype
- ویندوز
- لینوکس
- macOS
- Aspose.Slides
description: "بررسی الزامات سیستم عامل، پایتون، جاوا و JPype برای اجرای Aspose.Slides for Python via Java روی ویندوز، لینوکس و macOS."
---
## **بررسی کلی**

Aspose.Slides for Python via Java ارائه‌ها را ایجاد، ویرایش، تبدیل و رندر می‌کند بدون نیاز به نصب Microsoft PowerPoint. این ابزار از JPype برای دسترسی به کتابخانهٔ Java از Python استفاده می‌کند، بنابراین محیط باید همزمان از Python، Java و JPype پشتیبانی کند.

## **سیستم‌عامل‌های پشتیبانی‌شده**

پکیج [Aspose.Slides](https://pypi.org/project/aspose-slides-java/) زیر مجموعه‌های سیستم‌عامل زیر را پشتیبانی می‌کند:

- ویندوز
- لینوکس
- macOS

نسخهٔ سیستم‌عامل را متناسب با نسخه‌های انتخابی Python، Java و JPype خود انتخاب کنید. صرفاً در دسترس بودن Java کافی نیست تا سازگاری با پکیج Python و پل آن را تضمین کند.

## **پیش‌نیازهای Python، Java و JPype**

| Component | Requirement |
| --- | --- |
| Python | پکیج Aspose.Slides پشتیبانی از Python نسخه ۳.۷ تا ۳.۱۴ را اعلام می‌کند. نسخهٔ انتخابی JPype باید همان نسخهٔ Python را پشتیبانی کند؛ برای مثال، [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) نیاز به Python ۳.۸ یا بالاتر دارد. |
| Java | یک محیط اجرایی Java یا JDK سازگار با نسخهٔ انتخابی JPype نصب کنید. [پیش‌نیازهای JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) بیان می‌کند که Java ۱۱ یا بالاتر مورد نیاز است. Java 8 نمی‌تواند JPype1 1.7.1 را اجرا کند. |
| JPype | پکیج JPype1 را برای مفسر Python، سیستم‌عامل و معماری CPU خود نصب کنید. |
| CPU architecture | معمارى CPU: Python و ماشین مجازی Java (JVM) باید معماری‌های یکسانی داشته باشند. برای مثال، یک مفسر Python ۶۴‑بیتی به یک JVM ۶۴‑بیتی سازگار نیاز دارد. |

در Apple Silicon، Python و Java باید هر دو از ARM64 یا هر دو از x64 استفاده کنند. JVMی که به‌صورت مستقل اجرا می‌شود همچنان ممکن است هنگام بارگذاری از طریق JPype شکست بخورد اگر معماری‌اش با معماری Python متفاوت باشد.

برای یک محیط جدید، Python ۳.۱۲، JDK ۱۷ و JPype1 1.7.1 نقطهٔ شروع مناسبی هستند. این ترکیب با Aspose.Slides for Python via Java نسخه ۲۶.۶.۰ روی ویندوز تأیید شده است. ترکیب‌های دیگر باید نیازمندی‌های هر سه مؤلفه را برآورده کنند.

برای تنظیم محیط و یک مثال تأیید کارکرد، ببینید [نصب](/slides/fa/python-java/installation/).

## **وابستگی‌های اضافی**

یک wheel پیش‌ساختهٔ سازگار JPype نیازی به کامپایلر C++ ندارد. اگر JPype باید از منبع ساخته شود، یک کامپایلر C++ سازگار و فایل‌های توسعه Python مورد نیاز پلتفرم خود را نصب کنید. برای نیازمندی‌های ساخت و عیب‌یابی به [دستورالعمل‌های نصب JPype](https://jpype.readthedocs.io/en/latest/install.html) مراجعه کنید.

## **پرسش‌های متداول**

**آیا نیاز به نصب Microsoft PowerPoint دارم؟**

خیر. Aspose.Slides ارائه‌ها را به‌صورت مستقل از PowerPoint پردازش می‌کند. همچنان Python، Java و JPype مورد نیاز هستند.

**آیا می‌توانم Python 3.7 را با هر نسخهٔ JPype استفاده کنم؟**

خیر. اگرچه پکیج Aspose.Slides پشتیبانی از Python 3.7 را اعلام می‌کند، JPype1 1.7.1 به Python 3.8 یا بالاتر نیاز دارد. نسخه‌هایی را انتخاب کنید که نیازمندی‌هایشان با هم همپوشانی دارد.

**آیا می‌توانم Python 32‑بیتی را با Java 64‑بیتی ترکیب کنم؟**

خیر. JPype JVM را در فرایند Python بارگذاری می‌کند، بنابراین Python و Java باید معماری‌های یکسانی داشته باشند. همین الزامات برای ARM64 و x64 در macOS نیز صادق است.
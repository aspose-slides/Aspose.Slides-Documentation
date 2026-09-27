---
title: نصب
type: docs
weight: 70
url: /fa/python-java/installation/
keywords:
- دریافت Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- Python
- Java
- JPype
- ویندوز
- macOS
- لینوکس
description: "Aspose.Slides برای Python از طریق Java را در Windows، Linux یا macOS نصب کنید، Java و JPype را پیکربندی کنید، و با یک مثال عملی تنظیمات را تأیید نمایید."
---
Aspose.Slides برای Python از طریق Java بر روی Windows، Linux و macOS اجرا می‌شود. این کتابخانه از JPype برای دسترسی به کتابخانه Java از Python استفاده می‌کند. نیازی به Microsoft PowerPoint نیست.

## **پیش‌نیازها**

قبل از نصب بسته‌های Python، Python و JDKی که با [System Requirements](/slides/fa/python-java/system-requirements/) مطابقت دارند نصب کنید. آن صفحه نسخه‌های سازگار، نیازهای معماری و هر وابستگی لازم برای ساخت JPype از منبع را فهرست می‌کند.

`JAVA_HOME` را به مسیر نصب JDK تنظیم کنید، نه زیر پوشه `bin` آن، و پوشه `bin` JDK را به `PATH` اضافه کنید. پس از تغییر متغیرهای محیطی، یک ترمینال جدید باز کنید.

## **نصب از PyPI**

دستورات زیر را در یک ترمینال اجرا کنید، نه در خط فرمان تعاملی Python. یک پوشه پروژه و یک محیط مجازی ایجاد کنید تا بسته‌ها از سایر پروژه‌ها جدا بمانند.

### **ویندوز**

اگر مفسر Python انتخابی شما به عنوان `python` در `PATH` موجود باشد، دستورات زیر را در Command Prompt اجرا کنید:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux و macOS**

اگر نسخه Python انتخابی شما به عنوان `python3` در دسترس باشد، دستورات زیر را در Bash یا zsh اجرا کنید:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

در Debian یا Ubuntu، اگر ایجاد محیط به دلیل عدم وجود `ensurepip` شکست خورد، بسته `python3-venv` را با `sudo apt-get install python3-venv` نصب کنید و سپس فرمان ایجاد محیط را دوباره اجرا کنید. ممکن است نسخهٔ جداگانهٔ Python نیاز به بستهٔ `venv` متناسب با نسخه‌اش داشته باشد.

### **نصب بسته‌ها**

در حالی که محیط مجازی فعال است، JPype و Aspose.Slides را نصب کنید:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

استفاده از `python -m pip` تضمین می‌کند که بسته‌ها برای مفسری که برنامه‌تان با آن اجرا می‌شود نصب شوند.

برای به‌روزرسانی نصب موجود Aspose.Slides، `python -m pip install --upgrade aspose-slides-java` را در همان محیط اجرا کنید.

## **نصب از بایگانی ZIP**

همچنین می‌توانید کتابخانه را از [Aspose.Slides downloads page](https://releases.aspose.com/slides/python-java/) دریافت کنید:

1. Python و Java را همان‌طور که در [پیش‌نیازها](#prerequisites) توضیح داده شد نصب کنید.
2. یک محیط مجازی ایجاد و فعال کنید با استفاده از دستورالعمل‌های بالا.
3. JPype را با `python -m pip install JPype1` نصب کنید.
4. بایگانی ZIP Aspose.Slides برای Python از طریق Java را دانلود و استخراج کنید.
5. پوشهٔ استخراج‌شدهٔ `asposeslides` را پیدا کنید. محتویات آن شامل پوشهٔ `lib` و فایل JAR را همراه هم نگه دارید.
6. `example.py` را از بخش بعدی در کنار پوشهٔ `asposeslides` قرار دهید تا Python بتواند بسته را ایمپورت کند. این بایگانی از قبل یک `example.py` خود دارد؛ آن را با کد زیر جایگزین کنید.

## **بررسی نصب**

کد زیر را به عنوان `example.py` ذخیره کنید. این کد یک ارائه با یک جعبه متن ایجاد می‌کند و به‌عنوان `out.pptx` در پوشهٔ کاری فعلی ذخیره می‌شود.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

در حالی که محیط مجازی فعال است، مثال را از پوشه‌ای که `example.py` در آن قرار دارد اجرا کنید:

```sh
python example.py
```

ایمپورت `asposeslides` کتابخانهٔ Java بسته‌بندی‌شده را قبل از شروع JVM ثبت می‌کند. پس از راه‌اندازی JVM، `asposeslides.api` را ایمپورت کنید و قبل از خاموش کردن JVM، منابع ارائه را آزاد کنید.

{{% alert color="info" title="Note" %}}
بدون لایسنس، خروجی شامل واترمارک ارزیابی می‌شود. برای محدودیت‌های ارزیابی و اطلاعات لایسنس موقت به [Evaluate Aspose.Slides](/slides/fa/python-java/evaluate-aspose-slides/) مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**چرا Python گزارش می‌دهد که JVM یافت نمی‌شود یا قابل بارگذاری نیست؟**

اطمینان حاصل کنید که `JAVA_HOME` به JDKی اشاره دارد که با Python و JPime شما سازگار است، همان‌طور که در [System Requirements](/slides/fa/python-java/system-requirements/) توضیح داده شده است. برای بررسی‌های بیشتر راهنمای عیب‌یابی نصب JPype را در [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) ببینید.

**چرا پس از نصب Python گزارش می‌دهد که `asposeslides` موجود نیست؟**

ممکن است بسته برای مفسر Python دیگری نصب شده باشد. محیط مجازی که برای نصب استفاده کردید را فعال کنید و `python -m pip show aspose-slides-java` را اجرا کنید. برای نصب از ZIP، اطمینان حاصل کنید که پوشهٔ `asposeslides` در کنار اسکریپت شما یا در مسیر جستجوی ماژول‌های Python قرار داشته باشد.

**آیا می‌توانم مثال را به‌صورت مکرر در یک نوت‌بوک اجرا کنم؟**

این مثال برای یک فرآیند Python مستقل در نظر گرفته شده است. پیش از سازگار کردن آن برای اجرای مکرر در نوت‌بوک، به [Limitations and API Differences](/slides/fa/python-java/limitations-and-api-differences/#import-the-library) برای چرخهٔ حیات JVM و راهنمایی‌های نوت‌بوک مراجعه کنید.

**چرا pip با خطای `CERTIFICATE_VERIFY_FAILED` شکست می‌خورد؟**

اگر شبکهٔ شما از یک پروکسی بازرسی HTTPS استفاده می‌کند، pip باید به مرجع گواهی آن اعتماد کند. با استفاده از گزینهٔ `--cert` در pip یا متغیر محیطی `PIP_CERT` بستهٔ CA مورد اعتماد را پیکربندی کنید؛ برای جزئیات به [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/) مراجعه کنید. پیکربندی مورد نیاز به شبکه و نسخهٔ pip شما بستگی دارد.
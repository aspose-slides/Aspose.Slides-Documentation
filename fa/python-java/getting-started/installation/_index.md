---
title: نصب
type: docs
weight: 70
url: /fa/python-java/installation/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- پایتون
- جاوا
- JPype
- ویندوز
- macOS
- لینوکس
description: "Aspose.Slides برای Python از طریق Java را بر روی Windows، Linux یا macOS نصب کنید، Java و JPype را پیکربندی کنید و تنظیمات را با یک مثال عملی تأیید نمایید."
---
Aspose.Slides برای Python از طریق Java بر روی Windows، Linux و macOS اجرا می‌شود. این کتابخانه از JPype برای دسترسی به کتابخانه Java از طریق Python استفاده می‌کند. Microsoft PowerPoint نیازی نیست.

## **پیش‌نیازها**

قبل از نصب بسته‌های Python، Python و JDKی که مطابق [System Requirements](/slides/fa/python-java/system-requirements/) باشد را نصب کنید. آن صفحه نسخه‌های سازگار، نیازمندی‌های معماری و هر وابستگی لازم برای ساخت JPype از منبع را فهرست می‌کند.

`JAVA_HOME` را به مسیر نصب JDK (نه زیرپوشه `bin` آن) تنظیم کنید و پوشه `bin` JDK را به `PATH` اضافه نمایید. پس از تغییر متغیرهای محیطی، یک ترمینال جدید باز کنید.

## **نصب از PyPI**

دستورات زیر را در یک ترمینال اجرا کنید، نه در خط تعاملی Python. یک پوشه پروژه و یک محیط مجازی ایجاد کنید تا بسته‌ها از سایر پروژه‌ها جدا بمانند.

### **Windows**

با این فرض که مفسر Python انتخابی شما به عنوان `python` در `PATH` موجود است، دستورات زیر را در Command Prompt اجرا کنید:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux و macOS**

با این فرض که نسخه Python انتخابی شما به عنوان `python3` موجود است، دستورات زیر را در Bash یا zsh اجرا کنید:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

در Debian یا Ubuntu، اگر ایجاد محیط به دلیل عدم وجود `ensurepip` با شکست مواجه شد، بسته `python3-venv` را با `sudo apt-get install python3-venv` نصب کنید و سپس دستور ایجاد محیط را مجدداً اجرا کنید. ممکن است نسخهٔ جداگانهٔ Python نیاز به بستهٔ `venv` مخصوص به نسخهٔ خود داشته باشد.

### **نصب بسته‌ها**

با فعال بودن محیط مجازی، JPype و Aspose.Slides را نصب کنید:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

استفاده از `python -m pip` تضمین می‌کند که بسته‌ها برای مفسری نصب شوند که برنامهٔ شما با آن اجرا می‌شود.

برای به‌روزرسانی نصب موجود Aspose.Slides، همان دستور زیر را در همان محیط اجرا کنید: `python -m pip install --upgrade aspose-slides-java`.

## **نصب از بایگانی ZIP**

همچنین می‌توانید کتابخانه را از [صفحه دانلود Aspose.Slides]https://releases.aspose.com/slides/fa/python-java/ دریافت کنید:

1. Python و Java را همان‌طور که در [پیش‌نیازها](#prerequisites) توضیح داده شد، نصب کنید.
2. یک محیط مجازی ایجاد و فعال کنید همان‌طور که در بالا شرح داده شد.
3. JPype را با `python -m pip install JPype1` نصب کنید.
4. بایگانی ZIP Aspose.Slides برای Python از طریق Java را دانلود و استخراج کنید.
5. پوشهٔ پکیج استخراج‌شدهٔ `asposeslides` را پیدا کنید. محتویات آن شامل پوشهٔ `lib` و فایل JAR را دست‌نخورده نگه دارید.
6. فایل `example.py` از بخش بعدی را در کنار پوشهٔ `asposeslides` قرار دهید تا Python بتواند پکیج را ایمپورت کند.

## **تأیید نصب**

کد زیر را به اسم `example.py` ذخیره کنید. این کد یک ارائه با یک جعبه متن ایجاد می‌کند و آن را به‌صورت `out.pptx` در پوشهٔ کاری جاری ذخیره می‌نماید.

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

با فعال بودن محیط مجازی، مثال را از پوشه‌ای که `example.py` در آن قرار دارد اجرا کنید:

```sh
python example.py
```

ایمپورت `asposeslides` قبل از راه‌اندازی JVM کتابخانهٔ Java را بارگیری می‌کند. پس از شروع JVM، `asposeslides.api` را ایمپورت کنید و قبل از خاموش کردن JVM منابع ارائه را آزاد کنید.

{{% alert color="info" title="Note" %}}
بدون داشتن لایسنس، خروجی شامل یک واترمارک ارزیابی خواهد بود. برای محدودیت‌های ارزیابی و اطلاعات مربوط به لایسنس موقت به [Evaluate Aspose.Slides](/slides/fa/python-java/evaluate-aspose-slides/) مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**چرا Python گزارش می‌دهد که JVM پیدا یا بارگذاری نمی‌شود؟**

اطمینان حاصل کنید که `JAVA_HOME` به یک JDK سازگار با نصب Python و JPype شما اشاره دارد، همان‌طور که در [System Requirements](/slides/fa/python-java/system-requirements/) توضیح داده شده است. برای بررسی‌های بیشتر به [راهنمای رفع مشکل نصب JPype]https://jpype.readthedocs.io/en/latest/install.html مراجعه کنید.

**چرا Python پس از نصب گزارش می‌دهد که `asposeslides` موجود نیست؟**

ممکن است بسته برای مفسر Python دیگری نصب شده باشد. محیط مجازی‌ای که برای نصب استفاده کردید را فعال کنید و دستور `python -m pip show aspose-slides-java` را اجرا کنید. برای نصب از طریق ZIP، اطمینان حاصل کنید که پوشهٔ `asposeslides` در کنار اسکریپت شما یا در مسیر جستجوی ماژول‌های Python قرار دارد.

**آیا می‌توانم مثال را به‌صورت مکرر در یک نوت‌بوک اجرا کنم؟**

این مثال برای یک فرآیند مستقل Python طراحی شده است. پیش از استفادهٔ مکرر در نوت‌بوک، به [محدودیت‌ها و تفاوت‌های API](/slides/fa/python-java/limitations-and-api-differences/#import-the-library) برای چرخهٔ حیات JVM و راهنمایی‌های مربوط به نوت‌بوک مراجعه کنید.

**چرا pip با خطای `CERTIFICATE_VERIFY_FAILED` ناموفق می‌شود؟**

اگر شبکهٔ شما از یک پروکسی بازرسی HTTPS استفاده می‌کند، pip باید گواهی مرجع آن را بپذیرفت. بسته به شبکه و نسخهٔ pip، با استفاده از گزینهٔ `--cert` در pip یا متغیر محیطی `PIP_CERT` پیوند گواهی مورد اعتماد را پیکربندی کنید؛ برای جزئیات به [دستورات گواهی HTTPS pip]https://pip.pypa.io/en/stable/topics/https-certificates/ مراجعه کنید.
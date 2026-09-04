---
title: محدودیت‌ها و تفاوت‌های API
type: docs
weight: 100
url: /fa/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides برای Python از طریق Java
- تفاوت‌های API
- پایتون
- جاوا
- JPype
- محدودیت‌های JVM
- پاورپوینت
description: "درباره محدودیت‌های JVM و تفاوت‌های API بین Aspose.Slides برای Java و Python از طریق Java، شامل واردات، پاکسازی منابع و مدیریت فایل‌ها بیاموزید."
---
## **مروری کلی**

Aspose.Slides برای Python از طریق Java از JPype برای دسترسی به کتابخانه Java از Python استفاده می‌کند. مثال‌های زیر واردات بسته‌ها، ایجاد ارائه و مدیریت فایل‌ها را در دو API مقایسه می‌کنند.

## **محدودیت‌های شناخته شده**

- **JVM lifecycle:** JPype یک JVM برای هر فرآیند Python پشتیبانی می‌کند. پس از خاموش کردن آن، نمی‌توانید در همان فرآیند دوباره آن را راه‌اندازی کنید. یک‌بار آن را راه‌اندازی کنید و برای عملیات‌های ارائه بعدی مجدداً استفاده کنید.
- **Architecture compatibility:** پایتون و جاوا باید معماری‌های سازگار داشته باشند. برای جزئیات به [System Requirements](/slides/fa/python-java/system-requirements/#python-java-and-jpype-requirements) مراجعه کنید.

برای جزئیات درباره این محدودیت‌ها و تعامل با Java، راهنمای کاربری [JPype User Guide](https://jpype.readthedocs.io/en/latest/userguide.html) را ببینید.

## **تفاوت‌های API عمومی**

مثال‌های Java و Python زیر را مقایسه کنید. برای جزئیات اعضا در Python از طریق Java، به [API Reference](/slides/fa/python-java/api-reference/) مراجعه کنید.

### **وارد کردن کتابخانه**

Java کلاس‌ها را از `com.aspose.slides` وارد می‌کند. در Python، قبل از شروع JVM `asposeslides` را وارد کنید، سپس پس از اجرای JVM کلاس‌ها را از `asposeslides.api` وارد کنید. برای جلوگیری از راه‌اندازی مجدد JVM فعال از [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) استفاده کنید.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
مثال‌های Python JVM را تا زمان خروجی فرآیند Python روشن نگه می‌دارند. در یک نوت‌بوک، JVM فعال را در بین سلول‌ها مجدداً استفاده کنید. اگر قبلاً خاموش شده باشد، قبل از استفاده دوباره از اشیای Java هسته نوت‌بوک را مجدداً راه‌اندازی کنید.
{{% /alert %}}

### **ایجاد ارائه**

Java از کلیدواژه `new` استفاده می‌کند؛ Python مستقیماً کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را فراخوانی می‌کند. منابع ارائه را در یک بلوک `finally` با [Presentation.dispose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#dispose) آزاد کنید.

هر دو مثال یک ارائه خالی را با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) و [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#pptx) ذخیره می‌کنند.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **خواندن فایل‌ها و استفاده از ثابت‌های قالب**

Java می‌تواند یک ارائه را از یک جریان ورودی Java بارگذاری کند. در Python، فایل را به‌صورت باینری می‌خوانید و بایت‌های حاصل را به [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#createpresentationfrombytes) پاس می‌دهید. یک شیء فایل Python یک جریان ورودی Java نیست.

مثال‌های زیر به یک فایل `presentation.pptx` موجود در پوشه کاری نیاز دارند و یک کپی به نام `result.pptx` ذخیره می‌کنند. هر دو فایل ورودی را می‌بندند و منابع ارائه را آزاد می‌کنند. مثال Python کل فایل ورودی را به‌صورت کامل در حافظه می‌خواند.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا برای هر ارائه باید JVM را مجدداً راه‌اندازی کنم؟**

نه. JVM را روشن نگه دارید و در صورت نیاز اشیای ارائه را ایجاد و حذف کنید. خاموش کردن JVM عملیات‌های Java بعدی را در همان فرآیند Python غیرممکن می‌سازد.

**آیا می‌توانم یک ارائه را مستقیماً از مسیر فایل باز کنم؟**

بله. سازنده [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) می‌تواند مسیر فایل را دریافت کند. وقتی داده‌های ارائه به‌صورت بایت در دسترس باشد، از روش کمکی بیتی استفاده کنید.

**آیا هنگام ترجمه مثال‌های Java به Python باید نام ثابت‌های قالب را تغییر دهم؟**

نه. برای مثال، [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#pptx) در هر دو API به همان نوشتار و حروف بزرگ/کوچک استفاده می‌شود.
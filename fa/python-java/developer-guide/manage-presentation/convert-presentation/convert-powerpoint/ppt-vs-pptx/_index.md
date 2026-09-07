---
title: "درک تفاوت: PPT در مقابل PPTX"
linktitle: PPT در مقابل PPTX
type: docs
weight: 10
url: /fa/python-java/ppt-vs-pptx/
keywords:
- PPT در مقابل PPTX
- PPT یا PPTX
- فرمت قدیمی
- فرمت مدرن
- فرمت باینری
- Office Open XML
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "قابلیت مقایسهٔ فرمت‌های PPT و PPTX، سازگاری و گزینه‌های تبدیل با Aspose.Slides برای Python از طریق Java، به همراه یک مثال کد Python."
---
## **مروری کلی**

PPT و PPTX فرمت‌های ارائه PowerPoint هستند که ساختارهای داخلی و پشتیبانی ویژگی‌های متفاوتی دارند. PPT فرمت باینری قدیمی است که توسط PowerPoint 97–2003 استفاده می‌شود. PPTX فرمت Office Open XML است که با PowerPoint 2007 معرفی شد. این مقاله فرمت‌ها را مقایسه می‌کند و نشان می‌دهد چگونه یک فایل PPT را به PPTX با Aspose.Slides برای Python از طریق Java تبدیل کنید.

## **PPT چیست؟**

[PPT](https://docs.fileformat.com/presentation/ppt/) داده‌های ارائه را در یک ساختار باینری ذخیره می‌کند. خواندن یا تغییر محتوای آن نیاز به نرم‌افزاری دارد که این ساختار را درک کند. PPT زمانی مفید است که فایل‌ها را با نسخه‌های قدیمی PowerPoint مبادله می‌کنید، اما توانایی آن در نمایش ویژگی‌های جدید ارائه محدود است.

## **PPTX چیست؟**

[PPTX](https://docs.fileformat.com/presentation/pptx/) بر پایه Office Open XML ساخته شده است. یک فایل PPTX یک بسته ZIP حاوی بخش‌های XML، رسانه‌ها و روابط بین این بخش‌ها است. این ساختار باعث می‌شود فرمت نسبت به PPT باینری راحت‌تر بررسی و گسترش یابد. PowerPoint از PowerPoint 2007 به بعد از PPTX به عنوان فرمت پیش‌فرض ارائه خود استفاده می‌کند.

## **PPT در مقابل PPTX**

| جنبه | PPT | PPTX |
| --- | --- | --- |
| ساختار داخلی | رکوردهای باینری | بسته ZIP شامل XML و رسانه |
| نیازمندی سازگاری معمولی | جریان‌های کاری PowerPoint 97–2003 | جریان‌های کاری PowerPoint 2007 به بعد |
| ویژگی‌های جدید ارائه | پشتیبانی محدود؛ ممکن است برخی محتواها ساده‌سازی شوند | پشتیبانی گسترده‌تر برای اشیاء و اثرات جدید |
| استفاده پیشنهادی | مبادله با سیستم‌هایی که به PPT نیاز دارند | ارائه‌های جدید و ویرایش مداوم |

تبدیل بین فرمت‌ها بیش از تغییر پسوند فایل است. برخی ویژگی‌های PPTX معادل مستقیم در PPT ندارند. PowerPoint می‌تواند اطلاعات اضافی را در رکوردهای خاص PPT مانند داده‌های MetroBlob ذخیره کند تا محتویات جدید را برای استفاده بعدی حفظ کند. نسخه‌های قدیمی PowerPoint نمی‌توانند تمام این محتوا را نمایش دهند، بنابراین ذخیره‌سازی آن تضمین نمی‌کند که ارائه در هر نمایشگر همانند یا رفتار مشابهی داشته باشد.

Aspose.Slides for Python via Java یک API مشترک برای بارگذاری و ذخیره هر دو فرمت فراهم می‌کند. این کتابخانه از تبدیل در هر دو جهت پشتیبانی می‌کند، اما تفاوت‌های فرمت و ویژگی‌های پشتیبانی‌نشده می‌توانند بر نتیجه تاثیر بگذارند. در صورت امکان از PPTX استفاده کنید و ارائه‌های تبدیل شده به PPT را در نمایشگر موردنظر بررسی کنید.

{{% alert color="info" title="Note" %}}

برای مقایسه نتایج تبدیل PPT به PPTX و PPTX به PPT به صورت آنلاین، برنامه [Aspose.Slides Conversion app](https://products.aspose.app/slides/fa/conversion/) را امتحان کنید.

{{% /alert %}}

## **تبدیل PPT به PPTX در Python**

فایل PPT را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) و پارامتر [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) آن را ذخیره کنید. نیاز به Microsoft PowerPoint نیست.

مثال در صورت نیاز ماشین مجازی Java را آغاز می‌کند و منابع ارائه را در بلاک `finally` آزاد می‌سازد. مسیرهای ورودی و خروجی را با نام‌های فایل خود جایگزین کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# بارگذاری ارائه PPT قدیمی.
presentation = Presentation("presentation.ppt")
try:
    # ذخیرهٔ ارائه در فرمت PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای مثال‌های بیشتر، به [Convert PPT to PPTX in Python](/slides/fa/python-java/convert-ppt-to-pptx/) مراجعه کنید. برای تبدیل معکوس و ملاحظات سازگاری آن، به [Convert PPTX to PPT in Python](/slides/fa/python-java/convert-pptx-to-ppt/) نگاه کنید.

## **سوالات متداول**

**آیا دلیل خاصی برای نگه‌داشتن ارائه‌های قدیمی در PPT وجود دارد اگر بدون خطا باز می‌شوند؟**

می‌توانید PPT را نگه دارید وقتی یک جریان کاری موجود به آن نیاز دارد. برای ویرایش مداوم و ویژگی‌های جدید، تبدیل به PPTX را در نظر بگیرید. اصل را تا زمان بررسی ارائه تبدیل‌شده حفظ کنید.

**کدام ارائه‌ها را باید ابتدا به PPTX تبدیل کنم؟**

فایل‌هایی که به‌طور مکرر ویرایش یا به اشتراک گذاشته می‌شوند، شامل نمودارهای پیچیده [charts](/slides/fa/python-java/create-chart/) یا [shapes](/slides/fa/python-java/shape-manipulations/) هستند، یا هنگام [opened](/slides/fa/python-java/open-presentation/) هشدارهای سازگاری ایجاد می‌کنند را در اولویت قرار دهید. پس از تبدیل، ظاهر و رفتار نمایش اسلاید آنها را بررسی کنید.

**آیا حفاظت با رمز عبور هنگام تبدیل بین PPT و PPTX حفظ می‌شود؟**

نفرض نکنید که حفاظت خروجی به طور خودکار با منبع مطابقت داشته باشد. هنگام بارگذاری فایل رمزگذاری‌شده، رمز عبور مورد نیاز را فراهم کنید، حفاظت خروجی را به صورت صریح تنظیم کنید و فایل ذخیره‌شده را بررسی کنید. برای جزئیات به [Password-Protected Presentations](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید.

**چرا برخی اثرها هنگام تبدیل PPTX به PPT ناپدید می‌شوند یا ساده می‌شوند؟**

PPT نمی‌تواند هر شیء، ویژگی یا اثر جدید را نمایش دهد. برخی از اطلاعات ممکن است برای بازگردانی بعدی محفوظ بماند، اما نمایشگرهای قدیمی نمی‌توانند همه آن را نشان دهند. در صورتی که نیاز به حفظ ویژگی‌های جدید دارید، اصل PPTX را نگه دارید.
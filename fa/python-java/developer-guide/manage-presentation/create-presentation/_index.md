---
title: ایجاد ارائه‌ها در پایتون از طریق جاوا
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/python-java/create-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- ایجاد PPT
- PPT جدید
- ایجاد PPTX
- PPTX جدید
- ایجاد ODP
- ODP جدید
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد ارائه‌ها در پایتون از طریق جاوا با Aspose.Slides — تولید فایل‌های PPT، PPTX و ODP، بهره‌مندی از پشتیبانی OpenDocument و ذخیره برنامه‌نویسی‌شدهٔ آن‌ها برای نتایج قابل‌اعتماد."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه می‌توانید با Aspose.Slides for Python via Java یک ارائه بسازید، شکل متنی به اسلاید اول اضافه کنید و نتیجه را به صورت فایل PPTX ذخیره کنید. بخش پرسش‌های متداول شامل قالب‌های خروجی، قالب‌ها، اندازه اسلاید، مصرف حافظه، چندنخی بودن، لایسنس، امضای دیجیتال و پشتیبانی از VBA است.

پیش از شروع، Python، JDK، JPype و Aspose.Slides for Python via Java را نصب کنید. برای مراحل نصب در ویندوز، لینوکس و macOS به [Installation](/slides/fa/python-java/installation/) مراجعه کنید.

## **ایجاد یک ارائه**

ساخت یک فایل PowerPoint از ابتدا در Aspose.Slides for Python via Java به آسانیِ نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) است. سازنده به‌طور خودکار یک دک خالی با یک اسلاید می‌سازد و بوم فوری برای اضافه‌کردن شکل‌ها، متن، نمودارها یا هر محتوای دیگری که برنامه‌تان نیاز دارد، فراهم می‌کند. پس از تغییر آن اسلاید یا افزودن اسلایدهای جدید می‌توانید نتیجه را به PPTX، PPT قدیمی یا حتی قالب‌های OpenDocument ذخیره کنید. نمونه کد کوتاه زیر این فرآیند را با افزودن یک شکل ساده به اسلاید اول نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. اسلاید اول را با شاخص 0 دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) از نوع [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) با استفاده از [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) اضافه کنید.
1. متن شکل را با [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText) تنظیم کنید.
1. ارائه را با [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) و [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) ذخیره کنید.

مثال زیر JVM را در صورت عدم اجرا راه‌اندازی می‌کند، یک شکل ابری با متن به اسلاید اول اضافه می‌کند و ارائه را ذخیره می‌نماید. آن را به نام *create_presentation.py* ذخیره کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# یک ارائه با یک اسلاید خالی ایجاد کنید.
presentation = Presentation()
try:
    # اسلاید اول را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)

    # یک شکل ابری اضافه کنید و متن آن را تنظیم کنید.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اسکریپٹ را در محیطی که بسته‌ها را نصب کرده‌اید اجرا کنید:

```sh
python create_presentation.py
```

گوشه بالای چپ ابر 20 نقطه از لبه‌های چپ و بالا اسلاید فاصله دارد و ابعاد ابر 200 نقطه عرض و 80 نقطه ارتفاع است. اسکریپت *new_presentation.pptx* را در پوشهٔ کاری فعلی ذخیره می‌کند، با یک اسلاید که شامل ابر و متن آن است. JVM تا خروجی پردازش Python فعال می‌ماند؛ برای جزئیات به [Limitations and API Differences](/slides/fa/python-java/limitations-and-api-differences/#import-the-library) مراجعه کنید. بدون لایسنس، Aspose.Slides یک جعبه متن علامت آب‌نشان ارزیابی را به هر اسلاید ذخیره‌شده اضافه می‌کند؛ برای اطلاعات بیشتر به [Licensing](/slides/fa/python-java/licensing/) نگاه کنید.

نتیجه:

![نمایش جدید](new_presentation.png)

## **پرسش‌های متداول**

**چه قالب‌هایی می‌توانم برای ذخیرهٔ یک ارائه جدید استفاده کنم؟**

می‌توانید به [PPTX، PPT و ODP](/slides/fa/python-java/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/python-java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)، [SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/) و [تصاویر](/slides/fa/python-java/convert-powerpoint-to-png/) صادر کنید.

**آیا می‌توانم از یک قالب (POTX/POTM) شروع کنم و به صورت PPTX معمولی ذخیره کنم؟**

بله. قالب را بارگیری کنید و به قالب دلخواه ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و مشابه آن‌ها [پشتیبانی می‌شوند](/slides/fa/python-java/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت تصویر اسلاید را هنگام ایجاد ارائه کنترل کنم؟**

[اندازهٔ اسلاید](/slides/fa/python-java/slide-size/) را تنظیم کنید (از پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد دلخواه) و نحوهٔ مقیاس‌بندی محتوا را انتخاب کنید.

**اندازه‌ها و مختصات به چه واحدی اندازه‌گیری می‌شوند؟**

به نقطه: 1 اینچ برابر 72 نقطه است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (با فایل‌های رسانه‌ای زیاد) را برای کاهش مصرف حافظه بهینه کنم؟**

از [استراتژی‌های مدیریت BLOB](/slides/fa/python-java/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و جریان‌های مبتنی بر فایل را نسبت به جریان‌های صرفاً در‑حافظه ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید به همان نمونهٔ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) از [چندین نخ](/slides/fa/python-java/multithreading/) دسترسی داشته باشید. برای هر نخ یا پردازش یک نمونهٔ جداگانه ایجاد کنید.

**چگونه می‌توانم علامت آب‌نشان آزمایشی و محدودیت‌ها را حذف کنم؟**

یک بار برای هر فرآیند [لایسنس اعمال کنید](/slides/fa/python-java/licensing/). فایل XML لایسنس باید دست‌نخورده بماند و تنظیم لایسنس در صورت استفاده از چندین نخ همگام‌سازی شود.

**آیا می‌توانم PPTX ایجادشده را دیجیتally امضا کنم؟**

بله. [امضاهای دیجیتال](/slides/fa/python-java/digital-signature-in-powerpoint/) (اضافه و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

**آیا ماکروها (VBA) در ارائه‌های ساخته‌شده پشتیبانی می‌شوند؟**

بله. می‌توانید [پروژه‌های VBA را ایجاد/ویرایش](/slides/fa/python-java/presentation-via-vba/) کنید و فایل‌های فعال‌سازی‌دار مانند PPTM/PPSM را ذخیره کنید.
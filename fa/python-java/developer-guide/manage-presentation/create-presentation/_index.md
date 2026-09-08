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
description: "ایجاد ارائه‌ها در پایتون از طریق جاوا با Aspose.Slides — تولید فایل‌های PPT، PPTX و ODP، بهره‌مندی از پشتیبانی OpenDocument و ذخیره برنامه‌ای آن‌ها برای نتایج قابل اطمینان."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه یک ارائه با Aspose.Slides for Python via Java ایجاد کنید، یک شکل حاوی متن به اولین اسلاید اضافه کنید و نتیجه را به صورت فایل PPTX ذخیره کنید. سؤالات متداول شامل فرمت‌های خروجی، الگوها، اندازه اسلاید، مصرف حافظه، چندنخی شدن، لایسنس، امضای دیجیتال و پشتیبانی از VBA می‌شود.

## **ایجاد یک ارائه**

ایجاد یک فایل PowerPoint از ابتدا در Aspose.Slides for Python via Java به سادگی نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) است. سازنده به‌طور خودکار یک دک خالی با یک اسلاید ارائه می‌دهد که بلافاصله می‌توانید برای اضافه کردن شکل‌ها، متن، نمودارها یا هر محتوای دیگری که برنامه‌تان نیاز دارد، استفاده کنید. پس از ویرایش آن اسلاید یا افزودن اسلایدهای جدید، می‌توانید نتیجه را به فرمت‌های PPTX، PPT قدیمی یا حتی OpenDocument ذخیره کنید. نمونه کد کوتاه زیر این جریان کار را با افزودن یک شکل ساده به اولین اسلاید نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. اولین اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) از نوع [ShapeType.Cloud](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/#Cloud) با استفاده از [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) اضافه کنید.
1. متن شکل را با استفاده از [TextFrame.setText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#setText) تنظیم کنید.
1. ارائه را با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) و [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) ذخیره کنید.

مثال زیر به Aspose.Slides for Python via Java و یک Runtime جاوا سازگار نیاز دارد. اگر JVM در حال اجرا نباشد آن را راه‌اندازی می‌کند، یک شکل ابری به اولین اسلاید اضافه می‌کند و ارائه را ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# یک ارائه با یک اسلاید خالی ایجاد کنید.
presentation = Presentation()
try:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)

    # یک شکل ابری اضافه کنید و متن آن را تنظیم کنید.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![ارائه جدید](new_presentation.png)

## **سؤالات متداول**

**چه فرمت‌هایی می‌توانم یک ارائه جدید را در آن ذخیره کنم؟**

می‌توانید به [PPTX, PPT, and ODP](/slides/fa/python-java/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/python-java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)، [SVG](/slides/fa/python-java/render-slide-as-svg/) و [images](/slides/fa/python-java/convert-powerpoint-to-png/) صادر کنید، و غیره.

**آیا می‌توانم از یک الگو (POTX/POTM) شروع کرده و به عنوان PPTX عادی ذخیره کنم؟**

بله. الگو را بارگذاری کنید و به فرمت موردنظر ذخیره کنید؛ فرمت‌های POTX/POTM/PPTM و مشابه آن‌ها [پشتیبانی می‌شوند](/slides/fa/python-java/supported-file-formats/).

**چگونه می‌توانم هنگام ایجاد ارائه، اندازه/نسبت ابعاد اسلاید را کنترل کنم؟**

[slide size](/slides/fa/python-java/slide-size/) را تنظیم کنید (از جمله پیش‌فرض‌های 4:3 و 16:9 یا ابعاد سفارشی) و نحوه مقیاس‌گذاری محتوا را انتخاب کنید.

**اندازه‌ها و مختصات بر حسب چه واحدی اندازه‌گیری می‌شوند؟**

بر حسب نقطه: 1 اینچ برابر 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (با فایل‌های رسانه‌ای زیاد) را برای کاهش مصرف حافظه مدیریت کنم؟**

از [BLOB management strategies](/slides/fa/python-java/manage-blob/) استفاده کنید، ذخیره‌سازی در‑حافظه را با استفاده از فایل‌های موقت محدود کنید و نسبت به جریان‌های صرفاً در‑حافظه، گردش کار مبتنی بر فایل را ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را از [multiple threads](/slides/fa/python-java/multithreading/) استفاده کنید. برای هر رشته یا فرآیند یک نمونهٔ جداگانه ایجاد کنید.

**چگونه واترمارک نسخه آزمایشی و محدودیت‌ها را حذف کنم؟**

یک بار در هر فرآیند [Apply a license](/slides/fa/python-java/licensing/) کنید. XML لایسنس باید دست‌نخورده بماند و تنظیم لایسنس در صورت وجود چندین رشته باید همگام‌سازی شود.

**آیا می‌توانم PPTX ایجاد شده را به صورت دیجیتالی امضا کنم؟**

بله. [Digital signatures](/slides/fa/python-java/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

**آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟**

بله. می‌توانید [create/edit VBA projects](/slides/fa/python-java/presentation-via-vba/) کنید و فایل‌های دارای ماکرو مانند PPTM/PPSM را ذخیره نمایید.
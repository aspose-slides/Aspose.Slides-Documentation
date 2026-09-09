---
title: ایجاد ارائه‌ها در Python از طریق Java
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
- پاورپوینت
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد ارائه‌ها در Python از طریق Java با Aspose.Slides—تولید فایل‌های PPT، PPTX و ODP، بهره‌مندی از پشتیبانی OpenDocument و ذخیره برنامه‌نویسی‌شده آن‌ها برای نتایج قابل‌اعتماد."
---
## **بررسی کلی**

این مقاله نشان می‌دهد که چگونه یک ارائه با Aspose.Slides برای Python از طریق Java ایجاد کنید، یک شکل با متن به اولین اسلاید اضافه کنید و نتیجه را به صورت فایل PPTX ذخیره کنید. بخش سوالات متداول، فرمت‌های خروجی، الگوها، اندازه‌گیری اسلاید، مصرف حافظه، رشته‌سازی، مجوزها، امضای دیجیتال و پشتیبانی VBA را پوشش می‌دهد.

## **ایجاد یک ارائه**

ایجاد یک فایل PowerPoint از ابتدا در Aspose.Slides برای Python از طریق Java به سادگی ساخت یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) است. سازنده به طور خودکار یک دک خالی با یک اسلاید واحد فراهم می‌کند که بلافاصله بستر برای شکل‌ها، متن، نمودارها یا هر محتوای دیگری که برنامه‌تان نیاز دارد، می‌شود. پس از آنکه این اسلاید را تغییر دادید—یا اسلایدهای جدیدی افزودید—می‌توانید نتیجه را به فرمت‌های PPTX، PPT قدیمی یا حتی OpenDocument ذخیره کنید. مثال کوتاه کد زیر این جریان کاری را با افزودن یک شکل ساده به اولین اسلاید نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اولین اسلاید را بر اساس ایندکس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) از نوع [ShapeType.Cloud](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/#Cloud) با استفاده از [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) اضافه کنید.
4. متن شکل را با استفاده از [TextFrame.setText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#setText) تنظیم کنید.
5. ارائه را با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) به همراه [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) ذخیره کنید.

مثال زیر به Aspose.Slides برای Python از طریق Java و یک زمان‌اجرای Java سازگار نیاز دارد. اگر JVM در حال اجرا نباشد، آن را راه‌اندازی می‌کند، یک شکل ابر به اولین اسلاید اضافه می‌کند و ارائه را ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# ایجاد یک ارائه با یک اسلاید خالی.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل ابر و تنظیم متن آن.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # ذخیره ارائه به عنوان فایل PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![ارائه جدید](new_presentation.png)

## **سوالات متداول**

**کدام فرمت‌ها را می‌توانم برای ذخیره یک ارائه جدید استفاده کنم؟**

می‌توانید به فرمت‌های [PPTX، PPT و ODP](/slides/fa/python-java/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/python-java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)، [SVG](/slides/fa/python-java/render-slide-as-svg/) و [تصاویر](/slides/fa/python-java/convert-powerpoint-to-png/) صادرات کنید، و غیره.

**آیا می‌توانم از یک قالب (POTX/POTM) شروع کنم و به‌عنوان یک PPTX معمولی ذخیره کنم؟**

بله. قالب را بارگذاری کنید و به فرمت مورد نظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و فرمت‌های مشابه [پشتیبانی می‌شوند](/slides/fa/python-java/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت ابعاد اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟**

اندازه [اسلاید](/slides/fa/python-java/slide-size/) را تنظیم کنید (از جمله پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد سفارشی) و انتخاب کنید که محتوای چطور مقیاس‌بندی شود.

**واحدهای اندازه‌ها و مختصات به چه صورت‌اند؟**

بر حسب پوینت: 1 اینچ معادل 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (با تعداد زیادی فایل رسانه) را برای کاهش مصرف حافظه مدیریت کنم؟**

از [استراتژی‌های مدیریت BLOB](/slides/fa/python-java/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و ترجیحاً روندهای مبتنی بر فایل را به جریان‌های کاملاً در حافظه ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید بر روی همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) از [چندین رشته](/slides/fa/python-java/multithreading/) کار کنید. برای هر رشته یا فرآیند، نمونه‌های جدا و ایزوله اجرا کنید.

**چگونه می‌توانم واترمارک و محدودیت‌های نسخه آزمایشی را حذف کنم؟**

[یک لایسنس اعمال کنید](/slides/fa/python-java/licensing/) یک بار برای هر فرآیند. XML لایسنس باید دست‌نخورده بماند و تنظیم لایسنس در صورت حضور چندین رشته باید همگام‌سازی شود.

**آیا می‌توانم PPTX تولید شده را به‌صورت دیجیتالی امضا کنم؟**

بله. [امضاهای دیجیتال](/slides/fa/python-java/digital-signature-in-powerpoint/) (افزودن و تأیید) برای ارائه‌ها پشتیبانی می‌شوند.

**آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟**

بله. می‌توانید [پروژه‌های VBA را ایجاد/ویرایش](/slides/fa/python-java/presentation-via-vba/) کنید و فایل‌های فعال‌ماکرو مانند PPTM/PPSM را ذخیره کنید.
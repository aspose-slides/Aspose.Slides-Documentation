---
title: تغییر اندازه اسلاید ارائه در Python از طریق Java
linktitle: اندازه اسلاید
type: docs
weight: 70
url: /fa/python-java/slide-size/
keywords:
- اندازه اسلاید
- نسبت تصویر
- استاندارد
- صفحه عریض
- 4:3
- 16:9
- تنظیم اندازه اسلاید
- تغییر اندازه اسلاید
- اندازه سفارشی اسلاید
- اندازه خاص اسلاید
- اندازه منحصر به فرد اسلاید
- اسلاید تمام‌صفحه
- نوع صفحه‌نمایش
- بدون مقیاس‌بندی
- اطمینان از متناسب بودن
- بیشینه‌سازی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه به سرعت اسلایدها را در فایل‌های PPT، PPTX و ODP با Python از طریق Java و Aspose.Slides تغییر اندازه دهید و ارائه‌ها را برای هر نمایشگر بهینه کنید بدون از دست دادن کیفیت."
---
## **معرفی**

Aspose.Slides ابزارهای جامع برای تنظیم اندازه اسلاید و نسبت تصویر در ارائه‌های PowerPoint فراهم می‌کند که برای چاپ و نمایش روی صفحه نمایش حیاتی است.

اندازه‌ها و نسبت‌های محبوب اسلاید:

- **استاندارد (نسبت تصویر 4:3)**: مناسب برای صفحه‌نمایش‌ها و دستگاه‌های قدیمی.
- **صفحه عریض (نسبت تصویر 16:9)**: توصیه شده برای پروژکتورهای مدرن و نمایشگرها.

از یکسان بودن تمام اسلایدها در ارائه خود اطمینان حاصل کنید زیرا یک اندازه اسلاید و نسبت تصویر برای همه اسلایدها اعمال می‌شود. برای نتایج بهینه، ابعاد اسلاید خود را در ابتدای فرآیند ایجاد ارائه تنظیم کنید تا از بروز مشکلات جلوگیری شود.

{{% alert color="info" title="نکته" %}}
به‌طور پیش‌فرض، ارائه‌های ایجاد شده با Aspose.Slides از نسبت تصویر استاندارد 4:3 استفاده می‌کنند.
{{% /alert %}}

## **تغییر اندازه اسلاید در ارائه‌ها**

این کد نمونه نشان می‌دهد چگونه می‌توانید اندازه اسلاید را در یک ارائه با Python از طریق Java با استفاده از Aspose.Slides تغییر دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مشخص کردن اندازه‌های سفارشی اسلاید در ارائه‌ها**

اگر اندازه‌های رایج اسلاید (4:3 و 16:9) برای کار شما مناسب نباشند، ممکن است تصمیم بگیرید از یک اندازه اسلاید خاص یا منحصربه‌فرد استفاده کنید. به‌عنوان مثال، اگر قصد دارید اسلایدهای کامل‌سایز را از ارائه خود بر روی یک قالب صفحه سفارشی چاپ کنید یا ارائه خود را بر روی انواع خاصی از صفحه‌نمایش‌ها نمایش دهید، احتمالاً از تنظیم اندازه سفارشی برای ارائه خود بهره‌مند خواهید شد.

این کد نمونه نشان می‌دهد چگونه می‌توانید با Aspose.Slides برای Python از طریق Java، یک اندازه سفارشی برای اسلاید یک ارائه تعیین کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مدیریت محتوای اسلاید پس از تغییر اندازه**

بعد از تغییر اندازه اسلاید برای یک ارائه، محتوای اسلایدها (مثلاً تصاویر یا اشیاء) ممکن است دچار تخریب شوند. به‌طور پیش‌فرض، اشیاء به‌صورت خودکار برای متناسب شدن با اندازه جدید اسلاید تغییر اندازه می‌یابند. با این حال، هنگام تغییر اندازه اسلاید یک ارائه، می‌توانید تنظیمی را مشخص کنید که تعیین می‌کند Aspose.Slides چگونه با محتویات اسلایدها برخورد کند.

بسته به آنچه می‌خواهید انجام یا دستیابی کنید، می‌توانید از هر یک از این تنظیمات استفاده کنید:

- [DoNotScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  اگر نمی‌خواهید اشیاء روی اسلایدها تغییر اندازه یابند، از این تنظیم استفاده کنید.

- [EnsureFit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  اگر می‌خواهید به یک اندازه اسلاید کوچک‌تر مقیاس دهید و نیاز دارید Aspose.Slides اشیاء اسلایدها را کوچک کند تا همه آنها در اسلاید قرار بگیرند (به این ترتیب از از دست رفتن محتوا جلوگیری می‌کنید)، از این تنظیم استفاده کنید.

- [Maximize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#Maximize)

  اگر می‌خواهید به یک اندازه اسلاید بزرگ‌تر مقیاس دهید و نیاز دارید Aspose.Slides اشیاء اسلایدها را بزرگ کند تا متناسب با اندازه جدید اسلاید شوند، از این تنظیم استفاده کنید.

این کد نمونه نشان می‌دهد چگونه می‌توانید تنظیم [Maximize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#Maximize) را هنگام تغییر اندازه اسلاید یک ارائه استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**آیا می‌توانم اندازه سفارشی اسلاید را با واحدهای دیگری جز اینچ (مثلاً نقاط یا میلی‌متر) تنظیم کنم؟**

بله. Aspose.Slides به‌صورت داخلی از نقاط استفاده می‌کند که 1 نقطه برابر 1/72 اینچ است. می‌توانید هر واحدی (مانند میلی‌متر یا سانتی‌متر) را به نقاط تبدیل کنید و از مقادیر تبدیل‌شده برای تعریف عرض و ارتفاع اسلاید استفاده کنید.

**آیا یک اندازه سفارشی بسیار بزرگ اسلاید بر عملکرد و مصرف حافظه در هنگام رندرینگ تأثیر می‌گذارد؟**

بله. ابعاد بزرگ‌تر اسلاید (به نقاط) همراه با مقیاس رندرینگ بالاتر منجر به مصرف بیشتر حافظه و زمان پردازش طولانی‌تر می‌شود. سعی کنید به یک اندازه عملی برای اسلاید برسید و مقیاس رندرینگ را فقط در صورت نیاز برای دستیابی به کیفیت خروجی مطلوب تنظیم کنید.

**آیا می‌توانم یک اندازه اسلاید غیر استاندارد تعریف کنم و سپس اسلایدها را از ارائه‌هایی که اندازه‌های متفاوتی دارند ترکیب کنم؟**

نمی‌توانید [merge presentations](/slides/fa/python-java/merge-presentation/) را در حالی که اندازه‌های اسلاید متفاوت دارند انجام دهید — ابتدا یک ارائه را برای مطابقت با دیگری تغییر اندازه دهید. هنگام تغییر اندازه اسلاید، می‌توانید نحوهٔ مدیریت محتویات موجود را از طریق گزینه [SlideSizeScaleType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/) انتخاب کنید. پس از هماهنگ کردن اندازه‌ها، می‌توانید اسلایدها را ترکیب کنید در حالی که قالب‌بندی حفظ می‌شود.

**آیا می‌توانم برای اشکال جداگانه یا بخش‌های خاصی از اسلاید تصاویری کوچک (thumbnail) تولید کنم و آیا این تصاویر اندازه جدید اسلاید را رعایت می‌کنند؟**

بله. Aspose.Slides می‌تواند تصاویر کوچک برای [entire slides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) و همچنین برای [selected shapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) تولید کند. تصاویر حاصل اندازه و نسبت تصویر فعلی اسلاید را نشان می‌دهند و اطمینان می‌بخشند که قاب‌بندی و هندسه به‌درستی حفظ شده است.
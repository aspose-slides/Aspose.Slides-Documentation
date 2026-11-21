---
title: تغییر اندازه اسلاید ارائه در پایتون از طریق جاوا
linktitle: اندازه اسلاید
type: docs
weight: 70
url: /fa/python-java/slide-size/
keywords:
- اندازه اسلاید
- نسبت تصویر
- استاندارد
- صفحه‌پهن
- 4:3
- 16:9
- تنظیم اندازه اسلاید
- تغییر اندازه اسلاید
- اندازه اسلاید سفارشی
- اندازه اسلاید خاص
- اندازه اسلاید منحصر به فرد
- اسلاید تمام‌سایز
- نوع صفحه‌نمایش
- بدون مقیاس
- تضمین سازگاری
- حداکثرسازی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "بیاموزید چگونه به‌سرعت اسلایدها را در فایل‌های PPT، PPTX و ODP با استفاده از پایتون از طریق جاوا و Aspose.Slides تغییر اندازه دهید و ارائه‌ها را برای هر صفحه‌نمایشی بدون افت کیفیت بهینه کنید."
---
## **مقدمه**

Aspose.Slides ابزارهای کاملی برای تنظیم اندازه اسلاید و نسبت تصویر در ارائه‌های PowerPoint فراهم می‌کند که برای چاپ و نمایش روی صفحه نمایش اهمیت دارد.

اندازه‌ها و نسبت‌های رایج اسلاید:

- **استاندارد (نسبت تصویر 4:3)**: ایده‌آل برای صفحه‌نمایش‌ها و دستگاه‌های قدیمی.
- **واسع‌صفحه (نسبت تصویر 16:9)**: برای پروژکتورها و نمایشگرهای مدرن توصیه می‌شود.

سازگاری را در سراسر ارائه خود حفظ کنید زیرا یک اندازه اسلاید و نسبت تصویر واحد برای تمام اسلایدها اعمال می‌شود. برای نتایج بهینه، ابعاد اسلاید خود را در ابتدای فرآیند ایجاد ارائه تنظیم کنید تا از بروز مشکلات جلوگیری شود.

{{% alert color="info" title="Note" %}}
به‌صورت پیش‌فرض، ارائه‌های ایجاد شده با Aspose.Slides از نسبت تصویر استاندارد 4:3 استفاده می‌کنند.
{{% /alert %}}

صفحات یادداشت و صفحه‌های طرح‌برگ ابعاد جداگانه‌ای نسبت به اسلایدهای عادی دارند. برای تغییر اندازه و جهت‌گیری آن‌ها به [اندازه صفحه یادداشت](/slides/fa/python-java/notes-size/) مراجعه کنید.

## **تغییر اندازه اسلاید در ارائه‌ها**

این نمونه کد نشان می‌دهد چگونه می‌توانید اندازه اسلاید را در یک ارائه با استفاده از Python via Java و Aspose.Slides تغییر دهید:

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

اگر اندازه‌های رایج اسلاید (4:3 و 16:9) برای کار شما مناسب نیستند، می‌توانید از یک اندازه اسلاید خاص یا منحصر به فرد استفاده کنید. برای نمونه، اگر قصد چاپ اسلایدهای تمام‑سایز از ارائه خود بر روی قالب صفحه سفارشی را دارید یا می‌خواهید ارائه را بر روی انواع خاصی از صفحه‌نمایش‌ها نشان دهید، احتمالاً استفاده از تنظیم اندازه سفارشی برای ارائه‌تان مفید خواهد بود.

این نمونه کد نشان می‌دهد چگونه می‌توانید با Aspose.Slides for Python via Java یک اندازه اسلاید سفارشی برای یک ارائه مشخص کنید:

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

پس از تغییر اندازه اسلاید برای یک ارائه، محتوای اسلایدها (مانند تصاویر یا اشیاء) ممکن است دچار اعوجاج شوند. به‌صورت پیش‌فرض، اشیاء به‌طور خودکار برای سازگار شدن با اندازه جدید اسلاید تغییر اندازه می‌یابند. با این حال، هنگام تغییر اندازه اسلاید ارائه، می‌توانید تنظیمی را مشخص کنید که تعیین می‌کند Aspose.Slides چگونه با محتوای اسلایدها رفتار کند.

با توجه به هدف شما، می‌توانید از هر یک از این تنظیمات استفاده کنید:

- [DoNotScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  اگر نمی‌خواهید اشیاء روی اسلایدها تغییر اندازه دهند، از این تنظیم استفاده کنید.

- [EnsureFit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  اگر می‌خواهید به اندازه اسلاید کوچکتر مقیاس دهید و نیاز دارید Aspose.Slides اشیاء اسلایدها را کوچک کند تا همه روی اسلایدها جای بگیرند (به این ترتیب از از دست رفتن محتوا جلوگیری می‌شود)، از این تنظیم استفاده کنید.

- [Maximize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#Maximize)

  اگر می‌خواهید به اندازه اسلاید بزرگتر مقیاس دهید و نیاز دارید Aspose.Slides اشیاء اسلایدها را بزرگ‌تر کند تا نسبت به اندازه جدید اسلاید متناسب شوند، از این تنظیم استفاده کنید.

این نمونه کد نشان می‌دهد چگونه می‌توانید از تنظیم [Maximize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/#Maximize) هنگام تغییر اندازه اسلایدهای یک ارائه استفاده کنید:

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

**آیا می‌توانم اندازه اسلاید سفارشی را با واحدهای دیگری غیر از اینچ (مثلاً نقاط یا میلی‌متر) تنظیم کنم؟**

بله. Aspose.Slides به‌صورت داخلی از نقاط استفاده می‌کند که 1 نقطه برابر 1/72 اینچ است. می‌توانید هر واحدی (مانند میلی‌متر یا سانتی‌متر) را به نقاط تبدیل کنید و از مقادیر تبدیل‌شده برای تعریف عرض و ارتفاع اسلاید استفاده کنید.

**آیا اندازه اسلاید سفارشی بسیار بزرگ بر عملکرد و مصرف حافظه در هنگام رندرینگ تأثیر می‌گذارد؟**

بله. ابعاد بزرگ‌تر اسلاید (به نقاط) همراه با مقیاس رندرینگ بالاتر منجر به مصرف حافظه بیشتر و زمان پردازش طولانی‌تر می‌شود. سعی کنید اندازه اسلایدی عملی انتخاب کنید و مقیاس رندرینگ را فقط در صورت نیاز برای دستیابی به کیفیت خروجی موردنظر تنظیم کنید.

**آیا می‌توانم یک اندازه اسلاید غیراستاندارد تعریف کنم و سپس اسلایدها را از ارائه‌هایی که اندازه‌های متفاوتی دارند ترکیب کنم؟**

نمی‌توانید [ارائه‌ها را ترکیب کنید](/slides/fa/python-java/merge-presentation/) در حالی که اندازه اسلایدهای متفاوت داشته باشند — ابتدا یک ارائه را به اندازه دیگری تغییر اندازه دهید. هنگام تغییر اندازه اسلاید، می‌توانید نحوهٔ مدیریت محتوای موجود را از طریق گزینهٔ [SlideSizeScaleType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesizescaletype/) انتخاب کنید. پس از هم‌تراز کردن اندازه‌ها، می‌توانید اسلایدها را ترکیب کنید و قالب‌بندی را حفظ نمایید.

**آیا می‌توانم برای اشکال جداگانه یا نواحی خاصی از یک اسلاید تصویر کوچک (thumbnail) تولید کنم و آیا این تصاویر اندازه اسلاید جدید را رعایت می‌کنند؟**

بله. Aspose.Slides می‌تواند تصویرهای کوچک برای [تمام اسلایدها](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) و همچنین برای [اشکال منتخب](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) رندر کند. تصاویر تولید‌شده اندازه و نسبت تصویر فعلی اسلاید را بازتاب می‌دهند و چارچوب و هندسهٔ سازگار را تضمین می‌کنند.
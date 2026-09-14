---
title: حذف اسلایدها از ارائه‌ها در پایتون
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/python-java/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- حذف اسلاید
- حذف اسلاید استفاده‌نشده
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "به راحتی اسلایدها را از ارائه‌های پاورپوینت و OpenDocument با Aspose.Slides برای پایتون از طریق جاوا حذف کنید. مثال‌های کد واضح دریافت کنید و گردش کار خود را تقویت کنید."
---
## **مقدمه**

اگر یک اسلاید (یا محتوای آن) زائد شود، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را ارائه می‌دهد که [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) را در بر می‌گیرد، که مخزنی برای همه اسلایدهای یک ارائه است. با استفاده از یک مرجع یا شاخص برای یک شیء [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) شناخته‌شده، می‌توانید اسلایدی را که می‌خواهید حذف کنید، مشخص کنید.

## **حذف اسلاید با مرجع**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شناسه یا شاخص، مرجعی به اسلایدی که می‌خواهید حذف کنید به‌دست آورید.
3. اسلاید مرجع‌شده را از ارائه حذف کنید.
4. ارائه تغییر یافته را ذخیره کنید.

این کد پایتون نحوه حذف یک اسلاید از طریق مرجع آن را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
presentation = Presentation("demo.pptx")
try:
    # به یک اسلاید از طریق شاخص آن در مجموعه اسلایدها دسترسی پیدا کنید.
    slide = presentation.getSlides().get_Item(0)

    # اسلاید را از طریق مرجع آن حذف کنید.
    presentation.getSlides().remove(slide)

    # ارائه‌ی تغییر یافته را ذخیره کنید.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حذف اسلاید با شاخص**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید را از ارائه از طریق موقعیت شاخص آن حذف کنید.
3. ارائه تغییر یافته را ذخیره کنید.

این کد پایتون نحوه حذف یک اسلاید از طریق شاخص آن را نشان می‌دهد:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation می‌سازد که نمایانگر یک فایل ارائه است.
presentation = Presentation("demo.pptx")
try:
    # یک اسلاید را از طریق شاخص آن حذف کنید.
    presentation.getSlides().removeAt(0)

    # ارائه‌ی تغییر یافته را ذخیره کنید.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) (از کلاس [Compress](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/)) را ارائه می‌دهد تا بتوانید اسلایدهای طرح‌بندی ناخواسته و استفاده‌نشده را حذف کنید. این کد پایتون نشان می‌دهد چگونه یک اسلاید طرح‌بندی را از یک ارائه PowerPoint حذف کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حذف اسلایدهای مستر استفاده‌نشده**

Aspose.Slides متد [removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedMasterSlides) (از کلاس [Compress](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/)) را ارائه می‌دهد تا بتوانید اسلایدهای مستر ناخواسته و استفاده‌نشده را حذف کنید. این کد پایتون نشان می‌دهد چگونه یک اسلاید مستر را از یک ارائه PowerPoint حذف کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**چه اتفاقی برای شاخص‌های اسلاید پس از حذف یک اسلاید می‌افتد؟**

پس از حذف، [collection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) مجدداً شاخص‌بندی می‌شود: هر اسلاید بعدی یک موقعیت به سمت چپ جابه‌جا می‌شود، بنابراین شماره‌های شاخص قبلی منقضی می‌شوند. اگر به مرجع پایداری نیاز دارید، به‌جای شاخص، شناسهٔ پایدار هر اسلاید را استفاده کنید.

**آیا شناسهٔ اسلاید متفاوت از شاخص آن است و آیا هنگام حذف اسلایدهای همسایه تغییر می‌کند؟**

بله. شاخص موقعیت اسلاید است و هنگام افزودن یا حذف اسلایدها تغییر می‌کند. شناسهٔ اسلاید یک شناسهٔ پایدار است و وقتی اسلایدهای دیگر حذف می‌شوند، تغییر نمی‌کند.

**حذف یک اسلاید چه تأثیری بر بخش‌های اسلاید دارد؟**

اگر اسلاید در یک بخش قرار داشت، آن بخش به سادگی یک اسلاید کمتر خواهد داشت. ساختار بخش حفظ می‌شود؛ اگر بخشی خالی شد، می‌توانید [remove or reorganize sections](/slides/fa/python-java/slide-section/) را طبق نیاز انجام دهید.

**چه اتفاقی برای یادداشت‌ها و نظرات پیوست‌شده به یک اسلاید زمانی که حذف می‌شود می‌افتد؟**

[Notes](/slides/fa/python-java/presentation-notes/) و [comments](/slides/fa/python-java/presentation-comments/) به آن اسلاید خاص متصل هستند و همراه با آن حذف می‌شوند. محتوای اسلایدهای دیگر تحت تأثیر قرار نمی‌گیرد.

**حذف اسلایدها چه تفاوتی با پاک‌سازی طرح‌بندی‌ها/مسترهای استفاده‌نشده دارد؟**

حذف، اسلایدهای عادی خاصی را از مجموعه حذف می‌کند. پاک‌سازی طرح‌بندی‌ها/مسترهای استفاده‌نشده، اسلایدهای طرح‌بندی یا مستر را که هیچ‌کسی به آن‌ها ارجاع نمی‌دهد حذف می‌کند و بدون تغییر محتوای اسلایدهای باقی‌مانده، حجم فایل را کاهش می‌دهد. این دو عمل مکمل هستند: معمولاً ابتدا حذف می‌شود، سپس پاک‌سازی انجام می‌گیرد.
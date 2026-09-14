---
title: افزودن اسلایدها به ارائه‌ها در پایتون
linktitle: افزودن اسلاید
type: docs
weight: 10
url: /fa/python-java/add-slide-to-presentation/
keywords:
- افزودن اسلاید
- ایجاد اسلاید
- اسلاید خالی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "به راحتی با استفاده از Aspose.Slides برای Python via Java، اسلایدها را به ارائه‌های PowerPoint و OpenDocument خود اضافه کنید - درج اسلایدی بدون درز و کارآمد در چند ثانیه."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد اسلایدها را به ارائه‌های PowerPoint به‌صورت برنامه‌نویسی اضافه کنید. یک ارائه شامل اسلایدهای master/layout و اسلایدهای عادی است و اسلایدهای عادی بر اساس یک ایندکس صفرپایه ترتیب داده می‌شوند. هر اسلاید یک شناسه یکتا دارد و فایل‌های ارائه بدون اسلاید پشتیبانی نمی‌شوند.

این مقاله توضیح می‌دهد چگونه یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید، به مجموعه اسلایدهای آن دسترسی پیدا کنید، یک اسلاید خالی اضافه کنید، با اسلاید تازه اضافه شده کار کنید و ارائه به‌روزشده را ذخیره نمایید. همچنین نکات مرتبط مانند درج اسلایدها در موقعیت خاص، استفاده از لِیوت‌ها و درک اسلاید خالی که در یک ارائه تازه ایجاد شده وجود دارد را پوشش می‌دهد.

## **افزودن اسلاید به یک ارائه**

قبل از بحث در مورد نحوه افزودن اسلایدها به فایل‌های ارائه، اجازه دهید چند نکته در مورد اسلایدها را مرور کنیم. هر فایل ارائه PowerPoint شامل اسلایدهای **master/layout** و اسلایدهای **normal** است. یک فایل ارائه حداقل شامل یک اسلاید می‌باشد. فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for Python via Java پشتیبانی نمی‌شوند. هر اسلاید یک شناسه یکتا دارد و تمام اسلایدهای عادی بر اساس ترتیب مشخص شده توسط یک ایندکس صفرپایه مرتب می‌شوند.

Aspose.Slides for Python via Java به توسعه‌دهندگان امکان می‌دهد اسلایدهای خالی را به ارائه‌های خود اضافه کنند. برای افزودن یک اسلاید خالی به یک ارائه، این مراحل را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- با استفاده از متد [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) موجود در شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/)، یک مرجع به شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) دریافت کنید.
- با فراخوانی متد [addEmptySlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addEmptySlide) موجود در شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/)، یک اسلاید خالی به انتهای مجموعه اسلایدهای ارائه اضافه کنید.
- کارهایی را با اسلاید خالی تازه اضافه‌شده انجام دهید.
- در نهایت، فایل ارائه را با استفاده از شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بنویسید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation که فایل ارائه را نمایندگی می‌کند.
presentation = Presentation()
try:
    # دریافت مجموعه اسلایدها.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # یک اسلاید خالی به مجموعه اسلایدها اضافه کنید.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # عملیات‌خاصی بر روی اسلاید تازه اضافه‌شده انجام دهید.

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا می‌توانم یک اسلاید جدید را در موقعیت خاصی وارد کنم، نه فقط در انتها؟**

بله. کتابخانه از مجموعه‌های اسلاید و عملیات‌های [insert](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertClone) پشتیبانی می‌کند، بنابراین می‌توانید اسلاید را در ایندکس مورد نیاز اضافه کنید نه فقط در انتها.

**آیا تم/استایل‌ها هنگام افزودن اسلاید بر پایه یک لِیوت حفظ می‌شوند؟**

بله. یک لِیوت فرمت‌بندی را از master خود به ارث می‌برد و اسلاید جدید نیز از لِیوت انتخاب‌شده و master مرتبط آن ارث می‌برد.

**کدام اسلاید در یک ارائه جدید «خالی» قبل از افزودن اسلایدها وجود دارد؟**

یک ارائه تازه ایجاد شده از پیش شامل یک اسلاید خالی با ایندکس صفر است. این موضوع در محاسبه ایندکس‌های درج مهم است.

**چگونه می‌توانم لِیوت «مناسب» برای یک اسلاید جدید را انتخاب کنم اگر master گزینه‌های متعددی داشته باشد؟**

به طور کلی، [LayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/) که با ساختار مورد نیاز مطابقت دارد (مانند [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidelayouttype/)) انتخاب کنید. اگر چنین لِیوتی وجود نداشت، می‌توانید آن را به master اضافه کنید ([add it to the master](/slides/fa/python-java/slide-layout/)) و سپس از آن استفاده کنید.
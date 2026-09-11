---
title: "اشکال گروهی ارائه در پایتون از طریق جاوا"
linktitle: "گروه شکل"
type: docs
weight: 40
url: /fa/python-java/group/
keywords:
  - "شکل گروهی"
  - "گروه شکل‌ها"
  - "افزودن گروه"
  - "متن جایگزین"
  - "پاورپوینت"
  - "ارائه"
  - "پایتون"
  - "Aspose.Slides"
description: "یاد بگیرید چگونه اشکال را در مجموعه‌های پاورپوینت گروه‌بندی و جداسازی کنید با استفاده از Aspose.Slides برای پایتون از طریق جاوا—راهنمای گام به قدم با کد رایگان پایتون."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با اشکال گروهی در Aspose.Slides کار کنید. نشان می‌دهد چگونه یک شکل گروهی را به اسلاید اضافه کنید، اشکال را داخل آن قرار دهید و ارائه‌نامه به‌روز شده را ذخیره کنید. همچنین نشان می‌دهد چگونه به اشکال ذخیره‌شده در یک گروه دسترسی پیدا کنید و متن جایگزین آنها را با استفاده از [getAlternativeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getAlternativeText) بخوانید. علاوه بر این، مقاله به‌طور مختصر به قابلیت‌های مرتبط با اشکال گروهی مانند گروه‌های تو در تو، ترتیب Z و گزینه‌های قفل‌گذاری می‌پردازد.

## **افزودن یک شکل گروهی**

Aspose.Slides از کار با اشکال گروهی در اسلایدها پشتیبانی می‌کند. این ویژگی به توسعه‌دهندگان کمک می‌کند ارائه‌های غنی‌تری ایجاد کنند. Aspose.Slides برای Python از طریق Java امکان افزودن و دسترسی به اشکال گروهی را فراهم می‌کند. می‌توانید یک شکل گروهی را با اشکال پر کنید یا به ویژگی‌های آن دسترسی پیدا کنید. برای افزودن یک شکل گروهی به اسلاید با استفاده از Aspose.Slides برای Python از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
1. یک شکل گروهی به اسلاید اضافه کنید.
1. اشکال را به شکل گروهی اضافه کنید.
1. ارائه‌نامه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی را به اسلاید اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# نمونه‌سازی کلاس Presentation.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # دسترسی به مجموعه اشکال اسلاید.
    slide_shapes = slide.getShapes()

    # افزودن یک شکل گروهی به اسلاید.
    group_shape = slide_shapes.addGroupShape()

    # افزودن اشکال داخل شکل گروهی.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # تنظیم چارچوب شکل گروهی.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # نوشتن فایل PPTX به دیسک.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به متن جایگزین**

این بخش نشان می‌دهد چگونه به متن جایگزین اشکال داخل یک گروه در یک اسلاید دسترسی پیدا کنید. برای دسترسی به این متن با استفاده از Aspose.Slides برای Python از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) که نمایانگر یک فایل PPTX است، ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع بگیرید.
1. به مجموعه اشکال اسلاید دسترسی پیدا کنید.
1. به شکل گروهی دسترسی پیدا کنید.
1. متن جایگزین اشکال آن را با استفاده از [getAlternativeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getAlternativeText) بخوانید.

مثال زیر به متن جایگزین اشکال داخل یک گروه دسترسی پیدا می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است.
presentation = Presentation("AltText.pptx")
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # دسترسی به یک شکل در مجموعه اشکال اسلاید.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # دسترسی به اشکال داخل گروه.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # خواندن متن جایگزین.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**آیا گروه‌بندی تو در تو (یک گروه داخل گروه) پشتیبانی می‌شود؟**

بله. [GroupShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshape/) دارای متد [getParentGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getParentGroup) است که نشان‌دهنده پشتیبانی از سلسله‌مراتب است: یک گروه می‌تواند فرزند گروه دیگری باشد.

**چگونه می‌توانم ترتیب Z گروه را نسبت به سایر اشیاء در اسلاید کنترل کنم؟**

از متد [getZOrderPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getZOrderPosition) شیء [GroupShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshape/) استفاده کنید تا موقعیت آن را در پشته نمایش بررسی کنید.

**آیا می‌توانم از جابجا شدن، ویرایش یا تقسیم گروه جلوگیری کنم؟**

بله. قفل‌های گروه از طریق [getGroupShapeLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshape/#getGroupShapeLock) در دسترس هستند که به شما امکان می‌دهد عملیات روی شیء را محدود کنید.
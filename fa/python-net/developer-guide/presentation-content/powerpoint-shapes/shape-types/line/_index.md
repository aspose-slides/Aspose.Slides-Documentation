---
title: ایجاد شکل‌های خطی در ارائه‌ها با پایتون
linktitle: خط
type: docs
weight: 50
url: /fa/python-net/line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط‌چین
- سر پیکان
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET مدیریت کنید. ویژگی‌ها، متدها و مثال‌ها را کشف کنید."
---
## **بررسی اجمالی**

Aspose.Slides برای Python از طریق .NET از افزودن انواع مختلف شکل‌ها به اسلایدها پشتیبانی می‌کند. در این موضوع، کار با شکل‌ها را با افزودن خطوط به اسلایدها آغاز می‌کنیم. با استفاده از Aspose.Slides، توسعه‌دهندگان نه تنها می‌توانند خطوط ساده ایجاد کنند، بلکه می‌توانند خطوط زیبا نیز بر روی اسلایدها رسم کنند.

## **ایجاد خطوط ساده**

از Aspose.Slides برای افزودن یک خط ساده به اسلاید به عنوان جداکننده یا اتصال‌کننده استفاده کنید. برای افزودن یک خط ساده به اسلاید انتخاب‌شده در یک ارائه، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک مرجع به اسلاید بر اساس شاخص دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) از نوع `LINE` با استفاده از متد `add_auto_shape` بر روی شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) اضافه کنید.
4. ارائه را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک خط به اولین اسلاید ارائه اضافه می‌شود.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن auto shape از نوع LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # ذخیره ارائه به‌صورت فایل PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد خطوط شکل‌دار به شکل پیکان**

Aspose.Slides به شما امکان تنظیم ویژگی‌های خط را می‌دهد تا ظاهری جذاب‌تر داشته باشد. در ادامه، چند ویژگی از یک خط را تنظیم می‌کنیم تا شبیه یک پیکان شود. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک مرجع به اسلاید بر اساس شاخص دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) از نوع `LINE` با استفاده از متد `add_auto_shape` بر روی شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) اضافه کنید.
4. [سبک خط](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linestyle/) را تنظیم کنید.
5. عرض خط را تنظیم کنید.
6. [سبک خط‌چین](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linedashstyle/) خط را تنظیم کنید.
7. [سبک سرپیکان](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linearrowheadstyle/) و طول آن را برای نقطه شروع خط تنظیم کنید.
8. سبک سرپیکان و طول آن را برای نقطه انتهای خط تنظیم کنید.
9. ارائه را به صورت فایل PPTX ذخیره کنید.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است.
with slides.Presentation() as presentation:
    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن auto shape از نوع LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # اعمال قالب‌بندی به خط.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # ذخیره ارائه به‌صورت فایل PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا می‌توانم یک خط عادی را به یک اتصال‌کننده تبدیل کنم تا به شکل‌ها «چسبانبند» شود؟**

خیر. یک خط عادی (یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) از نوع [LINE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapetype/)) به‌طور خودکار تبدیل به اتصال‌کننده نمی‌شود. برای چسباندن آن به شکل‌ها، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/python-net/aspose.slides/connector/) و [APIهای مربوطه](/slides/fa/python-net/connector/) استفاده کنید.

**اگر ویژگی‌های یک خط از تم ارث‌بری شده باشد و تعیین مقادیر نهایی دشوار باشد، چه کار کنم؟**

[ویژگی‌های مؤثر را بخوانید](/slides/fa/python-net/shape-effective-properties/) از طریق کلاس‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ilinefillformateffectivedata/) — این کلاس‌ها پیشاپیش اثر ارث‌بری و سبک‌های تم را در نظر می‌گیرند.

**آیا می‌توانم یک خط را در برابر ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال [شیء‌های قفل](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/auto_shape_lock/) را فراهم می‌کنند که به شما اجازه می‌دهد [عملیات ویرایشی را غیرمجاز کنید](/slides/fa/python-net/applying-protection-to-presentation/).
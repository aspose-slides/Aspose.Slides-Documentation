---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint با استفاده از Python
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/python-net/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- ردیف اول
- سرصفحه جدول
- کلون ردیف
- کلون ستون
- کپی ردیف
- کپی ستون
- حذف ردیف
- حذف ستون
- قالب‌بندی متن ردیف
- قالب‌بندی متن ستون
- سبک جدول
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه ردیف‌ها و ستون‌های جدول را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python مدیریت کنید. خواهید آموخت چگونه ردیف یا ستونی را اضافه، وارد، کلون و حذف کنید، ردیف اول را به عنوان سرصفحه علامت‌گذاری کنید، اندازه و چیدمان را تنظیم کنید و قالب‌بندی متن و سبک را در سطح ردیف یا ستون اعمال کنید. هر کار با قطعات کد کوتاه و خودکفا بر پایهٔ API [جدول](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) نشان داده می‌شود تا بتوانید به سرعت جدولی را در اسلاید پیدا کنید و ساختار آن را مطابق طراحی خود بازسازی کنید.

## **تنظیم ردیف اول به عنوان سرصفحه**

ردیف اول جدول را به عنوان سرصفحه علامت‌گذاری کنید تا عناوین ستون‌ها به وضوح از داده‌ها متمایز شوند. در Aspose.Slides برای Python، کافی است گزینه *First Row* جدول را فعال کنید تا قالب‌بندی سرصفحه تعریف‌شده توسط سبک جدول انتخاب‌شده اعمال شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
1. اسلاید را بر اساس شاخص آن دسترسی پیدا کنید.
1. تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را مرور کنید تا جدول مربوطه را پیدا کنید.
1. ردیف اول جدول را به عنوان سرصفحه تنظیم کنید.

این کد Python نشان می‌دهد چگونه ردیف اول جدول را به عنوان سرصفحه تنظیم کنیم:

```python
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation.
with slides.Presentation("table.pptx") as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # در میان اشکال پیمایش کنید و مرجع جدول را دریافت کنید.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # ردیف اول جدول را به عنوان سرصفحه تنظیم کنید.
    table.first_row = True
    
    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون‌کردن ردیف یا ستون جدول**

هر ردیف یا ستونی از جدول را کلون کنید و کپی آن را در موقعیت دلخواه داخل جدول وارد کنید. نسخهٔ تکراری محتوا، قالب‌بندی و اندازه‌های سلول‌ها را حفظ می‌کند، بنابراین می‌توانید چیدمان‌ها را به سرعت و به‌صورت سازگار گسترش دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
1. اسلاید را بر اساس شاخص آن دسترسی پیدا کنید.
1. آرایه‌ای از عرض‌های ستون‌ها را تعریف کنید.
1. آرایه‌ای از ارتفاع‌های ردیف‌ها را تعریف کنید.
1. یک [جدول](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) به اسلاید اضافه کنید با `add_table(x, y, column_widths, row_heights)`.
1. یک ردیف جدول را کلون کنید.
1. یک ستون جدول را کلون کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک ردیف و یک ستون از جدول PowerPoint را کلون کنید:

```python
 import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation.
with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # افزودن جدول به اسلاید.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # افزودن متن به ردیف 1، ستون 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # افزودن متن به ردیف 2، ستون 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # کلون ردیف 1 در انتهای جدول.
    table.rows.add_clone(table.rows[0], False)

    # افزودن متن به ردیف 1، ستون 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # افزودن متن به ردیف 2، ستون 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # کلون ردیف 2 به عنوان ردیف 4 جدول.
    table.rows.insert_clone(3,table.rows[1], False)

    # کلون ستون اول در انتها.
    table.columns.add_clone(table.columns[0], False)

    # کلون ستون دوم در اندیس 3 (موقعیت 4).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # ذخیرهٔ ارائه بر روی دیسک.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف ردیف یا ستون از جدول**

با حذف هر ردیف یا ستونی بر پایهٔ شاخص، جدول را به‌صورت بهینه‌سازی‌شده ساده کنید؛ چیدمان به‌صورت خودکار تنظیم می‌شود در حالی که قالب‌بندی سلول‌های باقی‌مانده حفظ می‌شود. این کار برای ساده‌سازی شبکه‌های داده یا حذف مکان‌دارهای بدون نیاز به بازسازی جدول مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
1. اسلاید را بر اساس شاخص آن دسترسی پیدا کنید.
1. آرایه‌ای از عرض‌های ستون‌ها را تعریف کنید.
1. آرایه‌ای از ارتفاع‌های ردیف‌ها را تعریف کنید.
1. یک ITable به اسلاید اضافه کنید با `add_table(x, y, column_widths, row_heights)`.
1. ردیف جدول را حذف کنید.
1. ستون جدول را حذف کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد Python زیر نشان می‌دهد چگونه یک ردیف و یک ستون را از جدول حذف کنیم:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

قالب‌بندی متن یکسانی را برای تمام ردیف جدول در یک گام اعمال کنید. با Aspose.Slides برای Python می‌توانید خانوادهٔ قلم، اندازه، وزن، رنگ و تراز را برای تمام سلول‌های ردیف همزمان تنظیم کنید تا عناوین یا نوارهای داده‌ای یکنواخت بمانند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
1. اسلاید را بر اساس شاخص آن دسترسی پیدا کنید.
1. شیء [جدول](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) مربوطه را در اسلاید دسترسی پیدا کنید.
1. ارتفاع قلم را برای سلول‌های ردیف اول تنظیم کنید.
1. تراز و حاشیهٔ راست را برای سلول‌های ردیف اول تنظیم کنید.
1. نوع عمودی متن را برای سلول‌های ردیف دوم تنظیم کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد Python عملیات را نشان می‌دهد.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # ارتفاع قلم را برای سلول‌های ردیف اول تنظیم کنید.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # تراز متن و حاشیهٔ راست سلول‌های ردیف اول را تنظیم کنید.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # نوع عمودی متن سلول‌های ردیف دوم را تنظیم کنید.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

قالب‌بندی متن یکسانی را برای تمام ستون جدول به‌صورت یک‌جا اعمال کنید. با Aspose.Slides برای Python می‌توانید خانوادهٔ قلم، اندازه، وزن، رنگ و تراز را برای تمام سلول‌های یک ستون تنظیم کنید تا نوارهای عمودی یکنواخت برای عناوین یا داده‌ها ایجاد شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
1. اسلاید را بر اساس شاخص آن دسترسی پیدا کنید.
1. شیء [جدول](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) مربوطه را در اسلاید دسترسی پیدا کنید.
1. ارتفاع قلم را برای سلول‌های ستون اول تنظیم کنید.
1. تراز و حاشیهٔ راست را برای سلول‌های ستون اول تنظیم کنید.
1. نوع عمودی متن را برای سلول‌های ستون دوم تنظیم کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد Python زیر عملیات را نشان می‌دهد:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # ارتفاع قلم سلول‌های ستون اول را تنظیم کنید.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # تراز متن و حاشیهٔ راست سلول‌های ستون اول را تنظیم کنید.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # نوع عمودی متن سلول‌های ستون دوم را تنظیم کنید.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را استخراج کنید تا بتوانید آن‌ها را برای جدول دیگری یا در جاهای دیگر بازاستفاده کنید. کد Python زیر نحوهٔ دریافت ویژگی‌های سبک از یک سبک جدول پیش‌تنظیم‌شده را نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا می‌توانم تم‌ها/استایل‌های PowerPoint را به جدولی که قبلاً ایجاد شده است اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و همچنان می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را بر روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را همانند Excel مرتب کنم؟**

خیر، جدول‌های Aspose.Slides قابلیت مرتب‌سازی یا فیلتر داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید و سپس ردیف‌های جدول را به ترتیب جدید پر کنید.

**آیا می‌توانم ستون‌های نواردار (راه‌راه) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص نگه می‌دارم؟**

بله. نوارهای ستون را فعال کنید و سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول اولویت دارد نسبت به سبک جدول.
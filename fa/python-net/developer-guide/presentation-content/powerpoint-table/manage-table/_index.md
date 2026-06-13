---
title: مدیریت جداول ارائه با پایتون
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/python-net/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- تراز متن
- قالب‌بندی متن
- سبک جدول
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET. مثال‌های کد ساده‌ای را کشف کنید تا جریان کاری جداول خود را بهینه کنید."
---
## **مقدمه**

یک جدول در PowerPoint یک روش کارآمد برای ارائه اطلاعات است. اطلاعاتی که در قالب شبکه‌ای از سلول‌ها (ردیف و ستون) مرتب می‌شوند، ساده و آسان برای درک هستند.

Aspose.Slides کلاس‌های [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) و [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) و سایر انواع مرتبط را فراهم می‌کند تا بتوانید جداول را در هر ارائه‌ای ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جداول از ابتدا**

این بخش نشان می‌دهد چگونه یک جدول را از ابتدا در Aspose.Slides با افزودن یک شکل جدول به یک اسلاید، تعریف ردیف‌ها و ستون‌ها و تعیین اندازه‌های دقیق ایجاد کنید. همچنین خواهید دید چگونه سلول‌ها را با متن پر کنید، تنظیمات تراز و حاشیه‌ها را اعمال کنید و ظاهر جدول را سفارشی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجعی به اسلایدی بر اساس شاخص آن بگیرید.
3. آرایه‌ای از عرض‌های ستون‌ها تعریف کنید.
4. آرایه‌ای از ارتفاع‌های ردیف‌ها تعریف کنید.
5. یک [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) به اسلاید اضافه کنید.
6. بر هر [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) تکرار کنید و حاشیه‌های بالایی، پایینی، راست و چپ آن را قالب‌بندی کنید.
7. دو سلول اول را در ردیف اول جدول ادغام کنید.
8. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) یک [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) دسترسی پیدا کنید.
9. متن را به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
10. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال Python زیر نشان می‌دهد چگونه یک جدول در یک ارائه ایجاد شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

    # ایجاد یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
    with slides.Presentation() as presentation:
        # دسترسی به اولین اسلاید.
        slide = presentation.slides[0]

        # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
        column_widths = [50, 50, 50]
        row_heights = [50, 30, 30, 30, 30]

        # افزودن یک شکل جدول به اسلاید.
        table = slide.shapes.add_table(100, 50, column_widths, row_heights)

        # تنظیم قالب حاشیه برای هر سلول.
        for row in table.rows:
            for cell in row:
                cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
                cell.cell_format.border_top.width = 5

                cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
                cell.cell_format.border_bottom.width = 5

                cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
                cell.cell_format.border_left.width = 5

                cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
                cell.cell_format.border_right.width = 5
            
        # ادغام سلول‌ها از (ردیف ۰، ستون ۰) تا (ردیف ۱، ستون ۱).
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        # افزودن متن به سلول ادغام‌شده.
        table.rows[0][0].text_frame.text = "Merged Cells"

        # ذخیرهٔ ارائه در دیسک.
        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **شماره‌گذاری در جداول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها به‌راحتی و به‌صورت صفر-مبنا انجام می‌شود. اولین سلول در جدول به‌عنوان (0, 0) (ستون 0، ردیف 0) شماره‌گذاری می‌شود.

برای مثال، در جدولی با 4 ستون و 4 ردیف، سلول‌ها به‌صورت زیر شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

مثال Python زیر نشان می‌دهد چگونه با استفاده از این شماره‌گذاری صفر-مبنا به سلول‌ها ارجاع دهید:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **دسترسی به جدول موجود**

این بخش توضیح می‌دهد چگونه یک جدول موجود در یک ارائه را با استفاده از Aspose.Slides پیدا کنید و با آن کار کنید. خواهید آموخت چگونه جدول را در اسلاید پیدا کنید، به ردیف‌ها، ستون‌ها و سلول‌های آن دسترسی پیدا کنید و محتوا یا قالب‌بندی را به‌روزرسانی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجعی به اسلایدی که جدول را شامل می‌شود بر اساس شاخص آن بگیرید.
3. تمام اشیای [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را پیمایش کنید تا جدول را پیدا کنید.
4. از شیء [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) برای کار با جدول استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

{{% alert color="info" %}}
اگر اسلاید شامل چند جدول باشد، بهتر است جدول مورد نیاز خود را با ویژگی `alternative_text` جستجو کنید.
{{% /alert %}}

مثال Python زیر نشان می‌دهد چگونه به یک جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation را برای بارگذاری فایل PPTX ایجاد کنید.
with slides.Presentation("sample.pptx") as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    table = None

    # بر شکل‌ها تکرار کنید و به اولین جدولی که پیدا می‌شود ارجاع دهید.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # متن اولین سلول در اولین ردیف را تنظیم کنید.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # ارائهٔ اصلاح‌شده را در دیسک ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تراز متن در جداول**

این بخش نشان می‌دهد چگونه با استفاده از Aspose.Slides تراز متن داخل سلول‌های جدول را کنترل کنید. خواهید آموخت چگونه تراز افقی و عمودی سلول‌ها را تنظیم کنید تا محتوا واضح و سازگار باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجعی به اسلاید بر اساس شاخص آن بگیرید.
3. یک شیء [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) به اسلاید اضافه کنید.
4. یک شیء [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) از جدول دسترسی پیدا کنید.
5. متن را به‌صورت عمودی تراز کنید.
6. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال Python زیر نشان می‌دهد چگونه متن را در یک جدول تراز کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # افزودن یک شکل جدول به اسلاید.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # متن را در وسط قرار دهید و جهت عمودی را تنظیم کنید.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # ارائه را در دیسک ذخیره کنید.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب‌بندی متن در سطح جدول**

این بخش نشان می‌دهد چگونه قالب‌بندی متن را در سطح جدول در Aspose.Slides اعمال کنید تا هر سلول یک سبک یکپارچه و هماهنگ داشته باشد. خواهید آموخت چگونه اندازه قلم، ترازها و حاشیه‌ها را به‌صورت سراسری تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجعی به اسلاید بر اساس شاخص آن بگیرید.
3. یک [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) به اسلاید اضافه کنید.
4. اندازه قلم (ارتفاع قلم) برای متن تنظیم شود.
5. تراز پاراگراف و حاشیه‌ها تنظیم شوند.
6. جهت‌گیری عمودی متن تنظیم شود.
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال Python زیر نشان می‌دهد چگونه گزینه‌های قالب‌بندی موردنظر خود را به متن در یک جدول اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # تنظیم اندازه قلم برای همهٔ سلول‌های جدول.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # تنظیم متن راست‌چین و حاشیهٔ راست برای همهٔ سلول‌های جدول.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # تنظیم جهت‌گیری عمودی متن برای همهٔ سلول‌های جدول.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **اعمال سبک‌های پیش‌فرض جدول**

Aspose.Slides به شما امکان می‌دهد جداول را با استفاده از سبک‌های پیش‌تعریف‌شده مستقیماً در کد قالب‌بندی کنید. این مثال نشان می‌دهد چگونه یک جدول ایجاد کنید، یک سبک پیش‌فرض اعمال کنید و نتیجه را ذخیره کنید—روشی کارآمد برای اطمینان از قالب‌بندی ثابت و حرفه‌ای.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل کردن نسبت ابعاد جداول**

نسبت ابعاد یک شکل، نسبت ابعاد آن است. Aspose.Slides ویژگی `aspect_ratio_locked` را فراهم می‌کند که به شما امکان می‌دهد نسبت ابعاد جداول و سایر اشکال را قفل کنید.

مثال Python زیر نشان می‌دهد چگونه نسبت ابعاد یک جدول را قفل کنید:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا می‌توانم جهت خواندن راست‌به‌چپ (RTL) را برای کل جدول و متن داخل سلول‌ها فعال کنم؟**

بله. جدول ویژگی [right_to_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/right_to_left/) را فراهم می‌کند و پاراگراف‌ها دارای [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/right_to_left/) هستند. استفاده از هر دو اطمینان می‌دهد که ترتیب و رندر صحیح RTL داخل سلول‌ها اعمال شود.

**چگونه می‌توانم از حرکت یا تغییر اندازه جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**

از [shape locks](/slides/fa/python-net/applying-protection-to-presentation/) استفاده کنید تا حرکت، تغییر اندازه، انتخاب و غیره غیرفعال شوند. این قفل‌ها بر روی جداول نیز اعمال می‌شوند.

**آیا افزودن تصویر به‌عنوان پس‌زمینه داخل سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر حسب حالت انتخابی (کشیدن یا کاشت) فضای سلول را پوشش می‌دهد.
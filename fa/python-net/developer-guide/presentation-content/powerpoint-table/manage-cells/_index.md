---
title: مدیریت سلول‌های جدول در ارائه‌ها با پایتون
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/python-net/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "به سادگی سلول‌های جدول را در PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET مدیریت کنید. دسترسی، اصلاح و استایل‌دهی به سلول‌ها را به‌سرعت تسلط پیدا کنید تا اتوماسیون اسلایدها بدون دردسر باشد."
---
## **بررسی کلی**

Aspose.Slides به شما اجازه می‌دهد تا به سلول‌های جدول در ارائه‌های PowerPoint دسترسی داشته باشید و آن‌ها را ویرایش کنید. این مقاله توضیح می‌دهد که چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، با شماره‌گذاری سلول‌ها پس از ادغام یا تقسیم سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید، و یک تصویر را داخل سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روز کنید، و ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

## **شناسایی سلول‌های جدول ادغام‌شده**

جداول غالباً شامل سلول‌های ادغام‌شده برای سرفصل‌ها یا گروه‌بندی داده‌های مرتبط هستند. در این بخش، خواهید دید چگونه تشخیص دهید آیا یک سلول خاص به یک ناحیه ادغام‌شده تعلق دارد و چگونه به سلول اصلی (بالا‑چپ) ارجاع دهید تا بتوانید کل بلوک را به‌صورت یکنواخت بخوانید یا قالب‌بندی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. جدول را از اولین اسلاید دریافت کنید.
3. در سطرها و ستون‌های جدول پیمایش کنید تا سلول‌های ادغام‌شده را پیدا کنید.
4. زمانی که سلول‌های ادغام‌شده یافت شدند، یک پیام چاپ کنید.

کد Python زیر سلول‌های جدول ادغام‌شده را در یک ارائه شناسایی می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # فرض بر این است که اولین شکل در اولین اسلاید یک جدول است.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **حذف حاشیه‌های سلول جدول**

گاهی بعضی اوقات حاشیه‌های جدول حواس را از محتوا منحرف می‌کنند یا شلوغی بصری ایجاد می‌نمایند. این بخش نشان می‌دهد چگونه حاشیه‌های سلول‌های انتخاب‌شده یا حتی سمت‌های خاص یک سلول را حذف کنید تا یک چیدمان تمیزتر داشته باشید و بهتر با طراحی اسلاید شما هم‌راستا شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید را بر حسب اندیس آن دریافت کنید.
3. یک آرایه از عرض‌های ستون‌ها تعریف کنید.
4. یک آرایه از ارتفاع‌های سطرها تعریف کنید.
5. با استفاده از متد [add_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_table/) یک جدول به اسلاید اضافه کنید.
6. در هر سلول پیمایش کنید تا حاشیه‌های بالا، پایین، چپ و راست را پاک کنید.
7. ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

کد Python زیر نشان می‌دهد چگونه حاشیه‌های سلول‌های جدول حذف شوند:

```python
import aspose.slides as slides

# نمونه‌ای از کلاس Presentation که یک فایل PPTX را نمایندگی می‌کند.
with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # تعریف ستون‌ها با عرض‌ها و سطرها با ارتفاع‌ها.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # افزودن یک شکل جدول به اسلاید.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # پاک‌سازی پر کردن حاشیه برای هر سلول.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **شماره‌گذاری در سلول‌های ادغام‌شده**

اگر دو جفت سلول را ادغام کنید—به عنوان مثال، (1, 1) × (2, 1) و (1, 2) × (2, 2)—جدول نتیجه همان شماره‌گذاری سلول‌ها را همانند جدول بدون ادغام حفظ می‌کند. کد Python زیر این رفتار را نشان می‌دهد:

```python
import aspose.slides as slides

# نمونه‌ای از کلاس Presentation که نمایانگر یک فایل PPTX است.
with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # تعریف ستون‌ها با عرض‌ها و سطرها با ارتفاع‌ها.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # افزودن یک شکل جدول به اسلاید.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # ادغام سلول‌های (1,1) و (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # ادغام سلول‌های (1, 2) و (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # چاپ شاخص‌های سلول.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

خروجی:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **شماره‌گذاری در سلول‌های تقسیم‌شده**

در مثال قبلی، زمانی که سلول‌های جدول ادغام شدند، شماره‌گذاری سلول‌های دیگر تغییر نکرد. این بار، یک جدول عادی (بدون سلول‌های ادغام‌شده) ایجاد می‌کنیم و سپس سلول (1, 1) را تقسیم می‌کنیم تا جدولی ویژه به دست آید. به شماره‌گذاری این جدول دقت کنید—ممکن است غیرعادی به نظر برسد. اما این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides نیز همان رفتار را پیروی می‌کند.

کد Python زیر این رفتار را نشان می‌دهد:

```python
import aspose.slides as slides

# نمونه‌ای از کلاس Presentation که نمایانگر یک فایل PPTX است.
with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # تعریف عرض ستون‌ها و ارتفاع سطرها.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # افزودن یک شکل جدول به اسلاید.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # تقسیم سلول (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # چاپ شاخص‌های سلول.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

خروجی:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **تغییر رنگ پس‌زمینه سلول جدول**

مثال Python زیر نشان می‌دهد چگونه رنگ پس‌زمینه یک سلول جدول را تغییر دهید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # ایجاد یک جدول جدید.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # تنظیم رنگ پس‌زمینه برای یک سلول.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **درج تصویر در سلول‌های جدول**

این بخش نشان می‌دهد چگونه یک تصویر را در یک سلول جدول در Aspose.Slides درج کنید. این شامل اعمال پر کردن با تصویر به سلول هدف و پیکربندی گزینه‌های نمایش مانند کشش یا کاشی‌بندی است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
3. یک آرایه از عرض‌های ستون‌ها تعریف کنید.
4. یک آرایه از ارتفاع‌های سطرها تعریف کنید.
5. با استفاده از متد [add_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_table/) یک جدول به اسلاید اضافه کنید.
6. تصویر را از یک فایل بارگذاری کنید.
7. تصویر را به مجموعه تصاویر ارائه اضافه کنید تا یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) دریافت کنید.
8. نوع پر کردن (FillType) سلول جدول را به `PICTURE` تنظیم کنید.
9. تصویر را به سلول جدول اعمال کنید و یک حالت پر شدن (مانند `STRETCH`) انتخاب کنید.
10. ارائه را به صورت فایل PPTX ذخیره کنید.

کد Python زیر نشان می‌دهد چگونه هنگام ایجاد جدول، تصویر را داخل یک سلول جدول قرار دهید:

```python
import aspose.slides as slides

# یک شیء Presentation را نمونه‌سازی کنید.
with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # تعریف عرض ستون‌ها و ارتفاع سطرها.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # افزودن یک شکل جدول به اسلاید.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # بارگذاری تصویر و افزودن آن به ارائه برای دریافت یک PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # اعمال تصویر به اولین سلول جدول.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # ذخیرهٔ ارائه بر روی دیسک.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای سمت‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [بالا](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cellformat/border_top/)/[پایین](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cellformat/border_bottom/)/[چپ](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cellformat/border_left/)/[راست](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cellformat/border_right/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد. این به‌طرزی منطقی از کنترل حاشیه به‌ازای هر سمت برای یک سلول که در مقاله نشان داده شد، پیروی می‌کند.

**اگر پس از تنظیم یک تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/سطر را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [حالت پر کردن](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillmode/) دارد (کشیدگی/کاشی). در حالت کشیدگی، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها مجدداً محاسبه می‌شوند. مقاله به حالت‌های نمایش تصویر در یک سلول اشاره می‌کند.

**آیا می‌توانم یک پیوند (Hyperlink) به تمام محتوای یک سلول اختصاص دهم؟**

[پیوندها](/slides/fa/python-net/manage-hyperlinks/) در سطح متن (بخش) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. چارچوب متن یک سلول از [بخش‌ها](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) (runs) با قالب‌بندی مستقل—خانواده فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.
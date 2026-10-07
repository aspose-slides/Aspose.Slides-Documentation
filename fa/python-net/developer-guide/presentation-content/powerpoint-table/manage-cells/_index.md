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
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در پایتون: شناسایی سلول‌های ترکیبی، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای پایتون از طریق .NET."
---
## **بررسی کلی**

Aspose.Slides به شما امکان دسترسی و ویرایش سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله نحوه شناسایی سلول‌های ترکیبی جدول، حذف خطوط حاشیه سلول، کار با شماره‌گذاری سلول پس از ادغام یا تقسیم سلول‌ها، تغییر رنگ پس‌زمینه سلول و افزودن تصویر داخل سلول جدول را توضیح می‌دهد. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره نمایید.

Aspose.Slides از ایندکس‌های صفر‑پایه استفاده می‌کند. مختصات در این مقاله به صورت `(column, row)` نوشته شده‌اند.

## **شناسایی سلول ترکیبی جدول**

مثال یک ارائه موجود را باز می‌کند و اولین شکل در اولین اسلاید را به عنوان جدول دسترسی می يابد. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک جدول باشد. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) برای شناسایی سلول‌های موجود در نواحی ترکیبی استفاده می‌کند. برای هر مورد مطابق، مختصات سلول را به ترتیب `row;column`، [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)، [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)، و مختصات شروع ناحیه، [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) و [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) چاپ می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **حذف خطوط حاشیه سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید و با [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) یک جدول را به اسلاید اول آن اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب نقطه مشخص می‌شود. مثال تمام چهار خط حاشیه سلول را به [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **ادغام سلول‌های جدول**

از [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی کنترل می‌کند آیا ادغام می‌تواند سلول‌های خارج از بازه مشخص شده را شامل شود یا نه؛ `False` ادغام را فقط در آن بازه نگه می‌دارد.

مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70‑نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را پوشش می‌دهد، در حالی که شبکه‌ی زیرین جدول همچنان چهار ستون و چهار ردیف دارد. برای دسترسی به محتوای یا قالب‌بندی سلول ترکیبی، موقعیت بالا‑چپ آن را استفاده کنید: `table.rows[1][1]` در این مثال. موقعیت‌های دیگر در بازه ترکیبی همچنان بخشی از شبکه جدول می‌مانند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **تقسیم سلول‌های جدول**

ادغام سلول‌ها در مثال قبلی ساختار شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و ایندکس‌های ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکه جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70‑نقطه‌ای ایجاد می‌کند و بر روی سلول `(1, 1)` با [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) عمل تقسیم می‌نماید. نصف عرض 70‑نقطه‌ای سلول برای ایجاد دو سلول با عرض برابر استفاده می‌شود.

پس از این تقسیم، دو نیمه به صورت `table.rows[1][1]` و `table.rows[1][2]` دسترسی دارند. شبکه جدول حالا پنج ستون دارد: سلول‌های قبلاً در ستون‌های 2 و 3 قرار داشتند به ستون‌های 3 و 4 منتقل می‌شوند. ایندکس‌های ردیف بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از ایندکس‌های ستون به‌روزرسانی‌شده استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **تقسیم سلول‌های ترکیبی بر اساس ردیف یا ستون**

برای آماده‌سازی سلول‌های الگوی ترکیبی جهت پر کردن داده، از [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) برای تقسیم بر اساس مرز ردیف موجود یا [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) برای تقسیم بر اساس مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در بخش بالایی یا ستون‌ها را در بخش چپ تقسیم می‌شمارد؛ این مقدار نسبی به ناحیه ترکیبی است:

- تقسیم ردیفی: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- تقسیم ستونی: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

مثال انتظار دارد ارائه‌ای داشته باشد که جدول به عنوان اولین شکل در اولین اسلاید قرار داشته باشد، به‌طوری که سلول‌های `(1, 2)` و `(1, 3)` به‌صورت عمودی ترکیب شده باشند. از موقعیت پایین شروع می‌کند، از [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) و [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) برای یافتن مبدأ استفاده می‌کند و هر دو بازه را بررسی می‌کند. `split_by_row_span` با مقدار `index` برابر 1 سپس ردیف‌های 2 و 3 را برای نام محصولات جدا می‌کند. برای ترکیب افقی دو ستونی، به جای آن از `split_by_col_span` با مقدار `index` برابر 1 استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # سلول‌های حاصل شده از جدول بعد از تقسیم را بازیابی کنید.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

شبکه جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را با مختصاتشان بازیابی کنید؛ در اینجا هر دو بازه دارای ترکیب 1 هستند و [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) مقدار `False` را چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم همچنان جزئی ترکیبی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌مانند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پر، خطوط حاشیه و حاشیه‌ها را به ارث می‌برد. پس از تقسیم، سلول‌ها را پر کنید و هر قالب‌بندی متنی لازم را به‌صورت صریح تنظیم کنید.

ارائه ذخیره‌شده شامل سلول‌های جداگانه «Product A» و «Product B» با حفظ قالب‌بندی سلول‌های الگو است. برای جزئیات بیشتر به [مرجع API سلول](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) مراجعه کنید.

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدولی با ستون‌های 150‑نقطه‌ای و ردیف‌های 50‑نقطه‌ای ایجاد می‌کند. برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم قرار دارد، [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به حالت sólido تنظیم می‌کند و [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) را به رنگ قرمز می‌گذارد.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن تصویر داخل سلول جدول**

قبل از اجرای این مثال، تصویر ورودی را در پوشه کاری قرار دهید. تصویر را با [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) بارگیری می‌کند و با [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) به مجموعه تصویرهای ارائه اضافه می‌کند. سپس تصویر را به پرکردن تصویر (picture fill) سلول `(0, 0)`—اولین سلول جدول—تخصیص می‌دهد.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) تصویر را به‌گونه‌ای کش می‌کند که سلول را پر کند، که ممکن است نسبت ابعاد آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب نقطه هستند. تصویر بارگیری‌شده به‌صورت خودکار زمانی که بلوک `with` به پایان می‌رسد آزاد می‌شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط حاشیه را برای طرف‌های مختلف یک سلول متفاوت تنظیم کنم؟**

بله. خطوط حاشیهٔ [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) ویژگی‌های جداگانه‌ای دارند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه می‌شود؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (کش / کاشی) دارد. در حالت کشیدن، تصویر با سلول جدید وفق می‌یابد؛ در حالت کاشی، کاشی‌ها دوباره محاسبه می‌شوند.

**آیا می‌توانم یک پیوندهای فراگیر به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/python-net/manage-hyperlinks/) در سطح متن (بخش) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول داشته باشم؟**

بله. چارچوب متن یک سلول از [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانوادهٔ فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.
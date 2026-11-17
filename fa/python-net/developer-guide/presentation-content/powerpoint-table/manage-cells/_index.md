---
title: مدیریت سلول‌های جدول در ارائه‌ها با Python
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
- ارائه
- Python
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در Python: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای Python از طریق .NET."
---
## **مرور کلی**

Aspose.Slides به شما امکان دسترسی و ویرایش سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، با شماره‌گذاری سلول پس از ادغام یا تقسیم سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل سلول جدول اضافه کنید. نمونه‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، یک جدول را از اسلاید بگیرید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

Aspose.Slides از شاخص‌های صفر مبنا استفاده می‌کند. مختصات در این مقاله به صورت `(column, row)` نوشته شده‌اند.

## **شناسایی یک سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل در اولین اسلاید را به عنوان جدول دسترسی می‌یابد. فرض می‌کند که اسلاید و شکل وجود داشته باشند و شکل یک جدول باشد. سپس از تمام ردیف‌ها و ستون‌ها عبور می‌کند و از [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) برای شناسایی سلول‌های موجود در مناطق ادغام‌شده استفاده می‌کند. برای هر مورد مطابقت، مختصات سلول را به ترتیب `row;column` چاپ می‌کند، [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)، [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)، و مختصات شروع منطقه، [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) و [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) را نمایش می‌دهد.

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

## **حذف حاشیه‌های سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید و یک جدول را به اسلاید اول آن با [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب پوینت مشخص می‌شوند. مثال تمام چهار حاشیه سلول را به [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **اضافه کردن حاشیه‌های قطری سلول**

از [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) برای کشیدن خطی از گوشه بالا‑چپ به پایین‑راست و از [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) برای کشیدن خطی از گوشه پایین‑چپ به بالا‑راست استفاده کنید. یک قطر می‌تواند سرصفحه‌ای گوشه‌ای را علامت‌گذاری کند؛ هر دو قطر می‌توانند یک X تشکیل دهند تا سلول را به‌عنوان غیرقابل اعمال علامت‌گذاری کنند.

هر قطر یک [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/) است. در [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) آن، [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم کنید و یک [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) انتخاب کنید. عرض خط را با [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) بر حسب پوینت تنظیم کنید.

مثال سه سلول در یک ردیف ایجاد می‌کند: یک قطر نزولی قرمز، یک قطر صعودی آبی و هر دو قطر. حاشیه‌های بالایی، پایین، چپ و راست سلول‌ها بدون تغییر می‌مانند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

یک قطر یک ویژگی قالب‌بندی است، نه یک تقسیم سلول. هر سلول یک [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) تک را حفظ می‌کند؛ مناطق هر دو طرف یک قطر را نمی‌توان به‌صورت مستقل ویرایش کرد.

جدول ذخیره‌شده، که در Microsoft PowerPoint رندر شده است:
![سه سلول جدول نشان‌دهنده یک قطر قرمز از بالا‑چپ به پایین‑راست، یک قطر آبی از پایین‑چپ به بالا‑راست، و هر دو قطر تشکیل X می‌دهند.](diagonal-cell-borders.png)

*از چپ به راست: قطر نزولی (قرمز، 3 pt)، قطر صعودی (آبی، 5 pt) و هر دو قطر.*

## **ادغام سلول‌های جدول**

از [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از بازه مشخص‌شده باشد یا خیر؛ `False` ادغام را در همان بازه نگه می‌دارد.

مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70 پوینت ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌نماید. سلول حاصل دو ستون و دو ردیف را پوشش می‌دهد، در حالی که شبکه پایه جدول هنوز چهار ستون و چهار ردیف دارد. برای دسترسی به محتوا یا قالب‌بندی سلول ادغام‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table.rows[1][1]` در این مثال. سایر موقعیت‌ها در بازه ادغام‌شده همچنان بخشی از شبکه جدول باقی می‌مانند، بنابراین شاخص‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

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

ادغام سلول‌ها در مثال قبلی شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و شاخص‌های ستون سلول‌های سمت راست آن را تغییر دهد. Aspose.Slides از مدل شبکه جدول PowerPoint پیروی می‌کند.

این مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70 پوینت ایجاد می‌کند و بر روی سلول `(1, 1)` متد [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) را فراخوانی می‌کند. نیمی از عرض 70 پوینت سلول برای ایجاد دو سلول با عرض مساوی استفاده می‌شود.

پس از این تقسیم، دو نیمه به‌صورت `table.rows[1][1]` و `table.rows[1][2]` دسترسی پیدا می‌کنند. شبکه جدول اکنون دارای پنج ستون است: سلول‌های اصلی در ستون‌های 2 و 3 به ستون‌های 3 و 4 منتقل می‌شوند. شاخص‌های ردیف ثابت می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این شاخص‌های ستون به‌روز استفاده کنید.

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

<!-- visual-explanation:manage-cells:start -->
[![یک سلول 70 پوینت ادغام‌نشده به دو سلول 35 پوینت تقسیم می‌شود، ستون پنجم شبکه را اضافه می‌کند و شاخص‌ها را به سمت راست آن جابجا می‌کند.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسیم عرض بر روی سلول (1, 1) تأثیر می‌گذارد، با استفاده از شاخص‌های صفر مبنا (column, row). سایر ردیف‌ها یک سلول را که هر دو موقعیت ستون جدید را پوشش می‌دهد، حفظ می‌کنند.*
<!-- visual-explanation:manage-cells:end -->

### **تقسیم سلول‌های ادغام‌شده بر حسب گستردگی ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ادغام‌شده برای پر کردن داده‌ها، از [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) برای تقسیم بر وفق یک مرز ردیف موجود، یا از [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) برای تقسیم بر وفق یک مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در قسمت بالایی یا ستون‌ها را در قسمت چپ تقسیم می‌شمارد؛ نسبت به ناحیه ادغام‌شده نسبی است:

- تقسیم ردیف: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- تقسیم ستون: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

مثال انتظار دارد که یک ارائه جدول را به عنوان اولین شکل در اولین اسلاید داشته باشد، به‌طوری که `(1, 2)` و `(1, 3)` به‌صورت عمودی ادغام شده باشند. با شروع از موقعیت پایین، از [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) و [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) برای یافتن منشا استفاده می‌کند و هر دو گستردگی را بررسی می‌کند. `split_by_row_span` با شاخص 1 سپس ردیف‌های 2 و 3 را برای نام‌های محصول جدا می‌کند. برای یک ادغام افقی دو ستونی، به‌جای آن از `split_by_col_span` با شاخص 1 استفاده کنید.

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

        # دریافت سلول‌های حاصل از جدول پس از تقسیم.
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

شبکه جدول و شاخص‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را با مختصاتشان بازیابی کنید؛ در اینجا، هر دو گستردگی 1 دارند و [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) `False` چاپ می‌کند. نواحی بزرگتر می‌توانند پس از یک تقسیم بخشی ادغام‌شده باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالا (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکردن، حاشیه‌ها و حاشیه‌ها را به ارث می‌برد. پس از تقسیم، سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را به‌صراحت تنظیم کنید.

ارائه ذخیره‌شده شامل سلول‌های جداگانه "Product A" و "Product B" است که قالب‌بندی سلول قالب حفظ شده است. برای جزئیات، به [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) مراجعه کنید.

### **تقسیم یک سلول به ارتفاع خاص**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) ارتفاع بخش بالایی را بر حسب پوینت می‌گیرد. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) تعداد ردیف‌های موجود در شبکه را در بخش بالایی می‌گیرد. برای مرکز کردن یک سلول 40 پوینت به صورت عمودی در ستون راست، 40 را از ارتفاع واقعی سلول کم کنید و فضا را به‌صورت مساوی بالای و پایین آن تقسیم کنید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

تقسیم اول یک ردیف شبکه اضافه می‌کند و 90 پوینت پایین را در `table.rows[1][1]` باقی می‌گذارد. تقسیم دوم آن سلول را به یک سلول میانی 40 پوینت و یک سلول پایین 50 پوینت تقسیم می‌کند. سه سلول در ستون راست اکنون به ترتیب 50، 40 و 50 پوینت از بالا به پایین ارتفاع دارند. سلول چپ تمام سه ردیف را با ارتفاع اصلی 140 پوینت پوشش می‌دهد.

![سلول چپ تمام ارتفاع جدول را در کنار سه سلول با متن "Middle" در مرکز پوشش می‌دهد.](split-by-height.png)

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال یک جدول با ستون‌های 150 پوینت و ردیف‌های 50 پوینت ایجاد می‌کند. برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم قرار دارد، [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به solid و [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) را به رنگ قرمز تنظیم می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن تصویر داخل سلول جدول**

تصویر ورودی را قبل از اجرای این مثال در پوشه کاری قرار دهید. تصویر را با [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) بارگذاری می‌کند و به مجموعه تصاویر ارائه با [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) اضافه می‌نماید. سپس تصویر را به پرکردن تصویری سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کشیده می‌کند که ممکن است نسبت تصویر را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب پوینت است. تصویر بارگذاری‌شده به‌صورت خودکار هنگام پایان بلاک `with` آن آزاد می‌شود.

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

## **پرسش‌های متداول**

**آیا می‌توانم ضخامت و سبک خطوط مختلف را برای طرف‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد.

**چه اتفاقی برای تصویر می‌افتد اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم؟**

رفتار بسته به [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) متفاوت است. با کشیده شدن، تصویر با سلول جدید سازگار می‌شود؛ با کاشی‌گذاری، کاشی‌ها دوباره محاسبه می‌شوند.

**آیا می‌توانم یک پیوند به تمام محتویات یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/python-net/manage-hyperlinks/) در سطح متن (قسمت) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک قسمت یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های مختلفی داخل یک سلول تنظیم کنم؟**

بله. چارچوب متن یک سلول از [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.
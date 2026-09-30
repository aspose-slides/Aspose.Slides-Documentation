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
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET. مثال‌های کد ساده‌ای را برای بهینه‌سازی روندهای کاری جدول خود کشف کنید."
---
## **معرفی**

جداول در پاورپوینت اطلاعات را به صورت سطرها و ستون‌ها سازماندهی می‌کنند و خواندن و مقایسه مقادیر را آسان‌تر می‌سازند.

Aspose.Slides کلاس‌های [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) و [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) و سایر انواع را برای ایجاد، به‌روزرسانی و مدیریت جداول در ارائه‌ها فراهم می‌کند.

## **ایجاد جدول از ابتدا**

یک جدول را با تعیین موقعیت، عرض ستون‌ها و ارتفاع سطرها ایجاد کنید. پس از افزودن آن به یک اسلاید، می‌توانید حاشیه‌های سلول را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
2. ارجاع به اسلاید را بر اساس اندیس آن دریافت کنید.
3. لیستی از عرض‌های ستون‌ها بر حسب پوینت تعریف کنید.
4. لیستی از ارتفاع‌های سطرها بر حسب پوینت تعریف کنید.
5. یک شیء [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) را از طریق متد [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) به اسلاید اضافه کنید.
6. برای هر [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) به منظور تنظیم حاشیه‌های بالا، پایین، راست و چپ، قالب‌بندی اعمال کنید.
7. دو سلول اول سطر اول جدول را ادغام کنید.
8. به سلول ادغام‌شده از طریق ویژگی [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) دسترسی پیدا کنید.
9. متن را در سلول ادغام‌شده تنظیم کنید.
10. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر جدولی با سه ستون و پنج سطر در موقعیت (100, 50) پوینت ایجاد می‌کند. حاشیه‌های قرمز با عرض 5 پوینت اعمال می‌شود، دو سلول اول سطر اول ادغام می‌شوند و نتیجه به صورت `table.pptx` ذخیره می‌شود.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، اندیس‌های سلول صفر‑محور هستند و به ترتیب (ستون، سطر) بیان می‌شوند. اولین سلول به صورت (0, 0) اندیس‌گذاری می‌شود. در پایتون، برای دسترسی به یک سلول از `table.rows[row_index][column_index]` استفاده می‌کنید؛ در این عبارت ابتدا اندیس سطر قرار می‌گیرد.

به‌عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 سطر به این صورت شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول 4 × 4 نشان داده‌شده در بالا را ایجاد می‌کند، عرض ستون‌ها و ارتفاع سطرها را 70 پوینت تنظیم می‌کند و حاشیه‌های سلول‌ها را به رنگ قرمز با عرض 5 پوینت می‌سازد. مختصات، اندیس‌های سلول‌ها را نشان می‌دهد؛ مثال سلول‌ها را خالی می‌گذارد و جدول را به صورت `StandardTables_out.pptx` ذخیره می‌کند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به جدول موجود**

جداول در مجموعهٔ اشکال یک اسلاید ذخیره می‌شوند. با پیمایش اشکال، جدول را پیدا کنید و سپس از کلاس [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) برای خواندن یا به‌روزرسانی سلول‌های آن استفاده کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. ارجاع به اسلایدی که جدول در آن است را بر اساس اندیس آن دریافت کنید.
3. از میان اشیاء [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) پیمایش کنید و وقتی جدول یافت شد متوقف شوید. اگر اسلاید چند جدول داشته باشد، از [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) برای شناسایی جدول مورد نیاز استفاده کنید.
4. متن سلول هدف را به‌روزرسانی کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول در اولین اسلاید را پیدا می‌کند. سلول در ستون 0، سطر 1 را به `New` تنظیم می‌کند و نتیجه را به صورت `table1_out.pptx` ذخیره می‌کند. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول آن اسلاید باید حداقل یک ستون و دو سطر داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

برای تغییر اندازهٔ یک سطر در جدول موجود و فهمیدن اینکه چرا ارتفاع واقعی می‌تواند بیش از حداقل درخواست‌شده باشد، به [کنترل ارتفاع سطر](/slides/fa/python-net/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **یافتن سلولی که TextFrame را مالک است**

زمانی که کد عمومی پردازش متن یک [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) را از یک جدول دریافت می‌کند، از ویژگی [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) برای بازیابی [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) مالک استفاده کنید. برای یک TextFrame مربوط به سلول جدول، ویژگی [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) تنظیم شده و [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) برابر `None` است، حتی اگر جدول خود یک شکل باشد.

مختصات سلول از طریق ویژگی‌های فقط‑خواندنی [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) و [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) در دسترس است. ویژگی [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) نیز فقط‑خواندنی است: ناوبری به مالک را فراهم می‌کند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده، سلول برگشت‌گرفته‌شده را برای مقدار `None` بررسی کنید.

برای مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله اشکالی که به گره‌های SmartArt مرتبط هستند، به [جستجو و جایگزینی متن](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **هم‌ترازبندی متن در جدول**

می‌توانید تکیه‌گاه عمودی و جهت متن سلول‌های جداگانه جدول را کنترل کنید. مثال این بخش متن را در اولین سلول مرکز می‌کند و به‌صورت 270 درجه می‌چرخاند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
2. ارجاع به اسلاید را بر اساس اندیس آن دریافت کنید.
3. یک شیء [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) را به اسلاید اضافه کنید.
4. یک شیء [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) را از جدول دریافت کنید.
5. اولین [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) را دسترسی پیدا کنید و متن و رنگ آن را تنظیم کنید.
6. ویژگی‌های [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) و [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) سلول را تنظیم کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال جدول 4 × 4 با عرض ستون 120 پوینت و ارتفاع سطر 100 پوینت ایجاد می‌کند. متن سلول (0, 0) را قالب‌بندی می‌کند، مقادیر را به سلول‌های باقی‌مانده سطر اول اضافه می‌کند و نتیجه را به صورت `Vertical_Align_Text_out.pptx` ذخیره می‌کند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب‌بندی متن در سطح جدول**

از [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) برای اعمال قالب‌بندی متن به تمام سلول‌های یک جدول استفاده کنید. بارگذاری‌های آن می‌توانند قالب‌بندی بخش، پاراگراف و فریم متن را بپذیرند، بنابراین می‌توانید این ویژگی‌ها را بدون پیمایش سلول‌های جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. ارجاع به اسلاید را بر اساس اندیس آن دریافت کنید.
3. یک شیء [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) را از اسلاید دریافت کنید.
4. برای متن، [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) را تنظیم کنید.
5. [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) و [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) را تنظیم کنید.
6. [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) را تنظیم کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر `table.pptx` را باز می‌کند که باید حداقل یک اسلاید با یک جدول به عنوان اولین شکل داشته باشد. اندازهٔ قلم را به 25 پوینت تنظیم می‌کند، پاراگراف‌ها را راست‌تراصف می‌کند با حاشیهٔ راست 20 پوینت و متن را عمودی می‌کند. ارائهٔ قالب‌بندی‌شده به صورت `result.pptx` ذخیره می‌شود.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت ویژگی‌های سبک جدول**

از [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) برای خواندن یا اختصاص یک سبک پیش‌تنظیم‌شده به جدول استفاده کنید. این مثال [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) را به یک جدول اعمال می‌کند، نام پیش‌تنظیم را چاپ می‌کند و همان پیش‌تنظیم را به جدول دوم اختصاص می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک جدول، نسبت عرض آن به ارتفاع است. از [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) برای قفل کردن این نسبت برای یک جدول استفاده کنید.

مثال زیر `pres.pptx` را باز می‌کند که باید حداقل یک اسلاید با یک جدول به عنوان اولین شکل داشته باشد. وضعیت قفل فعلی را چاپ می‌کند، قفل نسبت ابعاد را فعال می‌سازد، وضعیت به‌روزشده (`True`) را چاپ می‌کند و نتیجه را به صورت `pres-out.pptx` ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای کل جدول و متن در سلول‌های آن فعال کنم؟**

بله. جدول ویژگی [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) را در اختیار دارد و پاراگراف‌ها نیز [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) را دارند. استفاده از هر دو، ترتیب RTL صحیح و رندرینگ داخل سلول‌ها را تضمین می‌کند.

**چگونه می‌توانم از جابجا یا تغییر اندازهٔ جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**

از [قفل‌های شکل](/slides/fa/python-net/applying-protection-to-presentation/) برای غیرفعال کردن جابجایی، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها بر روی جداول نیز اعمال می‌شوند.

**آیا درج تصویر به‌عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر اساس حالت انتخابی (کشیدگی یا کاشی) ناحیهٔ سلول را پوشش می‌دهد.
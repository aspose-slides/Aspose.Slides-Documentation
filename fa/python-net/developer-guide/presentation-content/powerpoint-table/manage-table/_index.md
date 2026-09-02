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
- Python
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET. نمونه‌های کد ساده‌ای را کشف کنید تا گردش کار جداول خود را بهبود بخشید."
---
## **مقدمه**

یک جدول در PowerPoint یک روش کارآمد برای ارائه اطلاعات است. اطلاعاتی که در یک شبکه از سلول‌ها (سطرها و ستون‌ها) مرتب شده‌اند، ساده و آسان برای درک هستند.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) ، کلاس [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) و سایر انواع مرتبط را فراهم می‌آورد تا به شما در ایجاد، به‌روزرسانی و مدیریت جداول در هر ارائه‌ای کمک کند.

## **ایجاد جداول از ابتدا**

این بخش نشان می‌دهد چگونه یک جدول را از ابتدا در Aspose.Slides با افزودن یک شکل جدول به یک اسلاید، تعریف ردیف‌ها و ستون‌ها، و تنظیم اندازه‌های دقیق ایجاد کنید. همچنین خواهید دید چگونه سلول‌ها را با متن پر کنید، تنظیمات تراز و حاشیه‌ها را تنظیم کنید و ظاهر جدول را سفارشی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.  
3. آرایه‌ای از عرض ستون‌ها تعریف کنید.  
4. آرایه‌ای از ارتفاع ردیف‌ها تعریف کنید.  
5. یک [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) به اسلاید اضافه کنید.  
6. بر روی هر [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) مرور کنید و حاشیه‌های بالا، پایین، راست و چپ آن را فرمت کنید.  
7. سلول‌های دو ردیف اول و دو ستون اول را در یک سلول ترکیب کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) یک [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) دسترسی پیدا کنید.  
9. متن را به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.  
10. ارائه‌ی اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه در یک ارائه جدول ایجاد کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    # ذخیره‌سازی ارائه به دیسک.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **شماره‌گذاری در جداول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و صفر-مبتنی است. اولین سلول در جدول با اندیس (0, 0) (ستون 0، ردیف 0) شناخته می‌شود.

به عنوان مثال، در جدولی با 4 ستون و 4 ردیف، سلول‌ها به صورت زیر شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

مثال زیر به زبان Python نشان می‌دهد چگونه با این شماره‌گذاری صفر-مبنایی به سلول‌ها ارجاع دهید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن جدول با ۴ ستون و ۴ ردیف.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به جدول موجود**

این بخش توضیح می‌دهد چگونه جدول موجودی را در یک ارائه پیدا کرده و با آن کار کنید با استفاده از Aspose.Slides. خواهید آموخت چگونه جدول را در یک اسلاید پیدا کنید، به ردیف‌ها، ستون‌ها و سلول‌های آن دسترسی پیدا کنید و محتوا یا قالب‌بندی را به‌روزرسانی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع به اسلایدی که جدول را شامل می‌شود بر اساس اندیس آن دریافت کنید.  
3. از تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) تا پیدا کردن جدول مرور کنید.  
4. از شیء [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) برای کار با جدول استفاده کنید.  
5. ارائه‌ی اصلاح‌شده را ذخیره کنید.

{{% alert color="info" title="Note" %}}
اگر اسلاید شامل چندین جدول باشد، بهتر است با ویژگی `alternative_text` جدول مورد نیاز را جستجو کنید.
{{% /alert %}}

مثال زیر به زبان Python نشان می‌دهد چگونه به یک جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای بارگذاری یک فایل PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    table = None

    # در بین اشکال حلقه بزنید و اولین جدولی که یافت می‌شود را ارجاع دهید.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # متن اولین سلول در اولین ردیف را تنظیم کنید.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # ذخیره ارائه‌ی اصلاح‌شده به دیسک.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **یافتن سلولی که فریم متن را در اختیار دارد**

هنگامی که کد عمومی پردازش متن یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) را از یک جدول دریافت می‌کند، از ویژگی [TextFrame.parent_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_cell/) برای به‌دست آوردن [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) مالک استفاده کنید. برای فریم متن سلول جدول، ویژگی [TextFrame.parent_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_cell/) تنظیم شده و [TextFrame.parent_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_shape/) برابر `None` است، حتی اگر جدول خود یک shape باشد.

مختصات سلول از طریق ویژگی‌های فقط‑خواندنی [Cell.first_column_index](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/first_column_index/) و [Cell.first_row_index](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/first_row_index/) در دسترس است. ویژگی [TextFrame.parent_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_cell/) نیز فقط‑خواندنی است: مسیریابی به مالک را فراهم می‌کند امامالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده سلول برگردانده‌شده را برای مقدار `None` بررسی کنید.

برای مثال کامل که مالکین سلول‑جدول و shape را شناسایی می‌کند، از جمله shape‌های مرتبط با گره‌های SmartArt، به صفحه [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **تراز کردن متن در جداول**

این بخش نشان می‌دهد چگونه جایگاه متن داخل سلول‌های جدول را با Aspose.Slides کنترل کنید. خواهید آموخت چگونه متن را به صورت عمودی در یک سلول ثابت کنید و جهت‌نمای متن را تغییر دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) به اسلاید اضافه کنید.  
4. یک شیء [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) از جدول دسترسی پیدا کنید.  
5. متن را به صورت عمودی در وسط سلول قرار دهید و جهت متن را تنظیم کنید.  
6. ارائه‌ی اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه متن را در یک جدول تراز کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation.
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

    # مرکز کردن متن و تنظیم جهت عمودی.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # ذخیره‌سازی ارائه به دیسک.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب‌بندی متن در سطح جدول**

این بخش نشان می‌دهد چگونه قالب‌بندی متن را در سطح جدول در Aspose.Slides اعمال کنید تا هر سلول یک سبک یکسان و یکپارچه به ارث ببرد. خواهید آموخت چگونه اندازه قلم، تراز‌ها و حاشیه‌ها را به صورت سراسری تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.  
3. یک [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) به اسلاید اضافه کنید.  
4. اندازه قلم (ارتفاع قلم) برای متن تنظیم کنید.  
5. تراز پاراگراف و حاشیه‌ها را تنظیم کنید.  
6. جهت‌نمای عمودی متن را تنظیم کنید.  
7. ارائه‌ی اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه گزینه‌های قالب‌بندی دلخواه خود را بر متن در یک جدول اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # تنظیم اندازه قلم برای تمام سلول‌های جدول.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # تنظیم متن راست‌چین و حاشیه راست برای تمام سلول‌های جدول.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # تنظیم جهت عمودی متن برای تمام سلول‌های جدول.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از سبک‌های پیش‌فرض جدول**

Aspose.Slides به شما امکان می‌دهد جداول را با استفاده از سبک‌های پیش‌فرض مستقیماً در کد قالب‌بندی کنید. این مثال ایجاد یک جدول، اعمال یک سبک پیش‌فرض و ذخیره نتیجه را نشان می‌دهد — راهی کارآمد برای اطمینان از قالب‌بندی ثابت و حرفه‌ای.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل کردن نسبت ابعاد جداول**

نسبت ابعاد یک shape نسبت طول و عرض آن است. Aspose.Slides ویژگی `aspect_ratio_locked` را فراهم می‌کند که به شما اجازه می‌دهد نسبت ابعاد جداول و سایر shape‌ها را قفل کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه نسبت ابعاد یک جدول را قفل کنید:

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

**آیا می‌توانم جهت‌خوانی راست به چپ (RTL) را برای تمام جدول و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول ویژگی [right_to_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/right_to_left/) را در اختیار می‌گذارد و پاراگراف‌ها ویژگی [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/right_to_left/) دارند. استفاده از هر دو اطمینان می‌دهد ترتیب RTL صحیح و رندر مناسب داخل سلول‌ها اعمال شود.

**چگونه می‌توانم مانع حرکت یا تغییر اندازه جدول توسط کاربران در فایل نهایی شوم؟**

از [shape locks](/slides/fa/python-net/applying-protection-to-presentation/) برای غیرفعال کردن حرکت، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها بر روی جداول نیز اعمال می‌شوند.

**آیا افزودن تصویر به عنوان پس‌زمینه داخل سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر ناحیه سلول را بر اساس حالت انتخابی (کشیدگی یا کاشی) پوشش می‌دهد.
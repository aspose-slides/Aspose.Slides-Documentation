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
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای Python از طریق .NET و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **مقدمه**

Aspose.Slides for Python via .NET به شما امکان مدیریت ساختار جدول و قالب‌بندی آن در ارائه‌های PowerPoint را از طریق کلاس [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) می‌دهد. می‌توانید یک ردیف سرصفحه تعیین کنید، ردیف‌ها و ستون‌ها را کلون یا حذف کنید و قالب‌بندی متن را به کل ردیف یا ستون اعمال کنید.

این مقاله این عملیات را با مثال‌های Python توضیح می‌دهد. همچنین نشان می‌دهد چگونه یک پیش‌تنظیم سبک جدول را بازیابی کنید تا بتوانید آن را مجدداً استفاده کنید. شاخص‌های ردیف و ستون جدول بر پایه صفر هستند.

## **کنترل ارتفاع ردیف**

از [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) برای تعیین حداقل ارتفاع یک ردیف به واحد پوینت استفاده کنید. این مقدار یک حد پایین است، نه ارتفاع ثابت. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) ارتفاع واقعی را برمی‌گرداند و فقط‑خواندنی است. ردیف را از طریق [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) دسترسی پیدا کنید.

مثال فایل ‎[row‑height‑input.pptx](row-height-input.pptx) را بارگذاری می‌کند که اولین شکل در اولین اسلاید یک جدول است. ردیف اول آن در 70 پوینت شروع می‌شود. سلول‌ها از متن Arial با اندازه 18 پوینت، بسته شدن متن و حاشیه‌های بالا و پایین 6 پوینت استفاده می‌کنند؛ متن طولانی‌تر در ستون دوم به خطوط متعدد می‌پیچد. مثال حداقل ارتفاع را به 100 پوینت افزایش می‌دهد، سپس به 20 پوینت کاهش می‌دهد، بعد از هر تغییر ارتفاع واقعی را چاپ می‌کند و هر دو نتیجه را ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

با ارائه ارائه‌شده، افزایش حداقل فضای بیشتری به ردیف اضافه می‌کند. کاهش آن این فضا را حذف می‌کند، اما ارتفاع واقعی بیش از 20 پوینت باقی می‌ماند زیرا متن و حاشیه‌های سلول به فضای بیشتری نیاز دارند. فقط کاهش حداقل نمی‌تواند ردیف را زیر فضای مورد نیاز محتوای آن بکشاند.

چند عامل بر ارتفاع واقعی تأثیر می‌گذارند:

- **متن و اندازه قلم:** متن طولانی‌تر، شکست سطر صریح یا قلم بزرگ‌تر می‌تواند فضای عمودی بیشتری نیاز داشته باشد.
- **بسته شدن متن و عرض ستون:** با فعال بودن بسته شدن، یک [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) باریک‌تر می‌تواند خطوط بیشتری ایجاد کند. ستون وسیع‌تر می‌تواند فضای مورد نیاز عمودی را کاهش دهد.
- **حاشیه‌های سلول:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) و [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) فضای عمودی اضافه می‌کنند. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) و [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) عرض موجود برای متن را کاهش می‌دهند و می‌توانند بسته شدن اضافی ایجاد کنند.

برای این جدول بدون سلول‌های ادغام‌شده، سلولی که بیشترین فضای عمودی را نیاز دارد، حد پایین مبتنی بر محتوا برای کل ردیف را تعیین می‌کند. برای کوتاه‌تر کردن ردیف، ممکن است نیاز به کوتاه کردن متن، کاهش اندازه قلم یا حاشیه‌ها، یا بزرگ‌تر کردن یک ستون داشته باشید.

تصاویر زیر همان جدول را با همان مقیاس نشان می‌دهند. در این اجرا، ارتفاع‌های واقعی 70، 100 و 55.2 پوینت بودند: ردیف نهایی بلندتر از حداقل 20 پوینت باقی ماند. اندازه‌گیری دقیق متن می‌تواند بسته به قلم‌های موجود در محیط شما متفاوت باشد. نتایج ذخیره‌شده را دانلود کنید: [increased minimum](row-height-increased.pptx) و [decreased minimum](row-height-decreased.pptx).

| حداقل اصلی 70 پوینت، واقعی 70 پوینت | حداقل افزایش یافته 100 پوینت، واقعی 100 پوینت | حداقل کاهش یافته 20 پوینت، واقعی 55.2 پوینت |
| --- | --- | --- |
| ![جدول اصلی با ردیف اول 70‑پوینت.](row-height-before.png) | ![جدول پس از افزایش حداقل ردیف اول به 100 پوینت.](row-height-increased.png) | ![جدول پس از کاهش حداقل ردیف اول به 20 پوینت؛ متن بسته شده ردیف را بلندتر از حداقل نگه می‌دارد.](row-height-decreased.png) |

## **تنظیم ردیف اول به عنوان سرصفحه**

از ویژگی [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) برای علامت‌گذاری ردیف اول به منظور قالب‌بندی سرصفحه استفاده کنید. ظاهر آن به سبک جدول اعمال‌شده به جدول بستگی دارد.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. جدول ذخیره‌شده به عنوان اولین شکل در اسلاید را دسترسی پیدا کنید.
4. قالب‌بندی سرصفحه را برای ردیف اول فعال کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایلی به نام `table.pptx` نیاز دارد که جدول به عنوان اولین شکل در اولین اسلاید داشته باشد. قالب‌بندی سرصفحه برای ردیف اول فعال می‌شود و `First_row_header.pptx` ذخیره می‌گردد.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون ردیف یا ستون جدول**

ردیف‌ها یا ستون‌ها را کلون کنید تا محتوایشان و قالب‌بندی‌ آن‌ها را دوباره استفاده کنید. می‌توانید یک کپی را به انتهای جدول اضافه کنید یا در موقعیتی خاص درج کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. جدول را با متد [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) اضافه کنید.
5. ردیف‌های مورد نیاز را کلون کنید.
6. ستون‌های مورد نیاز را کلون کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایلی به نام `Test.pptx` نیاز دارد که حداقل یک اسلاید داشته باشد. جدولی با سه ستون و پنج ردیف ایجاد می‌کند که ابعاد آن‌ها بر حسب پوینت مشخص شده‌اند. نسخه‌های کپی‌شده از ردیف و ستون اول را اضافه می‌کند، سپس نسخه‌های کپی‌شده از ردیف و ستون دوم را در شاخص 3 (موقعیت چهارم) وارد می‌کند. جدول حاصل دارای هفت ردیف و پنج ستون است. آرگومان `False` کلونینگ را در ردیف‌ها یا ستون‌های ادغام‌شده مجاور غیرفعال می‌کند؛ این جدول سلول ادغام‌شده‌ای ندارد.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف ردیف یا ستون از جدول**

ردیف‌ها یا ستون‌هایی که دیگر نیازی به آن‌ها ندارید را از جدول حذف کنید. حذف یک مورد شاخص‌های ردیف‌ها یا ستون‌های پس از آن را جابه‌جا می‌کند.

1. یک ارائه با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. جدول را با متد [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) اضافه کنید.
5. ردیف دوم و ستون دوم را حذف کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال یک جدول سه در سه ایجاد کرده و ردیف و ستون با شاخص 1 را حذف می‌کند؛ جدول دو در دو در `TestTable_out.pptx` باقی می‌ماند. ابعاد بر حسب پوینت هستند. آرگومان `False` حذف ردیف‌ها یا ستون‌های ادغام‌شده مجاور را غیرفعال می‌کند؛ این جدول سلول ادغام‌شده‌ای ندارد.

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

قالب‌بندی متن را برای کل ردیف اعمال کنید تا سلول‌های آن یکدست بمانند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به طور جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. جدول موجود در اولین اسلاید را دسترسی پیدا کنید.
3. برای ردیف اول [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) را تنظیم کنید.
4. برای ردیف اول [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) و [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) را تنظیم کنید.
5. برای ردیف دوم [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) را تنظیم کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایلی به نام `table.pptx` نیاز دارد که جدول به عنوان اولین شکل در اولین اسلاید داشته باشد و حداقل دو ردیف داشته باشد. متن 25‑پوینت، ترازبندی راست و حاشیه راست پاراگراف 20 پوینت را به ردیف اول اعمال می‌کند، سپس متن عمودی را در ردیف دوم تنظیم می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

قالب‌بندی متن را برای کل ستون اعمال کنید تا سلول‌های آن یکدست بمانند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به طور جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. جدول موجود در اولین اسلاید را دسترسی پیدا کنید.
3. برای ستون اول [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) را تنظیم کنید.
4. برای ستون اول [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) و [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) را تنظیم کنید.
5. برای ستون دوم [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) را تنظیم کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

مثال به فایلی به نام `table.pptx` نیاز دارد که جدول به عنوان اولین شکل در اولین اسلاید داشته باشد و حداقل دو ستون داشته باشد. متن 25‑پوینت، ترازبندی راست و حاشیه راست پاراگراف 20 پوینت را به ستون اول اعمال می‌کند، سپس متن عمودی را در ستون دوم تنظیم می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت ویژگی‌های سبک جدول**

از ویژگی [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) برای بازیابی پیش‌تنظیم اعمال‌شده به یک جدول و استفاده مجدد از آن در جدول دیگر استفاده کنید. این پیش‌تنظیم را به جای بازنویسی قالب‌بندی سلول‌های فردی شناسایی می‌کند.

مثال یک جدول ایجاد می‌کند، [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) را اعمال می‌کند و پیش‌تنظیم را بر می‌گرداند. زمانی که پیش‌تنظیم بازیابی‌شده با پیش‌تنظیم اعمال‌شده مطابقت داشته باشد، `True` چاپ می‌کند و جدول در `table.pptx` ذخیره می‌شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدولی که قبلاً ایجاد شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستری را به ارث می‌برد و همچنان می‌توانید پرکننده‌ها، مرزبندها و رنگ‌های متن را بر روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

نه، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب جدید پر کنید.

**آیا می‌توانم ستون‌های راه‌راه (banded) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص حفظ کنم؟**

بله. ستون‌های راه‌راه را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر سبک جدول ارجحیت دارد.
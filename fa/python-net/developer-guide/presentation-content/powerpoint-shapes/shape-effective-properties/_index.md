---
title: "دریافت ویژگی‌های مؤثر شکل‌ها از ارائه‌ها در پایتون"
linktitle: "ویژگی‌های مؤثر"
type: docs
weight: 50
url: /fa/python-net/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- سیستم نورپردازی
- شکل برج
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پرکننده
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "آموزش استفاده از Aspose.Slides برای پایتون از طریق .NET برای تشخیص قالب‌بندی محلی، ارث‌برداری‌شده و مؤثر شکل‌ها در ارائه‌های PowerPoint."
---
## **درک ویژگی‌های محلی، ارث‌برداری‌شده و مؤثر**

قالب‌بندی در PowerPoint می‌تواند از چندین منبع آمده باشد. مقداری که به طور مستقیم بر روی یک شی ذخیره می‌شود، **مقدار محلی** آن است. اگر این مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد نگاه می‌کند، مانند پیش‌فرض پاراگراف، سبک متن، یک طرح یا اسلاید اصلی، یک تم یا پیش‌فرض‌های سطح ارائه. این مقادیر **مقدارهای ارث‌برداری‌شده** نامیده می‌شوند. مقداری که پس از حل کل سلسله‌مراتب باقی می‌ماند، **مقدار مؤثر** است که برای رندر شی استفاده می‌شود.

به عنوان مثال، ممکن است یک بخش متن ارتفاع قلم خود را تعریف نکرده باشد. مقدار محلی آن در [font_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ibaseportionformat/font_height/) سپس `float("nan")` است که به معنای «در اینجا تنظیم نشده» می‌باشد. این بخش می‌تواند ارتفاع را از پاراگراف خود، سبک متن پیش‌فرض ارائه، یا منبع قابل اعمال دیگر به ارث ببرد. فراخوانی [get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iportionformat/get_effective/) بر روی قالب بخش، ارتفاع نهایی حل‌شده را برمی‌گرداند.

از دو نوع داده قالب‌بندی برای مقاصد مختلف استفاده کنید:

- برای خواندن یا تغییر یک شی قالب محلی، مانند [IPortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iportionformat/)، زمانی که نیاز به کنترل مکان تعریف مقدار دارید.
- برای خواندن یک شی داده مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iportionformateffectivedata/)، زمانی که به نتیجه نهایی و رندر شده نیاز دارید. داده‌های مؤثر فقط‑خواندنی هستند.

## **مقایسه مقادیر محلی، ارث‌برداری‌شده و مؤثر**

مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع‌های قلم را در سطوح ارائه، پاراگراف و بخش اعمال می‌نماید. هر گام مقادیری را که در آن سطوح تعریف شده‌اند چاپ می‌کند و مقدار مؤثر حاصل برای همان بخش متن را نشان می‌دهد. همچنین دلیل نیاز به خواندن دوباره داده‌های مؤثر پس از تغییرات قالب‌بندی را نشان می‌دهد.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # داده‌های مؤثر را پس از تغییرات قبلی بخوانید.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # مقادیر ارث‌برداری‌شده را در دو سطح مختلف تعریف کنید.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # یک مقدار محلی در بخش، هر دو مقدار ارث‌برداری‌شده را نادیده می‌گیرد.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # تغییر یک مقدار ارث‌برداری‌شده مقدار محلی موجود را نادیده نمی‌گیرد.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # مقدار محلی را پاک کنید. بخش اکنون دوباره از پاراگراف ارث می‌برد.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # مقدار پاراگراف را پاک کنید. پیش‌فرض ارائه حالا نتیجه را فراهم می‌کند.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

اولویت در این مثال، قالب‌بندی محلی بخش است، سپس قالب‌بندی پاراگراف، و سپس پیش‌فرض ارائه. اشیاء دیگر می‌توانند زنجیره‌های ارث‌بری متفاوتی داشته باشند، اما اصل یکسان است: مقدار صریح و خاص‌تر برنده می‌شود و [get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iportionformat/get_effective/) نتیجه نهایی را برمی‌گرداند.

## **دریافت ویژگی‌های مؤثر متن**

قالب‌بندی متن در چندین شی تقسیم می‌شود:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/itextframeformat/get_effective/) ویژگی‌های چارچوب متن مانند حاشیه‌ها، لنگرگیری، خود‑تنظیم و جهت متن عمودی را حل می‌کند.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/itextstyle/get_effective/) قالب‌بندی پاراگراف را برای هر سطح سبک متن حل می‌کند.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iparagraphformat/get_effective/) ویژگی‌های پاراگراف مانند تراز، تورفتگی و بولت‌ها را حل می‌کند.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iportionformat/get_effective/) ویژگی‌های کاراکتر مانند ارتفاع قلم، نوع فونت، رنگ، بولد و ایتالیک را حل می‌کند.

برای مثال بعدی، `text-formatting.pptx` باید حداقل یک اسلای드 و یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با چارچوب متنی غیر خالی داشته باشد. AutoShape می‌تواند در هر موقعیتی از مجموعه شکل‌ها ظاهر شود؛ کد یک شی مناسب را جستجو می‌کند و قبل از استفاده آن را تأیید می‌نماید.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **دریافت ویژگی‌های مؤثر سه‌بعدی**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformat/get_effective/) یک شی [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/) را برمی‌گرداند که تمام تنظیمات سه‌بعدی حل‌شده را گروه‌بندی می‌کند. ویژگی‌های [camera](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/camera/)، [light_rig](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/light_rig/)، [bevel_top](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) و [bevel_bottom](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) داده‌های مؤثر مربوطه را نشان می‌دهند. خواندن این تنظیمات مرتبط به‌صورت هم‑زمان درک ظاهر نهایی سه‌بعدی یک شکل را آسان‌تر می‌کند.

برای این مثال، `shape-3d.pptx` باید حداقل یک شکل در اسلاید اول خود داشته باشد. اگر می‌خواهید خروجی شامل مقادیری متفاوت از پیش‌فرض‌ها باشد، دوربین سه‌بعدی، نورپردازی یا تنظیمات برج کوجکی را بر روی آن شکل اعمال کنید.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **دریافت قالب‌بندی مؤثر جدول**

قالب‌بندی جدول می‌تواند از سبک جدول و از قالب‌های اعمال شده بر کل جدول، یک ستون، یک ردیف یا یک سلول منفرد بیاید. برای تداخل بین پرکردن‌های صریح تعریف‌شده، اولویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی استفاده‌شده برای رسم آن سلول است.

برای این مثال، `table-formatting.pptx` باید حداقل یک جدول در اسلاید اول خود داشته باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به‌جای فرض اینکه `shapes[0]` یک جدول است، به دنبال یک شی [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) می‌گردد.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

اگر به رنگ نیاز دارید نه فقط نوع پرکننده، ابتدا نوع پرکننده مؤثر [fill_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ifillformateffectivedata/fill_type/) را بررسی کنید و سپس ویژگی مربوط به آن نوع را بخوانید، برای مثال [solid_fill_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) برای پرکنندهٔ جامد.

## **دوباره‌خوانی داده‌های مؤثر پس از تغییرات**

داده‌های مؤثر توصیف‌کنندهٔ سلسله‌مراتب قالب‌بندی در زمان حل هستند. پس از تغییر هر چیزی که می‌تواند در آن سلسله‌مراتب شرکت کند، دوباره `get_effective` را فراخوانی کنید، از جمله:

- قالب‌بندی محلی شی؛
- پیش‌فرض‌های پاراگراف یا چارچوب متن؛
- سبک جدول، قالب جدول، ستون، ردیف یا سلول؛
- قالب‌بندی طرح یا اسلاید اصلی؛
- داده‌های تم یا پیش‌فرض‌های سطح ارائه؛
- طرح یا اسلاید اصلی اختصاص داده‌شده به یک اسلاید.

دادهٔ مؤثر را به‌عنوان یک snapshot دائمی نگه ندارید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی ذخیره‌سازی کند و یک فراخوانی بعدی `get_effective` می‌تواند آن داده‌ها را تازه‌سازی کند. اگر نیاز به مقایسهٔ مقادیر قبل و بعد از تغییر دارید، مقادیر اسکالار مورد نیاز (مانند ارتفاع قلم، رنگ، تراز یا عرض برج) را پیش از اعمال تغییر در متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شی قالب محلی مناسب را به‌روزرسانی کنید و سپس `get_effective` را فراخوانی کنید تا نتیجه را تأیید کنید. خود اشیاء دادهٔ مؤثر فقط‑خواندنی هستند.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که کدام سطح مقدار مؤثر را فراهم کرده است؟**

دادهٔ مؤثر تنها مقدار نهایی را شامل می‌شود، نه منبع آن. باید اشیاء محلی مربوط از سطح خاص‌ترین به سمت عمومی‌تر بررسی شوند. برای متن، این می‌تواند شامل بخش، پاراگراف، چارچوب متن، طرح، اسلاید اصلی، تم و پیش‌فرض‌های ارائه باشد. مقادیر تعریف‌نشده مانند `float("nan")` یا `None` نشان می‌دهند که جستجو به سطح دیگری ادامه می‌یابد.

**چه می‌شود وقتی هیچ سطحی ویژگی را تعریف نکند؟**

Aspose.Slides مقدار پیش‌فرض مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در دادهٔ مؤثر ظاهر می‌شود حتی اگر هیچ شی محلی صریحاً آن را تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر مقدار محلی است؟**

مقدار محلی بر محاسبهٔ ارث‌بری پیروز شده است. این رفتار زمانی پیش می‌آید که ویژگی به‌طور صریح بر روی شی تنظیم شده باشد و هیچ قانون خاص‌تری آن را بازنویسی نکرده باشد.

**کی باید به جای داده‌های مؤثر از داده‌های محلی استفاده کنم؟**

از داده‌های محلی برای بررسی یا ویرایش یک سطح خاص قالب‌بندی استفاده کنید. از داده‌های مؤثر زمانی استفاده کنید که به ظاهر نهایی پس از حل ارث‌بری، قوانین تم و سبک‌های قابل اعمال نیاز دارید. مثال **مقایسه مقادیر محلی، ارث‌برداری‌شده و مؤثر** هر دو مورد را در یک جریان کاری نشان می‌دهد.
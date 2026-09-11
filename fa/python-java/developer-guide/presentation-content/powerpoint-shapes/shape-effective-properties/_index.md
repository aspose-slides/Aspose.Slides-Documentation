---
title: دریافت ویژگی‌های مؤثر اشکال از ارائه‌ها در Python از طریق Java
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/python-java/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- شکل برجسته
- فریم متن
- سبک متن
- ارتفاع قلم
- فرمت پرکننده
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه از Aspose.Slides برای Python از طریق Java استفاده کنید تا قالب‌بندی محلی، به ارث‌رفته و مؤثر اشکال را در ارائه‌های PowerPoint تمایز دهید."
---
## **درک خصوصیات محلی، به ارث‌رفته و مؤثر**

قالب‌بندی PowerPoint می‌تواند از چندین منبع باشد. مقداری که مستقیماً بر روی یک شی ذخیره می‌شود **مقدار محلی** است. اگر این مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد نگاه می‌کند، مانند مقدار پیش‌فرض پاراگراف، سبک متن، قالب‌بندی لایه یا اسلاید مستر، تم یا مقادیر پیش‌فرض سطح ارائه. این مقادیر **مقدارهای به ارث رسیده** هستند. مقداری که پس از حل کامل سلسله‌مراتب باقی می‌ماند **مقدار مؤثر** است — مقداری که برای رندر شی استفاده می‌شود.

به عنوان مثال، ممکن است یک بخش متن ارتفاع قلم خود را تعریف نکند. مقدار محلی [getFontHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#getFontHeight) آن سپس `float("nan")` است که به معنای «در اینجا تنظیم نشده» می‌باشد. این بخش می‌تواند ارتفاعی را از پاراگراف خود، سبک پیش‌فرض متن ارائه، یا منبع دیگری به ارث ببرد. فراخوانی [getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#getEffective) بر روی فرمت بخش، ارتفاع نهایی حل‌شده را برمی‌گرداند.

از دو نوع داده قالب‌بندی برای مقاصد مختلف استفاده کنید:

- یک شی قالب محلی، مانند [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/)، را بخوانید یا تغییر دهید، زمانی که نیاز دارید محل تعریف مقدار را کنترل کنید.
- یک شی داده مؤثر، مانند `PortionFormatEffectiveData`، را بخوانید، زمانی که به نتیجه نهایی رندر شده نیاز دارید. داده‌های مؤثر فقط‌خواندنی هستند.

## **مقایسه مقادیر محلی، به ارث‌رفته و مؤثر**

مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع‌های قلم را در سطوح ارائه، پاراگراف و بخش اعمال می‌گیرد. در هر مرحله مقادیر تعریف‌شده در آن سطوح چاپ می‌شوند و مقدار مؤثر حاصل برای همان بخش متن نمایش داده می‌شود. این همچنین نشان می‌دهد چرا پس از تغییرات قالب‌بندی باید داده‌های مؤثر دوباره خوانده شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # داده‌های مؤثر را پس از تغییرات قبلی بخوانید.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # مقادیر به ارث‌رفته را در دو سطح مختلف تعریف کنید.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # یک مقدار محلی در بخش، هر دو مقدار به ارث‌رفته را نادیده می‌گیرد.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # تغییر یک مقدار به ارث‌رفته، مقدار محلی موجود را نادیده نمی‌گیرد.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # مقدار محلی را پاک کنید. بخش اکنون دوباره از پاراگراف به ارث می‌برد.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # مقدار پاراگراف را پاک کنید. پیش‌فرض ارائه اکنون نتیجه را فراهم می‌کند.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


اولویت در این مثال، قالب‌بندی محلی بخش است، سپس قالب‌بندی پاراگراف، و سپس مقدار پیش‌فرض ارائه. اشیای دیگر می‌توانند زنجیره‌های ارث‌برداری متفاوتی داشته باشند، اما اصل همان است: مقدار صریح‌تری که خاص‌تر باشد پیروز می‌شود، و [getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#getEffective) نتیجه نهایی را برمی‌گرداند.

## **دریافت ویژگی‌های متن مؤثر**

قالب‌بندی متن در چندین شی تقسیم می‌شود:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getEffective) ویژگی‌های فریم متن را مانند حاشیه‌ها، مقیاس‌گذاری، خودتنظیم و جهت عمودی متن حل می‌کند.
- [TextStyle.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textstyle/#getEffective) قالب‌بندی پاراگراف برای هر سطح سبک متن را حل می‌کند.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getEffective) ویژگی‌های پاراگراف مانند تراز، تورفتگی و نقطه‌گذاری را حل می‌کند.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#getEffective) ویژگی‌های کاراکتر مانند ارتفاع قلم، نوع قلم، رنگ، بولد و ایتالیک را حل می‌کند.

برای مثال بعدی، فایل `text-formatting.pptx` باید حتماً حداقل یک اسلاید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) با فریم متنی غیر خالی داشته باشد. AutoShape می‌تواند در هر موقعیتی از مجموعه اشکال ظاهر شود؛ کد به‌دنبال شی مناسب می‌گردد و قبل از استفاده آن را اعتبارسنجی می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **دریافت ویژگی‌های سه‌بعدی مؤثر**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getEffective) یک شی `ThreeDFormatEffectiveData` را برمی‌گرداند که تمام تنظیمات سه‌بعدی حل‌شده را گروه‌بندی می‌کند. متدهای `getCamera`، `getLightRig`، `getBevelTop` و `getBevelBottom` داده‌های مؤثر مربوطه را نمایان می‌سازند. خواندن این تنظیمات مرتبط به‌صورت یک‌جا درک ظاهر نهایی سه‌بعدی یک شکل را آسان‌تر می‌کند.

برای این مثال، فایل `shape-3d.pptx` باید حداقل یک شکل در اسلاید اول داشته باشد. اگر می‌خواهید خروجی شامل مقادیری غیر از پیش‌فرض باشد، تنظیمات دوربین سه‌بعدی، نورپردازی یا برجستگی را بر آن شکل اعمال کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **دریافت قالب‌بندی جدول مؤثر**

قالب‌بندی جدول می‌تواند از سبک جدول و از قالب‌بندی‌های اعمال‌شده بر کل جدول، یک ستون، یک ردیف یا یک سلول منفرد ناشی شود. در مواردی که پرکننده‌های صریح‌تعریف‌شده تضاد داشته باشند، اولویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی است که برای رسم آن سلول استفاده می‌شود.

برای این مثال، فایل `table-formatting.pptx` باید حداقل یک جدول در اسلاید اول داشته باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به‌جای فرض اینکه `getShapes().get_Item(0)` یک جدول است، به‌دنبال یک [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) می‌گردد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

اگر به رنگ نیاز دارید و نه فقط نوع پرکننده، ابتدا `getFillType` مؤثر را بررسی کنید، سپس متدی که به آن نوع مربوط است را بخوانید — برای مثال، `getSolidFillColor` برای پرکنندهٔ یک‌دسته.

## **دوباره‌خواندن داده‌های مؤثر پس از تغییرات**

داده‌های مؤثر، سلسله‌مراتب قالب‌بندی را در زمان حل شدن توصیف می‌کنند. پس از تغییر هر چیزی که می‌تواند در این سلسله‌مراتب شرکت کند، دوباره [getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#getEffective) را فراخوانی کنید، از جمله:

- قالب‌بندی محلی شی;
- پیش‌فرض‌های پاراگراف یا فریم متن;
- سبک جدول، جدول، ستون، ردیف یا قالب سلول;
- قالب‌بندی لایه یا اسلاید مستر;
- داده‌های تم یا پیش‌فرض‌های سطح ارائه;
- لایه یا مستری که به یک اسلاید اختصاص داده شده است.

یک شی داده مؤثر را به‌عنوان تصویر فوری دائم نگهداری نکنید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی کش کند و فراخوانی بعدی [getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#getEffective) می‌تواند آن داده‌ها را به‌روزرسانی کند. اگر نیاز به مقایسه مقادیر قبل و بعد از تغییر دارید، مقادیر اسکالاری مورد نیاز خود—مانند ارتفاع قلم، رنگ، تراز یا عرض برجستگی—را قبل از اعمال تغییر در متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شی قالب محلی مناسب را به‌روزرسانی کنید و سپس [getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#getEffective) را فراخوانی کنید تا نتیجه را تأیید کنید. خود اشیای داده مؤثر فقط‌خواندنی هستند.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم کدام سطح مقدار مؤثر را فراهم کرده است؟**

داده‌های مؤثر فقط مقدار نهایی را در بر دارند، نه منبع آن. اشیای محلی قابل اعمال را از سطح بیشترین خصوصیت به سمت بیرون بررسی کنید. برای متن، این می‌تواند شامل بخش، پاراگراف، فریم متن، لایه، مستر، تم و پیش‌فرض‌های ارائه باشد. مقادیر تعریف‌نشده مانند `float("nan")` یا `None` نشان می‌دهند که جستجو به سطح دیگری ادامه می‌یابد.

**چه اتفاقی می‌افتد وقتی هیچ سطحی ویژگی‌ای را تعریف نکند؟**

Aspose.Slides مقدار پیش‌فرض مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در داده‌های مؤثر ظاهر می‌شود حتی اگر هیچ شی محلی آن را صریحاً تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر مقدار محلی است؟**

مقدار محلی محاسبه ارث‌بری را برنده شد. این زمانی انتظار می‌رود که ویژگی به‌صورت صریح بر روی شی تنظیم شده باشد و هیچ قاعدهٔ خاص‌تری آن را بازنویسی نکند.

**چه زمانی باید از داده‌های محلی به‌جای داده‌های مؤثر استفاده کنم؟**

از داده‌های محلی برای بررسی یا ویرایش یک سطح خاص قالب‌بندی استفاده کنید. از داده‌های مؤثر زمانی استفاده کنید که به ظاهر نهایی پس از ارث‌بری، قواعد تم و سبک‌های قابل اعمال نیاز دارید. [مثال کامل مقایسه](#compare-local-inherited-and-effective-values) هر دو را در یک جریان کاری نشان می‌دهد.
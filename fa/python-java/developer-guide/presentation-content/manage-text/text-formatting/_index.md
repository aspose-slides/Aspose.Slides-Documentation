---
title: قالب‌بندی متن ارائه در پایتون از طریق جاوا
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-java/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله حروف
- خصوصیات قلم
- خانواده قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصلهٔ خط
- ویژگی autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی‌ کنید."
---
## **مرور کلی**

این مقاله نحوه قالب‌بندی متن در ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای Python از طریق Java نشان می‌دهد. موضوعات شامل رنگ‌های پس‌زمینه، شفافیت، فاصله حروف، خصوصیات قلم، چرخش، فاصله بین پاراگراف‌ها، رفتار autofit، لنگر متن، توقف‌های تب و تنظیمات زبان است.

مگر اینکه به‌طور خاص ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن حاوی متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل به صورت صفر‑مبتنی هستند. مثال‌هایی که بخش‌های پر رنگ را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌نمایند، شامل قالب‌بندی پر رنگ وارث شده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌کردن متن دقیق یا موارد مطابق با عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض برای یک پاراگراف استفاده کنید یا برای بخش‌های متنی فردی از [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) بهره ببرید.

مثال زیر رنگ برجستهٔ خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجستهٔ صریح بر روی بخش‌های فردی بر این پیش‌فرض ارجحیت دارند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متنی با قلم پر نقش** تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # رنگ برجسته را برای بخش متن تنظیم کنید.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز کردن پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم تراز پاراگراف داخل یک چارچوب متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و ... باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تراز پاراگراف را به مرکز تنظیم کنید.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تراز کردن قلم‌ها در یک خط**

از [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و تراز را در هر یک از خطوط آن کنترل می‌کند.

مثال کاملا مستقل زیر چهار جعبه متن برچسب‌دار را در یک اسلاید ایجاد می‌کند. هر پاراگراف متن یکسانی با اندازه‌های 18، 36 و 54 پوینت دارد و تراز قلم متفاوتی دارد. از Arial استفاده می‌شود، autofit و wrap غیرفعال می‌شوند و چارچوب‌های متن به اندازه‌ای بزرگ هستند که یک خط را در بر بگیرند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![مقایسه تراز Baseline، Top، Center و Bottom با اندازه‌های قلم مختلف](font_alignment.png)

تراز قلم از متریک‌های قلم استفاده می‌کند، بنابراین لبه‌های قابل رؤیت حروف لزوماً دقیقاً هم‌سطح نیستند. مثال شامل یک حرف بزرگ و یک حرف پایین‌خانه برای نشان دادن تفاوت بین تراز baseline و bottom می‌شود. در دسترس بودن قلم و جایگزینی آن، کاراکترهای استفاده‌شده و تفاوت در اندازه‌های قلم بر نتیجه تاثیر می‌گذارند. ابعاد چارچوب، حاشیه‌ها، فاصله خط، wrap و autofit نیز بر چیدمان اثر دارند؛ برای مقایسه حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) است که تراز افقی پاراگراف را کنترل می‌کند و از [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) که بلوک متن را به صورت عمودی داخل شکل موقعیت می‌دهد. قالب‌بندی superscript و subscript از طریق [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) بخش‌های فردی را نسبت به baseline جابجا می‌کند نه اینکه تراز قلم را برای خطوط پاراگراف تنظیم کند.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگی که به [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را بر **کل پاراگراف** اعمال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # رنگ پر متن را به رنگ شفاف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت را بر **بخش‌های متنی با قلم پر نقش** اعمال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # شفافیت بخش متن را تنظیم کنید.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله حروف برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) برای گسترش یا فشرده‌سازی فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد پایتون زیر نشان می‌دهد چگونه فاصله حروف را در **کل پاراگراف** گسترش دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # توجه: برای فشرده شدن فاصله حروف از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # گسترش فاصله حروف.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله حروف را در **بخش‌های متنی با قلم پر نقش** گسترش دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # توجه: برای فشرده‌کردن فاصله حروف از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3) # گسترش فاصله حروف.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله حروف در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از متن مشابه در PowerPoint ظاهر شود. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم متاثر استفاده می‌کنند، غیرفعال کنید. مقدار [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) را بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. نام‌های قلم مؤثر، از جمله قلم‌های وارث شده، بررسی می‌شوند و برای بخش‌هایی که از Roboto استفاده می‌کنند، آستانهٔ 100 پوینت تنظیم می‌شود؛ این کار کرنینگ را برای بخش‌های مطابقت‌دار با اندازهٔ قلم زیر 100 پوینت غیرفعال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای متن مطابقت‌دار زیر آستانه، این تنظیم کرنینگ را پیشگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت خصوصیات قلم متن**

خصوصیات قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا برای بخش‌های منفرد از طریق [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با پر نقش، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های منفرد بر این پیش‌فرض‌ها ارجحیت دارد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # خصوصیات قلم برای پاراگراف را تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![خصوصیات قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر 13 پوینت Times New Roman، قالب ایتالیک و زیرخط نقطه‌دار را بر بخش‌هایی که قالب مؤثرشان پر نقش است اعمال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # خصوصیات قلم برای بخش متن را تنظیم کنید.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![خصوصیات قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **کنترل نرمال‌سازی ارتفاع متن**

از [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) هنگام بازتولید تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع حروف استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی حروف را به‌صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل رؤیت یکسانی درون بخش متنی داشته باشند. این کار تضمین‌کنندهٔ ارتفاع برابر متن در قلم‌های مختلف نیست.

مقدار ویژگی را به [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) تنظیم کنید تا صراحتاً نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool.NotDefined` تنظیم محلی را خالی می‌گذارد تا بخش مقدار را از مثالاً پاراگراف [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) به ارث ببرد. این به معنای `False` نیست. از [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) استفاده کنید و `getNormaliseHeight` را روی قالب مؤثر برگردانده شده بخوانید تا مقدار بولی حل‌شده را بدست آورید.

مثال کاملاً مستقل زیر نیاز به نصب **Arial** دارد. دو بلوک متن حاوی حروف بزرگ، حروف کوچک، حروف پایین‌خانه و نویسه‌های لهجه‌دار در 54 پوینت ایجاد می‌کند. هر دو پاراگراف به‌طور پیش‌فرض نرمال‌سازی را فعال می‌کند. بخش بالایی صراحتاً آن را غیرفعال می‌کند؛ بخش پایین‌تر آن را ارث می‌برد. اندازهٔ فریم‌ها، حاشیه‌ها و فاصله پاراگراف یکسان هستند، با wrap و autofit غیرفعال برای حفظ سازگاری مقایسه. مثال رشتهٔ `False: False` و `NotDefined: True` را چاپ می‌کند سپس «text_height_normalization.pptx» را ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مقایسهٔ زیر از ارائهٔ ذخیره‌شده استخراج شده است. ردیف بالایی نرمال‌سازی غیرفعال (`False`) دارد؛ ردیف پایینی تنظیم فعال را ارث می‌برد (`NotDefined` → `True`). برای بازتولید این ظاهر، Arial باید نصب باشد.

![متن 54‑پوینت Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌برده در زیر](text_height_normalization.png)

نرمال‌سازی ارتفاع حروف را بدون تغییر مقدار [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) که اندازهٔ قلم را به پوینت مشخص می‌کند، تغییر می‌دهد. پاراگراف [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) فاصلهٔ خطوط را کنترل می‌کند، در حالی که [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) در فریم متن نحوهٔ تنظیم متن یا محفظه را برای تناسب تعیین می‌کند. این تنظیمات مقاصد متفاوتی دارند و می‌توانند به طور مستقل بر چیدمان کلی اثر بگذارند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و وراثت، به [مدیریت پاراگراف](/slides/fa/python-java/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌خورده**

از [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) بر یک بخش متنی استفاده کنید تا اصلاحات، اصطلاحات لغو شده یا قیمت‌های قبلی را بدون حذف متن اصلی نشان دهید. برای یک یا دو خط روی متن، آن را به [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف خط‌خورده، از [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) استفاده کنید. این به‌صورت صریح اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی پیرامونی خط‌خورده باشد. در مقابل، [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش قالب‌بندی را از پاراگراف ارث ببرد. این به معنای حذف خط‌خورده نیست. برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌برده، از [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) استفاده کنید.

مثال خودکفا زیر سه مقایسهٔ قیمتی ایجاد می‌کند. هر پاراگراف دارای بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت فعلی است؛ فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌خورده را اعمال و سپس حذف می‌کند؛ ردیف‌های دیگر به ترتیب خط‌خوردهٔ تک و دو خطی را حفظ می‌کنند. تغییر این تنظیم متن و سایر قالب‌بندی‌های آن، از جمله پر نقش بودن قیمت قبلی را حفظ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # خط‌خورده را اعمال کنید، سپس به‌صورت صریح آن را از اولین قیمت قبلی حذف کنید.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه، از بالا به پایین: بدون خط‌خورده، خط‌خوردهٔ تک، و خط‌خوردهٔ دوخطی.

![قیمت‌های قبلی بدون خط‌خورده، با خط‌خوردهٔ تک و با خط‌خوردهٔ دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) برای تعیین جهت پیش‌تعریف‌شدهٔ متن داخل یک شکل استفاده کنید.

کد زیر جهت متن را در شکل به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) تنظیم می‌کند؛ این کار متن را **90 درجه به‌صورت خلاف ساعت** می‌چرخاند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) برای تعیین زاویهٔ چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را درون شکل به‌صورت 3 درجه ساعت‌گرد می‌چرخاند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خط پاراگراف‌ها**

Aspose.Slides توابع [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصله پاراگراف ارائه می‌دهد. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به‌صورت درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط به‌صورت پوینت استفاده کنید.

مثال زیر فاصلهٔ داخلی اولین پاراگراف را به 200 ٪ از ارتفاع خط (دوبل اسپیس) تنظیم می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصلهٔ خط داخلی پاراگراف](line_spacing.png)

## **کنترل شکستن خط**

قوانین شکستن خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و متون شرق آسیا را مخلوط می‌کنند، مفید هستند. توابع زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) هستند و بر کل پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) قوانین شکستن خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته شدن متون و علامت‌های نقطه‌گذاری شرق آسیا را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) قوانین شکستن خط شرق آسیا را کنترل می‌کند، شامل محدودیت‌های کاراکترهای آغاز و انتهای خط.

این قوانین جایگزین [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) نمی‌شوند؛ آن گزینه بسته شدن خودکار متن را درون فریم متن فعال می‌کند. این قوانین بر چیدمان هنگام بسته شدن تأثیر می‌گذارند؛ کاراکترهای شکستن خط را وارد نمی‌کنند. یک شکستن خط صریح یک خط جدید را درون پاراگراف ایجاد می‌کند بدون توجه به عرض موجود.

مثال خودکفا زیر یک بلوک متنی باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو گزینهٔ شکستن خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قوانین، مقدار مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. مثال از Arial 24 پوینت و SimSun با عرض فریم 160 پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) با [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد فریم ثابت بمانند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کنترل نقطه‌گذاری معلق**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) اجازه می‌دهد علامت‌های نقطه‌گذاری مجاز فراتر از لبهٔ راست خط متن امتداد یابند به‌جای این‌که در خط بعدی قرار گیرند. این ویژگی برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودکفا زیر نقطه‌گذاری معلق را در یک فریم متن با عرض 100 پوینت فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌نماید. با Arial 24 پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و فراتر از لبهٔ راست متن امتداد می‌یابد. مقدار ویژگی را به [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) تنظیم کنید تا مقایسه کنید: با این تنظیمات، نقطه در یک خط جداگانه قرار می‌گیرد. wrap فعال و autofit غیرفعال می‌شود تا عرض موجود ثابت بماند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

همهٔ علامت‌های نقطه‌گذاری نمی‌توانند معلق شوند. شرایط قلم و چیدمان توصیف‌شده در بخش [کنترل شکستن خط](#control-line-breaking) نیز برای این مقایسه اعمال می‌شوند: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند متن وقتی بیش از مرزهای محفظهٔ خود می‌شود، چگونه رفتار کند. از آن برای کنترل اینکه آیا متن کوچک شود، بیش از حد خارج شود یا شکل به‌صورت خودکار اندازهٔ خود را تغییر دهد، استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود اندازهٔ شکل را تغییر دهد و نتیجه در «autofit_type.pptx» ذخیره می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای شمارش خطوط پس از بسته شدن خودکار و مشاهدهٔ نحوهٔ تغییر عرض متن یا شکل، به [شمارش خطوط رندر شده](/slides/fa/python-java/manage-paragraph/) مراجعه کنید. خود شمارش خطوط بیانگر این نیست که متن از محفظهٔ خود بیرون می‌زنند یا نه.

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) تعیین می‌کند متن به‌صورت عمودی داخل شکل چگونه موقعیت یابد؛ برای مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه در «text_anchor.pptx» ذخیره می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم تب‌بندی متن**

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر اندازهٔ پیش‌فرض تب را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌تراز در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است، اثر می‌گذارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان تصحیح املایی**

Aspose.Slides متد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح املایی برای یک بخش متنی را تنظیم کنید. زبان تصحیح املایی تعیین می‌کند PowerPoint از کدام لغت‌نامه برای بررسی املایی و گرامری استفاده کند.

مثال زیر به «presentation.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید دارد و حداقل یک پاراگراف دارد، نیاز دارد. محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان تصحیح املایی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # شناسه زبان تصحیح املایی را تنظیم کنید.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هر دو [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) و [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) را حفظ کنید. مثال خودکفا زیر یک بخش منبع با زبان انگلیسی (ایالات متحده) به عنوان زبان اصلی و فرانسوی به عنوان زبان جایگزین ایجاد می‌کند و متن و شناسه‌ها را به بخش در یک ارائهٔ جدید کپی می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # اگر منبع زبان جایگزینی نداشته باشد، None مقدار مقصد را پاک می‌کند.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای آزمایش منبع بدون زبان جایگزین، اختصاص `"fr-FR"` را حذف کنید. شناسهٔ جایگزین سپس `None` خواهد بود و همان عبارت کپی عدم حضور آن را بدون افزودن مقدار پیش‌فرض حفظ می‌کند، حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبانی هستند. حفظ آن‌ها تعیین‌کنندهٔ این نیست که کدام لغت‌نامه توسط PowerPoint برای بررسی املایی یا گرامری انتخاب می‌شود.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد ارائه ایجاد می‌شود، استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی (ایالات متحده) ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متنی آن `en-US` را چاپ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # یک شکل مستطیل با متن اضافه کنید.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # زبان اولین بخش را بررسی کنید.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

مثال زیر قلم 14‑پوینت پر نقش را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌نماید. متن می‌تواند این پیش‌فرض‌ها را ارث ببرد مگر آنکه قالب‌بندی خاص‌تری آنها را بازنویسی کند.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # دریافت قالب پاراگراف سطح بالایی.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج متن با اثر تماماً بزرگ‌حروف (All‑Caps)**

در PowerPoint، اعمال اثر **All Caps** بر قلم باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نشان داده شود حتی اگر ابتدا با حروف کوچک وارد شده باشد. هنگام بازیابی چنین بخشی از متن با Aspose.Slides، کتابخانه دقیقاً همان متنی را که وارد شده است برمی‌گرداند. برای مطابقت با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `All` باشد، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. اولین پاراگراف آن اولین بخش خود حاوی «Hello, Aspose!» با اثر All Caps اعمال‌شده دارد، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه می‌توان متن داخل جدول در یک اسلاید را اصلاح کرد؟**

برای اصلاح متن داخل جدول در یک اسلاید، از [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) تنظیم کنید.

**چگونه می‌توان رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کرد؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. مقدار [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) را به [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) تنظیم کنید و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.
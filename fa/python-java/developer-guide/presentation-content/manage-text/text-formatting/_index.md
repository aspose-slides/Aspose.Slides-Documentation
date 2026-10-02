---
title: قالب‌بندی متن ارائه در پایتون از طریق جاوا
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-java/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینهٔ متن
- شفافیّت متن
- فاصله کاراکترها
- ویژگی‌های قلم
- خانوادهٔ قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصله خط
- خاصیت autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "متن را در ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق جاوا قالب‌بندی و استایل کنید. قلم‌ها، رنگ‌ها، تراز و موارد بیشتر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for Python via Java قالب‌بندی کنید. موضوعات شامل رنگ پس‌زمینه، شفافیت، فاصله بین کاراکترها، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار autofit، لنگر بندی متن، توقف‌های تب و تنظیمات زبان است.

مگر اینکه به‌طور خاص ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اسلاید اول یک جعبه متن است و اولین پاراگراف آن متن زیر را دارد. اندیس‌های اسلاید و شکل صفر-پایه هستند. مثال‌های استفاده از بخش‌های بولد، قالب‌بندی مؤثر را نشان می‌دهند که شامل قالب‌بندی ارث‌بری شده بولد است:

![متن نمونه](sample_text.png)

برای پیدا کردن و برجسته‌سازی متن به‌صورت دقیق یا تطابق‌های عبارات منظم، به بخش [Search and Replace Text](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید یا برای بخش‌های متنی فردی از [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) بهره ببرید.

مثال زیر رنگ برجسته خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح در بخش‌های فردی بر این پیش‌فرض اولویت دارند:

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

    # تنظیم رنگ برجسته برای کل پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم بولد** تنظیم کنید:

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
            # تنظیم رنگ برجسته برای بخش متن.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متن خاکستری](gray_text_portions.png)

## **تراز کردن پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) برای تعیین تراز پاراگراف درون یک فریم متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

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

    # تنظیم تراز پاراگراف به مرکز.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تراز کردن قلم‌ها درون یک خط**

از [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و تراز در هر یک از خطوط آن را کنترل می‌کند.

مثال کاملاً خودکفا زیر چهار جعبه متن برچسب‌دار را در یک اسلاید ایجاد می‌کند. هر پاراگراف همان متن را با اندازه‌های 18، 36 و 54 پوینت دارد و تراز قلم متفاوتی دارد. از Arial استفاده می‌کند، autofit و wrapping را غیرفعال می‌سازد و فریم‌های متن را به‌گونه‌ای بزرگ می‌کند که فقط یک خط جای بگیرد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

تراز قلم بر پایه معیارهای متریک قلم انجام می‌شود، بنابراین لبه‌های قابل‌مشاهدهٔ حروف لزوماً دقیقاً هم‌خط نمی‌شوند. مثال شامل یک حرف بزرگ و یک حرف پایین‌خط (descender) است تا تفاوت بین تراز baseline و bottom را نشان دهد. در دسترس بودن قلم و جایگزینی آن، حروف استفاده‌شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارد. ابعاد فریم، حاشیه‌ها، فاصله خطوط، wrapping و autofit نیز بر چینش تأثیر دارند؛ هنگام مقایسه حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) است که تراز افقی پاراگراف را کنترل می‌کند و همچنین از [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) که بلوک متن را به‌صورت عمودی درون شکل موقعیت می‌دهد. قالب‌بندی superscript و subscript از طریق [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) بخش‌های فردی را نسبت به baseline جابجا می‌کند و نه تراز قلم برای خطوط پاراگراف.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگی که به [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0 تا 255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را برای **کل پاراگراف** اعمال کنید:

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

کد زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با قلم بولد** اعمال کنید:

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
            # تنظیم شفافیت بخش متن.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکترها برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) برای گسترش یا فشردن فاصله بین کاراکترها در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌سازند.

کد پایتون زیر نشان می‌دهد چگونه فاصله کاراکترها را در **کل پاراگراف** افزایش دهید:

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

    # نکته: برای فشرده‌کردن فاصله کاراکترها از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # افزایش فاصله کاراکترها.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله کاراکترها را در **بخش‌های متنی با قلم بولد** افزایش دهید:

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
            # نکته: برای فشرده‌کردن فاصله کاراکترها از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3) # افزایش فاصله کاراکترها.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله کاراکترها در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیر فعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint دیده شود. این می‌تواند به دلیل این باشد که PowerPoint داده‌های کرنینگ برای برخی قلم‌ها را نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم مورد تأثیر استفاده می‌کنند غیرفعال کنید. با تنظیم [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) به مقدار بزرگتر از اندازه واقعی قلم، این کار انجام می‌شود. این مثال به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اسلاید اول نیاز دارد. نام‌های قلم مؤثر، شامل قلم‌های ارث‌بری شده، بررسی می‌شوند و آستانه 100 پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند تنظیم می‌شود؛ این کار کرنینگ را برای بخش‌های منطبق با اندازه قلم کمتر از 100 پوینت غیرفعال می‌کند:

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

برای متن‌های منطبق زیر آستانه، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به تطبیق رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) در سطح پاراگراف یا روی بخش‌های فردی از طریق [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با قالب‌بندی بولد، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح روی بخش‌های فردی بر این پیش‌فرض‌ها اولویت دارد:

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

    # تنظیم ویژگی‌های قلم برای پاراگراف.
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

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر 13 پوینت Times New Roman، قالب‌بندی ایتالیک و زیرخط نقطه‌ای را به بخش‌هایی که قالب‌بندی مؤثر آنها بولد است اعمال می‌کند:

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
            # تنظیم ویژگی‌های قلم برای بخش متن.
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

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت از پیش تعریف‌شدهٔ متن درون یک شکل استفاده کنید.

کد زیر جهت متن را در شکل به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه ضد ساعت‌گرد** می‌چرخاند:

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

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویهٔ چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را درون شکل 3 درجه ساعت‌گرد می‌چرخاند:

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

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides توابع [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصله پاراگراف‌ها ارائه می‌دهد. این خصوصیات به‌صورت زیر استفاده می‌شوند:

* برای تعیین فاصله خط به‌عنوان درصدی از ارتفاع خط، مقدار مثبت بدهید.
* برای تعیین فاصله خط به‌واحد پوینت، مقدار منفی بدهید.

مثال زیر فاصله داخل اولین پاراگراف را به 200% ارتفاع خط (دوبل اسپیس) تنظیم می‌کند:

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

![فاصله خط داخل پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و آسیای شرقی را ترکیب می‌کنند مفید است. توابع زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) هستند و بر کل پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) قواعد شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته شدن متن و نقطه‌گذاری آسیای شرقی را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) قواعد شکست خط آسیای شرقی را، شامل محدودیت‌های کاراکتر در ابتدا و انتهای خط، کنترل می‌کند.

این قواعد جایگزین [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) نمی‌شوند که wrapping خودکار را در فریم متن فعال می‌کند. آنها بر چیدمان تأثیر می‌گذارند اما کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح، خط جدیدی را درون پاراگراف ایجاد می‌کند، مستقل از عرض در دسترس.

مثال زیر یک بلوک متن باریک شامل چینایی و لاتین ایجاد می‌کند. هر دو گزینهٔ شکست خط به‌طور صریح تنظیم شده و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر قانون، مقدار مربوطه را تغییر دهید در حالی که تنظیم دیگر ثابت بماند. مثال از Arial 24 پوینت و SimSun با عرض فریم 160 پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) با [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد فریم ثابت بمانند.

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) اجازه می‌دهد نقطه‌گذاری مجاز از لبهٔ راست خط متن فراتر رود به‌جای اینکه در خط بعدی قرار گیرد. این تنظیم برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال زیر نقطه‌گذاری معلق را در فریم متنی 100 پوینت عرض فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌گردد. با Arial 24 پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» باقی می‌ماند و از لبهٔ راست متن فراتر می‌رود. برای مقایسه مقدار را به [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) تنظیم کنید: در این حالت نقطه در خط جداگانه‌ای قرار می‌گیرد. wrapping فعال و autofit غیرفعال است تا عرض در دسترس ثابت بماند.

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

همهٔ علائم نقطه‌گذاری قابلیت معلق شدن ندارند. شرایط قلم و چیدمان توضیح داده‌شده در بخش [control-line-breaking](#control-line-breaking) نیز برای این مقایسه اعمال می‌شود: تغییر قلم، عرض در دسترس، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل‌مشاهده را از بین ببرد.

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند متن هنگام تجاوز از مرزهای مخزن خود چگونه رفتار کند. از آن برای کنترل این‌که آیا متن کوچک می‌شود، خارج می‌شود یا شکل به‌طور خودکار اندازه‌گیری می‌شود، استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود اندازه‌گیری شود و نتیجه در «autofit_type.pptx» ذخیره می‌شود.

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

برای شمارش خطوط پس از بسته شدن خودکار و مشاهدهٔ تأثیر تغییر عرض متن یا شکل، به بخش [Count Rendered Lines](/slides/fa/python-java/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشان نمی‌دهد آیا متن از مخزن خود عبور کرده است یا خیر.

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) تعیین می‌کند متن به‌صورت عمودی داخل شکل چگونه موقعیت‌یابی شود؛ مثلاً در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه در «text_anchor.pptx» ذخیره می‌شود.

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

## **تنظیم تب متن**

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ تب پیش‌فرض را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌چین به 30 پوینت اضافه می‌کند. این تنظیمات بر متن حاوی کاراکترهای تب اثر می‌گذارند.

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

Aspose.Slides متد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) را فراهم می‌کند که به شما امکان می‌دهد زبان تصحیح املایی یک بخش متنی را تنظیم کنید. زبان تصحیح املایی تعیین می‌کند که بررسی املایی و گرامری در PowerPoint به کدام زبان انجام شود.

مثال زیر به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اسلاید اول و حداقل یک پاراگراف نیاز دارد. محتوای اولین پاراگراف را با «1。» جایگزین می‌کند، SimSun را به عنوان قلم تنظیم می‌کند و زبان تصحیح املایی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    # تنظیم شناسهٔ زبان اصلاح.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد ارائه ساخته می‌شود، استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی ایالات متحده ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متن آن `en-US` چاپ می‌کند.

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

مثال زیر قلم 14 پوینت بولد را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح‑بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را ارث‌بری کند مگر اینکه قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # دریافت قالب پاراگراف سطح بالا.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج متن با اثر All‑Caps**

در PowerPoint، اعمال افکت قلم **All Caps** باعث می‌شود متن در اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر ابتدا با حروف کوچک نوشته شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده برمی‌گرداند. برای تطبیق با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) را بررسی کنید و هنگام مقدار `All` رشتهٔ برگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» با یک جعبه متن به‌عنوان اولین شکل در اسلاید اول نیاز دارد. اولین بخش اولین پاراگراف آن شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده است.

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

## **پرسش‌های متداول**

**چگونه متن در جدول یک اسلاید را ویرایش کنم؟**

برای ویرایش متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) به‌روزرسانی کنید.

**چگونه یک رنگ گرادیان به متن در اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) را به [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) تنظیم کنید و نقاط توقف، جهت و شفافیت گرادیان را پیکربندی کنید.
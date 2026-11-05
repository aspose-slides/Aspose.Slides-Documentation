---
title: قالب‌بندی متن ارائه در Python
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- ترازبندی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قالب‌بندی و استایل متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET. فونت‌ها، رنگ‌ها، ترازبندی و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for Python via .NET قالب‌بندی کنید. این مقاله شامل رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری حروف، ویژگی‌های قلم، چرخش، فاصله‌گذاری پاراگراف، رفتار autofit، لنگر متن، توقف‌های تب و تنظیمات زبان می‌شود.

مگر در مواردی که به‌طور خاص گفته شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اسلاید اول آن یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. ایندکس اسلاید و شکل از صفر شروع می‌شود. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند، از قالب‌بندی مؤثر شامل قالب‌بندی بولد به‌ارث‌برده استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای پیدا کردن و برجسته‌سازی متن لغوی یا تطابق‌های عبارت منظم، به [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) استفاده کنید یا برای بخش‌های متنی منفرد از [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) استفاده کنید.

مثال زیر برجسته‌سازی خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح بر بخش‌های منفرد بر این پیش‌فرض ارجحیت دارند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # رنگ برجسته را برای تمام پاراگراف تنظیم کنید.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** تنظیم شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # رنگ برجسته را برای بخش متن تنظیم کنید.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **ترازبندی پاراگراف‌های متن**

برای تنظیم ترازبندی پاراگراف درون یک قاب متن از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) استفاده کنید. مقدار می‌تواند centered، left-aligned، right-aligned، justified و غیره باشد.

کد مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** ترازبندی کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم ترازبندی پاراگراف به مرکز.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف ترازبندی‌شده](aligned_paragraph.png)

## **ترازبندی قلم‌ها درون یک خط**

برای ترازبندی عمودی بخش‌های متنی با اندازه‌های قلم مختلف درون یک خط از [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و ترازبندی در هر یک از خطوط آن را کنترل می‌کند.

مثال خودکفا زیر چهار جعبه متن برچسب‌دار در یک اسلاید ایجاد می‌کند. هر پاراگراف متن یکسان را در اندازه‌های 18، 36 و 54 پوینت دارد و ترازبندی قلم متفاوتی دارد. از Arial استفاده می‌کند، autofit و wrapping را غیرفعال می‌کند و قاب‌های متن را به اندازه‌ای بزرگ می‌کند که تنها یک خط را بپذیرند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![مقایسه ترازبندی Baseline، Top، Center و Bottom با اندازه‌های قلم ترکیبی](font_alignment.png)

ترازبندی قلم از معیارهای متریک قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهده حروف لزوماً دقیقاً هم‌راستا نمی‌شوند. این مثال شامل یک حرف بزرگ و یک حرف کاهش‌دهنده است تا تفاوت بین ترازبندی پایه و پایین را نشان دهد. در دسترس بودن قلم و جایگزینی آن، کاراکترهای استفاده‌شده و تفاوت در اندازه قلم بر نتیجه تأثیر می‌گذارند. ابعاد قاب، حاشیه‌ها، فاصله‌گذاری خطوط، wrapping و autofit نیز بر طرح کلی تأثیر می‌گذارند؛ برای مقایسه حالت‌ها از همان قلم و تنظیمات طرح استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) است که ترازبندی افقی پاراگراف را کنترل می‌کند و همچنین متفاوت از [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) است که بلوک متن را به صورت عمودی داخل شکل موقعیت می‌دهد. قالب‌بندی superscript و subscript از طریق [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) بخش‌های منفرد را نسبت به خط پایه جابه‌جا می‌کند نه اینکه ترازبندی قلم برای خطوط پاراگراف تنظیم شود.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص داده‌شده به [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت را برای **تمام پاراگراف** اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم پر رنگ سیاه نیمه شفاف برای متن.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با قلم بولد** اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تنظیم شفافیت بخش متن.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله حروف برای متن**

برای گسترش یا فشردن فاصله بین حروف در یک جعبه متن از [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد Python زیر نشان می‌دهد چگونه فاصله حروف را در **تمام پاراگراف** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # نکته: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # گسترش فاصله حروف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله حروف در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله حروف را در **بخش‌های متنی با قلم بولد** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # نکته: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # گسترش فاصله حروف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله حروف در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن Kerning برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های kerning را برای برخی قلم‌ها نادیده بگیرد، حتی زمانی که قلم حاوی اطلاعات معتبر kerning باشد و kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک کردن خروجی رندر شده به PowerPoint در این موارد، می‌توانید kerning را برای بخش‌های متنی که از قلم تحت تأثیر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را بزرگ‌تر از اندازه واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» با یک جعبه متن به عنوان اولین شکل در اسلاید اول نیاز دارد. نام‌های قلم مؤثر، از جمله قلم‌های به‌ارث‌برده، بررسی می‌شود و آستانه 100 پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند تنظیم می‌شود. این کار kerning را برای بخش‌های مطابق با اندازه قلم زیر 100 پوینت غیرفعال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

برای متنی که زیر آستانه باشد، این تنظیم از kerning جلوگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) یا در بخش‌های منفرد از طریق [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به Times New Roman 12 پوینت با قالب بولد، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های منفرد بر این پیش‌فرض‌ها ارجحیت دارد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم ویژگی‌های قلم برای پاراگراف.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر 13 پوینت Times New Roman، قالب ایتالیک و زیرخط نقطه‌ای را بر بخش‌هایی که قالب مؤثرشان بولد است اعمال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تنظیم ویژگی‌های قلم برای بخش متن.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **کنترل نرمال‌سازی ارتفاع متن**

هنگام بازآفرینی تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع حروف، از [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی ارتفاع کاراکترهای منفرد را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهده یکسانی داشته باشند. این کار تضمین نمی‌کند که ارتفاع متن بین قلم‌های مختلف برابر باشد.

ویژگی را به [NullableBool.TRUE یا FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) تنظیم کنید تا به‌صورت صریح نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool.NOT_DEFINED` تنظیم محلی را خالی می‌گذارد تا بخش مقدار را از مثالاً از [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) پاراگراف به ارث ببرد. این به معنای `False` نیست. از [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) و [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) برای دریافت مقدار بولی حل‌شده استفاده کنید.

مثال خودکفا زیر به **Arial** نصب‌شده نیاز دارد. دو بلوک متن حاوی حروف بزرگ، حروف کوچک، حروف پایین‌روند و حروف معترض 54 پوینت ایجاد می‌کند. هر دو پاراگراف به‌طور پیش‌فرض نرمال‌سازی را فعال می‌کنند. بخش بالایی آن را به‌صورت صریح غیرفعال می‌کند؛ بخش پایینی آن را به ارث می‌برد. ابعاد قاب، حاشیه‌ها و فاصله‌گذاری پاراگراف یکسان هستند، با wrapping و autofit غیرفعال برای حفظ مقایسه ثابت. مثال `FALSE: False` و `NOT_DEFINED: True` چاپ می‌کند، سپس «text_height_normalization.pptx» را ذخیره می‌نماید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

مقایسه زیر از ارائه ذخیره‌شده استخراج شده است. ردیف بالایی نرمال‌سازی غیرفعال (`FALSE`) دارد؛ ردیف پایینی تنظیم فعال را به‌صورت ارث‌بری (`NOT_DEFINED` → `True`) دارد. برای بازتولید این ظاهر، Arial باید نصب باشد.

![متن 54 پوینتی Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌بری در زیر](text_height_normalization.png)

نرمال‌سازی ارتفاع حروف را بدون تغییر مقدار [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) که اندازه قلم را به پوینت مشخص می‌کند، تغییر می‌دهد. [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) پاراگراف فاصله خطوط را کنترل می‌کند، در حالی که [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) فریم‑متن نحوهٔ سازگاری متن یا محفظهٔ آن را تنظیم می‌کند. این تنظیمات مقاصد متفاوتی دارند و می‌توانند به‌طور مستقل بر چیدمان کلی تأثیر بگذارند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و وراثت، به [Manage Paragraph](/slides/fa/python-net/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف Strikethrough**

برای نمایش اصلاحات، اصطلاحات لغو‌شده یا قیمت‌های قبلی بدون حذف متن اصلی، از [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) روی یک بخش متن استفاده کنید. برای یک خط یا دو خط از طریق [TextStrikethroughType.SINGLE یا DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف Strikethrough مقدار `TextStrikethroughType.NONE` را اختصاص دهید. این به‌صورت صریح اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی پیرامونی Strikethrough داشته باشد. در مقابل، `TextStrikethroughType.NOT_DEFINED` تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش قالب‌بندی را از مثالاً پاراگراف به ارث ببرد. این تضمین نمی‌کند که Strikethrough حذف شود. برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌بری، از [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) استفاده کنید.

مثال خودکفا زیر سه مقایسه قیمت ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت فعلی دارد؛ بنابراین فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول Strikethrough را اعمال و سپس حذف می‌کند؛ ردیف‌های دیگر به‌صورت تک‌خطی و دو‌خطی حفظ می‌شوند. تغییر این ویژگی متن و قالب‌بندی‌های دیگر آن، از جمله بولد بودن قیمت قبلی، را حفظ می‌کند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # اعمال Strikethrough، سپس به‌صورت صریح آن را از اولین قیمت قبلی حذف کنید.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه، از بالا به پایین: بدون Strikethrough، Strikethrough تک‌خطی و Strikethrough دو‌خطی.

![قیمت‌های قبلی بدون Strikethrough، با Strikethrough تک‌خطی و با Strikethrough دو‌خطی](strikethrough.png)

## **تنظیم چرخش متن**

برای تنظیم جهت پیش‌تعریف‌شدهٔ متن درون یک شکل از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) استفاده کنید.

مثال کد زیر جهت متن در شکل را به [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه به صورت پادساعت‌گرد** می‌چرخاند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

برای تنظیم زاویهٔ چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) استفاده کنید.

مثال کد زیر فریم متن را داخل شکل 3 درجه به سمت ساعت‌گرد می‌چرخاند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides انواع [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)، و [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصله پاراگراف ارائه می‌دهد. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* مقدار مثبت برای تعیین فاصله خط به‌صورت درصدی از ارتفاع خط.
* مقدار منفی برای تعیین فاصله خط به پوینت.

مثال زیر فاصله داخل اولین پاراگراف را به 200٪ از ارتفاع خط (فاصلهٔ دو برابر) تنظیم می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله خطوط داخل پاراگراف](line_spacing.png)

## **کنترل شکست خطوط**

قوانین شکست خطوط پاراگراف در بلاک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند مفید هستند. ویژگی‌های زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) هستند، بنابراین بر کل پاراگراف اعمال می‌شوند:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته شدن متن شرق آسیایی و نقطه‌گذاری مجاور را نیز تغییر دهد.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) قوانین شکست خط شرق آسیایی را کنترل می‌کند، از جمله محدودیت‌های کاراکترهای ابتدای و انتهای خط.

این قوانین جایگزین [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) که wrapping خودکار را در داخل یک فریم متن فعال می‌کند، نمی‌شوند؛ بلکه هنگام wrapping بر طرح تأثیر می‌گذارند و کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید درون پاراگراف ایجاد می‌کند، صرف‌نظر از عرض در دسترس.

مثال خودکفا زیر یک بلاک متنی باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو ویژگی شکست خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قوانین، مقدار آن ویژگی را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. این مثال از Arial 24 پوینت و SimSun با عرض قاب 160 پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) بر روی [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) تنظیم شده تا اندازه متن و ابعاد قاب ثابت بمانند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **کنترل نقطه‌گذاری معلق**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) اجازه می‌دهد نقطه‌گذاری واجد شرایط فراتر از لبهٔ راست خط متن کشیده شود به جای اینکه در خط بعدی قرار گیرد. این ویژگی برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودکفا زیر نقطه‌گذاری معلق را در یک فریم متن 100 پوینتی فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با Arial 24 پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و فراتر از لبهٔ راست متن کشیده می‌شود. برای مقایسه مقدار ویژگی را به [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در یک خط جداگانه قرار می‌گیرد. wrapping فعال و autofit غیرفعال برای ثابت نگه داشتن عرض در دسترس هستند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

تمامی علامت‌های نقطه‌گذاری قابلیت معلق شدن ندارند. نتیجهٔ قابل مشاهده به [شرایط قلم و طرح‌بندی](#control-line-breaking) وابسته است: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند که متن هنگام عبور از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل اینکه آیا متن کوچک می‌شود، بیش از حد می‌گذرد یا شکل به‌صورت خودکار اندازهٔ خود را تغییر می‌دهد استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود اندازه‌اش را تغییر دهد و نتیجه در «autofit_type.pptx» ذخیره می‌شود.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

برای شمارش خطوط پس از wrapping خودکار و مشاهدهٔ نحوهٔ تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/python-net/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشان‌دهندهٔ عبور متن از محفظه نیست.

## **تنظیم Anchor فریم‌های متن**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) تعیین می‌کند که متن به صورت عمودی داخل یک شکل چگونه موقعیت‌یابی شود، مثلاً در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تب‌های متن**

از [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) و [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌چین در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارد.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان Proofing**

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) را فراهم می‌کند که به شما امکان می‌دهد زبان proofing برای یک بخش متن را تنظیم کنید. زبان proofing تعیین می‌کند که بررسی املایی و دستوری در PowerPoint با چه زبانی انجام شود.

مثال زیر به «presentation.pptx» با یک جعبه متن به عنوان اولین شکل در اسلاید اول و حداقل یک پاراگراف نیاز دارد. محتویات اولین پاراگراف را با «1。» جایگزین می‌کند، SimSun را به عنوان قلم آن تنظیم می‌کند و زبان proofing چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # زبان proofing را به چینی ساده تنظیم کنید.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متنی که در حین بارگذاری یا ایجاد یک ارائه ایجاد می‌شود استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی ایالات متحده ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متن آن `en-US` چاپ می‌کند.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # افزودن یک شکل مستطیل جدید با متن.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # بررسی زبان اولین بخش متن.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید.

مثال زیر قلم بولد 14 پوینتی را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و در «default_text_style.pptx» ذخیره می‌شود. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # دریافت قالب پاراگراف سطح بالا.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج متن با اثر All‑Caps**

در PowerPoint، اعمال اثر **All Caps** به قلم باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نشان داده شود حتی اگر در ابتدا با حروف کوچک تایپ شده باشد. وقتی چنین بخش متنی را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن دقیقاً همان‌گونه که وارد شده را برمی‌گرداند. برای مطابقت با متن نمایش‌داده‌شده، [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `ALL` باشد، رشتهٔ برگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» با یک جعبه متن به عنوان اولین شکل در اسلاید اول نیاز دارد. اولین پاراگراف اولین بخش آن شامل «Hello, Aspose!» با اثر All Caps اعمال‌شده است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن با اثر **All Caps** استخراج شود:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه متن را در یک جدول در اسلاید اصلاح کنم؟**

برای اصلاح متن در یک جدول در اسلاید، از [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) استفاده کنید. در سلول‌ها مرور کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) و قالب‌بندی پاراگراف از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) به‌روزرسانی کنید.

**چگونه به متن در یک اسلاید PowerPoint رنگ گرادیان اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) استفاده کنید. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.

ویژگی مرتبط: [Format text within slides](/slides/fa/features/text-formatting/).
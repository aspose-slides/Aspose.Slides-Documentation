---
title: قالب‌بندی متن ارائه در پایتون
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله بین حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله بین خطوط
- خاصیت خودتنظیم
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET. سفارشی‌سازی قلم‌ها، رنگ‌ها، تراز و موارد بیشتر."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET قالب‌بندی کنید. این راهنما شامل رنگ‌های پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله بین پاراگراف‌ها، رفتار خودتنظیم، نگه‌دارنده متن، توقف‌های تب و تنظیمات زبان می‌شود.

مگر اینکه خلاف آن ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو اندیس اسلاید و شکل به صورت صفر مبنا هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند، از قالب‌بندی مؤثر شامل قالب‌بندی بولد به ارث‌برده استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن لITERAL یا تطابق‌های عبارت منظم، به [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) برای بخش‌های متنی جداگانه استفاده کنید.

مثال زیر یک برجسته خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح روی بخش‌های جداگانه بر این پیش‌فرض اولویت دارند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم بولد** تنظیم کنید:

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

![بخش‌های متن خاکستری](gray_text_portions.png)

## **تراز کردن پاراگراف‌های متن**

از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) برای تنظیم تراز پاراگراف درون یک فریم متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

کد مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تراز پاراگراف را به مرکز تنظیم کنید.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تراز کردن قلم‌ها درون یک خط**

از [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم مختلف درون یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و تراز در هر یک از خطوط آن را کنترل می‌کند.

مثال خود‌کفا زیر چهار جعبه متن دارای برچسب در یک اسلاید ایجاد می‌کند. هر پاراگراف همان متن را با اندازه‌های 18، 36 و 54 پوینت دارد و تراز قلم متفاوتی دارد. از Arial استفاده می‌شود، خودتنظیم و پیچش غیرفعال هستند و فریم‌های متن به اندازه کافی بزرگ هستند تا یک خط را در بر بگیرند:

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

![مقایسه تراز Baseline، Top، Center و Bottom با اندازه‌های قلم ترکیبی](font_alignment.png)

تراز قلم از متریک‌های قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهده حروف لزوماً با هم هم‌سطح نمی‌شوند. این مثال شامل یک حرف بزرگ و یک حروف پایین‌خط برای نشان دادن تفاوت بین تراز baseline و bottom است. در دسترس بودن قلم و جایگزینی، کاراکترهای استفاده شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد فریم، حاشیه‌ها، فاصله بین خطوط، پیچش و خودتنظیم نیز بر طرح‌بندی تأثیر دارند؛ هنگام مقایسه حالت‌ها از همان قلم‌ها و تنظیمات طرح‌بندی استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) است که تراز افقی پاراگراف را کنترل می‌کند، و از [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) که بلوک متن را عموداً درون شکل موقعیت می‌دهد. فرمت‌گذاری ابرنویسی و زیرنویسی از طریق [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) بخش‌های جداگانه را نسبت به baseline جابه‌جا می‌کند به‌جای تنظیم تراز قلم برای خطوط پاراگراف.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگی که به [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) اختصاص داده می‌شود کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **کل پاراگراف** اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # پر رنگ سیاه نیمه‌شفاف را برای متن تنظیم کنید.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با قلم بولد** اعمال کنید:

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
            # شفافیت بخش متن را تنظیم کنید.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله بین حروف برای متن**

از [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) برای گسترش یا فشرده‌سازی فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کند.

کد پایتون زیر نشان می‌دهد چگونه فاصله بین حروف را در **کل پاراگراف** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تذکر: برای فشرده‌سازی فاصله بین حروف از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # فاصله بین حروف را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله بین حروف در پاراگراف](character_spacing_in_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه فاصله بین حروف را در **بخش‌های متنی با قلم بولد** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # نکته: برای فشرده‌سازی فاصله بین حروف از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # فاصله بین حروف را گسترش دهید.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله بین حروف در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است اندکی فشرده‌تر از متن مشابه در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی زمانی که قلم دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را بزرگتر از اندازه واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر، از جمله قلم‌های به ارث‌برده، بررسی می‌شوند و برای بخش‌هایی که از Roboto استفاده می‌کنند آستانه 100 پوینت تنظیم می‌شود؛ این کار کرنینگ را برای بخش‌های مطابق با اندازه قلم زیر 100 پوینت غیرفعال می‌کند:

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

برای متن منطبق زیر آستانه، این تنظیم کرنینگ را منع می‌کند و می‌تواند به هم‌راستاپذیری رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با قالب بولد، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح روی بخش‌های جداگانه بر این پیش‌فرض‌ها اولویت دارد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
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
            # ویژگی‌های قلم را برای بخش متن تنظیم کنید.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) برای تنظیم یک جهت متنی پیش‌تعریف‌شده درون یک شکل استفاده کنید.

کد مثال زیر جهت متن در شکل را به [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه به سمت ساعتگرد** می‌چرخاند:

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

از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) استفاده کنید.

کد مثال زیر فریم متن را 3 درجه به سمت ساعتگرد درون شکل می‌چرخاند:

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

Aspose.Slides ویژگی‌های [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) و [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصله پاراگراف ارائه می‌دهد. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای مشخص کردن فاصله خط به‌عنوان درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای مشخص کردن فاصله خط به پوینت استفاده کنید.

مثال زیر فاصله درون اولین پاراگراف را به 200٪ ارتفاع خط (دو برابر) تنظیم می‌کند:

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

![فاصله خطوط درون پاراگراف](line_spacing.png)

## **کنترل شکست خطوط**

قواعد شکست خطوط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند مفید است. ویژگی‌های زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) هستند، بنابراین بر تمام پاراگراف اعمال می‌شوند:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) قواعد شکست خطوط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل شکست متن شرق آسیا و علائم نگارشی مجاور را نیز تغییر دهد.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) قواعد شکست خطوط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکترهای آغاز و پایان خط.

این قواعد جایگزین [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) که پیچش خودکار را درون فریم متن فعال می‌کند، نمی‌شوند. آن‌ها چیدمان را هنگام پیچش تحت تأثیر قرار می‌دهند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف مستقل از عرض در دسترس ایجاد می‌کند.

مثال خود‌کفا زیر یک بلوک متن باریک حاوی چینی و لاتین ایجاد می‌کند. هر دو ویژگی شکست خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌گردد. برای آزمایش هر قانون، مقدار آن ویژگی را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. این مثال از Arial 24 پوینت و SimSun با عرض فریم 160 پوینت و حاشیه افقی صفر استفاده می‌کند. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) بر روی [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) تنظیم شده تا اندازه متن و ابعاد فریم ثابت بمانند:

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

## **کنترل علائم نگارشی معلق**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) اجازه می‌دهد علائم نگارشی مجاز از لبه راست خط متن فراتر بروند به‌جای این که در خط بعدی قرار گیرند. این ویژگی برای تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خود‌کفا زیر علامت‌گذاری معلق را در فریم متنی به عرض 100 پوینت فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با Arial 24 پوینت و حاشیه افقی صفر، نقطه نهایی پس از «sentence» می‌ماند و از لبه راست متن فراتر می‌رود. برای مقایسه، ویژگی را به [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) تنظیم کنید: در این حالت نقطه در خط جداگانه‌ای قرار می‌گیرد. پیچش فعال و خودتنظیم غیرفعال شده‌اند تا عرض در دسترس ثابت بماند:

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

هر علامت نگارشی نمی‌تواند معلق شود. نتیجه قابل مشاهده به [شرایط قلم و طرح‌بندی](#control-line-breaking) وابسته است: تغییر قلم، عرض در دسترس، حاشیه‌ها یا تنظیمات خودتنظیم می‌توانند تفاوت قابل مشاهده را حذف کنند.

## **تنظیم نوع خودتنظیم برای فریم‌های متن**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، سرریز شود یا به‌صورت خودکار شکل را تغییر اندازه دهد استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود تغییر اندازه دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

برای شمارش خطوط پس از پیچش خودکار و مشاهدهٔ نحوهٔ تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/python-net/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشان‌دهندۀ سرریز شدن متن نیست.

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) تعریف می‌کند متن چگونه به صورت عمودی داخل یک شکل موقعیت یابد، برای مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین‌ترین شکل اولین شکل متصل می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تب‌های متن**

از [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) و [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصله تب پیش‌فرض را به 100 پوینت تنظیم کرده و یک توقف تب چپ‌تراز در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارد:

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

## **تنظیم زبان اصلاح نویسی**

Aspose.Slides ویژگی [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) را فراهم می‌کند که به شما امکان می‌دهد زبان اصلاح نویسی یک بخش متنی را تنظیم کنید. زبان اصلاح نویسی تعیین می‌کند کدام زبان برای بررسی املایی و دستوری در PowerPoint استفاده شود.

مثال زیر به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف نیاز دارد. محتویات اولین پاراگراف را با «1。» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان اصلاح نویسی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    # زبان اصلاح نوشتاری را به چینی ساده تنظیم کنید.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود استفاده کنید. مثال زیر ارائه‌ای با زبان پیش‌فرض متن انگلیسی ایالات متحده ایجاد می‌کند، یک جعبه متن اضافه می‌کند و `en-US` را برای اولین بخش متنی‌اش چاپ می‌کند:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # یک شکل مستطیل جدید با متن اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # زبان بخش اول را بررسی کنید.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید.

مثال زیر یک قلم 14 پوینت بولد را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌نماید. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آن‌ها را لغو کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # قالب پاراگراف سطح بالا را دریافت کنید.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر فونت **All Caps** باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نشان داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین بخشی را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار `ALL` باشد، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. اولین بخش اولین پاراگراف شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

کد مثال زیر نشان می‌دهد چگونه متن با اثر **All Caps** استخراج شود:

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

**چگونه متن در یک جدول روی اسلاید را اصلاح کنم؟**

برای اصلاح متن در یک جدول روی اسلاید، از [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) استفاده کنید. از طریق سلول‌ها پیمایش کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) به‌روز کنید و قالب‌بندی پاراگراف را از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) تنظیم کنید.

**چگونه یک رنگ گرادیان به متن روی اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) استفاده کنید. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم کنید و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.
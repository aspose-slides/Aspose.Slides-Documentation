---
title: قالب‌بندی متن ارائه در پایتون
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- هم‌ترازی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکترها
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
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET. قلم‌ها، رنگ‌ها، هم‌ترازی و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET قالب‌بندی کنید. این مقاله شامل رنگ‌های پس‌زمینه، شفافیت، فاصله کاراکترها، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار autofit، قرارگیری متن، تک‌نقطه‌ها و تنظیمات زبان است.

بدون اشاره به خلاف آن، نمونه‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اسلاید اول یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نمایش داده شده است. هر دو ایندکس اسلاید و شکل از صفر شروع می‌شوند. نمونه‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی بولد به ارث‌برده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن به صورت دقیق یا تطبیق‌های عبارات با قاعده، به [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) برای تنظیم رنگ پیش‌زمینه پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متنی جداگانه از [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) استفاده کنید.

مثال زیر یک برجسته‌سازی خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح روی بخش‌های جداگانه بر این پیش‌فرض ارجحیت دارند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم رنگ برجسته برای تمام پاراگراف.
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
            # تنظیم رنگ برجسته برای بخش متن.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **هم‌تراز کردن پاراگراف‌های متنی**

از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) برای تنظیم هم‌ترازی پاراگراف در داخل یک فریم متنی استفاده کنید. مقدار می‌تواند وسط‌چین، چپ‌چین، راست‌چین، توجیه‌شده و ... باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** هم‌تراز کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم هم‌تراز پاراگراف به مرکز.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف هم‌تراز](aligned_paragraph.png)

## **هم‌تراز کردن قلم‌ها در یک خط**

از [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) برای هم‌ترازی عمودی بخش‌های متنی با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم برای تمام پاراگراف اعمال می‌شود و هم‌ترازی خطوط آن را کنترل می‌کند.

مثال زیر یک اسلاید را با چهار جعبه متن برچسب‌دار ایجاد می‌کند. هر پاراگراف همان متن را با اندازه‌های 18، 36 و 54 پوینت و هم‌ترازی قلم متفاوت دارد. از Arial استفاده می‌کند، autofit و بسته‌بندی را غیرفعال می‌کند و فریم‌های متنی را به‌ اندازه‌ای بزرگ می‌گذارد که تنها یک خط را در خود جای دهد.

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

![مقایسه‌ی هم‌ترازی قلم بر پایه، بالا، وسط و پایین با اندازه‌های مختلف قلم](font_alignment.png)

هم‌ترازی قلم از معیارهای متریکی قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهده‌ی حروف به‌طور دقیق هم‌سطح نمی‌شوند. این مثال شامل یک حرف بزرگ و یک دیسیندر است تا تفاوت بین هم‌ترازی پایه و پایین را نشان دهد. در دسترس بودن قلم و جایگزینی، کاراکترهای استفاده‌شده و تفاوت اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد فریم، حاشیه‌ها، فاصله خطوط، بسته‌بندی و autofit نیز بر چیدمان تأثیر دارند؛ برای مقایسه حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) است که هم‌ترازی افقی پاراگراف را کنترل می‌کند و از [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) که بلوک متن را به‌صورت عمودی در داخل شکل موقعیت می‌دهد. فرمت فوق‌نویس و زیرنویس با استفاده از [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) بخش‌های جداگانه را نسبت به خط پایه جابجا می‌کند نه اینکه هم‌ترازی قلم خطوط پاراگراف را تنظیم کند.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص داده‌شده به [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

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
            # تنظیم شفافیت بخش متن.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکتر برای متن**

از [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد پایتون زیر نشان می‌دهد چگونه فاصله کاراکترها را در **تمام پاراگراف** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # توجه: برای فشرده‌سازی فاصله کاراکترها از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # فاصله کاراکترها را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکترها را در **بخش‌های متنی با قلم بولد** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # توجه: برای فشرده‌سازی فاصله کاراکترها از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # فاصله کاراکترها را گسترش دهید.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکترها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی تندتر از همان متن در PowerPoint ظاهر شود. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی زمانی که قلم شامل اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را بزرگ‌تر از اندازه قلم واقعی تنظیم کنید. این مثال به پرونده "presentation.pptx" با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر، شامل قلم‌های به‌ارث‌برده، را بررسی می‌کند و برای بخش‌هایی که از Roboto استفاده می‌کنند آستانه 100 پوینت تنظیم می‌شود: این کار کرنینگ را برای بخش‌های مطابق با اندازه قلم زیر 100 پوینت غیرفعال می‌کند:

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

برای متن‌های مطابقت‌دار زیر آستانه، این تنظیم از کرنینگ جلوگیری می‌کند و می‌تواند به تطبیق رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با قالب بولد، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب صریح بر بخش‌های جداگانه بر پیش‌فرض‌ها ارجحیت دارد:

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

مثال زیر 13 پوینت Times New Roman، قالب ایتالیک و زیرخط نقطه‌دار را بر بخش‌هایی که قالب مؤثر آنها بولد است اعمال می‌کند:

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

از [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) هنگام بازآفرینی تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع کاراکتر استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی کاراکترهای جداگانه را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهده‌ی یکنواختی در داخل بخش متن داشته باشند. این کار تضمین نمی‌کند که ارتفاع متون در قلم‌های مختلف برابر باشد.

مقدار ویژگی را به [NullableBool.TRUE یا FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) تنظیم کنید تا نرمال‌سازی را صریحاً فعال یا غیرفعال کنید. `NullableBool.NOT_DEFINED` تنظیم محلی را خالی می‌گذارد تا بخش قالب مؤثر والد، مثلاً از [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) پاراگراف، را به ارث ببرد. این به معنای `False` نیست. از [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) و [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) برای دریافت مقدار بولی نهایی استفاده کنید.

مثال خودکفا زیر به **Arial** نیاز دارد. دو بلوک متن حاوی حروف بزرگ، حروف کوچک، دیسیندرها و کاراکترهای لهجه‌دار در اندازه 54 پوینت ایجاد می‌کند. هر دو پاراگراف به‌طور پیش‌فرض نرمال‌سازی را فعال می‌کنند. بخش بالا صریحاً آن را غیرفعال می‌کند؛ بخش پایین مقدار ارث‌برده را نگه می‌دارد. ابعاد فریم، حاشیه‌ها و فاصله پاراگراف یکسان است، با بسته‌بندی و autofit غیرفعال برای حفظ مقایسه ثابت. مثال `FALSE: False` و `NOT_DEFINED: True` را چاپ می‌کند و سپس "text_height_normalization.pptx" را ذخیره می‌کند.

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

مقایسه زیر از ارائه ذخیره‌شده استخراج شده است. ردیف بالا نرمال‌سازی غیرفعال (`FALSE`) دارد؛ ردیف پایین مقدار ارث‌برده فعال (`NOT_DEFINED` → `True`) را نشان می‌دهد. برای بازآفرینی این ظاهر Arial باید نصب باشد.

![متن 54 پوینتی Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌برده در پایین](text_height_normalization.png)

نرمال‌سازی ارتفاع کاراکترها را بدون تغییر مقدار [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) که اندازه قلم را به پوینت مشخص می‌کند، تغییر می‌دهد. [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) کنترل فاصله خطوط را بر عهده دارد، در حالی که [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) نحوه تنظیم متن یا کانتینر آن را برای جا شدن تعیین می‌کند. این تنظیمات مقاصد متفاوتی دارند و می‌توانند به طور مستقل چیدمان کلی را تحت تأثیر قرار دهند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به [Manage Paragraph](/slides/fa/python-net/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌خطی (Strikethrough)**

از [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) بر یک بخش متن برای نمایش اصلاحات، عبارات لغو شده یا قیمت‌های قبلی بدون حذف متن اصلی استفاده کنید. مقدار آن را به [TextStrikethroughType.SINGLE یا DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) برای یک یا دو خط عبوردهی از متن تنظیم کنید.

برای حذف خط‌خطی، `TextStrikethroughType.NONE` را اختصاص دهید. این به‌صورت صریح اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی اطراف خط‌خطی باشد. برعکس، `TextStrikethroughType.NOT_DEFINED` تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش قالب‌بندی را از مثالاً از پاراگراف به ارث ببرد. این به معنای حذف خط‌خطی نیست. برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌برده، از [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) استفاده کنید.

مثال خودکفا زیر سه مقایسه قیمت ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت جاری دارد، به‌طوری‌که فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌خطی را اعمال می‌کند و سپس حذف می‌کند؛ ردیف‌های دیگر به‌ ترتیب خط‌خطی تک‌خطی و دوخطی را حفظ می‌کنند. تغییر این ویژگی متن و قالب‌بندی‌های دیگر آن، از جمله بولد بودن قیمت قبلی، را حفظ می‌کند.

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

    # اعمال خط‌خطی، سپس به‌صورت صریح آن را از اولین قیمت قبلی حذف کنید.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه، از بالا به پایین: بدون خط‌خطی، خط‌خطی تک‌خطی و خط‌خطی دوخطی.

![قیمت‌های قبلی بدون خط‌خطی، با خط‌خطی تک‌خطی و با خط‌خطی دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) برای تنظیم جهت پیش‌فرض متن در داخل یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه در جهت پادساعتگرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای فریم‌های متنی**

از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) برای تنظیم زاویه چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متنی را به میزان 3 درجه ساعت‌گرد در داخل شکل می‌چرخاند:

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

Aspose.Slides ویژگی‌های [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) و [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصله پاراگراف فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* برای تعیین فاصله خطوط به‌صورت درصدی از ارتفاع خط، مقدار مثبت وارد کنید.
* برای تعیین فاصله خطوط به پوینت، مقدار منفی وارد کنید.

مثال زیر فاصله داخل اولین پاراگراف را به 200٪ از ارتفاع خط (دو برابر) تنظیم می‌کند:

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

قوانین شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند مفید هستند. این ویژگی‌ها به [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) تعلق دارند، بنابراین برای کل پاراگراف اعمال می‌شوند:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) قوانین شکست خط لاتین را کنترل می‌کند. در متن‌های ترکیبی، تغییر آن می‌تواند مکان بسته‌بندی متن و علامت نقطه‌گذاری شرق آسیا را نیز تغییر دهد.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) قوانین شکست خط شرق آسیا را شامل محدودیت‌های کاراکتر در ابتدا و انتهای خط کنترل می‌کند.

این قوانین جایگزین [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) که بسته‌بندی خودکار را در داخل فریم متنی فعال می‌کند، نمی‌شوند. آنها بر چیدمان هنگام بسته‌بندی تأثیر می‌گذارند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید در داخل پاراگراف ایجاد می‌کند مستقل از عرض موجود.

مثال خودکفا زیر یک بلوک متن باریک حاوی متن چینی و لاتین ایجاد می‌کند. هر دو ویژگی شکست خط به‌صورت صریح تنظیم شده و "line_breaking.pptx" ذخیره می‌شود. برای آزمایش هر یک از قوانین، مقدار آن ویژگی را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. مثال از Arial 24 پوینت و SimSun با عرض فریم 160 پوینت و حاشیه‌های افقی فریم صفر استفاده می‌کند. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) به [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) تنظیم شده تا اندازه متن و ابعاد فریم ثابت بمانند.

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

## **کنترل علائم نگارشی آویز (Hanging Punctuation)**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) به علامت‌های نگارشی مجاز اجازه می‌دهد تا فراتر از لبه راست خط متن ادامه یابد به‌جای اینکه در خط بعدی قرار گیرد. این ویژگی برای تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی آویز است.

مثال خودکفا زیر علائم نگارشی آویز را در فریم متنی به عرض 100 پوینت فعال می‌کند و "hanging_punctuation.pptx" را ذخیره می‌کند. با Arial 24 پوینت و حاشیه‌های افقی صفر، نقطه پایانی پس از «جمله» می‌ماند و فراتر از لبه راست متن گسترش می‌یابد. برای مقایسه مقدار را به [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در یک خط جداگانه قرار می‌گیرد. بسته‌بندی فعال و autofit غیرفعال برای ثابت نگه داشتن عرض در دسترس است.

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

همه علائم نگارشی قادر به آویز شدن نیستند. نتیجهٔ قابل مشاهده به [شرایط قلم و چیدمان](#control-line-breaking) بستگی دارد: تغییر قلم، عرض در دسترس، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع Autofit برای فریم‌های متنی**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند که متن هنگام تجاوز از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، خارج بزند یا به‌طور خودکار شکل را تغییر اندازه دهد استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود اندازه‌اش را تغییر دهد و نتیجه را در "autofit_type.pptx" ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ نحوهٔ تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/python-net/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشان نمی‌دهد که متن از محفظه‌اش خارج شده است یا نه.

## **تنظیم لنگر فریم‌های متنی**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) تعریف می‌کند که متن به صورت عمودی داخل شکل چگونه موقعیت یابد، برای مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در "text_anchor.pptx" ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تب‌های متن**

از [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) و [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصله تب پیش‌فرض را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌چین را در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارد.

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

## **تنظیم زبان اثبات (Proofing Language)**

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) را فراهم می‌کند که به شما امکان می‌دهد زبان اثبات برای یک بخش متن را تنظیم کنید. زبان اثبات تعیین می‌کند که بررسی املا و دستور زبان در PowerPoint به چه زبانی انجام شود.

مثال زیر به "presentation.pptx" با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف نیاز دارد. محتویات اولین پاراگراف را با "1。" جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان اثبات چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در "proofing_language.pptx" ذخیره می‌شود:

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

    # تنظیم زبان اثبات به چینی ساده.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هم [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) و هم [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) را حفظ کنید. مثال خودکفا زیر یک بخش منبع با زبان US English و زبان جایگزین French ایجاد می‌کند و متن و شناسه‌ها را به یک بخش در ارائه جدید کپی می‌نماید.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # اگر منبع زبان جایگزین نداشته باشد، None مقدار مقصد را پاک می‌کند.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

برای آزمایش منبع بدون زبان جایگزین، اختصاص `"fr-FR"` را حذف کنید. در این صورت شناسه جایگزین `None` می‌شود و همان دستور کپی عدم وجود آن را بدون افزودن مقدار پیش‌فرض حفظ می‌کند، حتی اگر مقصد پیش‌تر زبان جایگزینی داشته باشد.

این شناسه‌ها متادیتای زبان هستند. حفظ آن‌ها تعیین نمی‌کند که PowerPoint برای املا یا بررسی دستور زبان از کدام فرهنگ‌نامه استفاده کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد ارائه ایجاد می‌شود استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض US English ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متن `en-US` را چاپ می‌کند.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # افزودن شکل مستطیل جدید با متن.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # بررسی زبان اولین بخش متن.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید.

مثال زیر قلم 14 پوینت بولد را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالایی در یک ارائه جدید تنظیم می‌کند و آن را در "default_text_style.pptx" ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را ارث‌بری کند مگر این‌که قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # دریافت فرمت پاراگراف سطح بالایی.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج متن با افکت تمام حروف بزرگ (All-Caps)**

در PowerPoint، اعمال افکت **All Caps** بر قلم باعث می‌شود متن در اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. هنگامی که چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه دقیقاً همان متنی را که وارد شده برمی‌گرداند. برای هماهنگی با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) را بررسی کنید و هنگام مقدار `ALL` رشتهٔ برگشتی را به حروف بزرگ تبدیل کنید.

مثال زیر به "sample2.pptx" با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. اولین پاراگراف و اولین بخش آن شامل "Hello, Aspose!" با افکت All Caps است، همان‌طور که در تصویر زیر نشان داده شده است.

![افکت All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن با افکت **All Caps** استخراج شود:

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

**چگونه متن در جدول یک اسلاید را اصلاح کنم؟**

برای اصلاح متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) استفاده کنید. سلول‌ها را مرور کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) تنظیم نمایید.

**چگونه رنگ گرادیان را به متن یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) استفاده کنید. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم کنید و نقاط گرادیان، جهت و شفافیت را پیکربندی کنید.

قابلیت مرتبط: [Format text within slides](/slides/fa/features/text-formatting/).
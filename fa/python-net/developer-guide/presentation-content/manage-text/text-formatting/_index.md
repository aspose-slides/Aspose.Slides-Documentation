---
title: قالب‌بندی متن ارائه در پایتون
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- همترازی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی خودتنظیم
- مرسا قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET قالب‌بندی کنید. این مقاله رنگ‌های پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار خودتنظیم، ثابت‌سازی متن، ایست‌گاه‌های تب و تنظیمات زبان را پوشش می‌دهد.

مگر آنکه به‌طور خاص اشاره شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید آن یک جعبه متن است و اولین پاراگراف آن متنی را که در زیر نشان داده شده دارد. هر دو ایندکس اسلاید و شکل به‌صورت صفر‑پایه هستند. مثال‌هایی که بخش‌های برجسته را انتخاب می‌کنند، از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی برجسته به ارث‌برده:

![نمونه متن](sample_text.png)

برای یافتن و برجسته‌سازی متن به‌صورت دقیق یا تطابق‌های عبارات منظم، به [جستجو و جایگذاری متن](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا برای قسمت‌های متنی جداگانه از [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) بهره ببرید.

مثال زیر برجسته‌سازی خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح برای قسمت‌های جداگانه نسبت به این پیش‌فرض اولویت دارند:

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

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم ضخیم** تنظیم کنید:

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

## **همترازی پاراگراف‌های متنی**

از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) برای تنظیم تراز پاراگراف درون یک چارچوب متن استفاده کنید. مقدار می‌تواند مرکز، چپ‌تراز، راست‌تراز، تراز شده (justified) و غیره باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** همتراز کنید:

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

![پاراگراف هم‌تراز](aligned_paragraph.png)

## **همترازی قلم‌ها در یک خط**

از [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) برای همترازی عمودی بخش‌های متنی با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و تراز را در هر یک از خطوط آن کنترل می‌کند.

مثال مستقل زیر چهار جعبه متن برچسب‌دار را در یک اسلاید ایجاد می‌کند. هر پاراگراف متنی یکسان با اندازه‌های ۱۸، ۳۶ و ۵۴ پوینت دارد که تراز قلم متفاوتی دارند. این مثال از Arial استفاده می‌کند، خودتنظیم و بسته‌بندی را غیرفعال می‌کند و چارچوب‌های متن را به اندازه‌ای بزرگ می‌گذارد که فقط یک خط را در بر بگیرد.

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

![مقایسه تراز Baseline، Top، Center و Bottom قلم با اندازه‌های مختلف](font_alignment.png)

تراز قلم از متریک‌های قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهده حروف جداگانه لزوماً دقیقاً هم‌راستا نمی‌شوند. مثال شامل یک حرف بزرگ و یک حرف پایین‌بر (descender) برای نشان دادن تفاوت بین تراز baseline و bottom است. در دسترس بودن قلم و جایگزینی آن، حروف استفاده‌شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد چارچوب، حاشیه‌ها، فاصله خطوط، بسته‌بندی و خودتنظیم نیز بر چیدمان تأثیر دارند؛ برای مقایسه حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) است که تراز افقی پاراگراف را کنترل می‌کند و از [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) که بلوک متن را به صورت عمودی درون شکل موقعیت می‌دهد. قالب‌بندی فوقانی و زیرنویس از طریق [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) بخش‌های جداگانه را نسبت به baseline جابجا می‌کند به جای تنظیم تراز قلم برای خطوط پاراگراف.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص‌یافته به [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس ۰ تا ۲۵۵ است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت را به **کل پاراگراف** اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # پر کردن سیاه نیمه‌شفاف برای متن تنظیم کنید.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت را به **بخش‌های متنی با قلم ضخیم** اعمال کنید:

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

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکتر برای متن**

از [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) برای گسترش یا فشرده‌سازی فاصله بین حروف در یک جعبه متن استفاده کنید. در مثال‌ها ۳ پوینت فاصله اضافه می‌شود؛ مقادیر منفی متن را فشرده می‌کند.

کد Python زیر نشان می‌دهد چگونه فاصله کاراکتر را در **کل پاراگراف** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # فاصله کاراکتر را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکتر در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکتر را در **بخش‌های متنی با قلم ضخیم** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # فاصله کاراکتر را گسترش دهید.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکتر در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به‌نظر برسد. این به این دلیل است که PowerPoint ممکن است داده‌های کرنینگ برای برخی قلم‌ها را نادیده بگیرد، حتی اگر قلم شامل اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم تحت تأثیر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را بزرگ‌تر از اندازه واقعی قلم تنظیم کنید. این مثال نیاز به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید دارد. این مثال نام‌های قلم مؤثر، شامل قلم‌های به ارث‌برده، را بررسی می‌کند و آستانه ۱۰۰ پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند تنظیم می‌کند. این کار کرنینگ را برای بخش‌های مطابق با اندازه قلم زیر ۱۰۰ پوینت غیرفعال می‌کند:

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

برای متنی که زیر آستانه قرار می‌گیرد، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هم‌راستا کردن رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به Times New Roman ۱۲ پوینت با قالب‌بندی ضخیم، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح در بخش‌های جداگانه نسبت به این پیش‌فرض‌ها اولویت دارد.

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

مثال زیر ۱۳ پوینت Times New Roman، قالب‌بندی ایتالیک و زیرخط نقطه‌دار را بر بخش‌هایی که قالب‌بندی مؤثرشان ضخیم است اعمال می‌کند:

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

از [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) استفاده کنید وقتی که به بازآفرینی تایپوگرافی قالب یا بررسی اختلافات ارتفاع حروف می‌پردازید. در PowerPoint، فعال‌سازی نرمال‌سازی حروف را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهده یکسانی داشته باشند. این ویژگی تضمین نمی‌کند که ارتفاع متن بین قلم‌های مختلف برابر باشد.

مقدار این ویژگی را به [NullableBool.TRUE یا FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) تنظیم کنید تا به‌صراحت نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool.NOT_DEFINED` تنظیم محلی را خالی می‌گذارد تا بخش مقدار را از مثالاً از [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) پاراگراف به ارث ببرد. این به معنای `False` نیست. از [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) استفاده کنید و [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) را بخوانید تا مقدار بولی نهایی را به دست آورید.

مثال مستقل زیر نیاز به نصب **Arial** دارد. این مثال دو بلوک متن حاوی همان حروف بزرگ، حروف کوچک، حروف پایین‌بر و کاراکترهای با اکسنت در اندازه ۵۴ پوینت ایجاد می‌کند. هر دو پاراگراف به‌صورت پیش‌فرض نرمال‌سازی را فعال دارند. بخش بالایی صراحتاً آن را غیرفعال می‌کند؛ بخش پایین‌تری مقدار را ارث‌بری می‌کند. ابعاد قالب، حاشیه‌ها و فاصله پاراگراف یکسان هستند، با بسته‌بندی و خودتنظیم غیرفعال برای حفظ مقایسه ثابت. مثال `FALSE: False` و `NOT_DEFINED: True` را چاپ می‌کند، سپس «text_height_normalization.pptx» را ذخیره می‌کند.

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

مقایسه زیر از ارائه ذخیره‌شده استخراج شد. ردیف بالایی نرمال‌سازی غیرفعال دارد (`FALSE`)، ردیف پایین‌تری تنظیم فعال را ارث‌بری می‌کند (`NOT_DEFINED` → `True`). برای بازآفرینی این ظاهر، Arial نصب باشد.

![متن Arial ۵۴ پوینت با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌بری فعال در زیر](text_height_normalization.png)

نرمال‌سازی ارتفاع حروف را بدون تغییر مقدار [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) که اندازه قلم را در پوینت مشخص می‌کند، تغییر می‌دهد. [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) پاراگراف فاصله خطوط را کنترل می‌کند، در حالی که [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) چارچوب متن نحوه تنظیم متن یا ظرف آن را برای جا شدن تعیین می‌کند. این تنظیمات اهداف متفاوتی دارند و می‌توانند به‌طور مستقل بر چیدمان کلی تأثیر بگذارند. برای جزئیات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به [Manage Paragraph](/slides/fa/python-net/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌خورده**

از [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) برای یک بخش متنی استفاده کنید تا اصلاحات، عبارات لغو‌شده یا قیمت‌های قبلی را بدون حذف متن اصلی نشان دهید. مقدار آن را به [TextStrikethroughType.SINGLE یا DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) برای یک یا دو خط عبور از متن تنظیم کنید.

برای حذف خط‌خورده، `TextStrikethroughType.NONE` را اختصاص دهید. این به‌صراحت اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی اطراف خط‌خورده باشد. در مقابل، `TextStrikethroughType.NOT_DEFINED` تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش بتواند قالب‌بندی را از جمله پاراگراف ارث ببرد. این تضمین نمی‌کند خط‌خورده حذف شود. برای خواندن قالب‌بندی حاصل، شامل مقادیر ارث‌بری، از [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) استفاده کنید.

مثال مستقل زیر سه مقایسه قیمت ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت جاری دارد، به طوری که فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌خورده را اعمال می‌کند و سپس حذف می‌کند؛ ردیف‌های دیگر خط‌خورده تک و دوتایی را حفظ می‌کنند. تغییر این ویژگی متن و سایر قالب‌بندی‌های آن، از جمله قیمت قبلی ضخیم، را حفظ می‌کند.

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

    # اعمال خط‌خورده، سپس به‌صورت صریح آن را از اولین قیمت قبلی حذف کنید.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه، از بالا به پایین: بدون خط‌خورده، خط‌خورده تک، و خط‌خورده دوتایی.

![قیمت‌های قبلی بدون خط‌خورده، با خط‌خورده تک، و با خط‌خورده دوتایی](strikethrough.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) برای تنظیم جهت پیش‌فرض متن درون یک شکل استفاده کنید. مثال کد زیر جهت متن در شکل را به [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

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

## **نمایش رقم‌ها به‌صورت کنار هم در متن عمودی**

برای نگه داشتن یک عدد دو رقمی به‌صورت یکجا در یک برچسب ژاپنی عمودی، هر دو رقم را در یک بخش متنی قرار دهید و بر آن بخش [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) را تنظیم کنید. مثال دو برچسب در یک ارائه جدید ایجاد می‌کند که از [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) و قلم MS Gothic ۴۰ پوینت استفاده می‌کنند. فقط مقدار [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) اختصاص‌یافته به بخش عددی متفاوت است.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

در PowerPoint، برچسب چپ (`TRUE`) اعداد را به‌صورت عمودی و کنار هم بین حروف 和 و 年 نشان می‌دهد. در برچسب راست (`FALSE`) زوج اعداد ۹۰ درجه ساعت‌گرد چرخیده‌اند. حروف ژاپنی اطراف در هر دو برچسب عمودی می‌مانند.

![مقایسه برچسب‌های تاریخ عمودی در PowerPoint با رقم‌های عمودی در سمت چپ و رقم‌های چرخیده در سمت راست](vertical_date.png)

## **تنظیم چرخش سفارشی برای چارچوب‌های متن**

از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) استفاده کنید. مثال کد زیر چارچوب متن را به‌صورت ۳ درجه ساعت‌گرد درون شکل می‌چرخاند:

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

Aspose.Slides امتیازهای [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)، و [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصله پاراگراف‌ها فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به‌عنوان درصدی از ارتفاع خط استفاده کنید.  
* از مقدار منفی برای تعیین فاصله خط به‌واحد پوینت استفاده کنید.

مثال زیر فاصله داخلی اولین پاراگراف را به ۲۰۰٪ ارتفاع خط (فاصله‌گذاری دوبرابر) تنظیم می‌کند:

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

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیایی را ترکیب می‌کنند مفید هستند. ویژگی‌های زیر به [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) تعلق دارند، بنابراین بر کل پاراگراف اعمال می‌شوند:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته‌بندی متن شرق آسیایی و نقطه‌گذاری مجاور را نیز تغییر دهد.  
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) قوانین شکست خط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکترها در ابتدای و انتهای خط.

این قوانین جایگزین [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) که بسته‌بندی خودکار درون چارچوب متن را فعال می‌کند، نمی‌شوند. آن‌ها بر چیدمان هنگام بسته‌بندی تأثیر می‌گذارند؛ خودکار کاراکترهای شکست خط را درج نمی‌کنند. شکست خط صریح یک خط جدید را درون پاراگراف ایجاد می‌کند بدون توجه به عرض موجود.

مثال مستقل زیر یک بلوک متن باریک حاوی چینی و لاتین ایجاد می‌کند. هر دو ویژگی شکست خط به‌صورت صریح تنظیم شده و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هریک از قوانین، مقدار آن ویژگی را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. مثال ازArial ۲۴ پوینت و SimSun با عرض چارچوب ۱۶۰ پوینت و صفر حاشیه افقی استفاده می‌کند. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) روی [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) تنظیم شده است تا اندازه متن و ابعاد چارچوب ثابت بمانند.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) به نقطه‌گذاری‌های مجاز اجازه می‌دهد تا پشت لبه راست خط متن کشیده شوند به جای این که در خط بعدی قرار گیرند. این ویژگی برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق (hanging indent) است.

مثال مستقل زیر نقطه‌گذاری معلق را در یک چارچوب متن با عرض ۱۰۰ پوینت فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌نماید. با Arial ۲۴ پوینت و صفر حاشیه افقی، نقطه نهایی پس از «sentence» می‌ماند و پشت لبه راست متن کشیده می‌شود. برای مقایسه مقدار ویژگی را به [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در خط جداگانه‌ای قرار می‌گیرد. بسته‌بندی فعال و خودتنظیم غیرفعال نگه‌داشته می‌شود تا عرض موجود ثابت بماند.

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

همه نقطه‌گذاری‌ها قابلیت معلق شدن ندارند. نتیجه قابل مشاهده به [شرایط قلم و چیدمان](#control-line-breaking) بستگی دارد: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات خودتنظیم می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع خودتنظیم برای چارچوب‌های متن**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند متن چگونه رفتار کند وقتی از محدودهٔ ظرف خود فراتر رود. از آن برای کنترل اینکه آیا متن کوچک می‌شود، سرریز می‌شود یا شکل به‌صورت خودکار تغییر اندازه می‌دهد استفاده کنید. مثال زیر شکل را طوری پیکربندی می‌کند که برای متن خود بازسازی (resize) شود و نتیجه را در فایل «autofit_type.pptx» ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهده اینکه چگونه عرض متن یا شکل نتیجه را تغییر می‌دهد، به [Count Rendered Lines](/slides/fa/python-net/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشان نمی‌دهد آیا متن از ظرف خود سرریز می‌شود یا خیر.

## **تنظیم مرسا (Anchor) چارچوب‌های متن**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) تعیین می‌کند متن به‌صورت عمودی داخل یک شکل در چه موقعیتی قرار گیرد، مثلاً در بالا، میانه یا پایین. مثال زیر متن را به پایین اولین شکل مرسا می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تب‌بندی متن**

از [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) و [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) برای پیکربندی ایست‌گاه‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصله پیش‌فرض تب را به ۱۰۰ پوینت تنظیم می‌کند و یک ایست‌گاه تب چپ‌تراز در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارند.

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

## **تنظیم زبان تصحیح**

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) را فراهم می‌کند که به شما امکان می‌دهد زبان تصحیح متنی برای یک بخش تعیین کنید. زبان تصحیح تعیین می‌کند کدام زبان برای بررسی املا و دستور زبان در PowerPoint استفاده می‌شود.

مثال زیر نیاز به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف دارد. این مثال محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌نماید و زبان تصحیح چینی ساده (`zh-CN`) را اختصاص می‌دهد. سپس نتیجه را در «proofing_language.pptx» ذخیره می‌کند:

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

    # زبان تصحیح را به چینی ساده تنظیم کنید.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **کپی متادیتای زبان**

هنگام کپی‌کردن متن چندزبانه از یک قالب، هر دو [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) و [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) را حفظ کنید. مثال مستقل زیر یک بخش منبع با زبان انگلیسی (US) به عنوان زبان اصلی و فرانسوی به عنوان زبان جایگزین ایجاد می‌کند و متن و شناسه‌ها را به یک بخش در ارائه جدید کپی می‌نماید.

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
    # اگر منبع زبان جایگزینی نداشته باشد، None مقدار مقصد را پاک می‌کند.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

برای آزمایش منبع بدون زبان جایگزین، اختصاص `"fr-FR"` را حذف کنید. شناسه جایگزین سپس `None` می‌شود و همان دستور کپی عدم وجود آن را حفظ می‌کند بدون اینکه مقدار پیش‌فرضی اضافه کند، حتی اگر مقصد قبلاً زبان جایگزینی تعیین کرده باشد.

این شناسه‌ها به‌عنوان متادیتای زبان ذخیره می‌شوند. حفظ آن‌ها تعیین نمی‌کند کدام واژه‌نامه PowerPoint برای املا یا بررسی‌های گرامری انتخاب می‌کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متن هنگام بارگذاری یا ایجاد یک ارائه استفاده کنید. مثال زیر ارائه‌ای با زبان پیش‌فرض متن انگلیسی (US) ایجاد می‌کند، یک جعبه متن اضافه می‌نماید و برای اولین بخش متنی آن `en-US` چاپ می‌کند.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # افزودن یک شکل مستطیل جدید با متن.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # بررسی زبان اولین بخش.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید. مثال زیر یک قلم ضخیم ۱۴ پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائه جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می نماید. متن می‌تواند این پیش‌فرض‌ها را ارث‌بری کند مگر اینکه قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # دریافت قالب پاراگراف سطح بالایی.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال افکت **All Caps** بر قلم باعث می‌شود متن به‌صورت بزرگ تمام حروف روی اسلاید نمایش داده شود حتی اگر در اصل به‌صورت حروف کوچک وارد شده باشد. وقتی چنین بخشی را با Aspose.Slides دریافت می‌کنید، کتابخانه دقیقاً همان متن وارد شده را بر می‌گرداند. برای مطابقت با متن نمایش‌داده‌شده، [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) را بررسی کنید و اگر مقدار `ALL` بود، رشتهٔ بازگشتی را به بزرگ حروف تبدیل کنید.

این مثال نیاز به «sample2.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید دارد. اولین بخش اولین پاراگراف آن حاوی «Hello, Aspose!» با افکت All Caps اعمال‌شده است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن را با افکت **All Caps** استخراج کنیم:

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **پرسش‌های متداول**

**چگونه متن را در یک جدول روی اسلاید اصلاح کنم؟**

برای اصلاح متن در یک جدول روی اسلاید، از [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) استفاده کنید. در سلول‌ها پیمایش کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) تنظیم نمایید.

**چگونه رنگ گرادیان را بر متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) استفاده کنید. مقدار [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم کنید و ایست‌گاه‌های گرادیان، جهت و شفافیت را پیکربندی نمایید.

ویژگی مرتبط: [قالب‌بندی متن در اسلایدها](/slides/fa/features/text-formatting/).
---
title: قالب‌بندی متن ارائه در پایتون
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- ترازبندی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکتری
- خصوصیات قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی Autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET قالب‌بندی و استایل کنید. قلم‌ها، رنگ‌ها، ترازبندی و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for Python via .NET قالب‌بندی کنید. موضوعات شامل رنگ پس‌زمینه، شفافیت، فاصله بین کاراکترها، خصوصیات قلم، چرخش، فاصله پاراگراف، رفتار Autofit، لنگر متن، توقف‌های تب و تنظیمات زبان است.

در مثال‌های زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که یک جعبه متن واحد در اسلاید اول دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

برای یافتن و هایلایت متن به صورت دقیق یا مطابقت‌های عبارات منظم، به [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف، یا از [PortionFormat.highlight_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/highlight_color/) برای بخش‌های متنی فردی استفاده کنید.

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه **تمام پاراگراف** را تنظیم کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # رنگ برجسته را برای تمام پاراگراف تنظیم کنید.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متنی با قلم ضخیم** را نشان می‌دهد:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # رنگ برجسته را برای بخش متن تنظیم کنید.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متن خاکستری](gray_text_portions.png)

## **ترازبندی پاراگراف‌های متن**

از [ParagraphFormat.alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) برای تنظیم ترازبندی پاراگراف در داخل یک فریم متن استفاده کنید. مقدار می‌تواند centered، left-aligned، right-aligned، justified و ... باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** ترازبندی کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم ترازبندی پاراگراف به مرکز.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف ترازبندی شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص داده شده به [PortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/fill_format/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس 0-255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را برای **تمام پاراگراف** اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم رنگ پر شدن متن به رنگ شفاف.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نحوه اعمال شفافیت برای **بخش‌های متنی با قلم ضخیم** را نشان می‌دهد:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **تنظیم فاصله کاراکتری برای متن**

از [BasePortionFormat.spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/spacing/) برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله کاراکتری را در **تمام پاراگراف** افزایش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # فاصله کاراکتر را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکتری در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله کاراکتری را در **بخش‌های متنی با قلم ضخیم** افزایش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # نکته: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # فاصله کاراکتر را گسترش دهید.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکتری در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن Kerning برای قلم‌های خاص**

در برخی موارد، متن ر.render شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از همان متن در PowerPoint ظاهر شود. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات معتبر kerning باشد و kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی ر.render به PowerPoint در چنین مواردی، می‌توانید kerning را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را به مقدار deutlich بزرگتر از اندازه واقعی قلم تنظیم کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

این تنظیم از اعمال kerning بر روی بخش‌های متن مطابق جلوگیری می‌کند و می‌تواند به هم‌خوانی ر.render Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت خصوصیات قلم متن**

خصوصیات قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) یا در بخش‌های فردی از طریق [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازه قلم، ضخامت، ایتالیک، زیرخط نقطه‌ای و قلم Times New Roman به تمام بخش‌های پاراگراف اعمال می‌شود.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # خصوصیات قلم را برای پاراگراف تنظیم کنید.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![خصوصیات قلم برای پاراگراف](font_properties_for_paragraph.png)

کد زیر خصوصیات مشابه را برای **بخش‌های متنی با قلم ضخیم** اعمال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # خصوصیات قلم را برای بخش متن تنظیم کنید.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![خصوصیات قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/text_vertical_type/) برای تنظیم یک جهت‌گیری پیش‌تعریف شده متن در داخل یک شکل استفاده کنید.

کد زیر جهت‌گیری متن در شکل را به `VERTICAL270` تنظیم می‌کند که متن را **90 درجه به خلاف ساعت** می‌چرخاند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/rotation_angle/) برای تنظیم زاویه چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را به میزان 3 درجه ساعت‌گرد در داخل شکل می‌چرخاند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat.space_after](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_before/) و [ParagraphFormat.space_within](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصله پاراگراف فراهم می‌کند. این خصوصیات به صورت زیر استفاده می‌شوند:

* برای مشخص کردن فاصله خط به صورت درصد از ارتفاع خط، از مقدار مثبت استفاده کنید.
* برای مشخص کردن فاصله خط به صورت پوینت، از مقدار منفی استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله خطوط را درون پاراگراف تنظیم کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله خطوط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل اینکه آیا متن کوچک می‌شود، سرریز می‌شود یا به‌صورت خودکار شکل را تغییر اندازه می‌دهد، استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/anchoring_type/) تعریف می‌کند متن به صورت عمودی داخل یک شکل در کجا قرار گیرد؛ مثلاً در بالا، وسط یا پایین.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تب‌های متن**

از [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_tab_size/) و [ParagraphFormat.tabs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان تصحیح املایی**

Aspose.Slides متد [PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) را فراهم می‌کند که به شما امکان می‌دهد زبان تصحیح املایی یک بخش متن را تنظیم کنید. این زبان تعیین می‌کند که در PowerPoint از کدام زبان برای بررسی املا و گرامر استفاده شود.

کد زیر نشان می‌دهد چگونه زبان تصحیح املایی یک بخش متن را تنظیم کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # شناسهٔ زبان تصحیح املایی را تنظیم کنید.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متنی که در هنگام بارگذاری یا ایجاد ارائه ساخته می‌شود، استفاده کنید.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # یک شکل مستطیل جدید با متن اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # زبان اولین بخش متن را بررسی کنید.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک قلم ضخیم پیش‌فرض با اندازه 14 pt برای تمام متن‌ها در اسلایدهای یک ارائه جدید تنظیم کنید.

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

## **استخراج متن با اثر All-Caps**

در PowerPoint، اعمال اثر فونت **All Caps** باعث می‌شود متن در اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر در اصل با حروف کوچک typed شده باشد. هنگامی که چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقا همان‌طور که وارد شده است باز می‌گرداند. برای مطابقت با متن نمایش داده شده، [TextCapType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `ALL` باشد، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

فرض کنید جعبه متن زیر را در اسلاید اول فایل sample2.pptx داریم.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

**چگونه متن را در جدول موجود در اسلاید اصلاح کنیم؟**

برای اصلاح متن در جدول موجود در اسلاید، از [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/text_frame/) و قالب‌بندی پاراگراف از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/paragraph_format/) به‌روز کنید.

**چگونه رنگ گرادیان را به متن در اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [PortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/fill_format/) استفاده کنید. [FillFormat.fill_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.
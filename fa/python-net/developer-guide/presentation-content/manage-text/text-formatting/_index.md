---
title: قالب‌بندی متن ارائه در پایتون
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- برجسته‌سازی متن
- عبارت منظم
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله‌گذاری کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله‌گذاری خطوط
- ویژگی خودسازماندهی
- لنگر فریم متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قالب‌بندی و استایل متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET. سفارشی‌سازی قلم‌ها، رنگ‌ها، ترازبندی و موارد بیشتر."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET قالب‌بندی کرد. این راهنما شامل هایلایت کردن، رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌گذاری پاراگراف، رفتار Autofit، لنگر متن، توقف‌های تب و تنظیمات زبان می‌شود.

در مثال‌های زیر، فایلی به نام **"sample.pptx"** استفاده می‌کنیم که یک جعبه متن تک در اسلاید اول دارد و متنی به شکل زیر در آن موجود است:

![متن نمونه](sample_text.png)

## **هایلایت متن**

از متد [TextFrame.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_text/) زمانی استفاده کنید که نیاز دارید متن مطابق با یک نمونه خاص در یک فریم متن را هایلایت کنید. این متد رنگ هایلایت را به بخش‌های متن منطبق اعمال می‌کند و می‌تواند همراه با [TextSearchOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/) برای کنترل نحوه جستجو، مثلاً برای مطابقت فقط با کلمات کامل، استفاده شود.

مثال کد زیر تمام وقوعات کاراکترهای **"try"** را هایلایت می‌کند و سپس فقط کلمهٔ کامل **"to"** را هایلایت می‌نماید.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # دریافت اولین شکل از اولین اسلاید.
    shape = presentation.slides[0].shapes[0]

    # برجسته‌سازی کلمه "try" در شکل.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # برجسته‌سازی کلمه "to" در شکل.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![متن هایلایت‌شده](highlighted_text.png)

## **هایلایت متن با استفاده از عبارات منظم**

متد [TextFrame.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_regex/) متن‌های منطبق با یک عبارت منظم را هایلایت می‌کند. در پایتون، این API بر روی [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) قابل استفاده است.

مثال کد زیر تمام کلماتی را که **حداقل هفت کاراکتر** دارند، هایلایت می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # برجسته‌سازی تمام کلماتی که دارای هفت یا بیشتر کاراکتر هستند.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![متن هایلایت‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) برای تنظیم رنگ پیش‌فرض هایلایت یک پاراگراف استفاده کنید، یا از [PortionFormat.highlight_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/highlight_color/) برای بخش‌های متنی جداگانه.

کد زیر نشان می‌دهد چگونه برای **تمام پاراگراف** رنگ پس‌زمینه تنظیم شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم رنگ هایلایت برای تمام پاراگراف.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نمایش می‌دهد چگونه برای **بخش‌های متنی با قلم بولد** رنگ پس‌زمینه تنظیم شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تنظیم رنگ هایلایت برای بخش متنی.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متنی**

از [ParagraphFormat.alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) برای تنظیم تراز پاراگراف درون یک فریم متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم تراز پاراگراف به مرکز.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگ اختصاص داده شده به [PortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/fill_format/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0‑255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت برای **تمام پاراگراف** اعمال شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم رنگ پر متن به رنگ شفاف.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت برای **بخش‌های متنی با قلم بولد** اعمال شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تنظیم شفافیت بخش متنی.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله‌گذاری کاراکترها برای متن**

از [BasePortionFormat.spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/spacing/) برای افزایش یا کاهش فاصله‌گذاری بین کاراکترها در یک جعبه متن استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه فاصله‌گذاری کاراکترها در **تمام پاراگراف** گسترش یابد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # نکته: برای فشرده‌سازی فاصله‌گذاری کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # افزایش فاصله‌گذاری کاراکتر.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکتری در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله‌گذاری کاراکترها در **بخش‌های متنی با قلم بولد** گسترش یابد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # نکته: برای فشرده‌سازی فاصله‌گذاری کاراکتر از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # افزایش فاصله‌گذاری کاراکتر.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله کاراکتری در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، ممکن است کمی فشرده‌تر از متن مشابه در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر به PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم مورد نظر استفاده می‌کنند، غیرفعال کنید. مقدار [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را به عددی بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید:

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

این تنظیم مانع اعمال کرنینگ بر روی بخش‌های متنی منطبق می‌شود و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) یا بر روی بخش‌های فردی از طریق [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman را برای تمام بخش‌ها اعمال می‌نماید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم ویژگی‌های قلم برای پاراگراف.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

کد زیر ویژگی‌های مشابهی را برای **بخش‌های متنی با قلم بولد** اعمال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تنظیم ویژگی‌های قلم برای بخش متنی.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/text_vertical_type/) برای تنظیم جهت‌گیری پیش‌تعریف‌شدهٔ متن درون یک شکل استفاده کنید.

کد زیر جهت‌گیری متن در شکل را به `VERTICAL270` تنظیم می‌کند که متن را **۹۰ درجه پاد ساعت‌گرد** می‌چرخاند:

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

از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/rotation_angle/) برای تنظیم زاویهٔ چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را درون شکل به میزان ۳ درجه ساعت‌گرد می‌چرخاند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله‌گذاری خطوط پاراگراف‌ها**

Aspose.Slides توابع [ParagraphFormat.space_after](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_before/) و [ParagraphFormat.space_within](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصله‌گذاری پاراگراف‌ها فراهم می‌کند. این ویژگی‌ها به شکل زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله‌گذاری خط به صورت درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله‌گذاری خط به واحد پوینت استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله‌گذاری خط را درون پاراگراف مشخص کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله‌گذاری خط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند که متن هنگام خروج از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، overflow کند یا شکل را به‌صورت خودکار تغییر اندازه دهد، استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/anchoring_type/) تعیین می‌کند متن به صورت عمودی درون شکل چگونه موقعیت‌یابی شود، مثلاً در بالا، وسط یا پایین.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تب‌بندی متن**

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

Aspose.Slides متد [PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) را فراهم می‌کند که به شما امکان می‌دهد زبان تصحیح املایی یک بخش متنی را تنظیم کنید. این زبان برای بررسی املایی و گرامری در PowerPoint استفاده می‌شود.

کد زیر نشان می‌دهد چگونه زبان تصحیح املایی برای یک بخش متنی تنظیم شود:

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

    # تنظیم شناسهٔ زبان تصحیح املایی.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متنی که در حین بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # یک شکل مستطیلی جدید با متن اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # زبان اولین بخش متن را بررسی کنید.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک قلم بولد پیش‌فرض با اندازهٔ ۱۴ pt برای تمام متن‌ها در تمام اسلایدها در یک ارائه جدید تنظیم شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # دریافت فرمت پاراگراف سطح بالای سطح 0.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج متن با افکت All‑Caps**

در PowerPoint، اعمال افکت **All Caps** باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. زمانی که چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است باز می‌گرداند. برای تطبیق با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار آن `ALL` باشد، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

فرض کنیم جعبه متنی زیر در اسلاید اول فایل **sample2.pptx** وجود دارد.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متنی را که افکت **All Caps** بر روی آن اعمال شده است استخراج کنید:

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

## **پرسش‌های متداول**

**چگونه متن در یک جدول روی اسلاید را ویرایش کنیم؟**

برای ویرایش متن در یک جدول روی اسلاید، از [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/text_frame/) و قالب‌بندی پاراگراف از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/paragraph_format/) به‌روزرسانی کنید.

**چگونه رنگ گرادیانی به متن در یک اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [PortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/fill_format/) استفاده کنید. [FillFormat.fill_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.
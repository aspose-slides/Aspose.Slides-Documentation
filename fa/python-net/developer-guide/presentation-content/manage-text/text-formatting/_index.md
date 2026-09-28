---
title: قالب‌بندی متن ارائه در Python
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- تنظیم پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصلهٔ حروف
- ویژگی‌های قلم
- خانوادهٔ قلم
- چرخش متن
- زاویهٔ چرخش
- فریم متن
- فاصلهٔ خطوط
- ویژگی خودمتناسب‌سازی
- لنگر فریم متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET قالب‌بندی و سبک‌دهی کنید. فونت‌ها، رنگ‌ها، ترازها و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نحوه قالب‌بندی متن در ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای Python از طریق .NET نشان می‌دهد. این مقاله رنگ‌های پس‌زمینه، شفافیت، فاصلهٔ بین حروف، ویژگی‌های قلم، چرخش، فاصلهٔ پاراگراف، رفتار خودکار‑متناسب، تکیه‌گاه متن، توقف‌های تب و تنظیمات زبان را پوشش می‌دهد.

مگر آنکه خلاف آن ذکر شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید آن یک جعبهٔ متن است و اولین پاراگراف آن حاوی متن نشان‌داده‌شده در زیر است. هم ایندکس اسلاید و هم ایندکس شکل از صفر شروع می‌شوند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر، شامل قالب‌بندی بولد ارث‌برده، استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا تطابق‌های عبارت منظم، به [جستجو و جایگزینی متن](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینهٔ متن**

از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) برای تنظیم رنگ برجستهٔ پیش‌فرض یک پاراگراف استفاده کنید، یا از [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/highlight_color/) برای قسمت‌های متن جداگانه استفاده کنید.

مثال زیر برجستهٔ خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجستهٔ صریح روی قسمت‌های جداگانه بر این پیش‌فرض ارجحیت دارند:

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

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **قسمت‌های متن با قلم بولد** تنظیم شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تنظیم رنگ برجسته برای قسمت متن.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![قسمت‌های متن خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [ParagraphFormat.alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) برای تنظیم تراز پاراگراف داخل یک فریم متن استفاده کنید. مقدار می‌تواند مرکزی، چپ‌تراز، راست‌تراز، هم‌تراز و غیره باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنیم:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم تراز پاراگراف به مرکز.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت متن**

شفافیت متن از طریق مؤلفهٔ آلفا رنگ اختصاص داده‌شده به [BasePortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/fill_format/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس 0 تا 255 است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت را بر **تمام پاراگراف** اعمال کنیم:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # تنظیم رنگ پر سیاه نیمه‌شفاف برای متن.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت را بر **قسمت‌های متن با قلم بولد** اعمال کنیم:

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
            # تنظیم شفافیت قسمت متن.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![قسمت‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصلهٔ حروف متن**

از [BasePortionFormat.spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/spacing/) برای گسترش یا فشرده‌سازی فاصلهٔ بین حروف در یک جعبهٔ متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد پایتون زیر نشان می‌دهد چگونه فاصلهٔ حروف را در **تمام پاراگراف** گسترش داد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # نکته: برای فشرده‌سازی فاصلهٔ حروف از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # گسترش فاصلهٔ حروف.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصلهٔ حروف در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصلهٔ حروف را در **قسمت‌های متن با قلم بولد** گسترش داد:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # نکته: برای فشرده‌سازی فاصلهٔ حروف از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # گسترش فاصلهٔ حروف.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصلهٔ حروف در قسمت‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این ممکن است به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی اگر قلم شامل اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای قسمت‌های متنی که از قلم مورد اثر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را به عددی بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» که یک جعبهٔ متن به‌عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. این مثال نام‌های قلم مؤثر، از جمله قلم‌های ارث‌برده را بررسی می‌کند و آستانهٔ ۱۰۰ پوینت برای قسمت‌هایی که از Roboto استفاده می‌کنند تعیین می‌کند. این کار کرنینگ را برای قسمت‌های مطابقت‑دار با اندازهٔ قلم زیر ۱۰۰ پوینت غیرفعال می‌کند:

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

برای متنی که زیر آستانه مطابقت دارد، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هم‌ساز کردن رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) یا روی قسمت‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با قالب‌بندی بولد، ایتالیک و زیرخط نقاطی تنظیم می‌کند. قالب‌بندی صریح روی قسمت‌های جداگانه بر این پیش‌فرض‌ها ارجحیت دارد:

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

مثال زیر 13 پوینت Times New Roman، قالب‌بندی ایتالیک و زیرخط نقطه‌ای را بر قسمت‌هایی که قالب‌بندی مؤثرشان بولد است اعمال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # تنظیم ویژگی‌های قلم برای قسمت متن.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![ویژگی‌های قلم برای قسمت‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/text_vertical_type/) برای تنظیم جهت متن پیش‌تعریف‌شده داخل یک شکل استفاده کنید.

مثال کد زیر جهت متن داخل شکل را به [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه به سمت پخش ساعت** می‌چرخاند:

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

از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/rotation_angle/) برای تنظیم زاویهٔ چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) استفاده کنید.

مثال کد زیر فریم متن را داخل شکل به میزان ۳ درجه ساعتگرد می‌چرخاند:

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

## **تنظیم فاصلهٔ خط پاراگراف‌ها**

Aspose.Slides [ParagraphFormat.space_after](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_before/)، و [ParagraphFormat.space_within](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصلهٔ پاراگراف فراهم می‌کند. این ویژگی‌ها به شکل زیر استفاده می‌شوند:

* مقدار مثبت برای تعیین فاصلهٔ خط به‌عنوان درصدی از ارتفاع خط استفاده کنید.
* مقدار منفی برای تعیین فاصلهٔ خط به‌واحد پوینت استفاده کنید.

مثال زیر فاصله داخل اولین پاراگراف را به ۲۰۰٪ از ارتفاع خط (دوبل اسپیسینگ) تنظیم می‌کند:

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

![فاصلهٔ خط داخل پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و آسیای شرقی را ترکیب می‌کنند مفید هستند. ویژگی‌های زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/) هستند، بنابراین بر تمام پاراگراف اعمال می‌شوند:

- [latin_line_break](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/latin_line_break/) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان پیچیدگی متن آسیای شرقی و نقطه‌گذاری مجاور را نیز تغییر دهد.
- [east_asian_line_break](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/east_asian_line_break/) قوانین شکست خط آسیای شرقی را کنترل می‌کند، شامل محدودیت‌های کاراکترها در ابتدای و انتهای خط.

این قوانین جایگزین [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/) نمی‌شوند، که بسته‌بندی خودکار را درون یک فریم متن فعال می‌کند. این قوانین هنگام بسته‌بندی طرح‌بندی را تحت تأثیر قرار می‌دهند؛ کاراکترهای شکست خط را درج نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف صرف‌نظر از عرض موجود ایجاد می‌کند.

مثال خودمستقل زیر یک بلوک متن باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو ویژگی شکست خط را به‌صورت صریح تنظیم می‌کند و "line_breaking.pptx" را ذخیره می‌کند. برای آزمایش هر یک از قوانین، مقدار آن ویژگی را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. این مثال از ۲۴ پوینت Arial و SimSun با عرض فریم ۱۶۰ پوینت و حاشیه‌های افقی فریم متن صفر استفاده می‌کند. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/autofit_type/) به [TextAutofitType.NONE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textautofittype/) تنظیم شده است تا اندازهٔ متن و ابعاد فریم ثابت بمانند.

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

## **کنترل نقطه‌گذاری آویزان**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/hanging_punctuation/) اجازه می‌دهد نقطه‌گذاری‌های واجد شرایط فراتر از لبهٔ راست خط متن امتداد یابند به‌جای اینکه خط بعدی را اشغال کنند. این ویژگی بر تمام پاراگراف اعمال می‌شود و با تورفتگی آویزان متفاوت است.

مثال خودمستقل زیر نقطه‌گذاری آویزان را در یک فریم متن با عرض ۱۰۰ پوینت فعال می‌کند و "hanging_punctuation.pptx" را ذخیره می‌کند. با ۲۴ پوینت Arial و حاشیه‌های افقی فریم متن صفر، نقطهٔ نهایی پس از "sentence" می‌ماند و فراتر از لبهٔ راست متن امتداد می‌یابد. برای مقایسه ویژگی را به [NullableBool.FALSE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در خط جداگانه‌ای قرار می‌گیرد. بسته‌بندی فعال است و خودمتناسب‌سازی غیرفعال شده تا عرض موجود ثابت بماند.

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

همهٔ علامت‌های نقطه‌گذاری قابلیت آویزان شدن ندارند. نتیجهٔ قابل مشاهده به فونت و شرایط طرح‌بندی بستگی دارد: تغییر فونت، عرض موجود، حاشیه‌ها یا تنظیمات خودمتناسب‌سازی می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع خودمتناسب‌سازی برای فریم‌های متن**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل این‌که آیا متن کوچک شود، سرریز کند یا شکل را به‌صورت خودکار تغییر اندازه دهد، استفاده کنید. مثال زیر شکل را طوری پیکربندی می‌کند که برای متن خود اندازه‌اش را تغییر دهد و نتیجه را در "autofit_type.pptx" ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ اینکه چگونه عرض متن یا شکل نتیجه را تغییر می‌دهد، به [تعداد خطوط رندر شده](/slides/fa/python-net/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشانگر این نیست که آیا متن از محفظهٔ خود سرریز می‌شود یا خیر.

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/anchoring_type/) تعیین می‌کند متن به صورت عمودی داخل یک شکل چگونه موقعیت یابد، به‌عنوان مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در "text_anchor.pptx" ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تب متن**

از [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_tab_size/) و [ParagraphFormat.tabs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به ۱۰۰ پوینت تنظیم می‌کند و یک توقف تب چپ‌تراز در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تاثیر می‌گذارد.

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

## **تنظیم زبان بازبینی**

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/language_id/) را فراهم می‌کند که به شما امکان تنظیم زبان بازبینی برای یک قسمت متن را می‌دهد. زبان بازبینی زبان مورد استفاده برای بررسی املاء و grammar در PowerPoint را تعیین می‌کند.

مثال زیر به "presentation.pptx" که یک جعبهٔ متن به‌عنوان اولین شکل در اولین اسلاید دارد و حداقل یک پاراگراف دارد، نیاز دارد. این مثال محتوای اولین پاراگراف را با "1。" جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند، و زبان بازبینی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه را در "proofing_language.pptx" ذخیره می‌کند:

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

    # تنظیم زبان بازبینی به چینی ساده.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید. مثال زیر یک ارائه با انگلیسی ایالات متحده به‌عنوان زبان پیش‌فرض متن ایجاد می‌کند، یک جعبهٔ متن اضافه می‌کند، و برای اولین قسمت متن آن `en-US` را چاپ می‌کند.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # اضافه کردن یک شکل مستطیل جدید با متن.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # بررسی زبان اولین بخش متن.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید.

مثال زیر قلم ۱۴ پوینت بولد را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالای یک ارائهٔ جدید تنظیم می‌کند و آن را در "default_text_style.pptx" ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر این‌که قالب‌بندی خاص‌تری آنها را بازنویسی کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # دریافت فرمت پاراگراف سطح بالا.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر قلم **All Caps** باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نشان داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین قسمتی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textcaptype/) را بررسی کنید و رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید هنگامی که مقدار `ALL` باشد.

این مثال به "sample2.pptx" که یک جعبهٔ متن به‌عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. اولین قسمت اولین پاراگراف آن شامل "Hello, Aspose!" با اثر All Caps اعمال‌شده است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنیم:

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

## **FAQ**

**چگونه می‌توانم متن را در جدول یک اسلاید اصلاح کنم؟**

برای اصلاح متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) استفاده کنید. از طریق سلول‌ها iteration کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/text_frame/) و قالب‌بندی پاراگراف از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/paragraph_format/) به‌روز کنید.

**چگونه می‌توانم رنگ گرادیان را به متن یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/fill_format/) استفاده کنید. مقدار [FillFormat.fill_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) تنظیم کنید و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.
---
title: "قالب‌بندی متن ارائه در پایتون"
linktitle: "قالب‌بندی متن"
type: docs
weight: 50
url: /fa/python-net/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله‌گذاری کاراکترها
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله بین خطوط
- ویژگی خودکار مقیاس
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قالب‌بندی و استایل متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for Python via .NET قالب‌بندی کنید. این مقاله به رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌گذاری پاراگراف، رفتار خودکار مقیاس، تکیه‌گیری متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

در مثال‌های زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که شامل یک جعبه متن در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

برای پیدا کردن و برجسته‌سازی متن به‌صورت دقیق یا مطابقت‌های عبارت منظم، ببینید [جستجو و جایگزینی متن](/slides/fa/python-net/search-and-replace-text/).

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متنی جداگانه از [PortionFormat.highlight_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/highlight_color/) استفاده کنید.

کد مثال زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **تمام پاراگراف** تنظیم کنید:

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

کد مثال زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم ضخیم** تنظیم کنید:

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

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متنی**

از [ParagraphFormat.alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) برای تنظیم تراز پاراگراف داخل یک فریم متن استفاده کنید. مقدار می‌تواند مرکزی، چپ‌تراز، راست‌تراز، توجیه‌شده و ... باشد.

کد مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ترازبندی پاراگراف را به مرکز تنظیم کنید.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص داده شده به [PortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/fill_format/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0 تا 255 است، نه درصد شفافیت.

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **تمام پاراگراف** اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # رنگ پر کردن متن را به رنگ شفاف تنظیم کنید.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با قلم ضخیم** اعمال کنید:

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

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله بین کاراکترها برای متن**

از [BasePortionFormat.spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/spacing/) برای افزایش یا کاهش فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد Python زیر نشان می‌دهد چگونه فاصله بین کاراکترها را در **تمام پاراگراف** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # نکته: برای فشرده‌سازی فاصله بین کاراکترها از مقادیر منفی استفاده کنید.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # فاصله بین کاراکترها را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله بین کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه فاصله بین کاراکترها را در **بخش‌های متنی با قلم ضخیم** گسترش دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # نکته: برای فشرده‌سازی فاصله بین کاراکترها از مقادیر منفی استفاده کنید.
            portion.portion_format.spacing = 3  # فاصله بین کاراکترها را گسترش دهید.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله بین کاراکترها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از متن مشابه در PowerPoint به‌نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ برای برخی قلم‌ها را نادیده می‌گیرد، حتی اگر قلم دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint در چنین مواردی می‌توانید کرنینگ را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) را به مقدار بسیار بزرگتر از اندازه واقعی قلم تنظیم کنید:

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

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/default_portion_format/) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای تمام پاراگراف تنظیم می‌کند: اندازه قلم، ضخامت، ایتالیک، زیرخط نقطه‌ای و قلم Times New Roman را برای تمام بخش‌های پاراگراف اعمال می‌کند.

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

کد مثال زیر ویژگی‌های مشابهی را برای **بخش‌های متنی با قلم ضخیم** اعمال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **تنظیم چرخش متن**

از [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/text_vertical_type/) برای تنظیم جهت‌گیری پیش‌تعریف‌شده متن داخل یک شکل استفاده کنید.

کد مثال زیر جهت‌گیری متن را در شکل به `VERTICAL270` تنظیم می‌کند که متن را **۹۰ درجه خلاف ساعت‌گرد** می‌چرخاند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متنی**

از [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/rotation_angle/) برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) استفاده کنید.

کد مثال زیر فریم متن را به میزان 3 درجه ساعت‌گرد داخل شکل می‌چرخاند:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله بین خطوط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat.space_after](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_after/)، [ParagraphFormat.space_before](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_before/)، و [ParagraphFormat.space_within](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/space_within/) را برای کنترل فاصله‌گذاری پاراگراف فراهم می‌کند. این ویژگی‌ها به صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله بین خطوط به صورت درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله بین خطوط به واحد پوینت استفاده کنید.

کد مثال زیر نشان می‌دهد چگونه فاصله بین خطوط را داخل پاراگراف مشخص کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![فاصله بین خطوط در پاراگراف](line_spacing.png)

## **تنظیم نوع خودکار مقیاس برای فریم‌های متنی**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/autofit_type/) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، سرریز شود یا به‌صورت خودکار شکل را تغییر اندازه دهد استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهده نحوه تغییر عرض متن یا شکل، ببینید [شمارش خطوط رندر شده](/slides/fa/python-net/manage-paragraph/). تنها شمارش خطوط نشان‌دهنده سرریز شدن متن از محفظه نیست.

## **تنظیم تکیه‌گاه فریم‌های متنی**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/anchoring_type/) تعیین می‌کند متن به‌صورت عمودی داخل یک شکل در چه موقعیتی (بالا، وسط یا پایین) قرار گیرد.

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

## **تنظیم زبان تصحیح**

Aspose.Slides متد [PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح برای یک بخش متنی را تنظیم کنید. زبان تصحیح تعیین می‌کند کدام زبان برای بررسی املا و قواعد گرامری در PowerPoint استفاده شود.

کد مثال زیر نشان می‌دهد چگونه زبان تصحیح را برای یک بخش متنی تنظیم کنید:

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

    # تنظیم شناسه زبان تصحیح.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/default_text_language/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد ارائه ایجاد می‌شود استفاده کنید.

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

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.default_text_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/default_text_style/) استفاده کنید.

کد مثال زیر نشان می‌دهد چگونه یک قلم ضخیم پیش‌فرض با اندازه 14 pt برای تمام متن در تمام اسلایدها در یک ارائه جدید تنظیم کنید.

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

## **استخراج متن با افکت حروف بزرگ**

در PowerPoint، اعمال افکت فونت **All Caps** باعث می‌شود متن بر روی اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر ابتدا با حروف کوچک نوشته شده باشد. وقتی چنین بخشی را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textcaptype/) را بررسی کنید و در صورت مقدار `ALL` رشته بازگشتی را به حروف بزرگ تبدیل کنید.

فرض کنید جعبه متنی زیر را در اسلاید اول فایل sample2.pptx داریم.

![افکت حروف بزرگ](all_caps_effect.png)

کد مثال زیر نشان می‌دهد چگونه متنی را که افکت **All Caps** روی آن اعمال شده است استخراج کنید:

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

**چگونگی ویرایش متن در جدول یک اسلاید؟**

برای ویرایش متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/text_frame/) و قالب‌بندی پاراگراف از طریق [Paragraph.paragraph_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/paragraph_format/) به‌روز کنید.

**چگونگی اعمال رنگ گرادیان به متن در یک اسلاید PowerPoint؟**

برای اعمال رنگ گرادیان به متن، از [PortionFormat.fill_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/fill_format/) استفاده کنید. [FillFormat.fill_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.GRADIENT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) تنظیم کنید و نقاط گرادیان، جهت و شفافیت را پیکربندی کنید.
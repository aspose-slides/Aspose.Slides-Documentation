---
title: إدراج الخطوط في العروض التقديمية باستخدام بايثون
linktitle: إدراج الخط
type: docs
weight: 40
url: /ar/python-net/embedded-font/
keywords:
- إضافة خط
- إدراج خط
- تضمين الخط
- الحصول على الخط المُضمّن
- إضافة خط مُضمّن
- إزالة خط مُضمّن
- ضغط الخط المُضمّن
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدراج خطوط TrueType في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة بايثون عبر .NET، مما يضمن عرضًا دقيقًا عبر جميع المنصات."
---

## **نظرة عامة**

**إدراج الخطوط في PowerPoint** يضمن أن يظل عرضك التقديمي بالمظهر المقصود عبر الأنظمة المختلفة. سواء كنت تستخدم خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن إدراج الخطوط يمنع تشويه النص والتخطيط.

إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لإدراج الخط الخاص بك. وإلا (بدون خطوط مُضمنة)، قد يتغير النص أو الأرقام على الشرائح، ويتأثر التخطيط، والتنسيق، إلخ، وقد يتحول إلى مربعات مربكة.

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)، و[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لإدارة الخطوط المُضمَّنة.

## **الحصول على الخطوط المُضمَّنة وإزالتها**

استرجع أو أزل الخطوط المُضمَّنة من عرض تقديمي بسهولة باستخدام طريقتي [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) و[remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

يعرض هذا الكود بلغة بايثون كيفية الحصول على الخطوط المُضمَّنة وإزالتها من عرض تقديمي:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render the slide containing a text frame that uses the embedded 'FunSized' font.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Get all embedded fonts.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Find the 'Calibri' font.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Remove the 'Calibri' font.
    fonts_manager.remove_embedded_font(font_data)

    # Render the slide; the 'Calibri' font will be replaced with an existing one.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Save the presentation without the embedded 'Calibri' font to disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **إضافة خطوط مُضمَّنة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) والوظيفتين المتحمّلتين للطريقة [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/)، يمكنك تحديد قاعدة الإدراج المفضلة لإدراج الخطوط في عرض تقديمي. يُظهر هذا الكود بلغة بايثون كيفية إدراج وإضافة الخطوط إلى عرض تقديمي:

```python
import aspose.slides as slides

# Load a presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Save the presentation to disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **ضغط الخطوط المُضمَّنة**

حسّن حجم الملف عن طريق ضغط الخطوط المُضمَّنة باستخدام [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

مثال على كود الضغط:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتداولة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيُستبدل أثناء العرض بالرغم من إدراجه؟**

تحقق من [معلومات الاستبدال](/slides/ar/python-net/font-substitution/) في مدير الخطوط و[قواعد الفوّلات/الاستبدال](/slides/ar/python-net/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام الفوّلة.

**هل يستحق إدراج الخطوط "النظامية" مثل Arial/Calibri؟**

عادة لا—فهذه الخطوط متوفرة دائمًا تقريبًا. إلا أنه لضمان قابلية النقل الكاملة في بيئات "خفيفة" (Docker، خادم لينكس بدون خطوط مُثبَّة مسبقًا)، قد يمنع إدراج خطوط النظام مخاطر الاستبدالات غير المتوقعة.
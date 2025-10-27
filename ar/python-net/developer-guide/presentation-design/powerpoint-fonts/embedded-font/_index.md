---
title: إدراج الخطوط في العروض التقديمية باستخدام Python
linktitle: إدراج الخط
type: docs
weight: 40
url: /ar/python-net/embedded-font/
keywords:
- إضافة خط
- إدراج خط
- إدراج الخط
- الحصول على الخط المُدرج
- إضافة خط مُدرج
- إزالة خط مُدرج
- ضغط الخط المُدرج
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدراج خطوط TrueType في عروض PowerPoint و OpenDocument التقديمية باستخدام Aspose.Slides للغة Python عبر .NET، لضمان عرض دقيق عبر جميع الأنظمة."
---

## **نظرة عامة**

**إدراج الخطوط في PowerPoint** يضمن أن يبقى عرضك التقديمي بالمظهر المقصود عبر الأنظمة المختلفة. سواء كنت تستخدم خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن إدراج الخطوط يمنع تشويه النص والتخطيط.

إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لإدراج الخط الخاص بك. وإلا (بدون خطوط مدرجة)، قد يتغير النص أو الأرقام على الشرائح، أو التخطيط، أو الأنماط، إلخ، وقد يتحول إلى مستطيلات مربكة.

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)، و[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لإدارة الخطوط المدرجة.

## **الحصول على الخطوط المدرجة وإزالتها**

احصل على الخطوط المدرجة أو أزلها من عرض تقديمي بسهولة باستخدام طريقتي [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) و[remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

هذا الكود في Python يوضح لك كيفية الحصول على الخطوط المدرجة وإزالتها من عرض تقديمي:

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

## **إضافة خطوط مدرجة**

باستخدام التعداد [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) وطيّتين من طريقة [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/)، يمكنك اختيار قاعدة الإدراج (الدمج) المفضلة لتضمين الخطوط في عرض تقديمي. هذا الكود في Python يوضح لك كيفية إدراج وإضافة الخطوط إلى عرض تقديمي:

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

## **ضغط الخطوط المدرجة**

حسّن حجم الملف بضغط الخطوط المدرجة باستخدام [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

مثال على الكود للضغط:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**كيف يمكنني معرفة أن خطًا معينًا في العرض سيستبدل أثناء العرض بالرغم من إدراجه؟**

تحقق من [معلومات الاستبدال](/slides/ar/python-net/font-substitution/) في مدير الخطوط و[قواعد السقوط/الاستبدال](/slides/ar/python-net/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام خط بديل.

**هل من المفيد إدراج خطوط النظام مثل Arial/Calibri؟**

عادة لا—فهي متاحة تقريبًا دائمًا. لكن من أجل قابلية النقل الكاملة في بيئات "رقيقة" (Docker، خادم Linux بدون خطوط مثبتة مسبقًا)، يمكن أن يزيل إدراج خطوط النظام خطر الاستبدالات غير المتوقعة.
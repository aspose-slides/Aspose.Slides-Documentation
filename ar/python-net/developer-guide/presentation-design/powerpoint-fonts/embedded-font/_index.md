---
title: إدراج الخطوط في العروض التقديمية باستخدام بايثون
linktitle: إدراج الخط
type: docs
weight: 40
url: /ar/python-net/embedded-font/
keywords:
- إضافة خط
- إدراج خط
- إدراج الخطوط
- الحصول على الخط المدرج
- إضافة خط مدرج
- إزالة خط مدرج
- ضغط الخط المدرج
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدراج خطوط TrueType في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET، لضمان عرض دقيق عبر جميع المنصات."
---

## **نظرة عامة**

**Embedding fonts in PowerPoint** يضمن أن عرضك التقديمي يحتفظ بالمظهر المقصود عبر الأنظمة المختلفة. سواءً استخدمت خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن إدراج الخطوط يمنع اضطراب النص وتخطيطه.

إذا كنت قد استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب أكثر لإدراج الخط الخاص بك. وإلا (بدون خطوط مدمجة)، قد تتغير النصوص أو الأرقام على الشرائح، وقد يتغير التخطيط، أو التنسيق، إلخ، إلى مستطيلات مربكة.

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)، و[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لإدارة الخطوط المدمجة.

## **الحصول على الخطوط المدمجة وإزالتها**

استرجع أو أزل الخطوط المدمجة من عرض تقديمي بسهولة باستخدام طريقتي [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) و[remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

هذا الكود بايثون يوضح لك كيفية الحصول على الخطوط المدمجة وإزالتها من عرض تقديمي:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # إنشاء صورة للشريحة التي تحتوي على إطار نصي يستخدم الخط المدمج 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # الحصول على جميع الخطوط المدمجة.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # العثور على الخط 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # إزالة الخط 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # إنشاء صورة للشريحة؛ سيتم استبدال الخط 'Calibri' بخط موجود.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # حفظ العرض التقديمي بدون الخط المدمج 'Calibri' على القرص.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **إضافة خطوط مدمجة**

باستخدام التعداد [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) واثنين من التحميلات لطريقة [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/)، يمكنك اختيار قاعدة (الإدراج) المفضلة لدمج الخطوط في عرض تقديمي. هذا الكود بايثون يوضح لك كيفية دمج وإضافة الخطوط إلى عرض تقديمي:

```python
import aspose.slides as slides

# تحميل عرض تقديمي.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # حفظ العرض التقديمي على القرص.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **ضغط الخطوط المدمجة**

حسّن حجم الملف بضغط الخطوط المدمجة باستخدام [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

مثال على الكود للضغط:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيستبدل خلال العرض بالرغم من إدراجه؟**

تحقق من [معلومات الاستبدال](/slides/ar/python-net/font-substitution/) في مدير الخطوط و[قواعد الاستبدال/البديل](/slides/ar/python-net/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام بديل.

**هل يجدر إدراج خطوط النظام مثل Arial/Calibri؟**

عادة لا—فهي متاحة تقريبًا دائمًا. لكن لضمان النقل الكامل في بيئات "خفيفة" (Docker، خادم لينكس بدون خطوط مثبتة مسبقًا)، يمكن أن يزيل إدراج خطوط النظام خطر الاستبدالات غير المتوقعة.
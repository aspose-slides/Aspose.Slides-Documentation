---
title: تضمين الخطوط في العروض التقديمية باستخدام Python
linktitle: تضمين الخط
type: docs
weight: 40
url: /ar/python-net/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على الخط المضمّن
- إضافة خط مضمّن
- إزالة الخط المضمّن
- ضغط الخط المضمّن
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تضمين خطوط TrueType في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للغة Python عبر .NET، مع ضمان عرض دقيق عبر جميع المنصات."
---

## **نظرة عامة**

**إدراج الخطوط في PowerPoint** يضمن أن العرض التقديمي الخاص بك يحافظ على مظهره المقصود عبر الأنظمة المختلفة. سواءً كنت تستخدم خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن إدراج الخطوط يمنع حدوث اضطراب في النص والتخطيط.

إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فسيكون لديك أسباب إضافية لإدراج الخط. وإلا (بدون خطوط مُدرَجة)، قد تتغير النصوص أو الأرقام على الشرائح، وكذلك التخطيط والتنسيق، وتتحول إلى مستطيلات مربكة.

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)، و[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لإدارة الخطوط المدرجة.

## **الحصول على الخطوط المدرجة وإزالتها**

يمكنك استرجاع أو إزالة الخطوط المدرجة من عرض تقديمي بسهولة باستخدام طريقتي [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) و[remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

يوضح لك هذا الكود Python كيفية الحصول على الخطوط المدرجة وإزالتها من عرض تقديمي:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # عرض الشريحة التي تحتوي على إطار نص يستخدم الخط المضمن 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # الحصول على جميع الخطوط المضمنة.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # البحث عن الخط 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # إزالة الخط 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # عرض الشريحة؛ سيتم استبدال الخط 'Calibri' بخط موجود.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # حفظ العرض التقديمي بدون الخط المضمن 'Calibri' على القرص.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```


## **إضافة الخطوط المدرجة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) واثنين من التحميلات الزائدة (overloads) للطريقة [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/)، يمكنك اختيار قاعدة (الإدراج) المفضلة لتضمين الخطوط في عرض تقديمي. يوضح لك هذا الكود Python كيفية إدراج وإضافة الخطوط إلى عرض تقديمي:
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


## **ضغط الخطوط المدرجة**

حسّن حجم الملف عن طريق ضغط الخطوط المدرجة باستخدام [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

كود مثال للضغط:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض التقديمي سيظل يُستبدل أثناء العرض على الرغم من إدراجه؟**

تحقق من [معلومات الاستبدال](/slides/ar/python-net/font-substitution/) في مدير الخطوط ومن [قواعد الاستبدال/البديل](/slides/ar/python-net/fallback-font/): إذا كان الخط غير متوفر أو مقيد، سيتم استخدام بديل.

**هل من الجدير إدراج خطوط "النظام" مثل Arial/Calibri؟**

عادة لا—فهذه الخطوط متوفرة في معظم الأحيان. ولكن لضمان قابلية النقل الكاملة في بيئات "خفيفة" (Docker، خادم Linux بدون خطوط مُثبتة مسبقًا)، يمكن أن يعزل إدراج خطوط النظام خطر الاستبدالات غير المتوقعة.
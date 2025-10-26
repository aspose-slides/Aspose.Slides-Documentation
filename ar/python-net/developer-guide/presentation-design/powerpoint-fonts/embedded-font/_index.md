---
title: تضمين الخطوط في العروض التقديمية باستخدام بايثون
linktitle: تضمين الخط
type: docs
weight: 40
url: /ar/python-net/developer-guide/presentation-design/powerpoint-fonts/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على خط مضمّن
- إضافة خط مضمّن
- إزالة خط مضمّن
- ضغط خط مضمّن
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تضمين خطوط TrueType في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET لضمان عرض دقيق عبر جميع المنصات."
---

## **نظرة عامة**

**تضمين الخطوط في PowerPoint** يضمن أن يحتفظ عرضك التقديمي بمظهره المقصود عبر الأنظمة المختلفة. سواءً كنت تستخدم خطوطًا فريدة للإبداع أو خطوطًا قياسية، فإن تضمين الخطوط يمنع تشويه النص وتخطيطات العرض.

إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك كنت مبدعًا في عملك، فستكون لديك أسباب أكثر لتضمين الخط. وإلا (بدون خطوط مضمَّنة)، قد يتغير النص أو الأرقام في الشرائح، كما قد تتغير التخطيطات، الأنماط، وما إلى ذلك، وتتحول إلى مستطيلات غامضة.

استخدم الفئات [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)، [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)، و[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لإدارة الخطوط المضمنة.

## **الحصول على الخطوط المضمنة وإزالتها**

استرجع أو أزل الخطوط المضمنة من عرض تقديمي بسهولة باستخدام طريقتي [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) و[remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

يُظهر لك هذا الكود بلغة بايثون كيفية الحصول على الخطوط المضمنة وإزالتها من عرض تقديمي:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # عرض الشريحة التي تحتوي على إطار نصي يستخدم الخط المضمن 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # الحصول على جميع الخطوط المضمنة.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # العثور على خط 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # إزالة خط 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # عرض الشريحة؛ سيتم استبدال خط 'Calibri' بخط موجود.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # حفظ العرض التقديمي دون الخط المضمن 'Calibri' على القرص.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **إضافة خطوط مضمَّنة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) وطريقتين متجاوزتين من طريقة [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/)، يمكنك اختيار قاعدة (التضمين) المفضلة لتضمين الخطوط في عرض تقديمي. يُظهر لك هذا الكود بلغة بايثون كيفية تضمين وإضافة الخطوط إلى عرض تقديمي:

```python
import aspose.slides as slides

# تحميل عرض تقديمي.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **ضغط الخطوط المضمَّنة**

حسن حجم الملف عن طريق ضغط الخطوط المضمَّنة باستخدام [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

مثال على الشيفرة للضغط:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض سيستبدل أثناء العرض بالرغم من تم تضمينه؟**

تحقق من [معلومات الاستبدال](/slides/ar/python-net/font-substitution/) في مدير الخطوط و[قواعد fallback/substitution](/slides/ar/python-net/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام بديل.

**هل يستحق تضمين خطوط النظام مثل Arial/Calibri؟**

عادةً لا—فهي متوفرة تقريبًا دائمًا. لكن من أجل قابلية نقل كاملة في بيئات "خفيفة" (Docker، خادم لينكس دون خطوط مسبقة التثبيت)، يمكن لتضمين خطوط النظام القضاء على خطر الاستبدالات غير المتوقعة.
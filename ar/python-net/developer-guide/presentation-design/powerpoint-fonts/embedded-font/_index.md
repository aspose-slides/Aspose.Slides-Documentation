---
title: الخطوط المدمجة
type: docs
weight: 40
url: /python-net/embedded-font/
keywords: "الخطوط، الخطوط المدمجة، إضافة خطوط، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "استخدم الخطوط المدمجة في عرض PowerPoint باستخدام بايثون"
---

**الخطوط المدمجة في PowerPoint** مفيدة عندما تريد أن يظهر عرضك التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا كنت قد استخدمت خطًا طرف ثالث أو غير قياسي لأنك كنت مبدعًا في عملك، فأنت لديك المزيد من الأسباب لإدماج خطك. خلاف ذلك (دون خطوط مدمجة)، قد تتغير النصوص أو الأرقام في الشرائح الخاصة بك، والتخطيط، والتصميم، إلخ، أو تتحول إلى مستطيلات مربكة.

تحتوي فئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) وفئة [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) وواجهاتهم على معظم الخصائص والأساليب التي تحتاجها للعمل مع الخطوط المدمجة في عروض PowerPoint.

## **الحصول على الخطوط المدمجة أو إزالتها من العرض التقديمي**

يوفر Aspose.Slides طريقة `get_embedded_fonts()` (التي تتيحها فئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)) للسماح لك بالحصول على (أو معرفة) الخطوط المدمجة في عرض تقديمي. لإزالة الخطوط، تُستخدم الطريقة `remove_embedded_font(font_data)` (التي توفرها نفس الفئة).

يعرض هذا الكود في بايثون كيفية الحصول على الخطوط المدمجة وإزالتها من عرض تقديمي:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # رسم شريحة تحتوي على إطار نص يستخدم خط "FunSized" المدمج
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture1_out.png", slides.ImageFormat.PNG)

    fontsManager = presentation.fonts_manager

    # الحصول على جميع الخطوط المدمجة
    embeddedFonts = fontsManager.get_embedded_fonts()

    # العثور على خط "Calibri"
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # إزالة خط "Calibri"
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # رسم العرض التقديمي؛ يتم استبدال خط "Calibri" بخط موجود
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture2_out.png", slides.ImageFormat.PNG)

    # حفظ العرض التقديمي بدون خط "Calibri" المدمج على القرص
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **إضافة خطوط مدمجة إلى العرض التقديمي**

باستخدام العد المسمى [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) واثنين من الأشكال الزائدة من الطريقة `add_embedded_font(font_data, embed_font_rule)`، يمكنك اختيار القاعدة المفضلة لديك (لإدماج) لإدماج الخطوط في عرض تقديمي. يعرض هذا الكود في بايثون كيفية إدماج وإضافة الخطوط إلى عرض تقديمي:

```python
import aspose.slides as slides

# تحميل العرض التقديمي
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # تحميل الخط المصدر ليتم استبداله
    sourceFont = slides.FontData("Arial")


    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # حفظ العرض التقديمي على القرص
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ضغط الخطوط المدمجة**

للسماح لك بضغط الخطوط المدمجة في عرض تقديمي وتقليل حجم الملف، يوفر Aspose.Slides الطريقة `compress_embedded_fonts` (التي توفرها فئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)).

يعرض هذا الكود في بايثون كيفية ضغط الخطوط المدمجة في PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```
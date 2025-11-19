---
title: "إدارة سمات عرض PowerPoint التقديمية في Python"
linktitle: "سمة العرض التقديمي"
type: docs
weight: 10
url: /ar/python-net/presentation-theme/
keywords:
- "سمة PowerPoint"
- "سمة العرض التقديمي"
- "سمة الشريحة"
- "تعيين سمة"
- "تغيير سمة"
- "إدارة سمة"
- "لون السمة"
- "لوحة ألوان إضافية"
- "خط السمة"
- "نمط السمة"
- "تأثير السمة"
- "PowerPoint"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "إتقان سمات العروض التقديمية في Aspose.Slides للغة Python عبر .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---

## **نظرة عامة**

تعرف سمة العرض التقديمي خصائص عناصر التصميم الخاصة بها. عند اختيار سمة، فإنك تختار مجموعة منسقة من العناصر البصرية وخصائصها.

في PowerPoint، تشمل السمة الألوان، [الخطوط](/slides/ar/python-net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/python-net/presentation-background/)، والتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك القيم الافتراضية، يمكنك تغييرها بتطبيق ألوان سمة جديدة. لتوفير خيار اختيار لون سمة جديد، توفر Aspose.Slides قيمًا في تعداد [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/).

يعرض هذا الكود Python كيفية تغيير لون التمييز في السمة:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```


يمكنك تحديد القيمة الفعلية للون الناتج كما يلي:
```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# مخرجات المثال:
#
# ff8064a2 (اللون [A=255, R=128, G=100, B=162])
```


لتوضيح تغيير اللون بشكل إضافي، نقوم بإنشاء عنصر آخر، نعين له لون التمييز من الخطوة الأولية، ثم نحدث لون السمة.
```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```


يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون سمة من اللوحة الإضافية**

عندما تطبق تحويلات الإضاءة على اللون الرئيسي للسمة (1)، يتم توليد ألوان من اللوحة الإضافية (2). يمكنك بعد ذلك تعيين هذه الألوان واسترجاعها.

![additional-palette-colors](additional-palette-colors.png)

**1** — ألوان السمة الرئيسية

**2** — ألوان من اللوحة الإضافية

يوضح هذا الكود Python كيفية اشتقاق ألوان اللوحة الإضافية من اللون الرئيسي للسمة ثم استخدامها في الأشكال:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # التمييز 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # التمييز 4، أخف 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # التمييز 4، أخف 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # التمييز 4، أخف 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # التمييز 4، أغمق 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # التمييز 4، أغمق 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **تغيير خط السمة**

لتمكينك من اختيار خطوط للسمة وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مماثلة لتلك الموجودة في PowerPoint):

- **+mn-lt** — خط الجسم باللاتينية (Minor Latin Font)
- **+mj-lt** — خط العناوين باللاتينية (Major Latin Font)
- **+mn-ea** — خط الجسم بالآسيوية الشرقية (Minor East Asian Font)
- **+mj-ea** — خط العناوين بالآسيوية الشرقية (Major East Asian Font)

يظهر هذا الكود Python كيفية تعيين الخط اللاتيني لعنصر سمة:
```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```


هذا المثال Python يوضح كيفية تغيير خط سمة العرض التقديمي:
```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```


سيتم تحديث جميع مربعات النص إلى الخط الجديد.

{{% alert color="primary" title="TIP" %}}
لمزيد من المعلومات، راجع [إدارة خطوط PowerPoint الرئيسية باستخدام Python](/slides/ar/python-net/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر PowerPoint 12 خلفية محددة مسبقًا، لكن العرض التقديمي النموذجي يخزن 3 منها فقط.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في PowerPoint، يمكنك تشغيل الكود Python التالي لتحديد عدد الخلفيات المحددة مسبقًا التي يحتويها:
```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```


{{% alert color="warning" %}}
باستخدام الخاصية `background_fill_styles` من فئة [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/)، يمكنك إضافة أو الوصول إلى أنماط الخلفية في سمة PowerPoint.
{{% /alert %}}

 يوضح هذا المثال Python كيفية تعيين خلفية العرض التقديمي:
```python
presentation.masters[0].background.style_index = 2  # 0 يدل على عدم وجود تعبئة؛ يبدأ الفهرسة من 1.
```


{{% alert color="primary" title="TIP" %}}
لمزيد من المعلومات، راجع [إدارة خلفيات العرض التقديمي باستخدام Python](/slides/ar/python-net/presentation-background/).
{{% /alert %}}

## **تغيير تأثيرات السمة**

عادةً ما تتضمن سمة PowerPoint ثلاث قيم في كل مصفوفة نمط. تتجمع هذه المصفوفات لتكوين ثلاثة مستويات من التأثير: خفيف، متوسط، وشديد. على سبيل المثال، إليك النتيجة عندما تُطبق هذه التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام الخصائص الثلاث — `FillStyles`، `LineStyles`، و `EffectStyles` — من فئة [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/)، يمكنك تعديل عناصر السمة (بمرونة أكبر من PowerPoint).

يوضح هذا الكود Python كيفية تغيير تأثير سمة عبر تعديل أجزاء من تلك العناصر:
```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


تشمل التغييرات الناتجة تحديث لون التعبئة، نوع التعبئة، تأثير الظل، وخصائص أخرى:

![todo:image_alt_text](presentation-design_11.png)

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير السمة الرئيسية؟**

نعم. يدعم Aspose.Slides تجاوزات سمة على مستوى الشريحة، بحيث يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة الماستر (من خلال [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

استخدم [استنساخ الشرائح](/slides/ar/python-net/clone-slides/) مع الماستر إلى العرض المستهدف. هذا يحافظ على الماستر الأصلي، تخطيطات الشرائح، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعالة" بعد جميع الوراثة والتجاوزات؟**

استخدم عارض ["الفعالية"](/slides/ar/python-net/shape-effective-properties/) للسمات/الألوان/الخطوط/التأثيرات. تُعيد هذه الواجهات الخصائص النهائية المحلولة بعد تطبيق الماستر وأي تجاوزات محلية.
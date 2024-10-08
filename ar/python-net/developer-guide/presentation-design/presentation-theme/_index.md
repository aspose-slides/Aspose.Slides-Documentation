---
title: قالب العرض التقديمي
type: docs
weight: 10
url: /ar/python-net/presentation-theme/
keywords: "قالب، قالب PowerPoint، عرض تقديمي PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "قالب عرض تقديمي PowerPoint في بايثون"
---

يعرف قالب العرض التقديمي خصائص عناصر التصميم. عندما تختار قالب عرض تقديمي، فإنك في الأساس تختار مجموعة معينة من العناصر المرئية وخصائصها.

في PowerPoint، يتكون القالب من الألوان، [الخطوط](/slides/ar/python-net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/python-net/presentation-background/)، والتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون القالب**

يستخدم قالب PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها عن طريق تطبيق ألوان جديدة للقالب. للسماح لك باختيار لون جديد للقالب، يوفر Aspose.Slides قيم تحت [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) التعداد.

يعرض هذا الكود بايثون كيفية تغيير لون التمييز لقالب:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

يمكنك تحديد القيمة الفعالة للون الناتج بهذه الطريقة:

```python
fillEffective = shape.fill_format.get_effective()
print("{0} ({1})".format(fillEffective.solid_fill_color.name, fillEffective.solid_fill_color)) # ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

لإظهار عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونعين لون التمييز (من العملية الأولية) له. ثم نغير اللون في القالب:

```python
otherShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
otherShape.fill_format.fill_type = slides.FillType.SOLID
otherShape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

pres.master_theme.color_scheme.accent4.color = draw.Color.red
```

يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون القالب من لوحة إضافية**

عند تطبيق تحويلات السطوع على لون القالب الرئيسي(1)، يتم تشكيل ألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين والحصول على تلك الألوان في القالب.

![additional-palette-colors](additional-palette-colors.png)

**1**- ألوان القالب الرئيسية

**2** - ألوان من اللوحة الإضافية.

يعرض هذا الكود بايثون عملية حيث يتم الحصول على ألوان اللوحة الإضافية من لون القالب الرئيسي ثم استخدامها في الأشكال:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Accent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Accent 4, Lighter 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Accent 4, Lighter 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Accent 4, Lighter 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Accent 4, Darker 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Accent 4, Darker 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير خط القالب**

للسماح لك باختيار الخطوط للقوالب وأغراض أخرى، يستخدم Aspose.Slides هذه المعرفات الخاصة (المشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي اللاتيني (خط لاتيني ثانوي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط النص الأساسي شرق آسيوي (خط شرق آسيوي ثانوي)
* **+mj-ea** - خط النص الأساسي شرق آسيوي (خط شرق آسيوي رئيسي)

يعرض هذا الكود بايثون كيفية تعيين الخط اللاتيني لعنصر في القالب:

```python
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)

paragraph = slides.Paragraph()
portion = slides.Portion("تنسيق نص القالب")
paragraph.portions.add(portion)
shape.text_frame.paragraphs.add(paragraph)
portion.portion_format.latin_font = slides.FontData("+mn-lt")
```

يعرض هذا الكود بايثون كيفية تغيير خط قالب العرض التقديمي:

```python
pres.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

سيتم تحديث الخط في جميع صناديق النص.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/python-net/powerpoint-fonts/).

{{% /alert %}}

## **تغيير نمط خلفية القالب**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفيات محددة مسبقًا ولكن فقط 3 من تلك الخلفيات الـ 12 محفوظة في عرض تقديمي نموذجي. 

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود بايثون لمعرفة عدد الخلفيات المحددة مسبقًا في العرض التقديمي:

```python
with slides.Presentation() as pres:
    numberOfBackgroundFills = len(pres.master_theme.format_scheme.background_fill_styles)
    print("عدد أنماط التعبئة الخلفية للقالب هو {0}".format(numberOfBackgroundFills))
```

{{% alert color="warning" %}} 

باستخدام خاصية `BackgroundFillStyles` من فئة [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) ، يمكنك إضافة أو الوصول إلى نمط الخلفية في قالب PowerPoint. 

{{% /alert %}}

يعرض هذا الكود بايثون كيفية تعيين الخلفية لعرض تقديمي:

```python
pres.masters[0].background.style_index = 2
```

**دليل الفهرس**: 0 يستخدم للتعبئة بدون. يبدأ الفهرس من 1.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/python-net/presentation-background/).

{{% /alert %}}

## **تغيير تأثير القالب**

يحتوي قالب PowerPoint عادةً على 3 قيم لكل مصفوفة نمط. يتم دمج تلك المصفوفات في هذه 3 تأثيرات: خفية، معتدلة، وشديدة. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص (`FillStyles`, `LineStyles`, `EffectStyles`) من فئة [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) يمكنك تغيير العناصر في قالب (حتى بشكل أكثر مرونة من الخيارات في PowerPoint).

يعرض هذا الكود بايثون كيفية تغيير تأثير قالب عن طريق تعديل أجزاء من العناصر:

```python
with slides.Presentation("combined_with_master.pptx") as pres:
    pres.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    pres.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    pres.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    pres.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", slides.export.SaveFormat.PPTX)
```

التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![todo:image_alt_text](presentation-design_11.png)
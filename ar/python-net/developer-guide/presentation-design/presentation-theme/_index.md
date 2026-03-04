---
title: إدارة سمات عروض PowerPoint التقديمية باستخدام بايثون
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/python-net/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض التقديمي
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحكم في سمات العروض التقديمية في Aspose.Slides للبايثون عبر .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **نظرة عامة**

تعرف سمة العرض التقديمي خصائص عناصر التصميم الخاصة بها. عند اختيارك لسمة، فأنت تختار مجموعة منسقة من العناصر البصرية وخصائصها.

في PowerPoint، تشمل السمة الألوان، [الخطوط](/slides/ar/python-net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/python-net/presentation-background/)، والتأثيرات.

![مكونات_المظهر](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان للعناصر المختلفة على الشريحة. إذا لم تعجبك القيم الافتراضية، يمكنك تغييرها بتطبيق ألوان سمة جديدة. لتحديد لون سمة جديد، توفر Aspose.Slides قيمًا في تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/).

هذا الكود Python يوضح كيفية تغيير لون التمييز في السمة:

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

# مثال الإخراج:
#
# ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

لتوضيح تغيير اللون بشكل أكبر، نُنشئ عنصرًا آخر، نُعيّن له لون التمييز من الخطوة الأولى، ثم نُحدّث لون السمة.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

يُطبّق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون سمة من لوحة الألوان الإضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي (1)، تُولد ألوان من لوحة الألوان الإضافية (2). يمكنك بعد ذلك تعيين تلك الألوان واسترجاعها.

![ألوان_لوحة_الألوان_الإضافية](additional-palette-colors.png)

**1** — ألوان السمة الرئيسية  

**2** — ألوان من لوحة الألوان الإضافية  

هذا الكود Python يوضح كيفية اشتقاق ألوان اللوحة الإضافية من لون السمة الرئيسي ثم استخدامها في الأشكال:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تمييز 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # تمييز 4، أفتح 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # تمييز 4، أفتح 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # تمييز 4، أفتح 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # تمييز 4، أغمق 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # تمييز 4، أغمق 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **تعيين `SchemeColor` إلى ألوان `ColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان السمة التالية:

`BACKGROUND1`، `BACKGROUND2`، `TEXT1`، و`TEXT2`.

مع ذلك، تُعيد `Presentation.master_theme.color_scheme` كائنًا من نوع [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/)، الذي يُظهر الألوان المقابلة كالتالي:

`dark1`، `dark2`، `light1`، و`light2`.

هذا الاختلاف يقتصر على التسمية فقط. هذه القيم تشير إلى نفس مواضع ألوان السمة، والربط ثابت:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

لا يوجد تحويل ديناميكي بين `TEXT`/`BACKGROUND` و`dark`/`light`. إنها مجرد مسميات بديلة لنفس ألوان السمة.

يأتي هذا الاختلاف في التسمية من مصطلحات Microsoft Office. الإصدارات القديمة من Office استخدمت `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما تعرض الإصدارات الحديثة من الواجهة نفس المواضع كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **تغيير خط السمة**

لتمكينك من اختيار الخطوط للسماق وغيرها من الأغراض، تستخدم Aspose.Slides هذه المعرفات الخاصة (المشابهة لتلك الموجودة في PowerPoint):

- **+mn-lt** — خط جسم النص اللاتيني (Minor Latin Font)
- **+mj-lt** — خط عنوان النص اللاتيني (Major Latin Font)
- **+mn-ea** — خط جسم النص الآسيوي الشرقي (Minor East Asian Font)
- **+mj-ea** — خط عنوان النص الآسيوي الشرقي (Major East Asian Font)

هذا الكود Python يوضح كيفية تعيين الخط اللاتيني لعنصر سمة:

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

{{% alert color="primary" title="نصيحة" %}}
لمزيد من المعلومات، راجع [خطوط PowerPoint الأساسية مع Python](/slides/ar/python-net/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر PowerPoint 12 خلفية مُعرفة مسبقًا، لكن العرض التقديمي النموذجي يخزن فقط 3 منها.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في PowerPoint، يمكنك تشغيل الكود Python التالي لتحديد عدد الخلفيات المعرفة مسبقًا التي يحتويها:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
باستخدام خاصية `background_fill_styles` من فئة [FormatScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/)، يمكنك إضافة أو الوصول إلى أنماط الخلفية في سمة PowerPoint.
{{% /alert %}}

هذا المثال Python يوضح كيفية تعيين خلفية العرض التقديمي:

```python
presentation.masters[0].background.style_index = 2  # 0 يعني لا تعبئة؛ يبدأ الفهرس من 1.
```

{{% alert color="primary" title="نصيحة" %}}
لمزيد من المعلومات، راجع [إدارة خلفيات العرض التقديمي في Python](/slides/ar/python-net/presentation-background/).
{{% /alert %}}

## **تغيير تأثيرات السمة**

عادةً ما تتضمن سمة PowerPoint ثلاث قيم في كل مصفوفة نمط. تُدمج هذه المصفوفات في ثلاثة مستويات من التأثير: خفيف، متوسط، وشديد. على سبيل المثال، هذه النتيجة عندما تُطبّق هذه التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام الخصائص الثلاث — `FillStyles`، `LineStyles`، و`EffectStyles` — من فئة [FormatScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/)، يمكنك تعديل عناصر السمة (بمرونة أكبر مقارنةً بـ PowerPoint).

هذا الكود Python يوضح كيفية تغيير تأثير سمة عن طريق تعديل أجزاء من تلك العناصر:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

التغييرات الناتجة تشمل تحديث لون التعبئة، نوع التعبئة، تأثير الظل، وخصائص أخرى:

![todo:image_alt_text](presentation-design_11.png)

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير القالب الرئيسي؟**

نعم. تدعم Aspose.Slides تجاوز السمة على مستوى الشريحة، لذا يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة القالب الرئيسي (من خلال [SlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

استخدم [استنساخ الشرائح](/slides/ar/python-net/clone-slides/) مع القالب الخاص بها إلى العرض الهدف. هذا يحافظ على القالب الأصلي، والتخطيطات، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة والتجاوزات؟**

استخدم طرق العرض ["الفعّالة"](/slides/ar/python-net/shape-effective-properties/) للثيم/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية المحلّلة بعد تطبيق القالب وأي تجاوزات محلية.
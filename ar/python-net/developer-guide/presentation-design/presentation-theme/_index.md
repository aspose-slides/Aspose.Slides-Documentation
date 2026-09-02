---
title: إدارة سمات عروض PowerPoint في Python
linktitle: سمة العرض
type: docs
weight: 10
url: /ar/python-net/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- لون السمة
- لوحة إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض
- Python
- Aspose.Slides
description: "إدارة سمات العروض في Aspose.Slides لـ Python عبر .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية موحدة."
---
## **مقدمة**

يعرّف سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تشير الكائنات ذات الوعي بالسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال خاصية [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للسمة في مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/masterthememanager/override_theme/)، ويمكن للتخطيط أن يتجاوز سمة الماستر الموروثة عبر [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)، ويمكن للشرائح الفردية أن تفعل ذلك أيضاً. عمليًا، تُحل السمة الفعّالة للشفرة عبر سلسلة الوراثة التالية: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل سمة شيوعًا: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/) خاصية [color_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/font_scheme/)، و[format_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/format_scheme/). يُعد فحص هذه المجموعات قبل تعديلها مفيدًا بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للسمة ويقارير عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

إذا كان الملف يستخدم عدة ماسترز، لا تفترض أن كل شريحة لها نفس السمة الفعّالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذا المقال عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للتعبئات، الخطوط، والنصوص ذات الوعي بالسمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/) الخاص بالسمة، تُحل كل الكائنات التي لا تزال تشير إلى ذلك اللون السمة مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتأثر بتحديث لون السمة.

المثال النهائي التالي ينشئ شكلًا يستخدم `ACCENT4`، يغير لون السمة `accent4` إلى الأحمر، يحفظ العرض، يعيده، ويطبع لون التعبئة الفعّال:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

لأن المستطيل لا يزال مرتبطًا بـ`ACCENT4`، يصبح لونه الظاهر أحمر بعد تغيير السمة. إذا استبدلت اللون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة لـ`accent4` لن تؤثر على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

يستمد PowerPoint تنوعات أفتح وأغمق من لون السمة عبر تطبيق تحولات اللون. تُظهر Aspose.Slides هذه التحولات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/colortransformoperation/).

![الألوان الأساسية للسمة والألوان الفاتحة والغامقة المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان السمة الأساسية.

**2** - التنوعات الفاتحة والغامقة المنتجة من ألوان السمة الأساسية.

المثال التالي ينشئ ستة مستطيلات بناءً على `ACCENT4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

تظل هذه التنوعات مبنية على لون السمة. إذا تغير `accent4` لاحقًا، تُعاد حساب الألوان المحولة من قيمة `accent4` الجديدة.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/) القيم `TEXT1`، `BACKGROUND1`، `TEXT2`، و`BACKGROUND2`، بينما يُظهر [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/) نفس فتحات السمة كـ `dark1`، `light1`، `dark2`، و`light2`. الخريطة ثابتة:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

يتضمن مخطط خطوط السمة مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تُظهر خاصيتي [FontScheme.major](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/major/) و[FontScheme.minor](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/minor/) تلك المجموعات.

يمكن استخدام معرّفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - الخط الأساسي للغة اللاتينية (Minor Latin Font)
* `+mj-lt` - خط العنوان للغة اللاتينية (Major Latin Font)
* `+mn-ea` - الخط الأساسي للغات شرق آسيا (Minor East Asian Font)
* `+mj-ea` - خط العنوان للغات شرق آسيا (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا نصيًا يستخدم الخط اللاتيني الفرعي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

يتبع العنوان الخط الرئيسي ويتبع النص الأساسي الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلًا من معرف سمة لن يتبدل تلقائيًا عندما يتغيّر مخطط خطوط السمة.

يمكن لمجموعات الخطوط الرئيسية والفرعية أيضًا أن تحتوي على تعيينات خطوط للأنظمة الكتابية الفردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثعنا. لاستعراض، إضافة، استبدال أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/python-net/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/python-net/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

هناك عملان شائعة، وكل منهما يحل مشكلة مختلفة.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا كنت تريد نقل شريحة إلى عرض آخر والحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/)، ثم استنسخ الشريحة باستخدام [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) والماستر المستنسخ. ينتقل الماستر، تخطيطاته، والسمة المرتبطة معه معًا.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر وجهة غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات التي تعتمد على السمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على الماستر والتخطيط الحاليين، ابدأ تجاوزًا على مستوى الشريحة من السمة المصدر. تنسخ طرق [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)، و[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

ينطبق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، إلا إذا كان لشريحة معينة تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/layoutslidethememanager/) للتخطيط:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تُصعّب التجاوزات الزائدة على مستوى الشريحة تغييرات السمة العامة لاحقًا.

## **تحديث أنماط خلفية السمة**

تُخزن تعبئات خلفية السمة في [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). يمكن لـPowerPoint تقديم خيارات خلفية أكثر في واجهته مما هو مخزن فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة وإشارات الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.style_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/style_index/) الحالي. يستخدم `style_index` القيمة `0` لعدم وجود تعبئة سمة؛ القيم الموجبة هي مراجع لأنماط خلفية السمة. هذا يختلف عن فهرسة مجموعة بايثون مباشرةً، حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية سمة للماستر الأول، ويحفظ العرض:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة الظاهرة تعتمد على مدخل السمة الذي يشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت الشريحة تستخدم خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) عندما تحتاج لمعرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لا تعامل `style_index` كفهرس مجموعة يبدأ من الصفر. وتجنب ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية، راجع [Presentation Background](/slides/ar/python-net/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على مجموعات منفصلة من [FormatScheme.fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/line_styles/)، و[FormatScheme.effect_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/effect_styles/). غالبًا ما تحتوي سمات Office على ثلاث إدخالات أساسية تتطابق بصريًا مع تنسيقات خفيفة، معتدلة، وشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات سمة خفيفة، معتدلة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في بايثون، يكون فهرس المجموعة بصفرية: `[0]` هو النمط المخزن الأول و`[2]` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، تُظهرها [IShapeStyle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود إدخالات النمط المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط التعبئة الثالث، يفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

للأشكال التي تشير إلى هذه الفتحات، يصبح النمط السطري الأول للثيمة أحمر، والنمط التعبئة الثالث للثيمة أخضر غابي صلب، والنمط التأثير الثالث يضيف ظلًا خارجيًا بمسافة 10 نقاط. لا يزال الشكل النهائي يعتمد على الفتحات التي يشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تعديل إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

تخبرك كائنات السمة الخام بما هو معرف في مستوى معين. تُظهر القيم الفعّالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). للخلفية، استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/)، وللتعبئة استخدم [FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، وتعبئة الشكل الأول من شريحة:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

استخدم البيانات الفعّالة لتشخيص العرض، والتحقق، والمقارنات. إذا فحصت فقط [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/)، قد تفوتك ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/slidethememanager/) للشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/) و[SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/). سيحافظ ذلك على الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) لسمة شريحة أو تخطيط، واستخدم طرق البيانات الفعّالة المقابلة لكائنات التنسيق مثل [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) و[FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/). تُرجع هذه الواجهات القيم المَحَلَّة بعد تطبيق الوراثة والتجاوزات.
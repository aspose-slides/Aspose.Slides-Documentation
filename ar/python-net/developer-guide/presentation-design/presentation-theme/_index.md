---
title: إدارة سمات عروض PowerPoint التقديمية باستخدام بايثون
linktitle: سمة العرض
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
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides لبايثون عبر .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **مقدمة**

يحدد سمة العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملء والحدود والتأثيرات. تشير الكائنات المدركة للسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية مرئية كقيمة ثابتة، وبالتالي يمكن لتغيير السمة تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال الخاصية [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/). يمكن للعرض أيضًا أن يحتوي على تجاوزات سمة عند المستويات الأدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/masterthememanager/override_theme/)، ويمكن للتخطيط أن يتجاوز سمة الموروثة عبر [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)، ويمكن للشريحة الفردية أن تفعل نفس الشيء. عمليًا، يتم حل السمة الفعالة لشريحة ما عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان والخطوط وأنماط الخلفية والتأثيرات](theme-constituents.png)

تظهر الأقسام أدناه أكثر سير عمل السمة شيوعًا: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعالة بعد حل الوراثة والتجاوزات.

## **فحص السمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/) خصائص سمة [color_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/color_scheme/)، و[font_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/font_scheme/)، و[format_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/format_scheme/). فحص هذه التجميعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات النمط يمكن أن يختلف.

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعالة. فحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات تخطيط أو شريحة.

## **تغيير ألوان السمة**

يمكن للملء والخط والنص المدركين للسمة أن يشيروا إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/). عند تغيير الإدخال المقابل في سمة [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السُمِّّي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

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

نظرًا لأن المستطيل يظل مرتبطًا بـ `ACCENT4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `accent4` لن تؤثر بعد ذلك على ذلك الملء.

### **استخدام الألوان من لوحة الألوان الإضافية**

يستخرج PowerPoint متغيّرات أفتح وأغمق من لون السمة عن طريق تطبيق تحويلات الألوان. تُظهر Aspose.Slides هذه التحويلات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الفاتحة والغامقة المولدة من لوحة الألوان الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.

**2** - المتغيّرات الفاتحة والغامقة المشتقة من الألوان الرئيسية للسمة.

إنشاء مثال يخلق ستة مستطيلات قائمة على `ACCENT4`، ويطبق تحويلات إضاءة على خمسة منها، ثم يحفظ النتيجة:

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

هذه المتغيّرات ما تزال تستند إلى لون السمة. إذا تغير `accent4` لاحقًا، تُعاد حساب الألوان المحوَّلة من القيمة الجديدة لـ `accent4`.

### **تعيين قيم `SchemeColor` إلى فتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/) القيم `TEXT1` و`BACKGROUND1` و`TEXT2` و`BACKGROUND2`، بينما يكشف تعداد [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/) عن نفس الفتحات السِمِيّة كـ `dark1` و`light1` و`dark2` و`light2`. التعيين ثابت:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

هذه أسماء بديلة لنفس الفتحات السِمِيّة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل لآخر.

## **تغيير خطوط السمة**

تحتوي مخطّط خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر خصائص [FontScheme.major](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/major/) و[FontScheme.minor](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/minor/) تلك المجموعات.

يمكن استخدام معرفات خطوط سمة متوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (خط لاتيني ثانوي)
* `+mj-lt` - خط العنوان اللاتيني (خط لاتيني رئيسي)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي ثانوي)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (خط آسيوي شرقي رئيسي)

إنشاء مثال ينشئ عنوانًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط السمة اللاتيني الثانوي، ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتبدل تلقائيًا عندما يتغيّر مخطّط خطوط السمة.

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، انظر [PowerPoint Fonts](/slides/ar/python-net/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

هناك سير عملان شائعان، ويحلّان مشكلتين مختلفتين.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/)، ثم استنسخ الشريحة باستخدام [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) والماستر المستنسخ. ينقل هذا الماستر وتخطيطاته والسمة المرتبطة معه معًا.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر وجهة غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان يجب أن تظل الشريحة الهدف على الماستر والتخطيط الحاليين، ابدأ تجاوزًا على مستوى الشريحة من السمة المصدر. تنسخ الطرق [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)، و[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

يطبق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوزها الخاص. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/layoutslidethememanager/) الخاص بالتخطيط:

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

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى نمط مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة تغييرات السمة العالمية لاحقًا أصعب في التنبّؤ.

## **تحديث أنماط خلفية السمة**

تُخزن ملء خلفية السمة في [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته من عدد تعريفات الملء المخزنة فعليًا في هذا التجميع لأن الواجهة يمكنها دمج ملء السمة مع ألوان السمة وإشارات نمطية أخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص التجميع المخزن وخصية [Background.style_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/style_index/). يستخدم `style_index` القيمة `0` لعدم وجود ملء سِمِي؛ القيم الموجبة تشير إلى مراجع أنماط خلفية سِمِيّة. هذا يختلف عن فهرسة تجميع بايثون مباشرةً حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

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

يعتمد النتيجة الظاهرة على إدخال السمة المشار إليه من قبل الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت الشريحة تستخدم خلفية خاصة بها، قد لا يغيّر تغيير خلفية الماستر ذلك الشريحة. استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعامل `style_index` كفهرس تجميع يبدأ من الصفر. وتجنب أيضًا ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ولوراثة الخلفية، انظر [Presentation Background](/slides/ar/python-net/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطّط تنسيق السمة على تجميعات منفصلة لـ [FormatScheme.fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/fill_styles/)، و[FormatScheme.line_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/line_styles/)، و[FormatScheme.effect_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/effect_styles/). غالبًا ما تحتوي سمات Office على ثلاث إدخالات نمط رئيسية تمثّل بصريًا التنسيقات الدقيقة والمتوسطة والشديدة، لكن يجب على الكود فحص كل تجميع بدلاً من افتراض عدد ثابت.

![تأثيرات السمة الدقيقة والمتوسطة والشديدة المطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه التجميعات في بايثون، يكون فهرس التجميع يبدأ من الصفر: `[0]` هو أول نمط مخزن و`[2]` هو الثالث. فهارس مراجع النمط لل shapes هي مفهوم منفصل، يُظهره [IShapeStyle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

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

للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط سِمِيّ أحمر، ويصبح ثالث نمط ملء سِمِيّ أخضر غامق صلب، وتكتسب الخاصة الثالثة لتأثير الظل خارجي بمسافة 10 نقاط. لا يزال النتيجة البصرية الدقيقة تعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان هناك تنسيق مباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير إعدادات الخط والملء والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعالة**

تُظهر كائنات السمة الخام ما تم تعريفه على مستوى معين. تُظهر القيم الفعالة ما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). للخلفية، استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/)، وللملء، استخدم [FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/).

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

استخدم البيانات الفعالة للتشخيص والعرض والتحقق والمقارنات. إذا افترضت فقط [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/)، قد تغفل عن ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/slidethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة ثم استنسخ الشريحة باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/) و[SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/). يبقي هذا الماستر والتخطيطات والسمة معًا.

**كيف يمكنني رؤية القيم الفعالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) لسمة شريحة أو تخطيط، والطُرُق الفعّالة المقابلة لكائنات التنسيق مثل [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) و[FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
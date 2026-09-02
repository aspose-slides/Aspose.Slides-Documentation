---
title: إدارة سمات عروض PowerPoint التقديمية في Python
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
- سمة خارجية
- THMX
- لون السمة
- لوحة إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides لـ Python عبر .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع هوية تجارية متسقة."
---
## **مقدمة**

تحدد سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تشير الكائنات المدركة للسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية مرئية كقيمة ثابتة، وبالتالي يمكن لتغيير السمة تحديث العديد من الكائنات مرة واحدة.

In Aspose.Slides، تتوفر سمة مستوى العرض من خلال خاصية [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/) . يمكن للعرض أيضًا أن يحتوي على تجاوزات للسمة في مستويات أدنى. يمكن للـ master استبدال سمة العرض عبر [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/masterthememanager/override_theme/)، ويمكن للتخطيط استبدال سمة الموروثة عبر [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)، ويمكن للشريحة الفردية القيام بالمثل. عمليًا، يتم حل السمة الفعّالة لشريحة ما من خلال سلسلة الوراثة هذه: سمة العرض، تجاوز الـ master، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

الأقسام التالية تُظهر أكثر سير عمل السمة شيوعًا: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

كائن [MasterTheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/) يكشف عن خصائص سمة [color_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/font_scheme/)، و[format_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/format_scheme/) . فحص هذه التجميعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:
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

إذا كان الملف يستخدم عدة masters، لا تفترض أن كل شريحة لها نفس السمة الفعّالة. فحص الـ master المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات في التخطيط أو الشريحة.

## **تغيير ألوان السمة**

التعبئات، الخطوط، والنص المدرك للسمة يمكنه الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/) . عندما تقوم بتغيير المدخل المقابل في سمة [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/)، سيتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير عند تحديث لون السمة.

المثال التالي كاملًا ينشئ شكلًا يستخدم `ACCENT4`، يغير لون السمة `accent4` إلى الأحمر، يحفظ العرض، يعيده مرة أخرى، ويطبع لون التعبئة الفعّال:
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

نظرًا لأن المستطيل ما يزال مرتبطًا بـ `ACCENT4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

يستخرج PowerPoint تنويعات أفتح وأغمق من لون السمة عبر تطبيق تحولات لونية. تعرض Aspose.Slides هذه التحولات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/colortransformoperation/) .

![الألوان الرئيسة للسمة والألوان الأفتح والأغمق المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية.  
**2** - تنويعات أفتح وأغمق مُنتجة من ألوان السمة الرئيسية.

المثال التالي ينشئ ستة مستطيلات تستند إلى `ACCENT4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:
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

تظل هذه التنويعات مبنية على لون السمة. إذا تغير `accent4` لاحقًا، يتم إعادة حساب الألوان المحوّلة من القيمة الجديدة لـ `accent4`.

### **تعيين قيم `SchemeColor` إلى فتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/) القيم `TEXT1`، `BACKGROUND1`، `TEXT2`، و`BACKGROUND2`، بينما يكشف [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/) عن نفس فتحات السمة كـ `dark1`، `light1`، `dark2`، و`light2`. الخريطة ثابتة:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

تحتوي مخطَّط خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تعرض خصائص [FontScheme.major](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/major/) و[FontScheme.minor](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/minor/) تلك المجموعات.

* `+mn-lt` - خط النص الأساسي لاتيني (خط لاتيني ثانوي)
* `+mj-lt` - خط العنوان لاتيني (خط لاتيني رئيسي)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (خط شرق آسيوي ثانوي)
* `+mj-ea` - خط العنوان شرق آسيوي (خط شرق آسيوي رئيسي)

المثال التالي ينشئ عنوانًا يستخدم الخط اللاتيني الرئيسي للسمة وسطرًا أساسيًا يستخدم الخط اللاتيني الثانوي للسمة. ثم يغير خطوط السمة ويحفظ النتيجة:
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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتبدل تلقائيًا عندما تتغير مخطَّط خطوط السمة.

يمكن لمجموعات الخطوط الرئيسية والثانوية أيضًا أن تحتوي على تعيينات خطوط لأنظمة الكتابة الفردية، مثل السيريلي، العربية، اليابانية، الجورجية، والثانا. لفحصها أو إضافتها أو استبدالها أو إزالتها، راجع [Script-Specific Theme Fonts](/slides/ar/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
للمزيد من المعلومات حول خطوط العروض، راجع [PowerPoint Fonts](/slides/ar/python-net/powerpoint-fonts/) .
{{% /alert %}}

## **نسخ أو تطبيق سمة**

سير عمل أدناه يحل مشاكل مختلفة متعلقة بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة للـ Master**

استخدم [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على master معين. حدد الـ master من مجموعة [Presentation.masters](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/masters/) التي تنفّذ [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

الطريقة تنفّذ العمليات التالية:
1. ينشئ شريحة master جديدة استنادًا إلى الـ master المحدد.
2. يطبق السمة الخارجية على الـ master الجديد.
3. يُعيّن الـ master الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الـ master المحدد.
4. يُعيد الـ [IMasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على الـ master الأول ويحفظ العرض:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

قد تتسبب سمة غير صالحة أو تالفة أو غير مدعومة في حدوث [PptxException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxexception/) أو أحد الفئات الفرعية المرتبطة بالتنسيق. تحقّق من صحة المسارات التي يقدمها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يتم إعادة تعيين الشرائح التي كانت تعتمد على الـ master المحدد فقط. الشرائح المرتبطة بآخرين يحتفظون بالـ master والسمة الحالية. تُحل الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات المدركة للسمة مقابل السمة الخارجية. قد تبقى الألوان، الخطوط، التعبئات، والتنسيقات الصريحة المعينة مباشرة دون تغيير. يمكن لتجاوزات مستوى التخطيط ومستوى الشريحة أيضًا أن تتصدر القيم الموروثة من الـ master الجديد.

قد تشير السمة إلى خطوط غير متوفرة في بيئة التنفيذ. للحصول على عرض وتصدير متسقين، قم بتثبيت الخطوط المطلوبة، أو وفرها عبر [custom font sources](/slides/ar/python-net/custom-font/)، أو اضبط [font substitution](/slides/ar/python-net/font-substitution/).

هذا سير عمل مباشر على مستوى الـ master: تستقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة يدوية على مستوى الشريحة أو التخطيط.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الـ Master**

عند عدم معرفة الـ master المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide.layout_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/layout_slide/) و[LayoutSlide.master_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/master_slide/). احفظ مراجع الـ master الأصلية قبل تطبيق أي سمات لأن كل استدعاء ينشئ master آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد الـ masters الخاصة بها ويطبق سمة خارجية مختلفة على كل مجموعة:
```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

النداء الأول يؤثر فقط على الشرائح التي كانت تعتمد على `first_group_master`، والنداء الثاني يؤثر فقط على الشرائح التي كانت تعتمد على `second_group_master`. الشرائح المرتبطة بأي master آخر لا يتم إعادة تنسيقها.

### **حفظ سمة المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، قم باستنساخ الـ master الأصلي إلى العرض الهدف باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/)، ثم استنسخ الشريحة باستخدام [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) والـ master المستنسخ. هذا ينقل الـ master وتخطيطاته والسمة المرتبطة معًا.
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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى إلى master غير مرتبط يمكن أن يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة المستهدفة على الـ master والتخطيط الحاليين، قم بتهيئة تجاوز على مستوى الشريحة من السمة المصدرية. تنسخ طرق [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)، و[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.
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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/clear/) .

### **تطبيق تجاوز سمة على التخطيط**

تطبيق التجاوز على مستوى التخطيط ينطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لديها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/layoutslidethememanager/) الخاص بالتخطيط:
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

استخدم سمة على مستوى الـ master أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدام تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدام تجاوز الشريحة فقط للحالات الاستثنائية الحقيقية. التجاوزات الكثيفة على مستوى الشريحة تجعل من الصعب التنبؤ بتغييرات السمة العامة لاحقًا.

## **تحديث أنماط خلفية السمة**

تُخزَّن تعبئات خلفية السمة في [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). يمكن لـ PowerPoint عرض المزيد من خيارات الخلفية في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة وإشارات أسلوب أخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.style_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/style_index/) الحالي. يستخدم `style_index` القيمة `0` لعدم وجود تعبئة سمة؛ والقيم الإيجابية تشير إلى إشارات أنماط خلفية السمة. هذا يختلف عن فهرسة مجموعة Python مباشرةً، حيث يعني `[0]` العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلّغ عن عدد تعبئات الخلفية المتوفرة، يعيّن إشارة خلفية سمة للـ master الأول، ويحفظ العرض:
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

النتيجة المرئية تعتمد على مدخل السمة المشار إليه من قبل الـ master وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت شريحة ما تستخدم خلفية خاصة بها، قد لا يؤدي تغيير خلفية الـ master فقط إلى تغيير تلك الشريحة. استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعامل `style_index` كفهرس مجموعة يبدأ من الصفر. تجنّب أيضًا ترميز رقم نمط ثابت من ملف واحد وفترض أنه يظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/python-net/presentation-background/) .
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطَّط تنسيق السمة على مجموعات منفصلة من [FormatScheme.fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/line_styles/)، و[FormatScheme.effect_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/effect_styles/) . غالبًا ما تحتوي سمات Office النموذجية على ثلاثة مدخلات نمط رئيسية تمثّل بصريًا تنسيقًا خفيفًا، معتدلًا، ومكثفًا، لكن يجب على الكود فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات السمة الخفيفة، المعتدلة، والمكثفة المطبقة على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Python، يكون فهرس المجموعة يبدأ من الصفر: `[0]` هو أول نمط مخزن و`[2]` هو الثالث. فهارس إشارة نمط الشكل مفهوم منفصل، يُظهر عبر [IShapeStyle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapestyle/) . تعديل نمط السمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقّق من وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر النمط الثالث للتعبئة، يُفعّل ظل خارجي في النمط الثالث للتأثير، ويحفظ النتيجة:
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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط سمة باللون الأحمر، والنمط الثالث للتعبئة سمة باللون الأخضر الغابي الصلب، ويضيف النمط الثالث للتأثير ظلًا خارجيًا بمسافة 10 نقاط. لا يزال النتيجة البصرية الدقيقة تعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

توفر كائنات السمة الخام ما هو معرف على مستوى معين. القيم الفعّالة توضح ما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للحصول على سمة شريحة، استدعِ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) . للحصول على خلفية، استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) ، وللتعبئة استخدم [FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/) .

المثال التالي يقرأ السمة الفعّالة، الخلفية، والتعبئة الأولى للشكل من شريحة:
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

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/)، قد تفوت تجاوزًا على مستوى الـ master أو التخطيط أو الشريحة أو الشكل يغيّر المظهر النهائي.

## **الأسئلة الشائعة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. تقوم [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) بإعادة تعيين فقط الشرائح التي تعتمد على الـ master المحدد. الشرائح التي تستخدم ماسات أخرى تحتفظ بسماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الـ master؟**

نعم. استخدم [SlideThemeManager] الخاص بالشريحة وابدأ سمة التجاوز الخاصة به. يبقى التغيير محليًا لتلك الشريحة؛ الشرائح الأخرى تستمر في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، قم باستنساخ الـ master المصدر إلى الوجهة ثم استنسخ الشريحة مع ذلك الـ master باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/) و[SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) . هذا يحافظ على الـ master، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.create_theme_effective] لسمة شريحة أو تخطيط، واستخدم طرق البيانات الفعّالة المقابلة لكائنات التنسيق مثل [Background.get_effective] و[FillFormat.get_effective] . تُعيد هذه الـ API القيم التي تم حلها بعد تطبيق الوراثة والتجاوزات.
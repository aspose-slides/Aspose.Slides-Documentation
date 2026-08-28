---
title: إدارة سمات عروض PowerPoint التقديمية في بايثون
linktitle: موضوع العرض
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
- سمة خارجية
- THMX
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض
- Python
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides للبايثون عبر .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على الهوية البصرية المتسقة."
---
## **المقدمة**

يعرّف موضوع العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والأنماط التأثيرية. تشير الكائنات المتوافقة مع الموضوع إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير الموضوع أن يحدّث العديد من الكائنات في آنٍ واحد.

في Aspose.Slides، يتوفر موضوع العرض على مستوى العرض عبر الخاصية [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للموضوع في مستويات أدنى. يمكن للماستر أن يتجاوز موضوع العرض عبر [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/masterthememanager/override_theme/)، ويمكن للتخطيط أن يتجاوز موضوعه الموروث عبر [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)، كما يمكن للشفرة الفردية أن تفعل ذلك. عملياً، يتم حل الموضوع الفعّال للشفرة عبر سلسلة الوراثة هذه: موضوع العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات الموضوع: الألوان، الخطوط، أنماط الخلفية، والأنماط التأثيرية](theme-constituents.png)

العناوين أدناه توضح أكثر سير عمل شائع للموضوع: فحص موضوع، تغيير الألوان والخطوط، نسخ أو تطبيق موضوع، تحديث أنماط الخلفية والأنماط التأثيرية، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص موضوع**

الكائن [MasterTheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/) يعرض خاصية [color_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/font_scheme/)، و[format_scheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/mastertheme/format_scheme/). فحص هذه المجموعات قبل تعديلها يكون مفيداً خصوصاً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مداخل الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للموضوع ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والأنماط التأثيرية المخزنة في الموضوع:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لديها نفس الموضوع الفعّال. افحص الماستر المرتبط بالشفرة، واستخدم سير عمل الموضوع الفعّال الموضّح لاحقاً في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان الموضوع**

يمكن للملء، الخطوط، والنص المتوافق مع الموضوع أن يشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/) الخاص بالموضوع، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون عبر القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون الموضوع.

المثال التالي يُنشئ شكلاً يستخدم `ACCENT4`، يغيّر لون `accent4` في الموضوع إلى الأحمر، يحفظ العرض، يفتحه مجدداً، ويطبع لون التعبئة الفعّال:

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

بما أن المستطيل ما زال مرتبطاً بـ `ACCENT4`، يصبح لونه الظاهر أحمر بعد تغيير الموضوع. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة لـ `accent4` لن تؤثر على ذلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

يستخرج PowerPoint تنويعات أفتح وأغمق من لون الموضوع عبر تطبيق تحويلات لونية. تُظهر Aspose.Slides هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للموضوع والألوان الفاتحة والداكنة المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للموضوع.

**2** - التنويعات الفاتحة والداكنة المولدة من الألوان الرئيسية للموضوع.

المثال التالي يُنشئ ستة مستطيلات تعتمد على `ACCENT4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

هذه التنويعات لا تزال مستندة إلى لون الموضوع. إذا تغير `accent4` لاحقاً، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/) القيم `TEXT1`، `BACKGROUND1`، `TEXT2`، و`BACKGROUND2`، بينما يعرض [ColorScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/colorscheme/) نفس الفتحات كـ `dark1`، `light1`، `dark2`، و`light2`. الخريطة ثابتة:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

هذه أسماء بديلة لنفس فتحات الموضوع؛ ليست قيماً تُحوَّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط الموضوع**

تحتوي مخطّط خطوط الموضوع على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر الخصائص [FontScheme.major](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/major/) و[FontScheme.minor](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/minor/) تلك المجموعات.

يمكن استخدام معرفات خطوط الموضوع المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي لاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان لاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)

المثال التالي يُنشئ عنواناً يستخدم خط الموضوع اللاتيني الرئيسي وسطر نص أساسي يستخدم خط الموضوع اللاتيني الثانوي. ثم يغيّر خطوط الموضوع ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف موضوع لن يتحول تلقائيًا عندما يتغيّر مخطّط خطوط الموضوع.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والثانوية أيضاً على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريلية، العربية، اليابانية، الجورجية، والثانا. لاستعراض، إضافة، استبدال أو إزالة هذه التعيينات، راجع [خطوط الموضوع الخاصة بالسكربت](/slides/ar/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/python-net/powerpoint-fonts/).

{{% /alert %}}

## **نسخ أو تطبيق موضوع**

تُحلّ سير العمل أدناه مشاكل مختلفة متعلقة بالموضوع.

### **تطبيق موضوع خارجي على الشرائح التابعة لِماستر**

استخدم [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) عندما يكون لديك ملف موضوع PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.masters](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/masters/) التي تنفّذ [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/)، ومرّر مسار ملف الموضوع إلى الطريقة.

تُجري الطريقة العمليات التالية:

1. تنشئ ماستر شريحة جديد بناءً على الماستر المحدد.
1. تطبق الموضوع الخارجي على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد مسبقاً على الماستر المختار.
1. تُعيد كائن [IMasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/) الذي تم إنشاؤه حديثاً.

المثال التالي يُطبّق موضوعًا خارجيًا على الشرائح التي تعتمد على الماستر الأول ويحفظ العرض:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

يمكن أن يتسبب موضوع غير صالح، أو فاسد، أو غير مدعوم في حدوث [PptxException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxexception/) أو أحد فروعه المتعلقة بالتنسيق. تحقق من صحة المسارات التي يزودها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق الموضوع بنجاح.

يُعاد فقط تعيين الشرائح التي كانت تعتمد على الماستر المختار. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها ومواضيعها الحالية. تُحلّ الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والأنماط التأثيرية المتوافقة مع الموضوع ضد الموضوع الخارجي. قد تظل الألوان، الخطوط، التعبئات، والتنسيقات الصريحة المُعيَّنة مباشرةً دون تغيير. يمكن لتجاوزات المستوى التخطيطية والمستوى الشريحة أيضاً أن تتفوق على القيم الموروثة من الماستر الجديد.

قد يشير الموضوع إلى خطوط غير متوفرة في بيئة التشغيل. من أجل عرض وتصدير متسقين، ثبّت الخطوط المطلوبة، أو وفّرها عبر [مصادر الخطوط المخصَّصة](/slides/ar/python-net/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/python-net/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تستقبل الطريقة مسار ملف `.thmx` ولا تتطلّب إنشاء تجاوزات موضوع على مستوى الشريحة أو التخطيط يدوياً.

### **تطبيق مواضيع خارجية مختلفة في عرض متعدد الماسترات**

عند عدم معرفة الماستر المناسب مسبقاً، احصل عليه من شريحة تمثيلية عبر [Slide.layout_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/layout_slide/) و[LayoutSlide.master_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/master_slide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي موضوع لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويطبق موضوعًا خارجيًا مختلفًا على كل مجموعة:

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

الاستدعاء الأول يؤثّر فقط على الشرائح التي تعتمد على `first_group_master`، والاستدعاء الثاني يؤثّر فقط على الشرائح التي تعتمد على `second_group_master`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على موضوع المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، قم باستنساخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/)، ثم استنسخ الشريحة باستخدام [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) والماستر المستنسخ. هذا يحمل الماستر وتخطيطاته والموضوع المرتبط به معاً.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية كما هي في الوجهة. مجرد استنساخ المحتوى إلى ماستر هدف غير ذي صلة قد يغيّر الألوان، الخطوط، الخلفيات، والأنماط التأثيرية المدفوعة بالموضوع.

### **تطبيق قيم الموضوع على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على ماسترها وتخطيطها الحالي، ابدأ بتجاوز مستوى الشريحة من موضوع المصدر. تنسخ الطرق [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)، و[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) المكوّنات الثلاثة الرئيسية للموضوع إلى التجاوز.

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

هذا يغيّر الموضوع المستخدم لتلك الشريحة دون تعديل الموضوع الموروث من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز موضوع على تخطيط**

يُطبّق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم يكن للشفرة نفسها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/layoutslidethememanager/) الخاص بالتخطيط:

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

استخدم موضوع على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيطات واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للحالات الاستثنائية الحقيقية. التجاوزات المفرطة على مستوى الشريحة تجعل التغييرات العالمية للموضوع لاحقاً أصعب في التنبؤ.

## **تحديث أنماط خلفية الموضوع**

يتم تخزين تعبئات خلفية الموضوع في [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). يمكن لـ PowerPoint عرض مزيد من خيارات الخلفية في واجهته من عدد التعريفات الفعلية المخزنة في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات الموضوع مع ألوان الموضوع ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لموضوع عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.style_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/style_index/) الحالي. يستخدم `style_index` القيمة `0` لعدم وجود تعبئة موضوع؛ القيم الموجبة تشير إلى مراجع أنماط خلفية الموضوع. هذا يختلف عن فهرسة مجموعة بايثون مباشرةً حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط التعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يُعيّن إشارة خلفية موضوعية للماستر الأول، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على المدخل الموضوعي الذي يُشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت الشريحة خلفيتها الخاصة، قد لا يغيّر تعديل خلفية الماستر فقط تلك الشريحة. استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}

لا تتعامل مع `style_index` كفهرس مجموعة يبدأ من الصفر. وتجنّب أيضًا ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط الموضوع خاصة بالعرض.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

للتنسيق الخلفي المباشر والوراثة الخلفية، راجع [خلفية العرض](/slides/ar/python-net/presentation-background/).

{{% /alert %}}

## **تحديث أنماط تأثيرات الموضوع**

يحتوي مخطّط تنسيق الموضوع على مجموعات منفصلة لـ [FormatScheme.fill_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/line_styles/)، و[FormatScheme.effect_styles](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/formatscheme/effect_styles/). غالباً ما تحتوي المواضيع المكتبية على ثلاث مداخل أساسية تتCorrespond to subtle, moderate, and intense formatting, لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات موضوعية دقيقة، معتدلة، وشديدة تُطبّق على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في بايثون، يكون الفهرس صفرياً: `[0]` هو أول نمط مخزن و`[2]` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، يُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapestyle/). تعديل نمط موضوع يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود المداخل المطلوبة، يغيّر النمط الخط الأول، يغيّر النمط التعبئة الثالث، يُفعّل ظلًا خارجيًا في النمط التأثيري الثالث، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح النمط الخط الأول للموضوع أحمر، والنمط التعبئة الثالث يصبح أخضر غابوي صلب، والنمط التأثيري الثالث يضيف ظلًا خارجيًا بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على أي فتحات نمط كل شكل يشير إليها وما إذا كان التنسيق المباشر يتجاوز الموضوع.

![أنماط تأثير موضوعية بعد تغيير الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **تحديد ما إذا كان تعبئة صلبة فعّالة تستخدم لون موضوع**

يمكن تخزين التعبئة مباشرة على كائن أو وراثتها من فقرة، تخطيط، ماستر، نمط موضوع، أو مستوى تنسيق آخر. استدعِ [FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/) لحل تلك السلسلة إلى كائن [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/) غير قابل للتغيير. أولاً افحص [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/fill_type/). فقط عندما يكون `FillType.SOLID` يجب قراءة خصائص التعبئة الصلبة.

للتعبئة الصلبة، تُعيد [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) القيمة النهائية للـ RGB بعد الوراثة، بحث الموضوع، وتطبيق تحويلات اللون. تُعيد [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) الفتحة المنطقية من [SchemeColor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/schemecolor/) المقابلة، مثل `TEXT1` أو `ACCENT6`. قيمة `SchemeColor.NOT_DEFINED` تعني أن التعبئة الصلبة الفعّالة ليست مبنية على لون مخطط. في سير عمل حيث تكون التعبئات إما ألوان موضوع أو ألوان RGB مباشرة، تُحدِّد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [IColorFormat.scheme_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icolorformat/scheme_color/) المحلية بمفردها لتصنيف التعبئة. على سبيل المثال، قد لا يحتوي جزء نص على لون مخطط محلي، فيصبح قيمته `NOT_DEFINED` محلياً، بينما تعبئته الفعّالة ترتكز على لون موضوع وتُحل إلى `TEXT1` أو `ACCENT6`. بالمقابل، تُظهر `solid_fill_scheme_color` أي فتحة موضوع منطقية أنتجت اللون الفعّال، لكنها لا تخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر في شجرة التنسيق.

المثال التالي يحمل عرضًا، يُدقق كل من تعبئات الأشكال وتعبئات أجزاء النص، يطبع كل قيمة RGB نهائية واللون المخطط المرتبط، ويُعلم عن التعبئات الصلبة التي لن تتعقّب تغيّر ألوان الموضوع:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

الفرع `NOT_DEFINED` يقدم قائمة تدقيق للتعبئات الصلبة التي لن تستجيب لتغيّرات فتحات ألوان الموضوع. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. ما زالت قيمة RGB المُدرجة تُظهر المظهر الحالي، بينما يوضح قيمة المخطط ما إذا كان هذا المظهر مرتبطًا بالموضوع.

الكائنات الفعّالة تمثّل لقطات. بعد تغيير موضوع العرض، أو تجاوز موضوع، أو أي تنسيق وراثي، استدعِ `get_effective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم الموضوع الفعّالة**

تُظهر كائنات الموضوع الخام ما تم تعريفه في مستوى معين. القيم الفعّالة تُظهر ما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). للخلفية، استخدم [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/)، وللتعبئة، استخدم [FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/).

المثال التالي يقرأ الموضوع الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، وإجراء المقارنات. إذا فحصت فقط [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/)، قد تغفل تجاوز ماستر، تخطيط، شريحة، أو شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق موضوع خارجي على كل شريحة في العرض؟**

لا. تُعيد [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) تعيين الشرائح التي تعتمد فقط على الماستر المختار. الشرائح التي تستخدم ماسترات أخرى تحتفظ بمواضيعها الحالية.

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/slidethememanager/) للشفرة وابدأ تهيئة موضوع التجاوز الخاص بها. يبقى التغيير محليًا لتلك الشريحة؛ الشرائح الأخرى تستمر في وراثة مواضيعها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل موضوع من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/add_clone/) و[SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/). هذا يحافظ على الماستر، التخطيطات، والموضوع معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) لشريحة أو تخطيط موضوع، واستخدم الطرق المقابلة للبيانات الفعّالية لكائنات التنسيق مثل [Background.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/background/get_effective/) و[FillFormat.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fillformat/get_effective/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
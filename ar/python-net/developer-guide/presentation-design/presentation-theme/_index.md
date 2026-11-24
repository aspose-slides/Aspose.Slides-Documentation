---
title: إدارة سمات عروض PowerPoint التقديمية في بايثون
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/python-net/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض التقديمي
- سمة الشريحة
- تعيين السمة
- تغيير السمة
- إدارة السمة
- سمة خارجية
- THMX
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "التحكم في سمات العروض التقديمية في Aspose.Slides للبايثون عبر .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **المقدمة**

يُعرّف موضوع العرض التقديمي مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، الملء، الخطوط، والتأثيرات. تُشير الكائنات المدركة للموضوع إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير الموضوع أن يُحدّث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، يتوفر موضوع مستوى العرض التقديمي عبر خاصية [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) . يمكن للعرض التقديمي أيضًا أن يحتوي على تجاوزات للموضوع على مستويات أدنى. يمكن للماستر أن يتجاوز موضوع العرض التقديمي من خلال [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/)، ويمكن للتخطيط أن يتجاوز موضوعه الموروث عبر [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)، ويمكن للشرحة الفردية أن تفعل الشيء نفسه. عمليًا، يُحلّ الموضوع الفعّال لشرحة ما من خلال سلسلة الوراثة هذه: موضوع العرض التقديمي، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشرحة.

![مكونات الموضوع: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل شائع للموضوع: فحص موضوع، تغيير الألوان والخطوط، نسخ أو تطبيق موضوع، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص موضوع**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) خاصية [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/)، [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/)، و[format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) الخاصة بالموضوع. فحص هذه المجموعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

المثال التالي يقرأ خصائص الموضوع الرئيسية ويبلغ عن عدد أنماط الخلفية، الملء، الخط، والتأثير المخزنة في الموضوع:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس الموضوع الفعّال. افحص الماستر المرتبط بالشرحة، واستخدم سير عمل الموضوع الفعّال الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان الموضوع**

يمكن للملء، الخطوط، والنص المدرك للموضوع الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) الخاص بالموضوع، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون وفقًا للقيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون الموضوع.

المثال التالي من البداية إلى النهاية ينشئ شكلًا يستخدم `ACCENT4`، يغير لون `accent4` في الموضوع إلى الأحمر، يحفظ العرض، يعيده فتحه، ويطبع لون الملء الفعّال:

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

لأن المستطيل لا يزال مرتبطًا بـ `ACCENT4`، يصبح لونه المرئي أحمر بعد تغيير الموضوع. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `accent4` لن تؤثر بعد الآن على ذلك الملء.

### **استخدام الألوان من اللوحة الإضافية**

يستخرج PowerPoint متغيرات أفتح وأغمق من لون موضوع عن طريق تطبيق تحولات لونية. تكشف Aspose.Slides عن هذه التحولات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![الألوان الأساسية للموضوع والألوان الأفتح والأغمق المتولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الأساسية للموضوع.

**2** - المتغيرات الأفتح والأغمق المنتجة من الألوان الأساسية للموضوع.

المثال التالي ينشئ ستة مستطيلات تستند إلى `ACCENT4`، يطبق تحولات اللمعان على خمسة منها، ويحفظ النتيجة:

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

هذه المتغيرات لا تزال مستندة إلى لون الموضوع. إذا تغير `accent4` لاحقًا، تُعاد حساب الألوان المتحولة من القيمة الجديدة لـ `accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) القيم `TEXT1`، `BACKGROUND1`، `TEXT2`، و`BACKGROUND2`، بينما يكشف [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) عن نفس فتحات الموضوع كـ `dark1`، `light1`، `dark2`، و`light2`. الترابط ثابت:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

هذه أسماء بديلة لنفس فتحات الموضوع؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل لآخر.

## **تغيير خطوط الموضوع**

تحتوي مخططات خطوط الموضوع على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تكشف خصائص [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) و[FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) عن تلك المجموعات.

يمكن استخدام معرفات خطوط الموضوع المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)
* `+mn-cs` - خط النص الأساسي للخطوط المركبة (Minor Complex Script Font)
* `+mj-cs` - خط العنوان للخطوط المركبة (Major Complex Script Font)

المثال التالي ينشئ عنوانًا يستخدم خط الموضوع اللاتيني الرئيسي وخطًا أساسيًا يستخدم خط الموضوع اللاتيني الفرعي. ثم يغيّر خطوط الموضوع ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف موضوع لن يتحول تلقائيًا عندما يتغيّر مخطط خطوط الموضوع.

يمكن أن تحتوي مجموعة الخطوط الرئيسة والفرعية أيضًا على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريلية، العربية، اليابانية، الجورجية، والثانائية. لفحص، إضافة، استبدال، أو إزالة هذه التعيينات، انظر [Script-Specific Theme Fonts](/slides/ar/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض التقديمي، انظر [PowerPoint Fonts](/slides/ar/python-net/powerpoint-fonts/).
{{% /alert %}}

### **حل مراجع خطوط الموضوع**

عند فحص النص، قد يحتوي [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) على إشارة موضوع مثل `+mn-lt` بدلاً من اسم عائلة الخط. استدعِ [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) مع [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) المناسب لحل تلك الإشارة. تمهيدات `+mj` و `+mn` تختار مجموعات الخطوط الرئيسة والفرعية؛ اللاحقات `-lt`، `-ea`، و `-cs` تختار خطوط اللاتينية، الآسيوية الشرقية، والكتابة المركبة على التوالي.

احصل على الموضوع الفعّال عبر [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) على الكائن الذي ينطبق عليه الموضوع بالنسبة للنص المفحوص. للنص العادي على شريحة، استخدم `slide.create_theme_effective` حتى يشمل السياق موضوع الشريحة الموروث وتجاوزاتها المحلية. عند فحص تخطيط أو ماستر نفسه، استخدم موضوعه الفعّال الخاص. لا تفترض أن موضوع أول ماستر ينطبق على كل شريحة.

المثال التالي ينشئ جزء نص يشار صراحة إلى الخط اللاتيني الفرعي. يهيئ مخطط خطوط شريحة عبر [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) ويضبط عائلتي الخطوط اللاتينية الرئيسة والفرعية إلى `Arial` و`Calibri`، مما يجعل النتيجة قابلة لإعادة الإنتاج دون ملف إدخال.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

الناتج هو `+mn-lt -> Calibri` يليه `Verdana -> Verdana`. تظل الإشارة المخزنة دون تغيير، في حين يُرجع اسم العائلة الصريح كما هو. إذا استخدم الجزء `+mj-lt`، لكان يُحل إلى `Arial` في هذا الموضوع.

حل إشارة الموضوع يحدّد عائلة الخط التي حدّدها الموضوع. لا يتحقق من توفر الخط أو يحدد ملف الخط النهائي المستخدم بعد الاستبدال أو التراجع عن الحروف أثناء التصيير. انظر [Font Selection Sequence](/slides/ar/python-net/font-selection-sequence/) و[Font Substitution](/slides/ar/python-net/font-substitution/) لتلك الخطوات المنفصلة.

## **نسخ أو تطبيق موضوع**

تحلّ سير العمل أدناه مشكلات مختلفة متعلقة بالموضوع.

### **تطبيق موضوع خارجي على الشرائح التابعة للماستر**

استخدم [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) عندما يكون لديك ملف موضوع PowerPoint (`.thmx`) وتريد إعادة تصميم كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/))، ومرّر مسار ملف الموضوع إلى الطريقة.

تُجري الطريقة العمليات التالية:

1. تنشئ ماستر شريحة جديد استنادًا إلى الماستر المختار.
1. تُطبق الموضوع الخارجي على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الماستر المختار.
1. تُعيد ماستر الشريحة الجديد [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

المثال التالي يُطبق موضوعًا خارجيًا على الشرائح التي تعتمد على أول ماستر ويحفظ العرض التقديمي:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

قد يسبب موضوع غير صالح أو تالف أو غير مدعوم استثناءً من نوع [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) أو أحد فروعه المتعلقة بالتنسيق. تحقق من صحة المسارات التي يُدخلها المستخدمون، وتعامل مع فشل وصول نظام الملفات، واحفظ العرض فقط بعد تطبيق الموضوع بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المحدد فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها ومواضيعها الحالية. تُحلّ ألوان، خطوط، ملء، خطوط، خلفيات، وتأثيرات مدركة للموضوع مقابل الموضوع الخارجي. قد تظل الألوان، الخطوط، الملء، والتنسيق الصريح المعين مباشرة دون تغيير. قد تتفوّق تجاوزات المستوى التخطيطي أو المستوى الشريحي على القيم الموروثة من الماستر الجديد.

يمكن أن يشير الموضوع إلى خطوط غير متوفرة في بيئة التشغيل. للحصول على تصيير وتصدير ثابتين، قم بتثبيت الخطوط المطلوبة، ووفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/python-net/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/python-net/font-substitution/).

هذا هو سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات موضوع على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق مواضيع خارجية مختلفة في عرض متعدد الماسترات**

عندما لا يُعرف الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) و[LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). احفظ مراجع الماستر الأصلي قبل تطبيق أي موضوع لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

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

النداء الأول يؤثر فقط على الشرائح التي كانت تعتمد على `first_group_master`، والنداء الثاني يؤثر فقط على الشرائح التي كانت تعتمد على `second_group_master`. الشرائح المرتبطة بأي ماستر آخر لن تُعاد تصميمها.

### **الحفاظ على موضوع المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، انسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/)، ثم انسخ الشريحة باستخدام [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) والماستر المستنسخ. ينقل هذا الماستر وتخطيطاته والموضوع المرتبط معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. إن نسخ المحتوى إلى ماستر غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالموضوع.

### **تطبيق قيم الموضوع على شريحة موجودة**

إذا كان لابد من بقاء الشريحة الهدف على ماستره وتخطيطه الحاليين، ابدِء تجاوزًا على مستوى الشريحة من الموضوع المصدر. تنسخ الأساليب [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)، [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)، و[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) المكوِّنات الثلاثة الرئيسية للموضوع إلى التجاوز.

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

هذا يغيّر الموضوع المُستَخدم لتلك الشريحة دون تغيير الموضوع الموروث للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز موضوع على تخطيط**

يُطبق تجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، إلا إذا كانت شريحة معينة لديها تجاوز خاص بها. يمكن استخدام نفس أساليب التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) الخاص بالتخطيط:

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

استخدم موضوعًا على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة تغييرات الموضوع العامة اللاحقة أصعب في التنبؤ.

## **تحديث أنماط خلفية الموضوع**

تُخزن ملء الخلفيات للموضوع في [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مما هو مخزن فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج ملء الموضوع مع ألوان الموضوع وإشارات الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لموضوع عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) الحالي. يستخدم `style_index` القيمة `0` لعدم وجود ملء موضوع؛ القيم الموجبة تمثل إشارات أنماط خلفية موضوعية. هذا مختلف عن فهرسة مجموعة بايثون مباشرةً، حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

المثال التالي يبلغ عن عدد ملء الخلفية المتاح، يعيّن إشارة خلفية موضوعية إلى أول ماستر، ويحفظ العرض:

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

يعتمد النتيجة الظاهرة على مدخل الموضوع الذي يشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعتبـر `style_index` كفهرس مجموعة يبدأ من الصفر. وتجنّب أيضًا ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط الموضوع خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية، انظر [Presentation Background](/slides/ar/python-net/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات الموضوع**

تحتوي مخططات تنسيق الموضوع على مجموعات منفصلة من [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/)، [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/)، و[FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). غالبًا ما تحتوي مواضيع Office على ثلاثة مدخلات أساسية تمثل بصريًا تنسيقات خفيفة، متوسطة، ومكثفة، لكن ينبغي على الكود فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات موضوع خفيفة، متوسطة ومكثفة مطبقة على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في بايثون، يكون فهرس المجموعة صفرًا أساسًا: `[0]` هو أول نمط مخزن و`[2]` هو الثالث. فهارس مراجع الأنماط للشكّل مفهوم منفصل، يتم كشفه عبر [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). تعديل نمط موضوع يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتأكد من وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط ملء، يُفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح أول نمط خط موضوع أحمر، وثالث نمط ملء موضوع أخضر غابي صلب، وثالث نمط تأثير يضيف ظلًا خارجيًا بمسافة 10 نقاط. لا يزال الناتج البصري يعتمد على أي فتحات نمط تشير إليها الأشكال وما إذا كان التنسيق المباشر يتجاوز الموضوع.

![أنماط تأثير الموضوع بعد تغيير الخط، الملء، وإعدادات الظل](presentation-design_11.png)

## **اختيار أنماط ملء وخط موضوع لشكل**

يمكن للشكل اختيار ملءه وخطّه بشكل مستقل عبر [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) و[ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). لكل من الخاصيتين، يحدد الفهرس `1` أول مدخل في مجموعة الموضوع المقابلة (`fill_styles[0]` أو `line_styles[0]`)، ويحدد الفهرس `2` المدخل الثاني.

المثال التالي يُعرّف ملءين (ذهبي وأزرق سماوي) وخطّين (أزرق غامق بـ 6 نقاط وأحمر غامق بـ 12 نقطة) في موضوع افتراضي لعرض تقديمي جديد. يحفظ الشريحة في ثلاث مراحل لتتمكن من مقارنة النتائج في PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| الأنماط الأولية | تغيير الخط الأيمن | تعديل أول ملء موضوع |
|:---:|:---:|:---:|
| ![مستطيلات ذهبية وزرقاء سماوية ذات حدود زرقاء داكنة رقيقة مطابقة](theme-style-initial.png) | ![المستطيل الأزرق السماوي الآن له حدود حمراء داكنة سميكة](theme-style-line-changed.png) | ![المستطيل الأيسر الآن أخضر وكلا الحدين لا يزالان دون تغيير](theme-style-fill-changed.png) |

اختيار نمط خط مختلف يغيّر حدود المستطيل الأيمن فقط. تعديل أول ملء موضوع يحدث تحديثًا لكل الأشكال التي تستخدمه. هنا، يتحول المستطيل الأيسر فقط إلى اللون الأخضر.

على شكل موجود، يمكن للون ملء محلي أو لون أو عرض خط محلي أن يتجاوز جزءًا من نمط الموضوع. إذا لم يُظهر تغيير فهرس النمط أي تأثير مرئي، افحص [التنسيق المباشر](/slides/ar/python-net/shape-formatting/) للشكل.

## **تحديد ما إذا كان ملء صلب فعّال يستخدم لون موضوع**

يمكن تخزين ملء إما مباشرة على كائن أو موروث من فقرة، تخطيط، ماستر، نمط موضوع، أو مستوى تنسيق آخر. استدعِ [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) لحل تلك الشجرة إلى كائن [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) غير قابل للتغيير. أولاً افحص [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). فقط عندما تكون `FillType.SOLID` ينبغي قراءة خصائص الملء الصلب.

للملء الصلب، تُعيد [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) قيمة RGB النهائية بعد تطبيق الوراثة، والبحث في الموضوع، وتحويلات اللون. تُعيد [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) الفتحة المنطقية من [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/)؛ مثل `TEXT1` أو `ACCENT6`. قيمة `SchemeColor.NOT_DEFINED` تعني أن الملء الصلب الفعّال ليس مستندًا إلى لون مخطط. في سير عمل يكون فيه الملء إما لون موضوع أو لون RGB مباشر، تُحدّد هذه القيمة ملء RGB مباشر.

لا تستخدم قيمة [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) المحلية وحدها لتصنيف ملء. على سبيل المثال، قد لا يحتوي جزء نص على لون مخطط معرف محليًا، لذا تكون قيمته المحلية `NOT_DEFINED`، في حين أن ملءه الفعّال قد يرث لون موضوع ويُحل إلى `TEXT1` أو `ACCENT6`. بالمقابل، تُخبرك `solid_fill_scheme_color` أي فتحة موضوع منطقية أنتجت اللون الفعّال، لكنها لا تُخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر من شجرة التنسيق.

المثال التالي يحمل عرضًا تقديميًا، يدقق كل ملء شكل وملء جزء نص، يطبع كل قيمة RGB نهائية واللون المخططي المرتبط، ويُعلّم الملء الصلب الذي لن يتتبع تغييرات ألوان الموضوع:

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

يوفر الفرع `NOT_DEFINED` قائمة تدقيق للملء الصلب الذي لن يستجيب لتغييرات فتحات ألوان الموضوع. راجع تلك الكائنات عندما يجب أن يتبع العرض التقديمي لوحة ألوان علامة تجارية جديدة. لا يزال قيمة RGB المُبلغ عنها تُظهر المظهر الحالي، بينما تفسّر قيمة المخطط ما إذا كان ذلك المظهر مرتبطًا بالموضوع.

كائنات الصيغة الفعّالة هي لقطات. بعد تغيير موضوع العرض، أو تجاوز موضوع، أو أي تنسيق موروث، استدعِ `get_effective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل مقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم الموضوع الفعّالة**

تخبرك كائنات الموضوع الخام بما هو مُعرّف على مستوى معين. تخبرك القيم الفعّالة بما يستخدمه شريحة أو شكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). للخلفية، استخدم [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/)، وللملء استخدم [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

المثال التالي يقرأ الموضوع الفعّال، الخلفية، والملء الأول للشكل من شريحة:

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

استخدم البيانات الفعّالة لتشخيصات التصيير، التحقق، والمقارنات. إذا فحصت فقط [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/)، قد تفوتك تجاوزات ماستر، تخطيط، شريحة، أو شكل تغير المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق موضوع خارجي على كل شريحة في العرض التقديمي؟**

لا. طريقة [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) تعيد تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بمواضيعها الحالية.

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) الخاص بالشريحة وابدأ تهيئة موضوع التجاوز الخاص بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة مواضيعها الحالية.

**ما هي الطريقة الأكثر أمانًا لحمل موضوع من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي، انسخ ماستر المصدر إلى الوجهة ثم انسخ الشريحة مع ذلك الماستر باستخدام [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) و[SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). سيحافظ ذلك على ماستر، تخطيطات، وموضوع معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) لموضوع شريحة أو تخطيط، واستخدم الأساليب المقابلة للبيانات الفعّالة لكائنات الصيغة مثل [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) و[FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
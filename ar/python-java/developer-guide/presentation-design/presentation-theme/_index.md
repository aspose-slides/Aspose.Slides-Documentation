---
title: إدارة أنماط العرض في Python عبر Java
linktitle: نمط العرض
type: docs
weight: 10
url: /ar/python-java/presentation-theme/
keywords:
- نمط PowerPoint
- نمط العرض
- نمط الشريحة
- تعيين النمط
- تغيير النمط
- إدارة النمط
- نمط خارجي
- THMX
- لون النمط
- لوحة ألوان إضافية
- خط النمط
- نمط النمط
- تأثير النمط
- PowerPoint
- OpenDocument
- عرض
- Python
- Java
- Aspose.Slides
description: "إتقان أنماط العرض في Aspose.Slides للغة Python عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
## **المقدمة**

يحدد نمط العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والتعبئات والخطوط والتأثيرات. تشير الكائنات المستندة إلى النمط إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذلك يمكن لتغيير النمط تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، يمكن الوصول إلى نمط العرض على مستوى العرض عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasterTheme). يمكن للعرض أيضاً أن يحتوي على تجاوزات للنمط على مستويات أدنى. يمكن للماستر أن يتجاوز نمط العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterthememanager/#getOverrideTheme)، بينما يمكن للتخطيط أو الشريحة الفردية أن يتجاوزان نمطهما الموروث عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). عمليًا، يتم حل النمط الفعلي لشرائح عبر سلسلة الوراثة هذه: نمط العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات النمط: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل شائع للنمط: فحص النمط، تغيير الألوان والخطوط، نسخ أو تطبيق نمط، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعالة بعد حل الوراثة والتجاوزات.

## **فحص النمط**

كائن [MasterTheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mastertheme/) يعرض مخطط ألوان النمط، ومخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mastertheme/#getColorScheme)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mastertheme/#getFontScheme)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mastertheme/#getFormatScheme). فحص هذه التجميعات قبل تعديلها مفيد خاصة عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مداخل الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للنمط ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في النمط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس النمط الفعلي. افحص الماستر المرتبط بالشرائح، واستخدم سير عمل النمط الفعلي الموضح لاحقًا في هذه المقالة عندما تكون هناك تجاوزات على مستوى التخطيط أو الشريحة.

## **تغيير ألوان النمط**

التعبئات، الخطوط، والنص المستند إلى النمط يمكن أن يشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/colorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون النمطي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تُغيّر بتحديث لون النمط.

المثال التالي يخلق شكلًا يستخدم `Accent4`، يغيّر لون `Accent4` في النمط إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون التعبئة الفعلي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

لأن المستطيل ما زال مرتبطًا بـ `Accent4`، يصبح لونه الظاهري أحمر بعد تغيير النمط. إذا استبدلت اللون المنطقي بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

PowerPoint يستخلص متغيرات أفتح وأغمق من لون النمط بتطبيق تحويلات لونية. Aspose.Slides ي expose هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للنمط والألوان الأفتح والأغمق المُنشأة من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان النمط الرئيسية.

**2** - المتغيرات الأفتح والأغمق المُنتجة من ألوان النمط الرئيسية.

المثال التالي يخلق ستة مستطيلات مبنية على `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هذه المتغيرات ما زالت مستندة إلى لون النمط. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المُتحولة استنادًا إلى القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما ي expose [ColorScheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/colorscheme/) نفس الفتحات كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الترابط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات النمط؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط النمط**

مخطط خطوط النمط يحتوي على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. طُرق [FontScheme.getMajor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontscheme/#getMajor) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontscheme/#getMinor) تكشف عن تلك المجموعات.

معرفات خطوط النمط المتوافقة مع PowerPoint يمكن استخدامها في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)

المثال التالي يخلق عنوانًا يستخدم الخط اللاتيني الرئيسي وخطًا أساسيًا يستخدم الخط اللاتيني الفرعي. ثم يغيّر خطوط النمط ويحفظ النتيجة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف نمط لن يتحول تلقائيًا عند تغيير مخطط خطوط النمط.

المجموعتان الرئيسيتان والفرعيتان يمكن أن تحتويان أيضًا على تعيينات خطوط للأنظمة الكتابية الفردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثانا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، راجع [خطوط النمط الخاصة بالسكريبت](/slides/ar/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/python-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق نمط**

تُحل المشكلات المختلفة المتعلقة بالنمط عبر سير عمل أدناه.

### **تطبيق نمط خارجي على الشرائح التابعة للماستر**

استخدم [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) عندما يكون لديك ملف نمط PowerPoint (`.thmx`) وتريد إعادة تصميم كل شريحة تعتمد على ماستر معين. اختر الماستر من تجميع [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters) المُمَثَّل بـ [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف النمط إلى الطريقة.

تقوم الطريقة بالعمليات التالية:

1. تنشئ شريحة ماستر جديدة بناءً على الماستر المختار.
1. تطبق النمط الخارجي على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الماستر المختار.
1. تُعيد كائن [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/) الجديد.

المثال التالي يطبق نمطًا خارجيًا على الشرائح التي تعتمد على الماستر الأول ويحفظ العرض:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النمط غير الصالح أو الفاسد أو غير المدعوم قد يسبب [PptxReadException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يُدخلها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق النمط بنجاح.

فقط الشرائح التي اعتمدت على الماستر المختار تُعاد تعيينها. الشرائح المرتبطة بماسترات أخرى تحتفظ بالماسترات والنمات الحالية. الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات المستندة إلى النمط تُحل بالنسبة للنمط الخارجي. التنسيقات المخصصة قد تظل دون تغيير. تجاوزات مستوى التخطيط أو الشريحة قد تتفوق أيضًا على القيم الموروثة من الماستر الجديد.

قد يشير النمط إلى خطوط غير متوفرة في بيئة التنفيذ. لضمان العرض والتصدير المتسق، ثبّت الخطوط المطلوبة، أو وفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/python-java/custom-font/)، أو اضبط [بدائل الخطوط](/slides/ar/python-java/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: الطريقة تقبل مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات نمطية يدوية على مستوى الشريحة أو التخطيط.

### **تطبيق نمط خارجي مختلف في عرض متعدد الماسترات**

عندما لا يكون الماستر المناسب معروفًا مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getLayoutSlide) و[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getMasterSlide). احفظ مراجع الماسترات الأصلية قبل تطبيق أي نمط لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويطبق نمطًا خارجيًا مختلفًا على كل مجموعة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النداء الأول يؤثر فقط على الشرائح التي تعتمد على `first_group_master`، والنداء الثاني يؤثر فقط على الشرائح التي تعتمد على `second_group_master`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تصميمها.

### **الحفاظ على نمط المصدر عند نقل الشرائح**

إذا رغبت بنقل شريحة إلى عرض آخر مع الحفاظ على التصميم الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#addClone)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) والماستر المستنسخ. هذا يحمل الماستر وتخطيطاته والنمط المرتبط به معًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

هذا هو سير العمل المفضَّل عندما يجب أن تبدوا الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى إلى ماستر وجهة غير ذي صلة قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالنمط.

### **تطبيق قيم النمط على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على ماسترها وتخطيطها الحالي، ابدأ تجاوزًا على مستوى الشريحة من النمط الأصلي. طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/overridetheme/#initFontSchemeFrom)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) تنسخ المكونات الثلاثة الرئيسية للنمط إلى التجاوز.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

هذا يغيّر النمط المستخدم لتلك الشريحة دون تغيير النمط الموروث للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/overridetheme/#clear).

### **تطبيق تجاوز نمط على تخطيط**

تجاوز على مستوى التخطيط يُطبَّق على الشرائح التي تستخدم ذلك التخطيط، ما لم يكن للشفرة شريحة معينة تجاوزها الخاص. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

استخدم نمط ماستر أو عرض عندما تحتاج العديد من التخطيطات والشرائح إلى مشاركة نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة لتصميم مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. كثرة التجاوزات على مستوى الشريحة تجعل التغييرات العالمية للنمط لاحقًا أصعب في التنبؤ.

## **تحديث أنماط خلفية النمط**

تُخزن تعبئات خلفية النمط في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات التعبئة الفعلية المخزنة في هذا التجميع لأن الواجهة يمكنها دمج تعبئات النمط مع ألوان النمط ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لنمط عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص التجميع المخزن و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/background/#getStyleIndex) الحالي. قيمة الفهرس `0` تعني عدم وجود تعبئة نمطية؛ القيم الموجبة تشير إلى مراجع أنماط خلفية نمطية. هذا يختلف عن فهرسة التجميع مباشرة حيث `get_Item(0)` يعني العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية نمطي للماستر الأول، ويحفظ العرض:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة الظاهرة تعتمد على مدخل النمط الذي يشير إليه الماستر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت شريحة ما تستخدم خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/background/#getEffective) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تتعامل مع فهرس النمط كفهرس تجميع يبدأ من الصفر. كما تجنب ترميز رقم نمط من ملف واحد والافتراض بأنه سيظهر بالمظهر نفسه في ملف آخر؛ تعريفات نمط العرض خاصة بالعرض نفسه.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية، راجع [خلفية العرض](/slides/ar/python-java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات النمط**

مخطط تنسيق النمط يحتوي على تجميعات منفصلة للتعبئة، الخط، وتأثيرات النمط تُعرض عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/python-java/aspose.slides/formatscheme/#getFillStyles)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/python-java/aspose.slides/formatscheme/#getLineStyles)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/python-java/aspose.slides/formatscheme/#getEffectStyles). عادةً ما تحتوي الأنماط المكتبية على ثلاث مدخلات رئيسية تمثل بصريًا تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الشيفرة فحص كل تجميع بدلاً من الافتراض بوجود عدد ثابت.

![تأثيرات نمطية خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه التجميعات في Python عبر Java، يكون فهرس التجميع يبدأ من الصفر: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. فهارس مراجع النمط للشكل هي مفهوم منفصل، تُعرض عبر [ShapeStyle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapestyle/). تعديل نمط نمطي يؤثر على الأشكال التي تشير إلى ذلك النمط؛ الأشكال التي لديها تنسيق مباشر قد تبقى دون تغيير.

المثال التالي يتحقق من وجود مداخل النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط نمطي أحمر، وثالث نمط تعبئة يصبح أخضر غابات صلب، والثالث تأثير يكتسب ظلًا خارجيًا بمقدار 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز النمط.

![أنماط تأثير النمط بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **تحديد ما إذا كانت تعبئة صلبة فعّالة تستخدم لون نمط**

يمكن تخزين التعبئة مباشرة على كائن أو وراثتها من فقرة، تخطيط، ماستر، نمط، أو مستوى تنسيق آخر. استدعِ [FillFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getEffective) لحل تلك السلسلة إلى بيانات تعبئة صلبة غير قابلة للتغيير. أولًا افحص `getFillType` على كائن البيانات الفعّالة. فقط عندما يكون `FillType.Solid` يجب قراءة خصائص التعبئة الصلبة.

لل تعبئة صلبة، `getSolidFillColor` تُعيد القيمة النهائية لـ RGB بعد تطبيق الوراثة، بحث النمط، وتحويلات اللون. `getSolidFillSchemeColor` تُعيد الفتحة المنطقية لـ [SchemeColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/schemecolor/) المقابلة، مثل `Text1` أو `Accent6`. القيمة `SchemeColor.NotDefined` تعني أن التعبئة الصلبة الفعّالة ليست مبنية على لون مخطط. في سير عمل حيث تكون التعبئات إما ألوان نمطية أو ألوان RGB مباشرة، تُحدد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/colorformat/#getSchemeColor) المحلية وحدها لتصنيف التعبئة. على سبيل المثال، قد لا يحتوي مقطع نصي على لون مخطط معرف محليًا، وبالتالي تكون قيمته المحلية `NotDefined`، بينما تعبئته الفعّالة ترث لون نمط وتُحل إلى `Text1` أو `Accent6`. بالمقابل، `getSolidFillSchemeColor` تُظهر لك أي فتحة نمطية منطقية أنتجت اللون الفعّال، لكنها لا تُظهر ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى تنسيق آخر.

المثال التالي يحمل عرضًا، يدقق كل تعبئات الأشكال وتعبئات أجزاء النص، يطبع كل قيمة RGB نهائية واللون المخطّط المرتبط، ويُحدد التعبئات الصلبة التي لن تتتبع تغييرات ألوان النمط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

الفرع `NotDefined` يُوفر قائمة تدقيق للتعبئات الصلبة التي لن تستجيب لتغيّر فتحات لون النمط. راجع هذه الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا تزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما يوضح قيمة المخطط ما إذا كان هذا المظهر مرتبطًا بالنمط.

كائنات الصيغة الفعّالة هي لقطات. بعد تغيير نمط العرض، أو تجاوز نمط، أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ كائن تعبئة فعّال جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم النمط الفعّالة**

الكائنات النمطية الخام تُظهر ما تم تعريفه في مستوى معين. القيم الفعّالة تُظهر ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/background/#getEffective)، وللتعبئة استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getEffective).

المثال التالي يقرأ النمط الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

استخدم البيانات الفعّالة للتشخيص والرصد والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasterTheme)، قد تفوتك تجاوزات ماستر، تخطيط، شريحة، أو شكل تُغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل تطبيق نمط خارجي يؤثر على كل شريحة في العرض؟**

لا. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) يعيد تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بأنماطها الحالية.

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidethememanager/) للشفرة وابدأ بنظام تجاوز النمط الخاص بها. التغيير يبقى محليًا لتلك الشريحة؛ الشرائح الأخرى تظل ترث أنماطها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل نمط من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة ثم استنسخ الشريحة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#addClone) و[SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone). هذا يحافظ على الماستر، التخطيطات، والنمط معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) لنمط شريحة أو تخطيط، والطُرق المقابلة للبيانات الفعّالة للكائنات التنسيقية مثل [Background.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/background/#getEffective) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getEffective). تُعيد هذه الواجهات القيم المُحلَّة بعد تطبيق الوراثة والتجاوزات.
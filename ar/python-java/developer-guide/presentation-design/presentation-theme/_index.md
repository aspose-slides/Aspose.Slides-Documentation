---
title: إدارة أنماط العروض التقديمية في بايثون عبر جافا
linktitle: نمط العرض التقديمي
type: docs
weight: 10
url: /ar/python-java/presentation-theme/
keywords:
- نمط PowerPoint
- نمط العرض التقديمي
- نمط الشريحة
- تعيين النمط
- تغيير النمط
- إدارة النمط
- نمط خارجي
- THMX
- لون النمط
- لوحة ألوان إضافية
- خط النمط
- نمط التصميم
- تأثير النمط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحكم في أنماط العروض التقديمية في Aspose.Slides لبايثون عبر جافا لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **المقدمة**

يُعرّف نمط العرض مجموعة مُنسَّقة من الألوان والخطوط وأنماط الخلفية والتعبئات والخطوط والتأثيرات. تُشير الكائنات التي تدعم النمط إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيّر النمط أن يُحدِّث الكثير من الكائنات دفعة واحدة.

في Aspose.Slides، النمط على مستوى العرض متاح عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme). يمكن للعرض أيضًا أن يحتوي على تجاوزات للنمط في مستويات أدنى. يمكن للماستر تجاوز نمط العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme)، بينما يمكن لتخطيط أو لشريحة فردية تجاوز النمط الموروث عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). عمليًا، يتم حل النمط الفعّال لشريحة من خلال سلسلة الوراثة هذه: نمط العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

مكونات الصورة: "مكونات النمط: الألوان والخطوط وأنماط الخلفية والتأثيرات"

تُظهر الأقسام أدناه أكثر سير عمل شائع للنمط: فحص النمط، تغيير الألوان والخطوط، نسخ أو تطبيق نمط، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص النمط**

كائن [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) يعرض مخطط ألوان النمط، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme). يُعتبر فحص هذه المجموعات قبل تعديلها مفيدًا بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط يمكن أن يختلف.

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

إذا كان الملف يستخدم متعددة ماسترات، لا تفترض أن كل شريحة لديها نفس النمط الفعّال. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل النمط الفعّال الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان النمط**

التعبئات، الخطوط، والنصوص التي تدعم النمط يمكنها الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/). عندما تقوم بتغيير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/)، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون النمطي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغيّر بتحديث لون النمط.

المثال الشامل التالي يُنشئ شكلًا يستخدم `Accent4`، يغيّر لون `Accent4` في النمط إلى الأحمر، يحفظ العرض، يفتحه مرة أخرى، ويطبع لون التعبئة الفعّال:

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

لأن المستطيل يظل مرتبطًا بـ`Accent4`، يصبح لونه الظاهر أحمر بعد تغيير النمط. إذا استبدلت اللون المنطقي بلون مباشر على الشكل، فإن التغييرات المستقبلية على `Accent4` لن تؤثر على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

يستخلص PowerPoint متغيرات أفتح وأغمق من لون النمط عبر تطبيق تحولات الألوان. Aspose.Slides ي expose هذه التحولات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - ألوان النمط الرئيسية.

**2** - المتغيرات الأفتح والأغمق المُنتجة من ألوان النمط الرئيسية.

المثال التالي يُنشئ ستة مستطيلات مبنية على `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتغيرات مبنية على لون النمط. إذا تغيّر `Accent4` لاحقًا، تُعاد حساب الألوان المُحوّلة من القيمة الجديدة لـ`Accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) نفس فتحات النمط كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. القاعدة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات النمط؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط النمط**

مخطط خطوط النمط يحتوي على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. طريقتا [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) و[FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) تُظهران هاتين المجموعتين.

معرفات خطوط النمط المتوافقة مع PowerPoint يمكن استخدامها في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)
* `+mn-cs` - خط النص الأساسي للخطوط المركبة (Minor Complex Script Font)
* `+mj-cs` - خط العنوان للخطوط المركبة (Major Complex Script Font)

المثال التالي يُنشئ عنوانًا يستخدم خط النمط اللاتيني الرئيسي وخطًا أساسيًا يستخدم خط النمط اللاتيني الفرعي. ثم يغيّر خطوط النمط ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف نمط لن يتبدل تلقائيًا عندما يتغير مخطط خطوط النمط.

يمكن لمجموعات الخطوط الرئيسة والفرعية أيضًا أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السريلية، العربية، اليابانية، الجورجية، والثانا. لاستعراض، إضافة، استبدال أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}

لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/python-java/powerpoint-fonts/).

{{% /alert %}}

### **حل مراجع خطوط النمط**

عند فحص النص، يمكن لـ[FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) أن تُعيد مرجع نمط مثل `+mn-lt` بدلاً من اسم عائلة الخط. استدعِ [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) مع بيانات النمط الفعّال المناسبة لحل هذا المرجع. البادئات `+mj` و`+mn` تختار مجموعات الخطوط الرئيسية والفرعية؛ واللواحق `-lt`، `-ea`، و`-cs` تختار خطوطها اللاتينية، الآسيوية الشرقية، والسكريبت المركبة على التوالي.

احصل على النمط الفعّال عبر [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) على مدير النمط للكائن الذي يُطبق نمطه على النص المفحوص. للنص العادي على شريحة، استخدم مدير نمط الشريحة بحيث يشمل السياق النمط الموروث لتلك الشريحة وتجاوزاتها المحلية. عند فحص تخطيط أو ماستر نفسه، استخدم نمطه الفعّال الخاص. لا تفترض أن نمط أول ماستر يطبق على كل شريحة.

المثال التالي يُنشئ جزء نص يُشير صراحةً إلى الخط اللاتيني الفرعي. يُنشئ مخطط خطوط شريحة عبر [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) ويضبط عائلات اللاتينية الرئيسة والفرعية إلى `Arial` و`Calibri`، مما يجعل النتيجة قابلة لإعادة الإنتاج دون ملف إدخال.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

الناتج هو `+mn-lt -> Calibri` متبوعًا بـ `Verdana -> Verdana`. يبقى المرجع المخزن دون تغيير، بينما يُعاد إرجاع اسم العائلة الصريح كما هو. إذا كان الجزء يستخدم `+mj-lt`، فسيُحل إلى `Arial` في هذا النمط.

حل مرجع النمط يحدد عائلة الخط المحددة بواسطة النمط. لا يتحقق من توافر الخط أو يحدد ملف الخط الذي يُستَخدم في النهاية بعد الاستبدال أو fallback أثناء التصيير. راجع [Font Selection Sequence](/slides/ar/python-java/font-selection-sequence/) و[Font Substitution](/slides/ar/python-java/font-substitution/) لتلك الخطوات المنفصلة.

## **نسخ أو تطبيق نمط**

تُحَلُّ سير العمل أدناه مشكلات مختلفة متعلقة بالنمط.

### **تطبيق نمط خارجي على الشرائح التابعة لماسْتر**

استخدم [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) عندما يكون لديك ملف نمط PowerPoint (`.thmx`) وتريد إعادة تصميم كل شريحة تعتمد على ماستَر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) الممثلة بـ[MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف النمط إلى الطريقة.

تقوم الطريقة بالعمليات التالية:

1. تنشئ شريحة ماستَر جديدة بالاعتماد على الماستر المحدد.
1. تطبق النمط الخارجي على الماستر الجديد.
1. تُعيّن الماستر الجديد لكل الشرائح التي كانت تعتمد مسبقًا على الماستر المحدد.
1. تُعيد كائن [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) المُنشأ حديثًا.

المثال التالي يطبق نمطًا خارجيًا على الشرائح التي تعتمد على أول ماستَر ويحفظ العرض:

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

نمط غير صالح، أو فاسد، أو غير مدعوم قد يسبب [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/). قم بالتحقق من المسارات التي يُدخلها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد أن يُطبق النمط بنجاح.

فقط الشرائح التي كانت تعتمد على الماستر المحدد تُعاد تعيينها. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها ونماطها الحالية. الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات المدركة للنمط تُحل مقابل النمط الخارجي. قد تظل الألوان، الخطوط، التعبئات، وغيرها من التنسيقات الصريحة دون تغيير. يمكن لتجاوزات على مستوى التخطيط أو الشريحة أيضًا أن تتفوق على القيم الموروثة من الماستر الجديد.

قد يشير النمط إلى خطوط غير متوفرة في بيئة التنفيذ. للحصول على تصيير وتصدير متسق، ثبّت الخطوط المطلوبة، وفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/python-java/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/python-java/font-substitution/).

هذا سير عمل على مستوى ماستَر مباشرة: الطريقة تقبل مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات نمط على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق أنماط خارجية مختلفة في عرض متعدد ماسترات**

عند عدم معرفة الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) و[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). احفظ مراجع الماسترات الأصلية قبل تطبيق أي نمط لأن كل استدعاء يُنشئ ماستَرًا آخر في العرض.

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

النداء الأول يؤثر فقط على الشرائح التي كانت تعتمد على `first_group_master`، والنداء الثاني يؤثر فقط على الشرائح التي كانت تعتمد على `second_group_master`. الشرائح التابعة لأي ماستَر آخر لا تُعيد تصميمها.

### **الحفاظ على نمط المصدر عند نقل الشرائح**

إذا كنت تريد نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ ماستَر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) والماستَر المستنسخ. هذا ينقل الماستر، تخطيطاته، والنمط المرتبط به معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. استنساخ المحتوى فقط على ماستَر هدف غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالنمط.

### **تطبيق قيم النمط على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على ماستَرها وتخطيطها الحالي، ابدأ تجاوزًا على مستوى الشريحة من النمط المصدر. الطُرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) تنسخ المكونات الثلاثة الرئيسية للنمط إلى التجاوز.

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

هذا يغيّر النمط المستخدم لتلك الشريحة دون تغيير النمط الموروث للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear).

### **تطبيق تجاوز نمط لتخطيط**

تجاوز على مستوى التخطيط يُطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تُحدد شريحة معينة تجاوزًا خاصًا بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/):

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

استخدم نمط ماستَر أو مستوى العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجاوزات متعددة على مستوى الشريحة تجعل تغييرات النمط العالمية اللاحقة أصعب في التنبؤ.

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*A layout override applies to slides using that layout unless a slide supplies its own override. Theme-based values follow their resolved scheme; explicitly formatted objects can retain their local appearance. Keep overrides as narrow as the intended design exception.*
<!-- visual-explanation:presentation-theme:end -->

## **تحديث أنماط خلفية النمط**

تُخزن تعبئات خلفية النمط في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). يمكن لـPowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات النمط مع ألوان النمط ومراجع أنماط أخرى.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل استخدام نمط الخلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex) الحالي. قيمة الفهرس `0` تعني عدم وجود تعبئة نمطية؛ القيم الإيجابية تشير إلى مراجع أنماط خلفية نمطية. هذا يختلف عن فهرسة المجموعة مباشرةً، حيث `get_Item(0)` يعني العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يُعيّن مرجع خلفية نمطية للماستَر الأول، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على إدخال النمط المُشار إليه من قبل الماستَر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستَر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}

لا تُعامل فهرس النمط كفهرس مجموعة يبدأ من الصفر. كما يجب تجنّب ترقيم ثابت لرقم نمط من ملف واحد والافتراض أنه سيظهر نفس الشكل في ملف آخر؛ تعريفات نمط النمط خاصة بالعرض.

{{% /alert %}}

{{% alert color="success" title="Tip" %}}

للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/python-java/presentation-background/).

{{% /alert %}}

## **تحديث تأثيرات النمط**

يحتوي مخطط تنسيق النمط على مجموعات منفصلة من تعبئات الخط، الخطوط، وتأثيرات الأنماط التي تُظهر عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles). غالبًا ما تحتوي الأنماط المكتبية على ثلاثة إدخالات أساسية تُطابق بصريًا تنسيقات دقيقة، معتدلة، ومشددة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Python عبر Java، يكون فهرس المجموعة يبدأ من الصفر: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. فهرس مراجع نمط الشكل هو مفهوم منفصل، يُظهره [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/). تعديل نمط النمط يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود إدخالات النمط المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط التعبئة الثالث، يُفعِّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تشير إلى هذه الفتحات، يصبح نمط الخط النمطي الأول أحمر، ونمط التعبئة النمطي الثالث أخضر غابوي صلب، ونمط التأثير الثالث يضيف ظلًا خارجيًا بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز النمط.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **اختيار تعبئة الخطوط والحدود النمطية لشكل**

يمكن للشكل اختيار تعبئته وحدوده بشكل مستقل عبر [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) و[ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex). بالنسبة لكل طريقة، الفهرس `1` يختار الإدخال الأول في مجموعة النمط المقابلة (`get_Item(0)`)، والفهرس `2` يختار الثاني (`get_Item(1)`).

المثال التالي يُعدّ نمطين تعبئة (ذهب وأزرق سماوي) ونمطين حد (أزرق داكن بسمك 6 نقطة وأحمر داكن بسمك 12 نقطة) في النمط الافتراضي لعرض جديد. يحفظ الشريحة في ثلاث مراحل لتتمكن من مقارنة النتائج في PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| الأنماط الأولية | تغيير الحد الأيمن | تعديل أول تعبئة نمطية |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

اختيار نمط حد مختلف يغيّر فقط حد المستطيل الأيمن. تعديل أول تعبئة نمطية يُحدّث كل شكل يستخدمها. هنا، يتحول المستطيل الأيسر فقط إلى اللون الأخضر.

على شكل موجود، يمكن للون تعبئة محلي أو لون حد أو سمك حد محلي أن يتجاوز ذلك الجزء من نمط النمط. إذا لم يُظهر تغيير فهرس النمط تأثيرًا مرئيًا، تحقق من [التنسيق المباشر](/slides/ar/python-java/shape-formatting/) للشكل.

## **تحديد ما إذا كان التعبئة الصلبة الفعّالة تستخدم لون نمط**

يمكن أن تُخزن التعبئة مباشرةً على كائن أو موروثة من فقرة أو تخطيط أو ماستَر أو نمط أو مستوى تنسيق آخر. استدعِ [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) لتسوية تلك الهرمية إلى بيانات تعبئة صلبة غير قابلة للتغيير. أولًا تحقق من `getFillType` على كائن البيانات الفعّالة. فقط عندما تكون `FillType.Solid` يجب قراءة خصائص التعبئة الصلبة.

للتعبئة الصلبة، تُعيد `getSolidFillColor` القيمة النهائية RGB بعد الوراثة، بحث النمط، وتطبيق تحويلات الألوان. تُعيد `getSolidFillSchemeColor` الفتحة المنطقية في [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) مثل `Text1` أو `Accent6`. قيمة `SchemeColor.NotDefined` تعني أن التعبئة الصلبة الفعّالة غير مبنية على لون مخطط. في سير عمل حيث تكون التعبئات إما ألوان نمط أو ألوان RGB مباشرة، تحدد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) المحلية وحدها لتصنيف تعبئة. على سبيل المثال، قد لا يكون لجزء نص لون مخطط معرف محليًا، لذا تكون قيمته المحلية `NotDefined`، بينما تعبئته الفعّالة موروثة من نمط وتُحل إلى `Text1` أو `Accent6`. بالعكس، `getSolidFillSchemeColor` يخبرك أي فتحة نمط منطقية أنتجت اللون الفعّال، لكنه لا يحدد ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر أو مستوى آخر من الهرمية.

المثال التالي يحمل عرضًا، يراجِع تعبئات الأشكال وتعبئات أجزاء النص، يطبع كل قيمة RGB نهائية والفتحة المخططة المرتبطة، ويُعلم عن التعبئات الصلبة التي لن تتعقب تغيّر ألوان النمط:

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

فرع `NotDefined` يُوفر قائمة تدقيق للتعبئات الصلبة التي لن تستجيب لتغيّر فتحات ألوان النمط. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة علامات تجارية جديدة. ما زالت قيمة RGB المبلغة تُظهر المظهر الحالي، بينما تشرح قيمة الفتحة ما إذا كان هذا المظهر مرتبطًا بالنمط.

كائنات التنسيق الفعّال هي لقطات. بعد تغيير نمط العرض، أو تجاوز نمط، أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ كائن تعبئة فعّال جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم النمط الفعّالة**

كائنات النمط الخام تُخبرك بما هو معرف عند مستوى معين. القيم الفعّالة تُخبرك بما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective)، وللتعبئة، استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

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

استخدم البيانات الفعّالة لتشخيصات التصيير، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme)، قد تفوتك تجاوزات ماستَر أو تخطيط أو شريحة أو شكل تغير المظهر النهائي.

## **الأسئلة المتكررة**

**هل تطبيق نمط خارجي يؤثر على كل شريحة في العرض؟**

لا. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) يعيد تعيين فقط الشرائح التي تعتمد على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بالنماذج الحالية.

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) للشريحة وابدأ نمط التجاوز الخاص بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة نمطها الحالي.

**ما هي الطريقة الأكثر أمانًا لنقل نمط من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ ماستَر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) و[SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). هذا يحافظ على الماستر، التخطيطات، والنمط معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) لنمط شريحة أو تخطيط، والطرق المكافئة للبيانات الفعّالة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) و[FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). تُعيد هذه الواجهات القيم المُحلَّة بعد تطبيق الوراثة والتجاوزات.
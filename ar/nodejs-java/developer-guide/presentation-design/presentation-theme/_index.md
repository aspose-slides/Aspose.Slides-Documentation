---
title: إدارة أنماط العرض في JavaScript
linktitle: نمط العرض
type: docs
weight: 10
url: /ar/nodejs-java/presentation-theme/
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
- نمط التصميم
- تأثير النمط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحكم الكامل في أنماط العرض في JavaScript باستخدام Aspose.Slides لـ Node.js لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية متسقة."
---
## **مقدمة**

يحدد نمط العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تُشير الكائنات المدركة للنمط إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية مرئية كقيمة ثابتة، لذا يمكن لتغيير النمط تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، يتوفر نمط العرض على مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/). يمكن للعرض أيضًا أن يحتوي على تجاوزات للنمط في مستويات أدنى. يمكن للماستر تجاوز نمط العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية تجاوز النمط الموروث عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). عمليًا، يُستخلص النمط الفعّال لشريحة ما من خلال سلسلة الوراثة هذه: نمط العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات النمط: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تظهر الأقسام أدناه أكثر سير عمل شائع للنمط: فحص النمط، تغيير الألوان والخطوط، نسخ أو تطبيق نمط، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص نمط**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) مخطط ألوان النمط، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/). يُعتبر فحص هذه المجموعات قبل تعديلها مفيدًا بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات النمط قد يختلف.

المثال التالي يقرأ خصائص النمط الرئيسية ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في النمط:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لديها نفس النمط الفعّال. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل النمط الفعّال الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان النمط**

يمكن للتعبئات، الخطوط، والنصوص المدركة للنمط الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/)، يتم حل جميع الكائنات التي لا تزال تُشير إلى ذلك اللون النمطي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تُغيّر بتحديث لون النمط.

المثال التالي الشامل ينشئ شكلًا يستخدم `Accent4`، yغيّر لون `Accent4` في النمط إلى الأحمر، يحفظ العرض، يفتحّه مرة أخرى، ويطبع لون التعبئة الفعّال:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);

    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

نظرًا لأن المستطيل يبقى مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير النمط. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على ذلك التعبئة.

### **استخدام ألوان من لوحة الألوان الإضافية**

يستخرج PowerPoint متغيرات أخف وأغمق من لون النمط عبر تطبيق تحويلات اللون. تُظهر Aspose.Slides هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للنمط والألوان الأخف والأغمق المُنشأة من لوحة الألوان الإضافية](additional-palette-colors.png)

**1** - ألوان النمط الرئيسية.

**2** - المتغيرات الأخف والأغمق المُنتجة من ألوان النمط الرئيسية.

المثال التالي يُنشئ ستة مستطيلات تستند إلى `Accent4`، يطبّق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذه المتغيرات لا تزال معتمدة على لون النمط. إذا تغيّر `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بخانات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر تعداد [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) نفس خانات النمط كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس خانات النمط؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط النمط**

يتضمن مخطط خطوط النمط مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تُظهر طُرق [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) تلك المجموعات.

يمكن استخدام معرّفات خطوط النمط المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - الخط الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - الخط الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)
* `+mn-cs` - الخط الأساسي للخط المعقّد (Minor Complex Script Font)
* `+mj-cs` - خط العنوان للخط المعقّد (Major Complex Script Font)

المثال التالي يُنشئ عنوانًا يستخدم خط النمط اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط النمط اللاتيني الفرعي. ثم يغيّر خطوط النمط ويحفظ النتيجة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));

    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف نمط لن يتغيّر تلقائيًا عندما يتغيّر مخطط خطوط النمط.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والفرعية أيضًا على تعيينات خطوط للأنظمة الكتابية الفردية، مثل السيريالية، العربية، اليابانية، الجورجية، والتهانية. لفحص هذه التعيينات أو إضافتها أو استبدالها أو إزالتها، راجع [Script-Specific Theme Fonts](/slides/ar/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}

لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

### **حل مراجع خطوط النمط**

عند فحص النص، يمكن لـ [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) إرجاع مرجع نمط مثل `+mn-lt` بدلاً من اسم عائلة الخط. استدعِ [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) مع النمط الفعّال المناسب لحل ذلك المرجع. تمهيدات `+mj` و`+mn` تُحدد مجموعات الخطوط الرئيسية والفرعية؛ واللاحقات `-lt`، `-ea`، و`-cs` تُحدد خطوط اللاتيني، الآسيوي الشرقي، والخط المعقّد على التوالي.

احصل على النمط الفعّال عبر [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) على الكائن الذي ينطبق عليه النمط للفحص. بالنسبة للنص العادي على شريحة، استدعِ هذه الطَّرِقة على الشريحة بحيث يتضمن السياق النمط الموروث لتلك الشريحة والتجاوزات المحلية. عند فحص تخطيط أو ماستر نفسه، استخدم النمط الفعّال الخاص به. لا تفترض أن نمط أول ماستر ينطبق على كل الشريحة.

المثال التالي يُنشئ جزء نصٍ يُشير صراحة إلى الخط اللاتيني الفرعي. يتهيئ مخطط خطوط الشريحة عبر [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) ويُعيّن عائلات اللاتيني الرئيسية والفرعية إلى `Arial` و`Calibri`، لجعل النتيجة قابلة لإعادة الإنتاج دون ملف إدخال.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

الإخراج هو `+mn-lt -> Calibri` يليه `Verdana -> Verdana`. يظل المرجع المخزن غير متغيّر، بينما يُعاد إرجاع اسم العائلة الصريح كما هو. إذا كان الجزء يستخدم `+mj-lt`، لكان سيُحل إلى `Arial` في هذا النمط.

تحديد مرجع النمط يعرّف عائلة الخط المحددة بواسطة النمط. لا يتحقّق من توفر الخط أو يحدد ملف الخط الفعلي المستخدم بعد الاستبدال أو fallback الحروف أثناء العرض. راجع [Font Selection Sequence](/slides/ar/nodejs-java/font-selection-sequence/) و[Font Substitution](/slides/ar/nodejs-java/font-substitution/) لتلك الخطوات المنفصلة.

## **نسخ أو تطبيق نمط**

تحل سير عمل الأسفل مشكلات مختلفة متعلقة بالنمط.

### **تطبيق نمط خارجي على الشرائح التابعة للماستر**

استخدم [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) عندما يكون لديك ملف نمط PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) التي يُمثِّلها [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف النمط إلى الطريقة.

تُجري الطريقة العمليات التالية:

1. تنشئ شريحة ماستر جديدة استنادًا إلى الماستر المُحدد.
1. تُطبّق النمط الخارجي على الماستر الجديد.
1. تُعيّن الماستر الجديد إلى جميع الشرائح التي كانت تعتمد مسبقًا على الماستر المُختار.
1. تُعيد كائن [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) الجديد.

المثال التالي يُطبق نمطًا خارجيًا على الشرائح التي تعتمد على أول ماستر ويحفظ العرض:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قد يتسبب النمط غير الصالح، أو المُفسَّد، أو غير المدعوم في رفع استثناء [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/). تحقّق من صحة المسارات التي يُدخلها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق النمط بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المختار فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها ونماطها الحالية. تُحل الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات المدركة للنمط مقابل النمط الخارجي. قد تظل الألوان، الخطوط، التعبئات، وغيرها من التنسيقات الصريحة غير متغيّرة. يمكن لتجاوزات المستوى التخطيطي أو مستوى الشريحة أن تتفوّق أيضًا على القيم الموروثة من الماستر الجديد.

قد يُشير النمط إلى خطوط غير متوفرة في بيئة التشغيل. لضمان عرض وتصدير متسقين، قم بتثبيت الخطوط المطلوبة، وفّرها عبر [مصادر الخطوط المخصَّصة](/slides/ar/nodejs-java/custom-font/)، أو عيّن [استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تحتاج إلى إنشاء تجاوزات نمط على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق أنماط خارجية مختلفة في عرض متعدد الماستر**

عند عدم معرفة الماستر ذي الصلة مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) و[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي نمط لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويطبق نمطًا خارجيًا مختلفًا على كل مجموعة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

النداء الأول يؤثّر فقط على الشرائح التي كانت تعتمد على `firstGroupMaster`، والنداء الثاني يؤثّر فقط على الشرائح التي كانت تعتمد على `secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **حفظ نمط المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) والماستر المستنسخ. هذا يحمل الماستر، تخطيطاتها، والنمط المرتبط بها معًا.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);

        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد نسخ المحتوى إلى ماستر هدف غير مرتبط قد يُغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالنمط.

### **تطبيق قيم النمط على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على ماسترها وتخطيطها الحاليين، ابدء تجاوزًا على مستوى الشريحة من النمط المصدر. تنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) المكوّنات الثلاثة الرئيسية للنمط إلى التجاوز.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

يغيّر هذا النمط المستخدم لتلك الشريحة دون تغيير النمط الموروث من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز نمط على تخطيط**

يُطبق تجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم يكن لشريحة معينة تجاوز خاص بها. يمكن استخدام طرق التهيئة نفسها عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

استخدم نمط ماستر أو نمط على مستوى العرض عندما ينبغي للعديد من التخطيطات والشرائح مشاركة نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة تغييرات النمط العالمية لاحقًا أصعب في التنبؤ.

<!-- visual-explanation:presentation-theme:start -->
[![ماستر النمط يمدّ تخطيطين؛ تجاوز التخطيط يؤثّر على شرائحه ما عدا شريحة ذات تجاوز أكثر محلية.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*تجاوز التخطيط يُطبّق على الشرائح التي تستخدم ذلك التخطيط ما لم تزود شريحة تجاوزًا خاصًا بها. تتبع القيم القائمة على النمط مخططها المُستوى؛ يمكن للكائنات المُنسَّقة صراحةً الاحتفاظ بمظهرها المحلي. احرص على أن تكون التجاوزات ضيقة بقدر الاستثناء التصميمي المقصود.*
<!-- visual-explanation:presentation-theme:end -->

## **تحديث أنماط خلفية النمط**

تُخزَّن تعبئات خلفية النمط في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات التعبئة المخزَّنة فعليًا في هذه المجموعة، لأن الواجهة يمكنها دمج تعبئات النمط مع ألوان النمط ومراجع الأنماط الأخرى.

![معرض أنماط الخلفية في PowerPoint لنمط عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزَّنة و[Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/). مؤشر النمط `0` يعني عدم وجود تعبئة نمطية؛ القيم الإيجابية تُشير إلى مراجع أنماط خلفية نمطية. هذا يختلف عن فهرسة مجموعة JavaScript مباشرةً، حيث يعني الفهرس `0` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية نمطية للماستر الأول، ويحفظ العرض:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يعتمد النتيجة الظاهرة على مدخل النمط الذي يُشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر فقط تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}

لا تعامل مؤشر النمط كفهرس مجموعة يبدأ من الصفر. وتجنّب أيضًا ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات نمط النمط خاصة بالعرض.

{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}

للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/nodejs-java/presentation-background/).

{{% /alert %}}

## **تحديث تأثيرات النمط**

يحتوي مخطط تنسيق النمط على مجموعات تعبئة، خط، وتأثير منفصلة تُعرض عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). غالبًا ما تحتوي أنماط Office على ثلاثة مدخلات رئيسية تتطابق بصريًا مع تنسيقات خفيفة، متوسطة، ومكثفة، لكن يجب على الكود فحص كل مجموعة بدلًا من افتراض عدد ثابت.

![تأثيرات نمط خفيفة، متوسطة، ومكثفة مطبقة على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في JavaScript، يكون فهرس المجموعة يبدأ من الصفر: الفهرس `0` هو أول نمط مخزن والفهرس `2` هو الثالث. فهارس مراجع نمط الشكل مفهوم منفصل، يُعرَض عبر [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/). تعديل نمط النمط يؤثّر على الأشكال التي تُشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقّق من وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يُفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);

    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بالنسبة للأشكال التي تُشير إلى هذه الخانات، يصبح أول خط نمط النمط أحمر، وثالث تعبئة النمط أخضر غابي صلب، ويكتسب ثالث تأثير نمط ظلًا خارجيًا بمسافة 10 نقاط. لا يزال المظهر البصري النهائي يعتمد على أي خانة نمط تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز النمط.

![أنماط تأثير النمط بعد تعديل الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **اختيار أنماط تعبئة وخط لشكل**

يمكن للشكل اختيار تعبئته وخطه بشكل مستقل عبر [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) و[ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/). بالنسبة لكل طريقة، يُحدد الفهرس `1` أول مدخل في مجموعة النمط المقابلة (`get_Item(0)`)، والفهرس `2` الثاني (`get_Item(1)`).

المثال التالي يُنشئ نمطين تعبئة (ذهبي وأزرق سماوي) ونمطين خط (أزرق داكن 6 pt وأحمر داكن 12 pt) في النمط الافتراضي لعروض تقديمية جديدة. يحفظ الشريحة في ثلاث مراحل لتتمكن من مقارنة النتائج في PowerPoint.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| الأنماط الأولية | تغيير الحد الأيمن | تعديل أول تعبئة نمطية |
|:---:|:---:|:---:|
| ![مستطيلات ذهبية وزرقاء سماوية مع حدود زرقاء داكنة رقيقة متطابقة](theme-style-initial.png) | ![المستطيل الأزرق السماوي الآن يحتوي على حد أحمر داكن سميك](theme-style-line-changed.png) | ![المستطيل الأيسر الآن أخضر وكلا الحدين دون تغيير](theme-style-fill-changed.png) |

اختيار نمط خط مختلف يغيّر فقط حد المستطيل الأيمن. تعديل أول تعبئة نمطية يُحدّث كل شكل يستخدمها. هنا، يتحول المستطيل الأيسر إلى الأخضر فقط.

على شكل موجود، يمكن للون تعبئة محلي، لون خط، أو عرض خط أن يتجاوز ذلك الجزء من نمط النمط. إذا لم يُظهر تغيير فهرس النمط أي أثر مرئي، تحقق من [التنسيق المباشر](/slides/ar/nodejs-java/shape-formatting/) للشكل.

## **تحديد ما إذا كان التعبئة الصلبة الفعّالة تستخدم لون نمط**

يمكن تخزين التعبئة مباشرةً على كائن أو وراثتها من فقرة، تخطيط، ماستر، نمط، أو مستوى تنسيق آخر. استدعِ [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) لحل تلك السلسلة إلى لقطة تعبئة صلبة غير قابلة للتغيير. أولًا تحقق من قيمة `getFillType`. فقط عندما تكون `FillType.Solid` يجب قراءة خصائص التعبئة الصلبة.

لتعبئة صلبة، تُرجع `getSolidFillColor` القيمة النهائية RGB بعد الوراثة، والبحث في النمط، وتطبيق تحويلات اللون. تُرجع طريقة `getSolidFillSchemeColor` الخانة المنطقية لـ [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) المقابلة، مثل `Text1` أو `Accent6`. قيمة `SchemeColor.NotDefined` تعني أن التعبئة الصلبة الفعّالة ليست مبنية على لون مخطط. في سير عمل حيث تكون التعبئات إما ألوان نمط أو ألوان RGB مباشرة، تحدد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) المحلية وحدها لتصنيف تعبئة. على سبيل المثال، قد لا يحتوي جزء نص على لون مخطط معرف محليًا، لذا تكون قيمته المحلية `NotDefined`، بينما تُورّث تعبئته لون نمط وتُحَل إلى `Text1` أو `Accent6`. على العكس، تُخبرك `getSolidFillSchemeColor` أي خانة نمط منطقية نتجت عنها اللون الفعّالي، لكنها لا تُظهر ما إذا كانت تلك الخانة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر.

المثال التالي يحمل عرضًا، يراجِع تعبئات الأشكال وتعبئات أجزاء النص، يطبع كل قيمة RGB نهائية واللون المخطط المرتبط، ويُعرّف التعبئات الصلبة التي لن تتتبع تغييرات لون النمط:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

الفَرْع `NotDefined` يُوفِّر قائمة مراجعة للتعبئات الصلبة التي لن تستجيب لتغييرات خانات لون النمط. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا يزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما تُوضح قيمة المخطط ما إذا كان ذلك المظهر مرتبطًا بالنمط.

كائنات التنسيق الفعّالة هي لقطات. بعد تغيير نمط العرض، أو تجاوز النمط، أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ كائن تعبئة فعّال جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم النمط الفعّالة**

تُظهر كائنات النمط الأولية ما تم تعريفه على مستوى معين. تُظهر القيم الفعّالة ما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)، وللتعبئة استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/).

المثال التالي يقرأ النمط الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();

    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/)، قد تُفوت ماسترًا أو تخطيطًا أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثّر تطبيق نمط خارجي على كل شريحة في العرض؟**

لا. تُعيد [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) تعيين الشرائح التي تعتمد على الماستر المحدد فقط. الشرائح التي تستخدم ماسترات أخرى تحتفظ بأنماطها الحالية.

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) للشفرة وابدأ تجاوز النمط الخاص بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة نمطها الحالي.

**ما هي الطريقة الأكثر أمانًا لنقل نمط من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ ماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) و[SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/). يضمن ذلك بقاء الماستر، التخطيطات، والنمط معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) لشريحة أو تخطيط النمط، واستخدم طرق البيانات الفعّالة المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المُستخلصة بعد تطبيق الوراثة والتجاوزات.
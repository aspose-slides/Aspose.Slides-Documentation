---
title: إدارة أنماط العرض التقديمي في JavaScript
linktitle: نمط العرض التقديمي
type: docs
weight: 10
url: /ar/nodejs-java/presentation-theme/
keywords:
- نمط PowerPoint
- نمط العرض التقديمي
- نمط الشريحة
- تعيين النمط
- تغيير النمط
- إدارة النمط
- لون النمط
- لوحة ألوان إضافية
- خط النمط
- نمط التصميم
- تأثير النمط
- PowerPoint
- OpenDocument
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة أنماط العروض التقديمية في JavaScript باستخدام Aspose.Slides لـ Node.js لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
## **المقدمة**

يحدد نمط العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تشير الكائنات المدركة للنمط إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير النمط تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، يتوفر نمط العرض على مستوى العرض عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للنمط في مستويات أدنى. يمكن للماستر تجاوز نمط العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterthememanager/)، بينما يمكن لتخطيط أو شريحة فردية تجاوز نمطها الموروث عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). عملياً، يتم حل النمط الفعلي لشريحة عبر سلسلة الوراثة هذه: نمط العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات النمط: ألوان، خطوط، أنماط خلفية، وتأثيرات](theme-constituents.png)

تظهر الأقسام أدناه أكثر سير عمل شائع للنمط: فحص النمط، تغيير الألوان والخطوط، نسخ أو تطبيق نمط، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعلية بعد حل الوراثة والتجاوزات.

## **فحص نمط**

يكشف كائن [MasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/) عن مخطط ألوان النمط، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/). يُعد فحص هذه التجميعات قبل تعديلها مفيداً بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات النمط يمكن أن يتغير.

المثال التالي يقرأ الخصائص الرئيسية للنمط ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في النمط:

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

إذا كان الملف يستخدم عدة ماستر، لا تفترض أن كل شريحة لديها نفس النمط الفعلي. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل النمط الفعلي الموضح لاحقاً في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان النمط**

يمكن للتعبئات، الخطوط، والنصوص المدركة للنمط أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون النمطي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون النمط.

المثال الشامل التالي ينشئ شكلاً يستخدم `Accent4`، يغيّر لون النمط `Accent4` إلى الأحمر، يحفظ العرض، يفتحّه مرة أخرى، ويطبع لون التعبئة الفعلي:

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

نظرًا لأن المستطيل لا يزال مرتبطاً بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير النمط. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة لـ `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

يستخلص PowerPoint إصدارات أفتح وأق darker من لون النمط بتطبيق تحولات لونية. تُظهر Aspose.Slides هذه التحولات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للنمط والألوان الأفتح والأق darker المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان النمط الرئيسية.

**2** - إصدارات أفتح وأق darker المنتجة من ألوان النمط الرئيسية.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه الإصدارات معتمدة على لون النمط. إذا تغيّر `Accent4` لاحقاً، تُعاد حساب الألوان المحوَّلة من قيمة `Accent4` الجديدة.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/) القِيَم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يكشف تعداد [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/) عن نفس فتحات النمط كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات النمط؛ ليست قيماً تُحوَّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط النمط**

يحتوي مخطط خطوط النمط على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تكشف الطريقتان [FontScheme.getMajor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) تلك المجموعات.

يمكن استخدام معرفات خطوط النمط المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)

المثال التالي ينشئ عنواناً يستخدم خط النمط اللاتيني الرئيسي وسطر نص أساسي يستخدم خط النمط اللاتيني الفرعي. ثم يغيّر خطوط النمط ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع نص الجسم الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف نمط لن يتبدل تلقائياً عندما يتغيّر مخطط خطوط النمط.

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض، انظر [PowerPoint Fonts](/slides/ar/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق نمط**

هناك سيرا عمل شائعان، يحلان مشاكل مختلفة.

### **الحفاظ على نمط المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر والحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/) والماستر المستنسخ. هذا ينقل الماستر، تخطيطاته، والنمط المرتبط معه معاً.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. ببساطة استنساخ المحتوى على ماستر غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالنمط.

### **تطبيق قيم النمط على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على الماستر والتخطيط الحاليين، ابدأ تجاوزاً على مستوى الشريحة من النمط المصدر. تنسخ الطرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/) المكونات الثلاثة الرئيسية للنمط إلى التجاوز.

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

هذا يغيّر النمط المستخدم لتلك الشريحة دون تغيير النمط الموروث من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز نمط على تخطيط**

يُطبق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم يكن لشريحة معينة تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslidethememanager/):

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

استخدم نمط على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المتعددة على مستوى الشريحة تغييرات النمط العالمية لاحقاً أصعب في التنبؤ.

## **تحديث أنماط خلفية النمط**

تُخزن تعبئات خلفية النمط في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعلياً في هذا التجميع لأن الواجهة يمكنها دمج تعبئات النمط مع ألوان النمط وإشارات نمطية أخرى.

![معرض أنماط الخلفية في PowerPoint لنمط عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص التجميع المخزن و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) الحالي. يعني فهرس النمط `0` عدم وجود تعبئة نمطية؛ القيم الموجبة هي إشارات إلى أنماط خلفية نمطية. يختلف هذا عن فهرسة التجميع في JavaScript مباشرةً، حيث يعني الفهرس `0` العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن إشارة خلفية نمطية للماستر الأول، ويحفظ العرض:

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

تعتمد النتيجة المرئية على إدخال النمط الذي يشير إليه الماستر وعلى أي تجاوزات خلفية في مستوى التخطيط أو الشريحة. إذا كانت الشريحة تستخدم خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر فقط تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لا تتعامل مع فهرس النمط كفهرس تجميع يبدأ من الصفر. كما تجنّب ترميز رقم نمط ثابت من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعاريف نمط الخلفية خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية، انظر [Presentation Background](/slides/ar/nodejs-java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات النمط**

يحتوي مخطط تنسيق النمط على تجميعات منفصلة للتعبئة، الخط، وتأثيرات النمط تُعرض عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). غالباً ما تحتوي الأنماط المكتبية على ثلاث مدخلات رئيسية تمثل بصرياً تنسيقات خفيفة، معتدلة، وشديدة، لكن يجب على الشيفرة فحص كل تجميع بدلاً من افتراض عدد ثابت.

![تأثيرات نمط خفيفة، معتدلة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه التجميعات في JavaScript، يكون فهرس التجميع صفرياً: الفهرس `0` هو أول نمط مخزن والفهرس `2` هو الثالث. فهارس مراجع النمط للشكل مفهوم منفصل، تُعرض عبر [ShapeStyle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapestyle/). تعديل نمط نمط يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتأكد من وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط نمطي أحمر، ويصبح ثالث نمط تعبئة نمطي أخضر غابة صلصالي، ويحصل ثالث نمط تأثير على ظل خارجي ببعد 10 نقاط. لا يزال الناتج البصري يعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يغلب النمط.

![أنماط تأثير النمط بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم النمط الفعلي**

توفر كائنات النمط الخام ما تم تعريفه على مستوى معين. القيم الفعلية تخبرك بما يستخدمه الشريحة أو الشكل فعلياً بعد حل الوراثة والتجاوزات المحلية. للحصول على نمط شريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/)، وللتعبئة استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/).

المثال التالي يقرأ النمط الفعلي، الخلفية، وأول تعبئة شكل من شريحة:

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

استخدم البيانات الفعلية لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/)، قد تفوتك تجاوزات ماستر، تخطيط، شريحة، أو شكل تغير المظهر النهائي.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidethememanager/) للشريحة وابدأ تجاوُز النمط الخاص بها. يبقى التغيير محلياً لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة أنماطها الحالية.

**ما هي الطريقة الأكثر أماناً لنقل نمط من عرض تقديمي إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/) و[SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/). هذا يحافظ على الماستر، التخطيطات، والنمط معاً.

**كيف يمكنني رؤية القيم الفعلية بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/) لنمط شريحة أو تخطيط والطرق الفعلية المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/). تُعيد هذه الـ APIs القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
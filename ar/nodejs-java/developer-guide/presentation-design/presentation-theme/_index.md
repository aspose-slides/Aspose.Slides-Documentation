---
title: إدارة سمات العروض التقديمية في جافاسكريبت
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/nodejs-java/presentation-theme/
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
- عرض تقديمي
- Node.js
- جافاسكريبت
- Aspose.Slides
description: "قم بإدارة سمات العروض التقديمية في جافاسكريبت باستخدام Aspose.Slides لـ Node.js لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **مقدمة**

تعريف سمة العرض يحدد مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. الكائنات المدركة للسمة تشير إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة أن يحدّث العديد من الكائنات مرة واحدة.

في Aspose.Slides، يمكن الوصول إلى سمة المستوى العرضي عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للسمة على مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية أن تتجاوز السمة الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). عملياً، يتم حل السمة الفعّالة لشريحة عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

الأقسام أدناه توضح أكثر سير عمل شائع للسمة: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

كائن [MasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/) يعرض مخطط ألوان السمة، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد خصوصاً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للسمة ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لديها نفس السمة الفعّالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقاً في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

التعبئات، الخطوط، والنصوص المدركة للسمة يمكن أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/). عندما تغيّر الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/)، جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمة تُستدل على القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تُغيّر عند تحديث لون السمة.

المثال التالي الشامل ينشئ شكلاً يستخدم `Accent4`، يغيّر لون `Accent4` في السمة إلى الأحمر، يحفظ العرض، يفتحه مجدداً، ويطبع لون التعبئة الفعّالية:

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

لأن المستطيل ما زال مرتبطاً بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

PowerPoint يولد متغيرات أفتح وأغمق من لون السمة عن طريق تطبيق تحولات اللون. Aspose.Slides يعرّف هذه التحولات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colortransformoperation/).

![الألوان الأساسية للسمة والألوان الفاتحة والداكنة المولدة من لوحة الألوان الإضافية](additional-palette-colors.png)

**1** - الألوان الأساسية للسمة.

**2** - المتغيرات الفاتحة والداكنة المنتجة من الألوان الأساسية للسمة.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

هذه المتغيرات تبقى مستندة إلى لون السمة. إذا تغير `Accent4` لاحقاً، تُعاد حساب الألوان المُحوّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيماً تُحوّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط السمة**

مخطط خطوط السمة يحتوي على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. طريقتا [FontScheme.getMajor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) تعرضان هاتين المجموعتين.

معرّفات خطوط السمة المتوافقة مع PowerPoint يمكن استخدامها في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)

المثال التالي ينشئ عنواناً يستخدم خط السمة اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط السمة اللاتيني الفرعي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي لديه اسم خط صريح بدلاً من معرف سمة لن يتبدل تلقائياً عندما يتغيّر مخطط خطوط السمة.

المجموعات الرئيسية والفرعية للخطوط يمكن أن تحتوي أيضاً على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثانا. لفحص، إضافة، استبدال، أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض التقديمي، انظر [PowerPoint Fonts](/slides/ar/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

هناك سير عملين شائعين، ويحلان مشاكل مختلفة.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض تقديمي آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/) والماستر المستنسخ. هذا يحمل الماستر، تخطيطاته، والسمة المرتبطة معاً.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر وجهة غير متعلق قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم سمة على شريحة موجودة**

إذا كان يجب أن تظل الشريحة الهدف على الماستر والتخطيط الحاليين، ابدأ تجاوز سمة على مستوى الشريحة من السمة المصدر. طُرُق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/) تنسخ المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

تجاوز على مستوى التخطيط يطّبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لديها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslidethememanager/):

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

استخدم سمة ماستر أو سمة مستوى العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدام تجاوز تخطيط عندما تحتاج عائلة تخطيط واحدة إلى نمط مختلف، وتجاوز شريحة فقط للاستثناءات الحقيقية. التجاوزات المفرطة على مستوى الشرائح تجعل التغييرات السمة العامة لاحقاً أصعب في التنبؤ.

## **تحديث أنماط خلفية السمة**

تعبئات خلفية السمة تُخزن في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات التعبئة المخزنة فعلياً في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة وإشارات أنماط أخرى.

![معرض أنماط خلفية PowerPoint لسمة العرض التقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) الحالي. فهرس النمط `0` يعني لا تعبئة سمة؛ القيم الموجبة هي إشارات إلى أنماط خلفية سمة. هذا يختلف عن فهرسة مجموعة JavaScript مباشرةً، حيث يعني الفهرس `0` أول عنصر مخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن إشارة خلفية سمة إلى أول ماستر، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على مدخل السمة المشار إليه من قبل الماستر وعلى أي تجاوزات خلفية في التخطيط أو مستوى الشريحة. إذا كانت الشريحة تستخدم خلفية خاصة بها، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لاTreat فهرس النمط كفهرس مجموعة يبدأ من الصفر. كما تجنب ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بالمظهر نفسه في ملف آخر؛ تعريفات نمط السمة خاصة بالعرض التقديمي.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
لتنسيق الخلفية المباشر والوراثة الخلفية، راجع [Presentation Background](/slides/ar/nodejs-java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

مخطط تنسيق السمة يحتوي على مجموعات منفصلة للتعبئة، الخط، وتأثيرات النمط التي تُعرض عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). عادةً ما تحتوي سمات Office على ثلاث إدخالات أساسية تتطابق بصرياً مع تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات السمة الخفيفة والمتوسطة والشديدة المطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في JavaScript، فهرس المجموعة يبدأ من الصفر: الفهرس `0` هو أول نمط مخزن والفهرس `2` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، تُعرض عبر [ShapeStyle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ الأشكال ذات التنسيق المباشر قد تبقى دون تغيير.

المثال التالي يتحقق من وجود إدخالات النمط المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط التعبئة الثالث، يفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط سمة أحمر، يصبح النمط الثالث لتعبئة السمة أخضر غابة صلب، ويحصل نمط التأثير الثالث على ظل خارجي بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على أي فواصل نمط تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

الكائنات الخام للسمة تخبرك ما هو معرف على مستوى معين. القيم الفعّالة تخبرك ما الذي يستخدمه شريحة أو شكل فعلياً بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/)، وللتعبئة استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة للتشخيصات الرسومية، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/)، قد تفوتك تجاوزات ماستر أو تخطيط أو شريحة أو شكل تغير المظهر النهائي.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. التغيير يبقى محلياً لتلك الشريحة؛ الشرائح الأخرى تستمر في وراثة السمات الحالية.

**ما هي الطريقة الآمنة لنقل سمة من عرض تقديمي إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/) و[SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/). هذا يحافظ على الماستر، التخطيطات، والسمة معاً.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط والطرق الفعّالة المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/). هذه الواجهات تُعيد القيم المُستخرجة بعد تطبيق الوراثة والتجاوزات.
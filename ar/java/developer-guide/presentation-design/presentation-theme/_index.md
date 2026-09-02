---
title: إدارة أنماط العروض التقديمية في Java
linktitle: نمط العرض التقديمي
type: docs
weight: 10
url: /ar/java/presentation-theme/
keywords:
- نمط PowerPoint
- نمط العرض
- نمط الشريحة
- تعيين النمط
- تغيير النمط
- إدارة النمط
- لون النمط
- لوحة إضافية
- خط النمط
- نمط التصميم
- تأثير النمط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "أدِر أنماط العرض التقديمي في Aspose.Slides للغة Java لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية موحدة."
---
## **المقدمة**

يحدد نمط العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والتعبئات والخطوط والتأثيرات. تشير الكائنات المدركة للنمط إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذلك يمكن لتغيير النمط أن يحدث تحديثاً للعديد من الكائنات مرة واحدة.

في Aspose.Slides، يتوفر نمط العرض على مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للنمط في مستويات أدنى. يمكن للماستر أن يتجاوز نمط العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية أن يتجاوز النمط الموروث عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). عملياً، يتم حل النمط الفعّال لشريحة ما من خلال سلسة الوراثة هذه: نمط العرض → تجاوز الماستر → تجاوز التخطيط → تجاوز الشريحة.

![مكونات النمط: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تظهر الأقسام أدناه أكثر سير عمل شائع للنمط: فحص النمط، تغيير الألوان والخطوط، نسخ أو تطبيق نمط، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص النمط**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/) مخطط ألوان النمط، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/). يكون فحص هذه المجموعات قبل تعديلها مفيداً خصوصاً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى الإدخالات النمطية قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للنمط ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في النمط:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لديها نفس النمط الفعّال. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل النمط الفعّال الموضح لاحقاً في هذه المقالة عندما قد تكون هناك تجاوزات في التخطيط أو الشريحة.

## **تغيير ألوان النمط**

يمكن أن تشير التعبئات والخطوط والنصوص المدركة للنمط إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون النمطي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون النمط.

المثال التالي الشامل ينشئ شكلاً يستخدم `Accent4`، يغير لون النمط `Accent4` إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون التعبئة الفعّال:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

لأن المستطيل ما يزال مرتبطاً بـ `Accent4`، يصبح اللون الظاهر له أحمر بعد تغيير النمط. إذا قمت باستبدال لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

يستخلص PowerPoint متغيرات أخف وأغمق من لون النمط عبر تطبيق تحويلات لونية. تعرض Aspose.Slides هذه التحويلات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/colortransformoperation/).

![الألوان الرئيسية للنمط والألوان الأخف والأغمق المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للنمط.

**2** - المتغيرات الأخف والأغمق المستخرجة من الألوان الرئيسية للنمط.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبق تحويلات الإنارة على خمسة منها، ويحفظ النتيجة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تظل هذه المتغيرات مبنية على لون النمط. إذا تغير `Accent4` لاحقاً، تُعاد حساب الألوان المعدّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يكشف [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/) عن نفس فتحات النمط كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. التعيين ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات النمط؛ ليست قيماً تُحوَّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط النمط**

يحتوي مخطط خطوط النمط على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تكشف الطريقتان [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) عن هاتين المجموعتين.

يمكن استخدام معرفات خطوط النمط المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم خط النمط اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط النمط اللاتيني الفرعي. ثم يغيّر خطوط النمط ويحفظ النتيجة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف نمط لن يتبدل تلقائياً عندما يتغيّر مخطط خطوط النمط.

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق نمط**

هناك نمسان شائعان للعمل، ويحلّان مشاكل مختلفة.

### **الإبقاء على نمط المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/) والماستر المستنسخ. هذا ينقل الماستر وتخطيطاته والنمط المرتبط معه معاً.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر وجهة غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالنمط.

### **تطبيق قيم النمط على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على ماسترها وتخطيطها الحالي، ابدأ تجاوزًا على مستوى الشريحة من النمط المصدر. تُنسخ الطرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/) المكونين الرئيسيين للنمط إلى التجاوز.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

هذا يغيّر النمط المستخدم لتلك الشريحة دون تغيير النمط الموروث للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز نمط على تخطيط**

يطبق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

استخدم نمط ماستر أو مستوى عرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز تخطيط عندما تحتاج فئة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز شريحة فقط للاستثناءات الحقيقية. التجاوزات المتعددة على مستوى الشريحة تجعل تغييرات النمط العامة لاحقاً أصعب في التوقع.

## **تحديث أنماط خلفية النمط**

تُخزن تعبئات خلفية النمط في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مما هو مخزن فعلياً في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات النمط مع ألوان النمط وإشارات نمطية أخرى.

![معرض أنماط خلفية PowerPoint لنمط عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/). مؤشر النمط `0` يعني لا تعبئة نمطية؛ القيم الموجبة تشير إلى مراجع أنماط خلفية نمطية. هذا مختلف عن فهرسة مجموعة Java مباشرة، حيث يعني `get_Item(0)` العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية نمطي للماستر الأول، ويحفظ العرض:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة الظاهرة تعتمد على إدخال النمط الذي يشير إليه الماستر وأي تجاوزات خلفية في التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تعديل خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لاTreat مؤشر النمط كفهرس مجموعة يبدأ من الصفر. كما تجنّب ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط النمط خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
للتنسيق المباشر للخلفية والوراثة، راجع [Presentation Background](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات النمط**

يحتوي مخطط تنسيق النمط على مجموعات منفصلة من تعبئات الخطوط والتأثيرات التي تُعرض عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). غالباً ما تحتوي أنماط Office النمطية على ثلاثة مداخل رئيسية تمثل بصرياً تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات نمطية خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Java، يكون فهرس المجموعة صفرياً: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. فهارس المراجع النمطية للشكل مفهوم منفصل، يُكشف عبر [IShapeStyle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapestyle/). تعديل نمط نمطي يؤثر على الأشكال التي تشير إلى ذلك النمط؛ الأشكال ذات التنسيق المباشر قد تظل دون تغيير.

المثال التالي يتحقق من وجود المداخل المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يمكّن ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط نمطي أحمر، ثالث نمط تعبئة نمطي أخضر غابوي صلب، والثالث يحصل على ظل خارجي بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على أي فترات نمطية كل شكل يشير إليها وما إذا كان التنسيق المباشر يتجاوز النمط.

![أنماط تأثير النمط بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم النمط الفعّالة**

تخبرك كائنات النمط الخام بما تم تعريفه على مستوى معين. القيم الفعّالة تخبرك بما تستخدمه الشريحة أو الشكل فعلياً بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/)، وللتعبئة استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/).

المثال التالي يقرأ النمط الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

استخدم البيانات الفعّالة للتشخيص العرضي، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، قد تفوتك ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidethememanager/) للشريحة وابدأ تجاوُزه النمطي. يبقى التغيير محلياً لتلك الشريحة؛ الشريحة الأخرى تستمر في وراثة أنماطها الحالية.

**ما هي الطريقة الأكثر أماناً لنقل نمط من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/). هذا يحتفظ بالماستر والتخطيطات والنمط معاً.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/) لنمط شريحة أو تخطيط، والطُرُق الفعّالة المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
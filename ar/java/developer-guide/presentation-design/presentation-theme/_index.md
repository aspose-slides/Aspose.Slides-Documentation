---
title: إدارة سمات العرض في جافا
linktitle: سمة العرض
type: docs
weight: 10
url: /ar/java/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- لون السمة
- لوحة إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض
- جافا
- Aspose.Slides
description: "إدارة سمات العرض الرئيسية في Aspose.Slides لجافا لإنشاء وتخصيص وتحويل ملفات PowerPoint مع علامة تجارية متسقة."
---
## **المقدمة**

يحدد سمة العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملء والحدود والتأثيرات. تُشير الكائنات المدركة للسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، مما يتيح لتغيير السمة تحديث العديد من الكائنات في آن واحد.

في Aspose.Slides، تتوفر سمة مستوى العرض عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للسمة في مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterthememanager/)، بينما يمكن لتخطيط أو شريحة فردية تجاوز السمة الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). عمليًا، يتم حل السمة الفعَّالة لشريحة ما من خلال سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل السمة شيوعًا: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعَّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

الكائن [MasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/) يُظهر مخطط ألوان السمة، ومخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/). إن فحص هذه التجميعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويبلغ عن عدد أنماط الخلفية، والملء، والحدود، والتأثيرات المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعَّالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعَّالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للملء والحدود والنصوص المدركة للسمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمة وفق القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

المثال التالي الكامل ينشئ شكلاً يستخدم `Accent4`، ويغير لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يفتحه مرة أخرى، ويطبع لون الملء الفعَّال:

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

نظرًا لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون التعداد بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على ذلك الملء.

### **استخدام ألوان من اللوحة الإضافية**

يستمد PowerPoint متغيرات أفتح وأغمق من لون السمة عبر تطبيق تحويلات ألوان. تُظهر Aspose.Slides هذه التحويلات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الأفتح والأغمق المُنشأة من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية.

**2** - المتغيرات الأفتح والأغمق المُنتجة من ألوان السمة الرئيسية.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يُطبق تحويلات إضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتغيرات مستندة إلى لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **خريطة قيم `SchemeColor` إلى فتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحول ديناميكيًا من صيغة إلى أخرى.

## **تغيير خطوط السمة**

تحتوي مخططات خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تُظهر طُرق [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) تلك المجموعات.

يمكن استخدام معرّفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - الخط الأساسي للغة اللاتينية (Minor Latin Font)
* `+mj-lt` - خط العنوان للغة اللاتينية (Major Latin Font)
* `+mn-ea` - الخط الأساسي للغة الآسيوية الشرقية (Minor East Asian Font)
* `+mj-ea` - خط العنوان للغة الآسيوية الشرقية (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا نصيًا يستخدم الخط اللاتيني الفرعي. ثم يُغيّر خطوط السمة ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع النص الأساسي الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرّف السمة لن يتحول تلقائيًا عند تغيير مخطط خطوط السمة.

يمكن لمجموعات الخطوط الرئيسة والفرعية أيضًا أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريلية، العربية، اليابانية، الجورجية، والثانا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، راجع [خطوط السمة الخاصة بالسكريبت](/slides/ar/java/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

هناك سير عملان شائعان، ويحلان مشاكل مختلفة.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/) والماستر المستنسخ. ينقل ذلك الماستر وتخطيطاته والسمة المرتبطة معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على الماستر والتخطيط الحاليين، قم بتهيئة تجاوز سمة على مستوى الشريحة من سمة المصدر. تنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/) المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوزها الخاص. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslidethememanager/):

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

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تشترك الكثير من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج مجموعة تخطيطات واحدة إلى نمط مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة تغييرات السمة العامة المستقبلية أصعب في التنبؤ.

## **تحديث أنماط خلفية السمة**

تُخزَّن ملء خلفية السمة في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات الملء الفعلية المخزَّنة في هذه التجميع لأن الواجهة يمكنها دمج ملء السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص التجميع المخزن و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) الحالي. يُشير فهرس النمط `0` إلى عدم وجود ملء مَسْتَند إلى السمة؛ القيم الموجبة هي مراجع أنماط خلفية السمة. هذا يختلف عن فهرسة التجميع الجافا مباشرة، حيث يعني `get_Item(0)` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

المثال التالي يُبلغ عن عدد ملء الخلفية المتاح، يُعيّن مرجع خلفية سمة إلى أول ماستر، ويحفظ العرض:

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

النتيجة المرئية تعتمد على مدخل السمة الذي يشير إليه الماستر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت شريحة تستخدم خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) عندما تحتاج لمعرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لا تتعامل مع فهرس النمط كفهرس تجميع صفر‑مستند. أيضًا تجنَّب ترميز رقم نمط ثابت من ملف واحد والافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية، راجع [خلفية العرض](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على تجميعات منفصلة للملء، والحدود، وتأثيرات الأنماط تُعرض عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). غالبًا ما تحتوي سمات Office على ثلاثة مدخلات أساسية تُطابق بصريًا التنسيقات الخفيفة، المتوسطة، والشديدة، لكن يجب على الشيفرة فحص كل تجميع بدلًا من افتراض عدد ثابت.

![تأثيرات السمة الخفيفة، المتوسطة، والشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه التجميعات في Java، يكون فهرس التجميع صفر‑مستند: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. فهارس مراجع النمط للشكل هي مفهوم منفصل، تُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapestyle/). تعديل نمط سمة يُؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر أول نمط حد، يغيّر ثالث نمط ملء، يفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط حد سمةً أحمر، وثالث نمط ملء سمةً أخضر غابي صلب، والثالث تأثير سمةً يكتسب ظلًا خارجيًا بمسافة 10 نقاط. لا يزال الناتج البصري يعتمد على أي فتحات نمط كل شكل يشير إليها وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير الحد، الملء، وإعدادات الظل](presentation-design_11.png)

## **قراءة القيم الفعَّالة للسمة**

توفر كائنات السمة الأصلية ما تم تعريفه على مستوى معين. تُظهر القيم الفعَّالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/)، وللملء استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعَّالة، الخلفية، وملء الشكل الأول من شريحة:

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

استخدم البيانات الفعَّالة للتشخيص، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، قد تفوّت ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidethememanager/) الخاص بالشريحة وقم بتهيئة سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/). يبقي ذلك الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني مشاهدة القيم الفعَّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط والطُّرُق الفعَّالة المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المُحَلَّة بعد تطبيق الوراثة والتجاوزات.
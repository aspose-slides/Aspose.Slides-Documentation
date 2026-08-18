---
title: إدارة سمات العروض التقديمية على Android
linktitle: سمة العرض
type: docs
weight: 10
url: /ar/androidjava/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
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
- Android
- Java
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides لنظام Android عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **المقدمة**

تعرف سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تشير الكائنات المدركة للسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات للسمة في مستويات أدنى. يمكن للمستوى الرئيسي (master) تجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية تجاوز السمة الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/). عمليًا، تُحل السمة الفعّالة لشريحة ما عبر سلسلة الوراثة هذه: سمة العرض، تجاوز المستوي الرئيسي، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تظهر الأقسام أدناه أكثر سير عمل شائع للسمة: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص السمة**

كائن [MasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/) يُظهر مخطط ألوان السمة، مخطط الخطوط، ومخطط الصيغ عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات النمط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للسمة ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

إذا كان الملف يستخدم عدة مستويات رئيسية، لا تفترض أن كل شريحة لديها نفس السمة الفعّالة. افحص المستوى الرئيسي المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

التعبئات، الخطوط، والنصوص المدركة للسمة يمكن أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/)، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السيمائي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

المثال الشامل التالي ينشئ شكلاً يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يفتحه مرة أخرى، ويطبع لون التعبئة الفعّال:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

نظرًا لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير السمة. إذا استبدلت اللون السيمائي بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على تلك التعبئة بعد الآن.

### **استخدام الألوان من اللوحة الإضافية**

يستخلص PowerPoint متباينات أفتح وأغمق من لون السمة عبر تطبيق تحويلات اللون. تُظهر Aspose.Slides هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الفاتحة والداكنة المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.

**2** - المتغيّرات الفاتحة والداكنة المنتجة من الألوان الرئيسية للسمة.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتباينات مستندة إلى لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة بناءً على قيمة `Accent4` الجديدة.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

تستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. هذا الترابط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من صيغة إلى أخرى.

## **تغيير خطوط السمة**

يتضمن مخطط خطوط السمة مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر طريقتا [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/) تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي لاتيني (خط لاتيني فرعي)
* `+mj-lt` - خط العنوان لاتيني (خط لاتيني رئيسي)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (خط شرق آسيوي فرعي)
* `+mj-ea` - خط العنوان شرق آسيوي (خط شرق آسيوي رئيسي)

المثال التالي ينشئ عنوانًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا أساسيًا يستخدم الخط اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع النص الأساسي الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتبدل تلقائيًا عند تغيير مخطط خطوط السمة.

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

هناك سير عملان شائعان، ويحلّان مشكلات مختلفة.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا كنت ترغب في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ المستوى الرئيسي (master) المصدر إلى العرض الهدف عبر [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/)، ثم استنسخ الشريحة عبر [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/) مع المستوى المستنسخ. هذا يحمل المستوى الرئيسي وتخطيطاته والسمة المرتبطة به معًا.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على مستوى رئيسي غير مرتبط قد يُغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على مستوىها الرئيسي وتخطيطها الحالي، ابدأ تجاوزًا للمستوى الشريحة من السمة المصدر. تُنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/) المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز السمة على تخطيط**

تطبيق تجاوز على مستوى التخطيط ينطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

استخدم سمة مستوى المستوى الرئيسي أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. عدد كبير من التجاوزات على مستوى الشريحة يجعل توقع تغييرات السمة العامة لاحقًا أصعب.

## **تحديث أنماط خلفية السمة**

تُخزن تعبئات خلفية السمة في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة ومراجع النمط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/) الحالي. فهرس النمط `0` يعني عدم وجود تعبئة themed؛ القيم الإيجابية تشير إلى مراجع أنماط خلفية السمة. هذا يختلف عن فهرسة مجموعة Java مباشرة، حيث `get_Item(0)` يعني العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية themed إلى المستوى الرئيسي الأول، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على إدخال السمة الذي يشير إليه المستوى الرئيسي وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية المستوى الرئيسي تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعتبر فهرس النمط كفهرس مجموعة يبدأ من الصفر. وتجنب أيضًا ترميز رقم نمط من ملف واحد والافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/androidjava/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

تحتوي مخططات صيغة السمة على مجموعات منفصلة من أنماط التعبئة، الخط، والتأثير تُعرَض عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/). غالبًا ما تحتوي سلالم Office على ثلاث مدخلات أساسية تتطابق بصريًا مع تنسيق خفيف، متوسط، وشديد، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات السمة الدقيقة والمتوسطة والشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Java، يكون فهرس المجموعة صفرًا أساسًا: `get_Item(0)` هو النمط المخزن الأول و`get_Item(2)` هو الثالث. فهارس مرجع النمط في الشكل مفهوم منفصل، يُعرَض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ الأشكال التي لديها تنسيق مباشر قد تبقى دون تغيير.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للأشكال التي تشير إلى هذه الفتحات، يصبح النمط الخط الأول للثيمة أحمر، والنمط التعبئة الثالث يصبح أخضر غابة صلب، والنمط التأثير الثالث يحصل على ظل خارجي بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

الكائنات الأولية للسمة تُظهر لك ما هو معرف على مستوى معين. القيم الفعّالة تُظهر لك ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/)، وللتعبئة، استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، وتعبئة الشكل الأول من شريحة:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

استخدم البيانات الفعّالة لتشخيص العرض، والتحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، قد تفوتك تجاوزات المستوى الرئيسي أو التخطيط أو الشريحة أو الشكل التي تغيّر المظهر النهائي.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير المستوى الرئيسي؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidethememanager/) للشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهر المصدر، استنسخ المستوى الرئيسي المصدر إلى الوجهة واستنسخ الشريحة باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/). هذا يحافظ على المستوى الرئيسي، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/) لسمة الشريحة أو التخطيط والاستدعاءات المناظرة للبيانات الفعّالة لكائنات الصيغة مثل [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
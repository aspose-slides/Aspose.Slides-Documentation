---
title: إدارة سمات العرض في Java
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
- سمة خارجية
- THMX
- لون السمة
- لوحة الألوان الإضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- العرض
- Java
- Aspose.Slides
description: "التحكم في سمات العرض في Aspose.Slides للغة Java لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية موحدة."
---
## **المقدمة**

تعرّف سمة العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والتعبئات والخطوط والتأثيرات. تشير الكائنات المدركة للسمات إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للسمات في مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterthememanager/), بينما يمكن لتخطيط أو شريحة فردية تجاوز السمة الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). عمليًا، تُحل السمة الفعّالة لشريحة عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان والخطوط وأنماط الخلفية والتأثيرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل السمة شيوعًا: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يكشف كائن [MasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/) عن نظام الألوان والخطوط وتنسيق السمة عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/), و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/). يعتبر فحص هذه المجموعات قبل تعديلها مفيدًا بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويبلغ عن عدد أنماط الخلفية والتعبئة والخط والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعّالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للتعبئات والخطوط والنصوص المدركة للسمات الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/). عند تعديل الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/), يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمة وفقًا للقيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

المثال التالي شاملًا يخلق شكلًا يستخدم `Accent4`, يغير لون السمة `Accent4` إلى الأحمر, يحفظ العرض, يعيد فتحه, ويطبع لون التعبئة الفعّال:

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

لأن المستطيل ما يزال مرتبطًا بـ `Accent4`, يصبح لونه الظاهر أحمرًا بعد تغيير السمة. إذا استبدلت لون التعداد بلون مباشر على الشكل, فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام الألوان من لوحة الألوان الإضافية**

يستنتاج PowerPoint تنويعات أفتح وأغمق من لون السمة عن طريق تطبيق تحولات اللون. تعرض Aspose.Slides هذه التحولات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمّة والألوان الفاتحة والغامقة المولدة من لوحة الألوان الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمّة.  
**2** - تنويعات أفتح وأغمق مُنتجة من الألوان الرئيسية للسمّة.

المثال التالي يخلق ستة مستطيلات مستندة إلى `Accent4`, يطبق تحولات الإضاءة على خمسة منها, ويحفظ النتيجة:

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

تبقى هذه التنويعات مبنية على لون السمة. إذا تغيّر `Accent4` لاحقًا, تُعاد حساب الألوان المُحولة من القيمة الجديدة لـ `Accent4`.

### **تعيين قيم `SchemeColor` إلى خلايا `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/) القيم `Text1`, `Background1`, `Text2`, و`Background2`, بينما يعرض [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/) نفس خلايا السمة كـ `Dark1`, `Light1`, `Dark2`, و`Light2`. التعيين ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس خلايا السمة; ليست قيمًا يتم تحويلها ديناميكيًا من شكل لآخر.

## **تغيير خطوط السمة**

يتضمن نظام الخطوط في السمة مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تُظهر طريقتا [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) هذه المجموعات.

يمكن لخطوط السمة المتوافقة مع PowerPoint أن تُستَخدم في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (خط لاتيني فرعي)
* `+mj-lt` - خط العنوان اللاتيني (خط لاتيني رئيسي)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (خط شرق آسيوي فرعي)
* `+mj-ea` - خط العنوان شرق آسيوي (خط شرق آسيوي رئيسي)

المثال التالي يخلق عنوانًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط السمة اللاتيني الفرعي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحمل اسم خط صريح بدلاً من معرف سمة لن يتبدل تلقائيًا عندما يتغير نظام خطوط السمة.

يمكن للمجموعتين الرئيسيين والفرعيين أيضًا أن يحتويا على تعيينات خطوط لأنظمة كتابة فردية، مثل السيرلية والعربية واليابانية والجورجية وثآنا. لفحص, إضافة, استبدال, أو إزالة هذه التعيينات, راجع [Script-Specific Theme Fonts](/slides/ar/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض, راجع [PowerPoint Fonts](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

تحل سير عمل أدناه مشكلات مختلفة متعلقة بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة للماستر**

استخدم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر محدد. حدد الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) التي تنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/), ومرّر مسار ملف السمة إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. ينشئ شريحة ماستر جديدة استنادًا إلى الماستر المحدد.  
2. يطبق السمة الخارجية على الماستر الجديد.  
3. يعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الماستر المحدد.  
4. يرجّع [IMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) الذي تم إنشاؤه حديثًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قد يتسبب سمة غير صالحة أو تالفة أو غير مدعومة في حدوث [PptxReadException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يقدمها المستخدمون, تعامل مع فشل الوصول إلى نظام الملفات, واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين فقط الشرائح التي كانت تعتمد على الماستر المحدد. الشرائح المرتبطة بماسترات أخرى تحتفظ بالماستر والسمة الحاليين. تُحل الألوان والخطوط والتعبئات والخطوط الخلفية والتأثيرات المدركة للسمات وفقًا للسمة الخارجية. قد تظل الألوان والخطوط والتعبئات وتنسيقات أخرى مخصصة دون تغيير. قد تتفوق التجاوزات على مستوى التخطيط أو الشريحة على القيم الموروثة من الماستر الجديد.

قد تشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. لضمان العرض والتصدير المتسقين, ثبّت الخطوط المطلوبة, قدّمها عبر [custom font sources](/slides/ar/java/custom-font/), أو اضبط [font substitution](/slides/ar/java/font-substitution/).

هذه سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تحتاج إلى إنشاء تجاوزات سمة يدوية على مستوى الشريحة أو التخطيط.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عندما لا يُعرف الماستر المناسب مسبقًا, احصل عليه من شريحة تمثيلية عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/) و[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/). احفظ مراجع الماستر الأصلية قبل تطبيق أي سمات لأن كل استدعاء يخلق ماسترًا آخر في العرض.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

الاستدعاء الأول يؤثر فقط على الشرائح التي تعتمد على `firstGroupMaster`, والاستدعاء الثاني يؤثر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح التي تنتمي إلى أي ماستر آخر لا يتم إعادة تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر والحفاظ على تصميمها الأصلي, استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/), ثم استنسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/) والماستر المستنسخ. هذا ينقل الماستر وتخطيطاته والسمة المرتبطة معه معًا.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر الوجهة غير المرتبط قد يغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على الماستر والتخطيط الحاليين, ابدأ تجاوزًا على مستوى الشريحة من سمة المصدر. تقوم طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/), و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/) بنسخ المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة, استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

يطبق تجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط, ما لم يكن لدى شريحة معينة تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslidethememanager/):

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

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي, واستخدم تجاوز التخطيط عندما يحتاج عائلة تخطيط واحدة إلى تنسيق مختلف, واستخدم تجاوز الشريحة فقط للحالات الاستثنائية الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة تغييرات السمة العامة لاحقًا أصعب في التنبؤ.

## **تحديث أنماط خلفية السمة**

يتم تخزين تعبئات خلفية السمة في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكبر في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة وإشارات أنماط أخرى.

![معرض أنماط خلفية PowerPoint لسمة العرض](presentation-design_8.png)

قبل استخدام نمط خلفية, افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/). يشير فهرس النمط `0` إلى عدم وجود تعبئة ذات سمة; القيم الإيجابية هي إشارة إلى نمط خلفية السمة. هذا يختلف عن فهرسة مجموعة Java مباشرةً, حيث يعني `get_Item(0)` أول عنصر مخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة, يعيّن إشارة خلفية ذات سمة إلى أول ماستر, ويحفظ العرض:

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

تعتمد النتيجة المرئية على إدخال السمة الذي يشير إليه الماستر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت الشريحة تستخدم خلفية خاصة بها, قد لا يغيّر تغيير خلفية الماستر فقط تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعامل فهرس النمط كفهرس مجموعة يبدأ من الصفر. تجنب أيضًا الترميز الصلب لرقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر; تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية, راجع [Presentation Background](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي نظام تنسيق السمة على مجموعات منفصلة من أنماط التعبئة والخط والتأثير تُكشف عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/), و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). غالبًا ما تحتوي سمات Office النموذجية على ثلاثة إدخالات أساسية تتطابق مرئيًا مع تنسيقات خفيفة, معتدلة, وشديدة, لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات السمة الخفيفة والمتوسطة والشديدة المطبقة على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Java, يكون فهرس المجموعة يبدأ من الصفر: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. مؤشرات إشارة نمط الشكل هي مفهوم منفصل, تُكشف عبر [IShapeStyle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapestyle/). تعديل نمط السمة يؤثر على الأشكال التي تشير إلى ذلك النمط; قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود إدخالات الأنماط المطلوبة, يغيّر نمط الخط الأول, يغيّر نمط التعبئة الثالث, يفعّل ظلًا خارجيًا في نمط التأثير الثالث, ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الخلايا, يصبح نمط الخط الأول للسمة أحمر, والنمط الثالث للتعبئة يصبح أخضر غابي صلب, والنمط الثالث للتأثير يضيف ظلًا خارجيًا بمسافة 10 نقاط. لا يزال النتيجة البصرية الدقيقة تعتمد على الخلايا التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير إعدادات الخط, التعبئة, والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

تخبرك كائنات السمة الخام ما هو معرّف على مستوى معين. تُظهر القيم الفعّالة ما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة, استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). للخلفية, استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/), وللتعبئة, استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعّالة, الخلفية, وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض, التحقق, والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/), قد تفوت تجاوز ماستر أو تخطيط أو شريحة أو شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. تقوم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) بإعادة تعيين فقط الشرائح التي تعتمد على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager] الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة; تستمر الشرائح الأخرى في وراثة سَماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي, استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/). هذا يحافظ على الماستر, التخطيطات, والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط, واستخدم طرق البيانات الفعّالة المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/). تُعيد هذه الواجهات البرمجية القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
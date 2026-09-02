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
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض
- Java
- Aspose.Slides
description: "إدارة سمات العروض في Aspose.Slides لـ Java لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية متسقة."
---
## **Introduction**

تعرف سمة العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملء والخطوط والتأثيرات. تشير الكائنات المدركة للسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، وبالتالي يمكن لتغيير السمة تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، تتاح سمة مستوى العرض عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات سمة في مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية أن يتجاوز سمتها الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). عمليًا، تُحل السمة الفعلية لشريحة ما عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل شائع للسمة: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعلية بعد حل وراثة وتجاوزات السمة.

## **Inspect a Theme**

كائن [MasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/) يُظهر مخطط ألوان السمة، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mastertheme/). يكون فحص هذه المجموعات قبل تعديلها مفيدًا خاصةً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات النمط قد يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويُبلغ عن عدد أنماط الخلفية، الملء، الخط، والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم أكثر من ماستر، لا تفترض أن كل شريحة لديها نفس السمة الفعلية. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعلية الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات تخطيط أو شريحة.

## **Change Theme Colors**

يمكن للملء، الخطوط، والنصوص المستندة إلى السمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/)، تُحل جميع الكائنات التي لا زالت تشير إلى ذلك اللون السمة مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير من خلال تحديث لون السمة.

المثال التالي end-to-end يُنشئ شكلًا يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يفتحّه مرة أخرى، ويطبع لون الملء الفعلي:

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

لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تعديل السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على ذلك الملء.

### **Use Colors from the Additional Palette**

يستخرج PowerPoint متغيرات أفتح وأكثر قتامة من لون السمة عن طريق تطبيق تحويلات اللون. تُظهر Aspose.Slides هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية.  
**2** - المتغيرات الفاتحة والداكنة المنتجة من ألوان السمة الرئيسية.

المثال التالي يُنشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتغيرات معتمدة على لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المُحوَّلة من القيمة الجديدة لـ `Accent4`.

### **Map `SchemeColor` Values to `IColorScheme` Slots**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا يتم تحويلها ديناميكيًا من شكل إلى آخر.

## **Change Theme Fonts**

يحتوي مخطط خط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر طريقتا [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) تلك المجموعات.

يمكن استخدام معرّفات خطوط سمة متوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - الخط الأساسي اللاتيني (خط لاتيني ثانوي)
* `+mj-lt` - خط العنوان اللاتيني (خط لاتيني رئيسي)
* `+mn-ea` - الخط الأساسي الآسيوي الشرقي (خط آسيوي شرقي ثانوي)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (خط آسيوي شرقي رئيسي)

المثال التالي يُنشئ عنوانًا واحدًا يستخدم الخط اللاتيني الرئيسي وخطًا نصيًا واحدًا يستخدم الخط اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرّف سمة لن يتحول تلقائيًا عندما تتغير مخط طب الخط السمة.

يمكن لمجموعات الخطوط الرئيسية والثانوية أيضًا أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السيرية، العربية، اليابانية، الجورجية، والثانا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، انظر [Script-Specific Theme Fonts](/slides/ar/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، انظر [PowerPoint Fonts](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

## **Copy or Apply a Theme**

تُحل سير العمل أدناه مشاكل مختلفة مرتبطة بالسمة.

### **Apply an External Theme to a Master's Dependent Slides**

استخدم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) التي تُنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تُجري الطريقة العمليات التالية:

1. تنشئ شريحة ماستر جديدة بناءً على الماستر المختار.  
1. تُطبق السمة الخارجية على الماستر الجديد.  
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد على الماستر المختار.  
1. تُعيد الـ [IMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) المُنشأ حديثًا.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على أول ماستر ويحفظ العرض:

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

قد يتسبب سمة غير صالحة أو فاسدة أو غير مدعومة في حدوث [PptxReadException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يُدخلها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد فقط تعيين الشرائح التي كانت تعتمد على الماستر المختار. الشرائح المرتبطة بماسترات أخرى تحتفظ بالماستر والسمة الحالية. تُحل الألوان، الخطوط، الملء، الخطوط، الخلفيات، والتأثيرات المدركة للسمة مقابل السمة الخارجية. قد تظل الألوان، الخطوط، الملء، وغيرها من التنسيقات الصريحة غير متغيّرة. يمكن لتجاوزات مستوى التخطيط ومستوى الشريحة أن تتفوق أيضًا على القيم الموروثة من الماستر الجديد.

قد تُشير السمة إلى خطوط غير متوفرة في بيئة التنفيذ. لضمان عرض وتصدير متسق، قم بتثبيت الخطوط المطلوبة، أو وفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/java/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/java/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تُقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدويًا.

### **Apply Different External Themes in a Multi-Master Presentation**

عندما لا يُعرف الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/) و[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد معالمهم ويطبق سمة خارجية مختلفة على كل مجموعة:

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

النداء الأول يؤثر فقط على الشرائح التي تعتمد على `firstGroupMaster`، والنداء الثاني يؤثر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح التي تنتمي إلى أي ماستر آخر لا تُعاد تنسيقها.

### **Preserve a Source Theme When Moving Slides**

إذا رغبت في نقل شريحة إلى عرض آخر والحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/) والماستر المستنسخ. يحمل هذا الماستر وتخطيطاته والسمة المرتبطة به معًا.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى إلى ماستر وجهة غير مرتبط قد يغيّر ألوان، خطوط، خلفيات، وتأثيرات السمة.

### **Apply Theme Values to an Existing Slide**

إذا كان على الشريحة الهدف البقاء على ماسترها وتخطيطها الحالي، ابدأ تجاوزًا على مستوى الشريحة من السمة المصدر. تُنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/) المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

يغيّر هذا السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/overridetheme/).

### **Apply a Theme Override to a Layout**

تطبيق التجاوز على مستوى التخطيط يُطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تُجرِ شريحة معينة تجاوزها الخاص. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslidethememanager/):

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

استخدم سمة ماستر أو سمة مستوى العرض عندما تحتاج العديد من التخطيطات والشرائح إلى مشاركة نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة تغييرات السمة العامة اللاحقة أصعب في التنبؤ.

## **Update Theme Background Styles**

تُخزن ملء خلفيات السمة في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات الملء المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج ملء السمة بألوان السمة ومراجع نمط أخرى.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/). مؤشر النمط `0` يعني عدم وجود ملء مُمَثَّل بسمة؛ القيم الموجبة تشير إلى مراجع أنماط خلفية السمة. هذا مختلف عن فهرسة مجموعة Java مباشرةً، حيث يعني `get_Item(0)` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

المثال التالي يُبلغ عن عدد ملء الخلفيات المتاح، يُعيّن مرجع خلفية مُمَثَّل بسمة للماستر الأول، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على إدخال السمة الذي يُشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تُعامل مؤشر النمط كفهرس مجموعة يبدأ من الصفر. تجنّب أيضًا ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات نمط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
لتنسيق الخلفية المباشر ووراثة الخلفية، راجع [Presentation Background](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **Update Theme Effects**

يحتوي مخطط تنسيق السمة على مجموعات منفصلة للملء، الخط، وأسلوب التأثير تُعرض عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iformatscheme/). غالبًا ما تحتوي سمات Office النموذجية على ثلاثة مدخلات أساسية تتCorrespond بصريًا إلى تنسيقات خفيفة، معتدلة، وشديدة، لكن يجب على الكود فحص كل مجموعة بدلًا من افتراض عدد ثابت.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Java، يكون فهرس المجموعة يبدأ من الصفر: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، تُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تُشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط الملء الثالث، يفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح نمط الخط السمة الأول أحمر، ونمط الملء السمة الثالث يصبح أخضر غامق صلب، ونمط التأثير الثالث يضيف ظلًا خارجيًا بمسافة 10 نقاط. لا يزال الناتج البصري يعتمد على أي فِتحات نمط كل شكل يُشير إليها وما إذا كان التنسيق المباشر يتجاوز السمة.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Determine Whether an Effective Solid Fill Uses a Theme Color**

يمكن أن يُخزن الملء مباشرةً على كائن أو يُورّث من فقرة أو تخطيط أو ماستر أو نمط سمة أو مستوى تنسيق آخر. استدعِ [IFillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformat/) لحل تلك السلسلة إلى [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformateffectivedata/) غير قابل للتغيير. أولًا افحص [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformateffectivedata/). عندما يكون `FillType.Solid` فقط، يجب قراءة خصائص الملء الصلب.

بالنسبة للملء الصلب، تُعيد [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformateffectivedata/) القيمة النهائية لـ RGB بعد تطبيق الوراثة، والبحث في السمة، وتحويلات اللون. تُعيد [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformateffectivedata/) الفتحة المنطقية لـ [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/) المقابلة، مثل `Text1` أو `Accent6`. القيمة `SchemeColor.NotDefined` تعني أن الملء الصلب الفعلي ليس مستندًا إلى لون مخطط. في سير عمل حيث تكون الملء إما ألوان سمة أو ألوان RGB مباشرة، تُحدّد هذه القيمة ملء RGB مباشر.

لا تستخدم قيمة [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorformat/) المحلية بمفردها لتصنيف ملء. على سبيل المثال، قد لا يحتوي جزء نص على لون مخطط مُعرّف محليًا، لذا تكون قيمته المحلية `NotDefined`، بينما يرث ملءه الفعال لون سمة ويُحل إلى `Text1` أو `Accent6`. بالمقابل، تُخبرك `getSolidFillSchemeColor` أي فتحة سمة منطقية أنتجت اللون الفعلي، لكنها لا تُظهر ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر من سلالة التنسيق.

المثال التالي يحمل عرضًا، يراجع كل ملء شكل وملء جزء نص، يطبع كل قيمة RGB نهائية واللون المخطط المرتبط، ويُعلّم الملء الصلب الذي لن يتتبع تغييرات ألوان السمة:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

الفَرْع `NotDefined` يُوفر قائمة تدقيق للملء الصلب الذي لن يستجيب لتغييرات فتحات ألوان السمة. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا تزال قيمة RGB المبلّغ عنها تُظهر المظهر الحالي، بينما يوضح قيمة المخطط ما إذا كان هذا المظهر مرتبطًا بالسمة.

الكائنات الفعّالة هي لقطات. بعد تغيير سمة العرض أو تجاوز سمة أو أي تنسيق مُورَّث، استدعِ `getEffective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل مقارنة أو تقرير الألوان.

## **Read Effective Theme Values**

تُخبرك كائنات السمة الخام ما تم تعريفه في مستوى معين. تُظهر القيم الفعّالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/)، وللملء، استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعّالة، والخلفية، والملء لأول شكل من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، قد تفوتك ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **FAQ**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. تُعيد [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسماها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidethememanager/) للشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/). سيبقي هذا الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط، والطُرُق المقابلة للبيانات الفعّالة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المُحلَّة بعد تطبيق الوراثة والتجاوزات.
---
title: إدارة أنماط العروض التقديمية على Android
linktitle: نمط العرض التقديمي
type: docs
weight: 10
url: /ar/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "إدارة أنماط العروض التقديمية في Aspose.Slides لنظام Android عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
## **المقدمة**

يحدد نمط العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملء والخطوط والتأثيرات. تشير الكائنات التي تدعم النمط إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية مرئية كقيمة ثابتة، وبالتالي يمكن لتغيير النمط تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، يتوفر نمط مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات للنمط في مستويات أدنى. يمكن للماستر تجاوز نمط العرض من خلال [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية تجاوز النمط الموروث من خلال [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/). عمليًا، يتم حل النمط الفعّال لشريحة عبر سلسلة الوراثة هذه: نمط العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات النمط: الألوان والخطوط وأنماط الخلفية والتأثيرات](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل شائع للنمط: فحص النمط، تغيير الألوان والخطوط، نسخ أو تطبيق نمط، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص النمط**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/) مخطط ألوان النمط، ومخطط الخطوط، ومخطط الصيغ عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد خاصة عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مداخل الأنماط قد يختلف.

المثال التالي يقرأ خصائص النمط الرئيسي ويبلغ عن عدد أنماط الخلفية، والملء، والخط، والتأثير المخزنة في النمط:

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

إذا كان الملف يستخدم العديد من الماسترات، لا تفترض أن كل شريحة لها نفس النمط الفعّال. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل النمط الفعّال الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان النمط**

يمكن للملء، والخطوط، والنصوص الواعية للنمط أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/)، تُعاد حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون النمطي وفق القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون النمط.

المثال التالي من البداية إلى النهاية ينشئ شكلًا يستخدم `Accent4`، يغير لون `Accent4` في النمط إلى الأحمر، يحفظ العرض، يفتحه مرة أخرى، ويطبع لون الملء الفعّال:

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

لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير النمط. إذا استبدلت لون المخطط بلون مباشر على الشكل، سيتوقف التغيّر اللاحق لـ `Accent4` عن التأثير على ذلك الملء.

### **استخدام الألوان من لوحة الألوان الإضافية**

PowerPoint يستخرج متغيرات أفتح وأغمق من لون النمط بتطبيق تحولات لونية. Aspose.Slides يكشف عن هذه التحولات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/colortransformoperation/).

![الألوان الرئيسية للنمط والألوان الفاتحة والغامقة المولدة من لوحة الألوان الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للنمط.

**2** - المتغيرات الفاتحة والغامقة المستخرجة من الألوان الرئيسية للنمط.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

هذه المتغيرات لا تزال مستندة إلى لون النمط. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المُحوَّلة وفق القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بالفتحات في `IColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/) نفس فتحات النمط كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. التوافق ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات النمط؛ ليست قيمًا يتم تحويلها ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط النمط**

مخطط خطوط النمط يحتوي على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. طُرُق [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/) تكشف عن تلك المجموعات.

يمكن استخدام معرفات خطوط النمط المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (خط لاتيني فرعي)
* `+mj-lt` - خط العنوان اللاتيني (خط لاتيني رئيسي)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي فرعي)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (خط آسيوي شرقي رئيسي)

المثال التالي ينشئ عنوانًا يستخدم خط النمط اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط النمط اللاتيني الفرعي. بعد ذلك يغيّر خطوط النمط ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف النمط لن يتغير تلقائيًا عندما يتغير مخطط خطوط النمط.

يمكن لمجموعات الخطوط الرئيسية والفرعية أن تحتوي أيضًا على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، والعربية، واليابانية، والجورجية، والثآنا. لفحص أو إضافة أو استبدال أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق نمط**

تُحل سير العمل أدناه مشكلات مختلفة متعلقة بالنمط.

### **تطبيق نمط خارجي على الشرائح التابعة للماستر**

استخدم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) عندما يكون لديك ملف نمط PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) التي تنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/)، ومرّر مسار ملف النمط إلى الطريقة.

تقوم الطريقة بالعمليات التالية:

1. تنشئ ماستر شريحة جديد بناءً على الماستر المختار.
1. تطبق النمط الخارجي على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد على الماستر المختار مسبقًا.
1. ترجع كائن [IMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يطبق نمطًا خارجيًا على الشرائح التي تعتمد على أول ماستر ويحفظ العرض:

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

قد يتسبب نمط غير صالح أو تالف أو غير مدعوم في حدوث استثناء [PptxReadException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يقدمها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق النمط بنجاح.

فقط الشرائح التي كانت تعتمد على الماستر المختار يتم إعادة تعيينها. الشرائح المرتبطة بغيره من الماسترات تحتفظ بالماسترات والنُسق الحالية. تُحل الألوان، الخطوط، الملء، الخطوط، الخلفيات، والتأثيرات الواعية للنمط وفق النمط الخارجي. قد تظل الألوان، الخطوط، الملء، وغيرها من التنسيقات الصريحة دون تغيير. يمكن لتجاوزات مستوى التخطيط أو الشريحة أيضًا أن تتفوق على القيم الموروثة من الماستر الجديد.

قد يشير النمط إلى خطوط غير متوفرة في بيئة التشغيل. للحصول على عرض وتصدير ثابت، قم بتثبيت الخطوط المطلوبة، أو وفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/androidjava/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/androidjava/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: الطريقة تقبل مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات نمط على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق أنماط خارجية مختلفة في عرض متعدد الماسترات**

عندما لا يكون الماستر المناسب معروفًا مسبقًا، احصل عليه من شريحة تمثيلية عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/) و[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي نمط لأن كل استدعاء ينشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماسترهم ويطبق نمطًا خارجيًا مختلفًا على كل مجموعة:

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

الاستدعاء الأول يؤثر فقط على الشرائح التي تعتمد على `firstGroupMaster`، والاستدعاء الثاني يؤثر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح التي تنتمي إلى أي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على نمط المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/) مع الماستر المستنسخ. هذا يحمل الماستر، وتخطيطاته، والنمط المرتبط معه معًا.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد نسخ المحتوى إلى ماستر غير متعلق قد يغيّر ألوان، خطوط، خلفيات، وتأثيرات النمط.

### **تطبيق قيم النمط على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على ماسترها وتخطيطها الحالي، ابدئ تجاوزًا على مستوى الشريحة من النمط المصدر. تُنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/) المكونات الثلاثة الرئيسية للنمط إلى التجاوز.

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

هذا يغيّر النمط المستخدم لتلك الشريحة دون تعديل النمط الموروث من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز النمط على تخطيط**

تجاوز على مستوى التخطيط يُطبق على الشرائح التي تستخدم ذلك التخطيط، إلا إذا كان للشفرة استبدال خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslidethememanager/):

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

استخدم نمطًا على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما يحتاج عائلة تخطيط إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. وجود تجاوزات كثيرة على مستوى الشريحة يجعل تعديل النمط العام لاحقًا أصعب في التنبؤ.

## **تحديث أنماط خلفية النمط**

تُخزن ملء خلفيات النمط في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مما يُخزن فعليًا من تعريفات ملء في هذه المجموعة، لأن الواجهة يمكنها دمج ملء النمط مع ألوان النمط ومراجع أنماط أخرى.

![معرض أنماط خلفية PowerPoint لنمط عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/). مؤشر النمط `0` يعني عدم وجود ملء نمطي؛ القيم الموجبة هي مراجع أنماط خلفية النمط. هذا يختلف عن الفهرسة المباشرة لمجموعة Java حيث يعني `get_Item(0)` أول عنصر مخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

المثال التالي يبلغ عن عدد ملء الخلفية المتاحة، يعيّن مرجع خلفية نمطي للماستر الأول، ويحفظ العرض:

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

النتيجة الظاهرية تعتمد على مدخل النمط الذي يشير إليه الماستر وأية تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت شريحة تستخدم خلفية خاصة بها، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تُعامل مؤشر النمط كفهرس مجموعة يبدأ من الصفر. وتجنب أيضًا ترميز رقم نمط من ملف واحد واعتقاده أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات نمط العرض خاصة بالعرض نفسه.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية والوراثة، راجع [Presentation Background](/slides/ar/androidjava/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات النمط**

يحتوي مخطط صيغ النمط على مجموعات منفصلة للملء، الخط، وتأثير الصيغة تُعرض عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/). غالبًا ما تحتوي الأنماط المكتبية على ثلاثة مداخل رئيسية تتطابق بصريًا مع تنسيقات خفيفة، معتدلة، وشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات النمط الخفيفة والمتوسطة والشديدة المطبقة على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Java، يكون فهرس المجموعة يبدأ من الصفر: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. فهارس مرجع النمط للشكل مفهوم منفصل، يُعرَض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapestyle/). تعديل نمط النمط يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود المداخل المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط الملء الثالث، يُفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط للنمط أحمر، ويصبح ثالث نمط ملء للنمط أخضر غابي صلب، ويضيف نمط التأثير الثالث ظلًا خارجيًا بمقدار 10 نقاط. لا يزال المظهر الفعلي يعتمد على الفتحات التي يشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز النمط.

## **تحديد ما إذا كان الملء الصلب الفعلي يستخدم لون نمط**

يمكن أن يُخزن الملء إما مباشرة على كائن أو يُورث من فقرة أو تخطيط أو ماستر أو نمط أو مستوى تنسيق آخر. استدعِ [IFillFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformat/) لحل تلك السلسلة إلى كائن غير قابل للتغيير [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/). أولًا تحقق من [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/). فقط عندما تكون `FillType.Solid` يجب قراءة خصائص الملء الصلب.

بالنسبة للملء الصلب، تُرجع [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/) القيمة النهائية للـ RGB بعد الوراثة، والبحث في النمط، وتطبيق التحولات اللونية. تُرجع [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/) فتحة [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/) المنطقية المقابلة، مثل `Text1` أو `Accent6`. القيمة `SchemeColor.NotDefined` تعني أن الملء الصلب الفعلي ليس مبنيًا على لون مخطط. في سير عمل يكون فيه الملء إما ألوان نمط أو ألوان RGB مباشرة، تحدد هذه القيمة ملءً مباشرًا بـ RGB.

لا تستخدم قيمة [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorformat/) المحلية وحدها لتصنيف الملء. فمثلاً قد لا يحتوي جزء نص على لون مخطط معرف محليًا، لذا تكون قيمته المحلية `NotDefined`، بينما يرث ملءه الفعلي لون نمط ويُحل إلى `Text1` أو `Accent6`. على العكس، تُخبرك `getSolidFillSchemeColor` أي فتحة نمط منطقية أنتجت اللون الفعلي، لكنها لا تخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر في شجرة التنسيق.

المثال التالي يحمل عرضًا، يدقق كل ملء للأشكال وملء أجزاء النص، يطبع كل قيمة RGB نهائية واللون المخطط المرتبط، ويُعلِم الملء الصلب الذي لن يتتبع تغيّر ألوان النمط:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
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

الفرع `NotDefined` يُوفر قائمة تدقيق للملء الصلب الذي لن يستجيب لتغيّر فتحات ألوان النمط. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا تزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما يوضح قيمة المخطط ما إذا كان هذا المظهر مرتبطًا بالنمط.

الكائنات الفعّالة هي لقطات. بعد تغيير نمط العرض أو تجاوز النمط أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم النمط الفعّالة**

تُظهر كائنات النمط الخام ما تم تعريفه على مستوى معين. القيم الفعّالة تُظهر ما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/)، وللملء استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/).

المثال التالي يقرأ النمط الفعّال، الخلفية، وملء الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة للتشخيص، والتحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، قد تفوتك أي تجاوز ماستر أو تخطيط أو شريحة أو شكل يُغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل تطبيق نمط خارجي يؤثر على كل شريحة في العرض؟**

لا. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) يعيد تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بأنماطها الحالية.

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidethememanager/) الخاص بالشريحة وابدأ بإنشاء تجاوز النمط لها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة أنماطها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل نمط من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، انسخ الماستر المصدر إلى الوجهة وانسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/). يظل الماستر، وتخطيطاته، والنمط معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/) للنمط الخاص بشريحة أو تخطيط وطرق البيانات الفعّالة المقابلة لكائنات الصيغة مثل [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
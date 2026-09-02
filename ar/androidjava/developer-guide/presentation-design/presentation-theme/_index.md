---
title: إدارة سمة العرض على Android
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
- سمة خارجية
- THMX
- لون السمة
- لوحة إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- العرض
- Android
- Java
- Aspose.Slides
description: "إدارة سَمات العروض الرئيسية في Aspose.Slides لنظام Android عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على الهوية التجارية المتسقة."
---
## **المقدمة**

يحدد موضوع العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والتعبئات والخطوط والتأثيرات. تشير الكائنات المدركة للموضوع إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، بحيث يمكن لتغيير الموضوع تحديث العديد من الكائنات في آنٍ واحد.

في Aspose.Slides، يتوفر موضوع مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). يمكن أن يحتوي العرض أيضًا على تجاوزات للموضوع في مستويات أدنى. يمكن للماستر تجاوز موضوع العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterthememanager/)، بينما يمكن لتخطيط أو شريحة فردية تجاوز موضوعها الموروث عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/). عمليًا، يتم حل الموضوع الفعلي للشريحة عبر سلسلة الإرث هذه: موضوع العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات الموضوع: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل شائع للموضوع: فحص موضوع، تغيير الألوان والخطوط، نسخ أو تطبيق موضوع، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعالة بعد حل الإرث والتجاوزات.

## **فحص موضوع**

كائن [MasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/) يعرض مخطط ألوان الموضوع، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mastertheme/). فحص هذه التجميعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للموضوع ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في الموضوع:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس الموضوع الفعلي. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل الموضوع الفعال الموضح لاحقًا في هذا المقال عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان الموضوع**

يمكن أن تشير التعبئات والخطوط والنصوص المدركة للموضوع إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون الثيم إلى القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون الثيم.

المثال التالي من البداية إلى النهاية ينشئ شكلًا يستخدم `Accent4`، يغيّر لون `Accent4` في الموضوع إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون التعبئة الفعلي:

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

نظرًا لأن المستطيل يظل مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير الموضوع. إذا استبدلت لون المخطط بلون مباشر على الشكل، لن تؤثر التغييرات اللاحقة على `Accent4` على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

يستخلص PowerPoint تدرجات أخف وأغمق من لون الموضوع بتطبيق تحويلات اللون. تعرض Aspose.Slides هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/colortransformoperation/).

![الألوان الرئيسية للموضوع والألوان الأخف والأغمق المُولَّدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للموضوع.  
**2** - التدرجات الأخف والأغمق المُنتجة من الألوان الرئيسية للموضوع.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

هذه التدرجات تبقى مستندة إلى لون الموضوع. إذا تغير `Accent4` لاحقًا، يتم إعادة حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **تطابق قيم `SchemeColor` مع خانات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يعرض [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/) نفس خانات الموضوع كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. التطابق ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس خانات الموضوع؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط الموضوع**

يتضمن مخطط خطوط الموضوع مجموعة خطوط رئيسية لعناوين الصفحات ومجموعة خطوط ثانوية لنص الجسم. تكشف الطريقتان [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/) عن هاتين المجموعتين.

يمكن استخدام معرفات خطوط موضوع متوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط الجسم لاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان لاتيني (Major Latin Font)
* `+mn-ea` - خط الجسم شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم الخط اللاتيني الرئيسي وخطًا للنص الجسدي يستخدم الخط اللاتيني الثانوي. ثم يغيّر خطوط الموضوع ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الجسدي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف موضوع لن يتغيّر تلقائيًا عندما يتغير مخطط خطوط الموضوع.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والثانوية أيضًا على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثعانية. لتفقد أو إضافة أو استبدال أو إزالة هذه التعيينات، راجع [خطوط الموضوع الخاصة بالسكريبت](/slides/ar/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق موضوع**

تحل سير العمل أدناه مشكلات مختلفة متعلقة بالموضوع.

### **تطبيق موضوع خارجي على الشرائح التابعة للماستر**

استخدم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) عندما يكون لديك ملف موضوع PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من تجميع [Presentation.getMasters](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، الذي يطبق [IMasterSlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/)، ومرّر مسار ملف الموضوع إلى الطريقة.

تقوم الطريقة بالعمليات التالية:

1. تنشئ شريحة ماستر جديدة بناءً على الماستر المختار.  
1. تطبق الموضوع الخارجي على الماستر الجديد.  
1. تُعين الماستر الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الماستر المختار.  
1. ترجع الكائن [IMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) الجديد.

المثال التالي يطبق موضوعًا خارجيًا على الشرائح التي تعتمد على الماستر الأول ويحفظ العرض:

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

قد يتسبب موضوع غير صالح أو فاسد أو غير مدعوم في حدوث [PptxReadException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يقدمها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق الموضوع بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المختار فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بالماسترات والموضوعات الحالية. تُحل الألوان والخطوط والتعبئات والخطوط الخلفية والتأثيرات المدركة للموضوع مقابل الموضوع الخارجي. قد تبقى الألوان والخطوط والتعبئات والتنسيق الصريح المعين مباشرةً دون تغيير. يمكن لتجاوزات المستوى التخطيطي والمستوى الشريحي أيضًا أن تتفوق على القيم الموروثة من الماستر الجديد.

قد يشير الموضوع إلى خطوط غير متوفرة في بيئة التشغيل. لضمان عرض وتصدير ثابتين، قم بتثبيت الخطوط المطلوبة، أو وفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/androidjava/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/androidjava/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تحتاج إلى إنشاء تجاوزات موضوع على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق موضوعات خارجية مختلفة في عرض متعدد الماسترات**

عند عدم معرفة الماستر ذي الصلة مسبقًا، احصل عليه من شريحة تمثيلية عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/) و[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي موضوع لأن كل استدعاء ينشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويطبق موضوعًا خارجيًا مختلفًا لكل مجموعة:

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

### **الحفاظ على موضوع المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على التصميم الأصلي، استنساخ الماستر المصدر في العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/) والماستر المستنسخ. ينقل هذا الماستر وتخطيطاته والموضوع المرتبط معه بالكامل.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى إلى ماستر وجهة غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالموضوع.

### **تطبيق قيم الموضوع على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على الماستر والتخطيط الحاليين، قم بتهيئة تجاوز على مستوى الشريحة من الموضوع المصدر. تنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/) المكونات الثلاثة الرئيسية للموضوع إلى التجاوز.

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

هذا يغيّر الموضوع المستخدم لتلك الشريحة دون تغيير الموضوع الموروث من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز موضوع على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslidethememanager/):

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

استخدم موضوعًا على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط في حالات الاستثناء الحقيقية. تجعل التجاوزات الزائدة على مستوى الشريحة التغييرات العالمية للموضوع لاحقًا أصعب في التنبؤ.

## **تحديث أنماط خلفية الموضوع**

تُخزن تعبئات خلفية الموضوع في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint تقديم المزيد من خيارات الخلفية في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذا التجميع، لأن الواجهة يمكنها دمج تعبئات الموضوع مع ألوان الموضوع ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لموضوع العرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص التجميع المخزن والمؤشر الحالي عبر [Background.getStyleIndex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/). قيمة المؤشر `0` تعني عدم وجود تعبئة موضوعية؛ القيم الموجبة هي مراجع لأنماط خلفية الموضوع. هذا يختلف عن فهرسة التجميع Java مباشرةً، حيث يعني `get_Item(0)` العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية موضوعية للماستر الأول، ويحفظ العرض:

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

النتيجة المرئية تعتمد على المدخل الموضوعي الذي يشيره الماستر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/) عندما تحتاج لمعرفة الخلفية النهائية بعد تطبيق الإرث.

{{% alert color="warning" title="تحذير" %}}
لا تعامل مؤشر النمط كفهرس تجميع صفر‑قائم. تجنّب أيضًا ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات أنماط الموضوع خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
للتنسيق المباشر للخلفية وإرث الخلفية، راجع [خلفية العرض](/slides/ar/androidjava/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات الموضوع**

يحتوي مخطط تنسيق الموضوع على تجميعات منفصلة للتعبئة والخط وتأثيرات الأنماط، يتم كشفها عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iformatscheme/). غالبًا ما تحتوي موضوعات Office النموذجية على ثلاث مدخلات أساسية تتطابق بصريًا مع تنسيقات دقيقة، ومتوسطة، ومكثفة، لكن يجب على الكود فحص كل تجميع بدلاً من افتراض عدد ثابت.

![تأثيرات موضوع دقيقة، متوسطة، ومكثفة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه التجميعات في Java، يكون فهرس التجميع صفر‑قائم: `get_Item(0)` هو النمط المخزن الأول و`get_Item(2)` هو الثالث. مؤشرات مرجع النمط للشكل مفهوم منفصل، تُكشف عبر [IShapeStyle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapestyle/). تعديل نمط موضوع يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال التي لها تنسيق مباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الخانات، يصبح أول نمط خط موضوع أحمر، والثالث نمط تعبئة موضوع أخضر غابي صلب، والثالث نمط تأثير يضيف ظلًا خارجيًا بمسافة 10 نقاط. لا يزال الشكل النهائي يعتمد على الخانات التي يشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز الموضوع.

![أنماط تأثيرات الموضوع بعد تعديل الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **قراءة قيم الموضوع الفعالة**

توفر كائنات الموضوع الخام ما تم تعريفه على مستوى معين. القيم الفعالة تخبرك بما يستخدمه الشريحة أو الشكل فعليًا بعد حل الإرث والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/)، وللتعبئة، استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/).

المثال التالي يقرأ الموضوع الفعال، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعالة لتشخيص العرض، والتحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، قد تفوتك تجاوزات ماستر أو تخطيط أو شريحة أو شكل تغير المظهر النهائي.

## **الأسئلة الشائعة**

**هل يؤثر تطبيق موضوع خارجي على كل شريحة في العرض؟**

لا. تقوم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) بإعادة تعيين فقط الشرائح التي تعتمد على الماستر المختار. الشرائح التي تستخدم ماسترات أخرى تحتفظ بموضوعاتها الحالية.

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidethememanager/) للشريحة وابدأ موضوع التجاوز الخاص بها. يبقى التغيير محليًا لتلك الشريحة؛ تظل الشرائح الأخرى ترث موضوعاتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل موضوع من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة ثم استنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/). يحافظ هذا على الماستر والتخطيطات والموضوع معًا.

**كيف يمكنني رؤية القيم الفعالة بعد الإرث والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseoverridethememanager/) لموضوع شريحة أو تخطيط، والطُرُق الفعالة المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلَّلة بعد تطبيق الإرث والتجاوزات.
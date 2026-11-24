---
title: إدارة سمات العروض التقديمية في جافا
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
- عرض تقديمي
- Java
- Aspose.Slides
description: "سمات العروض التقديمية الرئيسية في Aspose.Slides for Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتناسقة."
---
## **المقدمة**

تحدد سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. الكائنات المدركة للسمة تشير إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، سمة مستوى العرض متاحة عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات سمة في مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/)، بينما يمكن لتخطيط أو شريحة فردية تجاوز سمتها الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). عمليًا، يتم حل السمة الفعالة لشريحة عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل السمة شيوعًا: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

الكائن [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) يُظهر مخطط ألوان السمة، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد خصوصًا عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط يمكن أن يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعالة الموضح لاحقًا في هذا المقال عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

التعبئات، الخطوط، والنصوص المدركة للسمة يمكنها الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/)، جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمة تُحل وفق القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

المثال التالي المتكامل يُنشئ شكلًا يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يُعيد فتحه، ويطبع لون التعبئة الفعلي:

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

نظرًا لأن المستطيل ما زال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على ذلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

تُشتق PowerPoint متغيرات أفتح وأغمق من لون السمة عبر تطبيق تحويلات اللون. Aspose.Slides ي expose هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية.

**2** - متغيرات أفتح وأغمق مُنتجة من ألوان السمة الرئيسية.

المثال التالي يُنشئ ستة مستطيلات مستندة إلى `Accent4`، يطبق تحويلات الإنارة على خمسة منها، ويحفظ النتيجة:

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

هذه المتغيرات تبقى مستندة إلى لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفِتحات `IColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) نفس فِتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فِتحات السمة؛ ليست قيمًا تُحول ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

مخطط خطوط السمة يحتوي على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. طُرق [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) تُظهر تلك المجموعات.

يمكن استخدام مُعرّفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي شرق آسيا (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيا (Major East Asian Font)
* `+mn-cs` - خط النص الأساسي النص المعقد (Minor Complex Script Font)
* `+mj-cs` - خط العنوان النص المعقد (Major Complex Script Font)

المثال التالي يُنشئ عنوانًا واحدًا يستخدم خط السمة اللاتيني الرئيسي وخطًا أساسيًا واحدًا يستخدم خط السمة اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من مُعرّف سمة لن يتحول تلقائيًا عندما يتغير مخطط خطوط السمة.

يمكن لمجموعات الخطوط الرئيسية والثانوية أيضًا أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السيران، العربية، اليابانية، الجورجية، والثعنا. للفحص، الإضافة، الاستبدال، أو الإزالة، راجع [خطوط السمة الخاصة بالسكريبت](/slides/ar/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

### **حل مراجع خطوط السمة**

عند فحص النص، قد تُعيد [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) مرجع سمة مثل `+mn-lt` بدلًا من اسم عائلة الخط. استدعِ [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) مع [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) المناسب لحل هذا المرجع. البادئان `+mj` و`+mn` يحددان مجموعات الخطوط الرئيسية والثانوية؛ واللاحقان `-lt`، `-ea`، و`-cs` يحددان الخطوط اللاتينية، شرق آسيا، والنص المعقد على التوالي.

احصل على السمة الفعالة عبر [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) على الكائن الذي تُطبّق سمتّه على النص المفحوص. بالنسبة للنص العادي على شريحة، استدعِ هذه الطريقة على الشريحة بحيث يشتمل السياق على السمة الموروثة لتلك الشريحة وتجاوزاتها المحلية. عند فحص تخطيط أو ماستر نفسه، استخدم سمةه الفعالة. لا تفترض أن سمة الماستر الأول تنطبق على كل الشرائح.

المثال التالي يُنشئ جزء نصي يُشير صراحةً إلى الخط اللاتيني الثانوي. يُهيئ مخطط خطوط الشريحة عبر [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) ويضبط عائلتي الخطوط اللاتينية الرئيسية والثانوية إلى `Arial` و`Calibri`، مما يجعل النتيجة قابلة لإعادة الإنتاج دون ملف إدخال.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

الناتج هو `+mn-lt -> Calibri` يليه `Verdana -> Verdana`. يبقى المرجع المخزن دون تغيير، بينما يُعاد إرجاع اسم العائلة الصريح كما هو. إذا كان الجزء يستخدم `+mj-lt`، لكان سيُحل إلى `Arial` في هذه السمة.

حل مرجع السمة يُحدّد عائلة الخط المحددة بواسطة السمة. لا يتحقق من توفر الخط أو يحدد ملف الخط المستخدم نهائيًا بعد الاستبدال أو fallback للرموز أثناء العرض. راجع [تسلسل اختيار الخط](/slides/ar/java/font-selection-sequence/) و[استبدال الخط](/slides/ar/java/font-substitution/) لتلك الخطوات المنفصلة.

## **نسخ أو تطبيق سمة**

تحل سير عمل أدناه مشكلات مختلفة تتعلق بالسمة.

### **تطبيق سمة خارجية على شرائح تعتمد على ماستر**

استخدم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) التي تُنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تُجري الطريقة العمليات التالية:

1. تُنشئ شريحة ماستر جديدة بناءً على الماستر المحدد.
1. تُطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد على الماستر المحدد مسبقًا.
1. تُعيد [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) المُنشأ حديثًا.

المثال التالي يُطبق سمة خارجية على الشرائح التي تعتمد على الماستر الأول ويحفظ العرض:

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

سمة غير صالحة، فاسدة، أو غير مدعومة قد تتسبب في [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/). تحقق من المسارات التي يوردها المستخدمون، عالج فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

فقط الشرائح التي كانت تعتمد على الماستر المحدد تُعاد تعيينها. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها وسماها الحالية. تُحل الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات المدركة للسمة مقابل السمة الخارجية. قد تظل الألوان، الخطوط، التعبئات، والتنسيق الصريح المعيّن مباشرةً دون تغيير. يمكن لتجاوزات مستوى التخطيط أو الشريحة أيضًا أن تتفوق على القيم الموروثة من الماستر الجديد.

قد تشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. لتضمن عرضًا وتصديرًا ثابتًا، ثبّت الخطوط المطلوبة، قدّمها عبر [مصادر خطوط مخصصة](/slides/ar/java/custom-font/)، أو اضبط [استبدال الخط](/slides/ar/java/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: الطريقة تقبل مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عند عدم معرفة الماستر الملائم مسبقًا، احصل عليه من شريحة تمثيلية عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) و[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من مقسمين لتحديد ماستراتها ويطبق سمة خارجية مختلفة على كل مجموعة:

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

الاستدعاء الأول يؤثر فقط على الشرائح التي كانت تعتمد على `firstGroupMaster`، والاستدعاء الثاني يؤثر فقط على الشرائح التي كانت تعتمد على `secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا يُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا كنت تريد نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) والماستر المستنسخ. هذا ينقل الماستر، تخطيطاته، والسمة المرتبطة معه معًا.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفس الشكل في الوجهة. مجرد استنساخ المحتوى على ماستر وجهة غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على ماسترها وتخطيطها الحالي، ابدأ تجاوزًا على مستوى الشريحة من سمة المصدر. تُنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

تجاوز على مستوى التخطيط يُطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تُقدِّم شريحة معينة تجاوزًا خاصًا بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/):

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

استخدم سمة ماستر أو سمة مستوى العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما يحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تُصعّب التجاوزات المفرطة على مستوى الشريحة تغييرات السمة العامة اللاحقة.

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*تجاوز التخطيط يُطبق على الشرائح التي تستخدم ذلك التخطيط ما لم تُقدِّم شريحة تجاوزًا محليًا أكثر. القيم المستندة إلى السمة تتبع مخططها المحلول؛ يمكن للكائنات ذات التنسيق الصريح الاحتفاظ بمظهرها المحلي. احتفظ بالتجاوزات ضيقةً بقدر الاستثناء التصميمي المقصود.*
<!-- visual-explanation:presentation-theme:end -->

## **تحديث أنماط خلفية السمة**

تُخزّن خلفيات السمة في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات التعبئة المخزنة بالفعل في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/) الحالي. مؤشر النمط `0` يعني عدم وجود تعبئة سمة؛ القيم الموجبة هي مراجع نمط خلفية سمة. هذا يختلف عن فهرسة مجموعة Java مباشرةً، حيث أن `get_Item(0)` يعني العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يُعيّن مرجع خلفية سمة للماستر الأول، ويحفظ العرض:

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

يعتمد النتيجة الظاهرة على إدخال السمة الذي يُشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تُعامِل مؤشر النمط كأنه فهرس قائم على الصفر. كما يُستحسن تجنب ترميز رقم نمط من ملف واحد والافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات نمط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية والوراثة، راجع [خلفية العرض](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على مجموعات تعبئة، خط، وتأثير منفصلة يُظهرها [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). عادةً ما تحتوي سمات Office على ثلاثة مدخلات أساسية تتCorrespond بصريًا إلى تنسيقات خفيفة، معتدلة، ومكثفة، لكن يجب على الشفرة فحص كل مجموعة بدلًا من افتراض عدد ثابت.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Java، يكون فهرس المجموعة صفرًا أساسًا: `get_Item(0)` هو النمط المخزن الأول و`get_Item(2)` هو الثالث. فهارس مراجع النمط لكائن الشكل هي مفهوم منفصل، يُظهره [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر النمط الخط الأول، يغيّر النمط التعبئة الثالث، يُفعّل ظلًا خارجيًا في النمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تشير إلى هذه الفتحات، يصبح نمط الخط السمة الأول أحمر، ويصبح نمط التعبئة السمة الثالث أخضر غابي صلب، ويكتسب نمط التأثير الثالث ظلًا خارجيًا بمسافة 10 نقاط. لا يزال المظهر البصري الدقيق يعتمد على الفتحات التي تُشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **اختيار أنماط تعبئة وخط سمة لشكل**

يمكن للشكل اختيار تعبئته وخطّه بصفة مستقلة عبر [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) و[IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). لكل طريقة، الفهرس `1` يختار العنصر الأول في مجموعة السمة المقابلة (`get_Item(0)`)، والفهرس `2` يختار الثاني (`get_Item(1)`).

المثال التالي يُعدّ نمطين تعبئة (ذهبي وزرقاء سماوية) ونمطين خط (أزرق غامق بـ 6 نقاط وأحمر غامق بـ 12 نقطة) في السمة الافتراضية لعرض جديد. يحفظ الشريحة في ثلاث مراحل حتى يمكنك مقارنة النتائج في PowerPoint.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| الأنماط الأولية | تغيير حد الخط الأيمن | تعديل أول تعبئة سمة |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

اختيار نمط خط مختلف يغيّر فقط حد المستطيل الأيمن. تعديل أول تعبئة سمة يُحدّث كل شكل يستخدمها. هنا، فقط المستطيل الأيسر يتحول إلى اللون الأخضر.

على شكل موجود، يمكن للون تعبئة محلي، لون خط، أو عرض خط أن يتجاوز ذلك الجزء من نمط السمة. إذا لم يكن لتغيير فهرس النمط تأثير مرئي، فتحقق من [التنسيق المباشر](/slides/ar/java/shape-formatting/) للشكل.

## **تحديد ما إذا كانت تعبئة صلبة فعّالة تستخدم لون سمة**

يمكن أن تُخزن التعبئة مباشرةً على كائن أو تُورّث من فقرة، تخطيط، ماستر، نمط سمة، أو مستوى تنسيق آخر. استدعِ [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) لحل تلك الهرمية إلى [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) غير قابل للتغيير. أولًا افحص [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). فقط عندما يكون `FillType.Solid` يجب قراءة خصائص التعبئة الصلبة.

بالنسبة لتعبئة صلبة، تُعيد [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) القيمة النهائية RGB بعد الوراثة، البحث في السمة، وتطبيق تحويلات اللون. تُعيد [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) الفتحة المنطقية لـ [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) مثل `Text1` أو `Accent6`. قيمة `SchemeColor.NotDefined` تعني أن التعبئة الصلبة الفعالة ليست مبنية على لون مخطط. في سير عمل حيث تكون التعبئات إما ألوان سمة أو ألوان RGB مباشرة، تُحدد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) المحلية وحدها لتصنيف التعبئة. على سبيل المثال، قد لا يكون لجزء نص لون مخطط معرف محليًا، لذا تكون قيمته المحلية `NotDefined`، بينما تعبئته الفعالة قد تُورّث لون سمة وتُحل إلى `Text1` أو `Accent6`. بالمقابل، يُخبرك `getSolidFillSchemeColor` أي فتحة سمة منطقية أنتجت اللون الفعلي، لكنه لا يخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر.

المثال التالي يحمل عرضًا، يدقق كل تعبئات الأشكال وتعبئات أقسام النص، يطبع كل قيمة RGB نهائية والفتحة المخططة المرتبطة، ويُعلِّم التعبئات الصلبة التي لن تتتبع تغييرات ألوان السمة:

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

الفرع `NotDefined` يُوفر قائمة تدقيق للتعبئات الصلبة التي لن تستجيب لتغييرات فتحات ألوان السمة. راجع تلك الكائنات عندما يجب على عرض ما اتباع لوحة ألوان علامة تجارية جديدة. لا يزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما تُوضح قيمة المخطط ما إذا كان هذا المظهر مرتبطًا بالسمة.

كائنات الصيغة الفعالة هي لقطات. بعد تغيير سمة العرض، أو تجاوز سمة، أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واطلب كائن `IFillFormatEffectiveData` جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعالة**

تُخبرك كائنات السمة الخام بما هو مُعرّف على مستوى معين. القيم الفعالة تُخبرك بما يستخدمه شريحة أو شكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/)، وللتعبئة استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعالة، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعالة لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، قد تفوتك أي تجاوز ماستر، تخطيط، شريحة، أو شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) يُعيد تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسماها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) للشريحة وابدأ سمة تجاوزها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة السمة الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهر المصدر، استنسخ ماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). هذا يبقي الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط، واستخدم طرق البيانات الفعالة المقابلة للكائنات التنسيقية مثل [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.
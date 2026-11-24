---
title: إدارة سمات العروض التقديمية على Android
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/androidjava/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض التقديمي
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
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة سمات العرض التقديمي الرئيسية في Aspose.Slides لأجهزة Android عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على الهوية البصرية المتناسقة."
---
## **مقدمة**

يُعرّف سمة العرض مجموعةً منسقة من الألوان والخطوط وأنماط الخلفية والملء والحدود والتأثيرات. تشير الكائنات الواعية بالسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، وبالتالي يمكن لتغيير السمة تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات سمة على مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض من خلال [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية أن تتجاوز سمتها الموروثة من خلال [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). عمليًا، تُحل السمة الفعّالة لشريحة ما عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر عمليات السمة شيوعًا: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) مخطط اللون، مخطط الخط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). يُعد فحص هذه المجموعات قبل تعديلها مفيدًا خاصةً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط يمكن أن يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويُبلّغ عن عدد أنماط الخلفية والملء والحدود والتأثيرات المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعّالة. فحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضَح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات في التخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للملء والحدوط والنص الواعي بالسمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). عند تغيير الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/)، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السِمِي مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغيّر عند تحديث لون السمة.

المثال الشامل التالي يُنشئ شكلًا يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يعيده، ويطبع لون الملء الفعّال:

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

نظرًا لأن المستطيل ما زال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت اللون المخطّط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على ذلك الملء.

### **استخدام ألوان من اللوحة الإضافية**

يستخلص PowerPoint تدرجات أفتح وأغمق من لون السمة من خلال تطبيق تحويلات الألوان. تعرض Aspose.Slides هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الفاتحة والداكنة المشتقة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.

**2** - التدرجات الفاتحة والداكنة المستخرجة من الألوان الرئيسية للسمة.

المثال التالي يُنشئ ستة مستطيلات تعتمد على `Accent4`، يطبّق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه التدرجات معتمدة على لون السمة. إذا تغيّر `Accent4` لاحقًا، تُعاد حساب الألوان المُحوّلة من القيمة الجديدة لـ `Accent4`.

### **رسم خريطة قيم `SchemeColor` إلى فتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ هي ليست قيمًا تُحوّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

يحتوي مخطط خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية لنص الجسم. تُظهر طُرُق [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) و[IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) تلك المجموعات.

يمكن استخدام معرفات خطوط سمة متوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي (Latin Minor)
* `+mj-lt` - خط العنوان (Latin Major)
* `+mn-ea` - خط النص الأساسي (East Asian Minor)
* `+mj-ea` - خط العنوان (East Asian Major)
* `+mn-cs` - خط النص الأساسي (Complex Script Minor)
* `+mj-cs` - خط العنوان (Complex Script Major)

المثال التالي يُنشئ عنوانًا واحدًا يستخدم خط السمة اللاتيني الرئيسي، وسطرًا نصيًا يستخدم خط السمة اللاتيني الفرعي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع نص الجسم الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتبدّل تلقائيًا عندما يتغيّر مخطط خطوط السمة.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والفرعية أيضًا على خرائط خطوط لأنظمة كتابة معينة، مثل السيران، العربية، اليابانية، الجورجية، والثانا. للاطلاع على كيفية فحص، إضافة، استبدال أو إزالة هذه الخرائط، راجع [Script-Specific Theme Fonts](/slides/ar/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}

لمزيد من المعلومات حول خطوط العرض، شاهد [PowerPoint Fonts](/slides/ar/androidjava/powerpoint-fonts/).

{{% /alert %}}

### **حل مراجع خطوط السمة**

عند فحص النص، قد تُعيد [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) مرجع سمة مثل `+mn-lt` بدلاً من اسم عائلة الخط. استدعِ [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) مع [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) المناسب لحل ذلك المرجع. تُحدّد البادئات `+mj` و`+mn` مجموعات الخطوط الرئيسية والفرعية؛ وتُحدّد اللاحقات `-lt` و`-ea` و`-cs` خطوطهم اللاتينية والآسيوية الشرقية والسكريبت المعقّدة على التوالي.

احصل على السمة الفعّالة عبر [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) على الكائن الذي تُطبق سمة عليه النص المُفحص. للنص العادي على شريحة، استدعِ هذه الطريقة على الشريحة حتى تشمل السياق السمة الموروثة لتلك الشريحة وتجاوزاتها المحلية. عند فحص تخطيط أو ماستر بحد ذاته، استخدم سمةه الفعّالة. لا تفترض أن سمة أول ماستر تنطبق على كل شريحة.

المثال التالي يُنشئ جزءًا نصيًا يُشير صراحةً إلى الخط اللاتيني الفرعي. يهيّئ مخطط خطوط الشريحة عبر [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) ويضبط عائلتي الخطوط اللاتينية الرئيسيتين والفرعيتين إلى `Arial` و`Calibri`، مما يجعل النتيجة قابلة لإعادة الإنتاج دون ملف إدخال.

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

الناتج هو `+mn-lt -> Calibri` ثم `Verdana -> Verdana`. يبقى المرجع المخزن دون تغيير، بينما يُعاد إرجاع اسم العائلة الصريح كما هو. إذا كان الجزء يستخدم `+mj-lt`، فسيتم حلّه إلى `Arial` في هذه السمة.

يُظهر حل مرجع السمة عائلة الخط المحددة بواسطة السمة. لا يتحقق من توافر الخط أو يحدّد ملف الخط المستخدم نهائيًا بعد الاستبدال أو اللجوء إلى بدائل الحروف أثناء العرض. انظر إلى [Font Selection Sequence](/slides/ar/androidjava/font-selection-sequence/) و[Font Substitution](/slides/ar/androidjava/font-substitution/) لهذه الخطوات المنفصلة.

## **نسخ أو تطبيق سمة**

تحلّ الحلات العملية أدناه مشكلات مختلفة متعلقة بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة للماستر**

استخدم [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تصميم كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) التي تُنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. تُنشئ ماستر شريحة جديد استنادًا إلى الماستر المحدد.
1. تُطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد لكل الشرائح التي كانت تعتمد مسبقًا على الماستر المحدد.
1. تُعيد كائن [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يُطبق سمة خارجية على الشرائح التي تعتمد على أول ماستر ويحفظ العرض:

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

قد يتسبب سمة غير صالحة أو تالفة أو غير مدعومة في رفع استثناء [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يُدخلها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المختار فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها وسيماتها الحالية. تُحلّ الألوان والخطوط والملء والحدوط والخلفيات والتأثيرات الواعية بالسمة مقابل السمة الخارجية. قد تظل الألوان والخطوط والملء والتنسيق الصريح غير متغيّرة. يمكن لتجاوزات مستوى التخطيط أو الشريحة أيضًا أن تتفوّق على القيم الموروثة من الماستر الجديد.

قد تُشير السمة إلى خطوط غير متوفرة في بيئة التنفيذ. لضمان عرض وتصدير متسقين، ثبّت الخطوط المطلوبة، قدّمها عبر [مصادر الخطوط المخصصة](/slides/ar/androidjava/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/androidjava/font-substitution/).

هذا مسار عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تتطلّب إنشاء تجاوزات سمة على مستوى الشرائح أو التخطيطات يدويًا.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عند عدم معرفة الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) و[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمة لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويطبق سمة خارجية مختلفة على كل مجموعة:

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

الاستدعاء الأول يؤثّر فقط على الشرائح التي تعتمد على `firstGroupMaster`، والاستدعاء الثاني يؤثّر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح التابعة لأي ماستر آخر لا تُعيد تصميمها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، انسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)، ثم انسخ الشريحة باستخدام [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) والماستر المنسوخ. هذا ينقل الماستر وتخطيطاته والسمة المرتبطة به معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد نسخ المحتوى إلى ماستر هدف غير مرتبط قد يغير الألوان والخطوط والخلفيات والتأثيرات المدفوعّة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على الماستر والتخطيط الحاليين، ابدأ بتجاوز مستوى الشريحة من السمة المصدر. تنسخ الطرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

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

يغيّر هذا السمة المستخدمة لتلك الشريحة دون تعديل السمة الموروثة للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

تطبق تجاوزات مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تُعطِ شريحة معينة تجاوزًا خاصًا بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

استخدم سمة ماستر أو سمة عرض عندما تحتاج العديد من التخطيطات والشرائح إلى مشاركة نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما يحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المتعددة على مستوى الشريحة تغييرات السمة العامة لاحقًا أصعب في التنبؤ.

<!-- visual-explanation:presentation-theme:start -->
[![تُغذّي سمة ماستر اثنين من التخطيطات؛ يؤثر تجاوز التخطيط على شرائحه ما عدا شريحة ذات تجاوز محلي أكثر](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*تُطبّق تجاوزات التخطيط على الشرائح التي تستخدم ذلك التخطيط ما لم تُقدّم شريحة تجاوزًا محليًا. تتبع القيم القائمة على السمة المخطط المحلَّل؛ يمكن للكائنات المُنسَّقة صراحةً الاحتفاظ بمظهرها المحلي. حافظ على نطاق التجاوزات بقدر الاستثناءات التصميمية المقصودة.*
<!-- visual-explanation:presentation-theme:end -->

## **تحديث أنماط خلفية السمة**

تُخزَّن ملء خلفية السمة في [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات الملء المخزَّنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج ملء السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط الخلفية في PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزَّنة و[Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). مؤشر النمط `0` يعني عدم وجود ملء سمة؛ القيم الموجبة هي مراجع نمط خلفية سمة. هذا يختلف عن فهرسة مجموعة Java مباشرةً، حيث يعني `get_Item(0)` العنصر الأول المخزَّن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

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

تعتمد النتيجة الظاهرة على إدخال السمة الذي يُشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يتغيّر مظهرها عند تغيير خلفية الماستر فقط. استخدم [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) عندما تحتاج لمعرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}

لا تُعامل مؤشر النمط كفهرس مجموعة يبدأ من الصفر. وتجنّب أيضًا الترميز الثابت لرقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.

{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}

للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/androidjava/presentation-background/).

{{% /alert %}}

## **تحديث تأثيرات السمة**

يتضمن مخطط تنسيق السمة مجموعات منفصلة للملء، الحد، وتأثيرات الأسلوب التي تُعرض عبر [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)، و[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). غالبًا ما تحتوي سمات Office النموذجية على ثلاث مدخلات أساسية تتوافق بصريًا مع تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الكود فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات سمة خفيفة ومتوسطة وشديدة مُطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في Java، يكون فهرس المجموعة يبدأ من الصفر: `get_Item(0)` هو أول نمط مخزَّن و`get_Item(2)` هو الثالث. تُعد فهارس مراجع النمط في الشكل مفهومًا منفصلًا، تُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). تعديل نمط سمة يؤثّر على الأشكال التي تُشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر نمط الحد الأول، يغيّر نمط الملء الثالث، يُفعّل ظِلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح نمط الحد السمة الأول أحمر، يصبح نمط الملء السمة الثالث أخضرًا غامقًا صلبًا، ويضيف نمط التأثير الثالث ظلًا خارجيًا بمسافة 10 نقاط. لا يزال المظهر البصري الدقيق يعتمد على الفتحات التي تُشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير الحد، الملء، وإعدادات الظل](presentation-design_11.png)

## **تحديد أنماط ملء وخط سمة لشكل**

يمكن للشكل اختيار ملءه وحدوده بصورة مستقلة عبر [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) و[IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). لكل طريقة، يختار الفهرس `1` العنصر الأول في مجموعة السمة المقابلة (`get_Item(0)`)، ويختار الفهرس `2` العنصر الثاني (`get_Item(1)`).

المثال التالي يُعدّ نمطين للملء (ذهبي وأزرق سماوي) ونمطين للحد (أزرق غامق 6pt وأحمر غامق 12pt) في السمة الافتراضية لعرض جديد. يحفظ الشريحة في ثلاث مراحل لتتمكن من مقارنة النتائج في PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| الأنماط الأولية | تغيير حدّ اليمين | تحرير أول ملء سمة |
|:---:|:---:|:---:|
| ![مستطيلات ذهبية وزرقاء سماوية مع حدود رفيعة زرقاء غامقة متطابقة](theme-style-initial.png) | ![المستطيل السماوي الآن لديه حدّ أحمر غامق سميك](theme-style-line-changed.png) | ![المستطيل الأيسر الآن أخضر وكلا الحدين غير متغيرين](theme-style-fill-changed.png) |

يؤدي اختيار نمط حد مختلف إلى تغيير حدود المستطيل الأيمن فقط. يُحدّث تحرير أول ملء سمة كل الأشكال التي تستخدمه. هنا، يتحوّل المستطيل الأيسر إلى اللون الأخضر فقط.

على شكل موجود، يمكن للون ملء محلي أو لون حد أو عرض حد أن يتجاوز ذلك الجزء من نمط السمة. إذا لم يحدث لأي فهرس نمط تأثير مرئي، فتحقق من [التنسيق المباشر](/slides/ar/androidjava/shape-formatting/) للشكل.

## **تحديد ما إذا كان الملء الصلب الفعّال يستخدم لون سمة**

يمكن أن يُخزَّن الملء مباشرةً على كائن أو يُورِّث من فقرة أو تخطيط أو ماستر أو نمط سمة أو مستوى تنسيق آخر. استدعِ [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) لحل تلك الهرمية إلى بيانات غير قابلة للتغيير [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). أولًا تحقق من [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). فقط عندما يكون `FillType.Solid` ينبغي قراءة خصائص الملء الصلب.

بالنسبة للملء الصلب، تُعيد [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) القيمة النهائية لـ RGB بعد الوراثة، البحث في السمة، وتطبيق تحويلات الألوان. تُعيد [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) الفتحة المنطقية في تعداد [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) المقابلة، مثل `Text1` أو `Accent6`. القيمة `SchemeColor.NotDefined` تعني أن الملء الصلب الفعّال غير معتمد على لون مخطط. في سير عمل يكون فيه الملء إما ألوان سمة أو ألوان RGB مباشرة، تحدِّد هذه القيمة ملء RGB مباشر.

لا تُستخدم القيمة المحلية [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) بمفردها لتصنيف الملء. على سبيل المثال، قد لا يحدد جزء نص ما لون مخطط محليًا، وبالتالي تكون قيمته المحلية `NotDefined`، بينما يرث ملءه الفعّال لون سمة ويحل إلى `Text1` أو `Accent6`. بالمقابل، تُظهر `getSolidFillSchemeColor` أي فتحة سمة منطقية أدت إلى اللون الفعّال، لكنها لا تُظهر ما إذا كانت هذه الفتحة جاءت من الكائن أو الفقرة أو التخطيط أو الماستر أو مستوى آخر.

المثال التالي يحمّل عرضًا، يدقق كل ألوان ملء الأشكال وألوان ملء أجزاء النص، يطبع كل قيمة RGB نهائية والفتحة المرتبطة، ويُعلِم ما إذا كان ملء صلب لن يتتبع تغييرات ألوان السمة:

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

يوفّر الفرع `NotDefined` قائمة تدقيق للملء الصلب الذي لن يستجيب لتغييرات فتحات ألوان السمة. راجع هذه الكائنات عندما يجب على العرض اتباع لوحة علامات تجارية جديدة. لا يزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما تُوضح قيمة الفتحة ما إذا كان هذا المظهر مرتبطًا بالسمة.

كائنات التنسيق الفعّالة هي لقطات. بعد تغيير سمة العرض أو تجاوز سمة أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعّالة**

تخبرك كائنات السمة الخام بما هو مُعرّف على مستوى معين. تُظهر القيم الفعّالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)، وللملء استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، وأول ملء شكل من شريحة:

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

استخدم البيانات الفعّالة للتشخيصات الرسومية، والتحقق من الصحة، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، فقد تفوتك ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثّر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. لا يُعيد [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) تعيين سوى الشرائح التي تعتمد على الماستر المحدد. تحتفظ الشرائح التي تستخدم ماسترات أخرى بسيماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) الخاص بالشريحة وابدأ بتهيئة سمة التجاوز الخاصة بها. يظل التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سيماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، انسخ ماستر المصدر إلى الوجهة ونسخ الشريحة باستخدام [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) و[ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). يحتفظ ذلك بالماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط، واستخدم طرق البيانات الفعّالة للكائنات التنسيقية مثل [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلَّلة بعد تطبيق الوراثة والتجاوزات.
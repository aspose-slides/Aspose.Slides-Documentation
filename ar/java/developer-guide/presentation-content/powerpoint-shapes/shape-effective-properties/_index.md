---
title: "الحصول على خصائص الشكل الفعّالة من العروض التقديمية في جافا"
linktitle: "خصائص فعّالة"
type: docs
weight: 50
url: /ar/java/shape-effective-properties/
keywords:
  - "خصائص الشكل"
  - "خصائص الكاميرا"
  - "جهاز إضاءة"
  - "شكل الحدّ"
  - "إطار النص"
  - "نمط النص"
  - "ارتفاع الخط"
  - "تنسيق التعبئة"
  - "PowerPoint"
  - "العرض التقديمي"
  - "Java"
  - "Aspose.Slides"
description: "اكتشف كيف تقوم Aspose.Slides for Java بحساب وتطبيق خصائص الشكل الفعّالة للحصول على عرض دقيق في PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء على شريحة.
1. أنماط نص الشكل النموذجي على تخطيط أو شريحة رئيسية، عندما يحتوي إطار نص الجزء على شكل.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو إغفالها على أي مستوى. عندما تحتاج Aspose.Slides إلى تنسيق «كما هو معروض» النهائي، فإنها تحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها عن طريق استدعاء طريقة `getEffective` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص وعلى الأقل جزء واحد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
تمثل بيانات التنسيق الفعّال التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التطبيق الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة مؤقتًا داخليًا، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPortionFormatEffectiveData). استدعاء `getEffective` مرة أخرى بعد تغيير التنسيق الأب أو الموروث يمكنه تحديث البيانات المخزنة مؤقتًا، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى الاحتفاظ بالقيم الفعّالة لإعادة استخدامها لاحقًا، قم بنسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة للكاميرا. تمثل الواجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. يتم إتاحة مثال [ICameraEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICameraEffectiveData) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المثال البرمجي التالي كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لجهاز الإضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لجهاز الإضاءة. تمثل الواجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعّالة. يتم إتاحة مثال [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ILightRigEffectiveData) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المثال البرمجي التالي كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة للحدب (Bevel) في الشكل**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لحدب الشكل. تمثل الواجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الحدّ الفعّالة للشكل. يتم إتاحة مثال [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeBevelEffectiveData) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المثال البرمجي التالي كيفية الحصول على الخصائص الفعّالة للحدّ العلوي للشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. تحتوي الواجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormatEffectiveData) على خصائص تنسيق إطار النص الفعّالية.

يعرض المثال البرمجي التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالية. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. تحتوي الواجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextStyleEffectiveData) على خصائص نمط النص الفعّالية.

يعرض المثال البرمجي التالي كيفية الحصول على خصائص نمط النص الفعّالية. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على قيمة ارتفاع الخط الفعّال**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الكود التالي كيف يتغير ارتفاع الخط الفعّال للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على تنسيق التعبئة الفعّال للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. تحتوي الواجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IFillFormatEffectiveData) على خصائص تنسيق التعبئة الفعّالية. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

وبالتالي، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICellFormatEffectiveData) لرسم خلية الجدول. يعرض المثال البرمجي التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل تُعيد `getEffective` لقطة؟**

ليس دائمًا. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن قد يتم تخزين بعض كائنات البيانات الفعّالة مؤقتًا داخليًا. قد يعيد استدعاء `getEffective` التالي حساب التنسيق وتحديث البيانات المخزنة مؤقتًا، لذا لا ينبغي اعتبار الكائن الذي تم الحصول عليه مسبقًا كلقطة ثابتة.

**متى يجب عليّ قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `getEffective` مرة أخرى بعد تغيير التنسيق المحلي أو أنماط الأب أو تنسيق التخطيط أو تنسيق الرئيسي أو الإعدادات الافتراضية على مستوى العرض التقديمي. ستقوم الاستدعاء التالي بإعادة تقييم شجرة التنسيق وتعيد النتيجة الفعّالية الحالية.

**هل يؤثر تغيير أو إزالة شريحة تخطيط/رئيسية على الخصائص الفعّالية التي تم استرجاعها بالفعل؟**

نعم، لكن يتم انعكاس التغيير في الاستدعاء التالي لـ `getEffective`. إذا تم تغيير أو إزالة مصدر تنسيق أب، قد تصبح البيانات الفعّالة التي تم الحصول عليها مسبقًا قديمة. بمجرد استدعاء `getEffective` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى الناتجة.

**هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالة؟**

لا. كائنات البيانات الفعّالة تعرض القيم المحسوبة فقط. يجب إجراء التغييرات في كائنات التنسيق المحلي، ثم الحصول على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل أو في التخطيط/الرئيسية أو في الإعدادات العامة؟**

يتم تحديد القيمة الفعّالة من خلال آلية القيم الافتراضية، والتي تشمل القيم الافتراضية في PowerPoint و Aspose.Slides. تصبح تلك القيمة المحسومة جزءًا من البيانات الفعّالة الحالية.

**هل يمكنني، من قيمة الخط الفعّالية، معرفة أي مستوى قد وفر الحجم أو نوع الخط؟**

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، الرئيسي، ومستوى العرض التقديمي لترى أين تظهر التعريف الصريح الأول.

**لماذا تبدو القيم الفعّالة أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية أصبحت نهائية (لم يلزم أي وراثة من مستويات أعلى). في مثل هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب عليّ استخدام الخصائص الفعّالة، ومتى أعمل فقط بالقيم المحلية؟**

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة «كما هي معروضة» بعد تطبيق جميع الوراثات، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا أردت الحفاظ على تلك القيم بغض النظر عن التغييرات اللاحقة في التنسيق، قم بنسخ الخصائص المطلوبة إلى كائن خاص بك. إذا كنت تحتاج إلى تغيير التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالة مرة أخرى للتحقق من النتيجة.
---
title: "الحصول على خصائص الشكل الفعالة من العروض التقديمية في Java"
linktitle: "الخصائص الفعالة"
type: docs
weight: 50
url: /ar/java/shape-effective-properties/
keywords:
- "خصائص الشكل"
- "خصائص الكاميرا"
- "إعداد الإضاءة"
- "شكل الحافة"
- "إطار النص"
- "نمط النص"
- "ارتفاع الخط"
- "تنسيق التعبئة"
- PowerPoint
- "عرض تقديمي"
- Java
- Aspose.Slides
description: "اكتشف كيفية حساب وتطبيق Aspose.Slides for Java لخصائص الشكل الفعالة لضمان عرض PowerPoint بدقة."
---
## **نظرة عامة**

هذه المقالة تشرح الفرق بين الخصائص **المحلية** و **الفعالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء على شريحة.
1. أنماط نص الشكل النموذجي على تخطيط أو شريحة أساسية، عندما يكون للشكل إطار نص للجزء.
1. إعدادات النص العامة في عرض تقديمي.

يمكن تعريف القيم المحلية أو إغفالها على أي مستوى. عندما تحتاج Aspose.Slides إلى تنسيق "كما يُعرض" النهائي، تقوم بحل سلسلة الوراثة وتعيد القيم **الفعالة**. يمكن الحصول عليها باستدعاء طريقة `getEffective` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعالة. يفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص وعلى الأقل جزء واحد.

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
تمثل بيانات التنسيق الفعالة التنسيق المُحسب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعالة مؤقتًا، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPortionFormatEffectiveData)، داخليًا. استدعاء `getEffective` مرة أخرى بعد تغيير التنسيق الأب أو الموروث يمكنه تحديث البيانات المخزنة مؤقتًا، وقد لا يُمثل الكائن المسترجع مسبقًا الحالة السابقة. إذا كنت بحاجة إلى حفظ القيم الفعالة للاستخدام لاحقًا، انسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على خصائص الكاميرا الفعالة**

Aspose.Slides يتيح لك الحصول على الخصائص الفعالة للكاميرا. تمثل الواجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يتم الكشف عن مثال [ICameraEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICameraEffectiveData) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المثال البرمجي التالي كيفية الحصول على الخصائص الفعالة للكاميرا. يفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على خصائص إعداد الإضاءة الفعالة**

Aspose.Slides يتيح لك الحصول على الخصائص الفعالة لإعداد الإضاءة. تمثل الواجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص إعداد الإضاءة الفعالة. يتم الكشف عن مثال [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ILightRigEffectiveData) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المثال البرمجي التالي كيفية الحصول على الخصائص الفعالة لإعداد الإضاءة. يفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على خصائص الحافة الشكلية الفعالة**

Aspose.Slides يتيح لك الحصول على الخصائص الفعالة لحافة الشكل. تمثل الواجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الاحتراف الفعالة للشكل. يتم الكشف عن مثال [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeBevelEffectiveData) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المثال البرمجي التالي كيفية الحصول على الخصائص الفعالة للحافة العليا للشكل. يفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على خصائص إطار النص الفعالة**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعالة لإطار النص. الواجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormatEffectiveData) تحتوي على خصائص تنسيق إطار النص الفعالة.

يعرض المثال البرمجي التالي كيفية الحصول على خصائص تنسيق إطار النص الفعالة. يفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص.

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

## **الحصول على خصائص نمط النص الفعالة**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعالة لنمط النص. الواجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextStyleEffectiveData) تحتوي على خصائص نمط النص الفعالة.

يعرض المثال البرمجي التالي كيفية الحصول على خصائص نمط النص الفعالة. يفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص.

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

## **الحصول على قيمة ارتفاع الخط الفعالة**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعال. يوضح الكود التالي كيف يتغير ارتفاع الخط الفعال للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة في بنية العرض.

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

## **الحصول على تنسيق التعبئة الفعال للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعال لأجزاء مختلفة من الجدول. الواجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IFillFormatEffectiveData) تحتوي على خصائص تنسيق التعبئة الفعالة. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

نتيجة لذلك، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICellFormatEffectiveData) لرسم خلية الجدول. يعرض المثال البرمجي التالي كيفية الحصول على تنسيق التعبئة الفعال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول على الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable).

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

## **الأسئلة الشائعة**

**هل تُعيد `getEffective` لقطة؟**

ليس دائماً. تمثل البيانات الفعالة التنسيق المُحسب بعد تطبيق الوراثة، لكن قد يتم تخزين بعض كائنات البيانات الفعالة داخليًا. قد يؤدي استدعاء `getEffective` لاحقًا إلى إعادة حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي اعتبار الكائن المسترجع مسبقًا لقطة ثابتة.

**متى يجب علي قراءة الخصائص الفعالة مرة أخرى؟**

استدعِ `getEffective` مرة أخرى بعد تعديل التنسيق المحلي أو أنماط الأب أو تنسيق التخطيط أو تنسيق الشريحة الأساسية أو الإعدادات الافتراضية على مستوى العرض. الإستدعاء التالي يعيد تقييم شجرة التنسيق ويعيد النتيجة الفعالة الحالية.

**هل يؤدي تعديل أو إزالة شريحة تخطيط/أساسية إلى تأثير على الخصائص الفعالة التي تم استرجاعها مسبقًا؟**

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `getEffective`. إذا تم تعديل أو إزالة مصدر تنسيق أب، قد تصبح البيانات الفعالة التي تم الحصول عليها مسبقًا قديمة. بمجرد استدعاء `getEffective` مرة أخرى، يقوم Aspose.Slides بإعادة تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى.

**هل يمكنني تعديل القيم عبر كائنات البيانات الفعالة؟**

لا. كائنات البيانات الفعالة تُظهر القيم المحسوبة فقط. يجب إجراء التعديلات في كائنات التنسيق المحلية، ثم استرجاع القيم الفعالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/الأساسي، ولا في الإعدادات العامة؟**

يتم تحديد القيمة الفعالة عبر آلية القيم الافتراضية، التي تشمل الإعدادات الافتراضية لـ PowerPoint و Aspose.Slides. تصبح تلك القيمة المحسومة جزءًا من البيانات الفعالة الحالية.

**من قيمة الخط الفعالة، هل يمكنني معرفة أي مستوى قدم الحجم أو الخط؟**

ليس مباشرة. تُرجع البيانات الفعالة القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء، الفقرة، إطار النص، وأنماط النص على مستوى التخطيط، الشريحة الأساسية، والعرض لتحديد أين تظهر التعريف الأول.

**لماذا تبدو القيم الفعالة أحيانًا مماثلة للقيم المحلية؟**

لأن القيمة المحلية أصبحت نهائية (لم يُستَخدم وراثة من مستوى أعلى). في هذه الحالة، تكون القيمة الفعالة مطابقة للقيمة المحلية.

**متى يجب استخدام الخصائص الفعالة، ومتى يجب العمل فقط مع الخصائص المحلية؟**

استخدم البيانات الفعالة عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق جميع وراثات التنسيق، مثل مطابقة الألوان أو الهوامش أو الأحجام. إذا كنت بحاجة إلى حفظ تلك القيم بغض النظر عن التغييرات المستقبلية، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت تحتاج إلى تعديل التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعالة مرة أخرى للتحقق من النتيجة.
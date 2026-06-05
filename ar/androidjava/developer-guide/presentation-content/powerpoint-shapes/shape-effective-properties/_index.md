---
title: احصل على خصائص الشكل الفعّالة من العروض التقديمية على Android
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/androidjava/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز إضاءة
- شكل مقوّى
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيف يقوم Aspose.Slides لنظام Android عبر Java بحساب وتطبيق خصائص الشكل الفعّالة للحصول على عرض PowerPoint دقيق."
---
## **نظرة عامة**

هذا الموضوع يشرح الفرق بين الخصائص **المحلية** والخصائص **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق محدد، مثل:

1. خصائص الجزء في الشريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة رئيسية، عندما يكون لدى شكل إطار النص للجزء واحد.
1. إعدادات النص العالمية في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها في أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يتم عرضه"، فإنها تحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها عن طريق استدعاء الطريقة `getEffective()` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
تمثل بيانات التنسيق الفعّالة التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد تُخزن بعض كائنات البيانات الفعّالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformateffectivedata/)، داخليًا. استدعاء `getEffective()` مرة أخرى بعد تغيير التنسيق الأب أو الموروث يمكنه تحديث البيانات المخزنة مؤقتًا، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى الحفاظ على القيم الفعّالة لإعادة استخدامها لاحقًا، انسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة للكاميرا. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص كاميرا فعّالة. يتم عرض مثال [ICameraEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icameraeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/).

المثال التالي يوضح كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لجهاز إضاءة (Light Rig)**

تسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة لجهاز الإضاءة. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز إضاءة فعّالة. يتم عرض مثال [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilightrigeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/).

المثال التالي يوضح كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لتقويس الشكل (Bevel Shape)**

تسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة لتقويس الشكل. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص تقويس الوجه لشكل ما. يتم عرض مثال [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapebeveleffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/).

المثال التالي يوضح كيفية الحصول على الخصائص الفعّالة لتقويس الجزء العلوي من الشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. تحتوي واجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعّالة.

المثال التالي يوضح كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) يحتوي على إطار نص.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. تحتوي واجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعّالة.

المثال التالي يوضح كيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) يحتوي على إطار نص.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على قيمة ارتفاع الخط الفعّال**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الكود التالي كيف يتغيّر ارتفاع الخط الفعّال للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من هيكل العرض التقديمي.

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

## **الحصول على تنسيق التعبئة الفعّال لجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. تحتوي واجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعّالة. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

ونتيجة لذلك، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يوضح الكود التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل تُعيد `getEffective()` نسخة ثابتة (snapshot)؟**

ليس دائماً. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعّالة قد تُخزن مؤقتًا داخليًا. قد يقوم استدعاء `getEffective()` لاحقًا بإعادة حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي اعتبار الكائن الذي تم الحصول عليه مسبقًا نسخة ثابتة.

**متى يجب قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `getEffective()` مرة أخرى بعد تغيير التنسيق المحلي، أو أنماط الأب، أو تنسيق التخطيط، أو تنسيق الرئيسي، أو القيم الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويعيد النتيجة الفعّالة الحالية.

**هل يؤثر تغيير أو إزالة شريحة تخطيط/رئيسية على الخصائص الفعّالة التي تم استرجاعها مسبقًا؟**

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `getEffective()`. إذا تم تعديل مصدر تنسيق أب أو إزالته، قد تصبح البيانات الفعّالة التي تم الحصول عليها مسبقًا قديمة. بمجرد استدعاء `getEffective()` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى.

**هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالة؟**

لا. تكشف كائنات البيانات الفعّالة عن القيم المحسوبة فقط. أجري التغييرات في كائنات التنسيق المحلية، ثم احصل مرة أخرى على القيم الفعّالة.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا في التخطيط/الرئيسية ولا في الإعدادات العامة؟**

يُحدّد القيمة الفعّالة عبر الآلية الافتراضية، التي تشمل القيم الافتراضية لـ PowerPoint و Aspose.Slides. تصبح القيمة المحسومة جزءًا من البيانات الفعّالة الحالية.

**من قيمة الخط الفعّال، هل يمكنني معرفة أي مستوى قدّم الحجم أو نوع الخط؟**

ليس بصورة مباشرة. تُعيد البيانات الفعّالة القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية عند الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، الرئيسي، ومستوى العرض التقديمي لتحديد أول تعريف صريح.

**لماذا تبدو القيم الفعّالة أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية أصبحت النهائية (لم يُطلب وراثة من مستوى أعلى). في هذه الحالات تتطابق القيمة الفعّلية مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة "كما يتم عرضها" بعد تطبيق كل الوراثة، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا رغبت في الحفاظ على تلك القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت تريد تعديل التنسيق في مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالة مرة أخرى للتحقق من النتيجة.
---
title: خصائص الكائن الفعالة
type: docs
weight: 50
url: /java/shape-effective-properties/
---

في هذا الموضوع، سنناقش الخصائص **الفعالة** و**المحلية**. عندما نقوم بتعيين القيم مباشرة على هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط نص الشكل الأولي على الشريحة التخطيطية أو الشريحة الرئيسية (إذا كان لشكل إطار النص الخاص بالجزء شكل)؛
1. في إعدادات النص العالمية الخاصة بالعروض؛

تُسمى هذه القيم **محلية**. في أي مستوى، يمكن تعريف القيم **المحلية** أو إغفالها. ولكن عندما يحتاج التطبيق إلى معرفة كيف يجب أن يبدو الجزء، فإنه يستخدم القيم **الفعالة**. يمكنك الحصول على القيم الفعالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

هذا الكود المثال يوضح لك كيفية الحصول على القيم الفعالة:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص الكاميرا الفعالة**
تتيح Aspose.Slides for Java للمطورين الحصول على خصائص الكاميرا الفعالة. لهذا الغرض، تمت إضافة واجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) إلى Aspose.Slides. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يتم استخدام مثيل من واجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) ، والتي هي زوج من [القيم الفعالة](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

هذا الكود المثال يوضح لك كيفية الحصول على الخصائص الفعالة للكاميرا:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= خصائص الكاميرا الفعالة =");
    System.out.println("النوع: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("زاوية الرؤية: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("الزوم: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص جهاز الإضاءة الفعالة**
تتيح Aspose.Slides for Java للمطورين الحصول على خصائص جهاز الإضاءة الفعالة. لهذا الغرض، تمت إضافة واجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) إلى Aspose.Slides. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعالة. يتم استخدام مثيل من واجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) ، والتي هي زوج من [القيم الفعالة](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

هذا الكود المثال يوضح لك كيفية الحصول على الخصائص الفعالة لجهاز الإضاءة:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= خصائص جهاز الإضاءة الفعالة =");
    System.out.println("النوع: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("الاتجاه: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص الشكل الجانبي الفعالة**
تتيح Aspose.Slides for Java للمطورين الحصول على خصائص الشكل الجانبي الفعالة. لهذا الغرض، تمت إضافة واجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) إلى Aspose.Slides. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص البروز الوجهي للشكل الفعالة. يتم استخدام مثيل من واجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) ، والتي هي زوج من [القيم الفعالة](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

هذا الكود المثال يوضح لك كيفية الحصول على الخصائص الفعالة للشكل الجانبي:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= خصائص البروز العلوي للشكل الفعالة =");
    System.out.println("النوع: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("العرض: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("الارتفاع: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص إطار النص الفعالة**
باستخدام Aspose.Slides for Java، يمكنك الحصول على خصائص إطار النص الفعالة. لهذا الغرض، تمت إضافة واجهة [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق إطار النص الفعالة.

هذا الكود المثال يوضح لك كيفية الحصول على خصائص تنسيق إطار النص الفعالة:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("نوع التثبيت: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("نوع التعديل الذاتي: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("نوع النص العمودي: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("المسافات");
    System.out.println("   اليسار: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   الأعلى: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   اليمين: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   الأسفل: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص نمط النص الفعالة**
باستخدام Aspose.Slides for Java، يمكنك الحصول على خصائص نمط النص الفعالة. لهذا الغرض، تمت إضافة واجهة [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) إلى Aspose.Slides. تحتوي على خصائص نمط النص الفعالة.

هذا الكود المثال يوضح لك كيفية الحصول على خصائص نمط النص الفعالة:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= تنسيق الفقرة الفعالة لمستوى النمط #" + i + " =");

        System.out.println("العمق: " + effectiveStyleLevel.getDepth());
        System.out.println("الفراغ: " + effectiveStyleLevel.getIndent());
        System.out.println("المحاذاة: " + effectiveStyleLevel.getAlignment());
        System.out.println("محاذاة الخط: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على قيمة ارتفاع الخط الفعالة**
باستخدام Aspose.Slides for Java، يمكنك الحصول على الخصائص الفعالة لارتفاع الخط. هنا، نقدم كودًا يوضح قيمة ارتفاع الخط الفعالة للجزء تتغير بعد تعيين قيم ارتفاع الخط المحلية على مستويات بنية العرض المختلفة:

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("نص عينة مع الجزء الأول");
    IPortion portion1 = new Portion(" و الجزء الثاني.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("ارتفاع الخط الفعال مباشرة بعد الإنشاء:");
    System.out.println("الجزء #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("الجزء #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط الافتراضي للعروض بالكامل:");
    System.out.println("الجزء #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("الجزء #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط الافتراضي للفقرة:");
    System.out.println("الجزء #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("الجزء #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط للجزء #0:");
    System.out.println("الجزء #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("الجزء #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط للجزء #1:");
    System.out.println("الجزء #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("الجزء #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على تنسيق التعبئة الفعالة للجدول**
باستخدام Aspose.Slides for Java، يمكنك الحصول على تنسيق التعبئة الفعالة لأجزاء جدول منطقية مختلفة. لهذا الغرض، تمت إضافة واجهة [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) في Aspose.Slides. تحتوي على خصائص تنسيق التعبئة الفعالة. يرجى ملاحظة ما يلي: تنسيق الخلايا دائمًا يحصل على أولوية على تنسيق الصف؛ الصف يحصل على أولوية على العمود؛ والعمود يحصل على أولوية على الجدول بالكامل.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```
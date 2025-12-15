---
title: الحصول على الخصائص الفعّالة للأشكال من العروض التقديمية على Android
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/androidjava/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز إضاءة
- شكل مسنن
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for Android عبر Java بحساب وتطبيق الخصائص الفعّالة للأشكال لضمان عرض PowerPoint بدقة."
---

في هذا الموضوع، سنناقش الخصائص **الفعّالة** و **المحلية**. عندما نعيّن القيم مباشرةً على هذه المستويات

1. في خصائص الجزء على شريحة الجزء;
1. في نمط نص الشكل النموذجي على شريحة التخطيط أو الشريحة الرئيسة (إذا كان لشكل إطار النص الخاص بالجزء واحد);
1. في إعدادات النص العامة للعرض التقديمي;

تُطلق على هذه القيم **القيم المحلية**. في أي مستوى، يمكن تعريف أو حذف القيم **المحلية**. ولكن عندما يحتاج التطبيق إلى معرفة مظهر الجزء، يستخدم القيم **الفعّالة**. يمكنك الحصول على القيم الفعّالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

يعرض لك هذا المثال البرمجي كيفية الحصول على القيم الفعّالة:
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


## **الحصول على الخصائص الفعّالة للكاميرا**
تسمح Aspose.Slides for Android via Java للمطورين بالحصول على الخصائص الفعّالة للكاميرا. لهذا الغرض، تم إضافة الواجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) إلى Aspose.Slides. تمثّل الواجهة [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. تُستخدم نسخة من الواجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) كجزء من الواجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)، والتي تُعدّ [القيم الفعّالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) زوجًا لصفّ [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعّالة للكاميرا:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على الخصائص الفعّالة لجهاز إضاءة Light Rig**
تسمح Aspose.Slides for Android via Java للمطورين بالحصول على الخصائص الفعّالة لجهاز إضاءة Light Rig. لهذا الغرض، تم إضافة الواجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) إلى Aspose.Slides. تمثّل الواجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص إضاءة Light Rig الفعّالة. تُستخدم نسخة من الواجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) كجزء من الواجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)، والتي تُعدّ [القيم الفعّالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) زوجًا لصفّ [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعّالة لجهاز إضاءة Light Rig:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على الخصائص الفعّالة للشكل المسنن**
تسمح Aspose.Slides for Android via Java للمطورين بالحصول على الخصائص الفعّالة للشكل المسنن. لهذا الغرض، تمت إضافة الواجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) إلى Aspose.Slides. تمثّل الواجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص إ Relief للوجه الفعّالة. تُستخدم نسخة من الواجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) كجزء من الواجهة [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData))، والتي تُعدّ [القيم الفعّالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) زوجًا لصفّ [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعّالة للشكل المسنن:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على الخصائص الفعّالة لإطار النص**
باستخدام Aspose.Slides for Android via Java، يمكنك الحصول على الخصائص الفعّالة لإطار النص. لهذا الغرض، تمت إضافة الواجهة [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق إطار النص الفعّالة.

يعرض لك هذا المثال البرمجي كيفية الحصول على خصائص تنسيق إطار النص الفعّال:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
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
    if (pres != null) pres.dispose();
}
```


## **الحصول على الخصائص الفعّالة لنمط النص**
باستخدام Aspose.Slides for Android via Java، يمكنك الحصول على الخصائص الفعّالة لنمط النص. لهذا الغرض، تمت إضافة الواجهة [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) إلى Aspose.Slides. تحتوي على خصائص نمط النص الفعّالة.

يعرض لك هذا المثال البرمجي كيفية الحصول على خصائص نمط النص الفعّالة:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على قيمة ارتفاع الخط الفعّالة**
باستخدام Aspose.Slides for Android via Java، يمكنك الحصول على الخصائص الفعّالة لارتفاع الخط. هنا نقدم لك كودًا يوضح تغير قيمة ارتفاع الخط الفعّالة للجزء بعد ضبط قيم ارتفاع الخط المحلي على مستويات هيكلية مختلفة في العرض التقديمي:
```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على تنسيق التعبئة الفعّال لجدول**
باستخدام Aspose.Slides for Android via Java، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء منطقية مختلفة في الجدول. لهذا الغرض، تم إضافة الواجهة [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق التعبئة الفعّالة. يرجى ملاحظة ما يلي: تنسيق الخلية يحصل دائمًا على الأولوية على تنسيق الصف؛ الصف يحصل على الأولوية على العمود؛ والعمود يحصل على الأولوية على كامل الجدول.
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


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أنني حصلت على “لقطة” بدلاً من “كائن حي”، ومتى يجب أن أقراً الخصائص الفعّالة مرة أخرى؟**

كائنات EffectiveData هي لقطات ثابتة للقيم المحسوبة في وقت الاستدعاء. إذا غيرت الإعدادات المحلية أو الموروثة للشكل، استرجع البيانات الفعّالة مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تغيير شريحة التخطيط/الرئيسية على الخصائص الفعّالة التي تم استردادها مسبقًا؟**

نعم، ولكن فقط بعد قراءتها مرة أخرى. كائن EffectiveData الذي تم الحصول عليه مسبقًا لا يُحدّث نفسه—اطلبه مرة أخرى بعد تغيير التخطيط أو الشريحة الرئيسة.

**هل يمكنني تعديل القيم عبر EffectiveData؟**

لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلية (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العامة؟**

تُحدّد القيمة الفعّالة وفقًا للآلية الافتراضية (الافتراضات في PowerPoint/Aspose.Slides). تلك القيمة المحلولة تصبح جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدم الحجم أو الخط؟**

ليس مباشرة. EffectiveData تُعيد القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء/الفقرة/إطار النص والأنماط النصية في التخطيط/الرئيسية/العرض التقديمي لتحديد أول تعريف صريح.

**لماذا تبدو قيم EffectiveData أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية انتهت إلى أن تكون النهائية (لم يُطلب وراثة من مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب أن أستخدم الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم EffectiveData عندما تحتاج إلى النتيجة “كما تُعرض” بعد تطبيق كل الوراثة (مثلاً لتطابق الألوان أو الهوامش أو الأحجام). إذا كنت تحتاج إلى تعديل التنسيق على مستوى محدد، عدِّل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.
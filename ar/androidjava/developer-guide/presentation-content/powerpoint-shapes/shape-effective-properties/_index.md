---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية على Android
linktitle: خصائص فعّالة
type: docs
weight: 50
url: /ar/androidjava/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- معدات إضاءة
- شكل الإزاحة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides لنظام Android عبر Java بحساب وتطبيق خصائص الشكل الفعّالة لتحقيق عرض دقيق لـ PowerPoint."
---

في هذا الموضوع، سنناقش الخصائص **الفعّالة** و **المحلية**. عندما نحدد القيم مباشرةً على هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط نص الشكل الأولي على شريحة التخطيط أو الشريحة الرئيسة (إذا كان لشكل إطار النص للجزء واحد);  
1. في إعدادات النص العامة للعرض التقديمي؛

تُسمى تلك القيم **قيمة محلية**. في أي مستوى، يمكن تعريف القيم **المحلية** أو حذفها. ولكن عندما يحتاج التطبيق إلى معرفة شكل الجزء، يستخدم القيم **الفعّالة**. يمكنك الحصول على القيم الفعّالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

يُظهر لك مثال الشيفرة التالي كيف تحصل على القيم الفعّالة:
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
يتيح Aspose.Slides for Android via Java للمطورين الحصول على الخصائص الفعّالة للكاميرا. لهذا الغرض، تمت إضافة الواجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) إلى Aspose.Slides. تمثل الواجهة [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. يُستخدم مثال من الواجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) كجزء من الواجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)، وهي زوج [قيمة فعّالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

يُظهر لك مثال الشيفرة التالي كيف تحصل على الخصائص الفعّالة للكاميرا:
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


## **الحصول على الخصائص الفعّالة لتجهيز الإضاءة**
يتيح Aspose.Slides for Android via Java للمطورين الحصول على الخصائص الفعّالة لتجهيز الإضاءة. لهذا الغرض، تمت إضافة الواجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) إلى Aspose.Slides. تمثل الواجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص تجهيز الإضاءة الفعّالة. يُستخدم مثال من الواجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) كجزء من الواجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)، وهي زوج [قيمة فعّالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

يُظهر لك مثال الشيفرة التالي كيف تحصل على الخصائص الفعّالة لتجهيز الإضاءة:
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


## **الحصول على الخصائص الفعّالة لشكل الإزاحة**
يتيح Aspose.Slides for Android via Java للمطورين الحصول على الخصائص الفعّالة لشكل الإزاحة. لهذا الغرض، تمت إضافة الواجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) إلى Aspose.Slides. تمثل الواجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص إزاحة سطح الشكل الفعّالة. يُستخدم مثال من الواجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) كجزء من الواجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)، وهي زوج [قيمة فعّالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

يُظهر لك مثال الشيفرة التالي كيف تحصل على الخصائص الفعّالة لشكل الإزاحة:
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

يُظهر لك مثال الشيفرة التالي كيف تحصل على خصائص تنسيق إطار النص الفعّالة:
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

يُظهر لك مثال الشيفرة التالي كيف تحصل على خصائص نمط النص الفعّالة:
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
باستخدام Aspose.Slides for Android via Java، يمكنك الحصول على الخصائص الفعّالة لارتفاع الخط. هنا نقدم شيفرة تُظهر قيمة ارتفاع الخط الفعّالة للجزء بعد ضبط قيم ارتفاع الخط المحلي على مستويات مختلفة في بنية العرض التقديمي:
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
باستخدام Aspose.Slides for Android via Java، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء منطقية مختلفة من الجدول. لهذا الغرض، تمت إضافة الواجهة [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق التعبئة الفعّالة. يرجى ملاحظة ما يلي: تنسيق الخلية دائمًا يحصل على أولوية على تنسيق الصف؛ والصف يحصل على أولوية على العمود؛ والعمود يحصل على أولوية على كامل الجدول.
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


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أنني حصلت على "لقطة" بدلاً من "كائن حي"، ومتى يجب قراءة الخصائص الفعّالة مرة أخرى؟**

الكائنات من نوع EffectiveData هي لقطات غير قابلة للتغيير للقيم المحسوبة في وقت الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، استرجع البيانات الفعّالة مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تعديل شريحة التخطيط/الرئيسية على الخصائص الفعّالة التي تم استرجاعها مسبقًا؟**

نعم، ولكن فقط بعد قراءتها مرة أخرى. الكائن EffectiveData الذي تم الحصول عليه لا يُحدّث نفسه—اطلبه مرة أخرى بعد تعديل التخطيط أو الشريحة الرئيسية.

**هل يمكنني تعديل القيم عبر EffectiveData؟**

لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي (شكل/نص/3D، إلخ)، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العامة؟**

تُحدد القيمة الفعّالة بواسطة الآلية الافتراضية (الافتراضات الخاصة بـ PowerPoint/Aspose.Slides). تلك القيمة المُستخرجة تصبح جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعّال، هل يمكنني معرفة المستوى الذي وفر الحجم أو نوع الخط؟**

ليس مباشرة. EffectiveData تُعيد القيمة النهائية. لتحديد المصدر، راجع القيم المحلية في الجزء/الفقرة/إطار النص والأنماط النصية في التخطيط/الرئيسية/العرض التقديمي لترى أين يظهر التعريف الصريح الأول.

**لماذا تبدو قيم EffectiveData أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية هي التي أصبحت النهائية (لم تُستَخدم وراثة من مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى ينبغي استخدام الخصائص الفعّالة، ومتى أعمل فقط مع الخصائص المحلية؟**

استخدم EffectiveData عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق جميع الوراثات (مثل مطابقة الألوان، الهوامش، أو الأحجام). إذا كنت تحتاج إلى تعديل التنسيق على مستوى معين، غيّر الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.
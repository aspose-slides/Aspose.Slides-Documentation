---
title: الحصول على خصائص الشكل الفعالة من العروض التقديمية في جافا
linktitle: الخصائص الفعالة
type: docs
weight: 50
url: /ar/java/shape-effective-properties/
keywords:
  - خصائص الشكل
  - خصائص الكاميرا
  - مجموعة الإضاءة
  - الشكل المائل
  - إطار النص
  - نمط النص
  - ارتفاع الخط
  - تنسيق التعبئة
  - PowerPoint
  - العرض التقديمي
  - Java
  - Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for Java بحساب وتطبيق خصائص الشكل الفعالة للحصول على عرض PowerPoint دقيق."
---

في هذا الموضوع، سنناقش الخصائص **الفعالة** و **المحلية**. عندما نحدد القيم مباشرةً في هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط نص الشكل النموذجي على الشريحة التخطيطية أو الشريحة الرئيسية (إذا كان لشكل إطار النص للجزء واحد);
1. في إعدادات النص العامة للعرض التقديمي؛

تُسمى تلك القيم **القيم المحلية**. في أي مستوى، يمكن تعريف **القيم المحلية** أو حذفها. ولكن عندما يحتاج التطبيق إلى معرفة شكل الجزء، يستخدم **القيم الفعالة**. يمكنك الحصول على القيم الفعالة باستخدام الطريقة **getEffective()** من التنسيق المحلي.

يعرض لك هذا الكود النموذجي كيفية الحصول على القيم الفعالة:
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


## **الحصول على الخصائص الفعالة للكاميرا**
تسمح Aspose.Slides for Java للمطورين بالحصول على الخصائص الفعالة للكاميرا. لهذا الغرض، تمت إضافة الواجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) إلى Aspose.Slides. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يُستخدم كائن من الواجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData)، والتي تُعد زوجًا من [القيم الفعالة](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) للفئة [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعالة للكاميرا:
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


## **الحصول على الخصائص الفعالة لمجموعة الإضاءة**
تسمح Aspose.Slides for Java للمطورين بالحصول على الخصائص الفعالة لمجموعة الإضاءة. لهذا الغرض، تمت إضافة الواجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) إلى Aspose.Slides. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص مجموعة الإضاءة الفعالة. يُستخدم كائن من الواجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) ، والتي تُعد زوجًا من [القيم الفعالة](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) للفئة [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعالة لمجموعة الإضاءة:
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


## **الحصول على الخصائص الفعالة للشكل المائل**
تسمح Aspose.Slides for Java للمطورين بالحصول على الخصائص الفعالة للشكل المائل. لهذا الغرض، تمت إضافة الواجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) إلى Aspose.Slides. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص إطلالة شكل الوجه الفعالة. يُستخدم كائن من الواجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) ، والتي تُعد زوجًا من [القيم الفعالة](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) للفئة [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعالة لشكل الإقلام:
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


## **الحصول على الخصائص الفعالة لإطار النص**
باستخدام Aspose.Slides for Java، يمكنك الحصول على الخصائص الفعالة لإطار النص. لهذا الغرض، تمت إضافة الواجهة [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق إطار النص الفعالة.

يعرض لك هذا المثال البرمجي كيفية الحصول على خصائص تنسيق إطار النص الفعالة:
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


## **الحصول على الخصائص الفعالة لنمط النص**
باستخدام Aspose.Slides for Java، يمكنك الحصول على الخصائص الفعالة لنمط النص. لهذا الغرض، تمت إضافة الواجهة [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) إلى Aspose.Slides. تحتوي على خصائص نمط النص الفعالية.

يعرض لك هذا المثال البرمجي كيفية الحصول على خصائص نمط النص الفعالة:
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


## **الحصول على قيمة ارتفاع الخط الفعال**
باستخدام Aspose.Slides for Java، يمكنك الحصول على الخصائص الفعالة لارتفاع الخط. هنا، نقدم كودًا يُظهر قيمة ارتفاع الخط الفعالة للجزء تتغير بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي:
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


## **الحصول على تنسيق التعبئة الفعال لجدول**
باستخدام Aspose.Slides for Java، يمكنك الحصول على تنسيق التعبئة الفعال لأجزاء مختلفة من الجدول. لهذا الغرض، تمت إضافة الواجهة [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق التعبئة الفعالة. يرجى ملاحظة ما يلي: تنسيق الخلية يحصل دائمًا على الأولوية على تنسيق الصف؛ والصف يحصل على الأولوية على العمود؛ والعمود يحصل على الأولوية على الجدول بأكمله.
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

**كيف يمكنني معرفة أنني حصلت على "لقطة" بدلاً من "كائن حي"، ومتى يجب علي قراءة الخصائص الفعالة مرة أخرى؟**
كائنات EffectiveData هي لقطات غير قابلة للتغيير للقيم المحسوبة في وقت الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، استرجع البيانات الفعالة مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تغيير شريحة التخطيط/الرئيسية على الخصائص الفعالة التي تم استرجاعها مسبقًا؟**
نعم، ولكن فقط بعد أن تقرأها مرة أخرى. كائن EffectiveData الذي تم الحصول عليه مسبقًا لا يتم تحديثه تلقائيًا—اطلبه مرة أخرى بعد تغيير التخطيط أو الشريحة الرئيسية.

**هل يمكنني تعديل القيم عبر EffectiveData؟**
لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلية (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العامة؟**
يتم تحديد القيمة الفعالة بواسطة آلية الافتراضي (إعدادات PowerPoint/Aspose.Slides الافتراضية). تصبح تلك القيمة المحسومة جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعالة، هل يمكنني معرفة أي مستوى قدّم الحجم أو نوع الخط؟**
ليس مباشرة. تُعيد EffectiveData القيمة النهائية. للعثور على المصدر، تحقق من القيم المحلية في الجزء/الفقرة/إطار النص وأنماط النص في التخطيط/الرئيسية/العرض لمعرفة أين يظهر التعريف الصريح الأول.

**لماذا تبدو قيم EffectiveData أحيانًا مطابقة للقيم المحلية؟**
لأن القيمة المحلية أصبحت النهائية (لم يُحتاج إلى وراثة من مستوى أعلى). في مثل هذه الحالات، تكون القيمة الفعالة مطابقة للقيمة المحلية.

**متى يجب علي استخدام الخصائص الفعالة، ومتى يجب أن أعمل فقط بالقيم المحلية؟**
استخدم EffectiveData عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق جميع الوراثات (مثال: لتطابق الألوان أو الهوامش أو الأحجام). إذا كنت بحاجة إلى تغيير التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.
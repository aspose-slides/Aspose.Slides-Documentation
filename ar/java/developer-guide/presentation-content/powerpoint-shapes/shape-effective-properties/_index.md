---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية في Java
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام الإضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "اكتشف كيف يقوم Aspose.Slides for Java بحساب وتطبيق خصائص الشكل الفعّالة لتحقيق عرض PowerPoint دقيق."
---
## **نظرة عامة**

هذا الموضوع يوضح الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً في مستوى تنسيق معين، مثل:

1. خصائص الجزء في الشريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة رئيسية، عندما يكون لشكل إطار النص للجزء واحد.
1. إعدادات النص العالمية في العرض التقديمي.

يمكن تعريف القيم المحلية أو إغفالها في أي مستوى. عندما يحتاج Aspose.Slides إلى التنسيق النهائي "كما يُعرض"، يقوم بحل سلسلة الوراثة ويعيد القيم **الفعّالة**. يمكنك الحصول عليها باستدعاء طريقة `getEffective` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص وعلى الأقل جزء واحد.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
تمثل بيانات التنسيق الفعّالة التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPortionFormatEffectiveData)، مؤقتًا داخليًا. استدعاء `getEffective` مرة أخرى بعد تغيير التنسيق الأب أو الموروث يمكنه تحديث البيانات المخزنة، وقد لا يمثل الكائن الذي تم الحصول عليه سابقًا الحالة السابقة. إذا كنت بحاجة إلى حفظ القيم الفعّالة لإعادة استخدامها لاحقًا، انسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

يسمح Aspose.Slides لك بالحصول على الخصائص الفعّالة للكاميرا. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص كاميرا فعّالة. يتم إظهار نسخة من [ICameraEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICameraEffectiveData) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المقتطف البرمجي التالي كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
import com.aspose.slides.*;

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

## **الحصول على الخصائص الفعّالة لجهاز إضاءة**

يسمح Aspose.Slides لك بالحصول على الخصائص الفعّالة لجهاز الإضاءة. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز إضاءة فعّالة. يتم إظهار نسخة من [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ILightRigEffectiveData) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المقتطف البرمجي التالي كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
import com.aspose.slides.*;

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

## **الحصول على الخصائص الفعّالة لتدرّج الشكل**

يسمح Aspose.Slides لك بالحصول على الخصائص الفعّالة لتدرّج الشكل. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الوجه المرفوعة الفعّالة لشكل ما. يتم إظهار نسخة من [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeBevelEffectiveData) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormatEffectiveData)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IThreeDFormat).

يعرض المقتطف البرمجي التالي كيفية الحصول على الخصائص الفعّالة لتدرّج الجزء العلوي للشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
import com.aspose.slides.*;

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

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. تحتوي واجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormatEffectiveData) على خصائص تنسيق إطار النص الفعّالة.

يعرض المقتطف البرمجي التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص.

```java
import com.aspose.slides.*;

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

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. تحتوي واجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextStyleEffectiveData) على خصائص نمط النص الفعّالة.

يعرض المقتطف البرمجي التالي كيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) يحتوي على إطار نص.

```java
import com.aspose.slides.*;

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

## **الحصول على قيمة ارتفاع الخط الفعّالة**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الكود التالي كيف يتغير ارتفاع الخط الفعّال للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.

```java
import com.aspose.slides.*;

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

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. تحتوي واجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IFillFormatEffectiveData) على خصائص تنسيق التعبئة الفعّالة. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بأكمله.

وبالتالي، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICellFormatEffectiveData) لرسم خلية الجدول. يعرض المقتطف البرمجي التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITable).

```java
import com.aspose.slides.*;

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

### هل تُعيد `getEffective` لقطة ثابتة؟

ليس دائمًا. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعّالة قد تُخزن مؤقتًا داخليًا. قد يعيد استدعاء `getEffective` لاحقًا إعادة حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي اعتبار الكائن الذي تم الحصول عليه مسبقًا كلقطة دائمة.

### متى يجب قراءة الخصائص الفعّالة مرة أخرى؟

استدعِ `getEffective` مرة أخرى بعد تغيير تنسيق محلي أو أنماط أب، أو تنسيق تخطيط، أو تنسيق رئيس، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيُعيد الاستدعاء التالي تقييم شجرة التنسيق ويُعيد النتيجة الفعّالة الحالية.

### هل يؤثر تعديل أو إزالة شريحة تخطيط/رئيس على الخصائص الفعّالة التي تم استرجاعها مسبقًا؟

نعم، لكن سيظهر التغيير في الاستدعاء التالي لـ `getEffective`. إذا تم تعديل مصدر تنسيق أب أو إزالته، قد تصبح البيانات الفعّالة التي تم الحصول عليها سابقًا قديمة. بمجرد استدعاء `getEffective` مرة أخرى، يعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط والألوان والأحجام أو القيم الأخرى الناتجة.

### هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالة؟

لا. تكشف كائنات البيانات الفعّالة القيم المحسوبة فقط. يجب إجراء التغييرات في كائنات التنسيق المحلي، ثم الحصول على القيم الفعّالة مرة أخرى.

### ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا في التخطيط/الرئيس ولا في الإعدادات العالمية؟

يُحدد القيمة الفعّالة بواسطة آلية الافتراضية، التي تشمل إعدادات PowerPoint و Aspose.Slides الافتراضية. تصبح القيمة المُستخرجة جزءًا من البيانات الفعّالة الحالية.

### من قيمة الخط الفعّالة، هل يمكنني معرفة المستوى الذي وفر الحجم أو الخط؟

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، والرئيس، ومستوى العرض التقديمي لمعرفة أين تظهر التعريف الصريح الأول.

### لماذا تبدو القيم الفعّالة أحيانًا مطابقة تمامًا للقيم المحلية؟

لأن القيمة المحلية انتهت إلى أن تكون النهائية (لم تكن هناك حاجة إلى وراثة من مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

### متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق كل الوراثات، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا كنت بحاجة إلى الحفاظ على تلك القيم بغض النظر عن التغييرات المستقبلية في التنسيق، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت تريد تعديل التنسيق على مستوى معين، غيّر الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالة مرة أخرى للتحقق من النتيجة.
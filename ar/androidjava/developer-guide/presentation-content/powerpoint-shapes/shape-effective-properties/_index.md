---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية على Android
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/androidjava/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز إضاءة
- شكل مشطوف
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides لنظام Android عبر Java بحساب وتطبيق خصائص الشكل الفعّالة للحصول على عرض PowerPoint دقيق."
---
## **نظرة عامة**

توضح هذه المقالة الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي تُضبط مباشرةً في مستوى تنسيق معين، مثل:

1. خصائص الجزء في الشريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة رئيسية، عندما يكون للشكل إطار نص للجزء.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو إهمالها في أي مستوى. عندما تحتاج Aspose.Slides إلى تنسيق العرض النهائي "كما يُعرض"، تقوم بحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها باستدعاء طريقة `getEffective()` على كائن التنسيق المحلي.

يوضح المثال التالي كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
تمثل بيانات التنسيق الفعّالة التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة مؤقتًا داخليًا، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformateffectivedata/). استدعاء `getEffective()` مرة أخرى بعد تعديل التنسيق الوالدي أو الموروث يمكن أن يُحدث تحديثًا للبيانات المخزنة، وقد لا يعود الكائن الذي تم الحصول عليه مسبقًا يعكس الحالة السابقة. إذا كنت بحاجة إلى حفظ القيم الفعّالة لإعادة استخدامها لاحقًا، انسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة للكاميرا. تمثل الواجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص كاميرا فعّالة. يتم توفير نسخة من [ICameraEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icameraeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
import com.aspose.slides.*;

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

## **الحصول على الخصائص الفعّالة لجهاز الإضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لجهاز الإضاءة. تمثل الواجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز إضاءة فعّالة. يتم توفير نسخة من [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilightrigeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
import com.aspose.slides.*;

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

## **الحصول على الخصائص الفعّالة لحافة الشكل**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لحافة الشكل. تمثل الواجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص إزاحة الوجه الفعّالة لشكل ما. يتم توفير نسخة من [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapebeveleffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعّالة للحافة العلوية لشكل ما. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```java
import com.aspose.slides.*;

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

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. تحتوي الواجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار نص فعّالة.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) يحتوي على إطار نص.

```java
import com.aspose.slides.*;

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

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. تحتوي الواجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextstyleeffectivedata/) على خصائص نمط نص فعّالة.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) يحتوي على إطار نص.

```java
import com.aspose.slides.*;

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

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح المثال التالي كيف يتغير ارتفاع الخط الفعّال لجزء بعد ضبط قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.

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

## **الحصول على تنسيق التعبئة الفعّال للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق تعبئة فعّال لأجزاء مختلفة من الجدول. تحتوي الواجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/) على خصائص تنسيق تعبئة فعّالة. لتنسيق الخلية أولوية أعلى من تنسيق الصف، ولتنسيق الصف أولوية أعلى من تنسيق العمود، ولتنسيق العمود أولوية أعلى من تنسيق الجدول بأكمله.

وبالتالي تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يعرض مثال الشيفرة التالي كيفية الحصول على تنسيق تعبئة فعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itable/).

```java
import com.aspose.slides.*;

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

## **الأسئلة الشائعة**

### هل تُعيد `getEffective()` نسخة ثابتة؟

ليس دائمًا. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن قد يتم تخزين بعض كائنات البيانات الفعّالة مؤقتًا داخليًا. قد يؤدي استدعاء `getEffective()` لاحقًا بعد تعديل التنسيق المحلي أو الوالدي إلى إعادة حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي اعتبار الكائن المسترجع سابقًا نسخة ثابتة دائمًا.

### متى يجب قراءة الخصائص الفعّالة مرة أخرى؟

استدعِ `getEffective()` مرة أخرى بعد تغيير التنسيق المحلي أو أنماط الوالد، أو تنسيق التخطيط، أو تنسيق الرئيسي، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويُعيد النتيجة الفعّالة الحالية.

### هل يؤدي تعديل أو إزالة شريحة تخطيط/رئيسية إلى تأثير على الخصائص الفعّالة التي تم استرجاعها مسبقًا؟

نعم، لكن التغيير يُظهر أثره عند الاستدعاء التالي لـ `getEffective()`. إذا تم تعديل أو حذف مصدر تنسيق أبوي، قد تصبح البيانات الفعّالة التي تم الحصول عليها مسبقًا قديمة. بمجرد استدعاء `getEffective()` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى الناتجة.

### هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالة؟

لا. تُظهر كائنات البيانات الفعّالة القيم المحسوبة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي، ثم احصل على القيم الفعّالة مرة أخرى.

### ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العامة؟

يتم تحديد القيمة الفعّالة وفقًا للآلية الافتراضية التي تشمل إعدادات PowerPoint وإعدادات Aspose.Slides الافتراضية. تصبح القيمة التي تم حلّها جزءًا من البيانات الفعّالة الحالية.

### من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدم الحجم أو الخط؟

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية فقط. لتحديد المصدر، افحص القيم المحلية عند الجزء والفقرة وإطار النص وأنماط النص على مستويات التخطيط والرئيسية والعرض التقديمي لتتعرف على أول تعريف صريح ظاهر.

### لماذا تبدو القيم الفعّالة أحيانًا متطابقة مع القيم المحلية؟

لأن القيمة المحلية أصبحت نهائية (لم يتطلب الأمر وراثة من مستوى أعلى). في هذه الحالة تتطابق القيمة الفعّالة مع القيمة المحلية.

### متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالعمل على الخصائص المحلية فقط؟

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة "كما يُعرض" بعد تطبيق جميع مستويات الوراثة، مثل مطابقة الألوان أو الهوامش أو الأحجام. إذا أردت الحفاظ على تلك القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائن خاص بك. إذا كان هدفك تعديل التنسيق على مستوى معين، قم بتعديل الخصائص المحلية ثم، إذا لزم الأمر، احصل على البيانات الفعّالة مرة أخرى للتحقق من النتيجة.
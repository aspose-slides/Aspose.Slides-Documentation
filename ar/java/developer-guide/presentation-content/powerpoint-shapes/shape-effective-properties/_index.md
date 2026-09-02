---
title: الحصول على خصائص الشكل الفعالة من العروض التقديمية في Java
linktitle: الخصائص الفعالة
type: docs
weight: 50
url: /ar/java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام إضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides لـ Java للتمييز بين تنسيق الشكل المحلي والوراثي والفعال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية والوراثية والفعالة**

يمكن أن يأتي تنسيق PowerPoint من عدة مصادر. القيمة المخزنة مباشرة على الكائن هي **القيمة المحلية**. إذا لم تُحدد تلك القيمة، يبحث PowerPoint عن مصادر التنسيق الوالدية، مثل الإعداد الافتراضي للفقرة، نمط النص، تخطيط أو شريحة رئيسية، سمة، أو الإعدادات الافتراضية على مستوى العرض. تلك القيم هي **القيم الموروثة**. القيمة التي تبقى بعد حل كامل التسلسل الهرمي هي **القيمة الفعالة**—القيمة المستخدمة لعرض الكائن.

على سبيل المثال، قد لا تحدد قطعة نصية ارتفاع الخط الخاص بها. تكون قيمتها المحلية [getFontHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) ثم `Float.NaN`، مما يعني "لم يتم تعيينه هنا". يمكن للقطعة أن ترث ارتفاعاً من فقرتها، أو نمط النص الافتراضي في العرض، أو مصدر آخر قابل للتطبيق. الاتصال بـ [getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportionformat/#getEffective--) على تنسيق القطعة يعيد الارتفاع النهائي المحلول.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- قراءة أو تعديل كائن تنسيق محلي، مثل [IPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportionformat/)، عندما تحتاج إلى التحكم في مكان تعريف القيمة.
- قراءة كائن بيانات فعالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportionformateffectivedata/)، عندما تحتاج إلى النتيجة النهائية المعروضة. البيانات الفعالة للقراءة فقط.

## **مقارنة القيم المحلية والوراثية والفعالة**

المثال الكامل التالي يخلق شكلًا ويطبق ارتفاعات الخط على مستوى العرض، الفقرة، والقطعة. كل خطوة تطبع القيم المحددة على تلك المستويات والقيمة الفعالة الناتجة لنفس قطعة النص. كما يوضح لماذا يجب قراءة البيانات الفعالة مرة أخرى بعد تغييرات التنسيق.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // حدد القيم الموروثة في مستويين مختلفين.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // القيمة المحلية على القطعة تتجاوز كلا القيمتين الموروثتين.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // تغيير قيمة وراثية لا يتجاوز قيمة محلية موجودة.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // امسح القيمة المحلية. الآن القطعة ترث من الفقرة مرة أخرى.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // امسح قيمة الفقرة. الآن الإعداد الافتراضي للعرض يزود النتيجة.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // اقرأ البيانات الفعالة بعد التغييرات السابقة.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

الأولوية في هذا المثال هي تنسيق القطعة المحلي، ثم تنسيق الفقرة، ثم الإعداد الافتراضي للعرض. يمكن للكائنات الأخرى أن يكون لها سلاسل وراثة مختلفة، لكن المبدأ هو نفسه: القيمة الصريحة الأكثر تحديدًا تفوز، و[getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportionformat/#getEffective--) يعيد النتيجة النهائية.

## **الحصول على خصائص النص الفعالة**

تنسيق النص مقسَّم عبر عدة كائنات:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#getEffective--) يحل خصائص إطار النص مثل الهوامش، التثبيت، الضبط التلقائي، واتجاه النص العمودي.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextstyle/#getEffective--) يحل تنسيق الفقرة لكل مستوى من مستويات نمط النص.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#getEffective--) يحل خصائص الفقرة مثل المحاذاة، الإزاحة، والنقاط.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportionformat/#getEffective--) يحل خصائص الحرف مثل ارتفاع الخط، نوع الخط، اللون، الغامق، والمائل.

للمثال التالي، يجب أن يحتوي `text-formatting.pptx` على شريحة واحدة على الأقل و[AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/) واحد بإطار نص غير فارغ. يمكن أن يظهر AutoShape في أي موضع ضمن مجموعة الأشكال؛ يبحث الكود عن كائن مناسب ويتحقق منه قبل الاستخدام.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **الحصول على الخصائص ثلاثية الأبعاد الفعالة**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getEffective--) يرجع كائنًا واحدًا من نوع [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformateffectivedata/) يجمع جميع إعدادات 3D المحلولة. طُرُق [getCamera](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--)، [getLightRig](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--)، [getBevelTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--)، و[getBevelBottom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) تعرض البيانات الفعالة المقابلة. قراءة هذه الإعدادات المرتبطة معًا يجعل فهم المظهر النهائي ثلاثي الأبعاد للشكل أسهل.

في هذا المثال، يجب أن يحتوي `shape-3d.pptx` على شكل واحد على الأقل في شريحته الأولى. طبّق إعدادات كاميرا 3D أو إضاءة أو انحدار على ذلك الشكل إذا أردت أن يحتوي الناتج على قيم غير الإعدادات الافتراضية.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **الحصول على تنسيق الجدول الفعال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول ومن التنسيقات المطبقة على الجدول بالكامل، أو عمود، أو صف، أو خلية فردية. في حالات التعارض بين التعبئات المعرفة صراحة، تكون الأولوية للخلية، ثم الصف، ثم العمود، ثم الجدول بالكامل. التنسيق الفعال للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

في هذا المثال، يجب أن يحتوي `table-formatting.pptx` على جدول واحد على الأقل في شريحته الأولى. يجب أن يحتوي الجدول على صف واحد على الأقل وعمود واحد. يبحث الكود عن [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itable/) بدلًا من الافتراض أن `getShapes().get_Item(0)` هو جدول.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

إذا كنت بحاجة إلى اللون بدلاً من مجرد نوع التعبئة، تحقق أولًا من [getFillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) الفعال، ثم اقرأ الطريقة التي تنطبق على ذلك النوع—مثلاً، [getSolidFillColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) لتعبئة صلبة.

## **إعادة قراءة البيانات الفعالة بعد التغييرات**

البيانات الفعالة تصف تسلسل تنسيق الهرمي في الوقت الذي يتم فيه حله. استدعِ `getEffective` مرة أخرى بعد تغيير أي شيء يمكن أن يشارك في ذلك الهرم، بما في ذلك:

- تنسيق الكائن المحلي؛
- إعدادات الفقرة أو إطار النص الافتراضية؛
- نمط الجدول، أو الجدول، أو العمود، أو الصف، أو تنسيق الخلية؛
- تنسيق التخطيط أو الشريحة الرئيسية؛
- بيانات السمة أو الإعدادات الافتراضية على مستوى العرض؛
- التخطيط أو الشريحة الرئيسية المعيَّنة لشريحة.

لا تحتفظ بكائن بيانات فعالة كلقطة دائمة. قد يقوم Aspose.Slides بتخزين بعض البيانات الفعالة داخليًا، ويمكن لاستدعاء لاحق لـ `getEffective` تحديث تلك البيانات. إذا كنت تحتاج إلى مقارنة القيم قبل وبعد التغيير، انسخ القيم الأساسية التي تحتاجها—مثل ارتفاع الخط، اللون، المحاذاة، أو عرض الانحدار—في متغيراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة، حدّث كائن التنسيق المحلي المناسب ثم استدعِ `getEffective` للتحقق من النتيجة. كائنات البيانات الفعالة نفسها للقراءة فقط.

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أي مستوى وفر القيمة الفعالة؟**

البيانات الفعالة تحتوي على القيمة النهائية، وليس مصدرها. افحص الكائنات المحلية القابلة للتطبيق بدءًا من المستوى الأكثر تحديدًا إلى الخارج. بالنسبة للنص، قد يشمل ذلك القطعة، الفقرة، إطار النص، التخطيط، الشريحة الرئيسية، السمة، وإعدادات العرض الافتراضية. القيم غير المعرفة مثل `Float.NaN` أو `null` تشير إلى أن البحث يستمر إلى مستوى آخر.

**ماذا يحدث إذا لم يحدد أي مستوى خاصية؟**

يقوم Aspose.Slides بحل الإعداد الافتراضي المناسب لـ PowerPoint أو للمكتبة. تظهر تلك القيمة المحلولة في البيانات الفعالة رغم أنه لا يوجد كائن محلي يعرّفها صراحة.

**لماذا تكون القيمة الفعالة أحيانًا مساوية للقيمة المحلية؟**

فازت القيمة المحلية بحساب الوراثة. هذا متوقع عندما تُحدد الخاصية صراحةً على الكائن ولا يتجاوزها قاعدة أكثر تحديدًا.

**متى يجب استخدام البيانات المحلية بدلًا من البيانات الفعالة؟**

استخدم البيانات المحلية لتفقد أو تعديل مستوى تنسيق معين. استخدم البيانات الفعالة عندما تحتاج إلى المظهر النهائي بعد حل الوراثة وقواعد السمة والأنماط المطبقة. يوضح مثال [المقارنة الكامل](#compare-local-inherited-and-effective-values) كلاً من الاستخدامين في نفس سير العمل.
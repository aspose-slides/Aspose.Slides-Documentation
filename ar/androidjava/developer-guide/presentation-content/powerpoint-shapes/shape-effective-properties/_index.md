---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية على أندرويد
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/androidjava/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- مجموعة إضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides لأندرويد عبر Java للتفريق بين تنسيق الشكل المحلي، الموروث، والفعّال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية والموروثة والفعّالة**

يمكن أن يأتي تنسيق PowerPoint من عدة مصادر. القيمة المخزنة مباشرة على كائن ما هي **القيمة المحلية**. إذا لم يتم تعيين هذه القيمة، فإن PowerPoint يبحث في مصادر التنسيق الأب، مثل الإعداد الافتراضي للفقرة، نمط النص، تخطيط أو الشريحة الرئيسية, السمة, أو الإعدادات الافتراضية على مستوى العرض التقديمي. تلك القيم هي **القيم الموروثة**. القيمة التي تبقى بعد حل الهرمية بالكامل هي **القيمة الفعّالة** — القيمة المستخدمة لعرض الكائن.

على سبيل المثال, قد لا تحدد جزء النص ارتفاع الخط الخاص به. فإن قيمته المحلية [getFontHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) تصبح `Float.NaN`, وهو ما يعني "غير معين هنا". يمكن للجزء ورث ارتفاع من الفقرة, أو نمط النص الافتراضي للعرض التقديمي, أو مصدر آخر مناسب. استدعاء [getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformat/#getEffective--) على تنسيق الجزء يُعيد الارتفاع النهائي المحلول.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- قراءة أو تعديل كائن تنسيق محلي, مثل [IPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformat/), عندما تحتاج إلى التحكم في المكان الذي تُحدد فيه القيمة.
- قراءة كائن بيانات فعّالة, مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformateffectivedata/), عندما تحتاج إلى النتيجة النهائية المعروضة. البيانات الفعّالة للقراءة فقط.

## **قارن القيم المحلية والموروثة والفعّالة**

المثال الكامل التالي ينشئ شكلًا ويطبق ارتفاعات الخط على مستويات العرض التقديمي والفقرة والجزء. كل خطوة تطبع القيم المعرفة على تلك المستويات والقيمة الفعّالة الناتجة لنفس جزء النص. كما يوضح لماذا يجب قراءة البيانات الفعّالة مرة أخرى بعد تغييرات التنسيق.

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

            // تحديد القيم الموروثة على مستويين مختلفين.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // القيمة المحلية في الجزء تتجاوز كلا القيمتين الموروثتين.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // تغيير قيمة موروثة لا يتجاوز القيمة المحلية الحالية.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // مسح القيمة المحلية. الآن يرث الجزء من الفقرة مرة أخرى.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // مسح قيمة الفقرة. الآن يتم توفير النتيجة من الإعداد الافتراضي للعرض التقديمي.
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

        // قراءة البيانات الفعّالة بعد التغييرات السابقة.
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

الأولوية في هذا المثال هي تنسيق الجزء المحلي, ثم تنسيق الفقرة, ثم الإعداد الافتراضي للعرض التقديمي. قد تمتلك الكائنات الأخرى سلاسل وراثة مختلفة, لكن المبدأ هو نفسه: القيمة الصريحة الأكثر تحديدًا تفوز, و[getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformat/#getEffective--) يرجع النتيجة النهائية.

## **احصل على خصائص النص الفعّالة**

تنسيق النص مقسّم عبر عدة كائنات:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getEffective--) يحل خصائص إطار النص مثل الهوامش, التثبيت, الضبط التلقائي, واتجاه النص العمودي.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextstyle/#getEffective--) يحل تنسيق الفقرة لكل مستوى من نمط النص.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) يحل خصائص الفقرة مثل المحاذاة, المسافة البادئة, والنقاط.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformat/#getEffective--) يحل خصائص الحرف مثل ارتفاع الخط, الخط, اللون, الغامق, والمائل.

في المثال التالي, يجب أن يحتوي الملف `text-formatting.pptx` على شريحة واحدة على الأقل وعلى [AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/) واحد بإطار نص غير فارغ. يمكن أن يظهر AutoShape في أي موقع داخل مجموعة الأشكال; يبحث الكود عن كائن مناسب ويقوم بالتحقق منه قبل الاستخدام.

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

## **احصل على الخصائص الثلاثية الأبعاد الفعّالة**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getEffective--) يُعيد كائنًا واحدًا من نوع [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/) يجمع جميع إعدادات الثلاثية الأبعاد المحلولة. تُظهر طرقه [getCamera](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), و[getBevelBottom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) البيانات الفعّالة المقابلة. قراءة هذه الإعدادات المرتبطة معًا يجعل من السهل فهم المظهر الثلاثي الأبعاد النهائي للشكل.

في هذا المثال, يجب أن يحتوي الملف `shape-3d.pptx` على شكل واحد على الأقل في شريحته الأولى. قم بتطبيق إعدادات كاميرا ثلاثية الأبعاد أو إضاءة أو حواف على ذلك الشكل إذا كنت تريد أن يحتوي الناتج على قيم مختلفة عن الإعدادات الافتراضية.

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

## **احصل على تنسيق الجدول الفعّال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول ومن التنسيقات المطبقة على الجدول كله, عمود, صف, أو خلية فردية. عند وجود تعارضات بين التعبئات المعرفة صراحةً, تكون الأولوية للخلية, ثم الصف, ثم العمود, ثم الجدول بأكمله. التنسيق الفعّال للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

في هذا المثال, يجب أن يحتوي الملف `table-formatting.pptx` على جدول واحد على الأقل في شريحته الأولى. يجب أن يحتوي الجدول على صف واحد على الأقل وعمود واحد. يبحث الكود عن [ITable](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itable/) بدلاً من افتراض أن `getShapes().get_Item(0)` هو جدول.

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

إذا كنت بحاجة إلى اللون بدلاً من نوع التعبئة فقط, تحقق أولاً من [getFillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) الفعّال, ثم اقرأ الطريقة التي تنطبق على ذلك النوع—على سبيل المثال, [getSolidFillColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) لتعبئة صلبة.

## **إعادة قراءة البيانات الفعّالة بعد التغييرات**

البيانات الفعّالة تصف هيكلية التنسيق في لحظة الحل. استدعِ `getEffective` مرة أخرى بعد تعديل أي شيء يمكن أن يشارك في تلك الهيكلية, بما في ذلك:

- تنسيق الكائن المحلي;
- الإعدادات الافتراضية للفقرة أو إطار النص;
- نمط جدول, جدول, عمود, صف, أو تنسيق خلية;
- تنسيق التخطيط أو الشريحة الرئيسية;
- بيانات السمة أو الإعدادات الافتراضية على مستوى العرض التقديمي;
- التخطيط أو الشريحة الرئيسية المعينة لشريحة.

لا تحتفظ بكائن بيانات فعّال كلقطة ثابتة. قد يقوم Aspose.Slides بتخزين بعض البيانات الفعّالة مؤقتًا داخليًا, ويمكن لاستدعاء `getEffective` لاحقًا تحديث تلك البيانات. إذا كنت بحاجة إلى مقارنة القيم قبل وبعد التغيير, انسخ القيم الاساسية التي تحتاجها—مثل ارتفاع الخط, اللون, المحاذاة, أو عرض الحافة—إلى متغيراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة, قم بتحديث كائن التنسيق المحلي المناسب ثم استدعِ `getEffective` للتحقق من النتيجة. كائنات البيانات الفعّالة نفسها للقراءة فقط.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أي مستوى قدم القيمة الفعّالة؟**

البيانات الفعّالة تحتوي على القيمة النهائية, وليس مصدرها. افحص الكائنات المحلية المطبقة بدءًا من المستوى الأكثر تحديدًا إلى الخارج. بالنسبة للنص, قد يشمل ذلك الجزء, الفقرة, إطار النص, التخطيط, الشريحة الرئيسية, السمة, وإعدادات العرض التقديمي الافتراضية. القيم غير المعرفة مثل `Float.NaN` أو `null` تشير إلى أن البحث يستمر إلى مستوى آخر.

**ماذا يحدث عندما لا يحدد أي مستوى خاصية؟**

يقوم Aspose.Slides بحل الإعداد الافتراضي المناسب من PowerPoint أو المكتبة. تظهر تلك القيمة المحلولة في البيانات الفعّالة بالرغم من أن لا كائن محلي يحددها صراحةً.

**لماذا تكون القيمة الفعّالة في بعض الأحيان مساوية للقيمة المحلية؟**

فازت القيمة المحلية في حساب الوراثة. هذا متوقع عندما يتم تعيين الخاصية صراحةً على الكائن ولا تتجاوزها قاعدة أكثر تحديدًا.

**متى يجب عليّ استخدام البيانات المحلية بدلاً من البيانات الفعّالة؟**

استخدم البيانات المحلية لفحص أو تعديل مستوى تنسيق محدد. استخدم البيانات الفعّالة عندما تحتاج إلى المظهر النهائي بعد تطبيق الوراثة, قواعد السمة, والأنماط المطبقة. مثال [complete comparison example](#compare-local-inherited-and-effective-values) يوضح كلاهما في نفس سير العمل.
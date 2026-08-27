---
title: إدارة أشكال العرض التقديمي في Java
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف شكل Interop
- النص البديل للشكل
- نقطة ضبط الشكل
- ضبط شكل مسبق
- هندسة الشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي وتعديلها واستنساخها وإزالتها وإخفائها وإعادة ترتيبها وتصديرها ومحاذاتها وقلبها باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تمثل مكتبة Aspose.Slides for Java الأشكال الموجودة على الشريحة كـ [IShapeCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/) مرتب. هذه المجموعة هي المكان الذي يمكنك فيه العثور على الأشكال وتعديلها وكذلك مصدر ترتيب تراكبها: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية التعرف على الشكل بشكل موثوق وتعديل نقاط الضبط المسبقة، ثم يظهر كيفية الاستنساخ والإزالة والإخفاء وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيقات مستوى التخطيط وتصدير SVG والمحاذاة وإعدادات الانعكاس. كل مثال مستقل، لذا يمكنك استخدام العمليات التي يحتاجها سير عملك فقط.

## **التعرف على الأشكال وإيجادها**

مؤشرات المجموعة مفيدة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. يمكن أن يغيّر إضافة أو إزالة أو إعادة ترتيب شكل مؤشره. اختر معرفًا وفقًا للطريقة التي يتم فيها إنشاء العرض التقديمي وصيانته:

- **[Name](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getName--)** مفيد للقوالب التي يتحكم فيها المطور ويسهل فحصه في لوحة التحديد ببرنامج PowerPoint. يمكن تعديل الأسماء ولا يُضمن أنها فريدة، لذا ضع convention للتسمية إذا كان الكود يعتمد عليها.
- **[AlternativeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getAlternativeText--)** مفيد عندما تكون وصفية الوصول أو الوسم المقدم من المؤلف هي التي تحدد الشكل بالفعل. وهي مرئية للمستخدمين، قد تُترجم أو تُعاد صياغتها من أجل الوصول، ولا يُضمن أنها فريدة. لا تُعيد استخدام نص وصول ذي معنى كمفتاح قاعدة بيانات بشكل صامت.
- **[OfficeInteropShapeId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)** معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم من قبل PowerPoint interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا غامض له طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يُعامل كشكل مختلف ويحصل على معرف خاص به.

طريقة **[getUniqueId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getUniqueId--)** المرتبطة تُعيد معرفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا يجب معاملته كمفتاح خارجي دائم. إذا كان التعرّف على المدى الطويل ضروريًا، احتفظ بالربط في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث بالاسم بمقارنة دقيقة ويُبلغ عن معرف Interop الخاص بالشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلاً من الاستمرار مع الكائن الخاطئ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

عند أن تكون العملية خاصة بنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. يحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المُسمّى من نوع **[IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/)**.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **التعرف على وضبط إحداثيات الشكل المسبقة**

يمكن للأشكال الهندسية المسبقة أن تكشف عن نقاط ضبط تتحكم في ميزات مثل حجم الزوايا، نسب السهام، أو زوايا الأقواس. يمكن الوصول إليها عبر مجموعة القراءة فقط **[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igeometryshape/#getAdjustments--)**. تُوفَّر المجموعة نفسها من قبل الشكل، لكن كل **[IAdjustValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/)** يحتوي على قيمة يمكن تغيرها.

لا تعتمد فقط على فهرس مجموعة ثابت. كرّر عبر الضبط وتفحص طريقة القراءة فقط **[getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#getType--)**، حيث يصف قيمة **ShapeAdjustmentType** ما يتحكم فيه الضبط. تُوفّر طريقة **[getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#getName--)** معلومات تعريفية إضافية وتكون مفيدة خصوصًا عندما يحتويpreset على أكثر من ضبط من نفس النوع الدلالي.

استخدم طريقة القيمة التي تتطابق مع معنى الضبط:

| نوع الضبط | الغرض | القيمة المطلوب تعديلها |
|---|---|---|
| `CornerSize` | حجم الزوايا المدورة | [setRawValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | سمك ذيل السهم | `setRawValue` |
| `ArrowheadLength` | طول رأس السهم | `setRawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `setRawValue` |
| `StartAngle` | الزاوية البداية لفطيرة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | الزاوية النهاية لفطيرة أو قوس | `setAngleValue` |

`getType` و `getName` تُعيدان معلومات قراءة فقط. `getRawValue` و `setRawValue` يعملان مع عدد صحيح بوحدات الهندسة الأصلية للpreset، بينما `getAngleValue` و `setAngleValue` يعملان مع زاوية بالدرجات. عدد وترتيب ومعنى ونطاق الضبط يعتمد على **[ShapeType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igeometryshape/#getShapeType--)** الخاص بالpreset. قد تكون قيمة صالحة لإعداد مسبق غير صالحة أو لها تأثير مختلف لإعداد آخر.

عندما تُعيد `getType` القيمة `ShapeAdjustmentType.Custom`، لا يتعرف API على معنى دلالي قياسي. تفحص `getName`، ونوع الـpreset، والقيمة الحالية، واترك الضبط دون تغيير ما لم تُعرف المعنى والنطاق المتوقع. حتى للأنواع المعروفة، تحقق مما إذا كان النوع نفسه يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة **[Connector](/slides/ar/java/connector/)** هذا الوضع مع ضبط انحناءات الموصل.

المثال الكامل التالي ينشئ إصدارات افتراضية ومعدلة لثلاثة أشكال مسبقة. يكرّر عبر كل ضبط، يُبلغ عن اسمه ونوعه، يغيّر القيم المتعلقة بالحجم عبر `setRawValue`، ويغيّر الزوايا عبر `setAngleValue`، ثم يحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المدور المعدل، والسهم رباعي الاتجاهات، والفطيرة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يضيف رؤوسًا لأعمدة الشكل الافتراضي والمعدل.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

التحقق من النوع الدلالي قبل تغيير قيمة يجعل الكود واضحًا بشأن نيته ويتجنب الافتراض بأن فهرس مجموعة معين له نفس المعنى عبر أشكال مسبقة مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب على المجموعة فورًا. إذا غيرت عملية ما عدد أو ترتيب الأشكال، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

**[addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)** ينشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة المستهدفة. **[insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)** أيضًا ينشئ نسخة لكنه يضعها في فهرس z-order محدد. التحميل الزائد الذي يقبل إحداثيات ينقل النسخة دون تغيير حجمها؛ التحميل الزائد مع العرض والارتفاع يمكنه تغيير حجمه أيضًا.

ينشئ المثال شريحة هدف، يستنسخ مستطيلًا مسمى إلى الأمام، ثم يُدخل نسخة ثانية إلى الخلف. لا تؤثر التغييرات على أي نسخة على الشكل المصدر.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرّفات منطقية جديدة للنسخة عندما يجب أن تكون هذه القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقَّدة يديرها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة له هوية شكل جديدة.

### **إزالة الأشكال**

**[remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)** يحذف كائن شكل محدد من مجموعته. عند إزالة تطابقات متعددة خلال تكرار بفهرس، تجول من النهاية حتى يبقى كل فهرس متبقٍ صالحًا.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي، وليس عنصر مجموعة ثابت، ولا يقوم بتحويل النوع دون ضرورة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تظل المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. كما يجب أن تأخذ في الاعتبار الموصلات، الرسوم المتحركة، وميزات العرض الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل مرئي قد تغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط **[Hidden](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setHidden-boolean-)** إلى `true` يبقي الشكل في المجموعة لكنه يمنع ظهوره في عرض الشرائح العادي. يبقى فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا فإن الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بالإمكان اكتشاف الكائن وإظهاره مرة أخرى من قبل مستخدم أو كود، ويبقى جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. **[reorder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)** ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `size() - 1` هو الأمام.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يُنشأ المستطيل أولًا ويجلس في البداية خلف الشكل البيضاوي. نقله إلى الفهرس النهائي يضعه في الأمام. أكمل ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن هذه العمليات تُضيف أو تُدرج عناصر مجموعة جديدة وقد تُغيّر التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

تحتوي الشرائح العادية، شرائح التخطيط، والشرائح الأساسية على مجموعات أشكال منفصلة. الشكل الموجود في مجموعة التخطيط ليس نفس الكائن الموجود على شريحة عادية في موضع مماثل. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تعديل تنسيق يُوفره التخطيط.

المثال التالي يقرأ **[FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getFillFormat--)** و **[LineFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getLineFormat--)** لكل شكل تخطيط دون افتراض أن كل شكل هو `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تعديل شكل في التخطيط، حدّد ما إذا كانت شريحة عادية تُورّث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

**[writeAsSvg](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)** يكتب محتوى شكل واحد مُرَسَم إلى Stream. النتيجة تحتوي على الشكل فقط، دون خلفية الشريحة بالكامل أو الأشكال المجاورة.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت تحتاج إلى كامل التركيبة، صدّر الشريحة بدلًا من الشكل الفردي. المرمِّة يمتلك الـStream ويجب إغلاقه.

## **محاذاة الأشكال**

طرق **[SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)** لديها تحميل زائد يُمحاذ جميع الأشكال أو فهارس مجموعة مختارة. يحدد **[ShapesAlignmentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapesalignmenttype/)** الحافة أو الخط المركزي أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المختارة نسبةً إلى بعضها البعض.

هذا المثال يُحاذ ثلاثة أشكال إلى الحافة العليا للشريحة. تُحوَّل مراجع الأشكال المرجعة إلى فهارسها الحالية مباشرةً قبل المحاذاة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المحاذاة تغير المواقع، لا ترتيب Z. عادةً ما تحتاج المحاذاة النسبية إلى شكلين على الأقل، بينما يتطلب التوزيع الأفقي أو العمودي عددًا كافيًا من الأشكال لتحديد المسافات. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **انعكاس شكل**

فئة **[ShapeFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapeframe/)** تُخزّن الموقع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيمتي `getFlipH` و `getFlipV` تستخدمان **[NullableBool](https://reference.aspose.com/slides/ar/java/com.aspose.slides/nullablebool/)**: `True` يفعّل الانعكاس، `False` يعطّله، و `NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي الإدخالي أدناه يحتوي على شكل غير معكوس.

![الشكل قبل الانعكاس](shape_to_be_flipped.png)

يحافظ المثال على كل قيمة إطار أخرى ويستبدل إعدادات الانعكاس فقط. هذا مهم لأن تعيين **[Frame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)** جديد يستبدل الإطار بالكامل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الشكل المحفوظ يُعكَّس أفقياً ورأسياً مع الاحتفاظ بموقعه، حجمه، ودورانه.

![الشكل بعد الانعكاس](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يجب أن أستخدم فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة القصيرة الأمد عندما لا تتغيّر المجموعة قبل استخدام الفهرس. يُفضَّل اعتبار `Name` أو `AlternativeText` بمفهوم موثَّق للقوالب المُنشأة، أو `OfficeInteropShapeId` للمهام التي تتطلب تفاعلًا مع PowerPoint على مستوى الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يضيف النسخة إلى نهاية المجموعة، وهي أمامية ترتيب Z. استخدم `insertClone` لاختيار الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل مسبق؟**

فقط بعد التحقق من أن الـpreset وتخطيط المجموعة محددان بدقة. يُفضَّل التكرار عبر `IGeometryShape.getAdjustments` والتحقق من `IAdjustValue.getType`؛ واستخدم `IAdjustValue.getName` كمعلومات إضافية عندما يظهر النوع الدلالي نفسه أكثر من مرة.
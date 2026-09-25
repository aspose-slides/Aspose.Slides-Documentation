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
- البحث عن شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرّف الشكل Interop
- نص بديل للشكل
- نقطة تعديل الشكل
- تعديل شكل مسبق
- هندسة الشكل
- تنسيقات تخطيط الشكل
- شكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية تحديد وتعديل واستنساخ وإزالة وإخفاء وإعادة ترتيب وتصدير ومحاذاة وقلب أشكال العرض التقديمي باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

يمثل Aspose.Slides for Java الأشكال الموجودة على الشريحة كمجموعة مرتبة من نوع [IShapeCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/). تُعدّ المجموعة هي المكان الذي تجد فيه الأشكال وتُعدِّلها في آنٍ واحد، وكذلك مصدر ترتيب تكدسها: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال ذلك النموذج. يوضح أولاً كيفية تحديد شكل موثوق به وتعديل نقاط تعديل الشكل المسبق، ثم يظهر كيفية استنساخ، إزالة، إخفاء وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق مستوى التخطيط، تصدير SVG، المحاذاة وإعدادات القلب. كل مثال مستقل، لذا يمكنك استخدام العمليات التي يحتاجها سير العمل الخاص بك فقط.

## **تحديد وإيجاد الأشكال**

فهارس المجموعة ملائمة أثناء معالجة ملف معروف، لكنها ليست معرّفات ثابتة. إضافة أو إزالة أو إعادة ترتيب شكل يمكن أن يغيّر فهرسه. اختر معرّفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getName--) مفيد للقوالب التي يتحكم فيها المطور ويسهل فحصه في لوحة التحديد في PowerPoint. يمكن تحرير الأسماء ولا يُضمن أنها فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getAlternativeText--) مفيد عندما يكون وصف الإتاحة أو علامة يضيفها المؤلف قد حددت الشكل بالفعل. هو مرئي للمستخدمين، قد يتم تعريبه أو إعادة صياغته للإتاحة، ولا يُضمن أنه فريد. لا تعيد استخدام نص إتاحة ذو معنى كمعرّف قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) هو معرّف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرّف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج مرجعًا لا لبس فيه طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يُعتبر شكلًا مختلفًا ويحصل على معرّف خاص به.

الطريقة المرتبطة [getUniqueId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getUniqueId--) تُرجع معرّفًا بنطاق العرض التقديمي، لكن هذا المعرّف مخصص للإضافات ويمكن إعادة تعيينه. لا ينبغي اعتباره مفتاحًا خارجيًا دائمًا. إذا كان الهوية على المدى الطويل ضرورية، احتفظ بعملية الربط في بيانات التطبيق وتأكد من أن الشكل المتوقع لا يزال موجودًا.

لمثال عملي على قراءة وتحديث كل من عنوان النص البديل ووصفه، راجع [Manage Alternative Text Titles and Descriptions](/slides/ar/java/presentation-accessibility/). استخدم النص البديل لشرح معنى العنصر البصري للقراء، واحتفظ به منفصلًا عن أسماء الأشكال التي يستخدمها الكود للعثور على الأشكال.

المثال التالي يبحث بالاسم باستخدام مقارنة دقيقة ويُبلغ عن معرّف Interop بنطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلًا من الاستمرار في الكائن الخاطئ.

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

عند كون عملية ما خاصة بنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. يُحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المسمى من نوع [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).

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

## **تحديد وتعديل تعديلات الشكل المسبقة**

يمكن للأشكال الهندسية المسبقة كشف نقاط تعديل تتحكم في خصائص مثل حجم الزوايا، نسب السهام أو زوايا الأقواس. يمكن الوصول إليها عبر مجموعة القراءة فقط [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igeometryshape/#getAdjustments--) . تُزود الشكل المجموعة، لكن كل [IAdjustValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/) يحتوي على قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. استعرض التعديلات وتفحص طريقة القراءة فقط [getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#getType--)، التي تُعيد قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapeadjustmenttype/) التي تصف ما يتحكم به التعديل. تُوفر طريقة القراءة فقط [getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#getName--) معلومات تعريف إضافية وتكون مفيدة خصوصًا عندما يحتوي مسبق على أكثر من تعديل من نفس النوع الدلالي.

استخدم طريقة القيمة التي تطابق معنى التعديل:

| نوع التعديل | الغرض | القيمة المطلوب تغييرها |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [setRawValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | سمك ذيل السهم | `setRawValue` |
| `ArrowheadLength` | طول رأس السهم | `setRawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `setRawValue` |
| `StartAngle` | زاوية البداية لفطيرة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | زاوية النهاية لفطيرة أو قوس | `setAngleValue` |

`getType` و `getName` تُعيدان معلومات للقراءة فقط. `getRawValue` و `setRawValue` تعملان مع عدد صحيح بوحدات الهندسة الأصلية للمسبق، بينما `getAngleValue` و `setAngleValue` تعملان مع زاوية بالدرجات. العدد، الترتيب، المعنى والنطاق الصالح للتعديلات يعتمد على [ShapeType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igeometryshape/#getShapeType--) للمسبق. قد تكون القيمة صالحة لمسبق معين وغير صالحة أو لها تأثير مختلف لمسبق آخر.

عند إرجاع `getType` القيمة `ShapeAdjustmentType.Custom`، لا يتعرف الـ API على معنى دلالي قياسي. فحص `getName`، نوع المسبق، والقيمة الحالية، واترك التعديل دون تغيير ما لم يكن المعنى والنطاق معروفين. حتى للأنواع المعروفة، تحقق ما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة [Connector](/slides/ar/java/connector/) هذا الوضع مع تعديلات انحناء الموصل.

المثال الكامل التالي يُنشئ إصدارات افتراضية ومُعدَّلة لثلاثة أشكال مسبقة. يستعرض كل تعديل، يُبلغ عن اسمه ونوعه، يغيّر القيم المرتبطة بالحجم عبر `setRawValue`، يغيّر الزوايا عبر `setAngleValue`، ويحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المُعدَّل، والسهم رباعي الاتجاهات، والفطيرة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يضيف رؤوسًا للأعمدة الافتراضية والمعدلة للأشكال.
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

التحقق من النوع الدلالي قبل تغيير القيمة يجعل الكود صريحًا بشأن نواياه ويتجنب افتراض أن فهرس مجموعة معين له نفس المعنى عبر أشكال مسبقة مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة وإعادة الترتيب على المجموعة فورًا. إذا غيّرت عملية ما عدد الأشكال أو ترتيبها، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) يُنشئ نسخة مستقلة ويضيفها إلى نهاية مجموعة الهدف. [insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) أيضًا يُنشئ نسخة ولكنه يضعها في فهرس z-order محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تشمل العرض والارتفاع يمكنها تغيير الحجم أيضًا.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا مُعنونًا إلى الأمام، ويُدخل نسخة ثانية إلى الخلف. لا تُغيّر التغييرات على أي نسخة الشكل الأصلي.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. ضع معرّفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقَّدة تُدار بواسطة العرض التقديمي، لكن النسخة تظل عنصر مجموعة جديد به هوية شكل جديدة.

### **إزالة الأشكال**

[remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) يحذف كائن شكل محدد من مجموعته. عند إزالة عدة تطابقات أثناء تكرار فهرسي، تجول من النهاية بحيث يبقى كل فهرس متبقٍ صالحًا.

المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي، لا عنصر مجموعة ثابت، ولا يُحوِّل الشكل دون داع.

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

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تظل المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، الرسوم المتحركة والميزات الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل مرئي قد تغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Hidden](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setHidden-boolean-) إلى `true` يبقي الشكل في المجموعة لكنه يمنع ظهوره في عرض الشرائح العادي. يبقى فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا يُناسب الإخفاء العناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهارّه مرة أخرى، ويظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. [reorder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `size() - 1` هو الأمام.

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

يتم إنشاء المستطيل أولاً ويقع في البداية خلف القطعة الناعمة. نقله إلى الفهرس النهائي يجعله في الأمام. أكِّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدخل عناصر مجموعة جديدة وقد تُغيّر التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

تملك الشرائح العادية، شرائح التخطيط، والشرائح الرئيسية مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس نفس الكائن الموجود على شريحة عادية في موقع مماثل. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير التنسيق المقدم من تخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getFillFormat--) و [LineFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getLineFormat--) لشكل التخطيط دون افتراض أن كل شكل هو `AutoShape`.

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

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[writeAsSvg](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) يكتب محتوى شكل مُصوَّر إلى تدفق. النتيجة تحتوي على الشكل فقط، وليس خلفية الشريحة بالكامل أو الأشكال المجاورة.

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

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا احتجت إلى التكوين الكامل، صدِّر الشريحة بدلاً من شكل فردي. الكود المتصل يملك التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) يملك تحميلات تُحاذِّـى إما جميع الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapesalignmenttype/) يحدد الحافة أو الخط المركزي أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المحدَّدة نسبةً إلى بعضها البعض.

المثال يُحاذِى ثلاثة أشكال إلى الحافة العلوية للشريحة. مراجع الأشكال المرتجعة تُتحوَّل إلى فهارسها الحالية فورًا قبل المحاذاة.

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

المحاذاة تغيّر المواقع، لا ترتيب Z. عادةً ما تحتاج المحاذاة النسبية إلى شكلين على الأقل، بينما تتطلب التوزيعات الأفقية أو العمودية عددًا كافيًا من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدَّلت المجموعة قبل استدعاء الطريقة.

## **قلب شكل**

تخزن الفئة [ShapeFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapeframe/) الموقع، الحجم، إعدادات القليب الأفقي والعمودي، والدوران. قيمتي `getFlipH` و `getFlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/java/com.aspose.slides/nullablebool/): `True` يفعّل القليب، `False` يعطّله، و `NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلوب.

![الشكل قبل القلابة](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل فقط إعدادات القليب الثنائية. هذا أمر مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جديد يستبدل الإطار بالكامل.

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

الشكل المحفوظ يُعكس أفقياً وعمودياً مع الحفاظ على موقعه وحجمه ودورانه.

![الشكل بعد القلابة](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب أن أستخدم فهرس المجموعة كمعرّف للشكل؟**

فقط للمعالجة القصيرة الأمد عندما لا يتغير عدد الأشكال أو ترتيبها قبل استخدام الفهرس. يفضَّل اعتماد معيار `Name` أو `AlternativeText` للقوالب المُصمَّمة، أو `OfficeInteropShapeId` للعمل التفاعلي داخل الشريحة.

**هل الإخفاء يحذف الشكل من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة في نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهارُه مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يُضيف النسخة إلى نهاية المجموعة، وهي الأمام في ترتيب Z. استخدم `insertClone` لتحديد الفهرس الابتدائي أو `reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد تعديل شكل مسبق؟**

فقط بعد التحقق من المسبق المحدد وترتيب المجموعة بدقة. يفضَّل التكرار عبر `IGeometryShape.getAdjustments` وفحص `IAdjustValue.getType`؛ استخدم `IAdjustValue.getName` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.
---
title: إدارة أشكال العرض التقديمي على Android
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/androidjava/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل التفاعلي
- نص بديل للشكل
- نقطة ضبط الشكل
- ضبط الشكل المسبق
- هندسة الشكل
- تنسيقات تخطيط الشكل
- الشكل كملف SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تحديد وتعديل واستنساخ وإزالة وإخفاء وإعادة ترتيب وتصدير ومحاذاة وقلب أشكال العرض التقديمي باستخدام Aspose.Slides for Android عبر Java."
---
## **نظرة عامة**

يمثل Aspose.Slides for Android عبر Java الأشكال في الشريحة كـ[IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/). المجموعة هي المكان الذي تجد فيه الأشكال وتعدلها وكذلك مصدر ترتيب تكدسها: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى المقدمة.

يتبع هذا المقال ذلك النموذج. يشرح أولاً كيفية تحديد الشكل بشكل موثوق وتعديل نقاط ضبط الشكل المسبقة، ثم يوضح كيفية استنساخ الشكل، إزالته، إخفائه، وإعادة ترتيبه. تغطي الأقسام النهائية تنسيق مستوى التخطيط، تصدير SVG، المحاذاة، وإعدادات القلب. كل مثال مستقل، لذلك يمكنك استخدام العمليات التي يتطلبها سير عملك فقط.

## **تحديد وإيجاد الأشكال**

تكون فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرفات ثابتة. يمكن أن يغيّر إضافة أو إزالة أو إعادة ترتيب شكل فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getName--) مفيد للقوالب التي يتحكم فيها المطور ويسهل فحصه في لوحة التحديد في PowerPoint. يمكن تعديل الأسماء ولا يُضمن أنها فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getAlternativeText--) مفيد عندما يحدد وصف إمكانية الوصول أو الوسم المقدم من المؤلف الشكل بالفعل. هو مرئي للمستخدمين، يمكن ترجمته أو إعادة صياغته للتسهيل، ولا يُضمن أنه فريد. لا تعيد توظيف نص إمكانية وصول ذي معنى كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا لبس فيه طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يكون شكلًا مختلفًا ويتلقى معرفه الخاص.

طريقة [getUniqueId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getUniqueId--) المرتبطة تُعيد معرفًا بنطاق العرض التقديمي، لكن ذلك المعرف موجه للإضافات ويمكن إعادة تعيينه. لا ينبغي معالجته كمفتاح خارجي دائم. إذا كانت هوية طويلة الأمد ضرورية، احتفظ بالتحويل في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

لمثال عملي حول قراءة وتحديث عنوان النص البديل ووصفه، راجع [Manage Alternative Text Titles and Descriptions](/slides/ar/androidjava/presentation-accessibility/). استخدم النص البديل لشرح معنى العنصر البصري للقارئين، واحتفظ به منفصلًا عن أسماء الأشكال التي يستخدمها الكود للعثور على الأشكال.

يبحث المثال التالي عن الاسم بمقارنة دقيقة ويبلغ عن معرف التفاعل على مستوى الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلاً من المتابعة مع الكائن الخاطئ.

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

عند كون العملية خاصة بنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. يُحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المسمى من نوع [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).

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

## **تحديد وتعديل ضبط الأشكال المسبق**

يمكن للأشكال الهندسية المسبقة أن تُظهر نقاط ضبط تتحكم في خصائص مثل حجم الزاوية، نسب السهم، أو زوايا القوس. يمكن الوصول إليها عبر مجموعة القراءة فقط [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . تُزوَّد المجموعة نفسها من الشكل، لكن كل [IAdjustValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/) يحتوي على قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر الضبط وتفحص طريقة القراءة فقط [getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#getType--)، التي تُعيد قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapeadjustmenttype/) التي توصف ما يتحكم فيه الضبط. طريقة القراءة فقط [getName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#getName--) تُقدم معلومات تعريف إضافية وتكون مفيدة خصوصًا عندما يحتوي مسبق على أكثر من ضبط له نفس النوع الدلالي.

استخدم طريقة القيمة التي تتطابق مع معنى الضبط:

| نوع التعديل | الغرض | القيمة التي يجب تغييرها |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [setRawValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | سمك ذيل السهم | `setRawValue` |
| `ArrowheadLength` | طول رأس السهم | `setRawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `setRawValue` |
| `StartAngle` | الزاوية البداية لفطيرة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | الزاوية النهاية لفطيرة أو قوس | `setAngleValue` |

تُعيد `getType` و`getName` معلومات قراءة فقط. تعمل `getRawValue` و`setRawValue` مع عدد صحيح بوحدات الهندسة الأصلية للمسبق، بينما تعمل `getAngleValue` و`setAngleValue` مع زاوية بالدرجات. يعتمد عدد، وترتيب، ومعنى، والنطاق الصالح للضبط على [ShapeType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) للمسبق. قد تكون قيمة صالحة لمسبق ما غير صالحة أو لها تأثير مختلف لمسبق آخر.

عندما تُعيد `getType` القيمة `ShapeAdjustmentType.Custom`، لا يتعرف API على معنى دلالي قياسي. تفقد `getName`، نوع المسبق، والقيمة الحالية، واترك الضبط دون تغيير إلا إذا كان المعنى والنطاق معروفين. حتى للأنواع المعروفة، تحقق مما إذا كان النوع نفسه يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة [Connector](/slides/ar/androidjava/connector/) هذا الوضع مع ضبط انحناء الموصل.

المثال الكامل التالي يُنشئ نسخًا افتراضية ومُعدلة من ثلاثة أشكال مسبقة. يكرر عبر كل ضبط، يُبلغ عن اسمه ونوعه، يغيّر القيم المتعلقة بالحجم عبر `setRawValue`، ويغيّر الزوايا عبر `setAngleValue`، ويحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المُعدَّل، السهم رباعي الاتجاهات، والفطيرة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يضيف عناوين لأعمدة الشكل الافتراضي والمعدل.
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

التحقق من النوع الدلالي قبل تغيير القيمة يجعل الكود صريحًا بشأن نيته ويتجنب الافتراض بأن فهرس مجموعة معين له نفس المعنى عبر أشكال مسبقة مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب على المجموعة فورًا. إذا غيرت عملية ما عدد أو ترتيب الأشكال، لا تستمر بالاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) يُنشئ نسخة مستقلة ويضيفها إلى مجموعة الهدف. [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) يُنشئ نسخة أيضًا لكنه يضعها عند فهرس ترتيب Z محدد. التحميل الزائد الذي يقبل إحداثيات ينقل النسخة دون تغيير حجمها؛ التحميل الزائد الذي يحدد العرض والارتفاع يمكنه تغيير حجمها كذلك.

ينشئ المثال شريحة هدف، يستنسخ مستطيلًا مُعنونًا إلى المقدمة، ويُدرج نسخة ثانية إلى الخلف. لا تُعدّل أي من النسختين المصدر.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. تُدار الموارد المستخدمة بواسطة الأشكال المعقدة عبر العرض التقديمي، لكن النسخة تبقى عنصرًا جديدًا في المجموعة بمعرف شكل جديد.

### **إزالة الأشكال**

[remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) يحذف كائن شكل محدد من مجموعته. عند إزالة عدة تطابقات أثناء تكرار فهارس، انتقل من النهاية بحيث يظل كل فهرس متبقٍ صالحًا.

يزيل هذا المثال كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي، ليس عنصرًا ثابتًا في المجموعة، ولا يُجري تحويلًا غير ضروري للنوع.

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

بعد الإزالة، يتغير عدد الأشكال وفهارس الأشكال اللاحقة. تبقى المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ قد يغيّر إزالة شكل مرئي أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Hidden](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) إلى `true` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يبقى فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا يُعد الإخفاء مناسبًا للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهاره مرة أخرى، وهو يظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

تُرسم الأشكال المتداخلة بترتيب المجموعة. [reorder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `size() - 1` هو المقدمة.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يُنشأ المستطيل أولًا ويقع في البداية خلف الإهليلج. نقله إلى الفهرس النهائي يجعله في المقدمة. أكّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن هذه العمليات تُضيف أو تُدرج عناصر مجموعة جديدة ويمكن أن تغير التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

للشرائح العادية، وشرائح التخطيط، والشرائح الرئيسة مجموعات أشكال منفصلة. الشكل في مجموعة تخطيط ليس هو نفسه كائن الشكل المماثل في شريحة عادية. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تعديل التنسيق المزوَّد من قبل التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getFillFormat--) و[LineFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getLineFormat--) للشكل في التخطيط دون افتراض أن كل شكل هو `AutoShape`.

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

تحرير تخطيط يمكن أن يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدِّد ما إذا كانت شريحة عادية تورث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[writeAsSvg](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) يكتب محتوى شكل مُرَسَم إلى تيار. النتيجة تحتوي على الشكل فقط، لا خلفية الشريحة بأكملها أو الأشكال المجاورة.

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

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى الموارد مثل الخطوط والصور. إذا كنت بحاجة إلى التكوين الكامل، صدّر الشريحة بدلًا من الشكل الفردي. المتصل يملك التيار ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) يوفّر إما محاذاة جميع الأشكال أو فهارس مجموعة مختارة. تحدد [ShapesAlignmentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapesalignmenttype/) الحافة، أو الخط المركزي، أو وضع التوزيع. عيّن `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ عيّنه إلى `false` لمحاذاة الأشكال المحددة بالنسبة إلى بعضها البعض.

المثال التالي يُحاذِى ثلاثة أشكال إلى الحافة العلوية للشريحة. تُحوَّل مراجع الأشكال المرجعة إلى فهارسها الحالية مباشرةً قبل المحاذاة.

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

تغيّر المحاذاة المواقع، لا ترتيب Z. عادةً ما تحتاج المحاذاة النسبية إلى شكلين على الأقل، بينما تتطلب التوزيعات الأفقية أو العمودية عددًا كافيًا من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **قلب الشكل**

تخزّن فئة [ShapeFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapeframe/) الموقع، والحجم، وإعدادات القلب الأفقي والعمودي، والدوران. قيمتي `getFlipH` و`getFlipV` تستخدمان [NullableBool](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/nullablebool/): `True` يُفعِّل القلب، `False` يُعطِّله، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلوب.

![The shape before flipping](shape_to_be_flipped.png)

يحافظ المثال على كل قيمة إطار أخرى ويستبدل فقط إعدادات القلب الاثنين. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جديد يستبدل الإطار بالكامل.

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

يُحفظ الشكل معكوسًا أفقيًا وعموديًا مع الحفاظ على موقعه وحجمه ودورانه.

![The shape after flipping](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب عليّ استخدام فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لن تتغير المجموعة قبل استخدام الفهرس. يُفضَّل اعتماد اتفاقية `Name` أو `AlternativeText` للقوالب المُنشأة، أو `OfficeInteropShapeId` للعمل التفاعلي على مستوى الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يظل الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر شكل مستنسخ أمام شكل آخر؟**

`addClone` يضيف النسخة إلى نهاية المجموعة، وهي مقدمة ترتيب Z. استخدم `insertClone` لاختيار الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل مسبق؟**

فقط بعد التحقق من المسبق المحدد وتخطيط المجموعة بدقة. يُفضَّل التكرار عبر `IGeometryShape.getAdjustments` وفحص `IAdjustValue.getType`؛ استخدم `IAdjustValue.getName` كمعلومات إضافية عندما يظهر النوع الدلالي نفسه أكثر من مرة.
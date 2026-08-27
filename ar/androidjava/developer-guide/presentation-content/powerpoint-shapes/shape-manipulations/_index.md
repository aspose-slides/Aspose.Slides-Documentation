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
- البحث عن شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل interop
- نص بديل للشكل
- نقطة ضبط الشكل
- ضبط الشكل المسبق
- هندسة الشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- عكس الشكل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي وتعديلها واستنساخها وإزالتها وإخفائها وإعادة ترتيبها وتصديرها ومحاذاتها وعكسها باستخدام Aspose.Slides for Android عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يمثل الأشكال على الشريحة كمجموعة مرتبة من [IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/). تُعد المجموعة هي المكان الذي تجد فيه وتعدل الأشكال ومصدر ترتيب تكدسها: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية التعرف على الشكل موثوقًا وتعديل نقاط ضبط الشكل المسبقة، ثم يُظهر كيفية استنساخ، إزالة، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق مستوى التخطيط، تصدير SVG، المحاذاة، وإعدادات الانعكاس. كل مثال مستقل، بحيث يمكنك استخدام العمليات التي يتطلبها سير عملك فقط.

## **التعرف على الأشكال وإيجادها**

تعد فهارس المجموعة مريحة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. يمكن أن يغيّر إضافة أو إزالة أو إعادة ترتيب شكل فهرسه. اختر معرفًا وفقًا لطريقة إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getName--) مفيد للقوالب التي يتحكم فيها المطور ويسهل فحصه في لوحة الاختيار في PowerPoint. يمكن تعديل الأسماء ولا يُضمن أنها فريدة، لذا ضع convention تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getAlternativeText--) مفيد عندما يكون وصف إمكانية الوصول أو علامة يضيفها المؤلف تحدد الشكل بالفعل. هو مرئي للمستخدمين، قد يُترجم أو يُعاد صياغته لإمكانية الوصول، ولا يُضمن أنه فريد. لا تُعيد استخدام نص إمكانية الوصول ذو المعنى كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا لبس فيه طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يكون شكلًا مختلفًا ويحصل على معرف خاص به.

الطريقة المرتبطة [getUniqueId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getUniqueId--) تُعيد معرفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا ينبغي اعتباره مفتاحًا خارجيًا دائمًا. إذا كان الهوية طويلة الأمد ضرورية، احتفظ بربطها في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن طريق الاسم بمقارنة دقيقة ويُبلغ عن معرف interop للنطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن ذلك بدلاً من المتابعة مع الكائن الخطأ.

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

عندما تكون عملية معينة لنوع شكل معين، افحص الواجهة قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يُحدّث النص والنص البديل فقط إذا كان الكائن المُسمّى من نوع [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).

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

## **التعرف على وضبط تعديلات الشكل المسبق**

يمكن للأشكال الهندسية المسبقة الإعداد أن تعرض نقاط ضبط تتحكم في خصائص مثل حجم الزاوية، نسب السهم، أو زوايا القوس. وصول إليها عبر مجموعة القراءة فقط [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . تُزوّد المجموعة نفسها الشكل، لكن كل [IAdjustValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/) يحتوي على قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر التعديلات وتفقد طريقة القراءة فقط [getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#getType--)، حيث تُصف قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapeadjustmenttype/) ما يتحكم به الضبط. تُوفر طريقة القراءة فقط [getName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#getName--) معلومات تعريفية إضافية وتكون مفيدة خاصةً عندما يحتوي الإعداد المسبق على أكثر من تعديل بنوع دلالي واحد.

استخدم طريقة القيمة التي تتطابق مع معنى الضبط:

| نوع الضبط | الغرض | القيمة التي تُغيّر |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [setRawValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | سمك ذيل السهم | `setRawValue` |
| `ArrowheadLength` | طول رأس السهم | `setRawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `setRawValue` |
| `StartAngle` | زاوية البداية لفطيرة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | زاوية النهاية لفطيرة أو قوس | `setAngleValue` |

`getType` و `getName` تُعيد معلومات للقراءة فقط. `getRawValue` و `setRawValue` تعمل مع عدد صحيح بوحدات الهندسة الأصلية للإعداد المسبق، بينما `getAngleValue` و `setAngleValue` تعمل مع زاوية بالدرجة. عدد وترتيب ومعنى ونطاق التعديلات يعتمد على [ShapeType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) المسبق. قد تكون قيمة صالحة لإعداد مسبق غير صالحة أو تُحدث تأثيرًا مختلفًا لإعداد آخر.

عندما تُعيد `getType` القيمة `ShapeAdjustmentType.Custom`، لا تتعرف الـ API على معنى دلالي قياسي. افحص `getName`، نوع الإعداد المسبق، والقيمة الحالية، واترك الضبط دون تغيير ما لم تُعرف المعنى والنطاق المتوقعين. حتى للأنواع المعروفة، تحقق مما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة [Connector](/slides/ar/androidjava/connector/) هذا الوضع مع تعديلات انحناء الموصل.

المثال الكامل التالي يُنشئ إصدارات افتراضية ومُعدلة لثلاثة أشكال مسبقة. يكرّر عبر كل تعديل، يُبلغ عن اسمه ونوعه، يغيّر القيم المرتبطة بالحجم عبر `setRawValue`، ويغيّر الزوايا عبر `setAngleValue`، ثم يحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المعدل، السهم رباعي الاتجاهات، والفطيرة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يضيف رؤوسًا لأعمدة الشكل الافتراضي والعمود المعدل.
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

التحقق من النوع الدلالي قبل تغيير القيمة يجعل الكود واضحًا بشأن نيته ويتجنّب الافتراض بأن فهرس مجموعة معين له نفس المعنى عبر أشكال مسبقة مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب على المجموعة مباشرة. إذا غيّرت عملية ما عدد أو ترتيب الأشكال، لا تستمر في الاعتماد على الفهارس التي تم الحصول عليها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) يُنشئ نسخة مستقلة ويضيفها إلى مجموعة الهدف. [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) يُنشئ نسخة أيضًا لكنه يضعها عند فهرس z-order محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تشمل العرض والارتفاع يمكنها تغيير حجمه أيضًا.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلً مُسمّى إلى الأمام، ويُدخل نسخة ثانية إلى الخلف. لا تُغيّر التغييرات على أي نسخة الأصل.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرّفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة بواسطة الأشكال المعقّدة تُدار بواسطة العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة له هوية شكل جديدة.

### **إزالة الأشكال**

[remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) يحذف كائن شكل محدد من مجموعته. عند إزالة مطابقة متعددة أثناء تكرار فهرسي، تنقّب من النهاية بحيث يظل كل فهرس متبقٍ صالحًا.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي، ليس عنصر مجموعة ثابت، ولا يقوم بتحويل النوع دون حاجة.

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

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تبقى المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. كما يجب مراعاة الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ قد يغيّر إزالة شكل مرئي أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Hidden](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) إلى `true` يبقى الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا فإن الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الأشكال المتراكبة تُرسم بترتيب المجموعة. [reorder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `size() - 1` هو الأمام.

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

يُنشأ المستطيل أولًا ويجلس في البداية خلف القطعة البيضاوية. نقله إلى الفهرس النهائي يضعه في الأمام. احرص على تثبيت ترتيب Z بعد إضافة أو استنساخ كل الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدخل عناصر مجموعة جديدة ويمكن أن تغير التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

لشرائح عادية، شرائح تخطيط، وشرائح رئيسية مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس نفس الكائن مثل الشكل المماثل في شريحة عادية. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير التنسيق المزوّد بواسطة تخطيط.

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

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدّد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[writeAsSvg](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) يكتب محتوى شكل مُصاغ إلى تدفق. النتيجة تحتوي على الشكل فقط، لا الخلفية الكاملة للشريحة أو الأشكال المجاورة.

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

احفظ العرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت تحتاج إلى التركيب كاملًا، صدّر الشريحة بدلاً من شكل فردي. المتصل يمتلك التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) يحتوي على عدة تحميلات تُحاذى إما كل الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapesalignmenttype/) يحدد الحافة، الخط الأوسط، أو وضع التوزيع. عيّن `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ عيّنها إلى `false` لمحاذاة الأشكال المحددة بالنسبة لبعضها البعض.

هذا المثال يُحاذى ثلاثة أشكال إلى الحافة العليا للشريحة. تُحوّل مراجع الأشكال المرجعة إلى فهارسها الحالية مباشرةً قبل المحاذاة.

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

المحاذاة تغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادةً تتطلب شكلين على الأقل، بينما توزيع أفقي أو عمودي يحتاج إلى عدد كافٍ من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **انعكاس شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapeframe/) تخزن الموقع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيمتي `getFlipH` و `getFlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/nullablebool/): `True` يُفعّل الانعكاس، `False` يُعطّله، و `NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير معكوس.

![الشكل قبل الانعكاس](shape_to_be_flipped.png)

المثال يحافظ على كل قيم الإطار الأخرى ويستبدل فقط إعدادات الانعكاس الثانية. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جديد يُستبدل الإطار بالكامل.

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

الشكل المحفوظ مُعكس أفقيًا وعموديًا مع الحفاظ على موقعه وحجمه ودورانه.

![الشكل بعد الانعكاس](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يجب استخدام فهرس المجموعة كمعرّف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يُفضَّل اعتماد معيار `Name` أو `AlternativeText` للقوالب التي يصنعها المطور، أو `OfficeInteropShapeId` لأعمال التفاعل على مستوى الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يضيف النسخة إلى نهاية المجموعة، وهي أمام ترتيب Z. استخدم `insertClone` لتحديد الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد تعديل شكل مسبق؟**

فقط بعد التحقق من الإعداد المسبق الدقيق وتخطيط المجموعة. يُفضَّل التكرار عبر `IGeometryShape.getAdjustments` والتحقق من `IAdjustValue.getType`؛ استخدم `IAdjustValue.getName` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.
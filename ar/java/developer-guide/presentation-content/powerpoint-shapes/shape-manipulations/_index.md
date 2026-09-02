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
- بحث عن شكل
- نسخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف شكل Interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- شكل كملف SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي، نسخها، إزالتها، إخفائها، إعادة ترتيبها، تصديرها، محاذاتها، وقلبها باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تمثل Aspose.Slides for Java الأشكال على الشريحة كـ [IShapeCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/). المجموعة هي المكان الذي تجد فيه وتعدل الأشكال ومصدر ترتيب طبقاتها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامي.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية تحديد شكل بشكل موثوق، ثم يوضح كيفية استنساخ، حذف، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق المستوى التخطيطي، تصدير SVG، المحاذاة، وإعدادات القلب. كل مثال مستقل، بحيث يمكنك استخدام العمليات التي تحتاجها فقط في سير عملك.

## **تحديد وإيجاد الأشكال**

تكون فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرّفات ثابتة. يمكن أن يغيّر إضافة أو حذف أو إعادة ترتيب شكل فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getName--) مفيد للقوالب التي يتحكم فيها المطورون ويسهل فحصه في لوحة التحديد في PowerPoint. يمكن تحرير الأسماء ولا يضمن أن تكون فريدة، لذلك ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getAlternativeText--) مفيد عندما يكون الوصف التعييني أو العلامة التي يضيفها المؤلف قد حددت الشكل مسبقًا. وهو مرئي للمستخدمين، وقد يُترجم أو يُعاد صياغته من أجل إمكانية الوصول، ولا يضمن أن يكون فريدًا. لا تعِد استعمال نص إمكانية الوصول ذي المعنى كمفتاح قاعدة بيانات.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا لبس فيه طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يكون شكلًا مختلفًا ويحصل على معرف خاص به.

الطريقة المرتبطة [getUniqueId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getUniqueId--) تُعيد معرفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا ينبغي اعتباره مفتاحًا خارجيًا دائمًا. إذا كانت هوية الشكل على المدى الطويل ضرورية، احتفظ بالربط في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث بالاسم باستخدام مقارنة مطابقة تمامًا ويُبلغ عن معرف التفاعل بنطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلاً من الاستمرار مع الكائن الخطأ.

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

عندما تكون العملية محددة لنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يحدّث النص والنص البديل فقط إذا كان الكائن المُسمى من نوع [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).

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

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الحذف، وإعادة الترتيب على المجموعة فورًا. إذا غيّرت عملية ما عدد الأشكال أو ترتيبها، لا تواصل الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) ينشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة المستهدفة. [insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) ينشئ نسخة أيضًا لكنه يضعها عند فهرس ترتيب z محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تشمل العرض والارتفاع يمكنها تغيير الحجم أيضًا.

المثال ينشئ شريحة هدف، يستنسخ مستطيل معنون إلى الأمام، ويُدخل نسخة ثانية إلى الخلف. التغييرات على أي من النسختين لا تغير الشكل الأصلي.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرّفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقّدة يديرها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة له هوية شكل جديدة.

### **حذف الأشكال**

[remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) يحذف كائن شكل محدد من مجموعته. عند حذف عدة تطابقات أثناء التكرار الفهري، تجول من النهاية بحيث يبقى كل فهرس متبقٍ صالحًا.

هذا المثال يحذف كل شكل يحمل اسمًا معينًا. يقرأ الشكل في الفهرس الحالي، وليس عنصر مجموعة ثابت، ولا يحوّل الشكل بلا داعٍ.

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

بعد الحذف، يتغير عدد الأشكال وفهارس الأشكال اللاحقة. تبقى الإشارات إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، والرسوم المتحركة، والميزات الأخرى التي قد تشير إلى الكائن المحذوف؛ حذف شكل مرئي يمكن أن يغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Hidden](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setHidden-boolean-) إلى `true` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في العرض التقديمي العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا فإن الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهار سره مرة أخرى، ويظل جزءًا من ملف العرض التقديمي.

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

يُنشأ المستطيل أولاً ويجلس في البداية خلف الشكل البيضاوي. نقله إلى الفهرس النهائي يجعله في المقدمة. احرص على ضبط ترتيب z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدخل عناصر مجموعة جديدة وقد تُغيّر الترتيب المقصود.

## **فحص الأشكال على شرائح التخطيط**

لشرائح العادي، وشرائح التخطيط، وشرائح النموذج مجموعات شكل منفصلة. الشكل في مجموعة التخطيط ليس نفس الكائن كما هو في شريحة عادية بنفس الموضع. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير التنسيق المزوّد من قبل التخطيط.

المثال التالي يقرأ كل من [FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getFillFormat--) و[LineFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getLineFormat--) لكل شكل تخطيط دون افتراض أن كل شكل هو `AutoShape`.

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

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تعديل شكل تخطيط، حدّد ما إذا كانت شريحة عادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[writeAsSvg](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) يكتب محتوى شكل مُصوّر إلى تدفق. النتيجة تحتوي على الشكل فقط، لا الخلفية الكاملة للشريحة أو الأشكال المجاورة.

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

 أبقِ العرض التقديمي مفتوحًا أثناء التصيير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التركيب الكامل، صدر الشريحة بدلاً من الشكل الفردي. المتصل يملك التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) لديها تحميلات تُحاذِ جميع الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapesalignmenttype/) يحدد الحافة أو الخط المركزي أو وضع التوزيع. اضبط `alignToSlide` على `true` لاستخدام حواف الشريحة؛ اضبطه على `false` لمحاذاة الأشكال المختارة بالنسبة لبعضها البعض.

هذا المثال يُحاذِ ثلاث أشكال إلى الحافة العلوية للشريحة. تُحوَّل مراجع الشكل المرجعية إلى فهارسها الحالية مباشرةً قبل المحاذاة.

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

المحاذاة تُغيّر المواقع، لا ترتيب z. المحاذاة النسبية عادةً تحتاج على الأقل إلى شكلين، بينما التوزيع الأفقي أو العمودي يحتاج إلى عدد كافٍ من الأشكال لتحديد المسافات. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **قلب شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapeframe/) تخزن الموقع، الحجم، إعدادات القليب الأفقية والعمودية، والدوران. قيمتي `getFlipH` و`getFlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/java/com.aspose.slides/nullablebool/): `True` يفعّل القليب، `False` يلغيه، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلب.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل إعدادات القليب فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جديد يستبدل الإطار بالكامل.

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

الشكل المحفوظ أصبح مرآة أفقية وعمودية مع الحفاظ على موقعه، حجمه، ودورانه.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**هل يجب علي استخدام فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يفضَّل استخدام اتفاقية `Name` أو `AlternativeText` مُصادقة للقوالب التي أنشأها المؤلفون، أو `OfficeInteropShapeId` لأعمال التفاعل بنطاق الشريحة.

**هل يؤدي إخفاء الشكل إلى إزالته من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة على نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهارّه مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يضيف النسخة إلى نهاية المجموعة، وهي مقدمة ترتيب Z. استخدم `insertClone` لاختيار الفهرس الابتدائي أو `reorder` بعد إضافة جميع الأشكال.
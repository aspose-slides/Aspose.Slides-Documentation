---
title: إدارة أشكال العروض التقديمية على Android
linktitle: التعامل مع الأشكال
type: docs
weight: 40
url: /ar/androidjava/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف شكل Interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تحديد، استنساخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وقلب أشكال العروض التقديمية باستخدام Aspose.Slides for Android via Java."
---
## **نظرة عامة**

يمثل Aspose.Slides for Android via Java الأشكال على الشريحة كمجموعة مرتبة [IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/). المجموعة هي المكان الذي تجد فيه الأشكال وتعدّلها ومصدر ترتيب تكديسها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامي.

هذا المقال يتبع هذا النموذج. يبدأ بشرح كيفية تحديد الشكل بثقة، ثم يوضح كيفية استنساخ، إزالة، إخفاء وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق مستوى التخطيط، تصدير SVG، المحاذاة، وإعدادات القلب. كل مثال مستقل، لذا يمكنك استخدام العمليات التي تحتاجها في سير العمل الخاص بك فقط.

## **تحديد وإيجاد الأشكال**

فهارس المجموعة مريحة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. إضافة أو إزالة أو إعادة ترتيب شكل يمكن أن يغيّر فهرسه. اختر معرفاً بحسب طريقة إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getName--) مفيد للقوالب التي يتحكم فيها المطور وسهل الفحص في لوحة التحديد في PowerPoint. يمكن تعديل الأسماء ولا يضمن أن تكون فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getAlternativeText--) مفيد عندما يكون الوصف المناسب لقابلية الوصول أو علامة من المؤلف تحدد الشكل بالفعل. هو ظاهر للمستخدمين، قد يُترجم أو يُعاد صياغته لقابلية الوصول، ولا يضمن كونه فريداً. لا تُعيد استخدام نص قابلية الوصول ذو معنى كمفتاح قاعدة بيانات بشكل صامت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) هو معرف للقراءة فقط فريد داخل شريحة واحدة ويتطابق مع معرف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى إشارة لا لبس فيها طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يكون شكلًا مختلفًا ويتلقى معرفه الخاص.

طريقة [getUniqueId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getUniqueId--) المرتبطة تُعيد معرفًا بنطاق العرض التقديمي، لكن هذا المعرف موجه للإضافات ويمكن إعادة تعيينه. لا ينبغي اعتباره مفتاحًا خارجيًا دائمًا. إذا كانت هوية طويلة الأجل ضرورية، احتفظ بالربط في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث بالاسم باستخدام مقارنة مطابقة تمامًا ويُبلغ عن معرف التفاعل على مستوى الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلاً من المتابعة بالكائن الخطأ.

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

عند كون العملية محددة لنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يُحدّث النص والنص البديل فقط إذا كان الكائن المسمى من نوع [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).

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

تعمل طرق الإضافة، الاستنساخ، الإزالة وإعادة الترتيب على المجموعة مباشرة. إذا غيّرت عملية ما عدد أو ترتيب الأشكال، لا تستمر بالاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) يُنشئ نسخة مستقلة ويضيفها إلى مجموعة الهدف. [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) يُنشئ نسخة أيضًا لكنه يضعها في فهرس z‑order محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تشمل العرض والارتفاع يمكنها تغيير حجمه أيضًا.

المثال ينشئ شريحة هدف، يستنسخ مستطيلًا مُعنونًا إلى الأمام، ويُدرج نسخة ثانية في الخلف. التغييرات على أي نسخة لا تُعدّل الشكل الأصلي.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقدة تُعالجها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة بمعرف شكل جديد.

### **إزالة الأشكال**

[remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) يحذف كائن شكل محدد من مجموعته. عند إزالة عدة تطابقات أثناء تكرار بالفهرسة، تجول من النهاية بحيث يظل كل فهرس متبقي صالحًا.

هذا المثال يزيل كل شكل يحمل اسماً معينًا. يقرأ الشكل عند الفهرس الحالي، وليس عنصر مجموعة ثابت، ولا يُحوّل الشكل دون ضرورة.

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

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. المراجع إلى الأشكال غير المتأثرة تظل أكثر موثوقية من الفهارس المخزنة. أيضًا ضع في اعتبارك الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل مرئي قد تغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) إلى `true` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في العرض التقديمي العادي. يبقى فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا الإخفاء ملائم للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهاره مرة أخرى، ويبقى جزءًا من ملف العرض التقديمي.

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

المستطيل يُنشأ أولاً ويقع في البداية خلف القطعة الناعمة. نقله إلى الفهرس النهائي يضعه في المقدمة. أكّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدرج عناصر مجموعة جديدة ويمكن أن تُغيّر التكديس المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، وشرائح التخطيط، وشرائح القالب لها مجموعات أشكال منفصلة. الشكل في مجموعة تخطيط ليس نفس الكائن الموجود على شريحة عادية في موقع مماثل. فحص أشكال التخطيط مطلوب عندما تحتاج إلى فهم أو تغيير التنسيق المقدم بواسطة التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getFillFormat--) و[LineFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getLineFormat--) للأشكال في التخطيط دون افتراض أن كل شكل هو `AutoShape`.

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

تحرير تخطيط قد يؤثر على شرائح متعددة تستخدمه. قبل تغيير شكل في التخطيط، حدّد ما إذا كانت شريحة عادية تورث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[writeAsSvg](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) يكتب محتوى شكل مُصوّر إلى تدفق. النتيجة تحتوي على الشكل فقط، لا الخلفية الكاملة للشريحة أو الأشكال المجاورة.

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

احفظ العرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التكوين الكامل، صدّر الشريحة بدلاً من شكل فردي. المتصل يملك التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) يوفر إصدارات تُحاذي إما جميع الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapesalignmenttype/) يحدد الحافة، الخط المركزي، أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المحددة بالنسبة إلى بعضها البعض.

هذا المثال يُحاذي ثلاثة أشكال إلى الحافة العليا للشريحة. مراجع الأشكال المُرجَعة تُحوَّل إلى فهارسها الحالية مباشرة قبل المحاذاة.

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

المحاذاة تغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادةً تتطلب شكلين على الأقل، بينما التوزيع الأفقي أو العمودي يحتاج إلى عدد كافي من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **قلب شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapeframe/) تخزن الموقع، الحجم، إعدادات القلب الأفقي والعمودي، والدوران. قيمتي `getFlipH` و`getFlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/nullablebool/): `True` يُفعّل القلب، `False` يُعطّله، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي الإدخالي أدناه يحتوي على شكل غير مقلوب.

![الشكل قبل القبل](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل فقط إعدادتي القلب. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جديد يُستبدل الإطار بالكامل.

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

الشكل المُحفظ يُعكس أفقياً وعمودياً مع الحفاظ على موقعه، حجمه، ودورانه.

![الشكل بعد القبل](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يجب أن أستخدم فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة القصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يفضَّل اعتماد `Name` أو `AlternativeText` الموثق لقوالب مُنشأة، أو `OfficeInteropShapeId` للعمليات المتعلقة بالتفاعل داخل الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يضيف النسخة إلى نهاية المجموعة، وهي أمامية ترتيب Z. استخدم `insertClone` لتحديد الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.
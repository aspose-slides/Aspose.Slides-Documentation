---
title: تنسيق أشكال PowerPoint في Java
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير تخطيط
- خط الشكل المخطط
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيج
- تعبئة لون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- دوران الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Java باستخدام Aspose.Slides—قم بتعيين أنماط التعبئة والخط والتأثير لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **مقدمة**

تنسيق الأشكال في PowerPoint عن طريق تعديل الخطوط الخارجية، التعبئة، والتأثيرات. يسمح Aspose.Slides for Java بالتحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، الدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

يوفر Aspose.Slides for Java واجهات وطرق تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) للتحكم في حد الشكل. يُنشئ هذا المثال مستطيلًا غير مملوء بخط أزرق منقط. يختار [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) خطًا مركبًا سميك-رفيع، بينما يحدد [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) عرضه إلى 7 نقاط و[ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) نمط الخط المتقطع.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

### **تعيين أنماط متقطعة مخصصة للخط**

استخدم [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) عندما لا توفر الأنماط المسبقة طول الفواصل والفواصل التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. يؤدي تعيين نمط إلى تغيير نمط الخط المتقطع تلقائيًا إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

تتناوب قيم المصفوفة بين طول الفاصل وطول الفراغ، بدءًا بفاصل. كل قيمة هي مضاعف لعرض الخط: `{ 4, 2 }` عند عرض 3 نقاط ينتج فاصل بطول 12 نقطة يليه فراغ بطول 6 نقاط. استخدم أزواج من القيم المحدودة غير السلبية لتعريف قطاعات الفاصل والفراغ الكاملة. يستخدم المثال قيمًا موجبة للحفاظ على رؤية كل فاصل وفراغ.

هذا المثال ينشئ خمسة خطوط زرقاء بنفس الطول ورؤوس مسطحة. الثلاثة الأولى تقارن الأنماط عند عرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مضاعفًا كل من طول الفاصل والفراغ. الخامس يتحول من نمط مخصص إلى خط صلب.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // إرجاع الخط الأخير إلى نمط صلب.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للعودة إلى نمط متقطع محدد مسبقًا، مرر [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) إلى [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). يتحكم النمط المحدد في مظهر الخط.

النتيجة في PowerPoint، من الأعلى إلى الأسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و**Solid, 3 pt**.

![ثلاثة أنماط متقطعة مخصصة، خط أوسع يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين رؤوس الخط**

استخدم [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) لتحديد نهايات الخط المفتوح. توفر فئة [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) ثلاث أنماط رأس صريحة:

- `Flat`: يتوقف الخط عند نقطة النهاية.
- `Round`: رأس نصف دائري يمتد إلى ما وراء نقطة النهاية بنصف عرض الخط.
- `Square`: رأس مربع يمتد إلى ما وراء نقطة النهاية بنصف عرض الخط.

تتضمن الفئة أيضًا `NotDefined`، وهو يعني عدم تعيين أي نمط رأس بشكل صريح.

الرؤوس تختلف عن رؤوس السهام، التي تضيف رموزًا لنهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين مقاطع الخط. يقوم هذا المثال بتعطيل رؤوس السهام عبر [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) و[ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) بحيث يتم مقارنة أشكال الرؤوس فقط.

ينشئ المثال التالي ثلاثة خطوط أفقية متطابقة أخرى، عرضها 20 نقطة. من الأعلى إلى الأسفل، تستخدم رؤوس مسطحة، مستديرة، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ الرؤوس المستديرة والمربعة تمتد 10 نقاط خارج كل نقطة نهاية.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint، من الأعلى إلى الأسفل: **Flat**, **Round**, و**Square**.

![رؤوس مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يمنح تأثير الرسم التخطيطي خط الشكل مظهرًا مرسومًا باليد. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) للوصول إلى إعدادات الرسم التخطيطي، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) لتحديد قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

يظهر الكود التالي بلغة Java كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

القيمة التي تعيدها [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان تنسيق الخط يمكن وراثته من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--)، و[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--)، وقراءة [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). القيمة الفعّالة تعكس التنسيق الفعلي بعد حل الوراثة. يتطلب هذا المثال عرضًا تقديميًا موجودًا به على الأقل شكل واحد في الشريحة الأولى ويطبع القيمتين:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **تنسيق أنماط الوصل**

فيما يلي الخيارات الثلاثة لأنواع الوصل:

* Round
* Miter
* Bevel

يتحكم نمط الوصل في كيفية اجتماع جزئيي الخط عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

ينشئ هذا المثال ثلاثة مستطيلات سوداء بخطوط زرقاء عرضها 15 نقطة. يستخدم [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) لتعيين قيم الميتر، البيفل، والمستديرة من [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/)، على التوالي، لمقارنة كيفية رسم الزوايا.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تحديد حدود الميتر في الزوايا الحادة**

استخدم [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) مع [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) المعيّن إلى [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) لتحديد الحد الأقصى لامتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزاويتين الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول ميتر يصل إلى ثمانية أضعاف عرض الخط؛ ليست وحدة قياس بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة مبلطة في تلك الزاوية. يتيح الحد الأكبر نقاطًا أكثر حدة. يؤثر الإعداد على وصلات الميتر فقط، ولا ينتج عنه أي تأثير مرئي عندما تبقى الزاوية ضمن الحدين.

ينشئ هذا المثال مثلثين غير مملولين متطابقين بخطوط عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا قدره `2`، والمثلث الأيمن حدًا قدره `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، مما يعطي زاوية علوية بنسبة تقريبية `4.12` بين طول الميتر وعرض الخط. بناءً عليه، يملط PowerPoint القمة اليسرى ويحافظ على القمة اليمنى.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint: **Miter limit 2** على اليسار و**miter limit 8** على اليمين.

![قمة مبلطة بحد ميتر 2 وقمة حادة بحد ميتر 8 في PowerPoint](miter-limits.png)

## **تعبئة تدرجية**

تعبئة تدرجية تمزج الألوان عبر الشكل. يملأ هذا المثال بيضاويًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). يضيف أسلوب [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) نقاط التوقف اللونية عند 0 و 1، بداية ونهاية التدرج. يضمن مسح نقاط التوقف الموجودة أن يتم استخدام هذين اللونين فقط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![البيضوي مع تعبئة تدرجية](gradient-fill.png)

إذا كان التدرج يبدو مختلفًا في صورة مُصدَّرة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط عرض دون تغيير التدرج المخزن في العرض التقديمي.

### **تعيين زاوية التدرج الخطي**

استخدم [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه عقرب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. تُطبع الزوايا خارج النطاق `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

هذا المثال ينشئ ستة مستطيلات بنقاط توقف لونية حمراء، خضراء، وزرقاء متطابقة في المواقع `0`، `0.5`، و`1`. تم تعطيل التحجيم بحيث يمكن مقارنة الزوايا بشكل مستقل عن أبعاد المستطيلات. الزوايا من اليسار إلى اليمين هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint:

![تدرجات خطية عند 0، 45، و90 درجة في الصف العلوي، وعند 135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) تقبل قيمة من نوع [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). اضبطها صراحةً على `False` للحفاظ على زاوية التدرج الهندسية مع تغير أبعاد الشكل، أو على `True` لتحجيم التدرج مع عرض وارتفاع الشكل. مع تمكين التحجيم، قد تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونقاط توقف لونية مماثلة لمقارنة الزوايا. العمود الأيسر يستخدم `False`؛ العمود الأيمن يستخدم `True`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بأبعاد عريضة متساوية؛ يوضح تغيير عرض وارتفاع المستطيل الثاني كيف يستجيب التعبئة عند تغيير الحجم دون تغيير إعدادات التدرج.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint، مع تعطيل التحجيم على اليسار وتمكينه على اليمين:

![مستطيلات عريضة وطويلة مع تدرج بزاوية 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تبقى أشرطة اللون المائلة بنفس الاتجاه في كلا المستطيلين. مع تمكين التحجيم، تمتد الأشرطة مع أبعاد الشكل. يساعد هذا في استنساخ تدرج القالب عند تعديل الشكل إلى حجم مختلف. على شكل مربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والتحجيم على التدرجات الخطية فقط. لا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) يختار نمط تدرج من فئة [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); لا يُعَدّ بديلاً للزاوية العددية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزَّع فيها الألوان دون تغيير الزاوية المعينة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). حافظ على الاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

يطبق المثال التالي الإعدادات نفسها بترتيب عكسي. المستطيلان لهما المظهر نفسه: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعبئة بنمط**

تطبيق تعبئة بنمط يستخدم تصميمًا من لونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) لاختيار نمط شبكة. يزود [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) الخلفية بالرمادي الفاتح، و[IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) اللون الأصفر للنمط.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المستطيل بتعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

تعبئة الصورة تستخدم صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) لتحميلها إلى مجموعة صور العرض التقديمي. ضبط [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) على وضعية التبليط يكرر الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضحة أدناه:

![صورة اللوتس](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل بتعبئة صورة](picture-fill.png)

### **تبديل الصورة كقِماش**

إذا أردت تعيين صورة مبلطة كقِماش وتخصيص سلوك التبليط، يمكنك استخدام الأساليب التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يحدد وضعية تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة المربعات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كانت المربعة مقلوبة أفقيًا أو عموديًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يحدد إزاحة المربعة أفقياً (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يحدد إزاحة المربعة عموديًا (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يحدد مقياس المربعة أفقيًا كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يحدد مقياس المربعة عموديًا كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويضبط [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) لتكرارها بحجم 50% من حجمها الأصلي. إزاحات بـ −32 نقطة تحرك المربعات أفقيًا وعموديًا؛ يحدد المحاذاة السفلية اليمنى والقلب في الاتجاهين كيفية ترتيب القوام المتكررة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![خيارات المربعات](tile-options.png)

## **تعبئة لون صلب**

تعبئة صلبة تعطي الشكل لونًا موحدًا. يستخدم هذا المثال [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) لتعيين وضعية التعبئة الصلبة ويعين اللون الأصفر عبر [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--)، ثم يحفظ المستطيل في عرض تقديمي.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل بتعبئة لون صلب](solid-color-fill.png)

### **نسخ الألوان مع الحفاظ على مراجع السمة**

استخدم [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) لنسخ تعريف اللون، بما في ذلك نوع اللون، مرجع السمة، والتحويلات. هذا مفيد عند نقل لون تعبئة بين أشكال يجب أن تظل متوافقة مع سمة العرض التقديمي. تنسخ الطريقة اللون فقط: لا تنسخ نوع التعبئة أو الحد أو تنسيقات الشكل الأخرى. اضبط نوع التعبئة للوجهة صراحةً باستخدام [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-).

ينشئ هذا المثال ثلاثة مستطيلات، من اليسار إلى اليمين: المصدر، نسخة واعية للسمة، ونسخة RGB ثابتة. يستخدم المصدر [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) للإشارة إلى اللون المميز الأول ويضيف لونًا مائلًا عبر [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-). تستخدم نسخة RGB اللون الفعّال للمصدر بحيث تبدو الثلاثة متماثلة في البداية. يعيّن استدعاء [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) قيمة RGB ثابتة ويمسح أي تحولات لونية موجودة.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // مراجع السمة تتبع اللون المميز الجديد؛ القيمة الثابتة RGB لا تفعل ذلك.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قبل تغيير السمة، تتطابق جميع التعبئات الثلاث:

![المصدر، نسخة الوجهة من copyFrom، ونسخة RGB ثابتة مع تعبئات زرقاء متماثلة](color-copy-before.png)

بعد تغيير السمة، يتبع المصدر والنسخة الواعية للسمة اللون المميز الجديد وتحتفظان بظلها. تظل نسخة RGB ثابتة باللون الأزرق:

![المصدر ونسخة الوجهة من copyFrom مع تعبئات برتقالية، بينما تظل نسخة RGB ثابتة باللون الأزرق](color-copy-after.png)

التعريف المنسوخ مستقل عن المصدر. لا يؤدي تغيير مرجع السمة للمصدر أو تعيين لون آخر أو إضافة أو إزالة تحوله إلى تغيير الوجهة. لا يزال تغيير السمة يؤثر على الشكلين لأن كلًا منهما يشير بشكل مستقل إلى نفس لون السمة.

حفظ وإعادة فتح ملف PPTX يحفظ نوع اللون الذي رجعته [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--)، ومرجع السمة، ومجموعة التحويلات التي رجعتها [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--); لا يتم تسطيح التعريف إلى RGB.

عند النسخ بين سياقات سمة مختلفة، مثل العروض التقديمية ذات لوحات ألوان مميزة مختلفة، يتم حل المرجع المنسوخ مقابل سمة الوجهة. لذلك قد ينتج عن نفس المرجع والتحويلات لون مرئي مختلف. راجع [Presentation Theme](/slides/ar/java/presentation-theme/) للمزيد حول تكوين ألوان السمة.

## **استخدام خلفية الشريحة كملء الشكل**

استخدم [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط نوع التعبئة باستخدام [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) إلى [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. بهذه التركيبة، يستخدم الشكل خلفية الشريحة بدلاً من تعبئته النمطية. تمكين العلم وحده لا يزيل تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بمنطقة خلفية الشريحة المقابلة، بينما لا تعبئة تترك تلك الكائنات مرئية. يبقى التدرج محاذيًا مع الشريحة بدلاً من البدء داخل كل شكل.

ينشئ المثال التالي خلفية رئيسية يرثها الشريحة ويوضع شريط بكرماني خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا تعبئة، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // وارث التدرج من القالب الرئيسي.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // أضف هذا الكائن أولاً حتى يظهر خلف المستطيلات.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // تعطيل تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة، من اليسار إلى اليمين: **background fill**, **no fill**, و**explicit fill**. الشريط البُقَماطي مخفي خلف المستطيلين الأيسر والأيمن لكنه يظل مرئيًا عبر المستطيل الأوسط.

![تعبئة خلفية، لا تعبئة، وتعبئة صريحة بالبرتقالي فوق شريط بُقَماطي](background-fill.png)

يطبق نفس السلوك على خلفية معرفة مباشرة على الشريحة أو موروثة من تخطيط. يستخدم الشكل خلفية الشريحة المحلولة؛ يترك المثال كلًا من خلفية الشريحة والتخطيط غير معرفة بحيث يزودها الرئيس.

## **تعيين الشفافية**

لتعبئة صلبة، يتحكم مكوّن ألفا للون في الشفافية: 0 يعني شفاف بالكامل و255 يعني غير شفاف بالكامل. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50٪ بحيث يظل المستطيل الموجود تحته مرئيًا. يتم تعيين اللون عبر [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **دوران الأشكال**

استخدم [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) لتدوير الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال المستطيل 5 درجات مع اتجاه عقرب الساعة ويحفظ العرض التقديمي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات حواف ثلاثية الأبعاد**

استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) لإضفاء عمق وحواف مائلة على الشكل. ينشئ هذا المثال بيضاويًا أخضرًا بحد برتقالي، يستخدم [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) لتعيين العمق إلى 4 نقاط، ويطبق حافة علوية دائرية بعرض وارتفاع 6 نقاط عبر [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). تجعل كاميرا أرثوغرافية أمامية وإضاءة ثلاثية النقاط الحافة مرئية.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

يتم التحكم في عرض الشكل ثلاثي الأبعاد عبر إعدادات الكاميرا. يستخدم هذا المثال [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) بزاوية خطوط العرض والطول والثورة 40 و 35 و 20 درجة على التوالي. يختار كاميرا إيزومتريّة عبر [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) وإضاءة متوازنة عبر [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-)، ثم يحفظ المستطيل المنسق.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد طريقة [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي بوضع اللونين الأبيض والأسود. لا تمكّن وضع العرض بالأبيض والأسود نفسها، ولا تغير تعبئة الشكل أو الخط أو غيره من التنسيق في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يسمح لتطبيق العرض باختيار التحويل، `Gray` و`LightGray` يستخدمان تلوينًا رماديًا، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و`White` يجبران لونًا واحدًا، `Color` يحافظ على التلوين العادي، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

هذا المثال ينشئ مستطيلًا برتقاليًا ويستخدم [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) لتعيين الوضع إلى رمادي. يحتفظ الشكل المحفوظ بملئه البرتقالي للعرض بالألوان العادية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع اللون العادي، يحتفظ المستطيل بملئه البرتقالي. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `Gray`. يتيح لك هذا الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يحترم إعدادات العرض بالأبيض والأسود للعرض التقديمي.

## **إعادة تعيين التنسيق**

استخدم [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) لاستعادة موضع، حجم، وتنسيق عناصر النائب في الشريحة من عناصر النائب المقابلة في التخطيط. يتطلب هذا المثال عرضًا تقديميًا موجودًا به مكانات عناصر نائب مرتبطة بالتخطيط ويعيد تعيين كل شريحة قبل الحفظ. لا تُعاد تعيين الأشكال التي لا توجد لها عناصر نائب في التخطيط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**

الألوان، أنماط الخطوط، وإعدادات التأثيرات عادةً ما تزيد قليلًا من البيانات مقارنةً بالصور المدمجة والوسائط. قد تزيد تعبئات الصور حجم الملف لأن صورها مخزنة في العرض التقديمي.

**كيف يمكن اكتشاف Shapes على شريحة تتشارك نفس التنسيق؟**

قارن خصائص التنسيق الرئيسية لكل شكل—التعبئة، الخط، وإعدادات التأثير. إذا كان جميع القيم المطابقية مطابقة، اعتبرها أنماطًا متطابقة وجرّب تجميعها منطقيًا لتسهيل إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة إلى ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية تحمل الأنماط المطلوبة في شريحة قالب أو ملف .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط المطلوبة، وطبق تنسيقها حسب الحاجة.
---
title: تنسيق أشكال PowerPoint في Java
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم
- خط شكل الرسم
- تنسيق نمط الوصلة
- تعبئة تدرجية
- تعبئة نمطية
- تعبئة صورة
- تعبئة نسيج
- تعبئة لون صلبة
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالرمادي
- دوران الشكل
- تأثير بيفل ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Java باستخدام Aspose.Slides—حدد تعبئة الخطوط وأنماط التأثير لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **مقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها، وتعبئتها، وتأثيراتها. يتيح Aspose.Slides for Java التحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides for Java واجهات وأساليب تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) للتحكم في حدود الشكل. يوضح هذا المثال إنشاء مستطيل غير مملوء بحد أزرق متقطع. يحدد [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) خطاً مركباً سميكاً‑رفيعاً، بينما يحدد [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) عرضه بـ 7 نقاط و[ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) نمط التقطيع.

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

### **تعيين أنماط التقطيع المخصصة للخط**

استخدم [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) عندما لا توفر الأنماط المحددة سلفاً أطوال الفواصل والفواصل التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. يؤدي تعيين نمط إلى تغيير نمط التقطيع تلقائياً إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

تتناوب قيم المصفوفة بين أطوال الفواصل والفراغات، بدءاً بفاصل. كل قيمة هي مضاعف لعرض الخط: `{ 4, 2 }` بعرض 3 نقاط ينتج فاصل بطول 12 نقطة يتبعه فراغ بطول 6 نقاط. استخدم أزواج من القيم المحدودة وغير السالبة لتعريف أجزاء الفاصل‑الفراغ الكاملة. يستخدم المثال قيماً موجبة لإبقاء كل فاصل وفراغ واضحاً.

هذا المثال ينشئ خمسة خطوط زرقاء بنفس الطول ورؤوس مسطحة. الثلاثة الأولى تقارن الأنماط عند عرض 3 نقاط. يكرر الرابع النمط الأول بعرض مضاعف، مضاعفاً كلًا من فواصل الخط وفراغاته. يبدل الخامس من نمط مخصص إلى خط صلب.

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

للعودة إلى نمط متقطع محدد مسبقاً، مرّر [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) إلى [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). يتحكم النمط المحدد في مظهر الخط.

النتيجة في PowerPoint، من الأعلى إلى الأسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و**Solid, 3 pt**.

![ثلاثة أنماط تقطيع مخصصة، خط أوسع باستخدام النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين رؤوس الخطوط**

استخدم [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) لتحديد نهايات الخط المفتوح. توفر فئة [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) ثلاث أنماط صريحة للرؤوس:

- `Flat`: يتوقف الخط عند نقطة النهاية.
- `Round`: رأس نصف دائري يمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.
- `Square`: رأس مربع يمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.

تشمل الفئة أيضاً `NotDefined`، مما يعني عدم تعيين أي نمط رأس صريح.

الرؤوس تختلف عن رؤوس السهام، التي تضيف رموزاً إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين مقاطع الخط. يقوم هذا المثال بتعطيل رؤوس السهام عبر [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) و[ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) بحيث تُقارن فقط أشكال الرؤوس.

ينشئ المثال التالي ثلاثة خطوط أفقية متطابقة أخرى، عرضها 20 نقطة. من الأعلى إلى الأسفل، تستخدم رؤوساً مسطحة، مستديرة، ومربعة. لها إحداثيات أفقية متطابقة؛ تمتد الرؤوس المستديرة والمربعة 10 نقاط إلى ما بعد كل نقطة نهاية.

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

## **تطبيق تأثيرات الرسم على خطوط الشكل**

يُعطي تأثير الرسم الخط شكلًا كأنه مرسم يدويًا. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) للوصول إلى إعدادات الرسم، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) لاختيار قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

يعرض كود Java التالي كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

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

القيمة التي تُرجعها [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان تنسيق الخط يمكن وراثته من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--)، ثم الوصول إلى [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) وقراءة [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). تعكس القيمة الفعلية التنسيق الذي يُطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال وجود عرض تقديمي قائم يحتوي على شكل واحد على الأقل في الشريحة الأولى، ويطبع القيمتين:

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

## **تنسيق أنماط الوصلات**

إليك خيارات الأنواع الثلاثة للوصلات:

* Round
* Miter
* Bevel

تتحكم نمط الوصلة في كيفية اجتماع مقطعي الحد عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصلة في العرض التقديمي](join-style-powerpoint.png)

ينشئ هذا المثال ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يستخدم [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) لتعيين قيم المِتَر، والبيفل، والدائري من فئة [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) على التوالي، لمقارنة كيفية رسم الزوايا.

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

### **تقييد وصلات المِتَر عند الزوايا الحادة**

استخدم [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) مع ضبط [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) إلى [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) لتحديد أقصى مسافة يمكن للزاوية الحادة أن تمتد فيها.

الحد هو نسبة المسافة بين الزاوية الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، القيمة `8` تسمح بطول مِتَر يصل إلى ثمان مرات عرض الخط؛ وهي ليست قياساً بالنقاط. إذا exceded الزاوية الحد، يستخدم PowerPoint وصلة بيفل عند تلك الزاوية. يسمح الحد الأكبر بنقاط أكثر حدة. يؤثر الإعداد على وصلات المِتَر فقط، ولا يُظهر أي تأثير مرئي عندما تظل الزاوية ضمن الحدين.

ينشئ هذا المثال مثلثين غير مملوئين متطابقين بحدود عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا قدره `2`، واليمين حدًا قدره `8`. كل مثلث عرضُه 80 نقطة وارتفاعه 160 نقطة، مما يعطي نسبة طول المِتَر إلى عرض الخط تقريبًا `4.12`. وبالتالي، يُحوِّل PowerPoint القمة اليسرى إلى بيفل ويبقي القمة اليمنى حادة.

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

![قمة بيفلية بحد مِتَر 2 وقمة حادة بحد مِتَر 8 في PowerPoint](miter-limits.png)

## **تعبئة تدرجية**

التعبئة التدرجية تمزج الألوان عبر الشكل. يملأ هذا المثال إهليلاً بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). يضع أسلوب [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) نقاط التوقف اللونية عند 0 و1، بدايةً ونهايةً للتدرج. يضمن مسح النقاط السابقة أن تُستخدم هاتان اللونان فقط.

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

![الإهليلج مع تعبئة تدرجية](gradient-fill.png)

إذا بدا التدرج مختلفًا في صورة مُصدَّرَة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض.

### **تعيين زاوية التدرج الخطية**

استخدم [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد مع عقرب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. تُطبع الزوايا خارج النطاق `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

ينشئ هذا المثال ستة مستطيلات بنقاط توقف لون أحمر، أخضر، وأزرق متطابقة في المواقع `0`، `0.5`، و`1`. تم تعطيل المقياس لتتمكن من مقارنة الزوايا بشكل مستقل عن نسب الأشكال. الزوايا، من اليسار إلى اليمين، هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

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

![تدرجات خطية عند 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

يقبل [IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) قيمة من نوع [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). اضبطها صراحةً على `False` للحفاظ على زاوية التدرج الهندسية عند تغير أبعاد الشكل، أو على `True` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، قد تختلف الزاوية المرئية عن الزاوية المحددة في شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونفس نقاط الألوان كما في مقارنة الزوايا. يستخدم العمود الأيسر `False`؛ والعمود الأيمن `True`. كل عمود يحتوي على مستطيل عريض أعلى مستطيل طويل. يبدأ كلاهما بأبعاد عريضة متساوية؛ يوضح تغيير أبعاد المستطيل الثاني كيفية استجابة التعبئة لإعادة التحجيم دون تغيير إعدادات التدرج.

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

مع تعطيل التحجيم، تبقى أشرطة اللون المائلة ذات الاتجاه نفسه في كلا المستطيلين. مع تمكين التحجيم، تمتد الأشرطة مع نسب الشكل. يساعد ذلك في إعادة إنتاج تدرج القالب عند تعديل حجم الشكل. على الشكل المربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والتحجيم على التدرجات الخطية فقط. لا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

يختار [IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) نمط التدرج من فئة [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); وهو ليس بديلاً للزاوية الرقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي تُوزَّع فيها الألوان دون تغيير الزاوية المحددة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). أبقِ الاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

يطبق المثال التالي نفس الإعدادات بترتيب عكسي. يظل الشكلان متطابقين في المظهر: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

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

## **تعبئة نمطية**

تطبق التعبئة النمطية تصميمًا ذا لونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) لاختيار نمط شبكة. يوفر [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) الخلفية بالرمادي الفاتح، و[IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) اللون الأصفر للنمط.

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

![المستطيل مع تعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

تستخدم تعبئة الصورة صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) لتحميلها إلى مجموعة صور العرض. ضبط [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) على وضع التجانب يكرر الصورة داخل المستطيل. الصورة المصدرية المستخدمة هنا موضحة أدناه:

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

![الشكل مع تعبئة صورة](picture-fill.png)

### **استخدام صورة متجانبة كنقش**

إذا أردت تعيين صورة متجانبة كنقش وتخصيص سلوك التجانب، يمكنك استخدام الأساليب التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة البلاط داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كان البلاط مقلوبًا أفقياً أو عمودياً أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يحدد الإزاحة الأفقية للبلاط (نقطة) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يحدد الإزاحة العمودية للبلاط (نقطة) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يحدد مقياس البلاط الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يحدد مقياس البلاط العمودي كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويضبط [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) لتكرارها بنسبة 50 % من حجمها الأصلي. تحريك البلوط بــ −32 نقطة أفقيًا وعموديًا؛ محاذاة أسفل‑يمين وتدوير في الاتجاهين يحددان كيفية ترتيب النسيج المتكرر.

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

![خيارات التجانب](tile-options.png)

## **تعبئة لون صلبة**

تُعطي التعبئة الصلبة الشكل لونًا موحدًا. يستخدم هذا المثال [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) لتعيين وضع التعبئة الصلبة ويُعيّن اللون الأصفر عبر [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--)، ثم يحفظ المستطيل في عرض تقديمي.

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

![الشكل مع تعبئة لون صلبة](solid-color-fill.png)

## **استخدام خلفية الشريحة كملء شكل**

استخدام [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، مثلًا في قالب عرض تقديمي. استخدم [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) إلى [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. بهذه المجموعة، يستخدم الشكل خلفية الشريحة بدلاً من تعبئته الخاصة. تمكين العلامة وحدها لا يزيل تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بمنطقة خلفية الشريحة المقابلة، بينما لا تعبئة تترك تلك الكائنات مرئية. يبقى التدرج محاذيًا مع الشريحة بدلاً من أن يبدأ داخل كل شكل.

ينشئ المثال التالي خلفية رئيسية تُورَّث إلى الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا تعبئة له، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // وراثة التدرج من القالب الرئيسي.
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

    // إضافة هذا الكائن أولاً بحيث يظهر خلف المستطيلات.
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

النتيجة، من اليسار إلى اليمين: **تعبئة خلفية**، **لا تعبئة**، و**تعبئة صريحة**. يُخفى الشريط الأرجواني بالمستطيلين الأيسر والأيمن لكنه يظل مرئيًا من خلال المستطيل الأوسط.

![تعبئة خلفية، لا تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

يطبق السلوك نفسه على خلفية مُحددة مباشرةً على الشريحة أو مُورَّثة من تخطيط. يستخدم الشكل خلفية الشريحة المُحلَّلة؛ يترك المثال كلًا من خلفيات الشريحة والتخطيط غير معرفة بحيث يوفّر الماستر الخلفية.

## **تعيين الشفافية**

في تعبئة صلبة، يتحكم المكوّن ألفا للون في الشفافية: 0 يعني شفاف تمامًا و255 يعني غير شفاف تمامًا. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50 % لتبقى المستطيلات التي تحته مرئية. يُعيّن اللون عبر [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

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

استخدم [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) لتدوير الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال المستطيل 5 درجات مع عقرب الساعة ويحفظ العرض التقديمي.

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

## **إضافة تأثيرات بيفل ثلاثية الأبعاد**

استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) لإعطاء الشكل عمقًا وحوافًا مكسوة. ينشئ هذا المثال إهليلاً أخضرًا بحد برتقالي، ويستخدم [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) لضبط العمق إلى 4 نقاط، ويطبق بيفلًا علويًا دائريًا بعرض وارتفاع 6 نقاط عبر [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). تجعل الكاميرا الأورثوغرافية المواجهة للأمام وإضاءة ثلاثية النقاط البيفل مرئيًا.

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

![تأثير البيفل ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

يُتحكم في عرض الشكل ثلاثي الأبعاد عبر إعدادات الكاميرا. يستخدم هذا المثال [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) بزوايا خط العرض، الطول، والثورة 40، 35، و20 درجة على التوالي. يختار كاميرا إيزومتريّة عبر [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) وإضاءة متوازنة عبر [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-)، ثم يحفظ المستطيل المُنسق.

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

![تأثير دوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد طريقة [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي بوضع أبيض‑أسود. لا تُفعِّل هذه الطريقة العرض بالأبيض والأسود بحدّ نفسها، ولا تُغيّر تعبئة الشكل أو خطه أو أي تنسيق آخر في وضع اللون الطبيعي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يسمح لتطبيق العرض باختيار التحويل، و`Gray` و`LightGray` يستخدمان اللون الرمادي، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يفرضان لونًا واحدًا، و`Color` يحافظ على الألوان الطبيعية، و`Hidden` يحذف الشكل في وضع الأبيض‑أسود. يعني `NotDefined` عدم تعيين وضع على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويستخدم [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) لتعيين الوضع إلى رمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض بالألوان الطبيعية ويطلب اللون الرمادي من التطبيقات التي تحترم إعدادات العرض بالأبيض‑أسود:

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

في وضع اللون العادي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض أبيض‑أسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو أي سير عمل يحترم إعدادات العرض بالأبيض‑أسود للعرض.

## **إعادة ضبط التنسيق**

استخدم [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) لاستعادة موضع وحجم وتنسيق عناصر النائب في الشريحة من عناصر النائب المقابلة في التخطيط. يتطلب هذا المثال عرض تقديمي قائم يحتوي على عناصر نائب مرتبطة بالتخطيط ويعيد ضبط كل شريحة قبل الحفظ. لا تُعيد الأشكال التي لا تقابلها عناصر نائب في التخطيط الضبط.

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

عموماً، تضيف الألوان وأنماط الخطوط وإعدادات التأثيرات كمية قليلة من البيانات مقارنةً بالصور والوسائط المضمَّنة. يمكن لتعبئات الصور أن تزيد من حجم الملف لأن صورها تُخزن في العرض.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في نفس التنسيق لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقياً، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال ذات الأنماط المطلوبة، وطبق تنسيقها حيثما يلزم.
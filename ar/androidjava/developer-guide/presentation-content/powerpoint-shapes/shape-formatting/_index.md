---
title: تنسيق أشكال PowerPoint على Android
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/androidjava/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل التخطيطي
- تنسيق نمط الاتصال
- تعبئة التدرج اللوني
- تعبئة النمط
- تعبئة الصورة
- تعبئة القوام
- تعبئة اللون الصلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالتحويل إلى تدرج رمادي
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint على Android باستخدام Aspose.Slides—حدد أنماط التعبئة والحد وتأثيرات للملفات PPT وPPTX بدقة وتحكم كامل."
---
## **المقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها، وتعبئتها، وتأثيراتها. يتيح Aspose.Slides for Android عبر Java التحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

يقدم Aspose.Slides for Android عبر Java واجهات وطرق تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) للتحكم في حدود الشكل. يُنشئ هذا المثال مستطيلاً غير مملوء مع حد أزرق متقطع. يحدد [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) خطًا مركبًا سميكًا رفيعًا، بينما يحدد [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) عرضه إلى 7 نقاط و[ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) نمط التقطيع.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![الخطوط المُنسقة في العرض التقديمي](formatted-lines.png)

### **تحديد أنماط التقطيع المخصصة للخط**

استخدم [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) عندما لا توفر الأنماط المُحددة مسبقًا لطول الفواصل والمسافات التي تحتاجها، على سبيل المثال للحدود ذات العلامات التجارية أو المخططات التقنية. يؤدي تعيين نمط إلى تغيير نمط التقطيع للخط تلقائيًا إلى [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

تتناوب عناصر المصفوفة بين طول الفاصل وطول الفراغ، بدءًا بفاصل. كل قيمة هي مضاعف لعرض الخط: `{ 4, 2 }` عند عرض 3 نقاط ينتج فاصل بطول 12 نقطة يليه فراغ بطول 6 نقاط. استخدم أزواجًا من القيم المحدودة وغير السالبة لتحديد قطاعات الفواصل الكاملة. يستخدم المثال قيمًا موجبة للحفاظ على وضوح كل فاصل وفراغ.

هذا المثال ينشئ خمسة خطوط زرقاء ذات نفس الطول والنهايات المسطحة. الثلاثة الأولى تقارن الأنماط بعرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مما يضاعف طول الفواصل والفراغات. الخامس يتحول من نمط مخصص إلى خط صلب.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

للعودة إلى نمط متقطع مُحدد مسبقًا بدلاً من ذلك، مرر [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) إلى [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). يتحكم النمط المحدد في مظهر الخط.

النتيجة في PowerPoint من أعلى إلى أسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![ثلاثة أنماط تقطيع مخصصة، خط أوسع يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تحديد أشكال نهايات الخط**

استخدم [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) لتعيين نهايات خط مفتوح. توفر فئة [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) ثلاثة أنماط صريحة للنهايات:

- `Flat`: يتوقف الخط عند نقطة النهاية.
- `Round`: يمتد حد نصف دائري إلى ما بعد نقطة النهاية بمقدار نصف عرض الخط.
- `Square`: يمتد حد مربع إلى ما بعد نقطة النهاية بمقدار نصف عرض الخط.

تتضمن الفئة أيضًا `NotDefined`، مما يعني أنه لا يتم تعيين نمط نهاية صريح.

تختلف النهايات عن رؤوس السهام التي تضيف رموزًا إلى نهايات الخط، والاتصالات التي تتحكم في الزوايا بين مقاطع الخط. يقوم هذا المثال بإلغاء رؤوس السهام عبر [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) و[ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) بحيث تتم مقارنة أشكال النهايات فقط.

ينشئ المثال التالي ثلاثة خطوط أفقية متطابقة تقريبًا، عرضها 20 نقطة. من أعلى إلى أسفل، تستخدم نهايات مسطحة، مستديرة، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ تمتد النهايات المستديرة والمربعة 10 نقاط إلى ما بعد كل نقطة نهاية.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

النتيجة في PowerPoint من أعلى إلى أسفل: **Flat**, **Round**, و **Square**.

![نهايات مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضفي تأثير الرسم التخطيطي مظهرًا يدويًا على خط الشكل. استخدم [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) للوصول إلى إعدادات الخط، و[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) للوصول إلى إعدادات الرسم التخطيطي، و[ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) لتحديد قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

يعرض الكود التالي بلغة Java كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

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

القيمة التي تعيدها [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان تنسيق الخط يمكن وراثته من نمط أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--)، و[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--)، ثم اقرأ [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). القيمة الفعّالة تعكس التنسيق الذي يُطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الشريحة الأولى على الأقل ويطبع القيمتين:

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

## **تنسيق أنماط الاتصالات**

فيما يلي خيارات ثلاثة لأنواع الاتصالات:

* Round
* Miter
* Bevel

يتحكم نمط الاتصال في كيفية التقائهما لجزئي الحد عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الاتصال في العرض التقديمي](join-style-powerpoint.png)

هذا المثال ينشئ ثلاثة مستطيلات سوداء ذات حدود زرقاء عرضها 15 نقطة. يستخدم [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) لتطبيق قيم [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) للميتير، والبيفل، والراند على التوالي، للمقارنة بين كيفية رسم الزوايا.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **تحديد حدود الانضمام الحاد عند الزوايا الحادة**

استخدم [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) مع ضبط [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) إلى [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) لتحديد مدى امتداد الزاوية الحادة.

الحد هو نسبة المسافة بين الزاوية الداخلية والخارجية للاتصال إلى عرض الخط. على سبيل المثال، قيمة `8` تسمح بطول ميتير يصل إلى ثمانية أضعاف عرض الخط؛ وهي ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة بيفل عند تلك الزاوية. كلما زاد الحد، أصبحت النقاط أكثر حدة. يؤثر الإعداد على وصلات الميتير فقط، ولا يغيّر أي مظهر مرئي عندما تبقى الزاوية ضمن الحدين.

هذا المثال ينشئ مثلثين غير مملوءين متطابقين بحدود عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا `2`، واليمين حدًا `8`. كل مثلث عرضه 80 نقطة وطوله 160 نقطة، مما يمنحه نسبة طول ميتير إلى عرض الخط تقارب `4.12`. وبالتالي، يقوم PowerPoint بعمل بيفل للقمة اليسرى ويحافظ على القمة اليمنى.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة في PowerPoint: **Miter limit 2** على اليسار و**miter limit 8** على اليمين.

![قمة مسطحة بحد ميتير 2 وقمة حادة بحد ميتير 8 في PowerPoint](miter-limits.png)

## **تعبئة التدرج اللوني**

تُدمج تعبئة التدرج الألوان عبر الشكل. يملأ هذا المثال إهليلجًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى البنفسجي باستخدام [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). تُضيف الطريقة [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) ألوان التوقف عند 0 و1، البداية والنهاية للتدرج. يضمن مسح التوقفات الحالية استخدام هذين اللونين فقط.

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

![الإهليلج مع تعبئة التدرج](gradient-fill.png)

إذا ظهر التدرج بلون مختلف في صورة مُصدرة مقارنةً بما هو في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض التقديمي.

### **تحديد زاوية التدرج الخطي**

استخدم [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) للتحكم في اتجاه تعبئة [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من أعلى إلى أسفل، `180` من اليمين إلى اليسار، و`270` من أسفل إلى أعلى. تدعم الزوايا الكسرية. تُطبع الزوايا خارج نطاق `[0, 360)` إلى ثورة واحدة؛ على سبيل المثال، `-45` تصبح `315` و`360` تصبح `0`.

هذا المثال ينشئ ستة مستطيلات بألوان توقف حمراء، خضراء، وزرقاء متطابقة في المواقع `0`، `0.5`، و`1`. تم تعطيل التحجيم بحيث يمكن مقارنة الزاوية بشكل مستقل عن أبعاد المستطيلات. الزوايا، من اليسار إلى اليمين، هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![تدرجات خطية بزاوية 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) تقبل قيمة [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). اضبطها صراحةً إلى `False` للحفاظ على زاوية التدرج الهندسية مع تغيير أبعاد الشكل، أو إلى `True` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، يمكن أن تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونفس ألوان التوقف كما في مقارنة الزوايا. العمود الأيسر يستخدم `False`؛ العمود الأيمن يستخدم `True`. يحتوي كل عمود على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بنفس الأبعاد العريضة؛ يوضح تعديل عرض وارتفاع المستطيل الثاني كيفية استجابة التعبئة لإعادة التحجيم دون تغيير إعدادات التدرج.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

مع تعطيل التحجيم، تبقى أشرطة اللون المائلة بنفس الاتجاه في كلا المستطيلين. مع تمكين التحجيم، تمتد الأشرطة مع أبعاد الشكل. يساعد ذلك على استنساخ تدرج قالب عند تعديل حجم الشكل. على الشكل المربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والتحجيم على التدرجات الخطية فقط. لا تتحكم في تعبئات [GradientShape.Radial أو GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) يحدد نمط التدرج من فئة [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/); وهو ليس بديلاً عن الزاوية الرقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي توزّع فيها الألوان دون تغيير الزاوية المعينة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). حافظ على الاتجاه دون تغيير عند مقارنة الزوايا أو التحجيم.

يطبق المثال التالي نفس الإعدادات بترتيب عكسي. المستطيلان لهما المظهر نفسه: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **تعبئة النمط**

تُطبق تعبئة النمط تصميمًا بلونين، مثل النقاط أو الخطوط أو المتراجعات. يستخدم هذا المثال [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) لاختيار نمط trellis. يوفر [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) خلفية رمادية فاتحة، ويوفر [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) لون النمط الأصفر.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المستطيل مع تعبئة النمط](pattern-fill.png)

## **تعبئة الصورة**

تستخدم تعبئة الصورة صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) لتحميلها إلى مجموعة صور العرض التقديمي. ضبط [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) على وضع tiled يكرر الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضوعة أدناه:

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

![الشكل مع تعبئة الصورة](picture-fill.png)

### **تكرار الصورة كنقش**

إذا أردت ضبط صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) وفئة [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): يضبط وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): يحدد محاذاة البلاطات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): يتحكم فيما إذا كانت البلاطة مقلوبة أفقيًا أو رأسيًا أو كلاهما.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): يضبط إزاحة البلاطة الأفقية (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): يضبط إزاحة البلاطة العمودية (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): يعرف مقياس البلاطة الأفقية كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): يعرف مقياس البلاطة العمودية كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويضبط [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) لتكرارها بنسبة 50% من حجمها الأصلي. إزاحات `−32` نقطة تحرك البلاطات أفقيًا وعموديًا؛ محاذاة الأسفل-اليمين والقلب في الاتجاهين يحددان كيفية ترتيب النقش المكرر.

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

![خيارات البلاط](tile-options.png)

## **تعبئة اللون الصلب**

تعطي تعبئة اللون الصلب الشكل لونًا موحدًا واحدًا. يستخدم هذا المثال [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) لاختيار وضع التعبئة الصلبة ويعيّن اللون الأصفر عبر [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--)، ثم يحفظ المستطيل في عرض تقديمي.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **نسخ الألوان مع الحفاظ على مراجع النمط**

استخدم [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) لنسخ تعريف اللون، بما في ذلك نوع اللون، مرجع النمط، والتحويلات. هذا مفيد عند نقل لون تعبئة بين أشكال يجب أن تظل تتبع نمط العرض التقديمي. تنسخ الطريقة اللون فقط: لا تنسخ نوع التعبئة أو الحدود أو أي تنسيق آخر للشكل. اضبط نوع التعبئة للوجهة صراحةً باستخدام [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-).

هذا المثال ينشئ ثلاثة مستطيلات، من اليسار إلى اليمين: المصدر، نسخة واعية للنمط، ونسخة RGB ثابتة. يستخدم المصدر [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) للإشارة إلى اللون المميز الأول ويضيف ظلًا عبر [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-). تستخدم نسخة RGB اللون الفعّال للمصدر بحيث تبدو الثلاثة متماثلة في البداية. استدعاء [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) يعيّن قيمة RGB ثابتة ويمسح أي تحويلات لون موجودة.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

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

    // تشير مراجع النمط إلى لون التمييز الجديد؛ القيمة الثابتة RGB لا تفعل ذلك.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

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

قبل تغيير النمط، تتطابق جميع تعبئات الثلاثة:

![المصدر، نسخة copyFrom الوجهة، والوجهة RGB الثابتة مع تعبئات زرقاء متطابقة](color-copy-before.png)

بعد تغيير النمط، يتبع المصدر والنسخة المستندة إلى النمط اللون المميز الجديد وتحتفظان بالظل. تظل نسخة RGB الثابتة زرقاء:

![المصدر ونسخة copyFrom الوجهة بتعبئة برتقالية، بينما تظل النسخة RGB الثابتة زرقاء](color-copy-after.png)

التعريف المنسوخ مستقل عن المصدر. تعديل مرجع النمط للمصدر لاحقًا، أو تعيين لون آخر، أو إضافة أو إزالة تحويلاته لا يغيّر الوجهة. لا يزال تغيير النمط يؤثر على الشكلين لأن كلًا منهما يشير بشكل مستقل إلى نفس لون النمط.

حفظ وإعادة فتح ملف PPTX يحافظ على نوع اللون المنسوخ الذي تعيده [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--)، ومرجع النمط، ومجموعة التحويلات التي تعيدها [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--); لا يتم تحويل التعريف إلى RGB.

عند النسخ بين سياقات نمط مختلفة، مثل عروض تقديمية ذات لوحات ألوان مميزة مختلفة، يُحلّ المرجع المنسوخ وفقًا لنمط الوجهة. يمكن لنفس المرجع والتحويلات إذًا أن ينتج لونًا مرئيًا مختلفًا. راجع [Presentation Theme](/slides/ar/androidjava/presentation-theme/) للمزيد عن ضبط ألوان النمط.

## **استخدام خلفية الشريحة كملء الشكل**

استخدم [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، مثلاً في قالب عرض تقديمي. اضبط نوع التعبئة أولاً باستخدام [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) إلى [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لإزالة أي تعبئة صريحة. بهذه الطريقة، يستخدم الشكل خلفية الشريحة بدلاً من تعبئة نمطية. تمكين العلامة وحدها لا يزيل تعبئة صريحة موجودة.

هذا يختلف عن [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بالمنطقة المقابلة من خلفية الشريحة، بينما لا تعبئة تترك تلك الكائنات مرئية. يبقى التدرج محاذيًا للشفرة بدلاً من أن يبدأ داخل كل شكل.

ينشئ المثال التالي خلفية رئيسية يورثها الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا يحتوي على تعبئة، والمستطيل الأيمن يتحول من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // ورث التدرج من الشريحة الرئيسية.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // أضف هذا العنصر أولاً بحيث يظهر خلف المستطيلات.
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

    // تعطل تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة، من اليسار إلى اليمين: **background fill**, **no fill**, و **explicit fill**. يختفي الشريط الأرجواني خلف المستطيلين الأيسر والأيمن لكنه يظل مرئيًا من خلال المستطيل الأوسط.

![ملء الخلفية، لا ملء، وملء برتقالي صريح فوق شريط أرجواني](background-fill.png)

ينطبق نفس السلوك على خلفية مُعرفّة مباشرةً على الشريحة أو موروثة من تخطيط. يستخدم الشكل الخلفية التي تم حلها للشرائح؛ يترك المثال كلًا من خلفية الشريحة والتخطيط غير معرفين بحيث يزودهما الماستر.

## **تعيين الشفافية**

للتعبئة الصلبة، يتحكم مكوّن ألفا للون في الشفافية: 0 يعني شفاف تمامًا و255 يعني غير شفاف تمامًا. يستخدم هذا المثال قيمة ألفا `128` لمستطيل أصفر، ما يجعله شفافًا تقريبًا بنسبة 50% بحيث يبقى المستطيل الموجود تحته مرئيًا. يتم تعيين اللون عبر [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

استخدم [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) لتدوير شكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال مستطيلًا 5 درجات باتجاه عقارب الساعة ويحفظ العرض التقديمي.

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

## **إضافة تأثيرات الحافة ثلاثية الأبعاد**

استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لإضفاء عمق وحواف مشطوفة على الشكل. ينشئ هذا المثال إهليلجًا أخضرًا بحد برتقالي، ويستخدم [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) لتعيين العمق إلى 4 نقاط، ويطبق شطبة علوية دائرية بعرض وارتفاع 6 نقاط عبر [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). تجعل كاميرا أمامية أرثوغرافية وإضاءة ثلاثية النقاط الحافة مرئية.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
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

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

يتم التحكم في عرض الشكل ثلاثي الأبعاد عبر إعدادات الكاميرا. يستخدم هذا المثال [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) بزاوية خط العرض، الطول، والثورة 40، 35، و20 درجة على التوالي. يختار كاميرا إيزومترية عبر [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) وإضاءة متوازنة عبر [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-)، ثم يحفظ المستطيل المنسق.

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

طريقة [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) تحدد كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي في وضع أبيض وأسود. لا تفعّل العرض بالأبيض والأسود بذاتها، ولا تغيّر تعبئة الشكل أو حدوده أو أي تنسيق آخر في وضع اللون الطبيعي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يتيح لتطبيق العرض اختيار التحويل، و`Gray` و`LightGray` يستخدمان تلوينًا رماديًا، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يجبران على لون واحد، و`Color` يحافظ على التلوين الطبيعي، و`Hidden` يحذف الشكل في وضع أبيض وأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويستخدم [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) لاختيار تلوين رمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض بالألوان الطبيعية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في وضع اللون الطبيعي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض أبيض وأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل آخر يلتزم بإعدادات العرض بالأبيض والأسود للعرض التقديمي.

## **إعادة ضبط التنسيق**

استخدم [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) لاستعادة موقع، حجم، وتنسيق العناصر النائبة للشرائح من العناصر النائبة المقابلة في التخطيط. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على عناصر نائبة مرتبطة بالتخطيط ويعيد ضبط كل شريحة قبل الحفظ. لا يتم إعادة ضبط الأشكال التي لا تتوافر لها عناصر نائبة في التخطيط.

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

الألوان، وأنماط الخطوط، وإعدادات التأثير عادةً ما تضيف بيانات قليلة مقارنة بالصور والوسائط المضمنة. يمكن أن تزيد تعبئات الصور حجم الملف لأن صورها تُخزن في العرض التقديمي.

**كيف يمكنني اكتشاف الأشكال على شريحة تشترك في تنسيق متماثل لتجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع هذه الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة إلى ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية بالأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حيثما كان ذلك مطلوبًا.
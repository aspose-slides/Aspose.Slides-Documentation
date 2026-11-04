---
title: تنسيق أشكال PowerPoint في PHP
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/php-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل التخطيطي
- تنسيق نمط الوصل
- تعبئة تدرج لوني
- تعبئة بنمط
- تعبئة بصورة
- تعبئة قوام
- تعبئة لون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير تقويس ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية تنسيق أشكال PowerPoint في PHP باستخدام Aspose.Slides—قم بتعيين أنماط التعبئة والخط والمؤثرات لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **مقدمة**

قم بتنسيق الأشكال في PowerPoint عن طريق تعديل حدودها، وتعبئتها، وتأثيراتها. يتيح Aspose.Slides for PHP عبر Java التحكم في هذه الإعدادات برمجيًا، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الأشكال في PowerPoint](format-shape-powerpoint.png)

يوفر Aspose.Slides for PHP عبر Java الفئات والطرق التي تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) للتحكم في حدود الشكل. تنشئ هذه المثال مستطيلًا غير مملوء بحد أزرق متقطع. يختار [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) خطًا مركبًا سميكًا-رفيعًا، بينما يحدد [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) عرضه إلى 7 نقاط و[LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) النمط المتقطع.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

### **تعيين أنماط متقطعة مخصصة للخط**

استخدم [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) عندما لا توفر الأنماط المسبقة للخطوط أطوال الفواصل والفواصل التي تحتاجها، على سبيل المثال لحدود ذات علامة تجارية أو مخططات تقنية. يؤدي تعيين نمط إلى تغيير نمط المتقطع تلقائيًا إلى [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

تتناوب إدخالات المصفوفة بين أطوال الفواصل والفواصل، بدءًا بفاصل. كل قيمة هي مضاعف لعرض الخط: ينتج `[4, 2]` بعرض 3 نقاط فاصلًا بطول 12 نقطة يليه فجوة بطول 6 نقاط. استخدم أزواجًا من القيم النهائية غير السالبة لتعريف مقاطع فاصل-فجوة مكتملة. يستخدم المثال قيمًا موجبة لإبقاء كل فاصل وفجوة مرئية.

ينشئ هذا المثال خمسة خطوط زرقاء بنفس الطول وقمصان مسطحة. المقارنة بين الأنماط في الثلاثة الأولى تتم بعرض 3 نقاط. يكرر الرابع النمط الأول بضعف العرض، مما يضاعف كل من أطوال الفواصل والفجوات. يتحول الخامس من نمط مخصص إلى خط صلب.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // إرجاع الخط الأخير إلى نمط صلب.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

للعودة إلى نمط متقطع مسبقًا بدلاً من ذلك، مرّر [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) إلى [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). يتحكم النمط المحدد في مظهر الخط.

النتيجة في PowerPoint من الأعلى إلى الأسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و**Solid, 3 pt**.

![ثلاثة أنماط متقطعة مخصصة، خط أوسع باستخدام النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين أنماط قمة الخط**

استخدم [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) لتحديد نهايات الخط المفتوح. توفر الفئة [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) ثلاثة أنماط قمة صريحة:

- `Flat`: يتوقف الرسم عند نقطة النهاية.
- `Round`: قمة نصف دائرية تمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.
- `Square`: قمة مربعة تمتد إلى ما بعد نقطة النهاية بنصف عرض الخط.

تتضمن الفئة أيضًا `NotDefined`، والذي يعني عدم تعيين نمط قمة صريح.

القمم تختلف عن رؤوس السهام، التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين مقاطع الخط. يزيل هذا المثال رؤوس السهام عبر [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و[LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) بحيث تتم مقارنة أشكال القمة فقط.

ينشئ المثال التالي ثلاثة خطوط أفقية متطابقة أخرى، عرضها 20 نقطة. من الأعلى إلى الأسفل، تستخدم قمم مسطحة، مستديرة، ومربعة. تتساوى إحداثيات نقاط النهاية أفقياً؛ القمم المستديرة والمربعة تمتد 10 نقاط إلى ما بعد كل نقطة نهاية.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة في PowerPoint من الأعلى إلى الأسفل: **Flat**، **Round**، و**Square**.

![قُمم مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضفي تأثير الرسم التخطيطي مظهرًا يدويًا على خط الشكل. استخدم [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، و[LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) لتحديد قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

يعرض الكود PHP التالي كيفية تطبيق تأثير [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

القيمة التي تُرجعها [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective)، وادخل إلى طريقة `getSketchFormat` للكائن المرتجع، واقرأ قيمتها `getSketchType`. تمثل القيمة الفعلية التنسيق المطبق فعليًا بعد حل الوراثة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الأقل في شريحته الأولى ويطبع القيمتين:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **تنسيق أنماط الوصل**

فيما يلي خيارات ثلاثة لأنواع الوصل:

* Round
* Miter
* Bevel

يُتحكم نمط الوصل في كيفية اجتماع مقطعي الحد عند زاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

ينشئ هذا المثال ثلاثة مستطيلات سوداء بحدود زرقاء عرضها 15 نقطة. يضبط [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) إلى قيم الميتير، البيفيل، والرند للـ [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) على التوالي، لمقارنة كيفية رسم الزوايا.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تحديد حدود الميتير عند الزوايا الحادة**

استخدم [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) مع [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) مضبوطًا على [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) لتحديد أقصى مدى يمكن أن تمتد فيه زاوية حادة.

الحد هو نسبة المسافة بين الزوايا الداخلية والخارجية للوصلة إلى عرض الخط. على سبيل المثال، تسمح القيمة `8` بطول ميتر يصل إلى ثمان مرات عرض الخط؛ ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلة مبيفة عند تلك الزاوية. يتيح الحد الأكبر نقاطًا أكثر حدة. يؤثر الإعداد على وصلات الميتير فقط، ولا يحدث أي تأثير مرئي عند بقاء الزاوية ضمن الحدود.

ينشئ هذا المثال مثلثين غير مملوئين متطابقين بحدود عرضها 20 نقطة. يستخدم المثلث الأيسر حدًا `2`، واليمين حدًا `8`. كل مثلث عرضه 80 نقطة وارتفاعه 160 نقطة، ما يعطي نسبة طول الميتير إلى عرض الخط تقريبًا `4.12`. وبالتالي، يقوم PowerPoint ببيفِة القمة اليسرى ويحافظ على حدة القمة اليمنى.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة في PowerPoint: **Miter limit 2** على اليسار و**miter limit 8** على اليمين.

![قمة مبيفة بحد ميتير 2 وقمة حادة بحد ميتير 8 في PowerPoint](miter-limits.png)

## **تعبئة تدرج لوني**

يُمزج تعبئة التدرج الألوان عبر الشكل. يملأ هذا المثال قطعًا إهليلجية بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). تُضيف الطريقة [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) نقاط التوقف اللونية عند 0 و1، بداية ونهاية التدرج. يضمن مسح نقاط التوقف الحالية استخدام هذين اللونين فقط.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![القطع الإهليلجي مع تعبئة تدرج لوني](gradient-fill.png)

إذا بدا التدرج مختلفًا في الصورة المصدرة مقارنةً بما هو عليه في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزنة في العرض التقديمي.

### **تعيين زاوية التدرج الخطي**

استخدم [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) للتحكم في اتجاه تعبئة [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد في اتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. تُطبع الزوايا النهائية خارج النطاق `[0, 360)` إلى دورة واحدة؛ على سبيل المثال، يصبح `-45` إلى `315` و`360` إلى `0`.

ينشئ هذا المثال ستة مستطيلات بنقاط توقف حمراء، خضراء، وزرقاء متطابقة عند المواضع `0`، `0.5`، و`1`. تم تعطيل المقياس حتى يمكن مقارنة الزاوية بشكل مستقل عن نسب أبعاد المستطيلات. الزوايا من اليسار إلى اليمين هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة في PowerPoint:

![تدرجات خطية عند 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **مقاس التدرج الخطي مع الشكل**

تقبل [GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) قيمة من نوع [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). اضبطها صراحةً إلى `False` للحفاظ على زاوية التدرج الهندسية عند تغير أبعاد الشكل، أو إلى `True` لمقاس التدرج مع عرض وارتفاع الشكل. مع تمكين المقياس، قد تختلف الزاوية الظاهرة عن الزاوية المعينة على شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونقاط توقف اللون نفسها كما في مقارنة الزوايا. يستخدم العمود الأيسر `False`؛ والعمود الأيمن `True`. يحتوي كل عمود على مستطيل عريض فوق مستطيل مرتفع. يبدأ كلاهما بأبعاد عريضة متماثلة؛ يُظهر تعديل عرض وارتفاع المستطيل الثاني كيفية استجابة التعبئة لإعادة الحجم دون تغيير إعدادات التدرج.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة في PowerPoint مع تعطيل المقياس على اليسار وتمكينه على اليمين:

![مستطيلات عريضة ومرتفعة بتدرج 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل المقياس، تبقى أشرطة اللون المائلة ذات الاتجاه نفسه في كلتا المستطيلين. مع تمكين المقياس، تمتد الأشرطة مع نسب الشكل. يساعد ذلك على إعادة إنتاج تدرج القالب عند تعديل الشكل إلى حجم مختلف. في الشكل المربع، لا يغيّر تمكين المقياس مظهر هذا التدرج بزاوية `45` درجة.

تنطبق إعدادات الزاوية والمقياس على التدرجات الخطية. لا تتحكم في تعبئات [GradientShape::Radial أو GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

تُحدد [GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) نمط التدرج من فئة [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); وهو ليس بديلاً عن الزاوية الرقمية. بالنسبة لتدرج خطي، يمكن أن تغير أنماط الزوايا المنطقة التي تُوزع فيها الألوان دون تغيير الزاوية المحددة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). حافظ على الاتجاه ثابتًا عند مقارنة الزوايا أو المقياس.

يطبق المثال التالي الإعدادات نفسها بترتيب عكسي. المستطيلان لهما المظهر نفسه: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعبئة بنمط**

تُطبق تعبئة النمط تصميمًا ذا لونين، مثل النقاط أو الخطوط أو المربعات. يستخدم هذا المثال [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) لاختيار نمط "trellis". يزود [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) الخلفية باللون الرمادي الفاتح، و[PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) لون النمط الأصفر.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة بصورة**

تستخدم تعبئة الصورة صورة داخل الشكل. يتطلب هذا المثال صورة محلية ويستخدم [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) لتحميلها إلى مجموعة صور العرض التقديمي. ضبط [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) على وضع التكرار يكرر الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضحة أدناه:

![صورة اللوتس](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **تكرار الصورة كقشرة**

إذا رغبت في تعيين صورة مكررة كقشرة وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضع تعبئة الصورة — إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة القوالب داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كانت القوالب مقلوبة أفقياً أو رأسياً أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد الإزاحة الأفقية للقالب (بنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد الإزاحة الرأسية للقالب (بنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): يعرّف مقياس القالب الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): يعرّف مقياس القالب الرأسي كنسبة مئوية.

يتطلب هذا المثال صورة محلية ويضبط [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) لتكرارها بنسبة 50% من حجمه الأصلي. تُحوِّل الإزاحات بـ −32 نقطة القوالب أفقياً ورأسياً؛ تحدد محاذاة الزاوية السفلية اليمنى والقلب في كلا الاتجاهين كيفية ترتيب القشرة المكررة.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خيارات القالب](tile-options.png)

## **تعبئة لون صلب**

توفر التعبئة الصلبة للشكل لونًا موحدًا واحدًا. يضبط هذا المثال [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) إلى وضع التعبئة الصلبة ويُعيّن اللون الأصفر عبر [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor)، ثم يحفظ المستطيل في عرض تقديمي.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل مع تعبئة لون صلب](solid-color-fill.png)

## **استخدام خلفية الشريحة كملء للشكل**

استخدم [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) إلى [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. مع هذا الجمع، يستخدم الشكل خلفية الشريحة بدلاً من تعبئة النمط الخاصة به. تمكين العلم وحده لا يزيل تعبئة صريحة موجودة.

يختلف هذا عن [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بمنطقة خلفية الشريحة المقابلة، بينما ترك عدم التعبئة تلك الكائنات مرئية. يظل التدرج محاذيًا مع الشريحة بدلاً من أن يبدأ داخل كل شكل.

إنشاء المثال التالي خلفية رئيسية يرثها الشريحة ويضع شريطًا أرجوانيًا خلف ثلاثة مستطيلات. يستخدم المستطيل الأيسر الخلفية، والمستطيل الأوسط لا تعبئة، والمستطيل الأيمن ينتقل من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // وراثة التدرج من القالب الرئيسي.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // أضف هذا الكائن أولاً حتى يظهر خلف المستطيلات.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // عطّل تعبئة الخلفية قبل تطبيق تعبئة صريحة.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة من اليسار إلى اليمين: **تعبئة خلفية**، **بدون تعبئة**، و**تعبئة صريحة**. يُخفي الشريط الأرجواني المستطيلين الأيسر والأيمن لكنه يبقى مرئيًا من خلال المستطيل الأوسط.

![تعبئة خلفية، بدون تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

ينطبق السلوك نفسه على خلفية معينة مباشرةً على الشريحة أو موروثة من تخطيط. يستخدم الشكل خلفية الشريحة المحلولة؛ يترك المثال كلًا من خلفية الشريحة والتخطيط غير معرفةً حتى يزودها الرئيس.

## **تعيين الشفافية**

في تعبئة صلبة، يتحكم مكوّن ألفا للون في التعتيم: 0 يعني شفافية كاملة و255 يعني تعتيم كامل. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، مما يجعله شفافًا تقريبًا بنسبة 50% بحيث يظل المستطيل الموجود تحته مرئيًا. يُعيّن اللون عبر [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

استخدم [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) لتدوير الشكل في مستوى الشريحة. تُقاس الزاوية بالدرجات؛ يدور هذا المثال المستطيل 5 درجات باتجاه عقارب الساعة ويحفظ العرض التقديمي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات تقويس ثلاثي الأبعاد**

استخدم [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) لإعطاء الشكل عمقًا وحوافًا مقوّسة. ينشئ هذا المثال قطعًا إهليلجية خضراء بحد برتقالي، ويضبط [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) إلى 4 نقاط، ويطبق تقويسًا علويًا دائريًا بعرض وارتفاع 6 نقاط عبر [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). تجعل كاميرا أورثوغرافية أمامية وإضاءة ثلاثية نقاط التقويس مرئيًا.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تأثير التقويس ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثي الأبعاد**

تُتحكم إعدادات كاميرا العرض الثلاثي الأبعاد في طريقة عرض الشكل. يستخدم هذا المثال [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) بزاوية خطوط العرض، الطول، والثورة 40، 35، و20 درجة على التوالي. يختار كاميرا إسومترية عبر [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) وإضاءة متوازنة عبر [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType)، ثم يحفظ المستطيل المنسق.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدّد طريقة [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) كيف يُعرَض شكل فردي عندما يُعرض العرض التقديمي أو يُعالج بوضع الأبيض والأسود. لا تمكّن العرض بالأبيض والأسود بحد ذاته، ولا تغير تعبئة الشكل أو حدوده أو تنسيقه الآخر في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، يسمح `Automatic` لتطبيق العرض باختيار التحويل، ويستخدم `Gray` و`LightGray` الألوان الرمادية، و`BlackWhite` فقط اللونين الأسود والأبيض، و`Black` و`White` لونًا واحدًا، و`Color` يحافظ على الألوان العادية، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. تعني `NotDefined` عدم تعيين وضع على مستوى الشكل.

ينشئ هذا المثال مستطيلًا برتقاليًا ويضبط [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) إلى الرمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض بالألوان العادية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في وضع اللون العادي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض أبيض وأسود، يستخدم تلوينًا رماديًا لأن وضعه محدد إلى `Gray`. يتيح لك ذلك حفظ شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو غيرها من سير العمل التي تحترم إعدادات العرض بالأبيض والأسود للعرض التقديمي.

## **إعادة ضبط التنسيق**

استخدم [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) لاستعادة موضع، حجم، وتنسيق العناصر النائبة في الشريحة من العناصر النائبة المقابلة في التخطيط. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على عناصر نائبة مرتبطة بالتخطيط ويعيد ضبط كل شريحة قبل الحفظ. لا يتم إعادة ضبط الأشكال التي لا يوجد لها عناصر نائبة مقابلة في التخطيط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

الألوان، أنماط الخطوط، وإعدادات التأثيرات عادةً ما تضيف بيانات قليلة مقارنةً بالصور والوسائط المدمجة. يمكن أن تزيد تعبئات الصور من حجم الملف لأن صورها تُخزّن في العرض.

**كيف يمكنني اكتشاف الأشكال في شريحة تشترك في تنسيق متطابق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقياً، ما يُبسّط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة إلى ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة نمط أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وطبق تنسيقها حيثما يلزم.
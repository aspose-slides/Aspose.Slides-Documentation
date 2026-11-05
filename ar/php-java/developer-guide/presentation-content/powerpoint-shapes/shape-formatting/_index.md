---
title: تنسيق أشكال PowerPoint في PHP
linktitle: تنسيق الأشكال
type: docs
weight: 20
url: /ar/php-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل بالرسم التخطيطي
- تنسيق نمط الوصل
- تعبئة بالتدرج
- تعبئة بنمط
- تعبئة بالصورة
- تعبئة بالقوام
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بدرجات الرمادي
- تدوير الشكل
- تأثير الحافة ثلاثية الأبعاد
- تأثير الدوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في PHP باستخدام Aspose.Slides—حدد أنماط التعبئة، الخط، والتأثير لملفات PPT و PPTX بدقة وتحكم كامل."
---
## **المقدمة**

تنسيق الأشكال في PowerPoint عن طريق تعديل حدودها وتعبئتها وتأثيراتها. Aspose.Slides for PHP عبر Java يتيح لك التحكم في هذه الإعدادات برمجياً، بما في ذلك الشفافية، والدوران، وتنسيق ثلاثي الأبعاد.

![خيارات تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP عبر Java يوفر الفئات والطرق التي تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

استخدم [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) للتحكم في حدود الشكل. هذا المثال ينشئ مستطيلًا غير مملوء بحد أزرق متقطع. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) يختار خطًا مركبًا سميك-رفيع، بينما [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) يحدد عرضه إلى 7 نقاط و[LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) يختار نمط الشرط.

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

### **تعيين أنماط الشرط المخصصة للخط**

استخدم [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) عندما لا توفر الأنماط المسبقة للخطوط الطول والفجوات التي تحتاجها، على سبيل المثال للحدود ذات العلامة التجارية أو المخططات التقنية. تعيين نمط يغيّر تلقائيًا نمط الشرط إلى [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

تتبادل قيم المصفوفة بين طول الشرط والفجوة، بدءًا بشرط. كل قيمة هي مضاعف لعرض الخط: `[4, 2]` عند عرض 3 نقاط ينتج شرطًا بطول 12 نقطة ثم فجوة بطول 6 نقاط. استخدم أزواجًا من القيم المحدودة وغير السالبة لتحديد أقسام الشرط والفجوة الكاملة. المثال يستخدم قيمًا موجبة للحفاظ على ظهور كل شرط وفجوة.

هذا المثال ينشئ خمسة خطوط زرقاء بنفس الطول والحدود المسطحة. الثلاثة الأولى تقارن الأنماط عند عرض 3 نقاط. الرابع يكرر النمط الأول بعرض مضاعف، مما يضاعف أطوال الشرط والفجوة. الخامس يتحول من نمط مخصص إلى خط صلب.

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

للعودة إلى نمط متقطع مسبقًا بدلاً من ذلك، مرر [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) إلى [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). النمط المحدد يتحكم في مظهر الخط.

النتيجة في PowerPoint، من أعلى إلى أسفل: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![ثلاثة أنماط شرط مخصصة، خط أعرض يستخدم النمط الأول، وخط صلب في PowerPoint](custom-dash-patterns.png)

### **تعيين نهايات الخط**

استخدم [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) لتعيين نهايات الخط المفتوح. توفر فئة [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) ثلاث أنماط نهائية صريحة:

- `Flat`: يتوقف الخط عند نقطة النهاية.
- `Round`: يمتد طرف نصف دائري إلى ما بعد نقطة النهاية بمقدار نصف عرض الخط.
- `Square`: يمتد طرف مربع إلى ما بعد نقطة النهاية بمقدار نصف عرض الخط.

تتضمن الفئة أيضًا `NotDefined`، مما يعني أنه لم يتم تعيين نمط نهائي صراحة.

النهايات مختلفة عن رؤوس السهام التي تضيف رموزًا إلى نهايات الخط، وعن الوصلات التي تتحكم في الزوايا بين قطاعات الخط. هذا المثال يعطل رؤوس السهام عبر [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و[LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) بحيث تتم مقارنة أشكال النهايات فقط.

المثال التالي ينشئ ثلاثة خطوط أفقية متطابقة أخرى، بعرض 20 نقطة. من أعلى إلى أسفل، يستخدمون نهايات مسطحة، مستديرة، ومربعة. نقاط النهاية لها نفس الإحداثيات الأفقية؛ النهايات المستديرة والمربعة تمتد 10 نقاط خارج كل نقطة نهاية.

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

النتيجة في PowerPoint، من أعلى إلى أسفل: **Flat**، **Round**، و**Square**.

![نهايات مسطحة، مستديرة، ومربعة على خطوط سميكة متطابقة في PowerPoint](line-caps.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُعيد تأثير الرسم التخطيطي مظهر خط الشكل كأنه مرسوم يدويًا. استخدم [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) لاختيار قيمة من فئة [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

يظهر الكود PHP التالي كيفية تطبيق تأثير [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

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

القيمة التي تُرجعها [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرةً إلى الشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective)، وصل إلى طريقة `getSketchFormat` للعنصر المرتجع، واقرأ قيمة `getSketchType` الخاصة بها. القيمة الفعلية تعكس التنسيق المطبق فعليًا بعد حل الوراثة. هذا المثال يتطلب عرضًا تقديميًا موجودًا يحتوي على شكل واحد على الأقل في شريحته الأولى ويطبع القيمتين:

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

إليك ثلاثة خيارات لأنواع الوصل:
* Round
* Miter
* Bevel

تتحكم نمط الوصل في كيفية اجتماع قطعتين من الحد عند الزاوية. استخدم **Round** للزوايا المستديرة، **Miter** للزوايا الحادة، أو **Bevel** للزوايا المسطحة.

![نمط الوصل في العرض التقديمي](join-style-powerpoint.png)

هذا المثال ينشئ ثلاثة مستطيلات سوداء بحدود زرقاء بعرض 15 نقطة. يضبط [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) على قيم miter و bevel و round من فئة [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) على التوالي، لمقارنة كيفية رسم الزوايا.

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

### **تحديد وصلات Miter عند الزوايا الحادة**

استخدم [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) مع ضبط [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) إلى [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) لتحديد مدى امتداد الزاوية الحادة.

الحد هو نسبة بين المسافة بين الزاوية الداخلية والخارجية للوصل وعرض الخط. على سبيل المثال، قيمة `8` تسمح بطول Miter يصل حتى ثماني أضعاف عرض الخط؛ وهي ليست قياسًا بالنقاط. إذا تجاوزت الزاوية الحد، يستخدم PowerPoint وصلًا مسطحًا عند تلك الزاوية. الحد الأكبر يسمح بنقاط أكثر حدة. الإعداد يؤثر فقط على وصلات Miter، وتغييره لا يؤثر مرئيًا عندما تبقى الزاوية ضمن كلا الحدين.

هذا المثال ينشئ مثلثين غير مملوءين متطابقين بحدود بعرض 20 نقطة. المثلث الأيسر يستخدم حدًا بقيمة `2`، واليمين يستخدم `8`. كل مثلث بعرض 80 نقطة وارتفاع 160 نقطة، مما يعطي نسبة طول Miter إلى عرض الخط تقريبًا `4.12`. وبالتالي، يقوم PowerPoint بعمل وصل مسطح للقمة اليسرى ويحافظ على القمة اليمنى حادة.

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

![قمة مسطحة بحد Miter 2 وقمة حادة بحد Miter 8 في PowerPoint](miter-limits.png)

## **تعبئة بالتدرج**

تعبئة التدرج تمزج الألوان عبر الشكل. هذا المثال يملأ بيضاويًا بتدرج خطي بزاوية 45 درجة من الأحمر إلى الأرجواني باستخدام [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). طريقة [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) تضع نقاط اللون عند 0 و 1، بداية ونهاية التدرج. مسح النقاط الموجودة يضمن استخدام هذين اللونين فقط.

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
![البيضاوي بتعبئة بالتدرج](gradient-fill.png)

إذا ظهر التدرج بصورة مختلفة في صورة مُصدَّرة مقارنةً بـ PowerPoint، انظر [Choose a Gradient Rendering Style](/slides/ar/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط عرض دون تغيير تعبئة التدرج المخزنة في العرض التقديمي.

### **تعيين زاوية التدرج الخطي**

استخدم [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) للتحكم في اتجاه تعبئة [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). تُقاس الزاوية بالدرجات وتزداد باتجاه عقارب الساعة: `0` من اليسار إلى اليمين، `90` من الأعلى إلى الأسفل، `180` من اليمين إلى اليسار، و`270` من الأسفل إلى الأعلى. تدعم الزوايا الكسرية. الزوايا النهائية خارج `[0, 360)` تُطبع إلى دورة واحدة؛ على سبيل المثال، `-45` يصبح `315` و`360` يصبح `0`.

هذا المثال ينشئ ستة مستطيلات بنقاط توقف اللون الأحمر، الأخضر، والأزرق المتطابقة عند المواضع `0`، `0.5`، و`1`. تم تعطيل التحجيم بحيث يمكن مقارنة الزاوية بشكل مستقل عن نسب أبعاد المستطيلات. الزوايا من اليسار إلى اليمين هي `0`، `45`، و`90` في الصف الأول، و`135`، `180`، و`270` في الصف الثاني.

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
![تدرجات خطية بزاوية 0، 45، و90 درجة في الصف العلوي، و135، 180، و270 درجة في الصف السفلي](linear-gradient-angles.png)

### **تحجيم التدرج الخطي مع الشكل**

يقبل [GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) قيمة من نوع [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). اضبطها صراحةً إلى `False` للحفاظ على زاوية التدرج الهندسية مع تغير أبعاد الشكل، أو إلى `True` لتحجيم التدرج مع عرض وارتفاع الشكل. عند تمكين التحجيم، قد تختلف الزاوية المرئية عن الزاوية المعينة على شكل غير مربع.

يستخدم المثال التالي زاوية `45` درجة ونقاط توقف اللون نفسها كما في مقارنة الزوايا. العمود الأيسر يستخدم `False`؛ العمود الأيمن يستخدم `True`. كل عمود يحتوي على مستطيل عريض فوق مستطيل طويل. يبدأ كلاهما بالأبعاد العريضة نفسها؛ تغيير عرض وارتفاع المستطيل الثاني يُظهر كيف يستجيب التعبئة لإعادة الحجم دون تغيير إعدادات التدرج.

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

النتيجة في PowerPoint، مع تعطيل التحجيم على اليسار وتمكينه على اليمين:
![مستطيلات عريضة وطويلة بتدرج بزاوية 45 درجة، مقارنة LinearGradientScaled False على اليسار مع True على اليمين](linear-gradient-scaling.png)

مع تعطيل التحجيم، تبقى أشرطة اللون المائلة بنفس الاتجاه في كلا المستطيلين. مع تمكين التحجيم، تتمدد الأشرطة مع نسب أبعاد الشكل. يساعد هذا في إعادة إنتاج تدرج القالب عند تعديل الشكل إلى حجم مختلف. على شكل مربع، لا يغيّر تمكين التحجيم مظهر هذا التدرج بزاوية `45` درجة.

كلا إعدادَي الزاوية والتحجيم ينطبقان على التدرجات الخطية. لا يتحكمان في تعبئات [GradientShape::Radial أو GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **دمج الزاوية مع اتجاه التدرج**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) يختار نمط تدرج من فئة [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); ليس بديلاً عن زاوية رقمية. بالنسبة لتدرج خطي، يمكن لأنماط الزوايا تغيير المنطقة التي توزع فيها الألوان دون تغيير الزاوية المعينة عبر [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). احتفظ بالاتجاه ثابتًا عند مقارنة الزوايا أو التحجيم.

التطبيق التالي يطبق نفس الإعدادات بترتيب عكسي. المستطيلان لهما المظهر نفسه: تعيين الاتجاه قبل أو بعد الزاوية لا يغيّر النتيجة.

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

تعبئة بنمط تطبق تصميمًا ثنائي اللون مثل النقاط أو الخطوط أو المربعات. هذا المثال يستخدم [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) لاختيار نمط شَبكة. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) يزود الخلفية باللون الرمادي الفاتح، و[PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) يزود لون النمط الأصفر.

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
![المستطيل بتعبئة بنمط](pattern-fill.png)

## **تعبئة بالصورة**

تعبئة بالصورة تستخدم صورة داخل شكل. هذا المثال يتطلب صورة محلية ويستخدم [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) لتحميلها إلى مجموعة صور العرض التقديمي. ضبط [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) إلى وضع التكرار يعيد تكرار الصورة داخل المستطيل. الصورة المصدر المستخدمة هنا موضحة أدناه:

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
![الشكل بتعبئة بالصورة](picture-fill.png)

### **تكرار الصورة كنقش**

إذا رغبت في تعيين صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): يضبط وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة البلاطات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كانت البلاطة مقلوبة أفقياً أو رأسياً أو كليهما.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): يضبط الإزاحة الأفقية للبلاطة (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): يضبط الإزاحة الرأسية للبلاطة (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس البلاطة الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس البلاطة الرأسي كنسبة مئوية.

هذا المثال يتطلب صورة محلية ويضبط [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) لتكرارها بنسبة 50٪ من حجمها الأصلي. إزاحات −32 نقطة تحرك البلاطات أفقياً ورأسياً؛ محاذاة أسفل-يمين والانعكاس في كلا الاتجاهين يحددان كيفية ترتيب النقش المتكرر.

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
![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

تعبئة صلبة تعطي الشكل لونًا واحدًا ومتجانسًا. هذا المثال يضبط [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) إلى وضع التعبئة الصلبة ويعيّن الأصفر عبر [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor)، ثم يحفظ المستطيل في عرض تقديمي.

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
![الشكل بتعبئة بلون صلب](solid-color-fill.png)

### **نسخ الألوان مع الحفاظ على مراجع السمة**

استخدم [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) لنسخ تعريف اللون، بما في ذلك نوع اللون، مرجع السمة، والتحويلات. هذا مفيد عند نقل لون تعبئة بين أشكال يجب أن تظل تتبع سمة العرض التقديمي. الطريقة تنسخ اللون فقط: لا تنسخ نوع التعبئة أو الحد أو تنسيقات الشكل الأخرى. اضبط نوع تعبئة الوجهة صراحةً باستخدام [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

هذا المثال ينشئ ثلاثة مستطيلات، من اليسار إلى اليمين: المصدر، نسخة تتبع السمة، ونسخة RGB ثابتة. يستخدم المصدر [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) للإشارة إلى أول لون لهجة ويضيف تدرجًا عبر [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). النسخة RGB تستخدم اللون الفعلي للملء للمصدر بحيث تبدو الثلاثة في البداية متطابقة. استدعاء [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) يضبط قيمة RGB ثابتة ويزيل أي تحويلات لون موجودة.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // مراجع السمة تتبع اللون المميز الجديد؛ قيمة RGB الثابتة لا تفعل ذلك.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

قبل تغيير السمة، جميع التعبئات الثلاثة متطابقة:
![المصدر، نسخة الوجهة باستخدام copyFrom، والنسخة RGB الثابتة بتعبئات زرقاء متطابقة](color-copy-before.png)

بعد تغيير السمة، المصدر والنسخة المتابعة للسمة تتبعا اللون المميز الجديد وتحتفظان بالتدرج. النسخة RGB الثابتة تظل زرقاء:
![المصدر ونسخة الوجهة باستخدام copyFrom بتعبئات برتقالية، بينما تظل النسخة RGB الثابتة زرقاء](color-copy-after.png)

التعريف المنسوخ مستقل عن المصدر. تعديل مرجع السمة للمصدر لاحقًا، أو تعيين لون آخر، أو إضافة أو إزالة تحويلاته لا يؤثر على الوجهة. تغيير السمة لا يزال يؤثر على الشكلين لأن كلًا منهما يشير بشكل مستقل إلى نفس لون السمة.

حفظ وإعادة فتح ملف PPTX يحتفظ بنوع اللون المنسوخ الذي تُرجعه [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType)، مرجع السمة، ومجموعة التحويلات التي تُرجعها [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform)؛ لا يقوم بتحويل التعريف إلى RGB.

عند النسخ بين سياقات سمة مختلفة، مثل عروض تقديمية ذات لوحات ألوان مميزة مختلفة، يتم حل المرجع المنسوخ وفقًا لسمة الوجهة. يمكن أن ينتج عن نفس المرجع والتحويلات لونًا مرئيًا مختلفًا. راجع [Presentation Theme](/slides/ar/php-java/presentation-theme/) لمزيد من المعلومات حول ضبط ألوان السمة.

## **استخدام خلفية الشريحة كملء للشكل**

استخدم [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) عندما يجب أن يتطابق الشكل مع خلفية الشريحة، على سبيل المثال في قالب عرض تقديمي. اضبط نوع التعبئة عبر [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) إلى [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) أولاً لإزالة أي تعبئة صريحة. بهذا الجمع، يستخدم الشكل خلفية الشريحة بدلًا من تعبئته النمطية. تمكين العلامة وحده لا يزيل تعبئة صريحة موجودة.

هذا يختلف عن [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): تعبئة الخلفية تغطي الكائنات خلف الشكل بالمنطقة المقابلة من خلفية الشريحة، بينما لا تعبئة يترك تلك الكائنات مرئية. يظل التدرج محاذيًا مع الشريحة بدلاً من البدء داخل كل شكل.

المثال التالي ينشئ خلفية رئيسية يرثها الشريحة ويضع شريطًا أرجوانيًا خلف ثلاث مستطيلات. المستطيل الأيسر يستخدم الخلفية، المستطيل الأوسط بلا تعبئة، والمستطيل الأيمن ينتقل من تعبئة الخلفية إلى تعبئة برتقالية صريحة.

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

    // ورث التدرج من القالب الرئيسي.
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

    // أضف هذا الكائن أولاً بحيث يظهر خلف المستطيلات.
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

النتيجة، من اليسار إلى اليمين: **background fill**، **no fill**، و**explicit fill**. الشريط الأرجواني مخفي خلف المستطيلين الأيسر والأيمن لكنه يبقى مرئيًا من خلال المستطيل الأوسط.

![تعبئة خلفية، لا تعبئة، وتعبئة برتقالية صريحة فوق شريط أرجواني](background-fill.png)

السلوك نفسه ينطبق على خلفية محددة مباشرةً على الشريحة أو موروثة من تخطيط. يستخدم الشكل خلفية الشريحة المحسوبة؛ المثال يترك خلفيات كلٍّ من الشريحة والتخطيط غير معرفة بحيث يزودها الرئيسي.

## **تعيين الشفافية**

في التعبئة الصلبة، يتحكم مكون ألفا للون في الشفافية: 0 يعني شفاف بالكامل و255 يعني غير شفاف بالكامل. يستخدم هذا المثال قيمة ألفا 128 لمستطيل أصفر، مما يجعله شفافًا بنحو 50٪ بحيث يظل المستطيل الموجود تحته مرئيًا. يتم تعيين اللون عبر [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

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

استخدم [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) لتدوير شكل في سطح الشريحة. تُقاس الزاوية بالدرجات؛ هذا المثال يدور مستطيلًا 5 درجات باتجاه عقارب الساعة ويحفظ العرض التقديمي.

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

## **إضافة تأثيرات الحافة ثلاثية الأبعاد**

استخدم [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) لإضفاء عمق وحواف مشطوفة على الشكل. هذا المثال ينشئ بيضاويًا أخضرًا بحد برتقالي، يضبط [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) إلى 4 نقاط، ويطبق حافة علوية دائرية بعرض وارتفاع 6 نقاط عبر [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). تجعل كاميرا أورثوجرافية موجهة للأمام وإضاءة ثلاثية النقاط الحافة مرئية.

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
![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران ثلاثي الأبعاد**

يتم التحكم في عرض الشكل ثلاثي الأبعاد عبر إعدادات الكاميرا الخاصة به. يستخدم هذا المثال [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) بزاوية خطوط العرض والطول والزوايا الدوارة 40، 35، و20 درجة على التوالي. يختار كاميرا إسومترية عبر [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) وإضاءة متوازنة عبر [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType)، ثم يحفظ المستطيل المنسق.

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

طريقة [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) تحدد كيف يُعرض شكل فردي عندما يُعرض أو يُعالج العرض التقديمي في وضع الأسود والأبيض. لا تمكّن عرضًا بالأبيض والأسود بحد ذاتها، ولا تغير تعبئة الشكل أو خطه أو تنسيقه الآخر في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يترك تطبيق العرض يختار التحويل، `Gray` و`LightGray` يستخدمان اللون الرمادي، `BlackWhite` يستخدم فقط الأسود والأبيض، `Black` و`White` يفرضان لونًا واحدًا، `Color` يحافظ على اللون الطبيعي، و`Hidden` يزيل الشكل في وضع الأسود والأبيض. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

هذا المثال ينشئ مستطيلًا برتقاليًا ويضبط [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) إلى رمادي. يحتفظ الشكل المحفوظ بتعبئته البرتقالية للعرض بالألوان العادية ويطلب تلوينًا رماديًا من التطبيقات التي تحترم إعدادات العرض بالأبيض والأسود:

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

في وضع اللون العادي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض بالأبيض والأسود، يستخدم تلوينًا رماديًا لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تعريف مظهر مميز للطباعة أو المعاينة أو غيرها من سير العمل التي تحترم إعدادات العرض بالأبيض والأسود للعرض التقديمي.

## **إعادة تعيين التنسيق**

استخدم [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) لاستعادة موضع وحجم وتنسيق نواقل الشريحة من نواقل التخطيط المقابلة. يتطلب هذا المثال عرضًا تقديميًا موجودًا يحتوي على نواقل مرتبطة بالتخطيط ويعيد ضبط كل شريحة قبل الحفظ. الأشكال التي لا تمتلك نواقل تخطيط مقابلة لا يتم إعادة تعيينها.

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

**هل يؤثر تنسيق الشكل على حجم ملف العرض التقديمي النهائي؟**  
الألوان وأنماط الخطوط وإعدادات التأثيرات عادةً ما تضيف بيانات قليلة مقارنةً بالصور والوسائط المضمنة. تعبئة الصور يمكن أن تزيد من حجم الملف لأن صورها تُخزن في العرض التقديمي.

**كيف يمكنني اكتشاف الأشكال في الشريحة التي تشترك في تنسيق متطابق بحيث يمكنني تجميعها؟**  
قارن خصائص التنسيق الرئيسية لكل شكل — التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**  
نعم. احفظ أشكالًا نموذجية مع الأنماط المطلوبة في مجموعة شرائح قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حيثما يلزم.
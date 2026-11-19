---
title: إضافة معادلات رياضية إلى عروض PowerPoint في PHP
linktitle: معادلات رياضية PowerPoint
type: docs
weight: 80
url: /ar/php-java/powerpoint-math-equations/
keywords:
- معادلة رياضية
- رمز رياضي
- صيغة رياضية
- نص رياضي
- إضافة معادلة رياضية
- إضافة رمز رياضي
- إضافة صيغة رياضية
- إضافة نص رياضي
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في PowerPoint PPT و PPTX باستخدام Aspose.Slides للـ PHP عبر Java، مع دعم OMML، وضوابط التنسيق، وأمثلة شفرة PHP واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات بصيغة Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء نفس نوع محتوى الرياضيات برمجياً: الكسور، الجذور، الدوال، الحدود، المشغلات N‑ary، المصفوفات، المصفوفات المتعددة، وكتل الرياضيات المُنسقة.

في PowerPoint، يضيف المستخدمون المعادلات عادةً من **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يُنشأ باستخدام [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) يخزن المحتوى الرياضي داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) يحتوي على كائن واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) والطرق المتسلسلة من [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) لجعل الشفرة قصيرة وسهلة القراءة.

للحالات التي تتطلب تصدير MathML، راجع [Export Math Equations from Presentations in PHP via Java](/slides/ar/php-java/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال يستخدم [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) لإنشاء شكل رياضي ويضيف مبدأ فيثاغورس:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) يُنشئ شكلاً يحتوي بالفعل على فقرة رياضية. ادخل إلى أول [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)، وأضف كتل رياضية أو عناصر رياضية إليها.
{{% /alert %}}

### **دمج كتل الرياضيات**

عندما تُبنى أجزاء المعادلة بشكل مستقل ككائنات [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)، استخدم [joinBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/#joinBlock) لدمجها. المثال يبني `c² =` في الكتلة اليسرى و`a² + b²` في الكتلة اليمنى. [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSuperscript) يُنشئ أعلى رياضية قابلة للتحرير لجميع القوى الثلاث.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addMathShape(20, 20, 600, 100);
    $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $mathParagraph = $mathPortion->getMathParagraph();

    $leftBlock = new MathBlock();
    $leftBlock->add((new MathematicalText("c"))->setSuperscript("2"));
    $leftBlock->add(new MathematicalText("="));

    $rightBlock = new MathBlock();
    $rightBlock->add((new MathematicalText("a"))->setSuperscript("2"));
    $rightBlock->add(new MathematicalText("+"));
    $rightBlock->add((new MathematicalText("b"))->setSuperscript("2"));

    $combinedBlock = $leftBlock->joinBlock($rightBlock);
    $mathParagraph->add($combinedBlock);

    $presentation->save("equation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/#joinBlock) يرجع `$leftBlock` نفسه، الآن يحتوي على الجزأين بالترتيب، ويترك `$rightBlock` فارغًا. أضف الكتلة المدمجة إلى [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) مرة واحدة فقط. بعد إعادة فتح `equation.pptx`، الفقرة تحتوي على كتلة واحدة تمثل `c² = a² + b²`، مع الحفاظ على جميع القوى الثلاث كقواسم رياضية.

استدعاء [add](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/#add) كـ `$leftBlock->add($rightBlock)` يحاول وضع كتلة داخل أخرى مباشرةً وينتج عنه `InvalidOperationException`.

## **إضافة كسور**

استخدم [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

للكسر المتراكم، استخدم [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **إضافة جذور**

استخدم [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) لإنشاء جذر تربيعي، جذر مكعب، أو جذر آخر. العنصر الحالي يصبح القاعدة، والوسيط يصبح الدرجة.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **إظهار أو إخفاء درجة الجذر التربيعي**

الجذر التربيعي يمكن أن يُظهر عدد 2 صريحًا أو يستخدم الترميز التقليدي √x. طريقة [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) في [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) تتحكم في الشكل الظاهر. كلا الشكلين يحتفظان بدرجة 2 والجزء داخل الجذر x في المعادلة القابلة للتحرير.

![The same square root with the degree visible on the left and hidden on the right](square-root-degree.png)

المثال يحفظ نفس الجذر التربيعي مرتين. في `visible-degree.pptx` يكون الـ2 مرئيًا. في `hidden-degree.pptx` يكون مخفيًا.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $radical = (new MathematicalText("x"))->radical("2");

    $shape = $slide->getShapes()->addMathShape(20, 20, 200, 100);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getMathParagraph()->add(new MathBlock($radical));

    $radical->setHideDegree(false);
    $presentation->save("visible-degree.pptx", SaveFormat::Pptx);

    $radical->setHideDegree(true);
    $presentation->save("hidden-degree.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إضافة دوال وحدود**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) أو [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) أو استخدم [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

لإنشاء اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي واستدعِ [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) مع الوسيط الخاص به:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **إضافة مشغلات N‑ary وتكاملات**

استخدم [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) للجمع، الاتحاد، التقاطع، وغيرها من المشغلات الكبيرة. استخدم [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) للتكاملات. كلتا الطريقتين تسمحان بتعيين الحدود السفلية والعلوية.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

مشغلات N‑ary مخصصة للمشغلات الكبيرة مع حدود اختيارية. المشغلات البسيطة مثل `+`, `-`, و `=` تُضاف عادةً كـ [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) وتُدمج في التعبير.

للتكامل، استخدم [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تتضمن أقواساً افتراضيًا، لذا قم بإحاطة المصفوفة عندما تحتاج إلى أقواس أو أقواس مربعة أو أقواس معقوفة.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **تحرير مصفوفة موجودة**

افترض أن درس الجبر الخطي يبدأ بمصفوفة المعاملات في `matrix.pptx`، التي تم حفظها بالمثال السابق. للتمرين التالي، احتفظ بالمعادلة الأولى، استبدل الثانية بمعادلتين جديدتين، وعدل مجموعة المتغيرات. افتح المصفوفة الحالية عبر [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) للحفاظ على المعاملات التي لا تزال صالحة.

![Original two-row coefficient matrix with entries 1, x, and an empty cell in the first row and x, 2, and y in the second](matrix-before-edit.png)

فهارس الصفوف والأعمدة تبدأ من الصفر وتشير إلى حالة المصفوفة في كل استدعاء. إدراج صف قبل الفهرس 1 ينقل الصف الأصلي الثاني إلى الفهرس 2. الإدراج بعد الفهرس 2 يضيف صفًا في النهاية. حذف الصف 2 يزيل المعادلة الأصلية الثانية ويحرك الصف المضاف إلى الأعلى موضعًا واحدًا. الأعمدة تتحرك بنفس الطريقة.

```php
use aspose\slides\MathematicalText;
use aspose\slides\MathHorizontalAlignment;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("matrix.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $block = $portion->getMathParagraph()->get_Item(0);
    $matrix = $block->get_Item(0);

    $matrix->insertRowBefore(1);
    $matrix->insertRowAfter(2);
    $matrix->deleteRow(2);

    $matrix->insertColumnBefore(1);
    $matrix->insertColumnAfter(3);
    $matrix->deleteColumn(3);

    // الخلايا الجديدة تكون في البداية null. اضبط المعاملات غير الصفرية أولاً.
    $matrix->set_Item(1, 0, new MathematicalText("12"));
    $matrix->set_Item(1, 1, new MathematicalText("1"));
    $matrix->set_Item(2, 2, new MathematicalText("10"));
    $matrix->set_Item(2, 3, new MathematicalText("1"));
    $rowCount = java_values($matrix->getRowCount());
    $columnCount = java_values($matrix->getColumnCount());
    for ($row = 0; $row < $rowCount; $row++) {
        for ($column = 0; $column < $columnCount; $column++) {
            $coefficient = $matrix->get_Item($row, $column);
            if (java_is_null($coefficient)) {
                $matrix->set_Item($row, $column, new MathematicalText("0"));
            }
        }
    }

    $matrix->setColumnAlignment(0, MathHorizontalAlignment::Left);
    $matrix->setColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

    $presentation->save("updated-matrix.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) يضبط المحاذاة للعمود الأول إلى اليسار. [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) يضبط ثلاثة أعمدة متتالية إلى اليمين، بدءًا من الفهرس 1. في `updated-matrix.pptx`، المصفوفة تحتوي على ثلاثة معادلات وأربعة متغيرات. معاملات الصف الأول الأصلية `1` و `x` تظهر الآن في العمودين الأول والثالث.

![Updated three-row matrix showing the rows 1, 0, x, 0; 12, 1, 0, 0; and 0, 0, 10, 1](matrix-after-edit.png)

## **إضافة مصفوفات معادلات**

استخدم [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) عندما تحتاج إلى معادلات محاذاة أو مجموعة رأسية من التعبيرات.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **محاذاة المصفوفة مع العناصر المجاورة**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) يتحكم في المحاذاة الرأسية للمصفوفة نسبةً إلى العناصر الرياضية بجوارها. المثال أدناه يقارن المحاذاة مع الصف الأول، مركز المصفوفة، والصف الأخير.

المثال التالي ينشئ ثلاث مصفوفات متطابقة، كل منها بثلاث صفوف وعناصر مجاورة `A=` و `=B`. كل النص الرياضي يستخدم خط Cambria Math بحجم 24 نقطة. فقط محاذاة المصفوفة تتغير.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المقارنة التالية تُظهر العرض المحفوظ في PowerPoint. لاحظ موضع `A=` و `=B` بجانب كل مصفوفة.

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **ضبط التباعد بين الصفوف**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) يحدد قاعدة التباعد للصفوف داخل المصفوفة. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) يزوّد قيمة عددية لقاعدة تباعد صريحة ويتم تجاهله إذا استُخدمت القواعد المسبقة.

للتباعد الدقيق، تُقاس القيمة بالنقاط. للتباعد النسبي، تُقاس بنصف خطوط: القيمة `3` في المثال تعني 1.5 سطر. اضبط الخصيتين معًا عند تحديد قيمة صريحة؛ تغيير القيمة العددية وحدها لا يختار قاعدة تباعد.

المثال أدناه يحفظ خمسة عروض تقديمية بنفس المعادلات، المحاذاة، وإعدادات الخط. الثلاثة الأولى تستخدم القواعد المسبقة؛ الأخيرة اثنتان تُظهران قيمًا صريحة.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

تباعد صفوف المصفوفة منفصل عن تباعد الفقرات. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) و [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) يضيفان مساحة حول الفقرة الحاوية، وليس بين صفوف المصفوفة. بالمثل، [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) يحدد موضع الفقرة الرياضية بأكملها أفقياً؛ لا يستبدل إعداد المحاذاة الرأسية للمصفوفة.

## **إضافة دوال مثلثية**

استخدم [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) عندما يكون الوسيط هو العنصر الحالي ويكون اسم الدالة معروفًا.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **إضافة أسفل وأسفل (Subscripts & Superscripts)**

استخدم مساعدي الأسفل والأسفل للفهارس والقوى. عندما يجب أن تظهر الفهارس على الجانب الأيسر للقاعدة، استخدم [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **إضافة محددات (Delimiters)**

استخدم [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) لوضع تعبير داخل محددات. يمكنك أيضًا ضبط حرف الفاصل لتعبيرات المحددات التي تحتوي على عدة عناصر.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **حجم ومطابقة المحددات**

مرّر `true` إلى [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) لجعل الأقواس تنمو حول عامل طويل، أو مرّر `false` لإبقائها بالحجم الطبيعي. استخدم [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) مع إحدى قيمتي [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` يوسّط الأقواس على محور الرياضيات، الذي يمر عبر وسط علامة المساواة. `Match` يطابقها مع المحتوى المحاط. كلا الإعدادين يؤثران فقط على المحددات. يبقى التعبير الداخلي كما هو.

المثال يضع كسرًا في القوة لـ`x` بحيث يمتد التعبير أعلى الخط الأساسي أكثر من أسفله. جميع المعادلات الأربعة تستخدم نفس الأقواس وإعدادات الخط.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في PowerPoint، قارن الصفوف لرؤية تأثير النمو. في الصف العلوي، تنمو الأقواس لتضمّن القوة وتظهر متشابهة لكل الشكلين. في الصف السفلي، النمو معطل. الأقواس الأصغر على اليسار (`Centered`) تتطابق مع علامة المساواة، بينما تلك على اليمين (`Match`) تقع أعلى حول التعبير.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **إضافة صندوق حدودي (Border Box)**

استدعِ [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) على كسر لتأطير التعبير بالكامل. الـ[MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) المعاد يُظهر جميع الجوانب الأربعة افتراضيًا. استخدم [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop)، [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom)، [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft)، و [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) لإزالة جوانب فردية.

المثال يضع ست نسخ من نفس الكسر على شريحة واحدة. لعرض الإلغاء، أخفِ جميع الجوانب الأربعة ومرّر `true` إلى [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) للحصول على خط مائل صاعد (↗) أو إلى [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) لخط مائل هابط (↘). يمكنك أيضًا استخدام [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) أو [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) مع أي تركيبة من الجوانب المرئية.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border](border-box-fractions.png)

في هذا الكسر، يتقاطع الخط الأفقي مع شريط الكسر. الخط العمودي يقطع كلًا من البسط والمقام بينما يبقى الإطار المحيط مرئيًا. هذه الخطوط تزّين التعبير بأكمله. الخط المشطوب للنص العادي يُطبّق على الأحرف داخل مقطع النص. بعد إعادة فتح العرض في PowerPoint، لا يزال بإمكانك تحرير البسط والمقام بشكل مستقل.

## **التحكم في الرؤية والتخطيط باستخدام عناصر شبحية (Phantom Elements)**

غيّرف تعبيرًا داخل [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) للتحكم في رؤيته والمساحة التي يضيفها إلى معادلة بشكل مستقل. طرق [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) تتحكم في ما يلي:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | مرّر `false` لإخفاء التعبير. أبعاده لا تزال تُساهم في التخطيط ما لم تتلقى الطرق المقابلة `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | اعتبر العرض الأفقي للتعبير صفرًا، مما يسمح للعناصر المجاورة بالاقتراب. |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | اعتبر ارتفاعه فوق الخط الأساسي صفرًا. يمكن أن يقلل ذلك من المسافة المحجوزة فوق العناصر المجاورة. |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | اعتبر عمقًا أسفل الخط الأساسي صفرًا. يمكن أن يقترب شريط الكسر أو محتوى آخر أسفل التعبير من جيرانه. |

الخط الأساسي هو الخط المرجعي الذي تجلس عليه الأحرف الرياضية العادية. إخفاء المحتوى لا يزيل أبعاده، وتعيين البعد كصفر لا يحذف التعبير. يبقى التعبير الأساسي متاحًا عبر [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase). مرّر `true` إلى [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) لعرضه مرة أخرى؛ تظل إعدادات الأبعاد كما هي.

المثال أدناه ينشئ خمس متغيّرات جنبًا إلى جنب: كسر مرئي، كسر مخفي يحتفظ بالمسافة، وثلاثة أكسرات مخفية مع تعيين بعد واحد كصفر. كل متغيّر يستخدم نفس التعبير المحيط وخط Cambria Math بحجم 24 نقطة. جميع أشكال المعادلات لها نفس الموضع العلوي، المحدد بالخط الرمادي. وضع الشبح في بسط كسر خارجي يجعل تغيّر التخطيط العمودي أسهل للملاحظة.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathFraction;
use aspose\slides\MathPhantom;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(1000, 180, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"];

    $guide = $slide->getShapes()->addAutoShape(ShapeType::Line, 10, 60, 980, 0);
    $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    foreach ($labels as $i => $labelText) {
        $left = 10 + $i * 200;

        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $left, 10, 190, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($labelText);

        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(14);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $fractionNumerator = $createText("a+b");
        $fractionDenominator = $createText("c+d");
        $fraction = new MathFraction($fractionNumerator, $fractionDenominator);
        $phantom = new MathPhantom($fraction);
        $phantom->setShow($i === 0);
        $phantom->setZeroWidth($i === 2);
        $phantom->setZeroAsc($i === 3);
        $phantom->setZeroDesc($i === 4);

        $leftText = $createText("x+");
        $rightText = $createText("+y");
        $numerator = (new MathBlock($leftText))->join($phantom)->join($rightText);
        $denominator = $createText("z");
        $equation = new MathFraction($numerator, $denominator);

        $shape = $slide->getShapes()->addMathShape($left, 60, 190, 100);
        $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);

        $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $mathParagraph = $mathPortion->getMathParagraph();
        $mathBlock = new MathBlock($equation);
        $mathParagraph->add($mathBlock);
    }

    $presentation->save("math-phantom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Five equations in PowerPoint comparing a visible fraction, a hidden fraction that reserves space, and hidden fractions with ZeroWidth, ZeroAsc, or ZeroDesc enabled](math-phantom.png)

## **تجميع المصطلحات**

استخدم [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) لوضع حرف تجميع فوق أو أسفل تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **تنسيق عناصر الرياضيات**

استخدم مساعدي التنسيق فقط حيث يوضح الصيغة. على سبيل المثال، [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) يضع شريطًا فوق عنصر رياضي.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **تنسيق النص في معادلة موجودة**

لتنسيق النص في معادلة موجودة، اجتز شجرة عناصر كل كتلة رياضية. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) تُعيد الأطفال المباشرين فقط، لذا استدعِها بصورة متداخلة للوصول إلى النص داخل الكسور، الأسفل/الأعلى، الجذور، والهياكل المتداخلة الأخرى. افحص العنصر الحالي وكذلك أطفاله لتضمين العنصر الابتدائي عندما يكون [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

هذا المثال يفترض أن `input.pptx` يحتوي على معادلة مثل `z = xᵢ / ∛y`، مع كسر يحتوي على أسفل في البسط وجذر في المقام. معالجة العناصر العليا فقط سيتغاضى عن النص داخل الكسر. المثال يحدد الأجزاء الرياضية في إطارات نص الشرائح، يَدخل إلى كتلها عبر [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)، ويستخدم [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) لضبط حجم الخط إلى 28 نقطة من خلال طريقة [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) لكل عنصر نصي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

العرض التقديمي المحفوظ يحتوي على تنسيق النص المحدث في كل مستوى من كل معادلة معالجة، مع الحفاظ على محتوى النص وبنية الرياضيات.

## **مرجع سريع**

| Task | Main API |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| دمج عناصر | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إنشاء كسور | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة أسفل أو أعلى | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة دوال | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة جذور | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة حدود | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة أسطر جانبية على اليسار | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة جمع وتكامل | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| إضافة مصفوفات معادلات | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة محددات | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| إضافة أشرطة وحدود | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| تجميع المصطلحات | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **الأسئلة المتكررة**

**هل يمكنني تحرير معادلة PowerPoint موجودة؟**

نعم. افتح العرض، ابحث عن الشكل الذي يحتوي على [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)، استدعِ [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)، وقم بتحديث كتل الرياضيات في تلك الفقرة.

**هل تُحفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند الحفظ إلى PPTX، تكتب Aspose.Slides المعادلة كمحتوى Office Math قابل للتحرير.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) من [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)، واستدعِ [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) لتصديره مباشرة. لمثال كامل، راجع [Export Math Equations from Presentations in PHP via Java](/slides/ar/php-java/exporting-math-equations/#export-math-equations-to-latex).
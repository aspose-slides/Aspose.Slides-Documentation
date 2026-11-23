---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام PHP
linktitle: انتقال الشرائح
type: docs
weight: 80
url: /ar/php-java/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال الشريحة المتقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وتأثيرات الانتقال الأخرى باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في كيفية ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك اختيار تأثير انتقال لكل شريحة، تكوين التقدم بالنقر بالفأرة أو المؤقت، وضبط الخيارات الخاصة بتأثير معين. يستخدم هذا المقال أمثلة PHP لتطبيق الانتقالات، ضبط مدة الانتقال بدقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. كما تظهر الأمثلة كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال للشرائح**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، وادخل على إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

المثال التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **انتقال العجلة**

طريقة [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة المستهدفة. استخدم [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) لاختيار Wheel من تعداد [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)، ثم استدعِ [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) للوصول إلى إعدادات [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

ينشئ المثال زوجين متطابقين من الشرائح. يبدأ كل زوج بشريحة سوداء وينتهي بشريحة مغطاة بمستطيل ذهبي. تستخدم الشريحة 2 عمودًا واحدًا والشريحة 4 ثمانية أعمدة. كلا الانتقالين يستخدمان نفس السرعة البطيئة، المحددة بواسطة [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)، ومدة صريحة قدرها 8000 مللي ثانية، محددة بواسطة [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

افتح العرض التقديمي المحفوظ في PowerPoint وابدأ عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2 لترى مسحًا واحدًا باتجاه عقارب الساعة. ثم انتقل من الشريحة 3 إلى الشريحة 4 لترى ثمانية قطاعات شعاعية تكشف نفس المستطيل في وقت واحد.

## **تلاشي عبر اللون الأسود باستخدام انتقال Reveal**

حدد نوع انتقال الشريحة المستهدفة إلى Reveal، ثم استدعِ [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) على إعدادات [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/). ينشئ المثال شريحة مصدر بلون أزرق مخضر وشريحة هدف بلون مرجاني، ثم ينسخهما. كل زوج يستخدم انتقال Reveal لمدة ثانيتين. فقط الزوج الثاني يضمّ عبر اللون الأسود.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

افتح العرض التقديمي المحفوظ في PowerPoint وابدأ عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2 لترى التلاشي مباشرةً من اللون الفيروزي إلى اللون المرجاني. ثم انتقل من الشريحة 3 إلى الشريحة 4. تصبح الشاشة مظلمة مؤقتًا تقريبًا إلى اللون الأسود قبل ظهور الشريحة المرجانية. تحتفظ كلتا الشريحتين بألوان الخلفية الأصلية.

تظهر الصفوف أدناه إطارات من PowerPoint بفواصل نصف ثانية. قارن الإطار الأوسط في كل صف لرؤية التأثير.

![أشرطة منفصلة تُظهر مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5,000 مللي ثانية.](reveal-through-black.png)

## **إضافة انتقال متقدم للشرائح**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالفأرة يقدّم عرض الشرائح. الطرق التالية تتحكم في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) يسمح للمشاهد بالتقدم بالنقر بالفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من التقدم بالنقر والوقت لتسمح للمشاهد بالتقدم بالنقر أو الانتظار للعداد. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). يتحكم التأخير في وقت تقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

يعين هذا المثال تأثيرات مختلفة للشرائح الثلاث الأولى ويفعّل التقدم التلقائي بعد 3، 5، و7 ثوانٍ على التوالي. يمكن للنقرات بالفأرة أيضًا تقديم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

للتحقق مما إذا كان التقدم الزمني مفعلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). مجرد وجود تأخير مخزن لا يدل على أن المؤقت نشط.

يفتح المثال التالي الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعّل، ويعطل التقدم التلقائي للشرائح التي لها تأخير أكبر من ثانيتين. يُفعّل النقر بالفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحكم بدقة في توقيت الانتقال**

استخدم [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تُظهر طريقة الشريحة [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) هذه الإعدادات عبر [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالمللي ثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة سرعة مسبقة التعريف من [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow، Medium، أو Fast. يُستخدم عندما لا يتم تحديد مدة صريحة. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) يتحكم فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. قم بتكوين تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![أشرطة منفصلة تُظهر مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5,000 مللي ثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*يوضح المثال المشترك إعطاء كل شريحة انتقال Fade لمدة 750 مللي ثانية وتمكين التقدم التلقائي بعد 5,000 مللي ثانية. مدة الانتقال تتحكم في التأثير؛ التقدم يتحكم في وقت مغادرة الشريحة. هذه الأشرطة تمثّل إعدادات تخطيّية، ليست مخططًا زمنيًا مُقاسًا.*  
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

للحصول على وتيرة متساوية، اطبق نفس التأثير والمدة الدقيقة على كل شريحة. يحمل هذا المثال ملف `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يُفعّل التقدم التلقائي بعد 5,000 مللي ثانية ويعطل التقدم بالنقر بالفأرة، ثم يحفظ النتيجة كـ PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // تكوين التقدم التلقائي بشكل مستقل عن مدة التأثير.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ضبط مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يضبط هذا المثال 500 مللي ثانية للشريحة الأولى و1,200 مللي ثانية للشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **تنسيق الانتقالات مع المخرجات المتحركة**

عند إعداد [GIF متحرك](/slides/ar/php-java/convert-powerpoint-to-animated-gif/)، [عرض HTML5](/slides/ar/php-java/export-to-html5/)، أو [فيديو](/slides/ar/php-java/convert-powerpoint-to-video/)، اضبط مدد الانتقالات بدقة قبل التصدير لتتناسب مع الوتيرة المطلوبة. على سبيل المثال، استخدم تلاشيًا لمدة 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بوقت للتعليق الصوتي أو المحتوى. بالنسبة للـ GIF والفيديو، نسّق معدل الإطارات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا بمعدل 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة للصيغة المختارة، وعرض معاينة للنتيجة للتأكد من التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم تعيين مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزنة بالمللي ثانية. القيمة غير المعينة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد تلك المدة. ضبط نوع الانتقال قد يهيئ مدة، لذا افحص الإعدادات الأصلية أولاً.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **انتقال Morph**

ينقل انتقال Morph التغييرات بين الكائنات في الشرائح المتتالية. لإنشاء تأثير Morph بسيط، انسخ شريحة، حرّك أو غيّر حجم كائن على النسخة، وطبّق انتقال Morph على الشريحة الثانية. يمنح ذلك الكائنات المقابلة انتقالًا بين حالتها الأصلية والمعدلة.

ينشئ المثال التالي شريحة تحتوي على مستطيل نصي، ينسخ الشريحة، ويغيّر موقع وحجم المستطيل في النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **أنواع انتقال Morph**

تتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) في كيفية مطابقة Morph وتحريك المحتوى:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) يتعامل مع كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). القيم ثم توفر كائن [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/)، وتختار طريقته [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) وضع المطابقة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **ضبط تأثيرات الانتقال**

تُظهر بعض الانتقالات خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المختار بواسطة [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). حدد النوع أولًا، ثم استخدم كائن الانتقال المناسب عبر [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

ينفذ المثال التالي انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة سرعة مسبقة التعريف من [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) كافية ولا توجد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال مستقلاً عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعلها تتكرر؟**

نعم. عيّن صوتًا مضمّنًا باستخدام [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound)، مرّر StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) بالقيمة `true`. يتكرر الصوت حتى حدث صوتي التالي في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بالتكرار عبر مجموعة [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل شريحة. اضبط أي توقيت وخيارات تأثير في نفس الحلقة للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال المعين حاليًا على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) الخاصة بالشريحة. يعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); القيمة None تعني عدم تطبيق أي تأثير انتقال.
---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام PHP
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/php-java/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص تأثيرات Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في كيفية ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك اختيار تأثير انتقالي لكل شريحة، تكوين التقدم بالنقر بالماوس أو المؤقت، وضبط الخيارات الخاصة بتأثير معين. يستخدم هذا المقال أمثلة PHP لتطبيق الانتقالات، ضبط مدد الانتقال الدقيقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) واطّلع على إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

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

## **انتقال Wheel**

طريقة [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة الهدف. استخدم [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) لاختيار Wheel من [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)، ثم استدعِ [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) للوصول إلى إعدادات [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

ينشئ المثال زوجين متماثلين من الشرائح. كل زوج يبدأ بشريحة سوداء وينتهي بشريحة مغطاة بمستطيل ذهبي. تستخدم الشريحة 2 قطاعًا واحدًا والشريحة 4 ثمانية قطاعات. كلا الانتقالين يستخدمان السرعة البطيئة نفسها، التي تم تعيينها عبر [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)، ومدة صريحة قدرها 8,000 ملليثانية، تم تحديدها عبر [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

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

افتح العرض التقديمي المحفوظ في PowerPoint وابدأ عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2 لترى مسحًا واحدًا مع اتجاه عقارب الساعة. ثم انتقل من الشريحة 3 إلى الشريحة 4 لترى ثمانية قطاعات شعاعية تكشف المستطيل نفسه في آنٍ واحد.

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس يتقدم بعرض الشرائح. الطرق التالية تتحكم في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) يسمح للمشاهد بالتقدم عند النقر بالماوس.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) يحدد التأخير قبل التقدم التلقائي، بالملليثانية.

فعّل كل من التقدم بالنقر والتوقيت لتمكين المشاهد من المتابعة بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). يتحكم التأخير في موعد تقدم عرض الشرائح؛ ولا يحدد مدة تأثير الانتقال البصري.

يعين هذا المثال تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن للنقرات أيضًا تقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم الزمني مفعلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). التخزين المتأخر وحده لا يدل على أن المؤقت نشط.

يفتح المثال التالي الملف المحفوظ أعلاه، يبلّغ عن كل مؤقت مفعّل، ويعطّل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يفعّل النقرات للشرائح تلك ويحفظ الإعدادات المحدثة.

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

## **التحكم في توقيت الانتقال بدقة**

استخدم [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالملليثانية. طريقة [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) في الشريحة تكشف عن هذه الإعدادات عبر [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | يحدد مدة تأثير الانتقال نفسه، بالملليثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالملليثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة سرعة مسبقة التعريف من [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow أو Medium أو Fast. يُستخدم عندما لا يتم تحديد مدة صريحة. |

تتحكم [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) فقط في تأثير الانتقال؛ ولا تحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![تُظهر الأشرطة المنفصلة مدة الانتقال 750 ملليثانية وإعداد التقدم التلقائي 5,000 ملليثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*يعطي المثال المشترك لكل شريحة انتقال Fade بمدة 750 ملليثانية ويفعّل التقدم التلقائي بعد 5,000 ملليثانية. تتحكم مدة الانتقال في التأثير؛ والتحكم في التقدم يحدد متى تُغادر الشريحة. هذه الأشرطة تمثّل إعدادات تخطيطية، ليست مخططًا زمنيًا مقاسًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

للحصول على إيقاع ثابت، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. يحمل هذا المثال `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 ملليثانية. يُفعّل التقدم التلقائي بعد 5,000 ملليثانية ويعطل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

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

### **تحديد مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يحدد هذا المثال 500 ملليثانية للشفريحة الأولى و1,200 ملليثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند إعداد [animated GIF](/slides/ar/php-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/php-java/export-to-html5/)، أو [video](/slides/ar/php-java/convert-powerpoint-to-video/)، عيّن مدد الانتقال الدقيقة قبل التصدير لتتناسب مع الإيقاع المقصود. على سبيل المثال، استخدم تلاشي 600 ملليثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل لإتاحة الوقت للسرد أو المحتوى.

لملفات GIF والفيديو، نسّق معدل الإطارات مع مدة التأثير: 600 ملليثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقّق من الدعم الفعلي للانتقالات وخيارات التوقيت للصيغة المُختارة، وعروض مسبقة للنتيجة للتأكد من التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ والقيمة غير السالبة تحدد المدة المخزنة بالملليثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد تلك المدة. تحديد نوع الانتقال قد يهيئ مدة، لذا افحص الإعدادات الأصلية أولًا.

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

يُحرك انتقـال Morph التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرك أو غير حجم كائن على النسخة، وطبق انتقـال Morph على الشريحة الثانية. يمنح ذلك الكائنات المتطابقة لتُحرك بين حالتها الأصلية وال-modified.

ينشئ المثال التالي شريحة تحتوي على مستطيل نص، ينسخ الشريحة، ويغيّر موضع وحجم المستطيل في النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) للشفريحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

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

## **أنواع انتقـال Morph**

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) في كيفية مطابقة وإ animating المحتوى:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). تُعيد القيمة بعد ذلك كائن [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/)، حيث تختار طريقة المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType).

يفتح هذا المثال العرض التقديمي الذي أنشئ في القسم السابق ويضبط الشريحة الثانية لاستخدام تحريك Morph على أساس الكلمات.

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

## **تعيين تأثيرات الانتقال**

تُظهر بعض الانتقالات خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المختار عبر [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). اضبط النوع أولاً، ثم استخدم كائن الانتقال المناسب من [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

يطبق المثال التالي انتقـال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) لتبدأ الانتقال من شاشة سوداء.

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

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يُفضَّل استخدام [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالملليثانية. استخدم [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) مسبقة (Slow أو Medium أو Fast) كافية ولا تُحدِّد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مدمجًا عبر [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound)، مرّر `StartSound` من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) بـ `true`. سيستمر الصوت بالتكرار حتى يحدث حدث صوتي التالي في عرض الشرائح.

**ما أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بالتكرار عبر مجموعة [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل انتقال شريحة. اضبط أي إعدادات توقيت وتأثير داخل نفس الحلقة للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المعين على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) الخاصة بالشريحة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); قيمة `None` تعني عدم تطبيق أي تأثير انتقالي.
---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام PHP
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/php-java/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for PHP عبر Java، يمكنك اختيار تأثير الانتقال لكل شريحة، وتكوين التقدم بواسطة نقرة الفأرة أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة PHP لتطبيق الانتقالات، وتحديد مدد الانتقال الدقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) وتوجه إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setType) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

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

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كانت نقرة الفأرة ستتقدم بالعرض. الطرق التالية تتحكم في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) يسمح للمُشاهد بالتقدم بالنقر.
- [setAdvanceAfter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) يحدد التأخير قبل التقدم التلقائي، بالميليثانية.

فعّل كل من النقر والتوقيت لتمكين المُشاهد من الانتقال بالنقر أو الانتظار للمدة المحددة. لاستخدام المؤقت فقط، مرّر القيمة `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). التحكم في التأخير يحدد متى يتقدم العرض؛ لا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعّل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن أيضًا التقدم بالنقر. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم الزمني مفعلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). التخزين الوحيد للتأخير لا يعني أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يحدد كل مؤقت مفعّل، ويعطل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يُفعّل النقر لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

استخدم [setDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالميليثانية. تُظهر طريقة [getSlideShowTransition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#getSlideShowTransition) للشرائح هذه الإعدادات عبر فئة [SlideShowTransition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setDuration) | يحدد مدة تأثير الانتقال نفسه، بالميليثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالميليثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة سرعة مُعرّفة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitionspeed/): Slow أو Medium أو Fast. تُستَخدم عندما لا يتم تحديد مدة صريحة. |

يُتحكم [setDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setDuration) فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **تطبيق نفس المدة على كل الشريحة**

لضمان إيقاع ثابت، طبق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 ميليثانية. يفعّل التقدم التلقائي بعد 5,000 ميليثانية ويعطل التقدم بنقرة الفأرة، ثم يحفظ النتيجة كملف PPTX.

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

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن أن تستخدم الشرائح المختلفة مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا سريعًا لشريحة العنوان وانتقالًا أطول لتقديم قسم. هذا المثال يحدد 500 ميليثانية للشريحة الأولى و1,200 ميليثانية للشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند إعداد [animated GIF](/slides/ar/php-java/convert-powerpoint-to-animated-gif/)، أو [HTML5 presentation](/slides/ar/php-java/export-to-html5/)، أو [video](/slides/ar/php-java/convert-powerpoint-to-video/)، حدد مدد الانتقال الدقيقة قبل التصدير لتتناسب مع الإيقاع المطلوب. على سبيل المثال، استخدم تلاشيًا مدته 600 ميليثانية بين المشاهد، وعدّل تأخير تقدم كل شريحة بشكل منفصل للسماح بالرا narration أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل الإطارات مع مدة التأثير: 600 ميليثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من الدعم للانتقالات وخيارات التوقيت في صيغة التصدير المختارة، واختبر النتيجة للتأكد من التزامن.

### **قراءة مدة الانتقال الحالية**

استدعِ [getDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزنة بالميليثانية. القيمة غير المضبوطة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد تلك المدة. قد يهيّء تعيين نوع الانتقال مدةً مبدئية، لذا افحص الإعدادات الأصلية أولاً.

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

يُحرك انتقال Morph التغييرات بين الكائنات في الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرّك أو غير حجم كائن على النسخة، وطبّق انتقال Morph على الشريحة الثانية. يُعطي ذلك الكائنات المقابلة القدرة على التحرك بين الحالة الأصلية والمعدلة.

المثال التالي ينشئ شريحة تحتوي على مستطيل نصي، ينسخ الشريحة، ثم يغيّر موقع وحجم المستطيل على النسخة. بعد ذلك يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء العرض.

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

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitionmorphtype/) في طريقة مطابقة وإ animating المحتوى:

- [ByObject](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitionmorphtype/#ByWord) يُحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitionmorphtype/#ByChar) يُحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setType) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#getValue). تُعطي القيمة بعد ذلك كائنًا من نوع [MorphTransition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/morphtransition/)، حيث يحدد [setMorphType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/morphtransition/#setMorphType) وضع المطابقة.

هذا المثال يفتح العرض التقديمي الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام حركة Morph قائمة على الكلمات.

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

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان يبدأ التأثير من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المختار باستخدام [setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setType). حدّد النوع أولاً، ثم استخدم كائن الانتقال المناسب من [getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#getValue).

المثال التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/ar/php-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر فئة [OptionalBlackTransition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

**هل يمكنني التحكم بسرعة تشغيل انتقال الشريحة؟**

نعم. استخدم [setDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالميليثانية. استخدم [setSpeed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitionspeed/) مُحددة (Slow أو Medium أو Fast) كافية ولا توجد مدة صريحة مُحددة. تُتحكم هذه الإعدادات في تأثير الانتقال بشكل منفصل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا باستخدام [setSound](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setSound)، مرّر `StartSound` من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setSoundLoop) بالقيمة `true`. سيتكرر الصوت حتى حدث صوتي لاحق في عرض الشرائح.

**ما أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

تجوّل عبر مجموعة [getSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSlides) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل شريحة. اضبط أي إعدادات توقيت أو تأثير داخل الحلقة نفسها للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المُطبق على شريحة معينة؟**

استدعِ [getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#getSlideShowTransition) للشفرة. ستُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/transitiontype/)؛ القيمة `None` تعني عدم تطبيق أي تأثير انتقال.
---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام JavaScript
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/nodejs-java/slide-transition/
keywords:
- انتقال شريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص تأثيرات Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides for Node.js via Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في كيفية ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for Node.js via Java، يمكنك اختيار تأثير الانتقال لكل شريحة، تكوين التقدم بالنقر بالماوس أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. تستخدم هذه المقالة أمثلة JavaScript لتطبيق الانتقالات، تحديد مدة الانتقال بدقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات في ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) وواصل إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setType) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

المثال التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس سيؤدي إلى تقدم عرض الشرائح. تتحكم الطرق التالية في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) يسمح للمشاهد بالتقدم بالنقر بالماوس.
- [setAdvanceAfter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) يحدد التأخير قبل التقدم التلقائي، بالميليثانية.

فعّل كل من النقر والتوقيت لتسمح للمشاهد بالتقدم بالنقر أو الانتظار للعداد. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). يتحكم التأخير في وقت تقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3، 5، و7 ثوانٍ على التوالي. يمكن للنقرات أيضًا تقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

للتحقق ما إذا كان التقدم الزمني مفعّلًا، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). التخزين المتأخر وحده لا يدل على أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يُبلّغ عن كل مؤقت مفعّل، ويعطل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يُفعّل النقرات لهذه الشرائح ويحفظ الإعدادات المحدثة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في توقيت الانتقال بدقة**

استخدم [setDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالميليثانية. تُظهر طريقة الشريحة [getSlideShowTransition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) هذه الإعدادات عبر [SlideShowTransition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | يحدد مدة تأثير الانتقال نفسه، بالميليثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدد التأخير قبل أن تتقدم الشريحة تلقائيًا، بالميليثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة سرعة محددة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitionspeed/): Slow أو Medium أو Fast. تُستعمل عندما لا تُحدد مدة دقيقة. |

[setDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setDuration) يتحكم فقط في تأثير الانتقال؛ لا يحدّد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، تُحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **تطبيق نفس المدة على كل شريحة**

لتحقيق إيقاع ثابت، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 ميليثانية. يُفعّل بشكل منفصل التقدم التلقائي بعد 5 000 ميليثانية ويعطل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // تكوين التقدم التلقائي بشكل مستقل عن مدة التأثير.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لتقديم قسم. هذا المثال يعيّن 500 ميليثانية للشفرة الأولى و1 200 ميليثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **التنسيق بين الانتقالات والمخرجات المتحركة**

عند إعداد [animated GIF](/slides/ar/nodejs-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/nodejs-java/export-to-html5/)، أو [video](/slides/ar/nodejs-java/convert-powerpoint-to-video/)، حدّد مدد الانتقال الدقيقة قبل التصدير لتطابق الإيقاع المطلوب. على سبيل المثال، استخدم تلاشيًا (fade) مدته 600 ميليثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بالوقت المخصص للسرد أو المحتوى.

بالنسبة لـ GIF والفيديو، نسّق معدل إطارات الإخراج مع مدة التأثير: 600 ميليثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة من صيغة التصدير المختارة، واستعرض المخرجات لتأكيد التزامن.

### **قراءة مدة الانتقال الحالية**

استدعِ [getDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت هناك قيمة صريحة مخزّنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزّنة بالميليثانية. القيمة غير المُحددة ليست مدة التشغيل المحسوبة: تستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد تلك المدة. تعيين نوع الانتقال قد يهيئ مدة، لذا افحص الإعدادات الأصلية أولاً.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **انتقال Morph**

يُحاكي انتقال Morph تغييرات الكائنات بين الشرائح المتتابعة. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرّك أو غيّر حجم كائن على النسخة، وطبق انتقال Morph على الشريحة الثانية. يمنح ذلك الكائنات المطابقة فرصة للإنّيميشن بين حالتها الأصلية والمعدلة.

المثال التالي ينشئ شريحة بها مستطيل نصي، يستنسخ الشريحة، ويغيّر موقع المستطيل وحجمه على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **أنواع انتقال Morph**

يُحدد تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitionmorphtype/) طريقة مطابقة المحتوى وإنمائه:

- [ByObject](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) يُحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) يُحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setType) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#getValue). ثم توفّر القيمة كائن [MorphTransition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/morphtransition/)؛ تُحدّد الطريقة المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/morphtransition/#setMorphType).

هذا المثال يفتح العرض التقديمي الذي أُنشئ في القسم السابق ويُعدّل الشريحة الثانية لتستخدم إنمائية Morph القائمة على الكلمات.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **تعيين تأثيرات الانتقال**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المختار عبر [setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setType). حدّد النوع أولاً، ثم استخدم كائن الانتقال المناسب من [getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#getValue).

المثال التالي يطبق انتقال Cut على الشريحة الأولى في `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر [OptionalBlackTransition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يُفضل استخدام [setDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالميليثانية. استخدم [setSpeed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitionspeed/) المعرفة مسبقًا—Slow أو Medium أو Fast—كافية ولا توجد مدة صريحة مُحددة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكن إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا عبر [setSound](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setSound)، مرّر StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) بالـ `true`. يتكرر الصوت حتى حدث صوتي التالي في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل الشريحة؟**

قم بالتكرار خلال مجموعة [getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSlides) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل شريحة. اضبط أي خيارات توقيت وتأثير داخل الحلقة نفسها للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المُعيّن على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) للشفرة. تُرجع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/transitiontype/)؛ قيمة None تعني عدم تطبيق تأثير انتقال.
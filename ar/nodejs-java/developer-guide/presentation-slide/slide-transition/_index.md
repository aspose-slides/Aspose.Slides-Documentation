---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام JavaScript
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides لـ Node.js عبر Java، يمكنك اختيار تأثير انتقال لكل شريحة، تكوين التقدم بالنقر بالفأرة أو المؤقت، وضبط الخيارات الخاصة بالتأثير. تستخدم هذه المقالة أمثلة JavaScript لتطبيق الانتقالات، وتحديد مدد الانتقال الدقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. كما تُظهر الأمثلة كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، حمِّل عرضًا تقديميًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وابدأ بالوصول إلى إعدادات انتقال الشريحة من خلال [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) ثم احفظ العرض التقديمي.

المثال التالي يطبق انتقال دائرة على الشريحة الأولى وانتقال مشط على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

## **انتقال عجلة**

طريقة [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) في [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة الهدف. اضبط نوع انتقال الشريحة إلى Wheel من خلال تعداد [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) باستخدام [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) قبل الوصول إلى [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) كـ [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

هذا المثال ينشئ زوجين متماثلين من الشرائح: شريحة سوداء تليها شريحة بها مستطيل ذهبي. الشرائح الهدف تستخدم عدد أسنان 1 و 8، مع نفس السرعة المعينة عبر [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) ومدد صريحة قدرها 8 000 مللي ثانية عبر [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) لجعل الفرق واضحًا للملاحظة.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

افتح العرض الناتج في PowerPoint وشغّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، عدد الأسنان المؤكد 1 يكشف الشريحة بفتحة واحدة في اتجاه عقارب الساعة؛ العدد المؤكد 8 يكشفها عبر ثمان قطاعات شعاعية في آنٍ واحد. محتوى الهدف وتوقيت الانتقال متطابقان، لذا الفرق هو عدد قطاعات الكشف.

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان نقرة الفأرة ستقدم عرض الشرائح. الطرق التالية تتحكم في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) تسمح للمشاهد بالتقدم بالنقر بالفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) تمكّن التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تحدد التأخير قبل التقدم التلقائي، بالملي ثانية.

فعّل كل من التقدم بالنقر والوقت ليتمكن المشاهد من المتابعة بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). يتحكم التأخير في وقت تقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعّل التقدم التلقائي بعد 3 و 5 و 7 ثوانٍ على التوالي. يمكن للنقرات الفأرة أيضًا أن تتقدم بهذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم المؤقت مفعّلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). التخزين المؤقت للتأخير وحده لا يدل على أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يضيف تقريرًا لكل مؤقت مفعّل، ويعطّل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يفعّل النقر بالفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

## **التحكم بدقة في توقيت الانتقال**

استخدم [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالملي ثانية. تُظهر طريقة الشريحة [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) هذه الإعدادات عبر [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | يحدد مدة تأثير الانتقال نفسه، بالملي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدد التأخير قبل أن تتقدم الشريحة تلقائيًا، بالملي ثانية. مرر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة السرعة المحددة مسبقًا من تعداد [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium, أو Fast. يُستخدم عندما لا يتم تحديد مدة صريحة. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) يتحكم فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير من نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![الأشرطة المنفصلة تُظهر مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5,000 مللي ثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*المثال المشترك يمنح كل شريحة انتقال Fade مدته 750 مللي ثانية ويُفعّل التقدم التلقائي بعد 5,000 مللي ثانية. مدة الانتقال تتحكم في التأثير؛ التقدم يتحكم في وقت مغادرة الشريحة. هذه الأشرطة هي إعدادات تخطيطية، ليست جدولًا زمنيًا مقاسًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

للحفاظ على وتيرة ثابتة، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)، ويمنح كل انتقال مدة 750 مللي ثانية. يُفعّل التقدم التلقائي بعد 5,000 مللي ثانية ويعطّل التقدم بنقرة الفأرة، ثم يحفظ النتيجة كملف PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // تكوين التقدم التلقائي بصورة مستقلة عن مدة التأثير.
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

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يحدد هذا المثال 500 مللي ثانية للشفرة الأولى و 1,200 مللي ثانية للشفرة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

### **تنسيق الانتقالات مع المخرجات المتحركة**

عند إعداد [animated GIF](/slides/ar/nodejs-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/nodejs-java/export-to-html5/)، أو [video](/slides/ar/nodejs-java/convert-powerpoint-to-video/)، اضبط مدد الانتقال الدقيقة قبل التصدير لتتناسب مع وتيرة التشغيل المقصودة. على سبيل المثال، استخدم انتقال Fade لمدة 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بالوقت للتعليق الصوتي أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل إطارات المخرجات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة ضمن صيغة التصدير المختارة، واعرض المخرجات مسبقًا للتأكد من التزامن.

### **قراءة مدة الانتقال الحالية**

استدعِ [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزّنة. القيمة `-1` تعني عدم تحديد مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزّنة بالملي ثانية. القيمة غير المضبوطة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد تلك المدة. قد تُنشئ تعيين نوع الانتقال مدةً مبدئية، لذا افحص الإعدادات الأصلية أولًا.

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

يقوم انتقال Morph بتحريك التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرّك أو غيّر حجم كائن على النسخة، ثم طبّق انتقال Morph على الشريحة الثانية. يمنح ذلك الكائنات المتطابقة انتقالًا بين حالتها الأصلية والمعدلة.

المثال التالي ينشئ شريحة بها مستطيل نصي، ينسخ الشريحة، ويغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) للشفرة الثانية. افتح الملف المحفوظ في عارض عرض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

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

تعداد [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) يحدّد كيفية مطابقة Morph وتحريك المحتوى:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) يتعامل مع كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) يُحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) يُحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) لتحديد Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue). ثم يُعطي القيمة كائن [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) حيث تُحدّد طريقة [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) وضع المطابقة.

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

## **ضبط تأثيرات الانتقال**

بعض الانتقالات تفضي إلى خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المختار عبر [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType). اضبط النوع أولًا، ثم استخدم كائن الانتقال المناسب من [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

المثال التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

نعم. يفضَّل استخدام [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالملي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) المحددة—Slow أو Medium أو Fast—كافية ولا تُحدد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا عبر [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound)، مرّر قيمة StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) بالـ `true`. يتكرر الصوت حتى حدث صوتي التالي في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

مرّر عبر مجموعة [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) في العرض، واستدعِ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل شريحة. اضبط أي إعدادات توقيت أو تأثير في نفس الحلقة للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال المحدد حاليًا على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) للشريحة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)؛ القيمة None تعني عدم تطبيق أي تأثير انتقال.
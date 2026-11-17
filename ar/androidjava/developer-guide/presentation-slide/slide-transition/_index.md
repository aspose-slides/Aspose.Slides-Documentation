---
title: إدارة انتقالات الشرائح في العروض التقديمية على Android
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وتأثيرات الانتقال الأخرى باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

تتحكم الانتقالات بين الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for Android عبر Java، يمكنك اختيار تأثير انتقال لكل شريحة، تكوين التقدم بالنقر بالفأرة أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة Java لتطبيق الانتقالات، تحديد مدد الانتقال بدقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تظهر الأمثلة أيضًا كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال الشريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) و الوصول إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). استخدم [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

التطبيق التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **انتقال العجلة**

طريقة [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) من [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة الهدف. اضبط نوع انتقال الشريحة إلى Wheel من [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) باستخدام [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) قبل الوصول إلى [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) كـ[IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/).

هذا المثال ينشئ زوجين متماثلين من الشرائح: شريحة سوداء تليها شريحة بها مستطيل ذهبي. تستخدم الشرائح الهدف عدد أسنان 1 و 8، مع نفس السرعة المحددة عبر [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) ومدة صريحة قدرها 8,000 مللي ثانية محددة عبر [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) لجعل الفرق سهل الملاحظة.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    int gold = Color.rgb(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

افتح العرض التقديمي الناتج في PowerPoint وشغّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، عدد الأسنان 1 يكشف الشريحة بسطرة واحدة دورانية؛ عدد الأسنان 8 يكشفها عبر ثماني قطاعات شعاعية في آن واحد. المحتوى والوقت للانتقال هما متطابقان، لذا الفرق هو عدد قطاعات الكشف.

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالفأرة يتقدم بعرض الشرائح. تتحكم الطرق التالية في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) تسمح للمشاهد بالتقدم بالنقر بالفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) تمكّن التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) تحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من التقدم بالنقر والوقت لتسمح للمشاهد بالانتقال بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، مرر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). يتحكم التأخير في وقت تقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعّل التقدم التلقائي بعد 3، 5، و 7 ثوانٍ على التوالي. يمكن للنقر بالفأرة أيضًا تقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

للتحقق مما إذا كان التقدم الزمني مُفعَّلًا، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). التخزين المتأخر وحده لا يدل على أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يبلغ عن كل مؤقت مفعَّل، ويعطّل التقدم التلقائي للشرائح التي لها تأخير أكبر من ثانيتين. يفعّل النقر بالفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في توقيت الانتقال بدقة**

استخدم [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تُظهر طريقة [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) في الشريحة هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/):

| طريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالمللي ثانية. مرر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | يختار فئة سرعة مسبقة التعريف من [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/): Slow، Medium، أو Fast. تُستَخدم عندما لا تُحدَّد مدة صريحة. |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) يتحكم فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدَّد مدة صريحة، يحدد Aspose.Slides مدة التأثير استنادًا إلى نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) .

<!-- visual-explanation:slide-transition:start -->
[![الأعمدة المنفصلة تحدد مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5,000 مللي ثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*المثال المشترك يمنح كل شريحة انتقال Fade بمدة 750 مللي ثانية ويفعّل التقدم التلقائي بشكل منفصل بعد 5,000 مللي ثانية. مدة الانتقال تتحكم في التأثير؛ التقدم يتحكم متى تُغادر الشريحة. هذه الأعمدة تمثّل إعدادات تخطيطية، ليست مخططًا زمنيًا مشتركًا مقاسًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

لتحقيق وتيرة ثابتة، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يفعّل التقدم التلقائي بعد 5,000 مللي ثانية ويعطل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // تكوين التقدم التلقائي بشكل مستقل عن مدة التأثير.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تحديد مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. هذا المثال يحدد 500 مللي ثانية للشريحة الأولى و 1,200 مللي ثانية للشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **التنسيق بين الانتقالات والإخراج المتحرك**

عند إعداد [GIF متحرك](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/)، [عرض HTML5](/slides/ar/androidjava/export-to-html5/)، أو [فيديو](/slides/ar/androidjava/convert-powerpoint-to-video/)، حدد مدد الانتقال الدقيقة قبل التصدير لمطابقة الوتيرة المطلوبة. على سبيل المثال، استخدم تلاشيًا بـ 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بوقت للتعليق الصوتي أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل الإطارات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقّق من تأثيرات وتوقيتات الصيغة المختارة، واعرض معاينة للنتيجة لتأكيد التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزونة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزنة بالمللي ثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) لتحديد تلك المدة. قد يهيئ تحديد نوع الانتقال مدةً، لذا افحص الإعدادات الأصلية أولًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **انتقال Morph**

ينشط انتقال Morph التغييرات بين الكائنات في الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرك أو غيّر حجم كائن على النسخة المستنسخة، ثم طبّق انتقال Morph على الشريحة الثانية. يمنح هذا الانتقال الكائنات المقابلة لتتحرك بين حالتها الأصلية والمعدلة.

التطبيق التالي ينشئ شريحة تحتوي على مستطيل نصي، يستنسخ الشريحة، ويغير موقع وحجم المستطيل على النسخة المستنسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) للشرائح الثانية. افتح الملف المحفوظ في عارض عرض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **أنواع انتقال Morph**

تحدد تعداد [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) كيفية مطابقة المحتوى وتحريكه:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات إن أمكن.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف إن أمكن.

استخدم [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--). توفر القيمة بعد ذلك واجهة [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/)، التي يختار وضع المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-).

هذا المثال يفتح العرض التقديمي الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام حركة Morph على أساس الكلمات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **تعيين تأثيرات الانتقال**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المحدد عبر [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). اضبط النوع أولاً، ثم استخدم الواجهة المناسبة عبر [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

التطبيق التالي يطبّق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) مسبقة التعريف—Slow، Medium، أو Fast—كافية ولا تُحدد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بصورة مستقلة عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. عيِّن صوتًا مدمجًا عبر [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-)، مرّر StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-)، وفعل [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) بالقيمة `true`. سيتكرر الصوت حتى حدث صوتي لاحق في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

عبر حلقة تمّر على مجموعة [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) بنفس القيمة لكل شريحة. اضبط أي توقيتات وخيارات تأثير داخل نفس الحلقة للحفاظ على سلوك موحَّد عبر جميع الشرائح.

**كيف يمكنني التحقق من نوع الانتقال الحالي المحدد على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) للشريحة. تُرجع القيمة من تعداد [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)؛ القيمة None تعني عدم تطبيق أي تأثير انتقال.
---
title: إدارة انتقالات الشرائح في العروض التقديمية على Android
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/androidjava/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال مورف
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقالات Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides للـ Android عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides للـ Android عبر Java، يمكنك اختيار تأثير انتقال لكل شريحة، وتكوين التقدم بالنقر على الفأرة أو المؤقت، وضبط الخيارات الخاصة بتأثير معين. يستخدم هذا المقال أمثلة Java لتطبيق الانتقالات، وتحديد مدد الانتقال الدقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات في ملف PPTX.

## **إضافة انتقال للشرائح**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) والوصول إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). استخدم [setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

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

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس يتقدم بالعرض. الطرق التالية تتحكم في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) يسمح للمشاهد بالتقدم عن طريق النقر بالفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) يحدّد التأخير قبل التقدم التلقائي، بالمليثانية.

فعّل كل من النقر والمؤقت لتسمح للمشاهد بالانتقال بالنقر أو الانتظار حتى يكتمل المؤقت. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). يتحكم التأخير في وقت تقدم عرض الشرائح؛ ولا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعّل التقدم التلقائي بعد 3، 5، و7 ثوانٍ على التوالي. يمكن للنقرات أيضًا التقدم بهذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم المؤقت مفعلًا، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). التخزين المتأخر لا يدل على أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يبلغ عن كل مؤقت مفعّل، ويعطل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يفعّل النقرات لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

## **التحكم بدقة في توقيت الانتقال**

استخدم [setDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) لتحديد الطول الدقيق لتأثير الانتقال بالمليثانية. طريقة [getSlideShowTransition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) للشفرة تعرض هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | يحدد مدة تأثير الانتقال نفسه، بالمليثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالمليثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) لتنشيط هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | يختار فئة سرعة مسبقة من تعداد [TransitionSpeed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitionspeed/): Slow، Medium، أو Fast. تُستخدم عندما لا يتم تحديد مدة دقيقة. |

[setDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) يتحكم فقط في تأثير الانتقال؛ ولا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا يتم تعيين مدة صريحة، تحدد Aspose.Slides مدة التأثير من نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) .

### **تطبيق نفس المدة على كل شريحة**

للحفاظ على إيقاع ثابت، طبق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 مليثانية. يفعّل التقدم التلقائي بعد 5,000 مليثانية ويعطل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // تهيئة التقدم التلقائي بشكل مستقل عن مدة التأثير.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يحدد هذا المثال 500 مليثانية للشريحة الأولى و1,200 مليثانية للشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

### **تنسيق الانتقالات مع المخرجات المتحركة**

عند إعداد [animated GIF](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/androidjava/export-to-html5/)، أو [video](/slides/ar/androidjava/convert-powerpoint-to-video/)، عيّن مدد انتقال دقيقة قبل التصدير لتناسب الإيقاع المقصود. على سبيل المثال، استخدم تلاشيًا مدته 600 مليثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بوقت للسرد أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل إطارات المخرجات مع مدة التأثير: 600 مليثانية تعادل 18 إطارًا بسرعة 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة للصيغة المختارة، وقم بمعاينة المخرجات لتأكيد التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني أنه لم تُحدّد مدة صريحة؛ والقيمة غير السالبة تحدد المدة المخزنة بالمليثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: تستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) لتحديد تلك المدة. قد يٍؤدي تعيين نوع الانتقال إلى تهيئة مدة، لذا فحص الإعدادات الأصلية أولاً.

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

ينشط انتقال Morph التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، انسخ شريحة، حرّك أو غير حجم كائن على النسخة، ثم طبّق انتقال Morph على الشريحة الثانية. يمنح هذا الانتقال الكائنات المقابلة لتُحرك بين حالتها الأصلية والمعدلة.

التطبيق التالي ينشئ شريحة تحتوي على مستطيل نص، ينسخ الشريحة، ويغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض يدعم Morph لتشاهد التأثير أثناء عرض الشرائح.

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

يحدد تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitionmorphtype/) كيف يطابق Morph ويُحرك المحتوى:

- [ByObject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#getValue--). ثم توفر القيمة واجهة [IMorphTransition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imorphtransition/)، التي يحدد منها الأسلوب [setMorphType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) وضع المطابقة.

يفتح هذا المثال العرض التقديمي الذي أنشئ في القسم السابق ويضبط الشريحة الثانية لاستخدام تأثير Morph القائم على الكلمات.

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

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المحدد عبر [setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). اضبط النوع أولاً، ثم استخدم الواجهة المناسبة من [getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

التطبيق التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioptionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [setDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) عندما تحتاج إلى مدة تأثير دقيقة بالمليثانية. استخدم [setSpeed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitionspeed/) محددة—Slow، Medium، أو Fast—كافية ولا يُحدّد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بصورة مستقلة عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا عبر [setSound](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-)، مرّر StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-)، وفعل [setSoundLoop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) بالقيمة `true`. سيُعاد تشغيل الصوت حتى يحدث حدث صوتي آخر في عرض الشرائح.

**ما أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بالمرور على مجموعة [getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) للعرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) بنفس القيمة لكل شريحة. اضبط أي توقيت أو خيارات تأثير داخل الحلقة نفسها للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال المُعيّن حاليًا على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideshowtransition/#getType--) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) الخاصة بالشريحة. تُرجع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/transitiontype/); القيمة None تعني عدم تطبيق أي تأثير انتقال.
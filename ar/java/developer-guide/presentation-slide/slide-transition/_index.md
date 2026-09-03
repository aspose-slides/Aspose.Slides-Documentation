---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Java
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/java/slide-transition/
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
- Java
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. مع Aspose.Slides for Java، يمكنك اختيار تأثير انتقال لكل شريحة، وتكوين التقدم بواسطة نقرة الفأرة أو المؤقت، وضبط الخيارات الخاصة بالتأثير. يستخدم هذا المقال أمثلة جافا لتطبيق الانتقالات، وتحديد مدد الانتقال بدقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتي عرض. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال الشريحة**

لتطبيق انتقال، احمّل عرضًا تقديميًا باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) وادخل إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). استخدم [setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setType-int-) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

التطبيق التالي يطبّق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

يمكنك تكوين المدة التي تظل فيها الشريحة على الشاشة وما إذا كانت نقرة الفأرة تُقدّم عرض الشرائح. تتحكم الطرق التالية في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) يسمح للمشاهد بالتقدم بنقرة الفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) يمكّن التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) يحدد التأخير قبل التقدم التلقائي، بالميلي ثانية.

فعّل كلًّا من التقدم بالنقرة والوقت لتسمح للمشاهد بالانتقال بنقرة أو الانتظار للمؤقت. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). يتحكم التأخير في وقت تقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويُمكّن التقدم التلقائي بعد 3، 5، و7 ثوانٍ على التوالي. يمكن أيضًا النقر لتقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم الزمني مفعَّلًا، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). التخزين للتأخير وحده لا يدل على أن المؤقت نشط.

يفتح المثال التالي الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعَّل، ويُعطل التقدم التلقائي للشرائح التي يزيد تأخيرها عن ثانيتين. يُفعّل نقر الفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

استخدم [setDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setDuration-int-) لتحديد الطول الدقيق لتأثير الانتقال بالميلي ثانية. تُظهر طريقة [getSlideShowTransition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) للشرائح هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | يحدد مدة تأثير الانتقال نفسه، بالميلي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالميلي ثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | يختار فئة سرعة مُعرَّفة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionspeed/): Slow أو Medium أو Fast. تُستَخدم عندما لا تُحدَّد مدة صريحة. |

يُتحكم [setDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setDuration-int-) فقط في تأثير الانتقال؛ لا يحدِّد مدة بقاء الشريحة مرئية. عيّن تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدَّد مدة صريحة، تُحَدِّد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#getSpeed--).

### **تطبيق نفس المدة على كل شريحة**

لتحقيق إيقاع ثابت، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. يحمّل هذا المثال `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 ميلي ثانية. يفعّل التقدم التلقائي بعد 5,000 ميلي ثانية ويعطِّل التقدم بنقر الفأرة، ثم يحفظ النتيجة كملف PPTX.

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

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة قسم. يحدّد هذا المثال 500 ميلي ثانية للشفريحة الأولى و1,200 ميلي ثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

### **تنسيق الانتقالات مع إخراج متحرك**

عند إعداد [GIF المتحرك](/slides/ar/java/convert-powerpoint-to-animated-gif/)، [عرض HTML5](/slides/ar/java/export-to-html5/)، أو [فيديو](/slides/ar/java/convert-powerpoint-to-video/)، اضبط مدد الانتقال بدقة قبل التصدير لتتناسب مع الإيقاع المطلوب. على سبيل المثال، استخدم تلاشيًا مدته 600 ميلي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بالوقت للسرد أو المحتوى.

للـ GIF والفيديو، نسّق معدل الإطارات مع مدة التأثير: 600 ميلي ثانية تعادل 18 إطارًا بسرعة 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقّق من التأثيرات وخيارات التوقيت المدعومة في صيغة التصدير المختارة، وعاين النتيجة للتأكد من التزامن.

### **قراءة مدة الانتقال الحالية**

استدعِ [getDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#getDuration--) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم ضبط مدة صريحة؛ القيمة غير السلبية تحدد المدة المخزنة بالميلي ثانية. القيمة غير المضبوطة ليست مدة التشغيل المحسوبة: تستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#getSpeed--) لتحديد تلك المدة. قد يُنشئ تعيين نوع الانتقال مدةً مبدئية، لذا راجع الإعدادات الأصلية أولاً.

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

يُحاكي انتقال Morph تغييرات الكائنات بين الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، انقل أو غيّر حجم كائن على النسخة المستنسخة، ثم طبّق انتقال Morph على الشريحة الثانية. يُعطي ذلك للانتقال الكائنات المقابلة لتتحرك بين حالتها الأصلية والمعدلة.

التطبيق التالي ينشئ شريحة تحتوي على مستطيل نص، يستنسخ الشريحة، ويغيّر موضع وحجم المستطيل في النسخة. يختار بعد ذلك Morph من تعداد [TransitionType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitiontype/) للشرحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لتلاحظ التأثير أثناء عرض الشرائح.

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

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionmorphtype/) في طريقة مطابقة وتحريك المحتوى بواسطة Morph:

- [ByObject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات حيثما كان ممكنًا.
- [ByChar](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف حيثما كان ممكنًا.

استخدم [setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setType-int-) لتحديد Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#getValue--). تُعيد القيمة واجهة [IMorphTransition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imorphtransition/)، وتحدّد طريقة [setMorphType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imorphtransition/#setMorphType-int-) وضع المطابقة.

يفتح هذا المثال العرض التقديمي الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام حركة Morph مبنية على الكلمات.

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

تُظهر بعض الانتقالات خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المختار عبر [setType]. عيّن النوع أولًا، ثم استخدم الواجهة الملائمة عبر [getValue].

التطبيق التالي يطبّق انتقال Cut على الشريحة الأولى من `input.pptx`. يطّلق [setFromBlack](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioptionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

نعم. يفضَّل استخدام [setDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setDuration-int-) عندما تحتاج إلى مدة تأثير دقيقة بالميلي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) عندما تكون فئة سرعة مُعرَّفة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionspeed/) (Slow أو Medium أو Fast) كافية ولا توجد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال مستقلاً عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرار؟**

نعم. عيّن صوتًا مدمجًا باستخدام [setSound](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-)، مرّر `StartSound` من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-)، وفعل [setSoundLoop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) بالقيمة `true`. سيتكرار الصوت حتى يحدث حدث صوتي آخر في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

مرّر على مجموعة [getSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlides--) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#setType-int-) بنفس القيمة لكل شريحة. عيّن أي خيارات توقيت أو تأثير داخل نفس الحلقة للحفاظ على سلوك موحَّد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال المحدد حاليًا على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideshowtransition/#getType--) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) للشريحة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitiontype/); القيمة `None` تعني عدم تطبيق أي تأثير انتقال.
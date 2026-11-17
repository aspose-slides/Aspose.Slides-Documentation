---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Java
linktitle: انتقال الشرائح
type: docs
weight: 80
url: /ar/java/slide-transition/
keywords:
- انتقال الشرائح
- إضافة انتقال الشرائح
- تطبيق انتقال الشرائح
- انتقال شرائح متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، وتكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في كيفية ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for Java، يمكنك اختيار تأثير الانتقال لكل شريحة، تكوين التقدم بواسطة نقرة الفأرة أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. تستخدم هذه المقالة أمثلة جافا لتطبيق الانتقالات، ضبط مدد الانتقال الدقيقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. كما تُظهر الأمثلة كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال للشرائح**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الصنف [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) واطّلع على إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). استخدم [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) ثم احفظ العرض التقديمي.

المثال التالي يطبق انتقال دائرة على الشريحة الأولى وانتقال مشط على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

تتحكم طريقة [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) في الصنف [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) في عدد القطاعات الشعاعية التي تكشف الشريحة الوجهة. اضبط نوع انتقال الشريحة إلى Wheel من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) باستخدام [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) قبل الوصول إلى [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) كـ [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

هذا المثال ينشئ زوجين متماثلين من الشرائح: شريحة سوداء يتبعها شريحة بها مستطيل ذهبي. تستخدم الشرائح الوجهة عدد أسنان 1 و 8، مع نفس السرعة المحددة عبر [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) ومدة صريحة مقدارها 8,000 مللي ثانية محددة عبر [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) لتسهيل ملاحظة الفرق.

```java
import java.awt.Color;
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
    Color gold = new Color(255, 215, 0);
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

افتح عرض الشرائح الناتج في PowerPoint وشغّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، يُظهر عدد الأسنان 1 الشريحة بماسة واحدة مع اتجاه عقربي؛ ويظهر عدد الأسنان 8 الشريحة عبر ثمانية قطاعات شعاعية في وقت واحد. محتوى الشريحة والوقت الانتقالي متطابقان، لذا الفرق هو عدد قطاعات الكشف.

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كانت نقرة الفأرة تُقدم عرض الشرائح. تتحكم الطرق التالية بهذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) يسمح للمستخدم بالتقدم بالنقر على الفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) يتيح التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من التقدم بالنقر والوقت لتسمح للمستخدم بالانتقال بالنقر أو الانتظار حتى المؤقت. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). يتحكم الت_delay في وقت تقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

يعين هذا المثال تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3، 5، و7 ثوانٍ على التوالي. يمكن أيضًا النقر بالفأرة لتقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم الزمني مفعلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). التخزين المتأخر بوحده لا يدل على أن المؤقت نشط.

يفتح المثال التالي الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعّل، ويعطّل التقدم التلقائي للشرائح التي لديها تأخير أكثر من ثانيتين. يفعّل نقرة الفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

استخدم [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تُظهر طريقة [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) للشرائح هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | يحدد التأخير قبل أن تتقدم الشريحة تلقائيًا، بالمللي ثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | يختار فئة سرعة مسبقة التعريف من تعداد [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow، Medium أو Fast. يُستخدم عندما لا يتم تحديد مدة صريحة. |

يتحكم [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) .

<!-- visual-explanation:slide-transition:start -->
[![الأشرطة المنفصلة تحدد مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5,000 مللي ثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*يعطي المثال المشترك لكل شريحة انتقال تلاشي (Fade) مدته 750 مللي ثانية ويفعّل التقدم التلقائي بعد 5,000 مللي ثانية. تتحكم مدة الانتقال في التأثير؛ ويتحكم التقدم في متى يُغادر الشريحة. هذه الأشرطة هي إعدادات تخطيطية، ليست مخططًا زمنيًا مقاسًا مُدمجًا.*  
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

لتحقيق وتيرة متسقة، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. يقوم هذا المثال بتحميل `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يفعّل التقدم التلقائي بعد 5,000 مللي ثانية ويعطّل التقدم بالنقر، ثم يحفظ النتيجة كـ PPTX.

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

### **تعيين مدد مختلفة لكل شريحة على حدة**

يمكن للشرائح المختلفة استخدام مدد انتقال مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لتقديم القسم. يحدد هذا المثال 500 مللي ثانية للشريحة الأولى و1,200 مللي ثانية للشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند إعداد [GIF متحرك](/slides/ar/java/convert-powerpoint-to-animated-gif/)، [عرض HTML5](/slides/ar/java/export-to-html5/)، أو [فيديو](/slides/ar/java/convert-powerpoint-to-video/)، اضبط مدد الانتقال الدقيقة قبل التصدير لتتناسب مع الوتيرة المطلوبة. على سبيل المثال، استخدم تلاشيًا مدته 600 مللي ثانية بين المشاهد، واضبط تأخير التقدم لكل شريحة بشكل منفصل للسماح بالوقت للسرد أو المحتوى الخاص بها. بالنسبة لـ GIF والفيديو، نسّق معدل الإطارات الناتج مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة من صيغة التصدير المختارة، واعرض المعاينة للتأكد من التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزّنة. القيمة `-1` تعني عدم تحديد مدة صريحة؛ والقيمة غير السالبة تشير إلى المدة المخزّنة بالمللي ثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) لتحديد تلك المدة. قد يخلق ضبط نوع الانتقال مدة مبدئية، لذا افحص الإعدادات الأصلية أولًا.

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

يقوم انتقال Morph بإنشاء الرسوم المتحركة للتغييرات بين الكائنات في الشرائح المتتالية. لإنشاء تأثير Morph بسيط، انسخ شريحة، حرّك أو غير حجم كائن على النسخة، واستخدم انتقال Morph على الشريحة الثانية. يمنح ذلك للانتقال الكائنات المقابلة ليتم تحريكها بين حالتهم الأصلية والمعدلة.

ينشئ المثال التالي شريحة تحتوي على مستطيل نصي، ينسخ الشريحة، ويغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عرض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

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

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) في طريقة مطابقة وتحريك المحتوى في Morph:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) لتحديد Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). تُعطي القيمة بعد ذلك واجهة [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) التي تختار وضع المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-).

يفتح هذا المثال العرض التقديمي الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام حركة Morph معتمدة على الكلمات.

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

بعض الانتقالات تُظهر خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المختار عبر [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). اضبط النوع أولاً، ثم استخدم الواجهة المناسبة من [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

يطبق المثال التالي انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) لتبدأ الانتقال من شاشة سوداء.

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

نعم. يُفضّل استخدام [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) (بطيء، متوسط أو سريع) كافية ولا تُحدد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مدمجًا عبر [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-)، مرّر StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-)، وفعل [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) بـ `true`. سيستمر الصوت في التكرار حتى الحدث الصوتي التالي في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بالتكرار عبر مجموعة [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) بنفس القيمة لكل انتقال شريحة. اضبط أي توقيتات وخيارات تأثير في نفس الحلقة للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المحدد على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) الخاصة بالشريحة. تُرجع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); وتعني None عدم تطبيق أي تأثير انتقال.
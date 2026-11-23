---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Java
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/java/slide-transition/
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
- Java
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for Java، يمكنك اختيار تأثير انتقال لكل شريحة، وتكوين التقدم عن طريق نقرة الفأرة أو المؤقت، وضبط الخيارات الخاصة بتأثير معين. يستخدم هذا المقال أمثلة Java لتطبيق الانتقالات، وتحديد مدّات انتقال دقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات في ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، حمّل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) و-access إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). استخدم [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) ثم احفظ العرض التقديمي.

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

## **انتقال Wheel**

طريقة [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) في [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة الوجهة. اضبط نوع انتقال الشريحة إلى Wheel من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) باستخدام [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) قبل الوصول إلى [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) كـ [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

هذا المثال ينشئ زوجين متطابقين من الشرائح: شريحة سوداء تليها شريحة ذات مستطيل ذهبي. تستخدم الشرائح الوجهة عدد أسلاك 1 و 8، مع ضبط السرعة نفسها عبر [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) ومدّ مدة صريحة 8,000 مللي ثانية عبر [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) لتسهيل ملاحظة الفرق.

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

افتح العرض الناتج في PowerPoint وشغّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، يُظهر عدد الأسلاك 1 الشريحة بتمرير واحد في اتجاه عقلي؛ يُظهر عدد الأسلاك 8 الشريحة عبر ثماني قطاعات شعاعية في آن واحد. المحتوى الوجهة وتوقيت الانتقال متماثلان، لذا الفرق هو في عدد قطاعات الكشف.

## **Fade Through Black مع انتقال Reveal**

اضبط نوع انتقال الشريحة الوجهة إلى Reveal، ثم استدعِ [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) على إعدادات [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/). يُنشئ المثال شريحة مصدر باللون الفيروزي وشريحة وجهة باللون المرجاني، ثم يستنسخهما. كل زوج يستخدم انتقال Reveal مدته ثانيتان. يُطبق الزوج الثاني Fade عبر اللون الأسود فقط.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

افتح العرض المحفوظ في PowerPoint وابدأ عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2 لتلاحظ الفيروزي يتلاشى مباشرةً إلى المرجاني. ثم انتقل من الشريحة 3 إلى الشريحة 4. تُظلم الشاشة مؤقتًا إلى شبه الأسود قبل ظهور شريحة المرجاني. تحتفظ كل شريحة بألوان الخلفية الأصلية.

الصفوف أدناه تُظهر إطارات من PowerPoint بفواصل نصف ثانية. قارن الإطار الأوسط في كل صف لرؤية التأثير.

![تشغيل PowerPoint مع إلغاء تفعيل التلاشي عبر الأسود (أعلى) وتفعيلها (أسفل). يمر الصف السفلي فقط عبر شبه الأسود.](reveal-through-black.png)

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كانت نقرة الفأرة تُقدم عرض الشرائح. الطرق التالية تتحكم في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) يسمح للمشاهد بالتقدم بالنقر على الفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) يُمكّن التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كلاً من التقدم بالنقرة والوقت لتمكين المشاهد من المتابعة بنقرة أو الانتظار للعداد. لاستخدام المؤقت فقط، مرّر `false` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). يتحكم التأخير متى يتقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

هذا المثال يُعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعّل التقدم التلقائي بعد 3، 5، و7 ثوانٍ على التوالي. يمكن للنقرات أيضًا تقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم الزمني مفعّلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). وجود تأخير مخزن لا يعني أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعّل، ويُعطّل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يُفعّل النقرات لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

## **التحكم الدقيق في توقيت الانتقال**

استخدم [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تُظهر طريقة [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) في الشريحة هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | يحدّد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | يحدّد التأخير قبل أن تتقدّم الشريحة تلقائيًا، بالمللي ثانية. مرّر `true` إلى [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | يختار فئة سرعة مسبقة التعريف من تعداد [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow أو Medium أو Fast. يُستخدم عندما لا تُحدّد مدة صريحة. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) يتحكم فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدّد مدة صريحة، تقوم Aspose.Slides بحساب مدة التأثير من نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) .

<!-- visual-explanation:slide-transition:start -->
[![الأشرطة المنفصلة تحدد مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5,000 مللي ثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*المثال المشترك يُعطي كل شريحة انتقال Fade مدته 750 مللي ثانية ويُفعل التقدم التلقائي بعد 5,000 مللي ثانية. مدة الانتقال تتحكم في التأثير؛ التقدم يتحكم متى نغادر الشريحة. هذه الأشرطة تمثّل إعدادات تخطيطية، ليست مخططًا زمنيًا مقاسًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

لضمان وتيرة ثابتة، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يُفعل التقدم التلقائي بعد 5,000 مللي ثانية ويعطل التقدم بالنقرة، ثم يحفظ النتيجة كملف PPTX.

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

### **ضبط مدّات مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدّات تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. هذا المثال يحدد 500 مللي ثانية للشفرة الأولى و1,200 مللي ثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند إعداد [animated GIF](/slides/ar/java/convert-powerpoint-to-animated-gif/)، أو [HTML5 presentation](/slides/ar/java/export-to-html5/)، أو [video](/slides/ar/java/convert-powerpoint-to-video/)، اضبط مدّات الانتقال بدقة قبل التصدير لتتناسب مع الوتيرة المطلوبة. على سبيل المثال، استخدم تلاشي 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بوقت للسرد أو المحتوى.

بالنسبة لـ GIF والفيديو، نسّق معدل الإطارات مع مدة التأثير: 600 مللي ثانية تُعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من تأثيرات وتوقيت الخيارات المدعومة في صيغة التصدير المختارة، ومعاينة المخرج للتأكد من التزامن.

### **قراءة مدة الانتقال الموجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تُحدّد المدة المخزنة بالمللي ثانية. القيمة غير المُحددة ليست مدة التشغيل المحسوبة: تستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) لتحديد تلك المدة. قد يضيف ضبط نوع الانتقال مدة، لذا افحص الإعدادات الأصلية أولاً.

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

يقوم انتقال Morph بتحريك التغييرات بين الكائنات في الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرّك أو غيّر حجم كائن على النسخة، ثم طبّق انتقال Morph على الشريحة الثانية. يمنح هذا الانتقال الكائنات المقابلة للتحرك بين حالتها الأصلية والمعدلة.

التطبيق التالي ينشئ شريحة تحتوي على مستطيل نصي، ينسخ الشريحة، ويُغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) للشفرة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

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

تُحدّد تعداد [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) طريقة مطابقة وتحريك المحتوى في Morph:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). تُرجِع القيمة بعد ذلك واجهة [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) التي تُحدّد طريقة المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-).

هذا المثال يفتح العرض المُنشأ في القسم السابق ويُكوّن الشريحة الثانية لاستخدام تحريك Morph على أساس الكلمات.

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

## **ضبط تأثيرات الانتقال**

تُظهر بعض الانتقالات خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المُختار عبر [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). اضبط النوع أولاً، ثم استخدم الواجهة المناسبة عبر [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

التطبيق التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) من خلال [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

نعم. يُفضَّل استخدام [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) عندما تكون فئة سرعة مسبقة التعريف من تعداد [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) – Slow أو Medium أو Fast – كافية ولا تُحدّد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمنًا عبر [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-)، مرّر قيمة StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-)، وفعل [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) بـ `true`. سيُعيد الصوت تشغيل نفسه حتى يحدث حدث صوتي لاحق في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

تكرّر عبر مجموعة [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) في العرض، واستدعِ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) بنفس القيمة لكل شريحة. ضع أي إعدادات توقيت وتأثير في نفس الحلقة للحفاظ على سلوك موحد عبر جميع الشرائح.

**كيف يمكنني التحقق من أي انتقال تم تعيينه حاليًا على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) للشفرة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); قيمة None تعني عدم تطبيق أي تأثير انتقال.
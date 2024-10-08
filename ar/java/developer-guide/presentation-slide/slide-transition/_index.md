---
title: انتقال الشرائح
type: docs
weight: 80
url: /ar/java/slide-transition/
keywords: "انتقال شريحة باوربوينت، انتقال تلاشي في جافا"
description: "انتقال شريحة باوربوينت، انتقال تلاشي في جافا"
---


## **نظرة عامة**
{{% alert color="primary" %}} 

تسمح Aspose.Slides لجافا للمطورين أيضاً بإدارة أو تخصيص تأثيرات انتقال الشرائح. في هذا الموضوع، سنناقش كيفية التحكم في انتقال الشرائح بسهولة كبيرة باستخدام Aspose.Slides لجافا.

{{% /alert %}} 

لتسهيل الفهم، قمنا بعرض استخدام Aspose.Slides لجافا لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين تطبيق تأثيرات انتقال مختلفة على الشرائح، ولكن يمكنهم أيضاً تخصيص سلوك هذه التأثيرات الانتقالية.

## **إضافة انتقال شريحة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. تطبيق نوع انتقال على الشريحة من أحد تأثيرات الانتقال المقدمة بواسطة Aspose.Slides لجافا من خلال TransitionType enum.
1. كتابة ملف العرض المعدل.

```java
// Instantiate Presentation class to load the source presentation file
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Apply circle type transition on slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Apply comb type transition on slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Write the presentation to disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة انتقال شريحة متقدم**
في القسم أعلاه، طبقنا فقط تأثير انتقال بسيط على الشريحة. الآن، لجعل ذلك التأثير الانتقالي البسيط أفضل وأكثر تحكماً، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. تطبيق نوع انتقال على الشريحة من أحد تأثيرات الانتقال المقدمة بواسطة Aspose.Slides لجافا.
1. يمكنك أيضاً تعيين الانتقال للتقدم عند النقرة، بعد فترة زمنية محددة، أو كليهما.
1. إذا كان انتقال الشريحة مفعلًا للتقدم عند النقرة، فسيتقدم الانتقال فقط عندما ينقر شخص ما على الماوس. علاوة على ذلك، إذا تم تعيين خاصية "التقدم بعد مرور الوقت"، سيتقدم الانتقال تلقائيًا بعد تجاوز الوقت المحدد.
1. كتابة العرض المعدل كملف عرض.

```java
// Instantiate Presentation class that represents a presentation file
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Apply circle type transition on slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Set the transition time of 3 seconds
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Apply comb type transition on slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Set the transition time of 5 seconds
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Apply zoom type transition on slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Set the transition time of 7 seconds
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Write the presentation to disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **انتقال التلاشي**
{{% alert color="primary" %}} 

تدعم Aspose.Slides لجافا الآن [انتقال التلاشي](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition). وهي تمثل انتقال التلاشي الجديد الذي تم تقديمه في باوربوينت 2019.

{{% /alert %}} 

يسمح انتقال التلاشي لك بتحريك سلس من شريحة إلى أخرى. تصف هذه المقالة مفهوم وكيفية استخدام انتقال التلاشي. لاستخدام انتقال التلاشي بشكل فعال، ستحتاج إلى وجود شريحتين مع كائن واحد على الأقل مشترك. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن على الشريحة الثانية إلى مكان مختلف.

يظهر لك المقتطف البرمجي التالي كيفية إضافة نسخة مكررة من الشريحة مع بعض النص إلى العرض وتعيين انتقال من نوع [التلاشي](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) إلى الشريحة الثانية.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("انتقال التلاشي في عروض باوربوينت");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **أنواع انتقال التلاشي**
تمت إضافة [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) enum جديدة. وتمثل أنواع مختلفة من انتقال الشرائح التلاشي.

تحتوي TransitionMorphType enum على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال التلاشي مع الأخذ في الاعتبار الأشكال ككائنات غير قابلة للتجزئة.
- ByWord: سيتم تنفيذ انتقال التلاشي مع نقل النص عبر الكلمات حيثما كان ذلك ممكنًا.
- ByChar: سيتم تنفيذ انتقال التلاشي مع نقل النص عبر الأحرف حيثما كان ذلك ممكنًا.

يظهر لك المقتطف البرمجي التالي كيفية ضبط انتقال التلاشي على الشريحة وتغيير نوع التلاشي:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تأثيرات الانتقال**
تدعم Aspose.Slides لجافا تعيين تأثيرات الانتقال مثل، من الأسود، من اليسار، من اليمين، إلخ. من أجل تعيين تأثير الانتقال، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- الحصول على مرجع للشريحة.
- تعيين تأثير الانتقال.
- كتابة العرض كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/).

في المثال المُعطى أدناه، قمنا بتعيين تأثيرات الانتقال.

```java
// Create an instance of Presentation class
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Set effect
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Write the presentation to disk
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
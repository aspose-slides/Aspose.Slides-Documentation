---
title: انتقال الشرائح
type: docs
weight: 80
url: /ar/androidjava/slide-transition/
keywords: "انتقال شرائح باور بوينت، انتقال تحول في جافا"
description: "انتقال شرائح باور بوينت، انتقال تحول باور بوينت في جافا"
---


## **نظرة عامة**
{{% alert color="primary" %}} 

تسمح Aspose.Slides لنظام Android عبر Java أيضًا للمطورين بإدارة أو تخصيص تأثيرات انتقال الشرائح. في هذا الموضوع، سنناقش كيفية التحكم في انتقال الشرائح بسهولة كبيرة باستخدام Aspose.Slides لنظام Android عبر Java.

{{% /alert %}} 

لتسهيل الفهم، قمنا بعرض استخدام Aspose.Slides لنظام Android عبر Java لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين تطبيق تأثيرات انتقال شرائح مختلفة على الشرائح، بالإضافة إلى تخصيص سلوك هذه التأثيرات الانتقالية.

## **إضافة انتقال شريحة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات أدناه:

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. طبق نوع انتقال الشريحة على الشريحة من أحد التأثيرات الانتقالية التي تقدمها Aspose.Slides لنظام Android عبر Java من خلال انتقال النوع TransitionType
1. اكتب ملف العرض التقديمي المعدل.

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
في القسم أعلاه، قمنا بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل تأثير الانتقال البسيط هذا أفضل وأكثر تحكمًا، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. طبق نوع انتقال الشريحة على الشريحة من أحد التأثيرات الانتقالية التي تقدمها Aspose.Slides لنظام Android عبر Java
1. يمكنك أيضًا تعيين الانتقال لتقدم عند النقر، بعد فترة زمنية محددة أو كلاهما.
1. إذا تم تمكين انتقال الشريحة للتقدم عند النقر، سيتقدم الانتقال فقط عندما ينقر شخص ما على الفأرة. علاوة على ذلك، إذا تم تعيين خاصية التقدم بعد الوقت، سيتقدم الانتقال تلقائيًا بعد انقضاء الوقت المحدد للتقدم.
1. اكتب العرض التقديمي المعدل كملف عرض تقديمي.

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

## **الانتقال التحويلي**
{{% alert color="primary" %}} 

تدعم Aspose.Slides لنظام Android عبر Java الآن [Morph Transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). تمثل انتقال التحول الجديد الذي تم تقديمه في PowerPoint 2019.

{{% /alert %}} 

يسمح الانتقال التحويلي لك بتحريك سلس من شريحة إلى أخرى. يصف هذا المقال مفهوم وكيفية استخدام الانتقال التحويلي. لاستخدام الانتقال التحويلي بشكل فعال، ستحتاج إلى وجود شريحتين مع وجود عنصر واحد على الأقل مشترك بينهما. أسهل طريقة هي تكرار الشريحة ثم نقل العنصر في الشريحة الثانية إلى مكان مختلف.

تظهر الشفرة البرمجية التالية كيفية إضافة نسخة من الشريحة مع بعض النص إلى العرض التقديمي وتعيين انتقال من نوع [متحول](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) إلى الشريحة الثانية.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("الانتقال التحويلي في عروض باور بوينت");

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

## **أنواع الانتقال التحويلي**
تم إضافة الجديد [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) enum. يمثل أنواعًا مختلفة من انتقالات الشريحة التحويلية.

يحتوي enum TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ الانتقال التحويلي مع اعتبار الأشكال ككائنات غير قابلة للتجزئة.
- ByWord: سيتم تنفيذ الانتقال التحويلي مع نقل النص بالكلمات حيثما أمكن.
- ByChar: سيتم تنفيذ الانتقال التحويلي مع نقل النص بالحروف حيثما أمكن.

تظهر الشفرة البرمجية التالية كيفية تعيين انتقال تحويلي للشريحة وتغيير نوع التحول:

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
تدعم Aspose.Slides لنظام Android عبر Java تعيين تأثيرات الانتقال مثل، من الأسود، من اليسار، من اليمين، إلخ. من أجل تعيين تأثير الانتقال. يرجى اتباع الخطوات أدناه:

- أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
- احصل على مرجع للشريحة.
- تعيين تأثير الانتقال.
- اكتب العرض التقديمي كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/) .

في المثال المعطى أدناه، قمنا بتعيين تأثيرات الانتقال.

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
---
title: انتقال الشريحة
type: docs
weight: 80
url: /php-java/slide-transition/
keywords: "انتقال شريحة PowerPoint، انتقال مورف"
description: "انتقال شريحة PowerPoint، انتقال مورف PowerPoint"
---

## **نظرة عامة**
{{% alert color="primary" %}} 

يتيح Aspose.Slides لـ PHP عبر Java للمطورين إدارة أو تخصيص تأثيرات انتقال الشريحة. في هذا الموضوع، سنناقش كيفية التحكم في انتقال الشرائح بسهولة كبيرة باستخدام Aspose.Slides لـ PHP عبر Java.

{{% /alert %}} 

لتسهيل الفهم، قمنا بعرض استخدام Aspose.Slides لـ PHP عبر Java لإدارة انتقالات الشريحة البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال مختلفة على الشرائح، ولكن أيضًا تخصيص سلوك هذه التأثيرات الانتقالية.

## **إضافة انتقال الشريحة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات أدناه:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. قم بتطبيق نوع انتقال الشريحة على الشريحة من أحد التأثيرات الانتقالية التي تقدمها Aspose.Slides لـ PHP عبر Java من خلال TransitionType enum
1. اكتب ملف العرض المعدل.

```php
  # Instantiate Presentation class to load the source presentation file
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Apply circle type transition on slide 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Apply comb type transition on slide 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Write the presentation to disk
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **إضافة انتقال شريحة متقدم**
في القسم أعلاه، قمنا فقط بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل ذلك التأثير الانتقالي البسيط أفضل وأكثر تحكمًا، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. قم بتطبيق نوع انتقال الشريحة على الشريحة من أحد التأثيرات الانتقالية التي تقدمها Aspose.Slides لـ PHP عبر Java
1. يمكنك أيضًا ضبط الانتقال ليكون متقدمًا عند النقر، بعد فترة زمنية محددة أو كلاهما.
1. إذا تم تمكين انتقال الشريحة ليكون متقدمًا عند النقر، فسيتقدم الانتقال فقط عندما يقوم شخص ما بالنقر على الماوس. علاوة على ذلك، إذا تم تعيين خاصية التقدم بعد الوقت، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
1. اكتب العرض المعدل كملف عرض تقديمي.

```php
  # Instantiate Presentation class that represents a presentation file
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Apply circle type transition on slide 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Set the transition time of 3 seconds
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Apply comb type transition on slide 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Set the transition time of 5 seconds
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Apply zoom type transition on slide 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Set the transition time of 7 seconds
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Write the presentation to disk
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **انتقال مورف**
{{% alert color="primary" %}} 

يدعم Aspose.Slides لـ PHP عبر Java الآن [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). تمثل انتقالات مورف الجديدة التي تم تقديمها في PowerPoint 2019.

{{% /alert %}} 

يسمح انتقال المورف لك بتحريك سلس من شريحة إلى أخرى. يصف هذا المقال المفهوم وكيفية استخدام انتقال المورف. لاستخدام انتقال المورف بفعالية، ستحتاج إلى وجود شريحتين بهما على الأقل عنصر واحد مشترك. الطريقة الأسهل هي تكرار الشريحة ثم تحريك العنصر في الشريحة الثانية إلى مكان مختلف.

يظهر مقتطف الكود التالي كيفية إضافة نسخة من الشريحة مع بعض النصوص إلى العرض وضبط انتقال [نوع المورف](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) إلى الشريحة الثانية.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("انتقال مورف في عروض PowerPoint التقديمية");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **أنواع انتقال المورف**
تمت إضافة Enum جديدة باسم [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType). تمثل أنواعًا مختلفة من انتقال شرائح المورف.

يتضمن Enum TransitionMorphType ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال المورف بمراعاة الأشكال ككائنات غير قابلة للتجزئة.
- ByWord: سيتم تنفيذ انتقال المورف بنقل النصوص بواسطة الكلمات عندما يكون ذلك ممكنًا.
- ByChar: سيتم تنفيذ انتقال المورف بنقل النصوص بواسطة الأحرف عندما يكون ذلك ممكنًا.

يظهر مقتطف الكود التالي كيفية ضبط انتقال المورف إلى الشريحة وتغيير نوع المورف:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **ضبط تأثيرات الانتقال**
يدعم Aspose.Slides لـ PHP عبر Java ضبط تأثيرات الانتقال مثل الانتقال من الأسود، من اليسار، من اليمين، إلخ. من أجل ضبط تأثير الانتقال. يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- احصل على مرجع الشريحة.
- ضبط تأثير الانتقال.
- اكتب العرض كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/) .

في المثال المقدم أدناه، قمنا بضبط تأثيرات الانتقال.

```php
  # Create an instance of Presentation class
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Set effect
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Write the presentation to disk
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```
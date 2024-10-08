---
title: تخطيط الشريحة
type: docs
weight: 60
url: /ar/php-java/slide-layout/
keyword: "تعيين حجم الشريحة، تعيين خيارات الشريحة، تحديد حجم الشريحة، رؤية التذييل، تذييل فرعي، قياس المحتوى، حجم الصفحة، Java، Aspose.Slides"
description: "تعيين حجم الشريحة وخياراته في PowerPoint"
---

يحتوي تخطيط الشريحة على صناديق العناصر النائبة ومعلومات التنسيق لجميع المحتويات التي تظهر على الشريحة. يحدد التخطيط مواقع العناصر النائبة المتاحة وأماكن وضعها.

تسمح تخطيطات الشرائح بإنشاء وتصميم العروض التقديمية بسرعة (سواء كانت بسيطة أو معقدة). إليك بعض من أكثر تخطيطات الشرائح شيوعًا المستخدمة في عروض PowerPoint التقديمية:

* **تخطيط شريحة العنوان**. يتكون هذا التخطيط من عنصرين نائبين للنص. واحد مخصص للعنوان والآخر للعنوان الفرعي.
* **تخطيط العنوان والمحتوى**. يحتوي هذا التخطيط على عنصر نائب صغير نسبيًا في الأعلى للعناوين وعنصر نائب أكبر للمحتوى الأساسي (مخطط، فقرات، قائمة نقطية، قائمة مرقمة، صور، إلخ).
* **تخطيط فارغ**. يفتقر هذا التخطيط إلى العناصر النائبة، مما يتيح لك إنشاء العناصر من الصفر.

نظرًا لأن الشريحة الرئيسية هي الشريحة العليا الهرمية التي تخزن معلومات حول تخطيطات الشرائح، يمكنك استخدام الشريحة الرئيسية للوصول إلى تخطيطات الشرائح وإجراء تغييرات عليها. يمكن الوصول إلى شريحة التخطيط بواسطة النوع أو الاسم. وبالمثل، تحتوي كل شريحة على معرّف فريد يمكن استخدامه للوصول إليها.

بدلاً من ذلك، يمكنك إجراء تغييرات مباشرة على تخطيط شريحة محددة في عرض تقديمي.

* لتتمكن من العمل مع تخطيطات الشرائح (بما في ذلك تلك الموجودة في الشرائح الرئيسية)، تقدم Aspose.Slides خصائص مثل [getLayoutSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides--) و[getMasters()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) تحت فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
* لأداء المهام ذات الصلة، توفر Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)، [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/)، [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/baseslideheaderfootermanager/)، والعديد من الأنواع الأخرى.

{{% alert title="معلومات" color="info" %}}

للحصول على مزيد من المعلومات حول العمل مع الشرائح الرئيسية بشكل خاص، اقرأ المقالة [Slide Master](https://docs.aspose.com/slides/php-java/slide-master/).

{{% /alert %}}

## **إضافة تخطيط شريحة إلى العرض التقديمي**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الوصول إلى مجموعة [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/).
1. تصفح تخطيطات الشرائح الموجودة لتأكيد أن تخطيط الشريحة المطلوب موجود بالفعل في مجموعة تخطيطات الشرائح. خلاف ذلك، أضف الشريحة التخطيطية التي تريدها.
1. أضف شريحة فارغة بناءً على تخطيط الشريحة الجديد.
1. احفظ العرض التقديمي.

يعرض كود PHP هذا كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:

```php
  # أنشئ مثيلًا من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation("AccessSlides.pptx");
  try {
    # تصفح أنواع تخطيطات الشرائح
    $layoutSlides = $pres->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }
    if (java_is_null($layoutSlide)) {
      # الوضع الذي لا يحتوي فيه العرض التقديمي على بعض أنواع التخطيطات.
      # ملف العرض يحتوي على أنواع تخطيطات فارغة ومخصصة فقط.
      # ولكن تخطيطات الشرائح من الأنواع المخصصة لها أسماء شرائح مختلفة،
      # مثل "عنوان" و"عنوان ومحتوى"، إلخ. ومن الممكن استخدام هذه
      # الأسماء لاختيار تخطيط الشريحة.
      # يمكنك أيضًا استخدام مجموعة من أنواع أشكال العناصر النائبة. على سبيل المثال،
      # يجب أن يحتوي تخطيط الشريحة العنوان فقط على عنصر نائب من نوع عنوان، إلخ.
      foreach($layoutSlides as $titleAndObjectLayoutSlide) {
        if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
          $layoutSlide = $titleAndObjectLayoutSlide;
          break;
        }
      }
      if (java_is_null($layoutSlide)) {
        foreach($layoutSlides as $titleLayoutSlide) {
          if (java_values($titleLayoutSlide->getName()) == "Title") {
            $layoutSlide = $titleLayoutSlide;
            break;
          }
        }
        if (java_is_null($layoutSlide)) {
          $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
          if (java_is_null($layoutSlide)) {
            $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
          }
        }
      }
    }
    # إضافة شريحة فارغة مع التخطيط المضاف
    $pres->getSlides()->insertEmptySlide(0, $layoutSlide);
    # حفظ العرض التقديمي على القرص
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **إزالة تخطيط الشريحة غير المستخدم**

توفر Aspose.Slides طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) من فئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) للسماح لك بحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة. يعرض كود PHP هذا كيفية إزالة تخطيط شريحة من عرض PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحديد الحجم والنوع لتخطيط الشريحة**

للسماح لك بتعيين الحجم والنوع لتخطيط شريحة معينة، توفر Aspose.Slides خصائص [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) و[getSize()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize--) (من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)). يوضح هذا الكود كيفية العملية:

```php
  # أنشئ مثيلًا من كائن Presentation الذي يمثل ملف العرض
  $presentation = new Presentation("demo.pptx");
  try {
    $auxPresentation = new Presentation();
    try {
      # تعيين حجم الشريحة للعرض الناتج ليتناسب مع المصدر
      $auxPresentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);
      # getType());
      $auxPresentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);
      # استنساخ الشريحة المطلوبة
      $auxPresentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
      $auxPresentation->getSlides()->removeAt(0);
      # حفظ العرض التقديمي على القرص
      $auxPresentation->save("size.pptx", SaveFormat::Pptx);
    } finally {
      $auxPresentation->dispose();
    }
  } finally {
    $presentation->dispose();
  }
```

## **تعيين رؤية التذييل داخل الشريحة**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. احصل على مرجع الشريحة من خلال فهرسها.
1. تعيين عنصر نائب تذييل الشريحة ليكون مرئيًا.
1. تعيين عنصر نائب التاريخ والوقت ليكون مرئيًا.
1. حفظ العرض التقديمي.

يعرض كود PHP هذا كيفية ضبط الرؤية لتذييل الشريحة (وأداء المهام ذات الصلة):

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getSlides()->get_Item(0)->getHeaderFooterManager();
    # يتم استخدام الأسلوب isFooterVisible لتحديد أن عنصر نائب تذييل الشريحة مفقود
    if (!$headerFooterManager->isFooterVisible()) {
      $headerFooterManager->setFooterVisibility(true);// يتم استخدام الأسلوب setFooterVisibility لتعيين عنصر نائب تذييل الشريحة ليكون مرئيًا

    }
    # يتم استخدام الأسلوب isSlideNumberVisible لتحديد أن عنصر نائب رقم الشريحة مفقود
    if (!$headerFooterManager->isSlideNumberVisible()) {
      $headerFooterManager->setSlideNumberVisibility(true);// يتم استخدام الأسلوب setSlideNumberVisibility لتعيين عنصر نائب رقم الشريحة ليكون مرئيًا

    }
    # يتم استخدام الأسلوب isDateTimeVisible لتحديد أن عنصر نائب التاريخ والوقت مفقود
    if (!$headerFooterManager->isDateTimeVisible()) {
      $headerFooterManager->setDateTimeVisibility(true);// يتم استخدام الأسلوب SetFooterVisibility لتعيين عنصر نائب موعد الشريحة ليكون مرئيًا

    }
    $headerFooterManager->setFooterText("نص التذييل");// يتم استخدام الأسلوب SetFooterText لتعيين نص لعنصر نائب تذييل الشريحة.

    $headerFooterManager->setDateTimeText("نص التاريخ والوقت");// يتم استخدام الأسلوب SetDateTimeText لتعيين نص لعنصر نائب موعد الشريحة.

  } finally {
    $presentation->dispose();
  }
```

## **تعيين رؤية التذييل الفرعي داخل الشريحة**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. احصل على مرجع للشريحة الرئيسية من خلال فهرسها.
1. تعيين الشريحة الرئيسية وجميع عناصر نائب التذييل الفرعي لتكون مرئية.
1. تعيين نص للشريحة الرئيسية وجميع عناصر نائب التذييل الفرعي.
1. تعيين نص للشريحة الرئيسية وجميع عناصر نائب التاريخ والوقت الفرعي.
1. حفظ العرض التقديمي.

يعرض كود PHP هذا العملية:

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);// يتم استخدام الأسلوب setFooterAndChildFootersVisibility لتعيين الشريحة الرئيسية وجميع عناصر نائب التذييل الفرعي لتكون مرئية

    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// يتم استخدام الأسلوب setSlideNumberAndChildSlideNumbersVisibility لتعيين الشريحة الرئيسية وجميع عناصر نائب رقم الصفحة الفرعي لتكون مرئية

    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// يتم استخدام الأسلوب setDateTimeAndChildDateTimesVisibility لتعيين الشريحة الرئيسية وجميع عناصر نائب التاريخ والوقت الفرعي لتكون مرئية

    $headerFooterManager->setFooterAndChildFootersText("نص التذييل");// يتم استخدام الأسلوب setFooterAndChildFootersText لتعيين النصوص للشريحة الرئيسية وجميع عناصر نائب التذييل الفرعي

    $headerFooterManager->setDateTimeAndChildDateTimesText("نص التاريخ والوقت");// يتم استخدام الأسلوب setDateTimeAndChildDateTimesText لتعيين النص لعناصر نائب التاريخ والوقت الفرعي للشريحة الرئيسية

  } finally {
    $presentation->dispose();
  }
```

## **تعيين حجم الشريحة بالنسبة إلى قياس المحتوى**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) واملأ العرض الذي يحتوي على الشريحة التي تريد تعيين حجمها.
1. أنشئ مثيلًا آخر من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) لإنشاء عرض تقديمي جديد.
1. احصل على مرجع الشريحة (من العرض الأول) عبر فهرسها.
1. تعيين عنصر نائب تذييل الشريحة ليكون مرئيًا.
1. تعيين عنصر نائب التاريخ والوقت ليكون مرئيًا.
1. حفظ العرض التقديمي.

يعرض كود PHP هذا العملية:

```php
  # أنشئ مثيلًا من كائن Presentation الذي يمثل ملف عرض تقديمي
  $presentation = new Presentation("demo.pptx");
  try {
    # تعيين حجم الشريحة للعروض الناتجة ليتناسب مع المصدر
    $presentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);// يتم استخدام الأسلوب SetSize لتعيين حجم الشريحة مع قياس المحتوى لضمان التناسب

    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);// يتم استخدام الأسلوب SetSize لتعيين حجم الشريحة مع الحجم الأقصى للمحتوى

    # حفظ العرض التقديمي على القرص
    $presentation->save("Set_Size&Type_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **تعيين حجم الصفحة عند إنشاء PDF**

غالبًا ما يتم تحويل بعض العروض التقديمية (مثل الملصقات) إلى مستندات PDF. إذا كنت ترغب في تحويل PowerPoint الخاص بك إلى PDF للوصول إلى أفضل خيارات الطباعة والوصول، فأنت تريد ضبط شرائحك على أحجام تناسب مستندات PDF (A4، على سبيل المثال).

توفر Aspose.Slides فئة [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/) للسماح لك بتحديد إعداداتك المفضلة للشرائح. يعرض كود PHP هذا كيفية استخدام خاصية [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) (من فئة `SlideSize`) لتعيين حجم ورقة معين للشرائح في عرض تقديمي:

```php
  # أنشئ مثيلًا من كائن Presentation الذي يمثل ملف عرض تقديمي
  $presentation = new Presentation();
  try {
    # تعيين الخاصية SlideSize.Type
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);
    # تعيين خصائص مختلفة لخيارات PDF
    $opts = new PdfOptions();
    $opts->setSufficientResolution(600);
    # حفظ العرض التقديمي على القرص
    $presentation->save("SetPDFPageSize_out.pdf", SaveFormat::Pdf, $opts);
  } finally {
    $presentation->dispose();
  }
```
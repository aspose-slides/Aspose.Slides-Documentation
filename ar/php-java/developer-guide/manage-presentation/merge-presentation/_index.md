---
title: دمج العرض التقديمي
type: docs
weight: 40
url: /php-java/merge-presentation/
keywords: "دمج PowerPoint, PPTX, PPT, دمج PowerPoint, دمج العروض التقديمية, دمج العروض, Java"
description: "دمج أو جمع عرض تقديمي PowerPoint"
---


{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في التحقق من **تطبيق Aspose المجاني عبر الإنترنت** [Merger app](https://products.aspose.app/slides/merger). يسمح للناس بدمج العروض التقديمية بتنسيق مماثل (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض في تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عندما تقوم بدمج عرض تقديمي مع آخر، فأنت فعليًا تجمع شرائحهم في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

تفتقر معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) إلى وظائف تسمح للمستخدمين بدمج العروض التقديمية بهذه الطريقة. 

ومع ذلك، يسمح لك [**Aspose.Slides لـ PHP عبر Java**](https://products.aspose.com/slides/php-java/) بدمج العروض بطرق مختلفة. يمكنك دمج العروض التقديمية بكل أشكالها، أنماطها، نصوصها، تنسيقاتها، تعليقاتها، حركاتها، إلخ، دون الحاجة للقلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[استنساخ الشرائح](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **ما الذي يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض التقديمية بالكامل. تنتقل جميع الشرائح من العروض التقديمية إلى عرض تقديمي واحد
* شرائح محددة. تنتهي الشرائح المحددة في عرض تقديمي واحد
* العروض التقديمية بتنسيق واحد (PPT إلى PPT، PPTX إلى PPTX، إلخ) وفي تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

{{% alert title="ملاحظة" color="warning" %}} 

بخلاف العروض التقديمية، يسمح لك Aspose.Slides بدمج ملفات أخرى:

* [صيغ](https://products.aspose.com/slides/php-java/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* مستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* وملفات مختلفة مثل [صورة إلى PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كانت 

* كل شريحة في العرض التقديمي الناتج تحتفظ بأسلوب فريد
* يتم استخدام أسلوب محدد لجميع الشرائح في العرض التقديمي الناتج. 

لدمج العروض التقديمية، يوفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)). هناك عدة تطبيقات لطرق `AddClone` التي تحدد معلمات عملية دمج العرض التقديمي. كل كائن عرض تقديمي لديه مجموعة [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `AddClone` من العرض التقديمي الذي تريد دمج الشرائح فيه.

ترجع طريقة `AddClone` كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض التقديمي الناتج هي ببساطة نسخة من الشرائح من المصدر. لذلك، يمكنك إجراء تغييرات على الشرائح الناتجة (على سبيل المثال، تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق بشأن تأثر العروض التقديمية المصدر. 

## **دمج العروض التقديمية** 

يوفر Aspose.Slides طريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تتيح لك دمج الشرائح بينما تحتفظ الشرائح بتخطيطات وعناصر تصميمها (معلمات افتراضية).

يظهر لك هذا الرمز PHP كيفية دمج العروض التقديمية:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **دمج العروض التقديمية مع شريحة الماستر**

يوفر Aspose.Slides طريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تتيح لك دمج الشرائح مع تطبيق قالب عرض تقديمي لشريحة الماستر. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير الأسلوب للشرائح في العرض التقديمي الناتج.

يوضح هذا الرمز العملية الموصوفة:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="ملاحظة" color="warning" %}} 

يتم تحديد تخطيط الشريحة لشريحة الماستر تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم تعيين المعامل البولي `allowCloneMissingLayout` لطريقة `AddClone` على true، يتم استخدام التخطيط لشرائح المصدر. خلاف ذلك، سيتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

إذا كنت ترغب في أن تحتوي الشرائح في العرض التقديمي الناتج على تخطيط شريحة مختلف، استخدم طريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض التقديمية**

يظهر لك هذا الرمز PHP كيفية اختيار ودمج شرائح محددة من عروض تقديمية مختلفة للحصول على عرض تقديمي واحد:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **دمج العروض التقديمية مع تخطيط الشريحة**

يظهر لك هذا الرمز PHP كيفية دمج الشرائح من العروض التقديمية مع تطبيق التخطيط المفضل لديك عليها للحصول على عرض تقديمي واحد:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **دمج العروض التقديمية مع أحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}} 

لا يمكنك دمج العروض التقديمية مع أحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين تقديميين مع أحجام شرائح مختلفة، تحتاج إلى تغيير حجم أحد العروض ليتناسب حجمه مع الآخر. 

يوضح هذا الرمز العينة العملية الموضحة:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **دمج الشرائح إلى قسم في العرض التقديمي**

يظهر لك هذا الرمز PHP كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

تمت إضافة الشريحة في نهاية القسم. 

{{% alert title="نصيحة" color="primary" %}}

تقدم Aspose تطبيق [ويب مجاني لتحرير الصور](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}
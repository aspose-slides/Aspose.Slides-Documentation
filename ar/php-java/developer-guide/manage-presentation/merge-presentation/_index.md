---
title: دمج العروض التقديمية بفعالية في PHP
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/php-java/merge-presentation/
keywords:
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- تجميع PowerPoint
- تجميع العروض التقديمية
- تجميع الشرائح
- تجميع PPT
- تجميع PPTX
- تجميع ODP
- PHP
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) بسهولة باستخدام Aspose.Slides for PHP عبر Java، ما يُسهل سير عملك."
---

## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، فإنك تقوم فعليًا بدمج الشرائح في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="Info" color="info" %}}

معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تسمح للمستخدمين بدمج العروض بهذه الطريقة. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), ومع ذلك، يتيح لك دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، إلخ، دون القلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[نسخ الشرائح](/slides/ar/php-java/clone-slides/).

{{% /alert %}}

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض الكاملة. جميع الشرائح من العروض تنتهي في عرض واحد
* الشرائح المحددة. الشرائح المختارة تنتهي في عرض واحد
* العروض بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) إلى بعضها البعض. 

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى العروض، يتيح لك Aspose.Slides دمج ملفات أخرى:

* [الصور](https://products.aspose.com/slides/php-java/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* وأيضًا ملفات مختلفة مثل [صورة إلى PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* كل شريحة في العرض الناتج تحتفظ بنمط فريد
* نمط محدد يُستخدم لجميع الشرائح في العرض الناتج. 

لدمج العروض، توفر Aspose.Slides طرق [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) (من فئة [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)). هناك عدة تنفيذات لطرق `addClone` التي تحدد معلمات عملية دمج العروض. كل كائن Presentation يحتوي على مجموعة [slide](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/)، لذلك يمكنك استدعاء طريقة `addClone` من العرض الذي تريد دمج الشرائح إليه.

طريقة `addClone` تُعيد كائن `Slide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض الناتج هي ببساطة نسخة من الشرائح الأصلية. وبالتالي، يمكنك تعديل الشرائح الناتجة (مثل تطبيق الأنماط أو خيارات التنسيق أو التخطيطات) دون القلق من أن تتأثر العروض المصدر.

## **دمج العروض**

توفر Aspose.Slides طريقة [addClone(Slide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) التي تتيح لك دمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (معلمات افتراضية).

يوضح هذا الكود PHP كيفية دمج العروض:
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


## **دمج العروض مع ماستر شريحة**

توفر Aspose.Slides طريقة [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) التي تتيح لك دمج الشرائح مع تطبيق قالب ماستر شريحة للعرض. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير نمط الشرائح في العرض الناتج.

يوضح هذا الكود العملية الموصوفة:
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


{{% alert title="Note" color="warning" %}} 

يتم تحديد تخطيط الشريحة للماستر تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم ضبط المعامل المنطقي `allowCloneMissingLayout` في طريقة `addClone` على true، يُستخدم تخطيط الشريحة المصدر. وإلا، سيتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

إذا أردت أن تكون للشرائح في العرض الناتج تخطيط شريحة مختلف، استخدم طريقة [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض**

يُعد دمج شرائح محددة من عروض متعددة مفيدًا لإنشاء مجموعات شرائح مخصصة. يتيح لك Aspose.Slides for PHP via Java اختيار واستيراد الشرائح التي تحتاجها فقط. يحافظ API على التنسيق والتخطيط وتصميم الشرائح الأصلية.

يقوم الكود PHP التالي بإنشاء عرض تقديمي جديد، وإضافة شرائح عنوان من عرضين آخرين، وحفظ النتيجة في ملف:
```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```

```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```


## **دمج العروض مع تخطيط شريحة**

يوضح هذا الكود PHP كيفية دمج الشرائح من العروض مع تطبيق تخطيط الشريحة المفضل لديك للحصول على عرض نهائي واحد:
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


## **دمج العروض بأحجام شرائح مختلفة**

{{% alert title="Note" color="warning" %}} 

لا يمكنك دمج عروض بأحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، يجب تغيير حجم أحد العروض لجعل حجمه يطابق حجم العرض الآخر. 

يوضح هذا المثال الكود العملية الموصوفة:
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


## **دمج شرائح إلى قسم في العرض**

يوضح هذا الكود PHP كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:
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


تُضاف الشريحة في نهاية القسم. 

## **انظر أيضًا**

توفر Aspose أداة [صانع الكولاج المجانية على الإنترنت](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور JPG إلى JPG أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، والمزيد.

اطلع على [Aspose FREE Online Merger](https://products.aspose.app/slides/merger). يتيح لك دمج عروض PowerPoint بنفس الصيغة (مثل PPT إلى PPT، PPTX إلى PPTX) أو عبر صيغ مختلفة (مثل PPT إلى PPTX، PPTX إلى ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **الأسئلة الشائعة**

**هل هناك أي قيود على عدد الشرائح عند دمج العروض؟**

لا توجد قيود صارمة. يمكن لـ Aspose.Slides معالجة ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. بالنسبة للعروض الكبيرة جدًا، يُنصح باستخدام JVM 64 بت وتخصيص ذاكرة heap كافية.

**هل يمكنني دمج عروض تحتوي على فيديو أو صوت مدمج؟**

نعم، يحافظ Aspose.Slides على المحتوى المتعدد الوسائط المدمج في الشرائح، لكن قد يصبح العرض النهائي أكبر حجمًا بشكل ملحوظ.

**هل سيتم الحفاظ على الخطوط عند دمج العروض؟**

نعم. يتم الحفاظ على الخطوط المستخدمة في العروض المصدر في الملف الناتج، بشرط أن تكون مثبتة على النظام أو [مضمنة](/slides/ar/php-java/embedded-font/).
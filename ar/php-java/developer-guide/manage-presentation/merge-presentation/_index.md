---
title: دمج العروض التقديمية بكفاءة في PHP
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
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- PHP
- Aspose.Slides
description: "ادمج بسهولة عروض PowerPoint (PPT، PPTX) وعروض OpenDocument (ODP) باستخدام Aspose.Slides للـ PHP عبر Java، مما يُبسّط سير العمل الخاص بك."
---

## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، فإنك في الواقع تجمع شرائحه في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="Info" color="info" %}}

معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تتيح للمستخدمين دمج العروض التقديمية بهذه الطريقة. 

[**Aspose.Slides للـ PHP عبر Java**](https://products.aspose.com/slides/php-java/), however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data.

**انظر أيضًا**

[استنساخ الشرائح](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 
* العروض التقديمية بالكامل. جميع الشرائح من العروض التقديمية تنتهي في عرض تقديمي واحد
* شرائح محددة. الشرائح المختارة تنتهي في عرض تقديمي واحد
* العروض التقديمية بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وفي صيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى العروض التقديمية، يسمح لك Aspose.Slides بدمج ملفات أخرى:
* [الصور](https://products.aspose.com/slides/php-java/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* وأيضًا ملفين مختلفين مثل [الصورة إلى PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان
* كل شريحة في العرض التقديمي الناتج تحتفظ بنمط فريد
* نمط محدد يُستخدم لجميع الشرائح في العرض التقديمي الناتج. 

لدمج العروض التقديمية، توفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) ). هناك عدة تنفيذات لطرق `AddClone` التي تحدد معايير عملية دمج العروض التقديمية. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `AddClone` من العرض التقديمي الذي تريد دمج الشرائح إليه.

طريقة `AddClone` تُعيد كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض التقديمي الناتج هي ببساطة نسخة من الشرائح الأصلية. لذلك، يمكنك إجراء تغييرات على الشرائح الناتجة (على سبيل المثال، تطبيق الأنماط أو خيارات التنسيق أو التخطيطات) دون القلق من التأثير على العروض التقديمية المصدر.

## **دمج العروض التقديمية** 

توفر Aspose.Slides الطريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تتيح لك دمج الشرائح مع بقاء تخطيطاتها وأنماطها (معلمات افتراضية).

يظهر لك هذا الكود PHP كيفية دمج العروض التقديمية:
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


## **دمج العروض التقديمية باستخدام قالب رئيسي للشرائح** 

توفر Aspose.Slides الطريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تتيح لك دمج الشرائح مع تطبيق قالب رئيسي للشرائح. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض التقديمي الناتج.

يظهر هذا الكود العملية الموصوفة:
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

يتم تحديد تخطيط الشريحة للقالب الرئيسي للشرائح تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم ضبط معامل `allowCloneMissingLayout` البولياني في طريقة `AddClone` على true، يُستخدم تخطيط الشريحة المصدر. وإلا، سيتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

إذا كنت تريد أن تكون للشرائح في العرض التقديمي الناتج تخطيط شريحة مختلف، استخدم الطريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض التقديمية** 

دمج شرائح محددة من عدة عروض تقديمية مفيد لإنشاء مجموعات شرائح مخصصة. يسمح لك Aspose.Slides للـ PHP عبر Java باختيار واستيراد الشرائح التي تحتاجها فقط. يحافظ API على التنسيق والتخطيط وتصميم الشرائح الأصلية.

الكود PHP التالي ينشئ عرضًا تقديميًا جديدًا، يضيف شرائح العنوان من عرضين تقديميين آخرين، ويحفظ النتيجة إلى ملف:
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


## **دمج العروض التقديمية باستخدام تخطيط شريحة** 

يعرض لك هذا الكود PHP كيفية دمج الشرائح من العروض التقديمية مع تطبيق تخطيط الشريحة المفضل لديك للحصول على عرض تقديمي ناتج واحد:
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


## **دمج العروض التقديمية بأحجام شرائح مختلفة** 

{{% alert title="Note" color="warning" %}} 

لا يمكنك دمج العروض التقديمية ذات أحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين تقديميين بأحجام شرائح مختلفة، يجب تعديل حجم أحد العروض ليطابق حجم العرض الآخر.

يظهر هذا الكود العيني العملية الموصوفة:
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


## **دمج شرائح إلى قسم في العرض التقديمي** 

يعرض لك هذا الكود PHP كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:
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


يتم إضافة الشريحة في نهاية القسم. 

## **انظر أيضًا**


توفر Aspose [صانع كولاج مجاني عبر الإنترنت](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وأكثر.

تفضل بزيارة [أسبوز مجاني دمج عبر الإنترنت](https://products.aspose.app/slides/merger). يتيح لك دمج عروض PowerPoint بنفس الصيغة (مثل PPT إلى PPT، PPTX إلى PPTX) أو عبر صيغ مختلفة (مثل PPT إلى PPTX، PPTX إلى ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **الأسئلة الشائعة** 

**هل هناك أي حدود لعدد الشرائح عند دمج العروض التقديمية؟**

لا توجد حدود صارمة. يمكن لـ Aspose.Slides التعامل مع ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. للعروض التقديمية الكبيرة جدًا، يُنصح باستخدام JVM 64‑بت وتخصيص ذاكرة كومة كافية.

**هل يمكنني دمج عروض تقديمية تحتوي على فيديو أو صوت مدمج؟**

نعم، يحافظ Aspose.Slides على المحتوى الوسائط المتعددة المدمج في الشرائح، لكن قد يصبح العرض التقديمي النهائي أكبر حجمًا بشكل ملحوظ.

**هل سيتم الحفاظ على الخطوط عند دمج العروض التقديمية؟**

نعم. الخطوط المستخدمة في العروض التقديمية المصدرية تُحافظ عليها في الملف الناتج، بشرط أن تكون مثبتة على النظام أو [مضمنة](/slides/ar/php-java/embedded-font/).
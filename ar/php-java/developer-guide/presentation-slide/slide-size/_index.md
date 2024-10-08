---
title: حجم الشريحة
type: docs
weight: 70
url: /ar/php-java/slide-size/

---

## أحجام الشرائح في عروض PowerPoint

يتيح لك Aspose.Slides لـ PHP عبر Java تغيير حجم الشريحة أو نسبة العرض إلى الارتفاع في عروض PowerPoint. إذا كنت تخطط لطباعة عرضك التقديمي أو عرض شرائحه على شاشة، يجب أن تولي اهتمامًا لحجم الشريحة أو نسبة العرض إلى الارتفاع.

هذه هي أحجام الشرائح ونسب العرض إلى الارتفاع الأكثر شيوعًا:

- **العرض القياسي (نسبة عرض 4:3)**

  إذا كان من المقرر عرض أو مشاهدة عرضك التقديمي على أجهزة أو شاشات قديمة نسبيًا، قد ترغب في استخدام هذا الإعداد.

- **الشاشة العريضة (نسبة عرض 16:9)** 

  إذا كان من المقرر مشاهدة عرضك التقديمي على أجهزة عرض أو شاشات حديثة، قد ترغب في استخدام هذا الإعداد.

لا يمكنك استخدام إعدادات حجم الشرائح المتعددة في عرض تقديمي واحد. عند اختيار حجم شريحة لعرض تقديمي، يتم تطبيق هذا الإعداد على جميع الشرائح في العرض.

إذا كنت تفضل استخدام حجم شريحة خاص لعروضك التقديمية، نوصي بشدة بأن تفعل ذلك مبكرًا. من المثالي أن تحدد حجم شريحتك المفضل في البداية، أي عندما تقوم بإعداد العرض، قبل إضافة أي محتوى إلى العرض. بهذه الطريقة، يمكنك تجنب التعقيدات الناتجة عن التغييرات (المستقبلية) التي تطرأ على أحجام الشرائح.

{{% alert color="primary" %}} 

 عند استخدامك لـ Aspose.Slides لإنشاء عرض تقديمي، يتم تلقائيًا ضبط جميع الشرائح في العرض على الحجم القياسي أو نسبة عرض 4:3.

{{% /alert %}} 

## تغيير حجم الشريحة في العروض التقديمية 

 يعرض لك هذا الكود النموذجي كيفية تغيير حجم الشريحة في عرض تقديمي باستخدام Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## تحديد أحجام شرائح مخصصة في العروض التقديمية

إذا كنت تجد أن الأحجام الشائعة للشرائح (4:3 و 16:9) غير مناسبة لعملك، يمكنك أن تقرر استخدام حجم شريحة محدد أو فريد. على سبيل المثال، إذا كنت تخطط لطباعة شرائح بالحجم الكامل من عرضك التقديمي على تنسيق صفحة مخصص أو إذا كنت تعتزم عرض عرضك التقديمي على أنواع معينة من الشاشات، فمن المحتمل أن تستفيد من استخدام إعداد حجم مخصص لعرضك التقديمي.

هذا الكود النموذجي يظهر لك كيفية استخدام Aspose.Slides لـ PHP عبر Java لتحديد حجم شريحة مخصص لعرض تقديمي:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// حجم ورق A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## التعامل مع المشكلات عند تغيير حجم الشرائح في العروض التقديمية

بعد تغيير حجم الشريحة لعرض تقديمي، قد تصبح محتويات الشرائح (كالصور أو الكائنات، على سبيل المثال) مشوهة. بشكل افتراضي، يتم إعادة ضبط حجم الكائنات تلقائيًا لتتناسب مع حجم الشريحة الجديد. ومع ذلك، عند تغيير حجم شريحة عرض تقديمي، يمكنك تحديد إعداد يحدد كيف يتعامل Aspose.Slides مع المحتويات الموجودة على الشرائح.

اعتمادًا على ما تنوي القيام به أو تحقيقه، يمكنك استخدام أي من هذه الإعدادات:

- `DoNotScale`

  إذا كنت لا تريد تغيير حجم الكائنات على الشرائح، استخدم هذا الإعداد.

- `EnsureFit`

  إذا كنت ترغب في تغيير الحجم إلى حجم شريحة أصغر وتحتاج إلى أن يقوم Aspose.Slides بتقليل حجم كائنات الشرائح لضمان تناسبها جميعًا على الشرائح (بهذه الطريقة، تتجنب فقدان المحتوى)، استخدم هذا الإعداد.

- `Maximize`

  إذا كنت ترغب في تغيير الحجم إلى حجم شريحة أكبر وتحتاج إلى أن يقوم Aspose.Slides بتكبير كائنات الشرائح لجعلها متناسبة مع حجم الشريحة الجديد، استخدم هذا الإعداد.

هذا الكود النموذجي يظهر لك كيفية استخدام إعداد `Maximize` عند تغيير حجم شريحة عرض تقديمي:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
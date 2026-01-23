---
title: تصدير العروض التقديمية إلى XAML في PHP
linktitle: عرض تقديمي إلى XAML
type: docs
weight: 30
url: /ar/php-java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- PHP
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML باستخدام Aspose.Slides للـ PHP عبر Java — حل سريع بلا Office يحافظ على تنسيقك الأصلي."
---

## **تصدير العروض التقديمية إلى XAML**

تدعم Aspose.Slides تصدير XAML. يمكنك تحويل عروضك التقديمية إلى XAML.

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، وخاصة تلك التي تستخدم WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform)، و Xamarin Forms.

XAML، التي هي لغة قائمة على XML، هي نسخة مايكروسوفت لتوصيف واجهة المستخدم الرسومية. من المرجح أن تستخدم المصمم للعمل على ملفات XAML في معظم الأوقات، لكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الخاصة بك.

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يعرض لك هذا الكود PHP كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار خيارات من الفئة [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) التي تتحكم في عملية التصدير وتحدد كيف يقوم Aspose.Slides بتصدير عرضك التقديمي إلى XAML.

على سبيل المثال، إذا كنت تريد أن يقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك استخدام الطريقة [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) بالقيمة `true`. راجع هذا مثال كود PHP:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يكن الخط الأصل متاحًا على الجهاز؟**

حدد [خطًا قياسيًا افتراضيًا](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي غير موجود. يساعد ذلك على تجنب الاستبدالات غير المتوقعة.

**هل الـ XAML المصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في تراكيب XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة المستخدم العامة المستخدمة في WPF، UWP، و Xamarin.Forms. تستهدف عملية التصدير التوافق مع تراكيب XAML من مايكروسوفت؛ السلوك الدقيق ودعم البنى المحددة يعتمد على المنصة المستهدفة. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

بشكل افتراضي، لا يتم تضمين الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — احتفظ به معطلاً إذا لم تكن بحاجة إلى تصديرها.
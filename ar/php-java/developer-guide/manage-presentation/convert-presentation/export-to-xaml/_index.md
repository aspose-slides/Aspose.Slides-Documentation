---
title: تصدير العروض التقديمية إلى XAML في PHP
linktitle: العرض التقديمي إلى XAML
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
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML باستخدام Aspose.Slides لـ PHP عبر Java — حل سريع وخالي من Office يحافظ على تنسيقك سليمًا."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/)، قمنا بإضافة دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML.

{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، وخاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، وهي لغة تعتمد على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم المصمم للعمل على ملفات XAML معظم الوقت، لكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الرسومية الخاصة بك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الإعدادات الافتراضية**

هذا الكود PHP يوضح لك كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
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

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) التي تتحكم في عملية التصدير وتحدد كيف تقوم Aspose.Slides بتصدير عرضك التقديمي إلى XAML.

على سبيل المثال، إذا كنت تريد أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك ضبط الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) إلى true. راجع هذا عينة كود PHP:
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

**كيف يمكنني ضمان خطوط متوقعة إذا لم يكن الخط الأصلي متوفرًا على الجهاز؟**

قم بتعيين [خط افتراضي عادي](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — يُستخدم كخط احتياطي عندما يكون الخط الأصلي مفقودًا. هذا يساعد على تجنب الاستبدالات غير المتوقعة.

**هل XAML المُصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة المستخدم العامة المستخدمة في WPF وUWP وXamarin.Forms. تستهدف عملية التصدير التوافق مع أطر Microsoft XAML؛ السلوك الدقيق والدعم للبنود المحددة يعتمد على منصة الهدف. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — أبقِها معطلة إذا لم تحتاج إلى تصديرها.
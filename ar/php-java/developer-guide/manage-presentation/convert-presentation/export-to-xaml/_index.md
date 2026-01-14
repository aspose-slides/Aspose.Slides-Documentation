---
title: تصدير العروض التقديمية إلى XAML في PHP
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/php-java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- عرض تقديمي إلى XAML
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
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML باستخدام Aspose.Slides للـ PHP عبر Java — حل سريع خالٍ من Office يحافظ على تخطيطك دون تغيير."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 
في Aspose.Slides 21.6، قمنا بتنفيذ دعم تصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML.
{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تسمح لك بإنشاء أو كتابة واجهات المستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform)، ونماذج Xamarin.  

XAML، وهي لغة تعتمد على XML، هي النسخة الخاصة بمايكروسفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم المصمم للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الخاصة بك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يظهر لك هذا الكود PHP كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
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


## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات المخصصة**

يمكنك اختيار الخيارات من فئة [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعرضك التقديمي إلى XAML.

على سبيل المثال، إذا كنت تريد أن يضيف Aspose.Slides الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك استخدام طريقة [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) بالقيمة `true`. راجع هذا مثال الكود PHP التالي:
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

**كيف يمكنني ضمان خطوط متوقعة إذا لم يتوفر الخط الأصلي على الجهاز؟**

قم بتعيين [خط عادي افتراضي](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — يُستخدم كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك في تجنّب الاستبدالات غير المتوقعة.

**هل يُقصد من XAML المصدّر أن يستخدم فقط لـ WPF، أم يمكن استخدامه في أكوام XAML الأخرى أيضًا؟**

XAML هي لغة توصيف عامة لواجهة المستخدم تُستخدم في WPF وUWP وXamarin.Forms. تستهدف عملية التصدير التوافق مع أكوام XAML الخاصة بمايكروسفت؛ السلوك الدقيق والدعم للبنَى المحددة يعتمد على منصة الهدف. اختبر العلامات في بيئتك.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

بشكل افتراضي، لا يتم تضمين الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — احفظه معطلًا إذا لم تكن بحاجة لتصديرها.
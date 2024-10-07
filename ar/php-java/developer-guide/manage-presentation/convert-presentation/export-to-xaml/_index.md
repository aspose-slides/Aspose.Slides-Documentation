---
title: تصدير إلى XAML
type: docs
weight: 30
url: /php-java/export-to-xaml/

---

# تصدير العروض التقديمية إلى XAML

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML.

{{% /alert %}} 

# عن XAML

XAML هو لغة برمجة وصفية تسمح لك ببناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) و UWP (Universal Windows Platform) و Xamarin forms.  

XAML، وهي لغة تعتمد على XML، هي إصدار مايكروسوفت لوصف واجهة المستخدم الرسومية (GUI). من المحتمل أنك ستستخدم مصممًا للعمل على ملفات XAML معظم الوقت، ولكن يمكنك أيضًا كتابة وتحرير واجهة المستخدم الخاصة بك. 

## تصدير العروض التقديمية إلى XAML مع الإعدادات الافتراضية

يظهر لك هذا الشيفرة PHP كيفية تصدير عرض تقديمي إلى XAML مع الإعدادات الافتراضية:

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

## تصدير العروض التقديمية إلى XAML مع خيارات مخصصة

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعرضك التقديمي إلى XAML.

على سبيل المثال، إذا كنت ترغب في أن تضيف Aspose.Slides شرائح مخفية من العرض التقديمي الخاص بك عند تصديره إلى XAML، يمكنك تعيين خاصية [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) إلى true. انظر إلى هذا الشيفرة PHP كمثال:

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
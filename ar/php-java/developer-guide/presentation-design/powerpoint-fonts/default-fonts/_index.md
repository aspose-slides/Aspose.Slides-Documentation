---
title: الخطوط الافتراضية - واجهة برمجة التطبيقات PowerPoint Java
linktitle: الخطوط الافتراضية
type: docs
weight: 30
url: /php-java/default-font/
description: تتيح لك واجهة برمجة التطبيقات PowerPoint Java تعيين الخط الافتراضي لعرض العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. تُظهر هذه المقالة كيفية تعريف الخط الافتراضي DefaultRegular والخط الافتراضي DefaultAsian لاستخدامهما كخطوط افتراضية.
---


## **استخدام الخطوط الافتراضية لعرض العرض التقديمي**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لعرض العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. تُظهر هذه المقالة كيفية تعريف الخط الافتراضي DefaultRegular والخط الافتراضي DefaultAsian لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من الدلائل الخارجية باستخدام Aspose.Slides لـ PHP عبر واجهة برمجة التطبيقات Java:

1. أنشئ مثيلًا من [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
1. [قم بتعيين DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) إلى الخط المرغوب فيه. في المثال التالي، استخدمت Wingdings.
1. [قم بتعيين DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) إلى الخط المرغوب فيه. لقد استخدمت Wingdings في المثال التالي.
1. قم بتحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، قم بتوليد الصورة المصغرة للشريحة، PDF و XPS للتحقق من النتائج.

تم إعطاء تنفيذ ما سبق أدناه.

```php
  # استخدم خيارات التحميل لتحديد الخطوط العادية والآسيوية الافتراضية
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # تحميل العرض التقديمي
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # توليد الصورة المصغرة للشريحة
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # حفظ الصورة على القرص.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # توليد PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # توليد XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
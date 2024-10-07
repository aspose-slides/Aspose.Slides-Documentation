---
title: استيراد العرض التقديمي
type: docs
weight: 60
url: /php-java/import-presentation/
keywords: "استيراد PowerPoint، PDF إلى عرض تقديمي، PDF إلى PPTX، PDF إلى PPT، Java، Aspose.Slides لـ PHP عبر Java"
description: "استيراد عرض PowerPoint من PDF. تحويل PDF إلى PowerPoint"
---

باستخدام [**Aspose.Slides لـ PHP عبر Java**](https://products.aspose.com/slides/php-java/)، يمكنك استيراد العروض التقديمية من ملفات بتنسيقات أخرى. يوفر Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من ملفات PDF، ومستندات HTML، وما إلى ذلك.

## **استيراد PowerPoint من PDF**

في هذه الحالة، يمكنك تحويل PDF إلى عرض تقديمي بصيغة PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. استدعاء الطريقة [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) وتمرير ملف PDF.
3. استخدم الطريقة [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق PowerPoint.

هذا الرمز PHP يوضح عملية تحويل PDF إلى PowerPoint:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="نصيحة" color="primary" %}} 

قد ترغب في الاطلاع على تطبيق **Aspose المجاني** على الويب [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ مباشر للعملية الموصوفة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، يمكنك تحويل مستند HTML إلى عرض تقديمي بصيغة PowerPoint.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. استدعاء الطريقة [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) وتمرير ملف PDF.
3. استخدم الطريقة [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق PowerPoint.

هذا الرمز PHP يوضح عملية تحويل HTML إلى PowerPoint:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="ملاحظة" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى تنسيقات ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}
---
title: استيراد العروض التقديمية من PDF أو HTML في PHP
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/php-java/import-presentation/
keywords:
- استيراد عرض تقديمي
- استيراد شريحة
- استيراد PDF
- استيراد HTML
- PDF إلى عرض تقديمي
- PDF إلى PPT
- PDF إلى PPTX
- PDF إلى ODP
- HTML إلى عرض تقديمي
- HTML إلى PPT
- HTML إلى PPTX
- HTML إلى ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "استيراد مستندات PDF وHTML إلى عروض PowerPoint وOpenDocument في PHP باستخدام Aspose.Slides لمعالجة الشرائح بسلاسة وعالية الأداء."
---

باستخدام [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من ملفات PDF، مستندات HTML، وما إلى ذلك.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض تقديمي بتنسيق PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) .
2. استدعاء الطريقة [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) وتمرير ملف PDF.
3. استخدام الطريقة [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق PowerPoint.

يظهر هذا الكود PHP عملية التحويل من PDF إلى PowerPoint:
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


{{% alert  title="Tip" color="primary" %}} 
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ مباشر للعملية الموضحة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي بتنسيق PowerPoint.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) .
2. استدعاء الطريقة [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) وتمرير ملف PDF.
3. استخدام الطريقة [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق PowerPoint.

يظهر هذا الكود PHP عملية التحويل من HTML إلى PowerPoint:
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


## **الأسئلة المتكررة**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ تتضمن فئة [PdfImportOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/) طريقة [setDetectTables](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/#setDetectTables) التي تمكّن من التعرف على الجداول. يعتمد الفاعلية على بنية ملف PDF.

{{% alert title="Note" color="warning" %}} 
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML to image](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}
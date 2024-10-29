---
title: تحويل باوربوينت إلى وورد
type: docs
weight: 110
url: /ar/php-java/convert-powerpoint-to-word/
keywords: "تحويل باوربوينت, PPT, PPTX, عرض, وورد, DOCX, DOC, PPTX إلى DOCX, PPT إلى DOC, PPTX إلى DOC, PPT إلى DOCX, Java, java, Aspose.Slides"
description: "تحويل عرض باوربوينت إلى وورد "
---

إذا كنت تخطط لاستخدام محتوى نصي أو معلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، فقد تستفيد من تحويل العرض إلى وورد (DOC أو DOCX).

* عند المقارنة مع Microsoft PowerPoint، فإن تطبيق Microsoft Word مزود بأدوات أو وظائف أكثر للمحتوى.
* بالإضافة إلى وظائف التحرير في وورد، يمكنك أيضًا الاستفادة من ميزات التعاون المعززة والطباعة ومشاركة المحتوى.

{{% alert color="primary" %}} 

قد ترغب في تجربة [**محول العرض إلى وورد عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لترى ما يمكنك الحصول عليه من العمل مع المحتوى النصي من الشرائح. 

{{% /alert %}} 

## **Aspose.Slides و Aspose.Words**

لتحويل ملف باوربوينت (PPTX أو PPT) إلى وورد (DOCX أو DOCX)، تحتاج إلى [Aspose.Slides لـ PHP عبر Java](https://products.aspose.com/slides/php-java/) و [Aspose.Words لـ Java](https://products.aspose.com/words/php-java/).

كواجهة برمجة تطبيقات قائمة بذاتها، يوفر [Aspose.Slides](https://products.aspose.app/slides) لـ Java وظائف تسمح لك باستخراج النصوص من العروض التقديمية.

[Aspose.Words](https://docs.aspose.com/words/php-java/) هي واجهة برمجة تطبيقات متقدمة لمعالجة المستندات تتيح للتطبيقات إنشاء، تعديل، تحويل، عرض، طباعة الملفات، وأداء مهام أخرى مع المستندات بدون استخدام Microsoft Word.

## **تحويل باوربوينت إلى وورد**

1. قم بتحميل مكتبات [Aspose.Slides لـ PHP عبر Java](https://downloads.aspose.com/slides/java) و [Aspose.Words لـ Java](https://downloads.aspose.com/words/java).
2. أضف *aspose-slides-x.x-jdk16.jar* و *aspose-words-x.x-jdk16.jar* إلى CLASSPATH الخاص بك.
3. استخدم مقتطف التعليمات البرمجية التالي لتحويل باوربوينت إلى وورد:

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # يولد ويُدخل صورة الشريحة
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # يُدخل نصوص الشريحة
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $builder->writeln($shape->getTextFrame()->getText());
        }
      }
      $builder->insertBreak(BreakType::PAGE_BREAK);
    }
    $doc->save($outputDoc);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
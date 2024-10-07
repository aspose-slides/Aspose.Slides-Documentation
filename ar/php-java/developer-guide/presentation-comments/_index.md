---
title: تعليقات العروض التقديمية
type: docs
weight: 100
url: /php-java/presentation-comments/
keywords: "تعليقات, تعليقات PowerPoint, عرض PowerPoint, جافا, Aspose.Slides لـ PHP عبر جافا"
description: "أضف تعليقات وردود في عرض PowerPoint"
---

في PowerPoint، تظهر التعليقات كملاحظات أوannotations على الشريحة. عند النقر على تعليق، يتم الكشف عن محتوياته أو رسائله.

### **لماذا تضيف تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint التقديمية، يوفر Aspose.Slides لـ PHP عبر جافا

* فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)، والتي تحتوي على مجموعات من المؤلفين (من واجهة [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). يضيف المؤلفون تعليقات إلى الشرائح.
* واجهة [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection)، والتي تحتوي على مجموعة من التعليقات لمؤلفين فرديين.
* فئة [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)، والتي تحتوي على معلومات عن المؤلفين وتعليقاتهم: من أضاف التعليق، الوقت الذي تمت فيه إضافة التعليق، موقع التعليق، إلخ.
* فئة [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor)، والتي تحتوي على معلومات عن مؤلفين فرديين: اسم المؤلف، الأحرف الأولى، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليق على الشريحة**
يعرض هذا الكود PHP كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:

```php
  # ينشئ مثيل من فئة Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # يضيف شريحة فارغة
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # يضيف مؤلف
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # يحدد موقع التعليقات
    $point = new Point2DFloat(0.2, 0.2);
    # يضيف تعليق شريحة لمؤلف على الشريحة 1
    $author->getComments()->addComment("مرحبًا Jawad، هذه تعليق الشريحة", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # يضيف تعليق شريحة لمؤلف على الشريحة 2
    $author->getComments()->addComment("مرحبًا Jawad، هذه تعليق الشريحة الثانية", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # يصل إلى الشريحة ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # عند تمرير null كوسيط، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    $Comments = $slide->getSlideComments($author);
    # يصل إلى التعليق في الفهرس 0 للشريحة 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # يحدد مجموعة تعليقات المؤلف في الفهرس 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الوصول إلى تعليقات الشريحة**
يعرض هذا الكود PHP كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:

```php
  # ينشئ مثيل من فئة Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " لديه تعليق: " . $comment->getText() . " مع المؤلف: " . $comment->getAuthor()->getName() . " نشرت في الوقت :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ردود التعليقات**
التعليق الرئيسي هو التعليق الأعلى أو الأصلي في هرم التعليقات أو الردود. باستخدام الطرق [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) أو [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (من واجهة [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment))، يمكنك تعيين أو الحصول على تعليق رئيسي.

يعرض هذا الكود PHP كيفية إضافة تعليقات والحصول على ردود عليها:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # يضيف تعليق
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("تعليق 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # يضيف ردًا على التعليق 1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("رد 1 على التعليق 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # يضيف ردًا آخر على التعليق 1
    $reply2 = $author2->getComments()->addComment("رد 2 على التعليق 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # يضيف ردًا على رد موجود
    $subReply = $author1->getComments()->addComment("رد فرعي 3 على الرد 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("تعليق 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("تعليق 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("رد 4 على التعليق 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # يعرض هرم التعليقات على وحدة التحكم
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # يزيل التعليق 1 وجميع الردود عليه
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="تنبيه" %}} 

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (من واجهة [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) لحذف تعليق، يتم حذف الردود على التعليق أيضًا.
* إذا أدى إعداد [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) إلى إنشاء مرجع دائري، سيتم رمي [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت شركة Microsoft *التعليقات الحديثة* في PowerPoint. تعمل ميزة التعليقات الحديثة على تحسين التعاون بشكل كبير في PowerPoint. من خلال التعليقات الحديثة، يتمكن مستخدمو PowerPoint من حل التعليقات، وتأمين التعليقات إلى الكائنات والنصوص، والانخراط في التفاعلات بشكل أسهل بكثير مما كان عليه في السابق.

في [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/)، قمنا بتنفيذ دعم التعليقات الحديثة من خلال إضافة فئة [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). تم إضافة طرق [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) و [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) إلى فئة [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

يعرض هذا الكود PHP كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("مؤلف ما", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("هذه تعليق حديث", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة التعليق**

### **حذف جميع التعليقات والمؤلفين**

يعرض هذا الكود PHP كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # يحذف جميع التعليقات من العرض التقديمي
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # يحذف جميع المؤلفين
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **حذف تعليقات محددة**

يعرض هذا الكود PHP كيفية حذف تعليقات محددة على شريحة:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # إضافة التعليقات...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("تعليق 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("تعليق 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # إزالة جميع التعليقات التي تحتوي على نص "تعليق 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("تعليق 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```
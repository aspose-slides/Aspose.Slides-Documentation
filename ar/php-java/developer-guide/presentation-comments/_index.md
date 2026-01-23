---
title: إدارة تعليقات العروض التقديمية في PHP
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/php-java/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى تعليق
- تحرير تعليق
- الرد على تعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides للـ PHP عبر Java: إضافة، قراءة، تحرير، وحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، يتم إظهار محتوياته أو رسائله. 

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint التقديمية، توفر Aspose.Slides for PHP عبر Java

* الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تحتوي على مجموعات المؤلفين (من الفئة [CommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/)). يضيف المؤلفون تعليقات إلى الشرائح.
* الفئة [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) التي تحتوي على مجموعة التعليقات للمؤلفين الفرديين.
* الفئة [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موقع التعليق، إلخ.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) التي تحتوي على معلومات حول المؤلفين الفرديين: اسم المؤلف، حرفيه، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليقات إلى الشريحة**
هذا الكود PHP يوضح لك كيفية إضافة تعليق إلى شريحة في عرض PowerPoint التقديمي:
```php
  # يخلق كائن من فئة Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # يضيف شريحة فارغة
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # يضيف مؤلفًا
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # يحدد موقع التعليقات
    $point = new Point2DFloat(0.2, 0.2);
    # يضيف تعليق شريحة لمؤلف على الشريحة 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # يضيف تعليق شريحة لمؤلف على الشريحة 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # يصل إلى ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # عندما يتم تمرير null كمعامل، تُستحضَر التعليقات من جميع المؤلفين إلى الشريحة المختارة
    $Comments = $slide->getSlideComments($author);
    # يصل إلى التعليق في الفهرس 0 للشريحة 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # يختار مجموعة تعليقات المؤلف في الفهرس 0
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
هذا الكود PHP يوضح لك كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint التقديمي:
```php
  # ينشئ كائن من فئة Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الرد على التعليقات**
التعليق الأصلي هو التعليق الأعلى أو الأصلي في تسلسل هرمي من التعليقات أو الردود. باستخدام طريقتي [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) أو [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) (من الفئة [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/))، يمكنك تعيين أو الحصول على التعليق الأصلي.

هذا الكود PHP يوضح لك كيفية إضافة تعليقات والحصول على الردود عليها:
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # يضيف تعليق
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # يضيف ردًا على التعليق 1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # يضيف ردًا آخر على التعليق 1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # يضيف ردًا على رد موجود
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # يعرض تسلسل التعليقات الهرمي في وحدة التحكم
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
    # يزيل التعليق 1 وكل الردود عليه
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="انتباه" %}} 

* عند استخدام طريقة [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) (من الفئة [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/)) لحذف تعليق، يتم أيضًا حذف الردود على التعليق.
* إذا أدى ضبط [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) إلى إشارة دائرية، سيتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).

{{% /alert %}}

## **إضافة تعليقات حديثة**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. ميزة التعليقات الحديثة تحسّن بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على إمكانية حل التعليقات، ربط التعليقات بالكائنات والنصوص، والمشاركة في التفاعلات بسهولة أكبر مما كان عليه سابقًا. 

يدعم Aspose Slides التعليقات الحديثة عبر الفئة [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/). تم إضافة الطريقتين [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) و[insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/insertmoderncomment/) إلى الفئة [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/).

هذا الكود PHP يوضح لك كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint التقديمي:
```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة التعليقات**

### **حذف جميع التعليقات والمؤلفين**

هذا الكود PHP يوضح لك كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:
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

هذا الكود PHP يوضح لك كيفية حذف تعليقات محددة على شريحة:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # أضف التعليقات...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # احذف جميع التعليقات التي تحتوي على نص "comment 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
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


## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**

نعم. تعرض [التعليقات الحديثة](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) طريقة [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/); يمكنك كتابة حالة [التعليق](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) (على سبيل المثال، وضع علامة تم الحل)، ويتم حفظ هذه الحالة في الملف وتتعرف عليها PowerPoint.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأصلي](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) الخاص به، مما يتيح سلاسل ردود غير محدودة. لا تُحدد الواجهة البرمجية حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تحديد موضع علامة التعليق على الشريحة؟**

يتم تخزين الموضع كنقطة ذات قيمة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان الذي تريده.
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
- تعديل تعليق
- الرد على تعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في تعليقات العروض التقديمية باستخدام Aspose.Slides for PHP عبر Java: أضف، واقرأ، وعدل، واحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، يتم عرض محتوياته أو رسائله. 

## ** لماذا إضافة تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint التقديمية، توفر Aspose.Slides for PHP via Java
* الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على مجموعات المؤلفين (من الواجهة [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). يقوم المؤلفون بإضافة تعليقات إلى الشرائح.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection) التي تحتوي على مجموعة التعليقات للمؤلفين الفرديين.
* الفئة [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أ添加 التعليق، وقت إضافة التعليق، موضع التعليق، إلخ.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor) التي تحتوي على معلومات حول المؤلفين الفرديين: اسم المؤلف، حروفه الأولى، التعليقات المرتبطة باسم المؤلف، إلخ.

## ** إضافة تعليقات إلى الشريحة**

يعرض لك هذا الكود PHP كيفية إضافة تعليق إلى شريحة في عرض PowerPoint التقديمي:
```php
  # إنشاء كائن من الفئة Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # إضافة شريحة فارغة
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # إضافة مؤلف
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # تحديد موضع التعليقات
    $point = new Point2DFloat(0.2, 0.2);
    # إضافة تعليق شريحة لمؤلف على الشريحة 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # إضافة تعليق شريحة لمؤلف على الشريحة 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # الوصول إلى ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # عند تمرير null كمعامل، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    $Comments = $slide->getSlideComments($author);
    # الوصول إلى التعليق عند الفهرس 0 للشريحة 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # اختيار مجموعة تعليقات المؤلف عند الفهرس 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## ** الوصول إلى تعليقات الشريحة**

يعرض لك هذا الكود PHP كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint التقديمي:
```php
  # إنشاء كائن من الفئة Presentation
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


## ** الرد على التعليقات**

التعليق الأب هو التعليق الأعلى أو الأصلي في تسلسل هرمي من التعليقات أو الردود. باستخدام طرق [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) أو [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (من الواجهة [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment))، يمكنك تعيين أو الحصول على تعليق أب.

يعرض لك هذا الكود PHP كيفية إضافة تعليقات والحصول على الردود عليها:
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # إضافة تعليق
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # إضافة رد إلى comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # إضافة رد آخر إلى comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # إضافة رد إلى رد موجود
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # عرض تسلسل التعليقات في وحدة التحكم
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
    # إزالة comment1 وجميع الردود عليه
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="انتباه" %}} 

* عندما يُستخدم طريقة [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (من الواجهة [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)) لحذف تعليق، تُحذف الردود على التعليق أيضًا.
* إذا أدت إعدادات [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) إلى إشارة دائرية، سيتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

## ** إضافة تعليقات حديثة**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تحسّن ميزة التعليقات الحديثة بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على إمكانية حل التعليقات، ربط التعليقات بالكائنات والنصوص، والتفاعل بسهولة أكبر مما كان سابقًا. 

في [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/)، قمنا بتنفيذ دعم التعليقات الحديثة بإضافة الفئة [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). تمت إضافة طريقتي [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) و[insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) إلى الفئة [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

يعرض لك هذا الكود PHP كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint التقديمي:
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


## ** حذف التعليقات**

### ** حذف جميع التعليقات والمؤلفين**

يعرض لك هذا الكود PHP كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # حذف جميع التعليقات من العرض التقديمي
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # حذف جميع المؤلفين
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


### ** حذف تعليقات محددة**

يعرض لك هذا الكود PHP كيفية حذف تعليقات محددة على شريحة:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # إضافة تعليقات...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # إزالة جميع التعليقات التي تحتوي على النص "comment 1"
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


## ** الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**

نعم. تُظهر [Modern comments](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) طريقة [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/); يمكنك كتابة [comment’s state](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) (على سبيل المثال، وضع علامة أنه تم حله)، ويتم حفظ هذه الحالة في الملف ويتعرف عليها PowerPoint.

**هل تُدعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) الخاص به، مما يتيح سلاسل ردود غير محدودة. لا تُعلن الواجهة عن حد معين لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تخزين الموضع كنقطة ذات قيمة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان المطلوب.
---
title: تعليق
type: docs
weight: 230
url: /ar/php-java/examples/elements/comment/
keywords:
- تعليق
- تعليق حديث
- إضافة تعليق
- الوصول إلى التعليق
- إزالة التعليق
- الرد على التعليق
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة تعليقات الشرائح في PHP باستخدام Aspose.Slides: إضافة، قراءة، الرد، تعديل، حذف، والعمل مع التعليقات المتسلسلة لـ PowerPoint و OpenDocument."
---
يوضح إضافة وقراءة وإزالة والرد على التعليقات الحديثة باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة تعليق حديث**

إنشاء تعليق من كتابة مستخدم وحفظ العرض التقديمي.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إضافة تعليق حديث.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى تعليق حديث**

قراءة تعليق حديث من عرض تقديمي موجود.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة تعليق حديث**

إزالة تعليق وحفظ الملف المحدث.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الرد على تعليق حديث**

إضافة ردود إلى تعليق حديث رئيسي.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إضافة مؤلف تعليق.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // إضافة تعليق أصلي والردود.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // تعيين التعليق الأصلي للردود.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // حفظ العرض التقديمي مع الردود.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
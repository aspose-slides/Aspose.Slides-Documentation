---
title: نظر
type: docs
weight: 230
url: /fa/php-java/examples/elements/comment/
keywords:
- نظر
- نظر مدرن
- افزودن نظر
- دسترسی به نظر
- حذف نظر
- پاسخ به نظر
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت نظرات اسلاید در PHP با Aspose.Slides: افزودن، خواندن، پاسخ دادن، ویرایش، حذف و کار با نظرات ردیفی برای PowerPoint و OpenDocument."
---
نشان می‌دهد که چگونه نظرات مدرن را با استفاده از **Aspose.Slides for PHP via Java** اضافه، خوانده، حذف و پاسخ داد.

## **افزودن یک نظر مدرن**

یک نظر با نویسنده یک کاربر ایجاد کنید و ارائه را ذخیره کنید.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افزودن یک نظر مدرن.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به یک نظر مدرن**

یک نظر مدرن را از ارائه‌ای موجود بخوانید.

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

## **حذف یک نظر مدرن**

یک نظر را حذف کنید و فایل به‌روز شده را ذخیره کنید.

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

## **پاسخ به یک نظر مدرن**

پاسخ‌ها را به یک نظر مدرن والد اضافه کنید.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // افزودن نویسندهٔ نظر.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // افزودن یک نظر والد و پاسخ‌ها.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // تنظیم نظر والد برای پاسخ‌ها.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // ذخیرهٔ ارائه با پاسخ‌ها.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
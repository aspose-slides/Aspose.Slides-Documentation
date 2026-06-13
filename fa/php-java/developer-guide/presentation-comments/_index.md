---
title: مدیریت نظرات ارائه در PHP
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/php-java/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات PowerPoint
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- حذف نظر
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت کامل نظرات ارائه با Aspose.Slides برای PHP از طریق Java: افزودن، خواندن، ویرایش و حذف نظرات در فایل‌های PowerPoint به‌سرعت و به‌راحتی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را در Aspose.Slides مدیریت کنید. انواع اصلی مرتبط با نظرات را نشان می‌دهد و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها، استفاده از نظرات مدرن و حذف نظرات از یک ارائه را به نمایش می‌گذارد.

مثال‌ها بر روی سناریوهای رایج بازبینی و همکاری در PowerPoint تمرکز دارند، مانند اختصاص نظرات به نویسندگان، خواندن محتوای نظر و متادیتا، ساخت زنجیرهٔ پاسخ‌ها، و پاک‌سازی تمام نظرات یا حذف نظرات انتخابی.

در PowerPoint، یک نظر به‌عنوان یادداشت یا حاشیه‌نویسی بر روی اسلاید ظاهر می‌شود. هنگامی که بر روی یک نظر کلیک می‌شود، محتوای آن یا پیام‌ها نشان داده می‌شوند.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

ممکن است بخواهید از نظرات برای ارائه بازخورد یا ارتباط با همکارانتان هنگام بازبینی ارائه‌ها استفاده کنید.

برای این که بتوانید از نظرات در ارائه‌های PowerPoint استفاده کنید، Aspose.Slides for PHP via Java ارائه می‌دهد
* کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که شامل مجموعهٔ نویسندگان است (از کلاس [CommentAuthorCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentauthorcollection/) گرفته شده). نویسندگان نظرات را به اسلایدها اضافه می‌کنند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentcollection/) که شامل مجموعهٔ نظرات برای هر نویسنده است.
* کلاس [Comment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/) که شامل اطلاعاتی درباره نویسندگان و نظرات آن‌ها است: چه کسی نظر را اضافه کرده است، زمان افزودن نظر، موقعیت نظر و غیره.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentauthor/) که شامل اطلاعاتی درباره هر نویسنده است: نام نویسنده، حروف اولیهٔ او، نظرات مرتبط با نام نویسنده و غیره.

## **افزودن نظرات به اسلاید**
این کد PHP نشان می‌دهد که چگونه یک نظر به اسلایدی در یک ارائه PowerPoint اضافه کنید:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # یک اسلاید خالی اضافه می‌کند
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # یک نویسنده اضافه می‌کند
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # موقعیت نظرات را تنظیم می‌کند
    $point = new Point2DFloat(0.2, 0.2);
    # یک نظر اسلاید برای نویسنده در اسلاید 1 اضافه می‌کند
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # یک نظر اسلاید برای نویسنده در اسلاید 2 اضافه می‌کند
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # به ISlide 1 دسترسی پیدا می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # وقتی مقدار null به‌عنوان آرگومان پاس داده شود، نظرات تمام نویسندگان به اسلاید انتخاب شده منتقل می‌شوند
    $Comments = $slide->getSlideComments($author);
    # نظر موجود در ایندکس 0 برای اسلاید 1 را می‌گیرد
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # مجموعه نظرات نویسنده را در ایندکس 0 انتخاب می‌کند
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به نظرات اسلاید**
این کد PHP نشان می‌دهد که چگونه به یک نظر موجود در اسلایدی از یک ارائه PowerPoint دسترسی پیدا کنید:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
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

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی یا بالای سلسله‌مراتبی نظرات یا پاسخ‌ها است. با استفاده از متدهای [getParentComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/getparentcomment/) یا [setParentComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/setparentcomment/) (از کلاس [Comment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/)) می‌توانید یک نظر والد را تنظیم یا دریافت کنید.

این کد PHP نشان می‌دهد که چگونه نظرات را اضافه کنید و پاسخ‌های آن‌ها را دریافت کنید:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # یک نظر اضافه می‌کند
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # یک پاسخ به comment1 اضافه می‌کند
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # یک پاسخ دیگر به comment1 اضافه می‌کند
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # یک پاسخ به پاسخ موجود اضافه می‌کند
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # نمایش سلسله‌مراتب نظرات در کنسول
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
    # حذف comment1 و تمام پاسخ‌های آن
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* وقتی که متد [remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/remove/) (از کلاس [Comment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/)) برای حذف یک نظر استفاده می‌شود، پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر تنظیم [setParentComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/setparentcomment/) منجر به یک ارجاع حلقوی شود، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxeditexception/) پرتاب خواهد شد.
{{% /alert %}}

## **افزودن نظرات مدرن**

در سال 2021، مایکروسافت *نظرات مدرن* را در PowerPoint معرفی کرد. ویژگی نظرات مدرن به طور قابل‌توجهی همکاری در PowerPoint را بهبود می‌بخشد. از طریق نظرات مدرن، کاربران PowerPoint می‌توانند نظرات را حل کنند، نظرات را به اشیا و متون ثابت کنند و تعاملات را بسیار آسان‌تر از قبل انجام دهند.

Aspose Slides نظرات مدرن را توسط کلاس [ModernComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/) پشتیبانی می‌کند. متدهای [addModernComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentcollection/addmoderncomment/) و [insertModernComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentcollection/insertmoderncomment/) به کلاس [CommentCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentcollection/) اضافه شده‌اند.

این کد PHP نشان می‌دهد که چگونه یک نظر مدرن به اسلایدی در یک ارائه PowerPoint اضافه کنید:

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

## **حذف نظرات**

### **حذف تمام نظرات و نویسندگان**

این کد PHP نشان می‌دهد که چگونه تمام نظرات و نویسندگان را در یک ارائه حذف کنید:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # تمام نظرات موجود در ارائه را حذف می‌کند
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # تمام نویسندگان را حذف می‌کند
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **حذف نظرات خاص**

این کد PHP نشان می‌دهد که چگونه نظرات خاصی را روی یک اسلاید حذف کنید:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # نظرات را اضافه کنید...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # حذف تمام نظراتی که متن "comment 1" را دارند
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

## **سوالات متداول**

**آیا Aspose.Slides وضعیت مانند «حل شده» را برای نظرات مدرن پشتیبانی می‌کند؟**

بله. [نظرات مدرن](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/) متد [setStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/setstatus/) را در اختیار می‌گذارند؛ می‌توانید وضعیت یک [نظر](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncommentstatus/) (به عنوان مثال، آن را به‌عنوان حل شده علامت بزنید) را بنویسید، و این وضعیت در پرونده ذخیره می‌شود و توسط PowerPoint تشخیص داده می‌شود.

**آیا بحث‌های رشته‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [نظر والد](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/getparentcomment/) خود ارجاع دهد، که امکان ایجاد زنجیره‌های پاسخ دلخواه را می‌دهد. API محدودیت عمق تو در توی خاصی را اعلام نمی‌کند.

**موقعیت علامت‌گذاری نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت به‌صورت یک نقطهٔ شناور در سیستم مختصات اسلاید ذخیره می‌شود. این امکان را می‌دهد که علامت‌گذاری نظر را دقیقاً در مکانی که نیاز دارید قرار دهید.
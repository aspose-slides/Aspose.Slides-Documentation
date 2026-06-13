---
title: مدیریت نظرات ارائه در JavaScript
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/nodejs-java/presentation-comments/
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
- پاک‌سازی نظر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای Node.js به‌صورت حرفه‌ای مدیریت کنید: افزودن، خواندن، ویرایش و حذف نظرات در فایل‌های PowerPoint با استفاده از JavaScript به‌سرعت و به‌راحتی."
---
## **نمایش کلی**

این مقاله نحوه مدیریت نظرات ارائه در Aspose.Slides را توضیح می‌دهد. انواع اصلی مرتبط با نظر را نشان می‌دهد و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها، استفاده از نظرات مدرن و حذف نظرات از یک ارائه را به نمایش می‌گذارد.

مثال‌ها بر سناریوهای رایج بررسی و همکاری در PowerPoint متمرکز هستند، مانند اختصاص نظرات به نویسندگان، خواندن محتوای نظر و متادیتا، ساخت زنجیره‌های پاسخ و پاک‌سازی تمام نظرات یا حذف نظرات منتخب.

در PowerPoint، یک نظر به شکل یادداشت یا حاشیه‌نویسی بر روی اسلاید ظاهر می‌شود. زمانی که بر روی نظر کلیک می‌شود، محتوا یا پیام‌های آن نمایش داده می‌گردد.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

ممکن است بخواهید برای ارائه بازخورد یا ارتباط با همکارانتان هنگام بررسی ارائه‌ها از نظرات استفاده کنید.

برای این که بتوانید در ارائه‌های PowerPoint از نظرات استفاده کنید، Aspose.Slides برای Node.js via Java موارد زیر را فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که شامل مجموعه‌های نویسندگان (از کلاس [CommentAuthorCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommentAuthorCollection) ) است. نویسندگان نظرات را به اسلایدها اضافه می‌کنند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommentCollection) که شامل مجموعه‌ای از نظرات برای هر نویسنده به‌صورت جداگانه است.
* کلاس [Comment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Comment) که شامل اطلاعاتی درباره نویسندگان و نظراتشان است: چه کسی نظر را اضافه کرده، زمان افزودن نظر، موقعیت نظر و غیره.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommentAuthor) که شامل اطلاعاتی درباره هر نویسنده است: نام نویسنده، حروف اولیه او، نظرات مرتبط با نام نویسنده و غیره.

## **افزودن نظر به اسلاید**
این کد JavaScript نشان می‌دهد چگونه به یک اسلاید در یک ارائه PowerPoint نظر اضافه کنید:

```javascript
// نمونه‌سازی کلاس Presentation
var pres = new aspose.slides.Presentation();
try {
    // یک اسلاید خالی اضافه می‌کند
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // یک نویسنده اضافه می‌کند
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // موقعیت نظرات را تنظیم می‌کند
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // نظر اسلاید برای یک نویسنده در اسلاید 1 اضافه می‌کند
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // نظر اسلاید برای یک نویسنده در اسلاید 2 اضافه می‌کند
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // به ISlide 1 دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
    // زمانی که مقدار null به‌عنوان آرگومان پاس شود، نظرات تمام نویسندگان به اسلاید انتخاب‌شده منتقل می‌شوند
    var Comments = slide.getSlideComments(author);
    // نظر موجود در ایندکس 0 برای اسلاید 1 را دسترسی می‌یابد
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // کلکسیون نظرات نویسنده را در ایندکس 0 انتخاب می‌کند
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دسترسی به نظرات اسلاید**
این کد JavaScript نشان می‌دهد چگونه به یک نظر موجود در یک اسلاید از یک ارائه PowerPoint دسترسی پیدا کنید:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پاسخ به نظرات**
یک نظر والد، نظر اصلی یا بالایی در یک سلسله مراتب نظرات یا پاسخ‌ها است. با استفاده از روش‌های [getParentComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Comment#getParentComment--) یا [setParentComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (از کلاس [Comment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Comment)) می‌توانید یک نظر والد تنظیم یا دریافت کنید.

این کد JavaScript نحوه افزودن نظرات و دریافت پاسخ‌ها به آن‌ها را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک نظر اضافه می‌کند
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // یک پاسخ به comment1 اضافه می‌کند
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // یک پاسخ دیگر به comment1 اضافه می‌کند
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // اضافه کردن یک پاسخ به پاسخ موجود
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // نمایش سلسله‌مراتب نظرات در کنسول
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // حذف comment1 و تمام پاسخ‌های آن
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 

* وقتی از متد [Remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Comment#remove--) (از کلاس [Comment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Comment)) برای حذف یک نظر استفاده می‌شود، پاسخ‌های آن نظر نیز حذف می‌گردند.
* اگر تنظیم [setParentComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) منجر به ایجاد ارجاع حلقوی شود، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PptxEditException) پرتاب می‌شود.

{{% /alert %}}

## **افزودن نظر مدرن**

در سال 2021، مایکروسافت *نظرات مدرن* را در PowerPoint معرفی کرد. ویژگی نظرات مدرن همکاری در PowerPoint را به‌طور قابل‌توجهی بهبود می‌بخشد. از طریق نظرات مدرن، کاربران PowerPoint می‌توانند نظرات را حل کنند، نظرات را به اشیاء و متن‌ها لنگر دهند و به‌صورت بسیار آسان‌تری با هم تعامل داشته باشند.

Aspose.Slides از نظرات مدرن توسط کلاس [ModernComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ModernComment) پشتیبانی می‌کند. روش‌های [addModernComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) و [insertModernComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) به کلاس [CommentCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommentCollection) اضافه شده‌اند.

این کد JavaScript نشان می‌دهد چگونه یک نظر مدرن به یک اسلاید در یک ارائه PowerPoint اضافه کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف نظر**

### **حذف تمام نظرات و نویسندگان**

این کد JavaScript نشان می‌دهد چگونه تمام نظرات و نویسندگان را در یک ارائه حذف کنید:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // تمام نظرات را از ارائه حذف می‌کند
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // تمام نویسندگان را حذف می‌کند
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **حذف نظرات مشخص**

این کد JavaScript نشان می‌دهد چگونه نظرات خاصی را روی یک اسلاید حذف کنید:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // نظرات را اضافه کنید...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // تمام نظراتی که متن "comment 1" را شامل می‌شوند حذف کنید
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **سوالات متداول**

**آیا Aspose.Slides وضعیت «حل شد» برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. [نظرات مدرن](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/) متدهای [getStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/getstatus/) و [setStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/setStatus/) را ارائه می‌دهند؛ می‌توانید وضعیت یک [نظر](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncommentstatus/) را بخوانید و تنظیم کنید (به‌عنوان مثال، آن را به‌عنوان حل‌شده علامت بزنید) و این وضعیت در فایل ذخیره شده و توسط PowerPoint شناسایی می‌شود.

**آیا بحث‌های سلسله‌وار (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [نظر والد](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/comment/getparentcomment/) خود ارجاع دهد، که امکان ایجاد زنجیره‌های پاسخ دلخواه را فراهم می‌کند. API محدودیت عمق تو در توی خاصی اعلام نکرده است.

**موقعیت نشانگر نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

این موقعیت به‌صورت یک نقطه شناور در سیستم مختصات اسلاید ذخیره می‌شود. این امکان را می‌دهد تا نشانگر نظر را دقیقاً در مکانی که نیاز دارید قرار دهید.
---
title: "مدیریت نظرات ارائه در اندروید"
linktitle: "نظرات ارائه"
type: docs
weight: 100
url: /fa/androidjava/presentation-comments/
keywords:
- "نظر"
- "نظر مدرن"
- "نظرات پاورپوینت"
- "نظرات ارائه"
- "نظرات اسلاید"
- "افزودن نظر"
- "دسترسی به نظر"
- "ویرایش نظر"
- "پاسخ به نظر"
- "حذف نظر"
- "حذف نظر"
- "پاورپوینت"
- "OpenDocument"
- "ارائه"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "نظرات ارائه را با Aspose.Slides برای اندروید از طریق جاوا به‌صورت کامل مدیریت کنید: افزودن، خواندن، ویرایش و حذف نظرات در فایل‌های پاورپوینت به‌سرعت و به‌سادگی."
---
## **نمای کلی**

این مقاله نحوه مدیریت نظرات ارائه در Aspose.Slides را شرح می‌دهد. این مقاله انواع اصلی مرتبط با نظرات را نشان می‌دهد و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها، استفاده از نظرات مدرن و حذف نظرات از یک ارائه را نشان می‌دهد.

مثال‌ها بر سناریوهای رایج بررسی و همکاری در PowerPoint متمرکز هستند، مانند اختصاص نظرات به نویسندگان، خواندن محتوای نظر و متادیتا، ساخت زنجیره‌های پاسخ، و پاک‌سازی تمام نظرات یا حذف نظرات منتخب.

در PowerPoint، یک نظر به‌عنوان یک یادداشت یا حاشیه‌نویسی روی اسلاید ظاهر می‌شود. وقتی روی یک نظر کلیک می‌شود، محتوا یا پیام‌های آن نشان داده می‌شود.

### **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

شاید بخواهید برای ارائه بازخورد یا ارتباط با همکاران خود هنگام بررسی ارائه‌ها از نظرات استفاده کنید.

برای این که بتوانید در ارائه‌های PowerPoint از نظرات استفاده کنید، Aspose.Slides برای Android از طریق Java فراهم می‌کند

* کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل مجموعه‌های نویسندگان (از رابط [ICommentAuthorCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICommentAuthorCollection)) است. نویسندگان نظرات را به اسلایدها اضافه می‌کنند.
* رابط [ICommentCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICommentCollection) که شامل مجموعه‌ای از نظرات برای هر نویسنده است.
* کلاس [IComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IComment) که شامل اطلاعات درباره نویسندگان و نظرات آن‌ها است: چه کسی نظر را اضافه کرده، زمان افزوده شدن نظر، موقعیت نظر و غیره.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/CommentAuthor) که شامل اطلاعات درباره هر نویسنده است: نام نویسنده، حروف اولیه او، نظرات مرتبط با نام نویسنده و غیره.

## **افزودن نظر به اسلاید**
این کد Java نشان می‌دهد چگونه یک نظر به اسلایدی در یک ارائه PowerPoint اضافه کنید:

```java
// یک شیء از کلاس Presentation را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // یک اسلاید خالی اضافه می‌کند
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // یک نویسنده اضافه می‌کند
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // موقعیت نظرات را تنظیم می‌کند
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // نظر اسلاید برای نویسنده در اسلاید 1 اضافه می‌کند
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // نظر اسلاید برای نویسنده در اسلاید 2 اضافه می‌کند
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // دسترسی به ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // وقتی null به عنوان آرگومان پاس داده شود، نظرات تمام نویسندگان به اسلاید انتخابی آورده می‌شوند
    IComment[] Comments = slide.getSlideComments(author);

    // دسترسی به نظر در ایندکس 0 برای اسلاید 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // مجموعه نظرات نویسنده را در ایندکس 0 انتخاب می‌کند
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به نظرات اسلاید**
این کد Java نشان می‌دهد چگونه به یک نظر موجود روی اسلایدی در یک ارائه PowerPoint دسترسی پیدا کنید:

```java
// یک شیء از کلاس Presentation را ایجاد می‌کند
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی یا بالایی در سلسله‌مراتب نظرات یا پاسخ‌ها است. با استفاده از روش‌های [getParentComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IComment#getParentComment--) یا [setParentComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (از رابط [IComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IComment)) می‌توانید یک نظر والد را تنظیم یا دریافت کنید.

این کد Java نشان می‌دهد چگونه نظرات اضافه کنید و پاسخ‌ها را دریافت کنید:

```java
Presentation pres = new Presentation();
try {
    // یک نظر اضافه می‌کند
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // یک پاسخ به comment1 اضافه می‌کند
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // یک پاسخ دیگر به comment1 اضافه می‌کند
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // یک پاسخ به یک پاسخ موجود اضافه می‌کند
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // سلسله‌مراتب نظرات را در کنسول نمایش می‌دهد
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1 و تمام پاسخ‌های آن را حذف می‌کند
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* وقتی متد [Remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IComment#remove--) (از رابط [IComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IComment)) برای حذف یک نظر استفاده می‌شود، پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر تنظیم [setParentComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) باعث ایجاد یک ارجاع چرخه‌ای شود، [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PptxEditException) پرتاب خواهد شد.
{{% /alert %}}

## **افزودن نظر مدرن**

در سال 2021، مایکروسافت *نظرات مدرن* را در PowerPoint معرفی کرد. ویژگی نظرات مدرن، همکاری در PowerPoint را به‌طور قابل توجهی بهبود می‌بخشد. با نظرات مدرن، کاربران PowerPoint می‌توانند نظرات را حل کنند، نظرات را به اشیا و متن‌ها پیوند دهند و تعاملات را بسیار آسان‌تر انجام دهند. 

Aspose.Slides نظرات مدرن را توسط کلاس [ModernComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ModernComment) پشتیبانی می‌کند. روش‌های [addModernComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) و [insertModernComment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) به کلاس [CommentCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/CommentCollection) اضافه شدند.

این کد Java نشان می‌دهد چگونه یک نظر مدرن به اسلایدی در یک ارائه PowerPoint اضافه کنید: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یک نظر**

### **حذف همه نظرات و نویسندگان**

این کد Java نشان می‌دهد چگونه تمام نظرات و نویسندگان را در یک ارائه حذف کنید:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // تمام نظرات را از ارائه حذف می‌کند
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // تمام نویسندگان را حذف می‌کند
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **حذف نظرات خاص**

این کد Java نشان می‌دهد چگونه نظرات خاصی را روی یک اسلاید حذف کنید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // نظرات را اضافه کنید...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // تمام نظراتی را حذف کنید که متن "comment 1" را دارند
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سوالات متداول**

**آیا Aspose.Slides وضعیت مانند «حل شد» برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. [نظرات مدرن](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/moderncomment/) یک متد [setStatus](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) را فراهم می‌کند؛ می‌توانید وضعیت یک [نظر](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/moderncommentstatus/) (مثلاً علامت‌گذاری به‌عنوان حل شد) را بنویسید و این وضعیت در فایل ذخیره می‌شود و توسط PowerPoint شناسایی می‌شود.

**آیا بحث‌های سلسله‌وار (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [نظر والد](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/comment/#getParentComment--) خود ارجاع دهد که امکان زنجیره‌های پاسخ دلخواه را فراهم می‌کند. API محدودیت عمق تو در توی خاصی را اعلام نمی‌کند.

**موقعیت نشانگر نظر روی اسلاید در چه سامانه مختصاتی تعریف می‌شود؟**

موقعیت به‌صورت نقطه‌ای شناور در سامانه مختصات اسلاید ذخیره می‌شود. این به شما امکان می‌دهد نشانگر نظر را دقیقاً در مکان دلخواه قرار دهید.
---
title: مدیریت نظرات ارائه در .NET
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/net/presentation-comments/
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
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای .NET به‌صورت حرفه‌ای مدیریت کنید: افزودن، خواندن، ویرایش و حذف نظرات در فایل‌های PowerPoint به‌سرعت و به‌راحتی."
---
## **نمای کلی**

این مقاله چگونگی مدیریت نظرات ارائه در Aspose.Slides را توضیح می‌دهد. انواع اصلی مرتبط با نظر را نشان می‌دهد و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها، استفاده از نظرات مدرن و حذف نظرات از یک ارائه را به نمایش می‌گذارد.

مثال‌ها بر روی سناریوهای متداول بازبینی و همکاری در PowerPoint متمرکز هستند، مانند اختصاص نظرات به نویسندگان، خواندن محتوای نظرات و فراداده‌ها، ساخت زنجیره پاسخ‌ها و پاک‌سازی تمام نظرات یا حذف نظرات انتخابی.

در PowerPoint، یک نظر به عنوان یادداشت یا حاشیه‌نویسی روی یک اسلاید ظاهر می‌شود. وقتی بر روی نظر کلیک می‌شود، محتوا یا پیام‌های آن آشکار می‌گردد.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

ممکن است بخواهید برای ارائه‌ی بازخورد یا برقراری ارتباط با همکارانتان هنگام بازبینی ارائه‌ها از نظرات استفاده کنید.

برای امکان استفاده از نظرات در ارائه‌های PowerPoint، Aspose.Slides for .NET فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که مجموعه‌های نویسندگان (از ویژگی [CommentAuthorCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icommentauthorcollection/properties/index)) را شامل می‌شود. نویسندگان نظرات را به اسلایدها اضافه می‌کنند. 
* اینترفیس [ICommentCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icommentcollection) که مجموعه‌ای از نظرات برای هر نویسنده را در خود دارد. 
* کلاس [IComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment) که اطلاعاتی درباره نویسندگان و نظراتشان شامل این است که چه کسی نظر را اضافه کرده، زمان افزودن نظر، موقعیت نظر و غیره. 
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/net/aspose.slides/commentauthor) که اطلاعاتی درباره هر نویسنده شامل نام نویسنده، حروف اول وی، نظرات مرتبط با نام نویسنده و غیره را در خود دارد. 

## **افزودن نظرات به اسلاید**
این کد C# نشان می‌دهد چگونه یک نظر به اسلایدی در ارائه PowerPoint اضافه کنید:

```c#
// یک شی از کلاس Presentation را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // یک اسلاید خالی اضافه می‌کند
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // یک نویسنده اضافه می‌کند
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // موقعیت نظرات را تنظیم می‌کند
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // یک نظر اسلاید برای نویسنده در اسلاید 1 اضافه می‌کند
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // یک نظر اسلاید برای نویسنده در اسلاید 2 اضافه می‌کند
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // به ISlide 1 دسترسی می‌یابد
    ISlide slide = presentation.Slides[0];

    // زمانی که null به‌عنوان آرگومان ارسال شود، نظرات تمام نویسندگان به اسلاید انتخاب‌شده منتقل می‌شوند
    IComment[] Comments = slide.GetSlideComments(author);

    // نظری را که در ایندکس 0 برای اسلاید 1 است دسترسی می‌یابد
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // مجموعه نظرات نویسنده را در ایندکس 0 انتخاب می‌کند
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **دسترسی به نظرات اسلاید**
این کد C# نشان می‌دهد چگونه به یک نظر موجود در اسلایدی از یک ارائه PowerPoint دسترسی پیدا کنید:

```c#
// یک شی از کلاس Presentation را ایجاد می‌کند
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **پاسخ به نظرات**
یک نظر والد، نظر اصلی یا بالاترین نظر در سلسله‌مراتبی از نظرات یا پاسخ‌ها است. با استفاده از ویژگی [ParentComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment/properties/parentcomment) (از اینترفیس [IComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment)) می‌توانید یک نظر والد را تنظیم یا دریافت کنید. 

این کد C# نشان می‌دهد چگونه نظرات را اضافه کنید و پاسخ‌های آن‌ها را دریافت کنید:

```c#
using (Presentation pres = new Presentation())
{
    // یک نظر اضافه می‌کند
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // پاسخی به comment1 اضافه می‌کند
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // پاسخ دیگری به comment1 اضافه می‌کند
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // پاسخی به پاسخ موجود اضافه می‌کند
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // سلسله مراتب نظرات را در کنسول نمایش می‌دهد
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1 و تمام پاسخ‌های آن را حذف می‌کند
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="توجه" %}} 
* وقتی روش [Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment/methods/remove) (از اینترفیس [IComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment)) برای حذف یک نظر استفاده می‌شود، پاسخ‌های آن نظر نیز حذف می‌گردند. 
* اگر تنظیم [ParentComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment/properties/parentcomment) منجر به یک مرجع چرخه‌ای شود، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception) پرتاب خواهد شد.
{{% /alert %}}

## **افزودن نظرات مدرن**

در سال 2021، مایکروسافت *نظرات مدرن* را در PowerPoint معرفی کرد. ویژگی نظرات مدرن به طور چشمگیری همکاری در PowerPoint را بهبود می‌بخشد. از طریق نظرات مدرن، کاربران PowerPoint می‌توانند نظرات را حل کنند، نظرات را به اشیاء و متون متصل کنند و تعاملات را بسیار راحت‌تر انجام دهند. 

در [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/fa/net/aspose-slides-for-net-21-11-release-notes/)، ما پشتیبانی از نظرات مدرن را با افزودن کلاس [ModernComment](https://reference.aspose.com/slides/fa/net/aspose.slides/moderncomment) پیاده‌سازی کردیم. روش‌های [AddModernComment](https://reference.aspose.com/slides/fa/net/aspose.slides/commentcollection/methods/addmoderncomment) و [InsertModernComment](https://reference.aspose.com/slides/fa/net/aspose.slides/commentcollection/methods/insertmoderncomment) به کلاس [CommentCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/commentcollection) اضافه شدند. 

این کد C# نشان می‌دهد چگونه یک نظر مدرن به اسلایدی در ارائه PowerPoint اضافه کنید:

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **حذف نظرات**

### **حذف تمام نظرات و نویسندگان**

این کد C# نشان می‌دهد چگونه تمام نظرات و نویسندگان را در یک ارائه حذف کنید:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // تمام نظرات را از ارائه حذف می‌کند
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // تمام نویسندگان را حذف می‌کند
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **حذف نظرات خاص**

این کد C# نشان می‌دهد چگونه نظرات خاصی را در یک اسلاید حذف کنید:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // نظرات را اضافه کنید...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // تمام نظراتی که متن "comment 1" را دارند حذف کنید
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا Aspose.Slides وضعیت «حل‌شده» برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. [نظرات مدرن](https://reference.aspose.com/slides/fa/net/aspose.slides/moderncomment/) یک ویژگی [Status](https://reference.aspose.com/slides/fa/net/aspose.slides/moderncomment/status/) را در اختیار می‌گذارند؛ می‌توانید وضعیت یک نظر را بخوانید و تنظیم کنید (برای مثال، آن را به صورت حل‌شده علامت بزنید) و این وضعیت در فایل ذخیره شده و توسط PowerPoint شناخته می‌شود.

**آیا بحث‌های زنجیره‌ای (زنجیره پاسخ) پشتیبانی می‌شود و آیا محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/net/aspose.slides/comment/parentcomment/) خود ارجاع دهد و زنجیره‌های پاسخ دلخواه را امکان‌پذیر می‌سازد. API محدودیتی مشخص برای عمق تو در تویی اعلام نکرده است.

**موقعیت نشانگر نظر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت به عنوان یک نقطه شناور در سیستم مختصات اسلاید ذخیره می‌شود. این امکان را می‌دهد که نشانگر نظر را دقیقاً در مکانی که نیاز دارید قرار دهید.
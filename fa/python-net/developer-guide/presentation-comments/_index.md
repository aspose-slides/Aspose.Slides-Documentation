---
title: مدیریت نظرات ارائه در Python
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/python-net/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات پاورپوینت
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- حذف نظر
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای پایتون از طریق .NET به‌صورت حرفه‌ای مدیریت کنید: افزودن، خواندن، ویرایش و حذف نظرات در فایل‌های پاورپوینت به سرعت و به آسانی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را در Aspose.Slides مدیریت کنید. انواع اصلی مرتبط با نظرات را نشان می‌دهد و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها، استفاده از نظرات مدرن، و حذف نظرات از یک ارائه را به تصویر می‌کشد.

مثال‌ها بر سناریوهای رایج بازبینی و همکاری در PowerPoint تمرکز دارند، مانند اختصاص نظرات به نویسندگان، خواندن محتوای نظر و فراداده‌ها، ساخت زنجیره‌های پاسخ، و پاک‌سازی تمام نظرات یا حذف نظرات انتخابی.

در PowerPoint، یک نظر به‌عنوان یادداشت یا حاشیه‌نویسی بر روی اسلاید ظاهر می‌شود. وقتی روی یک نظر کلیک می‌شود، محتوا یا پیام‌های آن نمایش داده می‌شود.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

ممکن است بخواهید برای ارائه بازخورد یا ارتباط با همکارانتان هنگام بازبینی ارائه‌ها از نظرات استفاده کنید.

برای این که بتوانید از نظرات در ارائه‌های PowerPoint استفاده کنید، Aspose.Slides for Python via .NET ارائه می‌دهد

* کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) که شامل مجموعه‌های نویسندگان (از ویژگی [CommentAuthorCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/commentauthorcollection/) ) است. نویسندگان نظرات را به اسلایدها اضافه می‌کنند. 
* کلاس [CommentCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/commentcollection/) که مجموعه‌ای از نظرات برای هر نویسنده را شامل می‌شود. 
* کلاس [Comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/) که شامل اطلاعاتی درباره نویسندگان و نظرات آن‌هاست: کسی که نظر را اضافه کرده، زمان افزودن نظر، موقعیت نظر و غیره. 
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/commentauthor/) که شامل اطلاعاتی درباره هر نویسنده است: نام نویسنده، حروف اولیه او، نظرات مربوط به نام نویسنده و غیره. 

## **افزودن نظر به اسلاید**
این کد Python نشان می‌دهد که چگونه یک نظر به اسلایدی در یک ارائه PowerPoint اضافه کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# یک شی از کلاس Presentation را ایجاد می‌کند
with slides.Presentation() as presentation:
    # یک اسلاید خالی اضافه می‌کند
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # یک نویسنده اضافه می‌کند
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # موقعیت نظرات را تنظیم می‌کند
    point = draw.PointF(0.2, 0.2)

    # یک نظر اسلاید برای نویسنده در اسلاید 1 اضافه می‌کند
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # یک نظر اسلاید برای نویسنده در اسلاید 2 اضافه می‌کند
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # دسترسی به ISlide 1
    slide = presentation.slides[0]

    # هنگامی که null به‌عنوان آرگومان پاس داده شود، نظرات تمام نویسندگان به اسلاید انتخاب شده منتقل می‌شوند
    comments = slide.get_slide_comments(author)

    # دسترسی به نظر در ایندکس 0 برای اسلاید 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # مجموعه نظرات نویسنده را در ایندکس 0 انتخاب می‌کند
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **دسترسی به نظرات اسلاید**
این کد Python نشان می‌دهد که چگونه به یک نظر موجود بر روی اسلایدی در یک ارائه PowerPoint دسترسی پیدا کنید:

```python
import aspose.slides as slides

# یک شی از کلاس Presentation را ایجاد می‌کند
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **پاسخ به نظرات**
یک نظر والد، نظر اصلی یا بالایی در یک سلسله‌مراتب نظرات یا پاسخ‌ها است. با استفاده از ویژگی `parent_comment` (از کلاس [Comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/)) می‌توانید یک نظر والد را تنظیم یا دریافت کنید.

این کد Python نشان می‌دهد که چگونه نظرات را اضافه کنید و پاسخ‌های آن‌ها را دریافت کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # افزودن یک نظر
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # افزودن یک پاسخ به comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # افزودن یک پاسخ دیگر به comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # افزودن یک پاسخ به پاسخ موجود
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # نمایش سلسله مراتب نظرات در کنسول
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # حذف comment1 و تمام پاسخ‌های آن
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 
* هنگامی که متد `remove` (از کلاس [Comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/)) برای حذف یک نظر استفاده می‌شود، پاسخ‌های آن نظر نیز حذف می‌شوند. 
* اگر تنظیم `parent_comment` منجر به یک ارجاع حلقوی شود، `PptxEditException` پرتاب خواهد شد.
{{% /alert %}}

## **افزودن نظر مدرن**

در سال 2021، مایکروسافت *نظرات مدرن* را در PowerPoint معرفی کرد. ویژگی نظرات مدرن به‌طور چشمگیری همکاری در PowerPoint را بهبود می‌بخشد. از طریق نظرات مدرن، کاربران PowerPoint می‌توانند نظرات را حل کنند، نظرات را به اشیاء و متون متصل کنند و تعاملات را بسیار آسان‌تر نسبت به قبل انجام دهند.

ما پشتیبانی از نظرات مدرن را با افزودن کلاس [ModernComment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/) پیاده‌سازی کردیم. متدهای `add_modern_comment` و `insert_modern_comment` به کلاس [CommentCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/commentcollection/) اضافه شدند.

این کد Python نشان می‌دهد که چگونه یک نظر مدرن به اسلایدی در یک ارائه PowerPoint اضافه کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف نظر**

### **حذف همه نظرات و نویسندگان**

این کد Python نشان می‌دهد که چگونه تمام نظرات و نویسندگان را در یک ارائه حذف کنید:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # تمام نظرات را از ارائه حذف می‌کند
    for author in presentation.comment_authors:
        author.comments.clear()

    # تمام نویسندگان را حذف می‌کند
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف نظرات خاص**

این کد Python نشان می‌دهد که چگونه نظرات خاصی را بر روی اسلاید حذف کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # افزودن نظرات...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # حذف تمام نظراتی که متن "comment 1" دارند
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**آیا Aspose.Slides وضعیت «حل شده» را برای نظرات مدرن پشتیبانی می‌کند؟**

بله. [نظرات مدرن](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/) یک ویژگی [status](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/status/) را ارائه می‌دهند؛ می‌توانید وضعیت [نظر](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncommentstatus/) را بخوانید و تنظیم کنید (به عنوان مثال، آن را به‌عنوان حل شده علامت‌گذاری کنید)، و این وضعیت در فایل ذخیره شده و توسط PowerPoint تشخیص داده می‌شود.

**آیا بحث‌های زنجیره‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/parent_comment/) خود ارجاع دهد، که امکان ساخت زنجیره‌های پاسخ دلخواه را فراهم می‌کند. API محدودیت خاصی برای عمق تو در تو اعلام نمی‌کند.

**موقعیت علامت‌گذاری نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت به صورت یک نقطه شناور در سیستم مختصات اسلاید ذخیره می‌شود. این به شما اجازه می‌دهد علامت‌گذاری نظر را دقیقاً در مکانی که نیاز دارید قرار دهید.
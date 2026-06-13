---
title: مدیریت نظرات ارائه در C++
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/cpp/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات پاورپوینت
- نظرات ارائه
- نظرات اسلاید
- اضافه کردن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- پاک کردن نظر
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مدیریت کامل نظرات ارائه با Aspose.Slides برای C++: اضافه کردن، خواندن، ویرایش و حذف نظرات در فایل‌های پاورپوینت به سرعت و به آسانی."
---
## **بررسی کلی**

این مقاله نحوهٔ مدیریت نظرات ارائه در Aspose.Slides را توضیح می‌دهد. انواع اصلی مرتبط با نظرات را نشان می‌دهد و نحوهٔ افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها، استفاده از نظرات مدرن و حذف نظرات از یک ارائه را نشان می‌دهد.

مثال‌ها بر سناریوهای رایج بازبینی و همکاری در PowerPoint متمرکز هستند، از جمله اختصاص نظرات به نویسندگان، خواندن محتوای نظر و فراداده‌ها، ساخت زنجیره‌های پاسخ، و پاک کردن تمام نظرات یا حذف نظرات انتخابی.

در PowerPoint، یک نظر به‌صورت یادداشت یا حاشیه‌ای بر روی اسلاید ظاهر می‌شود. وقتی بر روی یک نظر کلیک می‌کنید، محتوا یا پیام‌های آن نمایان می‌شوند.

### **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

ممکن است بخواهید برای ارائه بازخورد بدهید یا هنگام بازبینی ارائه‌ها با همکارانتان ارتباط برقرار کنید.

برای اینکه بتوانید در ارائه‌های PowerPoint از نظرات استفاده کنید، Aspose.Slides for C++ موارد زیر را فراهم می‌کند:

* کلاس [کلاس Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) که شامل مجموعهٔ نویسندگان (از طریق متد [get_CommentAuthors()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)) است. نویسندگان نظرات را به اسلایدها اضافه می‌کنند.  
* رابط [ICommentCollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_comment_collection) که شامل مجموعهٔ نظرات برای هر نویسنده به‌صورت جداگانه است.  
* کلاس [IComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_comment) که اطلاعاتی دربارهٔ نویسندگان و نظراتشان شامل اینکه چه کسی نظر را اضافه کرده، زمان افزودن، موقعیت نظر و غیره را در بر می‌گیرد.  
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.comment_author) که شامل اطلاعات نویسندگان به‌صورت جداگانه است: نام نویسنده، حروف ابتدایی او، نظرات مرتبط با نام نویسنده و غیره.

## **افزودن نظر به اسلاید**
این کد C++ نشان می‌دهد چگونه به یک اسلاید در یک ارائه PowerPoint نظر اضافه کنید:

```cpp
// یک شیء از کلاس Presentation ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();
// یک اسلاید خالی اضافه می‌کند
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// یک نویسنده اضافه می‌کند
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// موقعیت نظرات را تنظیم می‌کند
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// به ISlide 1 دسترسی می‌یابد
auto slide1 = presentation->get_Slides()->idx_get(0);
// به ISlide 2 دسترسی می‌یابد
auto slide2 = presentation->get_Slides()->idx_get(1);

// یک نظر اسلاید برای نویسنده در اسلاید 1 اضافه می‌کند
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// یک نظر اسلاید برای نویسنده در اسلاید 2 اضافه می‌کند
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// زمانی که مقدار null به‌عنوان آرگومان پاس داده شود، نظرات تمام نویسندگان به اسلاید انتخاب‌شده منتقل می‌شوند
auto comments = slide1->GetSlideComments(author);

// دسترسی به نظر در ایندکس 0 برای اسلاید 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // مجموعه نظرات نویسنده را در ایندکس 0 انتخاب می‌کند
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **دسترسی به نظرات اسلاید**
این کد C++ نشان می‌دهد چگونه به یک نظر موجود بر روی اسلاید در یک ارائه PowerPoint دسترسی پیدا کنید:

```cpp
// یک شیء از کلاس Presentation ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **پاسخ به نظرات**
یک نظر والد، نظر اصلی یا بالایی در یک سلسله‌مراتب نظرات یا پاسخ‌ها است. با استفاده از ویژگی [ParentComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (از رابط [IComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_comment)) می‌توانید یک نظر والد تنظیم یا دریافت کنید.

این کد C++ نشان می‌دهد چگونه نظرات اضافه کنید و پاسخ‌های آن‌ها را دریافت کنید:

```cpp
auto pres = System::MakeObject<Presentation>();

// به ISlide 1 دسترسی می‌یابد
auto slide1 = pres->get_Slides()->idx_get(0);

// یک نظر اضافه می‌کند
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// پاسخی به comment1 اضافه می‌کند
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// پاسخی دیگر به comment1 اضافه می‌کند
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// پاسخی به پاسخ موجود اضافه می‌کند
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// سلسله‌مراتب نظرات را در کنسول نمایش می‌دهد
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// Removes comment1 and all replies to it
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="توجه" %}} 

* وقتی متد [Remove](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (از رابط [IComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_comment)) برای حذف یک نظر استفاده می‌شود، پاسخ‌های آن نظر نیز حذف می‌شوند.  
* اگر تنظیم [ParentComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) منجر به یک ارجاع چرخشی شود، استثناء [PptxEditException](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) پرتاب می‌شود.

{{% /alert %}}

## **افزودن نظر مدرن**

در سال 2021، مایکروسافت *نظرات مدرن* را در PowerPoint معرفی کرد. ویژگی نظرات مدرن همکاری در PowerPoint را به‌طرز چشمگیری بهبود می‌بخشد. از طریق نظرات مدرن، کاربران PowerPoint می‌توانند نظرات را حل کنند، نظرات را به اشیاء و متن‌ها ثابت کنند و به‌صورت بسیار راحت‌تری با هم تعامل داشته باشند.

در [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/fa/cpp/aspose-slides-for-cpp-21-11-release-notes/) ما پشتیبانی از نظرات مدرن را با افزودن کلاس [ModernComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.modern_comment) پیاده‌سازی کردیم. متدهای [AddModernComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) و [InsertModernComment](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) به کلاس [CommentCollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.comment_collection) اضافه شدند.

این کد C++ نشان می‌دهد چگونه یک نظر مدرن به اسلایدی در یک ارائه PowerPoint اضافه کنید:

```cpp
auto pres = System::MakeObject<Presentation>();
// به ISlide 1 دسترسی می‌یابد
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **حذف یک نظر**

### **حذف تمام نظرات و نویسندگان**

این کد C++ نشان می‌دهد چگونه تمام نظرات و نویسندگان را در یک ارائه حذف کنید:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// تمام نظرات را از ارائه حذف می‌کند
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
        // تمام نویسندگان را حذف می‌کند
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **حذف نظرات خاص**

این کد C++ نشان می‌دهد چگونه نظرات خاصی را بر روی یک اسلاید حذف کنید:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
        // نظرات را اضافه کنید...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
        // تمام نظراتی که متن "comment 1" را شامل می‌شوند را حذف کنید
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);

```

## **پرسش‌های متداول**

**آیا Aspose.Slides از وضعیت «حل‌شده» برای نظرات مدرن پشتیبانی می‌کند؟**

بله. [نظرات مدرن](https://reference.aspose.com/slides/fa/cpp/aspose.slides/moderncomment/) متدهای [get_Status](https://reference.aspose.com/slides/fa/cpp/aspose.slides/moderncomment/get_status/) و [set_Status](https://reference.aspose.com/slides/fa/cpp/aspose.slides/moderncomment/set_status/) را ارائه می‌دهند؛ می‌توانید وضعیت یک نظر را بخوانید و تنظیم کنید (به‌عنوان مثال، آن را به‌عنوان حل‌شده علامت‌گذاری کنید) و این وضعیت در فایل ذخیره شده و توسط PowerPoint شناسایی می‌شود.

**آیا گفتگوهای سلسله‌مراتبی (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/comment/set_parentcomment/) خود ارجاع دهد که امکان زنجیره‌های پاسخ دلخواه را فراهم می‌کند. API محدودیت خاصی برای عمق تو در تو تعریف نکرده است.

**موقعیت علامت‌گذار نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت به‌صورت یک نقطهٔ شناور در سیستم مختصات اسلاید ذخیره می‌شود. این به شما امکان می‌دهد علامت‌گذار نظر را دقیقاً در مکانی که می‌خواهید قرار دهید.
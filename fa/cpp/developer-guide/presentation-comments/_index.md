---
title: مدیریت نظرات ارائه در C++
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/cpp/presentation-comments/
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
- پاک‌کردن نظر
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای C++: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های PowerPoint به‌سرعت و به آسانی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه نظرات ارائه را با Aspose.Slides برای C++ مدیریت کنیم. انواع اصلی مرتبط با نظر معرفی می‌شوند و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها و نظرات مدرن، و حذف نظرات از یک ارائه نشان داده می‌شود.

مثال‌ها سناریوهای رایج بازبینی و همکاری در PowerPoint را پوشش می‌دهند، مانند اختصاص نظرات به نویسندگان، خواندن متن نظر و داده‌های متا، ساخت زنجیره پاسخ‌ها، و حذف نظرات انتخاب‌شده یا تمام نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن آن و بحث مرتبط را نمایش می‌دهد.

برای درخواست نمایش یا پنهان‌کردن نظرات هنگام باز کردن یک ارائه بدون تغییر در خود نظرات، به [نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه](/slides/fa/cpp/presentation-view-properties/) مراجعه کنید.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام مرور ارائه‌ها استفاده کنید.

Aspose.Slides برای C++ APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* رابط [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) که نظرات مربوط به یک نویسنده فردی را نشان می‌دهد.
* رابط [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) که اطلاعاتی درباره یک نظر، از جمله نویسنده، زمان ایجاد، موقعیت و متن را فراهم می‌کند.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده، شامل نام، نام‌مستعار و نظرات مرتبط را ارائه می‌دهد.

## **افزودن نظرات به اسلاید**

این مثال دو اسلاید ایجاد می‌کند و یک نویسنده نظر را با [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) ثبت می‌کند. سپس با استفاده از [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) یک نظر روی هر اسلاید قرار می‌دهد، سپس نظرات اولین اسلاید را برای آن نویسنده با [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) بازیابی می‌کند. کنسول متن اولین نظر را دو بار نمایش می‌دهد، که دسترسی از طریق اسلاید و نویسنده هر دو نشان داده می‌شود، و ارائه ذخیره‌شده شامل هر دو نظر است.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **یافتن یا ایجاد نویسنده نظر**

هنگامی که یک بازبینی خودکار به‌طور مکرر همان ارائه را پردازش می‌کند، قبل از افزودن نویسنده، مجموعه‌ای که توسط [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) برگردانده می‌شود را جستجو کنید. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) هم نام و هم نام‌مستعار را مطابقت می‌دهد و آرایه‌ای از نویسندگان منطبق را بر می‌گرداند، یا آرایه خالی اگر مطابقتی وجود نداشته باشد. در مقابل، [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) تنها بر اساس نام جستجو می‌کند، بدون در نظر گرفتن نام‌مستعار. صدا زدن [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) با نام و نام‌مستعاری که قبلاً در مجموعه وجود دارد، استثنا پرتاب می‌کند.

این مثال به یک فایل ارائه با حداقل یک اسلاید نیاز دارد. در هر دو عبور، نویسنده منطبق اولین بار را مجدداً استفاده می‌کند، یا فقط وقتی نتیجه خالی باشد، یکی را ایجاد می‌کند. اگر چندین مطابقت وجود داشته باشد، عنصر اول آرایه را بدون ترکیب یا حذف نویسندگان دیگر انتخاب می‌کند. سپس برای نویسنده منتخب با [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) فراخوانی می‌کند و ارائه را ذخیره می‌کند. عبور دوم خروجی عبور اول را باز می‌کند و عملیات را تکرار می‌کند.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

عبور دوم نظر دیگری اضافه می‌کند بدون افزودن نویسنده دیگر یا حذف نظرات موجود. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را همراه با هر نظر اصلی موجود شامل می‌شود. استفاده مجدد از یک نویسنده نظرات را تکراری نمی‌کند: برای جلوگیری از افزودن مکرر همان نظر، قبل از افزودن، تشخیص تکراری جداگانه‌ای پیاده‌سازی کنید.

## **دسترسی به نظرات اسلاید**

این مثال یک ارائه موجود را باز می‌کند و مجموعه‌ای که توسط [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) برگردانده می‌شود را می‌خواند. برای هر نویسنده، مجموعه‌ای که توسط [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) برگردانده می‌شود را پیمایش می‌کند و شماره اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائه ورودی باید حاوی نظرات باشد تا خروجی کنسول تولید شود.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتب پاسخ‌ها است. متدهای [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) و [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) از رابط [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) به شما امکان می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

این مثال نظراتی از دو نویسنده ایجاد می‌کند و با استفاده از [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) برای ساخت پاسخ‌ها، از جمله پاسخی به پاسخ دیگر، استفاده می‌کند. ارسال `nullptr` به [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) نظرات را از همه نویسندگان بازیابی می‌کند؛ کنسول هر ورودی را بر اساس عمق آن در سلسله‌مراتب پاسخ‌ها تورفتگی می‌زند. مثال بحث کامل را ذخیره می‌کند، بر روی اولین نظر ریشه‌ای متد [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) را صدا می‌زند، و یک ارائه دوم را با حذف آن نظر و پاسخ‌هایش ذخیره می‌کند.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* هنگام استفاده از متد [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) رابط [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) برای حذف یک نظر، همه پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر متد [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) یک ارجاع حلقه‌ای ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص، یا به یک بازه متنی داخل یک AutoShape مرتبط شوند. متد [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) علاوه بر اسلاید و مختصات علامت‌گذار نظر، یک آرگومان [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) می‌پذیرد.

زمانی که `nullptr` برای آرگومان شکل ارسال می‌شود، نظر یک نظر سطح اسلاید است. علامت‌گذار آن توسط مختصات ارائه‌شده موقعیت یابد، اما به شکل خاصی مرتبط نیست، بنابراین [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` برمی‌گرداند. وقتی یک [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت علامت‌گذار نظر را روی اسلاید تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

مثال دو بار [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) را فراخوانی می‌کند: یک بار با شکل `nullptr` برای یک نظر سطح اسلاید و یک بار با یک مستطیل به عنوان لنگر. فراخوانی [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) برای نظر سطح اسلاید `True` را برای بررسی null چاپ می‌کند و برای نظر لنگر شده `Revenue title` را چاپ می‌کند. هر دو نظر با ارائه ذخیره می‌شوند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **اتصال نظرات به انواع مختلف شکل**

هر شیء اسلایدی که رابط [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) را پیاده‌سازی کند می‌تواند به عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/)، و نمونه‌های [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) مانند نمودارها هستند.

مثال از [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) برای ارتباط یک نظر با هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک قاب تصویر، یک گروه، یک اتصال‌دهنده و یک نمودار. تصویر از داده‌های تصویر جاسازی‌شده استفاده می‌کند، بنابراین نیازی به تصویر خارجی نیست. هر نظر موقعیت علامت‌گذار خود را دارد و ارائه ذخیره‌شده تمام پنج ارتباط شکل را حفظ می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");

auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)، متدهای [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) و [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) موقعیت شروع متن انتخاب‌شده در فریم متنی شکل را کنترل می‌کنند. به‌طور مشابه، [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) و [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) طول انتخاب را کنترل می‌کنند. این متدها همراه با هم نظر را به یک بازه متنی خاص داخل AutoShape پیوند می‌دهند.

متدهای [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) و [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) از مقدار enum [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) استفاده می‌کنند:

- `NotDefined` — وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته است.

مثال یک نظر مدرن را به کلمات «quarterly revenue» در متن یک مستطیل متصل می‌کند. شروع انتخاب صفر‑محور را از متن محاسبه کرده و به [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) می‌فرستد و سپس با تعداد کاراکترهای انتخاب‌شده [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) را فراخوانی می‌کند. پس از صدا زدن [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) با `Resolved`، ارائه را ذخیره و باز می‌کند. چهار بررسی کنسول باید هر کدام `True` چاپ کنند، که تأیید می‌کند لنگر شکل، بازه متن و وضعیت نگه داشته شده‌اند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **بازرسی نظرات مدرن موجود**

این مثال به یک ارائه موجود حاوی نظرات مدرن نیاز دارد و متن، وضعیت و جزئیات لنگر آنها را چاپ می‌کند. برای بازرسی، بررسی کنید کدام نظرات رابط [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/) را پیاده‌سازی کرده‌اند، سپس به [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)، [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/)، [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) و [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) نگاه کنید. یک شکل `nullptr` نشان‌دهنده یک نظر سطح اسلاید است. برای یک لنگر [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)، متدهای انتخاب متن بازه مربوطه در فریم متنی شکل را شناسایی می‌کنند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **حذف نظرات**

Aspose.Slides برای C++ به شما امکان می‌دهد تمام نظرات و نویسندگان آنها را از یک ارائه حذف کنید یا نظرات انتخاب‌شده را حذف کنید در حالی که بقیه نگه داشته می‌شوند. مثال‌های زیر هر دو رویکرد را نشان می‌دهند و ارائه به‌روزرسانی‌شده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

مثال یک ارائه موجود را باز می‌کند و برای هر نویسنده متد [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) را صدا می‌زند، سپس متد [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) را برای حذف خود نویسندگان فراخوانی می‌کند. ارائه ذخیره‌شده نه نظرات و نه نویسندگان نظرات را دارد. برای مشاهده حذف، از یک ارائه حاوی نظرات استفاده کنید.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **حذف نظرات خاص**

مثال دو نظر روی یک اسلاید ایجاد می‌کند و از [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) برای یافتن نظرات هر نویسنده استفاده می‌کند. قبل از صدا زدن [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/)، نظراتی که متن آنها برابر با «comment 1» است جمع‌آوری می‌کند تا از تغییر مجموعه هنگام انتخاب جلوگیری شود. ارائه ذخیره‌شده فقط «comment 2» را نگه می‌دارد.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا Aspose.Slides از وضعیت حل‌شده برای نظرات مدرن پشتیبانی می‌کند؟**

بله. متدهای [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) و [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) از مقدار enum [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) استفاده می‌کنند، شامل `Resolved`. وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی مجدد فایل می‌توان آن را دوباره خواند.

**آیا بحث‌های رشته‌ای (زنجیره پاسخ‌ها) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) خود ارجاع دهد و زنجیره پاسخ‌ها را فعال می‌کند. API محدودیت عمق خاصی برای تو در تویی تعریف نمی‌کند.

**موقعیت علامت‌گذار یک نظر در اسلاید بر اساس چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت علامت‌گذار با مختصات شناور (floating‑point) در سیستم مختصات اسلاید تعریف می‌شود، که امکان قرار دادن دقیق آن بر روی اسلاید را می‌دهد.
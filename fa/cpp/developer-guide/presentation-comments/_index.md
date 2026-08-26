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
- پاک کردن نظر
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای C++ مدیریت کنید: افزودن، خواندن، ویرایش، پاسخ دادن و حذف نظرات در ارائه‌های PowerPoint به‌سرعت و به سادگی."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides for C++ مدیریت کنید. این مقاله انواع اصلی مرتبط با نظرات را معرفی می‌کند و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، نظرات موجود را دسترسی پیدا کنید، با پاسخ‌ها و نظرات مدرن کار کنید، و نظرات را از یک ارائه حذف کنید.

مثال‌ها سناریوهای رایج مرور و همکاری در PowerPoint را پوشش می‌دهند، مانند تخصیص نظرات به نویسندگان، خواندن متن نظر و داده‌های متا، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخابی یا تمام نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مرتبط با آن را نمایش می‌دهد.

## **چرا به ارائه‌ها نظرات اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام مرور ارائه‌ها استفاده کنید.

Aspose.Slides for C++ APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* اینترفیس [ICommentCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icommentcollection/) که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* اینترفیس [IComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن آن ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده شامل نام، حروف اول و نظرات مربوطه را فراهم می‌کند.

## **اضافه کردن نظرات به اسلاید**

مثال زیر نشان می‌دهد چگونه نظرات را به اسلایدهای یک ارائه PowerPoint اضافه کنید:

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

## **دسترسی به نظرات اسلاید**

مثال زیر نشان می‌دهد چگونه به نظرات موجود در یک ارائه PowerPoint دسترسی پیدا کنید:

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

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتب پاسخ است. متدهای [get_ParentComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/get_parentcomment/) و [set_ParentComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/set_parentcomment/) از اینترفیس [IComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/) به شما امکان می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

مثال زیر نشان می‌دهد چگونه پاسخ‌ها را اضافه کرده و سلسله‌مراتب نتیجه‌گیری شدهٔ نظرات را بررسی کنید:

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

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
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

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* هنگام استفاده از متد [Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/remove/) از اینترفیس [IComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/) برای حذف یک نظر، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر متد [set_ParentComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/set_parentcomment/) یک مرجع چرخشی ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **اضافه کردن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به یک بازهٔ متنی داخل AutoShape مرتبط شوند. متد [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icommentcollection/addmoderncomment/) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) دریافت می‌کند.

هنگامی که `nullptr` برای پارامتر shape ارسال شود، نظر یک نظر سطح‑اسلاید است. نشانگر آن با مختصات ارائه شده موقعیت می‌یابد، اما به شکل خاصی مرتبط نیست، لذا [IModernComment::get_Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_shape/) مقدار `nullptr` برمی‌گرداند. هنگامی که یک [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر را بر روی اسلاید تعریف می‌کنند، در حالی که ارتباط شکل می‌تواند از طریق [IModernComment::get_Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_shape/) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

مثال زیر هم یک نظر مدرن سطح‑اسلاید و هم یک نظر مدرن متصل به یک AutoShape خاص ایجاد می‌کند. سپس شکل مرتبط با هر نظر را می‌خواند.

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

### **اتصال نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که اینترفیس [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را پیاده‌سازی کند، می‌تواند به‌عنوان نقطهٔ اتصال شکل استفاده شود. نمونه‌های رایج شامل [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iconnector/) و نمونه‌های [IGraphicalObject](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igraphicalobject/) مانند چارت‌ها هستند.

مثال زیر چند نوع شکل رایج ایجاد می‌کند و یک نظر مدرن را با هرکدام مرتبط می‌سازد.

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

### **اتصال نظر به متن و تعیین وضعیت آن**

برای یک نظر مدرن مرتبط با یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/)، متدهای [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_textselectionstart/) و [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/set_textselectionstart/) موقعیت شروع متن منتخب در فریم متنی شکل را کنترل می‌کنند. به‌طور مشابه، متدهای [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_textselectionlength/) و [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/set_textselectionlength/) طول انتخاب را تعیین می‌نمایند. این متدها با هم نظر را به بازهٔ متنی خاصی داخل AutoShape مرتبط می‌کنند.

متدهای [IModernComment::get_Status](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_status/) و [IModernComment::set_Status](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/set_status/) از یک مقدار در شمارندهٔ [ModernCommentStatus](https://reference.aspose.com/slides/fa/cpp/aspose.slides/moderncommentstatus/) استفاده می‌کنند:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته شده است.

مثال زیر یک نظر مدرن متصل به شکل ایجاد می‌کند، آن را به یک انتخاب متنی مرتبط می‌سازد، به‌عنوان حل شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌کند و پس از باز کردن مجدد فایل مقادیر را تأیید می‌کند.

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

### **بررسی نظرات مدرن موجود**

برای بررسی یک ارائه موجود، ابتدا بررسی کنید کدام نظرات اینترفیس [IModernComment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/) را پیاده‌سازی کرده‌اند، سپس به [IModernComment::get_Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_shape/)، [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_textselectionstart/)، [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_textselectionlength/) و [IModernComment::get_Status](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_status/) نگاه کنید. یک shape برابر `nullptr` نشان‌دهندهٔ یک نظر سطح‑اسلاید است. برای یک اتصال [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) ، متدهای انتخاب متن بازهٔ مرتبط در فریم متنی شکل را شناسایی می‌کنند.

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

### **حذف تمام نظرات و نویسندگان نظرات**

مثال زیر نشان می‌دهد چگونه تمام نظرات و نویسندگان نظرات را از یک ارائه حذف کنید:

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

مثال زیر نشان می‌دهد چگونه نظرات خاصی را از یک اسلاید حذف کنید:

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

**آیا Aspose.Slides از وضعیت حل شده برای نظرات مدرن پشتیبانی می‌کند؟**

بله. متدهای [IModernComment::get_Status](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/get_status/) و [IModernComment::set_Status](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imoderncomment/set_status/) از یک مقدار [ModernCommentStatus](https://reference.aspose.com/slides/fa/cpp/aspose.slides/moderncommentstatus/) استفاده می‌کنند که شامل `Resolved` می‌شود. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشت فایل می‌تواند مجدداً خوانده شود.

**آیا بحث‌های زنجیره‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icomment/set_parentcomment/) خود ارجاع دهد و امکان ایجاد زنجیره‌های پاسخ را فراهم می‌کند. API محدودیت خاصی برای عمق تو در تو تعریف نمی‌کند.

**موقعیت نشانگر نظر در اسلاید بر پایهٔ چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر با مختصات اعشاری در سیستم مختصات اسلاید تعریف می‌شود که امکان قرار دادن دقیق آن روی اسلاید را می‌دهد.
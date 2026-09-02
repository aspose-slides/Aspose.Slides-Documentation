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
- پاک کردن نظر
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای .NET: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های PowerPoint به‌سرعت و به‌راحتی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides برای .NET مدیریت کنید. انواع اصلی مربوط به نظرات را معرفی می‌کند و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، نظرات موجود را دسترسی داشته باشید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

مثال‌ها شامل سناریوهای رایج بررسی و همکاری در PowerPoint می‌شود، مانند اختصاص نظرات به نویسندگان، خواندن متن نظر و متادیتا، ساخت زنجیره‌های پاسخ و حذف نظرات انتخابی یا تمام نظرات.

در PowerPoint، نظرات به‌صورت حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن آن و بحث مرتبط را نشان می‌دهد.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بررسی ارائه‌ها استفاده کنید.

Aspose.Slides برای .NET APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* رابط [ICommentCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icommentcollection) که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* رابط [IComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment) که اطلاعاتی درباره یک نظر، شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/net/aspose.slides/commentauthor) که اطلاعاتی درباره یک نویسنده، شامل نام، حروف اولیه و نظرات مرتبط را فراهم می‌کند.

## **Add Slide Comments**
مثال زیر نشان می‌دهد چگونه به اسلایدهای یک ارائه PowerPoint نظرات اضافه کنید:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **دسترسی به نظرات اسلاید**
مثال زیر نشان می‌دهد چگونه به نظرات موجود در یک ارائه PowerPoint دسترسی پیدا کنید:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **Reply to Comments**
یک نظر والد، نظر اصلی در بالای سلسله‌مراتب پاسخ‌ها است. ویژگی [ParentComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment/properties/parentcomment) رابط [IComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment) به شما اجازه می‌دهد والد نظر را دریافت یا تنظیم کنید.

مثال زیر نشان می‌دهد چگونه پاسخ‌ها را اضافه کنید و سلسله‌مراتب نظرات حاصل را بررسی کنید:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* وقتی متد [Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment/methods/remove) رابط [IComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر ویژگی [ParentComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icomment/properties/parentcomment) یک اشاره‌دوره‌ای ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception) پرتاب می‌شود.

{{% /alert %}}

## **Add Modern Comments**
نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به یک بازه متنی داخل یک AutoShape مرتبط شوند. متد [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/fa/net/aspose.slides/icommentcollection/addmoderncomment/) یک آرگومان [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را علاوه بر اسلاید و مختصات نشانگر نظر می‌پذیرد.

زمانی که برای آرگومان shape مقدار `null` پاس می‌شود، نظر به‌صورت نظر سطح اسلاید است. نشانگر آن توسط مختصات ارائه شده موقعیت می‌گیرد، اما به شکل خاصی مرتبط نیست، بنابراین [IModernComment.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/shape/) مقدار `null` برمی‌گرداند. وقتی یک [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) ارائه شود، نظر به آن شکل پیوست می‌شود. مختصات همچنان موقعیت نشانگر نظر را روی اسلاید تعیین می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [IModernComment.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/shape/) بازیابی شود.

### **پیوست کردن یک نظر مدرن به یک شکل**
مثال زیر یک نظر مدرن در سطح اسلاید و یک نظر مدرن پیوست شده به یک AutoShape خاص ایجاد می‌کند. سپس شکل مرتبط با هر نظر را می‌خواند.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **پیوست کردن نظرات به انواع مختلف شکل‌ها**
هر شیء اسلایدی که رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را پیاده‌سازی کند می‌تواند به‌عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/fa/net/aspose.slides/iconnector/)، و نمونه‌های [IGraphicalObject](https://reference.aspose.com/slides/fa/net/aspose.slides/igraphicalobject/) مانند نمودارها است.

مثال زیر چند نوع شکل رایج ایجاد می‌کند و یک نظر مدرن را به هر یک از آنها پیوست می‌کند.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";
var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **پیوست کردن یک نظر به متن و تنظیم وضعیت آن**
برای یک نظر مدرن که به یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) مرتبط است، [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/textselectionstart/) موقعیت شروع متن انتخاب شده در فریم متنی شکل را مشخص می‌کند، در حالی که [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/textselectionlength/) طول انتخاب را تعیین می‌کند. این دو ویژگی با هم نظر را به بازه متنی خاصی داخل AutoShape مرتبط می‌سازند.

ویژگی [IModernComment.Status](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/status/) می‌تواند خوانده یا با مقداری از enumeration [ModernCommentStatus](https://reference.aspose.com/slides/fa/net/aspose.slides/moderncommentstatus/) به‌روزرسانی شود:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته شده است.

مثال زیر یک نظر مدرن پیوست شده به شکل ایجاد می‌کند، آن را به یک انتخاب متنی پیوست می‌نماید، به عنوان حل شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌کند و پس از بازکردن مجدد فایل مقادیر را تأیید می‌کند.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **بررسی نظرات مدرن موجود**
برای بررسی یک ارائه موجود، بررسی کنید کدام نظرات رابط [IModernComment](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/) را پیاده‌سازی می‌کنند، سپس [IModernComment.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/shape/)، [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/textselectionstart/)، [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/textselectionlength/)، و [IModernComment.Status](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/status/) را بررسی کنید. یک شکل `null` نشان‌دهنده نظر سطح اسلاید است. برای لنگر [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) ویژگی‌های انتخاب متن بازه مرتبط در فریم متنی شکل را شناسایی می‌کنند.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **Remove Comments**
### **حذف همه نظرات و نویسندگان نظرات**
مثال زیر نشان می‌دهد چگونه همه نظرات و نویسندگان نظرات را از یک ارائه حذف کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();
presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **حذف نظرات خاص**
مثال زیر نشان می‌دهد چگونه نظرات خاص را از یک اسلاید حذف کنید:

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **FAQ**
**آیا Aspose.Slides وضعیت حل شده برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. ویژگی [IModernComment.Status](https://reference.aspose.com/slides/fa/net/aspose.slides/imoderncomment/status/) می‌تواند خوانده و با مقدار از enumeration [ModernCommentStatus](https://reference.aspose.com/slides/fa/net/aspose.slides/moderncommentstatus/) تنظیم شود، از جمله `Resolved`. وضعیت در ارائه ذخیره می‌شود و پس از باز کردن مجدد فایل قابل خواندن است.

**آیا بحث‌های سلسله‌مراتبی (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/net/aspose.slides/comment/parentcomment/) خود ارجاع دهد، که زنجیره‌های پاسخ را امکان‌پذیر می‌سازد. API محدودیت خاصی برای عمق تو در تو تعریف نشده است.

**موقعیت نشانگر نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر با مختصات عددی شناور در سیستم مختصات اسلاید تعریف می‌شود، که به شما امکان می‌دهد آن را دقیقاً روی اسلاید قرار دهید.
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
description: "نظرات ارائه را با Aspose.Slides برای .NET مدیریت کنید: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های PowerPoint به‌سرعت و به‌راحتی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides برای .NET مدیریت کنید. این مقاله انواع اصلی مرتبط با نظرات را معرفی می‌کند و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها و نظرات مدرن، و حذف نظرات از یک ارائه را نشان می‌دهد.

مثال‌ها سناریوهای رایج بررسی و همکاری در PowerPoint را پوشش می‌دهند، مانند اختصاص نظرات به نویسندگان، خواندن متن نظر و فراداده‌ها، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخاب شده یا همه نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مرتبط با آن را نمایش می‌دهد.

برای درخواست نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه بدون تغییر در خود نظرات، ببینید [نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه](/slides/fa/net/presentation-view-properties/).

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بررسی ارائه‌ها استفاده کنید.

Aspose.Slides برای .NET APIهای زیر را برای کار با نظرات ارائه می‌دهد:

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) class, which provides information about an author, including their name, initials, and associated comments.

## **افزودن نظرات به اسلاید**

مثال دو اسلاید ایجاد می‌کند و یک نویسنده نظر را با [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) ثبت می‌کند. از [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) برای قرار دادن یک نظر روی هر اسلاید استفاده می‌شود، سپس نظرات اسلاید اول برای آن نویسنده با [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) بازیابی می‌شود. کنسول متن اولین نظر را دو بار نمایش می‌دهد، دسترسی از طریق اسلاید و نویسنده را نشان می‌دهد و ارائه ذخیره‌شده هر دو نظر را شامل می‌شود.

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

## **یافتن یا ایجاد نویسندهٔ نظر**

هنگامی که یک بررسی خودکار به‌طور مکرر همان ارائه را پردازش می‌کند، قبل از افزودن یک نویسنده، مجموعه [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) آن را جستجو کنید. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) هم نام و هم حروف ابتدایی را مطابقت می‌دهد و آرایه‌ای از نویسندگان مطابقت‌داده‌شده بر می‌گرداند یا آرایه خالی اگر هیچ‌کدام وجود نداشته باشند. در مقابل، [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) فقط بر اساس نام جستجو می‌کند، صرف‌نظر از حروف ابتدایی. فراخوانی [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) با نام و حروف ابتدایی که از پیش در مجموعه موجود است، استثنا پرتاب می‌کند.

مثال به فایلی از ارائه با حداقل یک اسلاید نیاز دارد. در هر یک از دو گذر، نویسندهٔ اولین مطابقت‌شده را مجدداً استفاده می‌کند یا فقط وقتی نتایج خالی باشد یک نویسنده جدید می‌سازد. اگر چندین مطابقت وجود داشته باشد، اولین عنصر آرایه را بدون ترکیب یا حذف سایر نویسندگان انتخاب می‌کند. سپس برای نویسندهٔ انتخاب‌شده [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) را فراخوانی می‌کند و ارائه را ذخیره می‌کند. گذر دوم خروجی گذر اول را باز کرده و عمل را تکرار می‌کند.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

گذر دوم نظریه‌ای دیگر اضافه می‌کند بدون افزودن نویسندهٔ دیگر یا حذف نظرات موجود. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را به همراه هر نظر اصلی دیگر شامل می‌شود. استفاده مجدد از یک نویسنده تکراری‌سازی نظرات را انجام نمی‌دهد: برای جلوگیری از افزودن مکرر همان نظر، قبل از افزودن آن، تشخیص تکراری جداگانه‌ای پیاده‌سازی کنید.

## **دسترسی به نظرات اسلاید**

مثال یک ارائه موجود را باز می‌کند و مجموعه [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) آن را می‌خواند. برای هر نویسنده، از طریق [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) تکرار می‌کند و شماره اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائه ورودی باید شامل نظرات باشد تا خروجی کنسول تولید شود.

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

## **پاسخ به نظرات**

یک نظر پدر، نظر اصلی در بالای سلسله‌مراتبی پاسخ‌هاست. ویژگی [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) واسط [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) به شما امکان می‌دهد والد یک نظر را دریافت یا تنظیم کنید.

مثال نظراتی از دو نویسنده ایجاد می‌کند و از [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) برای ساخت پاسخ‌ها، از جمله پاسخی به یک پاسخ دیگر، استفاده می‌کند. عبور `null` به [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) نظرات همه نویسندگان را بازیابی می‌کند؛ کنسول هر ورودی را بر اساس عمق در سلسله‌مراتبی پاسخ‌ها تورفتگی می‌دهد. مثال بحث کامل را ذخیره می‌کند، بر روی اولین نظر ریشه [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) را فراخوانی می‌کند و ارائهٔ دوم را با حذف آن نظر و پاسخ‌هایش ذخیره می‌کند.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

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

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* هنگامی که متد [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) واسط [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نیز حذف می‌گردند.
* اگر ویژگی [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) مرجعی دایره‌ای ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به بازهٔ متنی داخل یک AutoShape پیوست شوند. متد [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) می‌پذیرد.

هنگامی که `null` برای آرگومان شکل پاس داده شود، نظر یک نظر سطح اسلاید است. نشانگر آن توسط مختصات ارائه‌شده موقعیت‌گذاری می‌شود، اما به شکل خاصی پیوست نیست، بنابراین [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) `null` برمی‌گرداند. زمانی که یک [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ارائه شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر بر روی اسلاید را تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

مثال دو بار [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) را فراخوانی می‌کند: یک بار با شکل `null` برای نظر سطح اسلاید و یک بار با یک مستطیل به‌عنوان لنگر. خواندن [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) برای نظر سطح اسلاید مقدار `True` را برای بررسی `null` و برای نظر لنگر شده مقدار `Revenue title` چاپ می‌کند. هر دو نظر با ارائه ذخیره می‌شوند.

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

### **اتصال نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که واسط [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را پیاده‌سازی کند می‌تواند به‌عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) و نمونه‌های [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) مانند نمودارها هستند.

مثال از [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) برای پیوست یک نظر به هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک چارچوب تصویر، یک گروه، یک کانکتور و یک نمودار. تصویر داخل چارچوب به‌صورت تعبیه‌شده است، بنابراین نیازی به تصویر خارجی نیست. هر نظر موقعیت نشانگر مخصوص به خود را دارد و ارائهٔ ذخیره‌شده تمام پنج ارتباط شکل را حفظ می‌کند.

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

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن که به یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) متصل است، ویژگی [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) موقعیت شروع متن انتخاب‌شده در فریم متنی شکل را مشخص می‌کند، در حالی که [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) طول انتخاب را تعیین می‌کند. با هم این ویژگی‌ها نظر را به بازهٔ متنی خاصی داخل AutoShape پیوست می‌کنند.

ویژگی [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) می‌تواند با مقدار از شمارش‌گر [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) خوانده یا به‌روزرسانی شود:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل و فصل شده است.
- `Closed` — نظر بسته است.

مثال یک نظر مدرن را به کلمات «quarterly revenue» در متن یک مستطیل لنگر می‌دهد. مقدار [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) را بر پایهٔ صفر از متن محاسبه می‌کند و [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) را به تعداد کاراکترهای انتخابی تنظیم می‌کند. پس از تنظیم [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) به `Resolved`، ارائه را ذخیره و دوباره باز می‌کند. چهار بررسی کنسول باید هر کدام `True` چاپ کنند، تأیید می‌کند که لنگر شکل، بازهٔ متن و وضعیت حفظ شده‌اند.

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

مثال به ارائه‌ای موجود که شامل نظرات مدرن است نیاز دارد و متن، وضعیت و جزئیات لنگر آن‌ها را چاپ می‌کند. برای بررسی، ابتدا بررسی کنید که کدام نظرات واسط [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) را پیاده‌سازی می‌کنند، سپس به [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/)، [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/)، [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) و [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) نگاه کنید. یک شکل `null` نشان‌دهندهٔ نظر سطح اسلاید است. برای لنگر [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ویژگی‌های انتخاب متن بازهٔ متن مربوطه در فریم متنی شکل را شناسایی می‌کند.

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

## **حذف نظرات**

Aspose.Slides برای .NET به شما امکان می‌دهد تمام نظرات و نویسندگان آن‌ها را از یک ارائه حذف کنید یا نظرات انتخابی را حذف کنید و بقیه را حفظ کنید. مثال‌های زیر هر دو رویکرد را نشان می‌دهند و ارائه به‌روز‌شده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

مثال یک ارائه موجود را باز می‌کند و برای هر نویسنده [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) را فراخوانی می‌کند، سپس [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) را برای حذف خود نویسندگان صدا می‌کند. ارائه ذخیره‌شده نه نظرات و نه نویسندگان نظرات را شامل نمی‌شود. برای مشاهده حذف، از ارائه‌ای که شامل نظرات است استفاده کنید.

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

مثال دو نظر در یک اسلاید ایجاد می‌کند و از [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) برای یافتن نظرات هر نویسنده استفاده می‌کند. نظراتی که متن آن‌ها برابر با «comment 1» است جمع‌آوری می‌کند قبل از فراخوانی [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/)، تا از تغییر مجموعه در طول انتخاب جلوگیری کند. ارائه ذخیره‌شده فقط «comment 2» را نگه می‌دارد.

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

## **پرسش‌های متداول**

**آیا Aspose.Slides برای نظرات مدرن وضعیت حل و فصل شده را پشتیبانی می‌کند؟**

بله. ویژگی [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) می‌تواند با مقدار از شمارش‌گر [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) خوانده و تنظیم شود، از جمله `Resolved`. این وضعیت در ارائه ذخیره می‌شود و پس از بازکردن مجدد فایل می‌تواند دوباره خوانده شود.

**آیا بحث‌های زنجیره‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در تو وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) خود ارجاع دهد و زنجیره‌های پاسخ را فعال می‌کند. API محدودیت عمق خاصی تعریف نکرده است.

**موقعیت نشانگر نظر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر با مختصات نقطه‌ای شناور در سیستم مختصات اسلاید تعریف می‌شود، که به شما امکان می‌دهد آن را دقیقاً بر روی اسلاید قرار دهید.
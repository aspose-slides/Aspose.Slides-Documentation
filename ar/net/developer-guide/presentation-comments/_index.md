---
title: إدارة تعليقات العرض التقديمي في .NET
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/net/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى تعليق
- تعديل تعليق
- الرد على تعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides for .NET: إضافة، قراءة، تعديل، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides for .NET. تُقدِّم الأنواع الرئيسية المتعلقة بالتعليقات وتوضح كيفية إضافة تعليقات إلى الشرائح، الوصول إلى التعليقات الموجودة، العمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتوّئات على الشرائح. عند تحديد تعليق يتم عرض نصه والنقاش المرتبط به.

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم ملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides for .NET واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) التي توفر الوصول إلى مؤلفي التعليقات في العرض.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icommentcollection) التي تمثِّل التعليقات المرتبطة بمؤلف فردي.
* الواجهة [IComment](https://reference.aspose.com/slides/ar/net/aspose.slides/icomment) التي توفر معلومات حول التعليق، بما في ذلك المؤلف، وقت الإنشاء، الموضع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/ar/net/aspose.slides/commentauthor) التي توفر معلومات حول المؤلف، بما في ذلك اسمه، الأحرف الأولية، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**
المثال التالي يُظهر كيفية إضافة تعليقات إلى الشرائح في عرض PowerPoint:

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

## **الوصول إلى تعليقات الشرائح**
المثال التالي يُظهر كيفية الوصول إلى التعليقات الموجودة في عرض PowerPoint:

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

## **الرد على التعليقات**
التعليق الأصل هو التعليق الأساسي في أعلى تسلسل الردود. خاصية [ParentComment](https://reference.aspose.com/slides/ar/net/aspose.slides/icomment/properties/parentcomment) في الواجهة [IComment](https://reference.aspose.com/slides/ar/net/aspose.slides/icomment) تتيح لك الحصول على التعليق الأصلي أو تعيينه.

المثال التالي يُظهر كيفية إضافة ردود وفحص هيكل التعليقات الناتج:

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

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/icomment/methods/remove) في الواجهة [IComment](https://reference.aspose.com/slides/ar/net/aspose.slides/icomment) لحذف تعليق، يتم حذف جميع الردود على ذلك التعليق أيضاً.
* إذا تسببت خاصية [ParentComment](https://reference.aspose.com/slides/ar/net/aspose.slides/icomment/properties/parentcomment) في إنشاء إشارة دائرية، سيتم إطلاق استثناء [PptxEditException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشرائح نفسها، أو بشكل محدد، أو بنطاق نص داخل AutoShape. طريقة [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/ar/net/aspose.slides/icommentcollection/addmoderncomment/) تقبل وسيطًا من نوع [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) بالإضافة إلى إحداثيات الشريحة وعلامة التعليق.

عند تمرير `null` كقيمة للوسيطة shape، يكون التعليق تعليقًا على مستوى الشريحة. يتم تحديد موضع العلامة بالإحداثيات المقدمة، لكنه غير مرتبط بشكل محدد بأي شكل، لذلك تُعيد [IModernComment.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/shape/) القيمة `null`. عندما يتم توفير كائن [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، يتم ربط التعليق بهذا الشكل. لا تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، بينما يمكن استرداد ربط الشكل عبر [IModernComment.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/shape/).

### **تثبيت تعليق حديث على شكل**

المثال التالي ينشئ كلًا من تعليق حديث على مستوى الشريحة وتعليق حديث مثبت على AutoShape محدد. ثم يقرأ الشكل المرتبط بكل تعليق.

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

### **تثبيت التعليقات على أنواع أشكال مختلفة**

أي كائن شريحة يطبق الواجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) يمكن استخدامه كمرساة للشكل. تشمل الأمثلة الشائعة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/ar/net/aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/ar/net/aspose.slides/iconnector/)، وحالات [IGraphicalObject](https://reference.aspose.com/slides/ar/net/aspose.slides/igraphicalobject/) مثل المخططات.

المثال التالي ينشئ عدة أنواع أشكال شائعة ويربط كلًا منها بتعليق حديث.

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

### **تثبيت تعليق على نص وتعيين حالته**

للتعليق الحديث المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/)، تحدد خاصية [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/textselectionstart/) موضع البداية للنص المحدد في إطار النص الخاص بالشكل، بينما تحدد خاصية [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/textselectionlength/) طول التحديد. معًا، تربط هذه الخصائص التعليق بنطاق نص محدد داخل AutoShape.

يمكن قراءة أو تحديث خاصية [IModernComment.Status](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/status/) باستخدام قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/ar/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — لا توجد حالة محددة للتعليق الحديث.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

المثال التالي ينشئ تعليقًا حديثًا مثبتًا على شكل، يربطه بتحديد نص، يحدد حالته كـ "تم الحل"، يحفظ العرض التقديمي، ويتحقق من القيم بعد إعادة فتح الملف.

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

### **فحص التعليقات الحديثة الموجودة**

لفحص عرض تقديمي موجود، تحقق من التعليقات التي تنفّذ الواجهة [IModernComment](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/)، ثم استعرض [IModernComment.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/shape/)، [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/textselectionstart/)، [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/textselectionlength/)، و[IModernComment.Status](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/status/). يشير الشكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/)، تحدد خصائص تحديد النص النطاق المرتبط في إطار نص الشكل.

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

## **إزالة التعليقات**

### **إزالة جميع التعليقات ومؤلفي التعليقات**

المثال التالي يُظهر كيفية إزالة جميع التعليقات ومؤلفي التعليقات من العرض:

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

### **إزالة تعليقات محددة**

المثال التالي يُظهر كيفية إزالة تعليقات محددة من شريحة:

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

## **الأسئلة الشائعة**

**هل تدعم Aspose.Slides حالة "تم الحل" للتعليقات الحديثة؟**

نعم. يمكن قراءة وتعيين [IModernComment.Status](https://reference.aspose.com/slides/ar/net/aspose.slides/imoderncomment/status/) باستخدام قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/ar/net/aspose.slides/moderncommentstatus/)، بما في ذلك `Resolved`. تُخزن الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/ar/net/aspose.slides/comment/parentcomment/)، مما يتيح سلاسل الردود. لا تحدد الواجهة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موقع علامة التعليق على الشريحة؟**

يتم تعريف موضع العلامة بإحداثيات ذات نقطة عائمة في نظام إحداثيات الشريحة، مما يسمح بوضعها بدقة على الشريحة.
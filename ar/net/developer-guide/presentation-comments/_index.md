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
- تحرير تعليق
- رد على تعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides لـ .NET: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

يشرح هذا المقال كيفية إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides لـ .NET. يقدم الأنواع الرئيسية المتعلقة بالتعليقات ويوضح كيفية إضافة تعليقات إلى الشرائح، الوصول إلى التعليقات الموجودة، التعامل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتعليقات توضيحية على الشرائح. عند تحديد تعليق يتم عرض نصه والنقاش المرتبط به.

للطلب عرض أو إخفاء التعليقات عند فتح عرض تقديمي دون تغيير التعليقات نفسها، انظر [إظهار أو إخفاء التعليقات عند فتح عرض تقديمي](/slides/ar/net/presentation-view-properties/).

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم الملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

يوفر Aspose.Slides لـ .NET واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي توفر الوصول إلى مؤلفي تعليقات العرض التقديمي.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) التي تمثل التعليقات المرتبطة بمؤلف واحد.
* الواجهة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) التي توفر معلومات حول التعليق، بما في ذلك المؤلف، وقت الإنشاء، الموقع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) التي توفر معلومات عن المؤلف، بما في ذلك اسمه، الأحرف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

يقوم المثال بإنشاء شريحتين ويسجل مؤلف تعليق باستخدام [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). يستخدم [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) لوضع تعليق واحد على كل شريحة، ثم يسترجع تعليقات الشريحة الأولى لهذا المؤلف باستخدام [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). يعرض وحدة التحكم نص التعليق الأول مرتين، مما يوضح الوصول عبر كل من الشريحة والمؤلف، ويحتوي العرض التقديمي المحفوظ على كلا التعليقين.

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

## **البحث عن مؤلف تعليق أو إنشاؤه**

عند قيام مراجعة آلية بمعالجة نفس العرض التقديمي بشكل متكرر، ابحث في مجموعة [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) قبل إضافة مؤلف. يطابق [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) كلًا من الاسم والأحرف الأولى ويعيد مصفوفة من المؤلفين المطابقين، أو مصفوفة فارغة إذا لم توجد مطابقات. بالمقابل، يبحث [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) بالاسم فقط بغض النظر عن الأحرف الأولى. استدعاء [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) باسم وأحرف أولية موجودة بالفعل في المجموعة يؤدي إلى إلقاء استثناء.

يتطلب المثال ملف عرض تقديمي يحتوي على شريحة واحدة على الأقل. في كل من المرورين، يعيد استخدام أول مؤلف مطابق، أو ينشئ واحدًا فقط عندما تكون النتيجة فارغة. إذا كان هناك عدة مطابقة، يختار العنصر الأول من المصفوفة دون دمج أو إزالة المؤلفين الآخرين. ثم يستدعي [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) للمؤلف المحدد ويحفظ العرض التقديمي. يفتح المرور الثاني مخرجات المرور الأول ويكرر العملية.

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

يضيف المرور الثاني تعليقًا آخر دون إضافة مؤلف آخر أو إزالة التعليقات الموجودة. يحتوي الملف النهائي، `review_pass_2.pptx`، على كلا التعليقين الجديدين جنبًا إلى جنب مع أي تعليقات أصلية. إعادة استخدام مؤلف لا يزيل التكرار في التعليقات: لتجنب إضافة نفس التعليق مرارًا، نفذ كشفًا منفصلًا للتكرارات قبل إضافته.

## **الوصول إلى تعليقات الشرائح**

يفتح المثال عرضًا تقديميًا موجودًا ويقرأ مجموعة [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). لكل مؤلف، يتنقل عبر [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) ويطبع رقم الشريحة، نص التعليق، اسم المؤلف، ووقت الإنشاء. يجب أن يحتوي عرض الإدخال على تعليقات لإنتاج مخرجات وحدة التحكم.

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

التعليق الأصلي هو التعليق الأصلي في أعلى هيكل الردود. تسمح خاصية [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) في واجهة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) لك بالحصول على أو تعيين الأصل للتعليق.

يقوم المثال بإنشاء تعليقات من مؤلفين اثنين ويستخدم [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) لبناء الردود، بما في ذلك رد على رد آخر. تمرير `null` إلى [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) يسترجع التعليقات من جميع المؤلفين؛ تقوم وحدة التحكم بترك مسافة بادئة لكل إدخال وفقًا لعمقه في هيكل الردود. يحفظ المثال النقاش الكامل، يستدعي [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) على أول تعليق جذري، ويحفظ عرضًا تقديميًا ثانيًا مع إزالة ذلك التعليق والردود المرتبطة به.

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
* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) في واجهة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) لحذف تعليق، يتم حذف جميع الردود على ذلك التعليق أيضًا.
* إذا أنشأت خاصية [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) مرجعًا دائريًا، يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشفرة نفسها، أو بشكل محدد، أو بنطاق نص داخل AutoShape. تقبل الطريقة [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) معاملًا من نوع [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) بالإضافة إلى إحداثيات الشريحة وعلامة التعليق.

عند تمرير `null` كمعامل الشكل، يكون التعليق تعليقًا على مستوى الشريحة. يتم وضع العلامة بواسطة الإحداثيات المقدمة، لكنه غير مرتبط بأي شكل معين، لذلك تُعيد [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) القيمة `null`. عندما يتم توفير [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)، يتم تثبيت التعليق على ذلك الشكل. لا تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، بينما يمكن استرجاع ارتباط الشكل من خلال [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **تثبيت تعليق حديث على شكل**

يستدعي المثال [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) مرتين: مرةً مع شكل `null` لتعليق على مستوى الشريحة ومرةً أخرى مع مستطيل كمرساة. قراءة [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) تطبع `True` للتحقق من null لتعليق مستوى الشريحة و`Revenue title` للتعليق المثبت. يتم حفظ كلا التعليقين مع العرض التقديمي.

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

يمكن استخدام أي كائن شريحة يطبق [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) كمرساة للشكل. تشمل الأمثلة الشائعة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), و[IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) مثل المخططات.

يستخدم المثال [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) لربط تعليق مع كل من خمسة أنواع من الأشكال: AutoShape، إطار صورة، مجموعة، موصل، ومخطط. تستخدم الصورة بيانات صورة مدمجة، لذا لا يلزم صورة خارجية. لكل تعليق موقع علامته الخاص، ويحافظ العرض التقديمي المحفوظ على جميع ارتباطات الأشكال الخمسة.

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

في تعليق حديث مرتبط بـ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), تحدد [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) موضع البداية للنص المحدد في إطار نص الشكل، بينما تحدد [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) طول التحديد. معًا، تربط هذه الخصائص التعليق بنطاق نص معين داخل AutoShape.

يمكن قراءة أو تحديث خاصية [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) بقيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — لا يوجد حالة محددة للتعليق الحديث.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

يثبت المثال تعليقًا حديثًا على كلمة "quarterly revenue" في نص المستطيل. يحسب [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) الصفري من النص ويضبط [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) إلى عدد الأحرف المحددة. بعد تعيين [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) إلى `Resolved`, ي حفظ العرض التقديمي ويعيد فتحه. يجب أن تطبع عمليات الفحص الأربعة في وحدة التحكم `True`, مؤكدةً الحفاظ على مرساة الشكل, نطاق النص, والحالة.

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

يتطلب المثال عرضًا تقديميًا موجودًا يحتوي على تعليقات حديثة ويطبع نصها, حالتها, وتفاصيل المرساة. لفحصه, تحقق من التعليقات التي تطبق [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), ثم افحص [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/), و[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). يشير شكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), تحدد خصائص اختيار النص النطاق المرتبط في إطار نص الشكل.

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

يسمح Aspose.Slides لـ .NET بإزالة جميع التعليقات ومؤلفيها من عرض تقديمي أو حذف تعليقات محددة مع الحفاظ على البقية. تُظهر الأمثلة التالية كلا الأسلوبين وتُحفظ العرض التقديمي المُحدث.

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يفتح المثال عرضًا تقديميًا موجودًا ويستدعي [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) لكل مؤلف, ثم يستدعي [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) لإزالة المؤلفين أنفسهم. يحتوي العرض التقديمي المحفوظ على لا تعليقات ولا مؤلفي تعليقات. استخدم عرضًا يحتوي على تعليقات لملاحظة الإزالة.

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

يُنشئ المثال تعليقاتين على شريحة واحدة ويستخدم [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) للعثور على التعليقات حسب كل مؤلف. يجمع التعليقات التي يساوي نصها "comment 1" قبل استدعاء [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), متجنبًا تغييرات في المجموعة أثناء الاختيار. يحتفظ العرض التقديمي المحفوظ فقط بـ "comment 2".

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

**هل يدعم Aspose.Slides حالة "تم الحل" للتعليقات الحديثة؟**

نعم. يمكن قراءة [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) وتعيينه بقيمة من [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), بما في ذلك `Resolved`. تُحفظ الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعمق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأب](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), مما يتيح سلاسل الردود. لا تحدد واجهة البرمجة حدًا معينًا لعمق التداخل.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تعريف موضع العلامة باستخدام إحداثيات بنقطة عائمة في نظام إحداثيات الشريحة, مما يتيح لك وضعها بدقة على الشريحة.
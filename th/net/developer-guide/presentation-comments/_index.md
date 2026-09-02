---
title: จัดการความคิดเห็นในการนำเสนอใน .NET
linktitle: ความคิดเห็นในการนำเสนอ
type: docs
weight: 100
url: /th/net/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นการนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความเห็น
- เข้าถึงความเห็น
- แก้ไขความเห็น
- ตอบกลับความเห็น
- ลบความเห็น
- ลบความเห็น
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการความคิดเห็นในการนำเสนอด้วย Aspose.Slides สำหรับ .NET: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในการนำเสนอด้วย Aspose.Slides for .NET แนะนำประเภทที่เกี่ยวกับความคิดเห็นหลักและสาธิตวิธีเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นจากการนำเสนอ

ตัวอย่างเหล่านี้ครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและเมตาดาต้าของความคิดเห็น, การสร้างสายตอบกลับ, และการลบความคิดเห็นที่เลือกหรือความคิดเห็นทั้งหมด

ใน PowerPoint, ความคิดเห็นปรากฏเป็นหมายเหตุบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อรีวิวงานนำเสนอ

Aspose.Slides for .NET มี API ต่อไปนี้สำหรับการทำงานกับความคิดเห็น:

* The [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icommentcollection) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/th/net/aspose.slides/commentauthor) class, which provides information about an author, including their name, initials, and associated comments.

## **เพิ่มความคิดเห็นในสไลด์**
ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มความคิดเห็นลงในสไลด์ของงานนำเสนอ PowerPoint:

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

## **เข้าถึงความคิดเห็นในสไลด์**
ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่ในงานนำเสนอ PowerPoint:

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

## **ตอบกลับความคิดเห็น**
ความคิดเห็นแม่คือความคิดเห็นเดิมที่อยู่บนสุดของลำดับชั้นการตอบกลับ คุณลักษณะ [ParentComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment/properties/parentcomment) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment) ทำให้คุณสามารถรับหรือกำหนดความคิดเห็นแม่ได้

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มการตอบกลับและตรวจสอบลำดับชั้นของความคิดเห็นที่ได้:

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

* เมื่อใช้เมธอด [Remove](https://reference.aspose.com/slides/th/net/aspose.slides/icomment/methods/remove) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment) เพื่อลบความคิดเห็น จะลบการตอบกลับทั้งหมดที่เกี่ยวข้องกับความคิดเห็นนั้นด้วย
* หากคุณสมบัติ [ParentComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment/properties/parentcomment) สร้างอ้างอิงเป็นวงกลม จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception)

{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปร่างที่ระบุ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/th/net/aspose.slides/icommentcollection/addmoderncomment/) รับอาร์กิวเมนต์ประเภท [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) นอกเหนือจากพิกัดของสไลด์และเครื่องหมายความคิดเห็น

เมื่อส่งค่า `null` ให้กับอาร์กิวเมนต์รูปร่าง ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์ เครื่องหมายจะถูกวางตามพิกัดที่กำหนด แต่ไม่มีการเชื่อมโยงกับรูปร่างใดโดยเฉพาะ ดังนั้น [IModernComment.Shape](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/shape/) จะคืนค่า `null` เมื่อมีการระบุ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ความคิดเห็นจะยึดติดกับรูปร่างนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์ในขณะที่การเชื่อมโยงรูปร่างสามารถดึงมาผ่าน [IModernComment.Shape](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/shape/) ได้

### **ยึดความคิดเห็นสมัยใหม่กับรูปร่าง**

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ระดับสไลด์และความคิดเห็นสมัยใหม่ที่ยึดกับ AutoShape เฉพาะ จากนั้นอ่านรูปร่างที่เชื่อมโยงจากแต่ละความคิดเห็น

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

### **ยึดความคิดเห็นกับประเภทรูปร่างต่าง ๆ**

ออบเจ็กต์สไลด์ใด ๆ ที่ 구현 [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ก็สามารถใช้เป็นตัวยึดรูปร่างได้ ตัวอย่างทั่วไปรวมถึง [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/th/net/aspose.slides/iconnector/), และอินสแตนซ์ของ [IGraphicalObject](https://reference.aspose.com/slides/th/net/aspose.slides/igraphicalobject/) เช่น แผนภูมิ

ตัวอย่างต่อไปนี้สร้างประเภทรูปร่างทั่วไปหลายชนิดและเชื่อมโยงความคิดเห็นสมัยใหม่กับแต่ละประเภท

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

### **ยึดความคิดเห็นกับข้อความและตั้งค่าสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/textselectionstart/) ระบุตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปร่าง, ส่วน [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/textselectionlength/) ระบุความยาวของการเลือก ทั้งสองคุณสมบัตินี้รวมกันทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

คุณสมบัติ [IModernComment.Status](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/status/) สามารถอ่านหรืออัปเดตด้วยค่าจาก enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — ไม่ได้กำหนดสถานะของความคิดเห็นสมัยใหม่
- `Active` — ความคิดเห็นอยู่ในสถานะทำงาน
- `Resolved` — ความคิดเห็นถูกแก้ไขแล้ว
- `Closed` — ความคิดเห็นถูกปิด

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ที่ยึดกับรูปร่าง, เชื่อมโยงกับการเลือกข้อความ, ทำเครื่องหมายว่าแก้ไขแล้ว, บันทึกงานนำเสนอ, และตรวจสอบค่าหลังจากเปิดไฟล์ใหม่

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

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

เพื่อตรวจสอบงานนำเสนอที่มีอยู่, ตรวจสอบว่าความคิดเห็นใดบ้างที่ทำงานตาม [IModernComment](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/), จากนั้นตรวจสอบ [IModernComment.Shape](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/textselectionlength/), และ [IModernComment.Status](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/status/). รูปร่างที่เป็น `null` หมายถึงความคิดเห็นระดับสไลด์ สำหรับการยึดกับ [IAutoShape] ตัวเลือกการเลือกข้อความจะบ่งบอกช่วงที่เชื่อมโยงในกรอบข้อความของรูปร่างนั้น

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

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมด**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมดจากงานนำเสนอ:

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

### **ลบความคิดเห็นเฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นเฉพาะจากสไลด์:

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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะที่แก้ไขสำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. สามารถอ่านและตั้งค่า [IModernComment.Status](https://reference.aspose.com/slides/th/net/aspose.slides/imoderncomment/status/) ด้วยค่าใน enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/net/aspose.slides/moderncommentstatus/) รวมถึง `Resolved` สถานะจะถูกเก็บไว้ในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากไฟล์ถูกเปิดใหม่

**สนับสนุนการสนทนาที่เป็นเธรด (สายตอบกลับ) หรือไม่และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment] ของมันได้ ทำให้สามารถสร้างสายตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันไว้เฉพาะ

**ตำแหน่งเครื่องหมายความคิดเห็นบนสไลด์ถูกกำหนดในระบบพิกัดใด?**

ตำแหน่งเครื่องหมายจะถูกกำหนดโดยพิกัดทศนิยมในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์
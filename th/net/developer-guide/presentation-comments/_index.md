---
title: จัดการความคิดเห็นของงานนำเสนอใน .NET
linktitle: ความคิดเห็นของงานนำเสนอ
type: docs
weight: 100
url: /th/net/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นงานนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการความคิดเห็นของงานนำเสนอด้วย Aspose.Slides สำหรับ .NET: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for .NET แนะนำประเภทข้อมูลที่เกี่ยวกับความคิดเห็นหลักและสาธิตวิธีเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันที่พบบ่อยใน PowerPoint เช่น การกำหนดผู้เขียนให้กับความคิดเห็น, การอ่านข้อความและข้อมูลเมตาของความคิดเห็น, การสร้างสายตอบกลับ, และการลบความคิดเห็นที่เลือกหรือความคิดเห็นทั้งหมด

ใน PowerPoint, ความคิดเห็นจะแสดงเป็นคำอธิบายบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

หากต้องการกำหนดให้ความคิดเห็นถูกแสดงหรือซ่อนเมื่อเปิดงานนำเสนอโดยไม่เปลี่ยนแปลงความคิดเห็นเอง โปรดดูที่ [Show or Hide Comments When Opening a Presentation](/slides/th/net/presentation-view-properties/)

## **ทำไมต้องเพิ่มความคิดเห็นลงในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานระหว่างการตรวจทานงานนำเสนอ

Aspose.Slides for .NET มี API ด้านล่างสำหรับทำงานกับความคิดเห็น:

* คลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ให้การเข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ
* อินเทอร์เฟซ [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) แทนความคิดเห็นที่เกี่ยวข้องกับผู้เขียนแต่ละคน
* อินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) ให้ข้อมูลเกี่ยวกับความคิดเห็นรวมถึงผู้เขียน, เวลาสร้าง, ตำแหน่ง, และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) ให้ข้อมูลเกี่ยวกับผู้เขียนรวมถึงชื่อ, ชื่อย่อ, และความคิดเห็นที่เกี่ยวข้อง

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างนี้สร้างสไลด์สองสไลด์และลงทะเบียนผู้เขียนความคิดเห็นด้วย [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) ใช้ [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) เพื่อวางความคิดเห็นหนึ่งรายการบนแต่ละสไลด์ จากนั้นดึงความคิดเห็นของสไลด์แรกสำหรับผู้เขียนนั้นด้วย [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) คอนโซลจะแสดงข้อความของความคิดเห็นแรกสองครั้ง เพื่อสาธิตการเข้าถึงผ่านสไลด์และผู้เขียน และงานนำเสนอที่บันทึกไว้จะมีทั้งสองความคิดเห็น

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

## **ค้นหา或สร้างผู้เขียนความคิดเห็น**

เมื่อการตรวจสอบอัตโนมัติโปรเซสงานนำเสนอเดียวกันหลายครั้ง ให้ค้นหาในคอลเลกชัน [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) ก่อนเพิ่มผู้เขียน [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) จะจับคู่ทั้งชื่อและชื่อย่อและคืนค่าอาเรย์ของผู้เขียนที่ตรงกัน หรืออาเรย์เปล่า หากไม่มีการจับคู่ ในขณะเดียวกัน [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) จะค้นหาโดยชื่อเพียงอย่างเดียวโดยไม่สนใจชื่อย่อ การเรียกใช้ [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) ด้วยชื่อและชื่อย่อที่มีอยู่แล้วในคอลเลกชันจะส่งข้อยกเว้น

ตัวอย่างต้องการไฟล์งานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์ ในแต่ละรอบสองรอบ จะใช้ผู้เขียนที่ตรงกันคนแรก หากไม่มีการจับคู่จะสร้างใหม่ หากมีการจับคู่หลายรายการจะเลือกอาเรย์ตำแหน่งแรกโดยไม่รวมหรือกำจัดผู้เขียนอื่น ๆ จากนั้นเรียก [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) สำหรับผู้เขียนที่เลือกและบันทึกงานนำเสนอ รอบที่สองจะเปิดผลลัพธ์ของรอบแรกและทำซ้ำขั้นตอน

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

รอบที่สองเพิ่มความคิดเห็นอีกหนึ่งรายการโดยไม่เพิ่มผู้เขียนอีกคนหรือทำลบความคิดเห็นที่มีอยู่ ไฟล์สุดท้าย `review_pass_2.pptx` จะมีทั้งความคิดเห็นใหม่และความคิดเห็นเดิมใด ๆ การใช้ผู้เขียนซ้ำไม่ได้ทำให้ความคิดเห็นซ้ำกันถูกลบออก: เพื่อหลีกเลี่ยงการเพิ่มความคิดเห็นเดียวกันหลายครั้ง ให้ตรวจจับความซ้ำก่อนการเพิ่ม

## **เข้าถึงความคิดเห็นในสไลด์**

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และอ่านคอลเลกชัน [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) สำหรับผู้เขียนแต่ละคน จะวนลูปผ่าน [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) และพิมพ์หมายเลขสไลด์, ข้อความความคิดเห็น, ชื่อผู้เขียน, และเวลาสร้าง งานนำเข้าต้องมีความคิดเห็นเพื่อให้คอนโซลแสดงผล

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

ความคิดเห็นพ่อแม่คือความคิดเห็นต้นฉบับที่อยู่บนสุดของลำดับชั้นการตอบกลับ คุณสมบัติ [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) ให้คุณรับหรือกำหนดผู้แสดงความคิดเห็นพ่อแม่

ตัวอย่างสร้างความคิดเห็นจากผู้เขียนสองคนและใช้ [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) เพื่อสร้างการตอบกลับ รวมถึงการตอบกลับต่อการตอบกลับอื่น ๆ การส่ง `null` ไปยัง [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) จะดึงความคิดเห็นจากผู้เขียนทั้งหมด; คอนโซลจะเยื้องแต่ละรายการตามระดับความลึกในลำดับชั้นการตอบกลับ ตัวอย่างบันทึกการสนทนาครบถ้วน แล้วเรียก [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) กับความคิดเห็นรากแรก แล้วบันทึกงานนำเสนอที่สองโดยที่ความคิดเห็นและการตอบกลับของมันถูกลบออก

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
* เมื่อใช้เมธอด [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) เพื่อลบความคิดเห็น จะลบการตอบกลับทั้งหมดที่เชื่อมกับความคิดเห็นนั้นด้วย
* หากคุณสมบัติ [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) สร้างการอ้างอิงแบบวงกลม จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) รับอาร์กิวเมนต์ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) เพิ่มเติมนอกเหนือจากสไลด์และพิกัดของตัวทำเครื่องหมายความคิดเห็น

เมื่อส่ง `null` เป็นอาร์กิวเมนต์รูปทรง ความคิดเห็นจะเป็นระดับสไลด์ ตัวทำเครื่องหมายจะถูกวางตามพิกัดที่ระบุ แต่ไม่ได้เชื่อมกับรูปทรงใดโดยเฉพาะ ดังนั้น [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) จะคืนค่า `null` หากส่ง [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) เข้าไป ความคิดเห็นจะถูกผูกกับรูปนั้น พิกัดยังคงกำหนดตำแหน่งของตัวทำเครื่องหมายบนสไลด์ ในขณะที่การเชื่อมกับรูปทรงสามารถดึงข้อมูลได้ผ่าน [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/)

### **ผูกความคิดเห็นสมัยใหม่กับรูปร่าง**

ตัวอย่างเรียก [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) สองครั้ง: ครั้งแรกใช้รูปทรง `null` สำหรับความคิดเห็นระดับสไลด์ และครั้งที่สองใช้สี่เหลี่ยมเป็นจุดยึด การอ่าน [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) จะพิมพ์ `True` สำหรับการตรวจสอบ `null` ของความคิดเห็นระดับสไลด์และพิมพ์ `Revenue title` สำหรับความคิดเห็นที่ผูกกับรูป ทั้งสองความคิดเห็นจะถูกบันทึกอยู่ในงานนำเสนอ

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

### **ผูกความคิดเห็นกับประเภทรูปร่างต่าง ๆ**

อ็อบเจกต์สไลด์ใด ๆ ที่ทำตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) สามารถใช้เป็นจุดยึดของรูปทรงได้ ตัวอย่างทั่วไปรวมถึง [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), และอินสแตนซ์ของ [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) เช่น ชาร์ต

ตัวอย่างใช้ [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) เพื่อเชื่อมความคิดเห็นกับรูปทรงห้าชนิด: AutoShape, picture frame, group, connector, และ chart ภาพใช้ข้อมูลภาพฝังอยู่จึงไม่ต้องการไฟล์ภาพภายนอก แต่ละความคิดเห็นมีตำแหน่งตัวทำเครื่องหมายของตนเองและงานนำเสนอที่บันทึกไว้จะรักษาการเชื่อมกับรูปทรงทั้งห้าไว้

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

### **ผูกความคิดเห็นกับข้อความและตั้งค่าสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมกับ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) คุณสมบัติ [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) ระบุตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปร่าง ในขณะที่ [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) ระบุความยาวของการเลือก คุณสมบัติเหล่านี้ทำให้ความคิดเห็นเชื่อมกับช่วงข้อความเฉพาะใน AutoShape

คุณสมบัติ [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) สามารถอ่านหรืออัปเดตด้วยค่าจาก enumeration [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) :

- `NotDefined` — ไม่ได้กำหนดสถานะความคิดเห็นสมัยใหม่เฉพาะ
- `Active` — ความคิดเห็นอยู่ในสถานะที่ใช้งาน
- `Resolved` — ความคิดเห็นได้รับการแก้ไขแล้ว
- `Closed` — ความคิดเห็นถูกปิด

ตัวอย่างผูกความคิดเห็นสมัยใหม่กับคำว่า "quarterly revenue" ในข้อความของสี่เหลี่ยม จะคำนวณค่า [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) ตั้งแต่ศูนย์และตั้งค่า [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) เป็นจำนวนอักขระที่เลือก หลังจากตั้งค่า [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) เป็น `Resolved` แล้วบันทึกและเปิดงานนำเสนออีกครั้ง การตรวจสอบคอนโซดสี่จุดควรพิมพ์ `True` เพื่อยืนยันว่าการผูกรูปทรง, ช่วงข้อความ, และสถานะถูกเก็บไว้

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

ตัวอย่างต้องการงานนำเสนอที่มีความคิดเห็นสมัยใหม่อยู่แล้วและพิมพ์ข้อความ, สถานะ, และรายละเอียดจุดยึด เพื่อทำการตรวจสอบให้ตรวจดูว่าความคิดเห็นใดบ้างที่ implement [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) จากนั้นตรวจสอบ [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/), และ [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) `null` shape แสดงว่าความคิดเห็นเป็นระดับสไลด์ สำหรับจุดยึดของ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) คุณสมบัติการเลือกข้อความบ่งบอกช่วงที่เชื่อมกับเฟรมข้อความของรูปร่าง

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

Aspose.Slides for .NET ให้คุณลบความคิดเห็นทั้งหมดและผู้เขียนทั้งหมดจากงานนำเสนอ หรือทำการลบความคิดเห็นที่เลือกไว้โดยคงส่วนที่เหลือไว้ ตัวอย่างต่อไปนี้สาธิตทั้งสองวิธีและบันทึกงานนำเสนอที่อัปเดตแล้ว

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเรียก [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) สำหรับแต่ละผู้เขียน แล้วเรียก [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) เพื่อลบผู้เขียนเอง งานนำเสนอที่บันทึกจะไม่มีความคิดเห็นหรือผู้เขียนใด ๆ ใช้งานนำเสนอที่มีความคิดเห็นเพื่อสังเกตการลบ

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

ตัวอย่างสร้างความคิดเห็นสองรายการบนสไลด์หนึ่งและใช้ [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) เพื่อค้นหาความคิดเห็นของแต่ละผู้เขียน จะรวบรวมความคิดเห็นที่ข้อความเท่ากับ "comment 1" ก่อนเรียก [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/) เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอลเลกชันระหว่างการเลือก งานนำเสนอที่บันทึกจะเหลือเพียง "comment 2"

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

ใช่. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) สามารถอ่านและตั้งค่าได้ด้วยค่า [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) รวมถึง `Resolved` สถานะจะถูกบันทึกในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากไฟล์ถูกเปิดใหม่

**สนทนาที่เป็นเธรด (สายตอบกลับ) ถูกสนับสนุนหรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) ของมันได้ ทำให้สร้างสายตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันเป็นค่าเฉพาะ

**ตำแหน่งของตัวทำเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งของตัวทำเครื่องหมายกำหนดโดยพิกัดแบบ floating‑point ในระบบพิกัดของสไลด์ ทำให้คุณวางตำแหน่งได้อย่างแม่นยำบนสไลด์
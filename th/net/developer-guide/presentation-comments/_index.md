---
title: จัดการความคิดเห็นในงานนำเสนอด้วย .NET
linktitle: ความคิดเห็นในงานนำเสนอ
type: docs
weight: 100
url: /th/net/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นในงานนำเสนอ
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
description: "ควบคุมความคิดเห็นในงานนำเสนอด้วย Aspose.Slides สำหรับ .NET: เพิ่ม, อ่าน, แก้ไขและลบความคิดเห็นในไฟล์ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides แสดงประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและสาธิตวิธีการเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับ, ใช้ความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างเน้นสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดผู้เขียนให้กับความคิดเห็น, การอ่านเนื้อหาและข้อมูลเมตาของความคิดเห็น, การสร้างสายตอบกลับ, และการลบความคิดเห็นทั้งหมดหรือเฉพาะที่เลือก

ใน PowerPoint ความคิดเห็นปรากฏเป็นโน้ตหรือคำอธิบายบนสไลด์ เมื่อคลิกที่ความคิดเห็น จะเผยเนื้อหาหรือข้อความของมัน

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณอาจต้องการใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะหรือสื่อสารกับเพื่อนร่วมงานเมื่อทำการตรวจทานงานนำเสนอ

เพื่อให้คุณสามารถใช้ความคิดเห็นในงานนำเสนอ PowerPoint, Aspose.Slides for .NET มีให้

* คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่เก็บคอลเลกชันของผู้เขียน (จากคุณสมบัติ [CommentAuthorCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icommentauthorcollection/properties/index)) ผู้เขียนจะเพิ่มความคิดเห็นลงในสไลด์
* อินเทอร์เฟซ [ICommentCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icommentcollection) ที่เก็บคอลเลกชันของความคิดเห็นสำหรับผู้เขียนแต่ละคน
* คลาส [IComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment) ที่บรรจุข้อมูลเกี่ยวกับผู้เขียนและความคิดเห็นของพวกเขา: ผู้ที่เพิ่มความคิดเห็น, เวลาที่ความคิดเห็นถูกเพิ่ม, ตำแหน่งของความคิดเห็น เป็นต้น
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/net/aspose.slides/commentauthor) ที่บรรจุข้อมูลของผู้เขียนแต่ละคน: ชื่อผู้เขียน, อักษรย่อ, ความคิดเห็นที่เชื่อมโยงกับชื่อของผู้เขียน เป็นต้น

## **เพิ่มความคิดเห็นบนสไลด์**
โค้ด C# นี้แสดงวิธีการเพิ่มความคิดเห็นลงในสไลด์ของงานนำเสนอ PowerPoint:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation presentation = new Presentation())
{
    // เพิ่มสไลด์เปล่า
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // เพิ่มผู้เขียน
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // ตั้งค่าตำแหน่งสำหรับความคิดเห็น
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // เข้าถึง ISlide 1
    ISlide slide = presentation.Slides[0];

    // เมื่อส่งค่า null เป็นอาร์กิวเมนต์ ความคิดเห็นจากผู้เขียนทั้งหมดจะถูกนำมาในสไลด์ที่เลือก
    IComment[] Comments = slide.GetSlideComments(author);

    // เข้าถึงความคิดเห็นที่ตำแหน่ง 0 สำหรับสไลด์ 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // เลือกคอลเลกชันความคิดเห็นของผู้เขียนที่ตำแหน่ง 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **เข้าถึงความคิดเห็นบนสไลด์**
โค้ด C# นี้แสดงวิธีการเข้าถึงความคิดเห็นที่มีอยู่บนสไลด์ของงานนำเสนอ PowerPoint:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **ตอบกลับความคิดเห็น**
ความคิดเห็นแม่คือความคิดเห็นต้นฉบับในลำดับชั้นของความคิดเห็นหรือการตอบกลับ โดยใช้คุณสมบัติ [ParentComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment/properties/parentcomment) (จากอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment)) คุณสามารถกำหนดหรือรับความคิดเห็นแม่ได้

โค้ด C# นี้แสดงวิธีการเพิ่มความคิดเห็นและรับการตอบกลับของมัน:

```c#
using (Presentation pres = new Presentation())
{
    // เพิ่มความคิดเห็น
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // เพิ่มการตอบกลับให้กับ comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // เพิ่มการตอบกลับอีกอันให้กับ comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // เพิ่มการตอบกลับให้กับการตอบกลับที่มีอยู่
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // แสดงลำดับชั้นของความคิดเห็นบนคอนโซล
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // ลบ comment1 และการตอบกลับทั้งหมดของมัน
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="คำเตือน" %}} 
* เมื่อใช้เมธอด [Remove](https://reference.aspose.com/slides/th/net/aspose.slides/icomment/methods/remove) (จากอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment)) เพื่อลบความคิดเห็น การตอบกลับของความคิดเห็นนั้นก็จะถูกลบด้วย
* หากการตั้งค่า [ParentComment](https://reference.aspose.com/slides/th/net/aspose.slides/icomment/properties/parentcomment) ทำให้เกิดการอ้างอิงวนรอบ จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ในปี 2021 Microsoft ได้นำเสนอ *ความคิดเห็นสมัยใหม่* ใน PowerPoint คุณลักษณะนี้ช่วยปรับปรุงการทำงานร่วมกันอย่างมีประสิทธิภาพมากขึ้น ผู้ใช้ PowerPoint สามารถแก้ไขสถานะของความคิดเห็น, ผูกความคิดเห็นกับวัตถุและข้อความ, และมีปฏิสัมพันธ์ได้ง่ายขึ้นอย่างมาก

ใน [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/th/net/aspose-slides-for-net-21-11-release-notes/) เราได้เพิ่มการสนับสนุนความคิดเห็นสมัยใหม่โดยการเพิ่มคลาส [ModernComment](https://reference.aspose.com/slides/th/net/aspose.slides/moderncomment) เมธอด [AddModernComment](https://reference.aspose.com/slides/th/net/aspose.slides/commentcollection/methods/addmoderncomment) และ [InsertModernComment](https://reference.aspose.com/slides/th/net/aspose.slides/commentcollection/methods/insertmoderncomment) ถูกเพิ่มเข้าในคลาส [CommentCollection](https://reference.aspose.com/slides/th/net/aspose.slides/commentcollection)

โค้ด C# นี้แสดงวิธีการเพิ่มความคิดเห็นสมัยใหม่ลงในสไลด์ของงานนำเสนอ PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

โค้ด C# นี้แสดงวิธีการลบความคิดเห็นและผู้เขียนทั้งหมดในงานนำเสนอ:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // ลบความคิดเห็นทั้งหมดจากงานนำเสนอ
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // ลบผู้เขียนทั้งหมด
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **ลบความคิดเห็นเฉพาะที่เลือก**

โค้ด C# นี้แสดงวิธีการลบความคิดเห็นเฉพาะบนสไลด์:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // เพิ่มความคิดเห็น...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // ลบความคิดเห็นทั้งหมดที่มีข้อความ "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะเช่น “แก้ไขแล้ว” สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [Modern comments](https://reference.aspose.com/slides/th/net/aspose.slides/moderncomment/) มีคุณสมบัติ [Status](https://reference.aspose.com/slides/th/net/aspose.slides/moderncomment/status/) ให้คุณอ่านและตั้งค่าสถานะของความคิดเห็น (เช่น ตั้งค่าเป็นแก้ไขแล้ว) สถานะนี้จะถูกบันทึกในไฟล์และ PowerPoint จะรับรู้

**รองรับการสนทนาที่เป็นเธรด (สายตอบกลับ) หรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/net/aspose.slides/comment/parentcomment/) ของมัน ทำให้สามารถสร้างสายตอบกลับได้โดยไม่มีขอบเขตจำกัด ความลึกของการซ้อนกันไม่ได้ถูกกำหนดใน API

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งจะถูกจัดเก็บเป็นจุดแบบ floating‑point ในระบบพิกัดของสไลด์ ซึ่งทำให้คุณสามารถวางเครื่องหมายความคิดเห็นได้อย่างแม่นยำตามที่ต้องการ
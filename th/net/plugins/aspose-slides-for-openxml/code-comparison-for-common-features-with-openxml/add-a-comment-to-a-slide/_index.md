---
title: เพิ่มคอมเมนต์ไปยังสไลด์
type: docs
weight: 10
url: /th/net/add-a-comment-to-a-slide/
---
## **การนำเสนอ OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// เพิ่มคอมเมนต์ไปยังสไลด์แรกของเอกสารการนำเสนอ
// เอกสารการนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // ประกาศออบเจกต์ CommentAuthorsPart

    CommentAuthorsPart authorsPart;

    // ตรวจสอบว่ามีส่วนผู้เขียนคอมเมนต์ที่มีอยู่หรือไม่

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // หากไม่มี ให้เพิ่มใหม่

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // ตรวจสอบว่ามีรายการผู้เขียนคอมเมนต์ในส่วนผู้เขียนคอมเมนต์หรือไม่

    if (authorsPart.CommentAuthorList == null)

    {

        // หากไม่มี ให้เพิ่มใหม่

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // ประกาศ ID ของผู้เขียนใหม่

    uint authorId = 0;

    CommentAuthor author = null;

    // หากมีองค์ประกอบลูกที่มีอยู่ในรายการผู้เขียนคอมเมนต์...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // ตรวจสอบว่าผู้เขียนที่ส่งเข้ามาอยู่ในรายการหรือไม่

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // หากมี...

        if (authors.Any())

        {

            // กำหนดผู้เขียนคอมเมนต์ใหม่ให้ใช้ ID ของผู้เขียนที่มีอยู่

            author = authors.First();

            authorId = author.Id;

        }

        // หากไม่มี...

        if (author == null)

        {

            // กำหนด ID ใหม่ให้ผู้เขียนที่ส่งเข้ามา

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // หากไม่มีองค์ประกอบลูกที่มีอยู่ในรายการผู้เขียนคอมเมนต์

    if (author == null)

    {

        authorId++;

        // เพิ่มองค์ประกอบลูกใหม่ (ผู้เขียนคอมเมนต์) เข้าในรายการผู้เขียนคอมเมนต์

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // ดึงสไลด์แรกโดยใช้เมธอด GetFirstSlide

    SlidePart slidePart1 = GetFirstSlide(doc);

    // ประกาศส่วนคอมเมนต์

    SlideCommentsPart commentsPart;

    // ตรวจสอบว่ามีส่วนคอมเมนต์ในสไลด์ส่วนแรกหรือไม่

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // หากไม่มี ให้เพิ่มส่วนคอมเมนต์ใหม่

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // หากมี ให้ใช้ส่วนคอมเมนต์แรกในสไลด์ส่วนนี้

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // หากรายการคอมเมนต์ไม่มีอยู่

    if (commentsPart.CommentList == null)

    {

        // เพิ่มรายการคอมเมนต์ใหม่

        commentsPart.CommentList = new CommentList();

    }

    // ดึง ID ของคอมเมนต์ใหม่

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // เพิ่มคอมเมนต์ใหม่

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // เพิ่มโหนดตำแหน่งลูกเข้าไปในองค์ประกอบคอมเมนต์

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // บันทึกส่วนผู้เขียนคอมเมนต์

    authorsPart.CommentAuthorList.Save();

    // บันทึกส่วนคอมเมนต์

    commentsPart.CommentList.Save();

}

}

// ดึงส่วนสไลด์ของสไลด์แรกในเอกสารการนำเสนอ

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// ดึง Relationship ID ของสไลด์แรก

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// ดึงส่วนสไลด์โดยใช้ Relationship ID

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
ใน **Aspose.Slides** สำหรับ .NET, คอลเลกชันคอมเมนต์ของสไลด์ PPT จะถูกรวมอยู่ในทุกคลาส **Slide**. คลาส **CommentCollection** ถูกใช้เพื่อเก็บคอมเมนต์ของสไลด์ที่เฉพาะเจาะจง. คลาส **Comment** รวมข้อมูลเช่น ผู้เขียนที่เพิ่มคอมเมนต์สไลด์, ย่อหน้าชื่อ, เวลาที่สร้าง, ตำแหน่งของคอมเมนต์บนสไลด์และข้อความคอมเมนต์. คลาส **CommentAuthor** ถูกใช้เพื่อเพิ่มผู้เขียนสำหรับคอมเมนต์สไลด์ในระดับการนำเสนอ. คลาส **Presentation** ถือคอลเลกชันของผู้เขียนสำหรับการนำเสนอในคลาส **CommentAuthors**.

ในตัวอย่างต่อไปนี้ เราได้เพิ่มโค้ดสแนปช็อตสำหรับการเพิ่มคอมเมนต์สไลด์.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //เพิ่มสไลด์เปล่า

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //เพิ่มผู้เขียน

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //ตำแหน่งของคอมเมนต์

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //เพิ่มคอมเมนต์สไลด์สำหรับผู้เขียนบนสไลด์

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)
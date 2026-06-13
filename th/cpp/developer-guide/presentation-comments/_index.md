---
title: จัดการความคิดเห็นในงานนำเสนอด้วย C++
linktitle: ความคิดเห็นในงานนำเสนอ
type: docs
weight: 100
url: /th/cpp/presentation-comments/
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
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมความคิดเห็นในงานนำเสนอด้วย Aspose.Slides สำหรับ C++: เพิ่ม, อ่าน, แก้ไขและลบความคิดเห็นในไฟล์ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides โดยแสดงประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและสาธิตวิธีการเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับ, ใช้ความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างมุ่งเน้นไปที่สถานการณ์การตรวจทานและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความเห็นให้กับผู้เขียน, การอ่านเนื้อหาและเมตาดาต้าของความคิดเห็น, การสร้างโซ่การตอบกลับ, และการลบความเห็นทั้งหมดหรือการลบความเห็นที่เลือก

ใน PowerPoint, ความคิดเห็นจะแสดงเป็นบันทึกหรือคำอธิบายบนสไลด์ เมื่อคลิกที่ความคิดเห็น, เนื้อหาหรือข้อความของมันจะปรากฏขึ้น

### **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณอาจต้องการใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะหรือสื่อสารกับเพื่อนร่วมงานเมื่อคุณตรวจทานงานนำเสนอ

เพื่อให้คุณสามารถใช้ความคิดเห็นในงานนำเสนอ PowerPoint, Aspose.Slides for C++ มีให้

* The [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) class, ซึ่งประกอบด้วยคอลเลกชันของผู้เขียน (จากเมธอด [get_CommentAuthors()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). ผู้เขียนจะเพิ่มความคิดเห็นลงในสไลด์
* The  [ICommentCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_comment_collection) interface, ซึ่งประกอบด้วยคอลเลกชันของความคิดเห็นสำหรับผู้เขียนแต่ละคน
* The  [IComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_comment) class, ซึ่งประกอบด้วยข้อมูลของผู้เขียนและความคิดเห็นของพวกเขา: ผู้ที่เพิ่มความคิดเห็น, เวลาเพิ่มความคิดเห็น, ตำแหน่งของความคิดเห็น, เป็นต้น
* The [CommentAuthor](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.comment_author) class, ซึ่งประกอบด้วยข้อมูลของผู้เขียนแต่ละคน: ชื่อผู้เขียน, ชื่อย่อ, ความคิดเห็นที่เชื่อมโยงกับชื่อผู้เขียน, เป็นต้น

## **เพิ่มความคิดเห็นในสไลด์**
โค้ด C++ นี้แสดงวิธีเพิ่มความคิดเห็นในสไลด์ของงานนำเสนอ PowerPoint:

```cpp
// สร้างตัวอย่างของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();
// เพิ่มสไลด์เปล่า
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// เพิ่มผู้เขียน
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// ตั้งค่าตำแหน่งสำหรับความคิดเห็น
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// เข้าถึง ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// เข้าถึง ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// เมื่อส่งค่า null เป็นอาร์กิวเมนต์, ความคิดเห็นจากผู้เขียนทั้งหมดจะถูกนำมาที่สไลด์ที่เลือก
auto comments = slide1->GetSlideComments(author);

// เข้าถึงความคิดเห็นที่ตำแหน่ง 0 สำหรับสไลด์ 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // เลือกคอลเลกชันความคิดเห็นของผู้เขียนที่ตำแหน่ง 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **เข้าถึงความคิดเห็นในสไลด์**
โค้ด C++ นี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่บนสไลด์ของงานนำเสนอ PowerPoint:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **ตอบกลับความคิดเห็น**
ความเห็นแม่คือความเห็นหลักหรือความเห็นต้นฉบับในลำดับชั้นของความคิดเห็นหรือการตอบกลับ โดยใช้คุณสมบัติ [ParentComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (จากอินเทอร์เฟส [IComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_comment)) คุณสามารถตั้งหรือรับความเห็นแม่ได้

โค้ด C++ นี้แสดงวิธีเพิ่มความคิดเห็นและรับการตอบกลับต่อความคิดเห็น:

```cpp
auto pres = System::MakeObject<Presentation>();

// เข้าถึง ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// เพิ่มความคิดเห็น
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// เพิ่มการตอบกลับให้กับ comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// เพิ่มการตอบกลับอีกรายการให้กับ comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// เพิ่มการตอบกลับให้กับการตอบกลับที่มีอยู่
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// แสดงลำดับความสำคัญของความคิดเห็นบนคอนโซล
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// ลบ comment1 และการตอบกลับทั้งหมดของมัน
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* เมื่อเมธอด [Remove](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (จากอินเทอร์เฟส [IComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_comment)) ถูกใช้เพื่อลบความเห็น, การตอบกลับของความเห็นนั้นก็จะถูกลบด้วย
* ถ้าการตั้งค่า [ParentComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) ทำให้เกิดการอ้างอิงแบบวนรอบ, จะขว้างข้อยกเวลาด [PptxEditException](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)

{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ในปี 2021, Microsoft ได้นำเสนอ *modern comments* ใน PowerPoint คุณลักษณะ modern comments ช่วยปรับปรุงการทำงานร่วมกันใน PowerPoint อย่างมีนัยสำคัญ ผ่าน modern comments ผู้ใช้ PowerPoint สามารถทำการแก้ไขความคิดเห็น, ผูกความคิดเห็นกับวัตถุและข้อความ, และมีปฏิสัมพันธ์ได้ง่ายกว่าที่เคย

ใน [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/th/cpp/aspose-slides-for-cpp-21-11-release-notes/) เราได้เพิ่มการสนับสนุน modern comments โดยเพิ่มคลาส [ModernComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.modern_comment) เมธอด [AddModernComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) และ [InsertModernComment](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) ถูกเพิ่มเข้าไปในคลาส [CommentCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.comment_collection)

โค้ด C++ นี้แสดงวิธีเพิ่มความคิดเห็นสมัยใหม่ในสไลด์ของงานนำเสนอ PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// เข้าถึง ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

โค้ด C++ นี้แสดงวิธีลบความคิดเห็นและผู้เขียนทั้งหมดในงานนำเสนอ:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// ลบความคิดเห็นทั้งหมดจากงานนำเสนอ
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// ลบผู้เขียนทั้งหมด
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);

```

### **ลบความคิดเห็นเฉพาะ**

โค้ด C++ นี้แสดงวิธีลบความคิดเห็นเฉพาะบนสไลด์:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// เพิ่มความคิดเห็น...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// ลบความคิดเห็นทั้งหมดที่มีข้อความ "comment 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);

```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะเช่น 'resolved' สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [Modern comments](https://reference.aspose.com/slides/th/cpp/aspose.slides/moderncomment/) มีเมธอด [get_Status](https://reference.aspose.com/slides/th/cpp/aspose.slides/moderncomment/get_status/) และ [set_Status](https://reference.aspose.com/slides/th/cpp/aspose.slides/moderncomment/set_status/) คุณสามารถอ่านและตั้งค่าสถานะของความคิดเห็น (เช่น ทำเครื่องหมายว่า resolved) ได้ และสถานะนี้จะถูกบันทึกในไฟล์และ PowerPoint จะรับรู้

**รองรับการสนทนาแบบเธรด (โซ่การตอบกลับ) หรือไม่, และมีขีดจำกัดการซ้อนกันหรือไม่?**

รองรับ. ความคิดเห็นแต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/cpp/aspose.slides/comment/set_parentcomment/) ทำให้สามารถสร้างโซ่การตอบกลับได้โดยไม่จำกัดระดับความลึกเฉพาะ

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งถูกเก็บเป็นจุดเชิงลอยในระบบพิกัดของสไลด์ ซึ่งทำให้คุณสามารถวางเครื่องหมายความคิดเห็นได้อย่างแม่นยำตามที่ต้องการ
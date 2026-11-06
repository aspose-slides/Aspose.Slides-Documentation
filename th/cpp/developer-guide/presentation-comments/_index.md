---
title: จัดการความคิดเห็นงานนำเสนอใน C++
linktitle: ความคิดเห็นงานนำเสนอ
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
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการความคิดเห็นงานนำเสนอด้วย Aspose.Slides for C++: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for C++. มันแนะนำประเภทหลักที่เกี่ยวข้องกับความคิดเห็นและสาธิตวิธีเพิ่มความคิดเห็นลงในสไลด์ การเข้าถึงความคิดเห็นที่มีอยู่ การทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่ และการลบความคิดเห็นออกจากงานนำเสนอ  

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน การอ่านข้อความความคิดเห็นและเมตาดาต้า การสร้างห่วงโซ่การตอบกลับ และการลบความคิดเห็นที่เลือกหรือความคิดเห็นทั้งหมด  

ใน PowerPoint ความคิดเห็นจะแสดงเป็นคำอธิบายในสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง  

เพื่อให้แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอโดยไม่เปลี่ยนความคิดเห็นเอง ดูที่ [แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอ](/slides/th/cpp/presentation-view-properties/)

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจสอบงานนำเสนอ  

Aspose.Slides for C++ มี API ต่อไปนี้สำหรับการทำงานกับความคิดเห็น:

* คลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ให้การเข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ
* อินเทอร์เฟซ [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) แสดงความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน
* อินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) ให้ข้อมูลเกี่ยวกับความคิดเห็นรวมถึงผู้เขียน เวลาในการสร้าง ตำแหน่ง และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) ให้ข้อมูลเกี่ยวกับผู้เขียนรวมถึงชื่อ อักษรย่อ และความคิดเห็นที่เชื่อมโยง

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างนี้สร้างสไลด์สองสไลด์และลงทะเบียนผู้เขียนความคิดเห็นด้วย [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). ใช้ [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) เพื่อวางความคิดเห็นหนึ่งรายการบนแต่ละสไลด์ จากนั้นเรียกคืนความคิดเห็นของสไลด์แรกสำหรับผู้เขียนนั้นด้วย [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). คอนโซลจะแสดงข้อความของความคิดเห็นแรกสองครั้ง เพื่อสาธิตการเข้าถึงทั้งผ่านสไลด์และผู้เขียน และงานนำเสนอที่บันทึกจะมีความคิดเห็นทั้งสองรายการ

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

## **ค้นหาหรือสร้างผู้เขียนความคิดเห็น**

เมื่อการตรวจทานอัตโนมัติโปรเซสงานนำเสนอเดียวกันหลายครั้ง ให้ค้นหาคอลเลกชันที่คืนค่าจาก [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) ก่อนเพิ่มผู้เขียน [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) จะจับคู่ทั้งชื่อและอักษรย่อและคืนค่าอาเรย์ของผู้เขียนที่ตรงกัน หรืออาเรย์ว่างหากไม่มีการจับคู่ ตรงกันข้าม [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) จะค้นหาโดยใช้ชื่ออย่างเดียวโดยไม่สนใจอักษรย่อ การเรียกใช้ [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) ด้วยชื่อและอักษรย่อที่มีอยู่แล้วในคอลเลกชันจะทำให้เกิดข้อยกเว้น  

ตัวอย่างต้องการไฟล์งานนำเสนอที่มีสไลด์อย่างน้อยหนึ่งสไลด์ ในแต่ละรอบสองรอบ จะใช้ผู้เขียนที่ตรงกันแรกซ้ำหรือสร้างใหม่เฉพาะเมื่อผลลัพธ์เป็นค่าว่าง หากมีหลายการจับคู่ จะเลือกสมาชิกอาเรย์แรกโดยไม่ผสานหรือลบผู้เขียนอื่น ๆ จากนั้นจะเรียก [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) สำหรับผู้เขียนที่เลือกและบันทึกงานนำเสนอ รอบที่สองจะเปิดผลลัพธ์จากรอบแรกและทำซ้ำการดำเนินการ  

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

รอบที่สองจะเพิ่มความคิดเห็นอีกหนึ่งรายการโดยไม่เพิ่มผู้เขียนใหม่หรือ ลบความคิดเห็นที่มีอยู่ไฟล์สุดท้าย `review_pass_2.pptx` จะมีความคิดเห็นใหม่ทั้งสองรายการรวมกับความคิดเห็นเดิมที่มีอยู่ การใช้ผู้เขียนซ้ำไม่ทำให้ความคิดเห็นซ้ำซ้อน: เพื่อหลีกเลี่ยงการเพิ่มความคิดเห็นเดียวกันหลายครั้ง ให้ดำเนินการตรวจจับสำเนาซ้ำแยกต่างหากก่อนเพิ่ม

## **เข้าถึงความคิดเห็นสไลด์**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และอ่านคอลเลกชันที่คืนค่าจาก [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). สำหรับผู้เขียนแต่ละคน จะวนผ่านคอลเลกชันที่คืนค่าจาก [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) และพิมพ์หมายเลขสไลด์ ข้อความความคิดเห็น ชื่อผู้เขียน และเวลาในการสร้าง งานนำเข้า ต้องมีความคิดเห็นเพื่อให้คอนโซลแสดงผล

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

## **ตอบกลับความคิดเห็น**

ความคิดเห็นแม่คือความคิดเห็นต้นฉบับที่อยู่ด้านบนของลำดับชั้นการตอบกลับ เมธอด [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) และ [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) ช่วยให้คุณรับหรือกำหนดความคิดเห็นแม่ของความคิดเห็น  

ตัวอย่างสร้างความคิดเห็นจากผู้เขียนสองคนและใช้ [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) เพื่อสร้างการตอบกลับรวมถึงการตอบกลับต่อการตอบกลับอื่น การส่งค่า `nullptr` ไปยัง [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) จะดึงความคิดเห็นจากผู้เขียนทั้งหมด; คอนโซลจะทำการเยื้องแต่ละรายการตามระดับความลึกในลำดับชั้นการตอบกลับ ตัวอย่างบันทึกการสนทนาทั้งหมด เรียก [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) กับความคิดเห็นรากแรก และบันทึกงานนำเสนอครั้งที่สองโดยลบความคิดเห็นนั้นและการตอบกลับของมันออก

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

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
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

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* เมื่อใช้เมธอด [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) เพื่อลบความคิดเห็น การตอบกลับทั้งหมดของความคิดเห็นนั้นก็จะถูกลบด้วย  
* หากเมธอด [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) สร้างการอ้างอิงแบบวงกลม จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) รับอาร์กิวเมนต์ [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) นอกเหนือจากพิกัดของสไลด์และเครื่องหมายความคิดเห็น  

เมื่อส่งค่า `nullptr` เป็นอาร์กิวเมนต์รูปทรง ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์ เครื่องหมายของมันจะถูกวางตามพิกัดที่ให้ไว้ แต่ไม่ได้เชื่อมโยงกับรูปทรงใดเป็นพิเศษ ดังนั้น [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) จะคืนค่า `nullptr` เมื่อมีการระบุ [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), ความคิดเห็นจะถูกยึดกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์ ในขณะที่การเชื่อมโยงรูปทรงสามารถดึงได้ผ่าน [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)

### **ยึดความคิดเห็นสมัยใหม่กับรูปทรง**

ตัวอย่างเรียก [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) สองครั้ง: ครั้งแรกด้วยรูปทรง `nullptr` สำหรับความคิดเห็นระดับสไลด์และครั้งที่สองด้วยสี่เหลี่ยมเป็นจุดยึด การเรียก [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) จะพิมพ์ `True` สำหรับการตรวจสอบค่าว่างของความคิดเห็นระดับสไลด์และ `Revenue title` สำหรับความคิดเห็นที่ยึดไว้ ทั้งสองความคิดเห็นจะถูกบันทึกพร้อมกับงานนำเสนอ

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

### **ยึดความคิดเห็นกับประเภทรูปทรงต่าง ๆ**

ออบเจ็กต์สไลด์ใด ๆ ที่ทำตาม [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) สามารถใช้เป็นจุดยึดรูปทรงได้ ตัวอย่างทั่วไปได้แก่ [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/), และอินสแตนซ์ของ [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) เช่น แผนภูมิ  

ตัวอย่างใช้ [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) เพื่อเชื่อมโยงความคิดเห็นกับแต่ละประเภทรูปทรงห้าแบบ: AutoShape, picture frame, group, connector, และ chart รูปภาพใช้ข้อมูลภาพฝังอยู่จึงไม่จำเป็นต้องมีไฟล์ภาพภายนอก แต่ละความคิดเห็นมีตำแหน่งเครื่องหมายของตนเอง และงานนำเสนอที่บันทึกจะคงการเชื่อมโยงรูปทรงทั้งห้าไว้

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

### **ยึดความคิดเห็นกับข้อความและตั้งค่าสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), เมธอด [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) และ [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) ควบคุมตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปทรงเช่นกัน เมธอด [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) และ [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) ควบคุมความยาวของการเลือก ทั้งสองเมธอดนี้ทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape  

[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) และ [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) ใช้ค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) ซึ่งรวมถึง `Resolved`  

- `NotDefined` — ไม่ได้กำหนดสถานะความคิดเห็นสมัยใหม่เฉพาะ  
- `Active` — ความคิดเห็นกำลังทำงาน  
- `Resolved` — ความคิดเห็นได้รับการแก้ไขแล้ว  
- `Closed` — ความคิดเห็นถูกปิด  

ตัวอย่างยึดความคิดเห็นสมัยใหม่กับคำว่า "quarterly revenue" ในข้อความของสี่เหลี่ยม มันคำนวณตำแหน่งเริ่มต้นการเลือกจากศูนย์ของข้อความ ส่งค่าไปยัง [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) และเรียก [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) ด้วยจำนวนอักขระที่เลือก หลังจากเรียก [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) ด้วย `Resolved` จะบันทึกและเปิดงานนำเสนออีกครั้ง การตรวจสอบคอนโซลสี่ครั้งควรพิมพ์ `True` ทั้งหมด เพื่อยืนยันว่าการยึดรูปทรง ช่วงข้อความ และสถานะถูกเก็บรักษาไว้

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

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

ตัวอย่างต้องการงานนำเสนอที่มีความคิดเห็นสมัยใหม่และพิมพ์ข้อความ สถานะ และรายละเอียดจุดยึดของพวกมัน เพื่อทำการตรวจสอบ ให้ตรวจสอบว่าความคิดเห็นใดบ้างที่ทำตาม [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/), จากนั้นตรวจสอบ [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/), และ [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). รูปทรง `nullptr` แสดงถึงความคิดเห็นระดับสไลด์ สำหรับจุดยึด [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), เมธอดการเลือกข้อความระบุช่วงที่เชื่อมโยงในกรอบข้อความของรูปทรง

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

## **ลบความคิดเห็น**

Aspose.Slides for C++ ให้คุณลบความคิดเห็นทั้งหมดและผู้เขียนจากงานนำเสนอ หรือทำการลบความคิดเห็นที่เลือกโดยคงส่วนที่เหลือไว้ ตัวอย่างต่อไปนี้แสดงวิธีการทั้งสองและบันทึกงานนำเสนอที่อัปเดต  

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเรียก [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) สำหรับผู้เขียนแต่ละคน จากนั้นเรียก [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) เพื่อลบผู้เขียนเอง งานนำเสนอที่บันทึกจะไม่มีความคิดเห็นหรือผู้เขียนความคิดเห็นใด ๆ ใช้งานนำเสนอที่มีความคิดเห็นเพื่อสังเกตการลบ

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

### **ลบความคิดเห็นเฉพาะ**

ตัวอย่างสร้างความคิดเห็นสองรายการบนสไลด์เดียวและใช้ [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) เพื่อค้นหาความคิดเห็นตามผู้เขียนแต่ละคน รวบรวมความคิดเห็นที่ข้อความเท่ากับ "comment 1" ก่อนเรียก [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/) เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอลเลกชันระหว่างการเลือก งานนำที่บันทึกจะเหลือเฉพาะ "comment 2"

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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะที่แก้ไขแล้วสำหรับความคิดเห็นสมัยใหม่หรือ?**

ใช่. [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) และ [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) ใช้ค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) ซึ่งรวมถึง `Resolved`. สถานะนี้ถูกเก็บในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่  

**สนับสนุนการสนทนาที่เป็นเธรด (ห่วงโซ่การตอบกลับ) หรือไม่ และมีขีดจำกัดระดับการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) ทำให้สามารถสร้างห่วงโซ่การตอบกลับได้ API ไม่กำหนดขีดจำกัดความลึกการซ้อนเฉพาะ  

**พิกัดของตำแหน่งเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งเครื่องหมายถูกกำหนดด้วยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์
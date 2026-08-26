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
- ความคิดเห็นในงานนำเสนอ
- ความคิดเห็นในสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความเห็น
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for C++: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for C++. แนะนำประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและสาธิตวิธีการเพิ่มความคิดเห็นในสไลด์ เข้าถึงความคิดเห็นที่มีอยู่ ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่ และลบความคิดเห็นจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน การอ่านข้อความและเมทาดาต้าของความคิดเห็น การสร้างสายตอบกลับ และการลบความคิดเห็นที่เลือกหรือทั้งหมด

ใน PowerPoint ความคิดเห็นปรากฏเป็นหมายเหตุบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจสอบงานนำเสนอ

Aspose.Slides for C++ มี API ต่อไปนี้สำหรับทำงานกับความคิดเห็น:

* The [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icommentcollection/) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/th/cpp/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มความคิดเห็นในสไลด์ของงานนำเสนอ PowerPoint:

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

## **เข้าถึงความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่ในงานนำเสนอ PowerPoint:

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

ความคิดเห็นแม่คือความคิดเห็นต้นฉบับที่อยู่บนสุดของลำดับชั้นการตอบกลับ วิธีการ [get_ParentComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/get_parentcomment/) และ [set_ParentComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/set_parentcomment/) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/) ให้คุณดึงหรือกำหนดความคิดเห็นแม่ของความคิดเห็น

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มการตอบกลับและตรวจสอบโครงสร้างความคิดเห็นที่ได้:

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

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
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

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* เมื่อใช้เมธอด [Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/remove/) ของอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/) เพื่อลบความคิดเห็น การตอบกลับทั้งหมดของความคิดเห็นนั้นก็จะถูกลบด้วย
* หากเมธอด [set_ParentComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/set_parentcomment/) สร้างการอ้างอิงเป็นวงกลม จะมีการโยน [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง รูปทรงเฉพาะ หรือช่วงข้อความภายใน AutoShape ได้ เมธอด [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icommentcollection/addmoderncomment/) รับอาร์กิวเมนต์ประเภท [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) นอกเหนือจากพิกัดของสไลด์และเครื่องหมายความคิดเห็น

เมื่อส่งค่า `nullptr` ให้กับอาร์กิวเมนต์ shape ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์ เครื่องหมายของมันจะถูกกำหนดตำแหน่งโดยพิกัดที่ให้มา แต่จะไม่ได้เชื่อมโยงกับรูปทรงใดๆ ดังนั้น [IModernComment::get_Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_shape/) จะคืนค่า `nullptr` เมื่อมีการระบุ [IShape] ความคิดเห็นจะถูกยึดตรึงกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์ ในขณะที่การเชื่อมโยงรูปทรงสามารถดึงคืนได้ผ่าน [IModernComment::get_Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_shape/)

### **ยึดความคิดเห็นสมัยใหม่กับรูปทรง**

ตัวอย่างต่อไปนี้สร้างทั้งความคิดเห็นระดับสไลด์และความคิดเห็นสมัยใหม่ที่ยึดกับ AutoShape ที่กำหนด จากนั้นอ่านรูปทรงที่เชื่อมโยงจากแต่ละความคิดเห็น

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

### **ยึดความคิดเห็นไปยังรูปแบบรูปทรงต่างๆ**

ออบเจ็กต์สไลด์ใดที่ทำตาม [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ก็สามารถใช้เป็นตัวยึดรูปทรงได้ ตัวอย่างทั่วไปได้แก่ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnector/), และอินสแตนซ์ [IGraphicalObject](https://reference.aspose.com/slides/th/cpp/aspose.slides/igraphicalobject/) เช่นแผนภูมิ

ตัวอย่างต่อไปนี้สร้างรูปทรงหลายประเภททั่วไปและเชื่อมโยงความคิดเห็นสมัยใหม่กับแต่ละรูปทรง

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

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/), เมธอด [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_textselectionstart/) และ [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/set_textselectionstart/) ควบคุมตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปทรงเช่นนั้นเดียวกัน เมธอด [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_textselectionlength/) และ [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/set_textselectionlength/) ควบคุมความยาวของการเลือก ทั้งสองเมธอดร่วมกันทำให้ความ​คิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

[IModernComment::get_Status](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_status/) และ [IModernComment::set_Status](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/set_status/) ใช้ค่าจาก enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/cpp/aspose.slides/moderncommentstatus/) :

- `NotDefined` — ไม่ได้กำหนดสถานะความคิดเห็นสมัยใหม่เฉพาะใด
- `Active` — ความคิดเห็นอยู่ในสถานะใช้งาน
- `Resolved` — ความคิดเห็นถูกทำให้เสร็จสิ้น
- `Closed` — ความคิดเห็นถูกปิด

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ที่ยึดกับรูปทรง, เชื่อมโยงกับการเลือกข้อความ, ทำเครื่องหมายว่าได้แก้ไขแล้ว, บันทึกงานนำเสนอ, และตรวจสอบค่าหลังจากเปิดไฟล์ใหม่

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

เพื่อสอบตรวจงานนำเสนอที่มีอยู่ ตรวจสอบว่าความคิดเห็นใดบ้างที่ทำตาม [IModernComment](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/), แล้วตรวจสอบ [IModernComment::get_Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_textselectionlength/), และ [IModernComment::get_Status](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_status/). รูปทรงที่เป็น `nullptr` แสดงว่าความคิดเห็นระดับสไลด์ สำหรับตัวยึด [IAutoShape] วิธีการเลือกข้อความจะบ่งบอกช่วงที่เชื่อมโยงในกรอบข้อความของรูปทรงนั้น

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

### **ลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็น**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็นจากงานนำเสนอ:

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

### **ลบความคิดเห็นที่ระบุ**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นที่ระบุจากสไลด์:

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

**Aspose.Slides รองรับสถานะ 'Resolved' สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [IModernComment::get_Status](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/get_status/) และ [IModernComment::set_Status](https://reference.aspose.com/slides/th/cpp/aspose.slides/imoderncomment/set_status/) ใช้ค่าจาก enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/cpp/aspose.slides/moderncommentstatus/) รวมถึง `Resolved`. สถานะนี้ถูกบันทึกในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่

**สนับสนุนการสนทนาที่เป็นเธรด (สายการตอบกลับ) หรือไม่ และมีขีดจำกัดระดับการซ้อนกันหรือไม่?**

ใช่. ความคิดเห็นแต่ละข้อสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/cpp/aspose.slides/icomment/set_parentcomment/) ของมัน ทำให้สามารถสร้างสายการตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันแบบเฉพาะเจาะจง

**ตำแหน่งเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งเครื่องหมายถูกกำหนดด้วยพิกัดจุดลอยในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์
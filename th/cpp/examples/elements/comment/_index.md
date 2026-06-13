---
title: ความคิดเห็น
type: docs
weight: 230
url: /th/cpp/examples/elements/comment/
keywords:
- ตัวอย่างโค้ด
- ความคิดเห็น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานกับความคิดเห็นสไลด์ใน Aspose.Slides for C++: เพิ่ม, ตอบกลับ, แก้ไข, แก้ปัญหา, และส่งออกความคิดเห็นในงานนำเสนอ PPT, PPTX, และ ODP ด้วยตัวอย่างโค้ด C++."
---
บทความนี้สาธิตการเพิ่ม, การอ่าน, การลบ, และการตอบกลับความคิดเห็นสมัยใหม่โดยใช้ **Aspose.Slides for C++**.

## **เพิ่มความคิดเห็นสมัยใหม่**

สร้างความคิดเห็นโดยผู้ใช้และบันทึกงานนำเสนอ

```cpp
static void AddModernComment()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto author = presentation->get_CommentAuthors()->AddAuthor(u"User", u"U1");

    author->get_Comments()->AddModernComment(
        u"This is a modern comment", slide, nullptr, PointF(100, 100), DateTime::get_Now());

    presentation->Save(u"modern_comment.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **เข้าถึงความคิดเห็นสมัยใหม่**

อ่านความคิดเห็นสมัยใหม่จากงานนำเสนอที่มีอยู่

```cpp
static void AccessModernComment()
{
    auto presentation = MakeObject<Presentation>(u"modern_comment.pptx");

    auto author = presentation->get_CommentAuthor(0);
    auto comment = ExplicitCast<SharedPtr<IModernComment>>(author->get_Comment(0));

    Console::WriteLine(u"Author: {0}, Comment: {1}, Position: {2}",
        author->get_Name(), comment->get_Text(), comment->get_Position());

    presentation->Dispose();
}
```

## **ลบความคิดเห็นสมัยใหม่**

ลบความคิดเห็นและบันทึกไฟล์ที่อัปเดต

```cpp
static void RemoveModernComment()
{
    auto presentation = MakeObject<Presentation>(u"modern_comment.pptx");
    auto author = presentation->get_CommentAuthor(0);

    auto comment = author->get_Comment(0);
    comment->Remove();

    presentation->Save(u"modern_comment_removed.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **ตอบกลับความคิดเห็นสมัยใหม่**

เพิ่มการตอบกลับให้กับความคิดเห็นสมัยใหม่ที่เป็นพาเรนต์

```cpp
static void ReplyToModernComment()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto author = presentation->get_CommentAuthors()->AddAuthor(u"User", u"U1");

    auto parentComment = author->get_Comments()->AddModernComment(
        u"Parent comment", slide, nullptr, PointF(100, 100), DateTime::get_Now());

    auto reply1 = author->get_Comments()->AddModernComment(
        u"Reply 1", slide, nullptr, PointF(110, 100), DateTime::get_Now());

    auto reply2 = author->get_Comments()->AddModernComment(
        u"Reply 2", slide, nullptr, PointF(120, 100), DateTime::get_Now());

    reply1->set_ParentComment(parentComment);
    reply2->set_ParentComment(parentComment);

    presentation->Save(u"modern_comment_replies.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```
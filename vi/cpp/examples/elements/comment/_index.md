---
title: Bình luận
type: docs
weight: 230
url: /vi/cpp/examples/elements/comment/
keywords:
- ví dụ mã
- bình luận
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Làm việc với bình luận trên slide trong Aspose.Slides for C++: thêm, trả lời, chỉnh sửa, giải quyết và xuất bình luận trong các bản trình chiếu PPT, PPTX và ODP với các ví dụ mã C++."
---
Bài viết này trình bày cách thêm, đọc, xóa và trả lời các nhận xét hiện đại bằng **Aspose.Slides for C++**.

## **Thêm Nhận Xét Hiện Đại**

Tạo một nhận xét do người dùng tạo và lưu bản trình chiếu.

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

## **Truy Cập Nhận Xét Hiện Đại**

Đọc một nhận xét hiện đại từ bản trình chiếu hiện có.

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

## **Xóa Nhận Xét Hiện Đại**

Xóa một nhận xét và lưu file đã cập nhật.

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

## **Trả Lời Nhận Xét Hiện Đại**

Thêm trả lời vào một nhận xét hiện đại cha.

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
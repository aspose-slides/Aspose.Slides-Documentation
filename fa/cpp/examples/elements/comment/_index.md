---
title: نظر
type: docs
weight: 230
url: /fa/cpp/examples/elements/comment/
keywords:
- مثال کد
- نظر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کار با نظرات اسلاید در Aspose.Slides for C++: افزودن، پاسخ، ویرایش، حل و استخراج نظرات در ارائه‌های PPT، PPTX و ODP با مثال‌های کد C++."
---
این مقاله افزودن، خواندن، حذف و پاسخ به نظرات مدرن را با استفاده از **Aspose.Slides for C++** نشان می‌دهد.

## **افزودن یک نظر مدرن**

یک نظر توسط یک کاربر ایجاد کنید و ارائه را ذخیره کنید.

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

## **دسترسی به یک نظر مدرن**

یک نظر مدرن را از یک ارائه موجود بخوانید.

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

## **حذف یک نظر مدرن**

یک نظر را حذف کنید و فایل به‌روز شده را ذخیره کنید.

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

## **پاسخ به یک نظر مدرن**

پاسخ‌ها را به یک نظر مدرن والد اضافه کنید.

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
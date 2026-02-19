---
title: تعليق
type: docs
weight: 230
url: /ar/cpp/examples/elements/comment/
keywords:
- مثال على الكود
- تعليق
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "التعامل مع تعليقات الشرائح في Aspose.Slides for C++: الإضافة، الرد، التعديل، الحل، وتصدير التعليقات في عروض PPT و PPTX و ODP باستخدام أمثلة كود C++."
---
توضح هذه المقالة كيفية الإضافة والقراءة والإزالة والرد على التعليقات الحديثة باستخدام **Aspose.Slides for C++**.

## **إضافة تعليق حديث**

إنشاء تعليق من تأليف مستخدم وحفظ العرض التقديمي.

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

## **الوصول إلى تعليق حديث**

قراءة تعليق حديث من عرض تقديمي موجود.

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

## **إزالة تعليق حديث**

إزالة التعليق وحفظ الملف المحدث.

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

## **الرد على تعليق حديث**

إضافة ردود إلى تعليق حديث رئيسي.

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
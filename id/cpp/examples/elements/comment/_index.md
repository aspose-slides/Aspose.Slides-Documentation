---
title: Komentar
type: docs
weight: 230
url: /id/cpp/examples/elements/comment/
keywords:
- contoh kode
- komentar
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bekerja dengan komentar slide di Aspose.Slides for C++: menambahkan, membalas, mengedit, menyelesaikan, dan mengekspor komentar dalam presentasi PPT, PPTX, dan ODP dengan contoh kode C++."
---
Artikel ini memperlihatkan cara menambah, membaca, menghapus, dan membalas komentar modern menggunakan **Aspose.Slides for C++**.

## **Menambahkan Komentar Modern**

Buat komentar yang ditulis oleh pengguna dan simpan presentasi.

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

## **Mengakses Komentar Modern**

Baca komentar modern dari presentasi yang sudah ada.

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

## **Menghapus Komentar Modern**

Hapus komentar dan simpan file yang telah diperbarui.

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

## **Membalas Komentar Modern**

Tambahkan balasan ke komentar modern induk.

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
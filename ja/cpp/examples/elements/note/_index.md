---
title: ノート
type: docs
weight: 240
url: /ja/cpp/examples/elements/note/
keywords:
- コード例
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライドノートを操作します。C++ の明快なサンプルを使用して、ノートの追加、読み取り、編集、そして PPT、PPTX、ODP へのスピーカーノートのエクスポートを行います。"
---
この記事では、**Aspose.Slides for C++** を使用してノート スライドの追加、読み取り、削除、更新方法を示します。

## **ノート スライドの追加**

ノート スライドを作成し、テキストを割り当てます。

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **ノート スライドにアクセス**

既存のノート スライドからテキストを読み取ります。

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **ノート スライドの削除**

スライドに関連付けられたノート スライドを削除します。

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **ノート テキストの更新**

ノート スライドのテキストを変更します。

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```
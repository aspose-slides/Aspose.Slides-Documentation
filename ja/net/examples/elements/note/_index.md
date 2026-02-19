---
title: ノート
type: docs
weight: 240
url: /ja/net/examples/elements/note/
keywords:
- ノート
- ノート スライドの追加
- ノート スライドへのアクセス
- ノート スライドの削除
- ノート テキストの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライド ノートを操作します。ノートの追加、読み取り、編集、そして PPT、PPTX、ODP でスピーカーノートをエクスポートする方法を、分かりやすい C# のサンプルで示しています。"
---
この記事では、**Aspose.Slides for .NET** を使用して、ノート スライドの追加、読み取り、削除、更新方法を実演します。

## **ノート スライドの追加**

ノート スライドを作成し、テキストを割り当てます。

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **ノート スライドへのアクセス**

既存のノート スライドからテキストを読み取ります。

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **ノート スライドの削除**

スライドに関連付けられたノート スライドを削除します。

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **ノート テキストの更新**

ノート スライドのテキストを変更します。

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```
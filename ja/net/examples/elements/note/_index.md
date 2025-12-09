---
title: ノート
type: docs
weight: 240
url: /ja/net/examples/elements/elements/note/
keywords:
- ノート例
- ノートスライドの追加
- ノートスライドへのアクセス
- ノートスライドの削除
- ノートテキストの更新
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してスピーカー ノートを追加、読み取り、編集、エクスポートします。テキストの書式設定、スライドごとのノート管理、PowerPoint および OpenDocument での表示制御が可能です。"
---

Aspose.Slides for .NET を使用して、ノート スライドの追加、読み取り、削除、更新を行う方法を示します。

## ノート スライドの追加

ノート スライドを作成し、テキストを割り当てます。
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## ノート スライドへのアクセス

既存のノート スライドからテキストを読み取ります。
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## ノート スライドの削除

スライドに関連付けられたノート スライドを削除します。
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## ノート テキストの更新

ノート スライドのテキストを変更します。
```csharp
static void Update_Note_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```

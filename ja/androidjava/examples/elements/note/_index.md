---
title: ノート
type: docs
weight: 240
url: /ja/androidjava/examples/elements/note/
keywords:
- コード例
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でスライドノートを操作します。Java の分かりやすい例を使用して、PPT、PPTX、ODP のスピーカーノートを追加、読み取り、編集、エクスポートできます。"
---
この記事では、**Aspose.Slides for Android via Java** を使用して、ノートスライドの追加、読み取り、削除、更新方法を示します。

## **ノートスライドの追加**

ノートスライドを作成し、テキストを割り当てます。

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **ノートスライドへのアクセス**

既存のノートスライドからテキストを読み取ります。

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **ノートスライドの削除**

スライドに関連付けられたノートスライドを削除します。

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **ノートテキストの更新**

ノートスライドのテキストを変更します。

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```
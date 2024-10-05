---
title: プレゼンテーションのノート
type: docs
weight: 110
url: /java/presentation-notes/
keywords: "JavaにおけるPowerPointのスピーカーノート"
description: "プレゼンテーションノート、Javaにおけるスピーカーノート"
---


{{% alert color="primary" %}} 

Aspose.Slidesはプレゼンテーションからノートスライドを削除する機能をサポートしています。このトピックでは、ノートを削除するという新しい機能と、任意のプレゼンテーションからスタイル付きのノートスライドを追加する機能について紹介します。

{{% /alert %}} 

Aspose.Slides for Javaは、任意のスライドのノートを削除する機能と既存のノートにスタイルを追加する機能を提供します。開発者は以下の方法でノートを削除できます：

* プレゼンテーションの特定のスライドのノートを削除する
* プレゼンテーションのすべてのスライドのノートを削除する


## **スライドからノートを削除する**
特定のスライドのノートを以下の例のように削除できます：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 最初のスライドのノートを削除
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // プレゼンテーションをディスクに保存
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションからノートを削除する**
プレゼンテーションのすべてのスライドのノートを以下の例のように削除できます：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // すべてのスライドのノートを削除
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // プレゼンテーションをディスクに保存
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ノートスタイルを追加**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--)メソッドが[IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide)インターフェイスと[MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide)クラスに追加されました。このプロパティはノートテキストのスタイルを指定します。実装は以下の例に示されています。

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlideテキストスタイルを取得
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // 最初のレベルの段落にシンボルバレットを設定
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
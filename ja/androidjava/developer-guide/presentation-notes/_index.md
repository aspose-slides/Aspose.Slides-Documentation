---
title: プレゼンテーションノート
type: docs
weight: 110
url: /ja/androidjava/presentation-notes/
keywords: "JavaでのPowerPointスピーカーノート"
description: "プレゼンテーションノート、Javaでのスピーカーノート"
---


{{% alert color="primary" %}} 

Aspose.Slidesはプレゼンテーションからノートスライドを削除する機能をサポートしています。このトピックでは、任意のプレゼンテーションからノートを削除する新しい機能と、スタイルスライドを追加することについて紹介します。

{{% /alert %}} 

Aspose.Slides for Android via Javaは、任意のスライドのノートを削除し、既存のノートにスタイルを追加する機能を提供します。開発者は以下の方法でノートを削除できます：

* プレゼンテーションの特定のスライドのノートを削除する。
* プレゼンテーションのすべてのスライドのノートを削除する。


## **スライドからノートを削除する**
特定のスライドのノートは、以下の例のように削除できます：

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
プレゼンテーションのすべてのスライドのノートは、以下の例のように削除できます：

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

## **ノートスタイルを追加する**
[getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--)メソッドは、[IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide)インターフェイスおよび[MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide)クラスに追加されました。このプロパティは、ノートテキストのスタイルを指定します。実装は以下の例で示されています。

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlideのテキストスタイルを取得
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
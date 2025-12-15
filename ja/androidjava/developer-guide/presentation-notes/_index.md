---
title: Android でプレゼンテーションノートを管理する
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/androidjava/presentation-notes/
keywords:
- ノート
- ノートスライド
- ノートの追加
- ノートの削除
- ノートスタイル
- マスターノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してプレゼンテーションノートをカスタマイズします。PowerPoint および OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---

{{% alert color="primary" %}} 

Aspose.Slides はプレゼンテーションからノートスライドを削除する機能をサポートしています。このトピックでは、ノートを削除する新機能と、任意のプレゼンテーションにノートスタイルのスライドを追加する方法を紹介します。 

{{% /alert %}} 

Aspose.Slides for Android via Java は、任意のスライドのノートを削除したり、既存のノートにスタイルを追加したりする機能を提供します。開発者は次の方法でノートを削除できます。

* プレゼンテーション内の特定のスライドのノートを削除する。
* プレゼンテーション内のすべてのスライドのノートを削除する


## **スライドからノートを削除**
特定のスライドのノートを削除する例を以下に示します。
```java
// プレゼンテーションファイルを表す Presentation オブジェクトを作成します
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 最初のスライドのノートを削除します
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // プレゼンテーションをディスクに保存します
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレゼンテーションからノートを削除**
プレゼンテーション内のすべてのスライドのノートを削除する例を以下に示します。
```java
// プレゼンテーションファイルを表す Presentation オブジェクトを作成します
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // すべてのスライドのノートを削除します
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // プレゼンテーションをディスクに保存します
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ノートスタイルを追加**
[getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) メソッドが [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) インターフェイスと [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) クラスにそれぞれ追加されました。このプロパティはノートテキストのスタイルを指定します。実装例は以下のとおりです。
```java
// プレゼンテーションファイルを表す Presentation オブジェクトを作成します
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide のテキストスタイルを取得します
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // 最初のレベルの段落にシンボル箇条書きを設定します
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**特定のスライドのノートにアクセスできる API エンティティはどれですか？**

ノートはスライドのノートマネージャーを介してアクセスされます。スライドには [NotesSlideManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/) があり、ノートオブジェクト（またはノートが存在しない場合は `null`）を返す [method](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) が用意されています。

**ライブラリが対応している PowerPoint のバージョン間でノートサポートに違いはありますか？**

本ライブラリは Microsoft PowerPoint の広範な形式（97 以降のバージョンおよび ODP）を対象としており、インストールされた PowerPoint の有無に関係なく、これらの形式内でノートがサポートされています。
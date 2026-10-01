---
title: Android でプレゼンテーション ノートを管理する
linktitle: プレゼンテーション ノート
type: docs
weight: 110
url: /ja/androidjava/presentation-notes/
keywords:
- ノート
- ノート スライド
- ノートを追加
- ノートを削除
- ノート スタイル
- マスターノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 用 Aspose.Slides でプレゼンテーション ノートをカスタマイズします。PowerPoint および OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---
## **概要**

Aspose.Slides はプレゼンテーションからノート スライドを削除する機能をサポートしています。このトピックでは、ノートの削除方法とプレゼンテーション内のノート スライドにスタイルを適用する方法について紹介します。Aspose.Slides を使用すると、任意のスライドからノートを削除したり、既存のノートにスタイリングを適用したりできます。開発者は次の方法でノートを削除できます。

- プレゼンテーション内の特定のスライドからノートを削除する。
- プレゼンテーション内のすべてのスライドからノートを削除する。

ノート ページのサイズを読み取ったり変更したり、向きを切り替えたり、エクスポートの動作を確認するには、[Notes Page Size](/slides/ja/androidjava/notes-size/) を参照してください。

## **スライドからノートを削除する**
特定のスライドからノートを削除する例は以下のとおりです。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 最初のスライドのノートを削除しています
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // プレゼンテーションをディスクに保存しています
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションからノートを削除する**
プレゼンテーション内のすべてのスライドからノートを削除する例は以下のとおりです。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // すべてのスライドのノートを削除しています
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // プレゼンテーションをディスクに保存しています
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ノート スタイルの追加**
[getNotesStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) メソッドが [IMasterNotesSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IMasterNotesSlide) インターフェイスと [MasterNotesSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/MasterNotesSlide) クラスにそれぞれ追加されました。このプロパティはノート テキストのスタイルを指定します。実装は以下の例で示されています。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide のテキスト スタイルを取得します
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // 最初のレベルの段落にシンボルバレットを設定します
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

ノートはスライドのノート マネージャーを介してアクセスされます。スライドには [NotesSlideManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notesslidemanager/) があり、ノート オブジェクトを返す [method](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) が用意されています。ノートが存在しない場合は `null` が返されます。

**ライブラリが対応する PowerPoint バージョン間でノートのサポートに違いがありますか？**

このライブラリは Microsoft PowerPoint の幅広い形式（97 以降）および ODP を対象としており、インストールされた PowerPoint の有無に関係なくこれらの形式でノートがサポートされます。
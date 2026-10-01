---
title: JavaScript でプレゼンテーションノートを管理
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して JavaScript でプレゼンテーションノートをカスタマイズします。PowerPoint と OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---
## **概要**

Aspose.Slides はプレゼンテーションからノート スライドを削除する機能をサポートしています。本トピックでは、この機能の概要と、ノートの削除方法およびプレゼンテーション内のノート スライドにスタイルを適用する方法を紹介します。Aspose.Slides を使用すると、任意のスライドからノートを削除したり、既存のノートにスタイルを適用したりできます。開発者は次の方法でノートを削除できます。

- プレゼンテーション内の特定のスライドからノートを削除する。
- プレゼンテーション内のすべてのスライドからノートを削除する。

ノート ページのサイズを読み取ったり変更したり、向きを切り替えたり、エクスポートの動作を確認したりするには、[Notes Page Size](/slides/ja/nodejs-java/notes-size/) を参照してください。

## **スライドからノートを削除する**
特定のスライドからノートを削除する方法は、以下の例のとおりです。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 最初のスライドのノートを削除
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // プレゼンテーションをディスクに保存
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **プレゼンテーションからノートを削除する**
プレゼンテーション内のすべてのスライドからノートを削除する方法は、以下の例のとおりです。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // すべてのスライドのノートを削除
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // プレゼンテーションをディスクに保存
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle の追加**
[getNotesStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) メソッドが [MasterNotesSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/MasterNotesSlide) クラスに追加されました。このプロパティはノート テキストのスタイルを指定します。実装例は以下のとおりです。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide のテキストスタイルを取得
        var notesStyle = notesMaster.getNotesStyle();
        // 最初のレベルの段落にシンボル バレットを設定
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**特定のスライドのノートにアクセスできる API エンティティはどれですか？**

ノートはスライドのノート マネージャーを通じてアクセスされます。スライドには [NotesSlideManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notesslidemanager/) があり、ノート オブジェクト（ノートが存在しない場合は `null`）を返す [method](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) が提供されています。

**ライブラリが対応する PowerPoint バージョン間でノートサポートに違いはありますか？**

このライブラリは Microsoft PowerPoint の広範なフォーマット（97 以降）と ODP を対象としており、これらのフォーマット内でノートは PowerPoint がインストールされていなくてもサポートされます。
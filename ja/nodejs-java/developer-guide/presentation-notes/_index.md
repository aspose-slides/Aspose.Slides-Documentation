---
title: プレゼンテーションノート
type: docs
weight: 110
url: /ja/nodejs-java/presentation-notes/
keywords: "JavaScript の PowerPoint スピーカーノート"
description: "JavaScript のプレゼンテーションノート、スピーカーノート"
---

{{% alert color="primary" %}} 
Aspose.Slides はプレゼンテーションからノートスライドを削除することをサポートしています。このトピックでは、ノートを削除し、任意のプレゼンテーションにノートスタイルスライドを追加するこの新機能をご紹介します。 
{{% /alert %}} 
Aspose.Slides for Node.js via Java は、任意のスライドのノートを削除し、既存のノートにスタイルを追加する機能を提供します。開発者は以下の方法でノートを削除できます：
* プレゼンテーションの特定のスライドのノートを削除する。
* プレゼンテーションのすべてのスライドのノートを削除する

## **スライドからノートを削除**
以下の例のように、特定のスライドのノートを削除できます。  
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 最初のスライドのノートを削除します
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // プレゼンテーションをディスクに保存します
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **プレゼンテーションからノートを削除**
以下の例のように、プレゼンテーション内のすべてのスライドのノートを削除できます。  
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // すべてのスライドのノートを削除します
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // プレゼンテーションをディスクに保存します
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ノートスタイルの追加**
[getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) メソッドが [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) クラスに追加されました。このプロパティはノートテキストのスタイルを指定します。実装例は以下の例で示しています。  
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide のテキストスタイルを取得します
        var notesStyle = notesMaster.getNotesStyle();
        // 最初のレベルの段落にシンボル箇条書きを設定します
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**特定のスライドのノートへアクセスできる API エンティティはどれですか？**  
ノートはスライドのノートマネージャーを介してアクセスされます。スライドには [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) があり、ノートオブジェクトを返す [method](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) が用意されています。ノートが存在しない場合は `null` が返されます。

**ライブラリが対応する PowerPoint バージョン間でノートのサポートに違いはありますか？**  
このライブラリは Microsoft PowerPoint のさまざまな形式（97 以降）および ODP を対象としており、これらの形式では PowerPoint がインストールされているかどうかに依存せずノートがサポートされています。
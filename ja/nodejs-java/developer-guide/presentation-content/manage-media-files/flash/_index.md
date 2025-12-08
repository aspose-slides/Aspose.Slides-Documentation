---
title: Flash
type: docs
weight: 10
url: /ja/nodejs-java/flash/
description: JavaScript を使用して PowerPoint プレゼンテーションから Flash オブジェクトを抽出
---

## **プレゼンテーションからFlashオブジェクトを抽出**

Aspose.Slides for Node.js via Java は、プレゼンテーションから flash オブジェクトを抽出する機能を提供します。名前で flash コントロールにアクセスし、プレゼンテーションから抽出して SWF オブジェクトデータを格納できます。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Flash コンテンツ抽出時にサポートされるプレゼンテーション形式は何ですか？**

[Aspose.Slides supports](/slides/ja/nodejs-java/supported-file-formats/) は、PPT や PPTX などの主要な PowerPoint 形式をサポートします。これらのコンテナをロードしてコントロールにアクセスでき、Flash 関連の ActiveX 要素も含まれます。

**Flash を含むプレゼンテーションを HTML5 に変換し、Flash のインタラクティブ性を保持できますか？**

いいえ。Aspose.Slides は SWF コンテンツを実行せず、インタラクティブ性も変換しません。[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/ja/nodejs-java/export-to-html5/) へのエクスポートはサポートされていますが、モダンブラウザではサポート終了のため Flash は再生されません。推奨される方法は、エクスポート前に Flash を動画や HTML5 アニメーションなどの代替手段に置き換えることです。

**セキュリティ観点から、プレゼンテーションの読み取り中に Aspose.Slides は SWF ファイルを実行しますか？**

いいえ。Aspose.Slides は Flash をファイルに埋め込まれたバイナリ データとして扱い、処理中に SWF コンテンツを実行しません。

**OLE を介して埋め込まれた他のファイルと共に Flash を含むプレゼンテーションはどのように扱うべきですか？**

Aspose.Slides は [extracting embedded OLE objects](/slides/ja/nodejs-java/manage-ole/) をサポートしているため、関連する埋め込みコンテンツを一括で処理でき、Flash コントロールと他の OLE 埋め込みドキュメントを同時に扱うことができます。
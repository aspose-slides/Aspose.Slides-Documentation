---
title: PowerPoint アドインを使用して OLE オブジェクトを自動的に更新する
type: docs
weight: 10
url: /ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE オブジェクト
- OLE を更新
- 自動的に
- アドイン
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint でアドインと Aspose.Slides for Java を使用して OLE チャートやオブジェクトを自動的に更新する方法を確認し、実用的なコードと最適化のヒントをご紹介します。"
---

## **OLE オブジェクトを自動的に更新する**

Aspose.Slides for Java のお客様から最も頻繁に寄せられる質問の一つは、プレゼンテーションを開いたときに自動的に更新される編集可能なチャート（またはその他の OLE オブジェクト）を作成または変更する方法です。残念ながら、PowerPoint は Excel や Word と同様に自動マクロをサポートしていません。利用できるマクロは `Auto_Open` と `Auto_Close` だけで、これらはアドインから自動的に実行されます。この短いテクニカルチップでは、その実現方法を示します。

まず、PowerPoint に Auto_Open マクロ機能を追加するフリーウェアのアドインがいくつか利用可能です。例として [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) と [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html) が挙げられます。

これらのアドインのいずれかをインストールしたら、以下のようにテンプレートプレゼンテーションに `Auto_Open()` マクロ（Event Generator を使用している場合は `OnPresentationOpen()`）を追加するだけです:
```java
// プレゼンテーション内の各スライドをループ処理します。
for (var oSlide : ActivePresentation.Slides) {
    // 現在のスライド上のすべてのシェイプをループ処理します。
    for (var oShape : oSlide.Shapes) {
        // シェイプが OLE オブジェクトかどうかを確認します。
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // OLE オブジェクトが見つかりました。オブジェクト参照を取得し、更新します。
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // 現在、OLE サーバープログラムを終了します。
            // これによりメモリが解放され、問題が防止されます。
            // また、オブジェクトを解放するために oObject を Nothing に設定します。
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```


Aspose.Slides for Java で OLE オブジェクトに加えた変更は、PowerPoint がプレゼンテーションを開くと自動的に更新されます。多数の OLE オブジェクトがありすべてを更新したくない場合は、処理する必要があるシェイプにカスタムタグを付け、マクロ内でそのタグをチェックしてください。
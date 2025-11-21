---
title: JavaScript で PowerPoint プレゼンテーションを作成する
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/nodejs-java/create-presentation/
keywords: ppt作成 java, pptプレゼンテーション作成, pptx作成 java
description: JavaScript を使用して、PPT や PPTX などの PowerPoint プレゼンテーションをゼロから作成する方法を学びます。
---

## **PowerPoint プレゼンテーションの作成**

プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください：

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapes オブジェクトが公開する addAutoShape メソッドで Line タイプの AutoShape を追加します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var slide = pres.getSlides().get_Item(0);
    // ラインタイプのオートシェイプを追加します
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**新しいプレゼンテーションを保存できる形式は何ですか？**

[PPTX、PPT、ODP](/slides/ja/nodejs-java/save-presentation/) に保存でき、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/)、[SVG](/slides/ja/nodejs-java/convert-powerpoint-to-png/)、および[画像](/slides/ja/nodejs-java/convert-powerpoint-to-png/) にエクスポートできます。

**テンプレート (POTX/POTM) から開始して、通常の PPTX として保存できますか？**

はい。テンプレートをロードし、目的の形式に保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/nodejs-java/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比をどのように制御しますか？**

[スライド サイズ](/slides/ja/nodejs-java/slide-size/) を設定します（4:3 や 16:9 のプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

**サイズと座標の単位は何ですか？**

ポイントで表します。1 インチは 72 ユニットです。

**非常に大きなプレゼンテーション（多数のメディアファイル）でメモリ使用量を削減するにはどうすればよいですか？**

[BLOB 管理戦略](/slides/ja/nodejs-java/manage-blob/) を使用し、一時ファイルを活用してメモリ内ストレージを制限し、純粋なメモリストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並列に作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/nodejs-java/multithreading/)から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

**トライアル透かしと制限を削除するにはどうすればよいですか？**

プロセスごとに1回[ライセンスを適用](/slides/ja/nodejs-java/licensing/)してください。ライセンス XML は変更せず、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付けられますか？**

はい。[デジタル署名](/slides/ja/nodejs-java/digital-signature-in-powerpoint/)（追加と検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/nodejs-java/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ対応ファイルとして保存できます。
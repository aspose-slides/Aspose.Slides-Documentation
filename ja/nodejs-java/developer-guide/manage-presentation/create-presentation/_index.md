---
title: JavaScriptでプレゼンテーションを作成する
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/nodejs-java/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PPTを作成
- 新しいPPT
- PPTXを作成
- 新しいPPTX
- ODPを作成
- 新しいODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用してプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して確実な結果を得られます。"
---
## **概要**

このガイドでは、Aspose.Slidesでプレゼンテーションを作成し、最初のスライドにテキストボックスを追加し、結果をファイルとして保存する方法を示します。

開始する前に、npmから `aspose.slides.via.java` パッケージをインストールし、必要な JDK、Python、C++ ビルドツールもインストールしてください。詳細は[Installation](/slides/ja/nodejs-java/installation/)をご覧ください。

## **PowerPoint プレゼンテーションの作成**

プレゼンテーションを作成し、最初のスライドにテキストボックスを配置するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。新しいプレゼンテーションには既に空のスライドが1枚含まれています。
1. [slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) からインデックス0でそのスライドを取得します。
1. [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) メソッドで矩形を追加し、[setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/) でテキストを設定します。
1. [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PPTX ファイルとして保存します。
1. [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/) メソッドでプレゼンテーションを解放し、プロセスを終了します。

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides は Node.js を継続させる Java 仮想マシン上で実行されるため、プロセスを明示的に終了します。
process.exit(0);
```

矩形の左上隅はスライドの左端から50ポイント、上端から50ポイントの位置にあり、幅が400ポイント、高さが100ポイントです。コードをプロジェクトフォルダーに *hello.js* として保存し、`node hello.js` を実行します。これにより現在のフォルダーに *hello.pptx* が作成され、1枚のスライドに矩形とそのテキストが含まれます。

Aspose.Slides は、`java` パッケージが Node.js プロセス内で起動する Java 仮想マシン上で実行されます。その仮想マシンにより、スクリプト完了後に Node.js が自動的に終了しないようになるため、サンプルは `process.exit(0)` で終了します。

ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを追加します。詳細は[Licensing](/slides/ja/nodejs-java/licensing/)をご覧ください。

## **よくある質問**

### 新しいプレゼンテーションを保存できる形式は何ですか？

保存は [PPTX、PPT、ODP](/slides/ja/nodejs-java/save-presentation/) が可能で、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/)、[SVG](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/) および [画像](/slides/ja/nodejs-java/convert-powerpoint-to-png/) などにもエクスポートできます。

### テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？

はい。テンプレートを読み込み、目的の形式で保存できます。POTX、POTM、PPTM などの形式は[サポートされています](/slides/ja/nodejs-java/supported-file-formats/)。

### プレゼンテーション作成時にスライドサイズやアスペクト比を制御するには？

[slide size](/slides/ja/nodejs-java/slide-size/) を設定します（4:3 や 16:9 などのプリセットまたはカスタムサイズ）。コンテンツのスケーリング方法も選択できます。

### サイズや座標の単位は何ですか？

ポイント単位です。1 インチは 72 ポイントに相当します。

### メディアファイルが多数ある大規模なプレゼンテーションのメモリ使用量を削減するには？

[BLOB 管理戦略](/slides/ja/nodejs-java/manage-blob/) を使用し、テンポラリファイルを活用してメモリ内保存を制限し、純粋なメモリストリームよりもファイルベースのワークフローを優先してください。

### プレゼンテーションを並列で作成/保存できますか？

同じ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) インスタンスに対して [複数のスレッド](/slides/ja/nodejs-java/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々のインスタンスを実行してください。

### 試用版の透かしや制限を解除するには？

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/nodejs-java/licensing/)してください。ライセンス XML は変更せず、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

### 作成した PPTX にデジタル署名できますか？

はい。[デジタル署名](/slides/ja/nodejs-java/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

### 作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？

はい。[VBA プロジェクトの作成/編集](/slides/ja/nodejs-java/presentation-via-vba/) が可能で、PPTM や PPSM といったマクロ有効ファイルとして保存できます。
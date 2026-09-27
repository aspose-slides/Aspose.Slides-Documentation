---
title: Aspose.Slides の評価
type: docs
weight: 120
url: /ja/nodejs-net/evaluate-aspose-slides/
keywords:
- Aspose.Slides を評価
- 評価版
- 評価用透かし
- 試用制限
- 一時ライセンス
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET の評価版が制限する内容、および両方の制限を示すスクリプトと、ライセンスでそれらを削除する方法。"
---
## **概要**

Aspose.Slides for Node.js via .NET の評価版は、ライセンス版と同じ npm パッケージです。ライセンスがない場合、評価モードで実行されます。すべての機能は動作しますが、保存されたプレゼンテーションやほとんどのエクスポートには透かしが入り、コードで取得したテキストは切り詰められます。本記事ではこれらの制限を説明し、削除方法を示します。

## **評価版の制限**

**すべてのスライドに評価用透かしが付く。** ライセンスなしでプレゼンテーションを保存すると、Aspose.Slides は保存ファイルの各スライドの中央にテキストボックスを追加します。このテキストボックスはロックされており、「Evaluation only.」に続いて製品ラインと著作権行が表示されます。透かしはメモリ上のプレゼンテーションではなく、保存されたファイルに埋め込まれます。そのため、プレゼンテーションを開くだけでは透かしは追加されません。ただし、評価モードで保存されたファイルを再度開いて保存すると、各スライドに 2 つ目の透かしが付加されます。

PDF、XPS、HTML へのエクスポートやスライドを画像としてレンダリングする場合も、同じ透かしが出力に描画されます。評価モードで保存されたプレゼンテーションをレンダリングすると、画像には保存時の透かしとレンダリング時の透かしの両方が表示されます。

**コードが取得するテキストが切り詰められる。** テキストフレーム、段落、またはパーツの `text` プロパティを通じてコードが取得するテキストは、最初の 5 文字に切り詰められ、続けて「... text has been truncated due to evaluation version limitation.」という通知が付加されます。5 文字以下のテキストはそのまま返されます。この動作はすべてのスライドに適用され、コードで直後に設定したテキストにも影響します。Markdown および HTML5 のエクスポートでも同様に切り詰められます。

コードが書き込むテキストは完全に保存されます。PPTX ファイル、PDF ページ、スライド画像には全文が含まれます。

## **スクリプトで制限を確認**

以下のスクリプトは両方の制限を示します。パッケージが [インストール](/slides/ja/nodejs-net/installation/) 手順どおりにインストールされており、プロジェクト フォルダーから実行されることを前提としています。スクリプトは最初のスライドに文章を含む長方形を追加し、その文章を読み戻し、プレゼンテーションを `evaluation.pptx` として保存し、ファイルを再度開いてスライド上のシェイプ数をカウントします。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // ライセンスがない場合、最初の5文字だけが返されます。
    console.log("Text read back:", rectangle.textFrame.text);

    // 保存すると、ファイルの各スライドに評価用透かしが追加されます。
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // スライドには長方形と透かしテキストボックスが格納されています。
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

ライセンスがない場合、スクリプトは次のように出力します。

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

2 番目のシェイプが透かし用テキストボックスです。`evaluation.pptx` を開くと、長方形内に全文が表示され、スライドの中央に透かしがあることが確認できます。

## **制限の削除**

両方の制限を解除するには、`Presentation` オブジェクトを作成する前にライセンスを適用します。[ライセンスの適用方法](/slides/ja/nodejs-net/licensing/) でライセンス ファイルの設定手順を確認してください。

{{% alert color="success" title="Tip" %}}
購入前に評価制限なしで Aspose.Slides をテストしたい場合は、無料の **30 日間の一時ライセンス** をリクエストしてください。詳細は [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) を参照してください。
{{% /alert %}}

## **FAQ**

**評価モードはスライド数を制限しますか？**

いいえ。プレゼンテーションはすべてのスライドを保持したまま作成、開く、保存できます。透かしとテキストの切り詰めはすべてのスライドに同様に適用されます。

**エクスポートしたスライド画像に透かしが 2 回表示されるのはなぜですか？**

レンダリング前にプレゼンテーションが評価モードで保存されているため、既に透かしテキストボックスが含まれています。ライセンスなしでレンダリングすると、さらに上に新しい透かしが描画されます。

**評価モード中にコードが正しいテキストを生成しているか確認できますか？**

はい。保存されたファイルやエクスポートされた PDF を開けば、テキストは完全に含まれています。コードが取得するテキストと Markdown／HTML5 の出力だけが切り詰められます。
---
title: .NET 経由の Node.js でプレゼンテーションテキストを管理
linktitle: テキストの管理
type: docs
weight: 50
url: /ja/nodejs-net/manage-text/
keywords:
- テキスト
- テキストボックス
- テキストの追加
- テキストの変更
- テキストの書式設定
- フォントサイズ
- 太字テキスト
- テキストフレーム
- 段落
- ポーション
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: ".NET 経由の Node.js 用 Aspose.Slides を使用して、スライドにテキストボックスを追加し、テキスト、フォントサイズ、太字スタイルを JavaScript で変更します。"
---
## **Overview**

Aspose.Slidesでは、スライド上のテキストはシェイプに属します。矩形などのオートシェイプにはテキストフレームがあり、テキストフレームには段落が含まれ、各段落には同じ書式のテキストランであるポーションが含まれます。テキストはテキストフレームを介して変更し、フォントはポーションの書式で変更します。

この記事では、スライドにテキストボックスを追加してプレゼンテーションを保存します。その後、保存したファイルを開き、テキストボックスのテキスト、フォントサイズ、太字スタイルを変更します。

例を実行するには、[Installation](/slides/ja/nodejs-net/installation/) に記載されたとおりにプロジェクトを設定する必要があります。各例をプロジェクトフォルダー内に `.js` ファイルとして保存し、そのフォルダーから `node` で実行します。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET には独自の API リファレンスがありません。camelCase 名で Aspose.Slides for .NET API をミラ―しているため、この記事の API リンクは [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ja/net/) の該当クラスやメンバーへ誘導します。
{{% /alert %}}

## **Add a Text Box**

テキストボックスを追加するには、[addAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/shapecollection/addautoshape/) メソッドでスライドにオートシェイプを追加し、[addTextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/addtextframe/) メソッドでテキストを設定します。次の例は新しいプレゼンテーションの最初のスライドに矩形を追加し、プレゼンテーションを `text-box.pptx` として保存します：

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置 (x, y) とサイズ (幅, 高さ) はポイント単位です。
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

`text-box.pptx` のスライドには幅 500 ポイント、高さ 80 ポイントの矩形が含まれ、デフォルトのフォントとサイズでテキスト「Quarterly report」が設定されています。次の例ではこのテキストボックスを変更します。

## **Change the Text and Its Formatting**

以下の例は前の例で作成した `text-box.pptx` を開き、最初のスライド上の最初のシェイプを取得します。画像やテーブルなどのシェイプにはテキストフレームがないため、例ではシェイプが [AutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) であることを確認してからシェイプの [textFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/textframe/) を使用します。その後、次の操作を行います：

1. テキストフレームの [text](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/text/) プロパティを使用してテキストを置き換えます。その結果、テキストフレームには 1 つの段落が 1 つのポーションとして含まれます。  
2. そのポーションを [paragraphs](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/paragraphs/) と [portions](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/portions/) コレクションから取得し、[portionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/portion/portionformat/) を読み取ります。  
3. [fontHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/fontheight/)（ポイント単位のフォントサイズ）と、[fontBold](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/fontbold/)（[NullableBool](https://reference.aspose.com/slides/ja/net/aspose.slides/nullablebool/) 値を受け取る）を設定します。

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

`text-box-updated.pptx` では、テキストボックスに太字 32 ポイントの「Quarterly report: third quarter」が表示されます。新しいテキストが単一のポーションであるため、2 つの書式設定プロパティはすべてに適用されます。ライセンスがない場合、保存するたびに評価用の透かしが追加されます。`text-box.pptx` 自体も評価モードで保存されているため、`text-box-updated.pptx` には透かしが 2 つ含まれます。詳細は [Evaluate Aspose.Slides](/slides/ja/nodejs-net/evaluate-aspose-slides/) を参照してください。

## **FAQ**

**Why does `fontBold` take a `NullableBool` value instead of `true` or `false`?**

ポーションはプロパティを未定義にして、段落、シェイプ、またはスライドのレイアウトやマスターから継承させることができます。`NullableBool.NotDefined` は「継承」を意味し、`NullableBool.True` と `NullableBool.False` は継承された値を上書きします。`true` または `false` を直接代入するとエラーが発生します。同様に、`fontHeight` はポーションがフォントサイズを継承している場合は `NaN` を返します。

**How do I change the text color?**

ポーションの書式の塗りつぶしを設定します。`portionFormat.fillFormat.fillType` に `FillType.Solid` を割り当て、続いて `portionFormat.fillFormat.solidFillColor.color` に `"#FF0000"` のようなカラーコードを割り当てます。`FillType` をパッケージからインポートする名前に追加してください。

**How do I format only part of the text?**

書式設定はポーション単位で行われるため、テキストの対象部分を独自のポーションに分けます。`Portion.CreatePortionFromText` でポーションを作成し、段落の `portions` コレクションの `add` メソッドで追加し、続いて新しいポーションの `portionFormat` を設定します。`Portion` をインポートする名前に追加してください。

**Why does reading text return "... text has been truncated due to evaluation version limitation"?**

ライセンスがない場合、Aspose.Slides は読み取ったテキストが長い場合、最初の 5 文字だけを返し、続けて「... text has been truncated due to evaluation version limitation」という通知を付加します。書き込んだテキストは完全に保存されます。完全なテキストを読み取るには、[Licensing](/slides/ja/nodejs-net/licensing/) に記載された手順でライセンスを適用してください。
---
title: Node.js via .NET でプレゼンテーションを作成
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/nodejs-net/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PowerPoint を作成
- PPTX を作成
- テキストボックスを追加
- スライドを追加
- スライドサイズ
- ワイドスクリーン
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET を使用して JavaScript で PowerPoint プレゼンテーションを作成します：テキストボックスとスライドを追加し、16:9 のスライドサイズを設定し、結果を PPTX として保存します。"
---
## **概要**

本記事では、Aspose.Slides for Node.js via .NET を使用してプレゼンテーションを作成し、最初のスライドにテキスト ボックスを追加し、結果を PPTX ファイルとして保存する方法を示します。また、スライドを追加する方法と、プレゼンテーションをワイドスクリーン（16:9）スライドに切り替える方法も示します。

例を実行するには、[インストール](/slides/ja/nodejs-net/installation/) に記載された手順でプロジェクトを設定する必要があります。各例をプロジェクト フォルダー内に `.js` ファイルとして保存し、そのフォルダーで `node` を使用して実行します。例: `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET には独自の API リファレンスがありません。CamelCase の名前で Aspose.Slides for .NET API をミラーリングしているため、本記事の API リンクは [Aspose.Slides for .NET API リファレンス](https://reference.aspose.com/slides/ja/net/) の該当クラスとメンバーにリンクしています。
{{% /alert %}}

## **テキスト ボックス付きプレゼンテーションの作成**

プレゼンテーションを作成し、最初のスライドにテキスト ボックスを配置するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。新しいプレゼンテーションには既に空のスライドが 1 枚含まれています。
1. [slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) コレクションからそのスライドを取得します。このパッケージのコレクションは `get(index)` で取得し、インデックスは 0 から始まります。
1. [addAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/shapecollection/addautoshape/) メソッドで長方形を追加し、その [textFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/textframe/) の [text](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/text/) を設定します。
1. [save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドと `SaveFormat.Pptx` 値を使用してプレゼンテーションを保存します。
1. `finally` ブロック内で `dispose` を呼び出し、プレゼンテーションを支える .NET リソースを解放します。

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置 (x, y) とサイズ (幅, 高さ) はポイント単位です。
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

スクリプトは `new-presentation.pptx` をプロジェクト フォルダーに書き込みます。このファイルには、左上端から 50 ポイント離れた位置に配置された塗りつぶし長方形が 1 枚のスライドに含まれます。長方形は幅 400 ポイント、高さ 100 ポイントで、テキストは中央揃えです。1 ポイントは 1/72 インチです。ライセンスがない場合、Aspose.Slides はスライドに評価用ウォーターマークを追加します。詳細は [ライセンス](/slides/ja/nodejs-net/licensing/) を参照してください。

## **スライドの追加**

新しいプレゼンテーションにはスライドが 1 枚あります。さらにスライドを追加するには、`slides` コレクションの [addEmptySlide](https://reference.aspose.com/slides/ja/net/aspose.slides/slidecollection/addemptyslide/) メソッドにレイアウト スライドを渡します。[layoutSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/layoutslides/) コレクションの [getByType](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutslidecollection/getbytype/) メソッドは、指定した [SlideLayoutType](https://reference.aspose.com/slides/ja/net/aspose.slides/slidelayouttype/) の最初のレイアウトを返します。

以下の例は Blank レイアウトのスライドを 2 枚追加します。

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

スクリプトは `Slide count: 3` と出力し、`three-slides.pptx` を作成します。新しいスライドは最初のスライドの後に追加され、シェイプは含まれません。新しいプレゼンテーションは常に Blank レイアウトを持ちますが、ファイルから開くプレゼンテーションは要求されたタイプのレイアウトを持たない場合があります。その場合 `getByType` は `null` を返すため、使用する前に結果を確認してください。

## **スライド サイズの設定**

新しいプレゼンテーションは 4:3 スライド（720 × 540 ポイント、10 × 7.5 インチ）を使用します。ワイドスクリーン スライドにするには、プレゼンテーションの [slideSize](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slidesize/) の [setSize](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesize/setsize/) メソッドに [SlideSizeType](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizetype/) と [SlideSizeScaleType](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) の値を渡します。スケール タイプは既存のシェイプの取り扱いを指定します。`DoNotScale` はシェイプをそのままにします。これはコンテンツがまだないプレゼンテーションに適した選択です。

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

スクリプトは `Slide size: 960 x 540 points` と出力し、`widescreen.pptx` を作成します。`SlideSizeType.OnScreen16x9` は同じ 16:9 のアスペクト比ですが、サイズは小さく 720 × 405 ポイントです。

## **よくある質問**

**位置とサイズの単位は何ですか？**

ポイントです。1 インチは 72 ポイントなので、既定の 4:3 スライドは 720 × 540 ポイント、16:9 ワイドスクリーン スライドは 960 × 540 ポイントです。

**新しいプレゼンテーションはどの形式で保存できますか？**

[SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) 列挙体の任意の値を使用できます。例: PowerPoint 97–2003 用の `SaveFormat.Ppt`、OpenDocument 用の `SaveFormat.Odp`、または `SaveFormat.Pdf`。PDF 出力については [PowerPoint を PDF に変換](/slides/ja/nodejs-net/convert-powerpoint-to-pdf/) を参照してください。

**保存されたプレゼンテーションに「Evaluation only」テキストが含まれるのはなぜですか？**

ライセンスがない場合、Aspose.Slides は保存するスライドに評価用ウォーターマークを追加します。[ライセンス](/slides/ja/nodejs-net/licensing/) の手順に従ってライセンスを適用すると削除できます。

**なぜ `dispose` を呼び出す必要があるのですか？**

`Presentation` オブジェクトはメモリやその他のリソースを保持する .NET オブジェクトに裏付けられています。`dispose` を呼び出すと、プレゼンテーションが不要になった直後にこれらのリソースが解放され、`finally` ブロックで呼び出すことでエラーが発生した場合でも確実に解放されます。
---
title: Node.js via .NET でプレゼンテーション スライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 40
url: /ja/nodejs-net/convert-slide/
keywords:
- スライドを変換
- スライドを画像に
- スライドをPNGに
- スライドを画像として保存
- スライドをレンダリング
- スライドサムネイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET を使用して、JavaScript で PPTX、PPT、ODP プレゼンテーションのスライドを PNG 画像としてレンダリングします。スケール係数またはピクセル単位の正確なサイズで出力できます。"
---
## **概要**

Aspose.Slides for Node.js via .NET は、PowerPoint および OpenDocument プレゼンテーションのスライドを画像としてレンダリングします。たとえば、Web ページ上でスライドのプレビューを表示するためです。本記事では、画像サイズを選択する 2 つの方法を示します。スライドサイズに対するスケール係数と、ピクセル単位の正確なサイズです。両方の例は PNG ファイルとして保存します。

例では、[Installation](/slides/ja/nodejs-net/installation/) で設定したプロジェクト フォルダーに `sample.pptx` という名前のプレゼンテーションがあることを想定しています。任意の PowerPoint プレゼンテーションで構いません。各例をプロジェクト フォルダーに `.js` ファイルとして保存し、そのフォルダーで `node` を実行します。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET には独自の API リファレンスがありません。camelCase 名で Aspose.Slides for .NET API を鏡像化しているため、この記事の API リンクは [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ja/net/) の該当クラスとメンバーに続きます。
{{% /alert %}}

スライドを画像に変換するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/presentation/) コンストラクタでプレゼンテーションを開きます。
1. `get(index)` で [slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) コレクションからスライドを取得します。インデックスは 0 から始まります。
1. `getImageWithScale` または `getImageWithImageSize` でスライドをレンダリングします。.NET API リファレンスでは、両方とも [Slide.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage/) のオーバーロードです。これらは [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) に対応する画像オブジェクトを返します。
1. 画像を [save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/save/) メソッドと [ImageFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) 値で保存し、続いて `dispose` メソッドを呼び出します。

## **すべてのスライドを PNG 画像に変換**

`getImageWithScale` は水平と垂直のスケール係数を受け取ります。スケール 1 の場合、スライドの 1 ポイントが画像の 1 ピクセルになります。以下の例は、すべてのスライドをスケール 2 でレンダリングします。

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// スケール 1 はポイントあたり 1 ピクセルをレンダリングします。スケール 2 は幅と高さを 2 倍にします。
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

スクリプトはスライドごとに 1 つのファイル、`slide_1.png`、`slide_2.png` などを作成し、1 から番号付けします。スライドが 960 × 540 ポイントの 16:9 プレゼンテーションの場合、各画像は 1920 × 1080 ピクセルになります。非表示スライドもレンダリングされます。スキップするにはスライドの [hidden](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/hidden/) プロパティを確認してください。各画像はそれぞれの `finally` ブロックで破棄され、次のスライドがレンダリングされる前に解放されます。ライセンスがない場合、画像には評価版の透かしが表示されます。[Licensing](/slides/ja/nodejs-net/licensing/) を参照してください。

## **指定サイズの画像にスライドを変換**

`getImageWithImageSize` はピクセル単位の `width` と `height` を持つオブジェクトを受け取ります。以下の例は、最初のスライドを幅 1280 ピクセルでレンダリングし、高さはスライドサイズから計算して、画像がスライドのアスペクト比を保つようにします。

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

[slideSize.size](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesize/size/) プロパティはスライドの幅と高さをポイントで返します。16:9 のプレゼンテーションでは、スクリプトは `Saved a 1280 x 720 image` と出力し、`slide_1_1280px.png` を作成します。4:3 のプレゼンテーションでは、画像は 1280 × 960 ピクセルになります。

## **FAQ**

**`getImage` を引数なしで呼んだ画像が小さい理由は何ですか？**

引数を省略すると、`getImage` はスライドをポイントサイズの 20% でレンダリングします。そのため、960 × 540 ポイントのスライドは 192 × 108 ピクセルの画像になります。サイズを選択するには `getImageWithScale` または `getImageWithImageSize` を使用してください。

**JPEG や他の画像形式はどう保存しますか？**

画像の `save` メソッドに別の `ImageFormat` 値を渡します。例: `image.save("slide_1.jpg", ImageFormat.Jpeg)`。形式はファイル拡張子ではなく `ImageFormat` 値から決まるので、拡張子と一致させてください。

**Linux で画像内のテキストが異なる表示になるのはなぜですか？**

Aspose.Slides は、スライドをレンダリングするマシンにインストールされているフォントのみを使用できます。プレゼンテーションで使用されているフォントが存在しない場合（たとえば、一般的な Linux サーバーで Calibri がない場合）、Aspose.Slides は代わりにインストール済みのフォントを使用します。その結果、テキストの見た目や改行位置が変わることがあります。Windows と同じ画像を得るために、プレゼンテーションで使用するフォントをインストールしてください。

**`getThumbnailWithImageSize` が TypeError で失敗するのはなぜですか？**

パッケージの README では `getThumbnailWithImageSize` が使用されていますが、パッケージには `getThumbnail` メソッドが存在しません。代わりに `getImageWithImageSize` を使用してください。引数は同じ `{ width, height }` です。
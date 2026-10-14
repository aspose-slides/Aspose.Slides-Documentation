---
title: JavaScript で PowerPoint スライドを PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides for Node.js を使用して、JavaScript で PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。
---
## **概要**

この記事では、Aspose.Slides for Node.js via Java を使用してプレゼンテーションスライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式でプレゼンテーションをロードし、各スライドをレンダリングして、個別の PNG 画像として保存できます。

以下の例では、デフォルトスケールでのレンダリング、スケールの拡大、ピクセル単位での出力サイズの指定、そしてグラデーションレンダリングスタイルの選択を示します。

## **PowerPoint を PNG に変換**

プレゼンテーションは [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスでロードし、[Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) コレクションからスライドにアクセスします。例では、パラメータなしで [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) を呼び出してサムネイルを作成し、各スライドをレンダリングします。その後、[IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) に [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) を指定して、レンダリングしたスライドを PNG 画像として保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
パラメータなしの [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) オーバーロードはスケール 0.2 でレンダリングします。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルを生成します。出力サイズを制御するには、以下に示すようにスケール係数を使用するオーバーロードまたは明示的な画像サイズを使用してください。
{{% /alert %}}

## **カスタム寸法で PowerPoint を PNG に変換**

水平および垂直のスケール係数を [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) に渡すことで、レンダリングサイズを制御できます。この例では、両方の係数が 2 で、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像になります。スケール係数が同じ場合、スライドのアスペクト比が保持されます。各画像は [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) を使用して PNG 形式で保存されます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **カスタムサイズで PowerPoint を PNG に変換**

ピクセル単位で出力サイズを指定するには、スケール係数の代わりにサイズを [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) に渡します。この例では、すべてのスライドを 960 × 720 ピクセルでレンダリングし、結果を [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) で保存します。画像が伸びるのを防ぐため、スライドのアスペクト比に合わせたサイズを選択してください。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **グラデーションレンダリングスタイルの選択**

スライドにグラデーション塗りが含まれているが、エクスポートされた PNG の遷移が PowerPoint で見るものよりも明るい、あるいは異なる場合があります。[RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) が継承する [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) メソッドを使用して、グラデーションのレンダリング方法を選択できます。

[gradient-styles.pptx](gradient-styles.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには、上部がシアンからオレンジ、下部が青から黄色へ変化する 2 つの線形グラデーションが含まれています。各グラデーションは 0% と 100% の 2 つのストップを持ちます。

以下の例では、このプレゼンテーションをロードし、[Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) を使用して同じ最初のスライドを両方のモードでレンダリングします。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

以下の画像は同じスライドの出力を示しており、各画像に両方のグラデーションが含まれています。

| デフォルト | PowerPointUI |
| --- | --- |
| ![デフォルトでレンダリングされたシアンからオレンジ、青から黄色へのグラデーション](gradient-Default.png) | ![PowerPointUI でレンダリングされた同じグラデーション](gradient-PowerPointUI.png) |

この例では、`Default` は中間色がより明るくなり、`PowerPointUI` は中間色がより暗くなります。違いはグラデーションの色とストップに依存します。

標準の Aspose.Slides 出力が要件に合う場合は `Default` を選択してください。PowerPoint の外観と一致させることが優先事項の場合は `PowerPointUI` を試してください。両方の出力を目的の結果と比較してください。どちらのモードも普遍的に優れているわけではありません。

## **よくある質問**

**スライド全体ではなく、チャートや画像などの特定のシェイプだけをエクスポートするにはどうすればよいですか？**

Aspose.Slides は、[個別シェイプのサムネイル生成](/slides/ja/nodejs-java/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバーで並列変換はサポートされていますか？**

はい。各スレッドまたはプロセスごに個別のプレゼンテーション インスタンスを使用してください；[スレッド間で単一のインスタンスを共有しないでください](/slides/ja/nodejs-java/multithreading/)。

**PNG へエクスポートする際の評価版の制限は何ですか？**

評価モードでは、出力画像に透かしが追加され、[その他の制限](/slides/ja/nodejs-java/licensing/) がライセンスが適用されるまで適用されます。
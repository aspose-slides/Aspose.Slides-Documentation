---
title: プレゼンテーションビューア
type: docs
weight: 50
url: /ja/nodejs-java/presentation-viewer/
keywords:
- プレゼンテーションを表示
- プレゼンテーションビューア
- PPT を表示
- PPTX を表示
- ODP を表示
- PowerPoint
- OpenDocument
- Node.js
- Java
- Node.js via Java 用 Aspose.Slides
description: "JavaScript での PowerPoint プレゼンテーションビューア"
---

Aspose.Slides for Node.js via Java は、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者がスライドを好みの画像ビューアで画像として表示したり、独自のプレゼンテーションビューアを作成したりする必要がある場合があります。そのような場合、Aspose.Slides を使用すると、個々のスライドを画像としてエクスポートできます。本記事ではその方法について説明します。

## **スライドからSVG画像を生成する**

Aspose.Slides を使用してプレゼンテーションスライドから SVG 画像を生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. ファイルストリームを開きます。
1. スライドを SVG 画像としてファイルストリームに保存します。
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **カスタムシェイプIDでSVGを生成する**

Aspose.Slides を使用して、カスタムシェイプIDを持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。これを行うには、[SvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/) の `setId` メソッドを使用します。`CustomSvgShapeFormattingController` を使用してシェイプIDを設定できます。
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```


## **スライドのサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像を生成するのに役立ちます。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 定義されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 希望する任意の画像形式でサムネイル画像を保存します。
```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **ユーザー定義サイズでスライドサムネイルを作成する**

ユーザー定義のサイズでスライドのサムネイル画像を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 定義された寸法で参照されたスライドのサムネイル画像を取得します。
1. 希望する任意の画像形式でサムネイル画像を保存します。
```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **スライドのスピーカーノート付きサムネイルを作成する**

Aspose.Slides を使用してスピーカーノート付きスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) クラスのインスタンスを作成します。
1. `RenderingOptions.setSlidesLayoutOptions` メソッドを使用してスピーカーノートの位置を設定します。
1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. レンダリングオプションを使用して参照されたスライドのサムネイル画像を取得します。
1. 希望する任意の画像形式でサムネイル画像を保存します。
```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **ライブ例**

[**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 無料アプリを試して、Aspose.Slides APIで実装できることを確認できます：

![オンライン PowerPoint ビューア](online-PowerPoint-viewer.png)

## **FAQ**

**Node.js の Web アプリケーションにプレゼンテーションビューアを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを画像または HTML にレンダリングし、ブラウザーで表示できます。ナビゲーションやズーム機能は JavaScript で実装でき、インタラクティブな体験を提供します。

**カスタムビューア内でスライドを表示する最適な方法は何ですか？**

推奨される方法は、各スライドを画像（例: PNG や SVG）としてレンダリングするか、Aspose.Slides を使用して HTML に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナ内に表示することです。

**多数のスライドを含む大規模なプレゼンテーションをどのように処理しますか？**

大規模なデッキの場合、スライドの遅延読み込みまたはオンデマンドレンダリングを検討してください。これは、ユーザーがスライドに移動したときにのみその内容を生成することで、メモリ使用量とロード時間を削減します。
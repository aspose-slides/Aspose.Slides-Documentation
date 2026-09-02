---
title: JavaScript を使用したプレゼンテーションでのピクチャーフレームの管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/nodejs-java/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームの追加
- ピクチャーフレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG 画像
- 画像のクロップ
- クロップ領域の削除
- 画像の圧縮
- StretchOffset
- ピクチャーフレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、プレゼンテーション内のピクチャーフレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

ピクチャーフレームは画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトとして扱われます。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) は埋め込み画像リソースを [ImageCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) を通じて所有し、[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、画像効果、その他フレームレベルの設定を制御します。

この分離は、同じ画像を複数回表示する場合に便利です。画像をプレゼンテーションに一度だけ追加し、返された [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を保持して、ピクチャーフレーム作成時にその画像リソースを使用します。

ピクチャーフレームは PNG や JPEG といったラスタ画像や、SVG といったベクター画像を含めることができます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照させることもできます。選択肢は携帯性、ファイルサイズ、抽出、エクスポートの挙動に影響するため、書式設定や最適化を行う前に画像の保存方法を決定しておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) でピクチャーフレームを作成します。画像はプレゼンテーション パッケージの一部になるため、プレゼンテーションを別のコンピューターに移動しても自己完結型のままです。

以下の例は PNG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ピクチャーフレームは表示される形状を制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変わりません。この区別は、後で画像をクロップしたり圧縮したりする場合に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) はフレームの幅と高さの相対スケールを [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) で公開します。`1.0` の値は元画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで便利です。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像を再サンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込みピクチャーは画像データをプレゼンテーション内部に保存するため、携帯性と予測可能なレンダリングに最も安全です。リンクピクチャーは [Picture.setLinkPathLong](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) メソッドで外部の場所を指し示すため、画像データを同様に埋め込むことはありません。

リンク画像は PPTX の画像データ量を削減できますが、外部依存が生じます。リンクされたファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションがアクセスできる状態である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなった場合、リンク画像は期待どおりに表示されないことがあります。メールで送信したり、アーカイブしたり、孤立した環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

以下の例はピクチャーフレームを作成し、ローカル画像ファイルへリンクします。画像リンクのみを扱い、ビデオリンクは別のメディア ワークフローであり、本例には意図的に混在させていません。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替として使用しないでください。壊れた画像依存関係を抱える小さな PPTX は、サイズの大きい自己完結型プレゼンテーションよりも実用的でないことが多いです。

## **ピクチャーフレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、対象のシェイプが実際に [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) であり、埋め込み画像を保持していることを確認してください。リンクされたピクチャーフレームは、同じ方法で抽出できるバイトを含まない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) を直接使用します。以下の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/#save) を使用して保存すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに格納されているエンコード済みバイトが必要な場合は、画像リソースのバイナリ データを直接使用してください。

### **SVG 画像の抽出**

SVG ピクチャーの場合、[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) は [SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) オブジェクトを公開します。これにより、画像をまずラスタライズすることなく SVG データを直接取得できます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内部にベクター ソースが残ります。PNG や JPEG といったラスタへのエクスポートは、そのベクター コンテンツをピクセルに変換します。PDF や SVG へのスライド エクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位でのコピーとはみなさないでください。元のベクター リソースが必要な場合は、埋め込み [SvgImage.getSvgData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/#getSvgData--) データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) のクロップ値は元画像の寸法に対するパーセンテージです。クロップは埋め込み画像から隠れたピクセルを即座に削除するわけではなく、表示領域を変更するだけです。

以下の例はピクチャーフレームを安全に取得し、クロップ値を適用します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

隠れた画像データは依然として存在するため、後で元のピクセルを失うことなくクロップを変更できます。ファイル サイズが重要であり、元に戻す必要がない場合は、次のセクションで説明するようにクロップ領域を物理的に削除できます。

## **クロップされた画像データの削除**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) は現在のクロップ矩形外の画像データを削除し、結果として得られる画像リソースを返します。これはファイル サイズを削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後からのアンクロップ操作では利用できません。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元画像が他のピクチャーフレームでも使用されている場合、これらのフレームは引き続き既存のリソースを必要とするため、クロップ領域を削除しても画像総数が減少するとは限りません。このメソッドで WMF や EMF コンテンツをクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) は、画像が表示されるサイズに対するラスタ画像の解像度を低減します。同時にクロップ領域を削除できる場合もあります。メソッドは画像がリサイズまたはクロップされた場合に `true`、変更が不要だった場合に `false` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturescompression/) 値を使用してください。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

特定のターゲットが必要な場合は、事前定義値の代わりにカスタムの正の DPI 値を渡すこともできます。

圧縮はラスタ画像を対象としています。SVG やメタファイル コンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げてクロップ領域を削除した場合、最適化されたプレゼンテーションからは元に戻せないことを忘れないでください。最終的に画像が実際に表示またはエクスポートされる最大サイズを基準にターゲット解像度を選択し、全体的に最低 DPI を適用しないようにしてください。

## **画像変形エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付けられたチェーン、検査、削除、往復検証を網羅した完全なワークフローについては、[Image Transform Effects](/nodejs-java/image-transform-effects/) を参照してください。

## **ピクチャーフレームのジオメトリをロックする**

[PictureFrameLock](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframelock/) 設定は、ピクチャーフレームに対して無効化する編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) はリサイズ時に形状の比率を保持します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ロックはピクチャーフレームのシェイプに適用されます。ソース画像が再サンプリングされたり、同じアスペクト比に永久に変更されたりすることは強制されません。

## **StretchOffset 値の調整**

ピクチャーの塗りつぶしモードが stretch の場合、[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) の stretch‑offset 値はピクチャーフレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからの内側のインセットを作り、負のパーセンテージは外側のアウトセットを作ります。

これはクロップとは異なります。クロップ値は元画像のどの部分が表示されるかを選択しますが、stretch offset は表示されるピクチャーの塗りつぶしが伸張される矩形を変更します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

塗りつぶしの配置には stretch offset を使用し、ソース画像の端を隠す目的にはクロップ プロパティを使用してください。

## **ストレージ、ファイル サイズ、エクスポートに関する考慮事項**

画像の保存とピクチャーフレームの書式設定を別々に扱うと、以下のようなトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結型にし、共有やサーバー側レンダリングで最も信頼性が高いですが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスまたは場所に残っていることに依存します。
- **クロップ** は当初破壊的ではありません。隠れたピクセルは、クロップ領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイル サイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での最終サイズが決まった後に適用すべきです。
- **SVG 画像** はベクター保存が重要な場合は SVG のままにしてください。ベクター リソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタ スライド エクスポートは常にスライドをピクセルに変換します。
- **繰り返し使用される画像** は、可能な限り同じ [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) リソースを再利用し、同一ファイルを何度もプレゼンテーション ワークフローに読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図はベクター コンテンツのまま保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップされたピクセルを削除し、外部リンクは依存関係管理がデプロイ設計の一部であるとき以外は避けてください。

## **FAQ**

**ピクチャーフレームと画像リソースの違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどのフレームレベルのジオメトリと書式設定を保存します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションを携帯可能に、アーカイブ可能に、または外部リソースにアクセスできずにレンダリングする必要がある場合は埋め込み画像を選択してください。画像ファイルを PPTX の外に置くことが意図的で、外部の場所を確実に維持できる場合にのみリンク画像を使用してください。

**クロップは PPTX のファイル サイズを削減しますか？**

単体では削減しません。通常のクロップ設定は画像の一部を非表示にしますが、基になるピクセルは保持されたままです。ピクセルを永久に削除したい場合は、[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) またはクロップ領域の削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を低下させ、クロップ領域の削除は画像データそのものを破棄します。後で高解像度で編集する可能性がある場合は、元のソース画像をプレゼンテーションの外部に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクターの忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) は直接抽出できます。PNG や JPEG といったラスタ形式へスライドをエクスポートすると、SVG はスライド画像の一部としてラスタライズされます。

**既存スライドを読むときに安全でないキャストを回避するには？**

ピクチャーフレーム固有のメンバーを使用する前に、シェイプの型を確認してください。`java.instanceOf` を使って [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) かどうかをチェックすれば、無効なキャストを防ぎ、ピクチャーフレームを含まないスライドにも対応できます。
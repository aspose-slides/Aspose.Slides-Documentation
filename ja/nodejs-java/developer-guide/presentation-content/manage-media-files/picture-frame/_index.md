---
title: JavaScript を使用してプレゼンテーションの画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/nodejs-java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG 画像
- 画像のトリミング
- トリミング領域の削除
- 画像の圧縮
- ストレッチオフセット
- 画像フレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、トリミング、抽出、圧縮します。"
---
## **概要**

画像フレームは画像を表示するスライドのシェイプです。Aspose.Slidesでは、画像リソースとそれを表示するシェイプは別々のオブジェクトです。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) は [ImageCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) を通じて埋め込み画像リソースを所有し、[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) は画像の位置、サイズ、線の書式設定、回転、トリミング、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合、この分離は便利です。画像をプレゼンテーションに一度追加し、返された[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/)を保持し、画像フレームを作成するときにその画像リソースを使用します。

画像フレームはPNGやJPEGなどのラスタ画像やSVGなどのベクター画像を含めることができます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照することも可能です。選択はポータビリティ、ファイルサイズ、抽出、エクスポートの動作に影響するため、書式設定や最適化を適用する前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-)で画像フレームを作成します。画像はプレゼンテーションパッケージの一部になるので、プレゼンテーションは別のコンピュータに移動しても自己完結しています。

次の例はPNG画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

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

画像フレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに保存されている元のピクセル寸法は変わりません。この区別は後で画像をトリミングまたは圧縮する場合に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) は[setRelativeScaleWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) と[setRelativeScaleHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) を介してフレームの幅と高さの相対スケールを提供します。`1.0` の値は元画像サイズの100%に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更します。埋め込み画像を再サンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内に保存するため、ポータビリティと予測可能な描画に最も安全です。リンク画像は[Picture.setLinkPathLong](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) メソッドで外部の場所を参照し、同じ方法で画像データを埋め込むことはありません。

リンク画像はPPTX に保存される画像データ量を減らすことができますが、外部依存性が発生します。リンクされたファイルはプレゼンテーションを開く、または描画するアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなったりすると、リンク画像は期待通りに表示されないことがあります。メールで送付したり、アーカイブしたり、隔離環境で描画したりする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例は画像フレームを作成し、ローカル画像ファイルへのパスを指定します。画像のリンクだけを扱い、ビデオのリンクは別のメディアワークフローであり、この例には意図的に混ぜていません。

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

外部ファイルの管理が意図的な場合にリンクを使用してください。単に圧縮の代替として使用しないでください。破損した画像依存関係を持つ小さな PPTX は、自己完結した大きなプレゼンテーションよりも実用性が低いことが多いです。

## **画像フレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/)であり、埋め込み画像を含んでいるか確認してください。リンクされた画像フレームは同じ方法で抽出できる画像バイトを含まない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は[IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) を直接使用します。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

[IImage.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/#save) を使用して保存すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに保存されているエンコード済みバイトが必要な場合は、画像リソースのバイナリデータを直接使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) は[SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) オブジェクトを公開します。これにより、まず画像をラスタライズせずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクター元が残ります。PNG や JPEG などのラスタエクスポートは必然的にベクターコンテンツをピクセルに変換します。PDF や SVG スライドエクスポートも描画操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位でのコピーとはみなさず、元のベクターリソースが必要な場合は埋め込み [SvgImage.getSvgData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/#getSvgData--) データを使用してください。

## **画像のトリミング**

トリミングはフレーム内で画像のどの部分が表示されるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) のトリミング値は元画像の寸法に対するパーセンテージです。トリミングは最初に埋め込み画像から隠れたピクセルを削除するのではなく、表示領域を変更するだけです。

次の例は安全に画像フレームを検索し、トリミング値を適用します。

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

隠れた画像データは依然として存在するため、後からトリミングを変更しても元のピクセルは失われません。ファイルサイズが重要であり、可逆性が不要な場合は、次のセクションで説明するようにトリミング領域を物理的に削除できます。

## **トリミングされた画像データの削除**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) は現在のトリミング矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズを削減できますが、破壊的な最適化です。プレゼンテーションが保存された後は、削除されたピクセルは後で元に戻すことができません。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元画像が他の画像フレームでも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、トリミング領域の削除が必ずしも画像総数の削減につながるわけではありません。WMF や EMF コンテンツをこのメソッドでトリミングすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) は画像が表示されるサイズに対するラスタ画像の解像度を低下させます。同時にトリミング領域を削除することもできます。メソッドは画像がリサイズまたはトリミングされた場合に `true`、変更が不要だった場合に `false` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された[PicturesCompression](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturescompression/) 値を使用してください。

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

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げてトリミング領域を削除した画像は最適化されたプレゼンテーションから復元できないことを忘れないでください。画像が実際に表示またはエクスポートされる最大サイズに基づいてターゲット解像度を選択し、全体的に最も低い DPI を適用しないようにしてください。

## **画像効果の検査**

画像効果はフレームで使用される画像に保存されます。画像変換コレクションには、透明度の固定アルファ変調や明るさ・コントラストのための輝度などの効果が含まれる可能性があります。以下の例はスライド上の最初の画像フレームから両方の種類の効果を安全に読み取ります。

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

これらの効果はフレーム内で画像がどのように描画されるかを変更しますが、元の埋め込み画像バイトを書き換えることはありません。

## **画像フレームジオメトリのロック**

[PictureFrameLock](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframelock/) 設定は画像フレームに対して無効にする編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) はサイズ変更時に形状の比率を保持します。

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

ロックは画像フレームシェイプに適用されます。元画像が再サンプリングされたり、同じアスペクト比に永久に変更されたりすることは強制しません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードがストレッチの場合、[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) の stretch‑offset 値は画像フレームのバウンディングボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはトリミングとは異なります。トリミング値は元画像のどの部分が表示されるかを選択し、ストレッチオフセットは表示された画像塗りつぶしが伸びる矩形を変更します。

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

塗りつぶしの配置にはストレッチオフセットを使用し、元画像のエッジを隠す目的の場合はトリミングプロパティを使用してください。

## **保存、ファイルサイズ、エクスポートの考慮事項**

画像の保存と画像フレームの書式設定を別々に扱うと、主要なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側描画に最も信頼性がありますが、ラスタ画像が大きいと PPTX サイズとメモリ使用量が増加します。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスや場所に残っていることに依存します。
- **トリミング** は最初は非破壊的です。隠れたピクセルはトリミング領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上の表示サイズが確定した後に適用すべきです。
- **SVG 画像** はベクターの保持が重要な場合は SVG のままにすべきです。ベクターリソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタスライドエクスポートは常にスライドをピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/)リソースを再利用し、同じファイルを何度もプレゼンテーションに読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図はベクターコンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみトリミングされたピクセルを削除し、外部リンクは依存関係管理がデプロイ設計の一部である場合に限って使用してください。

## **FAQ**

**画像フレームと画像リソースの違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、トリミング値、効果、ロックなどフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきかリンクすべきか？**

プレゼンテーションをポータブルに、アーカイブに、または外部リソースにアクセスせずに描画する必要がある場合は画像を埋め込みます。画像ファイルを PPTX の外部に保持し、外部場所を確実に管理できる場合のみリンクを使用してください。

**トリミングは PPTX のファイルサイズを減らしますか？**

単独では減らしません。通常のトリミング設定は画像の一部を非表示にしますが、基になるピクセルは保持されます。ピクセルを完全に削除したい場合は[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) またはトリミング領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、トリミング領域の削除は画像データを破棄します。後で高解像度で編集する可能性がある場合は、元のソース画像をプレゼンテーションの外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクターフィデリティが重要な場合は SVG コンテンツを SVG のまま保持します。埋め込み[SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) は直接抽出できます。PNG や JPEG などのラスタ形式へのスライドエクスポートは SVG をスライド画像の一部としてラスタライズします。

**既存スライドを読むときに安全でないキャストを回避するには？**

シェイプタイプを確認してから画像フレーム固有のメンバーを使用してください。[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) に対する `java.instanceOf` チェックは無効なキャストを防ぎ、画像フレームを含まないスライドでもコードが正しく動作するようにします。
---
title: プレゼンテーションで JavaScript を使用した画像フレームの管理
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
- ラスター画像
- SVG 画像
- 画像のクロップ
- クロップ領域の削除
- 画像の圧縮
- StretchOffset
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
description: "Java 経由で Node.js 用 Aspose.Slides を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、クロップ、抽出、および圧縮します。"
---
## **概要**

Picture frame は画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) は埋め込み画像リソースを [ImageCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) を介して所有し、[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) は画像の位置、サイズ、線の書式設定、回転、切り取り、画像効果、およびその他のフレームレベルの設定を制御します。

同じ画像を複数回表示する場合、この分離は有用です。画像をプレゼンテーションに一度だけ追加し、返される [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を保持して、PictureFrame を作成するときにその画像リソースを使用します。

Picture frame は PNG や JPEG などのラスタ画像や SVG のベクタ画像を格納できます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照することもできます。選択は可搬性、ファイルサイズ、抽出、エクスポート動作に影響するため、書式設定や最適化を適用する前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) で picture frame を作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピュータに移動してもプレゼンテーションは自己完結したままです。

以下の例は PNG 画像を追加し、画像のネイティブ寸法でフレームを作成し、線の書式設定と回転を適用します：

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

picture frame は表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに保存されている元のピクセル寸法は変わりません。この違いは、後で画像を切り取ったり圧縮したりする際に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) はフレームの幅と高さの相対スケールを [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) で公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算せずにソース画像サイズとの関係を保持したいワークフローで便利です。

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

埋め込み picture は画像データをプレゼンテーション内に保存するため、可搬性と予測可能なレンダリングの点で最も安全な選択です。リンク picture は [Picture.setLinkPathLong](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) メソッドで外部の場所を保持し、画像データを同様に埋め込むことはありません。

リンク画像は PPTX に保存される画像データ量を減らせますが、外部依存が発生します。リンク先ファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなった場合、リンク picture は期待どおりに表示されないことがあります。メールで送付したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

以下の例は picture frame を作成し、ローカル画像ファイルへのパスを設定します。画像リンクのみを扱い、動画リンクは別のメディア ワークフローであり、この例には意図的に混在させていません。

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

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替としてリンクを使用しないでください。壊れた画像依存関係を持つ小さな PPTX は、サイズが大きい自己完結型プレゼンテーションよりも実用的でないことが多いです。

## **Picture Frame から画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) であり、埋め込み画像を含んでいるか確認してください。リンクされた picture frame は同じ方法で抽出できる画像バイトを持たない場合があります。

### **ラスタ画像の抽出**

モダンな画像 API は [IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) を直接使用します。以下の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します：

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

[IImage.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/#save) を使用して保存すると、抽出された画像が要求された出力形式に変換されます。プレゼンテーションに保存されているエンコード済みバイトが必要な場合は、画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG picture の場合、[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) が [SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) オブジェクトを公開します。これにより、先に picture をラスタライズせずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクタ ソースが残ります。PNG や JPEG などのラスタ エクスポートはベクトル コンテンツをピクセルにレンダリングします。PDF や SVG へのスライドエクスポートもレンダリング操作であるため、エクスポートされた画像は元の埋め込み SVG のバイト単位コピーとして扱わず、元のベクタ リソースが必要な場合は埋め込み [SvgImage.getSvgData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/#getSvgData--) データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) のクロップ値はソース画像寸法のパーセンテージです。クロップは埋め込み画像から隠されたピクセルを削除するわけではなく、表示領域だけを変更します。

以下の例は picture frame を安全に取得し、クロップ値を適用します：

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

隠された画像データは依然として存在するため、後で元のピクセルを失うことなくクロップを変更できます。ファイルサイズが重要で、可逆性が不要な場合は、次のセクションで説明するようにクロップ領域を物理的に削除できます。

## **クロップされた画像データの削除**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) は現在のクロップ矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズを削減できますが、破壊的な最適化です。プレゼンテーションが保存された後は、削除されたピクセルは後のアンクロップ操作で利用できません。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元の画像が他の picture frame でも使用されている場合、これらのフレームは既存のリソースを必要とするため、クロップ領域の削除が必ずしも画像総数の減少につながるわけではありません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) は、画像が表示されるサイズに対するラスタ画像の解像度を下げます。同時にクロップ領域を削除できる場合もあります。メソッドは画像がリサイズまたはクロップされた場合に `true` を、変更が不要だった場合に `false` を返します。

標準的な目標解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturescompression/) 値を使用してください：

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

特定の目標が必要な場合は、事前定義値の代わりにカスタムの正の DPI 値を渡すこともできます。

圧縮はラスタ画像を対象としています。SVG やメタファイル コンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げたりクロップ領域を削除したりした画像は最適化されたプレゼンテーションから復元できないことに留意してください。最も大きく表示またはエクスポートされるサイズに基づいて目標解像度を選択し、全体的に最低 DPI を適用しないようにしてください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付きチェーン、検査、削除、往復検証を網羅した完全なワークフローについては、[Image Transform Effects](/slides/ja/nodejs-java/image-transform-effects/) を参照してください。

## **Picture Frame のジオメトリをロック**

[PictureFrameLock](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframelock/) 設定は picture frame に対して無効化する編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) はリサイズ時にシェイプの比率を保持します。

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

ロックは picture frame シェイプに適用されます。ソース画像が再サンプリングされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

picture fill モードが stretch の場合、[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) の stretch‑offset 値は picture frame のバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからの内側オフセットを、負のパーセンテージは外側オフセットを作ります。

これはクロップとは異なります。クロップ値はソース画像のどの部分が可視かを選択しますが、stretch offset は可視画像が伸張される矩形を変更します。

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

塗りつぶし位置を調整する際は stretch offset を使用し、ソース画像のエッジを隠す目的の場合はクロップ プロパティを使用してください。

## **ストレージ、ファイルサイズ、エクスポート上の考慮点**

画像の保存と picture‑frame 書式設定を別々に扱うと、主なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングで最も信頼性が高いですが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスや場所に残っていることに依存します。
- **クロップ** は最初は非破壊的です。隠れたピクセルはクロップ領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、ソース解像度を犠牲にします。スライド上の実際の表示サイズが判明してから適用すべきです。
- **SVG 画像** はベクタ の保存が重要な場合は SVG のままにしてください。ベクタ リソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタ スライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **画像の再利用** は可能な限り既存の [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) リソースを再利用し、同じファイルをプレゼンテーション ワークフローに何度もロードしないようにします。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図表はベクタ コンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップされたピクセルを削除し、外部リンクは依存関係管理がデプロイ設計の一部である場合にのみ使用してください。

## **FAQ**

**picture frame と image resource の違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきかリンクにすべきか？**

プレゼンテーションを可搬、アーカイブ、または外部リソースにアクセスできない状態でレンダリングする必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外部に保持し、外部場所を信頼できる形で管理できる場合にのみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを削減しますか？**

単体では削減しません。通常のクロップ設定はソース画像の一部を隠すだけで、基になるピクセルは残ります。ピクセルを永続的に削除したい場合は [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) またはクロップ領域除去付きの画像圧縮を使用してください。

**圧縮後に画像品質を回復できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度編集が必要になる可能性がある場合は、プレゼンテーションの外部に元画像を保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタ の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [SvgImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgimage/) は直接抽出できます。PNG や JPEG へのスライドレンダリングは SVG をラスタライズします。

**既存スライドを読む際に unsafe cast を回避するには？**

picture‑frame 固有のメンバーを使用する前にシェイプの型を確認してください。`java.instanceOf` で [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) かどうかをチェックすれば、無効なキャストを防ぎ、picture frame を含まないスライドを安全に処理できます。
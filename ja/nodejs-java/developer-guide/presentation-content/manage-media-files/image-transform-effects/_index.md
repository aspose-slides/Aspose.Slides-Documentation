---
title: JavaScript でプレゼンテーションの画像変換効果を管理する
linktitle: 画像変換効果
type: docs
weight: 11
url: /ja/nodejs-java/image-transform-effects/
keywords:
- 画像変換
- 画像効果
- 明るさ
- コントラスト
- グレースケール
- デュオトーン
- ティント
- HSL
- カラー置換
- ぼかし
- 透明度
- アルファ効果
- 効果チェーン
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、画像フレームの画像変換効果を適用、チェーン化、検査、削除、および検証します。"
---
## **概要**

Aspose.Slides は画像の調整を画像変換操作の順序付けられたコレクションとして表します。画像フレームの場合、フレームの [Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) から開始し、[Picture.getImageTransform](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) にアクセスします。返される [ImageTransformOperationCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用すると、元の画像バイトを書き換えることなく、効果を追加、列挙、検査、削除、クリアできます。

この記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付けられた効果チェーン、実効値、削除、および PPTX の往復検証の完全なワークフローを示します。

## **効果の所有権と画像再利用の理解**

画像リソースとそれを表示する画像は別オブジェクトです。

- [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) はプレゼンテーションが所有するソース画像データを格納または参照します。
- [Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) は画像塗りつぶしに属し、画像リソースを参照しながら画像変換コレクションを保持します。
- [PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) はスライド上のシェイプで、該当する画像塗りつぶし、ジオメトリ、切り抜き設定、その他フレームレベルの書式設定を所有します。

したがって、画像変換操作は [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) のバイトを変更しません。同じ [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/) に複数回渡すと、各新しい画像フレームは独自の [Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) と独自の変換コレクションを受け取ります。1 つのフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてが同じ埋め込み画像リソースを再利用しているからです。

同じ [Picture.getImageTransform](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) モデルは、シェイプやスライド背景など他の画像塗りつぶしでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位の使用**

示されているメソッドは以下の意味的範囲と単位を使用します。特定のライブラリ バージョンがすぐにすべての範囲外値を拒否しなくても、これらの範囲内に収めてください。ターゲットのプレゼンテーション形式は、保存時または PowerPoint がファイルを開く際に無効なデータを正規化、除外、または拒否する可能性があります。

| 操作 | パラメータ | 有効範囲と単位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100`〜`100`、パーセント；`0` はコンポーネントを変更しません。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | なし | 数値パラメータはありません。アルファは変更されません。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | 暗部と明部のピクセル用の 2 色。`java.awt.Color` の RGB とアルファは `0`〜`255`。 |
| [addTintEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | 色相は `0`（含む）〜`360`（除く）度、`amount` は `-100`〜`100` パーセント。 |
| [addHSLEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | 色相は `0`（含む）〜`360`（除く）度、彩度と輝度は `-100`〜`100` パーセント。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | 置換色はチャンネル値 `0`〜`255`。既存のアルファは変更されません。 |
| [addBlurEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | 半径は非負でポイント単位、`grow` はぼかし領域が元の境界を超えるかを制御するブール値。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | 非負パーセント。通常の不透明度スケーリングは `0`〜`100`：`0` は完全に透明、`100` は既存のアルファを保持。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0`〜`100` パーセントの不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0`〜`100` パーセントのアルファ閾値。閾値未満は透明、以上は不透明。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストの適用**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) は [BrightnessContrast](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/brightnesscontrast/) 操作を返します。スカラー設定は操作作成時に供給されます。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/brightnesscontrast/) は算出された読み取り専用値を返し、検査やログに利用できます。

以下の例は明るさを 15% 、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/brightnesscontrast/) は Office 2010 の画像効果拡張で、標準の DrawingML 輝度効果ほど移植性が高くありません。明るさとコントラストを PPTX 往復後も編集可能にしたい場合は、[ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用し、ファイル再オープン後に結果を検証してください。形式制限のセクションでこの違いを詳述しています。

## **カラー変換の適用**

カラー効果は、同一画像リソースを再利用する複数の画像フレームに対して独立して適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[Duotone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/duotone/) には 2 つの独立して編集可能なカラー パラメータがあります：`color1` が暗部ピクセル、`color2` が明部ピクセルにマッピングされます。これは単一スカラー値よりも設定が複雑な効果の有用な例です。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) はすべてのピクセルの色を固定色に置き換え、アルファは保持します。これは、ソース色を別の色にマッピングし、両方のカラー形式を公開する [addColorChangeEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) とは異なります。

## **ぼかし、透明度、アルファ効果の追加**

[addBlurEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) はアルファを含むすべてのカラー チャネルに影響します。ぼかしエッジが元の画像境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明度には [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用します。これは既存のすべてのアルファ値に乗算するため、部分的に透明なピクセルは比例的に異なるままです。[addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) はすべてのピクセルに単一のアルファ値を割り当てます。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) は閾値に基づいてアルファを 2 段階に変換します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

パラメータなしの他のアルファ操作には、すべての非ゼロアルファを完全に不透明にする [addAlphaCeilingEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/)、すべてのアルファを 100% 未満で完全に透明にする [addAlphaFloorEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/)、および `100% - alpha` に変更する [addAlphaInverseEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) があります。

## **順序付けられた効果チェーンの構築**

すべての `add...Effect` メソッドは新しい操作をコレクションの末尾に追加します。レンダラーはコレクションを順序付けられたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。そのため、同じ操作でも順序が異なると異なる画像が生成されます。

たとえば、グレースケールの後にティントを適用するとまず色情報が除去され、次に輝度結果が再着色されます。ティントの後にグレースケールを適用するとティントが再び除去されます。同様に、アルファ置換は以前の操作で算出されたアルファ値を上書きできますが、アルファ変調は相対的な差を保持します。

以下の例は 4 つの操作からなるチェーンを構築し、PPTX として保存後にプレゼンテーションを再オープンし、操作タイプと順序の両方をチェックし、再オープンした結果をレンダリングします。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

コレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせて使用できますが、常に有用とは限りません。固定カラー置換は以前のカラー効果で生成された RGB の変化を削除します。デュオトーンの後にグレースケールを適用すると 2 つの選択色が失われます。アルファの天井、床、置換、二段階操作は以前に作成されたアルファの詳細を破棄する可能性があります。目的のピクセル処理シーケンスに従ってチェーンを構築し、項目を順不同の書式フラグとして扱わないでください。

## **編集可能な値と実効値の検査**

編集可能な操作は [Picture.getImageTransform](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) に格納されているオブジェクトです。効果に応じて、直接書き込み可能なメンバーを公開する場合があります。たとえば、[Blur](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/blur/) は書き込み可能な `radius` と `grow` を、[AlphaModulateFixed](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/alphamodulatefixed/) は書き込み可能な `amount` を、[AlphaBiLevel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/alphabilevel/) は書き込み可能な `threshold` を公開します。 [Duotone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/duotone/) のようなカラー効果は可変的な [ColorFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorformat/) オブジェクトを公開します。

[BrightnessContrast](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tint/)、[AlphaReplace](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/alphareplace/) などの操作は、作成時のスカラーを書き込み可能プロパティとして公開しません。設定を変更するには、該当操作を削除し、必要な位置に新しい操作を追加してください。

`getEffective()` が返す実効データは計算済みで読み取り専用です。テーマ依存の色を解決したり、レンダラが使用する正規化値を取得したりするのに便利ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する場合に実効値を検査します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

グレースケール、アルファ天井、アルファ逆転などパラメータなしの効果でも実効データオブジェクトは存在しますが、出力すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換の削除またはクリア**

[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用してインデックスで 1 つの操作を削除します。削除後はインデックスがシフトするため、最初に対象を検索し、列挙後に削除してください。[ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用するとチェーン全体を削除できます。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

変換を削除またはクリアしても画像の書式設定のみが変更されます。再利用されている [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) リソースは削除、再圧縮、またはその他の変更は行われません。

## **プレゼンテーション形式とエクスポート先の考慮**

画像変換は DrawingML から派生しているため、効果チェーンの編集可能形式としては PPTX が推奨されます。PPTX でもすべての操作が同等の移植性を持つわけではありません。

- 輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作など標準 DrawingML 操作は PPTX 往復で残存する可能性が最も高いです。永続性が必要な場合は、生成したファイルを必ず再オープンし、コレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/brightnesscontrast/) は標準 DrawingML 輝度操作ではなく Office 2010 の拡張です。インメモリ描画には使用できますが、保存後に PPTX を再オープンした際に編集可能な [BrightnessContrast](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/brightnesscontrast/) 操作として残る保証はありません。永続的な明るさ・コントラスト調整には [addLuminanceEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) を優先してください。
- バイナリ PPT 形式は完全な DrawingML 効果モデルが登場する以前のものです。PPT に保存すると未対応の操作が省略されたり、チェーンがサポート対象のサブセットに縮小されたり、外観が近似されたりします。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンをレンダリング結果に適用します。これらの出力には編集可能な [ImageTransformOperationCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagetransformoperationcollection/) は含まれません。ラスタ形式は結果をピクセルにフラット化し、文書/ベクタ形式のエクスポートはそれぞれ独自のレンダリング表現を格納します。
- 効果はリンク画像を自己完結型にしません。リンク画像をレンダリングする際は、プレゼンテーション読み込み時にリンクリソースが利用可能である必要があります。

複数のアルファやカラー量子化操作を組み合わせた場合、異なるプレゼンテーション ビューアはエッジケースを異なる結果で描画することがあります。重要な出力の場合は、実稼働で使用している Aspose.Slides バージョンで、編集可能な往復と最終エクスポート形式の両方をテストしてください。

## **FAQ**

**画像変換効果は埋め込み画像データを変更しますか？**

いいえ。操作は画像塗りつぶしで使用される [Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) に属します。基盤となる [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームは効果を共有しますか？**

いいえ。[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) を再利用すると画像データの重複が回避されますが、各画像フレームは通常、個別の [Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/) と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファ効果は組み合わせられますか？**

はい。コレクションは 1 つの順序付けられたチェーンとして受け入れます。各操作が前の出力に与える影響を考慮してください。置換や閾値操作は以前のカラーまたはアルファの詳細を破棄する場合があります。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算値で、解決されたカラーなどを含みます。書き込み可能なメンバーがある操作はそのまま編集してください。そうでない場合は操作を削除し、新しい作成パラメータで置換してください。

**どの形式を使えば変換チェーンを保持できますか？**

PPTX を使用し、ファイルを再オープンして検証してください。レガシー PPT は完全な DrawingML 効果モデルを表現できず、レンダリング出力形式は外観を保持しますが編集可能な変換操作は保存されません。
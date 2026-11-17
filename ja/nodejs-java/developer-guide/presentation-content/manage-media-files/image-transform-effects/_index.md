---
title: JavaScript を使用したプレゼンテーションでの画像変換効果の管理
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
- エフェクトチェーン
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、画像フレームの画像変換効果を適用、連結、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像調整を画像変換操作の順序付きコレクションとして表します。画像フレームの場合、フレームの [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) から開始し、[Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) にアクセスします。返される [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用すると、元の画像バイトを書き換えることなく、効果を追加、列挙、検査、削除、クリアできます。

この記事では、明るさとコントラスト、色変換、ぼかし、透明度、順序付けられたエフェクトチェーン、実効値、削除、および PPTX ラウンドトリップ検証の完全なワークフローを示します。

## **エフェクトの所有権と画像の再利用を理解する**

An image resource and the picture that displays it are different objects:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) はプレゼンテーションが所有するソース画像データを格納または参照します。
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) は画像塗りつぶしに属し、画像リソースを参照しながら画像変換コレクションを保持します。
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) は、該当する画像塗りつぶし、ジオメトリ、クロップ設定、およびその他のフレームレベルの書式設定を所有するスライド形状です。

したがって、画像変換操作は [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) のバイトを変更しません。同じ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) が [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) に複数回渡されると、各新しい画像フレームは独自の [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) と独自の変換コレクションを受け取ります。1 つのフレームにグレイスケールを適用しても、他のフレームがグレイスケールになることはありません。同じ埋め込み画像リソースを再利用していてもです。

同じ [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) モデルは、シェイプやスライドの背景など他の画像塗りつぶしでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位を使用する**

示されたメソッドは以下の意味的範囲と単位を使用します。たとえ特定のライブラリバージョンがすべての範囲外の値を即座に拒否しなくても、これらの範囲内に値を保ってください。対象のプレゼンテーション形式は、保存時や PowerPoint がファイルを開く際にデータを正規化、除外、または拒否する可能性があります。

| 操作 | パラメータ | 有効な範囲と単位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` から `100` (パーセント); `0` はコンポーネントを変更しません。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | なし。数値パラメータはありません。アルファは変わりません。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | 暗部と明部のピクセル用の 2 つの色。`java.awt.Color` の RGB およびアルファチャンネルは `0` から `255` を使用します。 |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | 色相は `0` 以上 `360` 未満（度）; 量は `-100` から `100` (パーセント)。 |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | 色相は `0` 以上 `360` 未満（度）; 彩度と輝度は `-100` から `100` (パーセント)。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | 置換カラーはチャンネル値 `0` から `255` を使用します。既存のアルファ値は変更されません。 |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | 半径は負でなくポイントで測定されます; `grow` はブール値で、ぼかし領域が元の境界外に拡張できるかを制御します。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | 負でないパーセント。一般的な不透明度スケーリングには `0` から `100` を使用します: `0` は完全に透明、`100` は既存のアルファを保持します。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` から `100` (パーセント) の不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` から `100` (パーセント) のアルファしきい値。その以下は透明になり、以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストを適用する**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) は [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 操作を返します。そのスカラー設定は操作作成時に提供されます。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) は計算された読み取り専用値を返し、検査またはログに記録できます。

以下の例は明るさを 15% 、コントラストを 20% 上げ、埋め込み画像を変更せずにプレビューをレンダリングします。

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) は Office 2010 の画像効果拡張で、標準の DrawingML 輝度効果より移植性が低いです。明るさとコントラストを PPTX ラウンドトリップ後も編集可能にする必要がある場合は、[ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用し、ファイルを再度開いた後に結果を検証してください。この違いは「フォーマット制限」セクションで詳しく説明されています。

## **色変換を適用する**

色効果は、同一画像リソースを再利用する複数の画像フレームに対して個別に適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) には、暗いピクセルに対応する `color1` と明るいピクセルに対応する `color2` の 2 つの独立編集可能なカラー パラメータが含まれます。これは、設定が単一のスカラー値よりも複雑な効果の有用な例です。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) はアルファを保持しつつ、すべてのピクセルの色を固定の色に置き換えます。これは、ソースカラーを別のカラーにマッピングし、ソースとターゲットの両方のカラー形式を公開する [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) とは異なります。

### **輝度しきい値を適用する**

輝度しきい値は、スキャンしたページ上のかすかな痕跡を背景から区別しやすくします。[addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) は中間のグレー階調を保持します。[addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) は輝度を黒または白にマッピングし、[addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) は不透明度にしきい値を適用します。

輝度しきい値は 0% から 100%（両端含む）です。しきい値未満のピクセルは黒になり、しきい値以上のピクセルは白になります。しきい値を上げると、カットオフ以下になる階調が増えるため、より多くの色調が黒になります。

[grayscale-swatches.png](grayscale-swatches.png) を作業ディレクトリにダウンロードしてください。各ラベルは 0 から 255 のスケールで元のグレーレベルを示します。例では元画像を 2 つのコピーの横に配置し、各コピーのしきい値をプレゼンテーションに保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint で出力プレゼンテーションを開き、3 つのフレームを比較してください。ラベル 96 のスウォッチは約 38% の輝度（255 のうち 96）です。20% のしきい値で白に、60% のしきい値で黒になります。

![元のグレースケールスウォッチと、輝度しきい値 20% と 60% の黒白結果を並べたもの](luminance-threshold.png)

## **ぼかし、透明度、アルファ効果を追加する**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) はアルファを含むすべてのカラーチャンネルに影響します。ぼかしエッジが元画像の境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明度には [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用します。既存のすべてのアルファ値に乗算するため、部分的に透明なピクセルは比例的に異なるままです。[addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) はすべてのピクセルに単一のアルファ値を割り当てます。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) はしきい値に基づいてアルファを 2 段階に変換します。

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

その他のパラメータなしのアルファ操作として、[addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) はゼロ以外のすべてのアルファを完全に不透明にし、[addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) は 100% 未満のすべてのアルファを完全に透明にし、[addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) はアルファを `100% - alpha` に変換します。

## **順序付きエフェクトチェーンを構築する**

すべての `add...Effect` メソッドはコレクションの末尾に新しい操作を追加します。レンダラーはコレクションを順序付けられたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。したがって、同じ操作でも順序を変えると異なる画像になることがあります。

例として、グレースケールの後にティントを適用すると、まず色情報が除去され、次に輝度結果が再着色されます。ティントの後にグレースケールを適用すると、ティントが再び除去されます。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きでき、アルファ変調はそれらの相対的な違いを保持します。

以下の例は 4 つの操作チェーンを構築し、PPTX として保存し、プレゼンテーションを再度開き、操作の種類と順序を確認し、再開された結果をレンダリングします。

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

コレクションは、カラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。これらは組み合わせ可能ですが、組み合わせが常に有用とは限りません。固定カラー置換は以前のカラー効果で生じた RGB 変化を除去し、デュオトーンの後のグレースケールは選択された二色を除去し、アルファの天井、床、置換、または二段階操作は以前に作成されたアルファ詳細を破棄することがあります。項目を順不同の書式設定フラグとして扱うのではなく、望ましいピクセル処理シーケンスに従ってチェーンを構築してください。

<!-- visual-explanation:image-transform-effects:start -->
[![同じ画像がグレースケール→ティント、またはティント→グレースケールの順に通過します。最終的な 2 つのグレースケール画像は異なるトーンになります。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*この Aspose.Slides for .NET 26.11 のイラスト的なレンダリングでは、220° のティントを 25% で適用するとグレースケール画像は変わりません。同じティントをグレースケールの前に適用すると異なるトーンになります。*
<!-- visual-explanation:image-transform-effects:end -->

## **編集可能および実効値を検査する**

編集可能な操作は [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) に格納されているオブジェクトです。エフェクトに応じて、書き込み可能なメンバーを直接公開する場合があります。例えば、[Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) は書き込み可能な `radius` と `grow` 値を公開し、[AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) は書き込み可能な `amount` を、[AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) は書き込み可能な `threshold` を公開します。[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) のようなカラー効果は変更可能な [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) オブジェクトを公開します。

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/)、[AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/) などの一部の操作は、作成時のスカラーを書き込み可能なプロパティとして公開しません。これらの設定を変更するには、操作を削除し、必要な位置に置き換えの操作を追加してください。

`getEffective()` が返す実効データは計算済みの読み取り専用です。テーマ依存のカラーを解決したり、レンダラーが使用する正規化された値を取得したりするのに有用ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する場合に実効値を検査します。

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

グレースケール、アルファ天井、アルファ反転などのパラメータ不要の効果でも実効データオブジェクトは存在しますが、出力すべきスカラー設定はありません。重要なのはそれらの存在とコレクション内の位置です。

## **画像変換を削除またはクリアする**

[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用してインデックスで操作を 1 つ削除します。削除後にインデックスがシフトするため、最初に対象を検索し、列挙後に削除してください。[ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) を使用すると、チェーン全体を削除できます。

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

変換を削除またはクリアしても、画像の書式設定のみが変更されます。再利用されている [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) リソースは削除、再圧縮、またはその他の変更は行われません。

## **プレゼンテーション形式とエクスポート対象を検討する**

画像変換は DrawingML から派生するため、エフェクトチェーンの編集可能な形式として PPTX が推奨されます。PPTX でも、すべての操作が同じ移植性を持つわけではありません:

- 輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作などの標準 DrawingML 操作は、PPTX ラウンドトリップで維持される可能性が最も高いです。保存性が求められる場合は、常に生成ファイルを再度開き、コレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) は標準の DrawingML 輝度操作ではなく Office 2010 の拡張です。インメモリレンダリングには使用できますが、PPTX を保存・再オープンした後に編集可能な [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 操作として残る保証はありません。永続的な明るさとコントラスト調整には [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) を優先してください。
- バイナリ PPT 形式は完全な DrawingML エフェクトモデルよりも前に作られました。PPT に保存するとサポートされない操作が省かれ、チェーンがサポートされるサブセットに縮小されるか、外観が近似されることがあります。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などへのレンダリングは、サポートされたチェーンを描画結果に適用します。これらの出力には編集可能な [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) は含まれません。ラスタ形式は結果をピクセルにフラット化し、ドキュメント/ベクトルエクスポートは独自のレンダリング表現を保存します。
- エフェクトはリンクされた画像を自己完結させません。リンク画像のレンダリングは、プレゼンテーション読み込み時にリンクリソースが利用可能であることに依存します。

異なるプレゼンテーションの閲覧者は、特に複数のアルファやカラー量子化操作が組み合わさる場合に、エッジケースの描画が異なることがあります。重要な出力では、編集可能なラウンドトリップと最終エクスポート形式の両方を、実運用で使用している同じ Aspose.Slides バージョンでテストしてください。

## **よくある質問**

**画像変換エフェクトは埋め込み画像データを変更しますか？**

いいえ。操作は画像塗りつぶしで使用される [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) に属します。基礎となる [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームはエフェクトを共有しますか？**

いいえ。[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) を再利用すると画像データの重複は避けられますが、各画像フレームは通常個別の [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファ効果は組み合わせられますか？**

はい。コレクションは 1 つの順序付きチェーンとして受け入れます。置換やしきい値の操作は以前のカラーやアルファの詳細を破棄する可能性があるため、各操作が前の出力に何を行うかを考慮してください。

**なぜ実効値は読み取り専用ですか？**

実効データは、解決されたカラーを含む、レンダリングに使用される計算値を表します。書き込み可能なメンバーがある場合は、変換コレクションに格納された操作を編集してください。そうでない場合は、操作を削除し、新しい作成パラメータで置き換えを追加してください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、ファイルを再度開いて検証してください。従来の PPT は完全な DrawingML エフェクトモデルを表現できず、レンダリングされたエクスポート形式は外観を保持しますが、編集可能な変換操作は保持しません。
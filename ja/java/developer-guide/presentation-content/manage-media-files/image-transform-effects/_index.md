---
title: Java でプレゼンテーションの画像変換効果を管理する
linktitle: 画像変換効果
type: docs
weight: 11
url: /ja/java/image-transform-effects/
keywords:
- 画像変換
- 画像効果
- 明るさ
- コントラスト
- グレースケール
- デュートーン
- ティント
- HSL
- カラー置換
- ぼかし
- 透明度
- アルファ効果
- 効果チェーン
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、画像フレームの画像変換効果を適用、チェーン、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像調整を画像変換操作の順序付けされたコレクションとして表現します。画像フレームの場合、フレームの [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) から開始し、[ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--) にアクセスします。返される [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) では、元の画像バイト列を書き換えることなく、効果の追加、列挙、検査、削除、クリアが可能です。

この記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付けされた効果チェーン、有効値、削除、および PPTX の往復検証を行う完全なワークフローを示します。

## **効果の所有権と画像の再利用を理解する**

画像リソースとそれを表示する画像は別個のオブジェクトです。

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) はプレゼンテーションが所有する元画像データを格納または参照します。
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) は画像塗りつぶしに属し、画像リソースを参照しながら画像変換コレクションを保持します。
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) はスライド上のシェイプで、該当する画像塗りつぶし、ジオメトリ、クロップ設定、その他フレームレベルの書式設定を所有します。

したがって、画像変換操作は [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) のバイト列を変更しません。同じ `IPPImage` を [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) に複数回渡すと、各新しい画像フレームは独自の `ISlidesPicture` と独自の変換コレクションを取得します。あるフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてが同じ埋め込み画像リソースを再利用していても同様です。

同じ `ISlidesPicture.getImageTransform` モデルは、シェイプやスライド背景など他の画像塗りつぶしでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメーター範囲と単位を使用する**

示されたメソッドは次の意味的範囲と単位を使用します。特定のライブラリ バージョンがすぐに範囲外の値を拒否しなくても、これらの範囲内に収めてください。ターゲットのプレゼンテーション形式は保存時または PowerPoint がファイルを開く際に無効なデータを正規化、除外、または拒否する可能性があります。

| 操作 | パラメーター | 有効範囲と単位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` から `100`、パーセント；`0` はコンポーネントを変更しません。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | なし | 数値パラメーターはありません。アルファは変更されません。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 暗部と明部のピクセル用に 2 色。`java.awt.Color` の RGB およびアルファチャンネルは `0` から `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相は `0`（含む）から `360`（除く）度；量は `-100` から `100`、パーセント。 |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相は `0`（含む）から `360`（除く）度；彩度と輝度は `-100` から `100`、パーセント。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 置換色は `0` から `255` のチャンネル値を使用。既存のアルファは変更されません。 |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半径は非負でポイント単位；`grow` はブール値で、ぼかし領域が元の境界を超えるかを制御します。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非負パーセント。通常の不透明度スケーリングは `0` から `100`：`0` は完全に透明、`100` は既存のアルファを保持。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` から `100`、パーセント不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` から `100`、パーセントアルファしきい値。しきい値未満は透明、以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば 35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストを適用する**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) は [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) 操作を返します。スカラー設定は操作作成時に供給されます。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) は計算された読み取り専用値を返し、検査またはログに出力できます。

次の例は明るさを 15% 、コントラストを 20% 上げ、埋め込み画像を変更せずにプレビューをレンダリングします。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) は Office 2010 の画像効果拡張で、標準 DrawingML 輝度効果ほど移植性が高くありません。明るさとコントラストを PPTX 往復後も編集可能に保ちたい場合は、[IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) を使用し、ファイル再オープン後に結果を検証してください。形式の制限セクションでこの違いを詳しく説明しています。

## **カラー変換を適用する**

カラー効果は、同一画像リソースを再利用する複数の画像フレームに対して個別に適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュートーン、ティント、HSL 調整、カラー置換を適用します。

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) には `color1`（暗部ピクセル）と `color2`（明部ピクセル）という 2 つの独立した編集可能カラー パラメーターがあります。これは単一のスカラー値よりも設定が複雑な効果の有用な例です。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) はすべてのピクセルの色を固定色に置き換え、アルファは保持します。これは、ソース色を別の色にマップし、両方の色形式を公開する [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) とは異なります。

### **輝度しきい値を適用する**

輝度しきい値は、スキャンしたページ上の薄い印刷物を背景から区別しやすくします。[addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) は中間のグレイ階調を保持します。[addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) は輝度を黒または白にマップし、[addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) は不透明度にしきい値を適用します。

輝度しきい値の範囲は 0% から 100%（両端含む）です。しきい値未満のピクセルは黒になり、しきい値以上のピクセルは白になります。しきい値を上げると、より多くの階調が黒になるため、カットオフ以下に落ちるピクセルが増えます。

[grayscale-swatches.png](grayscale-swatches.png) を作業ディレクトリにダウンロードしてください。各ラベルは 0〜255 のスケールで元のグレイレベルを示しています。例は元画像を 2 つのコピーと共に配置し、各コピーのしきい値をプレゼンテーションに保存します。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);
    
    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint で出力プレゼンテーションを開き、3 つのフレームを比較してください。ラベル 96 のスウォッチは約 38% の輝度（255 中 96）です。20% のしきい値で白に、60% のしきい値で黒になります。

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **ぼかし、透明度、アルファ効果を追加する**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) はすべてのカラーチャネル（アルファ含む）に影響します。ぼかしエッジが元の画像境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明度には [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) を使用します。これは既存のアルファ値に対して乗算するため、部分的に透明なピクセルは比例的に異なるまま残ります。[addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) はすべてのピクセルに同一のアルファ値を割り当てます。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) はしきい値に基づいてアルファを 2 段階に変換します。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

パラメーターなしの他のアルファ操作には、[addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)（すべての非ゼロアルファを完全不透明に）や、[addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)（100% 未満のアルファを完全透明に）そして [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)（`100% - alpha` に変換）があります。

## **順序付けされた効果チェーンを構築する**

すべての `add...Effect` メソッドはコレクションの末尾に新しい操作を追加します。レンダラはコレクションを順序付けされたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。したがって、同じ操作でも順序が異なると異なる画像が生成されます。

たとえば、グレースケールの後にティントを適用すると、色相情報が除去された後に色付けされます。ティントの後にグレースケールを適用すると、ティントが再び除去されます。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きでき、アルファ変調はそれらの相対的な差を保持します。

次の例は 4 操作からなるチェーンを構築し、PPTX として保存し、プレゼンテーションを再オープンして操作タイプと順序の両方をチェックし、再オープンした結果をレンダリングします。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

このコレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせて使用可能ですが、常に有用とは限りません。固定カラー置換は以前のカラー効果が作り出す RGB のばらつきを除去します。デュートーンの後にグレースケールを適用すると、選択された 2 色が失われます。アルファの天井、床、置換、または二段階操作は、以前に作成されたアルファの詳細を破棄することがあります。望ましいピクセル処理順序に基づいてチェーンを構築し、項目を順不同の書式フラグとして扱わないでください。

<!-- visual-explanation:image-transform-effects:start -->
[![同じ画像がグレースケール→ティント、ティント→グレースケールの順に通過します。最終的な 2 つのグレースケール画像は異なるトーンになります。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*この Aspose.Slides for .NET 26.11 のレンダー例では、220° のティント（25%）はグレースケール画像に影響しません。同じティントをグレースケールの前に適用すると異なるトーンになります。*
<!-- visual-explanation:image-transform-effects:end -->

## **編集可能な値と有効値を検査する**

編集可能な操作は `ISlidesPicture.getImageTransform` に格納されたオブジェクトです。効果に応じて、直接書き込み可能なメンバーを公開することがあります。たとえば、[IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) は書き込み可能な `radius` と `grow` を、[IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) は書き込み可能な `amount` を、[IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) は書き込み可能な `threshold` を公開します。 [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) のようなカラー効果は変更可能な [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) オブジェクトを公開します。

[IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/) などのインターフェイスは、作成時のスカラーを書き込み可能プロパティとして公開しません。これらの設定を変更するには、操作を削除し、必要な位置に置き換える必要があります。

`getEffective()` が返す有効データは計算済みで読み取り専用です。テーマ依存の色を解決したり、レンダラが使用する正規化値を取得したりするのに便利ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する有効値を検査します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

グレースケール、アルファ天井、アルファ逆転などのパラメーターなし効果も有効データオブジェクトを持ちますが、出力すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換を削除またはクリアする**

[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) を使用してインデックスで 1 つの操作を削除します。インデックスは削除後にシフトするため、まず対象を検索し、列挙後に削除してください。[ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) を使用するとチェーン全体を削除できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

変換を削除またはクリアしても、画像の書式設定のみが変更されます。[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) リソース自体は削除、再圧縮、または変更されません。

## **プレゼンテーション形式とエクスポート先を考慮する**

画像変換は DrawingML に起因するため、効果チェーンの編集可能な形式としては PPTX が推奨されます。PPTX でもすべての操作が同等に移植できるわけではありません。

- 標準 DrawingML 操作（輝度、グレースケール、デュートーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX 往復で残る可能性が最も高いです。保存後に必ずファイルを再オープンし、コレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) は Office 2010 の拡張で、標準 DrawingML 輝度操作ではありません。メモリ内レンダリングには使用可能ですが、保存・再オープン後に編集可能な [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) として残る保証はありません。永続的な明るさ・コントラスト調整には [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) を推奨します。
- バイナリ PPT 形式は完全な DrawingML 効果モデルが導入される前のものです。PPT に保存すると未対応の操作が除外されたり、チェーンがサポートされたサブセットに縮小されたり、外観が近似されたりします。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンをレンダリング結果に適用しますが、これらの出力は編集可能な `IImageTransformOperationCollection` を含みません。ラスタ形式は結果をピクセルにフラット化し、文書/ベクタエクスポートは独自のレンダリング表現を保存します。
- 効果はリンク画像を自己完結型にしません。リンク画像のレンダリングは、プレゼンテーション読み込み時にリンクリソースが利用可能であることに依存します。

複数のアルファやカラー量子化操作を組み合わせた場合、異なるプレゼンテーション ビューアはエッジケースを異なる方法で描画することがあります。重要な出力の場合は、編集可能な往復と最終エクスポート形式の両方を、実稼働で使用している同一バージョンの Aspose.Slides でテストしてください。

## **FAQ**

**画像変換効果は埋め込み画像データを変更しますか？**

いいえ。操作は画像塗りつぶしで使用される `ISlidesPicture` に属し、基礎となる `IPPImage` バイト列は変更されません。

**同じ画像を再利用する 2 つの画像フレームは効果を共有しますか？**

いいえ。`IPPImage` を再利用すると画像データの重複は避けられますが、各画像フレームは通常個別の `ISlidesPicture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファ効果は組み合わせられますか？**

はい。コレクションは 1 つの順序付けされたチェーンとして受け入れます。置換やしきい値操作は以前のカラーやアルファの詳細を破棄する可能性があるため、各操作が前の出力に与える影響を考慮してください。

**なぜ有効値は読み取り専用ですか？**

有効データはレンダリングに使用される計算済みの値で、解決されたカラーを含みます。書き込み可能なメンバーがある操作は変換コレクション内のオブジェクトを編集してください。そうでない場合は操作を削除し、新しい作成パラメーターで置き換えてください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、ファイルを再オープンして確認してください。レガシー PPT は完全な DrawingML 効果モデルを表現できず、レンダリングされたエクスポート形式は外観は保持しますが、編集可能な変換操作は保持しません。
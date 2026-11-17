---
title: Android のプレゼンテーションで画像変換エフェクトを管理する
linktitle: 画像変換エフェクト
type: docs
weight: 11
url: /ja/androidjava/image-transform-effects/
keywords:
- 画像変換
- 画像エフェクト
- 明るさ
- コントラスト
- グレースケール
- デュオトーン
- ティント
- HSL
- カラー置換
- ぼかし
- 透明度
- アルファエフェクト
- エフェクトチェーン
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用し、画像フレームに対して画像変換エフェクトを適用、連鎖、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像調整を画像変換操作の順序付けされたコレクションとして表します。画像フレームの場合、フレームの [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) から開始し、[ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) にアクセスします。返される [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) を使用すると、元の画像バイトを書き換えることなく、エフェクトを追加、列挙、検査、削除、クリアできます。

この記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付けされたエフェクトチェーン、実効値、削除、PPTX の往復検証の完全なワークフローを示します。

## **エフェクトの所有権と画像の再利用を理解する**

画像リソースとそれを表示する画像は別々のオブジェクトです:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) はプレゼンテーションが所有するソース画像データを格納または参照します。
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) は画像フィルの一部であり、画像リソースを参照しながら画像変換コレクションを保持します。
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) はスライド上のシェイプで、関連する画像フィル、ジオメトリ、クロップ設定、その他のフレームレベルの書式設定を所有します。

したがって、画像変換操作は [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) のバイトを変更しません。同じ `IPPImage` を [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) に複数回渡すと、各新しい画像フレームは独自の `ISlidesPicture` と独自の変換コレクションを受け取ります。あるフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてのフレームが同じ埋め込み画像リソースを再利用しているからです。

同じ `ISlidesPicture.getImageTransform` モデルは、シェイプやスライドの背景など他の画像フィルでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位を使用する**

示されたメソッドは以下の意味的範囲と単位を使用します。特定のライブラリ バージョンがすぐにすべての範囲外値を拒否しなくても、これらの範囲内に値を保ってください。保存時や PowerPoint がファイルを開く際に、対象のプレゼンテーション形式が正規化、除外、または無効なデータを拒否する可能性があります。

| 操作 | パラメータ | 有効範囲と単位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` から `100`、パーセント; `0` はコンポーネントを変更しません。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | なし | 数値パラメータはありません。アルファは変更されません。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 暗部と明部のピクセル用の2色。`android.graphics.Color` が使用する RGB とアルファ チャネルの値は `0` から `255` の範囲です。 |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相は `0` (含む) から `360` (除く) 度; `amount` は `-100` から `100` パーセント。 |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相は `0` (含む) から `360` (除く) 度; 彩度と輝度は `-100` から `100` パーセント。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 置換色は `0` から `255` のチャネル値を使用します。既存のアルファ値は変更されません。 |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半径は非負でポイント単位; `grow` はブラーされたコンテンツが元の境界を超えて広がるかを制御する Boolean。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非負パーセント。通常の不透明度スケーリングには `0` から `100` を使用: `0` は完全に透明、`100` は既存のアルファを保持。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` から `100` パーセントの不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` から `100` パーセントのアルファしきい値。これ未満は透明に、以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば 35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストを適用する**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) は [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) 操作を返します。スカラー設定は操作作成時に供給されます。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) は計算された読み取り専用の値を返し、検査やログ記録に使用できます。

次の例は明るさを 15% 、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) は Office 2010 の画像エフェクト拡張で、標準の DrawingML 輝度エフェクトほど移植性が高くありません。PPTX の往復後も明るさとコントラストを編集可能に保つ必要がある場合は、[IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) を使用し、ファイルを再度開いた後に結果を検証してください。形式の制限セクションでこの違いが詳しく説明されています。

## **カラー変換を適用する**

カラーエフェクトは、同一画像リソースを再利用する異なる画像フレームに個別に適用できます。次の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) には 2 つの独立して編集可能なカラー パラメータがあります: `color1` は暗いピクセル、`color2` は明るいピクセルに対応します。これは単一スカラー値よりも複雑な設定を持つエフェクトの有用な例です。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) は、アルファを保持しながらすべてのピクセルの色を固定色に置き換えます。これは、ソース色を別の色にマッピングし、両方の色形式を公開する [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) とは異なります。

### **輝度しきい値を適用する**

輝度しきい値は、スキャンしたページ上の薄い跡を背景から区別しやすくします。[addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) は中間のグレー階調を保持します。[addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) は輝度を黒または白にマッピングし、[addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) は不透明度にしきい値を適用します。

輝度しきい値は 0% から 100%（含む）です。しきい値未満のピクセルは黒になります。しきい値以上のピクセルは白になります。しきい値を上げると、より多くの階調が黒になるため、カットオフ以下になるピクセルが増えます。

[grayscale-swatches.png](grayscale-swatches.png) を作業ディレクトリにダウンロードしてください。各ラベルは 0 から 255 のスケールで元のグレー レベルを示しています。例では元画像を 2 つのコピーと並べ、各コピーのしきい値をプレゼンテーションに保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

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

出力プレゼンテーションを PowerPoint で開き、3 つのフレームを比較してください。ラベル 96 のスウォッチは約 38% の輝度（255 中 96）です。20% のしきい値で白になり、60% のしきい値で黒になります。

![元のグレースケール スウォッチと、輝度しきい値 20% と 60% での白黒結果](luminance-threshold.png)

## **ぼかし、透明度、アルファ効果を追加する**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) はすべてのカラー チャネル、アルファを含めて影響します。ぼかしエッジが元画像の境界を超える可能性がある場合は、`grow` を `true` に設定してください。

均一な透明度を得るには、[addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) を使用します。これは既存のすべてのアルファ値に乗算するため、部分的に透明なピクセルは比例的に異なるままです。[addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) はすべてのピクセルに単一のアルファ値を割り当てます。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) はしきい値に基づきアルファを 2 段階に変換します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

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

パラメータなしのその他のアルファ操作には、[addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)（すべての非ゼロアルファを完全に不透明に）、[addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)（100% 未満のアルファを完全に透明に）、[addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)（アルファを `100% - alpha` に変換）があります。

## **順序付けされたエフェクトチェーンを構築する**

すべての `add...Effect` メソッドは新しい操作をコレクションの末尾に追加します。レンダラはコレクションを順序付けられたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。したがって、同じ操作でも順序を変えると異なる画像が得られます。

たとえば、グレースケールの後にティントを適用すると、まず色相情報が除去され、その後輝度結果が再着色されます。ティントの後にグレースケールを適用すると、ティントが再度除去されます。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きでき、アルファ変調はそれらの相対的な差異を保持します。

次の例は 4 操作のチェーンを構築し、PPTX として保存し、プレゼンテーションを再度開いて操作の種類と順序を確認し、再開した結果をレンダリングします:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

このコレクションは、カラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせて使用できますが、常に有用とは限りません。固定のカラー置換は以前のカラー効果で生成された RGB のばらつきを除去します。デュオトーンの後にグレースケールを適用すると 2 つの選択色が削除されます。アルファの上限、下限、置換、二段階操作は、以前に作成されたアルファの詳細を破棄する可能性があります。望むピクセル処理シーケンスに基づいてチェーンを構築し、項目を順序付けられた書式フラグとして扱わないでください。

<!-- visual-explanation:image-transform-effects:start -->
[![同じ画像がグレースケール → ティント、またはティント → グレースケールの順で通過します。2 つの最終グレースケール画像は異なるトーンになります。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*この Aspose.Slides for .NET 26.11 のレンダリング例では、220° のティントを 25% の強度で適用するとグレースケール画像は変化しません。同じティントをグレースケールの前に適用すると異なるトーンになります。*
<!-- visual-explanation:image-transform-effects:end -->

## **編集可能な値と実効値を検査する**

編集可能な操作は `ISlidesPicture.getImageTransform` に格納されたオブジェクトです。エフェクトによっては、書き込み可能なメンバーを直接公開します。たとえば、[IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) は書き込み可能な `radius` と `grow` を公開し、[IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) は書き込み可能な `amount` を、[IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) は書き込み可能な `threshold` を公開します。[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) などのカラーエフェクトは変更可能な [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) オブジェクトを公開します。

[IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/) などの一部の操作インターフェイスは、作成時のスカラーを書き込み可能なプロパティとして公開しません。これらの設定を変更するには、対象の操作を削除し、必要な位置に新しいものを追加してください。

`getEffective()` が返す実効データは計算済みで読み取り専用です。テーマ依存のカラーを解決したり、レンダラが使用する正規化値を取得したりするのに便利ですが、別の編集対象ではありません。次の例はチェーンを列挙し、対応する API が提供する実効値を検査します:

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

グレースケール、アルファ上限、アルファ反転などのパラメータなしエフェクトでも実効データオブジェクトは存在しますが、出力するスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換を削除またはクリアする**

[IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) を使用してインデックスで 1 つの操作を削除します。インデックスは削除後にシフトするため、まず対象を検索し、列挙後に削除してください。[ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) を使用するとチェーン全体を削除できます。

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

変換を削除またはクリアしても、画像の書式設定だけが変更されます。[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) リソース自体は削除、再圧縮、またはその他の変更は行われません。

## **プレゼンテーション形式とエクスポート先を検討する**

画像変換は DrawingML から発生するため、エフェクトチェーンの編集可能形式としては PPTX が推奨されます。PPTX でもすべての操作が同等の移植性を持つわけではありません:

- 標準の DrawingML 操作（輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX の往復で残存する可能性が最も高いです。保存後にファイルを再度開き、コレクションを検査して保持が必要か確認してください。
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) は Office 2010 の拡張で、標準の DrawingML 輝度操作ではありません。インメモリのレンダリングには使用できますが、保存して PPTX を再度開いた後に編集可能な [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) が残る保証はありません。永続的な明るさとコントラスト調整には [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) を優先してください。
- バイナリ PPT 形式は完全な DrawingML エフェクトモデルが導入される前のものです。PPT に保存すると、未対応の操作が省かれたり、チェーンがサポートされたサブセットに縮小されたり、外観が近似されたりします。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力へのレンダリングは、サポートされたチェーンを描画された外観に適用します。これらの出力には編集可能な `IImageTransformOperationCollection` は含まれず、ラスタ形式は結果をピクセルにフラット化し、ドキュメント/ベクタエクスポートは独自のレンダリング表現を保存します。
- エフェクトはリンクされた画像を自己完結型にしません。リンク画像のレンダリングは、プレゼンテーションが読み込まれる際にリンクリソースが利用可能であることに依存します。

異なるプレゼンテーション ビューアは、特に複数のアルファまたはカラー量子化操作が組み合わさった場合に、エッジケースを異なる方法で描画することがあります。重要な出力の場合は、同じ Aspose.Slides バージョンで編集可能な往復と最終エクスポート形式の両方をテストしてください。

## **FAQ**

**画像変換エフェクトは埋め込み画像データを変更しますか？**

いいえ。操作は画像フィルで使用される `ISlidesPicture` に属します。基盤となる `IPPImage` バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームはエフェクトを共有しますか？**

いいえ。`IPPImage` を再利用すると画像データの重複は防げますが、通常各画像フレームは個別の `ISlidesPicture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファエフェクトは組み合わせ可能ですか？**

はい。コレクションは 1 つの順序付けられたチェーンで受け入れます。各操作が前の出力に何を行うかを考慮してください。置換やしきい値操作は前のカラーやアルファの詳細を破棄する可能性があります。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算結果で、解決されたカラーを含みます。書き込み可能なメンバーがある操作は変換コレクション内のオブジェクトを編集してください。そうでなければ、操作を削除し新しい作成パラメータで置換してください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、再度開いてファイルを検証してください。レガシー PPT は完全な DrawingML エフェクトモデルを表現できず、エクスポート形式は外観を保持しますが編集可能な変換操作は保持しません。
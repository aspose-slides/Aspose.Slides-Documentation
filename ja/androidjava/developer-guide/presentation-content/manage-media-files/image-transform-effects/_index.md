---
title: Android でのプレゼンテーションにおける画像変換エフェクトの管理
linktitle: 画像変換エフェクト
type: docs
weight: 11
url: /ja/androidjava/image-transform-effects/
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
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 用 Aspose.Slides で画像フレームに対する画像変換エフェクトを適用、チェーン化、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像調整を画像変換操作の順序付けられたコレクションとして表現します。画像フレームの場合、フレームの [ISlidesPicture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/) から開始し、[ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) にアクセスします。返される [IImageTransformOperationCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/) では、元の画像バイト列を書き換えることなく、エフェクトの追加、列挙、検査、削除、クリアが可能です。

この項目では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付けられたエフェクトチェーン、実効値、削除、そして PPTX のラウンドトリップ検証の完全なワークフローを示します。

## **効果所有権と画像の再利用の理解**

画像リソースとそれを表示する画像は別々のオブジェクトです。

- [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) はプレゼンテーションが所有する元画像データを格納または参照します。
- [ISlidesPicture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/) は画像塗りつぶしに属し、画像リソースを参照しながら画像変換コレクションを保持します。
- [IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) はスライドのシェイプで、該当する画像塗りつぶし、ジオメトリ、切り抜き設定、その他フレームレベルの書式設定を所有します。

したがって、画像変換操作は [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) のバイト列を変更しません。同じ `IPPImage` を [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) に複数回渡すと、各新しい画像フレームは独自の `ISlidesPicture` と独自の変換コレクションを受け取ります。あるフレームにグレースケールを適用しても、他のフレームが同じ埋め込み画像リソースを再利用していてもグレースケールにはなりません。

同じ `ISlidesPicture.getImageTransform` モデルは、シェイプやスライド背景など他の画像塗りつぶしでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位の使用**

以下のメソッドは次の意味的範囲と単位を使用します。特定のライブラリ バージョンがすぐに範囲外の値を拒否しなくても、対象のプレゼンテーション形式は保存時または PowerPoint がファイルを開く際に正規化、除外、または無効データとして拒否する可能性があります。

| 操作 | パラメータ | 有効範囲と単位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` から `100`（パーセント）；`0` はコンポーネントを変更しません。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | なし | 数値パラメータはありません。アルファは変更されません。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 暗部と明部の2色。`android.graphics.Color` が使用する RGB とアルファ チャネルの値は `0` から `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相は `0`（含む）から `360`（除く）までの度数；`amount` は `-100` から `100`（パーセント）。 |
| [addHSLEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相は `0`（含む）から `360`（除く）までの度数；彩度と輝度は `-100` から `100`（パーセント）。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 置換色は各チャンネルが `0` から `255` の範囲。既存のアルファは変更されません。 |
| [addBlurEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半径は非負でポイント単位；`grow` はブラー領域が元の境界を超えてもよいかを制御するブール値。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非負パーセント。通常の不透明度スケーリングには `0`〜`100` を使用：`0` は完全に透明、`100` は既存のアルファを保持。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` から `100`（パーセント）不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` から `100`（パーセント）アルファしきい値。しきい値未満は透明に、しきい値以上は不透明になる。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストの適用**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) は [IBrightnessContrast](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibrightnesscontrast/) 操作を返します。スカラー設定は操作作成時に供給されます。[IBrightnessContrast.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) は計算された読み取り専用値を返し、検査やログ出力に利用できます。

次の例は明るさを 15% 増加し、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

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

[BrightnessContrast](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/brightnesscontrast/) は Office 2010 の画像エフェクト拡張であり、標準の DrawingML 輝度エフェクトほど移植性が高くありません。明るさとコントラストを PPTX のラウンドトリップ後も編集可能に保つ必要がある場合は、[IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) を使用し、ファイルを再度開いた後に結果を検証してください。フォーマット制限のセクションでこの違いを詳しく説明しています。

## **カラー変換の適用**

カラーエフェクトは、同一画像リソースを再利用する複数の画像フレームに対して個別に適用できます。次の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[IDuotone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iduotone/) には 2 つの独立した編集可能カラー パラメータがあります：`color1` は暗いピクセル、`color2` は明るいピクセルに対応します。これは単一のスカラー値よりも設定が複雑なエフェクトの有用な例です。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) はすべてのピクセルの色を固定色に置き換え、アルファは保持します。これは [addColorChangeEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) とは異なり、あるソース色を別の色にマップし、両方の色形式を公開します。

## **ぼかし、透明度、アルファ効果の追加**

[addBlurEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) はすべてのカラー チャネル、アルファも含めて影響します。ぼかしエッジが元画像の境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明度には [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) を使用します。これは既存のすべてのアルファ値に乗算するため、部分的に透明なピクセルは比例的に異なるままです。[addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) はすべてのピクセルに同じアルファ値を割り当てます。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) はしきい値に基づいてアルファを 2 レベルに変換します。

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

パラメータなしのその他のアルファ操作には、すべての非ゼロアルファを完全に不透明にする [addAlphaCeilingEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)、100% 未満のアルファを完全に透明にする [addAlphaFloorEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)、および `100% - alpha` に変換する [addAlphaInverseEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) があります。

## **順序付けられたエフェクトチェーンの構築**

すべての `add...Effect` メソッドは新しい操作をコレクションの末尾に追加します。レンダラはコレクションを順序付けられたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。そのため、同じ操作でも順序を変えると異なる画像が生成されます。

例として、グレースケールの後にティントを適用すると、まず色相情報が除去され、その後輝度結果が再着色されます。ティントの後にグレースケールを適用すると、ティントが再び除去されます。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きでき、アルファ変調は相対的な差異を保持します。

次の例は 4 つの操作からなるチェーンを構築し、PPTX として保存し、プレゼンテーションを再度開いて操作タイプと順序の両方を確認し、再オープンした結果をレンダリングします。

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

コレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせて使用できますが、常に有用とは限りません。固定カラー置換は以前のカラー効果で生成された RGB のばらつきを除去します。デュオトーンの後にグレースケールを適用すると 2 色が失われます。アルファの天井、床、置換、または二段階操作は以前に作成されたアルファの詳細を破棄する可能性があります。目的のピクセル処理シーケンスに従ってチェーンを構築し、項目を順序なしの書式フラグとして扱わないでください。

## **編集可能値と実効値の検査**

編集可能な操作は `ISlidesPicture.getImageTransform` に格納されているオブジェクトです。エフェクトに応じて、直接書き込み可能なメンバーを公開することがあります。たとえば、[IBlur](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iblur/) は書き込み可能な `radius` と `grow` を公開し、[IAlphaModulateFixed](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ialphamodulatefixed/) は書き込み可能な `amount` を、[IAlphaBiLevel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ialphabilevel/) は書き込み可能な `threshold` を公開します。[IDuotone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iduotone/) のようなカラー効果は変更可能な [IColorFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorformat/) オブジェクトを公開します。

[IBrightnessContrast](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ialphareplace/) などの一部インターフェイスは、作成時のスカラーを書き込み可能プロパティとして公開しません。設定を変更するには、該当操作を削除し、必要な位置に新しい操作を追加してください。

`getEffective()` が返す実効データは計算済みで読み取り専用です。テーマ依存のカラー解決や、レンダラが使用する正規化値の取得に便利ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する場合に実効値を検査します。

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

グレースケール、アルファ天井、アルファ逆転などのパラメータなしエフェクトでも実効データオブジェクトは存在しますが、出力するスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換の削除またはクリア**

[IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) を使用してインデックスで 1 つの操作を削除します。削除後はインデックスがシフトするため、まず対象を検索し、列挙後に削除してください。全チェーンを削除するには [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) を使用します。

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

変換を削除またはクリアしても画像の書式設定だけが変わります。[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) リソース自体は削除、再圧縮、または変更されません。

## **プレゼンテーション形式とエクスポート先の考慮**

画像変換は DrawingML に起源があるため、エフェクトチェーンの編集可能形式としては PPTX が推奨されます。PPTX でも、すべての操作が同等の移植性を持つわけではありません。

- DrawingML の標準操作（輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX のラウンドトリップで最も残存しやすいです。保存後にファイルを再度開き、コレクションを検証してください。
- [BrightnessContrast](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/brightnesscontrast/) は Office 2010 の拡張で、標準の DrawingML 輝度操作ではありません。インメモリ描画には使用できますが、保存後に再度開いた際に編集可能な [IBrightnessContrast](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibrightnesscontrast/) が残る保証はありません。永続的な明るさ・コントラスト調整には [addLuminanceEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) を使用してください。
- バイナリ PPT 形式は完全な DrawingML エフェクトモデルよりも前に登場しました。PPT に保存すると、未対応の操作が省略されたり、チェーンがサポートされるサブセットに縮小されたり、外観が近似されることがあります。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンを描画結果に適用しますが、これらの出力には編集可能な `IImageTransformOperationCollection` が含まれません。ラスタ形式は結果をピクセルにフラット化し、文書/ベクタ形式は独自の描画表現を保存します。
- エフェクトはリンク画像を自己完結型にしません。リンク画像をレンダリングする場合、プレゼンテーションが読み込まれるときにリンク先リソースが利用可能である必要があります。

複数のアルファやカラー量子化操作を組み合わせた場合、異なるプレゼンテーション ビューアがエッジケースを異なる結果で描画することがあります。重要な出力では、実際に本番で使用している Aspose.Slides のバージョンで、編集可能なラウンドトリップと最終エクスポート形式の両方をテストしてください。

## **FAQ**

**画像変換エフェクトは埋め込み画像データを変更しますか？**

いいえ。操作は画像塗りつぶしで使用される `ISlidesPicture` に属し、基になる `IPPImage` バイト列は変更されません。

**同じ画像を再利用する 2 つの画像フレームはエフェクトを共有しますか？**

いいえ。`IPPImage` を再利用すると画像データの重複が防げますが、各画像フレームは通常、個別の `ISlidesPicture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファのエフェクトは組み合わせられますか？**

はい。コレクションは 1 つの順序付けられたチェーンとして受け入れます。置換やしきい値操作は以前のカラーやアルファの詳細を失う可能性があるため、各操作が前の結果に与える影響を考慮してください。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算結果を表し、解決されたカラーを含みます。書き込み可能なメンバーがある操作は、変換コレクションに格納されたオブジェクトを直接編集してください。そうでない場合は、操作を削除し、新しい作成パラメータで置き換える必要があります。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、ファイルを再度開いて検証してください。レガシー PPT は完全な DrawingML エフェクトモデルを表現できず、レンダリング用のエクスポート形式は外観を保持しますが、編集可能な変換操作は含まれません。
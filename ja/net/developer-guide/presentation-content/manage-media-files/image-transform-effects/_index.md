---
title: .NET を使用したプレゼンテーションで画像変換エフェクトを管理する
linktitle: 画像変換エフェクト
type: docs
weight: 11
url: /ja/net/image-transform-effects/
keywords:
- 画像変換
- 画像エフェクト
- 明るさ
- コントラスト
- グレースケール
- デュートーン
- ティント
- HSL
- カラー置換
- ぼかし
- 透明度
- アルファエフェクト
- エフェクトチェーン
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して画像フレームの画像変換エフェクトを適用、チェーン化、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像変換操作の順序付けされたコレクションとして画像の調整を表します。画像フレームの場合、フレームの [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) を開始し、[ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/) にアクセスします。返される [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) を使用すると、元の画像バイトを書き換えることなく、エフェクトを追加、列挙、検査、削除、クリアできます。

この記事では、輝度とコントラスト、カラー変換、ぼかし、透明度、順序付けされたエフェクトチェーン、実効値、削除、および PPTX の往復検証の完全なワークフローを示します。

## **エフェクトの所有権と画像の再利用**

画像リソースとそれを表示する画像は別々のオブジェクトです。

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) はプレゼンテーションが所有するソース画像データを保存または参照します。
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) は画像フィルの一部であり、画像リソースを参照しながら画像変換コレクションを保持します。
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) は該当する画像フィル、ジオメトリ、クロップ設定、その他フレームレベルの書式設定を所有するスライド形状です。

したがって、画像変換操作は [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) のバイトを変更しません。同じ `IPPImage` が [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) に複数回渡されると、各新しい画像フレームは独自の `ISlidesPicture` と独自の変換コレクションを受け取ります。1 つのフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてのフレームが同じ埋め込み画像リソースを再利用しているからです。

同じ `ISlidesPicture.ImageTransform` モデルは、図形やスライド背景などの他の画像フィルでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位の使用**

デモで使用するメソッドは以下の意味的な範囲と単位を持ちます。特定のライブラリ バージョンがすべての範囲外の値を即座に拒否しなくても、これらの範囲内に値を保ってください。ターゲットのプレゼンテーション形式は保存時や PowerPoint がファイルを開く際に正規化、除外、または無効データを拒否する可能性があります。

| 操作 | パラメータ | 有効範囲と単位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` から `100`、パーセント; `0` はコンポーネントを変更しません。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | なし | 数値パラメータはありません。アルファは変更されません。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 暗部と明部のピクセル用の 2 つの色。`System.Drawing.Color` の RGB とアルファチャネルは `0` から `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相は `0` (含む) から `360` (除く) 度; 量は `-100` から `100`、パーセント。 |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相は `0` (含む) から `360` (除く) 度; 彩度と輝度は `-100` から `100`、パーセント。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 置換色は `0` から `255` のチャネル値を使用します。既存のアルファ値は変更されません。 |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半径は非負でポイント単位; `grow` はブール値で、ぼかしの内容が元の境界の外側に拡張できるかを制御します。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負パーセント。通常の不透明度スケーリングには `0` から `100` を使用します: `0` は完全に透明、`100` は既存のアルファを保持。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` から `100`、パーセント不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` から `100`、パーセントアルファ閾値。閾値未満は透明、閾値以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストの適用**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) は [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) 操作を返します。スカラー設定は操作作成時に供給されます。[IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) は計算された読み取り専用値を返し、検査またはログに記録できます。

次の例は明るさを 15%、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) は Office 2010 の画像エフェクト拡張で、標準の DrawingML 輝度エフェクトほど移植性が高くありません。PPTX の往復後も明るさとコントラストを編集可能に保ちたい場合は、[IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) を使用し、ファイルを再度開いた後に結果を検証してください。形式の制限セクションでこの違いについて詳しく説明しています。

## **カラー変換の適用**

カラーエフェクトは、同一画像リソースを再利用する異なる画像フレームに対して独立して適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュートーン、ティント、HSL 調整、カラー置換を適用します。

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) には 2 つの独立して編集可能なカラー パラメータがあります: `Color1` が暗部ピクセルに、`Color2` が明部ピクセルにマップされます。これは単一スカラー値よりも設定が複雑なエフェクトの有用な例です。

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) はすべてのピクセルの色を固定色に置き換え、アルファは保持します。これは [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) と異なり、ソースカラーを別のカラーにマッピングし、ソースとターゲットの両方のカラー形式を公開します。

### **輝度閾値の適用**

輝度閾値は、スキャンしたページ上の淡いマークリが背景と区別しやすくなるようにします。[AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) は中間のグレーレベルを保持します。[AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) は輝度を黒または白にマップし、[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) は不透明度に閾値を適用します。

輝度閾値は 0% から 100%（両端含む）です。閾値未満のピクセルは黒に、閾値以上は白になります。閾値を上げると、より多くのシェードが黒になるため、カットオフ以下になるピクセルが増えます。

[grayscale-swatches.png](grayscale-swatches.png) を作業ディレクトリにダウンロードしてください。各ラベルは 0 から 255 のスケールで元のグレーレベルを示します。例では元画像を 2 つのコピーと並べ、各コピーの閾値をプレゼンテーションに保存します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

出力プレゼンテーションを PowerPoint で開き、3 つのフレームを比較してください。ラベル 96 のスウォッチは約 38% の輝度（96/255）です。20% の閾値で白に、60% の閾値で黒になります。

![元のグレースケールスウォッチと輝度閾値 20% および 60% での白黒結果](luminance-threshold.png)

## **ぼかし、透明度、アルファ効果の追加**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) はすべてのカラー チャネル（アルファを含む）に影響します。ぼかしエッジが元画像の境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明度には [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) を使用します。これは既存のすべてのアルファ値に乗算するため、部分的に透明なピクセルは比例的に異なるまま残ります。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) はすべてのピクセルに単一のアルファ値を割り当てます。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) は閾値に基づいてアルファを 2 段階に変換します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

パラメータ無しの他のアルファ操作には、[AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)（非ゼロのアルファをすべて完全不透明に）、[AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)（100% 未満のアルファをすべて完全透明に）、[AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)（`100% - alpha` に変更）などがあります。

## **順序付けされたエフェクトチェーンの構築**

すべての `Add...Effect` メソッドは新しい操作をコレクションの末尾に追加します。レンダラーはコレクションを順序付けられたパイプラインとして使用します: 操作 0 の出力が操作 1 の入力となり、以下同様です。したがって、同じ操作でも順序が異なると異なる画像が生成されます。

たとえば、グレースケールの後にティントを適用すると、まず色情報が除去され、次に輝度結果が再着色します。ティントの後にグレースケールを適用すると、ティントが再び除去されます。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きでき、アルファ変調は相対的な差異を保持します。

次の例は 4 つの操作からなるチェーンを構築し、PPTX として保存し、プレゼンテーションを再度開いて操作タイプと順序の両方をチェックし、再開された結果をレンダリングします。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

コレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせて使用できますが、組み合わせが常に有用とは限りません。固定のカラー置換は以前のカラーエフェクトが生成した RGB 変化を除去します。デュートーンの後にグレースケールを適用すると 2 つの選択色が消えます。アルファの天井、床、置換、または二段階操作は、以前に作成されたアルファの詳細を破棄する可能性があります。目的のピクセル処理シーケンスに従ってチェーンを構築し、項目を順不同の書式フラグとして扱わないでください。

<!-- visual-explanation:image-transform-effects:start -->
[![同じ画像がグレースケール→ティント、そしてティント→グレースケールの順に通過します。最終的な2つのグレースケール画像は異なるトーンになります。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*この Aspose.Slides for .NET 26.11 のイラスト的レンダリングでは、220° のティント（25%）はグレースケール画像を変更しません。同じティントをグレースケールの前に適用すると異なるトーンになります。*
<!-- visual-explanation:image-transform-effects:end -->

## **編集可能な値と実効値の検査**

編集可能な操作は `ISlidesPicture.ImageTransform` に格納されているオブジェクトです。エフェクトによっては、書き込み可能なメンバーを直接公開します。たとえば、[IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) は書き込み可能な `Radius` と `Grow` を、[IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) は書き込み可能な `Amount` を、[IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) は書き込み可能な `Threshold` を公開します。[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) のようなカラーエフェクトは可変の [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) オブジェクトを公開します。

[IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/) などの一部の操作インターフェイスは、作成時のスカラーを書き込み可能なプロパティとして公開しません。これらの設定を変更するには、操作を削除し、必要な位置に置き換える必要があります。

`GetEffective()` が返す実効データは計算された読み取り専用オブジェクトです。テーマ依存のカラー解決や、レンダラが使用する正規化値の取得に便利ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する場合は実効値を検査します。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

グレースケール、アルファ天井、アルファ逆転などのパラメータ無しエフェクトでも実効データオブジェクトは存在しますが、出力するスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換の削除またはクリア**

[IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) を使用してインデックスで 1 つの操作を削除します。削除後はインデックスがシフトするため、まず対象を検索し、列挙後に削除してください。`Clear()` を使用するとチェーン全体を削除できます。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

変換の削除またはクリアは画像の書式設定のみを変更します。再利用されている [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) リソースを削除、再圧縮、または他の方法で変更することはありません。

## **プレゼンテーション形式とエクスポート ターゲットの考慮**

画像変換は DrawingML に由来するため、エフェクトチェーンの編集可能形式としては PPTX が推奨されます。PPTX でもすべての操作が同等の移植性を持つわけではありません。

- 標準の DrawingML 操作（輝度、グレースケール、デュートーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX の往復で残存する可能性が最も高いです。保存後に必ず生成ファイルを再度開き、コレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) は Office 2010 の拡張で、標準の DrawingML 輝度操作ではありません。メモリ内レンダリングには使用できますが、保存後に再び PPTX を開いたときに編集可能な [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) が残る保証はありません。永続的な明るさとコントラスト調整には [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) を優先してください。
- バイナリ PPT 形式は完全な DrawingML エフェクトモデルよりも前に登場しました。PPT に保存すると、未対応の操作が省かれたり、チェーンがサポートされたサブセットに縮小されたり、外観が近似されることがあります。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンをレンダリング外観に適用します。これらの出力は編集可能な `IImageTransformOperationCollection` を含まず、ラスタ形式は結果をピクセルにフラット化し、文書/ベクタエクスポートは独自のレンダリング表現を格納します。
- エフェクトはリンク画像を自己完結型にしません。リンクされた画像をレンダリングする場合、プレゼンテーションの読み込み時にリンクリソースが利用可能である必要があります。

さまざまなプレゼンテーションビューアは、特に複数のアルファまたはカラー量子化操作が組み合わされた場合にエッジケースを異なる方法でレンダリングすることがあります。重要な出力の場合、実編集往復と最終エクスポート形式の両方を、実稼働環境で使用している同じ Aspose.Slides バージョンでテストしてください。

## **FAQ**

**画像変換エフェクトは埋め込み画像データを変更しますか？**

いいえ。操作は画像フィルで使用される `ISlidesPicture` に属し、基礎となる `IPPImage` バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームはエフェクトを共有しますか？**

いいえ。`IPPImage` を再利用して画像データの重複を防げますが、各画像フレームは通常、個別の `ISlidesPicture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファエフェクトは組み合わせられますか？**

はい。コレクションは1つの順序付けされたチェーンでそれらを受け入れます。各操作が前の出力に何を行うかを考慮してください。置換や閾値操作は以前のカラーやアルファの詳細を破棄する可能性があります。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算済み値を表し、解決されたカラーを含みます。書き込み可能なメンバーが存在する操作はそのまま編集してください。存在しない場合は操作を削除し、新しい作成パラメータで置き換えてください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、ファイルを再度開いて検証してください。レガシー PPT は完全な DrawingML エフェクトモデルを表現できず、レンダリング出力形式は外観のみを保持し、編集可能な変換操作は保持しません。
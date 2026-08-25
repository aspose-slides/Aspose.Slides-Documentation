---
title: .NET を使用したプレゼンテーションでの画像変換エフェクトの管理
linktitle: 画像変換エフェクト
type: docs
weight: 11
url: /ja/net/image-transform-effects/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、画像フレームの画像変換エフェクトを適用、チェーン化、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像調整を画像変換操作の順序付けされたコレクションとして表します。画像フレームの場合、まずフレームの [ISlidesPicture](https://reference.aspose.com/slides/ja/net/aspose.slides/islidespicture/) を取得し、[ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/ja/net/aspose.slides/islidespicture/imagetransform/) にアクセスします。返される [IImageTransformOperationCollection](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/) を使用すると、元の画像バイト列を書き換えることなく、エフェクトの追加、列挙、検査、削除、クリアが可能です。

本記事では、明るさとコントラスト、カラー変換、ぼかし、透明性、順序付けされたエフェクトチェーン、実効値、削除、そして PPTX ラウンドトリップ検証の完全なワークフローを示します。

## **エフェクト所有権と画像再利用の理解**

画像リソースとそれを表示する画像は別々のオブジェクトです。

- [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) はプレゼンテーションが所有するソース画像データを格納または参照します。
- [ISlidesPicture](https://reference.aspose.com/slides/ja/net/aspose.slides/islidespicture/) は画像フィルの一部であり、画像リソースを参照しながら画像変換コレクションを保持します。
- [IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/) はスライド上のシェイプで、該当する画像フィル、ジオメトリ、トリミング設定、その他フレームレベルの書式設定を所有します。

したがって、画像変換操作は [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) のバイト列を変更しません。同じ `IPPImage` を [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addpictureframe/) に複数回渡すと、各新しい画像フレームは独自の `ISlidesPicture` と独自の変換コレクションを取得します。あるフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてが同じ埋め込み画像リソースを再利用しているからです。

同じ `ISlidesPicture.ImageTransform` モデルは、シェイプやスライド背景などの他の画像フィルでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメーター範囲と単位の使用**

デモで使用するメソッドは以下の意味的範囲と単位を持ちます。特定のライブラリバージョンがすぐに範囲外の値を拒否しなくても、対象のプレゼンテーション形式は保存時または PowerPoint がファイルを開く際に正規化、除外、またはエラーを出す場合があります。

| 操作 | パラメーター | 有効範囲と単位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` から `100`（パーセント）、`0` はコンポーネントを変更しません。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | なし | 数値パラメーターはありません。アルファは変更されません。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 暗部と明部のピクセル用に 2 つの色を指定。`System.Drawing.Color` の RGB とアルファは `0` から `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相は `0`（含む）から `360`（除く）度、`amount` は `-100` から `100`（パーセント）。 |
| [AddHSLEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相は `0`（含む）から `360`（除く）度、彩度と輝度は `-100` から `100`（パーセント）。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 置換色はチャンネル値が `0` から `255`。既存のアルファは変更しません。 |
| [AddBlurEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半径は非負でポイント単位、`grow` はブラー領域が元の境界外に拡張できるかを制御するブール値。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負パーセント。普通の不透明度スケーリングは `0` から `100`：`0` は完全に透明、`100` は既存のアルファを保持。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` から `100`（パーセント）不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` から `100`（パーセント）アルファしきい値。しきい値未満は透明、以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば 35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストの適用**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) は [IBrightnessContrast](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/ibrightnesscontrast/) 操作を返します。スカラー設定は操作作成時に渡します。[IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/brightnesscontrast/geteffective/) は計算された読み取り専用値を返し、検査やログ出力に利用できます。

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

[BrightnessContrast](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/brightnesscontrast/) は Office 2010 の画像エフェクト拡張であり、標準の DrawingML 輝度エフェクトほど移植性が高くありません。明るさとコントラストを PPTX ラウンドトリップ後も編集可能にしたい場合は、[IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) を使用し、ファイルを再度開いたときに結果を検証してください。形式の制限セクションでこの違いを詳しく説明しています。

## **カラー変換の適用**

カラーエフェクトは、同じ画像リソースを再利用する複数の画像フレームに対して個別に適用できます。次の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[IDuotone](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iduotone/) には 2 つの独立して編集可能なカラー パラメーターがあります：`Color1` が暗部ピクセル、`Color2` が明部ピクセルに割り当てられます。単一スカラー値よりも設定が複雑なエフェクトの例として有用です。

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) はすべてのピクセルの色を固定色に置き換え、アルファは保持します。これは、ソースカラーを別のカラーにマップし、両方のカラー形式を公開する [AddColorChangeEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) とは異なります。

## **ぼかし、透明性、アルファ効果の追加**

[AddBlurEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) はアルファを含むすべてのカラー チャネルに影響します。ぼかしエッジが元画像の境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明性には [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) を使用します。既存のアルファ値すべてに乗算するため、部分的に透明なピクセルは比例的に異なるままです。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) はすべてのピクセルに同一アルファ値を割り当てます。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) はしきい値に基づいてアルファを 2 段階に変換します。

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

パラメーターなしの他のアルファ操作として、[AddAlphaCeilingEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)（すべての非ゼロアルファを完全不透明に）、[AddAlphaFloorEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)（100% 未満のアルファを完全透明に）、[AddAlphaInverseEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)（`100% - alpha` に変換）があります。

## **順序付けされたエフェクトチェーンの構築**

すべての `Add...Effect` メソッドは新しい操作をコレクションの末尾に追加します。レンダラはこのコレクションを順序付けられたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。そのため、同じ操作でも順序が異なると異なる画像が生成されます。

例として、グレースケール → ティント の順序は色相情報を除去した後に輝度結果を再着色します。ティント → グレースケール の順序はティント効果を再び除去します。同様に、アルファ置換は以前の操作で計算されたアルファを上書きできますが、アルファ変調は相対的な差を保持します。

次の例は 4 操作からなるチェーンを構築し、PPTX として保存し、プレゼンテーションを再度開いて操作タイプと順序を確認し、再オープンされた結果をレンダリングします。

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

このコレクションはカラー、アルファ、ぼかし操作を別々のチェーンに限定する互換性マトリックスを課しません。組み合わせて使用できますが、常に有用とは限りません。固定カラー置換は以前のカラー効果で生じた RGB のばらつきを除去しますし、デュオトーンの後にグレースケールを適用すると 2 つの選択色が失われます。アルファの天井、床、置換、二段階操作は、以前に作成されたアルファの細部を破棄することがあります。目的のピクセル処理シーケンスに基づいてチェーンを構築し、項目を順序なしの書式フラグとして扱わないでください。

## **編集可能値と実効値の検査**

編集可能な操作は `ISlidesPicture.ImageTransform` に格納されたオブジェクトです。エフェクトによっては書き込み可能なメンバーを直接公開します。例として、[IBlur](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iblur/) は書き込み可能な `Radius` と `Grow`、[IAlphaModulateFixed](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/ialphamodulatefixed/) は書き込み可能な `Amount`、[IAlphaBiLevel](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/ialphabilevel/) は書き込み可能な `Threshold` を公開します。[IDuotone](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iduotone/) のようなカラーエフェクトは変更可能な [IColorFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/icolorformat/) オブジェクトを公開します。

[IBrightnessContrast](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/ialphareplace/) などのインターフェイスは作成時スカラーを書き込み可能プロパティとして公開しません。設定を変更するには、対象の操作を削除し、必要な位置に新しい操作を追加してください。

`GetEffective()` が返す実効データは計算済みで読み取り専用です。テーマ依存のカラー解決やレンダラが使用する正規化値の取得に便利ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する場合は実効値を検査します。

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

パラメーターなしのエフェクト（グレースケール、アルファ天井、アルファ反転など）も実効データオブジェクトを持ちますが、出力すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換の削除またはクリア**

[IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) を使用してインデックスで 1 つの操作を削除します。削除後はインデックスがシフトするため、まず対象を検索し、列挙後に削除してください。`Clear()` でチェーン全体を削除できます。

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

変換を削除またはクリアしても画像の書式設定のみが変わります。[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) リソース自体は削除、再圧縮、またはその他の変更を受けません。

## **プレゼンテーション形式とエクスポート先の考慮**

画像変換は DrawingML に由来するため、エフェクトチェーンの編集可能形式としては PPTX が推奨されます。PPTX でもすべての操作が同等の移植性を持つわけではありません。

- 標準 DrawingML 操作（輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX ラウンドトリップで残存する可能性が最も高いです。保存後にファイルを再度開き、コレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/brightnesscontrast/) は Office 2010 の拡張であり、標準 DrawingML 輝度操作ではありません。インメモリ描画には使用できますが、保存・再オープン後に編集可能な [IBrightnessContrast](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/ibrightnesscontrast/) が残る保証はありません。永続的な明るさ・コントラスト調整には [AddLuminanceEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) を推奨します。
- バイナリ PPT 形式は完全な DrawingML エフェクトモデルが登場する前のものです。PPT に保存すると未対応操作が省略されたり、チェーンがサポートされるサブセットに縮小されたり、外観が近似されることがあります。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンをレンダリング結果に適用します。これらの出力は編集可能な `IImageTransformOperationCollection` を含まず、ラスタ形式は結果をピクセルにフラット化し、文書/ベクタエクスポートは独自の描画表現を保持します。
- エフェクトはリンク画像を自己完結型にしません。リンク画像をレンダリングする場合、プレゼンテーション読み込み時にリンクリソースが利用可能である必要があります。

複数のアルファやカラー量子化操作を組み合わせると、使用するビューアによってエッジケースの描画結果が異なることがあります。重要な出力については、実際の運用環境で使用している Aspose.Slides バージョンで、編集可能なラウンドトリップと最終エクスポート形式の両方をテストしてください。

## **FAQ**

**画像変換エフェクトは埋め込み画像データを変更しますか？**

いいえ。操作は画像フィルが使用する `ISlidesPicture` に属し、基礎となる `IPPImage` バイト列は変更されません。

**同じ画像を再利用する 2 つの画像フレームはエフェクトを共有しますか？**

いいえ。`IPPImage` を再利用して画像データの重複を防げますが、各画像フレームは通常、個別の `ISlidesPicture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファのエフェクトは組み合わせられますか？**

はい。コレクションは 1 つの順序付けられたチェーンで受け入れます。置換やしきい値操作は以前のカラーやアルファの詳細を破棄する可能性があるため、各操作が前の出力に与える影響を考慮してください。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算済み値であり、解決されたカラーを含みます。書き込み可能メンバーがある操作はそのオブジェクトを直接編集し、そうでない場合は操作を削除して新しい作成パラメーターで置き換えてください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、保存後に再度開いてファイルを検証してください。レガシー PPT は完全な DrawingML エフェクトモデルを表現できず、レンダリング出力形式は外観のみを保持し、編集可能な変換操作は保存されません。
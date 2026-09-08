---
title: Python でプレゼンテーションの画像変換効果を管理する
linktitle: 画像変換効果
type: docs
weight: 11
url: /ja/python-java/image-transform-effects/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、画像フレームの画像変換効果を適用、チェーン化、検査、削除、検証します。"
---
## **概要**

Aspose.Slidesは画像の調整を画像変換操作の順序付きコレクションとして表現します。画像フレームの場合、フレームの[Picture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/)から開始し、[Picture.getImageTransform](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#getImageTransform)にアクセスします。返される[ImageTransformOperationCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/)を使用すると、元の画像バイト列を書き換えることなく、効果を追加、列挙、検査、削除、クリアできます。

この記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付き効果チェーン、実効値、削除、そしてPPTXの往復検証の完全なワークフローを示します。

## **効果の所有権と画像の再利用を理解する**

画像リソースとそれを表示する画像は別々のオブジェクトです。

- [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) はプレゼンテーションが所有する元画像データを格納または参照します。
- [Picture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/) は画像塗りつぶしに属し、画像リソースを参照しながら画像変換コレクションを保持します。
- [PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) はスライド形状で、関連する画像塗りつぶし、ジオメトリ、トリミング設定、その他のフレームレベルの書式設定を所有します。

したがって、画像変換操作は[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/)のバイトを変更しません。同じ`PPImage`を[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addPictureFrame)に複数回渡すと、各新しい画像フレームは独自の`Picture`と独自の変換コレクションを受け取ります。一方のフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてのフレームが同じ埋め込み画像リソースを再利用しているからです。

同じ`Picture.getImageTransform`モデルは、シェイプやスライド背景など他の画像塗りつぶしでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位を使用する**

示されたメソッドは以下の意味的な範囲と単位を使用します。特定のライブラリバージョンが直ちにすべての範囲外値を拒否しなくても、対象のプレゼンテーション形式は保存時またはPowerPointがファイルを開く際に正規化、除外、または拒否する可能性があります。

| 操作 | パラメータ | 有効範囲と単位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` から `100` までのパーセンテージ; `0` はコンポーネントを変更しません。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | なし | パラメータなし; 数値パラメータはありません。アルファは変更されません。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | 暗いピクセルと明るいピクセル用の2つの色。`java.awt.Color` の RGB とアルファチャンネルは `0` から `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | 色相は `0`（含む）から `360`（除く）度; 量は `-100` から `100` のパーセンテージ。 |
| [addHSLEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | 色相は `0`（含む）から `360`（除く）度; 彩度と輝度は `-100` から `100` のパーセンテージ。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | 置換色は `0` から `255` のチャンネル値を使用します。既存のアルファ値は変更されません。 |
| [addBlurEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | 半径は非負でポイント単位; `grow` はブール値で、ぼかし領域が元の境界を超えて拡張できるかを制御します。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | 非負のパーセンテージ。`0` から `100` を使用して不透明度をスケーリングします: `0` は完全に透明、`100` は既存のアルファを保持します。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` から `100` のパーセンテージ不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` から `100` のパーセンテージアルファしきい値。しきい値未満は透明、以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係です。例えば、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストを適用する**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) は[BrightnessContrast](https://reference.aspose.com/slides/ja/python-java/aspose.slides/brightnesscontrast/) 操作を返します。スカラー設定は操作作成時に供給されます。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/brightnesscontrast/#getEffective) は計算された読み取り専用値を返し、検査やログ出力に使用できます。

次の例は明るさを15%、コントラストを20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/ja/python-java/aspose.slides/brightnesscontrast/) は Office 2010 の画像効果拡張であり、標準の DrawingML 輝度効果ほどポータブルではありません。PPTX 往復後も明るさとコントラストを編集可能に保ちたい場合は、[ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) を使用し、ファイル再オープン後に結果を検証してください。形式の制限セクションでこの違いを詳しく説明します。

## **カラー変換を適用する**

カラー効果は、同一画像リソースを再利用する複数の画像フレームに個別に適用できます。次の例は5つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[Duotone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/duotone/) には2つの独立した編集可能カラー パラメータがあります: `color1` が暗いピクセル、`color2` が明るいピクセルにマッピングされます。単一スカラー値よりも設定が複雑な効果の例として有用です。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) はすべてのピクセルの色を固定色に置換し、アルファは保持します。これは、ソースカラーを別のカラーにマッピングし、両方のカラー形式を公開する [addColorChangeEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) とは異なります。

## **ぼかし、透明度、アルファ効果を追加する**

[addBlurEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) はすべてのカラー チャンネル、アルファを含めて影響します。ぼかしエッジが元の画像境界を超える可能性がある場合は、`grow` を `True` に設定してください。

均一な透明度には [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) を使用します。これは既存のすべてのアルファ値に乗算するため、部分的に透明なピクセルは比例的に異なるまま残ります。[addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) はすべてのピクセルに単一のアルファ値を割り当てます。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) はしきい値に基づいてアルファを2段階に変換します。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

他のパラメータなしのアルファ操作には、すべての非ゼロアルファを完全に不透明にする [addAlphaCeilingEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect)、すべてのアルファを 100% 未満で完全に透明にする [addAlphaFloorEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect)、および `100% - alpha` に変換する [addAlphaInverseEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) があります。

## **順序付き効果チェーンを構築する**

すべての `add...Effect` メソッドは新しい操作をコレクションの末尾に追加します。レンダラはコレクションを順序付きパイプラインとして使用します: 操作0の出力が操作1の入力となり、以降同様です。そのため、同じ操作でも順序が異なると異なる画像が生成されます。

たとえば、グレースケールの後にティントを適用すると最初に色情報が除去され、次に輝度結果が再着色されます。ティントの後にグレースケールを適用するとティントが再び除去されます。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きでき、アルファ変調は相対的な差を保持します。

次の例は4つの操作からなるチェーンを構築し、PPTX として保存し、プレゼンテーションを再オープンして操作タイプと順序を確認し、再オープンした結果をレンダリングします。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

コレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせて使用できますが、常に有用とは限りません。固定カラー置換は以前のカラー効果で生成されたRGB変動を除去します。デュオトーンの後にグレースケールを適用すると2色が消えます。アルファの天井、床、置換、二レベル操作は以前に作成されたアルファ詳細を失う可能性があります。ピクセル処理の希望シーケンスに従ってチェーンを構築し、項目を順序のない書式フラグとして扱わないでください。

## **編集可能および実効値を検査する**

編集可能な操作は`Picture.getImageTransform`に格納されたオブジェクトです。効果に応じて、書き込み可能なメンバーが直接公開されることがあります。たとえば、[Blur](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blur/) は書き込み可能な `radius` と `grow` を公開し、[AlphaModulateFixed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/alphamodulatefixed/) は書き込み可能な `amount`、[AlphaBiLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/alphabilevel/) は書き込み可能な `threshold` を公開します。[Duotone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/duotone/) のようなカラー効果は可変の[ColorFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/colorformat/) オブジェクトを公開します。

[BrightnessContrast](https://reference.aspose.com/slides/ja/python-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/ja/python-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tint/)、[AlphaReplace](https://reference.aspose.com/slides/ja/python-java/aspose.slides/alphareplace/) などの一部の操作クラスは、作成時のスカラーを書き込み可能プロパティとして公開しません。設定を変更するには、操作を削除し、必要な位置に置換操作を追加してください。

`getEffective` が返す実効データは計算済みで読み取り専用です。テーマ依存カラーの解決やレンダラが使用する正規化値の取得に有用ですが、別の編集対象ではありません。次の例はチェーンを列挙し、対応する API が提供する実効値を検査します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

グレースケール、アルファ天井、アルファ逆転などパラメータなしの効果でも実効データオブジェクトは存在しますが、出力すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換を削除またはクリアする**

[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) を使用してインデックスで1つの操作を削除します。インデックスは削除後にシフトするため、まず対象を検索し、列挙後に削除してください。[ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#clear) を使用するとチェーン全体を削除できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

変換を削除またはクリアしても、画像の書式設定のみが変わります。[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) リソースの削除、再圧縮、または別の変更は行われません。

## **プレゼンテーション形式とエクスポート対象を検討する**

画像変換は DrawingML に起因するため、PPTX が効果チェーンの編集可能形式として推奨されます。PPTX でもすべての操作が同等にポータブルというわけではありません。

- 標準の DrawingML 操作（輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX 往復で最も残存可能性が高いです。保存後は必ずファイルを再オープンし、コレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/ja/python-java/aspose.slides/brightnesscontrast/) は Office 2010 の拡張であり、標準 DrawingML 輝度操作ではありません。インメモリ描画には使用できますが、保存・再オープン後に編集可能な [BrightnessContrast] として残る保証はありません。永続的な明るさ・コントラスト調整には [addLuminanceEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) を優先してください。
- バイナリ PPT 形式は完全な DrawingML 効果モデルが存在する前に作られました。PPT に保存するとサポートされていない操作が省略されたり、チェーンがサポート済みサブセットに縮小されたり、外観が近似されたりします。複雑な編集チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンを描画結果に適用します。これらの出力は編集可能な `ImageTransformOperationCollection` を含まず、ラスタ形式は結果をピクセルに平坦化し、文書/ベクタエクスポートは独自の描画表現を格納します。
- 効果はリンク画像を自己完結型にしません。リンク画像を描画するには、プレゼンテーション読み込み時にリンクリソースが利用可能である必要があります。

複数のアルファまたはカラー量子化操作を組み合わせた場合、異なるプレゼンテーションビューアがエッジケースを異なる結果でレンダリングすることがあります。重要な出力では、実編集往復と最終エクスポート形式の両方を、実稼働環境と同じ Aspose.Slides バージョンでテストしてください。

## **FAQ**

**画像変換効果は埋め込み画像データを変更しますか？**

いいえ。操作は画像塗りつぶしで使用される `Picture` に属し、基になる `PPImage` バイトは変更されません。

**同じ画像を再利用する2つの画像フレームは効果を共有しますか？**

いいえ。`PPImage` の再利用は画像データの重複を防ぎますが、各画像フレームは通常、個別の `Picture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファ効果は組み合わせられますか？**

はい。コレクションは1つの順序付きチェーンとして受け入れます。置換やしきい値操作は以前のカラーやアルファの詳細を失う可能性があるため、各操作が前段の出力に与える影響を考慮してください。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算済み値で、解決されたカラーを含みます。書き込み可能メンバーがある操作はその場所で編集してください。そうでない場合は操作を削除し、新しい作成パラメータで置換してください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、再オープンしてファイルを検証してください。レガシー PPT は完全な DrawingML 効果モデルを表現できず、レンダリング出力形式は外観を保持しますが、編集可能な変換操作は保持しません。
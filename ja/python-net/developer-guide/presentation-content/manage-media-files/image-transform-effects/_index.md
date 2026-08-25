---
title: Python を使用したプレゼンテーションの画像変換効果の管理
linktitle: 画像変換効果
type: docs
weight: 11
url: /ja/python-net/image-transform-effects/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、画像フレームの画像変換効果を適用、チェーン化、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像変換操作の順序付けられたコレクションとして画像調整を表します。画像フレームの場合、フレームの [Picture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picture/) から開始し、その [image_transform](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picture/image_transform/) プロパティにアクセスします。返される [ImageTransformOperationCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/effects/imagetransformoperationcollection/) を使用すると、元の画像バイトを書き換えることなく、効果の追加、列挙、検査、削除、クリアが可能です。

本記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付けられた効果チェーン、実効値、削除、そして PPTX の往復検証までの完全なワークフローを示します。

## **効果の所有権と画像の再利用を理解する**

画像リソースとそれを表示する画像は別々のオブジェクトです。

- [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) はプレゼンテーションが所有するソース画像データを格納または参照します。
- [Picture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picture/) は画像塗りつぶしに属し、画像リソースを参照しながら画像変換コレクションを保持します。
- [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) はスライド上のシェイプで、該当する画像塗りつぶし、ジオメトリ、クロップ設定、その他フレームレベルの書式設定を所有します。

したがって、画像変換操作は [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) のバイトを変更しません。同じ `PPImage` を [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_picture_frame/) に複数回渡すと、各新しい画像フレームは独自の `Picture` と独自の変換コレクションを受け取ります。あるフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてのフレームが同じ埋め込み画像リソースを再利用しているからです。

同じ `Picture.image_transform` モデルは、シェイプやスライドの背景など、他の画像塗りつぶしでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位を使用する**

示されたメソッドは以下の意味的範囲と単位を使用します。特定のライブラリバージョンがすべての範囲外値を即座に拒否しなくても、これらの範囲内に収めてください。対象のプレゼンテーション形式は、保存時または PowerPoint がファイルを開く際に正規化、除外、または無効データを拒否する可能性があります。

| 操作 | パラメータ | 有効範囲と単位 |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100`〜`100`、パーセント；`0` はその要素を変更しません。 |
| [add_gray_scale_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | なし | 数値パラメータはありません。アルファは変更されません。 |
| [add_duotone_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | 暗部と明部のピクセル用の2色。RGB とアルファは `0`〜`255`。 |
| [add_tint_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | 色相は `0`（含む）から `360`（除く）度；`amount` は `-100`〜`100` パーセント。 |
| [add_hsl_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | 色相は `0`（含む）から `360`（除く）度；彩度と輝度は `-100`〜`100` パーセント。 |
| [add_color_replace_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | 置換色は `0`〜`255` のチャネル値を使用。既存のアルファは変更されません。 |
| [add_blur_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | 半径は非負でポイント単位；`grow` はブーリアンで、ぼかし領域が元の境界を超えるか制御します。 |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | 非負パーセント。普通の不透明度スケーリングには `0`〜`100` を使用：`0` は完全に透明、`100` は既存のアルファを保持。 |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0`〜`100` パーセントの不透明度。 |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0`〜`100` パーセントのアルファ閾値。閾値未満は透明、以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。例として、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストを適用する**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) は [BrightnessContrast](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/brightnesscontrast/) 操作を返します。スカラー設定は操作作成時に提供されます。[BrightnessContrast.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) は計算された読み取り専用値を返し、検査またはログに記録できます。

以下の例は明るさを 15% 、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/brightnesscontrast/) は Office 2010 の画像効果拡張であり、標準の DrawingML 輝度効果ほど移植性が高くありません。明るさとコントラストを PPTX の往復後も編集可能に保ちたい場合は、[ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) を使用し、ファイルを再度開いた後に結果を検証してください。形式の制限セクションでこの違いを詳しく説明しています。

## **カラー変換を適用する**

カラー効果は、同一画像リソースを再利用する複数の画像フレームに対して個別に適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[Duotone](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/duotone/) には `color1`（暗いピクセルにマップ）と `color2`（明るいピクセルにマップ）の 2 つの独立編集可能なカラー パラメータがあります。これは単一スカラー値よりも設定が複雑な効果の有用な例です。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) はすべてのピクセルのカラーを固定色に置き換え、アルファは保持します。これは、ソースカラーを別のカラーにマップし、両方のカラー形式を公開する [add_color_change_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) とは異なります。

## **ぼかし、透明度、アルファ効果を追加する**

[add_blur_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) はアルファを含むすべてのカラー チャネルに影響します。ぼかしエッジが元の画像領域を超える可能性がある場合は、`grow` を `True` に設定してください。

均一な透明度には [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) を使用します。これは既存のすべてのアルファ値に乗算し、部分的に透明なピクセルは比例的に異なるまま残ります。[add_alpha_replace_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) はすべてのピクセルに単一のアルファ値を割り当てます。[add_alpha_bi_level_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) は閾値に基づいてアルファを 2 段階に変換します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

パラメータなしのその他のアルファ操作には、非ゼロのすべてのアルファを完全に不透明にする [add_alpha_ceiling_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)、アルファが 100% 未満のものを完全に透明にする [add_alpha_floor_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)、および `100% - alpha` に変換する [add_alpha_inverse_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/) があります。

## **順序付けられた効果チェーンを構築する**

すべての `add_..._effect` メソッドはコレクションの末尾に新しい操作を追加します。レンダラーはコレクションを順序付けられたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。そのため、同じ操作でも順序が異なると異なる画像が生成されます。

例として、グレースケールの後にティントを適用すると、最初に色情報が除去され、次に輝度結果が再着色されます。ティントの後にグレースケールを適用するとティントが再び除去されます。同様に、アルファ置換は先行操作で計算されたアルファを上書きできますが、アルファ変調は相対的な差異を維持します。

以下の例は 4 つの操作からなるチェーンを構築し、PPTX として保存し、プレゼンテーションを再度開いて操作タイプと順序をチェックし、再オープンした結果をレンダリングします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

このコレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせは可能ですが、常に有用とは限りません。固定カラー置換は先行のカラー効果で生じた RGB のばらつきを除去します。デュオトーンの後にグレースケールを適用すると 2 色が消えます。アルファの天井、床、置換、二値化操作は、以前に作成されたアルファの詳細を破棄することがあります。項目を無秩序な書式フラグとしてではなく、望ましいピクセル処理シーケンスに基づいてチェーンを構築してください。

## **編集可能な値と実効値を検査する**

編集可能な操作は `Picture.image_transform` に格納されたオブジェクトです。効果に応じて、直接書き込み可能なメンバーを公開する場合があります。例として、[Blur](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/blur/) は書き込み可能な `radius` と `grow` プロパティを、[AlphaModulateFixed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/alphamodulatefixed/) は書き込み可能な `amount`、[AlphaBiLevel](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/alphabilevel/) は書き込み可能な `threshold` を公開します。 [Duotone](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/duotone/) のようなカラー効果は可変の [ColorFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/colorformat/) オブジェクトを公開します。

一部の操作、例えば [BrightnessContrast](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/hsl/)、[Tint](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/tint/)、[AlphaReplace](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/alphareplace/) は、作成時のスカラーを書き込み可能プロパティとして公開しません。これらの設定を変更するには、操作を削除し、必要な位置に置き換える必要があります。

`get_effective()` が返す実効データは計算済みで読み取り専用です。テーマ依存のカラー解決や、レンダラーが使用する正規化値の取得に便利ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する場合に実効値を検査します。

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

グレースケール、アルファ天井、アルファ逆転などのパラメータなし効果にも実効データオブジェクトは存在しますが、出力すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報となります。

## **画像変換を削除またはクリアする**

[ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) を使用してインデックスで 1 つの操作を削除します。削除後はインデックスがシフトするため、対象を先に検索し、列挙後に削除してください。`clear()` を使えばチェーン全体を削除できます。

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

変換を削除またはクリアしても、画像の書式設定のみが変更されます。再利用されている [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) リソースは削除、再圧縮、またはその他の変更を受けません。

## **プレゼンテーション形式とエクスポート先を考慮する**

画像変換は DrawingML から派生しているため、効果チェーンの編集可能形式としては PPTX が推奨されます。PPTX でもすべての操作が同等の移植性を持つわけではありません。

- DrawingML 標準の操作（輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX の往復で残る可能性が最も高いです。永続性が必要な場合は、生成したファイルを必ず再オープンし、コレクションを確認してください。
- [BrightnessContrast](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/brightnesscontrast/) は Office 2010 の拡張であり、標準の DrawingML 輝度操作ではありません。メモリ内レンダリングには使用可能ですが、保存後に PPTX を再度開いた際に編集可能な `BrightnessContrast` 操作として残る保証はありません。永続的な明るさ・コントラスト調整には [add_luminance_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) を使用してください。
- バイナリ PPT 形式は完全な DrawingML 効果モデルの登場以前のものです。PPT に保存すると、未サポートの操作が省略されたり、チェーンがサポート対象のサブセットに縮小されたり、外観が近似されることがあります。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンをレンダリング結果に適用します。これらの出力には編集可能な `ImageTransformOperationCollection` が含まれません。ラスタ形式は結果をピクセルに平坦化し、文書やベクタ形式のエクスポートは独自のレンダリング表現を保持します。
- 効果はリンク画像を自己完結型にしません。リンク画像をレンダリングする場合、プレゼンテーション読み込み時にリンクリソースが利用可能である必要があります。

複数のアルファやカラー量子化操作を組み合わせた場合、異なるプレゼンテーションビューアはエッジケースを異なる結果で描画することがあります。重要な出力については、同一の Aspose.Slides バージョンで編集往復と最終エクスポート形式の両方をテストしてください。

## **FAQ**

**画像変換効果は埋め込み画像データを変更しますか？**

いいえ。操作は画像塗りつぶしで使用される `Picture` に属します。基礎となる `PPImage` バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームは効果を共有しますか？**

いいえ。`PPImage` を再利用して画像データの重複を防げますが、各画像フレームは通常別々の `Picture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファ効果は組み合わせられますか？**

はい。コレクションは 1 つの順序付けられたチェーンとして受け入れます。置換や閾値操作が前段のカラーやアルファの詳細を破棄する可能性があるため、各操作が前の出力に与える影響を考慮してください。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算結果を表し、解決されたカラーを含みます。書き込み可能なメンバーがある操作は変換コレクション内のオブジェクトを直接編集してください。書き込み可能なプロパティがない場合は、操作を削除して新しい作成パラメータで置き換えてください。

**変換チェーンを保持するにはどの形式を使用すべきですか？**

PPTX を使用し、ファイルを再度開いて確認してください。レガシー PPT は完全な DrawingML 効果モデルを表現できず、レンダリングされたエクスポート形式は外観を保持しますが編集可能な変換操作は保持しません。
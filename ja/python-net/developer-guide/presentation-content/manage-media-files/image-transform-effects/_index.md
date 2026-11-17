---
title: Pythonでプレゼンテーションの画像変換エフェクトを管理する
linktitle: 画像変換エフェクト
type: docs
weight: 11
url: /ja/python-net/image-transform-effects/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、画像フレームの画像変換エフェクトを適用、チェーン化、検査、削除、および検証する。"
---
## **概要**

Aspose.Slides は画像変換操作の順序付きコレクションとして画像調整を表現します。画像フレームの場合、フレームの [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) とその [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) プロパティから開始します。返される [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) を使用すると、元の画像バイトを書き換えることなく、エフェクトを追加、列挙、検査、削除、クリアできます。

この記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付けられたエフェクトチェーン、実効値、削除、そして PPTX の往復検証の完全なワークフローを示します。

## **エフェクトの所有権と画像の再利用の理解**

画像リソースとそれを表示する画像は別々のオブジェクトです：

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) はプレゼンテーションが所有するソース画像データを保存または参照します。
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) は画像塗りつぶしに属し、画像リソースを参照しつつ画像変換コレクションを保持します。
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) はスライド形状で、関連する画像塗りつぶし、ジオメトリ、トリミング設定、その他フレームレベルの書式設定を所有します。

したがって、画像変換操作は [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) のバイトを変更しません。同じ `PPImage` を [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) に複数回渡すと、各新しい画像フレームは独自の `Picture` と変換コレクションを取得します。あるフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてが同じ埋め込み画像リソースを再利用しているからです。

同じ `Picture.image_transform` モデルは、シェイプやスライドの背景など他の画像塗りつぶしでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメータ範囲と単位の使用**

デモンストレーションで使用するメソッドは以下の意味的範囲と単位を使用します。特定のライブラリ バージョンがすべての範囲外値を即座に拒否しなくても、これらの範囲内に値を保ってください。ターゲットのプレゼンテーション形式は保存時または PowerPoint がファイルを開く際にデータを正規化、除外、または拒否する可能性があります。

| 操作 | パラメータ | 有効範囲と単位 |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` から `100` まで、パーセンテージ; `0` はコンポーネントを変更しません。 |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | 数値パラメータはありません。アルファは変更されません。 |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | 暗部と明部のピクセル用に 2 つの色を指定します。RGB とアルファチャンネルは `0` から `255` を使用します。 |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | 色相は `0` を含み `360` 未満、度単位です；量は `-100` から `100` のパーセンテージです。 |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | 色相は `0` を含み `360` 未満、度単位です；彩度と輝度は `-100` から `100` のパーセンテージです。 |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | 置換色は各チャンネルが `0` から `255` の値を使用します。既存のアルファ値は変更されません。 |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | 半径は非負でポイント単位です；`grow` はブーリアンで、ぼかし領域が元の境界の外に拡張できるかを制御します。 |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | 非負のパーセンテージです。通常の不透明度スケーリングには `0` から `100` を使用します：`0` は完全に透明、`100` は既存のアルファを保持します。 |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` から `100` のパーセンテージで不透明度を指定します。 |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` から `100` のパーセンテージでアルファしきい値を指定します。しきい値未満は透明になり、しきい値以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補数関係です。例えば、透明度 35% はアルファ変調量 65% に相当します。

## **明るさとコントラストの適用**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) は [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) 操作を返します。スカラー設定は操作作成時に提供されます。[BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) は計算された読み取り専用の値を返し、検査やログ出力が可能です。

以下の例は明るさを 15%、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

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

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) は Office 2010 の画像エフェクト拡張で、標準の DrawingML 輝度エフェクトほど移植性が高くありません。明るさとコントラストを PPTX の往復後も編集可能に保つ必要がある場合は、[ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) を使用し、ファイルを再オープンして結果を検証してください。フォーマット制限のセクションでこの違いについて詳しく説明しています。

## **カラー変換の適用**

カラーエフェクトは、同一画像リソースを再利用する複数の画像フレームに対して個別に適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) には、暗部ピクセルに対応する `color1` と明部ピクセルに対応する `color2` の 2 つの独立した編集可能なカラー パラメータがあります。これは、設定が単一スカラー値よりも複雑なエフェクトの有用な例です。

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

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) はすべてのピクセルの色を固定色に置換し、アルファは保持します。[add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) とは異なり、後者はあるソースカラーを別のカラーにマッピングし、ソースとターゲットの両方のカラー形式を公開します。

### **輝度しきい値の適用**

輝度しきい値を使用すると、スキャンしたページ上のかすかな印刷が背景と区別しやすくなります。[add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) は中間のグレー階調を保持します。[add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) は輝度を黒または白にマッピングし、[add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) は不透明度にしきい値を適用します。

輝度しきい値の範囲は 0% から 100%（両端含む）です。しきい値未満のピクセルは黒になり、しきい値以上のピクセルは白になります。しきい値を上げると、カットオフ未満になる階調が増えるため、より多くの色が黒になります。

[grayscale-swatches.png](grayscale-swatches.png) を作業ディレクトリにダウンロードしてください。各ラベルは 0 から 255 のスケールで元のグレーレベルを示します。例では元画像を 2 つのコピーの横に配置し、各コピーのしきい値をプレゼンテーションに保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint で出力されたプレゼンテーションを開き、3 つのフレームを比較してください。ラベルが 96 のスウォッチは約 38% の輝度（255 のうち 96）です。20% のしきい値で白に、60% のしきい値で黒になります。

![20% と 60% の輝度しきい値での白黒結果を横に並べた元のグレースケールスウォッチ](luminance-threshold.png)

## **ぼかし、透明度、およびアルファ効果の追加**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) はアルファを含むすべてのカラーチャンネルに影響します。ぼかしエッジが元の画像境界を超える可能性がある場合は、`grow` を `True` に設定してください。

均一な透明度には [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) を使用します。既存のアルファ値すべてに乗算するため、部分的に透明なピクセルは比例的に異なるままです。[add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) はすべてのピクセルに単一のアルファ値を割り当てます。[add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) はしきい値に基づいてアルファを 2 つのレベルに変換します。

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

他のパラメータなしのアルファ操作には、[add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)（非ゼロのアルファをすべて完全に不透明にする）、[add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)（100% 未満のアルファをすべて完全に透明にする）、[add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)（アルファを `100% - alpha` に変換する）が含まれます。

## **順序付けられたエフェクトチェーンの構築**

`add_..._effect` メソッドはすべて、新しい操作をコレクションの末尾に追加します。レンダラーはコレクションを順序付けられたパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。したがって、同じ操作でも順序を変えると異なる画像が生成されます。

例として、グレースケールの後にティントを適用すると、まず色相情報が除去され、次に輝度結果に再着色されます。ティントの後にグレースケールを適用すると、ティントが再び除去されます。同様に、アルファ置換は前の操作で計算されたアルファ値を上書きできますが、アルファ変調は相対的な差異を保持します。

以下の例は 4 つの操作からなるチェーンを構築し、PPTX として保存し、プレゼンテーションを再オープンして操作種別と順序の両方を確認し、再オープンした結果をレンダリングします。

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

コレクションは、カラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。これらは組み合わせ可能ですが、組み合わせが常に有用というわけではありません。固定カラー置換は以前のカラーエフェクトで生成された RGB のばらつきを除去します。デュオトーンの後にグレースケールを適用すると、選択された 2 色が削除されます。また、アルファのシーリング、フロア、置換、またはバイレベル操作は、以前に作成されたアルファの詳細を破棄する可能性があります。項目を順序なしの書式フラグとして扱うのではなく、目的とするピクセル処理シーケンスに従ってチェーンを構築してください。

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **編集可能な値と実効値の検査**

編集可能な操作は `Picture.image_transform` に格納されているオブジェクトです。エフェクトに応じて、直接書き込み可能なメンバーを公開する場合があります。例として、[Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) は書き込み可能な `radius` と `grow` プロパティを公開し、[AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) は書き込み可能な `amount` プロパティを、[AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) は書き込み可能な `threshold` プロパティを公開します。[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) などのカラーエフェクトは変更可能な [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) オブジェクトを公開します。

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/)、[Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/)、[AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/) などの一部の操作は、作成時のスカラーを書き込み可能なプロパティとして公開しません。これらの設定を変更するには、操作を削除し、必要な位置に置き換える操作を追加してください。

`get_effective()` が返す実効データは計算済みで読み取り専用です。テーマ依存のカラー解決や、レンダラーが使用する正規化値の取得に便利ですが、別の編集対象ではありません。以下の例はチェーンを列挙し、対応する API が提供する実効値を検査します。

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

グレースケール、アルファシーリング、アルファインバースなどのパラメータなしのエフェクトでも実効データオブジェクトは存在しますが、印刷すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換の削除またはクリア**

[ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) を使用してインデックスで操作を 1 つ削除します。削除後はインデックスがシフトするため、最初に対象を検索し、列挙後に削除してください。`clear()` を使用するとチェーン全体を削除できます。

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

変換の削除またはクリアは画像の書式設定のみを変更し、再利用される [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) リソースを削除、再圧縮、またはその他の変更は行いません。

## **プレゼンテーションフォーマットとエクスポート対象の検討**

画像変換は DrawingML から派生するため、エフェクトチェーンの編集可能なフォーマットとしては PPTX が推奨されます。PPTX でも、すべての操作が同等の移植性を持つわけではありません：

- 輝度、グレースケール、デュオトーン、ティント、HSL、ぼかし、一般的なアルファ操作などの標準 DrawingML 操作は、PPTX の往復で残存する可能性が最も高いです。保存性が必要な場合は、常に生成ファイルを再オープンしてコレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) は標準 DrawingML 輝度操作ではなく Office 2010 の拡張です。インメモリ描画には使用できますが、保存および PPTX 再オープン後に編集可能な `BrightnessContrast` 操作として残る保証はありません。永続的な明るさ・コントラスト調整には [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) を使用してください。
- バイナリ PPT フォーマットは完全な DrawingML エフェクトモデルよりも前に策定されました。PPT に保存すると、サポートされていない操作が省かれたり、チェーンがサポートされたサブセットに縮小されたり、外観が近似されます。複雑な編集可能チェーンの検証フォーマットとして PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などへのレンダリングは、サポートされたチェーンを描画結果に適用します。これらの出力には編集可能な `ImageTransformOperationCollection` は含まれません。ラスタ形式は結果をピクセルにフラット化し、ドキュメントやベクター出力は独自のレンダリング表現を保持します。
- エフェクトはリンクされた画像を自己完結にしません。リンク画像のレンダリングは、プレゼンテーションが読み込まれる際にリンクリソースが利用可能であることに依存します。

異なるプレゼンテーションビューアは、特に複数のアルファやカラー量子化操作が組み合わされた場合に、エッジケースを異なる方法でレンダリングすることがあります。重要な出力の場合は、実編集の往復と最終エクスポート形式の両方を、実運用で使用している同じ Aspose.Slides バージョンでテストしてください。

## **よくある質問**

**画像変換エフェクトは埋め込み画像データを変更しますか？**

いいえ。操作は画像塗りつぶしで使用される `Picture` に属します。基になる `PPImage` バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームはエフェクトを共有しますか？**

いいえ。`PPImage` を再利用して画像データの重複を防げますが、各画像フレームは通常、個別の `Picture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファエフェクトは組み合わせ可能ですか？**

はい。コレクションは 1 つの順序付けられたチェーンとして受け入れます。各操作が前の結果にどのように影響するかを考慮してください。置換やしきい値操作は、以前のカラーやアルファの詳細を破棄する可能性があります。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングに使用される計算値を表し、解決されたカラーを含みます。書き込み可能なメンバーがある操作はその場所で編集してください。そうでない場合は操作を削除し、新しい作成パラメータで置き換えてください。

**変換チェーンを保持するにはどのフォーマットを使用すべきですか？**

PPTX を使用し、ファイルを再オープンして確認してください。レガシー PPT は完全な DrawingML エフェクトモデルを表現できず、レンダリング出力形式は外観を保持しますが編集可能な変換操作は含みません。
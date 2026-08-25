---
title: PHP でプレゼンテーションの画像変換効果を管理する
linktitle: 画像変換効果
type: docs
weight: 11
url: /ja/php-java/image-transform-effects/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、画像フレームの画像変換効果を適用、チェーン化、検査、削除、および検証します。"
---
## **概要**

Aspose.Slides は画像の調整を画像変換操作の順序付けられたコレクションとして表現します。画像フレームの場合、フレームの [Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picture/) から開始し、[Picture::getImageTransform](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picture/getimagetransform/) にアクセスします。返される [ImageTransformOperationCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/) を使用すると、元の画像バイトを再書き込みせずに、効果を追加、列挙、検査、削除、クリアできます。

この記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付けられたエフェクトチェーン、有効値、削除、および PPTX の往復検証の完全なワークフローを示します。

## **エフェクトの所有権と画像の再利用を理解する**

画像リソースとそれを表示する画像は別々のオブジェクトです：

- [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) はプレゼンテーションが所有するソース画像データを保存または参照します。
- [Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picture/) はピクチャーフィルの一部であり、画像リソースを参照しながら画像変換コレクションを保持します。
- [PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) は、関連するピクチャーフィル、ジオメトリ、クロップ設定、およびその他のフレームレベルの書式設定を所有するスライドシェイプです。

したがって、画像変換操作は [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) のバイトを変更しません。同じ `PPImage` を [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addpictureframe/) に複数回渡すと、各新しい画像フレームは独自の `Picture` と独自の変換コレクションを受け取ります。あるフレームにグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてのフレームが同じ埋め込み画像リソースを再利用しているからです。

同じ `Picture::getImageTransform` モデルは、シェイプやスライドの背景など他のピクチャーフィルでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメーター範囲と単位を使用する**

デモで使用するメソッドは以下の意味的範囲と単位を持ちます。特定のライブラリ バージョンがすぐにすべての範囲外値を拒否しなくても、これらの範囲内に値を保ってください。ターゲットのプレゼンテーション形式が保存時や PowerPoint がファイルを開くときに正規化、除外、または拒否する可能性があります。

| 操作 | パラメーター | 有効範囲と単位 |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` から `100`、パーセント; `0` はコンポーネントを変更しません。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | なし | 数値パラメーターはありません。アルファは変更されません。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | 暗部と明部のピクセル用の 2 色。`java.awt.Color` の RGB とアルファチャンネルは `0` から `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相は `0` 以上 `360` 未満（度）; 量は `-100` から `100`、パーセント。 |
| [addHSLEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相は `0` 以上 `360` 未満（度）; 彩度と輝度は `-100` から `100`、パーセント。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | 置換色は各チャンネルが `0` から `255`。既存のアルファは変更されません。 |
| [addBlurEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半径は非負でポイント単位; `grow` はブール値で、ぼかし領域が元の境界を超えるか制御します。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負パーセント。通常の不透明度スケーリングは `0` から `100` を使用します。`0` は完全に透明、`100` は既存のアルファを保持。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` から `100`、パーセントの不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` から `100`、パーセントのアルファしきい値。しきい値未満は透明、しきい値以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストを適用する**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) は [Luminance](https://reference.aspose.com/slides/ja/php-java/aspose.slides/luminance/) 操作を返します。スカラー設定は操作作成時に供給されます。[Luminance::getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/luminance/geteffective/) は計算された読み取り専用値を返し、検査またはログ出力に使用できます。

以下の例は明るさを 15%、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` は標準的な DrawingML の明るさ・コントラスト効果です。これらの設定を PPTX 往復後も編集可能に保つ必要がある場合は、保存したプレゼンテーションを再度開き、操作のタイプと有効値の両方を確認してください。

## **カラー変換を適用する**

カラー効果は、同一画像リソースを再利用する異なる画像フレームに対して個別に適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュオトーン、ティント、HSL 調整、カラー置換を適用します。

[Duotone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/duotone/) には 2 つの独立した編集可能カラー パラメーターがあります: `color1` が暗いピクセルに、`color2` が明るいピクセルにマップされます。これは単一スカラー値よりも複雑な設定を持つ効果の有用な例です。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) はアルファを保持しながらすべてのピクセルの色を固定色に置換します。これは、ソース色を別の色にマップし、両方の色形式を公開する [addColorChangeEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) とは異なります。

## **ぼかし、透明度、アルファ効果を追加する**

[addBlurEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) はすべてのカラーチャンネル、アルファも含めて影響します。ぼかしエッジが元の画像境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明度には [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) を使用します。既存のアルファ値すべてに乗算するため、部分的に透明なピクセルは比例的に異なるまま残ります。[addAlphaReplaceEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) はすべてのピクセルに単一のアルファ値を割り当てます。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) はしきい値に基づいてアルファを 2 段階に変換します。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

パラメーターなしの他のアルファ操作には、すべての非ゼロアルファを完全に不透明にする [addAlphaCeilingEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)、すべてのアルファを 100% 未満で完全に透明にする [addAlphaFloorEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)、そして `100% - alpha` に変換する [addAlphaInverseEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/) があります。

## **順序付けられたエフェクトチェーンを構築する**

すべての `add...Effect` メソッドはコレクションの末尾に新しい操作を追加します。レンダラーはこのコレクションを順序付きパイプラインとして使用します：操作 0 の出力が操作 1 の入力となり、以降同様です。したがって、同じ操作でも順序が異なると異なる画像が生成されます。

例として、グレースケールの後にティントを適用すると、まず色相情報が除去され、その後輝度結果が再着色されます。ティントの後にグレースケールを適用するとティントが再び除去されます。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きでき、アルファ変調は相対的な差を保持します。

以下の例は 4 操作のチェーンを構築し、PPTX として保存し、プレゼンテーションを再度開いて操作タイプと順序の両方を確認し、再オープンした結果をレンダリングします。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

コレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリクスを課しません。組み合わせて使用できますが、組み合わせが常に有用とは限りません。固定カラー置換は以前のカラー効果で生成された RGB のばらつきを除去しますし、デュオトーンの後にグレースケールを適用すると 2 つの選択色が失われます。また、アルファの天井、床、置換、または二段階操作は、以前に作成されたアルファの細部を破棄する可能性があります。チェーンは目的とするピクセル処理シーケンスに合わせて構築し、項目を順序なしの書式フラグとして扱わないでください。

## **編集可能値と有効値を検査する**

編集可能な操作は `Picture::getImageTransform` に格納されているオブジェクトです。効果によっては書き込み可能なメンバーを直接公開します。たとえば、[Blur](https://reference.aspose.com/slides/ja/php-java/aspose.slides/blur/) は書き込み可能な `radius` と `grow` を公開し、[AlphaModulateFixed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/alphamodulatefixed/) は書き込み可能な `amount` を、[AlphaBiLevel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/alphabilevel/) は書き込み可能な `threshold` を公開します。[Duotone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/duotone/) のようなカラー効果は可変の [ColorFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorformat/) オブジェクトを公開します。

[Luminance](https://reference.aspose.com/slides/ja/php-java/aspose.slides/luminance/)、[HSL](https://reference.aspose.com/slides/ja/php-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tint/)、[AlphaReplace](https://reference.aspose.com/slides/ja/php-java/aspose.slides/alphareplace/) などの操作は作成時のスカラーを書き込み可能プロパティとして公開しません。これらの設定を変更するには、操作を削除して必要な位置に置換操作を追加してください。

`getEffective()` が返す有効データは計算済みで読み取り専用です。テーマ依存のカラーを解決したり、レンダラーが使用する正規化値を取得したりするのに便利ですが、別の編集用サーフェスではありません。以下の例はチェーンを列挙し、対応する API が提供する有効値を検査します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

パラメーターなしの効果（グレースケール、アルファ天井、アルファ逆転など）でも有効データオブジェクトは存在しますが、出力すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換を削除またはクリアする**

[ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/removeat/) を使用してインデックスで 1 つの操作を削除します。インデックスは削除後にシフトするため、まず対象を検索し、列挙後に削除してください。[ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagetransformoperationcollection/clear/) を使用するとチェーン全体を削除できます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

変換を削除またはクリアしても、画像の書式設定のみが変更されます。再利用されている [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) リソースは削除、再圧縮、またはその他の変更を受けません。

## **プレゼンテーション形式とエクスポート対象を考慮する**

画像変換は DrawingML から派生しているため、効果チェーンの編集可能形式としては PPTX が推奨されます。PPTX でもすべての操作が同等の移植性を持つわけではありません：

- luminance、grayscale、duotone、tint、HSL、blur、一般的なアルファ操作などの標準 DrawingML 操作は PPTX 往復で残存する可能性が最も高いです。保存したファイルを必ず再オープンし、コレクションを検査して保存要件を満たすか確認してください。
- バイナリ PPT 形式は完全な DrawingML 効果モデルが導入される前のものです。PPT に保存するとサポートされていない操作が省略されたり、チェーンがサポート対象のサブセットに縮小されたり、外観が近似されたりすることがあります。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンをレンダリング結果に適用します。これらの出力には編集可能な `ImageTransformOperationCollection` は含まれず、ラスタ形式は結果をピクセルにフラット化し、ドキュメントやベクタエクスポートは独自のレンダリング表現を保存します。
- 効果はリンク画像を自己完結型にしません。リンク画像をレンダリングする場合、プレゼンテーションが読み込まれる際にリンクリソースが利用可能である必要があります。

複数のアルファやカラー量子化操作が組み合わさると、異なるプレゼンテーションビューアーがエッジケースを異なる方式で描画することがあります。重要な出力については、編集可能な往復と最終エクスポート形式の両方を、実運用で使用している同一の Aspose.Slides バージョンでテストしてください。

## **FAQ**

**画像変換効果は埋め込み画像データを変更しますか？**

いいえ。操作はピクチャーフィルで使用される `Picture` に属し、基礎となる `PPImage` バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームは効果を共有しますか？**

いいえ。`PPImage` を再利用すると画像データの重複を防げますが、各画像フレームは通常別々の `Picture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファ効果は組み合わせられますか？**

はい。コレクションは 1 つの順序付けられたチェーンで受け入れます。置換やしきい値操作は以前のカラーやアルファの詳細を破棄する可能性があるため、各操作が前の出力に与える影響を考慮してください。

**なぜ有効値は読み取り専用ですか？**

有効データはレンダリングに使用される計算済み値で、解決されたカラーを含みます。書き込み可能メンバーが存在する場合は変換コレクションに格納された操作を編集し、そうでなければ削除して新しい作成パラメーターで置換してください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、再オープンしてファイルを検証してください。レガシー PPT は完全な DrawingML 効果モデルを表現できず、レンダリングエクスポート形式は外観を保持しますが、編集可能な変換操作は保持しません。
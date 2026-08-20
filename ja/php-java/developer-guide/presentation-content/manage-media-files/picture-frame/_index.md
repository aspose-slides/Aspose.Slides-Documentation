---
title: PHP を使用したプレゼンテーションでのピクチャーフレームの管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/php-java/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームを追加
- ピクチャーフレームを作成
- 埋め込み画像
- リンク画像
- 画像を抽出
- ラスタ画像
- SVG 画像
- 画像をクロップ
- クロップされた領域を削除
- 画像を圧縮
- ストレッチオフセット
- ピクチャーフレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、プレゼンテーション内のピクチャーフレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

ピクチャーフレームは画像を表示するスライドシェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです：a [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) が[ImageCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagecollection/) を介して埋め込み画像リソースを所有し、[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、画像効果、およびその他のフレームレベル設定を制御します。

この分離は、同じ画像を複数回表示する場合に便利です。プレゼンテーションに画像を一度だけ追加し、返された [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) を保持し、ピクチャーフレームを作成する際にその画像リソースを使用します。

ピクチャーフレームは PNG や JPEG などのラスタ画像や、SVG などのベクター画像を含めることができます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照することも可能です。この選択はポータビリティ、ファイルサイズ、抽出、エクスポート動作に影響するため、書式設定や最適化を適用する前に画像の保存方法を決定しておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addpictureframe/) を使用してピクチャーフレームを作成します。画像はプレゼンテーションパッケージの一部になるため、別のコンピューターに移動してもプレゼンテーションは自己完結した状態を保ちます。

以下の例は JPEG 画像を追加し、画像の元のサイズでフレームを作成し、線の書式設定と回転を適用します：

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ピクチャーフレームは表示される形状を制御します。フレームのサイズを変更しても、埋め込み画像リソースに保存された元のピクセルサイズは変わりません。この区別は、後で画像をクロップまたは圧縮する際に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) はフレームの相対幅と高さのスケーリングを [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/setrelativescalewidth/) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/setrelativescaleheight/) を通じて公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終サイズを手動で計算せずに元画像サイズとの関係を保持する必要があるワークフローで便利です。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像をリサンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に保存するため、ポータビリティと予測可能なレンダリングに最も安全な選択です。リンク画像は [Picture::setLinkPathLong](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picture/setlinkpathlong/) メソッドを使用して外部の場所を保存し、画像データを埋め込む代わりに参照します。

リンク画像は PPTX に保存される画像データ量を減らすことができますが、外部依存性が生じます。リンクされたファイルは、プレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できない場合、リンク画像は期待どおりに表示されません。メールで送信したり、アーカイブしたり、孤立した環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

以下の例はピクチャーフレームを作成し、ローカル画像ファイルを指すように設定します。画像のリンクのみを扱い、ビデオのリンクは別のメディアワークフローであり、この例には意図的に混在させていません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替としてのみ使用しないでください。破損した画像依存関係を持つ小さな PPTX は、サイズは大きくても自己完結したプレゼンテーションよりも実用性が低いことが多いです。

## **ピクチャーフレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) であり、埋め込み画像を含んでいるか確認してください。リンクされたピクチャーフレームは、同様に抽出できる画像バイトを含まない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) を直接使用します。以下の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

[IImage::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/#save) を使用して保存すると、抽出した画像が要求された出力形式に変換されます。変換されたラスタファイルではなく、プレゼンテーションに保存されたエンコードバイトが必要な場合は、画像リソースのバイナリデータを直接使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) は [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) オブジェクトを公開します。これにより、画像をラスタライズせずに SVG データを直接取得できます。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内のベクターソースが保存されます。PNG や JPEG などのラスタエクスポートは、そのベクターコンテンツをピクセルにレンダリングします。PDF や SVG スライドのエクスポートもレンダリング操作であるため、エクスポートされた画像は元の埋め込み SVG のバイト単位でのコピーとして扱うべきではありません。元のベクターリソース自体が必要な場合は、埋め込みの [SvgImage::getSvgData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/getsvgdata/) データを使用してください。

## **画像のクロップ**

クロップは、フレーム内で画像のどの部分が表示されるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/) のクロップ値は元画像の寸法に対するパーセンテージです。クロップは、埋め込み画像から隠れたピクセルを削除するわけではなく、表示領域を変更するだけです。

以下の例はピクチャーフレームを安全に取得し、クロップ値を適用します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

隠れた画像データがまだ存在するため、後でクロップを変更しても元のピクセルは失われません。ファイルサイズが可逆性より重要な場合は、次のセクションで説明するようにクロップ領域を実際に削除できます。

## **クロップされた画像データの削除**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) は現在のクロップ矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズを削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後でのアンクロップ操作に利用できなくなります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
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
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元の画像が他のピクチャーフレームでも使用されている場合、これらのフレームは既存のリソースを必要とするため、クロップ領域の削除が画像総数の削減につながるとは限りません。このメソッドで WMF や EMF コンテンツをクロップすると、クロップ結果が PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) は、画像が表示されるサイズに対してラスタ画像の解像度を下げます。同時にクロップ領域を削除することもできます。このメソッドは画像がリサイズまたはクロップされた場合に `true` を、変更が不要だった場合に `false` を返します。

標準の目標解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturescompression/) の値を使用してください：

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

特定の目標が必要な場合は、事前定義値の代わりにカスタムの正の DPI 値を指定できます。

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、低解像度化や削除されたクロップ領域は最適化されたプレゼンテーションから復元できないことを覚えておいてください。全体的に最低 DPI を適用するのではなく、画像が実際に閲覧またはエクスポートされる最大サイズに基づいて目標解像度を選択してください。

## **画像効果の検査**

画像効果はフレームで使用されている画像に格納されます。画像変換コレクションには、透明度用の固定アルファ変調や明るさ・コントラスト用のルミナンスなどの効果が含まれることがあります。以下の例はスライド上の最初のピクチャーフレームから両方の効果を安全に読み取ります：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
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
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

これらの効果はフレーム内での画像のレンダリング方法を変更しますが、元の埋め込み画像バイトを書き換えるものではありません。

## **ピクチャーフレームジオメトリのロック**

[PictureFrameLock](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframelock/) の設定はピクチャーフレームに対して無効化される編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) はリサイズ時にシェイプの比率を保持します。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

このロックはピクチャーフレームのシェイプに適用されます。元画像がリサンプリングされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードが stretch の場合、[PictureFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/) の stretch-offset 値はピクチャーフレームのバウンディングボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセット（内側）を、負のパーセンテージはアウトセット（外側）を作ります。

これはクロップとは異なります。クロップ値は元画像のどの部分が表示されるかを選択しますが、stretch offset は表示された画像塗りつぶしが伸びる矩形を変更します。

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

塗りつぶしの配置には stretch offset を使用してください。元画像の端を隠すことが目的の場合はクロッププロパティを使用します。

## **保存、ファイルサイズ、エクスポートの考慮事項**

画像の保存とピクチャーフレームの書式設定を別々に扱うことで、主なトレードオフをより管理しやすくなります：

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバーサイドレンダリングで最も信頼性がありますが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは保存されたパスや場所に外部ファイルが存在することに依存します。
- **クロップ** は当初は非破壊的です。隠れたピクセルは、クロップ領域が明示的に削除されるか、圧縮中に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での意図したサイズが判明した後に適用すべきです。
- **SVG 画像** はベクターの保存が重要な場合は SVG のままにすべきです。ベクターリソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタスライドエクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は可能な限り既存の [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) リソースを再利用し、同じファイルを何度もプレゼンテーションワークフローに読み込むのを避けるべきです。

大規模なプレゼンテーションでは、画像の最適化は選択的に実行することで最も効果的です。ロゴや図はベクターコンテンツのまま保持し、写真は実際の表示サイズに合わせて圧縮し、後での編集が不要な場合にのみクロップしたピクセルを削除し、外部リンクは依存性管理がデプロイ設計の一部でない限り避けてください。

## **よくある質問**

**ピクチャーフレームと画像リソースの違いは何ですか？**  
[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、効果、ロックなどのフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきか、リンクすべきか？**  
プレゼンテーションがポータブルである必要がある、アーカイブする、または外部リソースにアクセスせずにレンダリングする必要がある場合は、画像を埋め込んでください。画像ファイルを PPTX の外に保持することが意図的で、外部の場所を確実に維持できる場合にのみ、リンク画像を使用してください。

**クロップは PPTX のファイルサイズを削減しますか？**  
単独では削減しません。通常のクロップ設定は元画像の一部を隠すだけで、基になるピクセルは保持されます。ピクセルを永続的に破棄できる場合は、[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) を使用するか、クロップ領域の削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**  
できません。圧縮により保存されたラスタ解像度が下がり、クロップ領域の削除は画像データを破棄します。後で高解像度の編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外に保持してください。

**SVG 画像はどのように扱うべきですか？**  
ベクターの忠実度が重要な場合は、SVG コンテンツを SVG のまま保持してください。埋め込みの [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) は直接抽出できます。スライドを PNG や JPEG などのラスタ形式でレンダリングすると、SVG はスライド画像の一部としてラスタライズされます。

**既存のスライドを読む際に安全でないキャストを回避するにはどうすればよいですか？**  
ピクチャーフレーム固有のメンバーを使用する前に、シェイプのタイプを確認してください。[PictureFrame] に対する `java_instanceof` チェックを行うことで、無効なキャストを回避し、ピクチャーフレームを含まないスライドにも対応できます。
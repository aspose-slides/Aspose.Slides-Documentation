---
title: PHP を使用してプレゼンテーション内の画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/php-java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 埋め込み画像
- リンク画像
- 画像を抽出
- ラスター画像
- SVG 画像
- 画像をクロップ
- クロップ領域を削除
- 画像を圧縮
- StretchOffset
- 画像フレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

画像フレームは、画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) は [ImageCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagecollection/) を通じて埋め込み画像リソースを保持し、[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) が画像の位置、サイズ、線の書式設定、回転、クロップ、ピクチャ効果、その他フレームレベルの設定を制御します。

この分離は、同じ画像を複数回表示する場合に便利です。画像をプレゼンテーションに一度だけ追加し、返された [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) を保持して、ピクチャフレームを作成するときにその画像リソースを使用します。

ピクチャフレームは PNG や JPEG などのラスタ画像や SVG のようなベクタ画像を格納できます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照させることもできます。選択は可搬性、ファイル サイズ、抽出、エクスポートの動作に影響するため、書式設定や最適化を行う前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addpictureframe/) でピクチャフレームを作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピュータに移動しても自己完結した状態が保たれます。

次の例は JPEG 画像を追加し、画像の元サイズでフレームを作成し、線の書式設定と回転を適用します。

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

ピクチャフレームは表示されるジオメトリを制御します。フレームのサイズを変更しても、埋め込み画像リソースに保存されている元のピクセル寸法は変わりません。この区別は、後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) は [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/setrelativescalewidth/) と [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/setrelativescaleheight/) によってフレームの幅と高さの相対スケールを公開します。`1.0` の値は元画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算せずに元画像サイズとの関係を保持したいワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像を再サンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込みピクチャは画像データをプレゼンテーション内に保存するため、可搬性と予測可能なレンダリングに最も安全です。リンクピクチャは [Picture::setLinkPathLong](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picture/setlinkpathlong/) メソッドで外部の場所を参照し、同じ方法で画像データを埋め込むことはありません。

リンク画像は PPTX に保存される画像データ量を減らすことができますが、外部依存が生じます。リンクされたファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンクピクチャは期待どおりに表示されません。メールで送付したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションの場合、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例はピクチャフレームを作成し、ローカル画像ファイルへのリンクを設定します。この例は画像のリンクにのみ焦点を当てており、ビデオのリンクは別のメディア ワークフローで扱うため、意図的に混在させていません。

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

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替手段として使用しないでください。壊れた画像依存関係を持つ小さな PPTX は、サイズが大きくても自己完結したプレゼンテーションよりも実用性が低くなります。

## **ピクチャフレームからの画像抽出**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) であり、埋め込み画像を持っていることを確認します。リンクされたピクチャフレームは、同じ方法で抽出できる画像バイトを含まない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) を直接使用します。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

[IImage::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/#save) を介した保存は、抽出した画像を要求された出力形式に変換します。プレゼンテーションに保存されているエンコード済みバイトが必要な場合は、変換されたラスタ ファイルではなく画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG ピクチャの場合、[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) が [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) オブジェクトを公開します。これにより、最初に画像をラスタライズせずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクタ ソースが保存されます。PNG や JPEG などのラスタ エクスポートは、そのベクタ コンテンツをピクセルに変換します。PDF や SVG へのスライド エクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとして扱うべきではありません。元のベクタ リソースが必要な場合は、埋め込み [SvgImage::getSvgData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/getsvgdata/) を使用してください。

## **画像のクロップ**

クロップは、フレーム内で画像のどの部分が表示されるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/) のクロップ値は、ソース画像の寸法に対するパーセンテージです。クロップは最初は埋め込み画像から隠れたピクセルを削除せず、表示領域だけを変更します。

次の例はピクチャフレームを安全に取得し、クロップ値を適用します。

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

隠れた画像データはまだ存在するため、後でクロップを変更しても元のピクセルは失われません。ファイル サイズが重要で、可逆性が不要な場合は、次のセクションで説明するようにクロップ領域を物理的に削除できます。

## **クロップされた画像データの削除**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) は現在のクロップ矩形の外側にある画像データを削除し、結果として得られる画像リソースを返します。これによりファイル サイズが削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは元に戻せなくなります。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元の画像が他のピクチャフレームでも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、クロップ領域の削除が必ずしも画像総数の減少につながるわけではありません。WMF や EMF コンテンツをこのメソッドでクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) は、画像が表示されるサイズに対してラスタ画像の解像度を低下させます。同時にクロップ領域を削除することも可能です。メソッドは画像がリサイズまたはクロップされた場合に `true`、変更が不要だった場合に `false` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturescompression/) 値を使用してください。

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

特定のターゲットが必要な場合は、事前定義値の代わりにカスタムの正の DPI 値を渡すことができます。

圧縮はラスタ画像を対象としています。SVG やメタファイル コンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、低解像度化や削除されたクロップ領域は最適化されたプレゼンテーションから復元できないことを覚えておいてください。全体的に最低 DPI を適用するのではなく、画像が実際に表示またはエクスポートされる最大サイズに基づいてターゲット解像度を選択してください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付けられたチェーン、検査、削除、ラウンドトリップ検証を網羅した完全なワークフローについては、[Image Transform Effects](/slides/ja/php-java/image-transform-effects/) を参照してください。

## **ピクチャフレームジオメトリのロック**

[PictureFrameLock](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframelock/) 設定は、ピクチャフレームに対して無効化する編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) はリサイズ時にシェイプの縦横比を保持します。

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

ロックはピクチャフレーム シェイプに適用されます。ソース画像が同じ縦横比になるように再サンプリングされたり、永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

ピクチャの塗りつぶしモードが stretch の場合、[PictureFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/) の stretch-offset 値はピクチャフレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値はソース画像のどの部分が可視になるかを選択し、stretch offset は可視ピクチャ塗りつぶしが伸張される矩形を変更します。

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

塗りつぶしの配置には stretch offset を使用し、ソース画像の端を隠す目的の場合はクロップ プロパティを使用してください。

## **保存、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存とピクチャフレームの書式設定を別々に扱うと、主なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性が高いですが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスや場所で利用可能であることに依存します。
- **クロップ** は最初は非破壊的です。隠れたピクセルはクロップ領域が明示的に削除されるか、圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** はサイズが大きすぎるラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での実際の表示サイズが分かってから適用すべきです。
- **SVG 画像** はベクタ の保存が重要な場合は SVG のままにしてください。ベクタ リソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタ スライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用する画像** は、可能な限り既存の [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) リソースを再利用し、同じファイルを何度もプレゼンテーション ワークフローに読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図表はベクタ コンテンツのまま保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が必要ない場合にのみクロップされたピクセルを削除し、外部リンクは依存関係管理がデプロイ設計の一部である場合にのみ使用してください。

## **FAQ**

**ピクチャフレームと画像リソースの違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表します。[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、効果、ロックなどフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションを可搬性、アーカイブ、外部リソースなしでレンダリングする必要がある場合は埋め込み画像を選択してください。画像ファイルを PPTX の外に置くことが意図的で、外部場所を確実に管理できる場合のみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを減らしますか？**

単独では減らしません。通常のクロップ設定は画像の一部を隠すだけで、基になるピクセルは保持されます。ピクセルを永久に削除したい場合は、[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) またはクロップ領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮により保存されるラスタ解像度が下がり、クロップ領域の削除は画像データを破棄します。後で高解像度編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタ の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) は直接抽出できます。PNG や JPEG などのラスタ形式へのスライド レンダリングは、SVG をスライド画像の一部としてラスタライズします。

**既存スライドを読み取る際に安全でないキャストを回避するには？**

ピクチャフレーム固有のメンバーを使用する前に、シェイプのタイプを確認してください。[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) に対する `java_instanceof` チェックを行うことで、無効なキャストを防ぎ、ピクチャフレームを含まないスライドを適切に処理できます。
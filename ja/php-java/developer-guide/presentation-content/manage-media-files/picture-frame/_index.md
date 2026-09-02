---
title: PHP を使用したプレゼンテーションでの画像フレームの管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/php-java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスター画像
- SVG 画像
- 画像のトリミング
- トリミング領域の削除
- 画像の圧縮
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
description: "Aspose.Slides for PHP via Java を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、トリミング、抽出、圧縮します。"
---
## **概要**

PictureFrame は画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。a [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) が [ImageCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagecollection/) を通じて埋め込み画像リソースを所有し、[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) が画像の位置、サイズ、線の書式設定、回転、トリミング、画像効果、およびその他のフレームレベル設定を制御します。

同じ画像を複数回表示する場合、この分離は便利です。画像をプレゼンテーションに一度追加し、返された [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) を保持し、PictureFrame を作成するときにその画像リソースを使用します。

PictureFrame は PNG や JPEG などのラスター画像や SVG などのベクター画像を含めることができます。また、画像バイトをプレゼンテーションに格納せずにリンク画像を参照することもできます。選択は可搬性、ファイルサイズ、抽出、エクスポートの動作に影響するため、書式設定や最適化を適用する前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addpictureframe/) で PictureFrame を作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピュータに移動してもプレゼンテーションは自己完結した状態を保ちます。

次の例は JPEG 画像を追加し、画像の元のサイズでフレームを作成し、線の書式設定と回転を適用します。

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

PictureFrame は表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに保存されている元のピクセル寸法は変わりません。この違いは、後で画像をトリミングまたは圧縮する場合に重要になります。

## **相対スケールの使用**

[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) は [setRelativeScaleWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/setrelativescalewidth/) および [setRelativeScaleHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/setrelativescaleheight/) によってフレームの相対幅・高さスケーリングを公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像をリサンプルしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に格納するため、可搬性と予測可能なレンダリングに最も安全な選択です。リンク画像は [Picture::setLinkPathLong](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picture/setlinkpathlong/) メソッドで外部の場所を指し示し、画像データを埋め込む代わりに参照します。

リンク画像は PPTX に格納される画像データ量を削減できますが、外部依存性が生じます。リンク先のファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションからアクセス可能である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンク画像は期待通りに表示されない可能性があります。メールで送付したり、アーカイブしたり、分離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例は PictureFrame を作成し、ローカル画像ファイルへのリンクを設定します。これは画像リンクのみを扱い、動画リンクは別のメディア ワークフローであり、本例には意図的に混在させていません。

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

外部ファイル管理が意図的な場合にリンクを使用してください。単に圧縮の代替として使用しないでください。リンクが切れた小さな PPTX は、サイズが大きく自己完結したプレゼンテーションよりも実用性が低いことが多いです。

## **PictureFrame から画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) であること、かつ埋め込み画像を含んでいることを確認してください。リンクされた PictureFrame は同じ方法で抽出できる画像バイトを含まない場合があります。

### **ラスター画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) を直接使用します。次の例はスライド上の最初の埋め込みラスター画像を見つけて PNG として保存します。

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

[IImage::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/#save) を使用して保存すると、抽出した画像が要求された出力形式に変換されます。変換されたラスター ファイルではなく、プレゼンテーションに格納されているエンコード バイトが必要な場合は、画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) は [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) オブジェクトを公開します。これにより、画像をラスター化せずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のままで保持すると、プレゼンテーション内のベクタ ソースが保存されます。PNG や JPEG などのラスター エクスポートは、そのベクタ コンテンツをピクセルにレンダリングします。PDF や SVG のスライド エクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとして扱わず、元のベクタ リソースが必要なときは埋め込み [SvgImage::getSvgData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/getsvgdata/) データを使用してください。

## **画像のトリミング**

トリミングはフレーム内で画像のどの部分が表示されるかを変更します。[PictureFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/) のトリミング値は元画像の寸法に対するパーセンテージです。トリミングは埋め込み画像から隠れたピクセルを即座に削除するわけではなく、表示領域を変更するだけです。

次の例は PictureFrame を安全に取得し、トリミング値を適用します。

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

隠れた画像データは依然として存在するため、後でトリミングを変更しても元のピクセルを失うことはありません。ファイルサイズが可逆性より重要な場合は、次のセクションで説明するようにトリミング領域を物理的に削除できます。

## **トリミングされた画像データの削除**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) は現在のトリミング矩形の外側にある画像データを削除し、結果の画像リソースを返します。これによりファイルサイズが削減できる可能性がありますが、破壊的な最適化です。プレゼンテーションが保存された後は、削除されたピクセルは後で元に戻すことはできません。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元の画像が他の PictureFrame でも使用されている場合、そのフレームは既存のリソースを必要とするため、トリミング領域の削除だけで画像総数が減るとは限りません。WMF や EMF コンテンツをこのメソッドでトリミングすると、結果は PNG にラスター化されます。

## **ラスター画像の圧縮**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) は、画像が表示されるサイズに対するラスター画像の解像度を低減します。同時にトリミング領域を削除することもできます。メソッドは画像がリサイズまたはトリミングされた場合に `true`、変更が不要だった場合に `false` を返します。

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

圧縮はラスター画像を対象としています。SVG やメタファイルのコンテンツはこのラスター圧縮ワークフローでは削減されません。また、低解像度化や削除されたトリミング領域は最適化されたプレゼンテーションからは復元できないことを忘れないでください。最も大きく表示またはエクスポートされるサイズに基づいてターゲット解像度を選択し、全体に最低 DPI を適用するのは避けてください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付けチェーン、検査、削除、ラウンドトリップ検証を網羅した完全なワークフローについては、[Image Transform Effects](/php-java/image-transform-effects/) を参照してください。

## **PictureFrame のジオメトリをロックする**

[PictureFrameLock](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframelock/) 設定は、PictureFrame に対して無効化する編集操作を制御します。たとえば、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) はリサイズ時にシェイプの比例を保持します。

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

ロックは PictureFrame シェイプに適用されます。ソース画像がリサンプルされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

塗りつぶしモードが stretch の場合、[PictureFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/) の stretch‑offset 値は PictureFrame のバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはトリミングとは異なります。トリミング値は元画像のどの部分が表示されるかを選択し、stretch offset は表示される画像塗りつぶしが伸びる矩形を変更します。

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

塗りつぶし位置を調整したい場合は stretch offset を使用し、ソース画像の端を隠したい場合はトリミング プロパティを使用してください。

## **保存、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存と PictureFrame の書式設定を別々に扱うと、主なトレードオフが管理しやすくなります。

- **Embedded images** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングで最も信頼性が高いですが、大きなラスター画像は PPTX のサイズとメモリ使用量を増加させます。
- **Linked images** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが保存されたパスまたは場所で利用可能であることに依存します。
- **Cropping** は最初は非破壊的です。隠れたピクセルは削除領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **Compression** は過大なラスター画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上での実際の表示サイズが分かってから適用すべきです。
- **SVG images** はベクタ の保存が重要な場合は SVG のままにすべきです。ベクタ リソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスター スライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **Repeated images** は可能な限り既存の [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) リソースを再利用し、同じファイルを何度もプレゼンテーション ワークフローに読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図表はベクトル コンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみトリミング ピクセルを削除し、外部リンクは依存性管理がデプロイ設計の一部でない限り避けてください。

## **FAQ**

**PictureFrame と画像リソースの違いは何ですか？**

[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) はプレゼンテーションに関連付けられた画像リソースを表し、[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) はスライド上で画像を表示し、サイズ、回転、トリミング値、エフェクト、ロックなどのフレームレベルのジオメトリと書式設定を保持するシェイプです。

**画像は埋め込むべきか、リンクすべきか？**

プレゼンテーションを可搬性、アーカイブ、または外部リソースへのアクセスなしでレンダリングする必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外部に保持し、外部場所を確実に管理できる場合にのみリンク画像を使用します。

**トリミングは PPTX のファイルサイズを縮小しますか？**

単独では縮小しません。通常のトリミング設定は画像の一部を非表示にしますが、基になるピクセルは保持したままです。ピクセルを永久に削除できる場合は [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) またはトリミング領域の削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮により保存されたラスター解像度が低下し、トリミング領域の削除は画像データを破棄します。後で高解像度の編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外部に保存しておいてください。

**SVG 画像はどう扱うべきですか？**

ベクタ の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) は直接抽出できます。PNG や JPEG などのラスター形式へのスライド エクスポートは、SVG をスライド画像の一部としてラスター化します。

**既存のスライドを読み取る際に安全でないキャストを回避するには？**

シェイプが [PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) かどうかを確認してから、PictureFrame 固有のメンバーを使用してください。`java_instanceof` チェックを行うことで無効なキャストを防ぎ、PictureFrame を含まないスライドでも安全に処理できます。
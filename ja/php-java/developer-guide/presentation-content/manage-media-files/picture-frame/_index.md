---
title: PHP を使用したプレゼンテーションの画像フレーム管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/php-java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスター画像
- ベクター画像
- 画像をトリミング
- トリミング領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションに画像フレームを追加します。ワークフローを合理化し、スライドデザインを強化します。"
---
## **概要**

画像フレームは画像を含む形状で、フレーム内の写真のようなものです。  

画像フレームを介してスライドに画像を追加できます。この方法では、画像フレームをフォーマットすることで画像をフォーマットできます。  

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ—[JPEG を PowerPoint に変換](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG を PowerPoint に変換](https://products.aspose.app/slides/ja/import/png-to-ppt) —を提供しており、画像から迅速にプレゼンテーションを作成できます。  
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [ImageCollection] に画像を追加して、シェイプの塗りつぶしに使用する [PPImage] オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトから、`addPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame] を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスのインスタンスを作成します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同等の高さと幅で画像フレームを追加します
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PPTX ファイルを書き出してディスクに保存します
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
画像フレームを使用すると、画像から迅速にプレゼンテーションスライドを作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、入力/出力操作を操作して画像を別の形式に変換できます。次のページもご覧ください: 変換 [画像を JPG に変換](https://products.aspose.com/slides/ja/php-java/conversion/image-to-jpg/); 変換 [JPG を画像に変換](https://products.aspose.com/slides/ja/php-java/conversion/jpg-to-image/); 変換 [JPG を PNG に変換](https://products.aspose.com/slides/ja/php-java/conversion/jpg-to-png/), 変換 [PNG を JPG に変換](https://products.aspose.com/slides/ja/php-java/conversion/png-to-jpg/); 変換 [PNG を SVG に変換](https://products.aspose.com/slides/ja/php-java/conversion/png-to-svg/), 変換 [SVG を PNG に変換](https://products.aspose.com/slides/ja/php-java/conversion/svg-to-png/)。  
{{% /alert %}}

## **相対スケールで画像フレームを作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。  

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [ImageCollection] に画像を追加して、シェイプの塗りつぶしに使用する [PPImage] オブジェクトを作成します。  
5. 画像フレーム内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

```php
  # PPTX を表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスのインスタンスを作成します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同等の高さと幅で画像フレームを追加します
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 相対スケールの幅と高さを設定します
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTX ファイルを書き出してディスクに保存します
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **画像フレームからラスター画像を抽出**

[PictureFrame] オブジェクトからラスター画像を抽出し、PNG、JPG、その他の形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出し、PNG 形式で保存する方法を示しています。  

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **画像フレームから SVG 画像を抽出**

プレゼンテーションに SVG グラフィックが [PictureFrame] シェイプ内に配置されている場合、Aspose.Slides for PHP via Java を使用すると、元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査することで各 [PictureFrame] を特定し、基になる [PPImage] が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。  

以下のコード例は、画像フレームから SVG 画像を抽出する方法を示しています：  

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **画像の透明度を取得**

Aspose.Slides では、画像に適用された透明度効果を取得できます。この PHP コードはその操作を示しています：  

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **画像の明るさとコントラストを取得**

Aspose.Slides では、画像に適用された明るさとコントラストの効果を取得できます。[Luminance] クラスはこの画像変換効果を表します。  

この PHP コードは、画像フレームから明るさとコントラストの設定を取得する方法を示しています：  

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。  

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [ImageCollection] に画像を追加して、シェイプの塗りつぶしに使用する [PPImage] オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [ShapeCollection] オブジェクトから、`addPictureFrame` メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正または負の値を指定して画像フレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. スライドに画像フレーム（画像を含む）を追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

```php
  # PPTX を表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスのインスタンスを作成します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同等の高さと幅で画像フレームを追加します
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameEx にいくつかの書式設定を適用します
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTX ファイルを書き出してディスクに保存します
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/ja/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/ja/collage/photo-grid) したりする必要がある場合は、このサービスを利用できます。  
{{% /alert %}}

## **画像をリンクとして追加**

プレゼンテーションのサイズが大きくなるのを防ぐために、ファイルを直接埋め込む代わりにリンクで画像（またはビデオ）を追加できます。この PHP コードは、プレースホルダーに画像とビデオを追加する方法を示しています：  

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **画像をトリミング**

この PHP コードは、スライド上の既存画像をトリミングする方法を示しています：  

```php
  $pres = new Presentation();
  # 新しい画像オブジェクトを作成します
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # スライドに PictureFrame を追加します
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # 画像をトリミングします（パーセンテージ値）
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # 結果を保存します
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **画像フレームのトリミング領域を削除**

フレームに含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元の画像を、必要な場合はトリミングされた画像を返します。  

この PHP コードはこの操作を示しています：  

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 最初のスライドから PictureFrame を取得します
    $picFrame = $slide->getShapes()->get_Item(0);
    # PictureFrame 画像のトリミング領域を削除し、トリミングされた画像を返します
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # 結果を保存します
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) メソッドは、トリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame] のみで使用されている場合、この設定によりプレゼンテーションのサイズを削減できます。そうでない場合、結果として得られるプレゼンテーションの画像数が増加します。  

このメソッドは、トリミング操作中に WMF/EMF メタファイルをラスター PNG 画像に変換します。  
{{% /alert %}}

## **画像を圧縮**

プレゼンテーション内の画像は、[PictureFillFormat::compressImage()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) メソッドを使用して圧縮できます。このメソッドは、シェイプのサイズと指定された解像度に基づいて画像のサイズを縮小し、トリミング領域を削除するオプションも提供します。  

PowerPoint の **Picture Format -> Compress Pictures -> Resolution** 機能と同様に、画像のサイズと解像度を調整します。  

以下の PHP の例は、目標解像度を指定し、必要に応じてトリミング領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています：  

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 画像を目標解像度 150 DPI（ウェブ解像度）で圧縮し、トリミング領域を削除します。
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # 圧縮の結果を確認します。
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

またはカスタム DPI 値を直接使用：  

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 画像を 150 DPI（ウェブ解像度）に圧縮し、トリミング領域を削除します。
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
このメソッドは、シェイプのサイズと指定された DPI に基づいて画像を低解像度に変換します。ファイルサイズを最適化するために、トリミング領域も削除できます。画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持または若干低下し、PowerPoint が高解像度 JPEG を処理する方法と同様です。  
{{% /alert %}}

## **アスペクト比をロック**

画像を含むシェイプのアスペクト比を、画像サイズを変更した後でも保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。  

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # リサイズ時にアスペクト比を保持するようにシェイプを設定します
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、含まれる画像のアスペクト比は保持しません。  
{{% /alert %}}

## **StretchOff プロパティを使用**

[PictureFillFormat] クラスの [setStretchOffsetLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)、[setStretchOffsetTop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)、[setStretchOffsetRight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) および [setStretchOffsetBottom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) メソッドを使用して、塗りつぶし矩形を指定できます。  

画像に対してストレッチが指定されると、元の矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット（内側）を、負のパーセンテージはアウトセット（外側）を表します。  

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 矩形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. 画像のオフセットをシェイプのバウンディングボックスの対応する辺から指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # ImageEx クラスのインスタンスを作成します
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 矩形に設定された AutoShape を追加します
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # シェイプの塗りタイプを設定します
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # シェイプの画像塗りつぶしモードを設定します
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # シェイプを塗りつぶす画像を設定します
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTX ファイルを書き出してディスクに保存します
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**PictureFrame がサポートする画像形式を確認するにはどうすればよいですか？**  
Aspose.Slides は、[PictureFrame] に割り当てられる画像オブジェクトを通じて、ラスター画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）の両方をサポートしています。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。  

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**  
大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクで追加すればプレゼンテーションのサイズを抑えることができますが、外部ファイルが引き続きアクセス可能である必要があります。Aspose.Slides は、画像をリンクで追加する機能を提供しており、ファイルサイズを削減できます。  

**画像オブジェクトが誤って移動/サイズ変更されないようにロックするにはどうすればよいですか？**  
誤って移動/サイズ変更されないようにするには、[PictureFrame] の [shape locks] を使用します（例: 移動やサイズ変更を無効にする）。このロック機構は、[PictureFrame] を含むさまざまなシェイプタイプでサポートされています。  

**プレゼンテーションを PDF や画像にエクスポートする際、SVG ベクトルの忠実度は保持されますか？**  
Aspose.Slides は、[PictureFrame] から元のベクトルとして SVG を抽出できます。[exporting to PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) や [raster formats](/slides/ja/php-java/convert-powerpoint-to-png/) では、エクスポート設定により結果がラスター化される場合がありますが、抽出動作により元の SVG がベクトルとして保存されていることが確認できます。
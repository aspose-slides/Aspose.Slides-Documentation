---
title: ピクチャーフレーム
type: docs
weight: 10
url: /php-java/picture-frame/
keywords: "ピクチャーフレームの追加、ピクチャーフレームの作成、画像の追加、画像の作成、画像の抽出、StretchOffプロパティ、ピクチャーフレームの書式設定、ピクチャーフレームのプロパティ、PowerPointプレゼンテーション、Java、Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションにピクチャーフレームを追加 "

---

ピクチャーフレームは、画像を含む形状であり、額縁に入った写真のようなものです。

ピクチャーフレームを通じてスライドに画像を追加できます。この方法では、ピクチャーフレームの書式設定により画像も書式設定できます。

{{% alert  title="ヒント" color="primary" %}}

Asposeは、ユーザーが画像から迅速にプレゼンテーションを作成できる無料コンバータ—[JPEGからPowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)および[PNGからPowerPoint](https://products.aspose.app/slides/import/png-to-ppt)を提供しています。

{{% /alert %}}

## **ピクチャーフレームの作成**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection)に画像を追加することで[IPPImage]()オブジェクトを作成し、形状を埋めるのに使用します。
4. 画像の幅と高さを指定します。
5. 参照スライドに関連する形状オブジェクトが提供する`AddPictureFrame`メソッドを通じて、画像の幅と高さに基づいて[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame)を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下のPHPコードは、ピクチャーフレームを作成する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # Imageクラスをインスタンス化
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像の等価な高さと幅のピクチャーフレームを追加
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PPTXファイルをディスクに書き込み
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}}

ピクチャーフレームを使用すると、画像に基づいてプレゼンテーションスライドを迅速に作成できます。ピクチャーフレームとAspose.Slidesの保存オプションを組み合わせることで、画像を1つの形式から別の形式に変換する入出力操作を操作できます。これらのページを参照することをお勧めします：[画像をJPGに変換](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)；[JPGを画像に変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)；[JPGをPNGに変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)；[PNGをSVGに変換](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケールでピクチャーフレームを作成**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. プレゼンテーションの画像コレクションに画像を追加します。
4. プレゼンテーションオブジェクトに関連する[IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection)に画像を追加することで[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)オブジェクトを作成し、形状を埋めるのに使用します。
5. ピクチャーフレーム内の画像の相対的な幅と高さを指定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下のPHPコードは、相対スケールでピクチャーフレームを作成する方法を示しています：

```php
  # PPTXを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # Imageクラスをインスタンス化
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像の等しい高さと幅でピクチャーフレームを追加
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 相対スケールの幅と高さを設定
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTXファイルをディスクに書き込み
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ピクチャーフレームから画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame)オブジェクトから画像を抽出し、PNG、JPG、その他の形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG形式で保存する方法を示しています。

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

## **画像の透明度を取得**

Aspose.Slidesを使用すると、画像の透明度を取得できます。このPHPコードは、その操作を示しています：

```php
  $presentation = new Presentation($folderPath . "Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("画像の透明度: " . $transparencyValue);
    }
  }
```

## **ピクチャーフレームの書式設定**

Aspose.Slidesは、ピクチャーフレームに適用できる多くの書式設定オプションを提供しています。それらのオプションを使用して、特定の要件に合うようにピクチャーフレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. プレゼンテーションオブジェクトに関連する[IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection)に画像を追加して[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)オブジェクトを作成し、形状を埋めるのに使用します。
4. 画像の幅と高さを指定します。
5. 参照スライドに関連する[IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)オブジェクトが提供する[AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)メソッドを通じて、画像の幅と高さに基づいて`PictureFrame`を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. ピクチャーフレームの線の色を設定します。
8. ピクチャーフレームの線の幅を設定します。
9. ピクチャーフレームを回転させるために、正の値または負の値を与えます。
   * 正の値は画像を時計回りに回転させます。
   * 負の値は画像を反時計回りに回転させます。
10. スライドにピクチャーフレーム（画像を含む）を追加します。
11. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下のPHPコードは、ピクチャーフレームの書式設定プロセスを示しています：

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # Imageクラスをインスタンス化
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像の等しい高さと幅でピクチャーフレームを追加
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameExにいくつかの書式設定を適用
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTXファイルをディスクに書き込み
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ヒント" color="primary" %}}

Asposeは最近、[無料コラージュメイカー](https://products.aspose.app/slides/collage)を開発しました。もし[JPG/JPEG](https://products.aspose.app/slides/collage/jpg)またはPNG画像をマージしたり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid)したりする必要がある場合は、このサービスを利用できます。

{{% /alert %}}

## **リンクとして画像を追加**

プレゼンテーションのサイズを大きくしないために、ファイルを直接埋め込むのではなく、リンクを通じて画像（または動画）を追加できます。このPHPコードは、プレースホルダーに画像と動画を追加する方法を示しています：

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

このPHPコードは、スライド上の既存の画像をトリミングする方法を示しています：

```php
  $pres = new Presentation();
  # 新しい画像オブジェクトを作成
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
    # スライドにピクチャーフレームを追加
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # 画像をトリミング（パーセンテージ値）
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # 結果を保存
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## ピクチャーのトリミングされた領域を削除

フレームに含まれる画像のトリミングされた領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)メソッドを使用できます。このメソッドは、トリミングされた画像またはトリミングが不要な場合は元の画像を返します。

このPHPコードは、その操作を示しています：

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 最初のスライドからPictureFrameを取得
    $picFrame = $slide->getShapes()->get_Item(0);
    # PictureFrame画像のトリミングされた領域を削除し、トリミングされた画像を返す
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # 結果を保存
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}}

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)メソッドは、トリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)内でのみ使用される場合、このセットアップはプレゼンテーションのサイズを減少させる可能性があります。それ以外の場合、結果のプレゼンテーション内の画像の数が増加します。

このメソッドは、トリミング操作中にWMF/EMFメタファイルをラスターPNG画像に変換します。

{{% /alert %}}

## **アスペクト比をロック**

画像を含む形状が画像の寸法を変更してもアスペクト比を保持するようにしたい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)メソッドを使用して*アスペクト比のロック*設定を行うことができます。

このPHPコードは、形状のアスペクト比をロックする方法を示しています：

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
    # リサイズ時にアスペクト比を保持するように形状を設定
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}}

この*アスペクト比のロック*設定は、形状のアスペクト比のみを保持し、含まれる画像には影響しません。

{{% /alert %}}

## **StretchOffプロパティを使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--)および[StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-)プロパティを使用すると、画像を指定した塗りつぶし矩形にスケーリングできます。

画像に対して伸縮が指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各エッジは、形状の境界ボックスの対応するエッジからの割合オフセットによって定義されます。正の百分比は内側を指定し、負の百分比は外側を指定します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 四角形の`AutoShape`を追加します。
4. 画像を作成します。
5. 形状の塗りつぶしタイプを設定します。
6. 形状のピクチャーフィルモードを設定します。
7. 形状を埋めるために画像を追加します。
8. 形状の境界ボックスの対応するエッジからの画像オフセットを指定します。
9. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下のPHPコードは、StretchOffプロパティを使用するプロセスを示しています：

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # ImageExクラスをインスタンス化
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 四角形に設定されたAutoShapeを追加
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 形状の塗りつぶしタイプを設定
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # 形状のピクチャーフィルモードを設定
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 形状を埋める画像を設定
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 形状の境界ボックスの対応するエッジからの画像オフセットを指定
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTXファイルをディスクに書き込み
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
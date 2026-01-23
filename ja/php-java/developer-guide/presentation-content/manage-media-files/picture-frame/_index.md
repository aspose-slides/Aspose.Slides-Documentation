---
title: PHP を使用したプレゼンテーションでの画像フレーム管理
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---

画像フレームは画像を含むシェイプで、フレームに入った画像のようなものです。

画像フレームを通じてスライドに画像を追加できます。この方法では、画像フレームをフォーマットすることで画像をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. シェイプの塗りつぶしに使用されるプレゼンテーション オブジェクトに関連付けられた [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) に画像を追加して、[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプ オブジェクトが提供する `addPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは画像フレームの作成方法を示します。  
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを生成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスのインスタンスを生成します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像の高さと幅に相当するピクチャーフレームを追加します
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PPTX ファイルを書き込みます
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 
画像フレームを使用すると、画像に基づいたプレゼンテーション スライドを迅速に作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像のフォーマット変換などの入出力操作を操作できます。以下のページもご参照ください：変換 [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 
{{% /alert %}} 

## **相対スケールを使用した画像フレームの作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. シェイプの塗りつぶしに使用されるプレゼンテーション オブジェクトに関連付けられた [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) に画像を追加して、[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
5. 画像フレーム内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは相対スケールを使用した画像フレームの作成方法を示します。  
```php
  # PPTX を表す Presentation クラスのインスタンスを生成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスのインスタンスを生成します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同等の高さと幅でピクチャーフレームを追加します
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 相対スケールの幅と高さを設定します
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTX ファイルを書き込みます
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出し、PNG 形式で保存する方法を示しています。  
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


## **画像フレームから SVG 画像を抽出する**

プレゼンテーションに [PictureFrame] シェイプ内に配置された SVG グラフィックが含まれている場合、Java 経由の Aspose.Slides for PHP を使用して、元のベクター画像を完全に忠実に取得できます。スライドのシェイプコレクションを走査することで、各 [PictureFrame] を特定し、基になる [PPImage] が SVG コンテンツを保持しているか確認し、元の SVG 形式でディスクまたはストリームに保存できます。

次のコード例は、画像フレームから SVG 画像を抽出する方法を示しています。  
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


## **画像の透明度を取得する**

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。この PHP コードはその操作を示しています。  
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


## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. シェイプの塗りつぶしに使用されるプレゼンテーション オブジェクトに関連付けられた [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) に画像を追加して、[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) オブジェクトが提供する [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正または負の値を指定して画像フレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. スライドに画像フレーム（画像を含む）を追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは画像フレームの書式設定プロセスを示しています。  
```php
  # PPTX を表す Presentation クラスのインスタンスを生成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスのインスタンスを生成します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同等の高さと幅でピクチャーフレームを追加します
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameEx にいくつかの書式設定を適用します
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTX ファイルを書き込みます
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}} 
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG を結合したり、PNG 画像を結合したり、写真からグリッドを作成したりする必要がある場合は、このサービスを利用できます。 
{{% /alert %}} 

## **リンクとして画像を追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを介して画像（または動画）を追加できます。この PHP コードはプレースホルダーに画像と動画を追加する方法を示しています：  
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


## **画像のトリミング**

この PHP コードはスライド上の既存画像をトリミングする方法を示しています：  
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
    # スライドにPictureFrameを追加します
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


## **画像フレームのトリミング領域を削除する**

フレームに含まれる画像のトリミング領域を削除したい場合、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元の画像を、トリミングが行われた場合はトリミングされた画像を返します。

この PHP コードはその操作を示しています：  
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 最初のスライドから PictureFrame を取得します
    $picFrame = $slide->getShapes()->get_Item(0);
    # PictureFrame の画像のトリミング領域を削除し、トリミングされた画像を返します
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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame] のみで使用されている場合、この設定によりプレゼンテーションのサイズを削減できます。そうでない場合、結果として得られるプレゼンテーションの画像数は増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのサイズを変更した後でもアスペクト比を保持したい場合、[setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) メソッドを使用して *Lock Aspect Ratio* 設定を行うことができます。

この PHP コードはシェイプのアスペクト比をロックする方法を示しています：  
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
    # リサイズ時にアスペクト比を保持するようにシェイプを設定
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 
この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプに含まれる画像のアスペクト比は保持しません。 
{{% /alert %}}

## **StretchOff プロパティを使用する**

[setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)、[setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)、[setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) および [setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) メソッド（[PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) クラス）を使用して、塗りつぶし矩形を指定できます。

画像に対してストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット（内側）を、負のパーセンテージはアウトセット（外側）を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `AutoShape` の矩形を追加します。  
4. 画像を作成します。  
5. シェイプの塗りタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは StretchOff プロパティを使用したプロセスを示しています：  
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを生成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # ImageEx クラスのインスタンスを生成します
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 矩形の AutoShape を追加します
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # シェイプの塗りつぶしタイプを設定します
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # シェイプの画像塗りつぶしモードを設定します
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # シェイプを埋める画像を設定します
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**画像フレームでサポートされている画像フォーマットはどのように確認できますか？**  
Aspose.Slides は、[PictureFrame] に割り当てられる画像オブジェクトを通じて、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクター画像（例：SVG）の両方をサポートしています。サポートされるフォーマットの一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると、PPTX のサイズやパフォーマンスにどのような影響がありますか？**  
大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクで追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はファイルサイズ削減のためにリンクで画像を追加する機能を提供しています。

**画像オブジェクトが誤って移動/サイズ変更されないようにロックするにはどうすればよいですか？**  
[shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) を使用して [PictureFrame] をロックできます（例：移動やサイズ変更を無効にする）。このロック機構は、[PictureFrame] を含むさまざまなシェイプタイプでサポートされています。

**プレゼンテーションを PDF/画像にエクスポートする際、SVG のベクターフィデリティは保持されますか？**  
Aspose.Slides は [PictureFrame] から元のベクターとして SVG を抽出できます。PDF へのエクスポートやラスタ形式へのエクスポート時は、エクスポート設定に応じて結果がラスタ化されることがありますが、元の SVG がベクターとして保存されていることは抽出動作により確認できます。
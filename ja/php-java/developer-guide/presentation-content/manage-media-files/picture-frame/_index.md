---
title: プレゼンテーションで PHP を使用して画像フレームを管理する
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
- ラスタ画像
- ベクター画像
- 画像をクロップ
- クロップ領域
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

画像フレームは画像を含むシェイプであり、フレーム内の写真のようなものです。

画像フレームを使ってスライドに画像を追加できます。この方法では、画像フレームの書式設定により画像をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料のコンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) に画像を追加して、[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `addPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この PHP コードは画像フレームの作成方法を示します:  
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
    # PPTX ファイルをディスクに保存します
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 
画像フレームを使用すると、画像に基づくプレゼンテーションスライドを迅速に作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像の形式変換などの入出力操作を操作できます。以下のページをご参照ください：画像を JPG に変換 [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); JPG を画像に変換 [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); JPG を PNG に変換 [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), PNG を JPG に変換 [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); PNG を SVG に変換 [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), SVG を PNG に変換 [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。 
{{% /alert %}}

## **相対スケールを使用した画像フレームの作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) に画像を追加して、[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
5. 画像フレーム内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この PHP コードは相対スケールを使用した画像フレームの作成方法を示します:  
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
    # PPTX ファイルをディスクに保存します
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し PNG 形式で保存する方法を示しています。  
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

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) シェイプ内部に配置された SVG グラフィックが含まれている場合、Aspose.Slides for PHP via Java は元のベクター画像を忠実に取得できます。スライドのシェイプコレクションを走査して各 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、必要に応じてディスクまたはストリームにネイティブ SVG 形式で保存します。

以下のコード例は、画像フレームから SVG 画像を抽出する方法を示しています:  
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

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。この PHP コードはその操作を示しています:  
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

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて画像フレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) に画像を追加して、[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) オブジェクトが提供する [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. 画像フレーム（画像を含む）をスライドに追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正または負の値を指定して画像フレームを回転させます。  
   * 正の値は時計回りに回転します。  
   * 負の値は反時計回りに回転します。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この PHP コードは画像フレームの書式設定プロセスを示しています:  
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
    # PPTX ファイルをディスクに保存します
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}}

Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を [結合する](https://products.aspose.app/slides/collage/jpg) 必要がある場合や、[写真からグリッドを作成する](https://products.aspose.app/slides/collage/photo-grid) 場合は、このサービスをご利用ください。 

{{% /alert %}}

## **リンクとして画像を追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを介して画像（またはビデオ）を追加できます。この PHP コードはプレースホルダーに画像とビデオを追加する方法を示しています:  
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


## **画像のクロップ**

この PHP コードはスライド上の既存画像をクロップする方法を示しています:  
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
    # 画像をクロップします（パーセンテージ値）
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


## **画像フレームのクロップ領域を削除する**

フレームに含まれる画像のクロップ領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) メソッドを使用できます。このメソッドは、クロップが不要な場合は元の画像を、クロップが必要な場合はクロップされた画像を返します。  

この PHP コードはその操作を示しています:  
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 最初のスライドから PictureFrame を取得します
    $picFrame = $slide->getShapes()->get_Item(0);
    # PictureFrame の画像のクロップ領域を削除し、クロップされた画像を返します
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

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) メソッドはクロップされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズを削減できます。そうでない場合、結果として得られるプレゼンテーションの画像数は増加します。

このメソッドはクロップ操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 

{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのアスペクト比を、画像サイズを変更した後も保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

この PHP コードはシェイプのアスペクト比をロックする方法を示しています:  
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

この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプが保持する画像のアスペクト比は保持しません。 

{{% /alert %}}

## **StretchOff プロパティの使用**

[PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) クラスの [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)、[setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)、[setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) および [setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) メソッドを使用して、塗りつぶし矩形を指定できます。

画像の伸縮が指定されると、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 矩形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この PHP コードは StretchOff プロパティを使用したプロセスを示しています:  
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
    # 四角形に設定された AutoShape を追加します
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
    # PPTX ファイルをディスクに保存します
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**画像フレームでサポートされている画像形式はどのように確認できますか？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを介して、ラスタ画像（PNG、JPEG、BMP、GIF など）およびベクター画像（例: SVG）をサポートしています。サポートされている形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？**  
大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが常にアクセス可能である必要があります。Aspose.Slides はリンク形式で画像を追加する機能を提供し、ファイルサイズの削減に役立ちます。

**画像オブジェクトが誤って移動・リサイズされないようにロックするには？**  
[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) に対して [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) を使用できます（例: 移動やリサイズの無効化）。ロック機構は別記事の [プロテクションの適用](/slides/ja/php-java/applying-protection-to-presentation/) で説明されており、さまざまなシェイプタイプ（PictureFrame を含む）でサポートされています。

**SVG ベクターの忠実度は PDF/画像 にエクスポートしたときに保持されますか？**  
Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF やラスタ形式へのエクスポート時には、エクスポート設定に応じてラスタ化される可能性がありますが、抽出動作により元の SVG がベクターとして保持されていることが確認できます。
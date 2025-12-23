---
title: PHP を使用したプレゼンテーションで画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/php-java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスタ画像
- ベクタ画像
- 画像のトリミング
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

画像フレームは画像を含む形状です—フレームに入った画像のようなものです。

画像フレームを介してスライドに画像を追加できます。この方法で、画像フレームの書式設定により画像を整形できます。

{{% alert title="ヒント" color="primary" %}} 

Aspose は無料コンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、画像からプレゼンテーションをすばやく作成できます。 

{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) に画像を追加して、[IPPImage]() オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた shape オブジェクトの `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この PHP コードは画像フレームの作成方法を示します:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスのインスタンスを作成します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同じ高さと幅でピクチャーフレームを追加します
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

画像フレームを使用すると、画像からプレゼンテーションスライドをすばやく作成できます。Aspose.Slides の保存オプションと組み合わせることで、入力/出力操作を操作して画像形式を変換できます。次のページもご参考ください: 変換 [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 

{{% /alert %}}

## **相対スケール付き画像フレームの作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) オブジェクトを作成します。  
5. 画像フレーム内の画像の相対幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この PHP コードは相対スケール付き画像フレームの作成方法を示します:
```php
  # PPTX を表す Presentation クラスをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスをインスタンス化する
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同等の高さと幅でピクチャーフレームを追加する
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 相対スケールの幅と高さを設定する
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTX ファイルをディスクに書き込む
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。
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

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 形状内に埋め込まれた SVG グラフィックが含まれる場合、Aspose.Slides for PHP via Java は元のベクター画像を完全な忠実度で取得できます。スライドの shape コレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

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

Aspose.Slides は画像に適用された透明度効果を取得できます。この PHP コードは操作を示しています:
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

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) オブジェクトの [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正の値または負の値で画像フレームを回転させます。  
   * 正の値は時計回りに回転させます。  
   * 負の値は反時計回りに回転させます。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この PHP コードは画像フレームの書式設定プロセスを示します:
```php
  # PPTX を表す Presentation クラスをインスタンス化します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # Image クラスをインスタンス化します
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 画像と同等の高さと幅でピクチャーフレームを追加します
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameEx にいくつかの書式設定を適用します
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="ヒント" color="primary" %}}

Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid) したりしたい場合にこのサービスを利用できます。 

{{% /alert %}}

## **リンクとして画像を追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクとして画像（またはビデオ）を追加できます。この PHP コードはプレースホルダーに画像とビデオを追加する方法を示します:
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


## **画像をトリミングする**

この PHP コードはスライド上の既存画像をトリミングする方法を示します:
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


## **画像フレームのトリミング領域を削除する**

フレームに含まれる画像のトリミング領域を削除したい場合は、[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元画像を返します。

この PHP コードは操作を示します:
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


{{% alert title="注" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) メソッドは、トリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションサイズを削減できます。そうでない場合、結果のプレゼンテーション内の画像数は増加します。

このメソッドは、トリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 

{{% /alert %}}

## **アスペクト比ロック**

画像を含む形状の寸法を変更してもアスペクト比を保持したい場合は、[setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) メソッドを使用して *Lock Aspect Ratio* 設定を有効にできます。

この PHP コードは形状のアスペクト比をロックする方法を示します:
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
    # リサイズ時にアスペクト比を保持するようにシェイプを設定する
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="注" color="warning" %}} 

この *Lock Aspect Ratio* 設定は形状のアスペクト比のみを保持し、含まれる画像のアスペクト比は保持しません。

{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--)、[StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) プロパティを使用して、塗りつぶし矩形を指定できます。

画像のストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、形状のバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. 形状の塗りつぶしタイプを設定します。  
6. 形状の画像塗りつぶしモードを設定します。  
7. 塗りつぶし用の画像を設定します。  
8. 形状のバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

この PHP コードは StretchOff プロパティを使用したプロセスを示します:
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
    # シェイプの塗りつぶしタイプを設定します
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # シェイプの画像塗りつぶしモードを設定します
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 画像をシェイプの塗りつぶしに設定します
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

**PictureFrame がサポートする画像形式はどれですか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じて、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能とほぼ一致します。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供しています。

**画像オブジェクトを誤って移動・サイズ変更されないようにロックするには？**

[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) を使用します（例: 移動やサイズ変更の無効化）。ロックの仕組みは別の記事 [protection article](/slides/ja/php-java/applying-protection-to-presentation/) に記載されており、さまざまな形状タイプでサポートされています。

**SVG ベクタの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF へエクスポートする場合 (/slides/ja/php-java/convert-powerpoint-to-pdf/) やラスタ形式 (/slides/ja/php-java/convert-powerpoint-to-png/) では、エクスポート設定に応じてラスタ化されることがありますが、抽出時には元の SVG がベクターとして保持されていることが確認できます。
---
title: 画像
type: docs
weight: 10
url: /ja/php-java/image/
description: PHPを使用してPowerPointプレゼンテーションのスライドで画像を扱います。ディスクまたはWebからPowerPointスライドに画像を追加します。スライドマスターやスライドの背景として画像を追加します。PHPを使用してPowerPointプレゼンテーションにSVGを追加します。PHPを使用してPowerPointでSVGを図形に変換します。PHPを使用してスライドに画像をEMFとして追加します。
---

## **プレゼンテーションのスライドにおける画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPointでは、ファイル、インターネット、または他の場所から画像をスライドに挿入できます。同様に、Aspose.Slidesを使用すると、さまざまな手順を通じてプレゼンテーションのスライドに画像を追加できます。

{{% alert title="ヒント" color="primary" %}}

Asposeは無料のコンバータ—[JPEGからPowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)と[PNGからPowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、これにより人々は画像から迅速にプレゼンテーションを作成できます。

{{% /alert %}} 

{{% alert title="情報" color="info" %}}

フレームオブジェクトとして画像を追加したい場合、特にサイズを変更したり、効果を追加したりするために標準フォーマットオプションを使用する予定がある場合は、[ピクチャーフレーム](https://docs.aspose.com/slides/php-java/picture-frame/)を参照してください。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

画像とPowerPointプレゼンテーションを含む入出力操作を操作して、画像を別のフォーマットに変換できます。次のページを参照してください：[画像をJPGに変換](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)；[JPGを画像に変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)；[JPGをPNGに変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)；[PNGをSVGに変換](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slidesは、JPEG、PNG、GIFなどの人気のあるフォーマットでの画像操作をサポートしています。

## **ローカルに保存された画像をスライドに追加する**

コンピュータ上の1つまたは複数の画像をプレゼンテーションのスライドに追加できます。このサンプルコードは、画像をスライドに追加する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Webからスライドに画像を追加する**

スライドに追加する画像がコンピュータにない場合、Webから直接画像を追加できます。

このサンプルコードは、Webからスライドに画像を追加する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[URLを置き換えてください]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スライドマスターに画像を追加する**

スライドマスターは、すべてのスライドに関する情報（テーマ、レイアウトなど）を保存し、制御する最上位のスライドです。したがって、スライドマスターに画像を追加すると、その画像はそのスライドマスターの下のすべてのスライドに表示されます。

このJavaサンプルコードは、スライドマスターに画像を追加する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スライドの背景として画像を追加する**

特定のスライドまたは複数のスライドの背景として画像を使用することを決定する場合、その場合は*[スライドの背景として画像を設定する](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*を確認する必要があります。

## **プレゼンテーションにSVGを追加する**
[addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)メソッドを使用して、プレゼンテーションに任意の画像を追加または挿入できます。このメソッドは、[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)インターフェイスに属します。

SVG画像に基づいて画像オブジェクトを作成するには、次の方法で行うことができます：

1. SvgImageオブジェクトを作成し、ImageShapeCollectionに挿入します。
2. ISvgImageからPPImageオブジェクトを作成します。
3. IPPImageインターフェイスを使用してPictureFrameオブジェクトを作成します。

このサンプルコードは、上記の手順を実装してSVG画像をプレゼンテーションに追加する方法を示しています：
```php
  # PPTXファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SVGを図形のセットに変換する**
Aspose.SlidesによるSVGから図形のセットへの変換は、SVG画像を操作するために使用されるPowerPointの機能に似ています：

![PowerPointポップアップメニュー](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)インターフェイスの[addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-)メソッドのオーバーロードの1つによって提供されており、最初の引数として[ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage)オブジェクトを取ります。

このサンプルコードは、説明されたメソッドを使用してSVGファイルを図形のセットに変換する方法を示しています：

```php
  # 新しいプレゼンテーションを作成
  $presentation = new Presentation();
  try {
    # SVGファイルの内容を読み込む
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # SvgImageオブジェクトを作成
    $svgImage = new SvgImage($svgContent);
    # スライドサイズを取得
    $slideSize = $presentation->getSlideSize()->getSize();
    # スライドサイズにスケーリングしてSVG画像を図形のグループに変換
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # プレゼンテーションをPPTX形式で保存
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **スライドにEMFとして画像を追加する**
Aspose.Slides for PHP via Javaを使用すると、ExcelシートからEMF画像を生成し、Aspose.CellsでスライドにEMFとして画像を追加できます。

このサンプルコードは、前述のタスクを実行する方法を示しています：

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # ワークブックをストリームとして保存
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="情報" color="info" %}}

Aspose無料の[テキストからGIF](https://products.aspose.app/slides/text-to-gif)コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストからGIFを作成したりできます。

{{% /alert %}}
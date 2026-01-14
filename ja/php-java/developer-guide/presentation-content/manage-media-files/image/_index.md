---
title: PHP を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/php-java/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置き換える
- 画像を置き換える
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- EMF
- SVG
- PHP
- Aspose.Slides
description: "PowerPoint と OpenDocument の画像管理を Aspose.Slides for PHP via Java で効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーション スライドの画像**

画像はプレゼンテーションをより魅力的で面白くします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides では、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ―、[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像をフレーム オブジェクトとして追加したい場合（特にサイズ変更やエフェクト適用など標準の書式設定オプションを使用する予定がある場合）は、[Picture Frame](/slides/ja/php-java/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像と PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像を別の形式に変換できます。以下のページをご覧ください：画像を [JPG に変換]((https://products.aspose.com/slides/php-java/conversion/image-to-jpg/))、[JPG を画像に変換]((https://products.aspose.com/slides/php-java/conversion/jpg-to-image/))、[JPG を PNG に変換]((https://products.aspose.com/slides/php-java/conversion/jpg-to-png/))、[PNG を JPG に変換]((https://products.aspose.com/slides/php-java/conversion/png-to-jpg/))、[PNG を SVG に変換]((https://products.aspose.com/slides/php-java/conversion/png-to-svg/))、[SVG を PNG に変換]((https://products.aspose.com/slides/php-java/conversion/svg-to-png/))。 
{{% /alert %}}

Aspose.Slides は JPEG、PNG、GIF などの一般的な形式の画像操作をサポートします。 

## **ローカルに保存された画像をスライドに追加する**

コンピューター上の画像を 1 つまたは複数、プレゼンテーションのスライドに追加できます。このサンプル コードは、画像をスライドに追加する方法を示しています：
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


## **Web から画像をスライドに追加する**

スライドに追加したい画像がコンピューターに存在しない場合、Web から直接画像を追加できます。

このサンプル コードは、Web から画像をスライドに追加する方法を示しています：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
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


## **スライド マスターに画像を追加する**

スライド マスターは、下位のすべてのスライドの情報（テーマ、レイアウトなど）を保持し制御する最上位のスライドです。したがって、スライド マスターに画像を追加すると、その画像はそのマスター配下のすべてのスライドに表示されます。

この Java サンプル コードは、スライド マスターに画像を追加する方法を示しています：
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


## **スライドの背景画像として追加する**

特定のスライドまたは複数のスライドの背景として画像を使用することができます。その場合は、[Set an Image as a Slide Background](/slides/ja/php-java/presentation-background/#set-an-image-as-a-slide-background) の方法をご確認ください。

## **SVG をプレゼンテーションに追加する**

任意の画像をプレゼンテーションに追加または挿入するには、[ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) クラスに属する [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) メソッドを使用します。

SVG 画像に基づく画像オブジェクトを作成する手順は次のとおりです：

1. SvgImage オブジェクトを作成し、ImageShapeCollection に挿入します
2. ISvgImage から PPImage オブジェクトを作成します
3. PPImage クラスを使用して PictureFrame オブジェクトを作成します

このサンプル コードは、上記の手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています：
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
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


## **SVG を図形の集合に変換する**

Aspose.Slides の SVG から図形の集合への変換は、PowerPoint の SVG 画像操作機能と同様です：

![PowerPoint ポップアップ メニュー](img_01_01.png)

この機能は、[ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) クラスの [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addgroupshape/) メソッドのオーバーロードの 1 つで提供され、最初の引数に [SvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/) オブジェクトを取ります。

このサンプル コードは、記述されたメソッドを使用して SVG ファイルを図形の集合に変換する方法を示しています：
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
    # SVG画像をスライドサイズに合わせて図形のグループに変換する
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


## **EMF 画像をスライドに追加する**

Aspose.Slides for PHP via Java は、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF として画像を追加できます。

このサンプル コードは、記述されたタスクを実行する方法を示しています：
```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # ワークブックをストリームに保存
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
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


## **画像コレクション内の画像を置き換える**

Aspose.Slides は、プレゼンテーションの画像コレクション（スライド シェイプで使用されているものを含む）に保存されている画像の置き換えを可能にします。このセクションでは、コレクション内の画像を更新する複数のアプローチを示します。API は、バイト データ、[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置き換える簡単なメソッドを提供します。

以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスを使用して画像を含むプレゼンテーション ファイルをロードします
2. ファイルから新しい画像をバイト配列にロードします
3. バイト配列を使用して対象画像を新しい画像に置き換えます
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置き換えます
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置き換えます
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("sample.pptx");
try {
    // 最初の方法。
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 二番目の方法。
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // 三番目の方法。
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // プレゼンテーションをファイルに保存します。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose FREE の [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 
{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は維持されますか？**

はい。元のピクセルは保持されますが、最終的な表示はスライド上で [picture](/slides/ja/php-java/picture-frame/) がどのようにスケーリングされるか、保存時に適用される圧縮に依存します。

**多数のスライドに同じロゴを一括で置き換える最適な方法は？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置き換えると、リソースを使用しているすべての要素に自動的に反映されます。

**挿入した SVG を編集可能な図形に変換できますか？**

はい。SVG を図形のグループに変換でき、その後個々の部品は標準の図形プロパティで編集可能になります。

**複数のスライドに同時に画像を背景として設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てれば、そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。

**画像が多数あるためにプレゼンテーションのサイズが肥大化するのを防ぐには？**

画像の重複を避けて単一リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックを配置してください。
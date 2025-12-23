---
title: PHP を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像を管理する
type: docs
weight: 10
url: /ja/php-java/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置換
- 画像を置換
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
description: "Java 経由で PHP 用 Aspose.Slides を使用し、PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化してワークフローを自動化します。"
---

## **プレゼンテーションスライドの画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイルやインターネット、その他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides を使用すると、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料のコンバータ―、[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像をフレームオブジェクトとして追加したい場合、特にサイズ変更や効果の追加などの標準書式設定オプションを使用する予定がある場合は、[Picture Frame](https://docs.aspose.com/slides/php-java/picture-frame/) を参照してください。
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像や PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像をある形式から別の形式に変換できます。以下のページをご覧ください: convert [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides は JPEG、PNG、GIF などの一般的な形式の画像操作をサポートしています。 

## **ローカルに保存された画像をスライドに追加**

コンピューター上の画像を 1 枚または複数枚、プレゼンテーションのスライドに追加できます。このサンプルコードは、画像をスライドに追加する方法を示しています：
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


## **Web から画像をスライドに追加**

スライドに追加したい画像がコンピューターに無い場合、Web から直接画像を追加できます。 

このサンプルコードは、Web から画像をスライドに追加する方法を示しています：
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


## **スライドマスターに画像を追加**

スライドマスターは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を保存・管理する最上位のスライドです。そのため、スライドマスターに画像を追加すると、その画像はそのマスター配下のすべてのスライドに表示されます。 

この Java サンプルコードは、スライドマスターに画像を追加する方法を示しています：
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


## **スライドの背景として画像を追加**

特定のスライドまたは複数のスライドの背景として画像を使用することができます。その場合は、*[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

任意の画像をプレゼンテーションに追加または挿入するには、[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) インターフェイスに属する [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用できます。

SVG 画像を基に画像オブジェクトを作成する方法は次のとおりです。

1. SvgImage オブジェクトを作成し、ImageShapeCollection に挿入する  
2. ISvgImage から PPImage オブジェクトを作成する  
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成する  

このサンプルコードは、上記の手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています：
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
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


## **SVG を形状セットに変換**

Aspose.Slides の SVG を形状セットに変換する機能は、SVG 画像を操作するための PowerPoint の機能と同様です：

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) インターフェイスの [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードの一つによって提供され、最初の引数に [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) オブジェクトを取ります。

このサンプルコードは、記述されたメソッドを使用して SVG ファイルを形状セットに変換する方法を示しています：
```php
  # 新しいプレゼンテーションを作成
  $presentation = new Presentation();
  try {
    # SVG ファイルの内容を読み込む
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

    # SvgImage オブジェクトを作成
    $svgImage = new SvgImage($svgContent);
    # スライドサイズを取得
    $slideSize = $presentation->getSlideSize()->getSize();
    # SVG 画像をスライドサイズに合わせて形状のグループに変換
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # プレゼンテーションを PPTX 形式で保存
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **画像を EMF としてスライドに追加**

Aspose.Slides for PHP via Java を使用すると、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF 画像として追加できます。 

このサンプルコードは、上述のタスクを実行する方法を示しています：
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


## **画像コレクション内の画像を置換**

Aspose.Slides は、プレゼンテーションの画像コレクション（スライド形状で使用されているものを含む）に保存されている画像を置換できます。このセクションでは、コレクション内の画像を更新するための複数のアプローチを示します。API は、バイト データ、[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換するシンプルなメソッドを提供します。

以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルをロードします。  
2. ファイルから新しい画像をバイト配列にロードします。  
3. バイト配列を使用して対象画像を新しい画像に置換します。  
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。  
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。  
6. 変更済みのプレゼンテーションを PPTX ファイルとして書き出します。  
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
$presentation = new Presentation("sample.pptx");
try {
    // 最初の方法。
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 2 番目の方法。
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // 3 番目の方法。
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

## **よくある質問**

**画像を挿入した後でも元の解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/php-java/picture-frame/) がどのようにスケーリングされるか、および保存時に適用される圧縮に依存します。

**数十枚のスライドで同じロゴを一度に置き換える最善の方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクション内で置換します。これにより、そのリソースを使用しているすべての要素に変更が反映されます。

**挿入した SVG は編集可能な形状に変換できますか？**

はい。SVG を形状のグループに変換でき、その後、個々のパーツは標準の形状プロパティで編集可能になります。

**複数のスライドの背景として画像を一括で設定するにはどうすればよいですか？**

マスタースライドまたは該当するレイアウトで [Assign the image as the background](/slides/ja/php-java/presentation-background/) を設定します。これを使用するスライドはすべてその背景を継承します。

**多数の画像によりプレゼンテーションのサイズが膨張するのを防ぐにはどうすればよいですか？**

重複した画像の代わりに単一の画像リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、繰り返し使用するグラフィックは可能な限りマスターに配置してください。
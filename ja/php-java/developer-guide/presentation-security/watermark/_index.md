---
title: ウォーターマーク
type: docs
weight: 40
url: /ja/php-java/watermark/
keywords:
- ウォーターマーク
- ウォーターマークを追加
- テキストウォーターマーク
- 画像ウォーターマーク
- PowerPoint
- プレゼンテーション
- PHP
- Java
- Aspose.Slides for PHP via Java
description: "PHPでPowerPointプレゼンテーションにテキストおよび画像のウォーターマークを追加する"
---

## **ウォーターマークについて**

**ウォーターマーク**は、プレゼンテーションのスライドまたはすべてのプレゼンテーションスライドに使用されるテキストまたは画像のスタンプです。一般的に、ウォーターマークはプレゼンテーションが草案であることを示すため（例：「草案」ウォーターマーク）、機密情報が含まれていることを示すため（例：「機密」ウォーターマーク）、どの会社に属するかを特定するため（例：「会社名」ウォーターマーク）、プレゼンテーションの作者を識別するためなどに使用されます。ウォーターマークは、プレゼンテーションがコピーされるべきではないことを示すことによって著作権の侵害を防ぐ手助けをします。ウォーターマークは、PowerPointおよびOpenOfficeプレゼンテーションフォーマットの両方で使用されます。Aspose.Slidesを使用すると、PowerPoint PPT、PPTX、およびOpenOffice ODPファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/php-java/) では、PowerPointまたはOpenOfficeドキュメントにウォーターマークを作成し、そのデザインや動作を変更するさまざまな方法があります。共通の側面は、テキストウォーターマークを追加するには [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) クラスを使用し、画像ウォーターマークを追加するには [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) クラスを使用するか、ウォーターマークシェイプを画像で塗りつぶすことです。`PictureFrame` は [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスを実装しており、シェイプオブジェクトのすべての柔軟な設定を使用できます。`ITextFrame` はシェイプではなく、その設定は制限されているため、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) オブジェクトにラップされています。

ウォーターマークは、単一のスライドに適用する方法と、すべてのプレゼンテーションスライドに適用する方法の2つがあります。スライドマスターを使用して、すべてのプレゼンテーションスライドにウォーターマークを適用します。ウォーターマークはスライドマスターに追加され、そこで完全にデザインされ、個別のスライドのウォーターマークを変更する権限に影響を与えることなく、すべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーによる編集ができないと見なされます。ウォーターマーク（またはウォーターマークの親シェイプ）の編集を防ぐために、Aspose.Slidesはシェイプロック機能を提供します。特定のシェイプは、通常のスライドまたはスライドマスターでロックできます。スライドマスターでウォーターマークシェイプがロックされると、すべてのプレゼンテーションスライドでロックされます。

ウォーターマークに名前を付けておくことで、将来的に削除したい場合は、スライドのシェイプ内で名前で見つけることができます。

ウォーターマークは自由にデザインできますが、通常は中心揃え、回転、前面位置などの共通の特徴があります。以下の例でこれらを使用する方法を考慮します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、およびODPにテキストウォーターマークを追加するには、まずスライドにシェイプを追加し、その後このシェイプにテキストフレームを追加します。テキストフレームは [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) クラスで表されます。このタイプは、柔軟な方法でウォーターマークの位置を決定するための広範なプロパティを持つ [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) からは継承されません。したがって、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) オブジェクトは [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) オブジェクトにラップされます。シェイプにウォーターマークテキストを追加するには、以下のように [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) メソッドを使用します。

```php
$watermarkText = "機密";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="関連情報" %}} 
- [TextFrameクラスの使い方](/slides/ja/php-java/text-formatting/)
{{% /alert %}}

### **プレゼンテーションにテキストウォーターマークを追加する**

プレゼンテーション全体（つまり、すべてのスライドに一度に）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) に追加します。残りのロジックは、単一のスライドにウォーターマークを追加する場合と同じで、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) オブジェクトを作成し、[addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) メソッドを使用してそれにウォーターマークを追加します。

```php
$watermarkText = "機密";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="関連情報" %}} 
- [スライドマスターの使い方](/slides/ja/php-java/slide-master/)
{{% /alert %}}

### **ウォーターマークシェイプの透明度を設定する**

デフォルトでは、長方形シェイプには塗りつぶしと線の色がスタイルされています。次のコード行でシェイプを透明にします。

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **テキストウォーターマークのフォントを設定する**

以下のように、テキストウォーターマークのフォントを変更できます。

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **ウォーターマークテキストの色を設定する**

ウォーターマークテキストの色を設定するには、以下のコードを使用します。

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **テキストウォーターマークを中央揃えにする**

ウォーターマークをスライドの中央に配置することが可能です。そのためには、以下の操作を行います。

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

以下の画像は最終結果を示しています。

![テキストウォーターマーク](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションスライドに画像ウォーターマークを追加するには、以下のようにします。

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

## **編集からウォーターマークをロックする**

ウォーターマークの編集を防ぐ必要がある場合は、シェイプに対して [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) メソッドを使用します。このプロパティを使用することで、シェイプが選択、サイズ変更、再配置、他の要素とのグループ化、テキストの編集をロックすることができます。

```php
// ウォーターマークシェイプを変更不可にロックする
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **ウォーターマークを前面に持ってくる**

Aspose.Slidesでは、シェイプのZ順序を [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) メソッドを介して設定できます。これを行うには、プレゼンテーションのスライドリストからこのメソッドを呼び出し、シェイプの参照とその順序番号をメソッドに渡す必要があります。この方法により、シェイプを前面に持ってくることやスライドの背面に送ることができます。この機能は、プレゼンテーションの前面にウォーターマークを配置する必要がある場合に特に便利です。

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **ウォーターマークの回転を設定する**

ウォーターマークをスライドに対して斜めに配置するための回転を調整する方法のコード例は以下の通りです。

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **ウォーターマークに名前を付ける**

Aspose.Slidesでは、シェイプの名前を設定できます。シェイプ名を使用することで、将来的にそれにアクセスして変更または削除することができます。ウォーターマークシェイプの名前を設定するには、[AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) メソッドに割り当てます。

```php
$watermarkShape->setName("watermark");
```

## **ウォーターマークを削除する**

ウォーターマークシェイプを削除するには、[AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) メソッドを使用してそれをスライドシェイプで見つけます。その後、ウォーターマークシェイプを [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) メソッドに渡します。

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **ライブ例**

**Aspose.Slides無料**[ウォーターマークを追加](https://products.aspose.app/slides/watermark)および[ウォーターマークを削除](https://products.aspose.app/slides/watermark/remove-watermark)オンラインツールを確認することをお勧めします。

![ウォーターマークの追加および削除のためのオンラインツール](online_tools.png)
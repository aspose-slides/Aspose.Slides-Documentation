---
title: "PHPでプレゼンテーションにウォーターマークを追加する"
linktitle: "ウォーターマーク"
type: docs
weight: 40
url: /ja/php-java/watermark/
keywords:
- ウォーターマーク
- テキストウォーターマーク
- 画像ウォーターマーク
- ウォーターマークを追加
- ウォーターマークを変更
- ウォーターマークを削除
- ウォーターマークを削除
- PPTにウォーターマークを追加
- PPTXにウォーターマークを追加
- ODPにウォーターマークを追加
- PPTからウォーターマークを削除
- PPTXからウォーターマークを削除
- ODPからウォーターマークを削除
- PPTからウォーターマークを削除
- PPTXからウォーターマークを削除
- ODPからウォーターマークを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHPでPowerPointおよびOpenDocumentプレゼンテーションのテキストと画像のウォーターマークを管理し、ドラフト、機密情報、著作権などを示すことができます。"
---

## **ウォーターマークについて**

**ウォーターマーク**はプレゼンテーションのスライドまたは全スライドで使用されるテキストまたは画像のスタンプです。通常、ドラフト（例：`"Draft"` ウォーターマーク）であること、機密情報（例：`"Confidential"` ウォーターマーク）を含むこと、所属会社（例：`"Company Name"` ウォーターマーク）を示すこと、プレゼンテーションの作者を識別することなどに使用されます。ウォーターマークは、コピーすべきでないことを示すことで著作権侵害を防止するのに役立ちます。ウォーターマークは PowerPoint と OpenOffice の両方のプレゼンテーション形式で使用されます。Aspose.Slides では、PowerPoint の PPT、PPTX、OpenOffice の ODP ファイル形式にウォーターマークを追加できます。

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/)、さまざまな方法で PowerPoint または OpenOffice ドキュメントにウォーターマークを作成し、デザインや動作を変更できます。共通点は、テキスト ウォーターマークを追加するには [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) クラスを使用し、画像 ウォーターマークを追加するには [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) クラスを使用するか、ウォーターマーク形状に画像を設定することです。`PictureFrame` は [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスを実装しており、形状オブジェクトのすべての柔軟な設定を利用できます。`ITextFrame` は形状ではなく設定が制限されているため、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) オブジェクトにラップされます。

ウォーターマークの適用方法は 2 つあります。単一スライドに対して適用するか、プレゼンテーション全体のスライドに対して適用するかです。スライド マスターを使用すると、ウォーターマークをすべてのスライドに適用できます。ウォーターマークはスライド マスターに追加され、そこで完全にデザインされ、個々のスライドのウォーターマーク編集権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーが編集できないものと見なされます。ウォーターマーク（正確にはウォーターマークの親形状）の編集を防止するために、Aspose.Slides は形状のロック機能を提供します。特定の形状は通常のスライドまたはスライド マスター上でロックできます。スライド マスター上でウォーターマーク形状がロックされている場合、すべてのスライドでロックされた状態になります。

ウォーターマークに名前を設定すると、将来削除したいときにスライドの形状コレクションから名前で検索できます。

ウォーターマークは任意の方法でデザインできますが、中心揃え、回転、前面表示など、一般的な特徴がよく使われます。以下の例でこれらの使用方法を検討します。

## **テキスト ウォーターマーク**

### **スライドにテキスト ウォーターマークを追加する**

PPT、PPTX、または ODP でテキスト ウォーターマークを追加するには、まずスライドに形状を追加し、その形状にテキスト フレームを追加します。テキスト フレームは [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) クラスで表されます。この型は [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) から継承されておらず、柔軟な位置指定プロパティがありません。そのため、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) オブジェクトは [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) オブジェクトにラップされます。形状にウォーターマークテキストを追加するには、以下のように [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) メソッドを使用します。
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="こちらも参照" %}} 
- [TextFrame クラスの使用方法](/slides/ja/php-java/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキスト ウォーターマークを追加する**

プレゼンテーション全体（すべてのスライド）にテキスト ウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) に追加します。ロジックは単一スライドに追加する場合と同じです。まず [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) オブジェクトを作成し、次に [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) メソッドでウォーターマークを追加します。
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="こちらも参照" %}} 
- [スライド マスターの使用方法](/slides/ja/php-java/slide-master/)
{{% /alert %}}

### **ウォーターマーク形状の透明度を設定する**

既定では矩形形状に塗りつぶしと線の色が設定されています。以下のコードで形状を透明にします。
```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```


### **テキスト ウォーターマークのフォントを設定する**

以下のようにテキスト ウォーターマークのフォントを変更できます。
```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```


### **ウォーターマーク テキストの色を設定する**

ウォーターマーク テキストの色を設定するには、次のコードを使用します。
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


### **テキスト ウォーターマークを中央揃えにする**

スライド上でウォーターマークを中央に配置するには、以下の手順を実行します。
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

## **画像 ウォーターマーク**

### **プレゼンテーションに画像 ウォーターマークを追加する**

プレゼンテーションのスライドに画像 ウォーターマークを追加するには、次の手順を実行します。
```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```


### **ウォーターマークの編集をロックする**

ウォーターマークの編集を防止する必要がある場合は、形状に対して [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) メソッドを使用します。このプロパティにより、形状の選択、サイズ変更、位置変更、他の要素とのグループ化、テキストの編集ロックなどを保護できます。
```php
// ウォーターマーク形状が変更されないようにロックする
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```


### **ウォーターマークを前面に持ってくる**

Aspose.Slides では、形状の Z 順序を [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、形状参照と順序番号を渡します。これにより、形状を前面または背面に移動できます。この機能は、プレゼンテーションの前面にウォーターマークを配置したい場合に特に有用です。
```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```


### **ウォーターマークの回転を設定する**

以下は、ウォーターマークをスライド全体に対して対角線上に配置するために回転角度を調整するコード例です。
```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```


### **ウォーターマークに名前を設定する**

Aspose.Slides では形状に名前を設定できます。形状名を使用すると、将来その形状にアクセスして変更または削除できます。ウォーターマーク形状の名前を設定するには、[AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) メソッドを使用します。
```php
$watermarkShape->setName("watermark");
```


### **ウォーターマークを削除する**

ウォーターマーク形状を削除するには、[AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) メソッドでスライドの形状から名前を取得し、[ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) メソッドに渡します。
```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```


## **FAQ**

**ウォーターマークとは何ですか、なぜ使用すべきですか？**

ウォーターマークはスライドに適用されるテキストまたは画像のオーバーレイで、知的財産の保護、ブランド認知の向上、プレゼンテーションの不正使用防止に役立ちます。

**プレゼンテーションのすべてのスライドにウォーターマークを追加できますか？**

はい、Aspose.Slides を使用すると、プログラムでプレゼンテーションのすべてのスライドにウォーターマークを追加できます。すべてのスライドを反復処理して個別にウォーターマーク設定を適用できます。

**ウォーターマークの透明度はどう調整しますか？**

形状の塗りつぶし設定（[getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getfillformat/)）を変更することで、ウォーターマークの透明度を調整できます。これにより、ウォーターマークが控えめになり、スライドの内容の妨げになりません。

**どの画像形式がウォーターマークに対応していますか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などのさまざまな画像形式に対応しています。

**テキスト ウォーターマークのフォントやスタイルはカスタマイズできますか？**

はい、フォント、サイズ、スタイルを自由に選択してプレゼンテーションのデザインやブランドの一貫性に合わせることができます。

**ウォーターマークの位置や向きはどう変更しますか？**

形状の座標、サイズ、回転プロパティをプログラムで変更することで、ウォーターマークの位置や向きを調整できます。
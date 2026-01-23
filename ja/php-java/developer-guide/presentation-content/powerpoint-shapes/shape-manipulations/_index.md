---
title: PHPでプレゼンテーションのシェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/php-java/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン作成
- シェイプの削除
- シェイプの非表示
- シェイプの順序変更
- Interop シェイプ ID の取得
- シェイプの代替テキスト
- シェイプのレイアウト形式
- SVG としてのシェイプ
- シェイプを SVG に変換
- シェイプの配置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でシェイプを作成、編集、最適化し、高性能な PowerPoint プレゼンテーションを提供する方法を学びます。"
---

## **スライド上のシェイプを見つける**
このトピックでは、開発者が内部 ID を使用せずにスライド上の特定のシェイプを見つけやすくするシンプルな手法を説明します。PowerPoint プレゼンテーション ファイルでは、内部の一意な ID 以外にスライド上のシェイプを識別する方法がありません。内部の一意な ID を使用してシェイプを見つけるのは開発者にとって困難なことがあるようです。スライドに追加されたすべてのシェイプには Alt Text が設定されています。開発者には、特定のシェイプを見つけるために代替テキストを使用することを推奨します。将来変更する予定のオブジェクトに対して、MS PowerPoint を使用して代替テキストを定義できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for PHP via Java を使用してそのプレゼンテーションを開き、スライドに追加されたすべてのシェイプを走査できます。各イテレーションでシェイプの代替テキストを確認し、代替テキストが一致するシェイプが目的のシェイプとなります。この手法をより分かりやすく示すために、スライド内の特定のシェイプを見つけてそのシェイプを返すメソッド [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) を作成しました。
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成する
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 見つけるシェイプの代替テキスト
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **シェイプのクローン作成**
Aspose.Slides for PHP via Java を使用してスライドにシェイプをクローンするには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. 元スライドのシェイプ コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. 元スライドのシェイプ コレクションから新しいスライドへシェイプをクローンします。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加します。
```php
  # Presentation クラスをインスタンス化する
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # PPTX ファイルをディスクに保存する
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの削除**
Aspose.Slides for PHP via Java は、開発者が任意のシェイプを削除できるようにします。スライドからシェイプを削除するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを削除します。
1. ファイルをディスクに保存します。
```php
  # Presentation オブジェクトを作成する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプのオートシェイプを追加する
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # プレゼンテーションをディスクに保存する
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの非表示**
Aspose.Slides for PHP via Java は、開発者が任意のシェイプを非表示にできるようにします。スライドからシェイプを非表示にするには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。
```php
  # PPTX を表す Presentation クラスをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプのオートシェイプを追加する
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # プレゼンテーションをディスクに保存する
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの順序変更**
Aspose.Slides for PHP via Java は、開発者がシェイプの順序を変更できるようにします。シェイプの順序変更は、どのシェイプが前面にあるか、背面にあるかを指定します。スライド上でシェイプの順序を変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキスト フレームにテキストを追加します。
1. 同じ座標で別のシェイプを追加します。
1. シェイプの順序を変更します。
1. ファイルをディスクに保存します。
```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Interop シェイプ ID の取得**
Aspose.Slides for PHP via Java は、スライドスコープ内で一意なシェイプ識別子を取得できるようにします。これは、プレゼンテーションスコープで一意な識別子を取得できる [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/) メソッドとは対照的です。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) メソッドが [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスに追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) メソッドが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # スライドスコープ内での一意なシェイプ識別子を取得
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの代替テキストの設定**
Aspose.Slides for PHP via Java は、開発者が任意のシェイプの AlternateText を設定できるようにします。プレゼンテーション内のシェイプは `Alternative Text` または [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) メソッドで区別できます。[setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) と [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) メソッドは、Aspose.Slides および Microsoft PowerPoint の両方で読み書きできます。このメソッドを使用すると、シェイプにタグを付け、シェイプの削除、非表示、スライド上での順序変更などのさまざまな操作を実行できます。シェイプの AlternateText を設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 任意のシェイプをスライドに追加します。
1. 追加したシェイプで作業を行います。
1. シェイプを走査して目的のシェイプを見つけます。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```php
  # PPTX を表す Presentation クラスをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプのオートシェイプを追加する
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # プレゼンテーションをディスクに保存する
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプのレイアウト形式へのアクセス**
Aspose.Slides for PHP via Java は、シェイプのレイアウト形式にアクセスするためのシンプルな API を提供します。この記事では、レイアウト形式へのアクセス方法を示します。

以下にサンプルコードが示されています。
```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプを SVG としてレンダリング**
現在、Aspose.Slides for PHP via Java はシェイプを SVG としてレンダリングする機能をサポートしています。[writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) メソッド（およびそのオーバーロード）が [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスに追加されました。このメソッドにより、シェイプの内容を SVG ファイルとして保存できます。以下のコード スニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示しています。
```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの配置**
Aspose.Slides は、シェイプをスライドの余白に対して、または互いに対して配置することができます。そのために、オーバーロードされたメソッド [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/) が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) 列挙体は、可能な配置オプションを定義します。

**例 1**
以下のサンプルコードは、インデックス 1、2、4 のシェイプをスライドの上端に合わせます。
```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**例 2**
以下の例は、コレクション内の最下部シェイプに対してコレクション全体を配置する方法を示しています。
```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **フリップ プロパティ**
Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) クラスが `flipH` と `flipV` プロパティを介してシェイプの水平・垂直ミラーリングを制御します。これらのプロパティは [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 型で、`True` はフリップ、`False` はフリップなし、`NotDefined` はデフォルト動作を示します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) から取得できます。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、希望する `flipH` と `flipV` の値、回転角度を使用して新しい [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) インスタンスを作成します。そのインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) に割り当て、プレゼンテーションを保存すると、ミラー変換が適用され出力ファイルに反映されます。

たとえば、最初のスライドにデフォルトのフリップ設定の単一シェイプが含まれる sample.pptx ファイルがあるとします。以下に示す通りです。

![The shape to be flipped](shape_to_be_flipped.png)

以下のコード例は、シェイプの現在のフリッププロパティを取得し、水平および垂直にフリップします。
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // シェイプの水平フリップ プロパティを取得します。
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // シェイプの垂直フリップ プロパティを取得します。
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // 水平にフリップします。
    $flipV = NullableBool::True; // 水平にフリップします。
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![The flipped shape](flipped_shape.png)

## **FAQ**
**スライド上でデスクトップエディタのようにシェイプを結合（union/intersect/subtract）できますか？**
組み込みのブール演算 API はありません。目的のアウトラインを自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しいシェイプを作成し、元のシェイプをオプションで削除します。

**シェイプのスタック順序（z-order）を制御して常に「最上部」に表示させるには？**
スライドの [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) コレクション内で挿入または移動の順序を変更します。予測可能な結果を得るために、他のすべてのスライド変更が完了した後に z-order を確定してください。

**PowerPoint でユーザーがシェイプを編集できないように「ロック」できますか？**
はい。シェイプレベルの保護フラグ（例: 選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロック）を設定します。必要に応じて、マスタやレイアウト上でも同様の制限を適用できます。これは UI レベルの保護でありセキュリティ機能ではありません。より強力な保護が必要な場合は、[read-only recommendations or passwords](/slides/ja/php-java/password-protected-presentation/) などのファイルレベルの制限と組み合わせてください。
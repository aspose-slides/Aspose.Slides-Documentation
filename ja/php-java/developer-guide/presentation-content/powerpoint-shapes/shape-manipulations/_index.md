---
title: PHPでプレゼンテーションのシェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/php-java/shape-manipulations/
keywords:
- PowerPointシェイプ
- プレゼンテーションシェイプ
- スライド上のシェイプ
- シェイプを検索
- シェイプをクローン
- シェイプを削除
- シェイプを非表示
- シェイプの順序変更
- InteropシェイプID取得
- シェイプ代替テキスト
- シェイプレイアウト形式
- SVGとしてのシェイプ
- シェイプをSVGに変換
- シェイプの整列
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Javaでシェイプを作成、編集、最適化し、高性能なPowerPointプレゼンテーションを提供する方法を学びましょう。"
---

## **スライド上のシェイプを検索する**
このトピックでは、開発者が内部IDを使用せずにスライド上の特定のシェイプを簡単に見つけるためのシンプルな手法について説明します。PowerPointプレゼンテーション ファイルは、内部の一意なID以外でスライド上のシェイプを識別する手段がないことを理解することが重要です。内部の一意なIDを使用してシェイプを見つけるのは開発者にとって難しいようです。スライドに追加されたすべてのシェイプには Alt Text が設定されています。特定のシェイプを見つけるために代替テキストの使用を推奨します。将来変更する予定のオブジェクトの代替テキストは、MS PowerPoint で定義できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for PHP via Java を使用してそのプレゼンテーションを開き、スライドに追加されたすべてのシェイプを反復処理できます。各イテレーションでシェイプの代替テキストをチェックし、一致する代替テキストを持つシェイプが目的のシェイプとなります。この手法をより分かりやすく示すために、スライド内の特定のシェイプを見つけて単に返すメソッド[findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) を作成しました。
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 検索対象シェイプの代替テキスト
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


## **シェイプをクローンする**
Aspose.Slides for PHP via Java を使用してシェイプをスライドにクローンするには:
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドのシェイプコレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドのシェイプコレクションから新しいスライドへシェイプをクローンします。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループシェイプを追加します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # PPTX ファイルをディスクに保存
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプを削除する**
Aspose.Slides for PHP via Java は開発者が任意のシェイプを削除できるようにします。スライドからシェイプを削除するには、以下の手順に従ってください：
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを削除します。
1. ファイルをディスクに保存します。
```php
  # Presentation オブジェクトを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプのオートシェイプを追加
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
    # プレゼンテーションをディスクに保存
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプを非表示にする**
Aspose.Slides for PHP via Java は開発者が任意のシェイプを非表示にできるようにします。スライドからシェイプを非表示にするには、以下の手順に従ってください：
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。
```php

  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプのオートシェイプを追加
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
    # プレゼンテーションをディスクに保存
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの順序を変更する**
Aspose.Slides for PHP via Java は開発者がシェイプの順序を変更できるようにします。シェイプの順序変更により、どのシェイプが前面に、どのシェイプが背面にあるかを指定できます。スライド上のシェイプの順序を変更するには、以下の手順に従ってください：
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキストフレームにテキストを追加します。
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


## **Interop シェイプ ID を取得する**
Aspose.Slides for PHP via Java は開発者がプレゼンテーション全体のスコープで一意な ID を取得できる [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/) メソッドとは対照的に、スライドスコープで一意なシェイプ識別子を取得できるようにします。メソッド [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) が [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスに追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) メソッドが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # スライド スコープでの一意なシェイプ識別子の取得
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの代替テキストを設定する**
Aspose.Slides for PHP via Java は開発者が任意のシェイプの AlternateText を設定できるようにします。プレゼンテーション内のシェイプは `Alternative Text` または [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) メソッドで区別できます。[setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) と [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) メソッドは Aspose.Slides と Microsoft PowerPoint の両方で読み書きできます。このメソッドを使用すると、シェイプにタグ付けでき、シェイプの削除、非表示、スライド上のシェイプの順序変更などのさまざまな操作を実行できます。シェイプの AlternateText を設定するには、以下の手順に従ってください：
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意のシェイプを追加します。
1. 新しく追加したシェイプで何らかの作業を行います。
1. シェイプを走査してシェイプを見つけます。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプのオートシェイプを追加
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
    # プレゼンテーションをディスクに保存
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプのレイアウト形式にアクセスする**
Aspose.Slides for PHP via Java はシェイプのレイアウト形式にアクセスするためのシンプルな API を提供します。この記事では、レイアウト形式へのアクセス方法を示します。

以下にサンプルコードを示します。
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


## **シェイプを SVG としてレンダリングする**
現在、Aspose.Slides for PHP via Java はシェイプを SVG としてレンダリングする機能をサポートしています。[writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) メソッド（およびそのオーバーロード）が [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスに追加されました。このメソッドにより、シェイプの内容を SVG ファイルとして保存できます。以下のコードスニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示しています。
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


## **シェイプを整列する**
Aspose.Slides はシェイプをスライドの余白に対してまたは互いに対して整列させることができます。そのために、オーバーロードされたメソッド [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/) が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) 列挙体は利用可能な整列オプションを定義します。

**例 1**
以下のソースコードは、インデックス 1、2、4 のシェイプをスライドの上端に沿って整列させます。
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
以下の例は、コレクション内の最下位シェイプに対して全シェイプコレクションを整列させる方法を示しています。
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
Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) クラスが `flipH` および `flipV` プロパティを通じてシェイプの水平・垂直ミラーリングを制御します。両プロパティは [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 型で、`True` はフリップ、`False` はフリップなし、`NotDefined` はデフォルト動作を示します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) から取得可能です。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、希望する `flipH` および `flipV` の値、回転角度を指定して新しい [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) に割り当ててプレゼンテーションを保存すると、ミラー変換が適用され、出力ファイルに反映されます。

たとえば、sample.pptx の最初のスライドにデフォルトのフリップ設定を持つ単一のシェイプが含まれているとします。以下に示す通りです。

![The shape to be flipped](shape_to_be_flipped.png)

以下のコード例は、シェイプの現在のフリッププロパティを取得し、水平・垂直の両方でフリップします。
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // シェイプの水平フリッププロパティを取得します。
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // シェイプの垂直フリッププロパティを取得します。
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


## **よくある質問**
**スライド上でデスクトップ エディタのようにシェイプを結合（union/intersect/subtract）できますか？**
組み込みのブーリアン演算 API はありません。目的の輪郭を自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しいシェイプを作成し、元のシェイプをオプションで削除します。

**シェイプが常に「最前面」にあるように、スタック順（z-order）を制御するにはどうすればよいですか？**
スライドの [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) コレクション内で挿入/移動順序を変更します。予測可能な結果を得るには、他のすべてのスライド変更を終えた後で z-order を最終決定します。

**ユーザーが PowerPoint でシェイプを編集できないように「ロック」できますか？**
はい。[shape-level protection flags](/slides/ja/php-java/applying-protection-to-presentation/)（例：選択、移動、サイズ変更、テキスト編集のロック）を設定します。必要に応じて、マスターやレイアウトにも同様の制限を適用できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強固な保護が必要な場合は、[読み取り専用推奨やパスワード](/slides/ja/php-java/password-protected-presentation/) のようなファイルレベルの制限と組み合わせて使用してください。
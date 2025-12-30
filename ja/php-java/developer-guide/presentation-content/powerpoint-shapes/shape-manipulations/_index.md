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
- シェイプの検索
- シェイプのクローン
- シェイプの削除
- シェイプの非表示
- シェイプ順序の変更
- InteropシェイプIDの取得
- シェイプ代替テキスト
- シェイプのレイアウト形式
- シェイプをSVGとして
- シェイプをSVGへ
- シェイプの配置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してシェイプの作成、編集、最適化を学び、高性能な PowerPoint プレゼンテーションを提供します。"
---

## **スライド上でシェイプを見つける**
このトピックでは、開発者が内部 ID を使用せずにスライド上の特定のシェイプを見つけやすくするシンプルな手法について説明します。PowerPoint プレゼンテーション ファイルでは、スライド上のシェイプを識別する手段は内部の一意な ID だけであることを理解しておくことが重要です。開発者が内部の一意な ID を使用してシェイプを見つけるのは難しいようです。スライドに追加されたすべてのシェイプには Alt テキストが設定されています。特定のシェイプを見つけるために代替テキストの使用を推奨します。将来的に変更する予定のオブジェクトの代替テキストは、MS PowerPoint で定義できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for PHP via Java を使用してそのプレゼンテーションを開き、スライドに追加されたすべてのシェイプを反復処理できます。各反復でシェイプの代替テキストを確認し、代替テキストが一致するシェイプが目的のシェイプとなります。この手法をより分かりやすく示すために、スライド内の特定のシェイプを見つけてそのシェイプを返す[findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)メソッドを作成しました。
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 検索対象のシェイプの代替テキスト
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

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. ソーススライドのシェイプ コレクションにアクセスします。
4. プレゼンテーションに新しいスライドを追加します。
5. ソーススライドのシェイプ コレクションから新しいスライドへシェイプをクローンします。
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加します。
```php
  # Presentation クラスのインスタンスを作成する
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


## **シェイプを削除する**
Aspose.Slides for PHP via Java は、開発者が任意のシェイプを削除できるようにします。任意のスライドからシェイプを削除するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 特定の AlternativeText を持つシェイプを検索します。
4. シェイプを削除します。
5. ファイルをディスクに保存します。
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


## **シェイプを非表示にする**
Aspose.Slides for PHP via Java は、開発者が任意のシェイプを非表示にできるようにします。任意のスライドからシェイプを非表示にするには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 特定の AlternativeText を持つシェイプを検索します。
4. シェイプを非表示にします。
5. ファイルをディスクに保存します。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成する
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


## **シェイプの順序を変更する**
Aspose.Slides for PHP via Java は、開発者がシェイプの順序を変更できるようにします。シェイプの順序を変更すると、どのシェイプが前面にあり、どのシェイプが背面にあるかを指定できます。任意のスライドでシェイプの順序を変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. シェイプを追加します。
4. シェイプのテキスト フレームにテキストを追加します。
5. 同じ座標で別のシェイプを追加します。
6. シェイプの順序を変更します。
7. ファイルをディスクに保存します。
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
Aspose.Slides for PHP via Java は、[getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--) メソッドがプレゼンテーション スコープで一意の識別子を取得できるのに対し、スライド スコープで一意のシェイプ識別子を取得できるようにします。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) メソッドは [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) インターフェイスと [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) クラスに追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) メソッドが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # スライドスコープでユニークなシェイプ識別子を取得する
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプの代替テキストを設定する**
Aspose.Slides for PHP via Java は、任意のシェイプの AlternateText を設定できるようにします。プレゼンテーション内のシェイプは、[AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) または [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-) メソッドで区別できます。[setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) および [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) メソッドは、Aspose.Slides でも Microsoft PowerPoint でも取得・設定できます。このメソッドを使用すると、シェイプにタグ付けでき、シェイプの削除、非表示、スライド上での順序変更などの操作を実行できます。シェイプの AlternateText を設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. 追加したシェイプで何らかの処理を行います。
5. シェイプを走査して目的のシェイプを検索します。
6. AlternativeText を設定します。
7. ファイルをディスクに保存します。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成する
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


## **シェイプのレイアウトフォーマットにアクセスする**
Aspose.Slides for PHP via Java は、シェイプのレイアウトフォーマットにアクセスするためのシンプルな API を提供します。この記事では、レイアウトフォーマットへのアクセス方法を示します。

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
現在、Aspose.Slides for PHP via Java はシェイプを SVG としてレンダリングする機能をサポートしています。[writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) メソッド（およびオーバーロード）が [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) クラスと [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) インターフェイスに追加されました。このメソッドを使用すると、シェイプの内容を SVG ファイルとして保存できます。以下のコード スニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示しています。
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


## **シェイプを配置する**
Aspose.Slides は、シェイプをスライドの余白に対してまたは相互に対して配置できるようにします。そのために、オーバーロードされたメソッド [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) 列挙型は、可能な配置オプションを定義します。

**例 1**
以下のソースコードは、インデックス 1、2、4 のシェイプをスライドの上端に沿って配置します。
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
以下の例は、コレクション内の最下部シェイプに対して、シェイプ全体のコレクションを配置する方法を示しています。
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
Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) クラスが `flipH` および `flipV` プロパティを通じてシェイプの水平および垂直ミラーリングを制御します。これらのプロパティは [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 型で、`True` はフリップ、`False` はフリップなし、`NotDefined` はデフォルトの動作を使用することを示します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) から取得できます。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、希望する `flipH` と `flipV` の値、および回転角度を使用して新しい [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) に割り当て、プレゼンテーションを保存すると、ミラートランスフォーメーションが適用され、出力ファイルに反映されます。

例として、sample.pptx ファイルの最初のスライドにデフォルトのフリップ設定を持つ単一のシェイプが含まれているとします。以下に示すように。

![The shape to be flipped](shape_to_be_flipped.png)

以下のコード例は、シェイプの現在のフリップ プロパティを取得し、水平および垂直にフリップします。
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


結果：
![The flipped shape](flipped_shape.png)

## **よくある質問**
**スライド上でデスクトップ エディタのようにシェイプを結合（ユニオン/交差/減算）できますか？**
組み込みのブーリアン操作 API はありません。目的のアウトラインを自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しいシェイプを作成し、必要に応じて元のシェイプを削除します。

**シェイプが常に「最前面」にあるようにスタック順序（z オーダー）を制御するにはどうすればよいですか？**
スライドの [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) コレクション内で挿入順または移動順を変更します。予測可能な結果を得るには、他のすべてのスライド変更が完了した後に z オーダーを確定してください。

**PowerPoint でユーザーがシェイプを編集できないように「ロック」できますか？**
はい。[shape-level protection flags](/slides/ja/php-java/applying-protection-to-presentation/)（選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロックなど）を設定します。必要に応じて、マスターやレイアウトにも同様の制限を適用できます。これは UI レベルの保護であり、セキュリティ機能ではないことに注意してください。より強力な保護が必要な場合は、[読み取り専用推奨やパスワード](/slides/ja/php-java/password-protected-presentation/) などのファイルレベルの制限と組み合わせて使用してください。
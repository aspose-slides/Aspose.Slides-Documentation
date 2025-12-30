---
title: PHPでプレゼンテーションに矩形を追加する
linktitle: 矩形
type: docs
weight: 80
url: /ja/php-java/rectangle/
keywords:
- 矩形を追加
- 矩形を作成
- 矩形の形状
- シンプルな矩形
- 書式設定された矩形
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint プレゼンテーションに矩形を追加し、プログラムで形状を簡単に設計・変更できます。"
---

{{% alert color="primary" %}} 

前のトピックと同様に、今回も図形の追加について説明します。今回は **Rectangle**（矩形）についてです。このトピックでは、開発者が Aspose.Slides for PHP via Java を使用して、スライドにシンプルまたは書式設定された矩形を追加できる方法を説明しました。

{{% /alert %}} 

## **スライドに矩形を追加する**
プレゼンテーションの選択したスライドにシンプルな矩形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) の Rectangle タイプを、[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプの AutoShape を追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # PPTX ファイルをディスクに書き出し
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **スライドに書式設定された矩形を追加する**
スライドに書式設定された矩形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) の Rectangle タイプを、[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して追加します。
- 矩形の [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) を Solid に設定します。
- [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) オブジェクトに関連付けられた [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) オブジェクトが提供する [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) メソッドを使用して、矩形の色を設定します。
- 矩形の線の色を設定します。
- 矩形の線の幅を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

上記の手順は、以下の例で実装されています。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプの AutoShape を追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 楕円シェイプにいくつかの書式設定を適用
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # 楕円の線にいくつかの書式設定を適用
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX ファイルをディスクに書き出す
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**角丸矩形を追加するにはどうすればよいですか？**

角丸の [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリ調整により各コーナーごとに丸めを適用することもできます。

**画像（テクスチャ）で矩形を塗りつぶすにはどうすればよいですか？**

画像の [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) を設定します。

**矩形に影や光彩を付けることはできますか？**

はい。[Outer/inner shadow, glow, and soft edges](/slides/ja/php-java/shape-effect/) が利用可能で、パラメータを調整できます。

**矩形をハイパーリンク付きのボタンに変換できますか？**

はい。シェイプのクリックに [Assign a hyperlink](/slides/ja/php-java/manage-hyperlinks/) を設定すると、スライド、ファイル、ウェブアドレス、またはメールにジャンプできます。

**矩形を移動や変更から保護するにはどうすればよいですか？**

[Use shape locks](/slides/ja/php-java/applying-protection-to-presentation/) を使用すると、移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**矩形をラスタ画像または SVG に変換できますか？**

はい。指定したサイズ/スケールで画像に [render the shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) したり、ベクタ用途のために [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) したりできます。

**テーマや継承を考慮した矩形の実際（有効）プロパティをすばやく取得する方法は？**

[Use the shape’s effective properties](/slides/ja/php-java/shape-effective-properties/) を使用すると、API がテーマスタイル、レイアウト、ローカル設定を考慮した計算値を返し、書式設定の分析を簡素化します。
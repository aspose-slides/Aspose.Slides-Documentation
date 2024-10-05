---
title: 楕円
type: docs
weight: 30
url: /php-java/ellipse/
---


{{% alert color="primary" %}} 

このトピックでは、Aspose.Slides for PHP via Javaを使用して、スライドに楕円形を追加する開発者について紹介します。Aspose.Slides for PHP via Javaは、数行のコードでさまざまな種類の形状を描画するためのより簡単なAPIセットを提供します。

{{% /alert %}} 

## **楕円の作成**
プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)オブジェクトから公開されている[addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、楕円タイプのAutoShapeを追加します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、最初のスライドに楕円を追加しました。

```php
  # PPTXを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプのAutoShapeを追加
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # PPTXファイルをディスクに書き込む
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **フォーマットされた楕円の作成**
スライドにより良いフォーマットの楕円を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)オブジェクトから公開されている[addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、楕円タイプのAutoShapeを追加します。
- 楕円のフィルタイプをソリッドに設定します。
- [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)オブジェクトに関連付けられた[FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat)オブジェクトによって公開されるSolidFillColor.Colorプロパティを使用して、楕円の色を設定します。
- 楕円の線の色を設定します。
- 楕円の線の幅を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにフォーマットされた楕円を追加しました。

```php
  # PPTXを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプのAutoShapeを追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 楕円形状にいくつかのフォーマットを適用
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # 楕円の線にいくつかのフォーマットを適用
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTXファイルをディスクに書き込む
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
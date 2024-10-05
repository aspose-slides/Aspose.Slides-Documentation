---
title: 長方形
type: docs
weight: 80
url: /php-java/rectangle/
---

{{% alert color="primary" %}} 

前のトピックと同様に、今回も形状を追加することについてです。今回考察する形状は**長方形**です。このトピックでは、開発者がAspose.Slides for PHP via Javaを使用して、スライドにシンプルまたはフォーマットされた長方形を追加する方法を説明します。

{{% /alert %}} 

## **スライドに長方形を追加する**
プレゼンテーションの選択したスライドにシンプルな長方形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使ってスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)オブジェクトによって公開されている[addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、長方形型の[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)を追加します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しました。

```php
  # PPTXを表すPresentationクラスをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円型のAutoShapeを追加する
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # PPTXファイルをディスクに書き込む
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スライドにフォーマットされた長方形を追加する**
スライドにフォーマットされた長方形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使ってスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)オブジェクトによって公開されている[addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、長方形型の[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)を追加します。
- 長方形の[塗りつぶしタイプ](https://reference.aspose.com/slides/php-java/aspose.slides/FillType)をソリッドに設定します。
- [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)オブジェクトに関連付けられた[IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat)オブジェクトによって公開されている[SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-)メソッドを使用して、長方形の色を設定します。
- 長方形の線の色を設定します。
- 長方形の線の幅を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

上記の手順は、以下の例で実装されています。

```php
  # PPTXを表すPresentationクラスをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円型のAutoShapeを追加する
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 楕円形状にフォーマットを適用する
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # 楕円の線にフォーマットを適用する
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTXファイルをディスクに書き込む
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
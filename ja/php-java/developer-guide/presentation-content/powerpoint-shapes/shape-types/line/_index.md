---
title: 線
type: docs
weight: 50
url: /ja/php-java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides for PHP via Javaは、スライドにさまざまな種類の図形を追加することをサポートしています。このトピックでは、スライドに線を追加することで図形の操作を始めます。Aspose.Slides for PHP via Javaを使用することで、開発者は単純な線だけでなく、スライド上にいくつかの特別な線を描くこともできます。

{{% /alert %}} 

## **単純な線の作成**

プレゼンテーションの選択したスライドに単純な平面線を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)オブジェクトが公開する[addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、線タイプのAutoShapeを追加します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しました。

```php
  # PPTXファイルを表すPresentationExクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 線のタイプのAutoShapeを追加
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTXをディスクに書き込む
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **矢印型の線の作成**

Aspose.Slides for PHP via Javaは、開発者が線のいくつかのプロパティを設定して、より魅力的に見せることも可能にします。線を矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)オブジェクトが公開する[addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、線タイプのAutoShapeを追加します。
- Aspose.Slides for PHP via Javaが提供するスタイルのうちの1つに[線のスタイル](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle)を設定します。
- 線の幅を設定します。
- Aspose.Slides for PHP via Javaが提供するスタイルのうちの1つに[ダッシュスタイル](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle)を設定します。
- 線の始点の[矢印ヘッドスタイル](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle)と[長さ](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength)を設定します。
- 線の終点の[矢印ヘッドスタイル](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle)と[長さ](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength)を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

```php
  # PPTXファイルを表すPresentationExクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 線のタイプのAutoShapeを追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 線にいくつかのフォーマットを適用
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # PPTXをディスクに書き込む
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
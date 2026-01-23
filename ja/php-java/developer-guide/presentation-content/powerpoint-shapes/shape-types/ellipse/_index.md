---
title: PHPでプレゼンテーションに楕円を追加する
linktitle: 楕円
type: docs
weight: 30
url: /ja/php-java/ellipse/
keywords:
- 楕円
- 形状
- 楕円を追加
- 楕円を作成
- 楕円を描画
- フォーマットされた楕円
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PPT および PPTX プレゼンテーションで楕円形を作成、フォーマット、操作する方法を学びます — コード例付き。"
---

{{% alert color="primary" %}} 

このトピックでは、Aspose.Slides for PHP via Java を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for PHP via Java は、数行のコードでさまざまな形状を描画できる簡単な API セットを提供します。

{{% /alert %}} 

## **Create an Ellipse**
選択したプレゼンテーションのスライドにシンプルな楕円形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、最初のスライドに楕円形を追加しています
```php
  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプの AutoShape を追加
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # PPTX ファイルをディスクに書き込む
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Create a Formatted Ellipse**
スライドにより整った楕円形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 楕円形の塗りつぶしタイプを Solid に設定します。
- [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) オブジェクトに関連付けられた [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) オブジェクトが提供する `SolidFillColor::setColor` メソッドを使用して、楕円形の塗りつぶし色を設定します。
- 楕円形の線の色を設定します。
- 楕円形の線の幅を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに整形された楕円形を追加しています。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプの AutoShape を追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 楕円形にいくつかの書式設定を適用
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # 楕円の線にいくつかの書式設定を適用
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX ファイルをディスクに書き込む
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**How do I set the exact position and size of an ellipse with respect to the slide's units?**

座標とサイズは通常 **ポイント** 単位で指定します。予測可能な結果を得るために、スライドサイズを基準に計算し、必要なミリメートルまたはインチをポイントに変換してから値を設定してください。

**How can I place an ellipse above or below other objects (control stacking order)?**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整できます。これにより、楕円形が他のオブジェクトと重なったり、下のオブジェクトが表示されたりします。

**How do I animate the appearance or emphasis of an ellipse?**

[Apply](/slides/ja/php-java/shape-animation/) 入場、強調、または終了エフェクトを形状に適用し、トリガーとタイミングを構成して、アニメーションの再生タイミングと方法を制御します。
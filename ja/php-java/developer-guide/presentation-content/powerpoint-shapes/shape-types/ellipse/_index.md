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
- 書式設定された楕円
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java で PPT および PPTX プレゼンテーション向けに楕円形を作成、書式設定、操作する方法を学びます — コード例付き。"
---

{{% alert color="primary" %}} 
このトピックでは、Aspose.Slides for PHP via Java を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for PHP via Java は、数行のコードでさまざまな形状を描画できる簡単な API を提供します。
{{% /alert %}} 

## **楕円を作成**
プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、最初のスライドに楕円を追加しています
```php
  # PPTX を表す Presentation クラスをインスタンス化
  $pres = new Presentation();
  try {
    # 1枚目のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプの AutoShape を追加
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # PPTX ファイルをディスクに書き出し
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **書式設定された楕円を作成**
スライドに書式設定された楕円を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 楕円の塗りつぶしタイプを Solid に設定します。
- [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) オブジェクトに関連付けられた [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の色を設定します。
- 楕円の線の色を設定します。
- 楕円の線の幅を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。
```php
  # PPTX を表す Presentation クラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円タイプの AutoShape を追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 楕円シェイプにいくつかの書式設定を適用
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # 楕円の線にいくつかの書式設定を適用
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX ファイルをディスクに書き出し
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント単位**で指定されます。予測可能な結果を得るために、スライドのサイズを基準に計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**楕円を他のオブジェクトの上または下に配置するにはどうすればよいですか（スタック順の制御）？**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整します。これにより、楕円が他のオブジェクトと重なったり、背後にあるものを表示したりできます。

**楕円の表示や強調をアニメーションさせるにはどうすればよいですか？**

[Apply](/slides/ja/php-java/shape-animation/) を使用して、形状に出現、強調、または終了の効果を適用し、トリガーとタイミングを設定してアニメーションの再生時期と方法を制御します。
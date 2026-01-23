---
title: PHP でプレゼンテーションに線形状を追加する
linktitle: 線
type: docs
weight: 50
url: /ja/php-java/Line/
keywords:
- 線
- 線の作成
- 線の追加
- 単純な線
- 線の設定
- 線のカスタマイズ
- 破線スタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションの線書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルを確認してください。"
---

{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java はスライドにさまざまな形状を追加することをサポートします。このトピックでは、線をスライドに追加することで形状の操作を開始します。Aspose.Slides for PHP via Java を使用すると、単純な線だけでなく、スライド上に装飾的な線も描画できます。
{{% /alert %}} 

## **Create a Plain Line**

単純な線をプレゼンテーションの選択したスライドに追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) オブジェクトが公開する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```php
  # PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # line タイプの AutoShape を追加
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX をディスクに保存
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Create an Arrow-Shaped Line**

Aspose.Slides for PHP via Java では、線のプロパティを設定して外観をより魅力的にすることも可能です。線を矢印の形にするプロパティをいくつか設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) オブジェクトが公開する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、Line タイプの AutoShape を追加します。
- [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) を Aspose.Slides for PHP via Java が提供するスタイルのいずれかに設定します。
- 線の幅を設定します。
- [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) を Aspose.Slides for PHP via Java が提供するスタイルのいずれかに設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) を設定します。
- 線の終了点の [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルにします。
```php
  # PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # line タイプの AutoShape を追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 線にいくつかの書式設定を適用
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # PPTX をディスクに保存
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。形状にスナップさせたい場合は、専用の [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/php-java/connector/) を使用してください。

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

`LineFormatEffectiveData`/`LineFillFormatEffectiveData` を使用して [Read the effective properties](/slides/ja/php-java/shape-effective-properties/) を取得してください。これらは継承やテーマスタイルをすでに考慮した最終値を示します。

**Can I lock a line against editing (moving, resizing)?**

はい。形状は [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) を提供しており、編集操作（移動やサイズ変更）を禁止できます。
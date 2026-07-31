---
title: PHPでプレゼンテーションにラインシェイプを追加
linktitle: ライン
type: docs
weight: 50
url: /ja/php-java/line/
keywords:
- ライン
- ライン作成
- ライン追加
- シンプルライン
- ライン構成
- ラインカスタマイズ
- 破線スタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、例をご紹介します。"
---
## **概要**

Aspose.Slides を使用すると、プログラムで PowerPoint スライドに線形シェイプを追加できます。この記事では、シンプルな線の作成方法と、線を矢印として表示するカスタマイズ方法を示します。

スライドに線シェイプを追加し、外観を調整し、更新されたプレゼンテーションを保存する方法を学びます。例では、スタイル、幅、破線パターン、矢じりオプション、塗りつぶしカラーなど、実用的な線の書式設定に焦点を当てています。

## **シンプルな線の作成**

プレゼンテーションの選択したスライドにシンプルな平線を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。

```php
  # PPTX ファイルを表す PresentationEx クラスのインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # タイプ line の AutoShape を追加
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX をディスクに保存
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **矢印形状の線の作成**

Aspose.Slides for PHP via Java では、開発者が線のプロパティを設定して外観を向上させることもできます。線を矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、Line タイプの AutoShape を追加します。
- [Line Style](https://reference.aspose.com/slides/ja/php-java/aspose.slides/LineStyle) を Aspose.Slides for PHP via Java が提供するスタイルのいずれかに設定します。
- 線の幅を設定します。
- 線の [Dash Style](https://reference.aspose.com/slides/ja/php-java/aspose.slides/LineDashStyle) を Aspose.Slides for PHP via Java が提供するスタイルのいずれかに設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/ja/php-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/ja/php-java/aspose.slides/LineArrowheadLength) を設定します。
- 線の終了点の [Arrow Head Style](https://reference.aspose.com/slides/ja/php-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/ja/php-java/aspose.slides/LineArrowheadLength) を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

```php
  # PPTX ファイルを表す PresentationEx クラスのインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # タイプ line の AutoShape を追加
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # ラインにいくつかの書式設定を適用
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

**通常の線をコネクタに変換して、形状に「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) のタイプが [Line](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapetype/)）は自動的にコネクタにはなりません。形状にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/ja/php-java/aspose.slides/connector/) タイプと接続用の [corresponding APIs](/slides/ja/php-java/connector/) を使用してください。

**線のプロパティがテーマから継承されており、最終的な値が分かりにくい場合はどうすればよいですか？**

[Read the effective properties](/slides/ja/php-java/shape-effective-properties/) を `LineFormatEffectiveData`/`LineFillFormatEffectiveData` で確認します—これらは継承やテーマスタイルを考慮しています。

**線を編集（移動、サイズ変更）できないようにロックできますか？**

はい。Shapes は編集操作を禁止できる [lock objects](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/getautoshapelock/) を提供しています。
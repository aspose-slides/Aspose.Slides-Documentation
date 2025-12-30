---
title: PHPでプレゼンテーションにラインシェイプを追加する
linktitle: ライン
type: docs
weight: 50
url: /ja/php-java/Line/
keywords:
- ライン
- ラインを作成
- ラインを追加
- 単純なライン
- ラインの構成
- ラインのカスタマイズ
- ダッシュスタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルを紹介します。"
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、スライドにさまざまな種類のシェイプを追加することをサポートしています。このトピックでは、シェイプの操作を開始し、スライドに線を追加します。Aspose.Slides for PHP via Java を使用すると、開発者は単純な線だけでなく、装飾的な線もスライドに描画できます。

{{% /alert %}} 

## **単純な線の作成**

プレゼンテーションの選択したスライドに単純な直線を追加するには、以下の手順に従ってください。

- プレゼンテーションの [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドのインデックスを使用して、その参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```php
  # PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # ラインタイプの AutoShape を追加します
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX をディスクに保存します
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **矢印形状の線の作成**

Aspose.Slides for PHP via Java は、線の外観をより魅力的にするためにいくつかのプロパティを設定することも可能です。線を矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- プレゼンテーションの [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドのインデックスを使用して、その参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for PHP via Java が提供するスタイルのいずれかに、[Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) を設定します。
- 線の幅を設定します。
- Aspose.Slides for PHP via Java が提供するスタイルのいずれかに、線の [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) を設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) を設定します。
- 線の終了点の [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして保存します。
```php
  # PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # ラインタイプの AutoShape を追加
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


## **よくある質問**

**通常の線をコネクタに変換して、シェイプに「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。シェイプにスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/php-java/connector/) を使用してください。

**テーマから継承された線のプロパティで、最終的な値が分かりにくい場合はどうすればよいですか？**

[効果的なプロパティを読む](/slides/ja/php-java/shape-effective-properties/) を `LineFormatEffectiveData`/`LineFillFormatEffectiveData` 経由で読み取ります。これらは継承やテーマスタイルをすでに考慮しています。

**線を編集（移動、サイズ変更）できないようにロックできますか？**

はい。シェイプは [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) を提供しており、[編集操作を禁止](/slides/ja/php-java/applying-protection-to-presentation/) できます。
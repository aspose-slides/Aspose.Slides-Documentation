---
title: PHP を使用してプレゼンテーションのチャート データテーブルをカスタマイズする
linktitle: データテーブル
type: docs
url: /ja/php-java/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PPT および PPTX のチャート データテーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データ テーブルのフォント プロパティを設定する**
Aspose.Slides for PHP via Java は、系列の色におけるカテゴリの色の変更をサポートします。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャート テーブルを設定します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されます。
```php
  # 空のプレゼンテーションを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[legend keys](https://reference.aspose.com/slides/php-java/aspose.slides/datatable/setshowlegendkey/) をサポートしており、オンまたはオフに切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートする際にデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/php-java/convert-powerpoint-to-html/)/[image](/slides/ja/php-java/convert-powerpoint-to-png/) にはデータテーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれたチャートについては、チャートのプロパティを使用してデータテーブルが[is shown](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/)かどうかを確認し、変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく見つけるにはどうすればよいですか？**

データテーブルが[is shown](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/)かどうかを示す各チャートのプロパティを確認し、スライドを反復処理して有効になっているチャートを特定します。
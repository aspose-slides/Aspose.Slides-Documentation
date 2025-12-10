---
title: .NET のプレゼンテーションでチャート データテーブルをカスタマイズする
linktitle: データテーブル
type: docs
url: /ja/net/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PPT および PPTX のチャート データテーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データテーブルのフォント プロパティを設定する**
Aspose.Slides for .NET は、シリーズのカテゴリの色を変更する機能を提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。  
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/) をサポートしており、オンまたはオフにできます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートするとき、データテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/net/convert-powerpoint-to-html/)/[image](/slides/ja/net/convert-powerpoint-to-png/) にはデータテーブルを含むチャートが含まれます。

**テンプレートファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれた任意のチャートについて、チャートのプロパティを使用してデータテーブルが[表示されているか](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) を確認および変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく見つけるにはどうすればよいですか？**

各チャートのデータテーブルが[表示されているか](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) を示すプロパティを確認し、スライドを順に調べて有効になっているチャートを特定します。
---
title: Python を使用してプレゼンテーションのチャート データテーブルをカスタマイズする
linktitle: データテーブル
type: docs
url: /ja/python-java/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python 用に Aspose.Slides for Python via Java を使用して、PPT および PPTX のチャート データテーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---
## **概要**

この記事では、Aspose.Slidesでチャートのデータテーブルを操作する方法を説明します。チャートのデータテーブルを表示し、太字スタイルやフォント高さなどのフォントプロパティを設定してテキストの書式をカスタマイズする方法を示します。例として、プレゼンテーションの作成、チャートの追加、データテーブルの有効化、フォント設定の適用、更新されたプレゼンテーションの保存を行います。

また、チャートのデータテーブルに凡例キーを表示する方法、エクスポート時にデータテーブルを保持する方法、既存のプレゼンテーションやテンプレートから読み込んだチャートでの操作、データテーブルが有効になっているチャートの特定方法に関する一般的な質問への簡潔な回答も含まれています。

## **チャート データテーブルのフォントプロパティを設定する**

Aspose.Slides for Python via Java を使用すると、チャートのデータテーブルを表示し、そのテキストのフォントプロパティを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. チャートのデータテーブルを表示します。
1. データテーブルのテキストに太字スタイルとフォント高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下のサンプルがこれらの手順を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# 空のプレゼンテーションを作成します。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[凡例キー](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datatable/#setShowLegendKey)をサポートしており、オンまたはオフにできます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートする際にデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部として描画するため、エクスポートされた[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/python-java/convert-powerpoint-to-html/)/[画像](/slides/ja/python-java/convert-powerpoint-to-png/) にはデータテーブル付きのチャートが含まれます。

**テンプレートファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションやテンプレートから読み込んだチャートについても、チャートのプロパティを使用してデータテーブルが[表示されているか](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#hasDataTable)を確認し、変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく見つける方法はありますか？**

各チャートのデータテーブルが[表示されているか](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#hasDataTable)を示すプロパティを確認し、スライドを順に走査してデータテーブルが有効なチャートを特定します。
---
title: C++ を使用したプレゼンテーションの円グラフをカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/cpp/pie-chart/
keywords:
- 円グラフ
- チャートの管理
- チャートのカスタマイズ
- チャートオプション
- チャート設定
- プロットオプション
- スライスの色
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で円グラフを作成・カスタマイズする方法を学び、PowerPoint へエクスポート可能で、データストーリーテリングを数秒で強化します。"
---
## **概要**

この記事では、Aspose.Slides で円グラフを操作する方法を説明します。Pie of Pie および Bar of Pie チャートの二次プロットオプションの設定方法と、標準の円グラフで自動スライス着色を有効にする方法を示します。

例では、スライドにチャートを追加する、系列やラベル設定を調整する、既定のチャートデータをカスタムカテゴリと値に置き換える、更新されたプレゼンテーションを保存するなど、実用的なチャートカスタマイズ手順に焦点を当てています。

## **Pie of Pie と Bar of Pie チャートの二次プロットオプション**
Aspose.Slides for C++ は、Pie of Pie または Bar of Pie チャートの二次プロットオプションをサポートします。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法を例で確認します。プロパティを指定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの二次プロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、Pie of Pie チャートのさまざまなプロパティを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **自動パイチャートスライス色の設定**
Aspose.Slides for C++ は、円グラフのスライス色を自動設定するためのシンプルな API を提供します。サンプルコードは上記のプロパティ設定を適用しています。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初のシリーズを値の表示に設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータ ワークシートを取得します。
1. デフォルトで生成されたシリーズとカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しいシリーズを追加します。

変更されたプレゼンテーションを PPTX ファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**「Pie of Pie」および「Bar of Pie」バリエーションはサポートされていますか？**

はい、ライブラリは [二次プロット](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/charttype/) をサポートしており、'Pie of Pie' と 'Bar of Pie' のタイプが含まれます。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体を含めずに、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getimage/)（PNG など）できます。
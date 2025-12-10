---
title: C++ を使用したプレゼンテーションの円グラフのカスタマイズ
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
- С++
- Aspose.Slides
description: "Aspose.Slides を使用して С++ で円グラフを作成・カスタマイズする方法を学び、PowerPoint へエクスポート可能で、データストーリーテリングを数秒で強化します。"
---

## **パイ・オブ・パイ および バー・オブ・パイ チャートのセカンドプロット オプション**
Aspose.Slides for C++ は、パイ・オブ・パイまたはバー・オブ・パイ チャートのセカンドプロット オプションをサポートするようになりました。このトピックでは、例を使って Aspose.Slides を使用してこれらのオプションを指定する方法を見ていきます。プロパティを指定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのオブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートのセカンドプロット オプションを指定します。
4. プレゼンテーションを書き出してディスクに保存します。

以下の例では、パイ・オブ・パイ チャートのさまざまなプロパティを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **自動パイチャートスライスの色を設定**
Aspose.Slides for C++ は、自動パイチャートスライスの色を設定するシンプルな API を提供します。サンプルコードは、前述のプロパティの設定を実行します。

1. Presentation クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. チャートのタイトルを設定します。
5. 最初の系列に「値の表示」を設定します。
6. チャート データ シートのインデックスを設定します。
7. チャート データ ワークシートを取得します。
8. デフォルトで生成された系列とカテゴリを削除します。
9. 新しいカテゴリを追加します。
10. 新しい系列を追加します。

変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**「パイ・オブ・パイ」および「バー・オブ・パイ」バリエーションはサポートされていますか？**

はい、ライブラリは[サポート](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)しており、'Pie of Pie' と 'Bar of Pie' タイプを含む、円グラフのセカンダリ プロットを使用できます。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)（PNG など）し、プレゼンテーション全体を含めずに保存できます。
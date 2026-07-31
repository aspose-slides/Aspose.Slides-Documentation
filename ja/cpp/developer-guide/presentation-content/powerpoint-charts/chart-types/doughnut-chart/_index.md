---
title: C++ を使用したプレゼンテーションのドーナツ グラフのカスタマイズ
linktitle: ドーナツ グラフ
type: docs
weight: 30
url: /ja/cpp/doughnut-chart/
keywords:
- ドーナツ グラフ
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でドーナツ グラフを作成およびカスタマイズする方法を紹介し、動的なプレゼンテーション向けに PowerPoint 形式をサポートします。"
---
## **概要**

この項目では、Aspose.Slides でドーナツ グラフをスライドに追加し、中心の穴のサイズを設定し、プレゼンテーションを保存する方法を示します。`set_DoughnutHoleSize` メソッドに焦点を当て、コードでこのグラフ種別をカスタマイズする基本的な手順を解説します。

## **ドーナツ グラフの中心ギャップを指定する**
ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- スライドにドーナツ グラフを追加します。
- ドーナツ グラフの穴のサイズを指定します。
- プレゼンテーションをディスクに書き出します。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**マルチレベルのドーナツ（複数のリング）を作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、系列コレクション内の順序で決まります。

**「爆発」したドーナツ（スライスが分離された状態）はサポートされていますか？**

はい。Exploded Doughnut [chart type](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/charttype/) と、データ ポイントの爆発プロパティがあり、個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するには？**

グラフはシェイプです。シェイプを[ラスタ画像](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getimage/) にレンダリングするか、[SVG 画像](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/writeassvg/) にエクスポートできます。
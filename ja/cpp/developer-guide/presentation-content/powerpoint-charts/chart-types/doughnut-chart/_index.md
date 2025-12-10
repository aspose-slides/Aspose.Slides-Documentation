---
title: C++ を使用してプレゼンテーションのドーナツ グラフをカスタマイズ
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
description: "Aspose.Slides for C++ を使用してドーナツ グラフを作成およびカスタマイズする方法を紹介します。PowerPoint 形式に対応し、動的なプレゼンテーションを実現します。"
---

## **ドーナツ グラフの中心ギャップを指定する**
ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- スライドにドーナツ グラフを追加します。
- ドーナツ グラフの穴のサイズを指定します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**複数のリングを持つマルチレベル ドーナツを作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序によって決まります。

**「エクスプロード」ドーナツ（スライスが分離）のサポートはありますか？**

はい。Exploded Doughnut [chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) があり、データ ポイントに爆発プロパティがあります。個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するにはどうすればよいですか？**

グラフはシェイプです。[raster image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) にレンダリングするか、[SVG image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) にエクスポートできます。
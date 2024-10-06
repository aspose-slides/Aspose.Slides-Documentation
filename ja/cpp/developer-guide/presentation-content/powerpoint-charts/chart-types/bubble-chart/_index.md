---
title: バブルチャート
type: docs
url: /ja/cpp/bubble-chart/
---

## **バブルチャートサイズのスケーリング**
Aspose.Slides for C++はバブルチャートサイズのスケーリングをサポートしています。Aspose.Slides for **C++**では**IChartSeries.BubbleSizeScale**および**IChartSeriesGroup.BubbleSizeScale**プロパティが追加されました。以下にサンプル例を示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **データをバブルチャートサイズとして表現**
新しい**get_BubbleSizeRepresentation()**メソッドが**IChartSeries**および**ChartSeries**クラスに追加されました。**BubbleSizeRepresentation**はバブルチャートにおけるバブルサイズ値の表現方法を指定します。可能な値は、**BubbleSizeRepresentationType.Area**および**BubbleSizeRepresentationType.Width**です。それに応じて、データをバブルチャートサイズとして表現するための可能な方法を指定するために**BubbleSizeRepresentationType**列挙型が追加されました。サンプルコードは以下に示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}
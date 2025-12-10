---
title: C++ を使用したプレゼンテーションでバブルチャートをカスタマイズ
linktitle: バブルチャート
type: docs
url: /ja/cpp/bubble-chart/
keywords:
- バブルチャート
- バブルサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- プレゼンテーション
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ を使用して、PowerPoint で強力なバブルチャートを作成・カスタマイズし、データ可視化を簡単に強化します。"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for C++ はバブルチャートのサイズスケーリングをサポートしています。Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** および **IChartSeriesGroup.BubbleSizeScale** プロパティが追加されました。以下にサンプル例を示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **バブルチャートサイズとしてデータを表す**
新しい **get_BubbleSizeRepresentation()** メソッドが **IChartSeries** と **ChartSeries** クラスに追加されました。**BubbleSizeRepresentation** はバブルチャートでバブルサイズの値がどのように表現されるかを指定します。可能な値は **BubbleSizeRepresentationType.Area** と **BubbleSizeRepresentationType.Width** です。これに伴い、データをバブルチャートサイズとして表す可能な方法を指定するために **BubbleSizeRepresentationType** 列挙型が追加されました。以下にサンプルコードを示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**
**「3-D 効果付きバブルチャート」はサポートされていますか、通常のものとどう違いますか？**
はい。別個のチャートタイプ「Bubble with 3-D」が用意されています。これはバブルに 3-D スタイルを適用しますが、追加の軸は追加されません。データは X-Y-S（サイズ）のままです。このタイプは[chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)列挙体で利用可能です。

**バブルチャートの系列およびポイントの数に制限はありますか？**
API レベルでは明確な上限はありません。制約はパフォーマンスや対象の PowerPoint バージョンによって決まります。可読性とレンダリング速度を考慮し、ポイント数は適切に抑えることを推奨します。

**バブルチャートをエクスポートした場合（PDF、画像）、外観はどのように変わりますか？**
サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが実行します。ラスタ/ベクタ形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されるため、印刷時には十分な DPI を選択してください。
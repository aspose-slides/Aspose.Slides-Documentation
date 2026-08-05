---
title: C++ を使用したプレゼンテーションのバブルチャートをカスタマイズ
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint で強力なバブルチャートを作成およびカスタマイズし、データ可視化を簡単に強化します。"
---
## **概要**

この記事では、Aspose.Slidesでバブルチャートを操作する方法を示します。`set_BubbleSizeScale` メソッドによるバブルサイズのスケーリングと、`set_BubbleSizeRepresentation` メソッドによるバブルサイズ値の表現方法の制御という 2 つのカスタマイズ オプションを取り上げます。

例では、バブルチャートの作成方法、サイズスケーリングの調整方法、バブルサイズの表現を幅に変更する方法を示しています。また、短い FAQ セクションでは「Bubble with 3-D」チャートタイプのサポート状況、実際のチャートの制限はパフォーマンスと対象の PowerPoint バージョンに依存すること、エクスポート時に Aspose.Slides のレンダリング エンジンによりチャートの外観が保持されることを説明しています。

## **バブルチャートのサイズスケーリング**
Aspose.Slides for C++ はバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** および **IChartSeriesGroup.BubbleSizeScale** プロパティが追加されました。以下にサンプル例を示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **データをバブルチャートのサイズとして表す**
新しい **get_BubbleSizeRepresentation()** メソッドが **IChartSeries** および **ChartSeries** クラスに追加されました。**BubbleSizeRepresentation** はバブルチャートでバブルサイズ値がどのように表現されるかを指定します。可能な値は **BubbleSizeRepresentationType.Area** と **BubbleSizeRepresentationType.Width** です。それに伴い、データをバブルチャートのサイズとして表す方法を指定する **BubbleSizeRepresentationType** 列挙体が追加されました。以下にサンプルコードを示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**「3-D 効果のあるバブルチャート」はサポートされていますか、通常のものとどのように違うのですか？**

はい。別個のチャートタイプ「Bubble with 3-D」が用意されています。バブルに 3-D スタイルが適用されますが、追加の軸は追加されず、データは X-Y-S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/charttype/) 列挙体で利用可能です。

**バブルチャートの系列数やデータポイント数に制限はありますか？**

API レベルでの明確な上限はありません。制約はパフォーマンスと対象となる PowerPoint バージョンによって決まります。可読性とレンダリング速度を考慮し、ポイント数は適度に抑えることが推奨されます。

**エクスポート時にバブルチャートの外観はどのように影響しますか（PDF、画像）？**

対応フォーマットへのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが実行します。ラスター/ベクターフォーマットの場合、解像度やアンチエイリアスといった一般的なチャート描画ルールが適用されるため、印刷時は十分な DPI を選択してください。
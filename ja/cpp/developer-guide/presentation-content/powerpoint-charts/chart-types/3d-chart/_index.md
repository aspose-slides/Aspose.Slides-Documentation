---
title: C++ を使用したプレゼンテーションの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/cpp/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で PPT および PPTX ファイルをサポートしながら、3-D チャートの作成とカスタマイズ方法を学び、プレゼンテーションを強化しましょう。"
---
## **概要**

この記事では、`Rotation3D` の設定（`RotationX`、`RotationY`、`DepthPercents`、`RightAngleAxes`）を構成することで、Aspose.Slides の 3D チャートをカスタマイズする方法を説明します。プレゼンテーションの作成、デフォルトデータの 3D チャートの追加、必要な 3D ビュー設定の適用、および変更されたプレゼンテーションを PPTX ファイルとして保存する手順を示します。

## **3D チャートの RotationX、RotationY、DepthPercents プロパティの設定**
Aspose.Slides for C++ は、これらのプロパティを設定するためのシンプルな API を提供します。以下の記事では、X、Y 回転や **DepthPercents** などのさまざまなプロパティの設定方法を紹介します。サンプルコードは、上記のプロパティ設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. Rotation3D プロパティを設定します。
5. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **よくある質問**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、柱状グラフの 3D バリアントと、[ChartType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/charttype/) 列挙体で提供される関連の 3D タイプをサポートしています。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスター画像を取得できますか？**

はい。チャートを画像としてエクスポートするには [chart API](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getimage/) を使用するか、[スライド全体をレンダリング](/slides/ja/cpp/convert-powerpoint-to-png/) して PNG や JPEG 形式で取得できます。ピクセル単位で正確なプレビューが必要なときや、PowerPoint を使用せずにドキュメント、ダッシュボード、ウェブページにチャートを埋め込む場合に便利です。

**大規模な 3D チャートの作成とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。ベストな結果を得るには、3D 効果は最小限に抑え、壁やプロット領域への重いテクスチャを避け、可能な限りシリーズあたりのデータポイント数を制限し、ターゲットの表示や印刷要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。
---
title: C++ を使用してプレゼンテーションの 3D チャートをカスタマイズ
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
description: "Aspose.Slides for C++ で 3D チャートを作成およびカスタマイズする方法を学び、PPT と PPTX ファイルをサポートし、プレゼンテーションを強化しましょう。"
---

## **3D チャートの RotationX、RotationY および DepthPercents プロパティの設定**
Aspose.Slides for C++ は、これらのプロパティを設定するためのシンプルな API を提供します。この以下の記事では、X、Y の回転や **DepthPercents** など、さまざまなプロパティの設定方法を説明します。サンプルコードは、上記のプロパティの設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. Rotation3D プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **よくある質問**

**Aspose.Slides で 3D モードをサポートしているチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、そして 100% Stacked Column 3D など、柱状チャートの 3D バリアントをサポートしており、[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列挙体を通じて関連する 3D タイプも利用できます。正確で最新の一覧については、インストールされているバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) のメンバーを確認してください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像としてエクスポートするには、[chart API](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) を使用するか、[render the entire slide](/slides/ja/cpp/convert-powerpoint-to-png/) を利用して PNG や JPEG 形式に変換できます。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、ウェブページにチャートを埋め込みたい場合に便利です。

**大規模な 3D チャートの構築とレンダリングはどの程度のパフォーマンスですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最良の結果を得るには、3D 効果は最小限に抑え、壁やプロット領域への重いテクスチャの使用を避け、可能な限りシリーズごとのデータポイント数を制限し、ターゲットの表示や印刷要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。
---
title: С++ のプレゼンテーションチャートにトレンドラインを追加
linktitle: トレンドライン
type: docs
url: /ja/cpp/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- べき乗トレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ を使用して PowerPoint のチャートにトレンドラインを迅速に追加およびカスタマイズし、聴衆を引きつける実用的なガイドです。"
---

## **トレンドラインの追加**
Aspose.Slides for C++ は、さまざまなチャートのトレンドラインを管理するシンプルな API を提供します:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータを持つチャートを、希望のタイプのいずれかで追加します（この例では ChartType.ClusteredColumn を使用）。
1. 系列 1 の指数トレンドラインを追加します。
1. 系列 1 の線形トレンドラインを追加します。
1. 系列 2 の対数トレンドラインを追加します。
1. 系列 2 の移動平均トレンドラインを追加します。
1. 系列 3 の多項式トレンドラインを追加します。
1. 系列 3 のべき乗トレンドラインを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **カスタムラインの追加**
Aspose.Slides for C++ は、チャートにカスタムラインを追加するシンプルな API を提供します。プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください:

- Presentation クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapes オブジェクトが提供する AddChart メソッドを使用して新しいチャートを作成します
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用してラインタイプの AutoShape を追加します
- シェイプのラインの色を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **よくある質問**

**トレンドラインの「forward」と「backward」は何を意味しますか？**

それらはトレンドラインを前方／後方に伸ばした長さを表します。散布 (XY) チャートの場合は軸単位、散布でないチャートの場合はカテゴリ数で表されます。負の値は使用できません。

**プレゼンテーションを PDF や SVG にエクスポートする際、またはスライドを画像としてレンダリングする際にトレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を [エクスポート](/slides/ja/cpp/create-shape-thumbnails/) するメソッドも利用可能です。
---
title: トレンドライン
type: docs
url: /ja/cpp/trend-line/
---

## **トレンドラインの追加**
Aspose.Slides for C++ は、さまざまなチャートトレンドラインを管理するためのシンプルなAPIを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトのデータと任意の希望のタイプでチャートを追加します（この例では ChartType.ClusteredColumn を使用しています）。
1. チャート系列1に指数トレンドラインを追加します。
1. チャート系列1に線形トレンドラインを追加します。
1. チャート系列2に対数トレンドラインを追加します。
1. チャート系列2に移動平均トレンドラインを追加します。
1. チャート系列3に多項式トレンドラインを追加します。
1. チャート系列3に幾何学的トレンドラインを追加します。
1. 変更されたプレゼンテーションをPPTXファイルとして書き込みます。

次のコードは、トレンドラインを持つチャートを作成するために使用されます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **カスタムラインの追加**
Aspose.Slides for C++ は、チャートにカスタムラインを追加するためのシンプルなAPIを提供します。プレゼンテーションの選択されたスライドにシンプルな平面ラインを追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapesオブジェクトによって公開された AddChart メソッドを使用して新しいチャートを作成します
- Shapesオブジェクトによって公開された AddAutoShape メソッドを使用して、ラインタイプのオートシェイプを追加します
- シェイプラインの色を設定します
- 変更されたプレゼンテーションをPPTXファイルとして書き込みます

次のコードは、カスタムラインを持つチャートを作成するために使用されます。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}
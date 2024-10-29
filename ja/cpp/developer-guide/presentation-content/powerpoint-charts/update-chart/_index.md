---
title: チャートの更新
type: docs
weight: 10
url: /ja/cpp/update-chart/
---


## **チャートの更新**
Aspose.Slides for C++は、チャートを最も簡単な方法で更新するための最もシンプルなAPIを提供しています。スライド内のチャートを更新するには:

- チャートを含む Presentation クラスのインスタンスを開く。
- インデックスを使用してスライドの参照を取得する。
- すべての形状をトラバースして目的のチャートを見つける。
- チャートデータのワークシートにアクセスする。
- シリーズの値を変更してチャートデータの系列データを修正する。
- 新しい系列を追加し、その中にデータを入力する。
- 修正したプレゼンテーションをPPTXファイルとして書き込む。

チャートの更新方法を示すコード例は以下の通りです。


{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExistingChart-ExistingChart.cpp" >}}
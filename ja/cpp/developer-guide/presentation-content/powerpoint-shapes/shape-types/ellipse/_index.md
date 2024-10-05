---
title: 楕円
type: docs
weight: 30
url: /cpp/ellipse/
---


## **楕円の作成**
このトピックでは、Aspose.Slides for C++ を使用してスライドに楕円形状を追加する方法を開発者に紹介します。Aspose.Slides for C++ は、数行のコードでさまざまな種類の形状を描画するための簡単なAPIセットを提供します。プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

1. [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) のインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されるAddAutoShapeメソッドを使用して、楕円型のAutoShapeを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下の例では、最初のスライドに楕円を追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}


## **フォーマットされた楕円の作成**
スライドにより良くフォーマットされた楕円を追加するには、以下の手順に従ってください。

1. [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) のインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されるAddAutoShapeメソッドを使用して、楕円型のAutoShapeを追加します。
1. 楕円の塗りつぶしタイプをソリッドに設定します。
1. FillFormatオブジェクトと関連するIShapeオブジェクトによって公開されるSolidFillColor.Colorプロパティを使用して、楕円の色を設定します。
1. 楕円のラインの色を設定します。
1. 楕円のラインの幅を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにフォーマットされた楕円を追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}
---
title: 長方形
type: docs
weight: 80
url: /ja/cpp/rectangle/
---


## **シンプルな長方形を作成する**
前のトピックと同様に、今回は形状を追加することについてであり、今回議論する形状は長方形です。このトピックでは、開発者がAspose.Slides for C++を使用してスライドにシンプルまたはフォーマットされた長方形を追加する方法を説明しています。プレゼンテーションの選択したスライドにシンプルな長方形を追加するには、以下の手順に従ってください。

1. [Presentation クラス](http://www.aspose.com/api/net/slides/aspose.slides/)のインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、長方形型のIAutoShapeを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **フォーマットされた長方形を作成する**
スライドにフォーマットされた長方形を追加するには、以下の手順に従ってください。

1. [Presentation クラス](http://www.aspose.com/api/net/slides/aspose.slides/)のインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、長方形型のIAutoShapeを追加します。
1. 長方形の塗りつぶしタイプをソリッドに設定します。
1. IShapeオブジェクトに関連付けられたFillFormatオブジェクトによって公開されたSolidFillColor.Colorプロパティを使用して、長方形の色を設定します。
1. 長方形の線の色を設定します。
1. 長方形の線の幅を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。
   上記の手順は、以下の例で実装されています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}
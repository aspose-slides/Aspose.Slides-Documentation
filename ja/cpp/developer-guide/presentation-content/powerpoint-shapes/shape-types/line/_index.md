---
title: 線
type: docs
weight: 50
url: /ja/cpp/Line/
---

## **平面線を作成する**
プレゼンテーションの選択したスライドにシンプルな平面線を追加するには、以下の手順に従ってください。

- [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/)のインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapesオブジェクトによって公開された[AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index)メソッドを使用して、線タイプのAutoShapeを追加します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドに線を追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **矢印形線を作成する**
Aspose.Slides for C++では、開発者が線のいくつかのプロパティを設定して、より魅力的に見せることもできます。線を矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/)のインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、線タイプのAutoShapeを追加します。
- Aspose.Slides for C++が提供するスタイルの1つに線のスタイルを設定します。
- 線の幅を設定します。
- 線の[ダッシュスタイル](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle)をAspose.Slides for C++が提供するスタイルの1つに設定します。
- 線の開始点の[矢印ヘッドスタイル](http://www.aspose.com/api/net/slides/aspose.slides/lineformat)と長さを設定します。
- 線の終了点の矢印ヘッドスタイルと長さを設定します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}
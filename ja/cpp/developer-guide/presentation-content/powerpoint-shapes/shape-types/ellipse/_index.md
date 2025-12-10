---
title: C++ でプレゼンテーションに楕円を追加する
linktitle: 楕円
type: docs
weight: 30
url: /ja/cpp/ellipse/
keywords:
- 楕円
- 形状
- 楕円の追加
- 楕円の作成
- 楕円の描画
- 書式設定された楕円
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPT および PPTX プレゼンテーション内の楕円形を作成、書式設定、操作する方法を学びます — C++ コード例を含む。"
---

## **楕円の作成**
このトピックでは、Aspose.Slides for C++ を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for C++ は、数行のコードだけでさまざまな形状を描画できる簡単な API を提供します。プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

1. [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) のインスタンスを作成する
1. インデックスを使用してスライドの参照を取得する
1. IShapes オブジェクトが公開する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加する
1. 変更したプレゼンテーションを PPTX ファイルとして書き出す

以下の例では、最初のスライドに楕円を追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **書式設定された楕円の作成**
スライドに書式設定された楕円を追加するには、以下の手順に従ってください。

1. [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) のインスタンスを作成する。
1. インデックスを使用してスライドの参照を取得する。
1. IShapes オブジェクトが公開する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加する。
1. 楕円の塗りつぶしタイプを Solid に設定する。
1. FillFormat オブジェクトが提供する SolidFillColor.Color プロパティで楕円の塗りつぶし色を設定する。
1. 楕円の線の色を設定する。
1. 楕円の線の幅を設定する。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出す。

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント**で指定されます。予測可能な結果を得るには、スライドサイズを基準に計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**楕円を他のオブジェクトの前または後ろに配置するには（スタック順の制御）はどうすればよいですか？**

オブジェクトの描画順序を調整し、前面に持ってくるか背面に送ることで、楕円が他のオブジェクトと重なるようにしたり、下のオブジェクトを表示したりできます。

**楕円の表示や強調にアニメーションを付けるにはどうすればよいですか？**

[Apply](/slides/ja/cpp/shape-animation/) で入場、強調、退出エフェクトを形状に適用し、トリガーやタイミングを設定してアニメーションの再生時期と方法を調整してください。
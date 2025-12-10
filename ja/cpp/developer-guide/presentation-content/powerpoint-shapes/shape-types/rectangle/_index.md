---
title: C++ でプレゼンテーションに矩形を追加する
linktitle: 矩形
type: docs
weight: 80
url: /ja/cpp/rectangle/
keywords:
- 矩形を追加
- 矩形を作成
- 矩形シェイプ
- シンプルな矩形
- 書式設定された矩形
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションに矩形を追加し、プログラムで形状を簡単に設計・変更できます。"
---

## **シンプルな矩形の作成**
前のトピックと同様に、今回も図形の追加について説明します。今回取り上げる図形は矩形です。このトピックでは、開発者が Aspose.Slides for C++ を使用してスライドにシンプルまたはフォーマットされた矩形を追加する方法を説明しました。プレゼンテーションの選択したスライドにシンプルな矩形を追加するには、以下の手順に従ってください。

1. [Presentation クラス](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)のインスタンスを作成する。
1. インデックスを使用してスライドの参照を取得する。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加する。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルに保存する。

以下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **フォーマットされた矩形の作成**
スライドにフォーマットされた矩形を追加するには、以下の手順に従ってください。

1. [Presentation クラス](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)のインスタンスを作成する。
1. インデックスを使用してスライドの参照を取得する。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加する。
1. 矩形の塗りつぶしタイプを Solid に設定する。
1. FillFormat オブジェクトの SolidFillColor.Color プロパティを使用して、矩形の色を設定する。
1. 矩形の線の色を設定する。
1. 矩形の線の幅を設定する。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルに保存する。
   上記の手順は以下の例で実装されています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**角丸矩形を追加するにはどうすればよいですか？**

丸みを帯びた角の [shape type](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリ調整により、各コーナーごとに丸みを設定することも可能です。

**矩形を画像（テクスチャ）で塗りつぶすには？**

ピクチャー [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) を設定します。

**矩形に影や光彩を付けられますか？**

はい。[Outer/inner shadow、glow、soft edges](/slides/ja/cpp/shape-effect/) が利用でき、パラメータを調整できます。

**矩形をハイパーリンク付きのボタンにできますか？**

はい。シェイプのクリックに対して [ハイパーリンクを割り当て](/slides/ja/cpp/manage-hyperlinks/) できます（スライド、ファイル、Web アドレス、メールへ遷移）。

**矩形の移動や変更から保護するには？**

[shape locks](/slides/ja/cpp/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択、テキスト編集を禁止し、レイアウトを保護できます。

**矩形をラスタ画像や SVG に変換できますか？**

はい。指定したサイズ/スケールでシェイプを画像に [render](http://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) したり、ベクタ用に [SVG としてエクスポート](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) したりできます。

**テーマや継承を考慮した矩形の実際の（有効）プロパティをすぐに取得するには？**

[シェイプの有効プロパティ](/slides/ja/cpp/shape-effective-properties/) を使用します。API がテーマスタイル、レイアウト、ローカル設定を考慮した計算値を返すため、書式分析が簡素化されます。
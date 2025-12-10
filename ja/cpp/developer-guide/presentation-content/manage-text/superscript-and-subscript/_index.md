---
title: C++ を使用したプレゼンテーションでの上付き文字と下付き文字の管理
linktitle: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/cpp/superscript-and-subscript/
keywords:
- 上付き文字
- 下付き文字
- 上付き文字の追加
- 下付き文字の追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++で上付き文字と下付き文字をマスターし、プレゼンテーションをプロフェッショナルなテキスト書式で最大のインパクトに高めましょう。"
---

## **上付き文字と下付き文字の管理**
任意の段落部分に上付き文字および下付き文字を追加できます。Aspose.Slides のテキストフレームで上付きまたは下付き文字を追加するには、PortionFormat クラスの **Escapement** プロパティを使用する必要があります。

このプロパティは、上付きまたは下付き文字（-100%（下付き）から 100%（上付き）までの値）を取得または設定します。例：

- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに Rectangle 種類の IAutoShape を追加します。
- IAutoShape に関連付けられた ITextFrame にアクセスします。
- 既存の Paragraph をクリアします。
- 上付き文字を保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します。
- 上付き文字を追加するために Escapement プロパティを 0 から 100 の範囲で設定します。（0 は上付きなし）
- Portion にテキストを設定し、段落の Portion コレクションに追加します。
- 下付き文字を保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します。
- 下付き文字を追加するために Escapement プロパティを 0 から -100 の範囲で設定します。（0 は下付きなし）
- Portion にテキストを設定し、段落の Portion コレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下の通りです。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**PDF や他の形式にエクスポートしたときに上付き文字と下付き文字は保持されますか？**

はい、Aspose.Slides は PDF、PPT/PPTX、画像、その他のサポート形式へエクスポートする際に、上付き文字と下付き文字の書式を正しく保持します。専門的な書式はすべての出力ファイルでそのまま残ります。

**上付き文字と下付き文字は太字や斜体など他の書式スタイルと組み合わせられますか？**

はい、Aspose.Slides は単一の Portion 内でさまざまなテキストスタイルを混在させることができます。太字、斜体、下線を有効にしながら、[PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) の該当プロパティを設定して上付きまたは下付き文字を同時に適用できます。

**テーブル、チャート、または SmartArt 内のテキストにも上付き文字と下付き文字の書式は適用できますか？**

はい、Aspose.Slides はテーブルやチャート要素を含むほとんどのオブジェクト内で書式設定をサポートしています。SmartArt を操作する場合は、[SmartArtNode](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartnode/) などの適切な要素とそのテキストコンテナにアクセスし、同様に [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) のプロパティを設定してください。
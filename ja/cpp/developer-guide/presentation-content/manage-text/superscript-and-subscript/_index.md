---
title: 上付き文字と下付き文字
type: docs
weight: 80
url: /cpp/superscript-and-subscript/
---

## **上付き文字と下付き文字のテキストを管理する**
任意の段落部分に上付き文字と下付き文字のテキストを追加できます。Aspose.Slides テキストフレームに上付き文字または下付き文字のテキストを追加するには、**Escapement** プロパティを PortionFormat クラスで使用する必要があります。

このプロパティは、上付き文字または下付き文字のテキストを返すか設定します (値は -100% (下付き文字) から 100% (上付き文字) まで)。例えば：

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに長方形型の IAutoShape を追加します。
- IAutoShape に関連付けられた ITextFrame にアクセスします。
- 既存の段落をクリアします。
- 上付き文字テキストを保持するための新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しいポーションオブジェクトを作成します。
- 上付き文字を追加するためにポーションの Escapement プロパティを 0 から 100 の間に設定します。(0 は上付き文字なしを意味します)
- ポーションにテキストを設定し、それを段落のポーションコレクションに追加します。
- 下付き文字テキストを保持するための新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しいポーションオブジェクトを作成します。
- 下付き文字を追加するためにポーションの Escapement プロパティを 0 から -100 の間に設定します。(0 は下付き文字なしを意味します)
- ポーションにテキストを設定し、それを段落のポーションコレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記のステップの実装は以下に示されています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}
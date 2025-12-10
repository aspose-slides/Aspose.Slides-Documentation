---
title: C++ でプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/cpp/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- 言語 ID
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ で PowerPoint および OpenDocument スライドのローカリゼーションを自動化し、実用的なコードサンプルとヒントでグローバル展開を迅速化します。"
---

## **プレゼンテーションとシェイプテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
- インデックスを使用してスライドの参照を取得します。  
- スライドに矩形タイプの AutoShape を追加します。  
- TextFrame にテキストを追加します。  
- テキストに Language Id を設定します。  
- プレゼンテーションを PPTX ファイルとして書き込みます。

上記手順の実装例は以下のとおりです。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**言語 ID は自動テキスト翻訳をトリガーしますか？**

いいえ。[Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) はスペルチェックと文法校正のための言語情報を保持しますが、テキスト内容を翻訳したり変更したりはしません。これは PowerPoint が校正のために認識するメタデータです。

**言語 ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides における [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) は校正用です。ハイフネーションの品質や行折り返しは主に [適切なフォント](/slides/ja/cpp/powerpoint-fonts/) の有無や、書字システムのレイアウト/改行設定に依存します。正しい表示を確保するには、必要なフォントを用意し、[フォント置換ルール](/slides/ja/cpp/font-substitution/) を設定するか、プレゼンテーションに [フォントを埋め込む](/slides/ja/cpp/embedded-font/) 必要があります。

**単一の段落内で異なる言語を設定できますか？**

はい。[Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) はテキスト部分レベルで適用されるため、単一の段落内でも複数の言語を混在させて個別の校正設定を行うことができます。
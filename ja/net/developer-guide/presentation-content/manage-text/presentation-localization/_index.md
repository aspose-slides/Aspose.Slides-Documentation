---
title: .NETでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーションローカリゼーション
type: docs
weight: 100
url: /ja/net/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- 言語 ID
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NETでPowerPointおよびOpenDocumentスライドのローカリゼーションを自動化し、実用的なC#コードサンプルと迅速なグローバル展開のためのヒントを提供します。"
---

## **プレゼンテーションとシェイプのテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに矩形タイプの AutoShape を追加します。
- TextFrame にテキストを追加します。
- テキストに Language Id を設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

上記の手順の実装例を以下に示します。
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**言語 ID は自動テキスト翻訳をトリガーしますか？**

いいえ。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) はスペルチェックと文法校正のための言語を格納しますが、テキストを翻訳したり内容を変更したりはしません。これは PowerPoint が校正のために理解するメタデータです。

**言語 ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) は校正目的です。ハイフネーションの品質や改行は主に、[proper fonts](/slides/ja/net/powerpoint-fonts/) の利用可能性と、書記体系に合わせたレイアウト/改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/net/font-substitution/) を設定するか、プレゼンテーションに[embed fonts](/slides/ja/net/embedded-font/) を埋め込んでください。

**1 つの段落内で異なる言語を設定できますか？**

はい。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) はテキスト部分レベルで適用されるため、単一の段落内で複数の言語を混在させ、個別の校正設定を使用できます。
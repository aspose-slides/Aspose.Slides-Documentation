---
title: .NET でプレゼンテーションのローカリゼーションを自動化する
linktitle: プレゼンテーション ローカリゼーション
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
description: ".NET で Aspose.Slides を使用し、実践的な C# コードサンプルとヒントで、PowerPoint および OpenDocument スライドのローカリゼーションを自動化し、グローバル展開を迅速化します。"
---

## **プレゼンテーションおよびシェイプ テキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに矩形タイプの AutoShape を追加します。
- TextFrame にテキストを追加します。
- テキストに Language Id を設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装は、以下の例で示されています。
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **よくある質問**

**言語 ID は自動テキスト翻訳をトリガーしますか？**

いいえ。Aspose.Slides の [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) は、スペルチェックや文法校正のための言語情報を保持しますが、テキストの内容を翻訳したり変更したりはしません。これは PowerPoint が校正用に理解するメタデータです。

**言語 ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) は校正用です。ハイフネーションの品質や改行は主に、[適切なフォント](/slides/ja/net/powerpoint-fonts/) の有無や、書記体系に合わせたレイアウト・改行設定に依存します。正しく表示させるには、必要なフォントを利用可能にし、[フォント置換ルール](/slides/ja/net/font-substitution/) を設定するか、またはプレゼンテーションに[フォントを埋め込む](/slides/ja/net/embedded-font/)ことが必要です。

**単一の段落内で異なる言語を設定できますか？**

はい。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) はテキストの部分レベルで適用されるため、単一の段落内で複数の言語を混在させ、それぞれ異なる校正設定を持たせることができます。
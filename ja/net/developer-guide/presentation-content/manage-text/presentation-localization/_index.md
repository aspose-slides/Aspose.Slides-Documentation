---
title: プレゼンテーションのローカリゼーション
type: docs
weight: 100
url: /ja/net/presentation-localization/
keywords: "言語の変更, スペルチェック, スペル チェック, スペルチェッカー, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションの言語を変更またはチェックします。C# または .NET でテキストのスペルチェックを行います。"
---

## **プレゼンテーションと図形テキストの言語を変更する**
- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
- インデックスを使用してスライドの参照を取得します。  
- スライドに矩形タイプの AutoShape を追加します。  
- TextFrame にテキストを追加します。  
- テキストに Language Id を設定します。  
- プレゼンテーションを PPTX ファイルとして書き出します。  

上記の手順の実装は以下の例で示します。  
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

**Language ID は自動テキスト翻訳をトリガーしますか？**

いいえ。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) はスペルチェックや文法校正のための言語を格納しますが、テキスト内容を翻訳したり変更したりはしません。PowerPoint が校正のために理解するメタデータです。

**Language ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) は校正用です。ハイフネーションの品質や行折り返しは主に適切なフォントの有無や、書き込みシステム向けのレイアウト/改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/net/font-substitution/) を設定し、または[embed fonts](/slides/ja/net/embedded-font/) をプレゼンテーションに埋め込んでください。

**単一の段落内で異なる言語を設定できますか？**

はい。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) はテキストの部分レベルで適用されるため、単一の段落内で複数の言語を混在させ、各言語に異なる校正設定を適用できます。

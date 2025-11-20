---
title: プレゼンテーションのローカリゼーション
type: docs
weight: 100
url: /ja/net/presentation-localization/
keywords: "言語を変更, スペルチェック, スペルチェック, スペルチェッカー, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションで言語を変更または確認します。C# または .NET でテキストのスペルチェックを行います"
---

## **プレゼンテーションとシェイプのテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに矩形タイプのAutoShapeを追加します。
- TextFrameにテキストを追加します。
- テキストにLanguage Idを設定します。
- プレゼンテーションをPPTXファイルとして書き出します。

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

**language_idは自動テキスト翻訳をトリガーしますか？**

いいえ。Aspose.Slides の [language_id](https://reference.aspose.com/slides/net/aspose.slides/portionformat/languageid/) はスペルチェックと文法校正のための言語情報を保持しますが、テキスト内容を翻訳したり変更したりはしません。これは PowerPoint が校正用に理解するメタデータです。

**language_idはレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) は校正用です。ハイフネーションの品質や改行は主に、[proper fonts](/slides/ja/net/powerpoint-fonts/) の利用可能性や、書記体系に対するレイアウト/改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/net/font-substitution/) を設定するか、またはプレゼンテーションに[embed fonts](/slides/ja/net/embedded-font/) を埋め込んでください。

**単一の段落内で異なる言語を設定できますか？**

はい。[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) はテキストの部分レベルで適用されるため、単一の段落内で複数の言語を混在させ、それぞれ異なる校正設定を使用できます。
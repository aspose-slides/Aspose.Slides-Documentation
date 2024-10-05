---
title: プレゼンテーションのローカリゼーション
type: docs
weight: 100
url: /net/presentation-localization/
keywords: "言語を変更する, スペルチェック, スペル チェック, スペル チェッカー, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションの言語を変更または確認します。C# または .NET でテキストのスペルチェック"
---
## **プレゼンテーションおよび図形のテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに長方形タイプのオートシェイプを追加します。
- テキストフレームにいくつかのテキストを追加します。
- テキストの言語 ID を設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装は、以下の例で示されています。

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("スペルチェック言語を適用するテキスト");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```
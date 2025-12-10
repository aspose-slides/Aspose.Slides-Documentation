---
title: ".NET の AutoFit でプレゼンテーションを強化"
linktitle: "AutoFit 設定"
type: docs
weight: 30
url: /ja/net/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- 自動調整なし
- テキストに合わせる
- テキストを縮小
- テキスト折り返し
- シェイプのサイズ変更
- PowerPoint
- プレゼンテーション
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET の AutoFit 設定を管理し、PowerPoint および OpenDocument のプレゼンテーションにおけるテキスト表示を最適化して、コンテンツの可読性を向上させる方法を学びましょう。"
---

## **概要**

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **Resize shape to fit text** 設定を使用します。テキストが常に収まるように、テキストボックスのサイズが自動的に調整されます。

![A textbox in PowerPoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くまたは大きくなると、PowerPoint はテキストボックスを自動的に拡大し（高さを増やし）、より多くのテキストを収められるようにします。
* テキストボックス内のテキストが短くまたは小さくなると、PowerPoint はテキストボックスを自動的に縮小し（高さを減らし）、余分な空間を削除します。

PowerPoint では、テキストボックスの自動調整動作を制御する 4 つの重要なパラメータまたはオプションがあります。

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Autofit options in PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET は、プレゼンテーション内のテキストボックスの自動調整動作を制御できる、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスのプロパティという形で同様のオプションを提供します。

## **テキストに合わせてシェイプのサイズを変更**

テキストが変更された後でも常に箱に収まるようにするには、**Resize shape to fit text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `Shape` に設定します。

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

以下の C# コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


テキストが長くまたは大きくなると、テキストボックスは自動的にサイズ変更（高さが増加）され、すべてのテキストが収まるようになります。テキストが短くなると、逆の処理が行われます。

## **自動調整しない**

テキストの内容が変化してもテキストボックスやシェイプのサイズをそのまま保持したい場合は、**Do not Autofit** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `None` に設定します。

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

以下の C# コードは、PowerPoint プレゼンテーションでテキストボックスが常にサイズを保持するように指定する方法を示しています：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


テキストがボックスに対して長すぎる場合、テキストがはみ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長すぎる場合、**Shrink text on overflow** オプションにより、テキストのサイズと行間を縮小してボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `Normal` に設定します。

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

以下の C# コードは、PowerPoint プレゼンテーションでテキストがオーバーフローした際に縮小されるように指定する方法を示しています：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Info" color="info" %}}
**Shrink text on overflow** オプションが使用されると、テキストがボックスに対して長くなった場合にのみ設定が適用されます。
{{% /alert %}}

## **テキストの折り返し**

テキストがシェイプの境界（幅のみ）を超える場合に、シェイプ内でテキストを折り返したい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `WrapText` プロパティを `NullableBool.True` に設定します。

以下の C# コードは、PowerPoint プレゼンテーションでテキストの折り返し設定を使用する方法を示しています：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}}
`WrapText` プロパティを `NullableBool.False` に設定したシェイプでは、シェイプ内のテキストが幅を超えると、テキストが単一行でシェイプの境界を超えて伸びます。
{{% /alert %}}

## **FAQ**

**テキストフレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit が早めに作動し、フォントが縮小されたりシェイプがリサイズされたりします。AutoFit を調整する前に余白を確認し、必要に応じて調整してください。

**AutoFit は手動改行やソフト改行とどのように連携しますか？**

強制的な改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズや行間を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する度合いが緩和されることが多いです。

**テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。異なる字形メトリックを持つフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや改行に影響します。フォントを変更または置換した後は、スライドを再確認してください。
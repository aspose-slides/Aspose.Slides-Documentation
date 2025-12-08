---
title: C# の AutoFit でプレゼンテーションを強化する
linktitle: AutoFit 設定の管理
type: docs
weight: 30
url: /ja/net/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- 自動調整しない
- テキストに合わせる
- テキストを縮小
- テキストの折り返し
- 図形のサイズ変更
- PowerPoint
- プレゼンテーション
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET で AutoFit 設定を管理し、PowerPoint および OpenDocument のプレゼンテーションにおけるテキスト表示を最適化してコンテンツの可読性を向上させる方法を学びます。"
---

## **概要**

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **Resize shape to fit text** 設定を使用します。テキストが常に収まるようにテキストボックスのサイズが自動的に変更されます。

![PowerPoint のテキストボックス](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くまたは大きくなると、PowerPoint はテキストボックスを自動的に拡大し（高さを増やし）、より多くのテキストを収められるようにします。
* テキストボックス内のテキストが短くまたは小さくなると、PowerPoint はテキストボックスの高さを減らして自動的に縮小し、余分なスペースを取り除きます。

PowerPoint では、テキストボックスの AutoFit 動作を制御する重要な 4 つのパラメータまたはオプションがあります：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![PowerPoint の AutoFit オプション](autofit-options-powerpoint.png)

Aspose.Slides for .NET は、プレゼンテーション内のテキストボックスの AutoFit 動作を制御できる、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスのプロパティという形で、同様のオプションを提供します。

## **テキストに合わせて図形のサイズを変更**

ボックス内のテキストを常にそのボックスに合わせたい場合は、**Resize shape to fit text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `Shape` に設定します。

![PowerPoint の「テキストに合わせて図形のサイズを変更」設定](alwaysfit-setting-powerpoint.png)

この C# コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています:
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

テキストボックスや図形のサイズを、テキストの変更に関係なく保持したい場合は、**Do not Autofit** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `None` に設定します。

![PowerPoint の「自動調整しない」設定](donotautofit-setting-powerpoint.png)

この C# コードは、PowerPoint プレゼンテーションでテキストボックスが常にサイズを保持するように指定する方法を示しています:
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


テキストがボックスに対して長くなりすぎると、テキストがはみ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長くなりすぎた場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと行間を縮小し、ボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `Normal` に設定します。

![PowerPoint の「オーバーフロー時にテキストを縮小」設定](shrinktextonoverflow-setting-powerpoint.png)

この C# コードは、PowerPoint プレゼンテーションでテキストがオーバーフローしたときに縮小されるように指定する方法を示しています:
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
**Shrink text on overflow** オプションが使用されると、テキストがボックスの幅を超えた場合にのみ設定が適用されます。
{{% /alert %}}

## **テキストの折り返し**

テキストが図形の幅を超えたときに、テキストをその図形内で折り返したい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `WrapText` プロパティを `NullableBool.True` に設定します。

この C# コードは、PowerPoint プレゼンテーションでテキストの折り返し設定を使用する方法を示しています:
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
`WrapText` プロパティを `NullableBool.False` に設定した場合、図形内のテキストが図形の幅より長くなると、テキストは単一行で図形の境界を超えて伸びます。
{{% /alert %}}

## **よくある質問**

**テキスト フレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit が早期に作動し、フォントが縮小されたり図形がリサイズされたりします。AutoFit を調整する前に余白を確認し、必要に応じて調整してください。

**AutoFit は手動改行やソフト改行とどのように連動しますか？**

強制改行はそのまま保持され、AutoFit はそれらの周囲でフォントサイズや行間を調整します。不要な改行を削除すると、AutoFit が過度にテキストを縮小する必要が減ります。

**テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。字形メトリクスが異なるフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや改行位置が変化する可能性があります。フォントを変更または置換した後は、必ずスライドを再確認してください。
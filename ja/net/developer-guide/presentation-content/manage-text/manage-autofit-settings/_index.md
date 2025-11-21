---
title: .NET の AutoFit でプレゼンテーションを強化
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/net/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- AutoFit しない
- テキストに合わせる
- テキストを縮小
- テキスト折り返し
- シェイプのサイズ変更
- PowerPoint
- プレゼンテーション
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET で AutoFit 設定を管理し、PowerPoint および OpenDocument のプレゼンテーションにおけるテキスト表示を最適化し、コンテンツの可読性を向上させる方法を学びます。"
---

## **概要**

既定では、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **Resize shape to fit text** 設定を使用します。テキストが常に収まるようにテキストボックスのサイズが自動的に調整されます。

![PowerPoint のテキストボックス](textbox-in-powerpoint.png)

- テキストボックス内のテキストが長くまたは大きくなると、PowerPoint はテキストボックスを自動的に拡大し（高さを増やし）、より多くのテキストを収められるようにします。
- テキストボックス内のテキストが短くまたは小さくなると、PowerPoint はテキストボックスを自動的に縮小し（高さを減らし）、余分なスペースを取り除きます。

PowerPoint では、テキストボックスの自動調整動作を制御する 4 つの重要なパラメータまたはオプションがあります：

- **Do not Autofit**
- **Shrink text on overflow**
- **Resize shape to fit text**
- **Wrap text in shape**

![PowerPoint の自動調整オプション](autofit-options-powerpoint.png)

Aspose.Slides for .NET は、プレゼンテーション内のテキストボックスの自動調整動作を制御できる、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスのプロパティという形で、同様のオプションを提供します。

## **テキストに合わせてシェイプのサイズを変更**

テキストが変更された後もテキストが常にボックス内に収まるようにしたい場合は、**Resize shape to fit text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `Shape` に設定します。

![テキストに合わせてシェイプのサイズを変更設定](alwaysfit-setting-powerpoint.png)

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


テキストが長くまたは大きくなると、テキストボックスは自動的にサイズが変更され（高さが増加し）、すべてのテキストが収まるようになります。テキストが短くなると、その逆が行われます。

## **Do Not Autofit**

テキストが変更されてもテキストボックスまたはシェイプのサイズを保持したい場合は、**Do not Autofit** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `None` に設定します。

![PowerPoint の「Do not Autofit」設定](donotautofit-setting-powerpoint.png)

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


テキストがボックスに対して長すぎると、テキストははみ出します。

## **Shrink Text on Overflow**

テキストがボックスに対して長すぎる場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと字間を縮小しボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `AutofitType` プロパティを `Normal` に設定します。

![PowerPoint の「Shrink text on overflow」設定](shrinktextonoverflow-setting-powerpoint.png)

この C# コードは、PowerPoint プレゼンテーションでテキストがオーバーフロー時に縮小されるように指定する方法を示しています:
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
**Shrink text on overflow** オプションが使用されると、テキストがボックスに対して長くなったときだけ設定が適用されます。
{{% /alert %}}

## **Wrap Text**

テキストがシェイプの幅を超えたときに、テキストをシェイプ内で折り返したい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの `WrapText` プロパティを `NullableBool.True` に設定します。

この C# コードは、PowerPoint プレゼンテーションで文字列折り返し設定を使用する方法を示しています:
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
シェイプの `WrapText` プロパティを `NullableBool.False` に設定すると、シェイプ内のテキストがシェイプの幅を超えたときに、テキストは1行のままシェイプの境界を超えて表示されます。
{{% /alert %}}

## **FAQ**

**テキストフレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）はテキストの使用可能領域を減少させるため、AutoFit が早期に作動し、フォントが縮小されたりシェイプがリサイズされたりします。AutoFit を調整する前に余白を確認・調整してください。

**AutoFit は手動改行やソフト改行とどのように連動しますか？**

強制改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズと字間を調整します。不必要な改行を削除すると、AutoFit がテキストを縮小する必要性が減少します。

**テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。字形メトリックが異なるフォントに置換すると、テキストの幅・高さが変わり、最終的なフォントサイズや折り返しが変化します。フォント変更や置換後はスライドを再確認してください。
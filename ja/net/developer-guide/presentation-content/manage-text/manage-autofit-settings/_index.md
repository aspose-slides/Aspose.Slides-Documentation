---
title: 自動調整設定の管理
type: docs
weight: 30
url: /ja/net/manage-autofit-settings/
keywords: "テキストボックス, 自動調整, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint のテキストボックスの自動調整設定を設定する"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **テキストに合わせて図形をサイズ変更** 設定を使用します—これは、テキストが常にテキストボックスに収まるように、自動的にテキストボックスのサイズを変更します。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くなったり大きくなったりすると、PowerPoint はテキストボックスを自動的に拡大し—高さを増加させて—より多くのテキストを保持できるようにします。
* テキストボックス内のテキストが短くなったり小さくなったりすると、PowerPoint はテキストボックスを自動的に縮小し—高さを減少させて—無駄なスペースを取り除きます。

PowerPoint では、テキストボックスの自動調整動作を制御するための 4 つの重要なパラメーターまたはオプションがあります:

* **自動調整しない**
* **オーバーフロー時にテキストを縮小**
* **テキストに合わせて図形をサイズ変更**
* **形状内でテキストを折り返す。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET では、プレゼンテーション内のテキストボックスの自動調整動作を制御できる、[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスのいくつかのプロパティに類似したオプションが提供されます。

## **テキストに合わせて図形をサイズ変更**

ボックス内のテキストが変更されても常にそのボックスに収まるようにしたい場合は、**テキストに合わせて図形をサイズ変更** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスから）を `Shape` に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

この C# コードは、PowerPoint プレゼンテーション内でテキストが常にボックスに収まるように指定する方法を示しています:

```c#
 using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

テキストが長くなったり大きくなったりした場合、テキストボックスは自動的にリサイズされ（高さが増加し）、すべてのテキストが収まるようにします。テキストが短くなると、反対のことが起こります。

## **自動調整しない**

テキストが変更されてもテキストボックスや図形の寸法を保持したい場合は、**自動調整しない** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスから）を `None` に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

この C# コードは、PowerPoint プレゼンテーション内でテキストボックスが常にその寸法を保持するように指定する方法を示しています:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

テキストがボックスに対して長すぎる場合、テキストはあふれ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長すぎる場合、**オーバーフロー時にテキストを縮小** オプションを使用すると、テキストのサイズと間隔を減少させて、ボックスに収まるように指定できます。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスから）を `Normal` に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

この C# コードは、PowerPoint プレゼンテーション内でテキストがオーバーフロー時に縮小されるように指定する方法を示しています:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="情報" color="info" %}}

**オーバーフロー時にテキストを縮小** オプションが使用される場合、設定はテキストがボックスに対して長すぎる場合にのみ適用されます。

{{% /alert %}}

## **テキストを折り返す**

テキストが形状の境界を超える場合（幅のみ）にテキストをその形状内で折り返したい場合は、**形状内でテキストを折り返す** パラメーターを使用する必要があります。この設定を指定するには、[WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスから）を `true` に設定する必要があります。

この C# コードは、PowerPoint プレゼンテーション内でテキストの折り返し設定を使用する方法を示しています:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 

形状の `WrapText` プロパティを `False` に設定すると、形状内のテキストが形状の幅を超えて長くなると、テキストは 1 行で形状の境界を超えて延長されます。

{{% /alert %}}
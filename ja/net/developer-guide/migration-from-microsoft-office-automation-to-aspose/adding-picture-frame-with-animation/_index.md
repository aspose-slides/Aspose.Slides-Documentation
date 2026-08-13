---
title: VSTO と Aspose.Slides for .NET を使用したアニメーション付きピクチャフレームの追加
linktitle: アニメーション付きピクチャフレーム
type: docs
weight: 60
url: /ja/net/adding-picture-frame-with-animation/
keywords:
- ピクチャフレーム
- 画像の追加
- 図の追加
- アニメーション付き画像
- アニメーション付き図
- 移行
- VSTO
- Office オートメーション
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office オートメーションから Aspose.Slides for .NET へ移行し、PowerPoint (PPT, PPTX) スライドでクリーンな C# コードを使用してピクチャフレームにアニメーションを付けます。"
---
{{% alert color="info" %}} 
Microsoft PowerPointでは、図形や画像にピクチャフレームを適用して、プレゼンテーション内の画像を枠で囲むことができます。この記事では、最初に[VSTO 2008](/slides/ja/net/adding-picture-frame-with-animation/) を使用し、その後[Aspose.Slides for .NET](/slides/ja/net/adding-picture-frame-with-animation/) を使用して、プログラムでピクチャフレームを作成しアニメーションを適用する方法を示します。まず、VSTO 2008 を使用してフレームとアニメーションを適用する方法を説明し、次に Aspose.Slides for .NET を使用して同じ手順を実行する方法を示します。
{{% /alert %}} 
## **アニメーション付きピクチャフレームの追加**
以下のコードサンプルは、スライドを1枚持つプレゼンテーションを作成し、ピクチャフレーム付きの画像を追加してアニメーションを適用します。
### **VSTO 2008 の例**
VSTO 2008 を使用して、次の手順を実行します：

1. プレゼンテーションを作成します。
1. 空のスライドを追加します。
1. スライドに画像シェイプを追加します。
1. 画像にアニメーションを適用します。
1. プレゼンテーションをディスクに書き出します。

**VSTO で作成された出力プレゼンテーション** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//空のプレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//空白のスライドを追加
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//ピクチャフレームを追加
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//ピクチャフレームにアニメーションを適用
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//プレゼンテーションを保存
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET の例**
Aspose.Slides for .NET を使用して、次の手順を実行します：

1. プレゼンテーションを作成します。
1. 最初のスライドにアクセスします。
1. 画像をピクチャコレクションに追加します。
1. スライドに画像シェイプを追加します。
1. 画像にアニメーションを適用します。
1. プレゼンテーションをディスクに書き出します。

**Aspose.Slides で作成された出力プレゼンテーション** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 空のプレゼンテーションを作成
using (Presentation pres = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // プレゼンテーションの画像コレクションに画像を追加
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 画像の高さと幅に合わせたピクチャフレームを追加
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // スライドのメインアニメーションシーケンスを取得
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // ピクチャフレームに左からのフライ アニメーション効果を追加
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // プレゼンテーションを保存
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
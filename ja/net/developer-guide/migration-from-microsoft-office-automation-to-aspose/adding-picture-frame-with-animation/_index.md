---
title: VSTO と Aspose.Slides for .NET を使用したアニメーション付き画像枠の追加
linktitle: アニメーション付き画像枠
type: docs
weight: 60
url: /ja/net/adding-picture-frame-with-animation/
keywords:
- 画像枠
- 画像を追加
- 画像を追加
- アニメーション付き画像
- アニメーション付き画像
- 移行
- VSTO
- Office自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET へ移行し、クリーンな C# コードで PowerPoint (PPT, PPTX) スライドの画像枠にアニメーションを付けます。"
---

{{% alert color="primary" %}} 

Picture frames は Microsoft PowerPoint の図形や画像に適用され、プレゼンテーション内の画像を枠で囲むために使用されます。本記事では、最初に [VSTO 2008](/slides/ja/net/adding-picture-frame-with-animation/) を使い、次に [Aspose.Slides for .NET](/slides/ja/net/adding-picture-frame-with-animation/) を使って、プログラムで画像枠を作成しアニメーションを適用する方法を示します。まず VSTO 2008 を使用して枠とアニメーションの適用方法を説明し、その後 Aspose.Slides for .NET で同じ手順を実行する方法を紹介します。

{{% /alert %}} 
## **画像枠の追加とアニメーションの適用**
以下のコードサンプルは、スライドを持つプレゼンテーションを作成し、画像に画像枠を付けてアニメーションを適用します。
### **VSTO 2008 の例**
VSTO 2008 を使用して、次の手順を実行します。

1. プレゼンテーションを作成します。
1. 空のスライドを追加します。
1. スライドに画像シェイプを追加します。
1. 画像にアニメーションを適用します。
1. プレゼンテーションをディスクに書き込みます。

**VSTO で作成された出力プレゼンテーション** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)
```c#
//空のプレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//空白のスライドを追加
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//画像枠を追加
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//画像枠にアニメーションを適用
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//プレゼンテーションを保存
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET の例**
Aspose.Slides for .NET を使用して、次の手順を実行します。

1. プレゼンテーションを作成します。
1. 最初のスライドにアクセスします。
1. 画像コレクションに画像を追加します。
1. スライドに画像シェイプを追加します。
1. 画像にアニメーションを適用します。
1. プレゼンテーションをディスクに書き込みます。

**Aspose.Slides で作成された出力プレゼンテーション** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
// 空のプレゼンテーションを作成
using (Presentation pres = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // プレゼンテーションの画像コレクションに画像を追加
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 画像の高さと幅に合わせた高さと幅の画像枠を追加
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // スライドのメインアニメーションシーケンスを取得
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 画像枠に左から飛び込むアニメーション効果を追加
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // プレゼンテーションを保存
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```

---
title: アニメーション付きの画像フレームの追加
type: docs
weight: 60
url: /net/adding-picture-frame-with-animation/
---

{{% alert color="primary" %}} 

画像フレームは、Microsoft PowerPointの図形や画像に適用され、プレゼンテーション内の画像を枠で囲みます。この記事では、まず[VSTO 2008](/slides/net/adding-picture-frame-with-animation/)を使用してプログラム的に画像フレームを作成し、その上にアニメーションを適用する方法を示し、その後[Aspose.Slides for .NET](/slides/net/adding-picture-frame-with-animation/)を使用した同様の手順を示します。最初に、VSTO 2008を使用してフレームとアニメーションを適用する方法を説明します。次に、Aspose.Slides for .NETを使用して同じ手順を実行する方法を示します。

{{% /alert %}} 
## **アニメーション付き画像フレームの追加**
以下のコードサンプルは、スライドを含むプレゼンテーションを作成し、画像に画像フレームを追加し、アニメーションを適用します。
### **VSTO 2008の例**
VSTO 2008を使用して、以下の手順を実行します：

1. プレゼンテーションを作成する。
1. 空のスライドを追加する。
1. スライドに画像形状を追加する。
1. 画像にアニメーションを適用する。
1. プレゼンテーションをディスクに保存する。

**VSTOを使用して作成された出力プレゼンテーション** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//空のプレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//空白のスライドを追加
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//画像フレームを追加
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//画像フレームにアニメーションを適用
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//プレゼンテーションを保存
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NETの例**
Aspose.Slides for .NETを使用して、以下の手順を実行します：

1. プレゼンテーションを作成する。
1. 最初のスライドにアクセスする。
1. 画像を画像コレクションに追加する。
1. スライドに画像形状を追加する。
1. 画像にアニメーションを適用する。
1. プレゼンテーションをディスクに保存する。

**Aspose.Slidesを使用して作成された出力プレゼンテーション** 

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

    // 画像の高さと幅に合わせた画像フレームを追加
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // スライドのメインアニメーションシーケンスを取得
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 画像フレームに左からの飛び出しアニメーション効果を追加
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // プレゼンテーションを保存
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
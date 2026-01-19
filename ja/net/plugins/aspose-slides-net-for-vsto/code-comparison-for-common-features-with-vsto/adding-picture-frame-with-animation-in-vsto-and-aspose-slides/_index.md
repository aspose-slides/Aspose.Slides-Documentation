---
title: VSTO および Aspose.Slides でアニメーション付き画像フレームの追加
type: docs
weight: 20
url: /ja/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

以下のコードサンプルは、スライドを含むプレゼンテーションを作成し、画像をピクチャーフレームで追加し、アニメーションを適用します。
## **VSTO**
VSTO を使用して、次の手順を実行します。

1. プレゼンテーションを作成します。  
2. 空のスライドを追加します。  
3. スライドに画像シェイプを追加します。  
4. 画像にアニメーションを適用します。  
5. プレゼンテーションをディスクに保存します。

``` csharp

 //Creating empty presentation

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Add a blank slide

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add Picture Frame

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applying animation on picture frame

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Saving Presentation

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Aspose.Slides for .NET を使用して、次の手順を実行します。

1. プレゼンテーションを作成します。  
2. 最初のスライドにアクセスします。  
3. 画像を画像コレクションに追加します。  
4. スライドに画像シェイプを追加します。  
5. 画像にアニメーションを適用します。  
6. プレゼンテーションをディスクに保存します。

``` csharp

 //Creating empty presentation

Presentation pres = new Presentation();

//Accessing the First slide

Slide slide = pres.GetSlideByPosition(1);

//Adding the picture object to pictures collection of the presentation

Picture pic = new Picture(pres, "pic.jpeg");

//After the picture object is added, the picture is given a uniqe picture Id

int picId = pres.Pictures.Add(pic);

//Adding Picture Frame

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Applying animation on picture frame

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Saving Presentation

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)
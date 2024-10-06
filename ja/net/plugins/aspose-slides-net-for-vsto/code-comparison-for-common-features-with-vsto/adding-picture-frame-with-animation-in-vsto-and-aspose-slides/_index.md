---  
title: VSTOとAspose.Slidesでアニメーション付きの画像フレームを追加する  
type: docs  
weight: 20  
url: /ja/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/  
---  

以下のコードサンプルは、スライドを持つプレゼンテーションを作成し、画像を画像フレームとともに追加し、それにアニメーションを適用します。  
## **VSTO**  
VSTOを使用して、次の手順を実行します：  

1. プレゼンテーションを作成します。  
1. 空のスライドを追加します。  
1. スライドに画像シェイプを追加します。  
1. 画像にアニメーションを適用します。  
1. プレゼンテーションをディスクに書き込みます。  

``` csharp

 //空のプレゼンテーションを作成  

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);  

//空のスライドを追加  

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);  

//画像フレームを追加  

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",  

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,  

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);  

//画像フレームにアニメーションを適用  

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;  

//プレゼンテーションを保存  

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,  

Microsoft.Office.Core.MsoTriState.msoFalse);  

```  
## **Aspose.Slides**  
.NET用のAspose.Slidesを使用して、次の手順を実行します：  

1. プレゼンテーションを作成します。  
1. 最初のスライドにアクセスします。  
1. 画像を画像コレクションに追加します。  
1. スライドに画像シェイプを追加します。  
1. 画像にアニメーションを適用します。  
1. プレゼンテーションをディスクに書き込みます。  

``` csharp

 //空のプレゼンテーションを作成  

Presentation pres = new Presentation();  

//最初のスライドにアクセス  

Slide slide = pres.GetSlideByPosition(1);  

//プレゼンテーションの画像コレクションに画像オブジェクトを追加  

Picture pic = new Picture(pres, "pic.jpeg");  

//画像オブジェクトが追加されると、画像にユニークな画像IDが付与されます  

int picId = pres.Pictures.Add(pic);  

//画像フレームを追加  

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);  

//画像フレームにアニメーションを適用  

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;  

//プレゼンテーションを保存  

pres.Write("AsposeAnim.ppt");  

```  
## **サンプルコードのダウンロード**  
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)  
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)  
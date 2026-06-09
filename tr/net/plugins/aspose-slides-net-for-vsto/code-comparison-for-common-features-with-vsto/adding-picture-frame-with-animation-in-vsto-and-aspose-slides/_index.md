---
title: VSTO ve Aspose.Slides ile Animasyonlu Resim Çerçevesi Ekleme
type: docs
weight: 20
url: /tr/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Aşağıdaki kod örnekleri bir slayt içeren bir sunum oluşturur, bir resim çerçevesiyle bir görüntü ekler ve ona animasyon uygular.
## **VSTO**
VSTO kullanarak aşağıdaki adımları izleyin:

1. Bir sunum oluşturun.
1. Boş bir slayt ekleyin.
1. Slayta bir resim şekli ekleyin.
1. Resme animasyon uygulayın.
1. Sunumu diske yazın.

``` csharp

 //Boş bir sunum oluşturma
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Boş bir slayt ekle
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);
//Resim Çerçevesi Ekle
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);
//Resim çerçevesine animasyon uygulama
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;
//Sunumu kaydetme
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);

```
## **Aspose.Slides**
Aspose.Slides for .NET kullanarak aşağıdaki adımları gerçekleştirin:

1. Bir sunum oluşturun.
1. İlk slayta erişin.
1. Resim koleksiyonuna bir görüntü ekleyin.
1. Slayta bir resim şekli ekleyin.
1. Resme animasyon uygulayın.
1. Sunumu diske yazın.

``` csharp

 //Boş bir sunum oluşturma

Presentation pres = new Presentation();

//İlk slayta erişim

Slide slide = pres.GetSlideByPosition(1);

//Sunumun resim koleksiyonuna resim nesnesi ekleniyor

Picture pic = new Picture(pres, "pic.jpeg");

//Resim nesnesi eklendikten sonra, resme benzersiz bir resim kimliği verilir

int picId = pres.Pictures.Add(pic);

//Resim Çerçevesi Ekleme

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Resim çerçevesine animasyon uygulama

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Sunumu kaydetme

pres.Write("AsposeAnim.ppt");

```
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)
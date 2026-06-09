---
title: VSTO ve Aspose.Slides for .NET Kullanarak Animasyonlu Resim Çerçeveleri Ekleme
linktitle: Animasyonlu Resim Çerçeveleri
type: docs
weight: 60
url: /tr/net/adding-picture-frame-with-animation/
keywords:
- resim çerçevesi
- resim ekle
- resim ekle
- animasyonlu resim
- animasyonlu resim
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for .NET'e geçin ve PowerPoint (PPT, PPTX) slaytlarında temiz C# kodu ile resim çerçevelerine animasyon ekleyin."
---
{{% alert color="primary" %}} 

Resim çerçeveleri, Microsoft PowerPoint'te şekillere veya resimlere uygulanarak bir sunumda görselleri çerçeveler. Bu makale, önce [VSTO 2008](/slides/tr/net/adding-picture-frame-with-animation/) ve ardından [Aspose.Slides for .NET](/slides/tr/net/adding-picture-frame-with-animation/) kullanarak bir resim çerçevesi oluşturmayı ve buna programlı olarak animasyon eklemeyi gösterir. İlk olarak, VSTO 2008 ile bir çerçeve ve animasyon nasıl uygulanır gösteriyoruz. Ardından aynı adımları Aspose.Slides for .NET ile nasıl gerçekleştireceğinizi gösteriyoruz.

{{% /alert %}} 
## **Resim Çerçevelerine Animasyon Ekleme**
Aşağıdaki kod örnekleri bir slayt içeren bir sunum oluşturur, bir resim çerçevesiyle bir resim ekler ve ona animasyon uygular.
### **VSTO 2008 Örneği**
VSTO 2008 kullanarak aşağıdaki adımları izleyin:

1. Bir sunum oluşturun.
1. Boş bir slayt ekleyin.
1. Slayta bir resim şekli ekleyin.
1. Resme animasyon uygulayın.
1. Sunumu diske kaydedin.

**VSTO ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Boş sunum oluşturma
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Boş bir slayt ekle
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Resim Çerçevesi Ekle
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Resim çerçevesine animasyon uygulama
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Sunumu Kaydetme
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET Örneği**
Aspose.Slides for .NET kullanarak aşağıdaki adımları gerçekleştirin:

1. Bir sunum oluşturun.
1. İlk slayta erişin.
1. Resmi bir resim koleksiyonuna ekleyin.
1. Slayta bir resim şekli ekleyin.
1. Resme animasyon uygulayın.
1. Sunumu diske kaydedin.

**Aspose.Slides ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
 // Boş bir sunum oluştur
using (Presentation pres = new Presentation())
{
    // İlk slayta eriş
    ISlide slide = pres.Slides[0];

    // Sunumun resim koleksiyonuna bir resim ekle
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Resmin yüksekliği ve genişliğiyle aynı yüksekliğe ve genişliğe sahip bir resim çerçevesi ekle
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Slaytın ana animasyon dizisini al
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Resim çerçevesine Soldan Uçuş animasyon etkisini ekle
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Sunumu kaydet
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
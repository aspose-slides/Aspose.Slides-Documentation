---
title: Sunuma Resim Çerçevesi Ekle
type: docs
weight: 50
url: /tr/net/add-picture-frame-to-presentation/
---
## **VSTO**
Aşağıda VSTO sunumuna resim eklemek için kod yer almaktadır:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Slaytınıza basit bir resim çerçevesi eklemek için lütfen aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
1. Dizinini kullanarak bir slaytın referansını alın.
1. Şekli doldurmak için kullanılacak, Presentation nesnesine bağlı Images koleksiyonuna bir resim ekleyerek bir Image nesnesi oluşturun.
1. Resmin genişliğini ve yüksekliğini hesaplayın.
1. Referans alınan slayta bağlı Shapes nesnesi tarafından sağlanan AddPictureFrame yöntemini kullanarak, resmin genişliği ve yüksekliği ile bir PictureFrame oluşturun.
1. Resmi içeren bir picture frame'i slayta ekleyin.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Yukarıdaki adımlar aşağıda verilen örnekte uygulanmıştır.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //PPTX'i temsil eden Presentation sınıfını örnekleyin
  Presentation pres = new Presentation();

  //İlk slaytı alın
  ISlide sld = pres.Slides[0];

  //ImageEx sınıfını örnekleyin
  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Resmin yüksekliği ve genişliğiyle eşdeğer bir Picture Frame ekleyin
  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Çalışan Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)
---
title: Kullanıcı Tanımlı Boyutlarla Bir Slayttan Küçük Resim Oluşturma
type: docs
weight: 100
url: /tr/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Aspose.Slides for .NET kullanarak istediğiniz bir slaytın küçük resmini oluşturmak için:

- Presentation sınıfının bir örneğini oluşturun.
- İstenen slaytın referansını, ID'sini ya da indeksini kullanarak alın.
- Kullanıcı tanımlı X ve Y boyutlarına göre X ve Y ölçekleme faktörlerini alın.
- Belirtilen ölçekte referans alınan slaytın küçük resim görüntüsünü alın.
- Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

## **Örnek**
```cs
//Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //İlk slayta erişin
    ISlide sld = pres.Slides[0];

    //Kullanıcı tanımlı boyut
    int desiredX = 1200;
    int desiredY = 800;

    //X ve Y'nin ölçeklenmiş değerini alıyor
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Tam ölçekli bir görüntü oluşturun
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Görüntüyü JPEG formatında diske kaydedin
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)

## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Daha fazla ayrıntı için [Slaytı Dönüştür](/slides/tr/net/convert-slide/).

{{% /alert %}}
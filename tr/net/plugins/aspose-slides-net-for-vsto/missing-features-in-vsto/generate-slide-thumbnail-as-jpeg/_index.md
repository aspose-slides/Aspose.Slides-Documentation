---
title: Slayt Küçük Resmini JPEG Olarak Oluştur
type: docs
weight: 90
url: /tr/net/generate-slide-thumbnail-as-jpeg/
---
Aspose.Slides for .NET kullanarak istediğiniz bir slaytın küçük resmini oluşturmak için:

- Presentation sınıfının bir örneğini oluşturun.
- İstenen slaytı ID'si veya diziniyle referans alın.
- Referans alınan slaytın belirtilen ölçeğe göre küçük resim görüntüsünü alın.
- Küçük resim görüntüsünü istediğiniz bir görüntü formatında kaydedin.
## **Örnek**
```cs
//Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //İlk slayta erişin
    ISlide sld = pres.Slides[0];

    //Tam ölçekli bir görüntü oluşturun
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Görüntüyü JPEG formatında diske kaydedin
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Daha fazla ayrıntı için, [PPT ve PPTX'i .NET'te JPG'ye Dönüştür](/slides/tr/net/convert-powerpoint-to-jpg/).
{{% /alert %}}
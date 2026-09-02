---
title: Kullanıcı Tanımlı Değerlerle Slaytı JPEG Küçük Resmi Olarak Oluştur
type: docs
weight: 70
url: /tr/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Aspose.Slides for .NET kullanarak istenen bir slaytın küçük resmini oluşturmak için:

1. **Presentation** sınıfının bir örneğini oluşturun.
1. İstenen slaytın referansını ID’si veya diziniyle alın.
1. Kullanıcı tarafından tanımlanan X ve Y boyutlarına göre X ve Y ölçek faktörlerini alın.
1. Belirtilen ölçekte referans alınan slaytın küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
using (Presentation pres = new Presentation(srcFileName))
{
    //İlk slayta erişin
    ISlide sld = pres.Slides[0];

    //Kullanıcı tanımlı boyut
    int desiredX = 1200;
    int desiredY = 800;

    //X ve Y’nin ölçekli değerleri alın
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Tam ölçekli bir görüntü oluşturun
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Görüntüyü JPEG formatında diske kaydedin
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)
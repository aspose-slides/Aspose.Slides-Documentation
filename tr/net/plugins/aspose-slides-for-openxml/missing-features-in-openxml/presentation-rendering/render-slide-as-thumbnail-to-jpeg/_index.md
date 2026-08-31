---
title: Slaytı Küçük Resim Olarak JPEG'e Dönüştür
type: docs
weight: 60
url: /tr/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET**, slaytları içeren sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, Microsoft PowerPoint kullanarak sunum dosyalarını açarak görüntülenebilir. Ancak bazen geliştiriciler, favori resim görüntüleyicileriyle slaytları resim olarak görmek isteyebilirler. Böyle durumlarda, Aspose.Slides for .NET slaytların küçük resimlerini oluşturmanıza yardımcı olur.

Aspose.Slides for .NET kullanarak istediğiniz herhangi bir slaydın küçük resmini oluşturmak için:

1. **Presentation** sınıfının bir örneğini oluşturun.  
1. İstediğiniz slaydın referansını, kimliğini (ID) veya dizinini kullanarak alın.  
1. Referans verilen slaydın belirtilen ölçekle küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir resim formatında kaydedin.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
using (Presentation pres = new Presentation(srcFileName))
{
    //İlk slayta eriş
    ISlide sld = pres.Slides[0];

    //Tam ölçekli bir resim oluştur
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Görüntüyü JPEG formatında diske kaydet
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)
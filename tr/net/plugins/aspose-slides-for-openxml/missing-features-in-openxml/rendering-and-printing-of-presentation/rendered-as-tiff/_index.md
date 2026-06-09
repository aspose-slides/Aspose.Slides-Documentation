---
title: TIFF Olarak Render Edildi
type: docs
weight: 30
url: /tr/net/rendered-as-tiff/
---
TIFF formatı, çok sayfalı görüntüleri ve verileri barındırma esnekliği ile bilinir. TIFF formatının önemi ve popülaritesi göz önünde bulundurularak, Aspose.Slides for .NET, sunumları TIFF belgesine dönüştürme desteği sağlar.
Bu makale, farklı TIFF dışa aktarma seçeneklerini nasıl kullanacağınızı açıklar:

- Sunumu varsayılan boyutta TIFF'e dönüştürme.
- Sunumu özel boyutta TIFF'e dönüştürme.

**Presentation** sınıfı tarafından sunulan **Save** yöntemi, geliştiriciler tarafından tüm sunumu **TIFF** belgesine dönüştürmek için çağrılabilir. Ayrıca, TiffOptions sınıfı, gerektiğinde geliştiricinin görüntünün boyutunu belirlemesine olanak tanıyan ImageSize özelliğini ortaya çıkarır.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Sunumu temsil eden bir Presentation nesnesi oluşturun

using (Presentation pres = new Presentation(srcFileName))

{

    //Sunumu TIFF belgesine kaydetme

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)
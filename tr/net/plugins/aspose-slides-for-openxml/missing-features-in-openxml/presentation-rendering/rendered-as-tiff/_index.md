---
title: TIFF Olarak Render Edildi
type: docs
weight: 30
url: /tr/net/rendered-as-tiff/
---
TIFF formatı çok sayfalı görüntü ve veri barındırabilme esnekliğiyle bilinir. TIFF formatının önemi ve popülaritesi göz önüne alındığında, Aspose.Slides for .NET sunumları TIFF belgesine dönüştürme desteği sağlar.
Bu makale, farklı TIFF dışa aktarma seçeneklerini açıklar:

- Varsayılan boyutla Sunumu TIFF'e dönüştürme.
- Özel boyutla Sunumu TIFF'e dönüştürme.

Geliştiriciler, tüm sunumu **TIFF** belgesine dönüştürmek için **Presentation** sınıfı tarafından sunulan **Save** metodunu çağırabilir. Ayrıca, TiffOptions sınıfı, gerekirse geliştiricinin görüntünün boyutunu tanımlamasını sağlayan ImageSize özelliğini açığa çıkar.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Sunum dosyasını temsil eden bir Presentation nesnesi örneği oluştur

using (Presentation pres = new Presentation(srcFileName))

{

    //Sunumu TIFF belgesine kaydet

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)
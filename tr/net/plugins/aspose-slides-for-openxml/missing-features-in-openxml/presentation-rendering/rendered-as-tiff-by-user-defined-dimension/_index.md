---
title: Kullanıcı Tanımlı Boyutla TIFF Olarak Oluşturuldu
type: docs
weight: 40
url: /tr/net/rendered-as-tiff-by-user-defined-dimension/
---
Aşağıdaki örnek, **TiffOptions** sınıfını kullanarak özelleştirilmiş görüntü boyutlarıyla bir sunumu TIFF belgesine nasıl dönüştüreceğinizi gösterir.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Bir Sunum dosyasını temsil eden Presentation nesnesi oluşturur

Presentation pres = new Presentation(srcFileName);

//TiffOptions sınıfını oluşturur

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Sıkıştırma türünü ayarlama

opts.CompressionType = TiffCompressionTypes.Default;

//Sıkıştırma Türleri

//Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.

//None - Sıkıştırma olmadığını belirtir.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - sıkıştırma türüne bağlıdır ve manuel olarak ayarlanamaz.

//Resolution unit - daima "2" (inç başına nokta) değerine eşittir.

//Resim DPI'sını ayarlama

opts.DpiX = 200;

opts.DpiY = 100;

//Görüntü Boyutunu Ayarla

opts.ImageSize = new Size(1728, 1078);

//Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydet

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)
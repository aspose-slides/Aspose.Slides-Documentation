---
title: Kullanıcı Tanımlı Boyutla TIFF Olarak Render Edildi
type: docs
weight: 40
url: /tr/net/rendered-as-tiff-by-user-defined-dimension/
---
Aşağıdaki örnek, **TiffOptions** sınıfını kullanarak özelleştirilmiş görüntü boyutuyla bir sunumu TIFF belgesine nasıl dönüştüreceğinizi gösterir.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Bir Presentation nesnesi oluşturur; bu nesne bir sunum dosyasını temsil eder
Presentation pres = new Presentation(srcFileName);

//TiffOptions sınıfının bir örneğini oluşturur
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Sıkıştırma türü ayarlanıyor
opts.CompressionType = TiffCompressionTypes.Default;

//Sıkıştırma Türleri
//Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
//None - Sıkıştırma olmadığını belirtir.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - sıkıştırma türüne bağlıdır ve manuel olarak ayarlanamaz.
//Resolution unit - her zaman "2" (inç başına nokta) değerine eşittir.

//Görüntü DPI'sı ayarlanıyor
opts.DpiX = 200;

opts.DpiY = 100;

//Görüntü Boyutunu Ayarla
opts.ImageSize = new Size(1728, 1078);

//Belirtilen görüntü boyutuyla sunumu TIFF olarak kaydet
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)
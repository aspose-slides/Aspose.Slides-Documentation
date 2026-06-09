---
title: XPS'ye Dönüştürme
type: docs
weight: 40
url: /tr/net/conversion-to-xps/
---
**XPS** formatı da veri alışverişi için yaygın olarak kullanılır. Aspose.Slides for .NET bu önemi göz önünde bulundurur ve bir sunumu XPS belgesine dönüştürmek için yerleşik destek sağlar.

Presentation sınıfı tarafından sunulan **Save** yöntemi, tüm sunumu **XPS** belgesine dönüştürmek için kullanılabilir. Ayrıca, **XpsOptions** sınıfı, gereksinime göre true veya false olarak ayarlanabilen **SaveMetafileAsPng** özelliğini ortaya çıkarır.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun

Presentation pres = new Presentation(srcFileName);

//Sunumu TIFF belgesine kaydet

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)
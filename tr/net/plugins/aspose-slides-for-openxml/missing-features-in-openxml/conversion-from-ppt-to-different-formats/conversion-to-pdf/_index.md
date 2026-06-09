---
title: PDF'ye Dönüştürme
type: docs
weight: 30
url: /tr/net/conversion-to-pdf/
---
PDF belgeleri, organizasyonlar, devlet kurumları ve bireyler arasında belge değişimi için yaygın olarak kullanılan bir standart formattır. Popüler bir format olduğu için geliştiricilerden Microsoft PowerPoint sunum dosyalarını PDF belgelerine dönüştürmeleri sıkça istenir. Bu olası ihtiyacı fark eden Aspose.Slides for .NET, sunumları başka bir bileşen kullanmadan PDF belgelerine dönüştürmeyi destekler.

**Aspose.Slides for .NET** bir sunum dosyasını temsil eden Presentation sınıfını sunar. **Presentation** sınıfı, tüm sunumu bir **PDF** belgesine dönüştürmek için çağrılabilecek Save yöntemini ortaya çıkarır. **PdfOptions** sınıfı, JpegQuality, TextCompression, Compliance ve diğerleri gibi **PDF** oluşturma seçenekleri sunar. Bu seçenekler, istenen PDF standardına ulaşmak için kullanılabilir.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun

Presentation pres = new Presentation(srcFileName);

//Sunumu varsayılan seçeneklerle PDF olarak kaydedin

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)
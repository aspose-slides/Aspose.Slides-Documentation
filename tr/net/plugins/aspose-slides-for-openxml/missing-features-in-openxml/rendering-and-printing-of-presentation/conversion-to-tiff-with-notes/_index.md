---
title: Notlarla Tiff Dönüştürme
type: docs
weight: 10
url: /tr/net/conversion-to-tiff-with-notes/
---
TIFF, Aspose.Slides for .NET'in notlarla bir sunumu görüntülere dönüştürmek için desteklediği birkaç yaygın kullanılan görüntü formatından biridir. Not Slaytı görünümünde slayt küçük resimleri de oluşturabilirsiniz. Aşağıda, Not Slaytı görünümünde bir sunumun TIFF görüntülerini nasıl oluşturacağınızı gösteren iki kod parçacığı bulunmaktadır.

**Presentation** sınıfı tarafından sunulan **Save** yöntemi, Not Slaytı görünümündeki tüm sunumu TIFF formatına dönüştürmek için kullanılabilir. Tek tek slaytlar için de Not Slaytı görünümünde slayt küçük resmi oluşturabilirsiniz.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin

Presentation pres = new Presentation(srcFileName);

//Sunumu TIFF notları olarak kaydediyor

pres.Save(destFileName, SaveFormat.TiffNotes);

```
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)
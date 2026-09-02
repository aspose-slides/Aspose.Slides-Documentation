---
title: Notlarla Tiff'e Dönüştürme
type: docs
weight: 10
url: /tr/net/conversion-to-tiff-with-notes/
---
TIFF, Aspose.Slides for .NET'in notlu bir sunumu görüntülere dönüştürmek için desteklediği yaygın olarak kullanılan birkaç görüntü formatından biridir. Not Slaytı görünümünde slayt küçük resimlerini de oluşturabilirsiniz. Aşağıda, Not Slaytı görünümünde bir sunumun TIFF görüntülerini nasıl oluşturacağınızı gösteren iki kod parçacığı bulunmaktadır.

**Presentation** sınıfı tarafından sunulan **Save** yöntemi, Not Slaytı görünümündeki tüm sunumu TIFF formatına dönüştürmek için kullanılabilir. Ayrı ayrı slaytlar için de Not Slaytı görünümünde slayt küçük resmi oluşturabilirsiniz.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Sunum dosyasını temsil eden bir Presentation nesnesi oluşturma
using (Presentation pres = new Presentation(srcFileName))
{
    //Her işlenen slaytın altında konuşmacı notlarını yerleştir
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Sunumu notlarla TIFF formatında kaydetme
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)
---
title: Slayt Sayısını Hesapla
type: docs
weight: 50
url: /tr/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Sunum nesnesini al ve bir sonraki CountSlides metoduna geçir.

public static int CountSlides(string presentationFile)

{

    // Sunumu sadece okunacak şekilde aç.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Sunumu bir sonraki CountSlide metoduna geçir

        // ve slayt sayısını döndür.

        return CountSlides(presentationDocument);

    }

}

// Sunumdaki slaytları say.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Boş (null) belge nesnesi var mı kontrol et.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Belgenin sunum kısmını al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts'dan slayt sayısını al.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Slayt sayısını önceki metoda döndür.

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //PPTX dosyasını temsil eden bir PresentationEx nesnesi oluştur.

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)
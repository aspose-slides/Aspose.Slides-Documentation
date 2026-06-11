---
title: Räkna antalet bilder
type: docs
weight: 50
url: /sv/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Hämta presentationsobjektet och skicka det till nästa CountSlides-metod.

public static int CountSlides(string presentationFile)

{

    // Öppna presentationen som skrivskyddad.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Skicka presentationen till nästa CountSlide-metod

        // och returnera bildantalet.

        return CountSlides(presentationDocument);

    }

}

// Räkna bilderna i presentationen.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kontrollera om dokumentobjektet är null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Hämta presentationsdelen av dokumentet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hämta bildantalet från SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Returnera bildantalet till föregående metod.

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

  //Instansiera ett PresentationEx-objekt som representerar en PPTX-fil

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)
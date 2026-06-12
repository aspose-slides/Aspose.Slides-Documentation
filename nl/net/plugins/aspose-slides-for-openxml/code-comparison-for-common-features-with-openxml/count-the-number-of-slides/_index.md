---
title: "Tel het aantal dia's"
type: docs
weight: 50
url: /nl/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Haal het presentatie-object op en geef het door aan de volgende CountSlides-methode.

public static int CountSlides(string presentationFile)

{

    // Open de presentatie als alleen-lezen.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Geef de presentatie door aan de volgende CountSlide-methode

        // en retourneer het aantal dia's.

        return CountSlides(presentationDocument);

    }

}

// Tel het aantal dia's in de presentatie.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Controleer op een null documentobject.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Haal het presentatiedeel van het document op.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Haal het aantal dia's op uit de SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retourneer het aantal dia's naar de vorige methode.

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

  //Instantieer een PresentationEx-object dat een PPTX-bestand vertegenwoordigt

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)
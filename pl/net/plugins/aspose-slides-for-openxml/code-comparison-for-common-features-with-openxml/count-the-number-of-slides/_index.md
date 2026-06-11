---
title: Policz liczbę slajdów
type: docs
weight: 50
url: /pl/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Pobierz obiekt prezentacji i przekaż go do kolejnej metody CountSlides.

public static int CountSlides(string presentationFile)

{

    // Otwórz prezentację w trybie tylko do odczytu.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Przekaż prezentację do kolejnej metody CountSlide

        // i zwróć liczbę slajdów.

        return CountSlides(presentationDocument);

    }

}

// Policz slajdy w prezentacji.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Sprawdź, czy obiekt dokumentu jest nullem.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Pobierz część prezentacji dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Pobierz liczbę slajdów z SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Zwróć liczbę slajdów do poprzedniej metody.

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

  //Utwórz obiekt PresentationEx, który reprezentuje plik PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)
---
title: Počítejte počet snímků
type: docs
weight: 50
url: /cs/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Získejte objekt prezentace a předávejte jej další metodě CountSlides.

public static int CountSlides(string presentationFile)

{

    // Otevřete prezentaci jen pro čtení.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Předáte prezentaci další metodě CountSlide

        // a vraťte počet snímků.

        return CountSlides(presentationDocument);

    }

}

// Spočítejte snímky v prezentaci.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Zkontrolujte, zda není objekt dokumentu null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Získejte část prezentace dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Získejte počet snímků ze SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Vraťte počet snímků předchozí metodě.

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

  //Instancujte objekt PresentationEx, který představuje soubor PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)
---
title: A diák számának meghatározása
type: docs
weight: 50
url: /hu/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Szerezze meg a prezentáció objektumot, és adja át a következő CountSlides metódusnak.

public static int CountSlides(string presentationFile)

{

    // Nyissa meg a prezentációt csak olvasásra.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Adja át a prezentációt a következő CountSlide metódusnak

        // és adja vissza a dia számát.

        return CountSlides(presentationDocument);

    }

}

// Számolja meg a diákat a prezentációban.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ellenőrizze, hogy a dokumentumobjektum null-e.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Szerezze meg a dokumentum prezentáció részét.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Szerezze meg a dia számát a SlideParts-ből.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Adja vissza a dia számát az előző metódusnak.

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

  //PPTX fájlt képviselő PresentationEx objektum példányosítása

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)
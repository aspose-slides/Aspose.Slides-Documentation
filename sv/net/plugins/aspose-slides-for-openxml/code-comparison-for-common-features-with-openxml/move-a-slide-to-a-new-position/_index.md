---
title: Flytta en bild till en ny position
type: docs
weight: 140
url: /sv/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Räknar bilderna i presentationen.

public static int CountSlides(string presentationFile)

{

    // Öppna presentationen som skrivskyddad.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Skicka presentationen till nästa CountSlides‑metod

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

    // Hämta presentation-delen av dokumentet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Hämta bildantalet från SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Returnera bildantalet till föregående metod.

    return slidesCount;

}

// Flytta en bild till en annan position i bildordningen i presentationen.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Flytta en bild till en annan position i bildordningen i presentationen.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Anropa CountSlides‑metoden för att få antalet bilder i presentationen.

    int slidesCount = CountSlides(presentationDocument);

    // Verifiera att både 'from'- och 'to'-positionerna är inom intervall och inte är lika.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Hämta presentation-delen från presentationsdokumentet.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Bildantalet är inte noll, så presentationen måste innehålla bilder.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Hämta bild-ID för källbilden.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Identifiera positionen för målbilden som källbilden ska flyttas efter.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Ta bort källbilden från dess nuvarande position.

    sourceSlide.Remove();

    // Sätt in källbilden på dess nya position efter målbilden.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Spara den modifierade presentationen.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Flytta en bild till en annan position i bildordningen i presentationen.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instansiera PresentationEx-klassen för att ladda käll-PPTX-filen

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Hämta bilden vars position ska ändras

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Ange den nya positionen för bilden

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Skriv PPTX-filen till disk

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Ladda ner exempel på kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)
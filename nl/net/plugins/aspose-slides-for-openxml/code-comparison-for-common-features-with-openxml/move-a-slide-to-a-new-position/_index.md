---
title: Verplaats een dia naar een nieuwe positie
type: docs
weight: 140
url: /nl/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Dia's tellen in de presentatie.

public static int CountSlides(string presentationFile)

{

    // Open de presentatie alleen-lezen.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Geef de presentatie door aan de volgende CountSlides-methode

        // en retourneer het aantal dia's.

        return CountSlides(presentationDocument);

    }

}

// Tel de dia's in de presentatie.

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

    // Retourneer het aantal dia's aan de vorige methode.

    return slidesCount;

}

// Verplaats een dia naar een andere positie in de volgorde van de presentatie.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Verplaats een dia naar een andere positie in de volgorde van de presentatie.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Roep de CountSlides-methode aan om het aantal dia's in de presentatie te verkrijgen.

    int slidesCount = CountSlides(presentationDocument);

    // Verifieer dat zowel de 'from'- als 'to'-posities binnen het bereik vallen en van elkaar verschillen.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Haal het presentatiedeel op uit het presentatiedocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Het aantal dia's is niet nul, dus de presentatie moet dia's bevatten.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Haal het slide-ID van de bron-dia op.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Bepaal de positie van de doel-dia waarna de bron-dia moet worden verplaatst.

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

    // Verwijder de bron-dia uit de huidige positie.

    sourceSlide.Remove();

    // Voeg de bron-dia in op de nieuwe positie na de doel-dia.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Sla de gewijzigde presentatie op.

    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Verplaats een dia naar een andere positie in de volgorde van de dia's in de presentatie.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instantieer PresentationEx-klasse om het bron-PPTX-bestand te laden

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Haal de dia op waarvan de positie moet worden gewijzigd

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Stel de nieuwe positie voor de dia in

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Schrijf het PPTX-bestand naar schijf

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)
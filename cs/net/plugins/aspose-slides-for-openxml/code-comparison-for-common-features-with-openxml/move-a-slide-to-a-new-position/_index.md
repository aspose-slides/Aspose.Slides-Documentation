---
title: Přesunout snímek na novou pozici
type: docs
weight: 140
url: /cs/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Počítání snímků v prezentaci.

public static int CountSlides(string presentationFile)

{

    // Otevřít prezentaci jen pro čtení.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Předat prezentaci další metodě CountSlides

        // a vrátit počet snímků.

        return CountSlides(presentationDocument);

    }

}

// Spočítat snímky v prezentaci.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Zkontrolovat, zda objekt dokumentu není null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Získat část prezentace z dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Získat počet snímků ze SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Vrátit počet snímků předchozí metodě.

    return slidesCount;

}

// Přesunout snímek na jinou pozici v pořadí snímků v prezentaci.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Přesunout snímek na jinou pozici v pořadí snímků v prezentaci.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Vyvolat metodu CountSlides pro získání počtu snímků v prezentaci.

    int slidesCount = CountSlides(presentationDocument);

    // Ověřit, že oba pozice od a do jsou v rozsahu a liší se navzájem.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Získat část prezentace z dokumentu prezentace.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Počet snímků není nula, takže prezentace musí obsahovat snímky.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Získat ID snímku zdrojového snímku.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Určit pozici cílového snímku, za který se má přesunout zdrojový snímek.

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

    // Odstranit zdrojový snímek z jeho aktuální pozice.

    sourceSlide.Remove();

    // Vložit zdrojový snímek na novou pozici za cílový snímek.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Uložit upravenou prezentaci.

    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Přesunout snímek na jinou pozici v pořadí snímků v prezentaci.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // Vytvořit instanci třídy PresentationEx pro načtení zdrojového souboru PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        // Získat snímek, jehož pozice má být změněna

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // Nastavit novou pozici pro snímek

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // Zapsat PPTX na disk

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)
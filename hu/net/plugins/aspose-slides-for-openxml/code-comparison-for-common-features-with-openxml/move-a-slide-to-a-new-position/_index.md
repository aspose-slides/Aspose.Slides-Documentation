---
title: Diapozitív áthelyezése új pozícióba
type: docs
weight: 140
url: /hu/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// A diákok számlálása a prezentációban.

public static int CountSlides(string presentationFile)

{

    // A prezentáció megnyitása csak olvasásra.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // A prezentáció átadása a következő CountSlides metódusnak

        // és visszaadja a diák számát.

        return CountSlides(presentationDocument);

    }

}

// Diákok számlálása a prezentációban.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Ellenőrizze, hogy a dokumentumobjektum null-e.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // A dokumentum prezentáció részének lekérése.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // A diák számának lekérése a SlideParts-ből.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // A diák számának visszaadása az előző metódusnak.

    return slidesCount;

}

// Diát áthelyez egy másik pozícióba a diák sorrendjében a prezentációban.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Diát áthelyez egy másik pozícióba a diák sorrendjében a prezentációban.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // A CountSlides metódus meghívása a prezentáció diák számának lekéréséhez.

    int slidesCount = CountSlides(presentationDocument);

    // Ellenőrizze, hogy a 'from' és 'to' pozíciók a tartományon belül vannak, és egymástól különböznek.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // A prezentáció részének lekérése a prezentáció dokumentumból.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // A diák száma nem nulla, ezért a prezentációnak diákot kell tartalmaznia.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // A forrás dia azonosítójának lekérése.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // A cél dia pozíciójának azonosítása, amely után a forrás diát áthelyezik.

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

    // A forrás dia eltávolítása a jelenlegi pozíciójából.

    sourceSlide.Remove();

    // A forrás dia beszúrása az új pozícióba a cél dia után.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // A módosított prezentáció mentése.

    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Diát áthelyez egy másik pozícióba a diák sorrendjében a prezentációban.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Az PresentationEx osztály példányosítása a forrás PPTX fájl betöltéséhez

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Az a dia lekérése, amelynek pozícióját módosítani kell

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //A dia új pozíciójának beállítása

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //A PPTX írása lemezre

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)
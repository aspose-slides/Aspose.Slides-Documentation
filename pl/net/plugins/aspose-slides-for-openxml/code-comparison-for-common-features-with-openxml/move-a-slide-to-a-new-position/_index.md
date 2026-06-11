---
title: Przenieś slajd na nową pozycję
type: docs
weight: 140
url: /pl/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Zliczanie slajdów w prezentacji.

public static int CountSlides(string presentationFile)

{

    // Otwórz prezentację w trybie tylko do odczytu.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Przekaż prezentację do kolejnej metody CountSlides

        // i zwróć liczbę slajdów.

        return CountSlides(presentationDocument);

    }

}

// Zliczanie slajdów w prezentacji.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Sprawdź, czy obiekt dokumentu jest null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Pobierz część prezentacji z dokumentu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Pobierz liczbę slajdów z SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Zwróć liczbę slajdów do poprzedniej metody.

    return slidesCount;

}

// Przenieś slajd na inną pozycję w kolejności slajdów w prezentacji.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Przenieś slajd na inną pozycję w kolejności slajdów w prezentacji.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Wywołaj metodę CountSlides, aby uzyskać liczbę slajdów w prezentacji.

    int slidesCount = CountSlides(presentationDocument);

    // Zweryfikuj, że pozycje od i do są w zakresie i różne od siebie.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Pobierz część prezentacji z dokumentu prezentacji.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Liczba slajdów nie jest zerowa, więc prezentacja musi zawierać slajdy.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Pobierz ID slajdu źródłowego.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Określ pozycję slajdu docelowego, po którym należy przenieść slajd źródłowy.

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

    // Usuń slajd źródłowy z jego bieżącej pozycji.

    sourceSlide.Remove();

    // Wstaw slajd źródłowy na nową pozycję po slajdzie docelowym.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Zapisz zmodyfikowaną prezentację.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Przenieś slajd na inną pozycję w kolejności slajdów w prezentacji.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Utwórz instancję klasy PresentationEx, aby wczytać źródłowy plik PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Pobierz slajd, którego pozycja ma zostać zmieniona

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Ustaw nową pozycję dla slajdu

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Zapisz plik PPTX na dysku

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)